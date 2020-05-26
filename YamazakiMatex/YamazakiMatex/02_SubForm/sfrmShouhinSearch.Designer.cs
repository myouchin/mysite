namespace SubForm
{
    partial class sfrmShouhinSearch
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
            this.grdSearchList = new Common.CustomDataGridView();
            this.clmVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTopClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBtmClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbClassificationCode = new Common.CustomComboBox();
            this.txtItemNo = new Common.CustomTextBox();
            this.txtItemName = new Common.CustomTextBox();
            this.txtVendorKanaName = new Common.CustomTextBox();
            this.txtVendorName = new Common.CustomTextBox();
            this.txtVendorCode = new Common.CustomTextBox();
            this.lblItemName = new Common.ItemHeadLabel();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblClassificationCode = new Common.ItemHeadLabel();
            this.lblVendorCanaName = new Common.ItemHeadLabel();
            this.lblVendorName = new Common.ItemHeadLabel();
            this.lblVendorCode = new Common.ItemHeadLabel();
            this.lblItemNo = new Common.ItemHeadLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlRowSelectMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
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
            this.clmVendorName,
            this.clmItemCode,
            this.clmItemName,
            this.clmVendorCode,
            this.clmTopClassification,
            this.clmBtmClassification,
            this.clmItemNo});
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
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdSearchList.RowSegmentCount = 1;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.ScrollRowCount = 3;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(943, 287);
            this.grdSearchList.TabIndex = 120;
            this.grdSearchList.UpControl = this.cmbClassificationCode;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmVendorName
            // 
            this.clmVendorName.DataPropertyName = "shiresakiName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmVendorName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmVendorName.HeaderText = "仕入先名";
            this.clmVendorName.Name = "clmVendorName";
            this.clmVendorName.ReadOnly = true;
            this.clmVendorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmVendorName.Width = 390;
            // 
            // clmItemCode
            // 
            this.clmItemCode.DataPropertyName = "shouhinCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmItemCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmItemCode.HeaderText = "商品ｺｰﾄﾞ";
            this.clmItemCode.Name = "clmItemCode";
            this.clmItemCode.ReadOnly = true;
            this.clmItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmItemCode.Width = 142;
            // 
            // clmItemName
            // 
            this.clmItemName.DataPropertyName = "shouhinName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmItemName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmItemName.HeaderText = "商品名";
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.ReadOnly = true;
            this.clmItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmItemName.Width = 390;
            // 
            // clmVendorCode
            // 
            this.clmVendorCode.DataPropertyName = "shireCode";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmVendorCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmVendorCode.HeaderText = "仕入先ｺｰﾄﾞ";
            this.clmVendorCode.Name = "clmVendorCode";
            this.clmVendorCode.ReadOnly = true;
            this.clmVendorCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmVendorCode.Visible = false;
            // 
            // clmTopClassification
            // 
            this.clmTopClassification.DataPropertyName = "topClassification";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmTopClassification.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmTopClassification.HeaderText = "大分類";
            this.clmTopClassification.Name = "clmTopClassification";
            this.clmTopClassification.ReadOnly = true;
            this.clmTopClassification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTopClassification.Visible = false;
            // 
            // clmBtmClassification
            // 
            this.clmBtmClassification.DataPropertyName = "btmClassification";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmBtmClassification.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmBtmClassification.HeaderText = "小分類";
            this.clmBtmClassification.Name = "clmBtmClassification";
            this.clmBtmClassification.ReadOnly = true;
            this.clmBtmClassification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBtmClassification.Visible = false;
            // 
            // clmItemNo
            // 
            this.clmItemNo.DataPropertyName = "shouhinNo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmItemNo.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmItemNo.HeaderText = "商品番号";
            this.clmItemNo.Name = "clmItemNo";
            this.clmItemNo.ReadOnly = true;
            this.clmItemNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmItemNo.Visible = false;
            // 
            // cmbClassificationCode
            // 
            this.cmbClassificationCode.BeforeSelectedValue = "";
            this.cmbClassificationCode.DownControl = this.grdSearchList;
            this.cmbClassificationCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassificationCode.EnterControl = this.txtItemNo;
            this.cmbClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbClassificationCode.FormattingEnabled = true;
            this.cmbClassificationCode.LabelControl = null;
            this.cmbClassificationCode.LeftControl = null;
            this.cmbClassificationCode.Location = new System.Drawing.Point(133, 103);
            this.cmbClassificationCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClassificationCode.Name = "cmbClassificationCode";
            this.cmbClassificationCode.RightControl = null;
            this.cmbClassificationCode.Size = new System.Drawing.Size(130, 27);
            this.cmbClassificationCode.TabIndex = 80;
            this.cmbClassificationCode.UpControl = this.txtVendorCode;
            // 
            // txtItemNo
            // 
            this.txtItemNo.BeforeValue = "";
            this.txtItemNo.DownControl = this.grdSearchList;
            this.txtItemNo.EnterControl = this.txtItemName;
            this.txtItemNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtItemNo.LabelControl = null;
            this.txtItemNo.LeftControl = this.cmbClassificationCode;
            this.txtItemNo.Location = new System.Drawing.Point(414, 103);
            this.txtItemNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemNo.MaxLength = 5;
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.RightControl = this.txtItemName;
            this.txtItemNo.Size = new System.Drawing.Size(228, 27);
            this.txtItemNo.TabIndex = 90;
            this.txtItemNo.Text = "XXX4";
            this.txtItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemNo.UpControl = this.txtVendorName;
            this.txtItemNo.Leave += new System.EventHandler(this.txtZeroBuried_Leave);
            // 
            // txtItemName
            // 
            this.txtItemName.BeforeValue = "";
            this.txtItemName.DownControl = this.grdSearchList;
            this.txtItemName.EnterControl = this.grdSearchList;
            this.txtItemName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtItemName.LabelControl = null;
            this.txtItemName.LeftControl = this.txtItemNo;
            this.txtItemName.Location = new System.Drawing.Point(730, 103);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.RightControl = null;
            this.txtItemName.Size = new System.Drawing.Size(216, 27);
            this.txtItemName.TabIndex = 100;
            this.txtItemName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtItemName.UpControl = this.txtVendorKanaName;
            // 
            // txtVendorKanaName
            // 
            this.txtVendorKanaName.BeforeValue = "";
            this.txtVendorKanaName.DownControl = this.txtItemName;
            this.txtVendorKanaName.EnterControl = this.cmbClassificationCode;
            this.txtVendorKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorKanaName.LabelControl = null;
            this.txtVendorKanaName.LeftControl = this.txtVendorName;
            this.txtVendorKanaName.Location = new System.Drawing.Point(730, 75);
            this.txtVendorKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorKanaName.Name = "txtVendorKanaName";
            this.txtVendorKanaName.RightControl = null;
            this.txtVendorKanaName.Size = new System.Drawing.Size(216, 27);
            this.txtVendorKanaName.TabIndex = 70;
            this.txtVendorKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtVendorKanaName.UpControl = null;
            // 
            // txtVendorName
            // 
            this.txtVendorName.BeforeValue = "";
            this.txtVendorName.DownControl = this.txtItemNo;
            this.txtVendorName.EnterControl = this.txtVendorKanaName;
            this.txtVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorName.LabelControl = null;
            this.txtVendorName.LeftControl = this.txtVendorCode;
            this.txtVendorName.Location = new System.Drawing.Point(414, 75);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.RightControl = this.txtVendorKanaName;
            this.txtVendorName.Size = new System.Drawing.Size(228, 27);
            this.txtVendorName.TabIndex = 60;
            this.txtVendorName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtVendorName.UpControl = null;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.BeforeValue = "";
            this.txtVendorCode.DownControl = this.cmbClassificationCode;
            this.txtVendorCode.EnterControl = this.txtVendorName;
            this.txtVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCode.LabelControl = null;
            this.txtVendorCode.LeftControl = null;
            this.txtVendorCode.Location = new System.Drawing.Point(133, 75);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCode.MaxLength = 3;
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightControl = this.txtVendorName;
            this.txtVendorCode.Size = new System.Drawing.Size(130, 27);
            this.txtVendorCode.TabIndex = 50;
            this.txtVendorCode.Text = "XXXXXXX8";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorCode.UpControl = null;
            this.txtVendorCode.Leave += new System.EventHandler(this.txtZeroBuried_Leave);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblItemName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItemName.ForeColor = System.Drawing.Color.White;
            this.lblItemName.Location = new System.Drawing.Point(643, 103);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(87, 27);
            this.lblItemName.TabIndex = 53;
            this.lblItemName.Text = "商品名";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 140;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(734, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 170;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(844, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 180;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.cmbClassificationCode);
            this.pnlHeader.Controls.Add(this.lblClassificationCode);
            this.pnlHeader.Controls.Add(this.lblVendorCanaName);
            this.pnlHeader.Controls.Add(this.txtVendorKanaName);
            this.pnlHeader.Controls.Add(this.lblVendorName);
            this.pnlHeader.Controls.Add(this.lblVendorCode);
            this.pnlHeader.Controls.Add(this.txtVendorCode);
            this.pnlHeader.Controls.Add(this.txtVendorName);
            this.pnlHeader.Controls.Add(this.lblItemNo);
            this.pnlHeader.Controls.Add(this.txtItemNo);
            this.pnlHeader.Controls.Add(this.lblItemName);
            this.pnlHeader.Controls.Add(this.txtItemName);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(952, 139);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblClassificationCode
            // 
            this.lblClassificationCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblClassificationCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblClassificationCode.ForeColor = System.Drawing.Color.White;
            this.lblClassificationCode.Location = new System.Drawing.Point(3, 103);
            this.lblClassificationCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassificationCode.Name = "lblClassificationCode";
            this.lblClassificationCode.Size = new System.Drawing.Size(130, 27);
            this.lblClassificationCode.TabIndex = 75;
            this.lblClassificationCode.Text = "分類コード";
            this.lblClassificationCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCanaName
            // 
            this.lblVendorCanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCanaName.ForeColor = System.Drawing.Color.White;
            this.lblVendorCanaName.Location = new System.Drawing.Point(643, 75);
            this.lblVendorCanaName.Name = "lblVendorCanaName";
            this.lblVendorCanaName.Size = new System.Drawing.Size(87, 27);
            this.lblVendorCanaName.TabIndex = 74;
            this.lblVendorCanaName.Text = "カナ名";
            this.lblVendorCanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorName.ForeColor = System.Drawing.Color.White;
            this.lblVendorName.Location = new System.Drawing.Point(264, 75);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(150, 27);
            this.lblVendorName.TabIndex = 72;
            this.lblVendorName.Text = "仕入先名";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.ForeColor = System.Drawing.Color.White;
            this.lblVendorCode.Location = new System.Drawing.Point(3, 75);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(130, 27);
            this.lblVendorCode.TabIndex = 71;
            this.lblVendorCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemNo
            // 
            this.lblItemNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblItemNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItemNo.ForeColor = System.Drawing.Color.White;
            this.lblItemNo.Location = new System.Drawing.Point(264, 103);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.Size = new System.Drawing.Size(150, 27);
            this.lblItemNo.TabIndex = 55;
            this.lblItemNo.Text = "商品ｺｰﾄﾞ";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlBody.Location = new System.Drawing.Point(0, 139);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(952, 301);
            this.pnlBody.TabIndex = 110;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 440);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(952, 70);
            this.pnlBottom.TabIndex = 130;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(624, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 526;
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
            this.btnSelectCancel.TabIndex = 160;
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
            this.btnAllSelect.TabIndex = 150;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // sfrmShouhinSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(952, 511);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmShouhinSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品検索";
            this.Load += new System.EventHandler(this.sfrmShouhinSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
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
        private Common.CustomDataGridView grdSearchList;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblItemName;
        private Common.CustomTextBox txtItemName;
        private Common.ItemHeadLabel lblItemNo;
        private Common.CustomTextBox txtItemNo;
        private Common.ItemHeadLabel lblVendorCanaName;
        private Common.CustomTextBox txtVendorKanaName;
        private Common.CustomTextBox txtVendorName;
        private Common.CustomTextBox txtVendorCode;
        private Common.ItemHeadLabel lblVendorName;
        private Common.ItemHeadLabel lblVendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTopClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBtmClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemNo;
        private Common.CustomComboBox cmbClassificationCode;
        private Common.ItemHeadLabel lblClassificationCode;
        private Common.FeaturesButton btnCancel;
    }
}