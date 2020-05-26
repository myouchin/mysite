namespace Shiire
{
    partial class frmShiireInput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.btnDeleteRow = new Common.FeaturesButton();
            this.btnInsertRow = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPurchaseDate = new Common.ItemHeadLabel();
            this.pnlPurchaseDate = new System.Windows.Forms.Panel();
            this.lblPurchaseDateDays = new System.Windows.Forms.Label();
            this.txtPurchaseDateDays = new Common.CustomTextBox();
            this.txtCustomerName = new Common.CustomTextBox();
            this.txtAddress1 = new Common.CustomTextBox();
            this.grdPurchaseDetails = new Common.CustomDataGridView();
            this.clmRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRowStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTopClassificationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbtmClassificationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtZipCode = new Common.CustomTextBox();
            this.txtCustomerCode = new Common.CustomTextBox();
            this.txtPurchaseNo = new Common.CustomTextBox();
            this.txtPurchaseDateYears = new Common.CustomTextBox();
            this.txtPurchaseDateMonth = new Common.CustomTextBox();
            this.txtAddress2 = new Common.CustomTextBox();
            this.txtSalesNo = new Common.CustomTextBox();
            this.cmbOffices = new Common.CustomComboBox();
            this.txtCustomerKanaName = new Common.CustomTextBox();
            this.txtVendorCode = new Common.CustomTextBox();
            this.txtVendorName = new Common.CustomTextBox();
            this.cmbPersonnel = new Common.CustomComboBox();
            this.txtOrderNo = new Common.CustomTextBox();
            this.lblPurchaseDateMonth = new System.Windows.Forms.Label();
            this.lblPurchaseDateYears = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new Common.CustomDateTimePicker();
            this.itemHeadLabel2 = new Common.ItemHeadLabel();
            this.lblPersonnel = new Common.ItemHeadLabel();
            this.lblAddress = new Common.ItemHeadLabel();
            this.lblZipCode = new Common.ItemHeadLabel();
            this.lblOffices = new Common.ItemHeadLabel();
            this.lblCustomerKanaName = new Common.ItemHeadLabel();
            this.lblCustomerName = new Common.ItemHeadLabel();
            this.lblCustomerCode = new Common.ItemHeadLabel();
            this.lblOrderNo = new Common.ItemHeadLabel();
            this.lblPurchaseNo = new Common.ItemHeadLabel();
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.lblProcessingMode = new Common.ItemHeadLabel();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.lblVendorName = new Common.ItemHeadLabel();
            this.lblVendorCode = new Common.ItemHeadLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnCopyRow = new Common.FeaturesButton();
            this.btnPasteRow = new Common.FeaturesButton();
            this.grdPurchaseDetailsTotal = new System.Windows.Forms.DataGridView();
            this.clmTotalAmountTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new Common.FeaturesButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlPurchaseDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseDetails)).BeginInit();
            this.pnlProcessingMode.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseDetailsTotal)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(4, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 40);
            this.btnSearch.TabIndex = 381;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(908, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 40);
            this.btnSave.TabIndex = 391;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(1022, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 401;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDeleteRow.Location = new System.Drawing.Point(1158, 2);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(94, 40);
            this.btnDeleteRow.TabIndex = 351;
            this.btnDeleteRow.Text = "行削除";
            this.btnDeleteRow.UseVisualStyleBackColor = false;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnInsertRow
            // 
            this.btnInsertRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInsertRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnInsertRow.Location = new System.Drawing.Point(1062, 2);
            this.btnInsertRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInsertRow.Name = "btnInsertRow";
            this.btnInsertRow.Size = new System.Drawing.Size(94, 40);
            this.btnInsertRow.TabIndex = 341;
            this.btnInsertRow.Text = "行挿入";
            this.btnInsertRow.UseVisualStyleBackColor = false;
            this.btnInsertRow.Click += new System.EventHandler(this.btnInsertRow_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblPurchaseDate);
            this.pnlHeader.Controls.Add(this.pnlPurchaseDate);
            this.pnlHeader.Controls.Add(this.txtSalesNo);
            this.pnlHeader.Controls.Add(this.itemHeadLabel2);
            this.pnlHeader.Controls.Add(this.cmbPersonnel);
            this.pnlHeader.Controls.Add(this.lblPersonnel);
            this.pnlHeader.Controls.Add(this.txtAddress1);
            this.pnlHeader.Controls.Add(this.txtAddress2);
            this.pnlHeader.Controls.Add(this.lblAddress);
            this.pnlHeader.Controls.Add(this.txtZipCode);
            this.pnlHeader.Controls.Add(this.lblZipCode);
            this.pnlHeader.Controls.Add(this.lblOffices);
            this.pnlHeader.Controls.Add(this.cmbOffices);
            this.pnlHeader.Controls.Add(this.lblCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerKanaName);
            this.pnlHeader.Controls.Add(this.txtCustomerName);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Controls.Add(this.txtCustomerCode);
            this.pnlHeader.Controls.Add(this.lblCustomerCode);
            this.pnlHeader.Controls.Add(this.txtOrderNo);
            this.pnlHeader.Controls.Add(this.lblOrderNo);
            this.pnlHeader.Controls.Add(this.txtPurchaseNo);
            this.pnlHeader.Controls.Add(this.lblPurchaseNo);
            this.pnlHeader.Controls.Add(this.pnlProcessingMode);
            this.pnlHeader.Controls.Add(this.txtVendorName);
            this.pnlHeader.Controls.Add(this.lblVendorName);
            this.pnlHeader.Controls.Add(this.txtVendorCode);
            this.pnlHeader.Controls.Add(this.lblVendorCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1259, 235);
            this.pnlHeader.TabIndex = 103;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPurchaseDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPurchaseDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPurchaseDate.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseDate.Location = new System.Drawing.Point(134, 71);
            this.lblPurchaseDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(233, 24);
            this.lblPurchaseDate.TabIndex = 411;
            this.lblPurchaseDate.Text = "仕入日付";
            this.lblPurchaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPurchaseDate
            // 
            this.pnlPurchaseDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlPurchaseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPurchaseDate.Controls.Add(this.lblPurchaseDateDays);
            this.pnlPurchaseDate.Controls.Add(this.txtPurchaseDateDays);
            this.pnlPurchaseDate.Controls.Add(this.lblPurchaseDateMonth);
            this.pnlPurchaseDate.Controls.Add(this.txtPurchaseDateMonth);
            this.pnlPurchaseDate.Controls.Add(this.lblPurchaseDateYears);
            this.pnlPurchaseDate.Controls.Add(this.txtPurchaseDateYears);
            this.pnlPurchaseDate.Controls.Add(this.dtpPurchaseDate);
            this.pnlPurchaseDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlPurchaseDate.Location = new System.Drawing.Point(133, 95);
            this.pnlPurchaseDate.Name = "pnlPurchaseDate";
            this.pnlPurchaseDate.Size = new System.Drawing.Size(234, 27);
            this.pnlPurchaseDate.TabIndex = 410;
            // 
            // lblPurchaseDateDays
            // 
            this.lblPurchaseDateDays.Location = new System.Drawing.Point(170, 0);
            this.lblPurchaseDateDays.Name = "lblPurchaseDateDays";
            this.lblPurchaseDateDays.Size = new System.Drawing.Size(28, 27);
            this.lblPurchaseDateDays.TabIndex = 119;
            this.lblPurchaseDateDays.Text = "日";
            this.lblPurchaseDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPurchaseDateDays
            // 
            this.txtPurchaseDateDays.BeforeValue = "";
            this.txtPurchaseDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPurchaseDateDays.DownControl = this.txtCustomerName;
            this.txtPurchaseDateDays.EnterControl = this.txtVendorCode;
            this.txtPurchaseDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseDateDays.LabelControl = null;
            this.txtPurchaseDateDays.LeftControl = this.txtPurchaseDateMonth;
            this.txtPurchaseDateDays.Location = new System.Drawing.Point(137, 3);
            this.txtPurchaseDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseDateDays.Name = "txtPurchaseDateDays";
            this.txtPurchaseDateDays.RightControl = this.txtVendorCode;
            this.txtPurchaseDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtPurchaseDateDays.TabIndex = 171;
            this.txtPurchaseDateDays.Text = "12";
            this.txtPurchaseDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseDateDays.UpControl = null;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BeforeValue = "";
            this.txtCustomerName.DownControl = this.txtAddress1;
            this.txtCustomerName.EnterControl = this.txtCustomerKanaName;
            this.txtCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerName.LabelControl = null;
            this.txtCustomerName.LeftControl = this.txtCustomerCode;
            this.txtCustomerName.Location = new System.Drawing.Point(133, 147);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightControl = this.txtCustomerKanaName;
            this.txtCustomerName.Size = new System.Drawing.Size(234, 27);
            this.txtCustomerName.TabIndex = 241;
            this.txtCustomerName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtCustomerName.UpControl = this.txtPurchaseDateYears;
            // 
            // txtAddress1
            // 
            this.txtAddress1.BeforeValue = "";
            this.txtAddress1.DownControl = this.grdPurchaseDetails;
            this.txtAddress1.EnterControl = this.txtAddress2;
            this.txtAddress1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtAddress1.LabelControl = null;
            this.txtAddress1.LeftControl = this.txtZipCode;
            this.txtAddress1.Location = new System.Drawing.Point(133, 199);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.RightControl = this.txtAddress2;
            this.txtAddress1.Size = new System.Drawing.Size(351, 27);
            this.txtAddress1.TabIndex = 281;
            this.txtAddress1.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２５";
            this.txtAddress1.UpControl = this.txtCustomerName;
            // 
            // grdPurchaseDetails
            // 
            this.grdPurchaseDetails.AllowUserToAddRows = false;
            this.grdPurchaseDetails.AllowUserToDeleteRows = false;
            this.grdPurchaseDetails.AllowUserToResizeColumns = false;
            this.grdPurchaseDetails.AllowUserToResizeRows = false;
            this.grdPurchaseDetails.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPurchaseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPurchaseDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRowNo,
            this.clmItemCode,
            this.clmItemName,
            this.clmQuantity,
            this.clmUnit,
            this.clmBid,
            this.clmAmount,
            this.clmRowStatus,
            this.clmTopClassificationCode,
            this.clmbtmClassificationCode});
            this.grdPurchaseDetails.DownControl = null;
            this.grdPurchaseDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdPurchaseDetails.EnableHeadersVisualStyles = false;
            this.grdPurchaseDetails.EnterControl = null;
            this.grdPurchaseDetails.FlgSetCurrentCell = true;
            this.grdPurchaseDetails.LeftControl = null;
            this.grdPurchaseDetails.Location = new System.Drawing.Point(4, 42);
            this.grdPurchaseDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdPurchaseDetails.MultiSelect = false;
            this.grdPurchaseDetails.Name = "grdPurchaseDetails";
            this.grdPurchaseDetails.RightControl = null;
            this.grdPurchaseDetails.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdPurchaseDetails.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdPurchaseDetails.RowSegmentCount = 2;
            this.grdPurchaseDetails.RowTemplate.Height = 26;
            this.grdPurchaseDetails.ScrollRowCount = 3;
            this.grdPurchaseDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdPurchaseDetails.Size = new System.Drawing.Size(1248, 297);
            this.grdPurchaseDetails.TabIndex = 361;
            this.grdPurchaseDetails.UpControl = this.txtZipCode;
            this.grdPurchaseDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPurchaseDetails_CellEndEdit);
            this.grdPurchaseDetails.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdPurchaseDetails_CellPainting);
            this.grdPurchaseDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdPurchaseDetails_CellValidating);
            this.grdPurchaseDetails.CurrentCellChanged += new System.EventHandler(this.grdPurchaseDetails_CurrentCellChanged);
            this.grdPurchaseDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdPurchaseDetails_DataError);
            this.grdPurchaseDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdPurchaseDetails_EditingControlShowing);
            this.grdPurchaseDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.grdPurchaseDetails_Paint);
            // 
            // clmRowNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.clmRowNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmRowNo.HeaderText = "NO．";
            this.clmRowNo.Name = "clmRowNo";
            this.clmRowNo.ReadOnly = true;
            this.clmRowNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmRowNo.Width = 60;
            // 
            // clmItemCode
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.clmItemCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmItemCode.FillWeight = 120F;
            this.clmItemCode.HeaderText = "商品ｺｰﾄﾞ";
            this.clmItemCode.Name = "clmItemCode";
            this.clmItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmItemName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.clmItemName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmItemName.HeaderText = "商品名";
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmItemName.Width = 421;
            // 
            // clmQuantity
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.clmQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmQuantity.HeaderText = "数量";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmQuantity.Width = 177;
            // 
            // clmUnit
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmUnit.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clmUnit.DisplayStyleForCurrentCellOnly = true;
            this.clmUnit.HeaderText = "単位";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.Width = 115;
            // 
            // clmBid
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.clmBid.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmBid.HeaderText = "単価";
            this.clmBid.Name = "clmBid";
            this.clmBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBid.Width = 177;
            // 
            // clmAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmAmount.HeaderText = "金額";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmAmount.Width = 177;
            // 
            // clmRowStatus
            // 
            this.clmRowStatus.HeaderText = "行状態";
            this.clmRowStatus.Name = "clmRowStatus";
            this.clmRowStatus.ReadOnly = true;
            this.clmRowStatus.Visible = false;
            // 
            // clmTopClassificationCode
            // 
            this.clmTopClassificationCode.HeaderText = "大分類コード";
            this.clmTopClassificationCode.Name = "clmTopClassificationCode";
            this.clmTopClassificationCode.ReadOnly = true;
            this.clmTopClassificationCode.Visible = false;
            // 
            // clmbtmClassificationCode
            // 
            this.clmbtmClassificationCode.HeaderText = "小分類コード";
            this.clmbtmClassificationCode.Name = "clmbtmClassificationCode";
            this.clmbtmClassificationCode.ReadOnly = true;
            this.clmbtmClassificationCode.Visible = false;
            // 
            // txtZipCode
            // 
            this.txtZipCode.BeforeValue = "";
            this.txtZipCode.DownControl = this.grdPurchaseDetails;
            this.txtZipCode.EnterControl = this.txtAddress1;
            this.txtZipCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtZipCode.LabelControl = null;
            this.txtZipCode.LeftControl = null;
            this.txtZipCode.Location = new System.Drawing.Point(4, 199);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.RightControl = this.txtAddress1;
            this.txtZipCode.Size = new System.Drawing.Size(130, 27);
            this.txtZipCode.TabIndex = 271;
            this.txtZipCode.Text = "XXX-XXXX";
            this.txtZipCode.UpControl = this.txtCustomerCode;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BeforeValue = "";
            this.txtCustomerCode.DownControl = this.txtZipCode;
            this.txtCustomerCode.EnterControl = this.txtCustomerName;
            this.txtCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerCode.LabelControl = null;
            this.txtCustomerCode.LeftControl = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(4, 147);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerCode.MaxLength = 5;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightControl = this.txtCustomerName;
            this.txtCustomerCode.Size = new System.Drawing.Size(130, 27);
            this.txtCustomerCode.TabIndex = 231;
            this.txtCustomerCode.Text = "XXXXXXX8";
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.UpControl = this.txtPurchaseNo;
            // 
            // txtPurchaseNo
            // 
            this.txtPurchaseNo.BeforeValue = "";
            this.txtPurchaseNo.DownControl = this.txtCustomerCode;
            this.txtPurchaseNo.EnterControl = this.txtPurchaseDateYears;
            this.txtPurchaseNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseNo.LabelControl = null;
            this.txtPurchaseNo.LeftControl = null;
            this.txtPurchaseNo.Location = new System.Drawing.Point(4, 95);
            this.txtPurchaseNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseNo.Name = "txtPurchaseNo";
            this.txtPurchaseNo.RightControl = this.txtPurchaseDateYears;
            this.txtPurchaseNo.Size = new System.Drawing.Size(130, 27);
            this.txtPurchaseNo.TabIndex = 141;
            this.txtPurchaseNo.Text = "XXXXXXX8";
            this.txtPurchaseNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseNo.UpControl = null;
            // 
            // txtPurchaseDateYears
            // 
            this.txtPurchaseDateYears.BeforeValue = "";
            this.txtPurchaseDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPurchaseDateYears.DownControl = this.txtCustomerName;
            this.txtPurchaseDateYears.EnterControl = this.txtPurchaseDateMonth;
            this.txtPurchaseDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseDateYears.LabelControl = null;
            this.txtPurchaseDateYears.LeftControl = this.txtPurchaseNo;
            this.txtPurchaseDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtPurchaseDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseDateYears.Name = "txtPurchaseDateYears";
            this.txtPurchaseDateYears.RightControl = this.txtPurchaseDateMonth;
            this.txtPurchaseDateYears.Size = new System.Drawing.Size(51, 20);
            this.txtPurchaseDateYears.TabIndex = 151;
            this.txtPurchaseDateYears.Text = "1234";
            this.txtPurchaseDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseDateYears.UpControl = null;
            // 
            // txtPurchaseDateMonth
            // 
            this.txtPurchaseDateMonth.BeforeValue = "";
            this.txtPurchaseDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPurchaseDateMonth.DownControl = this.txtCustomerName;
            this.txtPurchaseDateMonth.EnterControl = this.txtPurchaseDateDays;
            this.txtPurchaseDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtPurchaseDateMonth.LabelControl = null;
            this.txtPurchaseDateMonth.LeftControl = this.txtPurchaseDateYears;
            this.txtPurchaseDateMonth.Location = new System.Drawing.Point(78, 3);
            this.txtPurchaseDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseDateMonth.Name = "txtPurchaseDateMonth";
            this.txtPurchaseDateMonth.RightControl = this.txtPurchaseDateDays;
            this.txtPurchaseDateMonth.Size = new System.Drawing.Size(33, 20);
            this.txtPurchaseDateMonth.TabIndex = 161;
            this.txtPurchaseDateMonth.Text = "12";
            this.txtPurchaseDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaseDateMonth.UpControl = null;
            // 
            // txtAddress2
            // 
            this.txtAddress2.BeforeValue = "";
            this.txtAddress2.DownControl = this.grdPurchaseDetails;
            this.txtAddress2.EnterControl = this.grdPurchaseDetails;
            this.txtAddress2.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtAddress2.LabelControl = null;
            this.txtAddress2.LeftControl = this.txtAddress1;
            this.txtAddress2.Location = new System.Drawing.Point(483, 199);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.RightControl = this.txtSalesNo;
            this.txtAddress2.Size = new System.Drawing.Size(351, 27);
            this.txtAddress2.TabIndex = 291;
            this.txtAddress2.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２５";
            this.txtAddress2.UpControl = this.txtCustomerKanaName;
            // 
            // txtSalesNo
            // 
            this.txtSalesNo.BeforeValue = "";
            this.txtSalesNo.DownControl = this.grdPurchaseDetails;
            this.txtSalesNo.EnterControl = this.grdPurchaseDetails;
            this.txtSalesNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSalesNo.LabelControl = null;
            this.txtSalesNo.LeftControl = this.txtAddress2;
            this.txtSalesNo.Location = new System.Drawing.Point(833, 199);
            this.txtSalesNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesNo.Name = "txtSalesNo";
            this.txtSalesNo.RightControl = null;
            this.txtSalesNo.Size = new System.Drawing.Size(210, 27);
            this.txtSalesNo.TabIndex = 301;
            this.txtSalesNo.Text = "XXXXXXXXXXXXXX16";
            this.txtSalesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesNo.UpControl = this.cmbOffices;
            this.txtSalesNo.Visible = false;
            // 
            // cmbOffices
            // 
            this.cmbOffices.BeforeSelectedValue = "";
            this.cmbOffices.DownControl = this.txtSalesNo;
            this.cmbOffices.EnterControl = this.txtZipCode;
            this.cmbOffices.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.LabelControl = null;
            this.cmbOffices.LeftControl = this.txtCustomerKanaName;
            this.cmbOffices.Location = new System.Drawing.Point(833, 147);
            this.cmbOffices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.RightControl = null;
            this.cmbOffices.Size = new System.Drawing.Size(210, 27);
            this.cmbOffices.TabIndex = 261;
            this.cmbOffices.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbOffices.UpControl = this.cmbPersonnel;
            // 
            // txtCustomerKanaName
            // 
            this.txtCustomerKanaName.BeforeValue = "";
            this.txtCustomerKanaName.DownControl = this.txtAddress1;
            this.txtCustomerKanaName.EnterControl = this.cmbOffices;
            this.txtCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtCustomerKanaName.LabelControl = null;
            this.txtCustomerKanaName.LeftControl = this.txtCustomerName;
            this.txtCustomerKanaName.Location = new System.Drawing.Point(366, 147);
            this.txtCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerKanaName.Name = "txtCustomerKanaName";
            this.txtCustomerKanaName.RightControl = this.cmbOffices;
            this.txtCustomerKanaName.Size = new System.Drawing.Size(468, 27);
            this.txtCustomerKanaName.TabIndex = 251;
            this.txtCustomerKanaName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０";
            this.txtCustomerKanaName.UpControl = this.txtVendorCode;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.BeforeValue = "";
            this.txtVendorCode.DownControl = this.txtCustomerKanaName;
            this.txtVendorCode.EnterControl = this.txtVendorName;
            this.txtVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorCode.LabelControl = null;
            this.txtVendorCode.LeftControl = this.txtPurchaseDateDays;
            this.txtVendorCode.Location = new System.Drawing.Point(366, 95);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightControl = this.txtVendorName;
            this.txtVendorCode.Size = new System.Drawing.Size(130, 27);
            this.txtVendorCode.TabIndex = 191;
            this.txtVendorCode.Text = "XXXXXXX8";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorCode.UpControl = null;
            // 
            // txtVendorName
            // 
            this.txtVendorName.BeforeValue = "";
            this.txtVendorName.DownControl = this.txtCustomerKanaName;
            this.txtVendorName.EnterControl = this.cmbPersonnel;
            this.txtVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtVendorName.LabelControl = null;
            this.txtVendorName.LeftControl = this.txtVendorCode;
            this.txtVendorName.Location = new System.Drawing.Point(495, 95);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.RightControl = this.cmbPersonnel;
            this.txtVendorName.Size = new System.Drawing.Size(339, 27);
            this.txtVendorName.TabIndex = 201;
            this.txtVendorName.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtVendorName.UpControl = null;
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.BeforeSelectedValue = "";
            this.cmbPersonnel.DownControl = this.cmbOffices;
            this.cmbPersonnel.EnterControl = this.txtOrderNo;
            this.cmbPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.LabelControl = null;
            this.cmbPersonnel.LeftControl = this.txtVendorName;
            this.cmbPersonnel.Location = new System.Drawing.Point(833, 95);
            this.cmbPersonnel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.RightControl = this.txtOrderNo;
            this.cmbPersonnel.Size = new System.Drawing.Size(210, 27);
            this.cmbPersonnel.TabIndex = 211;
            this.cmbPersonnel.Text = "ＸＸＸＸＸＸＸＸ１０";
            this.cmbPersonnel.UpControl = null;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BeforeValue = "";
            this.txtOrderNo.DownControl = null;
            this.txtOrderNo.EnterControl = this.txtCustomerCode;
            this.txtOrderNo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOrderNo.LabelControl = null;
            this.txtOrderNo.LeftControl = this.cmbPersonnel;
            this.txtOrderNo.Location = new System.Drawing.Point(1042, 95);
            this.txtOrderNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.RightControl = null;
            this.txtOrderNo.Size = new System.Drawing.Size(210, 27);
            this.txtOrderNo.TabIndex = 221;
            this.txtOrderNo.Text = "XXXXXXXXXXXXXX16";
            this.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrderNo.UpControl = null;
            // 
            // lblPurchaseDateMonth
            // 
            this.lblPurchaseDateMonth.Location = new System.Drawing.Point(111, 0);
            this.lblPurchaseDateMonth.Name = "lblPurchaseDateMonth";
            this.lblPurchaseDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblPurchaseDateMonth.TabIndex = 117;
            this.lblPurchaseDateMonth.Text = "月";
            this.lblPurchaseDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPurchaseDateYears
            // 
            this.lblPurchaseDateYears.Location = new System.Drawing.Point(51, 0);
            this.lblPurchaseDateYears.Name = "lblPurchaseDateYears";
            this.lblPurchaseDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblPurchaseDateYears.TabIndex = 115;
            this.lblPurchaseDateYears.Text = "年";
            this.lblPurchaseDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPurchaseDate.CustomFormat = " ";
            this.dtpPurchaseDate.DaysLinkTextControl = this.txtPurchaseDateDays;
            this.dtpPurchaseDate.DownControl = this.txtCustomerName;
            this.dtpPurchaseDate.EnterControl = this.txtVendorCode;
            this.dtpPurchaseDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.LeftControl = this.txtPurchaseDateDays;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpPurchaseDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpPurchaseDate.MonthLinkTextControl = this.txtPurchaseDateMonth;
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.RightControl = this.txtVendorCode;
            this.dtpPurchaseDate.Size = new System.Drawing.Size(234, 27);
            this.dtpPurchaseDate.TabIndex = 181;
            this.dtpPurchaseDate.TabStop = false;
            this.dtpPurchaseDate.UpControl = null;
            this.dtpPurchaseDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpPurchaseDate.Value2 = null;
            this.dtpPurchaseDate.YearsLinkTextControl = this.txtPurchaseDateYears;
            // 
            // itemHeadLabel2
            // 
            this.itemHeadLabel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.itemHeadLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemHeadLabel2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemHeadLabel2.ForeColor = System.Drawing.Color.White;
            this.itemHeadLabel2.Location = new System.Drawing.Point(834, 175);
            this.itemHeadLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemHeadLabel2.Name = "itemHeadLabel2";
            this.itemHeadLabel2.Size = new System.Drawing.Size(209, 24);
            this.itemHeadLabel2.TabIndex = 408;
            this.itemHeadLabel2.Text = "売上ＮＯ";
            this.itemHeadLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.itemHeadLabel2.Visible = false;
            // 
            // lblPersonnel
            // 
            this.lblPersonnel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonnel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonnel.ForeColor = System.Drawing.Color.White;
            this.lblPersonnel.Location = new System.Drawing.Point(834, 71);
            this.lblPersonnel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(209, 24);
            this.lblPersonnel.TabIndex = 406;
            this.lblPersonnel.Text = "担当者";
            this.lblPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddress.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(134, 175);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(700, 24);
            this.lblAddress.TabIndex = 402;
            this.lblAddress.Text = "住所";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZipCode
            // 
            this.lblZipCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblZipCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZipCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblZipCode.ForeColor = System.Drawing.Color.White;
            this.lblZipCode.Location = new System.Drawing.Point(4, 175);
            this.lblZipCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(130, 24);
            this.lblZipCode.TabIndex = 401;
            this.lblZipCode.Text = "郵便番号";
            this.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOffices
            // 
            this.lblOffices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffices.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOffices.ForeColor = System.Drawing.Color.White;
            this.lblOffices.Location = new System.Drawing.Point(834, 123);
            this.lblOffices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffices.Name = "lblOffices";
            this.lblOffices.Size = new System.Drawing.Size(209, 24);
            this.lblOffices.TabIndex = 390;
            this.lblOffices.Text = "事業所";
            this.lblOffices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerKanaName
            // 
            this.lblCustomerKanaName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerKanaName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerKanaName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerKanaName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerKanaName.Location = new System.Drawing.Point(367, 123);
            this.lblCustomerKanaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerKanaName.Name = "lblCustomerKanaName";
            this.lblCustomerKanaName.Size = new System.Drawing.Size(467, 24);
            this.lblCustomerKanaName.TabIndex = 388;
            this.lblCustomerKanaName.Text = "得意先カナ名";
            this.lblCustomerKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(134, 123);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(233, 24);
            this.lblCustomerName.TabIndex = 382;
            this.lblCustomerName.Text = "得意先名";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCode.Location = new System.Drawing.Point(4, 123);
            this.lblCustomerCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(130, 24);
            this.lblCustomerCode.TabIndex = 381;
            this.lblCustomerCode.Text = "得意先ｺｰﾄﾞ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(1043, 71);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(209, 24);
            this.lblOrderNo.TabIndex = 212;
            this.lblOrderNo.Text = "受注ＮＯ";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPurchaseNo
            // 
            this.lblPurchaseNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPurchaseNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPurchaseNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPurchaseNo.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseNo.Location = new System.Drawing.Point(5, 71);
            this.lblPurchaseNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchaseNo.Name = "lblPurchaseNo";
            this.lblPurchaseNo.Size = new System.Drawing.Size(129, 24);
            this.lblPurchaseNo.TabIndex = 113;
            this.lblPurchaseNo.Text = "仕入ＮＯ";
            this.lblPurchaseNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.rdoDelete);
            this.pnlProcessingMode.Controls.Add(this.lblProcessingMode);
            this.pnlProcessingMode.Controls.Add(this.rdoReference);
            this.pnlProcessingMode.Controls.Add(this.rdoCorrection);
            this.pnlProcessingMode.Controls.Add(this.rdoNew);
            this.pnlProcessingMode.Location = new System.Drawing.Point(4, 3);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(345, 65);
            this.pnlProcessingMode.TabIndex = 110;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoCheck = false;
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(257, 32);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(69, 24);
            this.rdoDelete.TabIndex = 5;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "削除";
            this.rdoDelete.UseVisualStyleBackColor = true;
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
            this.rdoReference.Location = new System.Drawing.Point(177, 32);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(69, 24);
            this.rdoReference.TabIndex = 2;
            this.rdoReference.TabStop = true;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoCheck = false;
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(97, 32);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(69, 24);
            this.rdoCorrection.TabIndex = 1;
            this.rdoCorrection.TabStop = true;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            // 
            // rdoNew
            // 
            this.rdoNew.AutoCheck = false;
            this.rdoNew.AutoSize = true;
            this.rdoNew.Checked = true;
            this.rdoNew.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(17, 32);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(69, 24);
            this.rdoNew.TabIndex = 0;
            this.rdoNew.TabStop = true;
            this.rdoNew.Text = "新規";
            this.rdoNew.UseVisualStyleBackColor = true;
            // 
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorName.ForeColor = System.Drawing.Color.White;
            this.lblVendorName.Location = new System.Drawing.Point(496, 71);
            this.lblVendorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(338, 24);
            this.lblVendorName.TabIndex = 44;
            this.lblVendorName.Text = "仕入先名";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendorCode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.ForeColor = System.Drawing.Color.White;
            this.lblVendorCode.Location = new System.Drawing.Point(366, 71);
            this.lblVendorCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(130, 24);
            this.lblVendorCode.TabIndex = 42;
            this.lblVendorCode.Text = "仕入先ｺｰﾄﾞ";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.btnCopyRow);
            this.pnlBody.Controls.Add(this.btnPasteRow);
            this.pnlBody.Controls.Add(this.grdPurchaseDetailsTotal);
            this.pnlBody.Controls.Add(this.grdPurchaseDetails);
            this.pnlBody.Controls.Add(this.btnDeleteRow);
            this.pnlBody.Controls.Add(this.btnInsertRow);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 235);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1259, 374);
            this.pnlBody.TabIndex = 311;
            // 
            // btnCopyRow
            // 
            this.btnCopyRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCopyRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopyRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopyRow.Location = new System.Drawing.Point(870, 2);
            this.btnCopyRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopyRow.Name = "btnCopyRow";
            this.btnCopyRow.Size = new System.Drawing.Size(94, 40);
            this.btnCopyRow.TabIndex = 321;
            this.btnCopyRow.Text = "行複写";
            this.btnCopyRow.UseVisualStyleBackColor = false;
            this.btnCopyRow.Click += new System.EventHandler(this.btnCopyRow_Click);
            // 
            // btnPasteRow
            // 
            this.btnPasteRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPasteRow.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPasteRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPasteRow.Location = new System.Drawing.Point(966, 2);
            this.btnPasteRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnPasteRow.Name = "btnPasteRow";
            this.btnPasteRow.Size = new System.Drawing.Size(94, 40);
            this.btnPasteRow.TabIndex = 331;
            this.btnPasteRow.Text = "行貼付";
            this.btnPasteRow.UseVisualStyleBackColor = false;
            this.btnPasteRow.Click += new System.EventHandler(this.btnPasteRow_Click);
            // 
            // grdPurchaseDetailsTotal
            // 
            this.grdPurchaseDetailsTotal.AllowUserToAddRows = false;
            this.grdPurchaseDetailsTotal.AllowUserToDeleteRows = false;
            this.grdPurchaseDetailsTotal.AllowUserToResizeColumns = false;
            this.grdPurchaseDetailsTotal.AllowUserToResizeRows = false;
            this.grdPurchaseDetailsTotal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseDetailsTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdPurchaseDetailsTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPurchaseDetailsTotal.ColumnHeadersVisible = false;
            this.grdPurchaseDetailsTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTotalAmountTitle,
            this.clmTotalAmount});
            this.grdPurchaseDetailsTotal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdPurchaseDetailsTotal.Enabled = false;
            this.grdPurchaseDetailsTotal.EnableHeadersVisualStyles = false;
            this.grdPurchaseDetailsTotal.Location = new System.Drawing.Point(876, 338);
            this.grdPurchaseDetailsTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdPurchaseDetailsTotal.MultiSelect = false;
            this.grdPurchaseDetailsTotal.Name = "grdPurchaseDetailsTotal";
            this.grdPurchaseDetailsTotal.ReadOnly = true;
            this.grdPurchaseDetailsTotal.RowHeadersVisible = false;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdPurchaseDetailsTotal.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.grdPurchaseDetailsTotal.RowTemplate.Height = 26;
            this.grdPurchaseDetailsTotal.Size = new System.Drawing.Size(357, 27);
            this.grdPurchaseDetailsTotal.TabIndex = 26;
            // 
            // clmTotalAmountTitle
            // 
            this.clmTotalAmountTitle.DataPropertyName = "TotalTitle";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.clmTotalAmountTitle.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmTotalAmountTitle.HeaderText = "仕入計見出し";
            this.clmTotalAmountTitle.Name = "clmTotalAmountTitle";
            this.clmTotalAmountTitle.ReadOnly = true;
            this.clmTotalAmountTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTotalAmountTitle.Width = 177;
            // 
            // clmTotalAmount
            // 
            this.clmTotalAmount.DataPropertyName = "Total";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.clmTotalAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmTotalAmount.HeaderText = "仕入計";
            this.clmTotalAmount.Name = "clmTotalAmount";
            this.clmTotalAmount.ReadOnly = true;
            this.clmTotalAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTotalAmount.Width = 177;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 609);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1259, 70);
            this.pnlBottom.TabIndex = 371;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(1136, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 411;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.Location = new System.Drawing.Point(561, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 42);
            this.lblTitle.TabIndex = 412;
            this.lblTitle.Text = "仕入";
            // 
            // frmShiireInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1259, 679);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmShiireInput";
            this.ShowIcon = false;
            this.Text = "仕入入力";
            this.Load += new System.EventHandler(this.frmShiireInput_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPurchaseDate.ResumeLayout(false);
            this.pnlPurchaseDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseDetails)).EndInit();
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseDetailsTotal)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private Common.FeaturesButton btnDeleteRow;
        private Common.FeaturesButton btnInsertRow;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdPurchaseDetails;
        private Common.CustomTextBox txtVendorName;
        private Common.ItemHeadLabel lblVendorName;
        private Common.CustomTextBox txtVendorCode;
        private Common.ItemHeadLabel lblVendorCode;
        private System.Windows.Forms.DataGridView grdPurchaseDetailsTotal;
        private Common.FeaturesButton btnPasteRow;
        private Common.FeaturesButton btnCopyRow;
        private System.Windows.Forms.Panel pnlProcessingMode;
        private System.Windows.Forms.RadioButton rdoDelete;
        private Common.ItemHeadLabel lblProcessingMode;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private Common.FeaturesButton btnClose;
        private Common.CustomTextBox txtPurchaseNo;
        private Common.ItemHeadLabel lblPurchaseNo;
        private Common.CustomTextBox txtOrderNo;
        private Common.ItemHeadLabel lblOrderNo;
        private Common.ItemHeadLabel lblOffices;
        private Common.CustomComboBox cmbOffices;
        private Common.CustomTextBox txtCustomerKanaName;
        private Common.CustomTextBox txtCustomerName;
        private Common.CustomTextBox txtCustomerCode;
        private Common.ItemHeadLabel lblCustomerKanaName;
        private Common.ItemHeadLabel lblCustomerName;
        private Common.ItemHeadLabel lblCustomerCode;
        private Common.CustomTextBox txtAddress1;
        private Common.CustomTextBox txtAddress2;
        private Common.CustomTextBox txtZipCode;
        private Common.ItemHeadLabel lblAddress;
        private Common.ItemHeadLabel lblZipCode;
        private Common.CustomTextBox txtSalesNo;
        private Common.ItemHeadLabel itemHeadLabel2;
        private Common.CustomComboBox cmbPersonnel;
        private Common.ItemHeadLabel lblPersonnel;
        private Common.ItemHeadLabel lblPurchaseDate;
        private System.Windows.Forms.Panel pnlPurchaseDate;
        private System.Windows.Forms.Label lblPurchaseDateDays;
        private Common.CustomTextBox txtPurchaseDateDays;
        private Common.CustomTextBox txtPurchaseDateMonth;
        private Common.CustomTextBox txtPurchaseDateYears;
        private System.Windows.Forms.Label lblPurchaseDateMonth;
        private System.Windows.Forms.Label lblPurchaseDateYears;
        private Common.CustomDateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalAmountTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRowStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTopClassificationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbtmClassificationCode;
        private System.Windows.Forms.Label lblTitle;
    }
}