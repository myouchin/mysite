namespace SeikyuKoshin
{
    partial class frmSeikyuShimebiKoshin
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
            this.pnlProcessingType = new System.Windows.Forms.Panel();
            this.lblProcessingType = new Common.ItemHeadLabel();
            this.rdoCancel = new System.Windows.Forms.RadioButton();
            this.rdoUpdate = new System.Windows.Forms.RadioButton();
            this.lblTightenDate = new Common.ItemHeadLabel();
            this.pnlTightenDate = new System.Windows.Forms.Panel();
            this.lblTightenDateDays = new System.Windows.Forms.Label();
            this.cmbTightenType = new Common.CustomComboBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtSalesDateFromYears = new Common.CustomTextBox();
            this.txtSalesDateFromMonth = new Common.CustomTextBox();
            this.txtSalesDateFromDays = new Common.CustomTextBox();
            this.txtSalesDateToYears = new Common.CustomTextBox();
            this.txtSalesDateToMonth = new Common.CustomTextBox();
            this.txtSalesDateToDays = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.cmbOffices = new Common.CustomComboBox();
            this.txtBillingDateYears = new Common.CustomTextBox();
            this.txtBillingDateMonth = new Common.CustomTextBox();
            this.txtBillingDateDays = new Common.CustomTextBox();
            this.txtTightenDateYears = new Common.CustomTextBox();
            this.txtTightenDateMonth = new Common.CustomTextBox();
            this.lblTightenDateMonth = new System.Windows.Forms.Label();
            this.lblTightenDateYears = new System.Windows.Forms.Label();
            this.dtpTightenDate = new Common.CustomDateTimePicker();
            this.pnlSalesDateTo = new System.Windows.Forms.Panel();
            this.lblSalesDateToDays = new System.Windows.Forms.Label();
            this.lblSalesDateToMonth = new System.Windows.Forms.Label();
            this.lblSalesDateToYears = new System.Windows.Forms.Label();
            this.dtpSalesDateTo = new Common.CustomDateTimePicker();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblSalesDate = new Common.ItemHeadLabel();
            this.pnlSalesDateFrom = new System.Windows.Forms.Panel();
            this.lblSalesDateFromDays = new System.Windows.Forms.Label();
            this.lblSalesDateFromMonth = new System.Windows.Forms.Label();
            this.lblSalesDateFromYears = new System.Windows.Forms.Label();
            this.dtpSalesDateFrom = new Common.CustomDateTimePicker();
            this.lblOffices = new Common.ItemHeadLabel();
            this.lblCustomerKanaName = new Common.ItemHeadLabel();
            this.lblCustomerName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.pnlProcessingTarget = new System.Windows.Forms.Panel();
            this.lblProcessingTarget = new Common.ItemHeadLabel();
            this.rdoIndividual = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.lblBillingDate = new Common.ItemHeadLabel();
            this.pnlBillingDate = new System.Windows.Forms.Panel();
            this.lblBillingDateDays = new System.Windows.Forms.Label();
            this.lblBillingDateMonth = new System.Windows.Forms.Label();
            this.lblBillingDateYears = new System.Windows.Forms.Label();
            this.dtpBillingDate = new Common.CustomDateTimePicker();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.btnExecution = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlProcessingType.SuspendLayout();
            this.pnlTightenDate.SuspendLayout();
            this.pnlSalesDateTo.SuspendLayout();
            this.pnlSalesDateFrom.SuspendLayout();
            this.pnlProcessingTarget.SuspendLayout();
            this.pnlBillingDate.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlProcessingType);
            this.pnlHeader.Controls.Add(this.lblTightenDate);
            this.pnlHeader.Controls.Add(this.pnlTightenDate);
            this.pnlHeader.Controls.Add(this.pnlSalesDateTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblSalesDate);
            this.pnlHeader.Controls.Add(this.pnlSalesDateFrom);
            this.pnlHeader.Controls.Add(this.lblOffices);
            this.pnlHeader.Controls.Add(this.cmbOffices);
            this.pnlHeader.Controls.Add(this.lblCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.pnlProcessingTarget);
            this.pnlHeader.Controls.Add(this.lblBillingDate);
            this.pnlHeader.Controls.Add(this.pnlBillingDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(969, 240);
            this.pnlHeader.TabIndex = 104;
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
            this.lblTightenDate.Size = new System.Drawing.Size(296, 24);
            this.lblTightenDate.TabIndex = 388;
            this.lblTightenDate.Text = "請求締日";
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
            this.pnlTightenDate.Location = new System.Drawing.Point(10, 95);
            this.pnlTightenDate.Name = "pnlTightenDate";
            this.pnlTightenDate.Size = new System.Drawing.Size(297, 27);
            this.pnlTightenDate.TabIndex = 70;
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
            this.cmbTightenType.EnterControl = this.txtBillingDateYears;
            this.cmbTightenType.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbTightenType.FormattingEnabled = true;
            this.cmbTightenType.LabelControl = null;
            this.cmbTightenType.LeftControl = this.txtTightenDateMonth;
            this.cmbTightenType.Location = new System.Drawing.Point(170, -1);
            this.cmbTightenType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTightenType.Name = "cmbTightenType";
            this.cmbTightenType.RightControl = this.txtBillingDateYears;
            this.cmbTightenType.Size = new System.Drawing.Size(62, 27);
            this.cmbTightenType.TabIndex = 110;
            this.cmbTightenType.Text = "Ｘ２";
            this.cmbTightenType.UpControl = null;
            this.cmbTightenType.SelectedIndexChanged += new System.EventHandler(this.cmbTightenType_SelectedIndexChanged);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.txtSalesDateFromYears;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(10, 147);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 170;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtTightenDateYears;
            // 
            // txtSalesDateFromYears
            // 
            this.txtSalesDateFromYears.BeforeValue = "";
            this.txtSalesDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesDateFromYears.DownControl = null;
            this.txtSalesDateFromYears.EnterControl = this.txtSalesDateFromMonth;
            this.txtSalesDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesDateFromYears.LabelControl = null;
            this.txtSalesDateFromYears.LeftControl = null;
            this.txtSalesDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtSalesDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesDateFromYears.Name = "txtSalesDateFromYears";
            this.txtSalesDateFromYears.RightControl = this.txtSalesDateFromMonth;
            this.txtSalesDateFromYears.Size = new System.Drawing.Size(51, 20);
            this.txtSalesDateFromYears.TabIndex = 220;
            this.txtSalesDateFromYears.Text = "1234";
            this.txtSalesDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesDateFromYears.UpControl = this.txtCustomerCode;
            // 
            // txtSalesDateFromMonth
            // 
            this.txtSalesDateFromMonth.BeforeValue = "";
            this.txtSalesDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesDateFromMonth.DownControl = null;
            this.txtSalesDateFromMonth.EnterControl = this.txtSalesDateFromDays;
            this.txtSalesDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesDateFromMonth.LabelControl = null;
            this.txtSalesDateFromMonth.LeftControl = this.txtSalesDateFromYears;
            this.txtSalesDateFromMonth.Location = new System.Drawing.Point(78, 3);
            this.txtSalesDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesDateFromMonth.Name = "txtSalesDateFromMonth";
            this.txtSalesDateFromMonth.RightControl = this.txtSalesDateFromDays;
            this.txtSalesDateFromMonth.Size = new System.Drawing.Size(33, 20);
            this.txtSalesDateFromMonth.TabIndex = 230;
            this.txtSalesDateFromMonth.Text = "12";
            this.txtSalesDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesDateFromMonth.UpControl = this.txtCustomerCode;
            // 
            // txtSalesDateFromDays
            // 
            this.txtSalesDateFromDays.BeforeValue = "";
            this.txtSalesDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesDateFromDays.DownControl = null;
            this.txtSalesDateFromDays.EnterControl = this.txtSalesDateToYears;
            this.txtSalesDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesDateFromDays.LabelControl = null;
            this.txtSalesDateFromDays.LeftControl = this.txtSalesDateFromMonth;
            this.txtSalesDateFromDays.Location = new System.Drawing.Point(137, 3);
            this.txtSalesDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesDateFromDays.Name = "txtSalesDateFromDays";
            this.txtSalesDateFromDays.RightControl = this.txtSalesDateToYears;
            this.txtSalesDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtSalesDateFromDays.TabIndex = 240;
            this.txtSalesDateFromDays.Text = "12";
            this.txtSalesDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesDateFromDays.UpControl = this.txtCustomerCode;
            // 
            // txtSalesDateToYears
            // 
            this.txtSalesDateToYears.BeforeValue = "";
            this.txtSalesDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesDateToYears.DownControl = null;
            this.txtSalesDateToYears.EnterControl = this.txtSalesDateToMonth;
            this.txtSalesDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesDateToYears.LabelControl = null;
            this.txtSalesDateToYears.LeftControl = this.txtSalesDateFromDays;
            this.txtSalesDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtSalesDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesDateToYears.Name = "txtSalesDateToYears";
            this.txtSalesDateToYears.RightControl = this.txtSalesDateToMonth;
            this.txtSalesDateToYears.Size = new System.Drawing.Size(51, 20);
            this.txtSalesDateToYears.TabIndex = 270;
            this.txtSalesDateToYears.Text = "1234";
            this.txtSalesDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesDateToYears.UpControl = this.txtCustomerName;
            // 
            // txtSalesDateToMonth
            // 
            this.txtSalesDateToMonth.BeforeValue = "";
            this.txtSalesDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesDateToMonth.DownControl = null;
            this.txtSalesDateToMonth.EnterControl = this.txtSalesDateToDays;
            this.txtSalesDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesDateToMonth.LabelControl = null;
            this.txtSalesDateToMonth.LeftControl = this.txtSalesDateToYears;
            this.txtSalesDateToMonth.Location = new System.Drawing.Point(78, 3);
            this.txtSalesDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesDateToMonth.Name = "txtSalesDateToMonth";
            this.txtSalesDateToMonth.RightControl = this.txtSalesDateToDays;
            this.txtSalesDateToMonth.Size = new System.Drawing.Size(33, 20);
            this.txtSalesDateToMonth.TabIndex = 280;
            this.txtSalesDateToMonth.Text = "12";
            this.txtSalesDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesDateToMonth.UpControl = this.txtCustomerName;
            // 
            // txtSalesDateToDays
            // 
            this.txtSalesDateToDays.BeforeValue = "";
            this.txtSalesDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesDateToDays.DownControl = null;
            this.txtSalesDateToDays.EnterControl = null;
            this.txtSalesDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesDateToDays.LabelControl = null;
            this.txtSalesDateToDays.LeftControl = this.txtSalesDateToMonth;
            this.txtSalesDateToDays.Location = new System.Drawing.Point(137, 3);
            this.txtSalesDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesDateToDays.Name = "txtSalesDateToDays";
            this.txtSalesDateToDays.RightControl = null;
            this.txtSalesDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtSalesDateToDays.TabIndex = 290;
            this.txtSalesDateToDays.Text = "12";
            this.txtSalesDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesDateToDays.UpControl = this.txtCustomerName;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.txtSalesDateFromYears;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(139, 147);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(232, 27);
            this.txtCustomerName.TabIndex = 180;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtTightenDateYears;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.txtSalesDateToYears;
            this.txtCustomerKanaName.EnterControl = this.cmbOffices;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(370, 147);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = this.cmbOffices;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(417, 27);
            this.txtCustomerKanaName.TabIndex = 190;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = this.txtBillingDateYears;
            // 
            // cmbOffices
            // 
            this.cmbOffices.BeforeSelectedValue = "";
            this.cmbOffices.DownControl = null;
            this.cmbOffices.EnterControl = this.txtSalesDateFromYears;
            this.cmbOffices.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.LabelControl = null;
            this.cmbOffices.LeftControl = this.txtCustomerKanaName;
            this.cmbOffices.Location = new System.Drawing.Point(786, 147);
            this.cmbOffices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.RightControl = null;
            this.cmbOffices.Size = new System.Drawing.Size(174, 27);
            this.cmbOffices.TabIndex = 200;
            this.cmbOffices.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbOffices.UpControl = null;
            this.cmbOffices.SelectedIndexChanged += new System.EventHandler(this.cmbOffices_SelectedIndexChanged);
            // 
            // txtBillingDateYears
            // 
            this.txtBillingDateYears.BeforeValue = "";
            this.txtBillingDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateYears.DownControl = this.txtCustomerName;
            this.txtBillingDateYears.EnterControl = this.txtBillingDateMonth;
            this.txtBillingDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateYears.LabelControl = null;
            this.txtBillingDateYears.LeftControl = this.cmbTightenType;
            this.txtBillingDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtBillingDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateYears.Name = "txtBillingDateYears";
            this.txtBillingDateYears.RightControl = this.txtBillingDateMonth;
            this.txtBillingDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtBillingDateYears.TabIndex = 130;
            this.txtBillingDateYears.Text = "1234";
            this.txtBillingDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateYears.UpControl = null;
            // 
            // txtBillingDateMonth
            // 
            this.txtBillingDateMonth.BeforeValue = "";
            this.txtBillingDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateMonth.DownControl = this.txtCustomerName;
            this.txtBillingDateMonth.EnterControl = this.txtBillingDateDays;
            this.txtBillingDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateMonth.LabelControl = null;
            this.txtBillingDateMonth.LeftControl = this.txtBillingDateYears;
            this.txtBillingDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtBillingDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateMonth.Name = "txtBillingDateMonth";
            this.txtBillingDateMonth.RightControl = this.txtBillingDateDays;
            this.txtBillingDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtBillingDateMonth.TabIndex = 140;
            this.txtBillingDateMonth.Text = "12";
            this.txtBillingDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateMonth.UpControl = null;
            // 
            // txtBillingDateDays
            // 
            this.txtBillingDateDays.BeforeValue = "";
            this.txtBillingDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateDays.DownControl = this.txtCustomerName;
            this.txtBillingDateDays.EnterControl = this.txtCustomerCode;
            this.txtBillingDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateDays.LabelControl = null;
            this.txtBillingDateDays.LeftControl = this.txtBillingDateMonth;
            this.txtBillingDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtBillingDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateDays.Name = "txtBillingDateDays";
            this.txtBillingDateDays.RightControl = null;
            this.txtBillingDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtBillingDateDays.TabIndex = 150;
            this.txtBillingDateDays.Text = "12";
            this.txtBillingDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateDays.UpControl = null;
            // 
            // txtTightenDateYears
            // 
            this.txtTightenDateYears.BeforeValue = "";
            this.txtTightenDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTightenDateYears.DownControl = this.txtCustomerCode;
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
            this.txtTightenDateYears.TextChanged += new System.EventHandler(this.txtTightenDateYears_TextChanged);
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
            this.txtTightenDateMonth.TextChanged += new System.EventHandler(this.txtTightenDateMonth_TextChanged);
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
            this.dtpTightenDate.TabIndex = 100;
            this.dtpTightenDate.TabStop = false;
            this.dtpTightenDate.UpControl = null;
            this.dtpTightenDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTightenDate.Value2 = null;
            this.dtpTightenDate.YearsLinkTextControl = this.txtTightenDateYears;
            // 
            // pnlSalesDateTo
            // 
            this.pnlSalesDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSalesDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSalesDateTo.Controls.Add(this.lblSalesDateToDays);
            this.pnlSalesDateTo.Controls.Add(this.txtSalesDateToDays);
            this.pnlSalesDateTo.Controls.Add(this.lblSalesDateToMonth);
            this.pnlSalesDateTo.Controls.Add(this.txtSalesDateToMonth);
            this.pnlSalesDateTo.Controls.Add(this.lblSalesDateToYears);
            this.pnlSalesDateTo.Controls.Add(this.txtSalesDateToYears);
            this.pnlSalesDateTo.Controls.Add(this.dtpSalesDateTo);
            this.pnlSalesDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlSalesDateTo.Location = new System.Drawing.Point(274, 199);
            this.pnlSalesDateTo.Name = "pnlSalesDateTo";
            this.pnlSalesDateTo.Size = new System.Drawing.Size(232, 27);
            this.pnlSalesDateTo.TabIndex = 260;
            // 
            // lblSalesDateToDays
            // 
            this.lblSalesDateToDays.Location = new System.Drawing.Point(170, 0);
            this.lblSalesDateToDays.Name = "lblSalesDateToDays";
            this.lblSalesDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblSalesDateToDays.TabIndex = 119;
            this.lblSalesDateToDays.Text = "日";
            this.lblSalesDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesDateToMonth
            // 
            this.lblSalesDateToMonth.Location = new System.Drawing.Point(111, 0);
            this.lblSalesDateToMonth.Name = "lblSalesDateToMonth";
            this.lblSalesDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblSalesDateToMonth.TabIndex = 117;
            this.lblSalesDateToMonth.Text = "月";
            this.lblSalesDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesDateToYears
            // 
            this.lblSalesDateToYears.Location = new System.Drawing.Point(51, 0);
            this.lblSalesDateToYears.Name = "lblSalesDateToYears";
            this.lblSalesDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblSalesDateToYears.TabIndex = 115;
            this.lblSalesDateToYears.Text = "年";
            this.lblSalesDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpSalesDateTo
            // 
            this.dtpSalesDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpSalesDateTo.CustomFormat = " ";
            this.dtpSalesDateTo.DaysLinkTextControl = this.txtSalesDateToDays;
            this.dtpSalesDateTo.DownControl = null;
            this.dtpSalesDateTo.EnterControl = null;
            this.dtpSalesDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpSalesDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSalesDateTo.LeftControl = this.txtSalesDateToDays;
            this.dtpSalesDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpSalesDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSalesDateTo.MonthLinkTextControl = this.txtSalesDateToMonth;
            this.dtpSalesDateTo.Name = "dtpSalesDateTo";
            this.dtpSalesDateTo.RightControl = null;
            this.dtpSalesDateTo.Size = new System.Drawing.Size(232, 27);
            this.dtpSalesDateTo.TabIndex = 300;
            this.dtpSalesDateTo.TabStop = false;
            this.dtpSalesDateTo.UpControl = this.txtCustomerName;
            this.dtpSalesDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpSalesDateTo.Value2 = null;
            this.dtpSalesDateTo.YearsLinkTextControl = this.txtSalesDateToYears;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.AutoSize = true;
            this.lblFromToSeparated1.Location = new System.Drawing.Point(247, 206);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(21, 14);
            this.lblFromToSeparated1.TabIndex = 385;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblSalesDate
            // 
            this.lblSalesDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSalesDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSalesDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSalesDate.ForeColor = System.Drawing.Color.White;
            this.lblSalesDate.Location = new System.Drawing.Point(10, 175);
            this.lblSalesDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalesDate.Name = "lblSalesDate";
            this.lblSalesDate.Size = new System.Drawing.Size(496, 24);
            this.lblSalesDate.TabIndex = 384;
            this.lblSalesDate.Text = "対象売上日付";
            this.lblSalesDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSalesDateFrom
            // 
            this.pnlSalesDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSalesDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSalesDateFrom.Controls.Add(this.lblSalesDateFromDays);
            this.pnlSalesDateFrom.Controls.Add(this.txtSalesDateFromDays);
            this.pnlSalesDateFrom.Controls.Add(this.lblSalesDateFromMonth);
            this.pnlSalesDateFrom.Controls.Add(this.txtSalesDateFromMonth);
            this.pnlSalesDateFrom.Controls.Add(this.lblSalesDateFromYears);
            this.pnlSalesDateFrom.Controls.Add(this.txtSalesDateFromYears);
            this.pnlSalesDateFrom.Controls.Add(this.dtpSalesDateFrom);
            this.pnlSalesDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlSalesDateFrom.Location = new System.Drawing.Point(9, 199);
            this.pnlSalesDateFrom.Name = "pnlSalesDateFrom";
            this.pnlSalesDateFrom.Size = new System.Drawing.Size(232, 27);
            this.pnlSalesDateFrom.TabIndex = 210;
            // 
            // lblSalesDateFromDays
            // 
            this.lblSalesDateFromDays.Location = new System.Drawing.Point(170, 0);
            this.lblSalesDateFromDays.Name = "lblSalesDateFromDays";
            this.lblSalesDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblSalesDateFromDays.TabIndex = 119;
            this.lblSalesDateFromDays.Text = "日";
            this.lblSalesDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesDateFromMonth
            // 
            this.lblSalesDateFromMonth.Location = new System.Drawing.Point(111, 0);
            this.lblSalesDateFromMonth.Name = "lblSalesDateFromMonth";
            this.lblSalesDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblSalesDateFromMonth.TabIndex = 117;
            this.lblSalesDateFromMonth.Text = "月";
            this.lblSalesDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesDateFromYears
            // 
            this.lblSalesDateFromYears.Location = new System.Drawing.Point(51, 0);
            this.lblSalesDateFromYears.Name = "lblSalesDateFromYears";
            this.lblSalesDateFromYears.Size = new System.Drawing.Size(28, 27);
            this.lblSalesDateFromYears.TabIndex = 115;
            this.lblSalesDateFromYears.Text = "年";
            this.lblSalesDateFromYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpSalesDateFrom
            // 
            this.dtpSalesDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpSalesDateFrom.CustomFormat = " ";
            this.dtpSalesDateFrom.DaysLinkTextControl = this.txtSalesDateFromDays;
            this.dtpSalesDateFrom.DownControl = null;
            this.dtpSalesDateFrom.EnterControl = this.txtSalesDateToYears;
            this.dtpSalesDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpSalesDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSalesDateFrom.LeftControl = this.txtSalesDateFromDays;
            this.dtpSalesDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpSalesDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSalesDateFrom.MonthLinkTextControl = this.txtSalesDateFromMonth;
            this.dtpSalesDateFrom.Name = "dtpSalesDateFrom";
            this.dtpSalesDateFrom.RightControl = this.txtSalesDateToYears;
            this.dtpSalesDateFrom.Size = new System.Drawing.Size(232, 27);
            this.dtpSalesDateFrom.TabIndex = 250;
            this.dtpSalesDateFrom.TabStop = false;
            this.dtpSalesDateFrom.UpControl = this.txtCustomerCode;
            this.dtpSalesDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpSalesDateFrom.Value2 = null;
            this.dtpSalesDateFrom.YearsLinkTextControl = this.txtSalesDateFromYears;
            // 
            // lblOffices
            // 
            this.lblOffices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffices.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffices.ForeColor = System.Drawing.Color.White;
            this.lblOffices.Location = new System.Drawing.Point(787, 123);
            this.lblOffices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffices.Name = "lblOffices";
            this.lblOffices.Size = new System.Drawing.Size(173, 24);
            this.lblOffices.TabIndex = 382;
            this.lblOffices.Text = "事業所";
            this.lblOffices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerKanaName
            // 
            this.lblCustomerKanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerKanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerKanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerKanaName.Location = new System.Drawing.Point(371, 123);
            this.lblCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerKanaName.Name = "lblCustomerKanaName";
            this.lblCustomerKanaName.Size = new System.Drawing.Size(416, 24);
            this.lblCustomerKanaName.TabIndex = 380;
            this.lblCustomerKanaName.Text = "得意先カナ名";
            this.lblCustomerKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(140, 123);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(231, 24);
            this.lblCustomerName.TabIndex = 376;
            this.lblCustomerName.Text = "得意先名";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(10, 123);
            this.lblCustomerCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 24);
            this.lblCustomerCode.TabIndex = 375;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblBillingDate
            // 
            this.lblBillingDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBillingDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBillingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBillingDate.ForeColor = System.Drawing.Color.White;
            this.lblBillingDate.Location = new System.Drawing.Point(306, 71);
            this.lblBillingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillingDate.Name = "lblBillingDate";
            this.lblBillingDate.Size = new System.Drawing.Size(240, 24);
            this.lblBillingDate.TabIndex = 116;
            this.lblBillingDate.Text = "請求日";
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
            this.pnlBillingDate.Location = new System.Drawing.Point(306, 95);
            this.pnlBillingDate.Name = "pnlBillingDate";
            this.pnlBillingDate.Size = new System.Drawing.Size(240, 27);
            this.pnlBillingDate.TabIndex = 120;
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
            this.dtpBillingDate.EnterControl = this.txtCustomerCode;
            this.dtpBillingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpBillingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillingDate.LeftControl = this.txtBillingDateDays;
            this.dtpBillingDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpBillingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpBillingDate.MonthLinkTextControl = this.txtBillingDateMonth;
            this.dtpBillingDate.Name = "dtpBillingDate";
            this.dtpBillingDate.RightControl = null;
            this.dtpBillingDate.Size = new System.Drawing.Size(240, 27);
            this.dtpBillingDate.TabIndex = 160;
            this.dtpBillingDate.TabStop = false;
            this.dtpBillingDate.UpControl = null;
            this.dtpBillingDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpBillingDate.Value2 = null;
            this.dtpBillingDate.YearsLinkTextControl = this.txtBillingDateYears;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 240);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(969, 70);
            this.pnlBottom.TabIndex = 310;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(730, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 340;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExecution
            // 
            this.btnExecution.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecution.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecution.Location = new System.Drawing.Point(616, 15);
            this.btnExecution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExecution.Name = "btnExecution";
            this.btnExecution.Size = new System.Drawing.Size(106, 40);
            this.btnExecution.TabIndex = 330;
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
            this.btnSearch.TabIndex = 320;
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
            this.btnClose.Location = new System.Drawing.Point(844, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 350;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSeikyuShimebiKoshin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 310);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmSeikyuShimebiKoshin";
            this.Text = "締日更新";
            this.Load += new System.EventHandler(this.frmShimebiKoshin_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProcessingType.ResumeLayout(false);
            this.pnlProcessingType.PerformLayout();
            this.pnlTightenDate.ResumeLayout(false);
            this.pnlTightenDate.PerformLayout();
            this.pnlSalesDateTo.ResumeLayout(false);
            this.pnlSalesDateTo.PerformLayout();
            this.pnlSalesDateFrom.ResumeLayout(false);
            this.pnlSalesDateFrom.PerformLayout();
            this.pnlProcessingTarget.ResumeLayout(false);
            this.pnlProcessingTarget.PerformLayout();
            this.pnlBillingDate.ResumeLayout(false);
            this.pnlBillingDate.PerformLayout();
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
        private Common.ItemHeadLabel lblBillingDate;
        private System.Windows.Forms.Panel pnlBillingDate;
        private System.Windows.Forms.Label lblBillingDateDays;
        private Common.CustomTextBox txtBillingDateDays;
        private Common.CustomTextBox txtBillingDateMonth;
        private Common.CustomTextBox txtBillingDateYears;
        private System.Windows.Forms.Label lblBillingDateMonth;
        private System.Windows.Forms.Label lblBillingDateYears;
        private Common.CustomDateTimePicker dtpBillingDate;
        private System.Windows.Forms.Panel pnlProcessingTarget;
        private Common.ItemHeadLabel lblProcessingTarget;
        private System.Windows.Forms.RadioButton rdoIndividual;
        private System.Windows.Forms.RadioButton rdoAll;
        private Common.ItemHeadLabel lblOffices;
        private Common.CustomComboBox cmbOffices;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomTextBox txtCustomerCode;
        private Common.ItemHeadLabel lblCustomerKanaName;
        private Common.ItemHeadLabel lblCustomerName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.ItemHeadLabel lblSalesDate;
        private System.Windows.Forms.Panel pnlSalesDateFrom;
        private System.Windows.Forms.Label lblSalesDateFromDays;
        private Common.CustomTextBox txtSalesDateFromDays;
        private Common.CustomTextBox txtSalesDateFromMonth;
        private Common.CustomTextBox txtSalesDateFromYears;
        private System.Windows.Forms.Label lblSalesDateFromMonth;
        private System.Windows.Forms.Label lblSalesDateFromYears;
        private Common.CustomDateTimePicker dtpSalesDateFrom;
        private System.Windows.Forms.Panel pnlSalesDateTo;
        private System.Windows.Forms.Label lblSalesDateToDays;
        private Common.CustomTextBox txtSalesDateToDays;
        private Common.CustomTextBox txtSalesDateToMonth;
        private Common.CustomTextBox txtSalesDateToYears;
        private System.Windows.Forms.Label lblSalesDateToMonth;
        private System.Windows.Forms.Label lblSalesDateToYears;
        private Common.CustomDateTimePicker dtpSalesDateTo;
        private System.Windows.Forms.Label lblFromToSeparated1;
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
    }
}