namespace SeikyuKoshin
{
    partial class frmSeikyuChangeSearch
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
            this.lblOffices = new Common.ItemHeadLabel();
            this.cmbOffices = new Common.CustomComboBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtOrdersNo = new Common.CustomTextBox();
            this.txtDocumentNo = new Common.CustomTextBox();
            this.txtDocumentDateFromYears = new Common.CustomTextBox();
            this.txtDocumentDateFromMonth = new Common.CustomTextBox();
            this.txtDocumentDateFromDays = new Common.CustomTextBox();
            this.txtDocumentDateToYears = new Common.CustomTextBox();
            this.txtDocumentDateToMonth = new Common.CustomTextBox();
            this.txtDocumentDateToDays = new Common.CustomTextBox();
            this.txtBillingDateDays = new Common.CustomTextBox();
            this.txtBillingDateYears = new Common.CustomTextBox();
            this.txtBillingDateMonth = new Common.CustomTextBox();
            this.lblCustomerKanaName = new Common.ItemHeadLabel();
            this.lblCustomerName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.lblOrdersNo = new Common.ItemHeadLabel();
            this.lblDocumentNo = new Common.ItemHeadLabel();
            this.lblBillingDate2 = new Common.ItemHeadLabel();
            this.pnlBillingDateDays = new System.Windows.Forms.Panel();
            this.lblBillingDateDays = new System.Windows.Forms.Label();
            this.pnlDocumentDateTo = new System.Windows.Forms.Panel();
            this.lblDocumentDateToDays = new System.Windows.Forms.Label();
            this.lblDocumentDateToMonth = new System.Windows.Forms.Label();
            this.lblDocumentDateToYears = new System.Windows.Forms.Label();
            this.dtpDocumentDateTo = new Common.CustomDateTimePicker();
            this.pnlDocumentDateFrom = new System.Windows.Forms.Panel();
            this.lblDocumentDateFromDays = new System.Windows.Forms.Label();
            this.lblDocumentDateFromMonth = new System.Windows.Forms.Label();
            this.lblDocumentDateFromYears = new System.Windows.Forms.Label();
            this.dtpDocumentDateFrom = new Common.CustomDateTimePicker();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblDocumentDate = new Common.ItemHeadLabel();
            this.lblBillingDate1 = new Common.ItemHeadLabel();
            this.pnlBillingDate = new System.Windows.Forms.Panel();
            this.lblBillingDateMonth = new System.Windows.Forms.Label();
            this.lblBillingDateYears = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlBillingDateDays.SuspendLayout();
            this.pnlDocumentDateTo.SuspendLayout();
            this.pnlDocumentDateFrom.SuspendLayout();
            this.pnlBillingDate.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblOffices);
            this.pnlHeader.Controls.Add(this.cmbOffices);
            this.pnlHeader.Controls.Add(this.lblCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblOrdersNo);
            this.pnlHeader.Controls.Add(this.txtOrdersNo);
            this.pnlHeader.Controls.Add(this.lblDocumentNo);
            this.pnlHeader.Controls.Add(this.txtDocumentNo);
            this.pnlHeader.Controls.Add(this.lblBillingDate2);
            this.pnlHeader.Controls.Add(this.pnlBillingDateDays);
            this.pnlHeader.Controls.Add(this.pnlDocumentDateTo);
            this.pnlHeader.Controls.Add(this.pnlDocumentDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblDocumentDate);
            this.pnlHeader.Controls.Add(this.lblBillingDate1);
            this.pnlHeader.Controls.Add(this.pnlBillingDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(641, 331);
            this.pnlHeader.TabIndex = 104;
            // 
            // lblOffices
            // 
            this.lblOffices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffices.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffices.ForeColor = System.Drawing.Color.White;
            this.lblOffices.Location = new System.Drawing.Point(20, 282);
            this.lblOffices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffices.Name = "lblOffices";
            this.lblOffices.Size = new System.Drawing.Size(130, 27);
            this.lblOffices.TabIndex = 384;
            this.lblOffices.Text = "事業所";
            this.lblOffices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbOffices
            // 
            this.cmbOffices.BeforeSelectedValue = "";
            this.cmbOffices.DownControl = null;
            this.cmbOffices.EnterControl = null;
            this.cmbOffices.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.LabelControl = null;
            this.cmbOffices.LeftControl = null;
            this.cmbOffices.Location = new System.Drawing.Point(150, 282);
            this.cmbOffices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.RightControl = null;
            this.cmbOffices.Size = new System.Drawing.Size(211, 27);
            this.cmbOffices.TabIndex = 210;
            this.cmbOffices.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbOffices.UpControl = this.txtCustomerKanaName;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.cmbOffices;
            this.txtCustomerKanaName.EnterControl = this.cmbOffices;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = null;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(150, 244);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.MaxLength = 30;
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = null;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(464, 27);
            this.txtCustomerKanaName.TabIndex = 200;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = this.txtCustomerName;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.txtCustomerKanaName;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = null;
            this.txtCustomerName.Location = new System.Drawing.Point(150, 206);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 15;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = null;
            this.txtCustomerName.Size = new System.Drawing.Size(211, 27);
            this.txtCustomerName.TabIndex = 190;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtCustomerCode;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.txtCustomerName;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(150, 168);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 8;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = null;
            this.txtCustomerCode.Size = new System.Drawing.Size(211, 27);
            this.txtCustomerCode.TabIndex = 180;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtOrdersNo;
            // 
            // txtOrdersNo
            // 
            this.txtOrdersNo.BeforeValue = "";
            this.txtOrdersNo.DownControl = this.txtCustomerCode;
            this.txtOrdersNo.EnterControl = this.txtCustomerCode;
            this.txtOrdersNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNo.LabelControl = null;
            this.txtOrdersNo.LeftControl = null;
            this.txtOrdersNo.Location = new System.Drawing.Point(150, 130);
            this.txtOrdersNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNo.MaxLength = 8;
            this.txtOrdersNo.Name = "txtOrdersNo";
            this.txtOrdersNo.RightControl = null;
            this.txtOrdersNo.Size = new System.Drawing.Size(211, 27);
            this.txtOrdersNo.TabIndex = 170;
            this.txtOrdersNo.Text = "XXXXXXX8";
            this.txtOrdersNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNo.UpControl = this.txtDocumentNo;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.BeforeValue = "";
            this.txtDocumentNo.DownControl = this.txtOrdersNo;
            this.txtDocumentNo.EnterControl = this.txtOrdersNo;
            this.txtDocumentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentNo.LabelControl = null;
            this.txtDocumentNo.LeftControl = null;
            this.txtDocumentNo.Location = new System.Drawing.Point(150, 92);
            this.txtDocumentNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentNo.MaxLength = 8;
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.RightControl = null;
            this.txtDocumentNo.Size = new System.Drawing.Size(211, 27);
            this.txtDocumentNo.TabIndex = 160;
            this.txtDocumentNo.Text = "XXXXXXX8";
            this.txtDocumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentNo.UpControl = this.txtDocumentDateFromYears;
            // 
            // txtDocumentDateFromYears
            // 
            this.txtDocumentDateFromYears.BeforeValue = "";
            this.txtDocumentDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateFromYears.DownControl = this.txtDocumentNo;
            this.txtDocumentDateFromYears.EnterControl = this.txtDocumentDateFromMonth;
            this.txtDocumentDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateFromYears.LabelControl = null;
            this.txtDocumentDateFromYears.LeftControl = null;
            this.txtDocumentDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtDocumentDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateFromYears.MaxLength = 4;
            this.txtDocumentDateFromYears.Name = "txtDocumentDateFromYears";
            this.txtDocumentDateFromYears.RightControl = this.txtDocumentDateFromMonth;
            this.txtDocumentDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtDocumentDateFromYears.TabIndex = 70;
            this.txtDocumentDateFromYears.Text = "1234";
            this.txtDocumentDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateFromYears.UpControl = this.txtBillingDateYears;
            // 
            // txtDocumentDateFromMonth
            // 
            this.txtDocumentDateFromMonth.BeforeValue = "";
            this.txtDocumentDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateFromMonth.DownControl = this.txtDocumentNo;
            this.txtDocumentDateFromMonth.EnterControl = this.txtDocumentDateFromDays;
            this.txtDocumentDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateFromMonth.LabelControl = null;
            this.txtDocumentDateFromMonth.LeftControl = this.txtDocumentDateFromYears;
            this.txtDocumentDateFromMonth.Location = new System.Drawing.Point(66, 3);
            this.txtDocumentDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateFromMonth.MaxLength = 2;
            this.txtDocumentDateFromMonth.Name = "txtDocumentDateFromMonth";
            this.txtDocumentDateFromMonth.RightControl = this.txtDocumentDateFromDays;
            this.txtDocumentDateFromMonth.Size = new System.Drawing.Size(30, 20);
            this.txtDocumentDateFromMonth.TabIndex = 80;
            this.txtDocumentDateFromMonth.Text = "12";
            this.txtDocumentDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateFromMonth.UpControl = this.txtBillingDateYears;
            // 
            // txtDocumentDateFromDays
            // 
            this.txtDocumentDateFromDays.BeforeValue = "";
            this.txtDocumentDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateFromDays.DownControl = this.txtDocumentNo;
            this.txtDocumentDateFromDays.EnterControl = this.txtDocumentDateToYears;
            this.txtDocumentDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateFromDays.LabelControl = null;
            this.txtDocumentDateFromDays.LeftControl = this.txtDocumentDateFromMonth;
            this.txtDocumentDateFromDays.Location = new System.Drawing.Point(115, 3);
            this.txtDocumentDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateFromDays.MaxLength = 2;
            this.txtDocumentDateFromDays.Name = "txtDocumentDateFromDays";
            this.txtDocumentDateFromDays.RightControl = this.txtDocumentDateToYears;
            this.txtDocumentDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtDocumentDateFromDays.TabIndex = 90;
            this.txtDocumentDateFromDays.Text = "12";
            this.txtDocumentDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateFromDays.UpControl = this.txtBillingDateYears;
            // 
            // txtDocumentDateToYears
            // 
            this.txtDocumentDateToYears.BeforeValue = "";
            this.txtDocumentDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateToYears.DownControl = null;
            this.txtDocumentDateToYears.EnterControl = this.txtDocumentDateToMonth;
            this.txtDocumentDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateToYears.LabelControl = null;
            this.txtDocumentDateToYears.LeftControl = this.txtDocumentDateFromDays;
            this.txtDocumentDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtDocumentDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateToYears.MaxLength = 4;
            this.txtDocumentDateToYears.Name = "txtDocumentDateToYears";
            this.txtDocumentDateToYears.RightControl = this.txtDocumentDateToMonth;
            this.txtDocumentDateToYears.Size = new System.Drawing.Size(45, 20);
            this.txtDocumentDateToYears.TabIndex = 120;
            this.txtDocumentDateToYears.Text = "1234";
            this.txtDocumentDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateToYears.UpControl = this.txtBillingDateDays;
            // 
            // txtDocumentDateToMonth
            // 
            this.txtDocumentDateToMonth.BeforeValue = "";
            this.txtDocumentDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateToMonth.DownControl = null;
            this.txtDocumentDateToMonth.EnterControl = this.txtDocumentDateToDays;
            this.txtDocumentDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateToMonth.LabelControl = null;
            this.txtDocumentDateToMonth.LeftControl = this.txtDocumentDateToYears;
            this.txtDocumentDateToMonth.Location = new System.Drawing.Point(68, 3);
            this.txtDocumentDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateToMonth.MaxLength = 2;
            this.txtDocumentDateToMonth.Name = "txtDocumentDateToMonth";
            this.txtDocumentDateToMonth.RightControl = this.txtDocumentDateToDays;
            this.txtDocumentDateToMonth.Size = new System.Drawing.Size(30, 20);
            this.txtDocumentDateToMonth.TabIndex = 130;
            this.txtDocumentDateToMonth.Text = "12";
            this.txtDocumentDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateToMonth.UpControl = this.txtBillingDateDays;
            // 
            // txtDocumentDateToDays
            // 
            this.txtDocumentDateToDays.BeforeValue = "";
            this.txtDocumentDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateToDays.DownControl = null;
            this.txtDocumentDateToDays.EnterControl = this.txtDocumentNo;
            this.txtDocumentDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateToDays.LabelControl = null;
            this.txtDocumentDateToDays.LeftControl = this.txtDocumentDateToMonth;
            this.txtDocumentDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtDocumentDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateToDays.MaxLength = 2;
            this.txtDocumentDateToDays.Name = "txtDocumentDateToDays";
            this.txtDocumentDateToDays.RightControl = null;
            this.txtDocumentDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtDocumentDateToDays.TabIndex = 140;
            this.txtDocumentDateToDays.Text = "12";
            this.txtDocumentDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateToDays.UpControl = this.txtBillingDateDays;
            // 
            // txtBillingDateDays
            // 
            this.txtBillingDateDays.BeforeValue = "";
            this.txtBillingDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateDays.DownControl = this.txtDocumentDateToYears;
            this.txtBillingDateDays.EnterControl = this.txtDocumentDateFromYears;
            this.txtBillingDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateDays.LabelControl = null;
            this.txtBillingDateDays.LeftControl = this.txtDocumentDateFromMonth;
            this.txtBillingDateDays.Location = new System.Drawing.Point(16, 3);
            this.txtBillingDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateDays.Name = "txtBillingDateDays";
            this.txtBillingDateDays.RightControl = null;
            this.txtBillingDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtBillingDateDays.TabIndex = 50;
            this.txtBillingDateDays.Text = "12";
            this.txtBillingDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateDays.UpControl = null;
            // 
            // txtBillingDateYears
            // 
            this.txtBillingDateYears.BeforeValue = "";
            this.txtBillingDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateYears.DownControl = this.txtDocumentDateFromYears;
            this.txtBillingDateYears.EnterControl = this.txtBillingDateMonth;
            this.txtBillingDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateYears.LabelControl = null;
            this.txtBillingDateYears.LeftControl = null;
            this.txtBillingDateYears.Location = new System.Drawing.Point(-2, 3);
            this.txtBillingDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateYears.Name = "txtBillingDateYears";
            this.txtBillingDateYears.RightControl = this.txtBillingDateMonth;
            this.txtBillingDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtBillingDateYears.TabIndex = 20;
            this.txtBillingDateYears.Text = "1234";
            this.txtBillingDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateYears.UpControl = null;
            // 
            // txtBillingDateMonth
            // 
            this.txtBillingDateMonth.BeforeValue = "";
            this.txtBillingDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillingDateMonth.DownControl = this.txtDocumentDateFromMonth;
            this.txtBillingDateMonth.EnterControl = this.txtBillingDateDays;
            this.txtBillingDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillingDateMonth.LabelControl = null;
            this.txtBillingDateMonth.LeftControl = this.txtBillingDateYears;
            this.txtBillingDateMonth.Location = new System.Drawing.Point(66, 3);
            this.txtBillingDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingDateMonth.Name = "txtBillingDateMonth";
            this.txtBillingDateMonth.RightControl = this.txtBillingDateDays;
            this.txtBillingDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtBillingDateMonth.TabIndex = 30;
            this.txtBillingDateMonth.Text = "12";
            this.txtBillingDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillingDateMonth.UpControl = null;
            // 
            // lblCustomerKanaName
            // 
            this.lblCustomerKanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerKanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerKanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerKanaName.Location = new System.Drawing.Point(20, 244);
            this.lblCustomerKanaName.Name = "lblCustomerKanaName";
            this.lblCustomerKanaName.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerKanaName.TabIndex = 150;
            this.lblCustomerKanaName.Text = "得意先カナ名";
            this.lblCustomerKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 206);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerName.TabIndex = 148;
            this.lblCustomerName.Text = "得意先名";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(20, 168);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 147;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrdersNo
            // 
            this.lblOrdersNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrdersNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrdersNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrdersNo.ForeColor = System.Drawing.Color.White;
            this.lblOrdersNo.Location = new System.Drawing.Point(20, 130);
            this.lblOrdersNo.Name = "lblOrdersNo";
            this.lblOrdersNo.Size = new System.Drawing.Size(130, 27);
            this.lblOrdersNo.TabIndex = 144;
            this.lblOrdersNo.Text = "受注NO";
            this.lblOrdersNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDocumentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDocumentNo.ForeColor = System.Drawing.Color.White;
            this.lblDocumentNo.Location = new System.Drawing.Point(20, 92);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(130, 27);
            this.lblDocumentNo.TabIndex = 142;
            this.lblDocumentNo.Text = "伝票NO";
            this.lblDocumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBillingDate2
            // 
            this.lblBillingDate2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBillingDate2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBillingDate2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBillingDate2.ForeColor = System.Drawing.Color.White;
            this.lblBillingDate2.Location = new System.Drawing.Point(403, 16);
            this.lblBillingDate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillingDate2.Name = "lblBillingDate2";
            this.lblBillingDate2.Size = new System.Drawing.Size(99, 27);
            this.lblBillingDate2.TabIndex = 140;
            this.lblBillingDate2.Text = "締日";
            this.lblBillingDate2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBillingDateDays
            // 
            this.pnlBillingDateDays.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBillingDateDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillingDateDays.Controls.Add(this.lblBillingDateDays);
            this.pnlBillingDateDays.Controls.Add(this.txtBillingDateDays);
            this.pnlBillingDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlBillingDateDays.Location = new System.Drawing.Point(502, 16);
            this.pnlBillingDateDays.Name = "pnlBillingDateDays";
            this.pnlBillingDateDays.Size = new System.Drawing.Size(112, 27);
            this.pnlBillingDateDays.TabIndex = 40;
            // 
            // lblBillingDateDays
            // 
            this.lblBillingDateDays.Location = new System.Drawing.Point(47, 0);
            this.lblBillingDateDays.Name = "lblBillingDateDays";
            this.lblBillingDateDays.Size = new System.Drawing.Size(32, 27);
            this.lblBillingDateDays.TabIndex = 119;
            this.lblBillingDateDays.Text = "日";
            this.lblBillingDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDocumentDateTo
            // 
            this.pnlDocumentDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDocumentDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDocumentDateTo.Controls.Add(this.lblDocumentDateToDays);
            this.pnlDocumentDateTo.Controls.Add(this.txtDocumentDateToDays);
            this.pnlDocumentDateTo.Controls.Add(this.lblDocumentDateToMonth);
            this.pnlDocumentDateTo.Controls.Add(this.txtDocumentDateToMonth);
            this.pnlDocumentDateTo.Controls.Add(this.lblDocumentDateToYears);
            this.pnlDocumentDateTo.Controls.Add(this.txtDocumentDateToYears);
            this.pnlDocumentDateTo.Controls.Add(this.dtpDocumentDateTo);
            this.pnlDocumentDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlDocumentDateTo.Location = new System.Drawing.Point(403, 54);
            this.pnlDocumentDateTo.Name = "pnlDocumentDateTo";
            this.pnlDocumentDateTo.Size = new System.Drawing.Size(211, 27);
            this.pnlDocumentDateTo.TabIndex = 110;
            // 
            // lblDocumentDateToDays
            // 
            this.lblDocumentDateToDays.Location = new System.Drawing.Point(148, 0);
            this.lblDocumentDateToDays.Name = "lblDocumentDateToDays";
            this.lblDocumentDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblDocumentDateToDays.TabIndex = 119;
            this.lblDocumentDateToDays.Text = "日";
            this.lblDocumentDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumentDateToMonth
            // 
            this.lblDocumentDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblDocumentDateToMonth.Name = "lblDocumentDateToMonth";
            this.lblDocumentDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblDocumentDateToMonth.TabIndex = 117;
            this.lblDocumentDateToMonth.Text = "月";
            this.lblDocumentDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumentDateToYears
            // 
            this.lblDocumentDateToYears.Location = new System.Drawing.Point(44, 0);
            this.lblDocumentDateToYears.Name = "lblDocumentDateToYears";
            this.lblDocumentDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblDocumentDateToYears.TabIndex = 115;
            this.lblDocumentDateToYears.Text = "年";
            this.lblDocumentDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDocumentDateTo
            // 
            this.dtpDocumentDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDocumentDateTo.CustomFormat = " ";
            this.dtpDocumentDateTo.DaysLinkTextControl = this.txtDocumentDateToDays;
            this.dtpDocumentDateTo.DownControl = null;
            this.dtpDocumentDateTo.EnterControl = null;
            this.dtpDocumentDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDocumentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocumentDateTo.LeftControl = this.txtDocumentDateToDays;
            this.dtpDocumentDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpDocumentDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDocumentDateTo.MonthLinkTextControl = this.txtDocumentDateToMonth;
            this.dtpDocumentDateTo.Name = "dtpDocumentDateTo";
            this.dtpDocumentDateTo.RightControl = null;
            this.dtpDocumentDateTo.Size = new System.Drawing.Size(211, 27);
            this.dtpDocumentDateTo.TabIndex = 150;
            this.dtpDocumentDateTo.UpControl = null;
            this.dtpDocumentDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpDocumentDateTo.Value2 = null;
            this.dtpDocumentDateTo.YearsLinkTextControl = this.txtDocumentDateToYears;
            // 
            // pnlDocumentDateFrom
            // 
            this.pnlDocumentDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDocumentDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDocumentDateFrom.Controls.Add(this.lblDocumentDateFromDays);
            this.pnlDocumentDateFrom.Controls.Add(this.txtDocumentDateFromDays);
            this.pnlDocumentDateFrom.Controls.Add(this.lblDocumentDateFromMonth);
            this.pnlDocumentDateFrom.Controls.Add(this.txtDocumentDateFromMonth);
            this.pnlDocumentDateFrom.Controls.Add(this.lblDocumentDateFromYears);
            this.pnlDocumentDateFrom.Controls.Add(this.txtDocumentDateFromYears);
            this.pnlDocumentDateFrom.Controls.Add(this.dtpDocumentDateFrom);
            this.pnlDocumentDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlDocumentDateFrom.Location = new System.Drawing.Point(150, 54);
            this.pnlDocumentDateFrom.Name = "pnlDocumentDateFrom";
            this.pnlDocumentDateFrom.Size = new System.Drawing.Size(211, 27);
            this.pnlDocumentDateFrom.TabIndex = 60;
            // 
            // lblDocumentDateFromDays
            // 
            this.lblDocumentDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblDocumentDateFromDays.Name = "lblDocumentDateFromDays";
            this.lblDocumentDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblDocumentDateFromDays.TabIndex = 119;
            this.lblDocumentDateFromDays.Text = "日";
            this.lblDocumentDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumentDateFromMonth
            // 
            this.lblDocumentDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblDocumentDateFromMonth.Name = "lblDocumentDateFromMonth";
            this.lblDocumentDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblDocumentDateFromMonth.TabIndex = 117;
            this.lblDocumentDateFromMonth.Text = "月";
            this.lblDocumentDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumentDateFromYears
            // 
            this.lblDocumentDateFromYears.Location = new System.Drawing.Point(44, 0);
            this.lblDocumentDateFromYears.Name = "lblDocumentDateFromYears";
            this.lblDocumentDateFromYears.Size = new System.Drawing.Size(28, 27);
            this.lblDocumentDateFromYears.TabIndex = 115;
            this.lblDocumentDateFromYears.Text = "年";
            this.lblDocumentDateFromYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDocumentDateFrom
            // 
            this.dtpDocumentDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDocumentDateFrom.CustomFormat = " ";
            this.dtpDocumentDateFrom.DaysLinkTextControl = this.txtDocumentDateFromDays;
            this.dtpDocumentDateFrom.DownControl = this.txtDocumentNo;
            this.dtpDocumentDateFrom.EnterControl = this.txtDocumentDateToYears;
            this.dtpDocumentDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDocumentDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocumentDateFrom.LeftControl = this.txtDocumentDateFromDays;
            this.dtpDocumentDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpDocumentDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDocumentDateFrom.MonthLinkTextControl = this.txtDocumentDateFromMonth;
            this.dtpDocumentDateFrom.Name = "dtpDocumentDateFrom";
            this.dtpDocumentDateFrom.RightControl = this.txtDocumentDateToYears;
            this.dtpDocumentDateFrom.Size = new System.Drawing.Size(211, 27);
            this.dtpDocumentDateFrom.TabIndex = 100;
            this.dtpDocumentDateFrom.UpControl = this.txtBillingDateYears;
            this.dtpDocumentDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpDocumentDateFrom.Value2 = null;
            this.dtpDocumentDateFrom.YearsLinkTextControl = this.txtDocumentDateFromYears;
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.Location = new System.Drawing.Point(372, 61);
            this.lblFromToSeparated2.Name = "lblFromToSeparated2";
            this.lblFromToSeparated2.Size = new System.Drawing.Size(24, 20);
            this.lblFromToSeparated2.TabIndex = 136;
            this.lblFromToSeparated2.Text = "～";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDocumentDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDocumentDate.ForeColor = System.Drawing.Color.White;
            this.lblDocumentDate.Location = new System.Drawing.Point(20, 54);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(130, 27);
            this.lblDocumentDate.TabIndex = 135;
            this.lblDocumentDate.Text = "伝票日付";
            this.lblDocumentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBillingDate1
            // 
            this.lblBillingDate1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBillingDate1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBillingDate1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBillingDate1.ForeColor = System.Drawing.Color.White;
            this.lblBillingDate1.Location = new System.Drawing.Point(20, 16);
            this.lblBillingDate1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillingDate1.Name = "lblBillingDate1";
            this.lblBillingDate1.Size = new System.Drawing.Size(130, 27);
            this.lblBillingDate1.TabIndex = 118;
            this.lblBillingDate1.Text = "請求年月";
            this.lblBillingDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBillingDate
            // 
            this.pnlBillingDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBillingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillingDate.Controls.Add(this.lblBillingDateMonth);
            this.pnlBillingDate.Controls.Add(this.txtBillingDateMonth);
            this.pnlBillingDate.Controls.Add(this.lblBillingDateYears);
            this.pnlBillingDate.Controls.Add(this.txtBillingDateYears);
            this.pnlBillingDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlBillingDate.Location = new System.Drawing.Point(150, 16);
            this.pnlBillingDate.Name = "pnlBillingDate";
            this.pnlBillingDate.Size = new System.Drawing.Size(211, 27);
            this.pnlBillingDate.TabIndex = 10;
            // 
            // lblBillingDateMonth
            // 
            this.lblBillingDateMonth.Location = new System.Drawing.Point(93, 0);
            this.lblBillingDateMonth.Name = "lblBillingDateMonth";
            this.lblBillingDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblBillingDateMonth.TabIndex = 117;
            this.lblBillingDateMonth.Text = "月";
            this.lblBillingDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBillingDateYears
            // 
            this.lblBillingDateYears.Location = new System.Drawing.Point(44, 0);
            this.lblBillingDateYears.Name = "lblBillingDateYears";
            this.lblBillingDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblBillingDateYears.TabIndex = 115;
            this.lblBillingDateYears.Text = "年";
            this.lblBillingDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 331);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(641, 70);
            this.pnlBottom.TabIndex = 220;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(384, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 250;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(229, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 40);
            this.btnSave.TabIndex = 240;
            this.btnSave.Text = "F10：一覧表示";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnListDisp_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(11, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 230;
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
            this.btnClose.Location = new System.Drawing.Point(498, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 260;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSeikyuChangeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 401);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmSeikyuChangeSearch";
            this.Text = "検索条件";
            this.Load += new System.EventHandler(this.frmSeikyuChangeSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBillingDateDays.ResumeLayout(false);
            this.pnlBillingDateDays.PerformLayout();
            this.pnlDocumentDateTo.ResumeLayout(false);
            this.pnlDocumentDateTo.PerformLayout();
            this.pnlDocumentDateFrom.ResumeLayout(false);
            this.pnlDocumentDateFrom.PerformLayout();
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
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private Common.ItemHeadLabel lblBillingDate1;
        private System.Windows.Forms.Panel pnlBillingDate;
        private Common.CustomTextBox txtBillingDateMonth;
        private Common.CustomTextBox txtBillingDateYears;
        private System.Windows.Forms.Label lblBillingDateMonth;
        private System.Windows.Forms.Label lblBillingDateYears;
        private System.Windows.Forms.Panel pnlDocumentDateTo;
        private System.Windows.Forms.Label lblDocumentDateToDays;
        private Common.CustomTextBox txtDocumentDateToDays;
        private Common.CustomTextBox txtDocumentDateToMonth;
        private Common.CustomTextBox txtDocumentDateToYears;
        private Common.CustomTextBox txtDocumentDateFromDays;
        private Common.CustomTextBox txtDocumentDateFromMonth;
        private Common.CustomTextBox txtDocumentDateFromYears;
        private System.Windows.Forms.Label lblDocumentDateToMonth;
        private System.Windows.Forms.Label lblDocumentDateToYears;
        private Common.CustomDateTimePicker dtpDocumentDateTo;
        private System.Windows.Forms.Panel pnlDocumentDateFrom;
        private System.Windows.Forms.Label lblDocumentDateFromDays;
        private System.Windows.Forms.Label lblDocumentDateFromMonth;
        private System.Windows.Forms.Label lblDocumentDateFromYears;
        private Common.CustomDateTimePicker dtpDocumentDateFrom;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.ItemHeadLabel lblDocumentDate;
        private Common.ItemHeadLabel lblBillingDate2;
        private System.Windows.Forms.Panel pnlBillingDateDays;
        private System.Windows.Forms.Label lblBillingDateDays;
        private Common.CustomTextBox txtBillingDateDays;
        private Common.ItemHeadLabel lblDocumentNo;
        private Common.CustomTextBox txtDocumentNo;
        private Common.ItemHeadLabel lblOrdersNo;
        private Common.CustomTextBox txtOrdersNo;
        private Common.ItemHeadLabel lblCustomerKanaName;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.ItemHeadLabel lblCustomerName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private Common.ItemHeadLabel lblOffices;
        private Common.CustomComboBox cmbOffices;
    }
}