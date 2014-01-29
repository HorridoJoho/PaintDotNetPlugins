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
using System;

namespace DirectionalBlur
{
    sealed class BlurDescriptor
    {
        public readonly String EnabledName;
        public readonly String AngleName;
        public readonly String DistanceName;

        public Boolean Enabled;
        public Int32 XModifier;
        public Int32 YModifier;

        public BlurDescriptor(UInt32 index)
        {
            EnabledName = Properties.Resources.BlurString + " " + (index + 1);
            AngleName = Properties.Resources.BlurString + " " + (index + 1) + " Angle";
            DistanceName = Properties.Resources.BlurString + " " + (index + 1) + " Distance";
        }
    }
}
