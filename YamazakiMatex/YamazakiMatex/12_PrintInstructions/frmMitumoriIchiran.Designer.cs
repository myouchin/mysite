namespace PrintInstructions
{
    partial class frmMitumoriIchiran
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtEstimateNoFrom = new Common.CustomTextBox();
            this.txtEstimateDateFromYears = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.grdSearchList = new Common.CustomDataGridView();
            this.clmEstimateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEstimateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.txtEstimateDateToYears = new Common.CustomTextBox();
            this.txtEstimateDateToMonth = new Common.CustomTextBox();
            this.txtEstimateDateToDays = new Common.CustomTextBox();
            this.txtEstimateNoTo = new Common.CustomTextBox();
            this.txtEstimateDateFromDays = new Common.CustomTextBox();
            this.txtEstimateDateFromMonth = new Common.CustomTextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
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
            this.lblEstimateNo = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnDispList = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptMitumoriIchiran1 = new YamazakiMatex.Print.Report.rptMitumoriIchiran();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlEstimateDateTo.SuspendLayout();
            this.pnlEstimateDateFrom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.txtEstimateNoFrom.Location = new System.Drawing.Point(133, 11);
            this.txtEstimateNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateNoFrom.Name = "txtEstimateNoFrom";
            this.txtEstimateNoFrom.RightControl = this.txtEstimateNoTo;
            this.txtEstimateNoFrom.Size = new System.Drawing.Size(228, 27);
            this.txtEstimateNoFrom.TabIndex = 1;
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
            this.txtEstimateDateFromYears.TabIndex = 115;
            this.txtEstimateDateFromYears.Text = "1234";
            this.txtEstimateDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateFromYears.UpControl = this.txtEstimateNoFrom;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.grdSearchList;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(133, 67);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 58;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtEstimateDateFromYears;
            // 
            // grdSearchList
            // 
            this.grdSearchList.AllowUserToAddRows = false;
            this.grdSearchList.AllowUserToDeleteRows = false;
            this.grdSearchList.AllowUserToResizeColumns = false;
            this.grdSearchList.AllowUserToResizeRows = false;
            this.grdSearchList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
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
            this.grdSearchList.ReadOnly = true;
            this.grdSearchList.RightControl = null;
            this.grdSearchList.RowHeadersVisible = false;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.grdSearchList.RowSegmentCount = 1;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.ScrollRowCount = 3;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(970, 287);
            this.grdSearchList.TabIndex = 24;
            this.grdSearchList.UpControl = this.txtCustomerCode;
            // 
            // clmEstimateNo
            // 
            this.clmEstimateNo.DataPropertyName = "mitumoriNo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmEstimateNo.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmEstimateNo.HeaderText = "見積NO";
            this.clmEstimateNo.Name = "clmEstimateNo";
            this.clmEstimateNo.ReadOnly = true;
            this.clmEstimateNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmEstimateNo.Width = 130;
            // 
            // clmEstimateDate
            // 
            this.clmEstimateDate.DataPropertyName = "mitumoriDate";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle10.Format = "D";
            dataGridViewCellStyle10.NullValue = null;
            this.clmEstimateDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmEstimateDate.HeaderText = "見積日付";
            this.clmEstimateDate.Name = "clmEstimateDate";
            this.clmEstimateDate.ReadOnly = true;
            this.clmEstimateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmEstimateDate.Width = 160;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.DataPropertyName = "tokuisakiNm";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmCustomerName.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmCustomerName.HeaderText = "得意先名";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerName.Width = 220;
            // 
            // clmSubject
            // 
            this.clmSubject.DataPropertyName = "kenmei1";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmSubject.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmSubject.HeaderText = "件名";
            this.clmSubject.Name = "clmSubject";
            this.clmSubject.ReadOnly = true;
            this.clmSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubject.Width = 280;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "kingaku";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmAmount.HeaderText = "税抜見積金額";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.ReadOnly = true;
            this.clmAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmAmount.Width = 160;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.grdSearchList;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(414, 67);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 40;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(228, 27);
            this.txtCustomerName.TabIndex = 59;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtEstimateDateToYears;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.grdSearchList;
            this.txtCustomerKanaName.EnterControl = this.grdSearchList;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(730, 67);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.MaxLength = 80;
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = null;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(216, 27);
            this.txtCustomerKanaName.TabIndex = 67;
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
            this.txtEstimateDateToYears.TabIndex = 115;
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
            this.txtEstimateDateToMonth.TabIndex = 116;
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
            this.txtEstimateDateToDays.TabIndex = 118;
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
            this.txtEstimateNoTo.Location = new System.Drawing.Point(414, 11);
            this.txtEstimateNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstimateNoTo.Name = "txtEstimateNoTo";
            this.txtEstimateNoTo.RightControl = null;
            this.txtEstimateNoTo.Size = new System.Drawing.Size(228, 27);
            this.txtEstimateNoTo.TabIndex = 57;
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
            this.txtEstimateDateFromDays.TabIndex = 118;
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
            this.txtEstimateDateFromMonth.TabIndex = 116;
            this.txtEstimateDateFromMonth.Text = "12";
            this.txtEstimateDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstimateDateFromMonth.UpControl = this.txtEstimateNoFrom;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlEstimateDateTo);
            this.pnlHeader.Controls.Add(this.pnlEstimateDateFrom);
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
            this.pnlHeader.Controls.Add(this.lblEstimateNo);
            this.pnlHeader.Controls.Add(this.txtEstimateNoFrom);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(983, 103);
            this.pnlHeader.TabIndex = 103;
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
            this.pnlEstimateDateTo.Location = new System.Drawing.Point(414, 39);
            this.pnlEstimateDateTo.Name = "pnlEstimateDateTo";
            this.pnlEstimateDateTo.Size = new System.Drawing.Size(228, 27);
            this.pnlEstimateDateTo.TabIndex = 133;
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
            this.dtpEstimateDateTo.TabIndex = 132;
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
            this.pnlEstimateDateFrom.Location = new System.Drawing.Point(133, 39);
            this.pnlEstimateDateFrom.Name = "pnlEstimateDateFrom";
            this.pnlEstimateDateFrom.Size = new System.Drawing.Size(228, 27);
            this.pnlEstimateDateFrom.TabIndex = 116;
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
            this.dtpEstimateDateFrom.TabIndex = 132;
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
            this.lblCustomerCanaName.Location = new System.Drawing.Point(643, 67);
            this.lblCustomerCanaName.Name = "lblCustomerCanaName";
            this.lblCustomerCanaName.Size = new System.Drawing.Size(87, 27);
            this.lblCustomerCanaName.TabIndex = 68;
            this.lblCustomerCanaName.Text = "カナ名";
            this.lblCustomerCanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated2.Location = new System.Drawing.Point(373, 42);
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
            this.lblCustomerCharactersName.Location = new System.Drawing.Point(264, 67);
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
            this.lblCustomerCode.Location = new System.Drawing.Point(3, 67);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.lblCustomerCode.TabIndex = 60;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated1.Location = new System.Drawing.Point(373, 14);
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
            this.lblEstimateDate.Location = new System.Drawing.Point(3, 39);
            this.lblEstimateDate.Name = "lblEstimateDate";
            this.lblEstimateDate.Size = new System.Drawing.Size(130, 27);
            this.lblEstimateDate.TabIndex = 54;
            this.lblEstimateDate.Text = "見積日付";
            this.lblEstimateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstimateNo
            // 
            this.lblEstimateNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEstimateNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstimateNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEstimateNo.ForeColor = System.Drawing.Color.White;
            this.lblEstimateNo.Location = new System.Drawing.Point(3, 11);
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
            this.pnlBody.Location = new System.Drawing.Point(0, 103);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(983, 301);
            this.pnlBody.TabIndex = 104;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnDispList);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 404);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 70);
            this.panel1.TabIndex = 451;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(148, 15);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(146, 40);
            this.btnPreview.TabIndex = 501;
            this.btnPreview.Text = "F3：プレビュー";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(302, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 40);
            this.btnPrint.TabIndex = 470;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDispList
            // 
            this.btnDispList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDispList.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDispList.Location = new System.Drawing.Point(3, 15);
            this.btnDispList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDispList.Name = "btnDispList";
            this.btnDispList.Size = new System.Drawing.Size(137, 40);
            this.btnDispList.TabIndex = 460;
            this.btnDispList.Text = "F1：一覧表示";
            this.btnDispList.UseVisualStyleBackColor = false;
            this.btnDispList.Click += new System.EventHandler(this.btnDispList_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(857, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMitumoriIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(983, 475);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMitumoriIchiran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "見積一覧出力";
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlEstimateDateTo.ResumeLayout(false);
            this.pnlEstimateDateTo.PerformLayout();
            this.pnlEstimateDateFrom.ResumeLayout(false);
            this.pnlEstimateDateFrom.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.CustomTextBox txtEstimateNoFrom;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private Common.CustomDataGridView grdSearchList;
        private Common.ItemHeadLabel lblEstimateNo;
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
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnDispList;
        private Common.FeaturesButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEstimateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEstimateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private YamazakiMatex.Print.Report.rptMitumoriIchiran rptMitumoriIchiran1;
    }
}