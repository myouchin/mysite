namespace SubForm
{
    partial class sfrmNyukinSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.rdoAsc = new System.Windows.Forms.RadioButton();
            this.rdoDesc = new System.Windows.Forms.RadioButton();
            this.pnlDepositDateTo = new System.Windows.Forms.Panel();
            this.lblDepositDateToDays = new System.Windows.Forms.Label();
            this.txtDepositDateToDays = new Common.CustomTextBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.grdSearchList = new System.Windows.Forms.DataGridView();
            this.clmDepositNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepositDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOfficesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtDepositNoFrom = new Common.CustomTextBox();
            this.txtDepositNoTo = new Common.CustomTextBox();
            this.txtDepositDateFromYears = new Common.CustomTextBox();
            this.txtDepositDateFromMonth = new Common.CustomTextBox();
            this.txtDepositDateFromDays = new Common.CustomTextBox();
            this.txtDepositDateToYears = new Common.CustomTextBox();
            this.txtDepositDateToMonth = new Common.CustomTextBox();
            this.lblDepositDateToMonth = new System.Windows.Forms.Label();
            this.lblDepositDateToYears = new System.Windows.Forms.Label();
            this.dtpDepositDateTo = new Common.CustomDateTimePicker();
            this.pnlDepositDateFrom = new System.Windows.Forms.Panel();
            this.lblDepositDateFromDays = new System.Windows.Forms.Label();
            this.lblDepositDateFromMonth = new System.Windows.Forms.Label();
            this.lblDepositDateFromYears = new System.Windows.Forms.Label();
            this.dtpDepositDateFrom = new Common.CustomDateTimePicker();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblDepositNo = new Common.ItemHeadLabel();
            this.lblCustomerCanaName = new Common.ItemHeadLabel();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblCustomerCharactersName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.lblDocumentDate = new Common.ItemHeadLabel();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.btnSelectCancel = new Common.FeaturesButton();
            this.btnAllSelect = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlDepositDateTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlDepositDateFrom.SuspendLayout();
            this.pnlRowSelectMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 230;
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
            this.btnCheck.TabIndex = 260;
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
            this.btnBack.TabIndex = 270;
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
            this.pnlHeader.Controls.Add(this.pnlDepositDateTo);
            this.pnlHeader.Controls.Add(this.pnlDepositDateFrom);
            this.pnlHeader.Controls.Add(this.txtDepositNoTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblDepositNo);
            this.pnlHeader.Controls.Add(this.txtDepositNoFrom);
            this.pnlHeader.Controls.Add(this.lblCustomerCanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblCustomerCharactersName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblDocumentDate);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1133, 170);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.rdoAsc);
            this.pnlOrder.Controls.Add(this.rdoDesc);
            this.pnlOrder.Location = new System.Drawing.Point(3, 133);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(343, 30);
            this.pnlOrder.TabIndex = 442;
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
            this.rdoAsc.Text = "入金日付の昇順";
            this.rdoAsc.UseVisualStyleBackColor = true;
            // 
            // rdoDesc
            // 
            this.rdoDesc.AutoSize = true;
            this.rdoDesc.Location = new System.Drawing.Point(172, 3);
            this.rdoDesc.Name = "rdoDesc";
            this.rdoDesc.Size = new System.Drawing.Size(163, 24);
            this.rdoDesc.TabIndex = 252;
            this.rdoDesc.Text = "入金日付の降順";
            this.rdoDesc.UseVisualStyleBackColor = true;
            // 
            // pnlDepositDateTo
            // 
            this.pnlDepositDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDepositDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDepositDateTo.Controls.Add(this.lblDepositDateToDays);
            this.pnlDepositDateTo.Controls.Add(this.txtDepositDateToDays);
            this.pnlDepositDateTo.Controls.Add(this.lblDepositDateToMonth);
            this.pnlDepositDateTo.Controls.Add(this.txtDepositDateToMonth);
            this.pnlDepositDateTo.Controls.Add(this.lblDepositDateToYears);
            this.pnlDepositDateTo.Controls.Add(this.txtDepositDateToYears);
            this.pnlDepositDateTo.Controls.Add(this.dtpDepositDateTo);
            this.pnlDepositDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlDepositDateTo.Location = new System.Drawing.Point(915, 75);
            this.pnlDepositDateTo.Name = "pnlDepositDateTo";
            this.pnlDepositDateTo.Size = new System.Drawing.Size(211, 27);
            this.pnlDepositDateTo.TabIndex = 120;
            // 
            // lblDepositDateToDays
            // 
            this.lblDepositDateToDays.Location = new System.Drawing.Point(148, 0);
            this.lblDepositDateToDays.Name = "lblDepositDateToDays";
            this.lblDepositDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateToDays.TabIndex = 119;
            this.lblDepositDateToDays.Text = "日";
            this.lblDepositDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDepositDateToDays
            // 
            this.txtDepositDateToDays.BeforeValue = "";
            this.txtDepositDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateToDays.DownControl = this.txtCustomerKanaName;
            this.txtDepositDateToDays.EnterControl = this.txtCustomerCode;
            this.txtDepositDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateToDays.LabelControl = null;
            this.txtDepositDateToDays.LeftControl = this.txtDepositDateToMonth;
            this.txtDepositDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtDepositDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateToDays.MaxLength = 2;
            this.txtDepositDateToDays.Name = "txtDepositDateToDays";
            this.txtDepositDateToDays.RightControl = null;
            this.txtDepositDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtDepositDateToDays.TabIndex = 150;
            this.txtDepositDateToDays.Text = "12";
            this.txtDepositDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateToDays.UpControl = null;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.grdSearchList;
            this.txtCustomerKanaName.EnterControl = this.grdSearchList;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(718, 103);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.MaxLength = 80;
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = null;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(408, 27);
            this.txtCustomerKanaName.TabIndex = 190;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = this.txtDepositDateFromYears;
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
            this.clmDepositNo,
            this.clmDepositDate,
            this.clmCustomerName,
            this.clmOfficesName});
            this.grdSearchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdSearchList.EnableHeadersVisualStyles = false;
            this.grdSearchList.Location = new System.Drawing.Point(3, 5);
            this.grdSearchList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSearchList.MultiSelect = false;
            this.grdSearchList.Name = "grdSearchList";
            this.grdSearchList.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(1123, 287);
            this.grdSearchList.TabIndex = 210;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmDepositNo
            // 
            this.clmDepositNo.DataPropertyName = "nyukinNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmDepositNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmDepositNo.HeaderText = "入金NO";
            this.clmDepositNo.Name = "clmDepositNo";
            this.clmDepositNo.ReadOnly = true;
            this.clmDepositNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmDepositDate
            // 
            this.clmDepositDate.DataPropertyName = "nyukinHizuke";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.clmDepositDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmDepositDate.HeaderText = "入金日付";
            this.clmDepositDate.Name = "clmDepositDate";
            this.clmDepositDate.ReadOnly = true;
            this.clmDepositDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDepositDate.Width = 160;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.DataPropertyName = "tokuisakiName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmCustomerName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmCustomerName.HeaderText = "得意先名";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerName.Width = 249;
            // 
            // clmOfficesName
            // 
            this.clmOfficesName.DataPropertyName = "jigyousyoName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmOfficesName.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmOfficesName.HeaderText = "事業所名";
            this.clmOfficesName.Name = "clmOfficesName";
            this.clmOfficesName.ReadOnly = true;
            this.clmOfficesName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOfficesName.Width = 150;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.grdSearchList;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(403, 103);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 40;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(210, 27);
            this.txtCustomerName.TabIndex = 180;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtDepositNoTo;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.grdSearchList;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(133, 103);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 5;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 170;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtDepositNoFrom;
            // 
            // txtDepositNoFrom
            // 
            this.txtDepositNoFrom.BeforeValue = "";
            this.txtDepositNoFrom.DownControl = this.txtCustomerCode;
            this.txtDepositNoFrom.EnterControl = this.txtDepositNoTo;
            this.txtDepositNoFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositNoFrom.LabelControl = null;
            this.txtDepositNoFrom.LeftControl = null;
            this.txtDepositNoFrom.Location = new System.Drawing.Point(133, 75);
            this.txtDepositNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositNoFrom.MaxLength = 8;
            this.txtDepositNoFrom.Name = "txtDepositNoFrom";
            this.txtDepositNoFrom.RightControl = this.txtDepositNoTo;
            this.txtDepositNoFrom.Size = new System.Drawing.Size(193, 27);
            this.txtDepositNoFrom.TabIndex = 50;
            this.txtDepositNoFrom.Text = "XXXXXXX8";
            this.txtDepositNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositNoFrom.UpControl = null;
            // 
            // txtDepositNoTo
            // 
            this.txtDepositNoTo.BeforeValue = "";
            this.txtDepositNoTo.DownControl = this.txtCustomerName;
            this.txtDepositNoTo.EnterControl = this.txtDepositDateFromYears;
            this.txtDepositNoTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositNoTo.LabelControl = null;
            this.txtDepositNoTo.LeftControl = this.txtDepositNoFrom;
            this.txtDepositNoTo.Location = new System.Drawing.Point(369, 75);
            this.txtDepositNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositNoTo.MaxLength = 8;
            this.txtDepositNoTo.Name = "txtDepositNoTo";
            this.txtDepositNoTo.RightControl = this.txtDepositDateFromYears;
            this.txtDepositNoTo.Size = new System.Drawing.Size(194, 27);
            this.txtDepositNoTo.TabIndex = 60;
            this.txtDepositNoTo.Text = "XXXXXXX8";
            this.txtDepositNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositNoTo.UpControl = null;
            // 
            // txtDepositDateFromYears
            // 
            this.txtDepositDateFromYears.BeforeValue = "";
            this.txtDepositDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateFromYears.DownControl = this.txtCustomerKanaName;
            this.txtDepositDateFromYears.EnterControl = this.txtDepositDateFromMonth;
            this.txtDepositDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateFromYears.LabelControl = null;
            this.txtDepositDateFromYears.LeftControl = this.txtDepositNoTo;
            this.txtDepositDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtDepositDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateFromYears.MaxLength = 4;
            this.txtDepositDateFromYears.Name = "txtDepositDateFromYears";
            this.txtDepositDateFromYears.RightControl = this.txtDepositDateFromMonth;
            this.txtDepositDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtDepositDateFromYears.TabIndex = 80;
            this.txtDepositDateFromYears.Text = "1234";
            this.txtDepositDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateFromYears.UpControl = null;
            // 
            // txtDepositDateFromMonth
            // 
            this.txtDepositDateFromMonth.BeforeValue = "";
            this.txtDepositDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateFromMonth.DownControl = this.txtCustomerKanaName;
            this.txtDepositDateFromMonth.EnterControl = this.txtDepositDateFromDays;
            this.txtDepositDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateFromMonth.LabelControl = null;
            this.txtDepositDateFromMonth.LeftControl = this.txtDepositDateFromYears;
            this.txtDepositDateFromMonth.Location = new System.Drawing.Point(66, 3);
            this.txtDepositDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateFromMonth.MaxLength = 2;
            this.txtDepositDateFromMonth.Name = "txtDepositDateFromMonth";
            this.txtDepositDateFromMonth.RightControl = this.txtDepositDateFromDays;
            this.txtDepositDateFromMonth.Size = new System.Drawing.Size(30, 20);
            this.txtDepositDateFromMonth.TabIndex = 90;
            this.txtDepositDateFromMonth.Text = "12";
            this.txtDepositDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateFromMonth.UpControl = null;
            // 
            // txtDepositDateFromDays
            // 
            this.txtDepositDateFromDays.BeforeValue = "";
            this.txtDepositDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateFromDays.DownControl = this.txtCustomerKanaName;
            this.txtDepositDateFromDays.EnterControl = this.txtDepositDateToYears;
            this.txtDepositDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateFromDays.LabelControl = null;
            this.txtDepositDateFromDays.LeftControl = this.txtDepositDateFromMonth;
            this.txtDepositDateFromDays.Location = new System.Drawing.Point(115, 3);
            this.txtDepositDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateFromDays.MaxLength = 2;
            this.txtDepositDateFromDays.Name = "txtDepositDateFromDays";
            this.txtDepositDateFromDays.RightControl = this.txtDepositDateToYears;
            this.txtDepositDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtDepositDateFromDays.TabIndex = 100;
            this.txtDepositDateFromDays.Text = "12";
            this.txtDepositDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateFromDays.UpControl = null;
            // 
            // txtDepositDateToYears
            // 
            this.txtDepositDateToYears.BeforeValue = "";
            this.txtDepositDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateToYears.DownControl = this.txtCustomerKanaName;
            this.txtDepositDateToYears.EnterControl = this.txtDepositDateToMonth;
            this.txtDepositDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateToYears.LabelControl = null;
            this.txtDepositDateToYears.LeftControl = this.txtDepositDateFromDays;
            this.txtDepositDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtDepositDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateToYears.MaxLength = 4;
            this.txtDepositDateToYears.Name = "txtDepositDateToYears";
            this.txtDepositDateToYears.RightControl = this.txtDepositDateToMonth;
            this.txtDepositDateToYears.Size = new System.Drawing.Size(45, 20);
            this.txtDepositDateToYears.TabIndex = 130;
            this.txtDepositDateToYears.Text = "1234";
            this.txtDepositDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateToYears.UpControl = null;
            // 
            // txtDepositDateToMonth
            // 
            this.txtDepositDateToMonth.BeforeValue = "";
            this.txtDepositDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepositDateToMonth.DownControl = this.txtCustomerKanaName;
            this.txtDepositDateToMonth.EnterControl = this.txtDepositDateToDays;
            this.txtDepositDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtDepositDateToMonth.LabelControl = null;
            this.txtDepositDateToMonth.LeftControl = this.txtDepositDateToYears;
            this.txtDepositDateToMonth.Location = new System.Drawing.Point(68, 3);
            this.txtDepositDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDateToMonth.MaxLength = 2;
            this.txtDepositDateToMonth.Name = "txtDepositDateToMonth";
            this.txtDepositDateToMonth.RightControl = this.txtDepositDateToDays;
            this.txtDepositDateToMonth.Size = new System.Drawing.Size(30, 20);
            this.txtDepositDateToMonth.TabIndex = 140;
            this.txtDepositDateToMonth.Text = "12";
            this.txtDepositDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepositDateToMonth.UpControl = null;
            // 
            // lblDepositDateToMonth
            // 
            this.lblDepositDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblDepositDateToMonth.Name = "lblDepositDateToMonth";
            this.lblDepositDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateToMonth.TabIndex = 117;
            this.lblDepositDateToMonth.Text = "月";
            this.lblDepositDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepositDateToYears
            // 
            this.lblDepositDateToYears.Location = new System.Drawing.Point(44, 0);
            this.lblDepositDateToYears.Name = "lblDepositDateToYears";
            this.lblDepositDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateToYears.TabIndex = 115;
            this.lblDepositDateToYears.Text = "年";
            this.lblDepositDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDepositDateTo
            // 
            this.dtpDepositDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDepositDateTo.CustomFormat = " ";
            this.dtpDepositDateTo.DaysLinkTextControl = this.txtDepositDateToDays;
            this.dtpDepositDateTo.DownControl = this.txtCustomerKanaName;
            this.dtpDepositDateTo.EnterControl = this.txtCustomerCode;
            this.dtpDepositDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDepositDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepositDateTo.LeftControl = this.txtDepositDateToDays;
            this.dtpDepositDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpDepositDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDepositDateTo.MonthLinkTextControl = this.txtDepositDateToMonth;
            this.dtpDepositDateTo.Name = "dtpDepositDateTo";
            this.dtpDepositDateTo.RightControl = null;
            this.dtpDepositDateTo.Size = new System.Drawing.Size(211, 27);
            this.dtpDepositDateTo.TabIndex = 160;
            this.dtpDepositDateTo.UpControl = null;
            this.dtpDepositDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpDepositDateTo.Value2 = null;
            this.dtpDepositDateTo.YearsLinkTextControl = this.txtDepositDateToYears;
            // 
            // pnlDepositDateFrom
            // 
            this.pnlDepositDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDepositDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDepositDateFrom.Controls.Add(this.lblDepositDateFromDays);
            this.pnlDepositDateFrom.Controls.Add(this.txtDepositDateFromDays);
            this.pnlDepositDateFrom.Controls.Add(this.lblDepositDateFromMonth);
            this.pnlDepositDateFrom.Controls.Add(this.txtDepositDateFromMonth);
            this.pnlDepositDateFrom.Controls.Add(this.lblDepositDateFromYears);
            this.pnlDepositDateFrom.Controls.Add(this.txtDepositDateFromYears);
            this.pnlDepositDateFrom.Controls.Add(this.dtpDepositDateFrom);
            this.pnlDepositDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlDepositDateFrom.Location = new System.Drawing.Point(662, 75);
            this.pnlDepositDateFrom.Name = "pnlDepositDateFrom";
            this.pnlDepositDateFrom.Size = new System.Drawing.Size(211, 27);
            this.pnlDepositDateFrom.TabIndex = 70;
            // 
            // lblDepositDateFromDays
            // 
            this.lblDepositDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblDepositDateFromDays.Name = "lblDepositDateFromDays";
            this.lblDepositDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateFromDays.TabIndex = 119;
            this.lblDepositDateFromDays.Text = "日";
            this.lblDepositDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepositDateFromMonth
            // 
            this.lblDepositDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblDepositDateFromMonth.Name = "lblDepositDateFromMonth";
            this.lblDepositDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateFromMonth.TabIndex = 117;
            this.lblDepositDateFromMonth.Text = "月";
            this.lblDepositDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepositDateFromYears
            // 
            this.lblDepositDateFromYears.Location = new System.Drawing.Point(44, 0);
            this.lblDepositDateFromYears.Name = "lblDepositDateFromYears";
            this.lblDepositDateFromYears.Size = new System.Drawing.Size(28, 27);
            this.lblDepositDateFromYears.TabIndex = 115;
            this.lblDepositDateFromYears.Text = "年";
            this.lblDepositDateFromYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDepositDateFrom
            // 
            this.dtpDepositDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDepositDateFrom.CustomFormat = " ";
            this.dtpDepositDateFrom.DaysLinkTextControl = this.txtDepositDateFromDays;
            this.dtpDepositDateFrom.DownControl = this.txtCustomerKanaName;
            this.dtpDepositDateFrom.EnterControl = this.txtDepositDateToYears;
            this.dtpDepositDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpDepositDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepositDateFrom.LeftControl = this.txtDepositDateFromDays;
            this.dtpDepositDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpDepositDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDepositDateFrom.MonthLinkTextControl = this.txtDepositDateFromMonth;
            this.dtpDepositDateFrom.Name = "dtpDepositDateFrom";
            this.dtpDepositDateFrom.RightControl = this.txtDepositDateToYears;
            this.dtpDepositDateFrom.Size = new System.Drawing.Size(211, 27);
            this.dtpDepositDateFrom.TabIndex = 110;
            this.dtpDepositDateFrom.UpControl = null;
            this.dtpDepositDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpDepositDateFrom.Value2 = null;
            this.dtpDepositDateFrom.YearsLinkTextControl = this.txtDepositDateFromYears;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Location = new System.Drawing.Point(333, 78);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 73;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblDepositNo
            // 
            this.lblDepositNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDepositNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDepositNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDepositNo.ForeColor = System.Drawing.Color.White;
            this.lblDepositNo.Location = new System.Drawing.Point(3, 75);
            this.lblDepositNo.Name = "lblDepositNo";
            this.lblDepositNo.Size = new System.Drawing.Size(130, 27);
            this.lblDepositNo.TabIndex = 72;
            this.lblDepositNo.Text = "入金NO";
            this.lblDepositNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCanaName
            // 
            this.lblCustomerCanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCanaName.Location = new System.Drawing.Point(614, 103);
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
            this.lblCustomerCharactersName.Location = new System.Drawing.Point(264, 103);
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
            this.lblCustomerCode.Location = new System.Drawing.Point(3, 103);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 60;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblDocumentDate.Text = "入金日付";
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
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 170);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1133, 301);
            this.pnlBody.TabIndex = 200;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 471);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1133, 70);
            this.pnlBottom.TabIndex = 220;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(804, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 522;
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
            this.btnSelectCancel.TabIndex = 250;
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
            this.btnAllSelect.TabIndex = 240;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // sfrmNyukinSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1133, 540);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmNyukinSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入金検索";
            this.Load += new System.EventHandler(this.sfrmNyukinSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlDepositDateTo.ResumeLayout(false);
            this.pnlDepositDateTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlDepositDateFrom.ResumeLayout(false);
            this.pnlDepositDateFrom.PerformLayout();
            this.pnlRowSelectMode.ResumeLayout(false);
            this.pnlRowSelectMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnCheck;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView grdSearchList;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblDocumentDate;
        private Common.ItemHeadLabel lblCustomerCharactersName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.ItemHeadLabel lblCustomerCanaName;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.CustomTextBox txtDepositNoTo;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.ItemHeadLabel lblDepositNo;
        private Common.CustomTextBox txtDepositNoFrom;
        private System.Windows.Forms.Panel pnlDepositDateFrom;
        private System.Windows.Forms.Label lblDepositDateFromDays;
        private Common.CustomTextBox txtDepositDateFromDays;
        private Common.CustomTextBox txtDepositDateFromMonth;
        private Common.CustomTextBox txtDepositDateFromYears;
        private System.Windows.Forms.Label lblDepositDateFromMonth;
        private System.Windows.Forms.Label lblDepositDateFromYears;
        private Common.CustomDateTimePicker dtpDepositDateFrom;
        private System.Windows.Forms.Panel pnlDepositDateTo;
        private System.Windows.Forms.Label lblDepositDateToDays;
        private Common.CustomTextBox txtDepositDateToDays;
        private Common.CustomTextBox txtDepositDateToMonth;
        private Common.CustomTextBox txtDepositDateToYears;
        private System.Windows.Forms.Label lblDepositDateToMonth;
        private System.Windows.Forms.Label lblDepositDateToYears;
        private Common.CustomDateTimePicker dtpDepositDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepositNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepositDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOfficesName;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.RadioButton rdoAsc;
        private System.Windows.Forms.RadioButton rdoDesc;
        private Common.FeaturesButton btnCancel;
    }
}