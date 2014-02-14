using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SelectionInnerContour
{
	public partial class SicAngleChooserExControl : UserControl
	{
		#region Inner types
		public delegate void ValueChangedHandler(Object sender);
		#endregion

		#region Properties
		public Double Value
		{
			get { return sicAngleChooserControl1.Value; }
			set { sicAngleChooserControl1.Value = value; }
		}
		#endregion

		#region Constructor
		public SicAngleChooserExControl()
		{
			InitializeComponent();
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
			sicAngleChooserControl1.BackColor = BackColor;
			sicAngleChooserControl1.ForeColor = ForeColor;
			numericUpDown1.Font = Font;
			base.OnLoad(e);
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			sicAngleChooserControl1.BackColor = BackColor;
			base.OnBackColorChanged(e);
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			sicAngleChooserControl1.ForeColor = ForeColor;
			base.OnForeColorChanged(e);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			numericUpDown1.Font = Font;
			base.OnFontChanged(e);
		}
		#endregion

		#region Attached event handlers
		private void sicAngleChooserControl1_AngleChangedEvent(object sender)
		{
			if (sicAngleChooserControl1.Value == (Double)numericUpDown1.Value)
			{
				return;
			}

			numericUpDown1.Value = (Decimal)sicAngleChooserControl1.Value;
			OnValueChanged();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (numericUpDown1.Value == (Decimal)sicAngleChooserControl1.Value)
			{
				return;
			}

			sicAngleChooserControl1.Value = (Double)numericUpDown1.Value;
			OnValueChanged();
		}
		#endregion
	}
}
