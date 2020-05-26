namespace SeikyuKoshin
{
    partial class frmSeikyuChange
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.grdSeikyuList = new Common.CustomDataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnSearchCriteria = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.clmDocumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDocumentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOffice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBillingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBillingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforeBillingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSeikyuList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.grdSeikyuList);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1565, 569);
            this.pnlHeader.TabIndex = 104;
            // 
            // grdSeikyuList
            // 
            this.grdSeikyuList.AllowUserToAddRows = false;
            this.grdSeikyuList.AllowUserToDeleteRows = false;
            this.grdSeikyuList.AllowUserToResizeColumns = false;
            this.grdSeikyuList.AllowUserToResizeRows = false;
            this.grdSeikyuList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSeikyuList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSeikyuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSeikyuList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDocumentNo,
            this.clmDocumentDate,
            this.clmCustomerName,
            this.clmOffice,
            this.clmItemName,
            this.clmQuantity,
            this.clmUnit,
            this.clmBid,
            this.clmAmount,
            this.clmBillingDate,
            this.clmBillingType,
            this.clmBeforeBillingDate,
            this.clmRowNo});
            this.grdSeikyuList.DownControl = null;
            this.grdSeikyuList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdSeikyuList.EnableHeadersVisualStyles = false;
            this.grdSeikyuList.EnterControl = null;
            this.grdSeikyuList.FlgSetCurrentCell = true;
            this.grdSeikyuList.LeftControl = null;
            this.grdSeikyuList.Location = new System.Drawing.Point(11, 12);
            this.grdSeikyuList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSeikyuList.MultiSelect = false;
            this.grdSeikyuList.Name = "grdSeikyuList";
            this.grdSeikyuList.RightControl = null;
            this.grdSeikyuList.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSeikyuList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdSeikyuList.RowSegmentCount = 1;
            this.grdSeikyuList.RowTemplate.Height = 26;
            this.grdSeikyuList.ScrollRowCount = 3;
            this.grdSeikyuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdSeikyuList.Size = new System.Drawing.Size(1546, 547);
            this.grdSeikyuList.TabIndex = 442;
            this.grdSeikyuList.UpControl = null;
            this.grdSeikyuList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdSeikyuList_CellPainting);
            this.grdSeikyuList.CurrentCellChanged += new System.EventHandler(this.grdSeikyuList_CurrentCellChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnSearchCriteria);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 569);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1565, 70);
            this.pnlBottom.TabIndex = 107;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(1327, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 40);
            this.btnCancel.TabIndex = 471;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(1213, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 40);
            this.btnSave.TabIndex = 461;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearchCriteria
            // 
            this.btnSearchCriteria.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearchCriteria.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearchCriteria.Location = new System.Drawing.Point(11, 15);
            this.btnSearchCriteria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearchCriteria.Name = "btnSearchCriteria";
            this.btnSearchCriteria.Size = new System.Drawing.Size(141, 40);
            this.btnSearchCriteria.TabIndex = 441;
            this.btnSearchCriteria.Text = "F1：検索条件";
            this.btnSearchCriteria.UseVisualStyleBackColor = false;
            this.btnSearchCriteria.Click += new System.EventHandler(this.btnSearchCriteria_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(1441, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // clmDocumentNo
            // 
            this.clmDocumentNo.DataPropertyName = "denpyoNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.clmDocumentNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmDocumentNo.HeaderText = "伝票番号";
            this.clmDocumentNo.Name = "clmDocumentNo";
            this.clmDocumentNo.ReadOnly = true;
            this.clmDocumentNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDocumentNo.Width = 104;
            // 
            // clmDocumentDate
            // 
            this.clmDocumentDate.DataPropertyName = "denpyoHizuke";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmDocumentDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmDocumentDate.HeaderText = "伝票日付";
            this.clmDocumentDate.Name = "clmDocumentDate";
            this.clmDocumentDate.ReadOnly = true;
            this.clmDocumentDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDocumentDate.Width = 110;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.DataPropertyName = "tokuisakiName";
            this.clmCustomerName.HeaderText = "得意先名";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCustomerName.Width = 208;
            // 
            // clmOffice
            // 
            this.clmOffice.DataPropertyName = "jigyousyoName";
            this.clmOffice.HeaderText = "事業所名";
            this.clmOffice.Name = "clmOffice";
            this.clmOffice.ReadOnly = true;
            this.clmOffice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmOffice.Width = 142;
            // 
            // clmItemName
            // 
            this.clmItemName.DataPropertyName = "shouhinName1";
            this.clmItemName.HeaderText = "商品名";
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.ReadOnly = true;
            this.clmItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmItemName.Width = 289;
            // 
            // clmQuantity
            // 
            this.clmQuantity.DataPropertyName = "suryo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.clmQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmQuantity.HeaderText = "数量";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.ReadOnly = true;
            this.clmQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmQuantity.Width = 132;
            // 
            // clmUnit
            // 
            this.clmUnit.DataPropertyName = "tani";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmUnit.HeaderText = "単位";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmBid
            // 
            this.clmBid.DataPropertyName = "tanka";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.clmBid.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmBid.HeaderText = "単価";
            this.clmBid.Name = "clmBid";
            this.clmBid.ReadOnly = true;
            this.clmBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBid.Width = 132;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "kingaku";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmAmount.HeaderText = "金額";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.ReadOnly = true;
            this.clmAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmAmount.Width = 98;
            // 
            // clmBillingDate
            // 
            this.clmBillingDate.DataPropertyName = "seikyuHizuke";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmBillingDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmBillingDate.HeaderText = "請求日";
            this.clmBillingDate.Name = "clmBillingDate";
            this.clmBillingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBillingDate.Width = 110;
            // 
            // clmBillingType
            // 
            this.clmBillingType.DataPropertyName = "seikyuHuragu";
            this.clmBillingType.HeaderText = "請求区分";
            this.clmBillingType.Name = "clmBillingType";
            this.clmBillingType.ReadOnly = true;
            this.clmBillingType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmBeforeBillingDate
            // 
            this.clmBeforeBillingDate.DataPropertyName = "beforeSeikyuHizuke";
            this.clmBeforeBillingDate.HeaderText = "(変更前)請求日";
            this.clmBeforeBillingDate.Name = "clmBeforeBillingDate";
            this.clmBeforeBillingDate.ReadOnly = true;
            this.clmBeforeBillingDate.Visible = false;
            // 
            // clmRowNo
            // 
            this.clmRowNo.DataPropertyName = "rowNo";
            this.clmRowNo.HeaderText = "行番号";
            this.clmRowNo.Name = "clmRowNo";
            this.clmRowNo.ReadOnly = true;
            this.clmRowNo.Visible = false;
            // 
            // frmSeikyuChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 639);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmSeikyuChange";
            this.Text = "締日変更";
            this.Load += new System.EventHandler(this.frmSeikyuChange_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSeikyuList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnSearchCriteria;
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private Common.CustomDataGridView grdSeikyuList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDocumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDocumentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOffice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBillingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBillingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforeBillingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRowNo;
    }
}