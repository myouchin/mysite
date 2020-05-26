namespace ShiharaiKoushin
{
    partial class frmShiharaiShimebiKoshin
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
            this.txtVendorName = new Common.CustomTextBox();
            this.txtVendorCode = new Common.CustomTextBox();
            this.lblVendorName = new Common.ItemHeadLabel();
            this.lblVendorCode = new Common.ItemHeadLabel();
            this.pnlProcessingType = new System.Windows.Forms.Panel();
            this.lblProcessingType = new Common.ItemHeadLabel();
            this.rdoCancel = new System.Windows.Forms.RadioButton();
            this.rdoUpdate = new System.Windows.Forms.RadioButton();
            this.lblTightenDate = new Common.ItemHeadLabel();
            this.pnlTightenDate = new System.Windows.Forms.Panel();
            this.txtTightenDateDays = new Common.CustomTextBox();
            this.cmbTightenType = new Common.CustomComboBox();
            this.txtTightenDateMonth = new Common.CustomTextBox();
            this.txtTightenDateYears = new Common.CustomTextBox();
            this.lblTightenDateDays = new System.Windows.Forms.Label();
            this.lblTightenDateMonth = new System.Windows.Forms.Label();
            this.lblTightenDateYears = new System.Windows.Forms.Label();
            this.dtpTightenDate = new Common.CustomDateTimePicker();
            this.pnlProcessingTarget = new System.Windows.Forms.Panel();
            this.lblProcessingTarget = new Common.ItemHeadLabel();
            this.rdoIndividual = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.btnExecution = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlProcessingType.SuspendLayout();
            this.pnlTightenDate.SuspendLayout();
            this.pnlProcessingTarget.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.txtVendorName);
            this.pnlHeader.Controls.Add(this.lblVendorName);
            this.pnlHeader.Controls.Add(this.txtVendorCode);
            this.pnlHeader.Controls.Add(this.lblVendorCode);
            this.pnlHeader.Controls.Add(this.pnlProcessingType);
            this.pnlHeader.Controls.Add(this.lblTightenDate);
            this.pnlHeader.Controls.Add(this.pnlTightenDate);
            this.pnlHeader.Controls.Add(this.pnlProcessingTarget);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(567, 181);
            this.pnlHeader.TabIndex = 1;
            // 
            // txtVendorName
            // 
            this.txtVendorName.BeforeValue = "";
            this.txtVendorName.DownControl = null;
            this.txtVendorName.EnterControl = null;
            this.txtVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorName.LabelControl = null;
            this.txtVendorName.LeftControl = this.txtVendorCode;
            this.txtVendorName.Location = new System.Drawing.Point(139, 147);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.RightControl = null;
            this.txtVendorName.Size = new System.Drawing.Size(339, 27);
            this.txtVendorName.TabIndex = 140;
            this.txtVendorName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtVendorName.UpControl = this.txtTightenDateYears;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.BeforeValue = "";
            this.txtVendorCode.DownControl = null;
            this.txtVendorCode.EnterControl = this.txtVendorName;
            this.txtVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCode.LabelControl = null;
            this.txtVendorCode.LeftControl = null;
            this.txtVendorCode.Location = new System.Drawing.Point(10, 147);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightControl = this.txtVendorName;
            this.txtVendorCode.Size = new System.Drawing.Size(130, 27);
            this.txtVendorCode.TabIndex = 130;
            this.txtVendorCode.Text = "XX3";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorCode.UpControl = this.txtTightenDateYears;
            // 
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorName.ForeColor = System.Drawing.Color.White;
            this.lblVendorName.Location = new System.Drawing.Point(140, 123);
            this.lblVendorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(338, 24);
            this.lblVendorName.TabIndex = 392;
            this.lblVendorName.Text = "仕入先名";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.ForeColor = System.Drawing.Color.White;
            this.lblVendorCode.Location = new System.Drawing.Point(10, 123);
            this.lblVendorCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(130, 24);
            this.lblVendorCode.TabIndex = 390;
            this.lblVendorCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProcessingType
            // 
            this.pnlProcessingType.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingType.Controls.Add(this.lblProcessingType);
            this.pnlProcessingType.Controls.Add(this.rdoCancel);
            this.pnlProcessingType.Controls.Add(this.rdoUpdate);
            this.pnlProcessingType.Location = new System.Drawing.Point(283, 3);
            this.pnlProcessingType.Name = "pnlProcessingType";
            this.pnlProcessingType.Size = new System.Drawing.Size(191, 65);
            this.pnlProcessingType.TabIndex = 40;
            // 
            // lblProcessingType
            // 
            this.lblProcessingType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblProcessingType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessingType.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProcessingType.ForeColor = System.Drawing.Color.White;
            this.lblProcessingType.Location = new System.Drawing.Point(5, 2);
            this.lblProcessingType.Name = "lblProcessingType";
            this.lblProcessingType.Size = new System.Drawing.Size(113, 27);
            this.lblProcessingType.TabIndex = 4;
            this.lblProcessingType.Text = "処理区分";
            this.lblProcessingType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoCancel
            // 
            this.rdoCancel.AutoCheck = false;
            this.rdoCancel.AutoSize = true;
            this.rdoCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCancel.Location = new System.Drawing.Point(102, 32);
            this.rdoCancel.Name = "rdoCancel";
            this.rdoCancel.Size = new System.Drawing.Size(69, 24);
            this.rdoCancel.TabIndex = 60;
            this.rdoCancel.Text = "取消";
            this.rdoCancel.UseVisualStyleBackColor = true;
            this.rdoCancel.Click += new System.EventHandler(this.processingTypeRadio_Click);
            // 
            // rdoUpdate
            // 
            this.rdoUpdate.AutoCheck = false;
            this.rdoUpdate.AutoSize = true;
            this.rdoUpdate.Checked = true;
            this.rdoUpdate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoUpdate.Location = new System.Drawing.Point(17, 32);
            this.rdoUpdate.Name = "rdoUpdate";
            this.rdoUpdate.Size = new System.Drawing.Size(69, 24);
            this.rdoUpdate.TabIndex = 50;
            this.rdoUpdate.Text = "更新";
            this.rdoUpdate.UseVisualStyleBackColor = true;
            this.rdoUpdate.Click += new System.EventHandler(this.processingTypeRadio_Click);
            // 
            // lblTightenDate
            // 
            this.lblTightenDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTightenDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTightenDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTightenDate.ForeColor = System.Drawing.Color.White;
            this.lblTightenDate.Location = new System.Drawing.Point(11, 71);
            this.lblTightenDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTightenDate.Name = "lblTightenDate";
            this.lblTightenDate.Size = new System.Drawing.Size(329, 24);
            this.lblTightenDate.TabIndex = 388;
            this.lblTightenDate.Text = "請求締日";
            this.lblTightenDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTightenDate
            // 
            this.pnlTightenDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTightenDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTightenDate.Controls.Add(this.txtTightenDateDays);
            this.pnlTightenDate.Controls.Add(this.lblTightenDateDays);
            this.pnlTightenDate.Controls.Add(this.cmbTightenType);
            this.pnlTightenDate.Controls.Add(this.lblTightenDateMonth);
            this.pnlTightenDate.Controls.Add(this.txtTightenDateMonth);
            this.pnlTightenDate.Controls.Add(this.lblTightenDateYears);
            this.pnlTightenDate.Controls.Add(this.txtTightenDateYears);
            this.pnlTightenDate.Controls.Add(this.dtpTightenDate);
            this.pnlTightenDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTightenDate.Location = new System.Drawing.Point(10, 95);
            this.pnlTightenDate.Name = "pnlTightenDate";
            this.pnlTightenDate.Size = new System.Drawing.Size(330, 27);
            this.pnlTightenDate.TabIndex = 70;
            // 
            // txtTightenDateDays
            // 
            this.txtTightenDateDays.BeforeValue = "";
            this.txtTightenDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTightenDateDays.DownControl = this.txtVendorCode;
            this.txtTightenDateDays.EnterControl = this.txtVendorCode;
            this.txtTightenDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTightenDateDays.LabelControl = null;
            this.txtTightenDateDays.LeftControl = this.txtTightenDateDays;
            this.txtTightenDateDays.Location = new System.Drawing.Point(240, 3);
            this.txtTightenDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTightenDateDays.Name = "txtTightenDateDays";
            this.txtTightenDateDays.RightControl = null;
            this.txtTightenDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtTightenDateDays.TabIndex = 120;
            this.txtTightenDateDays.Text = "12";
            this.txtTightenDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTightenDateDays.UpControl = null;
            // 
            // cmbTightenType
            // 
            this.cmbTightenType.BeforeSelectedValue = "";
            this.cmbTightenType.DownControl = this.txtVendorCode;
            this.cmbTightenType.EnterControl = this.txtTightenDateDays;
            this.cmbTightenType.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbTightenType.FormattingEnabled = true;
            this.cmbTightenType.LabelControl = null;
            this.cmbTightenType.LeftControl = this.txtTightenDateMonth;
            this.cmbTightenType.Location = new System.Drawing.Point(170, -1);
            this.cmbTightenType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTightenType.Name = "cmbTightenType";
            this.cmbTightenType.RightControl = this.txtTightenDateDays;
            this.cmbTightenType.Size = new System.Drawing.Size(62, 27);
            this.cmbTightenType.TabIndex = 110;
            this.cmbTightenType.Text = "Ｘ２";
            this.cmbTightenType.UpControl = null;
            this.cmbTightenType.SelectedIndexChanged += new System.EventHandler(this.cmbTightenType_SelectedIndexChanged);
            // 
            // txtTightenDateMonth
            // 
            this.txtTightenDateMonth.BeforeValue = "";
            this.txtTightenDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTightenDateMonth.DownControl = this.txtVendorCode;
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
            this.txtTightenDateMonth.TextChanged += new System.EventHandler(this.txtTightenMonthYears_TextChanged);
            // 
            // txtTightenDateYears
            // 
            this.txtTightenDateYears.BeforeValue = "";
            this.txtTightenDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTightenDateYears.DownControl = this.txtVendorCode;
            this.txtTightenDateYears.EnterControl = this.txtTightenDateMonth;
            this.txtTightenDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTightenDateYears.LabelControl = null;
            this.txtTightenDateYears.LeftControl = null;
            this.txtTightenDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtTightenDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTightenDateYears.Name = "txtTightenDateYears";
            this.txtTightenDateYears.RightControl = this.txtTightenDateMonth;
            this.txtTightenDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtTightenDateYears.TabIndex = 80;
            this.txtTightenDateYears.Text = "1234";
            this.txtTightenDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTightenDateYears.UpControl = null;
            this.txtTightenDateYears.TextChanged += new System.EventHandler(this.txtTightenMonthYears_TextChanged);
            // 
            // lblTightenDateDays
            // 
            this.lblTightenDateDays.Location = new System.Drawing.Point(273, 0);
            this.lblTightenDateDays.Name = "lblTightenDateDays";
            this.lblTightenDateDays.Size = new System.Drawing.Size(54, 27);
            this.lblTightenDateDays.TabIndex = 389;
            this.lblTightenDateDays.Text = "日締";
            this.lblTightenDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dtpTightenDate.DownControl = this.txtVendorCode;
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
            this.dtpTightenDate.TabIndex = 100;
            this.dtpTightenDate.TabStop = false;
            this.dtpTightenDate.UpControl = null;
            this.dtpTightenDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTightenDate.Value2 = null;
            this.dtpTightenDate.YearsLinkTextControl = this.txtTightenDateYears;
            // 
            // pnlProcessingTarget
            // 
            this.pnlProcessingTarget.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingTarget.Controls.Add(this.lblProcessingTarget);
            this.pnlProcessingTarget.Controls.Add(this.rdoIndividual);
            this.pnlProcessingTarget.Controls.Add(this.rdoAll);
            this.pnlProcessingTarget.Location = new System.Drawing.Point(10, 3);
            this.pnlProcessingTarget.Name = "pnlProcessingTarget";
            this.pnlProcessingTarget.Size = new System.Drawing.Size(267, 65);
            this.pnlProcessingTarget.TabIndex = 10;
            // 
            // lblProcessingTarget
            // 
            this.lblProcessingTarget.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblProcessingTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessingTarget.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProcessingTarget.ForeColor = System.Drawing.Color.White;
            this.lblProcessingTarget.Location = new System.Drawing.Point(5, 2);
            this.lblProcessingTarget.Name = "lblProcessingTarget";
            this.lblProcessingTarget.Size = new System.Drawing.Size(105, 27);
            this.lblProcessingTarget.TabIndex = 4;
            this.lblProcessingTarget.Text = "処理対象";
            this.lblProcessingTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoIndividual
            // 
            this.rdoIndividual.AutoCheck = false;
            this.rdoIndividual.AutoSize = true;
            this.rdoIndividual.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoIndividual.Location = new System.Drawing.Point(134, 32);
            this.rdoIndividual.Name = "rdoIndividual";
            this.rdoIndividual.Size = new System.Drawing.Size(111, 24);
            this.rdoIndividual.TabIndex = 30;
            this.rdoIndividual.Text = "個別更新";
            this.rdoIndividual.UseVisualStyleBackColor = true;
            this.rdoIndividual.Click += new System.EventHandler(this.processingTargetRadio_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoCheck = false;
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoAll.Location = new System.Drawing.Point(17, 32);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(111, 24);
            this.rdoAll.TabIndex = 20;
            this.rdoAll.Text = "全件更新";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Click += new System.EventHandler(this.processingTargetRadio_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnExecution);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 181);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(567, 70);
            this.pnlBottom.TabIndex = 150;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(329, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 180;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExecution
            // 
            this.btnExecution.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecution.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecution.Location = new System.Drawing.Point(215, 15);
            this.btnExecution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExecution.Name = "btnExecution";
            this.btnExecution.Size = new System.Drawing.Size(106, 40);
            this.btnExecution.TabIndex = 170;
            this.btnExecution.Text = "F10：実行";
            this.btnExecution.UseVisualStyleBackColor = false;
            this.btnExecution.Click += new System.EventHandler(this.btnExecution_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(11, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 160;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(443, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 190;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShiharaiShimebiKoshin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 253);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmShiharaiShimebiKoshin";
            this.Text = "締日更新";
            this.Load += new System.EventHandler(this.frmShiharaiShimebiKoshin_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProcessingType.ResumeLayout(false);
            this.pnlProcessingType.PerformLayout();
            this.pnlTightenDate.ResumeLayout(false);
            this.pnlTightenDate.PerformLayout();
            this.pnlProcessingTarget.ResumeLayout(false);
            this.pnlProcessingTarget.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnExecution;
        private System.Windows.Forms.Panel pnlProcessingTarget;
        private Common.ItemHeadLabel lblProcessingTarget;
        private System.Windows.Forms.RadioButton rdoIndividual;
        private System.Windows.Forms.RadioButton rdoAll;
        private Common.FeaturesButton btnCancel;
        private Common.ItemHeadLabel lblTightenDate;
        private System.Windows.Forms.Panel pnlTightenDate;
        private Common.CustomTextBox txtTightenDateMonth;
        private Common.CustomTextBox txtTightenDateYears;
        private System.Windows.Forms.Label lblTightenDateMonth;
        private System.Windows.Forms.Label lblTightenDateYears;
        private Common.CustomDateTimePicker dtpTightenDate;
        private Common.CustomComboBox cmbTightenType;
        private System.Windows.Forms.Label lblTightenDateDays;
        private System.Windows.Forms.Panel pnlProcessingType;
        private Common.ItemHeadLabel lblProcessingType;
        private System.Windows.Forms.RadioButton rdoCancel;
        private System.Windows.Forms.RadioButton rdoUpdate;
        private Common.CustomTextBox txtVendorName;
        private Common.CustomTextBox txtVendorCode;
        private Common.ItemHeadLabel lblVendorName;
        private Common.ItemHeadLabel lblVendorCode;
        private Common.CustomTextBox txtTightenDateDays;
    }
}