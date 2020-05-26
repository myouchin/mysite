namespace Menu
{
    partial class frmMitumoriTop
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
            this.featuresButton1 = new Common.FeaturesButton();
            this.featuresButton2 = new Common.FeaturesButton();
            this.featuresButton3 = new Common.FeaturesButton();
            this.SuspendLayout();
            // 
            // featuresButton1
            // 
            this.featuresButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton1.Location = new System.Drawing.Point(13, 13);
            this.featuresButton1.Name = "featuresButton1";
            this.featuresButton1.Size = new System.Drawing.Size(300, 50);
            this.featuresButton1.TabIndex = 12;
            this.featuresButton1.Text = "見積モニタ";
            this.featuresButton1.UseVisualStyleBackColor = false;
            this.featuresButton1.Click += new System.EventHandler(this.featuresButton1_Click);
            // 
            // featuresButton2
            // 
            this.featuresButton2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton2.Location = new System.Drawing.Point(13, 69);
            this.featuresButton2.Name = "featuresButton2";
            this.featuresButton2.Size = new System.Drawing.Size(300, 50);
            this.featuresButton2.TabIndex = 13;
            this.featuresButton2.Text = "見積一覧表";
            this.featuresButton2.UseVisualStyleBackColor = false;
            this.featuresButton2.Click += new System.EventHandler(this.featuresButton2_Click);
            // 
            // featuresButton3
            // 
            this.featuresButton3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton3.Location = new System.Drawing.Point(13, 125);
            this.featuresButton3.Name = "featuresButton3";
            this.featuresButton3.Size = new System.Drawing.Size(300, 50);
            this.featuresButton3.TabIndex = 14;
            this.featuresButton3.Text = "宛名印刷";
            this.featuresButton3.UseVisualStyleBackColor = false;
            this.featuresButton3.Click += new System.EventHandler(this.featuresButton3_Click);
            // 
            // frmMitumoriTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(326, 560);
            this.Controls.Add(this.featuresButton3);
            this.Controls.Add(this.featuresButton1);
            this.Controls.Add(this.featuresButton2);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "frmMitumoriTop";
            this.ResumeLayout(false);

        }

        #endregion
        private Common.FeaturesButton featuresButton1;
        private Common.FeaturesButton featuresButton2;
        private Common.FeaturesButton featuresButton3;
    }
}