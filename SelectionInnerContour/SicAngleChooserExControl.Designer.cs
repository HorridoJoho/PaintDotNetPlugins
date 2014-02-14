namespace SelectionInnerContour
{
	partial class SicAngleChooserExControl
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
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.sicAngleChooserControl1 = new SelectionInnerContour.SicAngleChooserControl();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDown1.Location = new System.Drawing.Point(3, 225);
			this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(72, 20);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel1.Controls.Add(this.sicAngleChooserControl1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 471);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// sicAngleChooserControl1
			// 
			this.sicAngleChooserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sicAngleChooserControl1.Location = new System.Drawing.Point(0, 0);
			this.sicAngleChooserControl1.Margin = new System.Windows.Forms.Padding(0);
			this.sicAngleChooserControl1.Name = "sicAngleChooserControl1";
			this.sicAngleChooserControl1.Size = new System.Drawing.Size(534, 471);
			this.sicAngleChooserControl1.TabIndex = 0;
			this.sicAngleChooserControl1.Value = 0D;
			this.sicAngleChooserControl1.ValueChangedEvent += new SelectionInnerContour.SicAngleChooserControl.ValueChangedHandler(this.sicAngleChooserControl1_AngleChangedEvent);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.numericUpDown1, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(534, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(75, 471);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// SicAngleChooserExControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SicAngleChooserExControl";
			this.Size = new System.Drawing.Size(609, 471);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private SicAngleChooserControl sicAngleChooserControl1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	}
}
