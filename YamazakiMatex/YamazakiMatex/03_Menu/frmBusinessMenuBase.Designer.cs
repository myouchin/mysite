namespace Menu
{
    partial class frmBusinessMenuBase
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.featuresButton1 = new Common.FeaturesButton();
            this.featuresButton4 = new Common.FeaturesButton();
            this.pnlBtmMenu = new System.Windows.Forms.Panel();
            this.pnlMidMenu = new System.Windows.Forms.Panel();
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.featuresButton1);
            this.panel2.Controls.Add(this.featuresButton4);
            this.panel2.Controls.Add(this.pnlBtmMenu);
            this.panel2.Controls.Add(this.pnlMidMenu);
            this.panel2.Controls.Add(this.pnlTopMenu);
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 671);
            this.panel2.TabIndex = 3;
            // 
            // featuresButton1
            // 
            this.featuresButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton1.Location = new System.Drawing.Point(685, 578);
            this.featuresButton1.Name = "featuresButton1";
            this.featuresButton1.Size = new System.Drawing.Size(300, 64);
            this.featuresButton1.TabIndex = 19;
            this.featuresButton1.Text = "戻る";
            this.featuresButton1.UseVisualStyleBackColor = false;
            this.featuresButton1.Click += new System.EventHandler(this.featuresButton1_Click);
            // 
            // featuresButton4
            // 
            this.featuresButton4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton4.Location = new System.Drawing.Point(25, 578);
            this.featuresButton4.Name = "featuresButton4";
            this.featuresButton4.Size = new System.Drawing.Size(300, 64);
            this.featuresButton4.TabIndex = 18;
            this.featuresButton4.Text = "メインメニュー";
            this.featuresButton4.UseVisualStyleBackColor = false;
            this.featuresButton4.Click += new System.EventHandler(this.featuresButton4_Click);
            // 
            // pnlBtmMenu
            // 
            this.pnlBtmMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBtmMenu.Location = new System.Drawing.Point(674, 12);
            this.pnlBtmMenu.Name = "pnlBtmMenu";
            this.pnlBtmMenu.Size = new System.Drawing.Size(326, 560);
            this.pnlBtmMenu.TabIndex = 14;
            this.pnlBtmMenu.TabStop = true;
            // 
            // pnlMidMenu
            // 
            this.pnlMidMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMidMenu.Location = new System.Drawing.Point(342, 12);
            this.pnlMidMenu.Name = "pnlMidMenu";
            this.pnlMidMenu.Size = new System.Drawing.Size(326, 560);
            this.pnlMidMenu.TabIndex = 13;
            this.pnlMidMenu.TabStop = true;
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTopMenu.Location = new System.Drawing.Point(10, 12);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(326, 560);
            this.pnlTopMenu.TabIndex = 12;
            this.pnlTopMenu.TabStop = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1016, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "業務メニュータイトル";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBusinessMenuBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 738);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmBusinessMenuBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Panel pnlMidMenu;
        private System.Windows.Forms.Panel pnlBtmMenu;
        private Common.FeaturesButton featuresButton4;
        private Common.FeaturesButton featuresButton1;
    }
}