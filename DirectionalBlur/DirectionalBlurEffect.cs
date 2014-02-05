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
using PDNP.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DirectionalBlur
{
    public sealed class DirectionalBlurEffect : PropertyBasedEffect
    {
        // precalculate some constants
        private const Double MAX_ANGLE_RADIANS = 2.0 * Math.PI;
        private const Double MAX_ANGLE_DEGREES = 360.0;

        private double _AngleOffset;
        private readonly BlurDescriptor[] _BlurDescriptors;

        public DirectionalBlurEffect()
            : base(Properties.Resources.PluginName, null, SubmenuNames.Blurs, EffectFlags.Configurable)
        {
            Properties.Resources.Culture = System.Globalization.CultureInfo.CurrentUICulture;
            _BlurDescriptors = new BlurDescriptor[4];
            for (uint i = 0; i < _BlurDescriptors.Length; ++i)
            {
                _BlurDescriptors[i] = new BlurDescriptor(i);
            }
        }

        private void _AddToColorChannels(ref UInt32 b, ref UInt32 g, ref UInt32 r, ref UInt32 a, ref UInt32 divisor, ref UInt32 divisorA, ColorBgra color)
        {
            if (color.A > 0)
            {
                b += color.B;
                g += color.G;
                r += color.R;
                a += color.A;
                ++divisor;
            }
            ++divisorA;
        }

        private void _ApplyAngleOffset(ref Double AngleDegrees)
        {
            AngleDegrees += _AngleOffset;
            while (AngleDegrees > MAX_ANGLE_DEGREES)
            {
                AngleDegrees -= MAX_ANGLE_DEGREES;
            }
        }

        protected override PropertyCollection OnCreatePropertyCollection()
        {
            List<Property> props = new List<Property>();
            List<PropertyCollectionRule> propRules = new List<PropertyCollectionRule>();

            props.Add(new DoubleProperty(Properties.Resources.AngleOffsetString, 0, 0, 360));

            foreach (BlurDescriptor BlurDescr in _BlurDescriptors)
            {
                // The three controls per blur descriptor
                props.Add(new BooleanProperty(BlurDescr.EnabledName, false));
                props.Add(new DoubleProperty(BlurDescr.AngleName, 0, 0, 360));
                props.Add(new Int32Property(BlurDescr.DistanceName, 0, 0, 1000));

                // The rules to disable angle chooser and distance slider
                propRules.Add(new ReadOnlyBoundToBooleanRule(BlurDescr.AngleName, BlurDescr.EnabledName, true));
                propRules.Add(new ReadOnlyBoundToBooleanRule(BlurDescr.DistanceName, BlurDescr.EnabledName, true));
            }

            return new PropertyCollection(props, propRules);
        }

        protected override ControlInfo OnCreateConfigUI(PropertyCollection props)
        {
            ControlInfo configUi = CreateDefaultConfigUI(props);

            configUi.SetPropertyControlType(Properties.Resources.AngleOffsetString, PropertyControlType.AngleChooser);

            foreach (BlurDescriptor BlurDescr in _BlurDescriptors)
            {
                // Make the angle control an AngleChooser
                configUi.SetPropertyControlType(BlurDescr.AngleName, PropertyControlType.AngleChooser);

                // Wipe out display name for angle chooser and distance slider, looks cleaner in the gui
                configUi.SetPropertyControlValue(BlurDescr.AngleName, ControlInfoPropertyNames.DisplayName, "");
                configUi.SetPropertyControlValue(BlurDescr.DistanceName, ControlInfoPropertyNames.DisplayName, "");
            }

            return configUi;
        }        

        protected override void OnSetRenderInfo(PropertyBasedEffectConfigToken newToken, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            _AngleOffset = newToken.GetProperty<DoubleProperty>(Properties.Resources.AngleOffsetString).Value;

            foreach (BlurDescriptor BlurDescr in _BlurDescriptors)
            {
                BlurDescr.Enabled = newToken.GetProperty<BooleanProperty>(BlurDescr.EnabledName).Value;

                Int32 Distance = newToken.GetProperty<Int32Property>(BlurDescr.DistanceName).Value;
                if (!BlurDescr.Enabled || Distance == 0)
                {
                    BlurDescr.Enabled = false;
                    continue;
                }

                // Precalculate X/Y modifiers so we save some time in the render loops
                Double AngleDegrees = newToken.GetProperty<DoubleProperty>(BlurDescr.AngleName).Value;
                _ApplyAngleOffset(ref AngleDegrees);
                Double AngleRadians = MAX_ANGLE_RADIANS * AngleDegrees / MAX_ANGLE_DEGREES;
                BlurDescr.YModifier = (Int32)(Math.Sin(AngleRadians) * Distance);
                BlurDescr.XModifier = (Int32)(Math.Cos(AngleRadians) * Distance);
            }

            base.OnSetRenderInfo(newToken, dstArgs, srcArgs);
        }

        protected override void OnRender(Rectangle[] renderRects, Int32 startIndex, Int32 length)
        {
            Surface src = SrcArgs.Surface;
            Surface dst = DstArgs.Surface;

            for (Int32 i = startIndex; i < startIndex + length; ++i)
            {
                Rectangle rect = renderRects[i];

                for (Int32 y = rect.Top; y < rect.Bottom; y++)
                {
                    for (Int32 x = rect.Left; x < rect.Right; x++)
                    {
                        ColorBgra color = src[x, y];
                        UInt32 newBlue = color.B;
                        UInt32 newGreen = color.G;
                        UInt32 newRed = color.R;
                        UInt32 newAlpha = color.A;
                        UInt32 divisor = 1;
                        UInt32 divisorA = 1;

                        foreach (BlurDescriptor BlurDescr in _BlurDescriptors)
                        {
                            if (!BlurDescr.Enabled)
                            {
                                continue;
                            }

                            // The line to blur with
                            LinePointIterator lpi = new LinePointIterator(x, y, x + BlurDescr.XModifier, y + BlurDescr.YModifier);
                            lpi.Next(); // skip original point

                            while (lpi.Next())
                            {
                                if (src.Bounds.Contains(lpi.X, lpi.Y))
                                {
                                    // accumulate b/g/r/a values
                                    _AddToColorChannels(ref newBlue, ref newGreen, ref newRed, ref newAlpha, ref divisor, ref divisorA, src[lpi.X, lpi.Y]);
                                }
                            }
                        }
                        

                        newBlue /= divisor;
                        newGreen /= divisor;
                        newRed /= divisor;
                        newAlpha /= divisorA;
                        
                        // Take the average from accumulated b/g/r/a as the destination color
                        dst[x, y] = ColorBgra.FromBgra((Byte)newBlue, (Byte)newGreen, (Byte)newRed, (Byte)newAlpha);
                    }
                }
            }
        }
    }
}