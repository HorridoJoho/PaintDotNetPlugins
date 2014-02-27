/*
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
			PdnRegion selection = EnvironmentParameters.GetSelection(srcArgs.Surface.Bounds);

            if (_Path == null)
            {
                Gpc.IPolygon poly = GpcProcessor.ClipRects(selection.GetRegionScans(), Gpc.ClipOp.Union, Gpc.GraphicsPathType.Polygons, this);
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

			if (Enum.IsDefined(typeof(PenFilling), token.SelectedTab))
			{
				PenFilling filling = (PenFilling)token.SelectedTab;

				switch (filling)
				{
					case PenFilling.Color:
					{
						_ContourPen = new Pen(token.Color_Color);
						break;
					}
					case PenFilling.Hatch:
					{
						_ContourPen = new Pen(new HatchBrush(token.Hatch_Style, token.Hatch_ForeColor, token.Hatch_BackColor));
						break;
					}
					case PenFilling.LinearGradient:
					{
						if (token.LinearGradient_Colors.Length < 2)
						{
							// we need at least 2 colors for the gradient
							_ContourPen = new Pen(token.Color_Color);
							break;
						}

						LinearGradientBrush brush = new LinearGradientBrush(_Path.GetBounds(), Color.Black, Color.Black, (Single)token.LinearGradient_Angle, true);
						brush.GammaCorrection = token.LinearGradient_GammaCorrection;

						if (token.LinearGradient_Colors.Length == 2)
						{
							brush.LinearColors = token.LinearGradient_Colors;
						}
						else
						{
							ColorBlend blend = new ColorBlend(token.LinearGradient_Colors.Length);
							blend.Colors = token.LinearGradient_Colors;
							Single[] positions = new Single[token.LinearGradient_Colors.Length];
							Single step = 1.0f / positions.Length;
							Single pos = 0.0f;
							for (int i = 0;i < positions.Length;++i)
							{
								if (i == positions.Length - 1)
								{
									positions[i] = 1.0f;
								}
								else
								{
									positions[i] = pos;
								}
								pos += step;
							}
							blend.Positions = positions;
							brush.InterpolationColors = blend;
						}

						_ContourPen = new Pen(brush);
						break;
					}
					case PenFilling.PathGradient:
					{
						PathGradientBrush brush = new PathGradientBrush(_Path);
						brush.CenterColor = token.PathGradient_CenterColor;
						if (token.PathGradient_SurroundingColors.Length > 0)
						{
							if (token.PathGradient_SurroundingColors.LongLength > _Path.PathData.Points.LongLength)
							{
								Color[] newColors = new Color[_Path.PathData.Points.Length];
								Array.Copy(token.PathGradient_SurroundingColors, newColors, _Path.PathData.Points.Length);
								brush.SurroundColors = newColors;
							}
							else
							{
								brush.SurroundColors = token.PathGradient_SurroundingColors;
							}
						}
						_ContourPen = new Pen(brush);
						break;
					}
					case PenFilling.Texture:
					{
						try
						{
							Image texture = Image.FromFile(token.Texture_File, true);
							TextureBrush brush = new TextureBrush(texture, token.Texture_WrapMode);

							Matrix m = new Matrix();
							RectangleF bounds = selection.GetBounds();
							PointF rotationPt = new PointF(bounds.X + texture.Width / 2, bounds.Y + texture.Height / 2);
							m.RotateAt((Single)token.Texture_Rotation, rotationPt);
							m.Translate((Single)token.Texture_TranslationX, (Single)token.Texture_TranslationY);
							brush.Transform = m;

							_ContourPen = new Pen(brush);
						}
						catch (Exception)
						{
							_ContourPen = new Pen(token.Color_Color);
						}
						break;
					}
					default:
					{
						_ContourPen = new Pen(token.Color_Color);
						break;
					}
				}
			}
			else
			{
				// as fallback we simply use normal color filling
				_ContourPen = new Pen(token.Color_Color);
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