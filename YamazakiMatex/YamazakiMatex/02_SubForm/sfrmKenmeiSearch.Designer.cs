namespace SubForm
{
    partial class sfrmKenmeiSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtConstructionNoFrom = new Common.CustomTextBox();
            this.grdSearchList = new Common.CustomDataGridView();
            this.clmConstructionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConstructionNoTo = new Common.CustomTextBox();
            this.txtSubject = new Common.CustomTextBox();
            this.btnSearch = new Common.FeaturesButton();
            this.btnCheck = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.pnlRowSelectMode = new System.Windows.Forms.Panel();
            this.lblRowSelectMode = new Common.ItemHeadLabel();
            this.rdoRange = new System.Windows.Forms.RadioButton();
            this.rdoMulti = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.lblSubject = new Common.ItemHeadLabel();
            this.lblConstructionNo = new Common.ItemHeadLabel();
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
            // txtConstructionNoFrom
            // 
            this.txtConstructionNoFrom.BeforeValue = "";
            this.txtConstructionNoFrom.DownControl = this.grdSearchList;
            this.txtConstructionNoFrom.EnterControl = this.txtConstructionNoTo;
            this.txtConstructionNoFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtConstructionNoFrom.LabelControl = null;
            this.txtConstructionNoFrom.LeftControl = null;
            this.txtConstructionNoFrom.Location = new System.Drawing.Point(133, 79);
            this.txtConstructionNoFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConstructionNoFrom.MaxLength = 5;
            this.txtConstructionNoFrom.Name = "txtConstructionNoFrom";
            this.txtConstructionNoFrom.RightControl = this.txtConstructionNoTo;
            this.txtConstructionNoFrom.Size = new System.Drawing.Size(130, 27);
            this.txtConstructionNoFrom.TabIndex = 40;
            this.txtConstructionNoFrom.Text = "XXXXXXX8";
            this.txtConstructionNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConstructionNoFrom.UpControl = null;
            this.txtConstructionNoFrom.Leave += new System.EventHandler(this.txtConstructionNo_Leave);
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
            this.clmConstructionNo,
            this.clmSubject});
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSearchList.RowSegmentCount = 1;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.ScrollRowCount = 3;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(780, 287);
            this.grdSearchList.TabIndex = 80;
            this.grdSearchList.UpControl = this.txtConstructionNoFrom;
            this.grdSearchList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchList_CellDoubleClick);
            this.grdSearchList.CurrentCellChanged += new System.EventHandler(this.grdSearchList_CurrentCellChanged);
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.grdSearchList_Paint);
            // 
            // clmConstructionNo
            // 
            this.clmConstructionNo.DataPropertyName = "kenmeiNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmConstructionNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmConstructionNo.HeaderText = "件名NO";
            this.clmConstructionNo.Name = "clmConstructionNo";
            this.clmConstructionNo.ReadOnly = true;
            this.clmConstructionNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmConstructionNo.Width = 130;
            // 
            // clmSubject
            // 
            this.clmSubject.DataPropertyName = "kenmei1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmSubject.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmSubject.HeaderText = "件名";
            this.clmSubject.Name = "clmSubject";
            this.clmSubject.ReadOnly = true;
            this.clmSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubject.Width = 629;
            // 
            // txtConstructionNoTo
            // 
            this.txtConstructionNoTo.BeforeValue = "";
            this.txtConstructionNoTo.DownControl = this.grdSearchList;
            this.txtConstructionNoTo.EnterControl = this.txtSubject;
            this.txtConstructionNoTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtConstructionNoTo.LabelControl = null;
            this.txtConstructionNoTo.LeftControl = this.txtConstructionNoFrom;
            this.txtConstructionNoTo.Location = new System.Drawing.Point(306, 79);
            this.txtConstructionNoTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConstructionNoTo.MaxLength = 5;
            this.txtConstructionNoTo.Name = "txtConstructionNoTo";
            this.txtConstructionNoTo.RightControl = this.txtSubject;
            this.txtConstructionNoTo.Size = new System.Drawing.Size(130, 27);
            this.txtConstructionNoTo.TabIndex = 50;
            this.txtConstructionNoTo.Text = "XXXXXXX8";
            this.txtConstructionNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConstructionNoTo.UpControl = null;
            this.txtConstructionNoTo.Leave += new System.EventHandler(this.txtConstructionNo_Leave);
            // 
            // txtSubject
            // 
            this.txtSubject.BeforeValue = "";
            this.txtSubject.DownControl = this.grdSearchList;
            this.txtSubject.EnterControl = this.grdSearchList;
            this.txtSubject.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtSubject.LabelControl = null;
            this.txtSubject.LeftControl = this.txtConstructionNoTo;
            this.txtSubject.Location = new System.Drawing.Point(567, 79);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject.MaxLength = 15;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.RightControl = null;
            this.txtSubject.Size = new System.Drawing.Size(216, 27);
            this.txtSubject.TabIndex = 60;
            this.txtSubject.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５";
            this.txtSubject.UpControl = null;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 40);
            this.btnSearch.TabIndex = 100;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(571, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 130;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(681, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 40);
            this.btnBack.TabIndex = 140;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.txtConstructionNoTo);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.pnlRowSelectMode);
            this.pnlHeader.Controls.Add(this.lblSubject);
            this.pnlHeader.Controls.Add(this.lblConstructionNo);
            this.pnlHeader.Controls.Add(this.txtConstructionNoFrom);
            this.pnlHeader.Controls.Add(this.txtSubject);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(789, 115);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated1.Location = new System.Drawing.Point(270, 82);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 74;
            this.lblFromToSeparated1.Text = "～";
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
            this.pnlRowSelectMode.TabIndex = 51;
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
            this.rdoRange.TabIndex = 30;
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
            this.rdoMulti.TabIndex = 20;
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
            this.rdoSingle.TabIndex = 10;
            this.rdoSingle.TabStop = true;
            this.rdoSingle.Text = "単一";
            this.rdoSingle.UseVisualStyleBackColor = true;
            this.rdoSingle.CheckedChanged += new System.EventHandler(this.rdoSingle_CheckedChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubject.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(437, 79);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(130, 27);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "件名";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConstructionNo
            // 
            this.lblConstructionNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblConstructionNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConstructionNo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConstructionNo.ForeColor = System.Drawing.Color.White;
            this.lblConstructionNo.Location = new System.Drawing.Point(3, 79);
            this.lblConstructionNo.Name = "lblConstructionNo";
            this.lblConstructionNo.Size = new System.Drawing.Size(130, 27);
            this.lblConstructionNo.TabIndex = 3;
            this.lblConstructionNo.Text = "件名NO";
            this.lblConstructionNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 115);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(789, 301);
            this.pnlBody.TabIndex = 70;
            // 
            // pnlBottom
            // 
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
            this.pnlBottom.Size = new System.Drawing.Size(789, 70);
            this.pnlBottom.TabIndex = 90;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(461, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 40);
            this.btnCancel.TabIndex = 332;
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
            this.btnSelectCancel.TabIndex = 120;
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
            this.btnAllSelect.TabIndex = 110;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // sfrmKenmeiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(789, 486);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmKenmeiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "件名検索";
            this.Load += new System.EventHandler(this.sfrmKenmeiSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRowSelectMode.ResumeLayout(false);
            this.pnlRowSelectMode.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Common.CustomTextBox txtConstructionNoFrom;
        private Common.CustomTextBox txtSubject;
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnCheck;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdSearchList;
        private Common.ItemHeadLabel lblConstructionNo;
        private Common.ItemHeadLabel lblSubject;
        private Common.FeaturesButton btnSelectCancel;
        private Common.FeaturesButton btnAllSelect;
        private System.Windows.Forms.Panel pnlRowSelectMode;
        private Common.ItemHeadLabel lblRowSelectMode;
        private System.Windows.Forms.RadioButton rdoRange;
        private System.Windows.Forms.RadioButton rdoMulti;
        private System.Windows.Forms.RadioButton rdoSingle;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private Common.CustomTextBox txtConstructionNoTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConstructionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
        private Common.FeaturesButton btnCancel;
    }
}