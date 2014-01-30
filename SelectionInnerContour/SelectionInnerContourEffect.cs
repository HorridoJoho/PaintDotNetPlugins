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
using PaintDotNet.PropertySystem;
using PDNP.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SelectionInnerContour
{
    public sealed class SelectionInnerContourEffect : PropertyBasedEffect
    {
        private Int32 _Strength;
        private Boolean _Circular;
        private Int32 _HasRendered;

        public SelectionInnerContourEffect()
            : base(Properties.Resources.PluginName, null, SubmenuNames.Render, EffectFlags.Configurable | EffectFlags.SingleThreaded)
        {
            Properties.Resources.Culture = System.Globalization.CultureInfo.CurrentUICulture;
        }

        private bool IsStartingPoint(PdnRegion region, Int32 x, Int32 y)
        {
            if (
                !region.IsVisible(x - 1, y) ||
                !region.IsVisible(x + 1, y) ||
                !region.IsVisible(x, y - 1) ||
                !region.IsVisible(x, y + 1))
            {
                return true;
            }

            return false;
        }            

        protected override PropertyCollection OnCreatePropertyCollection()
        {
            List<Property> props = new List<Property>();

            props.Add(new Int32Property(Properties.Resources.StrengthString, 1, 1, 20));
            props.Add(new BooleanProperty(Properties.Resources.CircularString, false));

            return new PropertyCollection(props);
        }

        protected override void OnSetRenderInfo(PropertyBasedEffectConfigToken newToken, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            _Strength = newToken.GetProperty<Int32Property>(Properties.Resources.StrengthString).Value;
            _Circular = newToken.GetProperty<BooleanProperty>(Properties.Resources.CircularString).Value;

            _HasRendered = 0;
            
            base.OnSetRenderInfo(newToken, dstArgs, srcArgs);
        }

        protected override void OnRender(Rectangle[] renderRects, Int32 startIndex, Int32 length)
        {
            if (Interlocked.CompareExchange(ref _HasRendered, 1, 0) != 0)
            {
                return;
            }

            PdnRegion region = EnvironmentParameters.GetSelection(SrcArgs.Surface.Bounds);
            renderRects = region.GetRegionScansReadOnlyInt();
            Surface dst = DstArgs.Surface;

            dst.CopySurface(SrcArgs.Surface, region);

            foreach (Rectangle renderRect in renderRects)
            {
                for (Int32 y = renderRect.Top; y < renderRect.Bottom; ++y)
                {
                    for (Int32 x = renderRect.Left; x < renderRect.Right; ++x)
                    {
                        if (!IsStartingPoint(region, x, y))
                        {
                            continue;
                        }

                        if (_Circular)
                        {
                            dst.FillCircle(EnvironmentParameters.PrimaryColor, x, y, _Strength - 1, region);
                        }
                        else
                        {
                            dst.FillRect(EnvironmentParameters.PrimaryColor, x - (_Strength - 1), y - (_Strength - 1), _Strength * 2 - 1, _Strength * 2 - 1, region);
                        }
                    }
                }
            }
        }
    }
}