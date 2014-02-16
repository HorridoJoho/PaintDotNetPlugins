using PaintDotNet.Effects;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SelectionInnerContour
{
	internal class SicToken : EffectConfigToken
	{
		public Single			Width			= 100;
		public DashStyle		DashStyle		= DashStyle.Solid;
		public String			CustomDashStyle	= "1";
		public DashCap			DashCap			= DashCap.Flat;
		public CompositingMode	CompositingMode	= CompositingMode.SourceOver;
		public Boolean			AntiAliasing	= true;
		public Int32			SelectedTab		= 0;

		////////////////////////////////////////////////////////////////////////////////
		// Color
		////////////////////////////////////////////////////////////////////////////////
		public Color	Color_Color	=	Color.White;

		////////////////////////////////////////////////////////////////////////////////
		// Hatch
		////////////////////////////////////////////////////////////////////////////////
		public Color		Hatch_BackColor	=	Color.White;
		public Color		Hatch_ForeColor	=	Color.White;
		public HatchStyle	Hatch_Style		=	HatchStyle.Horizontal;

		////////////////////////////////////////////////////////////////////////////////
		// Linear Gradient
		////////////////////////////////////////////////////////////////////////////////
		public Color[]	LinearGradient_Colors			= new Color[0];
		public Double	LinearGradient_Angle			= 0.0;
		public Boolean	LinearGradient_GammaCorrection	= false;

		public override object Clone()
		{
			SicToken clonedToken = (SicToken)MemberwiseClone();

			clonedToken.LinearGradient_Colors = new Color[LinearGradient_Colors.Length];
			for (Int32 i = 0;i < LinearGradient_Colors.Length;++ i)
			{
				clonedToken.LinearGradient_Colors[i] = LinearGradient_Colors[i];
			}

			return clonedToken;
		}
	}
}
