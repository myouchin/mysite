namespace Menu
{
    partial class frmUriageShimebiMid
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
            this.featuresButton4 = new Common.FeaturesButton();
            this.featuresButton6 = new Common.FeaturesButton();
            this.featuresButton5 = new Common.FeaturesButton();
            this.SuspendLayout();
            // 
            // featuresButton1
            // 
            this.featuresButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton1.Location = new System.Drawing.Point(13, 13);
            this.featuresButton1.Name = "featuresButton1";
            this.featuresButton1.Size = new System.Drawing.Size(300, 50);
            this.featuresButton1.TabIndex = 7;
            this.featuresButton1.Text = "請求更新";
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
            this.featuresButton2.TabIndex = 8;
            this.featuresButton2.Text = "請求書";
            this.featuresButton2.UseVisualStyleBackColor = false;
            this.featuresButton2.Click += new System.EventHandler(this.featuresButton2_Click);
            // 
            // featuresButton4
            // 
            this.featuresButton4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton4.Location = new System.Drawing.Point(13, 181);
            this.featuresButton4.Name = "featuresButton4";
            this.featuresButton4.Size = new System.Drawing.Size(300, 50);
            this.featuresButton4.TabIndex = 10;
            this.featuresButton4.Text = "請求一覧表";
            this.featuresButton4.UseVisualStyleBackColor = false;
            this.featuresButton4.Click += new System.EventHandler(this.featuresButton4_Click);
            // 
            // featuresButton6
            // 
            this.featuresButton6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton6.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton6.Location = new System.Drawing.Point(13, 237);
            this.featuresButton6.Name = "featuresButton6";
            this.featuresButton6.Size = new System.Drawing.Size(300, 50);
            this.featuresButton6.TabIndex = 12;
            this.featuresButton6.Text = "得意先別回収予定表";
            this.featuresButton6.UseVisualStyleBackColor = false;
            this.featuresButton6.Click += new System.EventHandler(this.featuresButton6_Click);
            // 
            // featuresButton5
            // 
            this.featuresButton5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton5.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton5.Location = new System.Drawing.Point(13, 293);
            this.featuresButton5.Name = "featuresButton5";
            this.featuresButton5.Size = new System.Drawing.Size(300, 50);
            this.featuresButton5.TabIndex = 14;
            this.featuresButton5.Text = "得意先別売上元帳";
            this.featuresButton5.UseVisualStyleBackColor = false;
            this.featuresButton5.Click += new System.EventHandler(this.featuresButton5_Click);
            // 
            // frmUriageShimebiMid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(326, 560);
            this.Controls.Add(this.featuresButton5);
            this.Controls.Add(this.featuresButton6);
            this.Controls.Add(this.featuresButton4);
            this.Controls.Add(this.featuresButton2);
            this.Controls.Add(this.featuresButton1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "frmUriageShimebiMid";
            this.ResumeLayout(false);

        }

        #endregion

        private Common.FeaturesButton featuresButton1;
        private Common.FeaturesButton featuresButton2;
        private Common.FeaturesButton featuresButton4;
        private Common.FeaturesButton featuresButton6;
        private Common.FeaturesButton featuresButton5;
    }
}