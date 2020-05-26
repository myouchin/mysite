namespace PrintInstructions
{
    partial class frmKenbetsuHibetsuUriageSyukei
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
            this.lblTargetYM = new Common.ItemHeadLabel();
            this.pnlTargetYM = new System.Windows.Forms.Panel();
            this.lblTargetYMMonth = new System.Windows.Forms.Label();
            this.txtTargetYMMonth = new Common.CustomTextBox();
            this.txtTargetYMYears = new Common.CustomTextBox();
            this.lblTargetYMYears = new System.Windows.Forms.Label();
            this.dtpTargetYM = new Common.CustomDateTimePicker();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptKenbetuUriageNikkeihyo1 = new YamazakiMatex.Print.Report.rptKenbetuUriageNikkeihyo();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetYM.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblTargetYM);
            this.pnlHeader.Controls.Add(this.pnlTargetYM);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(486, 42);
            this.pnlHeader.TabIndex = 103;
            // 
            // lblTargetYM
            // 
            this.lblTargetYM.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYM.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYM.ForeColor = System.Drawing.Color.White;
            this.lblTargetYM.Location = new System.Drawing.Point(82, 6);
            this.lblTargetYM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetYM.Name = "lblTargetYM";
            this.lblTargetYM.Size = new System.Drawing.Size(129, 27);
            this.lblTargetYM.TabIndex = 390;
            this.lblTargetYM.Text = "年月";
            this.lblTargetYM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTargetYM
            // 
            this.pnlTargetYM.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYM.Controls.Add(this.lblTargetYMMonth);
            this.pnlTargetYM.Controls.Add(this.txtTargetYMMonth);
            this.pnlTargetYM.Controls.Add(this.lblTargetYMYears);
            this.pnlTargetYM.Controls.Add(this.txtTargetYMYears);
            this.pnlTargetYM.Controls.Add(this.dtpTargetYM);
            this.pnlTargetYM.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYM.Location = new System.Drawing.Point(211, 6);
            this.pnlTargetYM.Name = "pnlTargetYM";
            this.pnlTargetYM.Size = new System.Drawing.Size(172, 27);
            this.pnlTargetYM.TabIndex = 389;
            // 
            // lblTargetYMMonth
            // 
            this.lblTargetYMMonth.Location = new System.Drawing.Point(111, 0);
            this.lblTargetYMMonth.Name = "lblTargetYMMonth";
            this.lblTargetYMMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMMonth.TabIndex = 117;
            this.lblTargetYMMonth.Text = "月";
            this.lblTargetYMMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetYMMonth
            // 
            this.txtTargetYMMonth.BeforeValue = "";
            this.txtTargetYMMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMMonth.DownControl = null;
            this.txtTargetYMMonth.EnterControl = null;
            this.txtTargetYMMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMMonth.LabelControl = null;
            this.txtTargetYMMonth.LeftControl = this.txtTargetYMYears;
            this.txtTargetYMMonth.Location = new System.Drawing.Point(78, 3);
            this.txtTargetYMMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMMonth.Name = "txtTargetYMMonth";
            this.txtTargetYMMonth.RightControl = null;
            this.txtTargetYMMonth.Size = new System.Drawing.Size(33, 20);
            this.txtTargetYMMonth.TabIndex = 90;
            this.txtTargetYMMonth.Text = "12";
            this.txtTargetYMMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMMonth.UpControl = null;
            // 
            // txtTargetYMYears
            // 
            this.txtTargetYMYears.BeforeValue = "";
            this.txtTargetYMYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMYears.DownControl = null;
            this.txtTargetYMYears.EnterControl = this.txtTargetYMMonth;
            this.txtTargetYMYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMYears.LabelControl = null;
            this.txtTargetYMYears.LeftControl = null;
            this.txtTargetYMYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYMYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMYears.Name = "txtTargetYMYears";
            this.txtTargetYMYears.RightControl = this.txtTargetYMMonth;
            this.txtTargetYMYears.Size = new System.Drawing.Size(51, 20);
            this.txtTargetYMYears.TabIndex = 80;
            this.txtTargetYMYears.Text = "1234";
            this.txtTargetYMYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMYears.UpControl = null;
            // 
            // lblTargetYMYears
            // 
            this.lblTargetYMYears.Location = new System.Drawing.Point(51, 0);
            this.lblTargetYMYears.Name = "lblTargetYMYears";
            this.lblTargetYMYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMYears.TabIndex = 115;
            this.lblTargetYMYears.Text = "年";
            this.lblTargetYMYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYM
            // 
            this.dtpTargetYM.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYM.CustomFormat = " ";
            this.dtpTargetYM.DaysLinkTextControl = null;
            this.dtpTargetYM.DownControl = null;
            this.dtpTargetYM.EnterControl = null;
            this.dtpTargetYM.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYM.LeftControl = this.txtTargetYMMonth;
            this.dtpTargetYM.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYM.MonthLinkTextControl = this.txtTargetYMMonth;
            this.dtpTargetYM.Name = "dtpTargetYM";
            this.dtpTargetYM.RightControl = null;
            this.dtpTargetYM.Size = new System.Drawing.Size(172, 27);
            this.dtpTargetYM.TabIndex = 110;
            this.dtpTargetYM.TabStop = false;
            this.dtpTargetYM.UpControl = null;
            this.dtpTargetYM.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYM.Value2 = null;
            this.dtpTargetYM.YearsLinkTextControl = this.txtTargetYMYears;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 42);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(486, 4);
            this.pnlBody.TabIndex = 104;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 70);
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
            this.btnClose.Location = new System.Drawing.Point(354, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmKenbetsuHibetsuUriageSyukei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(486, 112);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKenbetsuHibetsuUriageSyukei";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "県別日別売上集計表";
            this.Load += new System.EventHandler(this.frmSeikyuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTargetYM.ResumeLayout(false);
            this.pnlTargetYM.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnClose;
        private Common.ItemHeadLabel lblTargetYM;
        private System.Windows.Forms.Panel pnlTargetYM;
        private Common.CustomTextBox txtTargetYMMonth;
        private Common.CustomTextBox txtTargetYMYears;
        private System.Windows.Forms.Label lblTargetYMMonth;
        private System.Windows.Forms.Label lblTargetYMYears;
        private Common.CustomDateTimePicker dtpTargetYM;
        private YamazakiMatex.Print.Report.rptKenbetuUriageNikkeihyo rptKenbetuUriageNikkeihyo1;
    }
}