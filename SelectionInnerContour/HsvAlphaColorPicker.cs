using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SelectionInnerContour
{
	public partial class HsvAlphaColorPicker : UserControl
	{
		#region Internal types
		public delegate void ColorChangedHandler(Object sender);
		#endregion

		#region Fields
		private Color _CurrentColor;
		#endregion

		#region Properties
		public Color Color
		{
			get { return _CurrentColor; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => { _SetColor(value); }));
				}
				else
				{
					_SetColor(value);
				}
			}
		}
		#endregion

		#region Constructor
		public HsvAlphaColorPicker()
		{
			InitializeComponent();
		}
		#endregion

		#region Helper methods
		private void _SetColor(Color col)
		{
			hsvColorPicker.Color = col;
			nudAlpha.Value = col.A;
			_CurrentColor = col;
			pnAlphaColor.Invalidate();
		}
		#endregion

		#region Attachable events
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public event ColorChangedHandler ColorChangedEvent;
		#endregion

		#region Attached event handlers
		private void pnAlphaColor_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(_CurrentColor), pnAlphaColor.DisplayRectangle);
		}

		private void hsvColorPicker_ColorChangedEvent(object sender)
		{
			OnColorChanged();
		}

		private void nudAlpha_ValueChanged(object sender, EventArgs e)
		{
			OnColorChanged();
		}
		#endregion

		#region Event handlers
		protected void OnColorChanged()
		{
			_CurrentColor = Color.FromArgb((Int32)nudAlpha.Value, hsvColorPicker.Color);
			pnAlphaColor.Invalidate();

			if (ColorChangedEvent != null)
			{
				ColorChangedEvent(this);
			}
		}
		#endregion

		#region Inherited event handlers
		protected override void OnLoad(EventArgs e)
		{
			_CurrentColor = Color.FromArgb((Int32)nudAlpha.Value, hsvColorPicker.Color);
			pnAlphaColor.Invalidate();
			base.OnLoad(e);
		}
		#endregion
	}
}
