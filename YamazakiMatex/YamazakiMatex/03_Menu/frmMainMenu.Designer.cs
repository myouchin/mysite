namespace Menu
{
    partial class frmMainMenu
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnEnd = new Common.FeaturesButton();
            this.btnOrdersManagement = new Common.FeaturesButton();
            this.btnPurchaseManagement = new Common.FeaturesButton();
            this.btnBasicManagement = new Common.FeaturesButton();
            this.btnEstimateManagement = new Common.FeaturesButton();
            this.btnSalesManagement = new Common.FeaturesButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMenu.Controls.Add(this.btnEnd);
            this.pnlMenu.Controls.Add(this.btnOrdersManagement);
            this.pnlMenu.Controls.Add(this.btnPurchaseManagement);
            this.pnlMenu.Controls.Add(this.btnBasicManagement);
            this.pnlMenu.Controls.Add(this.btnEstimateManagement);
            this.pnlMenu.Controls.Add(this.btnSalesManagement);
            this.pnlMenu.Location = new System.Drawing.Point(0, 80);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(987, 623);
            this.pnlMenu.TabIndex = 3;
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnd.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEnd.Location = new System.Drawing.Point(572, 429);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(225, 125);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.Text = "終了";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.featuresButton6_Click);
            // 
            // btnOrdersManagement
            // 
            this.btnOrdersManagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOrdersManagement.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOrdersManagement.Location = new System.Drawing.Point(572, 211);
            this.btnOrdersManagement.Name = "btnOrdersManagement";
            this.btnOrdersManagement.Size = new System.Drawing.Size(225, 125);
            this.btnOrdersManagement.TabIndex = 10;
            this.btnOrdersManagement.Text = "受注管理";
            this.btnOrdersManagement.UseVisualStyleBackColor = false;
            this.btnOrdersManagement.Click += new System.EventHandler(this.featuresButton5_Click);
            // 
            // btnPurchaseManagement
            // 
            this.btnPurchaseManagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPurchaseManagement.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPurchaseManagement.Location = new System.Drawing.Point(572, 48);
            this.btnPurchaseManagement.Name = "btnPurchaseManagement";
            this.btnPurchaseManagement.Size = new System.Drawing.Size(225, 125);
            this.btnPurchaseManagement.TabIndex = 9;
            this.btnPurchaseManagement.Text = "仕入管理";
            this.btnPurchaseManagement.UseVisualStyleBackColor = false;
            this.btnPurchaseManagement.Click += new System.EventHandler(this.featuresButton4_Click);
            // 
            // btnBasicManagement
            // 
            this.btnBasicManagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBasicManagement.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBasicManagement.Location = new System.Drawing.Point(190, 429);
            this.btnBasicManagement.Name = "btnBasicManagement";
            this.btnBasicManagement.Size = new System.Drawing.Size(225, 125);
            this.btnBasicManagement.TabIndex = 8;
            this.btnBasicManagement.Text = "基本管理";
            this.btnBasicManagement.UseVisualStyleBackColor = false;
            this.btnBasicManagement.Click += new System.EventHandler(this.featuresButton3_Click);
            // 
            // btnEstimateManagement
            // 
            this.btnEstimateManagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEstimateManagement.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEstimateManagement.Location = new System.Drawing.Point(190, 211);
            this.btnEstimateManagement.Name = "btnEstimateManagement";
            this.btnEstimateManagement.Size = new System.Drawing.Size(225, 125);
            this.btnEstimateManagement.TabIndex = 7;
            this.btnEstimateManagement.Text = "見積管理";
            this.btnEstimateManagement.UseVisualStyleBackColor = false;
            this.btnEstimateManagement.Click += new System.EventHandler(this.featuresButton2_Click);
            // 
            // btnSalesManagement
            // 
            this.btnSalesManagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalesManagement.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSalesManagement.Location = new System.Drawing.Point(190, 48);
            this.btnSalesManagement.Name = "btnSalesManagement";
            this.btnSalesManagement.Size = new System.Drawing.Size(225, 125);
            this.btnSalesManagement.TabIndex = 6;
            this.btnSalesManagement.Text = "売上管理";
            this.btnSalesManagement.UseVisualStyleBackColor = false;
            this.btnSalesManagement.Click += new System.EventHandler(this.featuresButton1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(987, 80);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "メインメニュー";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 702);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ヤマザキマックス売上・仕入管理";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private Common.FeaturesButton btnEnd;
        private Common.FeaturesButton btnOrdersManagement;
        private Common.FeaturesButton btnPurchaseManagement;
        private Common.FeaturesButton btnBasicManagement;
        private Common.FeaturesButton btnEstimateManagement;
        private Common.FeaturesButton btnSalesManagement;
        private System.Windows.Forms.Label lblTitle;
    }
}