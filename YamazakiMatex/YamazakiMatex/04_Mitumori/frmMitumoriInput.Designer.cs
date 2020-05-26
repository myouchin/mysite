namespace Mitumori
{
    partial class frmEstimateInput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCustomerCd = new Common.ItemHeadLabel();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtSubject1 = new Common.CustomTextBox();
            this.txtSubject2 = new Common.CustomTextBox();
            this.txtTradingConditions = new Common.CustomTextBox();
            this.txtExpirationDateDays = new Common.CustomTextBox();
            this.txtDeliveryPlace1 = new Common.CustomTextBox();
            this.grdEstimateDetails = new Common.CustomDataGridView();
            this.clmRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRowStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTaxDispType = new Common.CustomComboBox();
            this.txtDelivery = new Common.CustomTextBox();
            this.lblExpirationDate = new Common.ItemHeadLabel();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.cmbOffices = new Common.CustomComboBox();
            this.txtCustomerPersonnel = new Common.CustomTextBox();
            this.txtOfficesNameOption = new Common.CustomTextBox();
            this.cmbPersonnel = new Common.CustomComboBox();
            this.cmbEstimateType = new Common.CustomComboBox();
            this.txtEstimateDateDays = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerNameOption = new Common.CustomTextBox();
            this.lblEstimateDate = new Common.ItemHeadLabel();
            this.txtEstimateDateMonth = new Common.CustomTextBox();
            this.txtEstimateDateYears = new Common.CustomTextBox();
            this.txtEstimateNo = new Common.CustomTextBox();
            this.lblEstimateNo = new Common.ItemHeadLabel();
            this.lblCustomerKanaName = new Common.ItemHeadLabel();
            this.lblDelivery = new Common.ItemHeadLabel();
            this.lblCustomerName = new Common.ItemHeadLabel();
            this.lblSubject = new Common.ItemHeadLabel();
            this.lblTradingConditions = new Common.ItemHeadLabel();
            this.lblDeliveryPlace = new Common.ItemHeadLabel();
            this.lblEstimateType = new Common.ItemHeadLabel();
            this.btnPrint = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.btnDeleteRow = new Common.FeaturesButton();
            this.btnInsertRow = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCopyRow = new Common.FeaturesButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPasteRow = new Common.FeaturesButton();
            this.lblTaxDispType = new Common.ItemHeadLabel();
            this.txtOrdersDocumentNo = new Common.CustomTextBox();
            this.lblOffices = new Common.ItemHeadLabel();
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.lblProcessingMode = new Common.ItemHeadLabel();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.pnlEstimateDate = new System.Windows.Forms.Panel();
            this.lblEstimateDays = new System.Windows.Forms.Label();
            this.lblEstimateMonth = new System.Windows.Forms.Label();
            this.lblEstimateYears = new System.Windows.Forms.Label();
            this.dtpEstimateDate = new Common.CustomDateTimePicker();
            this.lblPersonnel = new Common.ItemHeadLabel();
            this.lblCustomerPersonnel = new Common.ItemHeadLabel();
            this.pnlExpirationDate = new System.Windows.Forms.Panel();
            this.lblExpirationDateDays = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblUnderLine = new System.Windows.Forms.Label();
            this.lblEstimateTotalAmount = new System.Windows.Forms.Label();
            this.lblEstimateTotalAmountTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnOrdersSearch = new Common.FeaturesButton();
            this.rptMitumorisho1 = new YamazakiMatex.Print.Report.rptMitumorisho();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstimateDetails)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlProcessingMode.SuspendLayout();
            this.pnlEstimateDate.SuspendLayout();
            this.pnlExpirationDate.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustomerCd
            // 
            this.lblCustomerCd.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCd.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCd.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCd.Location = new System.Drawing.Point(4, 123);
            this.lblCustomerCd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerCd.Name = "lblCustomerCd";
            this.lblCustomerCd.Size = new System.Drawing.Size(130, 24);
            this.lblCustomerCd.TabIndex = 0;
            this.lblCustomerCd.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.txtSubject1;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = this.lblCustomerCd;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(4, 147);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 140;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtEstimateNo;
            // 
            // txtSubject1
            // 
            this.txtSubject1.BeforeValue = "";
            this.txtSubject1.DownControl = null;
            this.txtSubject1.EnterControl = this.txtSubject2;
            this.txtSubject1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject1.LabelControl = null;
            this.txtSubject1.LeftControl = null;
            this.txtSubject1.Location = new System.Drawing.Point(4, 199);
            this.txtSubject1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject1.Name = "txtSubject1";
            this.txtSubject1.RightControl = this.txtSubject2;
            this.txtSubject1.Size = new System.Drawing.Size(546, 27);
            this.txtSubject1.TabIndex = 180;
            this.txtSubject1.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０";
            this.txtSubject1.UpControl = this.txtCustomerCode;
            // 
            // txtSubject2
            // 
            this.txtSubject2.BeforeValue = "";
            this.txtSubject2.DownControl = this.txtTradingConditions;
            this.txtSubject2.EnterControl = this.cmbTaxDispType;
            this.txtSubject2.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject2.LabelControl = null;
            this.txtSubject2.LeftControl = this.txtSubject1;
            this.txtSubject2.Location = new System.Drawing.Point(549, 199);
            this.txtSubject2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject2.Name = "txtSubject2";
            this.txtSubject2.RightControl = null;
            this.txtSubject2.Size = new System.Drawing.Size(546, 27);
            this.txtSubject2.TabIndex = 190;
            this.txtSubject2.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０";
            this.txtSubject2.UpControl = this.txtCustomerKanaName;
            // 
            // txtTradingConditions
            // 
            this.txtTradingConditions.BeforeValue = "";
            this.txtTradingConditions.DownControl = null;
            this.txtTradingConditions.EnterControl = this.txtExpirationDateDays;
            this.txtTradingConditions.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTradingConditions.LabelControl = null;
            this.txtTradingConditions.LeftControl = this.txtDelivery;
            this.txtTradingConditions.Location = new System.Drawing.Point(550, 251);
            this.txtTradingConditions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTradingConditions.Name = "txtTradingConditions";
            this.txtTradingConditions.RightControl = this.txtExpirationDateDays;
            this.txtTradingConditions.Size = new System.Drawing.Size(380, 27);
            this.txtTradingConditions.TabIndex = 300;
            this.txtTradingConditions.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtTradingConditions.UpControl = this.txtSubject2;
            // 
            // txtExpirationDateDays
            // 
            this.txtExpirationDateDays.BeforeValue = "";
            this.txtExpirationDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpirationDateDays.DownControl = null;
            this.txtExpirationDateDays.EnterControl = this.txtDeliveryPlace1;
            this.txtExpirationDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtExpirationDateDays.LabelControl = this.lblExpirationDate;
            this.txtExpirationDateDays.LeftControl = this.txtTradingConditions;
            this.txtExpirationDateDays.Location = new System.Drawing.Point(8, 3);
            this.txtExpirationDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExpirationDateDays.Name = "txtExpirationDateDays";
            this.txtExpirationDateDays.RightControl = null;
            this.txtExpirationDateDays.Size = new System.Drawing.Size(117, 20);
            this.txtExpirationDateDays.TabIndex = 340;
            this.txtExpirationDateDays.Text = "60";
            this.txtExpirationDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpirationDateDays.UpControl = this.txtSubject2;
            // 
            // txtDeliveryPlace1
            // 
            this.txtDeliveryPlace1.BeforeValue = "";
            this.txtDeliveryPlace1.DownControl = this.grdEstimateDetails;
            this.txtDeliveryPlace1.EnterControl = this.grdEstimateDetails;
            this.txtDeliveryPlace1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDeliveryPlace1.LabelControl = null;
            this.txtDeliveryPlace1.LeftControl = null;
            this.txtDeliveryPlace1.Location = new System.Drawing.Point(4, 303);
            this.txtDeliveryPlace1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryPlace1.Name = "txtDeliveryPlace1";
            this.txtDeliveryPlace1.RightControl = null;
            this.txtDeliveryPlace1.Size = new System.Drawing.Size(547, 27);
            this.txtDeliveryPlace1.TabIndex = 360;
            this.txtDeliveryPlace1.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０";
            this.txtDeliveryPlace1.UpControl = this.cmbTaxDispType;
            // 
            // grdEstimateDetails
            // 
            this.grdEstimateDetails.AllowUserToAddRows = false;
            this.grdEstimateDetails.AllowUserToDeleteRows = false;
            this.grdEstimateDetails.AllowUserToResizeColumns = false;
            this.grdEstimateDetails.AllowUserToResizeRows = false;
            this.grdEstimateDetails.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEstimateDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstimateDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstimateDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRowNo,
            this.clmItemCode,
            this.clmItemName,
            this.clmQuantity,
            this.clmUnit,
            this.clmBid,
            this.clmAmount,
            this.clmRowStatus});
            this.grdEstimateDetails.DownControl = null;
            this.grdEstimateDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdEstimateDetails.EnableHeadersVisualStyles = false;
            this.grdEstimateDetails.EnterControl = null;
            this.grdEstimateDetails.FlgSetCurrentCell = true;
            this.grdEstimateDetails.LeftControl = null;
            this.grdEstimateDetails.Location = new System.Drawing.Point(3, 5);
            this.grdEstimateDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdEstimateDetails.MultiSelect = false;
            this.grdEstimateDetails.Name = "grdEstimateDetails";
            this.grdEstimateDetails.RightControl = null;
            this.grdEstimateDetails.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdEstimateDetails.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdEstimateDetails.RowSegmentCount = 2;
            this.grdEstimateDetails.RowTemplate.Height = 26;
            this.grdEstimateDetails.ScrollRowCount = 2;
            this.grdEstimateDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdEstimateDetails.Size = new System.Drawing.Size(1238, 287);
            this.grdEstimateDetails.TabIndex = 440;
            this.grdEstimateDetails.UpControl = this.txtDeliveryPlace1;
            this.grdEstimateDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEstimateDetails_CellEndEdit);
            this.grdEstimateDetails.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdEstimateDetails_CellPainting);
            this.grdEstimateDetails.CurrentCellChanged += new System.EventHandler(this.grdEstimateDetails_CurrentCellChanged);
            this.grdEstimateDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdEstimateDetails_EditingControlShowing);
            // 
            // clmRowNo
            // 
            this.clmRowNo.DataPropertyName = "No";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.clmRowNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmRowNo.HeaderText = "NO．";
            this.clmRowNo.Name = "clmRowNo";
            this.clmRowNo.ReadOnly = true;
            this.clmRowNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmRowNo.Width = 60;
            // 
            // clmItemCode
            // 
            this.clmItemCode.DataPropertyName = "ItemCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.clmItemCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmItemCode.HeaderText = "商品ｺｰﾄﾞ";
            this.clmItemCode.Name = "clmItemCode";
            this.clmItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmItemName
            // 
            this.clmItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.clmItemName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmItemName.HeaderText = "商品名";
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmItemName.Width = 551;
            // 
            // clmQuantity
            // 
            this.clmQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.clmQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmQuantity.HeaderText = "数量";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmQuantity.Width = 146;
            // 
            // clmUnit
            // 
            this.clmUnit.DataPropertyName = "Unit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmUnit.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clmUnit.DisplayStyleForCurrentCellOnly = true;
            this.clmUnit.HeaderText = "単位";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.Width = 69;
            // 
            // clmBid
            // 
            this.clmBid.DataPropertyName = "Rate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.clmBid.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmBid.HeaderText = "単価";
            this.clmBid.Name = "clmBid";
            this.clmBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBid.Width = 146;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmAmount.HeaderText = "金額";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmAmount.Width = 146;
            // 
            // clmRowStatus
            // 
            this.clmRowStatus.HeaderText = "エラー状態";
            this.clmRowStatus.Name = "clmRowStatus";
            this.clmRowStatus.ReadOnly = true;
            this.clmRowStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmRowStatus.Visible = false;
            // 
            // cmbTaxDispType
            // 
            this.cmbTaxDispType.BeforeSelectedValue = "";
            this.cmbTaxDispType.DownControl = this.txtDeliveryPlace1;
            this.cmbTaxDispType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxDispType.EnterControl = this.txtDelivery;
            this.cmbTaxDispType.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbTaxDispType.FormattingEnabled = true;
            this.cmbTaxDispType.LabelControl = null;
            this.cmbTaxDispType.LeftControl = null;
            this.cmbTaxDispType.Location = new System.Drawing.Point(3, 251);
            this.cmbTaxDispType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTaxDispType.Name = "cmbTaxDispType";
            this.cmbTaxDispType.RightControl = this.txtDelivery;
            this.cmbTaxDispType.Size = new System.Drawing.Size(275, 27);
            this.cmbTaxDispType.TabIndex = 200;
            this.cmbTaxDispType.UpControl = this.txtSubject1;
            // 
            // txtDelivery
            // 
            this.txtDelivery.BeforeValue = "";
            this.txtDelivery.DownControl = this.txtDeliveryPlace1;
            this.txtDelivery.EnterControl = this.txtTradingConditions;
            this.txtDelivery.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDelivery.LabelControl = null;
            this.txtDelivery.LeftControl = this.cmbTaxDispType;
            this.txtDelivery.Location = new System.Drawing.Point(277, 251);
            this.txtDelivery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.RightControl = this.txtTradingConditions;
            this.txtDelivery.Size = new System.Drawing.Size(274, 27);
            this.txtDelivery.TabIndex = 377;
            this.txtDelivery.UpControl = this.txtSubject1;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExpirationDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblExpirationDate.ForeColor = System.Drawing.Color.White;
            this.lblExpirationDate.Location = new System.Drawing.Point(929, 227);
            this.lblExpirationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(166, 24);
            this.lblExpirationDate.TabIndex = 0;
            this.lblExpirationDate.Text = "有効期限";
            this.lblExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.txtSubject1;
            this.txtCustomerKanaName.EnterControl = this.cmbOffices;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = this.lblCustomerKanaName;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerNameOption;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(421, 147);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = this.cmbOffices;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(390, 27);
            this.txtCustomerKanaName.TabIndex = 160;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = this.cmbEstimateType;
            // 
            // cmbOffices
            // 
            this.cmbOffices.BeforeSelectedValue = "";
            this.cmbOffices.DownControl = this.txtSubject2;
            this.cmbOffices.EnterControl = this.txtCustomerPersonnel;
            this.cmbOffices.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.LabelControl = null;
            this.cmbOffices.LeftControl = this.cmbOffices;
            this.cmbOffices.Location = new System.Drawing.Point(810, 147);
            this.cmbOffices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.RightControl = this.txtCustomerPersonnel;
            this.cmbOffices.Size = new System.Drawing.Size(146, 27);
            this.cmbOffices.TabIndex = 161;
            this.cmbOffices.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbOffices.UpControl = this.cmbPersonnel;
            // 
            // txtCustomerPersonnel
            // 
            this.txtCustomerPersonnel.BeforeValue = "";
            this.txtCustomerPersonnel.DownControl = this.txtSubject2;
            this.txtCustomerPersonnel.EnterControl = this.txtOfficesNameOption;
            this.txtCustomerPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerPersonnel.LabelControl = null;
            this.txtCustomerPersonnel.LeftControl = this.cmbOffices;
            this.txtCustomerPersonnel.Location = new System.Drawing.Point(955, 147);
            this.txtCustomerPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerPersonnel.Name = "txtCustomerPersonnel";
            this.txtCustomerPersonnel.RightControl = this.txtOfficesNameOption;
            this.txtCustomerPersonnel.Size = new System.Drawing.Size(213, 27);
            this.txtCustomerPersonnel.TabIndex = 170;
            this.txtCustomerPersonnel.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerPersonnel.UpControl = this.cmbPersonnel;
            // 
            // txtOfficesNameOption
            // 
            this.txtOfficesNameOption.BeforeValue = "";
            this.txtOfficesNameOption.DownControl = this.txtSubject1;
            this.txtOfficesNameOption.EnterControl = this.txtSubject1;
            this.txtOfficesNameOption.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOfficesNameOption.LabelControl = null;
            this.txtOfficesNameOption.LeftControl = this.txtCustomerPersonnel;
            this.txtOfficesNameOption.Location = new System.Drawing.Point(1167, 147);
            this.txtOfficesNameOption.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOfficesNameOption.Name = "txtOfficesNameOption";
            this.txtOfficesNameOption.RightControl = this.txtSubject1;
            this.txtOfficesNameOption.Size = new System.Drawing.Size(74, 27);
            this.txtOfficesNameOption.TabIndex = 162;
            this.txtOfficesNameOption.Text = "令令令";
            this.txtOfficesNameOption.UpControl = this.cmbPersonnel;
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.BeforeSelectedValue = "";
            this.cmbPersonnel.DownControl = this.txtCustomerKanaName;
            this.cmbPersonnel.EnterControl = this.txtCustomerCode;
            this.cmbPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.LabelControl = null;
            this.cmbPersonnel.LeftControl = this.cmbEstimateType;
            this.cmbPersonnel.Location = new System.Drawing.Point(506, 95);
            this.cmbPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.RightControl = null;
            this.cmbPersonnel.Size = new System.Drawing.Size(146, 27);
            this.cmbPersonnel.TabIndex = 130;
            this.cmbPersonnel.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPersonnel.UpControl = null;
            // 
            // cmbEstimateType
            // 
            this.cmbEstimateType.BeforeSelectedValue = "";
            this.cmbEstimateType.DownControl = this.txtCustomerKanaName;
            this.cmbEstimateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstimateType.EnterControl = this.cmbPersonnel;
            this.cmbEstimateType.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbEstimateType.FormattingEnabled = true;
            this.cmbEstimateType.LabelControl = null;
            this.cmbEstimateType.LeftControl = this.txtEstimateDateDays;
            this.cmbEstimateType.Location = new System.Drawing.Point(374, 95);
            this.cmbEstimateType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEstimateType.Name = "cmbEstimateType";
            this.cmbEstimateType.RightControl = this.cmbPersonnel;
            this.cmbEstimateType.Size = new System.Drawing.Size(133, 27);
            this.cmbEstimateType.TabIndex = 120;
            this.cmbEstimateType.UpControl = null;
            // 
            // txtEstimateDateDays
            // 
            this.txtEstimateDateDays.BeforeValue = "";
            this.txtEstimateDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateDays.DownControl = this.txtCustomerName;
            this.txtEstimateDateDays.EnterControl = this.cmbEstimateType;
            this.txtEstimateDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateDays.LabelControl = this.lblEstimateDate;
            this.txtEstimateDateDays.LeftControl = this.txtEstimateDateMonth;
            this.txtEstimateDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtEstimateDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateDays.Name = "txtEstimateDateDays";
            this.txtEstimateDateDays.RightControl = this.cmbEstimateType;
            this.txtEstimateDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtEstimateDateDays.TabIndex = 100;
            this.txtEstimateDateDays.Text = "12";
            this.txtEstimateDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateDays.UpControl = null;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.txtSubject1;
            this.txtCustomerName.EnterControl = this.txtCustomerNameOption;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(133, 147);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerNameOption;
            this.txtCustomerName.Size = new System.Drawing.Size(216, 27);
            this.txtCustomerName.TabIndex = 150;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = null;
            // 
            // txtCustomerNameOption
            // 
            this.txtCustomerNameOption.BeforeValue = "";
            this.txtCustomerNameOption.DownControl = this.txtSubject1;
            this.txtCustomerNameOption.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerNameOption.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerNameOption.LabelControl = null;
            this.txtCustomerNameOption.LeftControl = this.txtCustomerName;
            this.txtCustomerNameOption.Location = new System.Drawing.Point(348, 147);
            this.txtCustomerNameOption.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerNameOption.Name = "txtCustomerNameOption";
            this.txtCustomerNameOption.RightControl = this.txtCustomerKanaName;
            this.txtCustomerNameOption.Size = new System.Drawing.Size(74, 27);
            this.txtCustomerNameOption.TabIndex = 151;
            this.txtCustomerNameOption.Text = "令令令";
            this.txtCustomerNameOption.UpControl = null;
            // 
            // lblEstimateDate
            // 
            this.lblEstimateDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEstimateDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstimateDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateDate.ForeColor = System.Drawing.Color.White;
            this.lblEstimateDate.Location = new System.Drawing.Point(133, 71);
            this.lblEstimateDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstimateDate.Name = "lblEstimateDate";
            this.lblEstimateDate.Size = new System.Drawing.Size(242, 24);
            this.lblEstimateDate.TabIndex = 0;
            this.lblEstimateDate.Text = "見積日付";
            this.lblEstimateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEstimateDateMonth
            // 
            this.txtEstimateDateMonth.BeforeValue = "";
            this.txtEstimateDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateMonth.DownControl = this.txtCustomerName;
            this.txtEstimateDateMonth.EnterControl = this.txtEstimateDateDays;
            this.txtEstimateDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateMonth.LabelControl = this.lblEstimateDate;
            this.txtEstimateDateMonth.LeftControl = this.txtEstimateDateYears;
            this.txtEstimateDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtEstimateDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateMonth.Name = "txtEstimateDateMonth";
            this.txtEstimateDateMonth.RightControl = this.txtEstimateDateDays;
            this.txtEstimateDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtEstimateDateMonth.TabIndex = 90;
            this.txtEstimateDateMonth.Text = "12";
            this.txtEstimateDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateMonth.UpControl = null;
            // 
            // txtEstimateDateYears
            // 
            this.txtEstimateDateYears.BeforeValue = "";
            this.txtEstimateDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateYears.DownControl = this.txtCustomerName;
            this.txtEstimateDateYears.EnterControl = this.txtEstimateDateMonth;
            this.txtEstimateDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateYears.LabelControl = this.lblEstimateDate;
            this.txtEstimateDateYears.LeftControl = this.txtEstimateNo;
            this.txtEstimateDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtEstimateDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateYears.Name = "txtEstimateDateYears";
            this.txtEstimateDateYears.RightControl = this.txtEstimateDateMonth;
            this.txtEstimateDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtEstimateDateYears.TabIndex = 80;
            this.txtEstimateDateYears.Text = "1234";
            this.txtEstimateDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateYears.UpControl = null;
            // 
            // txtEstimateNo
            // 
            this.txtEstimateNo.BeforeValue = "";
            this.txtEstimateNo.DownControl = this.txtCustomerCode;
            this.txtEstimateNo.EnterControl = this.txtEstimateDateYears;
            this.txtEstimateNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateNo.LabelControl = this.lblEstimateNo;
            this.txtEstimateNo.LeftControl = null;
            this.txtEstimateNo.Location = new System.Drawing.Point(4, 95);
            this.txtEstimateNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateNo.Name = "txtEstimateNo";
            this.txtEstimateNo.RightControl = this.txtEstimateDateYears;
            this.txtEstimateNo.Size = new System.Drawing.Size(130, 27);
            this.txtEstimateNo.TabIndex = 60;
            this.txtEstimateNo.Text = "XXXXXXX8";
            this.txtEstimateNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateNo.UpControl = null;
            // 
            // lblEstimateNo
            // 
            this.lblEstimateNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEstimateNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstimateNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateNo.ForeColor = System.Drawing.Color.White;
            this.lblEstimateNo.Location = new System.Drawing.Point(5, 71);
            this.lblEstimateNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstimateNo.Name = "lblEstimateNo";
            this.lblEstimateNo.Size = new System.Drawing.Size(130, 24);
            this.lblEstimateNo.TabIndex = 0;
            this.lblEstimateNo.Text = "見積NO";
            this.lblEstimateNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerKanaName
            // 
            this.lblCustomerKanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerKanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerKanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerKanaName.Location = new System.Drawing.Point(422, 123);
            this.lblCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerKanaName.Name = "lblCustomerKanaName";
            this.lblCustomerKanaName.Size = new System.Drawing.Size(389, 24);
            this.lblCustomerKanaName.TabIndex = 112;
            this.lblCustomerKanaName.Text = "得意先カナ名";
            this.lblCustomerKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDelivery
            // 
            this.lblDelivery.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDelivery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDelivery.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDelivery.ForeColor = System.Drawing.Color.White;
            this.lblDelivery.Location = new System.Drawing.Point(277, 227);
            this.lblDelivery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(274, 24);
            this.lblDelivery.TabIndex = 0;
            this.lblDelivery.Text = "納期";
            this.lblDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(133, 123);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(289, 24);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "得意先名";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubject.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(4, 175);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(1091, 24);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "件名";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTradingConditions
            // 
            this.lblTradingConditions.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTradingConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTradingConditions.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTradingConditions.ForeColor = System.Drawing.Color.White;
            this.lblTradingConditions.Location = new System.Drawing.Point(551, 227);
            this.lblTradingConditions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTradingConditions.Name = "lblTradingConditions";
            this.lblTradingConditions.Size = new System.Drawing.Size(379, 24);
            this.lblTradingConditions.TabIndex = 0;
            this.lblTradingConditions.Text = "取引条件";
            this.lblTradingConditions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeliveryPlace
            // 
            this.lblDeliveryPlace.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDeliveryPlace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeliveryPlace.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDeliveryPlace.ForeColor = System.Drawing.Color.White;
            this.lblDeliveryPlace.Location = new System.Drawing.Point(4, 279);
            this.lblDeliveryPlace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeliveryPlace.Name = "lblDeliveryPlace";
            this.lblDeliveryPlace.Size = new System.Drawing.Size(547, 24);
            this.lblDeliveryPlace.TabIndex = 0;
            this.lblDeliveryPlace.Text = "受渡場所";
            this.lblDeliveryPlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateType
            // 
            this.lblEstimateType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEstimateType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstimateType.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateType.ForeColor = System.Drawing.Color.White;
            this.lblEstimateType.Location = new System.Drawing.Point(374, 71);
            this.lblEstimateType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstimateType.Name = "lblEstimateType";
            this.lblEstimateType.Size = new System.Drawing.Size(133, 24);
            this.lblEstimateType.TabIndex = 0;
            this.lblEstimateType.Text = "見積区分";
            this.lblEstimateType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(266, 9);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 40);
            this.btnPrint.TabIndex = 470;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 460;
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
            this.btnSave.Location = new System.Drawing.Point(897, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 40);
            this.btnSave.TabIndex = 480;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(1011, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 490;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(1125, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDeleteRow.Location = new System.Drawing.Point(1147, 296);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(94, 40);
            this.btnDeleteRow.TabIndex = 430;
            this.btnDeleteRow.TabStop = false;
            this.btnDeleteRow.Text = "行削除";
            this.btnDeleteRow.UseVisualStyleBackColor = false;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnInsertRow
            // 
            this.btnInsertRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInsertRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnInsertRow.Location = new System.Drawing.Point(1051, 296);
            this.btnInsertRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInsertRow.Name = "btnInsertRow";
            this.btnInsertRow.Size = new System.Drawing.Size(94, 40);
            this.btnInsertRow.TabIndex = 420;
            this.btnInsertRow.TabStop = false;
            this.btnInsertRow.Text = "行挿入";
            this.btnInsertRow.UseVisualStyleBackColor = false;
            this.btnInsertRow.Click += new System.EventHandler(this.btnInsertRow_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.txtDelivery);
            this.pnlHeader.Controls.Add(this.btnCopyRow);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnPasteRow);
            this.pnlHeader.Controls.Add(this.txtOfficesNameOption);
            this.pnlHeader.Controls.Add(this.txtCustomerNameOption);
            this.pnlHeader.Controls.Add(this.lblTaxDispType);
            this.pnlHeader.Controls.Add(this.btnDeleteRow);
            this.pnlHeader.Controls.Add(this.btnInsertRow);
            this.pnlHeader.Controls.Add(this.cmbTaxDispType);
            this.pnlHeader.Controls.Add(this.txtOrdersDocumentNo);
            this.pnlHeader.Controls.Add(this.lblOffices);
            this.pnlHeader.Controls.Add(this.cmbOffices);
            this.pnlHeader.Controls.Add(this.pnlProcessingMode);
            this.pnlHeader.Controls.Add(this.lblEstimateNo);
            this.pnlHeader.Controls.Add(this.txtEstimateNo);
            this.pnlHeader.Controls.Add(this.lblEstimateDate);
            this.pnlHeader.Controls.Add(this.pnlEstimateDate);
            this.pnlHeader.Controls.Add(this.lblEstimateType);
            this.pnlHeader.Controls.Add(this.cmbEstimateType);
            this.pnlHeader.Controls.Add(this.lblPersonnel);
            this.pnlHeader.Controls.Add(this.cmbPersonnel);
            this.pnlHeader.Controls.Add(this.lblCustomerCd);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.lblCustomerPersonnel);
            this.pnlHeader.Controls.Add(this.txtCustomerPersonnel);
            this.pnlHeader.Controls.Add(this.lblSubject);
            this.pnlHeader.Controls.Add(this.txtSubject1);
            this.pnlHeader.Controls.Add(this.txtSubject2);
            this.pnlHeader.Controls.Add(this.lblDelivery);
            this.pnlHeader.Controls.Add(this.lblTradingConditions);
            this.pnlHeader.Controls.Add(this.txtTradingConditions);
            this.pnlHeader.Controls.Add(this.lblExpirationDate);
            this.pnlHeader.Controls.Add(this.pnlExpirationDate);
            this.pnlHeader.Controls.Add(this.lblDeliveryPlace);
            this.pnlHeader.Controls.Add(this.txtDeliveryPlace1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1250, 345);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnCopyRow
            // 
            this.btnCopyRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCopyRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopyRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopyRow.Location = new System.Drawing.Point(859, 296);
            this.btnCopyRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopyRow.Name = "btnCopyRow";
            this.btnCopyRow.Size = new System.Drawing.Size(94, 40);
            this.btnCopyRow.TabIndex = 390;
            this.btnCopyRow.TabStop = false;
            this.btnCopyRow.Text = "行複写";
            this.btnCopyRow.UseVisualStyleBackColor = false;
            this.btnCopyRow.Click += new System.EventHandler(this.btnCopyRow_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.Location = new System.Drawing.Point(544, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 42);
            this.lblTitle.TabIndex = 376;
            this.lblTitle.Text = "見積書";
            // 
            // btnPasteRow
            // 
            this.btnPasteRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPasteRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPasteRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPasteRow.Location = new System.Drawing.Point(955, 296);
            this.btnPasteRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnPasteRow.Name = "btnPasteRow";
            this.btnPasteRow.Size = new System.Drawing.Size(94, 40);
            this.btnPasteRow.TabIndex = 400;
            this.btnPasteRow.TabStop = false;
            this.btnPasteRow.Text = "行貼付";
            this.btnPasteRow.UseVisualStyleBackColor = false;
            this.btnPasteRow.Click += new System.EventHandler(this.btnPasteRow_Click);
            // 
            // lblTaxDispType
            // 
            this.lblTaxDispType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTaxDispType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTaxDispType.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTaxDispType.ForeColor = System.Drawing.Color.White;
            this.lblTaxDispType.Location = new System.Drawing.Point(3, 227);
            this.lblTaxDispType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaxDispType.Name = "lblTaxDispType";
            this.lblTaxDispType.Size = new System.Drawing.Size(275, 24);
            this.lblTaxDispType.TabIndex = 375;
            this.lblTaxDispType.Text = "消費税出力区分";
            this.lblTaxDispType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrdersDocumentNo
            // 
            this.txtOrdersDocumentNo.BeforeValue = "";
            this.txtOrdersDocumentNo.DownControl = null;
            this.txtOrdersDocumentNo.EnterControl = null;
            this.txtOrdersDocumentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersDocumentNo.LabelControl = null;
            this.txtOrdersDocumentNo.LeftControl = null;
            this.txtOrdersDocumentNo.Location = new System.Drawing.Point(651, 95);
            this.txtOrdersDocumentNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersDocumentNo.Name = "txtOrdersDocumentNo";
            this.txtOrdersDocumentNo.RightControl = null;
            this.txtOrdersDocumentNo.Size = new System.Drawing.Size(130, 27);
            this.txtOrdersDocumentNo.TabIndex = 374;
            this.txtOrdersDocumentNo.Text = "XXXXXXX8";
            this.txtOrdersDocumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersDocumentNo.UpControl = null;
            this.txtOrdersDocumentNo.Visible = false;
            // 
            // lblOffices
            // 
            this.lblOffices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffices.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffices.ForeColor = System.Drawing.Color.White;
            this.lblOffices.Location = new System.Drawing.Point(811, 123);
            this.lblOffices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffices.Name = "lblOffices";
            this.lblOffices.Size = new System.Drawing.Size(145, 24);
            this.lblOffices.TabIndex = 372;
            this.lblOffices.Text = "事業所";
            this.lblOffices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.lblProcessingMode);
            this.pnlProcessingMode.Controls.Add(this.rdoNew);
            this.pnlProcessingMode.Controls.Add(this.rdoCorrection);
            this.pnlProcessingMode.Controls.Add(this.rdoReference);
            this.pnlProcessingMode.Controls.Add(this.rdoDelete);
            this.pnlProcessingMode.Location = new System.Drawing.Point(4, 3);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(345, 65);
            this.pnlProcessingMode.TabIndex = 10;
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
            // rdoNew
            // 
            this.rdoNew.AutoCheck = false;
            this.rdoNew.AutoSize = true;
            this.rdoNew.Checked = true;
            this.rdoNew.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(17, 32);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(69, 24);
            this.rdoNew.TabIndex = 20;
            this.rdoNew.Text = "新規";
            this.rdoNew.UseVisualStyleBackColor = true;
            this.rdoNew.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoCheck = false;
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(97, 32);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(69, 24);
            this.rdoCorrection.TabIndex = 30;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            this.rdoCorrection.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoReference
            // 
            this.rdoReference.AutoCheck = false;
            this.rdoReference.AutoSize = true;
            this.rdoReference.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoReference.Location = new System.Drawing.Point(177, 32);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(69, 24);
            this.rdoReference.TabIndex = 40;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            this.rdoReference.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoCheck = false;
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(257, 32);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(69, 24);
            this.rdoDelete.TabIndex = 50;
            this.rdoDelete.Text = "削除";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // pnlEstimateDate
            // 
            this.pnlEstimateDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlEstimateDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstimateDate.Controls.Add(this.lblEstimateDays);
            this.pnlEstimateDate.Controls.Add(this.txtEstimateDateDays);
            this.pnlEstimateDate.Controls.Add(this.lblEstimateMonth);
            this.pnlEstimateDate.Controls.Add(this.txtEstimateDateMonth);
            this.pnlEstimateDate.Controls.Add(this.lblEstimateYears);
            this.pnlEstimateDate.Controls.Add(this.txtEstimateDateYears);
            this.pnlEstimateDate.Controls.Add(this.dtpEstimateDate);
            this.pnlEstimateDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlEstimateDate.Location = new System.Drawing.Point(133, 95);
            this.pnlEstimateDate.Name = "pnlEstimateDate";
            this.pnlEstimateDate.Size = new System.Drawing.Size(242, 27);
            this.pnlEstimateDate.TabIndex = 70;
            // 
            // lblEstimateDays
            // 
            this.lblEstimateDays.Location = new System.Drawing.Point(170, 0);
            this.lblEstimateDays.Name = "lblEstimateDays";
            this.lblEstimateDays.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDays.TabIndex = 119;
            this.lblEstimateDays.Text = "日";
            this.lblEstimateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateMonth
            // 
            this.lblEstimateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblEstimateMonth.Name = "lblEstimateMonth";
            this.lblEstimateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateMonth.TabIndex = 117;
            this.lblEstimateMonth.Text = "月";
            this.lblEstimateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateYears
            // 
            this.lblEstimateYears.Location = new System.Drawing.Point(51, 0);
            this.lblEstimateYears.Name = "lblEstimateYears";
            this.lblEstimateYears.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateYears.TabIndex = 115;
            this.lblEstimateYears.Text = "年";
            this.lblEstimateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEstimateDate
            // 
            this.dtpEstimateDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpEstimateDate.CustomFormat = " ";
            this.dtpEstimateDate.DaysLinkTextControl = this.txtEstimateDateDays;
            this.dtpEstimateDate.DownControl = this.txtCustomerName;
            this.dtpEstimateDate.EnterControl = this.cmbEstimateType;
            this.dtpEstimateDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpEstimateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEstimateDate.LeftControl = this.txtEstimateDateDays;
            this.dtpEstimateDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpEstimateDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEstimateDate.MonthLinkTextControl = this.txtEstimateDateMonth;
            this.dtpEstimateDate.Name = "dtpEstimateDate";
            this.dtpEstimateDate.RightControl = this.cmbEstimateType;
            this.dtpEstimateDate.Size = new System.Drawing.Size(242, 27);
            this.dtpEstimateDate.TabIndex = 110;
            this.dtpEstimateDate.TabStop = false;
            this.dtpEstimateDate.UpControl = null;
            this.dtpEstimateDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpEstimateDate.Value2 = null;
            this.dtpEstimateDate.YearsLinkTextControl = this.txtEstimateDateYears;
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblPersonnel.Location = new System.Drawing.Point(507, 71);
            this.lblPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(145, 24);
            this.lblPersonnel.TabIndex = 110;
            this.lblPersonnel.Text = "担当者";
            this.lblPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerPersonnel
            // 
            this.lblCustomerPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblCustomerPersonnel.Location = new System.Drawing.Point(956, 123);
            this.lblCustomerPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPersonnel.Name = "lblCustomerPersonnel";
            this.lblCustomerPersonnel.Size = new System.Drawing.Size(285, 24);
            this.lblCustomerPersonnel.TabIndex = 122;
            this.lblCustomerPersonnel.Text = "得意先担当者名";
            this.lblCustomerPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExpirationDate
            // 
            this.pnlExpirationDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpirationDate.Controls.Add(this.lblExpirationDateDays);
            this.pnlExpirationDate.Controls.Add(this.txtExpirationDateDays);
            this.pnlExpirationDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlExpirationDate.Location = new System.Drawing.Point(929, 251);
            this.pnlExpirationDate.Name = "pnlExpirationDate";
            this.pnlExpirationDate.Size = new System.Drawing.Size(166, 27);
            this.pnlExpirationDate.TabIndex = 310;
            // 
            // lblExpirationDateDays
            // 
            this.lblExpirationDateDays.Location = new System.Drawing.Point(132, -1);
            this.lblExpirationDateDays.Name = "lblExpirationDateDays";
            this.lblExpirationDateDays.Size = new System.Drawing.Size(28, 27);
            this.lblExpirationDateDays.TabIndex = 119;
            this.lblExpirationDateDays.Text = "日";
            this.lblExpirationDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.lblUnderLine);
            this.pnlBody.Controls.Add(this.lblEstimateTotalAmount);
            this.pnlBody.Controls.Add(this.grdEstimateDetails);
            this.pnlBody.Controls.Add(this.lblEstimateTotalAmountTitle);
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 339);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1250, 340);
            this.pnlBody.TabIndex = 380;
            // 
            // lblUnderLine
            // 
            this.lblUnderLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnderLine.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUnderLine.Location = new System.Drawing.Point(945, 326);
            this.lblUnderLine.Name = "lblUnderLine";
            this.lblUnderLine.Size = new System.Drawing.Size(270, 1);
            this.lblUnderLine.TabIndex = 442;
            this.lblUnderLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstimateTotalAmount
            // 
            this.lblEstimateTotalAmount.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateTotalAmount.Location = new System.Drawing.Point(1093, 304);
            this.lblEstimateTotalAmount.Name = "lblEstimateTotalAmount";
            this.lblEstimateTotalAmount.Size = new System.Drawing.Size(125, 20);
            this.lblEstimateTotalAmount.TabIndex = 441;
            this.lblEstimateTotalAmount.Text = "100,000,000";
            this.lblEstimateTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstimateTotalAmountTitle
            // 
            this.lblEstimateTotalAmountTitle.AutoSize = true;
            this.lblEstimateTotalAmountTitle.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.lblEstimateTotalAmountTitle.Location = new System.Drawing.Point(941, 304);
            this.lblEstimateTotalAmountTitle.Name = "lblEstimateTotalAmountTitle";
            this.lblEstimateTotalAmountTitle.Size = new System.Drawing.Size(146, 20);
            this.lblEstimateTotalAmountTitle.TabIndex = 378;
            this.lblEstimateTotalAmountTitle.Text = "見積合計金額：";
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnPreview);
            this.pnlBottom.Controls.Add(this.btnOrdersSearch);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 678);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1249, 58);
            this.pnlBottom.TabIndex = 450;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(117, 9);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(141, 40);
            this.btnPreview.TabIndex = 502;
            this.btnPreview.Text = "F3：プレビュー";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnOrdersSearch
            // 
            this.btnOrdersSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOrdersSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOrdersSearch.Location = new System.Drawing.Point(380, 9);
            this.btnOrdersSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrdersSearch.Name = "btnOrdersSearch";
            this.btnOrdersSearch.Size = new System.Drawing.Size(146, 40);
            this.btnOrdersSearch.TabIndex = 501;
            this.btnOrdersSearch.Text = "F5：受注検索";
            this.btnOrdersSearch.UseVisualStyleBackColor = false;
            this.btnOrdersSearch.Click += new System.EventHandler(this.btnOrdersSearch_Click);
            // 
            // frmEstimateInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1250, 738);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEstimateInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "見積書作成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstimateInput_FormClosing);
            this.Load += new System.EventHandler(this.frmEstimateInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstimateDetails)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.pnlEstimateDate.ResumeLayout(false);
            this.pnlEstimateDate.PerformLayout();
            this.pnlExpirationDate.ResumeLayout(false);
            this.pnlExpirationDate.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.ItemHeadLabel lblCustomerCd;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private Common.ItemHeadLabel lblCustomerName;
        private Common.ItemHeadLabel lblEstimateNo;
        private Common.CustomTextBox txtEstimateNo;
        private Common.ItemHeadLabel lblSubject;
        private Common.CustomTextBox txtSubject1;
        private Common.CustomTextBox txtTradingConditions;
        private Common.ItemHeadLabel lblTradingConditions;
        private Common.ItemHeadLabel lblExpirationDate;
        private Common.ItemHeadLabel lblDeliveryPlace;
        private Common.ItemHeadLabel lblEstimateDate;
        private Common.ItemHeadLabel lblDelivery;
        private Common.ItemHeadLabel lblEstimateType;
        private Common.CustomComboBox cmbEstimateType;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnDeleteRow;
        private Common.FeaturesButton btnInsertRow;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdEstimateDetails;
        private Common.CustomTextBox txtDeliveryPlace1;
        private Common.CustomTextBox txtSubject2;
        private System.Windows.Forms.Panel pnlProcessingMode;
        private Common.ItemHeadLabel lblProcessingMode;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private System.Windows.Forms.RadioButton rdoDelete;
        private Common.FeaturesButton btnCopyRow;
        private Common.FeaturesButton btnPasteRow;
        private Common.CustomComboBox cmbPersonnel;
        private Common.ItemHeadLabel lblPersonnel;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.ItemHeadLabel lblCustomerKanaName;
        private System.Windows.Forms.Panel pnlEstimateDate;
        private Common.CustomDateTimePicker dtpEstimateDate;
        private System.Windows.Forms.Label lblEstimateDays;
        private Common.CustomTextBox txtEstimateDateDays;
        private System.Windows.Forms.Label lblEstimateMonth;
        private Common.CustomTextBox txtEstimateDateMonth;
        private System.Windows.Forms.Label lblEstimateYears;
        private Common.CustomTextBox txtEstimateDateYears;
        private Common.ItemHeadLabel lblOffices;
        private Common.CustomComboBox cmbOffices;
        private Common.CustomTextBox txtCustomerPersonnel;
        private Common.ItemHeadLabel lblCustomerPersonnel;
        private Common.FeaturesButton btnOrdersSearch;
        private Common.CustomTextBox txtOrdersDocumentNo;
        private System.Windows.Forms.Panel pnlExpirationDate;
        private System.Windows.Forms.Label lblExpirationDateDays;
        private Common.CustomTextBox txtExpirationDateDays;
        private Common.ItemHeadLabel lblTaxDispType;
        private Common.CustomComboBox cmbTaxDispType;
        private Common.FeaturesButton btnPreview;
        private YamazakiMatex.Print.Report.rptMitumorisho rptMitumorisho1;
        private Common.CustomTextBox txtCustomerNameOption;
        private Common.CustomTextBox txtOfficesNameOption;
        private System.Windows.Forms.Label lblTitle;
        private Common.CustomTextBox txtDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRowStatus;
        private System.Windows.Forms.Label lblEstimateTotalAmountTitle;
        private System.Windows.Forms.Label lblEstimateTotalAmount;
        private System.Windows.Forms.Label lblUnderLine;
    }
}