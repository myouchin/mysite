namespace PrintInstructions
{
    partial class frmShireMototyo
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
            this.lblVendorName = new System.Windows.Forms.Label();
            this.txtVendorCode = new Common.CustomTextBox();
            this.lblVendorCode = new Common.ItemHeadLabel();
            this.pnlTargetDateFrom = new System.Windows.Forms.Panel();
            this.lblTargetDateMonth = new System.Windows.Forms.Label();
            this.txtTargetDateMonth = new Common.CustomTextBox();
            this.txtTargetDateYears = new Common.CustomTextBox();
            this.lblTargetDateYears = new System.Windows.Forms.Label();
            this.dtpTargetDate = new Common.CustomDateTimePicker();
            this.lblTargetDate = new Common.ItemHeadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Common.FeaturesButton();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptSireMotocho1 = new YamazakiMatex.Print.Report.rptSireMotocho();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetDateFrom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblVendorName);
            this.pnlHeader.Controls.Add(this.txtVendorCode);
            this.pnlHeader.Controls.Add(this.lblVendorCode);
            this.pnlHeader.Controls.Add(this.pnlTargetDateFrom);
            this.pnlHeader.Controls.Add(this.lblTargetDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(822, 105);
            this.pnlHeader.TabIndex = 103;
            // 
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.SystemColors.Control;
            this.lblVendorName.Location = new System.Drawing.Point(364, 53);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(419, 27);
            this.lblVendorName.TabIndex = 206;
            this.lblVendorName.Text = "令令令令令令令令令令令令令令令令令令令令";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.BeforeValue = "";
            this.txtVendorCode.DownControl = null;
            this.txtVendorCode.EnterControl = null;
            this.txtVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCode.LabelControl = null;
            this.txtVendorCode.LeftControl = null;
            this.txtVendorCode.Location = new System.Drawing.Point(204, 53);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightControl = null;
            this.txtVendorCode.Size = new System.Drawing.Size(153, 27);
            this.txtVendorCode.TabIndex = 204;
            this.txtVendorCode.Text = "XXXXXXX8";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorCode.UpControl = null;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.ForeColor = System.Drawing.Color.White;
            this.lblVendorCode.Location = new System.Drawing.Point(73, 53);
            this.lblVendorCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(130, 27);
            this.lblVendorCode.TabIndex = 202;
            this.lblVendorCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTargetDateFrom
            // 
            this.pnlTargetDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetDateFrom.Controls.Add(this.lblTargetDateMonth);
            this.pnlTargetDateFrom.Controls.Add(this.txtTargetDateMonth);
            this.pnlTargetDateFrom.Controls.Add(this.lblTargetDateYears);
            this.pnlTargetDateFrom.Controls.Add(this.txtTargetDateYears);
            this.pnlTargetDateFrom.Controls.Add(this.dtpTargetDate);
            this.pnlTargetDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetDateFrom.Location = new System.Drawing.Point(203, 25);
            this.pnlTargetDateFrom.Name = "pnlTargetDateFrom";
            this.pnlTargetDateFrom.Size = new System.Drawing.Size(154, 27);
            this.pnlTargetDateFrom.TabIndex = 136;
            // 
            // lblTargetDateMonth
            // 
            this.lblTargetDateMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetDateMonth.Name = "lblTargetDateMonth";
            this.lblTargetDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetDateMonth.TabIndex = 117;
            this.lblTargetDateMonth.Text = "月";
            this.lblTargetDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetDateMonth
            // 
            this.txtTargetDateMonth.BeforeValue = "";
            this.txtTargetDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetDateMonth.DownControl = null;
            this.txtTargetDateMonth.EnterControl = null;
            this.txtTargetDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetDateMonth.LabelControl = null;
            this.txtTargetDateMonth.LeftControl = this.txtTargetDateYears;
            this.txtTargetDateMonth.Location = new System.Drawing.Point(66, 3);
            this.txtTargetDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetDateMonth.Name = "txtTargetDateMonth";
            this.txtTargetDateMonth.RightControl = null;
            this.txtTargetDateMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetDateMonth.TabIndex = 116;
            this.txtTargetDateMonth.Text = "12";
            this.txtTargetDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetDateMonth.UpControl = null;
            // 
            // txtTargetDateYears
            // 
            this.txtTargetDateYears.BeforeValue = "";
            this.txtTargetDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetDateYears.DownControl = null;
            this.txtTargetDateYears.EnterControl = this.txtTargetDateMonth;
            this.txtTargetDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetDateYears.LabelControl = null;
            this.txtTargetDateYears.LeftControl = null;
            this.txtTargetDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetDateYears.Name = "txtTargetDateYears";
            this.txtTargetDateYears.RightControl = this.txtTargetDateMonth;
            this.txtTargetDateYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetDateYears.TabIndex = 115;
            this.txtTargetDateYears.Text = "1234";
            this.txtTargetDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetDateYears.UpControl = null;
            // 
            // lblTargetDateYears
            // 
            this.lblTargetDateYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetDateYears.Name = "lblTargetDateYears";
            this.lblTargetDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetDateYears.TabIndex = 115;
            this.lblTargetDateYears.Text = "年";
            this.lblTargetDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetDate
            // 
            this.dtpTargetDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetDate.CustomFormat = " ";
            this.dtpTargetDate.DaysLinkTextControl = null;
            this.dtpTargetDate.DownControl = null;
            this.dtpTargetDate.EnterControl = null;
            this.dtpTargetDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetDate.LeftControl = null;
            this.dtpTargetDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetDate.MonthLinkTextControl = this.txtTargetDateMonth;
            this.dtpTargetDate.Name = "dtpTargetDate";
            this.dtpTargetDate.RightControl = null;
            this.dtpTargetDate.Size = new System.Drawing.Size(154, 27);
            this.dtpTargetDate.TabIndex = 132;
            this.dtpTargetDate.UpControl = null;
            this.dtpTargetDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetDate.Value2 = null;
            this.dtpTargetDate.YearsLinkTextControl = this.txtTargetDateYears;
            // 
            // lblTargetDate
            // 
            this.lblTargetDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetDate.ForeColor = System.Drawing.Color.White;
            this.lblTargetDate.Location = new System.Drawing.Point(73, 25);
            this.lblTargetDate.Name = "lblTargetDate";
            this.lblTargetDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetDate.TabIndex = 54;
            this.lblTargetDate.Text = "年月";
            this.lblTargetDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 105);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 70);
            this.panel1.TabIndex = 451;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(4, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 502;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(118, 15);
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
            this.btnPrint.Location = new System.Drawing.Point(272, 15);
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
            this.btnClose.Location = new System.Drawing.Point(701, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShireMototyo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(822, 175);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmShireMototyo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入元帳";
            this.Load += new System.EventHandler(this.frmJyuchachuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTargetDateFrom.ResumeLayout(false);
            this.pnlTargetDateFrom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private Common.ItemHeadLabel lblTargetDate;
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnClose;
        private Common.CustomTextBox txtTargetDateMonth;
        private Common.CustomTextBox txtTargetDateYears;
        private System.Windows.Forms.Panel pnlTargetDateFrom;
        private System.Windows.Forms.Label lblTargetDateMonth;
        private System.Windows.Forms.Label lblTargetDateYears;
        private Common.CustomDateTimePicker dtpTargetDate;
        private System.Windows.Forms.Label lblVendorName;
        private Common.CustomTextBox txtVendorCode;
        private Common.ItemHeadLabel lblVendorCode;
        private Common.FeaturesButton btnSearch;
        private YamazakiMatex.Print.Report.rptSireMotocho rptSireMotocho1;
    }
}