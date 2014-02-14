using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SelectionInnerContour
{
	public partial class SicAngleChooserControl : UserControl
	{
		#region Inner types
		public delegate void ValueChangedHandler(Object sender);
		#endregion

		#region Static constants
		private static Double _MAX_RADIAN = Math.PI * 2;
		private static Double _MAX_DEGREE = 360.0;
		#endregion

		#region Fields
		private PointF _CurrentMiddle = new PointF();
		private PointF _CurrentLinePoint = new PointF();
		private SolidBrush _BackBrush = null;
		private Pen _ForePen = null;
		private Double _CurrentDegree = 0.0;
		private Boolean _MouseOver = false;
		#endregion

		#region Properties
		public Double Value
		{
			get
			{
				return _CurrentDegree;
			}

			set
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(() => _SetCurrentDegree(value)));
				}
				else
				{
					_SetCurrentDegree(value);
				}
			}
		}
		#endregion

		#region Constructor
		public SicAngleChooserControl()
		{
			InitializeComponent();
		}
		#endregion

		#region Helper methods
		private void _SetCurrentDegree(Double newDegree)
		{
			_CurrentDegree = newDegree;
			_UpdateControlSelection();
			Invalidate();
			OnValueChanged();
		}

		private void _UpdateControl()
		{
			using (GraphicsPath path = new GraphicsPath())
			{
				path.AddEllipse(0, 0, Bounds.Width, Bounds.Height);
				using (Region oldRegion = Region)
				{
					Region = new Region(path);
				}
			}

			_CurrentMiddle.X = Width / 2.0f;
			_CurrentMiddle.Y = Height / 2.0f;

			if (_BackBrush == null)
			{
				_BackBrush = new SolidBrush(BackColor);
			}

			if (_ForePen == null)
			{
				_ForePen = new Pen(ForeColor);
				_ForePen.StartCap = LineCap.RoundAnchor;
				_ForePen.EndCap = LineCap.ArrowAnchor;
			}
			_ForePen.Width = (Single)Math.Max(Math.Max(Width, Height) * 0.01, 2.0);

			_UpdateControlSelection();
		}

		private void _UpdateControlSelection()
		{
			Double radian = _DegreeToRadian(_CurrentDegree);
			_CurrentLinePoint.X = (Single)(_CurrentMiddle.X + Math.Cos(radian) * (Width * 0.49));
			_CurrentLinePoint.Y = (Single)(_CurrentMiddle.Y + Math.Sin(radian) * (Height * 0.49));
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

		private Byte _LightupChannel(Byte channel)
		{
			if (channel > 223)
				return 255;
			return (Byte)(channel + 32);
		}

		private Byte _DarkenChannel(Byte channel)
		{
			if (channel < 32)
				return 0;
			return (Byte)(channel - 32);
		}

		private Color _GetDisabledColor(Color col)
		{
			Byte lightR = _LightupChannel(col.R);
			Byte lightG = _LightupChannel(col.G);
			Byte lightB = _LightupChannel(col.B);
			Byte allChannelsValue = (Byte)(lightR * 0.30 + lightG * 0.59 + lightB * 0.11);
			return Color.FromArgb(allChannelsValue, allChannelsValue, allChannelsValue);
		}

		private Color _GetCaptureColor(Color col)
		{
			return Color.FromArgb(_DarkenChannel(col.R), _DarkenChannel(col.G), _DarkenChannel(col.B));
		}
		#endregion

		#region Attachable events
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public event ValueChangedHandler ValueChangedEvent;
		#endregion

		#region Event handlers
		protected void OnValueChanged()
		{
			if (ValueChangedEvent != null)
			{
				ValueChangedEvent(this);
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
			if (!Enabled)
				_ForePen.Color = _GetDisabledColor(ForeColor);
			else if (Capture || _MouseOver)
				_ForePen.Color = _GetCaptureColor(ForeColor);
			else
				_ForePen.Color = ForeColor;

			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			// Angle line
			e.Graphics.DrawLine(_ForePen, _CurrentMiddle, _CurrentLinePoint);
			// Border
			e.Graphics.DrawEllipse(_ForePen, _ForePen.Width, _ForePen.Width, (Single)((Single)Bounds.Width - _ForePen.Width * 2.0), (Single)((Single)Bounds.Height - _ForePen.Width * 2.0));
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			_MouseOver = true;
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			_MouseOver = false;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}

			Capture = true;
			_CurrentDegree = _CalculateDegreeFromTo(ref _CurrentMiddle, e.Location.X, e.Location.Y);
			_UpdateControlSelection();
			Invalidate();
			OnValueChanged();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (!Capture)
			{
				return;
			}

			_CurrentDegree = _CalculateDegreeFromTo(ref _CurrentMiddle, e.Location.X, e.Location.Y);
			_UpdateControlSelection();
			Invalidate();
			OnValueChanged();
		}
		#endregion
	}
}
