namespace SubForm
{
    partial class sfrmShiiresakiSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtVendorCode = new Common.CustomTextBox();
            this.grdSearchList = new Common.CustomDataGridView();
            this.clmVendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmClosingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVendorName = new Common.CustomTextBox();
            this.txtVendorKanaName = new Common.CustomTextBox();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblVendorKanaName = new Common.ItemHeadLabel();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.lblVendorName = new Common.ItemHeadLabel();
            this.lblVendorCode = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSelectCancel = new Common.FeaturesButton();
            this.btnAllSelect = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlRowSelectMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.BeforeValue = "";
            this.txtVendorCode.DownControl = this.grdSearchList;
            this.txtVendorCode.EnterControl = this.txtVendorName;
            this.txtVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCode.LabelControl = null;
            this.txtVendorCode.LeftControl = null;
            this.txtVendorCode.Location = new System.Drawing.Point(133, 79);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightControl = this.txtVendorName;
            this.txtVendorCode.Size = new System.Drawing.Size(66, 27);
            this.txtVendorCode.TabIndex = 50;
            this.txtVendorCode.Text = "XX3";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorCode.UpControl = null;
            this.txtVendorCode.Leave += new System.EventHandler(this.txtVendorCode_Leave);
            // 
            // grdSearchList
            // 
            this.grdSearchList.AllowUserToAddRows = false;
            this.grdSearchList.AllowUserToDeleteRows = false;
            this.grdSearchList.AllowUserToResizeColumns = false;
            this.grdSearchList.AllowUserToResizeRows = false;
            this.grdSearchList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdSearchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmVendorCode,
            this.clmVendorName,
            this.clmClosingDate,
            this.clmPaymentSite});
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
            dataGridViewCellStyle12.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdSearchList.RowSegmentCount = 1;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.ScrollRowCount = 3;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(1064, 287);
            this.grdSearchList.TabIndex = 90;
            this.grdSearchList.UpControl = this.txtVendorCode;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmVendorCode
            // 
            this.clmVendorCode.DataPropertyName = "shiresakiCode";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmVendorCode.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmVendorCode.HeaderText = "仕入先ｺｰﾄﾞ";
            this.clmVendorCode.Name = "clmVendorCode";
            this.clmVendorCode.ReadOnly = true;
            this.clmVendorCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmVendorCode.Width = 130;
            // 
            // clmVendorName
            // 
            this.clmVendorName.DataPropertyName = "shiresakiName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmVendorName.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmVendorName.HeaderText = "仕入先名";
            this.clmVendorName.Name = "clmVendorName";
            this.clmVendorName.ReadOnly = true;
            this.clmVendorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmVendorName.Width = 514;
            // 
            // clmClosingDate
            // 
            this.clmClosingDate.DataPropertyName = "shimebi";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmClosingDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmClosingDate.HeaderText = "締日";
            this.clmClosingDate.Name = "clmClosingDate";
            this.clmClosingDate.ReadOnly = true;
            this.clmClosingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmClosingDate.Width = 200;
            // 
            // clmPaymentSite
            // 
            this.clmPaymentSite.DataPropertyName = "shiharaiSaito";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPaymentSite.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmPaymentSite.HeaderText = "支払サイト";
            this.clmPaymentSite.Name = "clmPaymentSite";
            this.clmPaymentSite.ReadOnly = true;
            this.clmPaymentSite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPaymentSite.Width = 200;
            // 
            // txtVendorName
            // 
            this.txtVendorName.BeforeValue = "";
            this.txtVendorName.DownControl = this.grdSearchList;
            this.txtVendorName.EnterControl = this.txtVendorKanaName;
            this.txtVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorName.LabelControl = null;
            this.txtVendorName.LeftControl = this.txtVendorCode;
            this.txtVendorName.Location = new System.Drawing.Point(330, 79);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.RightControl = this.txtVendorKanaName;
            this.txtVendorName.Size = new System.Drawing.Size(216, 27);
            this.txtVendorName.TabIndex = 60;
            this.txtVendorName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtVendorName.UpControl = null;
            // 
            // txtVendorKanaName
            // 
            this.txtVendorKanaName.BeforeValue = "";
            this.txtVendorKanaName.DownControl = this.grdSearchList;
            this.txtVendorKanaName.EnterControl = this.grdSearchList;
            this.txtVendorKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorKanaName.LabelControl = null;
            this.txtVendorKanaName.LeftControl = this.txtVendorName;
            this.txtVendorKanaName.Location = new System.Drawing.Point(677, 79);
            this.txtVendorKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorKanaName.Name = "txtVendorKanaName";
            this.txtVendorKanaName.RightControl = null;
            this.txtVendorKanaName.Size = new System.Drawing.Size(390, 27);
            this.txtVendorKanaName.TabIndex = 70;
            this.txtVendorKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtVendorKanaName.UpControl = null;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 110;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(855, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 140;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(965, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 150;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblVendorKanaName);
            this.pnlHeader.Controls.Add(this.txtVendorKanaName);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Controls.Add(this.lblVendorName);
            this.pnlHeader.Controls.Add(this.lblVendorCode);
            this.pnlHeader.Controls.Add(this.txtVendorCode);
            this.pnlHeader.Controls.Add(this.txtVendorName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1074, 115);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblVendorKanaName
            // 
            this.lblVendorKanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorKanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorKanaName.ForeColor = System.Drawing.Color.White;
            this.lblVendorKanaName.Location = new System.Drawing.Point(547, 79);
            this.lblVendorKanaName.Name = "lblVendorKanaName";
            this.lblVendorKanaName.Size = new System.Drawing.Size(130, 27);
            this.lblVendorKanaName.TabIndex = 53;
            this.lblVendorKanaName.Text = "仕入先カナ名";
            this.lblVendorKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorName.ForeColor = System.Drawing.Color.White;
            this.lblVendorName.Location = new System.Drawing.Point(200, 79);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(130, 27);
            this.lblVendorName.TabIndex = 4;
            this.lblVendorName.Text = "仕入先名";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.ForeColor = System.Drawing.Color.White;
            this.lblVendorCode.Location = new System.Drawing.Point(3, 79);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(130, 27);
            this.lblVendorCode.TabIndex = 3;
            this.lblVendorCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 115);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1074, 301);
            this.pnlBody.TabIndex = 80;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 416);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1074, 70);
            this.pnlBottom.TabIndex = 100;
            // 
            // btnSelectCancel
            // 
            this.btnSelectCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectCancel.Location = new System.Drawing.Point(223, 15);
            this.btnSelectCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCancel.Name = "btnSelectCancel";
            this.btnSelectCancel.Size = new System.Drawing.Size(102, 40);
            this.btnSelectCancel.TabIndex = 130;
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
            this.btnAllSelect.TabIndex = 120;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(745, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 524;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sfrmShiiresakiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1074, 486);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmShiiresakiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入先検索";
            this.Load += new System.EventHandler(this.sfrmShiiresakiSearch_Load);
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
        private Common.CustomTextBox txtVendorCode;
        private Common.CustomTextBox txtVendorName;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnCheck;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdSearchList;
        private Common.ItemHeadLabel lblVendorCode;
        private Common.ItemHeadLabel lblVendorName;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblVendorKanaName;
        private Common.CustomTextBox txtVendorKanaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmClosingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentSite;
        private Common.FeaturesButton btnCancel;
    }
}