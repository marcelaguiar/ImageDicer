namespace ImageDicer
{
    partial class frmMain
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
            this.selectImageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.colNumBox = new System.Windows.Forms.NumericUpDown();
            this.rowNumBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(12, 12);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(100, 23);
            this.selectImageButton.TabIndex = 0;
            this.selectImageButton.Text = "Select Image";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# of Columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "# of Rows";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(134, 93);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(115, 23);
            this.nextButton.TabIndex = 6;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // colNumBox
            // 
            this.colNumBox.Location = new System.Drawing.Point(134, 42);
            this.colNumBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.colNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colNumBox.Name = "colNumBox";
            this.colNumBox.Size = new System.Drawing.Size(40, 20);
            this.colNumBox.TabIndex = 7;
            this.colNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rowNumBox
            // 
            this.rowNumBox.Location = new System.Drawing.Point(134, 68);
            this.rowNumBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.rowNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowNumBox.Name = "rowNumBox";
            this.rowNumBox.Size = new System.Drawing.Size(40, 20);
            this.rowNumBox.TabIndex = 8;
            this.rowNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 178);
            this.Controls.Add(this.rowNumBox);
            this.Controls.Add(this.colNumBox);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectImageButton);
            this.Name = "frmMain";
            this.Text = "ImageDicer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.NumericUpDown colNumBox;
        private System.Windows.Forms.NumericUpDown rowNumBox;
    }
}

