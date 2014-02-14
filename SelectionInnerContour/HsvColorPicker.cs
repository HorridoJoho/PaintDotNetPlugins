using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using PaintDotNet;

namespace SelectionInnerContour
{
	public partial class HsvColorPicker : UserControl
	{
		#region Inner Types
		public delegate void ColorChangedHandler(Object sender);
		#endregion

		#region Fields
		private HsvColor _CurrentHsvColor;
		private Color _CurrentColor;
		#endregion

		#region Properties
		public HsvColor HsvColor
		{
			get { return _CurrentHsvColor; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => { _SetCurrentHsvColor(value); }));
				}
				else
				{
					_SetCurrentHsvColor(value);
				}
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color Color
		{
			get { return _CurrentColor; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => { _SetCurrentColor(value); }));
				}
				else
				{
					_SetCurrentColor(value);
				}
			}
		}
		#endregion

		#region Constructor
		public HsvColorPicker()
		{
			InitializeComponent();
		}
		#endregion

		#region Helper methods
		private void _SetCurrentHsvColor(HsvColor col)
		{
			_CurrentHsvColor = col;
			hsvColorWheel.Lightness = col.Value;
			nudLightness.Value = (Decimal)col.Value;
			hsvColorWheel.Hue = col.Hue;
			hsvColorWheel.Saturation = col.Saturation;
		}

		private void _SetCurrentColor(Color col)
		{
			_CurrentColor = Color.FromArgb(255, col);
			pnColor.BackColor = _CurrentColor;
			_SetCurrentHsvColor(HsvColor.FromColor(_CurrentColor));
		}
		#endregion

		#region Attachable events
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public event ColorChangedHandler ColorChangedEvent;
		#endregion

		#region Attached event handlers
		private void hsvColorWheel_SelectionChangedEvent(object sender)
		{
			if (nudHue.Value == (Decimal)hsvColorWheel.Hue && nudSaturation.Value == (Decimal)hsvColorWheel.Saturation)
			{
				return;
			}

			nudHue.Value = (Decimal)hsvColorWheel.Hue;
			nudSaturation.Value = (Decimal)hsvColorWheel.Saturation;
			OnColorChanged();
		}

		private void nudHue_ValueChanged(object sender, EventArgs e)
		{
			if (hsvColorWheel.Hue == (Double)nudHue.Value)
			{
				return;
			}

			hsvColorWheel.Hue = (Double)nudHue.Value;
			OnColorChanged();
		}

		private void nudSaturation_ValueChanged(object sender, EventArgs e)
		{
			if (hsvColorWheel.Saturation == (Double)nudSaturation.Value)
			{
				return;
			}

			hsvColorWheel.Saturation = (Double)nudSaturation.Value;
			OnColorChanged();
		}

		private void nudLightness_ValueChanged(object sender, EventArgs e)
		{
			if (hsvColorWheel.Lightness == (Double)nudLightness.Value)
			{
				return;
			}

			hsvColorWheel.Lightness = (Double)nudLightness.Value;
			OnColorChanged();
		}
		#endregion

		#region Event handlers
		protected void OnColorChanged()
		{
			_CurrentHsvColor = new HsvColor((Int32)hsvColorWheel.Hue, (Int32)hsvColorWheel.Saturation, (Int32)hsvColorWheel.Lightness);
			_CurrentColor = _CurrentHsvColor.ToColor();
			pnColor.BackColor = _CurrentColor;

			if (ColorChangedEvent != null)
			{
				ColorChangedEvent(this);
			}
		}
		#endregion

		#region Inherited event handlers
		protected override void OnLoad(EventArgs e)
		{
			_CurrentHsvColor = new HsvColor((Int32)hsvColorWheel.Hue, (Int32)hsvColorWheel.Saturation, (Int32)hsvColorWheel.Lightness);
			_CurrentColor = _CurrentHsvColor.ToColor();
			pnColor.BackColor = _CurrentColor;
			base.OnLoad(e);
		}
		#endregion
	}
}
