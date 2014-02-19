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
		public Color		Hatch_BackColor	= Color.White;
		public Color		Hatch_ForeColor	= Color.White;
		public HatchStyle	Hatch_Style		= HatchStyle.Horizontal;

		////////////////////////////////////////////////////////////////////////////////
		// Linear Gradient
		////////////////////////////////////////////////////////////////////////////////
		public Color[]	LinearGradient_Colors			= new Color[0];
		public Double	LinearGradient_Angle			= 0.0;
		public Boolean	LinearGradient_GammaCorrection	= false;

		////////////////////////////////////////////////////////////////////////////////
		// Path Gradient
		////////////////////////////////////////////////////////////////////////////////
		public Color	PathGradient_CenterColor		= Color.White;
		public Color[]	PathGradient_SurroundingColors	= new Color[0];

		////////////////////////////////////////////////////////////////////////////////
		// Texture
		////////////////////////////////////////////////////////////////////////////////
		public String	Texture_File		= String.Empty;
		public WrapMode	Texture_WrapMode	= WrapMode.Clamp;
		public Double	Texture_TranslationX	= 0.0;
		public Double	Texture_TranslationY	= 0.0;
		public Double	Texture_Rotation		= 0.0;

		public override object Clone()
		{
			SicToken clonedToken = (SicToken)MemberwiseClone();

			clonedToken.LinearGradient_Colors = new Color[LinearGradient_Colors.Length];
			for (Int32 i = 0;i < LinearGradient_Colors.Length;++ i)
			{
				clonedToken.LinearGradient_Colors[i] = LinearGradient_Colors[i];
			}

			clonedToken.PathGradient_SurroundingColors = new Color[PathGradient_SurroundingColors.Length];
			for (Int32 i = 0;i < PathGradient_SurroundingColors.Length;++i)
			{
				clonedToken.PathGradient_SurroundingColors[i] = PathGradient_SurroundingColors[i];
			}

			return clonedToken;
		}
	}
}
