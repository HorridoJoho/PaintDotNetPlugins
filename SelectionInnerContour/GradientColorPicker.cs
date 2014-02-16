using System;
using System.Drawing;

namespace SelectionInnerContour
{
	public partial class GradientColorPicker : CustomControls.ControlListBoxItem
	{
		public GradientColorPicker()
		{
			InitializeComponent();
		}

		public Color Color
		{
			get { return hsvAlphaColorPicker1.Color; }
			set
			{
				hsvAlphaColorPicker1.Color = value;
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			OnRequestRemoval();
		}

		private void hsvAlphaColorPicker1_ColorChangedEvent(object sender)
		{
			OnModified();
		}
	}
}
