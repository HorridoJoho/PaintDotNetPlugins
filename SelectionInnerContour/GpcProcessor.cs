using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SelectionInnerContour
{
    internal static class GpcProcessor
    {
        private class ClipRectsData
        {
            public readonly Gpc.ClipOp ClipOp;
            public readonly SicEffect Effect;
            public readonly RectangleF[] Rects;
            public readonly Gpc.IPolygon[] Polygons;

            internal ClipRectsData(Gpc.ClipOp clipOp, SicEffect effect, RectangleF[] rects, Int32 nClippers)
            {
                ClipOp = clipOp;
                Effect = effect;
                Rects = rects;
                Polygons = new Gpc.IPolygon[nClippers];
            }
        }

        private class ClipRectsWorkerData
        {
            public readonly Int32 ClipperIndex;
            public readonly ClipRectsData ClipData;

            internal ClipRectsWorkerData(Int32 iClipper, ClipRectsData clipData)
            {
                ClipperIndex = iClipper;
                ClipData = clipData;
            }
        }

        private static void _ClipRectsWorker(Object obj)
        {
            ClipRectsWorkerData clipperData = (ClipRectsWorkerData)obj;

            Int32 nRectsPerWorker = clipperData.ClipData.Rects.Length / clipperData.ClipData.Polygons.Length;

            Int32 iStart = clipperData.ClipData.Rects.Length / clipperData.ClipData.Polygons.Length * clipperData.ClipperIndex;
            Int32 iEnd;
            if (clipperData.ClipperIndex == clipperData.ClipData.Polygons.Length - 1)
            {
                iEnd = clipperData.ClipData.Rects.Length - 1;
            }
            else
            {
                iEnd = iStart + nRectsPerWorker - 1;
            }

            Gpc.IPolygon finalPolygon = null;
            for (Int32 iRect = iStart; iRect <= iEnd; ++iRect)
            {
                if (clipperData.ClipData.Effect.IsCancelRequested)
                {
                    if (finalPolygon != null)
                    {
                        finalPolygon.Dispose();
                    }
                    return;
                }

                if (finalPolygon == null)
                {
                    finalPolygon = Gpc.PolygonFactory.Create();
                    finalPolygon.AddContour(
                        clipperData.ClipData.Rects[iRect].Location,
                        new PointF(clipperData.ClipData.Rects[iRect].Right, clipperData.ClipData.Rects[iRect].Top),
                        new PointF(clipperData.ClipData.Rects[iRect].Right, clipperData.ClipData.Rects[iRect].Bottom),
                        new PointF(clipperData.ClipData.Rects[iRect].Left, clipperData.ClipData.Rects[iRect].Bottom),
                        false);
                }
                else
                {
                    using (Gpc.IPolygon tmpPolygon = Gpc.PolygonFactory.Create())
                    {
                        tmpPolygon.AddContour(
                            clipperData.ClipData.Rects[iRect].Location,
                            new PointF(clipperData.ClipData.Rects[iRect].Right, clipperData.ClipData.Rects[iRect].Top),
                            new PointF(clipperData.ClipData.Rects[iRect].Right, clipperData.ClipData.Rects[iRect].Bottom),
                            new PointF(clipperData.ClipData.Rects[iRect].Left, clipperData.ClipData.Rects[iRect].Bottom),
                            false);

                        using (Gpc.IPolygon oldPolygon = finalPolygon)
                        {
                            finalPolygon = oldPolygon.ClipPolygon(tmpPolygon, clipperData.ClipData.ClipOp);
                        }
                    }
                }
            }

            clipperData.ClipData.Polygons[clipperData.ClipperIndex] = finalPolygon;
        }

        public static Gpc.IPolygon ClipRects(RectangleF[] rects, Gpc.ClipOp clipOp, Gpc.GraphicsPathType pathType, SicEffect effect)
        {
            Int32 nClippers = Math.Max(Environment.ProcessorCount - 1, 1);
            nClippers = Math.Min(nClippers, rects.Length);
            ClipRectsData clipperData = new ClipRectsData(clipOp, effect, rects, nClippers);
            if (nClippers == 1)
            {
                _ClipRectsWorker(new ClipRectsWorkerData(0, clipperData));
            }
            else
            {
                Thread[] clipperWorker = new Thread[nClippers - 1];
                for (Int32 iClipper = 0; iClipper < nClippers; ++iClipper)
                {
                    if (iClipper == nClippers - 1)
                    {
                        // invoke the last worker directly
                        _ClipRectsWorker(new ClipRectsWorkerData(iClipper, clipperData));
                    }
                    else
                    {
                        clipperWorker[iClipper] = new Thread(_ClipRectsWorker);
                        clipperWorker[iClipper].Start(new ClipRectsWorkerData(iClipper, clipperData));
                    }
                }

                for (Int32 iComposer = 0; iComposer < nClippers - 1; ++iComposer)
                {
                    clipperWorker[iComposer].Join();
                }
            }

            Gpc.IPolygon finalPolygon = null;
            for (Int32 iPolygon = 0; iPolygon < clipperData.Polygons.Length; ++iPolygon)
            {
                if (clipperData.Effect.IsCancelRequested)
                {
                    if (finalPolygon != null)
                    {
                        finalPolygon.Dispose();
                    }
                    return null;
                }

                if (finalPolygon == null)
                {
                    finalPolygon = clipperData.Polygons[iPolygon];
                }
                else
                {
                    using (Gpc.IPolygon tmpPolygon = clipperData.Polygons[iPolygon])
                    {
                        using (Gpc.IPolygon oldPolygon = finalPolygon)
                        {
                            finalPolygon = oldPolygon.ClipPolygon(tmpPolygon, clipperData.ClipOp);
                        }
                    }
                }
            }

            return finalPolygon;
        }
    }
}
