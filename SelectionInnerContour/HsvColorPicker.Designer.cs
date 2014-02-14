namespace SelectionInnerContour
{
	partial class HsvColorPicker
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.hsvColorWheel = new SelectionInnerContour.HsvColorWheel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.nudLightness = new System.Windows.Forms.NumericUpDown();
			this.nudSaturation = new System.Windows.Forms.NumericUpDown();
			this.nudHue = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnColor = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLightness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSaturation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHue)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.hsvColorWheel, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.pnColor, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 300);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// hsvColorWheel
			// 
			this.hsvColorWheel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hsvColorWheel.Hue = 0D;
			this.hsvColorWheel.Lightness = 100D;
			this.hsvColorWheel.Location = new System.Drawing.Point(20, 0);
			this.hsvColorWheel.Margin = new System.Windows.Forms.Padding(0);
			this.hsvColorWheel.Name = "hsvColorWheel";
			this.hsvColorWheel.Saturation = 0D;
			this.hsvColorWheel.Size = new System.Drawing.Size(301, 300);
			this.hsvColorWheel.TabIndex = 1;
			this.hsvColorWheel.SelectionChangedEvent += new SelectionInnerContour.HsvColorWheel.SelectionChangedHandler(this.hsvColorWheel_SelectionChangedEvent);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(321, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(96, 300);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.nudLightness, 0, 4);
			this.tableLayoutPanel4.Controls.Add(this.nudSaturation, 0, 3);
			this.tableLayoutPanel4.Controls.Add(this.nudHue, 0, 2);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(21, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 5;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(75, 300);
			this.tableLayoutPanel4.TabIndex = 1;
			// 
			// nudLightness
			// 
			this.nudLightness.DecimalPlaces = 2;
			this.nudLightness.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudLightness.Location = new System.Drawing.Point(0, 280);
			this.nudLightness.Margin = new System.Windows.Forms.Padding(0);
			this.nudLightness.Name = "nudLightness";
			this.nudLightness.Size = new System.Drawing.Size(75, 20);
			this.nudLightness.TabIndex = 2;
			this.nudLightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudLightness.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudLightness.ValueChanged += new System.EventHandler(this.nudLightness_ValueChanged);
			// 
			// nudSaturation
			// 
			this.nudSaturation.DecimalPlaces = 2;
			this.nudSaturation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudSaturation.Location = new System.Drawing.Point(0, 260);
			this.nudSaturation.Margin = new System.Windows.Forms.Padding(0);
			this.nudSaturation.Name = "nudSaturation";
			this.nudSaturation.Size = new System.Drawing.Size(75, 20);
			this.nudSaturation.TabIndex = 1;
			this.nudSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudSaturation.ValueChanged += new System.EventHandler(this.nudSaturation_ValueChanged);
			// 
			// nudHue
			// 
			this.nudHue.DecimalPlaces = 2;
			this.nudHue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudHue.Location = new System.Drawing.Point(0, 240);
			this.nudHue.Margin = new System.Windows.Forms.Padding(0);
			this.nudHue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.nudHue.Name = "nudHue";
			this.nudHue.Size = new System.Drawing.Size(75, 20);
			this.nudHue.TabIndex = 0;
			this.nudHue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudHue.ValueChanged += new System.EventHandler(this.nudHue_ValueChanged);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel3.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 5;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(21, 300);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(3, 280);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "L";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(3, 260);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "S";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(3, 240);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(15, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "H";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnColor
			// 
			this.pnColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnColor.Location = new System.Drawing.Point(0, 0);
			this.pnColor.Margin = new System.Windows.Forms.Padding(0);
			this.pnColor.Name = "pnColor";
			this.pnColor.Size = new System.Drawing.Size(20, 300);
			this.pnColor.TabIndex = 3;
			// 
			// HsvColorPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "HsvColorPicker";
			this.Size = new System.Drawing.Size(417, 300);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudLightness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSaturation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHue)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private HsvColorWheel hsvColorWheel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nudHue;
		private System.Windows.Forms.NumericUpDown nudSaturation;
		private System.Windows.Forms.NumericUpDown nudLightness;
		private System.Windows.Forms.Panel pnColor;
	}
}
