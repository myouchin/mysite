namespace PrintInstructions
{
    partial class frmTokuisakiUrikakeMototyo
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
            this.lblTightenDate = new Common.ItemHeadLabel();
            this.pnlTightenDate = new System.Windows.Forms.Panel();
            this.lblTightenDateDays = new System.Windows.Forms.Label();
            this.cmbTightenType = new Common.CustomComboBox();
            this.txtTightenDateMonth = new Common.CustomTextBox();
            this.txtTightenDateYears = new Common.CustomTextBox();
            this.lblTightenDateMonth = new System.Windows.Forms.Label();
            this.lblTightenDateYears = new System.Windows.Forms.Label();
            this.dtpTightenDate = new Common.CustomDateTimePicker();
            this.txtCustomerName = new Common.CustomTextBox();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Common.FeaturesButton();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptTokuisakiUriageMotocyo1 = new YamazakiMatex.Print.Report.rptTokuisakiUriageMotocyo();
            this.pnlHeader.SuspendLayout();
            this.pnlTightenDate.SuspendLayout();
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
            this.txtCustomerCode.Location = new System.Drawing.Point(132, 32);
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
            this.pnlHeader.Controls.Add(this.lblTightenDate);
            this.pnlHeader.Controls.Add(this.pnlTightenDate);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(692, 71);
            this.pnlHeader.TabIndex = 103;
            // 
            // lblTightenDate
            // 
            this.lblTightenDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTightenDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTightenDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTightenDate.ForeColor = System.Drawing.Color.White;
            this.lblTightenDate.Location = new System.Drawing.Point(3, 4);
            this.lblTightenDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTightenDate.Name = "lblTightenDate";
            this.lblTightenDate.Size = new System.Drawing.Size(129, 27);
            this.lblTightenDate.TabIndex = 390;
            this.lblTightenDate.Text = "締年月日";
            this.lblTightenDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTightenDate
            // 
            this.pnlTightenDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTightenDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTightenDate.Controls.Add(this.lblTightenDateDays);
            this.pnlTightenDate.Controls.Add(this.cmbTightenType);
            this.pnlTightenDate.Controls.Add(this.lblTightenDateMonth);
            this.pnlTightenDate.Controls.Add(this.txtTightenDateMonth);
            this.pnlTightenDate.Controls.Add(this.lblTightenDateYears);
            this.pnlTightenDate.Controls.Add(this.txtTightenDateYears);
            this.pnlTightenDate.Controls.Add(this.dtpTightenDate);
            this.pnlTightenDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTightenDate.Location = new System.Drawing.Point(132, 4);
            this.pnlTightenDate.Name = "pnlTightenDate";
            this.pnlTightenDate.Size = new System.Drawing.Size(297, 27);
            this.pnlTightenDate.TabIndex = 389;
            // 
            // lblTightenDateDays
            // 
            this.lblTightenDateDays.Location = new System.Drawing.Point(234, 0);
            this.lblTightenDateDays.Name = "lblTightenDateDays";
            this.lblTightenDateDays.Size = new System.Drawing.Size(54, 27);
            this.lblTightenDateDays.TabIndex = 389;
            this.lblTightenDateDays.Text = "日締";
            this.lblTightenDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTightenType
            // 
            this.cmbTightenType.BeforeSelectedValue = "";
            this.cmbTightenType.DownControl = this.txtCustomerCode;
            this.cmbTightenType.EnterControl = null;
            this.cmbTightenType.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbTightenType.FormattingEnabled = true;
            this.cmbTightenType.LabelControl = null;
            this.cmbTightenType.LeftControl = this.txtTightenDateMonth;
            this.cmbTightenType.Location = new System.Drawing.Point(170, -1);
            this.cmbTightenType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTightenType.Name = "cmbTightenType";
            this.cmbTightenType.RightControl = null;
            this.cmbTightenType.Size = new System.Drawing.Size(62, 27);
            this.cmbTightenType.TabIndex = 389;
            this.cmbTightenType.Text = "Ｘ２";
            this.cmbTightenType.UpControl = null;
            // 
            // txtTightenDateMonth
            // 
            this.txtTightenDateMonth.BeforeValue = "";
            this.txtTightenDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTightenDateMonth.DownControl = this.txtCustomerCode;
            this.txtTightenDateMonth.EnterControl = this.cmbTightenType;
            this.txtTightenDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTightenDateMonth.LabelControl = null;
            this.txtTightenDateMonth.LeftControl = this.txtTightenDateYears;
            this.txtTightenDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtTightenDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTightenDateMonth.Name = "txtTightenDateMonth";
            this.txtTightenDateMonth.RightControl = this.cmbTightenType;
            this.txtTightenDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtTightenDateMonth.TabIndex = 90;
            this.txtTightenDateMonth.Text = "12";
            this.txtTightenDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTightenDateMonth.UpControl = null;
            // 
            // txtTightenDateYears
            // 
            this.txtTightenDateYears.BeforeValue = "";
            this.txtTightenDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTightenDateYears.DownControl = this.txtCustomerCode;
            this.txtTightenDateYears.EnterControl = this.txtTightenDateMonth;
            this.txtTightenDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTightenDateYears.LabelControl = null;
            this.txtTightenDateYears.LeftControl = this.cmbTightenType;
            this.txtTightenDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtTightenDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTightenDateYears.Name = "txtTightenDateYears";
            this.txtTightenDateYears.RightControl = this.txtTightenDateMonth;
            this.txtTightenDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtTightenDateYears.TabIndex = 80;
            this.txtTightenDateYears.Text = "1234";
            this.txtTightenDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTightenDateYears.UpControl = null;
            // 
            // lblTightenDateMonth
            // 
            this.lblTightenDateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblTightenDateMonth.Name = "lblTightenDateMonth";
            this.lblTightenDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTightenDateMonth.TabIndex = 117;
            this.lblTightenDateMonth.Text = "月";
            this.lblTightenDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTightenDateYears
            // 
            this.lblTightenDateYears.Location = new System.Drawing.Point(51, 0);
            this.lblTightenDateYears.Name = "lblTightenDateYears";
            this.lblTightenDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblTightenDateYears.TabIndex = 115;
            this.lblTightenDateYears.Text = "年";
            this.lblTightenDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTightenDate
            // 
            this.dtpTightenDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTightenDate.CustomFormat = " ";
            this.dtpTightenDate.DaysLinkTextControl = null;
            this.dtpTightenDate.DownControl = this.txtCustomerCode;
            this.dtpTightenDate.EnterControl = this.cmbTightenType;
            this.dtpTightenDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTightenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTightenDate.LeftControl = this.txtTightenDateMonth;
            this.dtpTightenDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpTightenDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTightenDate.MonthLinkTextControl = this.txtTightenDateMonth;
            this.dtpTightenDate.Name = "dtpTightenDate";
            this.dtpTightenDate.RightControl = this.cmbTightenType;
            this.dtpTightenDate.Size = new System.Drawing.Size(172, 27);
            this.dtpTightenDate.TabIndex = 110;
            this.dtpTightenDate.TabStop = false;
            this.dtpTightenDate.UpControl = null;
            this.dtpTightenDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTightenDate.Value2 = null;
            this.dtpTightenDate.YearsLinkTextControl = this.txtTightenDateYears;
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
            this.txtCustomerName.Location = new System.Drawing.Point(263, 32);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 40;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = null;
            this.txtCustomerName.Size = new System.Drawing.Size(419, 27);
            this.txtCustomerName.TabIndex = 136;
            this.txtCustomerName.Text = "令令令令令令令令令令令令令令令令令令令令";
            this.txtCustomerName.UpControl = null;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(2, 32);
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
            this.pnlBody.Location = new System.Drawing.Point(0, 71);
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
            this.panel1.Location = new System.Drawing.Point(0, 75);
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
            // frmTokuisakiUrikakeMototyo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(692, 146);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTokuisakiUrikakeMototyo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先別売掛元帳出力";
            this.Load += new System.EventHandler(this.frmSeikyuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTightenDate.ResumeLayout(false);
            this.pnlTightenDate.PerformLayout();
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
        private Common.FeaturesButton btnSearch;
        private Common.CustomTextBox txtCustomerName;
        private Common.ItemHeadLabel lblTightenDate;
        private System.Windows.Forms.Panel pnlTightenDate;
        private System.Windows.Forms.Label lblTightenDateDays;
        private Common.CustomComboBox cmbTightenType;
        private Common.CustomTextBox txtTightenDateMonth;
        private Common.CustomTextBox txtTightenDateYears;
        private System.Windows.Forms.Label lblTightenDateMonth;
        private System.Windows.Forms.Label lblTightenDateYears;
        private Common.CustomDateTimePicker dtpTightenDate;
        private YamazakiMatex.Print.Report.rptTokuisakiUriageMotocyo rptTokuisakiUriageMotocyo1;
    }
}