using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

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
			{
				FinishTokenUpdate();
			}
		}

		private void SicConfigDialog_Load(object sender, EventArgs e)
		{
			cbDashStyle.DataSource = Enum.GetValues(typeof(DashStyle));
			cbDashCap.DataSource = Enum.GetValues(typeof(DashCap));
			cbCompositingMode.DataSource = Enum.GetValues(typeof(CompositingMode));
			cbHatchFillingStyle.DataSource = Enum.GetValues(typeof(HatchStyle));
			cbTextureFillingWrapMode.DataSource = Enum.GetValues(typeof(WrapMode));
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
				// Color
				////////////////////////////////////////////////////////////////////////////////
				hsvacpColorFillingColor.Color = token.Color_Color;

				////////////////////////////////////////////////////////////////////////////////
				// Hatch
				////////////////////////////////////////////////////////////////////////////////
				hsvacpHatchFillingBackColor.Color = token.Hatch_BackColor;
				hsvacpHatchFillingForeColor.Color = token.Hatch_ForeColor;
				cbHatchFillingStyle.SelectedItem = token.Hatch_Style;

				////////////////////////////////////////////////////////////////////////////////
				// Linear Gradient
				////////////////////////////////////////////////////////////////////////////////
				clbLinearGradientFillingColors.RemoveAllControlItems();
				foreach (Color col in token.LinearGradient_Colors)
				{
					GradientColorPicker controlItem = new GradientColorPicker();
					controlItem.Color = col;
					clbLinearGradientFillingColors.AddControlItem(controlItem);
				}
				awcLinearGradientFillingAngle.Value = token.LinearGradient_Angle;
				cbLinearGradientFillingGammaCorrection.Checked = token.LinearGradient_GammaCorrection;

				////////////////////////////////////////////////////////////////////////////////
				// Path Gradient
				////////////////////////////////////////////////////////////////////////////////
				hsvacpPathGradientFillingCenterColor.Color = token.PathGradient_CenterColor;
				clbPathGradientFillingSurroundingColors.RemoveAllControlItems();
				foreach (Color col in token.PathGradient_SurroundingColors)
				{
					GradientColorPicker controlItem = new GradientColorPicker();
					controlItem.Color = col;
					clbPathGradientFillingSurroundingColors.AddControlItem(controlItem);
				}

				////////////////////////////////////////////////////////////////////////////////
				// Texture
				////////////////////////////////////////////////////////////////////////////////
				tbTextureFillingFile.Text = token.Texture_File;
				cbTextureFillingWrapMode.SelectedItem = token.Texture_WrapMode;
				tbTextureFillingTranslateX.Value = (Int32)token.Texture_TranslationX;
				tbTextureFillingTranslateY.Value = (Int32)token.Texture_TranslationY;
				awcTextureFillingRotation.Value = token.Texture_Rotation;
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
			// Color
			////////////////////////////////////////////////////////////////////////////////
			token.Color_Color = hsvacpColorFillingColor.Color;

			////////////////////////////////////////////////////////////////////////////////
			// Hatch
			////////////////////////////////////////////////////////////////////////////////
			token.Hatch_BackColor = hsvacpHatchFillingBackColor.Color;
			token.Hatch_ForeColor = hsvacpHatchFillingForeColor.Color;
			token.Hatch_Style = (HatchStyle)cbHatchFillingStyle.SelectedItem;

			////////////////////////////////////////////////////////////////////////////////
			// Linear Gradient
			////////////////////////////////////////////////////////////////////////////////
			List<Color> colors = new List<Color>();
			clbLinearGradientFillingColors.ForEach((CustomControls.ControlListBoxItem item) => {
				colors.Add(((GradientColorPicker)item).Color);
			});
			token.LinearGradient_Colors = colors.ToArray();
			token.LinearGradient_Angle = awcLinearGradientFillingAngle.Value;
			token.LinearGradient_GammaCorrection = cbLinearGradientFillingGammaCorrection.Checked;

			////////////////////////////////////////////////////////////////////////////////
			// Path Gradient
			////////////////////////////////////////////////////////////////////////////////
			token.PathGradient_CenterColor = hsvacpPathGradientFillingCenterColor.Color;
			colors.Clear();
			clbPathGradientFillingSurroundingColors.ForEach((CustomControls.ControlListBoxItem item) => {
				colors.Add(((GradientColorPicker)item).Color);
			});
			token.PathGradient_SurroundingColors = colors.ToArray();

			////////////////////////////////////////////////////////////////////////////////
			// Texture
			////////////////////////////////////////////////////////////////////////////////
			token.Texture_File = tbTextureFillingFile.Text;
			token.Texture_WrapMode = (WrapMode)cbTextureFillingWrapMode.SelectedItem;
			token.Texture_TranslationX = tbTextureFillingTranslateX.Value;
			token.Texture_TranslationY = tbTextureFillingTranslateY.Value;
			token.Texture_Rotation = awcTextureFillingRotation.Value;
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

		private void clbLinearGradientFillingColors_ItemAdded(object sender, CustomControls.ControlListBoxItem item)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void clbLinearGradientFillingColors_ItemModified(object sender, CustomControls.ControlListBoxItem item)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void clbLinearGradientFillingColors_ItemRemoved(object sender, CustomControls.ControlListBoxItem item)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void awcLinearGradientFillingAngle_ValueChangedEvent(object sender)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void cbLinearGradientFillingGammaCorrection_CheckedChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void btnLinearGradientFillingAddColor_Click(object sender, EventArgs e)
		{
			clbLinearGradientFillingColors.AddControlItem(new GradientColorPicker());
		}

		private void btnPathGradientFillingAddColor_Click(object sender, EventArgs e)
		{
			clbPathGradientFillingSurroundingColors.AddControlItem(new GradientColorPicker());
		}

		private void hsvacpPathGradientFillingCenterColor_ColorChangedEvent(object sender)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void clbPathGradientFillingSurroundingColors_ItemAdded(object sender, CustomControls.ControlListBoxItem item)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void clbPathGradientFillingSurroundingColors_ItemModified(object sender, CustomControls.ControlListBoxItem item)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void clbPathGradientFillingSurroundingColors_ItemRemoved(object sender, CustomControls.ControlListBoxItem item)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void tbTextureFillingFile_TextChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void cbTextureFillingWrapMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void btnTextureFillingChooseFile_Click(object sender, EventArgs e)
		{
			if (ofdTextureFillingFile.ShowDialog(this) == DialogResult.Cancel)
			{
				return;
			}

			tbTextureFillingFile.Text = ofdTextureFillingFile.FileName;
		}

		private void tbTextureFillingTranslateX_Scroll(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void tbTextureFillingTranslateY_Scroll(object sender, EventArgs e)
		{
			FinishTokenUpdateWhenNotIniting();
		}

		private void gcpTextureFillingRotation_ValueChangedEvent(object sender)
		{
			FinishTokenUpdateWhenNotIniting();
		}
	}
}
