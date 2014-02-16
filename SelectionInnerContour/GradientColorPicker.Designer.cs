namespace SelectionInnerContour
{
	partial class GradientColorPicker
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
			this.hsvAlphaColorPicker1 = new SelectionInnerContour.HsvAlphaColorPicker();
			this.btnRemove = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.hsvAlphaColorPicker1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 273);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// hsvAlphaColorPicker1
			// 
			this.hsvAlphaColorPicker1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.hsvAlphaColorPicker1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hsvAlphaColorPicker1.Location = new System.Drawing.Point(0, 0);
			this.hsvAlphaColorPicker1.Margin = new System.Windows.Forms.Padding(0);
			this.hsvAlphaColorPicker1.Name = "hsvAlphaColorPicker1";
			this.hsvAlphaColorPicker1.Size = new System.Drawing.Size(386, 273);
			this.hsvAlphaColorPicker1.TabIndex = 0;
			this.hsvAlphaColorPicker1.ColorChangedEvent += new SelectionInnerContour.HsvAlphaColorPicker.ColorChangedHandler(this.hsvAlphaColorPicker1_ColorChangedEvent);
			// 
			// btnRemove
			// 
			this.btnRemove.AutoSize = true;
			this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRemove.Location = new System.Drawing.Point(386, 0);
			this.btnRemove.Margin = new System.Windows.Forms.Padding(0);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(24, 23);
			this.btnRemove.TabIndex = 1;
			this.btnRemove.Text = "X";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// GradientColorPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "GradientColorPicker";
			this.Size = new System.Drawing.Size(410, 273);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private HsvAlphaColorPicker hsvAlphaColorPicker1;
		private System.Windows.Forms.Button btnRemove;

	}
}
