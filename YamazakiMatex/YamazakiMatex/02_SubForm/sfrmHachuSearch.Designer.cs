namespace SubForm
{
    partial class sfrmHachuSearch
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
            this.txtOrderNoFrom = new System.Windows.Forms.TextBox();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtArea = new Common.CustomComboBox();
            this.dtpOrderDateFrom = new Common.CustomDateTimePicker();
            this.lblArea = new Common.ItemHeadLabel();
            this.lblVendorCanaName = new Common.ItemHeadLabel();
            this.txtVendorCanaName = new System.Windows.Forms.TextBox();
            this.dtpOrderDateTo = new Common.CustomDateTimePicker();
            this.lblFromToSeparated2 = new System.Windows.Forms.Label();
            this.lblVendorCharactersName = new Common.ItemHeadLabel();
            this.lblVendorCode = new Common.ItemHeadLabel();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtVendorCharactersName = new System.Windows.Forms.TextBox();
            this.txtOrderNoTo = new System.Windows.Forms.TextBox();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblOrderDate = new Common.ItemHeadLabel();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.lblOrderNo = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grdSearchList = new System.Windows.Forms.DataGridView();
            this.clmOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSelectCancel = new Common.FeaturesButton();
            this.btnAllSelect = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlRowSelectMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOrderNoFrom
            // 
            this.txtOrderNoFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrderNoFrom.Location = new System.Drawing.Point(133, 79);
            this.txtOrderNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrderNoFrom.Name = "txtOrderNoFrom";
            this.txtOrderNoFrom.Size = new System.Drawing.Size(177, 27);
            this.txtOrderNoFrom.TabIndex = 50;
            this.txtOrderNoFrom.Text = "XXXXXXX8";
            this.txtOrderNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(761, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 29;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
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
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button10_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.txtArea);
            this.pnlHeader.Controls.Add(this.lblArea);
            this.pnlHeader.Controls.Add(this.lblVendorCanaName);
            this.pnlHeader.Controls.Add(this.txtVendorCanaName);
            this.pnlHeader.Controls.Add(this.dtpOrderDateTo);
            this.pnlHeader.Controls.Add(this.dtpOrderDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated2);
            this.pnlHeader.Controls.Add(this.lblVendorCharactersName);
            this.pnlHeader.Controls.Add(this.lblVendorCode);
            this.pnlHeader.Controls.Add(this.txtVendorCode);
            this.pnlHeader.Controls.Add(this.txtVendorCharactersName);
            this.pnlHeader.Controls.Add(this.txtOrderNoTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblOrderDate);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Controls.Add(this.lblOrderNo);
            this.pnlHeader.Controls.Add(this.txtOrderNoFrom);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 171);
            this.pnlHeader.TabIndex = 1;
            // 
            // txtArea
            // 
            this.txtArea.BeforeSelectedValue = "";
            this.txtArea.DownControl = null;
            this.txtArea.EnterControl = null;
            this.txtArea.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txtArea.FormattingEnabled = true;
            this.txtArea.LabelControl = null;
            this.txtArea.LeftControl = null;
            this.txtArea.Location = new System.Drawing.Point(661, 107);
            this.txtArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArea.Name = "txtArea";
            this.txtArea.RightControl = null;
            this.txtArea.Size = new System.Drawing.Size(133, 27);
            this.txtArea.TabIndex = 90;
            this.txtArea.Text = "ＸＸＸＸ５";
            this.txtArea.UpControl = this.dtpOrderDateFrom;
            // 
            // dtpOrderDateFrom
            // 
            this.dtpOrderDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateFrom.CustomFormat = "yyyy年MM月dd日";
            this.dtpOrderDateFrom.DaysLinkTextControl = null;
            this.dtpOrderDateFrom.DownControl = null;
            this.dtpOrderDateFrom.EnterControl = null;
            this.dtpOrderDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDateFrom.LeftControl = null;
            this.dtpOrderDateFrom.Location = new System.Drawing.Point(133, 107);
            this.dtpOrderDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpOrderDateFrom.MonthLinkTextControl = null;
            this.dtpOrderDateFrom.Name = "dtpOrderDateFrom";
            this.dtpOrderDateFrom.RightControl = null;
            this.dtpOrderDateFrom.Size = new System.Drawing.Size(177, 27);
            this.dtpOrderDateFrom.TabIndex = 70;
            this.dtpOrderDateFrom.UpControl = null;
            this.dtpOrderDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpOrderDateFrom.Value2 = null;
            this.dtpOrderDateFrom.YearsLinkTextControl = null;
            // 
            // lblArea
            // 
            this.lblArea.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblArea.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblArea.ForeColor = System.Drawing.Color.White;
            this.lblArea.Location = new System.Drawing.Point(531, 107);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(133, 27);
            this.lblArea.TabIndex = 69;
            this.lblArea.Text = "地区";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCanaName
            // 
            this.lblVendorCanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCanaName.ForeColor = System.Drawing.Color.White;
            this.lblVendorCanaName.Location = new System.Drawing.Point(631, 135);
            this.lblVendorCanaName.Name = "lblVendorCanaName";
            this.lblVendorCanaName.Size = new System.Drawing.Size(87, 27);
            this.lblVendorCanaName.TabIndex = 68;
            this.lblVendorCanaName.Text = "カナ名";
            this.lblVendorCanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVendorCanaName
            // 
            this.txtVendorCanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCanaName.Location = new System.Drawing.Point(718, 135);
            this.txtVendorCanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCanaName.Name = "txtVendorCanaName";
            this.txtVendorCanaName.Size = new System.Drawing.Size(216, 27);
            this.txtVendorCanaName.TabIndex = 67;
            this.txtVendorCanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            // 
            // dtpOrderDateTo
            // 
            this.dtpOrderDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateTo.CustomFormat = "yyyy年MM月dd日";
            this.dtpOrderDateTo.DaysLinkTextControl = null;
            this.dtpOrderDateTo.DownControl = null;
            this.dtpOrderDateTo.EnterControl = null;
            this.dtpOrderDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOrderDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDateTo.LeftControl = null;
            this.dtpOrderDateTo.Location = new System.Drawing.Point(353, 107);
            this.dtpOrderDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpOrderDateTo.MonthLinkTextControl = null;
            this.dtpOrderDateTo.Name = "dtpOrderDateTo";
            this.dtpOrderDateTo.RightControl = null;
            this.dtpOrderDateTo.Size = new System.Drawing.Size(177, 27);
            this.dtpOrderDateTo.TabIndex = 80;
            this.dtpOrderDateTo.UpControl = null;
            this.dtpOrderDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpOrderDateTo.Value2 = null;
            this.dtpOrderDateTo.YearsLinkTextControl = null;
            // 
            // lblFromToSeparated2
            // 
            this.lblFromToSeparated2.AutoSize = true;
            this.lblFromToSeparated2.Location = new System.Drawing.Point(317, 112);
            this.lblFromToSeparated2.Name = "lblFromToSeparated2";
            this.lblFromToSeparated2.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated2.TabIndex = 63;
            this.lblFromToSeparated2.Text = "～";
            // 
            // lblVendorCharactersName
            // 
            this.lblVendorCharactersName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCharactersName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCharactersName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCharactersName.ForeColor = System.Drawing.Color.White;
            this.lblVendorCharactersName.Location = new System.Drawing.Point(264, 135);
            this.lblVendorCharactersName.Name = "lblVendorCharactersName";
            this.lblVendorCharactersName.Size = new System.Drawing.Size(150, 27);
            this.lblVendorCharactersName.TabIndex = 61;
            this.lblVendorCharactersName.Text = "仕入先漢字名";
            this.lblVendorCharactersName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.ForeColor = System.Drawing.Color.White;
            this.lblVendorCode.Location = new System.Drawing.Point(3, 135);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(130, 27);
            this.lblVendorCode.TabIndex = 60;
            this.lblVendorCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCode.Location = new System.Drawing.Point(133, 135);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(130, 27);
            this.txtVendorCode.TabIndex = 58;
            this.txtVendorCode.Text = "XXXXXXX8";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVendorCharactersName
            // 
            this.txtVendorCharactersName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCharactersName.Location = new System.Drawing.Point(414, 135);
            this.txtVendorCharactersName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCharactersName.Name = "txtVendorCharactersName";
            this.txtVendorCharactersName.Size = new System.Drawing.Size(216, 27);
            this.txtVendorCharactersName.TabIndex = 59;
            this.txtVendorCharactersName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            // 
            // txtOrderNoTo
            // 
            this.txtOrderNoTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrderNoTo.Location = new System.Drawing.Point(353, 79);
            this.txtOrderNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrderNoTo.Name = "txtOrderNoTo";
            this.txtOrderNoTo.Size = new System.Drawing.Size(177, 27);
            this.txtOrderNoTo.TabIndex = 60;
            this.txtOrderNoTo.Text = "XXXXXXX8";
            this.txtOrderNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.AutoSize = true;
            this.lblFromToSeparated1.Location = new System.Drawing.Point(317, 82);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 56;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrderDate.ForeColor = System.Drawing.Color.White;
            this.lblOrderDate.Location = new System.Drawing.Point(3, 107);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(130, 27);
            this.lblOrderDate.TabIndex = 54;
            this.lblOrderDate.Text = "発注日付";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.rdoRange.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
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
            this.rdoMulti.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
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
            this.rdoSingle.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(3, 79);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(130, 27);
            this.lblOrderNo.TabIndex = 3;
            this.lblOrderNo.Text = "発注NO";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 171);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(980, 301);
            this.pnlBody.TabIndex = 104;
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
            this.clmOrderNo,
            this.clmOrderDate,
            this.clmVendorName,
            this.clmSubject});
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
            this.grdSearchList.Size = new System.Drawing.Size(970, 287);
            this.grdSearchList.TabIndex = 24;
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // clmOrderNo
            // 
            this.clmOrderNo.DataPropertyName = "HachuNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmOrderNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmOrderNo.HeaderText = "発注NO";
            this.clmOrderNo.Name = "clmOrderNo";
            this.clmOrderNo.ReadOnly = true;
            this.clmOrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOrderNo.Width = 130;
            // 
            // clmOrderDate
            // 
            this.clmOrderDate.DataPropertyName = "HachuDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.clmOrderDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmOrderDate.HeaderText = "発注日付";
            this.clmOrderDate.Name = "clmOrderDate";
            this.clmOrderDate.ReadOnly = true;
            this.clmOrderDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOrderDate.Width = 160;
            // 
            // clmVendorName
            // 
            this.clmVendorName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmVendorName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmVendorName.HeaderText = "仕入先名";
            this.clmVendorName.Name = "clmVendorName";
            this.clmVendorName.ReadOnly = true;
            this.clmVendorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmVendorName.Width = 220;
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
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnSelectCancel);
            this.pnlBottom.Controls.Add(this.btnAllSelect);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnBack);
            this.pnlBottom.Controls.Add(this.btnCheck);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 472);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(980, 70);
            this.pnlBottom.TabIndex = 105;
            // 
            // btnSelectCancel
            // 
            this.btnSelectCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectCancel.Location = new System.Drawing.Point(223, 15);
            this.btnSelectCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCancel.Name = "btnSelectCancel";
            this.btnSelectCancel.Size = new System.Drawing.Size(102, 40);
            this.btnSelectCancel.TabIndex = 33;
            this.btnSelectCancel.Text = "選択解除";
            this.btnSelectCancel.UseVisualStyleBackColor = false;
            this.btnSelectCancel.Click += new System.EventHandler(this.featuresButton2_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAllSelect.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAllSelect.Location = new System.Drawing.Point(113, 15);
            this.btnAllSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(102, 40);
            this.btnAllSelect.TabIndex = 32;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.featuresButton1_Click);
            // 
            // sfrmHachuSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(980, 543);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmHachuSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "発注検索";
            this.Load += new System.EventHandler(this.sfrmHachuSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRowSelectMode.ResumeLayout(false);
            this.pnlRowSelectMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOrderNoFrom;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnCheck;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView grdSearchList;
        private Common.ItemHeadLabel lblOrderNo;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblOrderDate;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.ItemHeadLabel lblVendorCharactersName;
        private Common.ItemHeadLabel lblVendorCode;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtVendorCharactersName;
        private System.Windows.Forms.TextBox txtOrderNoTo;
        private System.Windows.Forms.Label lblFromToSeparated2;
        private Common.CustomDateTimePicker dtpOrderDateTo;
        private Common.CustomDateTimePicker dtpOrderDateFrom;
        private Common.ItemHeadLabel lblVendorCanaName;
        private System.Windows.Forms.TextBox txtVendorCanaName;
        private Common.CustomComboBox txtArea;
        private Common.ItemHeadLabel lblArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
    }
}