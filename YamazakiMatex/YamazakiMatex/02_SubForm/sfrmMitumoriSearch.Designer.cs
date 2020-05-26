namespace SubForm
{
    partial class sfrmMitumoriSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtEstimateNoFrom = new Common.CustomTextBox();
            this.txtEstimateDateFromYears = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtSubject1 = new Common.CustomTextBox();
            this.grdSearchList = new Common.CustomDataGridView();
            this.clmEstimateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEstimateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubject2 = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.txtEstimateDateToYears = new Common.CustomTextBox();
            this.txtEstimateDateToMonth = new Common.CustomTextBox();
            this.txtEstimateDateToDays = new Common.CustomTextBox();
            this.txtEstimateNoTo = new Common.CustomTextBox();
            this.txtEstimateDateFromDays = new Common.CustomTextBox();
            this.txtEstimateDateFromMonth = new Common.CustomTextBox();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPersonnel = new Common.ItemHeadLabel();
            this.cmbPersonnel = new Common.CustomComboBox();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.rdoAsc = new System.Windows.Forms.RadioButton();
            this.rdoDesc = new System.Windows.Forms.RadioButton();
            this.lblSubject = new Common.ItemHeadLabel();
            this.pnlEstimateDateTo = new System.Windows.Forms.Panel();
            this.lblEstimateDateToDays = new System.Windows.Forms.Label();
            this.lblEstimateDateToMonth = new System.Windows.Forms.Label();
            this.lblEstimateDateToYears = new System.Windows.Forms.Label();
            this.dtpEstimateDateTo = new Common.CustomDateTimePicker();
            this.pnlEstimateDateFrom = new System.Windows.Forms.Panel();
            this.lblEstimateDateFromDays = new System.Windows.Forms.Label();
            this.lblEstimateDateFromMonth = new System.Windows.Forms.Label();
            this.lblEstimateDateFromYears = new System.Windows.Forms.Label();
            this.dtpEstimateDateFrom = new Common.CustomDateTimePicker();
            this.lblCustomerCanaName = new Common.ItemHeadLabel();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblCustomerCharactersName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblEstimateDate = new Common.ItemHeadLabel();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.lblEstimateNo = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSelectCancel = new Common.FeaturesButton();
            this.btnAllSelect = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlEstimateDateTo.SuspendLayout();
            this.pnlEstimateDateFrom.SuspendLayout();
            this.pnlRowSelectMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEstimateNoFrom
            // 
            this.txtEstimateNoFrom.BeforeValue = "";
            this.txtEstimateNoFrom.DownControl = this.txtEstimateDateFromYears;
            this.txtEstimateNoFrom.EnterControl = this.txtEstimateNoTo;
            this.txtEstimateNoFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateNoFrom.LabelControl = null;
            this.txtEstimateNoFrom.LeftControl = null;
            this.txtEstimateNoFrom.Location = new System.Drawing.Point(133, 79);
            this.txtEstimateNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateNoFrom.Name = "txtEstimateNoFrom";
            this.txtEstimateNoFrom.RightControl = this.txtEstimateNoTo;
            this.txtEstimateNoFrom.Size = new System.Drawing.Size(228, 27);
            this.txtEstimateNoFrom.TabIndex = 50;
            this.txtEstimateNoFrom.Text = "XXXXXXX8";
            this.txtEstimateNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateNoFrom.UpControl = null;
            this.txtEstimateNoFrom.Leave += new System.EventHandler(this.txtEstimateNo_Leave);
            // 
            // txtEstimateDateFromYears
            // 
            this.txtEstimateDateFromYears.BeforeValue = "";
            this.txtEstimateDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateFromYears.DownControl = this.txtCustomerCode;
            this.txtEstimateDateFromYears.EnterControl = this.txtEstimateDateFromMonth;
            this.txtEstimateDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateFromYears.LabelControl = null;
            this.txtEstimateDateFromYears.LeftControl = null;
            this.txtEstimateDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtEstimateDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateFromYears.Name = "txtEstimateDateFromYears";
            this.txtEstimateDateFromYears.RightControl = this.txtEstimateDateFromMonth;
            this.txtEstimateDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtEstimateDateFromYears.TabIndex = 80;
            this.txtEstimateDateFromYears.Text = "1234";
            this.txtEstimateDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateFromYears.UpControl = this.txtEstimateNoFrom;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.txtSubject1;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(133, 135);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 170;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtEstimateDateFromYears;
            // 
            // txtSubject1
            // 
            this.txtSubject1.BeforeValue = "";
            this.txtSubject1.DownControl = this.grdSearchList;
            this.txtSubject1.EnterControl = this.txtSubject2;
            this.txtSubject1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject1.LabelControl = null;
            this.txtSubject1.LeftControl = null;
            this.txtSubject1.Location = new System.Drawing.Point(133, 163);
            this.txtSubject1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject1.Name = "txtSubject1";
            this.txtSubject1.RightControl = this.txtSubject2;
            this.txtSubject1.Size = new System.Drawing.Size(420, 27);
            this.txtSubject1.TabIndex = 200;
            this.txtSubject1.Text = "令令令令令令令令令令令令令令令令令令令令";
            this.txtSubject1.UpControl = this.txtCustomerCode;
            // 
            // grdSearchList
            // 
            this.grdSearchList.AllowUserToAddRows = false;
            this.grdSearchList.AllowUserToDeleteRows = false;
            this.grdSearchList.AllowUserToResizeColumns = false;
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
            this.clmEstimateNo,
            this.clmEstimateDate,
            this.clmCustomerName,
            this.clmSubject,
            this.clmAmount});
            this.grdSearchList.DownControl = null;
            this.grdSearchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdSearchList.EnableHeadersVisualStyles = false;
            this.grdSearchList.EnterControl = null;
            this.grdSearchList.FlgSetCurrentCell = true;
            this.grdSearchList.LeftControl = null;
            this.grdSearchList.Location = new System.Drawing.Point(3, 5);
            this.grdSearchList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSearchList.MultiSelect = false;
            this.grdSearchList.Name = "grdSearchList";
            this.grdSearchList.RightControl = null;
            this.grdSearchList.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdSearchList.RowSegmentCount = 1;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.ScrollRowCount = 3;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(970, 287);
            this.grdSearchList.TabIndex = 230;
            this.grdSearchList.UpControl = this.txtCustomerCode;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmEstimateNo
            // 
            this.clmEstimateNo.DataPropertyName = "mitumoriNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmEstimateNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmEstimateNo.HeaderText = "見積NO";
            this.clmEstimateNo.Name = "clmEstimateNo";
            this.clmEstimateNo.ReadOnly = true;
            this.clmEstimateNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmEstimateNo.Width = 130;
            // 
            // clmEstimateDate
            // 
            this.clmEstimateDate.DataPropertyName = "mitumoriHizuke";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.clmEstimateDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmEstimateDate.HeaderText = "見積日付";
            this.clmEstimateDate.Name = "clmEstimateDate";
            this.clmEstimateDate.ReadOnly = true;
            this.clmEstimateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmEstimateDate.Width = 160;
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
            this.clmCustomerName.Width = 220;
            // 
            // clmSubject
            // 
            this.clmSubject.DataPropertyName = "kenmei1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmSubject.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmSubject.HeaderText = "件名";
            this.clmSubject.Name = "clmSubject";
            this.clmSubject.ReadOnly = true;
            this.clmSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubject.Width = 280;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "kingaku";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmAmount.HeaderText = "税抜見積金額";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.ReadOnly = true;
            this.clmAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmAmount.Width = 160;
            // 
            // txtSubject2
            // 
            this.txtSubject2.BeforeValue = "";
            this.txtSubject2.DownControl = this.grdSearchList;
            this.txtSubject2.EnterControl = this.grdSearchList;
            this.txtSubject2.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject2.LabelControl = null;
            this.txtSubject2.LeftControl = this.txtSubject1;
            this.txtSubject2.Location = new System.Drawing.Point(552, 163);
            this.txtSubject2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject2.Name = "txtSubject2";
            this.txtSubject2.RightControl = null;
            this.txtSubject2.Size = new System.Drawing.Size(420, 27);
            this.txtSubject2.TabIndex = 210;
            this.txtSubject2.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０";
            this.txtSubject2.UpControl = this.txtCustomerName;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.txtSubject1;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(414, 135);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(228, 27);
            this.txtCustomerName.TabIndex = 180;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtEstimateDateToYears;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.txtSubject2;
            this.txtCustomerKanaName.EnterControl = this.txtSubject1;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(730, 135);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = null;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(242, 27);
            this.txtCustomerKanaName.TabIndex = 190;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerKanaName.UpControl = null;
            // 
            // txtEstimateDateToYears
            // 
            this.txtEstimateDateToYears.BeforeValue = "";
            this.txtEstimateDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateToYears.DownControl = this.txtCustomerName;
            this.txtEstimateDateToYears.EnterControl = this.txtEstimateDateToMonth;
            this.txtEstimateDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateToYears.LabelControl = null;
            this.txtEstimateDateToYears.LeftControl = this.txtEstimateDateFromDays;
            this.txtEstimateDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtEstimateDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateToYears.Name = "txtEstimateDateToYears";
            this.txtEstimateDateToYears.RightControl = this.txtEstimateDateToMonth;
            this.txtEstimateDateToYears.Size = new System.Drawing.Size(45, 20);
            this.txtEstimateDateToYears.TabIndex = 130;
            this.txtEstimateDateToYears.Text = "1234";
            this.txtEstimateDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateToYears.UpControl = this.txtEstimateNoTo;
            // 
            // txtEstimateDateToMonth
            // 
            this.txtEstimateDateToMonth.BeforeValue = "";
            this.txtEstimateDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateToMonth.DownControl = this.txtCustomerName;
            this.txtEstimateDateToMonth.EnterControl = this.txtEstimateDateToDays;
            this.txtEstimateDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateToMonth.LabelControl = null;
            this.txtEstimateDateToMonth.LeftControl = this.txtEstimateDateToYears;
            this.txtEstimateDateToMonth.Location = new System.Drawing.Point(68, 3);
            this.txtEstimateDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateToMonth.Name = "txtEstimateDateToMonth";
            this.txtEstimateDateToMonth.RightControl = this.txtEstimateDateToDays;
            this.txtEstimateDateToMonth.Size = new System.Drawing.Size(30, 20);
            this.txtEstimateDateToMonth.TabIndex = 140;
            this.txtEstimateDateToMonth.Text = "12";
            this.txtEstimateDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateToMonth.UpControl = this.txtEstimateNoTo;
            // 
            // txtEstimateDateToDays
            // 
            this.txtEstimateDateToDays.BeforeValue = "";
            this.txtEstimateDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateToDays.DownControl = this.txtCustomerName;
            this.txtEstimateDateToDays.EnterControl = this.txtCustomerCode;
            this.txtEstimateDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateToDays.LabelControl = null;
            this.txtEstimateDateToDays.LeftControl = this.txtEstimateDateToMonth;
            this.txtEstimateDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtEstimateDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateToDays.Name = "txtEstimateDateToDays";
            this.txtEstimateDateToDays.RightControl = null;
            this.txtEstimateDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtEstimateDateToDays.TabIndex = 150;
            this.txtEstimateDateToDays.Text = "12";
            this.txtEstimateDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateToDays.UpControl = this.txtEstimateNoTo;
            // 
            // txtEstimateNoTo
            // 
            this.txtEstimateNoTo.BeforeValue = "";
            this.txtEstimateNoTo.DownControl = this.txtEstimateDateToYears;
            this.txtEstimateNoTo.EnterControl = this.txtEstimateDateFromYears;
            this.txtEstimateNoTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateNoTo.LabelControl = null;
            this.txtEstimateNoTo.LeftControl = this.txtEstimateNoFrom;
            this.txtEstimateNoTo.Location = new System.Drawing.Point(414, 79);
            this.txtEstimateNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateNoTo.Name = "txtEstimateNoTo";
            this.txtEstimateNoTo.RightControl = null;
            this.txtEstimateNoTo.Size = new System.Drawing.Size(228, 27);
            this.txtEstimateNoTo.TabIndex = 60;
            this.txtEstimateNoTo.Text = "XXXXXXX8";
            this.txtEstimateNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateNoTo.UpControl = null;
            this.txtEstimateNoTo.Leave += new System.EventHandler(this.txtEstimateNo_Leave);
            // 
            // txtEstimateDateFromDays
            // 
            this.txtEstimateDateFromDays.BeforeValue = "";
            this.txtEstimateDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateFromDays.DownControl = this.txtCustomerCode;
            this.txtEstimateDateFromDays.EnterControl = this.txtEstimateDateToYears;
            this.txtEstimateDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateFromDays.LabelControl = null;
            this.txtEstimateDateFromDays.LeftControl = this.txtEstimateDateFromMonth;
            this.txtEstimateDateFromDays.Location = new System.Drawing.Point(115, 3);
            this.txtEstimateDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateFromDays.Name = "txtEstimateDateFromDays";
            this.txtEstimateDateFromDays.RightControl = this.txtEstimateDateToYears;
            this.txtEstimateDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtEstimateDateFromDays.TabIndex = 100;
            this.txtEstimateDateFromDays.Text = "12";
            this.txtEstimateDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateFromDays.UpControl = this.txtEstimateNoFrom;
            // 
            // txtEstimateDateFromMonth
            // 
            this.txtEstimateDateFromMonth.BeforeValue = "";
            this.txtEstimateDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimateDateFromMonth.DownControl = this.txtCustomerCode;
            this.txtEstimateDateFromMonth.EnterControl = this.txtEstimateDateFromDays;
            this.txtEstimateDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtEstimateDateFromMonth.LabelControl = null;
            this.txtEstimateDateFromMonth.LeftControl = this.txtEstimateDateFromYears;
            this.txtEstimateDateFromMonth.Location = new System.Drawing.Point(66, 3);
            this.txtEstimateDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateDateFromMonth.Name = "txtEstimateDateFromMonth";
            this.txtEstimateDateFromMonth.RightControl = this.txtEstimateDateFromDays;
            this.txtEstimateDateFromMonth.Size = new System.Drawing.Size(30, 20);
            this.txtEstimateDateFromMonth.TabIndex = 90;
            this.txtEstimateDateFromMonth.Text = "12";
            this.txtEstimateDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateFromMonth.UpControl = this.txtEstimateNoFrom;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 250;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(761, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 280;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(871, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 290;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblPersonnel);
            this.pnlHeader.Controls.Add(this.cmbPersonnel);
            this.pnlHeader.Controls.Add(this.pnlOrder);
            this.pnlHeader.Controls.Add(this.lblSubject);
            this.pnlHeader.Controls.Add(this.txtSubject1);
            this.pnlHeader.Controls.Add(this.pnlEstimateDateTo);
            this.pnlHeader.Controls.Add(this.pnlEstimateDateFrom);
            this.pnlHeader.Controls.Add(this.txtSubject2);
            this.pnlHeader.Controls.Add(this.lblCustomerCanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblCustomerCharactersName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.txtEstimateNoTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblEstimateDate);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Controls.Add(this.lblEstimateNo);
            this.pnlHeader.Controls.Add(this.txtEstimateNoFrom);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 230);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblPersonnel.Location = new System.Drawing.Point(643, 79);
            this.lblPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(87, 27);
            this.lblPersonnel.TabIndex = 255;
            this.lblPersonnel.Text = "担当者";
            this.lblPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.BeforeSelectedValue = "";
            this.cmbPersonnel.DownControl = this.txtCustomerKanaName;
            this.cmbPersonnel.EnterControl = this.txtCustomerCode;
            this.cmbPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.LabelControl = null;
            this.cmbPersonnel.LeftControl = null;
            this.cmbPersonnel.Location = new System.Drawing.Point(730, 79);
            this.cmbPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.RightControl = null;
            this.cmbPersonnel.Size = new System.Drawing.Size(146, 27);
            this.cmbPersonnel.TabIndex = 256;
            this.cmbPersonnel.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPersonnel.UpControl = null;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.rdoAsc);
            this.pnlOrder.Controls.Add(this.rdoDesc);
            this.pnlOrder.Location = new System.Drawing.Point(3, 193);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(418, 30);
            this.pnlOrder.TabIndex = 254;
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
            this.rdoAsc.Text = "見積日付の昇順";
            this.rdoAsc.UseVisualStyleBackColor = true;
            // 
            // rdoDesc
            // 
            this.rdoDesc.AutoSize = true;
            this.rdoDesc.Location = new System.Drawing.Point(172, 3);
            this.rdoDesc.Name = "rdoDesc";
            this.rdoDesc.Size = new System.Drawing.Size(163, 24);
            this.rdoDesc.TabIndex = 252;
            this.rdoDesc.Text = "見積日付の降順";
            this.rdoDesc.UseVisualStyleBackColor = true;
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubject.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(3, 163);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(130, 27);
            this.lblSubject.TabIndex = 191;
            this.lblSubject.Text = "件名";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEstimateDateTo
            // 
            this.pnlEstimateDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlEstimateDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstimateDateTo.Controls.Add(this.lblEstimateDateToDays);
            this.pnlEstimateDateTo.Controls.Add(this.txtEstimateDateToDays);
            this.pnlEstimateDateTo.Controls.Add(this.lblEstimateDateToMonth);
            this.pnlEstimateDateTo.Controls.Add(this.txtEstimateDateToMonth);
            this.pnlEstimateDateTo.Controls.Add(this.lblEstimateDateToYears);
            this.pnlEstimateDateTo.Controls.Add(this.txtEstimateDateToYears);
            this.pnlEstimateDateTo.Controls.Add(this.dtpEstimateDateTo);
            this.pnlEstimateDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlEstimateDateTo.Location = new System.Drawing.Point(414, 107);
            this.pnlEstimateDateTo.Name = "pnlEstimateDateTo";
            this.pnlEstimateDateTo.Size = new System.Drawing.Size(228, 27);
            this.pnlEstimateDateTo.TabIndex = 120;
            // 
            // lblEstimateDateToDays
            // 
            this.lblEstimateDateToDays.Location = new System.Drawing.Point(148, 0);
            this.lblEstimateDateToDays.Name = "lblEstimateDateToDays";
            this.lblEstimateDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDateToDays.TabIndex = 119;
            this.lblEstimateDateToDays.Text = "日";
            this.lblEstimateDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateDateToMonth
            // 
            this.lblEstimateDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblEstimateDateToMonth.Name = "lblEstimateDateToMonth";
            this.lblEstimateDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDateToMonth.TabIndex = 117;
            this.lblEstimateDateToMonth.Text = "月";
            this.lblEstimateDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateDateToYears
            // 
            this.lblEstimateDateToYears.Location = new System.Drawing.Point(44, 0);
            this.lblEstimateDateToYears.Name = "lblEstimateDateToYears";
            this.lblEstimateDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDateToYears.TabIndex = 115;
            this.lblEstimateDateToYears.Text = "年";
            this.lblEstimateDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEstimateDateTo
            // 
            this.dtpEstimateDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpEstimateDateTo.CustomFormat = " ";
            this.dtpEstimateDateTo.DaysLinkTextControl = this.txtEstimateDateToDays;
            this.dtpEstimateDateTo.DownControl = this.txtCustomerName;
            this.dtpEstimateDateTo.EnterControl = this.txtCustomerCode;
            this.dtpEstimateDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpEstimateDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEstimateDateTo.LeftControl = this.txtEstimateDateToDays;
            this.dtpEstimateDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpEstimateDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEstimateDateTo.MonthLinkTextControl = this.txtEstimateDateToMonth;
            this.dtpEstimateDateTo.Name = "dtpEstimateDateTo";
            this.dtpEstimateDateTo.RightControl = null;
            this.dtpEstimateDateTo.Size = new System.Drawing.Size(228, 27);
            this.dtpEstimateDateTo.TabIndex = 160;
            this.dtpEstimateDateTo.UpControl = this.txtEstimateNoTo;
            this.dtpEstimateDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpEstimateDateTo.Value2 = null;
            this.dtpEstimateDateTo.YearsLinkTextControl = this.txtEstimateDateToYears;
            // 
            // pnlEstimateDateFrom
            // 
            this.pnlEstimateDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlEstimateDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstimateDateFrom.Controls.Add(this.lblEstimateDateFromDays);
            this.pnlEstimateDateFrom.Controls.Add(this.txtEstimateDateFromDays);
            this.pnlEstimateDateFrom.Controls.Add(this.lblEstimateDateFromMonth);
            this.pnlEstimateDateFrom.Controls.Add(this.txtEstimateDateFromMonth);
            this.pnlEstimateDateFrom.Controls.Add(this.lblEstimateDateFromYears);
            this.pnlEstimateDateFrom.Controls.Add(this.txtEstimateDateFromYears);
            this.pnlEstimateDateFrom.Controls.Add(this.dtpEstimateDateFrom);
            this.pnlEstimateDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlEstimateDateFrom.Location = new System.Drawing.Point(133, 107);
            this.pnlEstimateDateFrom.Name = "pnlEstimateDateFrom";
            this.pnlEstimateDateFrom.Size = new System.Drawing.Size(228, 27);
            this.pnlEstimateDateFrom.TabIndex = 70;
            // 
            // lblEstimateDateFromDays
            // 
            this.lblEstimateDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblEstimateDateFromDays.Name = "lblEstimateDateFromDays";
            this.lblEstimateDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDateFromDays.TabIndex = 119;
            this.lblEstimateDateFromDays.Text = "日";
            this.lblEstimateDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateDateFromMonth
            // 
            this.lblEstimateDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblEstimateDateFromMonth.Name = "lblEstimateDateFromMonth";
            this.lblEstimateDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDateFromMonth.TabIndex = 117;
            this.lblEstimateDateFromMonth.Text = "月";
            this.lblEstimateDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateDateFromYears
            // 
            this.lblEstimateDateFromYears.Location = new System.Drawing.Point(44, 0);
            this.lblEstimateDateFromYears.Name = "lblEstimateDateFromYears";
            this.lblEstimateDateFromYears.Size = new System.Drawing.Size(28, 27);
            this.lblEstimateDateFromYears.TabIndex = 115;
            this.lblEstimateDateFromYears.Text = "年";
            this.lblEstimateDateFromYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEstimateDateFrom
            // 
            this.dtpEstimateDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpEstimateDateFrom.CustomFormat = " ";
            this.dtpEstimateDateFrom.DaysLinkTextControl = this.txtEstimateDateFromDays;
            this.dtpEstimateDateFrom.DownControl = this.txtCustomerCode;
            this.dtpEstimateDateFrom.EnterControl = this.txtEstimateDateToYears;
            this.dtpEstimateDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpEstimateDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEstimateDateFrom.LeftControl = this.txtEstimateDateFromDays;
            this.dtpEstimateDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpEstimateDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEstimateDateFrom.MonthLinkTextControl = this.txtEstimateDateFromMonth;
            this.dtpEstimateDateFrom.Name = "dtpEstimateDateFrom";
            this.dtpEstimateDateFrom.RightControl = this.txtEstimateDateToYears;
            this.dtpEstimateDateFrom.Size = new System.Drawing.Size(228, 27);
            this.dtpEstimateDateFrom.TabIndex = 110;
            this.dtpEstimateDateFrom.UpControl = this.txtEstimateNoFrom;
            this.dtpEstimateDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpEstimateDateFrom.Value2 = null;
            this.dtpEstimateDateFrom.YearsLinkTextControl = this.txtEstimateDateFromYears;
            // 
            // lblCustomerCanaName
            // 
            this.lblCustomerCanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCanaName.Location = new System.Drawing.Point(643, 135);
            this.lblCustomerCanaName.Name = "lblCustomerCanaName";
            this.lblCustomerCanaName.Size = new System.Drawing.Size(87, 27);
            this.lblCustomerCanaName.TabIndex = 68;
            this.lblCustomerCanaName.Text = "カナ名";
            this.lblCustomerCanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated2.Location = new System.Drawing.Point(373, 110);
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
            this.lblCustomerCharactersName.Location = new System.Drawing.Point(264, 135);
            this.lblCustomerCharactersName.Name = "lblCustomerCharactersName";
            this.lblCustomerCharactersName.Size = new System.Drawing.Size(150, 27);
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
            this.lblCustomerCode.Location = new System.Drawing.Point(3, 135);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 60;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated1.Location = new System.Drawing.Point(373, 82);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 56;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblEstimateDate
            // 
            this.lblEstimateDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEstimateDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstimateDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateDate.ForeColor = System.Drawing.Color.White;
            this.lblEstimateDate.Location = new System.Drawing.Point(3, 107);
            this.lblEstimateDate.Name = "lblEstimateDate";
            this.lblEstimateDate.Size = new System.Drawing.Size(130, 27);
            this.lblEstimateDate.TabIndex = 54;
            this.lblEstimateDate.Text = "見積日付";
            this.lblEstimateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblEstimateNo
            // 
            this.lblEstimateNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEstimateNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstimateNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateNo.ForeColor = System.Drawing.Color.White;
            this.lblEstimateNo.Location = new System.Drawing.Point(3, 79);
            this.lblEstimateNo.Name = "lblEstimateNo";
            this.lblEstimateNo.Size = new System.Drawing.Size(130, 27);
            this.lblEstimateNo.TabIndex = 3;
            this.lblEstimateNo.Text = "見積NO";
            this.lblEstimateNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 230);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(980, 301);
            this.pnlBody.TabIndex = 220;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 531);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(980, 70);
            this.pnlBottom.TabIndex = 240;
            // 
            // btnSelectCancel
            // 
            this.btnSelectCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectCancel.Location = new System.Drawing.Point(223, 15);
            this.btnSelectCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCancel.Name = "btnSelectCancel";
            this.btnSelectCancel.Size = new System.Drawing.Size(102, 40);
            this.btnSelectCancel.TabIndex = 270;
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
            this.btnAllSelect.TabIndex = 260;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(651, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 333;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sfrmMitumoriSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(980, 602);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmMitumoriSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "見積検索";
            this.Load += new System.EventHandler(this.sfrmMitumoriSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlEstimateDateTo.ResumeLayout(false);
            this.pnlEstimateDateTo.PerformLayout();
            this.pnlEstimateDateFrom.ResumeLayout(false);
            this.pnlEstimateDateFrom.PerformLayout();
            this.pnlRowSelectMode.ResumeLayout(false);
            this.pnlRowSelectMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.CustomTextBox txtEstimateNoFrom;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnCheck;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdSearchList;
        private Common.ItemHeadLabel lblEstimateNo;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblEstimateDate;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.ItemHeadLabel lblCustomerCharactersName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomTextBox txtEstimateNoTo;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.ItemHeadLabel lblCustomerCanaName;
        private Common.CustomTextBox txtCustomerKanaName;
        private System.Windows.Forms.Panel pnlEstimateDateFrom;
        private System.Windows.Forms.Label lblEstimateDateFromDays;
        private Common.CustomTextBox txtEstimateDateFromDays;
        private Common.CustomTextBox txtEstimateDateFromMonth;
        private Common.CustomTextBox txtEstimateDateFromYears;
        private System.Windows.Forms.Label lblEstimateDateFromMonth;
        private System.Windows.Forms.Label lblEstimateDateFromYears;
        private Common.CustomDateTimePicker dtpEstimateDateFrom;
        private System.Windows.Forms.Panel pnlEstimateDateTo;
        private System.Windows.Forms.Label lblEstimateDateToDays;
        private Common.CustomTextBox txtEstimateDateToDays;
        private Common.CustomTextBox txtEstimateDateToMonth;
        private Common.CustomTextBox txtEstimateDateToYears;
        private System.Windows.Forms.Label lblEstimateDateToMonth;
        private System.Windows.Forms.Label lblEstimateDateToYears;
        private Common.CustomDateTimePicker dtpEstimateDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEstimateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEstimateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private Common.ItemHeadLabel lblSubject;
        private Common.CustomTextBox txtSubject1;
        private Common.CustomTextBox txtSubject2;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.RadioButton rdoAsc;
        private System.Windows.Forms.RadioButton rdoDesc;
        private Common.ItemHeadLabel lblPersonnel;
        private Common.CustomComboBox cmbPersonnel;
        private Common.FeaturesButton btnCancel;
    }
}