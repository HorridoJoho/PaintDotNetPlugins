using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using PaintDotNet.Effects;
using System.Windows.Forms;

namespace SelectionInnerContour
{
	internal class SicToken : EffectConfigToken
	{
		public Single Width = 100;
		public DashStyle DashStyle = DashStyle.Solid;
		public String CustomDashStyle = "1";
		public DashCap DashCap = DashCap.Flat;
		public CompositingMode CompositingMode = CompositingMode.SourceOver;
		public Boolean AntiAliasing = true;
		public Int32 SelectedTab = 0;

		////////////////////////////////////////////////////////////////////////////////
		// Color Filling
		////////////////////////////////////////////////////////////////////////////////
		public Color ColorFilling_Color = Color.White;

		////////////////////////////////////////////////////////////////////////////////
		// Color Filling
		////////////////////////////////////////////////////////////////////////////////
		public Color HatchFilling_BackColor = Color.White;
		public Color HatchFilling_ForeColor = Color.White;
		public HatchStyle HatchFilling_Style = HatchStyle.Horizontal;

		public override object Clone()
		{
			return MemberwiseClone();
		}
	}
}
