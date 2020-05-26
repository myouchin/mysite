namespace UriageIchiran
{
    partial class frmUriageIchiran
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubject = new Common.ItemHeadLabel();
            this.txtSubject1 = new Common.CustomTextBox();
            this.txtSubject2 = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.lblPersonnel = new Common.ItemHeadLabel();
            this.cmbPersonnel = new Common.CustomComboBox();
            this.pnlTargetYMDDateTo = new System.Windows.Forms.Panel();
            this.lblTargetYMDDateToDays = new System.Windows.Forms.Label();
            this.txtTargetYMDDateToDays = new Common.CustomTextBox();
            this.txtTargetYMDDateToMonth = new Common.CustomTextBox();
            this.txtTargetYMDDateToYears = new Common.CustomTextBox();
            this.txtTargetYMDDateFromDays = new Common.CustomTextBox();
            this.txtTargetYMDDateFromMonth = new Common.CustomTextBox();
            this.txtTargetYMDDateFromYears = new Common.CustomTextBox();
            this.lblTargetYMDDateToMonth = new System.Windows.Forms.Label();
            this.lblTargetYMDDateToYears = new System.Windows.Forms.Label();
            this.dtpTargetYMDDateTo = new Common.CustomDateTimePicker();
            this.pnlTargetYMDDateFrom = new System.Windows.Forms.Panel();
            this.lblTargetYMDDateFromDays = new System.Windows.Forms.Label();
            this.lblTargetYMDDateFromMonth = new System.Windows.Forms.Label();
            this.lblTargetYMDDateFromYears = new System.Windows.Forms.Label();
            this.dtpTargetYMDDateFrom = new Common.CustomDateTimePicker();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblTargetYMDDate = new Common.ItemHeadLabel();
            this.lblOfficesCode = new Common.ItemHeadLabel();
            this.txtOfficesName = new Common.CustomTextBox();
            this.txtOfficesCode = new Common.CustomTextBox();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.grdUriageList = new Common.CustomDataGridView();
            this.clmMonthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDenpyoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChumonNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHinmei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSuryo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTanka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKingaku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnListDisp = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetYMDDateTo.SuspendLayout();
            this.pnlTargetYMDDateFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUriageList)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(1170, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 140;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblSubject);
            this.pnlHeader.Controls.Add(this.txtSubject1);
            this.pnlHeader.Controls.Add(this.txtSubject2);
            this.pnlHeader.Controls.Add(this.lblPersonnel);
            this.pnlHeader.Controls.Add(this.cmbPersonnel);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateTo);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblTargetYMDDate);
            this.pnlHeader.Controls.Add(this.lblOfficesCode);
            this.pnlHeader.Controls.Add(this.txtOfficesName);
            this.pnlHeader.Controls.Add(this.txtOfficesCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1408, 105);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubject.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(11, 69);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(130, 27);
            this.lblSubject.TabIndex = 396;
            this.lblSubject.Text = "件名";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSubject1
            // 
            this.txtSubject1.BeforeValue = "";
            this.txtSubject1.DownControl = null;
            this.txtSubject1.EnterControl = this.txtSubject2;
            this.txtSubject1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject1.LabelControl = null;
            this.txtSubject1.LeftControl = null;
            this.txtSubject1.Location = new System.Drawing.Point(141, 69);
            this.txtSubject1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject1.Name = "txtSubject1";
            this.txtSubject1.RightControl = this.txtSubject2;
            this.txtSubject1.Size = new System.Drawing.Size(277, 27);
            this.txtSubject1.TabIndex = 397;
            this.txtSubject1.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０";
            this.txtSubject1.UpControl = this.txtCustomerCode;
            // 
            // txtSubject2
            // 
            this.txtSubject2.BeforeValue = "";
            this.txtSubject2.DownControl = null;
            this.txtSubject2.EnterControl = null;
            this.txtSubject2.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject2.LabelControl = null;
            this.txtSubject2.LeftControl = this.txtSubject1;
            this.txtSubject2.Location = new System.Drawing.Point(417, 69);
            this.txtSubject2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject2.Name = "txtSubject2";
            this.txtSubject2.RightControl = null;
            this.txtSubject2.Size = new System.Drawing.Size(277, 27);
            this.txtSubject2.TabIndex = 398;
            this.txtSubject2.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０";
            this.txtSubject2.UpControl = null;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = null;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(141, 13);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 5;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(90, 27);
            this.txtCustomerCode.TabIndex = 60;
            this.txtCustomerCode.Text = "XXXX5";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = null;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.DownControl = null;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.EnterControl = null;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(239, 16);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = null;
            this.txtCustomerName.Size = new System.Drawing.Size(404, 20);
            this.txtCustomerName.TabIndex = 384;
            this.txtCustomerName.Text = "令令令令令令令令令令令令令令令令令令令令";
            this.txtCustomerName.UpControl = null;
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblPersonnel.Location = new System.Drawing.Point(11, 41);
            this.lblPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(130, 27);
            this.lblPersonnel.TabIndex = 394;
            this.lblPersonnel.Text = "担当者";
            this.lblPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.BeforeSelectedValue = "";
            this.cmbPersonnel.DownControl = null;
            this.cmbPersonnel.EnterControl = this.txtCustomerCode;
            this.cmbPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.LabelControl = null;
            this.cmbPersonnel.LeftControl = null;
            this.cmbPersonnel.Location = new System.Drawing.Point(141, 41);
            this.cmbPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.RightControl = null;
            this.cmbPersonnel.Size = new System.Drawing.Size(277, 27);
            this.cmbPersonnel.TabIndex = 395;
            this.cmbPersonnel.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPersonnel.UpControl = null;
            // 
            // pnlTargetYMDDateTo
            // 
            this.pnlTargetYMDDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYMDDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYMDDateTo.Controls.Add(this.lblTargetYMDDateToDays);
            this.pnlTargetYMDDateTo.Controls.Add(this.txtTargetYMDDateToDays);
            this.pnlTargetYMDDateTo.Controls.Add(this.lblTargetYMDDateToMonth);
            this.pnlTargetYMDDateTo.Controls.Add(this.txtTargetYMDDateToMonth);
            this.pnlTargetYMDDateTo.Controls.Add(this.lblTargetYMDDateToYears);
            this.pnlTargetYMDDateTo.Controls.Add(this.txtTargetYMDDateToYears);
            this.pnlTargetYMDDateTo.Controls.Add(this.dtpTargetYMDDateTo);
            this.pnlTargetYMDDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYMDDateTo.Location = new System.Drawing.Point(1079, 41);
            this.pnlTargetYMDDateTo.Name = "pnlTargetYMDDateTo";
            this.pnlTargetYMDDateTo.Size = new System.Drawing.Size(210, 27);
            this.pnlTargetYMDDateTo.TabIndex = 393;
            // 
            // lblTargetYMDDateToDays
            // 
            this.lblTargetYMDDateToDays.Location = new System.Drawing.Point(148, 0);
            this.lblTargetYMDDateToDays.Name = "lblTargetYMDDateToDays";
            this.lblTargetYMDDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToDays.TabIndex = 119;
            this.lblTargetYMDDateToDays.Text = "日";
            this.lblTargetYMDDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetYMDDateToDays
            // 
            this.txtTargetYMDDateToDays.BeforeValue = "";
            this.txtTargetYMDDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateToDays.DownControl = null;
            this.txtTargetYMDDateToDays.EnterControl = null;
            this.txtTargetYMDDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateToDays.LabelControl = null;
            this.txtTargetYMDDateToDays.LeftControl = this.txtTargetYMDDateToMonth;
            this.txtTargetYMDDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtTargetYMDDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateToDays.Name = "txtTargetYMDDateToDays";
            this.txtTargetYMDDateToDays.RightControl = null;
            this.txtTargetYMDDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtTargetYMDDateToDays.TabIndex = 118;
            this.txtTargetYMDDateToDays.Text = "12";
            this.txtTargetYMDDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateToDays.UpControl = null;
            // 
            // txtTargetYMDDateToMonth
            // 
            this.txtTargetYMDDateToMonth.BeforeValue = "";
            this.txtTargetYMDDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateToMonth.DownControl = null;
            this.txtTargetYMDDateToMonth.EnterControl = this.txtTargetYMDDateToDays;
            this.txtTargetYMDDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateToMonth.LabelControl = null;
            this.txtTargetYMDDateToMonth.LeftControl = this.txtTargetYMDDateToYears;
            this.txtTargetYMDDateToMonth.Location = new System.Drawing.Point(68, 3);
            this.txtTargetYMDDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateToMonth.Name = "txtTargetYMDDateToMonth";
            this.txtTargetYMDDateToMonth.RightControl = this.txtTargetYMDDateToDays;
            this.txtTargetYMDDateToMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetYMDDateToMonth.TabIndex = 116;
            this.txtTargetYMDDateToMonth.Text = "12";
            this.txtTargetYMDDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateToMonth.UpControl = null;
            // 
            // txtTargetYMDDateToYears
            // 
            this.txtTargetYMDDateToYears.BeforeValue = "";
            this.txtTargetYMDDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateToYears.DownControl = null;
            this.txtTargetYMDDateToYears.EnterControl = this.txtTargetYMDDateToMonth;
            this.txtTargetYMDDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateToYears.LabelControl = null;
            this.txtTargetYMDDateToYears.LeftControl = this.txtTargetYMDDateFromDays;
            this.txtTargetYMDDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYMDDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateToYears.Name = "txtTargetYMDDateToYears";
            this.txtTargetYMDDateToYears.RightControl = this.txtTargetYMDDateToMonth;
            this.txtTargetYMDDateToYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYMDDateToYears.TabIndex = 115;
            this.txtTargetYMDDateToYears.Text = "1234";
            this.txtTargetYMDDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateToYears.UpControl = null;
            // 
            // txtTargetYMDDateFromDays
            // 
            this.txtTargetYMDDateFromDays.BeforeValue = "";
            this.txtTargetYMDDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateFromDays.DownControl = null;
            this.txtTargetYMDDateFromDays.EnterControl = this.txtTargetYMDDateToYears;
            this.txtTargetYMDDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateFromDays.LabelControl = null;
            this.txtTargetYMDDateFromDays.LeftControl = this.txtTargetYMDDateFromMonth;
            this.txtTargetYMDDateFromDays.Location = new System.Drawing.Point(115, 3);
            this.txtTargetYMDDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateFromDays.Name = "txtTargetYMDDateFromDays";
            this.txtTargetYMDDateFromDays.RightControl = this.txtTargetYMDDateToYears;
            this.txtTargetYMDDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtTargetYMDDateFromDays.TabIndex = 118;
            this.txtTargetYMDDateFromDays.Text = "12";
            this.txtTargetYMDDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateFromDays.UpControl = null;
            // 
            // txtTargetYMDDateFromMonth
            // 
            this.txtTargetYMDDateFromMonth.BeforeValue = "";
            this.txtTargetYMDDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateFromMonth.DownControl = null;
            this.txtTargetYMDDateFromMonth.EnterControl = this.txtTargetYMDDateFromDays;
            this.txtTargetYMDDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateFromMonth.LabelControl = null;
            this.txtTargetYMDDateFromMonth.LeftControl = this.txtTargetYMDDateFromYears;
            this.txtTargetYMDDateFromMonth.Location = new System.Drawing.Point(66, 3);
            this.txtTargetYMDDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateFromMonth.Name = "txtTargetYMDDateFromMonth";
            this.txtTargetYMDDateFromMonth.RightControl = this.txtTargetYMDDateFromDays;
            this.txtTargetYMDDateFromMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetYMDDateFromMonth.TabIndex = 116;
            this.txtTargetYMDDateFromMonth.Text = "12";
            this.txtTargetYMDDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateFromMonth.UpControl = null;
            // 
            // txtTargetYMDDateFromYears
            // 
            this.txtTargetYMDDateFromYears.BeforeValue = "";
            this.txtTargetYMDDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateFromYears.DownControl = null;
            this.txtTargetYMDDateFromYears.EnterControl = this.txtTargetYMDDateFromMonth;
            this.txtTargetYMDDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateFromYears.LabelControl = null;
            this.txtTargetYMDDateFromYears.LeftControl = null;
            this.txtTargetYMDDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYMDDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateFromYears.Name = "txtTargetYMDDateFromYears";
            this.txtTargetYMDDateFromYears.RightControl = this.txtTargetYMDDateFromMonth;
            this.txtTargetYMDDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYMDDateFromYears.TabIndex = 115;
            this.txtTargetYMDDateFromYears.Text = "1234";
            this.txtTargetYMDDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateFromYears.UpControl = null;
            // 
            // lblTargetYMDDateToMonth
            // 
            this.lblTargetYMDDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDDateToMonth.Name = "lblTargetYMDDateToMonth";
            this.lblTargetYMDDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToMonth.TabIndex = 117;
            this.lblTargetYMDDateToMonth.Text = "月";
            this.lblTargetYMDDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateToYears
            // 
            this.lblTargetYMDDateToYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYMDDateToYears.Name = "lblTargetYMDDateToYears";
            this.lblTargetYMDDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToYears.TabIndex = 115;
            this.lblTargetYMDDateToYears.Text = "年";
            this.lblTargetYMDDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYMDDateTo
            // 
            this.dtpTargetYMDDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateTo.CustomFormat = " ";
            this.dtpTargetYMDDateTo.DaysLinkTextControl = this.txtTargetYMDDateToDays;
            this.dtpTargetYMDDateTo.DownControl = null;
            this.dtpTargetYMDDateTo.EnterControl = null;
            this.dtpTargetYMDDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYMDDateTo.LeftControl = this.txtTargetYMDDateToDays;
            this.dtpTargetYMDDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYMDDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYMDDateTo.MonthLinkTextControl = this.txtTargetYMDDateToMonth;
            this.dtpTargetYMDDateTo.Name = "dtpTargetYMDDateTo";
            this.dtpTargetYMDDateTo.RightControl = null;
            this.dtpTargetYMDDateTo.Size = new System.Drawing.Size(210, 27);
            this.dtpTargetYMDDateTo.TabIndex = 132;
            this.dtpTargetYMDDateTo.UpControl = null;
            this.dtpTargetYMDDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYMDDateTo.Value2 = null;
            this.dtpTargetYMDDateTo.YearsLinkTextControl = this.txtTargetYMDDateToYears;
            // 
            // pnlTargetYMDDateFrom
            // 
            this.pnlTargetYMDDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYMDDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYMDDateFrom.Controls.Add(this.lblTargetYMDDateFromDays);
            this.pnlTargetYMDDateFrom.Controls.Add(this.txtTargetYMDDateFromDays);
            this.pnlTargetYMDDateFrom.Controls.Add(this.lblTargetYMDDateFromMonth);
            this.pnlTargetYMDDateFrom.Controls.Add(this.txtTargetYMDDateFromMonth);
            this.pnlTargetYMDDateFrom.Controls.Add(this.lblTargetYMDDateFromYears);
            this.pnlTargetYMDDateFrom.Controls.Add(this.txtTargetYMDDateFromYears);
            this.pnlTargetYMDDateFrom.Controls.Add(this.dtpTargetYMDDateFrom);
            this.pnlTargetYMDDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYMDDateFrom.Location = new System.Drawing.Point(827, 41);
            this.pnlTargetYMDDateFrom.Name = "pnlTargetYMDDateFrom";
            this.pnlTargetYMDDateFrom.Size = new System.Drawing.Size(210, 27);
            this.pnlTargetYMDDateFrom.TabIndex = 392;
            // 
            // lblTargetYMDDateFromDays
            // 
            this.lblTargetYMDDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblTargetYMDDateFromDays.Name = "lblTargetYMDDateFromDays";
            this.lblTargetYMDDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromDays.TabIndex = 119;
            this.lblTargetYMDDateFromDays.Text = "日";
            this.lblTargetYMDDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateFromMonth
            // 
            this.lblTargetYMDDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDDateFromMonth.Name = "lblTargetYMDDateFromMonth";
            this.lblTargetYMDDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromMonth.TabIndex = 117;
            this.lblTargetYMDDateFromMonth.Text = "月";
            this.lblTargetYMDDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateFromYears
            // 
            this.lblTargetYMDDateFromYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYMDDateFromYears.Name = "lblTargetYMDDateFromYears";
            this.lblTargetYMDDateFromYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromYears.TabIndex = 115;
            this.lblTargetYMDDateFromYears.Text = "年";
            this.lblTargetYMDDateFromYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYMDDateFrom
            // 
            this.dtpTargetYMDDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateFrom.CustomFormat = " ";
            this.dtpTargetYMDDateFrom.DaysLinkTextControl = this.txtTargetYMDDateFromDays;
            this.dtpTargetYMDDateFrom.DownControl = null;
            this.dtpTargetYMDDateFrom.EnterControl = this.txtTargetYMDDateToYears;
            this.dtpTargetYMDDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYMDDateFrom.LeftControl = this.txtTargetYMDDateFromDays;
            this.dtpTargetYMDDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYMDDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYMDDateFrom.MonthLinkTextControl = this.txtTargetYMDDateFromMonth;
            this.dtpTargetYMDDateFrom.Name = "dtpTargetYMDDateFrom";
            this.dtpTargetYMDDateFrom.RightControl = this.txtTargetYMDDateToYears;
            this.dtpTargetYMDDateFrom.Size = new System.Drawing.Size(210, 27);
            this.dtpTargetYMDDateFrom.TabIndex = 132;
            this.dtpTargetYMDDateFrom.UpControl = null;
            this.dtpTargetYMDDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYMDDateFrom.Value2 = null;
            this.dtpTargetYMDDateFrom.YearsLinkTextControl = this.txtTargetYMDDateFromYears;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated1.Location = new System.Drawing.Point(1044, 45);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 391;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblTargetYMDDate
            // 
            this.lblTargetYMDDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYMDDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYMDDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYMDDate.ForeColor = System.Drawing.Color.White;
            this.lblTargetYMDDate.Location = new System.Drawing.Point(697, 41);
            this.lblTargetYMDDate.Name = "lblTargetYMDDate";
            this.lblTargetYMDDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetYMDDate.TabIndex = 390;
            this.lblTargetYMDDate.Text = "売上日付";
            this.lblTargetYMDDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOfficesCode
            // 
            this.lblOfficesCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOfficesCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOfficesCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOfficesCode.ForeColor = System.Drawing.Color.White;
            this.lblOfficesCode.Location = new System.Drawing.Point(697, 13);
            this.lblOfficesCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOfficesCode.Name = "lblOfficesCode";
            this.lblOfficesCode.Size = new System.Drawing.Size(130, 27);
            this.lblOfficesCode.TabIndex = 389;
            this.lblOfficesCode.Text = "事業所ｺｰﾄﾞ";
            this.lblOfficesCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOfficesName
            // 
            this.txtOfficesName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtOfficesName.BeforeValue = "";
            this.txtOfficesName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOfficesName.DownControl = null;
            this.txtOfficesName.Enabled = false;
            this.txtOfficesName.EnterControl = null;
            this.txtOfficesName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOfficesName.LabelControl = null;
            this.txtOfficesName.LeftControl = this.txtCustomerCode;
            this.txtOfficesName.Location = new System.Drawing.Point(910, 16);
            this.txtOfficesName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOfficesName.Name = "txtOfficesName";
            this.txtOfficesName.RightControl = null;
            this.txtOfficesName.Size = new System.Drawing.Size(404, 20);
            this.txtOfficesName.TabIndex = 388;
            this.txtOfficesName.Text = "令令令令令令令令令令令令令令令令令令令令";
            this.txtOfficesName.UpControl = null;
            // 
            // txtOfficesCode
            // 
            this.txtOfficesCode.BeforeValue = "";
            this.txtOfficesCode.DownControl = null;
            this.txtOfficesCode.EnterControl = this.txtCustomerName;
            this.txtOfficesCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOfficesCode.LabelControl = null;
            this.txtOfficesCode.LeftControl = null;
            this.txtOfficesCode.Location = new System.Drawing.Point(827, 13);
            this.txtOfficesCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOfficesCode.MaxLength = 5;
            this.txtOfficesCode.Name = "txtOfficesCode";
            this.txtOfficesCode.RightControl = this.txtCustomerName;
            this.txtOfficesCode.Size = new System.Drawing.Size(75, 27);
            this.txtOfficesCode.TabIndex = 70;
            this.txtOfficesCode.Text = "XX3";
            this.txtOfficesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOfficesCode.UpControl = null;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(11, 13);
            this.lblCustomerCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 381;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdUriageList
            // 
            this.grdUriageList.AllowUserToAddRows = false;
            this.grdUriageList.AllowUserToDeleteRows = false;
            this.grdUriageList.AllowUserToResizeColumns = false;
            this.grdUriageList.AllowUserToResizeRows = false;
            this.grdUriageList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUriageList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdUriageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUriageList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMonthDay,
            this.clmDenpyoNo,
            this.clmChumonNo,
            this.clmHinmei,
            this.clmSuryo,
            this.clmTani,
            this.clmTanka,
            this.clmKingaku});
            this.grdUriageList.DownControl = null;
            this.grdUriageList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdUriageList.EnableHeadersVisualStyles = false;
            this.grdUriageList.EnterControl = null;
            this.grdUriageList.FlgSetCurrentCell = true;
            this.grdUriageList.LeftControl = null;
            this.grdUriageList.Location = new System.Drawing.Point(4, 3);
            this.grdUriageList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdUriageList.MultiSelect = false;
            this.grdUriageList.Name = "grdUriageList";
            this.grdUriageList.RightControl = null;
            this.grdUriageList.RowHeadersVisible = false;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdUriageList.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.grdUriageList.RowSegmentCount = 2;
            this.grdUriageList.RowTemplate.Height = 26;
            this.grdUriageList.ScrollRowCount = 2;
            this.grdUriageList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdUriageList.Size = new System.Drawing.Size(1396, 651);
            this.grdUriageList.TabIndex = 90;
            this.grdUriageList.UpControl = null;
            this.grdUriageList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdUriageList_CellPainting);
            // 
            // clmMonthDay
            // 
            this.clmMonthDay.DataPropertyName = "monthDay";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.clmMonthDay.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmMonthDay.HeaderText = "月日";
            this.clmMonthDay.Name = "clmMonthDay";
            this.clmMonthDay.ReadOnly = true;
            this.clmMonthDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmDenpyoNo
            // 
            this.clmDenpyoNo.DataPropertyName = "denpyoNo";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.clmDenpyoNo.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmDenpyoNo.FillWeight = 120F;
            this.clmDenpyoNo.HeaderText = "伝票番号";
            this.clmDenpyoNo.Name = "clmDenpyoNo";
            this.clmDenpyoNo.ReadOnly = true;
            this.clmDenpyoNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDenpyoNo.Width = 110;
            // 
            // clmChumonNo
            // 
            this.clmChumonNo.DataPropertyName = "chumonNo";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.clmChumonNo.DefaultCellStyle = dataGridViewCellStyle14;
            this.clmChumonNo.HeaderText = "注文No";
            this.clmChumonNo.Name = "clmChumonNo";
            this.clmChumonNo.ReadOnly = true;
            this.clmChumonNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmChumonNo.Width = 185;
            // 
            // clmHinmei
            // 
            this.clmHinmei.DataPropertyName = "hinmei";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.clmHinmei.DefaultCellStyle = dataGridViewCellStyle15;
            this.clmHinmei.HeaderText = "品名";
            this.clmHinmei.Name = "clmHinmei";
            this.clmHinmei.ReadOnly = true;
            this.clmHinmei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmHinmei.Width = 610;
            // 
            // clmSuryo
            // 
            this.clmSuryo.DataPropertyName = "suryo";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.clmSuryo.DefaultCellStyle = dataGridViewCellStyle16;
            this.clmSuryo.HeaderText = "数量";
            this.clmSuryo.Name = "clmSuryo";
            this.clmSuryo.ReadOnly = true;
            this.clmSuryo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmTani
            // 
            this.clmTani.DataPropertyName = "tani";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.NullValue = null;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.clmTani.DefaultCellStyle = dataGridViewCellStyle17;
            this.clmTani.HeaderText = "単位";
            this.clmTani.Name = "clmTani";
            this.clmTani.ReadOnly = true;
            this.clmTani.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTani.Width = 70;
            // 
            // clmTanka
            // 
            this.clmTanka.DataPropertyName = "tanka";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.clmTanka.DefaultCellStyle = dataGridViewCellStyle18;
            this.clmTanka.HeaderText = "単価";
            this.clmTanka.Name = "clmTanka";
            this.clmTanka.ReadOnly = true;
            this.clmTanka.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmKingaku
            // 
            this.clmKingaku.DataPropertyName = "kingaku";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            this.clmKingaku.DefaultCellStyle = dataGridViewCellStyle19;
            this.clmKingaku.HeaderText = "金額";
            this.clmKingaku.Name = "clmKingaku";
            this.clmKingaku.ReadOnly = true;
            this.clmKingaku.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdUriageList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 105);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1408, 663);
            this.pnlBody.TabIndex = 80;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnListDisp);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 768);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1408, 70);
            this.pnlBottom.TabIndex = 100;
            // 
            // btnListDisp
            // 
            this.btnListDisp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnListDisp.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnListDisp.Location = new System.Drawing.Point(118, 15);
            this.btnListDisp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnListDisp.Name = "btnListDisp";
            this.btnListDisp.Size = new System.Drawing.Size(143, 40);
            this.btnListDisp.TabIndex = 120;
            this.btnListDisp.Text = "F2：一覧表示";
            this.btnListDisp.UseVisualStyleBackColor = false;
            this.btnListDisp.Click += new System.EventHandler(this.btnListDisp_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(4, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 110;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(1284, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 150;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUriageIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1408, 838);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUriageIchiran";
            this.ShowIcon = false;
            this.Text = "売上一覧";
            this.Load += new System.EventHandler(this.frmTokuisakiSeikyuKanri_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTargetYMDDateTo.ResumeLayout(false);
            this.pnlTargetYMDDateTo.PerformLayout();
            this.pnlTargetYMDDateFrom.ResumeLayout(false);
            this.pnlTargetYMDDateFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUriageList)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.FeaturesButton btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdUriageList;
        private Common.FeaturesButton btnClose;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomTextBox txtCustomerCode;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtOfficesCode;
        private Common.CustomTextBox txtOfficesName;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnListDisp;
        private Common.ItemHeadLabel lblOfficesCode;
        private System.Windows.Forms.Panel pnlTargetYMDDateTo;
        private System.Windows.Forms.Label lblTargetYMDDateToDays;
        private Common.CustomTextBox txtTargetYMDDateToDays;
        private Common.CustomTextBox txtTargetYMDDateToMonth;
        private Common.CustomTextBox txtTargetYMDDateToYears;
        private Common.CustomTextBox txtTargetYMDDateFromDays;
        private Common.CustomTextBox txtTargetYMDDateFromMonth;
        private Common.CustomTextBox txtTargetYMDDateFromYears;
        private System.Windows.Forms.Label lblTargetYMDDateToMonth;
        private System.Windows.Forms.Label lblTargetYMDDateToYears;
        private Common.CustomDateTimePicker dtpTargetYMDDateTo;
        private System.Windows.Forms.Panel pnlTargetYMDDateFrom;
        private System.Windows.Forms.Label lblTargetYMDDateFromDays;
        private System.Windows.Forms.Label lblTargetYMDDateFromMonth;
        private System.Windows.Forms.Label lblTargetYMDDateFromYears;
        private Common.CustomDateTimePicker dtpTargetYMDDateFrom;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.ItemHeadLabel lblTargetYMDDate;
        private Common.ItemHeadLabel lblPersonnel;
        private Common.CustomComboBox cmbPersonnel;
        private Common.ItemHeadLabel lblSubject;
        private Common.CustomTextBox txtSubject1;
        private Common.CustomTextBox txtSubject2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenpyoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChumonNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHinmei;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSuryo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTani;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTanka;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKingaku;
    }
}