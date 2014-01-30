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

namespace PDNP.Utils
{
    public class CirclePointIterator
    {
        private Int32 _SrcX;
        private Int32 _SrcY;
        private Int32 _Radius;

        private Int32 _f;
        private Int32 _ddF_x;
        private Int32 _ddF_y;
        private Int32 _x;
        private Int32 _y;

        private Boolean _InitialPoints;
        Int32 _iPoint;
        Int32 _OutX;
        Int32 _OutY;

        public CirclePointIterator(Int32 x, Int32 y, Int32 radius)
        {
            _SrcX = x;
            _SrcY = y;
            _Radius = Math.Abs(radius);

            _f = 1 - _Radius;
            _ddF_x = 0;
            _ddF_y = -2 * _Radius;
            _x = 0;
            _y = _Radius;

            _InitialPoints = true;
            _iPoint = 0;
        }

        public bool Next()
        {
            if (_InitialPoints)
            {
                if (_Radius == 0)
                {
                    _OutX = _SrcX;
                    _OutY = _SrcY;

                    // make the next call return false
                    _iPoint = -1;
                    _x = _y;
                    _InitialPoints = false;

                    return true;
                }

                switch (_iPoint)
                {
                    case 0:
                        _OutX = _SrcX;
                        _OutY = _SrcY + _Radius;
                        break;
                    case 1:
                        _OutX = _SrcX;
                        _OutY = _SrcY - _Radius;
                        break;
                    case 2:
                        _OutX = _SrcX + _Radius;
                        _OutY = _SrcY;
                        break;
                    case 3:
                        _OutX = _SrcX + _Radius;
                        _OutY = _SrcY;
                        break;
                }

                if (_iPoint == 3)
                {
                    _iPoint = -1;
                    _InitialPoints = false;
                }
                else
                {
                    ++_iPoint;
                }

                return true;
            }
            else if (_x < _y || _iPoint > -1)
            {
                if (_iPoint == -1)
                {
                    if (_f > 0)
                    {
                        _y--;
                        _ddF_y += 2;
                        _f += _ddF_y;
                    }

                    _x++;
                    _ddF_x += 2;
                    _f += _ddF_x + 1;

                    _iPoint = 0;
                }

                switch (_iPoint)
                {
                    case 0:
                        // x0 + x, y0 + y
                        _OutX = _SrcX + _x;
                        _OutY = _SrcY + _y;
                        break;
                    case 1:
                        // x0 - x, y0 + y
                        _OutX = _SrcX - _x;
                        _OutY = _SrcY + _y;
                        break;
                    case 2:
                        // x0 + x, y0 - y
                        _OutX = _SrcX + _x;
                        _OutY = _SrcY - _y;
                        break;
                    case 3:
                        // x0 - x, y0 - y
                        _OutX = _SrcX - _x;
                        _OutY = _SrcY - _y;
                        break;
                    case 4:
                        // x0 + y, y0 + x
                        _OutX = _SrcX + _y;
                        _OutY = _SrcY + _x;
                        break;
                    case 5:
                        // x0 - y, y0 + x
                        _OutX = _SrcX - _y;
                        _OutY = _SrcY + _x;
                        break;
                    case 6:
                        // x0 + y, y0 - x
                        _OutX = _SrcX + _y;
                        _OutY = _SrcY - _x;
                        break;
                    case 7:
                        // x0 - y, y0 - x
                        _OutX = _SrcX - _y;
                        _OutY = _SrcY - _x;
                        break;
                }

                if (_iPoint == 7)
                {
                    _iPoint = -1;
                }
                else
                {
                    ++_iPoint;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public int X
        {
            get { return _OutX; }
        }

        public int Y
        {
            get { return _OutY; }
        }
    }
}
