namespace SubForm
{
    partial class sfrmTokuisakiSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCustomerKanaName = new Common.ItemHeadLabel();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.grdSearchList = new Common.CustomDataGridView();
            this.clmCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOfficesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDeploymentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonnelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOfficesCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.cmbPersonnel = new Common.CustomComboBox();
            this.cmbPrefecture = new Common.CustomComboBox();
            this.lblPersonnel = new Common.ItemHeadLabel();
            this.lblCustomerName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.lblPrefecture = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSelectCancel = new Common.FeaturesButton();
            this.btnAllSelect = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
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
            this.btnSearch.TabIndex = 130;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(982, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 160;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(1092, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 170;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.cmbPersonnel);
            this.pnlHeader.Controls.Add(this.lblPersonnel);
            this.pnlHeader.Controls.Add(this.cmbPrefecture);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Controls.Add(this.lblPrefecture);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1202, 143);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblCustomerKanaName
            // 
            this.lblCustomerKanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerKanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerKanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerKanaName.Location = new System.Drawing.Point(654, 107);
            this.lblCustomerKanaName.Name = "lblCustomerKanaName";
            this.lblCustomerKanaName.Size = new System.Drawing.Size(150, 27);
            this.lblCustomerKanaName.TabIndex = 116;
            this.lblCustomerKanaName.Text = "得意先カナ名";
            this.lblCustomerKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.grdSearchList;
            this.txtCustomerKanaName.EnterControl = this.grdSearchList;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(804, 107);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.MaxLength = 80;
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = null;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(390, 27);
            this.txtCustomerKanaName.TabIndex = 90;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = null;
            // 
            // grdSearchList
            // 
            this.grdSearchList.AllowUserToAddRows = false;
            this.grdSearchList.AllowUserToDeleteRows = false;
            this.grdSearchList.AllowUserToResizeColumns = false;
            this.grdSearchList.AllowUserToResizeRows = false;
            this.grdSearchList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdSearchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCustomerCode,
            this.clmCustomerName,
            this.clmOfficesName,
            this.clmDeploymentName,
            this.clmPersonnelName,
            this.clmOfficesCode});
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
            dataGridViewCellStyle16.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.grdSearchList.RowSegmentCount = 1;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.ScrollRowCount = 3;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(1191, 287);
            this.grdSearchList.TabIndex = 110;
            this.grdSearchList.UpControl = this.txtCustomerCode;
            this.grdSearchList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // clmCustomerCode
            // 
            this.clmCustomerCode.DataPropertyName = "tokuisakiCode";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmCustomerCode.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmCustomerCode.HeaderText = "得意先ｺｰﾄﾞ";
            this.clmCustomerCode.Name = "clmCustomerCode";
            this.clmCustomerCode.ReadOnly = true;
            this.clmCustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerCode.Width = 120;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.DataPropertyName = "tokuisakiName";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmCustomerName.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmCustomerName.HeaderText = "得意先名";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerName.Width = 384;
            // 
            // clmOfficesName
            // 
            this.clmOfficesName.DataPropertyName = "jigyousyoName";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmOfficesName.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmOfficesName.HeaderText = "事業所名";
            this.clmOfficesName.Name = "clmOfficesName";
            this.clmOfficesName.ReadOnly = true;
            this.clmOfficesName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOfficesName.Width = 222;
            // 
            // clmDeploymentName
            // 
            this.clmDeploymentName.DataPropertyName = "busyoName";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmDeploymentName.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmDeploymentName.HeaderText = "部署名";
            this.clmDeploymentName.Name = "clmDeploymentName";
            this.clmDeploymentName.ReadOnly = true;
            this.clmDeploymentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDeploymentName.Width = 222;
            // 
            // clmPersonnelName
            // 
            this.clmPersonnelName.DataPropertyName = "tokuisakiTantousyaName";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmPersonnelName.DefaultCellStyle = dataGridViewCellStyle14;
            this.clmPersonnelName.HeaderText = "担当者名";
            this.clmPersonnelName.Name = "clmPersonnelName";
            this.clmPersonnelName.ReadOnly = true;
            this.clmPersonnelName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPersonnelName.Width = 222;
            // 
            // clmOfficesCode
            // 
            this.clmOfficesCode.DataPropertyName = "jigyousyoCode";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmOfficesCode.DefaultCellStyle = dataGridViewCellStyle15;
            this.clmOfficesCode.HeaderText = "事業所ｺｰﾄﾞ";
            this.clmOfficesCode.Name = "clmOfficesCode";
            this.clmOfficesCode.ReadOnly = true;
            this.clmOfficesCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOfficesCode.Visible = false;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.grdSearchList;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(140, 107);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 5;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(146, 27);
            this.txtCustomerCode.TabIndex = 70;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.cmbPrefecture;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.grdSearchList;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(437, 107);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MaxLength = 40;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(216, 27);
            this.txtCustomerName.TabIndex = 80;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.cmbPersonnel;
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.BeforeSelectedValue = "";
            this.cmbPersonnel.DownControl = this.txtCustomerName;
            this.cmbPersonnel.EnterControl = this.txtCustomerCode;
            this.cmbPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.LabelControl = null;
            this.cmbPersonnel.LeftControl = this.cmbPrefecture;
            this.cmbPersonnel.Location = new System.Drawing.Point(437, 79);
            this.cmbPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.RightControl = null;
            this.cmbPersonnel.Size = new System.Drawing.Size(146, 27);
            this.cmbPersonnel.TabIndex = 60;
            this.cmbPersonnel.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPersonnel.UpControl = null;
            this.cmbPersonnel.Leave += new System.EventHandler(this.cmb_Leave);
            // 
            // cmbPrefecture
            // 
            this.cmbPrefecture.BeforeSelectedValue = "";
            this.cmbPrefecture.DownControl = this.txtCustomerCode;
            this.cmbPrefecture.EnterControl = this.cmbPersonnel;
            this.cmbPrefecture.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPrefecture.FormattingEnabled = true;
            this.cmbPrefecture.LabelControl = null;
            this.cmbPrefecture.LeftControl = null;
            this.cmbPrefecture.Location = new System.Drawing.Point(140, 79);
            this.cmbPrefecture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPrefecture.Name = "cmbPrefecture";
            this.cmbPrefecture.RightControl = this.cmbPersonnel;
            this.cmbPrefecture.Size = new System.Drawing.Size(146, 27);
            this.cmbPrefecture.TabIndex = 50;
            this.cmbPrefecture.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPrefecture.UpControl = null;
            this.cmbPrefecture.Leave += new System.EventHandler(this.cmb_Leave);
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblPersonnel.Location = new System.Drawing.Point(287, 79);
            this.lblPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(150, 27);
            this.lblPersonnel.TabIndex = 113;
            this.lblPersonnel.Text = "担当者";
            this.lblPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(287, 107);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(150, 27);
            this.lblCustomerName.TabIndex = 59;
            this.lblCustomerName.Text = "得意先漢字名";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(3, 107);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(137, 27);
            this.lblCustomerCode.TabIndex = 58;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.rdoRange.TabStop = true;
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
            this.rdoMulti.TabStop = true;
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
            // lblPrefecture
            // 
            this.lblPrefecture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPrefecture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrefecture.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrefecture.ForeColor = System.Drawing.Color.White;
            this.lblPrefecture.Location = new System.Drawing.Point(3, 79);
            this.lblPrefecture.Name = "lblPrefecture";
            this.lblPrefecture.Size = new System.Drawing.Size(137, 27);
            this.lblPrefecture.TabIndex = 3;
            this.lblPrefecture.Text = "都道府県";
            this.lblPrefecture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 143);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1202, 301);
            this.pnlBody.TabIndex = 100;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 444);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1202, 70);
            this.pnlBottom.TabIndex = 120;
            // 
            // btnSelectCancel
            // 
            this.btnSelectCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectCancel.Location = new System.Drawing.Point(223, 15);
            this.btnSelectCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCancel.Name = "btnSelectCancel";
            this.btnSelectCancel.Size = new System.Drawing.Size(102, 40);
            this.btnSelectCancel.TabIndex = 150;
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
            this.btnAllSelect.TabIndex = 140;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(872, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 527;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sfrmTokuisakiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1202, 514);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmTokuisakiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先検索";
            this.Load += new System.EventHandler(this.sfrmTokuisakiSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
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
        private Common.ItemHeadLabel lblPrefecture;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private Common.ItemHeadLabel lblCustomerName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtCustomerCode;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomComboBox cmbPrefecture;
        private Common.CustomComboBox cmbPersonnel;
        private Common.ItemHeadLabel lblPersonnel;
        private Common.ItemHeadLabel lblCustomerKanaName;
        private Common.CustomTextBox txtCustomerKanaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOfficesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDeploymentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonnelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOfficesCode;
        private Common.FeaturesButton btnCancel;
    }
}