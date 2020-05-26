namespace SubForm
{
    partial class sfrmShireSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtOrdersNoFromTop = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.grdSearchList = new System.Windows.Forms.DataGridView();
            this.clmPurchaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrdersNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOfficesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.txtOrdersNoToTop = new Common.CustomTextBox();
            this.txtOrdersNoToMid = new Common.CustomTextBox();
            this.txtOrdersNoToBtm = new Common.CustomTextBox();
            this.txtDocumentNoTo = new Common.CustomTextBox();
            this.txtDocumentDateFromYears = new Common.CustomTextBox();
            this.txtDocumentDateFromMonth = new Common.CustomTextBox();
            this.txtDocumentDateFromDays = new Common.CustomTextBox();
            this.txtDocumentDateToYears = new Common.CustomTextBox();
            this.txtDocumentDateToMonth = new Common.CustomTextBox();
            this.txtDocumentDateToDays = new Common.CustomTextBox();
            this.txtDocumentNoFrom = new Common.CustomTextBox();
            this.txtOrdersNoFromBtm = new Common.CustomTextBox();
            this.txtOrdersNoFromMid = new Common.CustomTextBox();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.rdoAsc = new System.Windows.Forms.RadioButton();
            this.rdoDesc = new System.Windows.Forms.RadioButton();
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
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblDocumentNo = new Common.ItemHeadLabel();
            this.lblCustomerCanaName = new Common.ItemHeadLabel();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblCustomerCharactersName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.lblFromToSeparated3 = new System.Windows.Forms.Label();
            this.lblDocumentDate = new Common.ItemHeadLabel();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.lblOrdersNo = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.btnSelectCancel = new Common.FeaturesButton();
            this.btnAllSelect = new Common.FeaturesButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlDocumentDateTo.SuspendLayout();
            this.pnlDocumentDateFrom.SuspendLayout();
            this.pnlRowSelectMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOrdersNoFromTop
            // 
            this.txtOrdersNoFromTop.BeforeValue = "";
            this.txtOrdersNoFromTop.DownControl = this.txtCustomerCode;
            this.txtOrdersNoFromTop.EnterControl = this.txtOrdersNoFromMid;
            this.txtOrdersNoFromTop.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNoFromTop.LabelControl = null;
            this.txtOrdersNoFromTop.LeftControl = null;
            this.txtOrdersNoFromTop.Location = new System.Drawing.Point(133, 103);
            this.txtOrdersNoFromTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNoFromTop.MaxLength = 3;
            this.txtOrdersNoFromTop.Name = "txtOrdersNoFromTop";
            this.txtOrdersNoFromTop.RightControl = this.txtOrdersNoFromMid;
            this.txtOrdersNoFromTop.Size = new System.Drawing.Size(64, 27);
            this.txtOrdersNoFromTop.TabIndex = 170;
            this.txtOrdersNoFromTop.Text = "XX3";
            this.txtOrdersNoFromTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNoFromTop.UpControl = this.txtDocumentNoFrom;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.grdSearchList;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(133, 131);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 5;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 230;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtOrdersNoFromTop;
            // 
            // grdSearchList
            // 
            this.grdSearchList.AllowUserToAddRows = false;
            this.grdSearchList.AllowUserToDeleteRows = false;
            this.grdSearchList.AllowUserToResizeRows = false;
            this.grdSearchList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSearchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPurchaseNo,
            this.clmPurchaseDate,
            this.clmOrdersNo,
            this.clmCustomerName,
            this.clmOfficesName,
            this.clmSubject});
            this.grdSearchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdSearchList.EnableHeadersVisualStyles = false;
            this.grdSearchList.Location = new System.Drawing.Point(3, 5);
            this.grdSearchList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSearchList.MultiSelect = false;
            this.grdSearchList.Name = "grdSearchList";
            this.grdSearchList.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(1123, 287);
            this.grdSearchList.TabIndex = 270;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmPurchaseNo
            // 
            this.clmPurchaseNo.DataPropertyName = "shireNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmPurchaseNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmPurchaseNo.HeaderText = "仕入NO";
            this.clmPurchaseNo.Name = "clmPurchaseNo";
            this.clmPurchaseNo.ReadOnly = true;
            this.clmPurchaseNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmPurchaseDate
            // 
            this.clmPurchaseDate.DataPropertyName = "denpyoHizuke";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.clmPurchaseDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmPurchaseDate.HeaderText = "仕入日付";
            this.clmPurchaseDate.Name = "clmPurchaseDate";
            this.clmPurchaseDate.ReadOnly = true;
            this.clmPurchaseDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPurchaseDate.Width = 160;
            // 
            // clmOrdersNo
            // 
            this.clmOrdersNo.DataPropertyName = "juchuNo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmOrdersNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmOrdersNo.HeaderText = "受注NO";
            this.clmOrdersNo.Name = "clmOrdersNo";
            this.clmOrdersNo.ReadOnly = true;
            this.clmOrdersNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOrdersNo.Width = 130;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.DataPropertyName = "tokuisakiName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmCustomerName.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmCustomerName.HeaderText = "得意先名";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerName.Width = 249;
            // 
            // clmOfficesName
            // 
            this.clmOfficesName.DataPropertyName = "jigyousyoName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmOfficesName.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmOfficesName.HeaderText = "事業所名";
            this.clmOfficesName.Name = "clmOfficesName";
            this.clmOfficesName.ReadOnly = true;
            this.clmOfficesName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOfficesName.Width = 150;
            // 
            // clmSubject
            // 
            this.clmSubject.DataPropertyName = "kenmei1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmSubject.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmSubject.HeaderText = "件名";
            this.clmSubject.Name = "clmSubject";
            this.clmSubject.ReadOnly = true;
            this.clmSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubject.Width = 313;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.grdSearchList;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(403, 131);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 40;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(210, 27);
            this.txtCustomerName.TabIndex = 240;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtOrdersNoToTop;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.grdSearchList;
            this.txtCustomerKanaName.EnterControl = this.grdSearchList;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(718, 131);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.MaxLength = 80;
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = null;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(408, 27);
            this.txtCustomerKanaName.TabIndex = 250;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = null;
            // 
            // txtOrdersNoToTop
            // 
            this.txtOrdersNoToTop.BeforeValue = "";
            this.txtOrdersNoToTop.DownControl = this.txtCustomerCode;
            this.txtOrdersNoToTop.EnterControl = this.txtOrdersNoToMid;
            this.txtOrdersNoToTop.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNoToTop.LabelControl = null;
            this.txtOrdersNoToTop.LeftControl = this.txtOrdersNoFromBtm;
            this.txtOrdersNoToTop.Location = new System.Drawing.Point(422, 103);
            this.txtOrdersNoToTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNoToTop.MaxLength = 3;
            this.txtOrdersNoToTop.Name = "txtOrdersNoToTop";
            this.txtOrdersNoToTop.RightControl = this.txtOrdersNoToMid;
            this.txtOrdersNoToTop.Size = new System.Drawing.Size(64, 27);
            this.txtOrdersNoToTop.TabIndex = 200;
            this.txtOrdersNoToTop.Text = "XX3";
            this.txtOrdersNoToTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNoToTop.UpControl = this.txtDocumentNoTo;
            // 
            // txtOrdersNoToMid
            // 
            this.txtOrdersNoToMid.BeforeValue = "";
            this.txtOrdersNoToMid.DownControl = this.txtCustomerCode;
            this.txtOrdersNoToMid.EnterControl = this.txtOrdersNoToBtm;
            this.txtOrdersNoToMid.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNoToMid.LabelControl = null;
            this.txtOrdersNoToMid.LeftControl = this.txtOrdersNoToTop;
            this.txtOrdersNoToMid.Location = new System.Drawing.Point(487, 103);
            this.txtOrdersNoToMid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNoToMid.MaxLength = 2;
            this.txtOrdersNoToMid.Name = "txtOrdersNoToMid";
            this.txtOrdersNoToMid.RightControl = this.txtOrdersNoToBtm;
            this.txtOrdersNoToMid.Size = new System.Drawing.Size(45, 27);
            this.txtOrdersNoToMid.TabIndex = 210;
            this.txtOrdersNoToMid.Text = "X2";
            this.txtOrdersNoToMid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNoToMid.UpControl = this.txtDocumentNoTo;
            // 
            // txtOrdersNoToBtm
            // 
            this.txtOrdersNoToBtm.BeforeValue = "";
            this.txtOrdersNoToBtm.DownControl = this.txtCustomerCode;
            this.txtOrdersNoToBtm.EnterControl = this.txtCustomerCode;
            this.txtOrdersNoToBtm.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNoToBtm.LabelControl = null;
            this.txtOrdersNoToBtm.LeftControl = this.txtOrdersNoToMid;
            this.txtOrdersNoToBtm.Location = new System.Drawing.Point(533, 103);
            this.txtOrdersNoToBtm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNoToBtm.MaxLength = 10;
            this.txtOrdersNoToBtm.Name = "txtOrdersNoToBtm";
            this.txtOrdersNoToBtm.RightControl = null;
            this.txtOrdersNoToBtm.Size = new System.Drawing.Size(135, 27);
            this.txtOrdersNoToBtm.TabIndex = 220;
            this.txtOrdersNoToBtm.Text = "XXXXXXXX10";
            this.txtOrdersNoToBtm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNoToBtm.UpControl = this.txtDocumentNoTo;
            // 
            // txtDocumentNoTo
            // 
            this.txtDocumentNoTo.BeforeValue = "";
            this.txtDocumentNoTo.DownControl = this.txtOrdersNoToTop;
            this.txtDocumentNoTo.EnterControl = this.txtDocumentDateFromYears;
            this.txtDocumentNoTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentNoTo.LabelControl = null;
            this.txtDocumentNoTo.LeftControl = this.txtDocumentNoFrom;
            this.txtDocumentNoTo.Location = new System.Drawing.Point(369, 75);
            this.txtDocumentNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentNoTo.MaxLength = 8;
            this.txtDocumentNoTo.Name = "txtDocumentNoTo";
            this.txtDocumentNoTo.RightControl = this.txtDocumentDateFromYears;
            this.txtDocumentNoTo.Size = new System.Drawing.Size(194, 27);
            this.txtDocumentNoTo.TabIndex = 60;
            this.txtDocumentNoTo.Text = "XXXXXXX8";
            this.txtDocumentNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentNoTo.UpControl = null;
            // 
            // txtDocumentDateFromYears
            // 
            this.txtDocumentDateFromYears.BeforeValue = "";
            this.txtDocumentDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateFromYears.DownControl = null;
            this.txtDocumentDateFromYears.EnterControl = this.txtDocumentDateFromMonth;
            this.txtDocumentDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateFromYears.LabelControl = null;
            this.txtDocumentDateFromYears.LeftControl = this.txtDocumentNoTo;
            this.txtDocumentDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtDocumentDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateFromYears.MaxLength = 4;
            this.txtDocumentDateFromYears.Name = "txtDocumentDateFromYears";
            this.txtDocumentDateFromYears.RightControl = this.txtDocumentDateFromMonth;
            this.txtDocumentDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtDocumentDateFromYears.TabIndex = 80;
            this.txtDocumentDateFromYears.Text = "1234";
            this.txtDocumentDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateFromYears.UpControl = null;
            // 
            // txtDocumentDateFromMonth
            // 
            this.txtDocumentDateFromMonth.BeforeValue = "";
            this.txtDocumentDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateFromMonth.DownControl = null;
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
            this.txtDocumentDateFromMonth.TabIndex = 90;
            this.txtDocumentDateFromMonth.Text = "12";
            this.txtDocumentDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateFromMonth.UpControl = null;
            // 
            // txtDocumentDateFromDays
            // 
            this.txtDocumentDateFromDays.BeforeValue = "";
            this.txtDocumentDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateFromDays.DownControl = null;
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
            this.txtDocumentDateFromDays.TabIndex = 100;
            this.txtDocumentDateFromDays.Text = "12";
            this.txtDocumentDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateFromDays.UpControl = null;
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
            this.txtDocumentDateToYears.TabIndex = 130;
            this.txtDocumentDateToYears.Text = "1234";
            this.txtDocumentDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateToYears.UpControl = null;
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
            this.txtDocumentDateToMonth.TabIndex = 140;
            this.txtDocumentDateToMonth.Text = "12";
            this.txtDocumentDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateToMonth.UpControl = null;
            // 
            // txtDocumentDateToDays
            // 
            this.txtDocumentDateToDays.BeforeValue = "";
            this.txtDocumentDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumentDateToDays.DownControl = null;
            this.txtDocumentDateToDays.EnterControl = this.txtOrdersNoFromTop;
            this.txtDocumentDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentDateToDays.LabelControl = null;
            this.txtDocumentDateToDays.LeftControl = this.txtDocumentDateToMonth;
            this.txtDocumentDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtDocumentDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentDateToDays.MaxLength = 2;
            this.txtDocumentDateToDays.Name = "txtDocumentDateToDays";
            this.txtDocumentDateToDays.RightControl = null;
            this.txtDocumentDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtDocumentDateToDays.TabIndex = 150;
            this.txtDocumentDateToDays.Text = "12";
            this.txtDocumentDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentDateToDays.UpControl = null;
            // 
            // txtDocumentNoFrom
            // 
            this.txtDocumentNoFrom.BeforeValue = "";
            this.txtDocumentNoFrom.DownControl = this.txtOrdersNoFromTop;
            this.txtDocumentNoFrom.EnterControl = this.txtDocumentNoTo;
            this.txtDocumentNoFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDocumentNoFrom.LabelControl = null;
            this.txtDocumentNoFrom.LeftControl = null;
            this.txtDocumentNoFrom.Location = new System.Drawing.Point(133, 75);
            this.txtDocumentNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocumentNoFrom.MaxLength = 8;
            this.txtDocumentNoFrom.Name = "txtDocumentNoFrom";
            this.txtDocumentNoFrom.RightControl = this.txtDocumentNoTo;
            this.txtDocumentNoFrom.Size = new System.Drawing.Size(193, 27);
            this.txtDocumentNoFrom.TabIndex = 50;
            this.txtDocumentNoFrom.Text = "XXXXXXX8";
            this.txtDocumentNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumentNoFrom.UpControl = null;
            // 
            // txtOrdersNoFromBtm
            // 
            this.txtOrdersNoFromBtm.BeforeValue = "";
            this.txtOrdersNoFromBtm.DownControl = this.txtCustomerCode;
            this.txtOrdersNoFromBtm.EnterControl = this.txtOrdersNoToTop;
            this.txtOrdersNoFromBtm.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNoFromBtm.LabelControl = null;
            this.txtOrdersNoFromBtm.LeftControl = this.txtOrdersNoFromMid;
            this.txtOrdersNoFromBtm.Location = new System.Drawing.Point(244, 103);
            this.txtOrdersNoFromBtm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNoFromBtm.MaxLength = 10;
            this.txtOrdersNoFromBtm.Name = "txtOrdersNoFromBtm";
            this.txtOrdersNoFromBtm.RightControl = this.txtOrdersNoToTop;
            this.txtOrdersNoFromBtm.Size = new System.Drawing.Size(135, 27);
            this.txtOrdersNoFromBtm.TabIndex = 190;
            this.txtOrdersNoFromBtm.Text = "XXXX5";
            this.txtOrdersNoFromBtm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNoFromBtm.UpControl = this.txtDocumentNoFrom;
            // 
            // txtOrdersNoFromMid
            // 
            this.txtOrdersNoFromMid.BeforeValue = "";
            this.txtOrdersNoFromMid.DownControl = this.txtCustomerCode;
            this.txtOrdersNoFromMid.EnterControl = this.txtOrdersNoFromBtm;
            this.txtOrdersNoFromMid.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrdersNoFromMid.LabelControl = null;
            this.txtOrdersNoFromMid.LeftControl = this.txtOrdersNoFromTop;
            this.txtOrdersNoFromMid.Location = new System.Drawing.Point(198, 103);
            this.txtOrdersNoFromMid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrdersNoFromMid.MaxLength = 2;
            this.txtOrdersNoFromMid.Name = "txtOrdersNoFromMid";
            this.txtOrdersNoFromMid.RightControl = this.txtOrdersNoFromBtm;
            this.txtOrdersNoFromMid.Size = new System.Drawing.Size(45, 27);
            this.txtOrdersNoFromMid.TabIndex = 180;
            this.txtOrdersNoFromMid.Text = "X2";
            this.txtOrdersNoFromMid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrdersNoFromMid.UpControl = this.txtDocumentNoFrom;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 290;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(914, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 320;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(1024, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 330;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlOrder);
            this.pnlHeader.Controls.Add(this.txtOrdersNoToBtm);
            this.pnlHeader.Controls.Add(this.txtOrdersNoToMid);
            this.pnlHeader.Controls.Add(this.txtOrdersNoFromBtm);
            this.pnlHeader.Controls.Add(this.txtOrdersNoFromMid);
            this.pnlHeader.Controls.Add(this.pnlDocumentDateTo);
            this.pnlHeader.Controls.Add(this.pnlDocumentDateFrom);
            this.pnlHeader.Controls.Add(this.txtDocumentNoTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblDocumentNo);
            this.pnlHeader.Controls.Add(this.txtDocumentNoFrom);
            this.pnlHeader.Controls.Add(this.lblCustomerCanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblCustomerCharactersName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.txtOrdersNoToTop);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated3);
            this.pnlHeader.Controls.Add(this.lblDocumentDate);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Controls.Add(this.lblOrdersNo);
            this.pnlHeader.Controls.Add(this.txtOrdersNoFromTop);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1133, 198);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.rdoAsc);
            this.pnlOrder.Controls.Add(this.rdoDesc);
            this.pnlOrder.Location = new System.Drawing.Point(3, 161);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(343, 30);
            this.pnlOrder.TabIndex = 444;
            // 
            // rdoAsc
            // 
            this.rdoAsc.AutoSize = true;
            this.rdoAsc.Checked = true;
            this.rdoAsc.Location = new System.Drawing.Point(3, 3);
            this.rdoAsc.Name = "rdoAsc";
            this.rdoAsc.Size = new System.Drawing.Size(163, 24);
            this.rdoAsc.TabIndex = 251;
            this.rdoAsc.TabStop = true;
            this.rdoAsc.Text = "仕入日付の昇順";
            this.rdoAsc.UseVisualStyleBackColor = true;
            // 
            // rdoDesc
            // 
            this.rdoDesc.AutoSize = true;
            this.rdoDesc.Location = new System.Drawing.Point(172, 3);
            this.rdoDesc.Name = "rdoDesc";
            this.rdoDesc.Size = new System.Drawing.Size(163, 24);
            this.rdoDesc.TabIndex = 252;
            this.rdoDesc.Text = "仕入日付の降順";
            this.rdoDesc.UseVisualStyleBackColor = true;
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
            this.pnlDocumentDateTo.Location = new System.Drawing.Point(915, 75);
            this.pnlDocumentDateTo.Name = "pnlDocumentDateTo";
            this.pnlDocumentDateTo.Size = new System.Drawing.Size(211, 27);
            this.pnlDocumentDateTo.TabIndex = 120;
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
            this.dtpDocumentDateTo.EnterControl = this.txtOrdersNoFromTop;
            this.dtpDocumentDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDocumentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocumentDateTo.LeftControl = this.txtDocumentDateToDays;
            this.dtpDocumentDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpDocumentDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDocumentDateTo.MonthLinkTextControl = this.txtDocumentDateToMonth;
            this.dtpDocumentDateTo.Name = "dtpDocumentDateTo";
            this.dtpDocumentDateTo.RightControl = null;
            this.dtpDocumentDateTo.Size = new System.Drawing.Size(211, 27);
            this.dtpDocumentDateTo.TabIndex = 160;
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
            this.pnlDocumentDateFrom.Location = new System.Drawing.Point(662, 75);
            this.pnlDocumentDateFrom.Name = "pnlDocumentDateFrom";
            this.pnlDocumentDateFrom.Size = new System.Drawing.Size(211, 27);
            this.pnlDocumentDateFrom.TabIndex = 70;
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
            this.dtpDocumentDateFrom.DownControl = null;
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
            this.dtpDocumentDateFrom.TabIndex = 110;
            this.dtpDocumentDateFrom.UpControl = null;
            this.dtpDocumentDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpDocumentDateFrom.Value2 = null;
            this.dtpDocumentDateFrom.YearsLinkTextControl = this.txtDocumentDateFromYears;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Location = new System.Drawing.Point(333, 78);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 73;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDocumentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDocumentNo.ForeColor = System.Drawing.Color.White;
            this.lblDocumentNo.Location = new System.Drawing.Point(3, 75);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(130, 27);
            this.lblDocumentNo.TabIndex = 72;
            this.lblDocumentNo.Text = "仕入NO";
            this.lblDocumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCanaName
            // 
            this.lblCustomerCanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCanaName.Location = new System.Drawing.Point(614, 131);
            this.lblCustomerCanaName.Name = "lblCustomerCanaName";
            this.lblCustomerCanaName.Size = new System.Drawing.Size(104, 27);
            this.lblCustomerCanaName.TabIndex = 68;
            this.lblCustomerCanaName.Text = "カナ名";
            this.lblCustomerCanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.Location = new System.Drawing.Point(880, 79);
            this.lblFromToSeparated2.Name = "lblFromToSeparated2";
            this.lblFromToSeparated2.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated2.TabIndex = 63;
            this.lblFromToSeparated2.Text = "～";
            // 
            // lblCustomerCharactersName
            // 
            this.lblCustomerCharactersName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCharactersName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCharactersName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCharactersName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCharactersName.Location = new System.Drawing.Point(264, 131);
            this.lblCustomerCharactersName.Name = "lblCustomerCharactersName";
            this.lblCustomerCharactersName.Size = new System.Drawing.Size(139, 27);
            this.lblCustomerCharactersName.TabIndex = 61;
            this.lblCustomerCharactersName.Text = "得意先漢字名";
            this.lblCustomerCharactersName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(3, 131);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 60;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated3
            // 
            this.lblFromToSeparated3.Location = new System.Drawing.Point(386, 106);
            this.lblFromToSeparated3.Name = "lblFromToSeparated3";
            this.lblFromToSeparated3.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated3.TabIndex = 56;
            this.lblFromToSeparated3.Text = "～";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDocumentDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDocumentDate.ForeColor = System.Drawing.Color.White;
            this.lblDocumentDate.Location = new System.Drawing.Point(564, 75);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(98, 27);
            this.lblDocumentDate.TabIndex = 54;
            this.lblDocumentDate.Text = "仕入日付";
            this.lblDocumentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRowSelectMode
            // 
            this.pnlRowSelectMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRowSelectMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRowSelectMode.Controls.Add(this.lblRowSelectMode);
            this.pnlRowSelectMode.Controls.Add(this.rdoRange);
            this.pnlRowSelectMode.Controls.Add(this.rdoMulti);
            this.pnlRowSelectMode.Controls.Add(this.rdoSingle);
            this.pnlRowSelectMode.Location = new System.Drawing.Point(3, 7);
            this.pnlRowSelectMode.Name = "pnlRowSelectMode";
            this.pnlRowSelectMode.Size = new System.Drawing.Size(260, 65);
            this.pnlRowSelectMode.TabIndex = 10;
            // 
            // lblRowSelectMode
            // 
            this.lblRowSelectMode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRowSelectMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRowSelectMode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRowSelectMode.ForeColor = System.Drawing.Color.White;
            this.lblRowSelectMode.Location = new System.Drawing.Point(5, 2);
            this.lblRowSelectMode.Name = "lblRowSelectMode";
            this.lblRowSelectMode.Size = new System.Drawing.Size(130, 27);
            this.lblRowSelectMode.TabIndex = 4;
            this.lblRowSelectMode.Text = "行選択モード";
            this.lblRowSelectMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoRange
            // 
            this.rdoRange.AutoSize = true;
            this.rdoRange.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoRange.Location = new System.Drawing.Point(177, 32);
            this.rdoRange.Name = "rdoRange";
            this.rdoRange.Size = new System.Drawing.Size(69, 24);
            this.rdoRange.TabIndex = 40;
            this.rdoRange.Text = "範囲";
            this.rdoRange.UseVisualStyleBackColor = true;
            this.rdoRange.CheckedChanged += new System.EventHandler(this.rdoRange_CheckedChanged);
            // 
            // rdoMulti
            // 
            this.rdoMulti.AutoSize = true;
            this.rdoMulti.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoMulti.Location = new System.Drawing.Point(97, 32);
            this.rdoMulti.Name = "rdoMulti";
            this.rdoMulti.Size = new System.Drawing.Size(69, 24);
            this.rdoMulti.TabIndex = 30;
            this.rdoMulti.Text = "複数";
            this.rdoMulti.UseVisualStyleBackColor = true;
            this.rdoMulti.CheckedChanged += new System.EventHandler(this.rdoMulti_CheckedChanged);
            // 
            // rdoSingle
            // 
            this.rdoSingle.AutoSize = true;
            this.rdoSingle.Checked = true;
            this.rdoSingle.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoSingle.Location = new System.Drawing.Point(17, 32);
            this.rdoSingle.Name = "rdoSingle";
            this.rdoSingle.Size = new System.Drawing.Size(69, 24);
            this.rdoSingle.TabIndex = 20;
            this.rdoSingle.TabStop = true;
            this.rdoSingle.Text = "単一";
            this.rdoSingle.UseVisualStyleBackColor = true;
            this.rdoSingle.CheckedChanged += new System.EventHandler(this.rdoSingle_CheckedChanged);
            // 
            // lblOrdersNo
            // 
            this.lblOrdersNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrdersNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrdersNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrdersNo.ForeColor = System.Drawing.Color.White;
            this.lblOrdersNo.Location = new System.Drawing.Point(3, 103);
            this.lblOrdersNo.Name = "lblOrdersNo";
            this.lblOrdersNo.Size = new System.Drawing.Size(130, 27);
            this.lblOrdersNo.TabIndex = 3;
            this.lblOrdersNo.Text = "受注NO";
            this.lblOrdersNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 198);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1133, 301);
            this.pnlBody.TabIndex = 260;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSelectCancel);
            this.pnlBottom.Controls.Add(this.btnAllSelect);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnBack);
            this.pnlBottom.Controls.Add(this.btnCheck);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 499);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1133, 70);
            this.pnlBottom.TabIndex = 280;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(804, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 525;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectCancel
            // 
            this.btnSelectCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectCancel.Location = new System.Drawing.Point(223, 15);
            this.btnSelectCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCancel.Name = "btnSelectCancel";
            this.btnSelectCancel.Size = new System.Drawing.Size(102, 40);
            this.btnSelectCancel.TabIndex = 310;
            this.btnSelectCancel.Text = "選択解除";
            this.btnSelectCancel.UseVisualStyleBackColor = false;
            this.btnSelectCancel.Click += new System.EventHandler(this.btnSelectCancel_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAllSelect.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAllSelect.Location = new System.Drawing.Point(113, 15);
            this.btnAllSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(102, 40);
            this.btnAllSelect.TabIndex = 300;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // sfrmShireSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1133, 570);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmShireSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入検索";
            this.Load += new System.EventHandler(this.sfrmShireSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlDocumentDateTo.ResumeLayout(false);
            this.pnlDocumentDateTo.PerformLayout();
            this.pnlDocumentDateFrom.ResumeLayout(false);
            this.pnlDocumentDateFrom.PerformLayout();
            this.pnlRowSelectMode.ResumeLayout(false);
            this.pnlRowSelectMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.CustomTextBox txtOrdersNoFromTop;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnCheck;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView grdSearchList;
        private Common.ItemHeadLabel lblOrdersNo;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblDocumentDate;
        private System.Windows.Forms.Label lblFromToSeparated3;
        private Common.ItemHeadLabel lblCustomerCharactersName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomTextBox txtOrdersNoToTop;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.ItemHeadLabel lblCustomerCanaName;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.CustomTextBox txtDocumentNoTo;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.ItemHeadLabel lblDocumentNo;
        private Common.CustomTextBox txtDocumentNoFrom;
        private System.Windows.Forms.Panel pnlDocumentDateFrom;
        private System.Windows.Forms.Label lblDocumentDateFromDays;
        private Common.CustomTextBox txtDocumentDateFromDays;
        private Common.CustomTextBox txtDocumentDateFromMonth;
        private Common.CustomTextBox txtDocumentDateFromYears;
        private System.Windows.Forms.Label lblDocumentDateFromMonth;
        private System.Windows.Forms.Label lblDocumentDateFromYears;
        private Common.CustomDateTimePicker dtpDocumentDateFrom;
        private System.Windows.Forms.Panel pnlDocumentDateTo;
        private System.Windows.Forms.Label lblDocumentDateToDays;
        private Common.CustomTextBox txtDocumentDateToDays;
        private Common.CustomTextBox txtDocumentDateToMonth;
        private Common.CustomTextBox txtDocumentDateToYears;
        private System.Windows.Forms.Label lblDocumentDateToMonth;
        private System.Windows.Forms.Label lblDocumentDateToYears;
        private Common.CustomDateTimePicker dtpDocumentDateTo;
        private Common.CustomTextBox txtOrdersNoFromBtm;
        private Common.CustomTextBox txtOrdersNoFromMid;
        private Common.CustomTextBox txtOrdersNoToBtm;
        private Common.CustomTextBox txtOrdersNoToMid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPurchaseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrdersNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOfficesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.RadioButton rdoAsc;
        private System.Windows.Forms.RadioButton rdoDesc;
        private Common.FeaturesButton btnCancel;
    }
}