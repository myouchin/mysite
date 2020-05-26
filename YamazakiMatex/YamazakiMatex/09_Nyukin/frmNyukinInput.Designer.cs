namespace Nyukin
{
    partial class frmNyukinInput
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
            this.lblDepositNo = new Common.ItemHeadLabel();
            this.txtDepositNo = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtCash = new Common.CustomTextBox();
            this.txtCheck = new Common.CustomTextBox();
            this.txtOffset = new Common.CustomTextBox();
            this.txtAdjustment = new Common.CustomTextBox();
            this.txtOther = new Common.CustomTextBox();
            this.txtRebate = new Common.CustomTextBox();
            this.txtERReceivables = new Common.CustomTextBox();
            this.txtBillsDiscount = new Common.CustomTextBox();
            this.txtBills = new Common.CustomTextBox();
            this.txtTransfer = new Common.CustomTextBox();
            this.txtFee = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.cmbOffices = new Common.CustomComboBox();
            this.cmbPersonnel = new Common.CustomComboBox();
            this.txtDepositDateDays = new Common.CustomTextBox();
            this.txtDepositDateMonth = new Common.CustomTextBox();
            this.txtDepositDateYears = new Common.CustomTextBox();
            this.txtTotal = new Common.CustomTextBox();
            this.btnPrint = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPlace = new Common.CustomTextBox();
            this.txtAddress1 = new Common.CustomTextBox();
            this.txtAddress2 = new Common.CustomTextBox();
            this.txtZipCode = new Common.CustomTextBox();
            this.txtArea = new Common.CustomTextBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.lblPersonnel = new Common.ItemHeadLabel();
            this.lblOffices = new Common.ItemHeadLabel();
            this.pnlDepositDate = new System.Windows.Forms.Panel();
            this.lblDepositDateDays = new System.Windows.Forms.Label();
            this.lblDepositDateMonth = new System.Windows.Forms.Label();
            this.lblDepositDateYears = new System.Windows.Forms.Label();
            this.dtpDepositDate = new Common.CustomDateTimePicker();
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.lblProcessingMode = new Common.ItemHeadLabel();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.lblCustomerName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.lblDepositDate = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblBillsDiscount = new Common.ItemHeadLabel();
            this.lblOther = new Common.ItemHeadLabel();
            this.lblAdjustment = new Common.ItemHeadLabel();
            this.lblERReceivables = new Common.ItemHeadLabel();
            this.lblCheck = new Common.ItemHeadLabel();
            this.lblTotal = new Common.ItemHeadLabel();
            this.lblOffset = new Common.ItemHeadLabel();
            this.lblRebate = new Common.ItemHeadLabel();
            this.lblCash = new Common.ItemHeadLabel();
            this.lblBills = new Common.ItemHeadLabel();
            this.lblFee = new Common.ItemHeadLabel();
            this.lblTransfer = new Common.ItemHeadLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlDepositDate.SuspendLayout();
            this.pnlProcessingMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDepositNo
            // 
            this.lblDepositNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDepositNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDepositNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDepositNo.ForeColor = System.Drawing.Color.White;
            this.lblDepositNo.Location = new System.Drawing.Point(130, 91);
            this.lblDepositNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepositNo.Name = "lblDepositNo";
            this.lblDepositNo.Size = new System.Drawing.Size(130, 27);
            this.lblDepositNo.TabIndex = 0;
            this.lblDepositNo.Text = "入金NO";
            this.lblDepositNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDepositNo
            // 
            this.txtDepositNo.BeforeValue = "";
            this.txtDepositNo.DownControl = this.txtCustomerCode;
            this.txtDepositNo.EnterControl = this.txtDepositDateYears;
            this.txtDepositNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositNo.LabelControl = null;
            this.txtDepositNo.LeftControl = null;
            this.txtDepositNo.Location = new System.Drawing.Point(260, 91);
            this.txtDepositNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositNo.Name = "txtDepositNo";
            this.txtDepositNo.RightControl = this.txtDepositDateYears;
            this.txtDepositNo.Size = new System.Drawing.Size(130, 27);
            this.txtDepositNo.TabIndex = 61;
            this.txtDepositNo.Text = "XXXXXXX8";
            this.txtDepositNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositNo.UpControl = null;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.txtCash;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(260, 119);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 131;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtDepositNo;
            // 
            // txtCash
            // 
            this.txtCash.BeforeValue = "";
            this.txtCash.DownControl = this.txtCheck;
            this.txtCash.EnterControl = this.txtTransfer;
            this.txtCash.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCash.LabelControl = null;
            this.txtCash.LeftControl = null;
            this.txtCash.Location = new System.Drawing.Point(260, 21);
            this.txtCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCash.Name = "txtCash";
            this.txtCash.RightControl = this.txtTransfer;
            this.txtCash.Size = new System.Drawing.Size(130, 27);
            this.txtCash.TabIndex = 161;
            this.txtCash.Text = "12,345,678";
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCash.UpControl = this.txtCustomerCode;
            // 
            // txtCheck
            // 
            this.txtCheck.BeforeValue = "";
            this.txtCheck.DownControl = this.txtOffset;
            this.txtCheck.EnterControl = this.txtBills;
            this.txtCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCheck.LabelControl = null;
            this.txtCheck.LeftControl = null;
            this.txtCheck.Location = new System.Drawing.Point(260, 54);
            this.txtCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.RightControl = this.txtBills;
            this.txtCheck.Size = new System.Drawing.Size(130, 27);
            this.txtCheck.TabIndex = 191;
            this.txtCheck.Text = "12,345,678";
            this.txtCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheck.UpControl = this.txtCash;
            // 
            // txtOffset
            // 
            this.txtOffset.BeforeValue = "";
            this.txtOffset.DownControl = this.txtAdjustment;
            this.txtOffset.EnterControl = this.txtRebate;
            this.txtOffset.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOffset.LabelControl = null;
            this.txtOffset.LeftControl = null;
            this.txtOffset.Location = new System.Drawing.Point(260, 87);
            this.txtOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.RightControl = this.txtRebate;
            this.txtOffset.Size = new System.Drawing.Size(130, 27);
            this.txtOffset.TabIndex = 221;
            this.txtOffset.Text = "12,345,678";
            this.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOffset.UpControl = this.txtCheck;
            // 
            // txtAdjustment
            // 
            this.txtAdjustment.BeforeValue = "";
            this.txtAdjustment.DownControl = null;
            this.txtAdjustment.EnterControl = this.txtOther;
            this.txtAdjustment.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtAdjustment.LabelControl = null;
            this.txtAdjustment.LeftControl = null;
            this.txtAdjustment.Location = new System.Drawing.Point(260, 120);
            this.txtAdjustment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdjustment.Name = "txtAdjustment";
            this.txtAdjustment.RightControl = this.txtOther;
            this.txtAdjustment.Size = new System.Drawing.Size(130, 27);
            this.txtAdjustment.TabIndex = 251;
            this.txtAdjustment.Text = "12,345,678";
            this.txtAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdjustment.UpControl = this.txtOffset;
            // 
            // txtOther
            // 
            this.txtOther.BeforeValue = "";
            this.txtOther.DownControl = null;
            this.txtOther.EnterControl = null;
            this.txtOther.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOther.LabelControl = null;
            this.txtOther.LeftControl = this.txtAdjustment;
            this.txtOther.Location = new System.Drawing.Point(558, 120);
            this.txtOther.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOther.Name = "txtOther";
            this.txtOther.RightControl = null;
            this.txtOther.Size = new System.Drawing.Size(130, 27);
            this.txtOther.TabIndex = 261;
            this.txtOther.Text = "12,345,678";
            this.txtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOther.UpControl = this.txtRebate;
            // 
            // txtRebate
            // 
            this.txtRebate.BeforeValue = "";
            this.txtRebate.DownControl = this.txtOther;
            this.txtRebate.EnterControl = this.txtERReceivables;
            this.txtRebate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtRebate.LabelControl = null;
            this.txtRebate.LeftControl = this.txtOffset;
            this.txtRebate.Location = new System.Drawing.Point(558, 87);
            this.txtRebate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRebate.Name = "txtRebate";
            this.txtRebate.RightControl = this.txtERReceivables;
            this.txtRebate.Size = new System.Drawing.Size(130, 27);
            this.txtRebate.TabIndex = 231;
            this.txtRebate.Text = "12,345,678";
            this.txtRebate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRebate.UpControl = this.txtBills;
            // 
            // txtERReceivables
            // 
            this.txtERReceivables.BeforeValue = "";
            this.txtERReceivables.DownControl = null;
            this.txtERReceivables.EnterControl = this.txtAdjustment;
            this.txtERReceivables.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtERReceivables.LabelControl = null;
            this.txtERReceivables.LeftControl = this.txtRebate;
            this.txtERReceivables.Location = new System.Drawing.Point(856, 87);
            this.txtERReceivables.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtERReceivables.Name = "txtERReceivables";
            this.txtERReceivables.RightControl = null;
            this.txtERReceivables.Size = new System.Drawing.Size(130, 27);
            this.txtERReceivables.TabIndex = 241;
            this.txtERReceivables.Text = "12,345,678";
            this.txtERReceivables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtERReceivables.UpControl = this.txtBillsDiscount;
            // 
            // txtBillsDiscount
            // 
            this.txtBillsDiscount.BeforeValue = "";
            this.txtBillsDiscount.DownControl = this.txtERReceivables;
            this.txtBillsDiscount.EnterControl = this.txtOffset;
            this.txtBillsDiscount.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBillsDiscount.LabelControl = null;
            this.txtBillsDiscount.LeftControl = this.txtBills;
            this.txtBillsDiscount.Location = new System.Drawing.Point(856, 54);
            this.txtBillsDiscount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillsDiscount.Name = "txtBillsDiscount";
            this.txtBillsDiscount.RightControl = null;
            this.txtBillsDiscount.Size = new System.Drawing.Size(130, 27);
            this.txtBillsDiscount.TabIndex = 211;
            this.txtBillsDiscount.Text = "12,345,678";
            this.txtBillsDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBillsDiscount.UpControl = this.txtFee;
            // 
            // txtBills
            // 
            this.txtBills.BeforeValue = "";
            this.txtBills.DownControl = this.txtRebate;
            this.txtBills.EnterControl = this.txtBillsDiscount;
            this.txtBills.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBills.LabelControl = null;
            this.txtBills.LeftControl = this.txtCheck;
            this.txtBills.Location = new System.Drawing.Point(558, 54);
            this.txtBills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBills.Name = "txtBills";
            this.txtBills.RightControl = this.txtBillsDiscount;
            this.txtBills.Size = new System.Drawing.Size(130, 27);
            this.txtBills.TabIndex = 201;
            this.txtBills.Text = "12,345,678";
            this.txtBills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBills.UpControl = this.txtTransfer;
            // 
            // txtTransfer
            // 
            this.txtTransfer.BeforeValue = "";
            this.txtTransfer.DownControl = this.txtBills;
            this.txtTransfer.EnterControl = this.txtFee;
            this.txtTransfer.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTransfer.LabelControl = null;
            this.txtTransfer.LeftControl = this.txtCash;
            this.txtTransfer.Location = new System.Drawing.Point(558, 21);
            this.txtTransfer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.RightControl = this.txtFee;
            this.txtTransfer.Size = new System.Drawing.Size(130, 27);
            this.txtTransfer.TabIndex = 171;
            this.txtTransfer.Text = "12,345,678";
            this.txtTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransfer.UpControl = this.txtCustomerCode;
            // 
            // txtFee
            // 
            this.txtFee.BeforeValue = "";
            this.txtFee.DownControl = this.txtBillsDiscount;
            this.txtFee.EnterControl = this.txtCheck;
            this.txtFee.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtFee.LabelControl = null;
            this.txtFee.LeftControl = this.txtTransfer;
            this.txtFee.Location = new System.Drawing.Point(856, 21);
            this.txtFee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFee.Name = "txtFee";
            this.txtFee.RightControl = null;
            this.txtFee.Size = new System.Drawing.Size(130, 27);
            this.txtFee.TabIndex = 181;
            this.txtFee.Text = "12,345,678";
            this.txtFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFee.UpControl = this.txtCustomerCode;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.txtCash;
            this.txtCustomerName.EnterControl = this.cmbOffices;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(521, 119);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.cmbOffices;
            this.txtCustomerName.Size = new System.Drawing.Size(242, 27);
            this.txtCustomerName.TabIndex = 141;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtDepositDateYears;
            // 
            // cmbOffices
            // 
            this.cmbOffices.BeforeSelectedValue = "";
            this.cmbOffices.DownControl = this.txtCash;
            this.cmbOffices.EnterControl = this.txtCash;
            this.cmbOffices.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.LabelControl = null;
            this.cmbOffices.LeftControl = this.txtCustomerName;
            this.cmbOffices.Location = new System.Drawing.Point(870, 119);
            this.cmbOffices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.RightControl = null;
            this.cmbOffices.Size = new System.Drawing.Size(146, 27);
            this.cmbOffices.TabIndex = 151;
            this.cmbOffices.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbOffices.UpControl = this.cmbPersonnel;
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.BeforeSelectedValue = "";
            this.cmbPersonnel.DownControl = this.cmbOffices;
            this.cmbPersonnel.EnterControl = this.txtCustomerCode;
            this.cmbPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.LabelControl = null;
            this.cmbPersonnel.LeftControl = this.txtDepositDateDays;
            this.cmbPersonnel.Location = new System.Drawing.Point(870, 90);
            this.cmbPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.RightControl = null;
            this.cmbPersonnel.Size = new System.Drawing.Size(146, 27);
            this.cmbPersonnel.TabIndex = 121;
            this.cmbPersonnel.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPersonnel.UpControl = null;
            // 
            // txtDepositDateDays
            // 
            this.txtDepositDateDays.BeforeValue = "";
            this.txtDepositDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateDays.DownControl = this.txtCustomerName;
            this.txtDepositDateDays.EnterControl = this.txtCustomerCode;
            this.txtDepositDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateDays.LabelControl = null;
            this.txtDepositDateDays.LeftControl = this.txtDepositDateMonth;
            this.txtDepositDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtDepositDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateDays.Name = "txtDepositDateDays";
            this.txtDepositDateDays.RightControl = null;
            this.txtDepositDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtDepositDateDays.TabIndex = 101;
            this.txtDepositDateDays.Text = "12";
            this.txtDepositDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateDays.UpControl = null;
            // 
            // txtDepositDateMonth
            // 
            this.txtDepositDateMonth.BeforeValue = "";
            this.txtDepositDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateMonth.DownControl = this.txtCustomerName;
            this.txtDepositDateMonth.EnterControl = this.txtDepositDateDays;
            this.txtDepositDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateMonth.LabelControl = null;
            this.txtDepositDateMonth.LeftControl = this.txtDepositDateYears;
            this.txtDepositDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtDepositDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateMonth.Name = "txtDepositDateMonth";
            this.txtDepositDateMonth.RightControl = this.txtDepositDateDays;
            this.txtDepositDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtDepositDateMonth.TabIndex = 91;
            this.txtDepositDateMonth.Text = "12";
            this.txtDepositDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateMonth.UpControl = null;
            // 
            // txtDepositDateYears
            // 
            this.txtDepositDateYears.BeforeValue = "";
            this.txtDepositDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateYears.DownControl = this.txtCustomerName;
            this.txtDepositDateYears.EnterControl = this.txtDepositDateMonth;
            this.txtDepositDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateYears.LabelControl = null;
            this.txtDepositDateYears.LeftControl = this.txtDepositNo;
            this.txtDepositDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtDepositDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateYears.Name = "txtDepositDateYears";
            this.txtDepositDateYears.RightControl = this.txtDepositDateMonth;
            this.txtDepositDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtDepositDateYears.TabIndex = 81;
            this.txtDepositDateYears.Text = "1234";
            this.txtDepositDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateYears.UpControl = null;
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeValue = "";
            this.txtTotal.DownControl = null;
            this.txtTotal.EnterControl = null;
            this.txtTotal.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTotal.LabelControl = null;
            this.txtTotal.LeftControl = null;
            this.txtTotal.Location = new System.Drawing.Point(856, 182);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightControl = null;
            this.txtTotal.Size = new System.Drawing.Size(130, 27);
            this.txtTotal.TabIndex = 271;
            this.txtTotal.Text = "12,345,678";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.UpControl = null;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(116, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 40);
            this.btnPrint.TabIndex = 301;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(4, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 40);
            this.btnSearch.TabIndex = 291;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(840, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 40);
            this.btnSave.TabIndex = 311;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(952, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 40);
            this.btnCancel.TabIndex = 321;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.txtPlace);
            this.pnlHeader.Controls.Add(this.txtAddress1);
            this.pnlHeader.Controls.Add(this.txtAddress2);
            this.pnlHeader.Controls.Add(this.txtZipCode);
            this.pnlHeader.Controls.Add(this.txtArea);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.cmbPersonnel);
            this.pnlHeader.Controls.Add(this.lblPersonnel);
            this.pnlHeader.Controls.Add(this.lblOffices);
            this.pnlHeader.Controls.Add(this.cmbOffices);
            this.pnlHeader.Controls.Add(this.pnlDepositDate);
            this.pnlHeader.Controls.Add(this.pnlProcessingMode);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.lblDepositDate);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblDepositNo);
            this.pnlHeader.Controls.Add(this.txtDepositNo);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1188, 155);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.Location = new System.Drawing.Point(685, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 42);
            this.lblTitle.TabIndex = 408;
            this.lblTitle.Text = "入金";
            // 
            // txtPlace
            // 
            this.txtPlace.BeforeValue = "";
            this.txtPlace.DownControl = null;
            this.txtPlace.EnterControl = this.cmbOffices;
            this.txtPlace.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPlace.LabelControl = null;
            this.txtPlace.LeftControl = this.txtCustomerName;
            this.txtPlace.Location = new System.Drawing.Point(459, 3);
            this.txtPlace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.RightControl = this.cmbOffices;
            this.txtPlace.Size = new System.Drawing.Size(131, 27);
            this.txtPlace.TabIndex = 407;
            this.txtPlace.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtPlace.UpControl = null;
            this.txtPlace.Visible = false;
            // 
            // txtAddress1
            // 
            this.txtAddress1.BeforeValue = "";
            this.txtAddress1.DownControl = null;
            this.txtAddress1.EnterControl = this.txtAddress2;
            this.txtAddress1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtAddress1.LabelControl = null;
            this.txtAddress1.LeftControl = this.txtZipCode;
            this.txtAddress1.Location = new System.Drawing.Point(459, 34);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.RightControl = this.txtAddress2;
            this.txtAddress1.Size = new System.Drawing.Size(131, 27);
            this.txtAddress1.TabIndex = 405;
            this.txtAddress1.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２５";
            this.txtAddress1.UpControl = null;
            this.txtAddress1.Visible = false;
            // 
            // txtAddress2
            // 
            this.txtAddress2.BeforeValue = "";
            this.txtAddress2.DownControl = null;
            this.txtAddress2.EnterControl = null;
            this.txtAddress2.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtAddress2.LabelControl = null;
            this.txtAddress2.LeftControl = this.txtAddress1;
            this.txtAddress2.Location = new System.Drawing.Point(589, 34);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.RightControl = null;
            this.txtAddress2.Size = new System.Drawing.Size(150, 27);
            this.txtAddress2.TabIndex = 406;
            this.txtAddress2.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２５";
            this.txtAddress2.UpControl = null;
            this.txtAddress2.Visible = false;
            // 
            // txtZipCode
            // 
            this.txtZipCode.BeforeValue = "";
            this.txtZipCode.DownControl = null;
            this.txtZipCode.EnterControl = this.txtAddress1;
            this.txtZipCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtZipCode.LabelControl = null;
            this.txtZipCode.LeftControl = null;
            this.txtZipCode.Location = new System.Drawing.Point(356, 34);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.RightControl = this.txtAddress1;
            this.txtZipCode.Size = new System.Drawing.Size(104, 27);
            this.txtZipCode.TabIndex = 404;
            this.txtZipCode.Text = "XXX-XXXX";
            this.txtZipCode.UpControl = null;
            this.txtZipCode.Visible = false;
            // 
            // txtArea
            // 
            this.txtArea.BeforeValue = "";
            this.txtArea.DownControl = null;
            this.txtArea.EnterControl = this.cmbOffices;
            this.txtArea.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtArea.LabelControl = null;
            this.txtArea.LeftControl = this.txtCustomerName;
            this.txtArea.Location = new System.Drawing.Point(589, 3);
            this.txtArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArea.Name = "txtArea";
            this.txtArea.RightControl = this.cmbOffices;
            this.txtArea.Size = new System.Drawing.Size(150, 27);
            this.txtArea.TabIndex = 378;
            this.txtArea.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtArea.UpControl = null;
            this.txtArea.Visible = false;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = null;
            this.txtCustomerKanaName.EnterControl = this.cmbOffices;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(356, 3);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = this.cmbOffices;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(104, 27);
            this.txtCustomerKanaName.TabIndex = 377;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = null;
            this.txtCustomerKanaName.Visible = false;
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblPersonnel.Location = new System.Drawing.Point(764, 91);
            this.lblPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(106, 27);
            this.lblPersonnel.TabIndex = 375;
            this.lblPersonnel.Text = "担当者";
            this.lblPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOffices
            // 
            this.lblOffices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffices.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffices.ForeColor = System.Drawing.Color.White;
            this.lblOffices.Location = new System.Drawing.Point(764, 119);
            this.lblOffices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffices.Name = "lblOffices";
            this.lblOffices.Size = new System.Drawing.Size(106, 27);
            this.lblOffices.TabIndex = 374;
            this.lblOffices.Text = "事業所";
            this.lblOffices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDepositDate
            // 
            this.pnlDepositDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDepositDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDepositDate.Controls.Add(this.lblDepositDateDays);
            this.pnlDepositDate.Controls.Add(this.txtDepositDateDays);
            this.pnlDepositDate.Controls.Add(this.lblDepositDateMonth);
            this.pnlDepositDate.Controls.Add(this.txtDepositDateMonth);
            this.pnlDepositDate.Controls.Add(this.lblDepositDateYears);
            this.pnlDepositDate.Controls.Add(this.txtDepositDateYears);
            this.pnlDepositDate.Controls.Add(this.dtpDepositDate);
            this.pnlDepositDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlDepositDate.Location = new System.Drawing.Point(521, 91);
            this.pnlDepositDate.Name = "pnlDepositDate";
            this.pnlDepositDate.Size = new System.Drawing.Size(242, 27);
            this.pnlDepositDate.TabIndex = 71;
            // 
            // lblDepositDateDays
            // 
            this.lblDepositDateDays.Location = new System.Drawing.Point(170, 0);
            this.lblDepositDateDays.Name = "lblDepositDateDays";
            this.lblDepositDateDays.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateDays.TabIndex = 119;
            this.lblDepositDateDays.Text = "日";
            this.lblDepositDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepositDateMonth
            // 
            this.lblDepositDateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblDepositDateMonth.Name = "lblDepositDateMonth";
            this.lblDepositDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateMonth.TabIndex = 117;
            this.lblDepositDateMonth.Text = "月";
            this.lblDepositDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepositDateYears
            // 
            this.lblDepositDateYears.Location = new System.Drawing.Point(51, 0);
            this.lblDepositDateYears.Name = "lblDepositDateYears";
            this.lblDepositDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateYears.TabIndex = 115;
            this.lblDepositDateYears.Text = "年";
            this.lblDepositDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDepositDate
            // 
            this.dtpDepositDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDepositDate.CustomFormat = " ";
            this.dtpDepositDate.DaysLinkTextControl = this.txtDepositDateDays;
            this.dtpDepositDate.DownControl = this.txtCustomerName;
            this.dtpDepositDate.EnterControl = this.cmbPersonnel;
            this.dtpDepositDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepositDate.LeftControl = this.txtDepositDateDays;
            this.dtpDepositDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpDepositDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDepositDate.MonthLinkTextControl = this.txtDepositDateMonth;
            this.dtpDepositDate.Name = "dtpDepositDate";
            this.dtpDepositDate.RightControl = this.cmbPersonnel;
            this.dtpDepositDate.Size = new System.Drawing.Size(242, 27);
            this.dtpDepositDate.TabIndex = 111;
            this.dtpDepositDate.TabStop = false;
            this.dtpDepositDate.UpControl = null;
            this.dtpDepositDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpDepositDate.Value2 = null;
            this.dtpDepositDate.YearsLinkTextControl = this.txtDepositDateYears;
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.rdoDelete);
            this.pnlProcessingMode.Controls.Add(this.lblProcessingMode);
            this.pnlProcessingMode.Controls.Add(this.rdoReference);
            this.pnlProcessingMode.Controls.Add(this.rdoCorrection);
            this.pnlProcessingMode.Controls.Add(this.rdoNew);
            this.pnlProcessingMode.Location = new System.Drawing.Point(4, 3);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(345, 65);
            this.pnlProcessingMode.TabIndex = 11;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(257, 32);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(69, 24);
            this.rdoDelete.TabIndex = 51;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "削除";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // lblProcessingMode
            // 
            this.lblProcessingMode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessingMode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProcessingMode.ForeColor = System.Drawing.Color.White;
            this.lblProcessingMode.Location = new System.Drawing.Point(5, 2);
            this.lblProcessingMode.Name = "lblProcessingMode";
            this.lblProcessingMode.Size = new System.Drawing.Size(130, 27);
            this.lblProcessingMode.TabIndex = 4;
            this.lblProcessingMode.Text = "処理モード";
            this.lblProcessingMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoReference
            // 
            this.rdoReference.AutoSize = true;
            this.rdoReference.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoReference.Location = new System.Drawing.Point(177, 32);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(69, 24);
            this.rdoReference.TabIndex = 41;
            this.rdoReference.TabStop = true;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            this.rdoReference.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(97, 32);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(69, 24);
            this.rdoCorrection.TabIndex = 31;
            this.rdoCorrection.TabStop = true;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            this.rdoCorrection.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoNew
            // 
            this.rdoNew.AutoSize = true;
            this.rdoNew.Checked = true;
            this.rdoNew.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(17, 32);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(69, 24);
            this.rdoNew.TabIndex = 21;
            this.rdoNew.TabStop = true;
            this.rdoNew.Text = "新規";
            this.rdoNew.UseVisualStyleBackColor = true;
            this.rdoNew.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(391, 119);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerName.TabIndex = 58;
            this.lblCustomerName.Text = "得意先名";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(130, 119);
            this.lblCustomerCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 57;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepositDate
            // 
            this.lblDepositDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDepositDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDepositDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDepositDate.ForeColor = System.Drawing.Color.White;
            this.lblDepositDate.Location = new System.Drawing.Point(391, 91);
            this.lblDepositDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepositDate.Name = "lblDepositDate";
            this.lblDepositDate.Size = new System.Drawing.Size(130, 27);
            this.lblDepositDate.TabIndex = 56;
            this.lblDepositDate.Text = "入金日";
            this.lblDepositDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.lblBillsDiscount);
            this.pnlBody.Controls.Add(this.txtBillsDiscount);
            this.pnlBody.Controls.Add(this.lblOther);
            this.pnlBody.Controls.Add(this.txtOther);
            this.pnlBody.Controls.Add(this.lblAdjustment);
            this.pnlBody.Controls.Add(this.txtAdjustment);
            this.pnlBody.Controls.Add(this.lblERReceivables);
            this.pnlBody.Controls.Add(this.txtERReceivables);
            this.pnlBody.Controls.Add(this.lblCheck);
            this.pnlBody.Controls.Add(this.txtCheck);
            this.pnlBody.Controls.Add(this.lblTotal);
            this.pnlBody.Controls.Add(this.txtTotal);
            this.pnlBody.Controls.Add(this.lblOffset);
            this.pnlBody.Controls.Add(this.txtOffset);
            this.pnlBody.Controls.Add(this.lblRebate);
            this.pnlBody.Controls.Add(this.txtRebate);
            this.pnlBody.Controls.Add(this.lblCash);
            this.pnlBody.Controls.Add(this.txtCash);
            this.pnlBody.Controls.Add(this.lblBills);
            this.pnlBody.Controls.Add(this.txtBills);
            this.pnlBody.Controls.Add(this.lblFee);
            this.pnlBody.Controls.Add(this.txtFee);
            this.pnlBody.Controls.Add(this.lblTransfer);
            this.pnlBody.Controls.Add(this.txtTransfer);
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 156);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.MinimumSize = new System.Drawing.Size(4, 100);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1187, 233);
            this.pnlBody.TabIndex = 151;
            // 
            // lblBillsDiscount
            // 
            this.lblBillsDiscount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBillsDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBillsDiscount.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBillsDiscount.ForeColor = System.Drawing.Color.White;
            this.lblBillsDiscount.Location = new System.Drawing.Point(726, 54);
            this.lblBillsDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillsDiscount.Name = "lblBillsDiscount";
            this.lblBillsDiscount.Size = new System.Drawing.Size(130, 27);
            this.lblBillsDiscount.TabIndex = 240;
            this.lblBillsDiscount.Text = "手形割引料";
            this.lblBillsDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOther
            // 
            this.lblOther.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOther.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOther.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOther.ForeColor = System.Drawing.Color.White;
            this.lblOther.Location = new System.Drawing.Point(428, 120);
            this.lblOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(130, 27);
            this.lblOther.TabIndex = 238;
            this.lblOther.Text = "その他";
            this.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdjustment
            // 
            this.lblAdjustment.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAdjustment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAdjustment.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAdjustment.ForeColor = System.Drawing.Color.White;
            this.lblAdjustment.Location = new System.Drawing.Point(130, 120);
            this.lblAdjustment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdjustment.Name = "lblAdjustment";
            this.lblAdjustment.Size = new System.Drawing.Size(130, 27);
            this.lblAdjustment.TabIndex = 236;
            this.lblAdjustment.Text = "調整";
            this.lblAdjustment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblERReceivables
            // 
            this.lblERReceivables.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblERReceivables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblERReceivables.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblERReceivables.ForeColor = System.Drawing.Color.White;
            this.lblERReceivables.Location = new System.Drawing.Point(726, 87);
            this.lblERReceivables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblERReceivables.Name = "lblERReceivables";
            this.lblERReceivables.Size = new System.Drawing.Size(130, 27);
            this.lblERReceivables.TabIndex = 234;
            this.lblERReceivables.Text = "でんさい";
            this.lblERReceivables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheck
            // 
            this.lblCheck.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCheck.ForeColor = System.Drawing.Color.White;
            this.lblCheck.Location = new System.Drawing.Point(130, 54);
            this.lblCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(130, 27);
            this.lblCheck.TabIndex = 232;
            this.lblCheck.Text = "小切手";
            this.lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(726, 182);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(130, 27);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "合計";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOffset
            // 
            this.lblOffset.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffset.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffset.ForeColor = System.Drawing.Color.White;
            this.lblOffset.Location = new System.Drawing.Point(130, 87);
            this.lblOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(130, 27);
            this.lblOffset.TabIndex = 12;
            this.lblOffset.Text = "相殺";
            this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRebate
            // 
            this.lblRebate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRebate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRebate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRebate.ForeColor = System.Drawing.Color.White;
            this.lblRebate.Location = new System.Drawing.Point(428, 87);
            this.lblRebate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRebate.Name = "lblRebate";
            this.lblRebate.Size = new System.Drawing.Size(130, 27);
            this.lblRebate.TabIndex = 10;
            this.lblRebate.Text = "リベート";
            this.lblRebate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCash
            // 
            this.lblCash.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCash.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCash.ForeColor = System.Drawing.Color.White;
            this.lblCash.Location = new System.Drawing.Point(130, 21);
            this.lblCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(130, 27);
            this.lblCash.TabIndex = 8;
            this.lblCash.Text = "現金";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBills
            // 
            this.lblBills.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBills.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBills.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBills.ForeColor = System.Drawing.Color.White;
            this.lblBills.Location = new System.Drawing.Point(428, 54);
            this.lblBills.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBills.Name = "lblBills";
            this.lblBills.Size = new System.Drawing.Size(130, 27);
            this.lblBills.TabIndex = 6;
            this.lblBills.Text = "手形";
            this.lblBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFee
            // 
            this.lblFee.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFee.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFee.ForeColor = System.Drawing.Color.White;
            this.lblFee.Location = new System.Drawing.Point(726, 21);
            this.lblFee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(130, 27);
            this.lblFee.TabIndex = 4;
            this.lblFee.Text = "手数料";
            this.lblFee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransfer
            // 
            this.lblTransfer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTransfer.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTransfer.ForeColor = System.Drawing.Color.White;
            this.lblTransfer.Location = new System.Drawing.Point(428, 21);
            this.lblTransfer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransfer.Name = "lblTransfer";
            this.lblTransfer.Size = new System.Drawing.Size(130, 27);
            this.lblTransfer.TabIndex = 2;
            this.lblTransfer.Text = "振込";
            this.lblTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 389);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1188, 70);
            this.pnlBottom.TabIndex = 281;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(1064, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 331;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmNyukinInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1187, 463);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNyukinInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入金入力";
            this.Load += new System.EventHandler(this.frmNyukinInput_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDepositDate.ResumeLayout(false);
            this.pnlDepositDate.PerformLayout();
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.ItemHeadLabel lblDepositNo;
        private Common.CustomTextBox txtDepositNo;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private Common.ItemHeadLabel lblTotal;
        private Common.CustomTextBox txtTotal;
        private Common.ItemHeadLabel lblOffset;
        private Common.CustomTextBox txtOffset;
        private Common.ItemHeadLabel lblRebate;
        private Common.CustomTextBox txtRebate;
        private Common.ItemHeadLabel lblCash;
        private Common.CustomTextBox txtCash;
        private Common.ItemHeadLabel lblBills;
        private Common.CustomTextBox txtBills;
        private Common.ItemHeadLabel lblFee;
        private Common.CustomTextBox txtFee;
        private Common.ItemHeadLabel lblTransfer;
        private Common.CustomTextBox txtTransfer;
        private Common.ItemHeadLabel lblCustomerName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.ItemHeadLabel lblDepositDate;
        private System.Windows.Forms.Panel pnlProcessingMode;
        private System.Windows.Forms.RadioButton rdoDelete;
        private Common.ItemHeadLabel lblProcessingMode;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private Common.FeaturesButton btnClose;
        private System.Windows.Forms.Panel pnlDepositDate;
        private System.Windows.Forms.Label lblDepositDateDays;
        private Common.CustomTextBox txtDepositDateDays;
        private Common.CustomTextBox txtDepositDateMonth;
        private Common.CustomTextBox txtDepositDateYears;
        private System.Windows.Forms.Label lblDepositDateMonth;
        private System.Windows.Forms.Label lblDepositDateYears;
        private Common.CustomDateTimePicker dtpDepositDate;
        private Common.ItemHeadLabel lblOffices;
        private Common.CustomComboBox cmbOffices;
        private Common.CustomComboBox cmbPersonnel;
        private Common.ItemHeadLabel lblPersonnel;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.CustomTextBox txtArea;
        private Common.CustomTextBox txtAddress1;
        private Common.CustomTextBox txtAddress2;
        private Common.CustomTextBox txtZipCode;
        private Common.ItemHeadLabel lblCheck;
        private Common.CustomTextBox txtCheck;
        private Common.ItemHeadLabel lblERReceivables;
        private Common.CustomTextBox txtERReceivables;
        private Common.ItemHeadLabel lblOther;
        private Common.CustomTextBox txtOther;
        private Common.ItemHeadLabel lblAdjustment;
        private Common.CustomTextBox txtAdjustment;
        private Common.ItemHeadLabel lblBillsDiscount;
        private Common.CustomTextBox txtBillsDiscount;
        private Common.CustomTextBox txtPlace;
        private System.Windows.Forms.Label lblTitle;
    }
}