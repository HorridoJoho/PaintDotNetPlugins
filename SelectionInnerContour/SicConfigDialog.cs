﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaintDotNet.Effects;

namespace SelectionInnerContour
{
	partial class SicConfigDialog : SicConfigDialog_
	{
		private Boolean _InitDialog = false;

		public SicConfigDialog()
		{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
		}

		private void FinishTokenUpdateWhenNotIniting()
		{
			if (!_InitDialog)
				FinishTokenUpdate();
		}

		private void SicConfigDialog_Load(object sender, EventArgs e)
		{
			cbDashStyle.DataSource = Enum.GetValues(typeof(DashStyle));
			cbDashCap.DataSource = Enum.GetValues(typeof(DashCap));
			cbCompositingMode.DataSource = Enum.GetValues(typeof(CompositingMode));
			cbHatchFillingStyle.DataSource = Enum.GetValues(typeof(HatchStyle));
		}

		protected override SicToken CreateInitialToken()
		{
			return new SicToken();
		}

		protected override void InitDialogFromToken(SicToken token)
		{
			_InitDialog = true;
			try
			{
				tbWidth.Value = (Int32)token.Width;
				cbDashStyle.SelectedItem = token.DashStyle;
				tbCustomDashStyle.Text = token.CustomDashStyle;
				cbDashCap.SelectedItem = token.DashCap;
				cbCompositingMode.SelectedItem = token.CompositingMode;
				cbAntiAliasing.Checked = token.AntiAliasing;
				tcFilling.SelectedIndex = token.SelectedTab;

				////////////////////////////////////////////////////////////////////////////////
				// Color Filling
				////////////////////////////////////////////////////////////////////////////////
				hsvacpColorFillingColor.Color = token.ColorFilling_Color;

				////////////////////////////////////////////////////////////////////////////////
				// Hatch Filling
				////////////////////////////////////////////////////////////////////////////////
				hsvacpHatchFillingBackColor.Color = token.HatchFilling_BackColor;
				hsvacpHatchFillingForeColor.Color = token.HatchFilling_ForeColor;
				cbHatchFillingStyle.SelectedItem = token.HatchFilling_Style;
			}
			finally
			{
				_InitDialog = false;
			}
		}

		protected override void LoadIntoTokenFromDialog(SicToken token)
		{
			token.Width = tbWidth.Value;
			token.DashStyle = (DashStyle)cbDashStyle.SelectedItem;
			token.CustomDashStyle = tbCustomDashStyle.Text;
			token.DashCap = (DashCap)cbDashCap.SelectedItem;
			token.CompositingMode = (CompositingMode)cbCompositingMode.SelectedItem;
			token.AntiAliasing = cbAntiAliasing.Checked;
			token.SelectedTab = tcFilling.SelectedIndex;

			////////////////////////////////////////////////////////////////////////////////
			// Color Filling
			////////////////////////////////////////////////////////////////////////////////
			token.ColorFilling_Color = hsvacpColorFillingColor.Color;

			////////////////////////////////////////////////////////////////////////////////
			// Hatch Filling
			////////////////////////////////////////////////////////////////////////////////
			token.HatchFilling_BackColor = hsvacpHatchFillingBackColor.Color;
			token.HatchFilling_ForeColor = hsvacpHatchFillingForeColor.Color;
			token.HatchFilling_Style = (HatchStyle)cbHatchFillingStyle.SelectedItem;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void tbWidth_Scroll(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void cbDashStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			tbCustomDashStyle.Enabled = (DashStyle)cbDashStyle.SelectedItem == DashStyle.Custom;
			FinishTokenUpdateWhenNotIniting();
		}

		private void tbCustomDashStyle_TextChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void cbDashCap_SelectedIndexChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void cbCompositingMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		// composing quality here

		private void cbAntiAliasing_CheckedChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void tcFilling_Selected(object sender, TabControlEventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void hsvacpColorFillingColor_ColorChangedEvent(object sender)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void hsvacpHatchFillingBackColor_ColorChangedEvent(object sender)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void hsvacpHatchFillingForeColor_ColorChangedEvent(object sender)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void cbHatchFillingStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}
	}
}
