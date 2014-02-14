﻿/*
 * Copyright (C) 2014 Christian Buck
 * https://github.com/HorridoJoho/PaintDotNetPlugins
 *
 * This software is provided 'as-is', without any express or implied warranty. In
 * no event will the authors be held liable for any damages arising from the use
 * of this software.
 *
 * Paint.NET is an image editing software. The original Paint.NET software can be
 * found at http://www.getpaint.net/. The license and copyright holders can be
 * found at http://www.getpaint.net/license.html.
 *
 * 1. Permission is granted to anyone to use this software in any environment,
 * including but not necessarily limited to: personal, academic, commercial,
 * government, business, non-profit, and for-profit, but only together with
 * the original Paint.NET software.
 *
 * 2. Permission is granted to anyone to alter the sourcecode of this software
 * and redistribute the sourcecode of this software, altered and unaltered, for
 * free. "Free" in the preceding sentence means that there is no cost or charge
 * associated with getting the sourcecode of this software.
 *
 * 3. Permission to distribute binary forms of this software, altered and
 * unaltered, is only granted to the copyright holders of Paint.NET.
 *
 * 4. This notice may not be removed or altered from any source distribution.
 */
using PaintDotNet;
using PaintDotNet.Effects;
using PaintDotNet.IndirectUI;
using PaintDotNet.PropertySystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;

namespace SelectionInnerContour
{
    sealed class SicEffect : Effect<SicToken>
    {
        internal enum PenFilling
        {
            Color,
            Hatch,
            LinearGradient,
            PathGradient,
            Texture
        }

        internal new Boolean IsCancelRequested
        {
            get { return base.IsCancelRequested; }
        }

        private GraphicsPath _Path = null;

        private Pen _ContourPen;
        private CompositingMode _Compositing;
        private Boolean _AntiAliasing;

        private Int32 _FirstRendererEntered;

        public SicEffect()
            : base(Properties.Resources.PluginName, null, Properties.Resources.SubmenuName_Selection, EffectFlags.Configurable | EffectFlags.SingleThreaded)
        {
            Properties.Resources.Culture = System.Globalization.CultureInfo.CurrentUICulture;
        }

		public override EffectConfigDialog CreateConfigDialog()
		{
			return new SicConfigDialog();
		}

        protected override void OnSetRenderInfo(SicToken token, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            if (_Path == null)
            {
                PdnRegion region = EnvironmentParameters.GetSelection(srcArgs.Surface.Bounds);
                Gpc.IPolygon poly = GpcProcessor.ClipRects(region.GetRegionScans(), Gpc.ClipOp.Union, Gpc.GraphicsPathType.Polygons, this);
                if (poly == null)
                {
                    // this only happens when the config ui got closed
                    return;
                }

                _Path = poly.ToGraphicsPath(Gpc.ContourType.All, Gpc.GraphicsPathType.Polygons);
            }

            if (_ContourPen != null)
            {
                _ContourPen.Dispose();
            }

			if (token.SelectedTab == (Int32)PenFilling.Color)
			{
				_ContourPen = new Pen(token.ColorFilling_Color);
			}
			else if (token.SelectedTab == (Int32)PenFilling.Hatch)
			{
				_ContourPen = new Pen(new HatchBrush(token.HatchFilling_Style, token.HatchFilling_ForeColor, token.HatchFilling_BackColor));
			}

			_ContourPen.Width = token.Width;
            _ContourPen.DashStyle = token.DashStyle;
            if (_ContourPen.DashStyle == DashStyle.Custom)
            {
                try
                {
                    String[] split = token.CustomDashStyle.Split(' ');
                    Single[] customDashStyleArray = new Single[split.Length];
                    for (int i = 0; i < split.Length; ++i)
                    {
                        customDashStyleArray[i] = Single.Parse(split[i]);
                    }
                    _ContourPen.DashPattern = customDashStyleArray;
                }
                catch (Exception)
                { }
            }
            _ContourPen.DashCap = token.DashCap;

			_Compositing = token.CompositingMode;
            _AntiAliasing = token.AntiAliasing;

            _FirstRendererEntered = 0;

            base.OnSetRenderInfo(token, dstArgs, srcArgs);
        }

        protected override void OnRender(Rectangle[] renderRects, Int32 startIndex, Int32 length)
        {
            if (IsCancelRequested)
            {
                return;
            }

            if (Interlocked.CompareExchange(ref _FirstRendererEntered, 1, 0) != 0)
            {
                return;
            }

            DstArgs.Surface.CopySurface(SrcArgs.Surface, EnvironmentParameters.GetSelection(SrcArgs.Surface.Bounds));

            if (_Path == null)
            {
                return;
            }

            Region oldClip = DstArgs.Graphics.Clip;
            SmoothingMode oldSmoothingMode = DstArgs.Graphics.SmoothingMode;
            CompositingMode oldCompositing = DstArgs.Graphics.CompositingMode;

            try
            {
                DstArgs.Graphics.Clip = EnvironmentParameters.GetSelection(SrcArgs.Surface.Bounds).GetRegionReadOnly();
                DstArgs.Graphics.SmoothingMode = _AntiAliasing ? SmoothingMode.AntiAlias : SmoothingMode.None;
                DstArgs.Graphics.CompositingMode = _Compositing;

                DstArgs.Graphics.DrawPath(_ContourPen, _Path);
            }
            finally
            {
                DstArgs.Graphics.CompositingMode = oldCompositing;
                DstArgs.Graphics.SmoothingMode = oldSmoothingMode;
                DstArgs.Graphics.Clip = oldClip;
            }
        }
    }
}