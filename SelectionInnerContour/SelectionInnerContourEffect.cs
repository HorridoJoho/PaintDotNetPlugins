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
    public sealed class SelectionInnerContourEffect : PropertyBasedEffect
    {
        internal enum PenFilling
        {
            Color,
            Hatch,
            LinearGradient,
            PathGradient
        }

        internal new Boolean IsCancelRequested
        {
            get { return base.IsCancelRequested; }
        }

        private GraphicsPath _Path = null;

        private Int32 _Width;

        private Pen _ContourPen;
        private Boolean _AntiAliasing;

        private Int32 _FirstRendererEntered;

        public SelectionInnerContourEffect()
            : base(Properties.Resources.PluginName, null, Properties.Resources.SubmenuName_Selection, EffectFlags.Configurable | EffectFlags.SingleThreaded)
        {
            Properties.Resources.Culture = System.Globalization.CultureInfo.CurrentUICulture;
        }

        protected override PropertyCollection OnCreatePropertyCollection()
        {
            List<Property> props = new List<Property>();
            props.Add(new Int32Property(Properties.Resources.PenWidthString, 1, 1, 1000));
            //props.Add(StaticListChoiceProperty.CreateForEnum<LineCap>(Properties.Resources.PenStartCapString, LineCap.Flat, false));
            //props.Add(StaticListChoiceProperty.CreateForEnum<LineCap>(Properties.Resources.PenEndCapString, LineCap.Flat, false));
            props.Add(StaticListChoiceProperty.CreateForEnum<DashStyle>(Properties.Resources.PenDashStyleString, DashStyle.Solid, false));
            props.Add(StaticListChoiceProperty.CreateForEnum<DashCap>(Properties.Resources.PenDashCapString, DashCap.Flat, false));
            props.Add(StaticListChoiceProperty.CreateForEnum<PenFilling>(Properties.Resources.PenFillingString, PenFilling.Color, false));
            props.Add(new Int32Property(Properties.Resources.ForegroundColorString, 0, 0, 16777215));
            props.Add(new Int32Property(Properties.Resources.ForegroundOpacityString, 255, 0, 255));
            props.Add(new Int32Property(Properties.Resources.BackgroundColorString, 0, 0, 16777215));
            props.Add(new Int32Property(Properties.Resources.BackgroundOpacityString, 255, 0, 255));
            props.Add(StaticListChoiceProperty.CreateForEnum<HatchStyle>(Properties.Resources.HatchStyleString, HatchStyle.Min, false));
            props.Add(new DoubleProperty(Properties.Resources.GradientAngleString, 0, 0, 360));
            props.Add(new BooleanProperty(Properties.Resources.AntiAliasingString, false));

            List<PropertyCollectionRule> propRules = new List<PropertyCollectionRule>();
            propRules.Add(new ReadOnlyBoundToValueRule<Object, StaticListChoiceProperty>(Properties.Resources.BackgroundColorString, Properties.Resources.PenFillingString, PenFilling.Color, false));
            propRules.Add(new ReadOnlyBoundToValueRule<Object, StaticListChoiceProperty>(Properties.Resources.BackgroundOpacityString, Properties.Resources.PenFillingString, PenFilling.Color, false));
            propRules.Add(new ReadOnlyBoundToValueRule<Object, StaticListChoiceProperty>(Properties.Resources.HatchStyleString, Properties.Resources.PenFillingString, new Object[]{PenFilling.Color, PenFilling.LinearGradient, PenFilling.PathGradient}, false));
            propRules.Add(new ReadOnlyBoundToValueRule<Object, StaticListChoiceProperty>(Properties.Resources.GradientAngleString, Properties.Resources.PenFillingString, new Object[] { PenFilling.Color, PenFilling.Hatch, PenFilling.PathGradient }, false));

            return new PropertyCollection(props, propRules);
        }

        protected override ControlInfo OnCreateConfigUI(PropertyCollection props)
        {
            ControlInfo configUi = CreateDefaultConfigUI(props);

            configUi.SetPropertyControlType(Properties.Resources.ForegroundColorString, PropertyControlType.ColorWheel);
            configUi.SetPropertyControlType(Properties.Resources.BackgroundColorString, PropertyControlType.ColorWheel);
            configUi.SetPropertyControlType(Properties.Resources.GradientAngleString, PropertyControlType.AngleChooser);

            return configUi;
        }

        protected override void OnSetRenderInfo(PropertyBasedEffectConfigToken newToken, RenderArgs dstArgs, RenderArgs srcArgs)
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

            _Width = newToken.GetProperty<Int32Property>(Properties.Resources.PenWidthString).Value;
            //LineCap startCap = (LineCap)newToken.GetProperty<StaticListChoiceProperty>(Properties.Resources.PenStartCapString).Value;
            //LineCap endCap = (LineCap)newToken.GetProperty<StaticListChoiceProperty>(Properties.Resources.PenEndCapString).Value;
            DashStyle dashStyle = (DashStyle)newToken.GetProperty<StaticListChoiceProperty>(Properties.Resources.PenDashStyleString).Value;
            DashCap dashCap = (DashCap)newToken.GetProperty<StaticListChoiceProperty>(Properties.Resources.PenDashCapString).Value;
            PenFilling filling = (PenFilling)newToken.GetProperty<StaticListChoiceProperty>(Properties.Resources.PenFillingString).Value;
            ColorBgra foregroundColor = ColorBgra.FromOpaqueInt32(newToken.GetProperty<Int32Property>(Properties.Resources.ForegroundColorString).Value);
            foregroundColor.A = (Byte)newToken.GetProperty<Int32Property>(Properties.Resources.ForegroundOpacityString).Value;

            if (_ContourPen != null)
            {
                _ContourPen.Dispose();
            }

            if (filling == PenFilling.Hatch)
            {
                ColorBgra backgroundColor = ColorBgra.FromOpaqueInt32(newToken.GetProperty<Int32Property>(Properties.Resources.BackgroundColorString).Value);
                backgroundColor.A = (Byte)newToken.GetProperty<Int32Property>(Properties.Resources.BackgroundOpacityString).Value;
                HatchStyle hatchStyle = (HatchStyle)newToken.GetProperty<StaticListChoiceProperty>(Properties.Resources.HatchStyleString).Value;
                HatchBrush brush = new HatchBrush(hatchStyle, foregroundColor, backgroundColor);
                _ContourPen = new Pen(brush, _Width);
            }
            else if (filling == PenFilling.LinearGradient)
            {
                ColorBgra backgroundColor = ColorBgra.FromOpaqueInt32(newToken.GetProperty<Int32Property>(Properties.Resources.BackgroundColorString).Value);
                backgroundColor.A = (Byte)newToken.GetProperty<Int32Property>(Properties.Resources.BackgroundOpacityString).Value;
                Single angle = (Single)newToken.GetProperty<DoubleProperty>(Properties.Resources.GradientAngleString).Value;
                if (angle >= 360.0f)
                {
                    angle -= 360.0f;
                }
                LinearGradientBrush brush = new LinearGradientBrush(srcArgs.Surface.Bounds, foregroundColor, backgroundColor, angle);
                _ContourPen = new Pen(brush, _Width);
            }
            else if (filling == PenFilling.PathGradient)
            {
                ColorBgra backgroundColor = ColorBgra.FromOpaqueInt32(newToken.GetProperty<Int32Property>(Properties.Resources.BackgroundColorString).Value);
                backgroundColor.A = (Byte)newToken.GetProperty<Int32Property>(Properties.Resources.BackgroundOpacityString).Value;
                Single angle = (Single)newToken.GetProperty<DoubleProperty>(Properties.Resources.GradientAngleString).Value;
                PathGradientBrush brush = new PathGradientBrush(_Path);
                brush.CenterColor = foregroundColor;
                brush.SurroundColors = new Color[]{backgroundColor};
                _ContourPen = new Pen(brush, _Width);
            }
            else
            {
                _ContourPen = new Pen(foregroundColor, _Width);
            }
            _ContourPen.DashStyle = dashStyle;
            _ContourPen.DashCap = dashCap;

            _AntiAliasing = newToken.GetProperty<BooleanProperty>(Properties.Resources.AntiAliasingString).Value;

            _FirstRendererEntered = 0;
            
            base.OnSetRenderInfo(newToken, dstArgs, srcArgs);
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

            try
            {
                DstArgs.Graphics.Clip = EnvironmentParameters.GetSelection(SrcArgs.Surface.Bounds).GetRegionReadOnly();
                DstArgs.Graphics.SmoothingMode = _AntiAliasing ? SmoothingMode.AntiAlias : SmoothingMode.None;

                DstArgs.Graphics.DrawPath(_ContourPen, _Path);
            }
            finally
            {
                DstArgs.Graphics.SmoothingMode = oldSmoothingMode;
                DstArgs.Graphics.Clip = oldClip;
            }
        }
    }
}