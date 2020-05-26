namespace TokuisakiUrikakeKanri
{
    partial class frmTokuisakiUrikakeKanri
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
            this.btnSave = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtOfficesName = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtTargetYear = new Common.CustomTextBox();
            this.txtOfficesCode = new Common.CustomTextBox();
            this.lblCustomer = new Common.ItemHeadLabel();
            this.lblTargetYear = new Common.ItemHeadLabel();
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.lblProcessingMode = new Common.ItemHeadLabel();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoRegist = new System.Windows.Forms.RadioButton();
            this.grdClaimList = new Common.CustomDataGridView();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnListDisp = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.clmMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmZengetsuKurikoshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUriage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShouhiZei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNyukin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKurikoshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlProcessingMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClaimList)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(691, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 40);
            this.btnSave.TabIndex = 130;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(805, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 140;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.txtOfficesName);
            this.pnlHeader.Controls.Add(this.txtOfficesCode);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.lblCustomer);
            this.pnlHeader.Controls.Add(this.txtTargetYear);
            this.pnlHeader.Controls.Add(this.lblTargetYear);
            this.pnlHeader.Controls.Add(this.pnlProcessingMode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1043, 135);
            this.pnlHeader.TabIndex = 1;
            // 
            // txtOfficesName
            // 
            this.txtOfficesName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtOfficesName.BeforeValue = "";
            this.txtOfficesName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOfficesName.DownControl = null;
            this.txtOfficesName.Enabled = false;
            this.txtOfficesName.EnterControl = null;
            this.txtOfficesName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOfficesName.LabelControl = null;
            this.txtOfficesName.LeftControl = this.txtCustomerCode;
            this.txtOfficesName.Location = new System.Drawing.Point(550, 102);
            this.txtOfficesName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOfficesName.Name = "txtOfficesName";
            this.txtOfficesName.RightControl = null;
            this.txtOfficesName.Size = new System.Drawing.Size(153, 20);
            this.txtOfficesName.TabIndex = 388;
            this.txtOfficesName.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.txtOfficesName.UpControl = null;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = null;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(134, 99);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 5;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(90, 27);
            this.txtCustomerCode.TabIndex = 60;
            this.txtCustomerCode.Text = "XXXX5";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtTargetYear;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.DownControl = null;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.EnterControl = null;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(308, 102);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = null;
            this.txtCustomerName.Size = new System.Drawing.Size(234, 20);
            this.txtCustomerName.TabIndex = 384;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = null;
            // 
            // txtTargetYear
            // 
            this.txtTargetYear.BeforeValue = "";
            this.txtTargetYear.DownControl = this.txtCustomerCode;
            this.txtTargetYear.EnterControl = null;
            this.txtTargetYear.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYear.LabelControl = null;
            this.txtTargetYear.LeftControl = null;
            this.txtTargetYear.Location = new System.Drawing.Point(134, 71);
            this.txtTargetYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYear.Name = "txtTargetYear";
            this.txtTargetYear.RightControl = null;
            this.txtTargetYear.Size = new System.Drawing.Size(90, 27);
            this.txtTargetYear.TabIndex = 50;
            this.txtTargetYear.Text = "XXX4";
            this.txtTargetYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYear.UpControl = null;
            // 
            // txtOfficesCode
            // 
            this.txtOfficesCode.BeforeValue = "";
            this.txtOfficesCode.DownControl = null;
            this.txtOfficesCode.EnterControl = this.txtCustomerName;
            this.txtOfficesCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOfficesCode.LabelControl = null;
            this.txtOfficesCode.LeftControl = null;
            this.txtOfficesCode.Location = new System.Drawing.Point(225, 99);
            this.txtOfficesCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOfficesCode.MaxLength = 5;
            this.txtOfficesCode.Name = "txtOfficesCode";
            this.txtOfficesCode.RightControl = this.txtCustomerName;
            this.txtOfficesCode.Size = new System.Drawing.Size(75, 27);
            this.txtOfficesCode.TabIndex = 70;
            this.txtOfficesCode.Text = "XX3";
            this.txtOfficesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOfficesCode.UpControl = this.txtTargetYear;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomer.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomer.ForeColor = System.Drawing.Color.White;
            this.lblCustomer.Location = new System.Drawing.Point(4, 99);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(130, 27);
            this.lblCustomer.TabIndex = 381;
            this.lblCustomer.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYear
            // 
            this.lblTargetYear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYear.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYear.ForeColor = System.Drawing.Color.White;
            this.lblTargetYear.Location = new System.Drawing.Point(5, 71);
            this.lblTargetYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetYear.Name = "lblTargetYear";
            this.lblTargetYear.Size = new System.Drawing.Size(129, 27);
            this.lblTargetYear.TabIndex = 113;
            this.lblTargetYear.Text = "年度";
            this.lblTargetYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.rdoDelete);
            this.pnlProcessingMode.Controls.Add(this.lblProcessingMode);
            this.pnlProcessingMode.Controls.Add(this.rdoReference);
            this.pnlProcessingMode.Controls.Add(this.rdoRegist);
            this.pnlProcessingMode.Location = new System.Drawing.Point(4, 3);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(257, 65);
            this.pnlProcessingMode.TabIndex = 10;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoCheck = false;
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(175, 32);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(69, 24);
            this.rdoDelete.TabIndex = 40;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "削除";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.Click += new System.EventHandler(this.inputModeRadio_Click);
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
            // rdoReference
            // 
            this.rdoReference.AutoCheck = false;
            this.rdoReference.AutoSize = true;
            this.rdoReference.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoReference.Location = new System.Drawing.Point(95, 32);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(69, 24);
            this.rdoReference.TabIndex = 30;
            this.rdoReference.TabStop = true;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            this.rdoReference.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoRegist
            // 
            this.rdoRegist.AutoCheck = false;
            this.rdoRegist.AutoSize = true;
            this.rdoRegist.Checked = true;
            this.rdoRegist.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoRegist.Location = new System.Drawing.Point(15, 32);
            this.rdoRegist.Name = "rdoRegist";
            this.rdoRegist.Size = new System.Drawing.Size(69, 24);
            this.rdoRegist.TabIndex = 20;
            this.rdoRegist.TabStop = true;
            this.rdoRegist.Text = "登録";
            this.rdoRegist.UseVisualStyleBackColor = true;
            this.rdoRegist.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // grdClaimList
            // 
            this.grdClaimList.AllowUserToAddRows = false;
            this.grdClaimList.AllowUserToDeleteRows = false;
            this.grdClaimList.AllowUserToResizeRows = false;
            this.grdClaimList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdClaimList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdClaimList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdClaimList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMonth,
            this.clmZengetsuKurikoshi,
            this.clmUriage,
            this.clmShouhiZei,
            this.clmNyukin,
            this.clmKurikoshi});
            this.grdClaimList.DownControl = null;
            this.grdClaimList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdClaimList.EnableHeadersVisualStyles = false;
            this.grdClaimList.EnterControl = null;
            this.grdClaimList.FlgSetCurrentCell = true;
            this.grdClaimList.LeftControl = null;
            this.grdClaimList.Location = new System.Drawing.Point(4, 3);
            this.grdClaimList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdClaimList.MultiSelect = false;
            this.grdClaimList.Name = "grdClaimList";
            this.grdClaimList.RightControl = null;
            this.grdClaimList.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdClaimList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdClaimList.RowSegmentCount = 1;
            this.grdClaimList.RowTemplate.Height = 26;
            this.grdClaimList.ScrollRowCount = 3;
            this.grdClaimList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdClaimList.Size = new System.Drawing.Size(1031, 339);
            this.grdClaimList.TabIndex = 90;
            this.grdClaimList.UpControl = null;
            this.grdClaimList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdClaimList_CellEndEdit);
            this.grdClaimList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdClaimList_CellValidating);
            this.grdClaimList.CurrentCellChanged += new System.EventHandler(this.grdClaimList_CurrentCellChanged);
            this.grdClaimList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdClaimList_EditingControlShowing);
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdClaimList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 135);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1043, 351);
            this.pnlBody.TabIndex = 80;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnListDisp);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 486);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1043, 70);
            this.pnlBottom.TabIndex = 100;
            // 
            // btnListDisp
            // 
            this.btnListDisp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnListDisp.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnListDisp.Location = new System.Drawing.Point(118, 15);
            this.btnListDisp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnListDisp.Name = "btnListDisp";
            this.btnListDisp.Size = new System.Drawing.Size(143, 40);
            this.btnListDisp.TabIndex = 120;
            this.btnListDisp.Text = "F2：一覧表示";
            this.btnListDisp.UseVisualStyleBackColor = false;
            this.btnListDisp.Click += new System.EventHandler(this.btnListDisp_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(4, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 110;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(919, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 150;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // clmMonth
            // 
            this.clmMonth.DataPropertyName = "month";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.clmMonth.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmMonth.HeaderText = "月";
            this.clmMonth.Name = "clmMonth";
            this.clmMonth.ReadOnly = true;
            this.clmMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMonth.Width = 60;
            // 
            // clmZengetsuKurikoshi
            // 
            this.clmZengetsuKurikoshi.DataPropertyName = "zengetsuKurikoshi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.clmZengetsuKurikoshi.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmZengetsuKurikoshi.FillWeight = 120F;
            this.clmZengetsuKurikoshi.HeaderText = "前月繰越額";
            this.clmZengetsuKurikoshi.Name = "clmZengetsuKurikoshi";
            this.clmZengetsuKurikoshi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmZengetsuKurikoshi.Width = 190;
            // 
            // clmUriage
            // 
            this.clmUriage.DataPropertyName = "uriage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.clmUriage.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmUriage.HeaderText = "売上";
            this.clmUriage.Name = "clmUriage";
            this.clmUriage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUriage.Width = 190;
            // 
            // clmShouhiZei
            // 
            this.clmShouhiZei.DataPropertyName = "shouhiZei";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.clmShouhiZei.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmShouhiZei.HeaderText = "消費税";
            this.clmShouhiZei.Name = "clmShouhiZei";
            this.clmShouhiZei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmShouhiZei.Width = 190;
            // 
            // clmNyukin
            // 
            this.clmNyukin.DataPropertyName = "nyukin";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.clmNyukin.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmNyukin.HeaderText = "入金額";
            this.clmNyukin.Name = "clmNyukin";
            this.clmNyukin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmNyukin.Width = 190;
            // 
            // clmKurikoshi
            // 
            this.clmKurikoshi.DataPropertyName = "kurikoshi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.clmKurikoshi.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmKurikoshi.HeaderText = "当月繰越";
            this.clmKurikoshi.Name = "clmKurikoshi";
            this.clmKurikoshi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmKurikoshi.Width = 190;
            // 
            // frmTokuisakiUrikakeKanri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1043, 556);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTokuisakiUrikakeKanri";
            this.ShowIcon = false;
            this.Text = "得意先別売掛管理";
            this.Load += new System.EventHandler(this.frmTokuisakiSeikyuKanri_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClaimList)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdClaimList;
        private System.Windows.Forms.Panel pnlProcessingMode;
        private System.Windows.Forms.RadioButton rdoDelete;
        private Common.ItemHeadLabel lblProcessingMode;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoRegist;
        private Common.FeaturesButton btnClose;
        private Common.CustomTextBox txtTargetYear;
        private Common.ItemHeadLabel lblTargetYear;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomTextBox txtCustomerCode;
        private Common.ItemHeadLabel lblCustomer;
        private Common.CustomTextBox txtOfficesCode;
        private Common.CustomTextBox txtOfficesName;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnListDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmZengetsuKurikoshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUriage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShouhiZei;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNyukin;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKurikoshi;
    }
}