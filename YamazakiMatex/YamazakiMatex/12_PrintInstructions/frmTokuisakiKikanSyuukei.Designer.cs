namespace PrintInstructions
{
    partial class frmTokuisakiKikanSyuukei
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlPrintMode = new System.Windows.Forms.Panel();
            this.lblShiireSelectMode = new Common.ItemHeadLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new Common.FeaturesButton();
            this.dtpOrderDateTo = new Common.CustomDateTimePicker();
            this.dtpOrderDateFrom = new Common.CustomDateTimePicker();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblOrderDate = new Common.ItemHeadLabel();
            this.lblCustomerCharactersName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtCustomerCharactersName = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.featuresButton1 = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlPrintMode.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblCustomerCharactersName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCharactersName);
            this.pnlHeader.Controls.Add(this.dtpOrderDateTo);
            this.pnlHeader.Controls.Add(this.dtpOrderDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblOrderDate);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlPrintMode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(639, 178);
            this.pnlHeader.TabIndex = 103;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SlateGray;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(635, 40);
            this.lblTitle.TabIndex = 52;
            this.lblTitle.Text = "買掛金一覧表";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPrintMode
            // 
            this.pnlPrintMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPrintMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPrintMode.Controls.Add(this.rdoCustomer);
            this.pnlPrintMode.Controls.Add(this.radioButton1);
            this.pnlPrintMode.Controls.Add(this.lblShiireSelectMode);
            this.pnlPrintMode.Location = new System.Drawing.Point(4, 43);
            this.pnlPrintMode.Name = "pnlPrintMode";
            this.pnlPrintMode.Size = new System.Drawing.Size(241, 68);
            this.pnlPrintMode.TabIndex = 51;
            // 
            // lblShiireSelectMode
            // 
            this.lblShiireSelectMode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblShiireSelectMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShiireSelectMode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShiireSelectMode.ForeColor = System.Drawing.Color.White;
            this.lblShiireSelectMode.Location = new System.Drawing.Point(5, 2);
            this.lblShiireSelectMode.Name = "lblShiireSelectMode";
            this.lblShiireSelectMode.Size = new System.Drawing.Size(176, 27);
            this.lblShiireSelectMode.TabIndex = 4;
            this.lblShiireSelectMode.Text = "得意先選択モード";
            this.lblShiireSelectMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.featuresButton1);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 178);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(639, 70);
            this.pnlBottom.TabIndex = 105;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(515, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpOrderDateTo
            // 
            this.dtpOrderDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateTo.CustomFormat = "yyyy年MM月dd日";
            this.dtpOrderDateTo.DownControl = null;
            this.dtpOrderDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDateTo.LeftControl = null;
            this.dtpOrderDateTo.Location = new System.Drawing.Point(354, 142);
            this.dtpOrderDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpOrderDateTo.Name = "dtpOrderDateTo";
            this.dtpOrderDateTo.RightControl = null;
            this.dtpOrderDateTo.Size = new System.Drawing.Size(177, 27);
            this.dtpOrderDateTo.TabIndex = 89;
            this.dtpOrderDateTo.UpControl = null;
            this.dtpOrderDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            // 
            // dtpOrderDateFrom
            // 
            this.dtpOrderDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateFrom.CustomFormat = "yyyy年MM月dd日";
            this.dtpOrderDateFrom.DownControl = null;
            this.dtpOrderDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDateFrom.LeftControl = null;
            this.dtpOrderDateFrom.Location = new System.Drawing.Point(134, 142);
            this.dtpOrderDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpOrderDateFrom.Name = "dtpOrderDateFrom";
            this.dtpOrderDateFrom.RightControl = null;
            this.dtpOrderDateFrom.Size = new System.Drawing.Size(177, 27);
            this.dtpOrderDateFrom.TabIndex = 88;
            this.dtpOrderDateFrom.UpControl = null;
            this.dtpOrderDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.AutoSize = true;
            this.lblFromToSeparated2.Location = new System.Drawing.Point(318, 147);
            this.lblFromToSeparated2.Name = "lblFromToSeparated2";
            this.lblFromToSeparated2.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated2.TabIndex = 87;
            this.lblFromToSeparated2.Text = "～";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrderDate.ForeColor = System.Drawing.Color.White;
            this.lblOrderDate.Location = new System.Drawing.Point(4, 142);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(130, 27);
            this.lblOrderDate.TabIndex = 86;
            this.lblOrderDate.Text = "集計期間";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCharactersName
            // 
            this.lblCustomerCharactersName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCharactersName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCharactersName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCharactersName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCharactersName.Location = new System.Drawing.Point(265, 114);
            this.lblCustomerCharactersName.Name = "lblCustomerCharactersName";
            this.lblCustomerCharactersName.Size = new System.Drawing.Size(150, 27);
            this.lblCustomerCharactersName.TabIndex = 93;
            this.lblCustomerCharactersName.Text = "得意先漢字名";
            this.lblCustomerCharactersName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(4, 114);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 92;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.Location = new System.Drawing.Point(134, 114);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 90;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustomerCharactersName
            // 
            this.txtCustomerCharactersName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCharactersName.Location = new System.Drawing.Point(415, 114);
            this.txtCustomerCharactersName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCharactersName.Name = "txtCustomerCharactersName";
            this.txtCustomerCharactersName.Size = new System.Drawing.Size(216, 27);
            this.txtCustomerCharactersName.TabIndex = 91;
            this.txtCustomerCharactersName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton1.Location = new System.Drawing.Point(15, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全件";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCustomer.Location = new System.Drawing.Point(90, 32);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(132, 24);
            this.rdoCustomer.TabIndex = 6;
            this.rdoCustomer.TabStop = true;
            this.rdoCustomer.Text = "得意先選択";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            // 
            // featuresButton1
            // 
            this.featuresButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.featuresButton1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.featuresButton1.Location = new System.Drawing.Point(4, 15);
            this.featuresButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.featuresButton1.Name = "featuresButton1";
            this.featuresButton1.Size = new System.Drawing.Size(116, 40);
            this.featuresButton1.TabIndex = 35;
            this.featuresButton1.Text = "F1：印刷";
            this.featuresButton1.UseVisualStyleBackColor = false;
            // 
            // frmTokuisakiKikanSyuukei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(639, 249);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTokuisakiKikanSyuukei";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "買掛金一覧表";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPrintMode.ResumeLayout(false);
            this.pnlPrintMode.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlPrintMode;
        private Common.ItemHeadLabel lblShiireSelectMode;
        private System.Windows.Forms.Label lblTitle;
        private Common.FeaturesButton btnClose;
        private Common.CustomDateTimePicker dtpOrderDateTo;
        private Common.CustomDateTimePicker dtpOrderDateFrom;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.ItemHeadLabel lblOrderDate;
        private Common.ItemHeadLabel lblCustomerCharactersName;
        private Common.ItemHeadLabel lblCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerCharactersName;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoCustomer;
        private Common.FeaturesButton featuresButton1;
    }
}