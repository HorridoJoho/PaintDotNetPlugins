﻿namespace SelectionInnerContour
{
	partial class SicConfigDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.cbAntiAliasing = new System.Windows.Forms.CheckBox();
			this.tbCustomDashStyle = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbDashStyle = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbDashCap = new System.Windows.Forms.ComboBox();
			this.tbWidth = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.cbCompositingMode = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tcFilling = new System.Windows.Forms.TabControl();
			this.tpColorFilling = new System.Windows.Forms.TabPage();
			this.hsvacpColorFillingColor = new SelectionInnerContour.HsvAlphaColorPicker();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.cbHatchFillingStyle = new System.Windows.Forms.ComboBox();
			this.hsvacpHatchFillingForeColor = new SelectionInnerContour.HsvAlphaColorPicker();
			this.hsvacpHatchFillingBackColor = new SelectionInnerContour.HsvAlphaColorPicker();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbWidth)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tcFilling.SuspendLayout();
			this.tpColorFilling.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.tableLayoutPanel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(778, 197);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pen Settings";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.cbAntiAliasing, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.tbCustomDashStyle, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.cbDashStyle, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.cbDashCap, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.tbWidth, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.cbCompositingMode, 1, 4);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(772, 178);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// cbAntiAliasing
			// 
			this.cbAntiAliasing.AutoSize = true;
			this.cbAntiAliasing.Location = new System.Drawing.Point(103, 161);
			this.cbAntiAliasing.Name = "cbAntiAliasing";
			this.cbAntiAliasing.Size = new System.Drawing.Size(15, 14);
			this.cbAntiAliasing.TabIndex = 7;
			this.cbAntiAliasing.UseVisualStyleBackColor = true;
			this.cbAntiAliasing.CheckedChanged += new System.EventHandler(this.cbAntiAliasing_CheckedChanged);
			// 
			// tbCustomDashStyle
			// 
			this.tbCustomDashStyle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCustomDashStyle.Enabled = false;
			this.tbCustomDashStyle.Location = new System.Drawing.Point(103, 81);
			this.tbCustomDashStyle.Name = "tbCustomDashStyle";
			this.tbCustomDashStyle.Size = new System.Drawing.Size(666, 20);
			this.tbCustomDashStyle.TabIndex = 4;
			this.tbCustomDashStyle.Text = "1";
			this.tbCustomDashStyle.TextChanged += new System.EventHandler(this.tbCustomDashStyle_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(3, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Anti-Aliasing";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbDashStyle
			// 
			this.cbDashStyle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbDashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDashStyle.FormattingEnabled = true;
			this.cbDashStyle.Location = new System.Drawing.Point(103, 54);
			this.cbDashStyle.Name = "cbDashStyle";
			this.cbDashStyle.Size = new System.Drawing.Size(666, 21);
			this.cbDashStyle.TabIndex = 3;
			this.cbDashStyle.SelectedIndexChanged += new System.EventHandler(this.cbDashStyle_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 51);
			this.label1.TabIndex = 1;
			this.label1.Text = "Width";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(3, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 27);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dash Style";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(3, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 27);
			this.label3.TabIndex = 5;
			this.label3.Text = "Dash Cap";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbDashCap
			// 
			this.cbDashCap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbDashCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDashCap.FormattingEnabled = true;
			this.cbDashCap.Location = new System.Drawing.Point(103, 107);
			this.cbDashCap.Name = "cbDashCap";
			this.cbDashCap.Size = new System.Drawing.Size(666, 21);
			this.cbDashCap.TabIndex = 6;
			this.cbDashCap.SelectedIndexChanged += new System.EventHandler(this.cbDashCap_SelectedIndexChanged);
			// 
			// tbWidth
			// 
			this.tbWidth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbWidth.Location = new System.Drawing.Point(103, 3);
			this.tbWidth.Maximum = 1000;
			this.tbWidth.Minimum = 1;
			this.tbWidth.Name = "tbWidth";
			this.tbWidth.Size = new System.Drawing.Size(666, 45);
			this.tbWidth.TabIndex = 0;
			this.tbWidth.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbWidth.Value = 1;
			this.tbWidth.Scroll += new System.EventHandler(this.tbWidth_Scroll);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(3, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 27);
			this.label5.TabIndex = 9;
			this.label5.Text = "Compositing Mode";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbCompositingMode
			// 
			this.cbCompositingMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbCompositingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCompositingMode.FormattingEnabled = true;
			this.cbCompositingMode.Location = new System.Drawing.Point(103, 134);
			this.cbCompositingMode.Name = "cbCompositingMode";
			this.cbCompositingMode.Size = new System.Drawing.Size(666, 21);
			this.cbCompositingMode.TabIndex = 10;
			this.cbCompositingMode.SelectedIndexChanged += new System.EventHandler(this.cbCompositingMode_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tcFilling);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 206);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(778, 327);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Filling";
			// 
			// tcFilling
			// 
			this.tcFilling.Controls.Add(this.tpColorFilling);
			this.tcFilling.Controls.Add(this.tabPage1);
			this.tcFilling.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcFilling.Location = new System.Drawing.Point(3, 16);
			this.tcFilling.Name = "tcFilling";
			this.tcFilling.SelectedIndex = 0;
			this.tcFilling.Size = new System.Drawing.Size(772, 308);
			this.tcFilling.TabIndex = 0;
			this.tcFilling.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcFilling_Selected);
			// 
			// tpColorFilling
			// 
			this.tpColorFilling.BackColor = System.Drawing.SystemColors.Control;
			this.tpColorFilling.Controls.Add(this.hsvacpColorFillingColor);
			this.tpColorFilling.Location = new System.Drawing.Point(4, 22);
			this.tpColorFilling.Name = "tpColorFilling";
			this.tpColorFilling.Padding = new System.Windows.Forms.Padding(3);
			this.tpColorFilling.Size = new System.Drawing.Size(764, 282);
			this.tpColorFilling.TabIndex = 0;
			this.tpColorFilling.Text = "Color";
			// 
			// hsvacpColorFillingColor
			// 
			this.hsvacpColorFillingColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.hsvacpColorFillingColor.Location = new System.Drawing.Point(195, 6);
			this.hsvacpColorFillingColor.Name = "hsvacpColorFillingColor";
			this.hsvacpColorFillingColor.Size = new System.Drawing.Size(385, 270);
			this.hsvacpColorFillingColor.TabIndex = 0;
			this.hsvacpColorFillingColor.ColorChangedEvent += new SelectionInnerContour.HsvAlphaColorPicker.ColorChangedHandler(this.hsvacpColorFillingColor_ColorChangedEvent);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.tableLayoutPanel4);
			this.tabPage1.Controls.Add(this.hsvacpHatchFillingForeColor);
			this.tabPage1.Controls.Add(this.hsvacpHatchFillingBackColor);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(764, 282);
			this.tabPage1.TabIndex = 1;
			this.tabPage1.Text = "Hatch";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.cbHatchFillingStyle, 1, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 252);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(758, 27);
			this.tableLayoutPanel4.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 27);
			this.label6.TabIndex = 0;
			this.label6.Text = "Hatch Style";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbHatchFillingStyle
			// 
			this.cbHatchFillingStyle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbHatchFillingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHatchFillingStyle.FormattingEnabled = true;
			this.cbHatchFillingStyle.Location = new System.Drawing.Point(71, 3);
			this.cbHatchFillingStyle.Name = "cbHatchFillingStyle";
			this.cbHatchFillingStyle.Size = new System.Drawing.Size(684, 21);
			this.cbHatchFillingStyle.TabIndex = 1;
			this.cbHatchFillingStyle.SelectedIndexChanged += new System.EventHandler(this.cbHatchFillingStyle_SelectedIndexChanged);
			// 
			// hsvacpHatchFillingForeColor
			// 
			this.hsvacpHatchFillingForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.hsvacpHatchFillingForeColor.Location = new System.Drawing.Point(385, 6);
			this.hsvacpHatchFillingForeColor.Name = "hsvacpHatchFillingForeColor";
			this.hsvacpHatchFillingForeColor.Size = new System.Drawing.Size(373, 248);
			this.hsvacpHatchFillingForeColor.TabIndex = 1;
			this.hsvacpHatchFillingForeColor.ColorChangedEvent += new SelectionInnerContour.HsvAlphaColorPicker.ColorChangedHandler(this.hsvacpHatchFillingForeColor_ColorChangedEvent);
			// 
			// hsvacpHatchFillingBackColor
			// 
			this.hsvacpHatchFillingBackColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.hsvacpHatchFillingBackColor.Location = new System.Drawing.Point(6, 6);
			this.hsvacpHatchFillingBackColor.Name = "hsvacpHatchFillingBackColor";
			this.hsvacpHatchFillingBackColor.Size = new System.Drawing.Size(373, 248);
			this.hsvacpHatchFillingBackColor.TabIndex = 0;
			this.hsvacpHatchFillingBackColor.ColorChangedEvent += new SelectionInnerContour.HsvAlphaColorPicker.ColorChangedHandler(this.hsvacpHatchFillingBackColor_ColorChangedEvent);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnOk, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 536);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(784, 26);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(731, 0);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.AutoSize = true;
			this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOk.Location = new System.Drawing.Point(696, 0);
			this.btnOk.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(32, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// SicConfigDialog
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "SicConfigDialog";
			this.Text = "Inner Contour";
			this.Load += new System.EventHandler(this.SicConfigDialog_Load);
			this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbWidth)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tcFilling.ResumeLayout(false);
			this.tpColorFilling.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar tbWidth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbDashStyle;
		private System.Windows.Forms.TextBox tbCustomDashStyle;
		private System.Windows.Forms.ComboBox cbDashCap;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox cbAntiAliasing;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbCompositingMode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabControl tcFilling;
		private System.Windows.Forms.TabPage tpColorFilling;
		private HsvAlphaColorPicker hsvacpColorFillingColor;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TabPage tabPage1;
		private HsvAlphaColorPicker hsvacpHatchFillingForeColor;
		private HsvAlphaColorPicker hsvacpHatchFillingBackColor;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbHatchFillingStyle;
	}
}