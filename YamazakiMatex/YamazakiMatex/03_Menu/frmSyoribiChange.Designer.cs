namespace Menu
{
    partial class frmSyoribiChange
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExecution = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.pnlProcessingDate = new System.Windows.Forms.Panel();
            this.lblProcessingDateDays = new System.Windows.Forms.Label();
            this.txtProcessingDateDays = new Common.CustomTextBox();
            this.txtProcessingDateMonth = new Common.CustomTextBox();
            this.txtProcessingDateYears = new Common.CustomTextBox();
            this.lblProcessingDateMonth = new System.Windows.Forms.Label();
            this.lblProcessingDateYears = new System.Windows.Forms.Label();
            this.dtpProcessingDate = new Common.CustomDateTimePicker();
            this.lblProcessingDate = new Common.ItemHeadLabel();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlProcessingDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblProcessingDate);
            this.pnlHeader.Controls.Add(this.pnlProcessingDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(482, 77);
            this.pnlHeader.TabIndex = 104;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnExecution);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 77);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(482, 70);
            this.pnlBottom.TabIndex = 107;
            // 
            // btnExecution
            // 
            this.btnExecution.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecution.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecution.Location = new System.Drawing.Point(31, 14);
            this.btnExecution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExecution.Name = "btnExecution";
            this.btnExecution.Size = new System.Drawing.Size(200, 40);
            this.btnExecution.TabIndex = 461;
            this.btnExecution.Text = "F10：変更してログイン";
            this.btnExecution.UseVisualStyleBackColor = false;
            this.btnExecution.Click += new System.EventHandler(this.btnExecution_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(239, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(202, 40);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "F12：変更せずログイン";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlProcessingDate
            // 
            this.pnlProcessingDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlProcessingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessingDate.Controls.Add(this.lblProcessingDateDays);
            this.pnlProcessingDate.Controls.Add(this.txtProcessingDateDays);
            this.pnlProcessingDate.Controls.Add(this.lblProcessingDateMonth);
            this.pnlProcessingDate.Controls.Add(this.txtProcessingDateMonth);
            this.pnlProcessingDate.Controls.Add(this.lblProcessingDateYears);
            this.pnlProcessingDate.Controls.Add(this.txtProcessingDateYears);
            this.pnlProcessingDate.Controls.Add(this.dtpProcessingDate);
            this.pnlProcessingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlProcessingDate.Location = new System.Drawing.Point(115, 37);
            this.pnlProcessingDate.Name = "pnlProcessingDate";
            this.pnlProcessingDate.Size = new System.Drawing.Size(242, 27);
            this.pnlProcessingDate.TabIndex = 395;
            // 
            // lblProcessingDateDays
            // 
            this.lblProcessingDateDays.Location = new System.Drawing.Point(170, 0);
            this.lblProcessingDateDays.Name = "lblProcessingDateDays";
            this.lblProcessingDateDays.Size = new System.Drawing.Size(28, 27);
            this.lblProcessingDateDays.TabIndex = 119;
            this.lblProcessingDateDays.Text = "日";
            this.lblProcessingDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProcessingDateDays
            // 
            this.txtProcessingDateDays.BeforeValue = "";
            this.txtProcessingDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcessingDateDays.DownControl = null;
            this.txtProcessingDateDays.EnterControl = null;
            this.txtProcessingDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtProcessingDateDays.LabelControl = this.lblProcessingDate;
            this.txtProcessingDateDays.LeftControl = this.txtProcessingDateMonth;
            this.txtProcessingDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtProcessingDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProcessingDateDays.Name = "txtProcessingDateDays";
            this.txtProcessingDateDays.RightControl = null;
            this.txtProcessingDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtProcessingDateDays.TabIndex = 100;
            this.txtProcessingDateDays.Text = "12";
            this.txtProcessingDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProcessingDateDays.UpControl = null;
            // 
            // txtProcessingDateMonth
            // 
            this.txtProcessingDateMonth.BeforeValue = "";
            this.txtProcessingDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcessingDateMonth.DownControl = null;
            this.txtProcessingDateMonth.EnterControl = this.txtProcessingDateDays;
            this.txtProcessingDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtProcessingDateMonth.LabelControl = this.lblProcessingDate;
            this.txtProcessingDateMonth.LeftControl = this.txtProcessingDateYears;
            this.txtProcessingDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtProcessingDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProcessingDateMonth.Name = "txtProcessingDateMonth";
            this.txtProcessingDateMonth.RightControl = this.txtProcessingDateDays;
            this.txtProcessingDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtProcessingDateMonth.TabIndex = 90;
            this.txtProcessingDateMonth.Text = "12";
            this.txtProcessingDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProcessingDateMonth.UpControl = null;
            // 
            // txtProcessingDateYears
            // 
            this.txtProcessingDateYears.BeforeValue = "";
            this.txtProcessingDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcessingDateYears.DownControl = null;
            this.txtProcessingDateYears.EnterControl = this.txtProcessingDateMonth;
            this.txtProcessingDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtProcessingDateYears.LabelControl = this.lblProcessingDate;
            this.txtProcessingDateYears.LeftControl = null;
            this.txtProcessingDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtProcessingDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProcessingDateYears.Name = "txtProcessingDateYears";
            this.txtProcessingDateYears.RightControl = this.txtProcessingDateMonth;
            this.txtProcessingDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtProcessingDateYears.TabIndex = 80;
            this.txtProcessingDateYears.Text = "1234";
            this.txtProcessingDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProcessingDateYears.UpControl = null;
            // 
            // lblProcessingDateMonth
            // 
            this.lblProcessingDateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblProcessingDateMonth.Name = "lblProcessingDateMonth";
            this.lblProcessingDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblProcessingDateMonth.TabIndex = 117;
            this.lblProcessingDateMonth.Text = "月";
            this.lblProcessingDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProcessingDateYears
            // 
            this.lblProcessingDateYears.Location = new System.Drawing.Point(51, 0);
            this.lblProcessingDateYears.Name = "lblProcessingDateYears";
            this.lblProcessingDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblProcessingDateYears.TabIndex = 115;
            this.lblProcessingDateYears.Text = "年";
            this.lblProcessingDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpProcessingDate
            // 
            this.dtpProcessingDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpProcessingDate.CustomFormat = " ";
            this.dtpProcessingDate.DaysLinkTextControl = this.txtProcessingDateDays;
            this.dtpProcessingDate.DownControl = null;
            this.dtpProcessingDate.EnterControl = null;
            this.dtpProcessingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProcessingDate.LeftControl = this.txtProcessingDateDays;
            this.dtpProcessingDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpProcessingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpProcessingDate.MonthLinkTextControl = this.txtProcessingDateMonth;
            this.dtpProcessingDate.Name = "dtpProcessingDate";
            this.dtpProcessingDate.RightControl = null;
            this.dtpProcessingDate.Size = new System.Drawing.Size(242, 27);
            this.dtpProcessingDate.TabIndex = 110;
            this.dtpProcessingDate.TabStop = false;
            this.dtpProcessingDate.UpControl = null;
            this.dtpProcessingDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpProcessingDate.Value2 = null;
            this.dtpProcessingDate.YearsLinkTextControl = this.txtProcessingDateYears;
            // 
            // lblProcessingDate
            // 
            this.lblProcessingDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblProcessingDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProcessingDate.ForeColor = System.Drawing.Color.White;
            this.lblProcessingDate.Location = new System.Drawing.Point(115, 13);
            this.lblProcessingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcessingDate.Name = "lblProcessingDate";
            this.lblProcessingDate.Size = new System.Drawing.Size(242, 24);
            this.lblProcessingDate.TabIndex = 394;
            this.lblProcessingDate.Text = "処理日付";
            this.lblProcessingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSyoribiChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 147);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmSyoribiChange";
            this.Text = "処理日付変更";
            this.Load += new System.EventHandler(this.frmShiharaiShimebiKoshin_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlProcessingDate.ResumeLayout(false);
            this.pnlProcessingDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnExecution;
        private Common.ItemHeadLabel lblProcessingDate;
        private System.Windows.Forms.Panel pnlProcessingDate;
        private System.Windows.Forms.Label lblProcessingDateDays;
        private Common.CustomTextBox txtProcessingDateDays;
        private Common.CustomTextBox txtProcessingDateMonth;
        private Common.CustomTextBox txtProcessingDateYears;
        private System.Windows.Forms.Label lblProcessingDateMonth;
        private System.Windows.Forms.Label lblProcessingDateYears;
        private Common.CustomDateTimePicker dtpProcessingDate;
    }
}