namespace Shiharai
{
    partial class frmShiharaiInput
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
            this.lblPaymentNo = new Common.ItemHeadLabel();
            this.txtPaymentNo = new Common.CustomTextBox();
            this.txtPurchaseCode = new Common.CustomTextBox();
            this.txtCash = new Common.CustomTextBox();
            this.txtBills = new Common.CustomTextBox();
            this.txtTransfer = new Common.CustomTextBox();
            this.txtOffset = new Common.CustomTextBox();
            this.txtTotal = new Common.CustomTextBox();
            this.txtPurchaseName = new Common.CustomTextBox();
            this.txtPaymentDateYears = new Common.CustomTextBox();
            this.txtPaymentDateMonth = new Common.CustomTextBox();
            this.txtPaymentDateDays = new Common.CustomTextBox();
            this.btnPrint = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtAddress1 = new Common.CustomTextBox();
            this.txtAddress2 = new Common.CustomTextBox();
            this.txtZipCode = new Common.CustomTextBox();
            this.pnlPaymentDate = new System.Windows.Forms.Panel();
            this.lblPaymentDateDays = new System.Windows.Forms.Label();
            this.lblPaymentDateMonth = new System.Windows.Forms.Label();
            this.lblPaymentDateYears = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new Common.CustomDateTimePicker();
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.lblProcessingMode = new Common.ItemHeadLabel();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.lblPurchaseName = new Common.ItemHeadLabel();
            this.lblPurchaseCode = new Common.ItemHeadLabel();
            this.lblPaymentDate = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblTotal = new Common.ItemHeadLabel();
            this.lblOffset = new Common.ItemHeadLabel();
            this.lblCash = new Common.ItemHeadLabel();
            this.lblBills = new Common.ItemHeadLabel();
            this.lblTransfer = new Common.ItemHeadLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlPaymentDate.SuspendLayout();
            this.pnlProcessingMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPaymentNo
            // 
            this.lblPaymentNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPaymentNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPaymentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPaymentNo.ForeColor = System.Drawing.Color.White;
            this.lblPaymentNo.Location = new System.Drawing.Point(150, 91);
            this.lblPaymentNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentNo.Name = "lblPaymentNo";
            this.lblPaymentNo.Size = new System.Drawing.Size(130, 27);
            this.lblPaymentNo.TabIndex = 0;
            this.lblPaymentNo.Text = "支払NO";
            this.lblPaymentNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPaymentNo
            // 
            this.txtPaymentNo.BeforeValue = "";
            this.txtPaymentNo.DownControl = this.txtPurchaseCode;
            this.txtPaymentNo.EnterControl = this.txtPaymentDateYears;
            this.txtPaymentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentNo.LabelControl = null;
            this.txtPaymentNo.LeftControl = null;
            this.txtPaymentNo.Location = new System.Drawing.Point(280, 91);
            this.txtPaymentNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentNo.Name = "txtPaymentNo";
            this.txtPaymentNo.RightControl = this.txtPaymentDateYears;
            this.txtPaymentNo.Size = new System.Drawing.Size(130, 27);
            this.txtPaymentNo.TabIndex = 61;
            this.txtPaymentNo.Text = "XXXXXXX8";
            this.txtPaymentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentNo.UpControl = null;
            // 
            // txtPurchaseCode
            // 
            this.txtPurchaseCode.BeforeValue = "";
            this.txtPurchaseCode.DownControl = this.txtCash;
            this.txtPurchaseCode.EnterControl = this.txtPurchaseName;
            this.txtPurchaseCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseCode.LabelControl = null;
            this.txtPurchaseCode.LeftControl = null;
            this.txtPurchaseCode.Location = new System.Drawing.Point(280, 119);
            this.txtPurchaseCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseCode.Name = "txtPurchaseCode";
            this.txtPurchaseCode.RightControl = this.txtPurchaseName;
            this.txtPurchaseCode.Size = new System.Drawing.Size(130, 27);
            this.txtPurchaseCode.TabIndex = 121;
            this.txtPurchaseCode.Text = "XXXXXXX8";
            this.txtPurchaseCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseCode.UpControl = this.txtPaymentNo;
            // 
            // txtCash
            // 
            this.txtCash.BeforeValue = "";
            this.txtCash.DownControl = this.txtBills;
            this.txtCash.EnterControl = this.txtBills;
            this.txtCash.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCash.LabelControl = null;
            this.txtCash.LeftControl = null;
            this.txtCash.Location = new System.Drawing.Point(280, 20);
            this.txtCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCash.Name = "txtCash";
            this.txtCash.RightControl = null;
            this.txtCash.Size = new System.Drawing.Size(130, 27);
            this.txtCash.TabIndex = 151;
            this.txtCash.Text = "12,345,678";
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCash.UpControl = this.txtPurchaseCode;
            // 
            // txtBills
            // 
            this.txtBills.BeforeValue = "";
            this.txtBills.DownControl = this.txtTransfer;
            this.txtBills.EnterControl = this.txtTransfer;
            this.txtBills.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtBills.LabelControl = null;
            this.txtBills.LeftControl = null;
            this.txtBills.Location = new System.Drawing.Point(280, 48);
            this.txtBills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBills.Name = "txtBills";
            this.txtBills.RightControl = null;
            this.txtBills.Size = new System.Drawing.Size(130, 27);
            this.txtBills.TabIndex = 161;
            this.txtBills.Text = "12,345,678";
            this.txtBills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBills.UpControl = this.txtCash;
            // 
            // txtTransfer
            // 
            this.txtTransfer.BeforeValue = "";
            this.txtTransfer.DownControl = this.txtOffset;
            this.txtTransfer.EnterControl = this.txtOffset;
            this.txtTransfer.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTransfer.LabelControl = null;
            this.txtTransfer.LeftControl = null;
            this.txtTransfer.Location = new System.Drawing.Point(280, 76);
            this.txtTransfer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.RightControl = null;
            this.txtTransfer.Size = new System.Drawing.Size(130, 27);
            this.txtTransfer.TabIndex = 171;
            this.txtTransfer.Text = "12,345,678";
            this.txtTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransfer.UpControl = this.txtBills;
            // 
            // txtOffset
            // 
            this.txtOffset.BeforeValue = "";
            this.txtOffset.DownControl = this.txtTotal;
            this.txtOffset.EnterControl = this.txtTotal;
            this.txtOffset.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOffset.LabelControl = null;
            this.txtOffset.LeftControl = null;
            this.txtOffset.Location = new System.Drawing.Point(280, 104);
            this.txtOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.RightControl = null;
            this.txtOffset.Size = new System.Drawing.Size(130, 27);
            this.txtOffset.TabIndex = 181;
            this.txtOffset.Text = "12,345,678";
            this.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOffset.UpControl = this.txtTransfer;
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeValue = "";
            this.txtTotal.DownControl = null;
            this.txtTotal.EnterControl = null;
            this.txtTotal.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTotal.LabelControl = null;
            this.txtTotal.LeftControl = null;
            this.txtTotal.Location = new System.Drawing.Point(280, 141);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightControl = null;
            this.txtTotal.Size = new System.Drawing.Size(130, 27);
            this.txtTotal.TabIndex = 191;
            this.txtTotal.Text = "12,345,678";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.UpControl = this.txtOffset;
            // 
            // txtPurchaseName
            // 
            this.txtPurchaseName.BeforeValue = "";
            this.txtPurchaseName.DownControl = null;
            this.txtPurchaseName.EnterControl = this.txtCash;
            this.txtPurchaseName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseName.LabelControl = null;
            this.txtPurchaseName.LeftControl = this.txtPurchaseCode;
            this.txtPurchaseName.Location = new System.Drawing.Point(541, 119);
            this.txtPurchaseName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseName.Name = "txtPurchaseName";
            this.txtPurchaseName.RightControl = null;
            this.txtPurchaseName.Size = new System.Drawing.Size(242, 27);
            this.txtPurchaseName.TabIndex = 131;
            this.txtPurchaseName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtPurchaseName.UpControl = this.txtPaymentDateYears;
            // 
            // txtPaymentDateYears
            // 
            this.txtPaymentDateYears.BeforeValue = "";
            this.txtPaymentDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateYears.DownControl = this.txtPurchaseName;
            this.txtPaymentDateYears.EnterControl = this.txtPaymentDateMonth;
            this.txtPaymentDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateYears.LabelControl = null;
            this.txtPaymentDateYears.LeftControl = this.txtPaymentNo;
            this.txtPaymentDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtPaymentDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateYears.Name = "txtPaymentDateYears";
            this.txtPaymentDateYears.RightControl = this.txtPaymentDateMonth;
            this.txtPaymentDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtPaymentDateYears.TabIndex = 81;
            this.txtPaymentDateYears.Text = "1234";
            this.txtPaymentDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateYears.UpControl = null;
            // 
            // txtPaymentDateMonth
            // 
            this.txtPaymentDateMonth.BeforeValue = "";
            this.txtPaymentDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateMonth.DownControl = this.txtPurchaseName;
            this.txtPaymentDateMonth.EnterControl = this.txtPaymentDateDays;
            this.txtPaymentDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateMonth.LabelControl = null;
            this.txtPaymentDateMonth.LeftControl = this.txtPaymentDateYears;
            this.txtPaymentDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtPaymentDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateMonth.Name = "txtPaymentDateMonth";
            this.txtPaymentDateMonth.RightControl = this.txtPaymentDateDays;
            this.txtPaymentDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtPaymentDateMonth.TabIndex = 91;
            this.txtPaymentDateMonth.Text = "12";
            this.txtPaymentDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateMonth.UpControl = null;
            // 
            // txtPaymentDateDays
            // 
            this.txtPaymentDateDays.BeforeValue = "";
            this.txtPaymentDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateDays.DownControl = this.txtPurchaseName;
            this.txtPaymentDateDays.EnterControl = this.txtPurchaseCode;
            this.txtPaymentDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateDays.LabelControl = null;
            this.txtPaymentDateDays.LeftControl = this.txtPaymentDateMonth;
            this.txtPaymentDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtPaymentDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateDays.Name = "txtPaymentDateDays";
            this.txtPaymentDateDays.RightControl = null;
            this.txtPaymentDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtPaymentDateDays.TabIndex = 101;
            this.txtPaymentDateDays.Text = "12";
            this.txtPaymentDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateDays.UpControl = null;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(116, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 40);
            this.btnPrint.TabIndex = 221;
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
            this.btnSearch.TabIndex = 211;
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
            this.btnSave.Location = new System.Drawing.Point(625, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 40);
            this.btnSave.TabIndex = 231;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(737, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 40);
            this.btnCancel.TabIndex = 241;
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
            this.pnlHeader.Controls.Add(this.txtAddress1);
            this.pnlHeader.Controls.Add(this.txtAddress2);
            this.pnlHeader.Controls.Add(this.txtZipCode);
            this.pnlHeader.Controls.Add(this.pnlPaymentDate);
            this.pnlHeader.Controls.Add(this.pnlProcessingMode);
            this.pnlHeader.Controls.Add(this.lblPurchaseName);
            this.pnlHeader.Controls.Add(this.lblPurchaseCode);
            this.pnlHeader.Controls.Add(this.lblPaymentDate);
            this.pnlHeader.Controls.Add(this.txtPurchaseCode);
            this.pnlHeader.Controls.Add(this.txtPurchaseName);
            this.pnlHeader.Controls.Add(this.lblPaymentNo);
            this.pnlHeader.Controls.Add(this.txtPaymentNo);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(973, 189);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.Location = new System.Drawing.Point(592, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 42);
            this.lblTitle.TabIndex = 404;
            this.lblTitle.Text = "支払";
            // 
            // txtAddress1
            // 
            this.txtAddress1.BeforeValue = "";
            this.txtAddress1.DownControl = null;
            this.txtAddress1.EnterControl = this.txtAddress2;
            this.txtAddress1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtAddress1.LabelControl = null;
            this.txtAddress1.LeftControl = this.txtZipCode;
            this.txtAddress1.Location = new System.Drawing.Point(253, 146);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.RightControl = this.txtAddress2;
            this.txtAddress1.Size = new System.Drawing.Size(131, 27);
            this.txtAddress1.TabIndex = 402;
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
            this.txtAddress2.Location = new System.Drawing.Point(383, 146);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.RightControl = null;
            this.txtAddress2.Size = new System.Drawing.Size(150, 27);
            this.txtAddress2.TabIndex = 403;
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
            this.txtZipCode.Location = new System.Drawing.Point(150, 146);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.RightControl = this.txtAddress1;
            this.txtZipCode.Size = new System.Drawing.Size(104, 27);
            this.txtZipCode.TabIndex = 401;
            this.txtZipCode.Text = "XXX-XXXX";
            this.txtZipCode.UpControl = null;
            this.txtZipCode.Visible = false;
            // 
            // pnlPaymentDate
            // 
            this.pnlPaymentDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlPaymentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaymentDate.Controls.Add(this.lblPaymentDateDays);
            this.pnlPaymentDate.Controls.Add(this.txtPaymentDateDays);
            this.pnlPaymentDate.Controls.Add(this.lblPaymentDateMonth);
            this.pnlPaymentDate.Controls.Add(this.txtPaymentDateMonth);
            this.pnlPaymentDate.Controls.Add(this.lblPaymentDateYears);
            this.pnlPaymentDate.Controls.Add(this.txtPaymentDateYears);
            this.pnlPaymentDate.Controls.Add(this.dtpPaymentDate);
            this.pnlPaymentDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlPaymentDate.Location = new System.Drawing.Point(541, 91);
            this.pnlPaymentDate.Name = "pnlPaymentDate";
            this.pnlPaymentDate.Size = new System.Drawing.Size(242, 27);
            this.pnlPaymentDate.TabIndex = 71;
            // 
            // lblPaymentDateDays
            // 
            this.lblPaymentDateDays.Location = new System.Drawing.Point(170, 0);
            this.lblPaymentDateDays.Name = "lblPaymentDateDays";
            this.lblPaymentDateDays.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateDays.TabIndex = 119;
            this.lblPaymentDateDays.Text = "日";
            this.lblPaymentDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDateMonth
            // 
            this.lblPaymentDateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblPaymentDateMonth.Name = "lblPaymentDateMonth";
            this.lblPaymentDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateMonth.TabIndex = 117;
            this.lblPaymentDateMonth.Text = "月";
            this.lblPaymentDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDateYears
            // 
            this.lblPaymentDateYears.Location = new System.Drawing.Point(51, 0);
            this.lblPaymentDateYears.Name = "lblPaymentDateYears";
            this.lblPaymentDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateYears.TabIndex = 115;
            this.lblPaymentDateYears.Text = "年";
            this.lblPaymentDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPaymentDate.CustomFormat = " ";
            this.dtpPaymentDate.DaysLinkTextControl = this.txtPaymentDateDays;
            this.dtpPaymentDate.DownControl = this.txtPurchaseName;
            this.dtpPaymentDate.EnterControl = this.txtPurchaseCode;
            this.dtpPaymentDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.LeftControl = this.txtPaymentDateDays;
            this.dtpPaymentDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpPaymentDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpPaymentDate.MonthLinkTextControl = this.txtPaymentDateMonth;
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.RightControl = null;
            this.dtpPaymentDate.Size = new System.Drawing.Size(242, 27);
            this.dtpPaymentDate.TabIndex = 111;
            this.dtpPaymentDate.TabStop = false;
            this.dtpPaymentDate.UpControl = null;
            this.dtpPaymentDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpPaymentDate.Value2 = null;
            this.dtpPaymentDate.YearsLinkTextControl = this.txtPaymentDateYears;
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
            this.rdoDelete.AutoCheck = false;
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
            this.rdoReference.AutoCheck = false;
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
            this.rdoCorrection.AutoCheck = false;
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
            this.rdoNew.AutoCheck = false;
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
            // lblPurchaseName
            // 
            this.lblPurchaseName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPurchaseName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPurchaseName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPurchaseName.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseName.Location = new System.Drawing.Point(411, 119);
            this.lblPurchaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchaseName.Name = "lblPurchaseName";
            this.lblPurchaseName.Size = new System.Drawing.Size(130, 27);
            this.lblPurchaseName.TabIndex = 59;
            this.lblPurchaseName.Text = "仕入先名";
            this.lblPurchaseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPurchaseCode
            // 
            this.lblPurchaseCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPurchaseCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPurchaseCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPurchaseCode.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseCode.Location = new System.Drawing.Point(150, 119);
            this.lblPurchaseCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchaseCode.Name = "lblPurchaseCode";
            this.lblPurchaseCode.Size = new System.Drawing.Size(130, 27);
            this.lblPurchaseCode.TabIndex = 58;
            this.lblPurchaseCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblPurchaseCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPaymentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPaymentDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.White;
            this.lblPaymentDate.Location = new System.Drawing.Point(411, 91);
            this.lblPaymentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(130, 27);
            this.lblPaymentDate.TabIndex = 56;
            this.lblPaymentDate.Text = "支払日";
            this.lblPaymentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.lblTotal);
            this.pnlBody.Controls.Add(this.txtTotal);
            this.pnlBody.Controls.Add(this.lblOffset);
            this.pnlBody.Controls.Add(this.txtOffset);
            this.pnlBody.Controls.Add(this.lblCash);
            this.pnlBody.Controls.Add(this.txtCash);
            this.pnlBody.Controls.Add(this.lblBills);
            this.pnlBody.Controls.Add(this.txtBills);
            this.pnlBody.Controls.Add(this.lblTransfer);
            this.pnlBody.Controls.Add(this.txtTransfer);
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 190);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.MinimumSize = new System.Drawing.Size(4, 100);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(973, 192);
            this.pnlBody.TabIndex = 141;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(150, 141);
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
            this.lblOffset.Location = new System.Drawing.Point(150, 104);
            this.lblOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(130, 27);
            this.lblOffset.TabIndex = 12;
            this.lblOffset.Text = "相殺";
            this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCash
            // 
            this.lblCash.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCash.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCash.ForeColor = System.Drawing.Color.White;
            this.lblCash.Location = new System.Drawing.Point(150, 20);
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
            this.lblBills.Location = new System.Drawing.Point(150, 48);
            this.lblBills.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBills.Name = "lblBills";
            this.lblBills.Size = new System.Drawing.Size(130, 27);
            this.lblBills.TabIndex = 6;
            this.lblBills.Text = "手形";
            this.lblBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransfer
            // 
            this.lblTransfer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTransfer.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTransfer.ForeColor = System.Drawing.Color.White;
            this.lblTransfer.Location = new System.Drawing.Point(150, 76);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 383);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(973, 70);
            this.pnlBottom.TabIndex = 201;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(849, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 251;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShiharaiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(973, 454);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmShiharaiInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "支払入力";
            this.Load += new System.EventHandler(this.frmShiharaiInput_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPaymentDate.ResumeLayout(false);
            this.pnlPaymentDate.PerformLayout();
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.ItemHeadLabel lblPaymentNo;
        private Common.CustomTextBox txtPaymentNo;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomTextBox txtPurchaseCode;
        private Common.CustomTextBox txtPurchaseName;
        private Common.ItemHeadLabel lblTotal;
        private Common.CustomTextBox txtTotal;
        private Common.ItemHeadLabel lblOffset;
        private Common.CustomTextBox txtOffset;
        private Common.ItemHeadLabel lblCash;
        private Common.CustomTextBox txtCash;
        private Common.ItemHeadLabel lblBills;
        private Common.CustomTextBox txtBills;
        private Common.ItemHeadLabel lblTransfer;
        private Common.CustomTextBox txtTransfer;
        private Common.ItemHeadLabel lblPurchaseName;
        private Common.ItemHeadLabel lblPurchaseCode;
        private Common.ItemHeadLabel lblPaymentDate;
        private System.Windows.Forms.Panel pnlProcessingMode;
        private System.Windows.Forms.RadioButton rdoDelete;
        private Common.ItemHeadLabel lblProcessingMode;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private Common.FeaturesButton btnClose;
        private System.Windows.Forms.Panel pnlPaymentDate;
        private System.Windows.Forms.Label lblPaymentDateDays;
        private Common.CustomTextBox txtPaymentDateDays;
        private Common.CustomTextBox txtPaymentDateMonth;
        private Common.CustomTextBox txtPaymentDateYears;
        private System.Windows.Forms.Label lblPaymentDateMonth;
        private System.Windows.Forms.Label lblPaymentDateYears;
        private Common.CustomDateTimePicker dtpPaymentDate;
        private Common.CustomTextBox txtAddress1;
        private Common.CustomTextBox txtAddress2;
        private Common.CustomTextBox txtZipCode;
        private System.Windows.Forms.Label lblTitle;
    }
}