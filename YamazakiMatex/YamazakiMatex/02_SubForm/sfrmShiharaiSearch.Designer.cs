namespace SubForm
{
    partial class sfrmShiharaiSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.rdoAsc = new System.Windows.Forms.RadioButton();
            this.rdoDesc = new System.Windows.Forms.RadioButton();
            this.pnlPaymentDateTo = new System.Windows.Forms.Panel();
            this.lblPaymentDateToDays = new System.Windows.Forms.Label();
            this.txtPaymentDateToDays = new Common.CustomTextBox();
            this.txtPurchaseName = new Common.CustomTextBox();
            this.grdSearchList = new System.Windows.Forms.DataGridView();
            this.clmPaymentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPurchaseCode = new Common.CustomTextBox();
            this.txtPaymentNoFrom = new Common.CustomTextBox();
            this.txtPaymentNoTo = new Common.CustomTextBox();
            this.txtPaymentDateFromYears = new Common.CustomTextBox();
            this.txtPaymentDateFromMonth = new Common.CustomTextBox();
            this.txtPaymentDateFromDays = new Common.CustomTextBox();
            this.txtPaymentDateToMonth = new Common.CustomTextBox();
            this.txtPaymentDateToYears = new Common.CustomTextBox();
            this.lblPaymentDateToMonth = new System.Windows.Forms.Label();
            this.lblPaymentDateToYears = new System.Windows.Forms.Label();
            this.dtpPaymentDateTo = new Common.CustomDateTimePicker();
            this.pnlPaymentDateFrom = new System.Windows.Forms.Panel();
            this.lblPaymentDateFromDays = new System.Windows.Forms.Label();
            this.lblPaymentDateFromMonth = new System.Windows.Forms.Label();
            this.lblDocumentDateFromYears = new System.Windows.Forms.Label();
            this.dtpPaymentDateFrom = new Common.CustomDateTimePicker();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblPaymentNo = new Common.ItemHeadLabel();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblPurchaseName = new Common.ItemHeadLabel();
            this.lblPurchaseCode = new Common.ItemHeadLabel();
            this.lblPaymentDate = new Common.ItemHeadLabel();
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
            this.pnlPaymentDateTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlPaymentDateFrom.SuspendLayout();
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
            this.btnSearch.TabIndex = 220;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(793, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 250;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(903, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 260;
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
            this.pnlHeader.Controls.Add(this.pnlPaymentDateTo);
            this.pnlHeader.Controls.Add(this.pnlPaymentDateFrom);
            this.pnlHeader.Controls.Add(this.txtPaymentNoTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblPaymentNo);
            this.pnlHeader.Controls.Add(this.txtPaymentNoFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblPurchaseName);
            this.pnlHeader.Controls.Add(this.lblPurchaseCode);
            this.pnlHeader.Controls.Add(this.txtPurchaseCode);
            this.pnlHeader.Controls.Add(this.txtPurchaseName);
            this.pnlHeader.Controls.Add(this.lblPaymentDate);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1013, 170);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.rdoAsc);
            this.pnlOrder.Controls.Add(this.rdoDesc);
            this.pnlOrder.Location = new System.Drawing.Point(3, 133);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(343, 30);
            this.pnlOrder.TabIndex = 443;
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
            this.rdoAsc.Text = "支払日付の昇順";
            this.rdoAsc.UseVisualStyleBackColor = true;
            // 
            // rdoDesc
            // 
            this.rdoDesc.AutoSize = true;
            this.rdoDesc.Location = new System.Drawing.Point(172, 3);
            this.rdoDesc.Name = "rdoDesc";
            this.rdoDesc.Size = new System.Drawing.Size(163, 24);
            this.rdoDesc.TabIndex = 252;
            this.rdoDesc.Text = "支払日付の降順";
            this.rdoDesc.UseVisualStyleBackColor = true;
            // 
            // pnlPaymentDateTo
            // 
            this.pnlPaymentDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlPaymentDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaymentDateTo.Controls.Add(this.lblPaymentDateToDays);
            this.pnlPaymentDateTo.Controls.Add(this.txtPaymentDateToDays);
            this.pnlPaymentDateTo.Controls.Add(this.lblPaymentDateToMonth);
            this.pnlPaymentDateTo.Controls.Add(this.txtPaymentDateToMonth);
            this.pnlPaymentDateTo.Controls.Add(this.lblPaymentDateToYears);
            this.pnlPaymentDateTo.Controls.Add(this.txtPaymentDateToYears);
            this.pnlPaymentDateTo.Controls.Add(this.dtpPaymentDateTo);
            this.pnlPaymentDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlPaymentDateTo.Location = new System.Drawing.Point(794, 75);
            this.pnlPaymentDateTo.Name = "pnlPaymentDateTo";
            this.pnlPaymentDateTo.Size = new System.Drawing.Size(211, 27);
            this.pnlPaymentDateTo.TabIndex = 120;
            // 
            // lblPaymentDateToDays
            // 
            this.lblPaymentDateToDays.Location = new System.Drawing.Point(148, 0);
            this.lblPaymentDateToDays.Name = "lblPaymentDateToDays";
            this.lblPaymentDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateToDays.TabIndex = 119;
            this.lblPaymentDateToDays.Text = "日";
            this.lblPaymentDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPaymentDateToDays
            // 
            this.txtPaymentDateToDays.BeforeValue = "";
            this.txtPaymentDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateToDays.DownControl = this.txtPurchaseName;
            this.txtPaymentDateToDays.EnterControl = this.txtPurchaseCode;
            this.txtPaymentDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateToDays.LabelControl = null;
            this.txtPaymentDateToDays.LeftControl = this.txtPaymentDateToMonth;
            this.txtPaymentDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtPaymentDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateToDays.MaxLength = 2;
            this.txtPaymentDateToDays.Name = "txtPaymentDateToDays";
            this.txtPaymentDateToDays.RightControl = null;
            this.txtPaymentDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtPaymentDateToDays.TabIndex = 150;
            this.txtPaymentDateToDays.Text = "12";
            this.txtPaymentDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateToDays.UpControl = null;
            // 
            // txtPurchaseName
            // 
            this.txtPurchaseName.BeforeValue = "";
            this.txtPurchaseName.DownControl = this.grdSearchList;
            this.txtPurchaseName.EnterControl = this.grdSearchList;
            this.txtPurchaseName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseName.LabelControl = null;
            this.txtPurchaseName.LeftControl = this.txtPurchaseCode;
            this.txtPurchaseName.Location = new System.Drawing.Point(403, 103);
            this.txtPurchaseName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseName.MaxLength = 15;
            this.txtPurchaseName.Name = "txtPurchaseName";
            this.txtPurchaseName.RightControl = null;
            this.txtPurchaseName.Size = new System.Drawing.Size(210, 27);
            this.txtPurchaseName.TabIndex = 180;
            this.txtPurchaseName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtPurchaseName.UpControl = this.txtPaymentNoTo;
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
            this.clmPaymentNo,
            this.clmPaymentDate,
            this.clmCustomerName});
            this.grdSearchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdSearchList.EnableHeadersVisualStyles = false;
            this.grdSearchList.Location = new System.Drawing.Point(3, 5);
            this.grdSearchList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSearchList.MultiSelect = false;
            this.grdSearchList.Name = "grdSearchList";
            this.grdSearchList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(1002, 287);
            this.grdSearchList.TabIndex = 200;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmPaymentNo
            // 
            this.clmPaymentNo.DataPropertyName = "shiharaiNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmPaymentNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmPaymentNo.HeaderText = "支払NO";
            this.clmPaymentNo.Name = "clmPaymentNo";
            this.clmPaymentNo.ReadOnly = true;
            this.clmPaymentNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmPaymentDate
            // 
            this.clmPaymentDate.DataPropertyName = "shiharaiHizuke";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.clmPaymentDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmPaymentDate.HeaderText = "支払日付";
            this.clmPaymentDate.Name = "clmPaymentDate";
            this.clmPaymentDate.ReadOnly = true;
            this.clmPaymentDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPaymentDate.Width = 160;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.DataPropertyName = "shiresakiName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmCustomerName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmCustomerName.HeaderText = "仕入先名";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerName.Width = 249;
            // 
            // txtPurchaseCode
            // 
            this.txtPurchaseCode.BeforeValue = "";
            this.txtPurchaseCode.DownControl = this.grdSearchList;
            this.txtPurchaseCode.EnterControl = this.txtPurchaseName;
            this.txtPurchaseCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseCode.LabelControl = null;
            this.txtPurchaseCode.LeftControl = null;
            this.txtPurchaseCode.Location = new System.Drawing.Point(133, 103);
            this.txtPurchaseCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseCode.MaxLength = 3;
            this.txtPurchaseCode.Name = "txtPurchaseCode";
            this.txtPurchaseCode.RightControl = this.txtPurchaseName;
            this.txtPurchaseCode.Size = new System.Drawing.Size(130, 27);
            this.txtPurchaseCode.TabIndex = 170;
            this.txtPurchaseCode.Text = "XXXXXXX8";
            this.txtPurchaseCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseCode.UpControl = this.txtPaymentNoFrom;
            // 
            // txtPaymentNoFrom
            // 
            this.txtPaymentNoFrom.BeforeValue = "";
            this.txtPaymentNoFrom.DownControl = this.txtPurchaseCode;
            this.txtPaymentNoFrom.EnterControl = this.txtPaymentNoTo;
            this.txtPaymentNoFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentNoFrom.LabelControl = null;
            this.txtPaymentNoFrom.LeftControl = null;
            this.txtPaymentNoFrom.Location = new System.Drawing.Point(133, 75);
            this.txtPaymentNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentNoFrom.MaxLength = 8;
            this.txtPaymentNoFrom.Name = "txtPaymentNoFrom";
            this.txtPaymentNoFrom.RightControl = this.txtPaymentNoTo;
            this.txtPaymentNoFrom.Size = new System.Drawing.Size(130, 27);
            this.txtPaymentNoFrom.TabIndex = 50;
            this.txtPaymentNoFrom.Text = "XXXXXXX8";
            this.txtPaymentNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentNoFrom.UpControl = null;
            // 
            // txtPaymentNoTo
            // 
            this.txtPaymentNoTo.BeforeValue = "";
            this.txtPaymentNoTo.DownControl = this.txtPurchaseCode;
            this.txtPaymentNoTo.EnterControl = this.txtPaymentDateFromYears;
            this.txtPaymentNoTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentNoTo.LabelControl = null;
            this.txtPaymentNoTo.LeftControl = this.txtPaymentNoFrom;
            this.txtPaymentNoTo.Location = new System.Drawing.Point(306, 75);
            this.txtPaymentNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentNoTo.MaxLength = 8;
            this.txtPaymentNoTo.Name = "txtPaymentNoTo";
            this.txtPaymentNoTo.RightControl = this.txtPaymentDateFromYears;
            this.txtPaymentNoTo.Size = new System.Drawing.Size(130, 27);
            this.txtPaymentNoTo.TabIndex = 60;
            this.txtPaymentNoTo.Text = "XXXXXXX8";
            this.txtPaymentNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentNoTo.UpControl = null;
            // 
            // txtPaymentDateFromYears
            // 
            this.txtPaymentDateFromYears.BeforeValue = "";
            this.txtPaymentDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateFromYears.DownControl = this.txtPurchaseName;
            this.txtPaymentDateFromYears.EnterControl = this.txtPaymentDateFromMonth;
            this.txtPaymentDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateFromYears.LabelControl = null;
            this.txtPaymentDateFromYears.LeftControl = this.txtPaymentNoTo;
            this.txtPaymentDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtPaymentDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateFromYears.MaxLength = 4;
            this.txtPaymentDateFromYears.Name = "txtPaymentDateFromYears";
            this.txtPaymentDateFromYears.RightControl = this.txtPaymentDateFromMonth;
            this.txtPaymentDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtPaymentDateFromYears.TabIndex = 80;
            this.txtPaymentDateFromYears.Text = "1234";
            this.txtPaymentDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateFromYears.UpControl = null;
            // 
            // txtPaymentDateFromMonth
            // 
            this.txtPaymentDateFromMonth.BeforeValue = "";
            this.txtPaymentDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateFromMonth.DownControl = this.txtPurchaseName;
            this.txtPaymentDateFromMonth.EnterControl = this.txtPaymentDateFromDays;
            this.txtPaymentDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateFromMonth.LabelControl = null;
            this.txtPaymentDateFromMonth.LeftControl = this.txtPaymentDateFromYears;
            this.txtPaymentDateFromMonth.Location = new System.Drawing.Point(66, 3);
            this.txtPaymentDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateFromMonth.MaxLength = 2;
            this.txtPaymentDateFromMonth.Name = "txtPaymentDateFromMonth";
            this.txtPaymentDateFromMonth.RightControl = this.txtPaymentDateFromDays;
            this.txtPaymentDateFromMonth.Size = new System.Drawing.Size(30, 20);
            this.txtPaymentDateFromMonth.TabIndex = 90;
            this.txtPaymentDateFromMonth.Text = "12";
            this.txtPaymentDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateFromMonth.UpControl = null;
            // 
            // txtPaymentDateFromDays
            // 
            this.txtPaymentDateFromDays.BeforeValue = "";
            this.txtPaymentDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateFromDays.DownControl = this.txtPurchaseName;
            this.txtPaymentDateFromDays.EnterControl = null;
            this.txtPaymentDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateFromDays.LabelControl = null;
            this.txtPaymentDateFromDays.LeftControl = this.txtPaymentDateFromMonth;
            this.txtPaymentDateFromDays.Location = new System.Drawing.Point(115, 3);
            this.txtPaymentDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateFromDays.MaxLength = 2;
            this.txtPaymentDateFromDays.Name = "txtPaymentDateFromDays";
            this.txtPaymentDateFromDays.RightControl = null;
            this.txtPaymentDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtPaymentDateFromDays.TabIndex = 100;
            this.txtPaymentDateFromDays.Text = "12";
            this.txtPaymentDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateFromDays.UpControl = null;
            // 
            // txtPaymentDateToMonth
            // 
            this.txtPaymentDateToMonth.BeforeValue = "";
            this.txtPaymentDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateToMonth.DownControl = this.txtPurchaseName;
            this.txtPaymentDateToMonth.EnterControl = this.txtPaymentDateToDays;
            this.txtPaymentDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateToMonth.LabelControl = null;
            this.txtPaymentDateToMonth.LeftControl = this.txtPaymentDateToYears;
            this.txtPaymentDateToMonth.Location = new System.Drawing.Point(68, 3);
            this.txtPaymentDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateToMonth.MaxLength = 2;
            this.txtPaymentDateToMonth.Name = "txtPaymentDateToMonth";
            this.txtPaymentDateToMonth.RightControl = this.txtPaymentDateToDays;
            this.txtPaymentDateToMonth.Size = new System.Drawing.Size(30, 20);
            this.txtPaymentDateToMonth.TabIndex = 140;
            this.txtPaymentDateToMonth.Text = "12";
            this.txtPaymentDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateToMonth.UpControl = null;
            // 
            // txtPaymentDateToYears
            // 
            this.txtPaymentDateToYears.BeforeValue = "";
            this.txtPaymentDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentDateToYears.DownControl = this.txtPurchaseName;
            this.txtPaymentDateToYears.EnterControl = this.txtPaymentDateToMonth;
            this.txtPaymentDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPaymentDateToYears.LabelControl = null;
            this.txtPaymentDateToYears.LeftControl = this.txtPaymentDateFromDays;
            this.txtPaymentDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtPaymentDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPaymentDateToYears.MaxLength = 4;
            this.txtPaymentDateToYears.Name = "txtPaymentDateToYears";
            this.txtPaymentDateToYears.RightControl = this.txtPaymentDateToMonth;
            this.txtPaymentDateToYears.Size = new System.Drawing.Size(45, 20);
            this.txtPaymentDateToYears.TabIndex = 130;
            this.txtPaymentDateToYears.Text = "1234";
            this.txtPaymentDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentDateToYears.UpControl = null;
            // 
            // lblPaymentDateToMonth
            // 
            this.lblPaymentDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblPaymentDateToMonth.Name = "lblPaymentDateToMonth";
            this.lblPaymentDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateToMonth.TabIndex = 117;
            this.lblPaymentDateToMonth.Text = "月";
            this.lblPaymentDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDateToYears
            // 
            this.lblPaymentDateToYears.Location = new System.Drawing.Point(44, 0);
            this.lblPaymentDateToYears.Name = "lblPaymentDateToYears";
            this.lblPaymentDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateToYears.TabIndex = 115;
            this.lblPaymentDateToYears.Text = "年";
            this.lblPaymentDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPaymentDateTo
            // 
            this.dtpPaymentDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPaymentDateTo.CustomFormat = " ";
            this.dtpPaymentDateTo.DaysLinkTextControl = this.txtPaymentDateToDays;
            this.dtpPaymentDateTo.DownControl = this.txtPurchaseName;
            this.dtpPaymentDateTo.EnterControl = this.txtPurchaseCode;
            this.dtpPaymentDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPaymentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDateTo.LeftControl = this.txtPaymentDateToDays;
            this.dtpPaymentDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpPaymentDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpPaymentDateTo.MonthLinkTextControl = this.txtPaymentDateToMonth;
            this.dtpPaymentDateTo.Name = "dtpPaymentDateTo";
            this.dtpPaymentDateTo.RightControl = null;
            this.dtpPaymentDateTo.Size = new System.Drawing.Size(211, 27);
            this.dtpPaymentDateTo.TabIndex = 160;
            this.dtpPaymentDateTo.UpControl = null;
            this.dtpPaymentDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpPaymentDateTo.Value2 = null;
            this.dtpPaymentDateTo.YearsLinkTextControl = this.txtPaymentDateToYears;
            // 
            // pnlPaymentDateFrom
            // 
            this.pnlPaymentDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlPaymentDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaymentDateFrom.Controls.Add(this.lblPaymentDateFromDays);
            this.pnlPaymentDateFrom.Controls.Add(this.txtPaymentDateFromDays);
            this.pnlPaymentDateFrom.Controls.Add(this.lblPaymentDateFromMonth);
            this.pnlPaymentDateFrom.Controls.Add(this.txtPaymentDateFromMonth);
            this.pnlPaymentDateFrom.Controls.Add(this.lblDocumentDateFromYears);
            this.pnlPaymentDateFrom.Controls.Add(this.txtPaymentDateFromYears);
            this.pnlPaymentDateFrom.Controls.Add(this.dtpPaymentDateFrom);
            this.pnlPaymentDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlPaymentDateFrom.Location = new System.Drawing.Point(541, 75);
            this.pnlPaymentDateFrom.Name = "pnlPaymentDateFrom";
            this.pnlPaymentDateFrom.Size = new System.Drawing.Size(211, 27);
            this.pnlPaymentDateFrom.TabIndex = 70;
            // 
            // lblPaymentDateFromDays
            // 
            this.lblPaymentDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblPaymentDateFromDays.Name = "lblPaymentDateFromDays";
            this.lblPaymentDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateFromDays.TabIndex = 119;
            this.lblPaymentDateFromDays.Text = "日";
            this.lblPaymentDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDateFromMonth
            // 
            this.lblPaymentDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblPaymentDateFromMonth.Name = "lblPaymentDateFromMonth";
            this.lblPaymentDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblPaymentDateFromMonth.TabIndex = 117;
            this.lblPaymentDateFromMonth.Text = "月";
            this.lblPaymentDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // dtpPaymentDateFrom
            // 
            this.dtpPaymentDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPaymentDateFrom.CustomFormat = " ";
            this.dtpPaymentDateFrom.DaysLinkTextControl = this.txtPaymentDateFromDays;
            this.dtpPaymentDateFrom.DownControl = this.txtPurchaseName;
            this.dtpPaymentDateFrom.EnterControl = this.txtPaymentDateToYears;
            this.dtpPaymentDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPaymentDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDateFrom.LeftControl = this.txtPaymentDateFromDays;
            this.dtpPaymentDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpPaymentDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpPaymentDateFrom.MonthLinkTextControl = this.txtPaymentDateFromMonth;
            this.dtpPaymentDateFrom.Name = "dtpPaymentDateFrom";
            this.dtpPaymentDateFrom.RightControl = this.txtPaymentDateToYears;
            this.dtpPaymentDateFrom.Size = new System.Drawing.Size(211, 27);
            this.dtpPaymentDateFrom.TabIndex = 110;
            this.dtpPaymentDateFrom.UpControl = null;
            this.dtpPaymentDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpPaymentDateFrom.Value2 = null;
            this.dtpPaymentDateFrom.YearsLinkTextControl = this.txtPaymentDateFromYears;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Location = new System.Drawing.Point(270, 78);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 73;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblPaymentNo
            // 
            this.lblPaymentNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPaymentNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPaymentNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPaymentNo.ForeColor = System.Drawing.Color.White;
            this.lblPaymentNo.Location = new System.Drawing.Point(3, 75);
            this.lblPaymentNo.Name = "lblPaymentNo";
            this.lblPaymentNo.Size = new System.Drawing.Size(130, 27);
            this.lblPaymentNo.TabIndex = 72;
            this.lblPaymentNo.Text = "支払NO";
            this.lblPaymentNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.Location = new System.Drawing.Point(759, 79);
            this.lblFromToSeparated2.Name = "lblFromToSeparated2";
            this.lblFromToSeparated2.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated2.TabIndex = 63;
            this.lblFromToSeparated2.Text = "～";
            // 
            // lblPurchaseName
            // 
            this.lblPurchaseName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPurchaseName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPurchaseName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPurchaseName.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseName.Location = new System.Drawing.Point(264, 103);
            this.lblPurchaseName.Name = "lblPurchaseName";
            this.lblPurchaseName.Size = new System.Drawing.Size(139, 27);
            this.lblPurchaseName.TabIndex = 61;
            this.lblPurchaseName.Text = "仕入先名";
            this.lblPurchaseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPurchaseCode
            // 
            this.lblPurchaseCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPurchaseCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPurchaseCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPurchaseCode.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseCode.Location = new System.Drawing.Point(3, 103);
            this.lblPurchaseCode.Name = "lblPurchaseCode";
            this.lblPurchaseCode.Size = new System.Drawing.Size(130, 27);
            this.lblPurchaseCode.TabIndex = 60;
            this.lblPurchaseCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblPurchaseCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPaymentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPaymentDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.White;
            this.lblPaymentDate.Location = new System.Drawing.Point(443, 75);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(98, 27);
            this.lblPaymentDate.TabIndex = 54;
            this.lblPaymentDate.Text = "支払日付";
            this.lblPaymentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlBody.Size = new System.Drawing.Size(1013, 301);
            this.pnlBody.TabIndex = 190;
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
            this.pnlBottom.Size = new System.Drawing.Size(1013, 70);
            this.pnlBottom.TabIndex = 210;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(683, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 523;
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
            this.btnSelectCancel.TabIndex = 240;
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
            this.btnAllSelect.TabIndex = 230;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // sfrmShiharaiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1013, 542);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmShiharaiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "支払検索";
            this.Load += new System.EventHandler(this.sfrmShiharaiSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlPaymentDateTo.ResumeLayout(false);
            this.pnlPaymentDateTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlPaymentDateFrom.ResumeLayout(false);
            this.pnlPaymentDateFrom.PerformLayout();
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
        private Common.ItemHeadLabel lblPaymentDate;
        private Common.ItemHeadLabel lblPurchaseName;
        private Common.ItemHeadLabel lblPurchaseCode;
        private Common.CustomTextBox txtPurchaseCode;
        private Common.CustomTextBox txtPurchaseName;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.CustomTextBox txtPaymentNoTo;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.ItemHeadLabel lblPaymentNo;
        private Common.CustomTextBox txtPaymentNoFrom;
        private System.Windows.Forms.Panel pnlPaymentDateFrom;
        private System.Windows.Forms.Label lblPaymentDateFromDays;
        private Common.CustomTextBox txtPaymentDateFromDays;
        private Common.CustomTextBox txtPaymentDateFromMonth;
        private Common.CustomTextBox txtPaymentDateFromYears;
        private System.Windows.Forms.Label lblPaymentDateFromMonth;
        private System.Windows.Forms.Label lblDocumentDateFromYears;
        private Common.CustomDateTimePicker dtpPaymentDateFrom;
        private System.Windows.Forms.Panel pnlPaymentDateTo;
        private System.Windows.Forms.Label lblPaymentDateToDays;
        private Common.CustomTextBox txtPaymentDateToDays;
        private Common.CustomTextBox txtPaymentDateToMonth;
        private Common.CustomTextBox txtPaymentDateToYears;
        private System.Windows.Forms.Label lblPaymentDateToMonth;
        private System.Windows.Forms.Label lblPaymentDateToYears;
        private Common.CustomDateTimePicker dtpPaymentDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.RadioButton rdoAsc;
        private System.Windows.Forms.RadioButton rdoDesc;
        private Common.FeaturesButton btnCancel;
    }
}