namespace PrintInstructions
{
    partial class frmJyuchachuIchiran
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
            this.txtTargetYmYears = new Common.CustomTextBox();
            this.txtTargetYmMonth = new Common.CustomTextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTargetYm = new System.Windows.Forms.Panel();
            this.lblTargetYmMonth = new System.Windows.Forms.Label();
            this.lblTargetYmYears = new System.Windows.Forms.Label();
            this.dtpTargetYm = new Common.CustomDateTimePicker();
            this.lblTargetYm = new Common.ItemHeadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptJyuchachuIchiran1 = new YamazakiMatex.Print.Report.rptJyuchachuIchiran();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetYm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTargetYmYears
            // 
            this.txtTargetYmYears.BeforeValue = "";
            this.txtTargetYmYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYmYears.DownControl = null;
            this.txtTargetYmYears.EnterControl = this.txtTargetYmMonth;
            this.txtTargetYmYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYmYears.LabelControl = null;
            this.txtTargetYmYears.LeftControl = null;
            this.txtTargetYmYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYmYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYmYears.Name = "txtTargetYmYears";
            this.txtTargetYmYears.RightControl = this.txtTargetYmMonth;
            this.txtTargetYmYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYmYears.TabIndex = 115;
            this.txtTargetYmYears.Text = "1234";
            this.txtTargetYmYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYmYears.UpControl = null;
            // 
            // txtTargetYmMonth
            // 
            this.txtTargetYmMonth.BeforeValue = "";
            this.txtTargetYmMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYmMonth.DownControl = null;
            this.txtTargetYmMonth.EnterControl = null;
            this.txtTargetYmMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYmMonth.LabelControl = null;
            this.txtTargetYmMonth.LeftControl = this.txtTargetYmYears;
            this.txtTargetYmMonth.Location = new System.Drawing.Point(66, 3);
            this.txtTargetYmMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYmMonth.Name = "txtTargetYmMonth";
            this.txtTargetYmMonth.RightControl = null;
            this.txtTargetYmMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetYmMonth.TabIndex = 116;
            this.txtTargetYmMonth.Text = "12";
            this.txtTargetYmMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYmMonth.UpControl = null;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlTargetYm);
            this.pnlHeader.Controls.Add(this.lblTargetYm);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(503, 75);
            this.pnlHeader.TabIndex = 103;
            // 
            // pnlTargetYm
            // 
            this.pnlTargetYm.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYm.Controls.Add(this.lblTargetYmMonth);
            this.pnlTargetYm.Controls.Add(this.txtTargetYmMonth);
            this.pnlTargetYm.Controls.Add(this.lblTargetYmYears);
            this.pnlTargetYm.Controls.Add(this.txtTargetYmYears);
            this.pnlTargetYm.Controls.Add(this.dtpTargetYm);
            this.pnlTargetYm.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYm.Location = new System.Drawing.Point(237, 25);
            this.pnlTargetYm.Name = "pnlTargetYm";
            this.pnlTargetYm.Size = new System.Drawing.Size(162, 27);
            this.pnlTargetYm.TabIndex = 116;
            // 
            // lblTargetYmMonth
            // 
            this.lblTargetYmMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYmMonth.Name = "lblTargetYmMonth";
            this.lblTargetYmMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYmMonth.TabIndex = 117;
            this.lblTargetYmMonth.Text = "月";
            this.lblTargetYmMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYmYears
            // 
            this.lblTargetYmYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYmYears.Name = "lblTargetYmYears";
            this.lblTargetYmYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYmYears.TabIndex = 115;
            this.lblTargetYmYears.Text = "年";
            this.lblTargetYmYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYm
            // 
            this.dtpTargetYm.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYm.CustomFormat = " ";
            this.dtpTargetYm.DaysLinkTextControl = null;
            this.dtpTargetYm.DownControl = null;
            this.dtpTargetYm.EnterControl = null;
            this.dtpTargetYm.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYm.LeftControl = null;
            this.dtpTargetYm.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYm.MonthLinkTextControl = this.txtTargetYmMonth;
            this.dtpTargetYm.Name = "dtpTargetYm";
            this.dtpTargetYm.RightControl = null;
            this.dtpTargetYm.Size = new System.Drawing.Size(162, 27);
            this.dtpTargetYm.TabIndex = 132;
            this.dtpTargetYm.UpControl = null;
            this.dtpTargetYm.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYm.Value2 = null;
            this.dtpTargetYm.YearsLinkTextControl = this.txtTargetYmYears;
            // 
            // lblTargetYm
            // 
            this.lblTargetYm.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYm.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYm.ForeColor = System.Drawing.Color.White;
            this.lblTargetYm.Location = new System.Drawing.Point(107, 25);
            this.lblTargetYm.Name = "lblTargetYm";
            this.lblTargetYm.Size = new System.Drawing.Size(130, 27);
            this.lblTargetYm.TabIndex = 54;
            this.lblTargetYm.Text = "対象年月";
            this.lblTargetYm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 70);
            this.panel1.TabIndex = 451;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(3, 15);
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
            this.btnPrint.Location = new System.Drawing.Point(157, 15);
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
            this.btnClose.Location = new System.Drawing.Point(380, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmJyuchachuIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(503, 145);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmJyuchachuIchiran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "受発注一覧出力";
            this.Load += new System.EventHandler(this.frmJyuchachuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTargetYm.ResumeLayout(false);
            this.pnlTargetYm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private Common.ItemHeadLabel lblTargetYm;
        private System.Windows.Forms.Panel pnlTargetYm;
        private Common.CustomTextBox txtTargetYmMonth;
        private Common.CustomTextBox txtTargetYmYears;
        private System.Windows.Forms.Label lblTargetYmMonth;
        private System.Windows.Forms.Label lblTargetYmYears;
        private Common.CustomDateTimePicker dtpTargetYm;
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnClose;
        private YamazakiMatex.Print.Report.rptJyuchachuIchiran rptJyuchachuIchiran1;
    }
}