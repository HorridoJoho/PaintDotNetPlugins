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
    public sealed class LinePointIterator
    {
	    // src is moved towards dst in Next()
	    private int _srcX;
	    private int _srcY;
	    private readonly int _dstX;
	    private readonly int _dstY;
	
	    private readonly int _dx;
	    private readonly int _dy;
	    private readonly int _sx;
	    private readonly int _sy;
	    private int _err;
	    private int _e2;
	
	    private bool _first;
	
	    public LinePointIterator(int srcX, int srcY, int dstX, int dstY)
	    {
		    _srcX = srcX;
		    _srcY = srcY;
		    _dstX = dstX;
		    _dstY = dstY;
		
		    _dx = Math.Abs(dstX - srcX);
		    _sx = srcX < dstX ? 1 : -1;
		    _dy = -Math.Abs(dstY - srcY);
		    _sy = srcY < dstY ? 1 : -1;
		    _err = _dx + _dy;
		    _e2 = 0;
		
		    _first = true;
	    }
	
	    public bool Next()
	    {
		    if (_first)
		    {
			    _first = false;
			    return true;
		    }
		    else if ((_srcX != _dstX) || (_srcY != _dstY))
		    {
			    _e2 = 2 * _err;
			    if (_e2 > _dy)
			    {
				    _err += _dy;
				    _srcX += _sx;
			    }
			
			    if (_e2 < _dx)
			    {
				    _err += _dx;
				    _srcY += _sy;
			    }
			    return true;
		    }
		
		    return false;
	    }
	
	    public int X
	    {
            get { return _srcX; }
	    }
	
	    public int Y
	    {
            get { return _srcY; }
	    }
    }
}
