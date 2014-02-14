namespace SelectionInnerContour
{
	partial class HsvAlphaColorPicker
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
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.nudAlpha = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.pnAlphaColor = new System.Windows.Forms.Panel();
			this.hsvColorPicker = new SelectionInnerContour.HsvColorPicker();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 303);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudAlpha, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 283);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(419, 20);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(327, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "A";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudAlpha
			// 
			this.nudAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudAlpha.Location = new System.Drawing.Point(344, 0);
			this.nudAlpha.Margin = new System.Windows.Forms.Padding(0);
			this.nudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nudAlpha.Name = "nudAlpha";
			this.nudAlpha.Size = new System.Drawing.Size(75, 20);
			this.nudAlpha.TabIndex = 1;
			this.nudAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudAlpha.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nudAlpha.ValueChanged += new System.EventHandler(this.nudAlpha_ValueChanged);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.pnAlphaColor, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.hsvColorPicker, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 283F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(419, 283);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// pnAlphaColor
			// 
			this.pnAlphaColor.BackgroundImage = global::SelectionInnerContour.NeutralResources.color_trans_back;
			this.pnAlphaColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnAlphaColor.Location = new System.Drawing.Point(0, 0);
			this.pnAlphaColor.Margin = new System.Windows.Forms.Padding(0);
			this.pnAlphaColor.Name = "pnAlphaColor";
			this.pnAlphaColor.Size = new System.Drawing.Size(20, 283);
			this.pnAlphaColor.TabIndex = 0;
			this.pnAlphaColor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAlphaColor_Paint);
			// 
			// hsvColorPicker
			// 
			this.hsvColorPicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.hsvColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hsvColorPicker.Location = new System.Drawing.Point(20, 0);
			this.hsvColorPicker.Margin = new System.Windows.Forms.Padding(0);
			this.hsvColorPicker.Name = "hsvColorPicker";
			this.hsvColorPicker.Size = new System.Drawing.Size(399, 283);
			this.hsvColorPicker.TabIndex = 1;
			this.hsvColorPicker.ColorChangedEvent += new SelectionInnerContour.HsvColorPicker.ColorChangedHandler(this.hsvColorPicker_ColorChangedEvent);
			// 
			// HsvAlphaColorPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "HsvAlphaColorPicker";
			this.Size = new System.Drawing.Size(419, 303);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Panel pnAlphaColor;
		private System.Windows.Forms.NumericUpDown nudAlpha;
		private HsvColorPicker hsvColorPicker;

	}
}
