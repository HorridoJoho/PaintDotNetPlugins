using System;
using PaintDotNet;
using System.Drawing;

namespace PDNP.Utils
{
    public static class SurfaceDrawing
    {
        public static void DrawLine(this Surface dst, ColorBgra color, Point p1, Point p2, PdnRegion region = null)
        {
            DrawLine(dst, color, p1.X, p1.Y, p2.X, p2.Y, region);
        }

        public static void DrawLine(this Surface dst, ColorBgra color, Int32 x1, Int32 y1, Int32 x2, Int32 y2, PdnRegion region = null)
        {
            LinePointIterator lpi = new LinePointIterator(x1, y1, x2, y2);
            while (lpi.Next())
            {
                if (region == null || region.IsVisible(lpi.X, lpi.Y))
                {
                    dst[lpi.X, lpi.Y] = color;
                }
            }
        }

        public static void FillRect(this Surface dst, ColorBgra color, Rectangle rect, PdnRegion region = null)
        {
            FillRect(dst, color, rect.X, rect.Y, rect.Width, rect.Height, region);
        }

        public static void FillRect(this Surface dst, ColorBgra color, Int32 x, Int32 y, Int32 width, Int32 height, PdnRegion region = null)
        {
            for (Int32 xDraw = x; xDraw < x + width; ++xDraw)
            {
                for (Int32 yDraw = y; yDraw < y + height; ++yDraw)
                {
                    if (region == null || region.IsVisible(xDraw, yDraw))
                    {
                        dst[xDraw, yDraw] = color;
                    }
                }
            }
        }

        public static void FillCircle(this Surface dst, ColorBgra color, Point p, Int32 radius, PdnRegion region = null)
        {
            FillCircle(dst, color, p.X, p.Y, radius, region);
        }

        public static void FillCircle(this Surface dst, ColorBgra color, Int32 x, Int32 y, Int32 radius, PdnRegion region = null)
        {
            CirclePointIterator cpi = new CirclePointIterator(x, y, radius);
            while (cpi.Next())
            {
                DrawLine(dst, color, x, y, cpi.X, cpi.Y, region);
            }
        }
    }
}