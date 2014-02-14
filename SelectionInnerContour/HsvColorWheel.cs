using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SelectionInnerContour
{
	public partial class HsvColorWheel : UserControl
	{
		#region Inner types
		public delegate void SelectionChangedHandler(Object sender);
		#endregion

		#region Static constants
		private static Double _MAX_RADIAN = Math.PI * 2;
		private static Double _MAX_DEGREE = 360.0;
		#endregion

		#region Fields
		private PointF _CurrentMiddle = new PointF();
		private PathGradientBrush _ForeBrush = null;
		private Double _CurrentHue = 0.0;
		private Double _CurrentSaturation = 0.0;
		private Double _Lightness = 100.0;
		#endregion

		#region Properties
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Double Hue
		{
			get { return _CurrentHue; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => { _SetHue(value); }));
				}
				else
				{
					_SetHue(value);
				}
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Double Saturation
		{
			get { return _CurrentSaturation; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => { _SetSaturation(value); }));
				}
				else
				{
					_SetSaturation(value);
				}
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Double Lightness
		{
			get { return _Lightness; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => { _SetLightness(value); }));
				}
				else
				{
					_SetLightness(value);
				}
			}
		}
		#endregion

		#region Constructor
		public HsvColorWheel()
		{
			InitializeComponent();
		}
		#endregion

		#region Helper methods
		private T _Clamp<T>(T min, T max, T value) where T : IComparable<T>
		{
			if (value.CompareTo(max) > 0)
			{
				return max;
			}
			else if (value.CompareTo(min) < 0)
			{
				return min;
			}

			return value;
		}

		private void _SetHue(Double hue)
		{
			_CurrentHue = _Clamp(0, 360, hue);
			OnSelectionChanged();
		}

		private void _SetSaturation(Double saturation)
		{
			_CurrentSaturation = _Clamp(0, 100, saturation);
			OnSelectionChanged();
		}

		private void _SetLightness(Double lightness)
		{
			_Lightness = _Clamp(0, 100, lightness);
			_UpdateControl();
			Invalidate();
		}

		private Double _CalculateDistanceSq(ref PointF from, Single toX, Single toY)
		{
			Double dx = from.X - toX;
			Double dy = from.Y - toY;
			return (dx * dx) + (dy * dy);
		}

		private Double _CalculateDistance(ref PointF from, Single toX, Single toY)
		{
			return Math.Sqrt(_CalculateDistanceSq(ref from, toX, toY));
		}

		private Double _DegreeToRadian(Double degree)
		{
			return degree * _MAX_RADIAN / _MAX_DEGREE;
		}

		private Double _RadianToDegree(Double radian)
		{
			return radian * _MAX_DEGREE / _MAX_RADIAN;
		}

		private Double _CalculateDegreeFromTo(ref PointF from, Single toX, Single toY)
		{
			Double degree = _RadianToDegree(Math.Atan2(toY - from.Y, toX - from.X));
			if (degree < 0)
			{
				degree = 360 + degree;
			}
			return degree;
		}

		private void _UpdateControl()
		{
			using (GraphicsPath ellipsePath = new GraphicsPath())
			{
				ellipsePath.AddEllipse(0, 0, Bounds.Width, Bounds.Height);
				using (Region oldRegion = Region)
				{
					Region = new Region(ellipsePath);
				}
			}

			using (GraphicsPath hexagonPath = new GraphicsPath())
			{
				hexagonPath.AddPolygon(new PointF[]{
					new PointF(Width, Height * 0.5f),
					new PointF(Width, Height),
					new PointF(0, Height),
					new PointF(0, Height * 0.5f),
					new PointF(0, 0),
					new PointF(Width, 0)
				});

				if (_ForeBrush != null)
				{
					_ForeBrush.Dispose();
					_ForeBrush = null;
				}
				_ForeBrush = new PathGradientBrush(hexagonPath);
				Double lightness0_1 = Lightness * 0.01;
				_ForeBrush.CenterColor = Color.FromArgb((Byte)(255 * lightness0_1), (Byte)(255 * lightness0_1), (Byte)(255 * lightness0_1));
				_ForeBrush.SurroundColors = new Color[] {
					Color.FromArgb((Byte)(255 * lightness0_1), 0, 0),
					Color.FromArgb((Byte)(255 * lightness0_1), (Byte)(255 * lightness0_1), 0),
					Color.FromArgb(0, (Byte)(255 * lightness0_1), 0),
					Color.FromArgb(0, (Byte)(255 * lightness0_1), (Byte)(255 * lightness0_1)),
					Color.FromArgb(0, 0, (Byte)(255 * lightness0_1)),
					Color.FromArgb((Byte)(255 * lightness0_1), 0, (Byte)(255 * lightness0_1))
				};
			}

			_CurrentMiddle.X = Width * 0.5f;
			_CurrentMiddle.Y = Height * 0.5f;
		}
		#endregion

		#region Attachable events
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public event SelectionChangedHandler SelectionChangedEvent;
		#endregion

		#region Event handlers
		protected void OnSelectionChanged()
		{
			Invalidate();

			if (SelectionChangedEvent != null)
			{
				SelectionChangedEvent(this);
			}
		}
		#endregion

		#region Inherited event handlers
		protected override void OnLoad(EventArgs e)
		{
			_UpdateControl();
			base.OnLoad(e);
		}

		protected override void OnResize(EventArgs e)
		{
			_UpdateControl();
			Invalidate();
			base.OnResize(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			// Fill the color wheel
			e.Graphics.FillEllipse(_ForeBrush, 1, 1, Width - 2, Height - 2);
			// Render selection
			Double radian = _DegreeToRadian(_CurrentHue);
			PointF selectionPt = new PointF();
			selectionPt.X = (Single)(_CurrentMiddle.X + Math.Cos(radian) * (Width / 2 * (_CurrentSaturation * 0.01)));
			selectionPt.Y = (Single)(_CurrentMiddle.Y + Math.Sin(radian) * (Height / 2 * (_CurrentSaturation * 0.01)));
			e.Graphics.DrawRectangle(Pens.Black, selectionPt.X - 1, selectionPt.Y - 1, 1, 1);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}

			Capture = true;
			_CurrentHue = _CalculateDegreeFromTo(ref _CurrentMiddle, e.Location.X, e.Location.Y);
			_CurrentSaturation = _Clamp(0.0, 100.0, 100.0 * _CalculateDistance(ref _CurrentMiddle, e.Location.X, e.Location.Y) / Math.Max(Width * 0.5, Height * 0.5));
			OnSelectionChanged();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (!Capture)
			{
				return;
			}

			_CurrentHue = _CalculateDegreeFromTo(ref _CurrentMiddle, e.Location.X, e.Location.Y);
			_CurrentSaturation = _Clamp(0.0, 100.0, 100.0 * _CalculateDistance(ref _CurrentMiddle, e.Location.X, e.Location.Y) / Math.Max(Width * 0.5, Height * 0.5));
			OnSelectionChanged();
		}
		#endregion
	}
}
