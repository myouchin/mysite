namespace Menu
{
    partial class frmUriageNenjiMid
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
            this.featuresButton1.Text = "得意先別売上集計表";
            this.featuresButton1.UseVisualStyleBackColor = false;
            this.featuresButton1.Click += new System.EventHandler(this.featuresButton1_Click);
            // 
            // frmUriageNenjiMid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(326, 560);
            this.Controls.Add(this.featuresButton1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "frmUriageNenjiMid";
            this.ResumeLayout(false);

        }

        #endregion

        private Common.FeaturesButton featuresButton1;
    }
}