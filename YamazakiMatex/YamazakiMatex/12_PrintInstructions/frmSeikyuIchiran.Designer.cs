namespace PrintInstructions
{
    partial class frmSeikyuIchiran
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
            this.txtCustomerCode = new Common.CustomTextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblOffices = new Common.ItemHeadLabel();
            this.cmbOffices = new Common.CustomComboBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.lblBillingDate = new Common.ItemHeadLabel();
            this.pnlBillingDate = new System.Windows.Forms.Panel();
            this.lblBillingDateDays = new System.Windows.Forms.Label();
            this.txtBillingDateDays = new Common.CustomTextBox();
            this.txtBillingDateMonth = new Common.CustomTextBox();
            this.txtBillingDateYears = new Common.CustomTextBox();
            this.lblBillingDateMonth = new System.Windows.Forms.Label();
            this.lblBillingDateYears = new System.Windows.Forms.Label();
            this.dtpBillingDate = new Common.CustomDateTimePicker();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Common.FeaturesButton();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptSeikyuIchiran1 = new YamazakiMatex.Print.Report.rptSeikyuIchiran();
            this.pnlHeader.SuspendLayout();
            this.pnlBillingDate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = null;
            this.txtCustomerCode.EnterControl = null;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(133, 35);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = null;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 58;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = null;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblOffices);
            this.pnlHeader.Controls.Add(this.cmbOffices);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblBillingDate);
            this.pnlHeader.Controls.Add(this.pnlBillingDate);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(692, 97);
            this.pnlHeader.TabIndex = 103;
            // 
            // lblOffices
            // 
            this.lblOffices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffices.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffices.ForeColor = System.Drawing.Color.White;
            this.lblOffices.Location = new System.Drawing.Point(3, 63);
            this.lblOffices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffices.Name = "lblOffices";
            this.lblOffices.Size = new System.Drawing.Size(130, 27);
            this.lblOffices.TabIndex = 374;
            this.lblOffices.Text = "事業所";
            this.lblOffices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbOffices
            // 
            this.cmbOffices.BeforeSelectedValue = "";
            this.cmbOffices.DownControl = null;
            this.cmbOffices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffices.EnterControl = null;
            this.cmbOffices.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.LabelControl = null;
            this.cmbOffices.LeftControl = null;
            this.cmbOffices.Location = new System.Drawing.Point(133, 63);
            this.cmbOffices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.RightControl = null;
            this.cmbOffices.Size = new System.Drawing.Size(146, 27);
            this.cmbOffices.TabIndex = 373;
            this.cmbOffices.UpControl = null;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = null;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.EnterControl = null;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = null;
            this.txtCustomerName.Location = new System.Drawing.Point(264, 35);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 40;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = null;
            this.txtCustomerName.Size = new System.Drawing.Size(419, 27);
            this.txtCustomerName.TabIndex = 136;
            this.txtCustomerName.Text = "令令令令令令令令令令令令令令令令令令令令";
            this.txtCustomerName.UpControl = null;
            // 
            // lblBillingDate
            // 
            this.lblBillingDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBillingDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBillingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBillingDate.ForeColor = System.Drawing.Color.White;
            this.lblBillingDate.Location = new System.Drawing.Point(3, 7);
            this.lblBillingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillingDate.Name = "lblBillingDate";
            this.lblBillingDate.Size = new System.Drawing.Size(130, 27);
            this.lblBillingDate.TabIndex = 135;
            this.lblBillingDate.Text = "請求年月日";
            this.lblBillingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBillingDate
            // 
            this.pnlBillingDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBillingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillingDate.Controls.Add(this.lblBillingDateDays);
            this.pnlBillingDate.Controls.Add(this.txtBillingDateDays);
            this.pnlBillingDate.Controls.Add(this.lblBillingDateMonth);
            this.pnlBillingDate.Controls.Add(this.txtBillingDateMonth);
            this.pnlBillingDate.Controls.Add(this.lblBillingDateYears);
            this.pnlBillingDate.Controls.Add(this.txtBillingDateYears);
            this.pnlBillingDate.Controls.Add(this.dtpBillingDate);
            this.pnlBillingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlBillingDate.Location = new System.Drawing.Point(133, 7);
            this.pnlBillingDate.Name = "pnlBillingDate";
            this.pnlBillingDate.Size = new System.Drawing.Size(240, 27);
            this.pnlBillingDate.TabIndex = 134;
            // 
            // lblBillingDateDays
            // 
            this.lblBillingDateDays.Location = new System.Drawing.Point(170, 0);
            this.lblBillingDateDays.Name = "lblBillingDateDays";
            this.lblBillingDateDays.Size = new System.Drawing.Size(34, 27);
            this.lblBillingDateDays.TabIndex = 119;
            this.lblBillingDateDays.Text = "日";
            this.lblBillingDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBillingDateDays
            // 
            this.txtBillingDateDays.BeforeValue = "";
            this.txtBillingDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateDays.DownControl = null;
            this.txtBillingDateDays.EnterControl = this.txtCustomerCode;
            this.txtBillingDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateDays.LabelControl = null;
            this.txtBillingDateDays.LeftControl = this.txtBillingDateMonth;
            this.txtBillingDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtBillingDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateDays.Name = "txtBillingDateDays";
            this.txtBillingDateDays.RightControl = null;
            this.txtBillingDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtBillingDateDays.TabIndex = 100;
            this.txtBillingDateDays.Text = "12";
            this.txtBillingDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateDays.UpControl = null;
            // 
            // txtBillingDateMonth
            // 
            this.txtBillingDateMonth.BeforeValue = "";
            this.txtBillingDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateMonth.DownControl = null;
            this.txtBillingDateMonth.EnterControl = this.txtBillingDateDays;
            this.txtBillingDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateMonth.LabelControl = null;
            this.txtBillingDateMonth.LeftControl = this.txtBillingDateYears;
            this.txtBillingDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtBillingDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateMonth.Name = "txtBillingDateMonth";
            this.txtBillingDateMonth.RightControl = this.txtBillingDateDays;
            this.txtBillingDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtBillingDateMonth.TabIndex = 90;
            this.txtBillingDateMonth.Text = "12";
            this.txtBillingDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateMonth.UpControl = null;
            // 
            // txtBillingDateYears
            // 
            this.txtBillingDateYears.BeforeValue = "";
            this.txtBillingDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateYears.DownControl = null;
            this.txtBillingDateYears.EnterControl = this.txtBillingDateMonth;
            this.txtBillingDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateYears.LabelControl = null;
            this.txtBillingDateYears.LeftControl = null;
            this.txtBillingDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtBillingDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateYears.Name = "txtBillingDateYears";
            this.txtBillingDateYears.RightControl = this.txtBillingDateMonth;
            this.txtBillingDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtBillingDateYears.TabIndex = 80;
            this.txtBillingDateYears.Text = "1234";
            this.txtBillingDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateYears.UpControl = null;
            // 
            // lblBillingDateMonth
            // 
            this.lblBillingDateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblBillingDateMonth.Name = "lblBillingDateMonth";
            this.lblBillingDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblBillingDateMonth.TabIndex = 117;
            this.lblBillingDateMonth.Text = "月";
            this.lblBillingDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBillingDateYears
            // 
            this.lblBillingDateYears.Location = new System.Drawing.Point(51, 0);
            this.lblBillingDateYears.Name = "lblBillingDateYears";
            this.lblBillingDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblBillingDateYears.TabIndex = 115;
            this.lblBillingDateYears.Text = "年";
            this.lblBillingDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpBillingDate
            // 
            this.dtpBillingDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpBillingDate.CustomFormat = " ";
            this.dtpBillingDate.DaysLinkTextControl = this.txtBillingDateDays;
            this.dtpBillingDate.DownControl = null;
            this.dtpBillingDate.EnterControl = null;
            this.dtpBillingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpBillingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillingDate.LeftControl = this.txtBillingDateDays;
            this.dtpBillingDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpBillingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpBillingDate.MonthLinkTextControl = this.txtBillingDateMonth;
            this.dtpBillingDate.Name = "dtpBillingDate";
            this.dtpBillingDate.RightControl = null;
            this.dtpBillingDate.Size = new System.Drawing.Size(240, 27);
            this.dtpBillingDate.TabIndex = 110;
            this.dtpBillingDate.TabStop = false;
            this.dtpBillingDate.UpControl = null;
            this.dtpBillingDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpBillingDate.Value2 = null;
            this.dtpBillingDate.YearsLinkTextControl = this.txtBillingDateYears;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(3, 35);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 60;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 97);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(692, 4);
            this.pnlBody.TabIndex = 104;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 101);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 70);
            this.panel1.TabIndex = 451;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 502;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(117, 15);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(146, 40);
            this.btnPreview.TabIndex = 501;
            this.btnPreview.Text = "F3：プレビュー";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(271, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 40);
            this.btnPrint.TabIndex = 470;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(567, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSeikyuIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(692, 172);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSeikyuIchiran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "請求一覧出力";
            this.Load += new System.EventHandler(this.frmSeikyuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBillingDate.ResumeLayout(false);
            this.pnlBillingDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtCustomerCode;
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnClose;
        private Common.ItemHeadLabel lblBillingDate;
        private System.Windows.Forms.Panel pnlBillingDate;
        private System.Windows.Forms.Label lblBillingDateDays;
        private Common.CustomTextBox txtBillingDateDays;
        private Common.CustomTextBox txtBillingDateMonth;
        private Common.CustomTextBox txtBillingDateYears;
        private System.Windows.Forms.Label lblBillingDateMonth;
        private System.Windows.Forms.Label lblBillingDateYears;
        private Common.CustomDateTimePicker dtpBillingDate;
        private Common.FeaturesButton btnSearch;
        private Common.CustomTextBox txtCustomerName;
        private YamazakiMatex.Print.Report.rptSeikyuIchiran rptSeikyuIchiran1;
        private Common.ItemHeadLabel lblOffices;
        private Common.CustomComboBox cmbOffices;
    }
}