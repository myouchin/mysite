namespace Master
{
    partial class frmMeisyoM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel20 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdTypeList = new Common.CustomDataGridView();
            this.clmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeName = new Common.CustomTextBox();
            this.txtType = new Common.CustomTextBox();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtName = new Common.CustomTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNameCode = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbNameCode = new Common.CustomComboBox();
            this.txtNameCode = new Common.CustomTextBox();
            this.txtBeforeType = new Common.CustomTextBox();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTypeList)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel20.Controls.Add(this.btnSave);
            this.panel20.Controls.Add(this.btnCancel);
            this.panel20.Controls.Add(this.btnClose);
            this.panel20.Location = new System.Drawing.Point(42, 475);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(598, 72);
            this.panel20.TabIndex = 42;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(176, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 47);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(307, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 47);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(437, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 47);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdTypeList
            // 
            this.grdTypeList.AllowUserToAddRows = false;
            this.grdTypeList.AllowUserToDeleteRows = false;
            this.grdTypeList.AllowUserToResizeColumns = false;
            this.grdTypeList.AllowUserToResizeRows = false;
            this.grdTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTypeList.ColumnHeadersVisible = false;
            this.grdTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmType,
            this.clmTypeName});
            this.grdTypeList.DownControl = null;
            this.grdTypeList.EnterControl = null;
            this.grdTypeList.FlgSetCurrentCell = true;
            this.grdTypeList.LeftControl = null;
            this.grdTypeList.Location = new System.Drawing.Point(257, 233);
            this.grdTypeList.MultiSelect = false;
            this.grdTypeList.Name = "grdTypeList";
            this.grdTypeList.ReadOnly = true;
            this.grdTypeList.RightControl = null;
            this.grdTypeList.RowHeadersVisible = false;
            this.grdTypeList.RowSegmentCount = 1;
            this.grdTypeList.RowTemplate.Height = 21;
            this.grdTypeList.ScrollRowCount = 3;
            this.grdTypeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTypeList.Size = new System.Drawing.Size(383, 216);
            this.grdTypeList.TabIndex = 41;
            this.grdTypeList.UpControl = null;
            this.grdTypeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTypeList_CellClick);
            // 
            // clmType
            // 
            this.clmType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmType.DataPropertyName = "kubun";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmType.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmType.HeaderText = "区分";
            this.clmType.Name = "clmType";
            this.clmType.ReadOnly = true;
            this.clmType.Width = 112;
            // 
            // clmTypeName
            // 
            this.clmTypeName.DataPropertyName = "kubunName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmTypeName.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmTypeName.HeaderText = "区分名";
            this.clmTypeName.Name = "clmTypeName";
            this.clmTypeName.ReadOnly = true;
            this.clmTypeName.Width = 250;
            // 
            // txtTypeName
            // 
            this.txtTypeName.BeforeValue = "";
            this.txtTypeName.DownControl = null;
            this.txtTypeName.EnterControl = null;
            this.txtTypeName.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTypeName.LabelControl = null;
            this.txtTypeName.LeftControl = null;
            this.txtTypeName.Location = new System.Drawing.Point(370, 202);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.RightControl = null;
            this.txtTypeName.Size = new System.Drawing.Size(251, 23);
            this.txtTypeName.TabIndex = 40;
            this.txtTypeName.UpControl = null;
            // 
            // txtType
            // 
            this.txtType.BeforeValue = "";
            this.txtType.DownControl = null;
            this.txtType.EnterControl = null;
            this.txtType.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtType.LabelControl = null;
            this.txtType.LeftControl = null;
            this.txtType.Location = new System.Drawing.Point(257, 202);
            this.txtType.Name = "txtType";
            this.txtType.RightControl = null;
            this.txtType.Size = new System.Drawing.Size(107, 23);
            this.txtType.TabIndex = 39;
            this.txtType.UpControl = null;
            // 
            // lblTypeName
            // 
            this.lblTypeName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTypeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTypeName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTypeName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTypeName.Location = new System.Drawing.Point(370, 169);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTypeName.Size = new System.Drawing.Size(251, 29);
            this.lblTypeName.TabIndex = 38;
            this.lblTypeName.Text = "区分名";
            this.lblTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblType.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblType.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblType.Location = new System.Drawing.Point(257, 169);
            this.lblType.Name = "lblType";
            this.lblType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblType.Size = new System.Drawing.Size(107, 29);
            this.lblType.TabIndex = 37;
            this.lblType.Text = "区分";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.BeforeValue = "";
            this.txtName.DownControl = null;
            this.txtName.EnterControl = null;
            this.txtName.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.LabelControl = null;
            this.txtName.LeftControl = null;
            this.txtName.Location = new System.Drawing.Point(375, 117);
            this.txtName.Name = "txtName";
            this.txtName.RightControl = null;
            this.txtName.Size = new System.Drawing.Size(206, 23);
            this.txtName.TabIndex = 36;
            this.txtName.Text = "令令令令令令令令令令";
            this.txtName.UpControl = null;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblName.Location = new System.Drawing.Point(257, 117);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(111, 25);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "名　称";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameCode
            // 
            this.lblNameCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblNameCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNameCode.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNameCode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNameCode.Location = new System.Drawing.Point(45, 117);
            this.lblNameCode.Name = "lblNameCode";
            this.lblNameCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNameCode.Size = new System.Drawing.Size(111, 25);
            this.lblNameCode.TabIndex = 33;
            this.lblNameCode.Text = "名称コード";
            this.lblNameCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(345, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(205, 42);
            this.label19.TabIndex = 32;
            this.label19.Text = "名称マスタ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.rdoReference);
            this.panel4.Controls.Add(this.rdoCorrection);
            this.panel4.Controls.Add(this.rdoNew);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(42, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 73);
            this.panel4.TabIndex = 31;
            // 
            // rdoReference
            // 
            this.rdoReference.AutoCheck = false;
            this.rdoReference.AutoSize = true;
            this.rdoReference.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoReference.Location = new System.Drawing.Point(183, 37);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(67, 23);
            this.rdoReference.TabIndex = 3;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            this.rdoReference.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoCheck = false;
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(96, 37);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(67, 23);
            this.rdoCorrection.TabIndex = 2;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            this.rdoCorrection.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoNew
            // 
            this.rdoNew.AutoCheck = false;
            this.rdoNew.AutoSize = true;
            this.rdoNew.Checked = true;
            this.rdoNew.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(8, 38);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(67, 23);
            this.rdoNew.TabIndex = 1;
            this.rdoNew.TabStop = true;
            this.rdoNew.Text = "新規";
            this.rdoNew.UseVisualStyleBackColor = true;
            this.rdoNew.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(6, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　処理モード　";
            // 
            // cmbNameCode
            // 
            this.cmbNameCode.BeforeSelectedValue = "";
            this.cmbNameCode.DownControl = null;
            this.cmbNameCode.EnterControl = null;
            this.cmbNameCode.Font = new System.Drawing.Font("ＭＳ 明朝", 11F);
            this.cmbNameCode.FormattingEnabled = true;
            this.cmbNameCode.LabelControl = null;
            this.cmbNameCode.LeftControl = null;
            this.cmbNameCode.Location = new System.Drawing.Point(162, 117);
            this.cmbNameCode.Name = "cmbNameCode";
            this.cmbNameCode.RightControl = null;
            this.cmbNameCode.Size = new System.Drawing.Size(89, 23);
            this.cmbNameCode.TabIndex = 43;
            this.cmbNameCode.UpControl = null;
            this.cmbNameCode.SelectedIndexChanged += new System.EventHandler(this.cmbNameCode_SelectedIndexChanged);
            // 
            // txtNameCode
            // 
            this.txtNameCode.BeforeValue = "";
            this.txtNameCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNameCode.DownControl = null;
            this.txtNameCode.EnterControl = null;
            this.txtNameCode.Font = new System.Drawing.Font("ＭＳ 明朝", 12F);
            this.txtNameCode.LabelControl = null;
            this.txtNameCode.LeftControl = null;
            this.txtNameCode.Location = new System.Drawing.Point(164, 120);
            this.txtNameCode.Name = "txtNameCode";
            this.txtNameCode.RightControl = null;
            this.txtNameCode.Size = new System.Drawing.Size(70, 16);
            this.txtNameCode.TabIndex = 44;
            this.txtNameCode.UpControl = null;
            // 
            // txtBeforeType
            // 
            this.txtBeforeType.BeforeValue = "";
            this.txtBeforeType.DownControl = null;
            this.txtBeforeType.EnterControl = null;
            this.txtBeforeType.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBeforeType.LabelControl = null;
            this.txtBeforeType.LeftControl = null;
            this.txtBeforeType.Location = new System.Drawing.Point(144, 202);
            this.txtBeforeType.Name = "txtBeforeType";
            this.txtBeforeType.RightControl = null;
            this.txtBeforeType.Size = new System.Drawing.Size(107, 23);
            this.txtBeforeType.TabIndex = 45;
            this.txtBeforeType.UpControl = null;
            this.txtBeforeType.Visible = false;
            // 
            // frmMeisyoM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 571);
            this.Controls.Add(this.txtBeforeType);
            this.Controls.Add(this.txtNameCode);
            this.Controls.Add(this.cmbNameCode);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.grdTypeList);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNameCode);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel4);
            this.Name = "frmMeisyoM";
            this.Text = "名称マスタ";
            this.Load += new System.EventHandler(this.frmMeisyoM_Load);
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTypeList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private Common.CustomDataGridView grdTypeList;
        private Common.CustomTextBox txtTypeName;
        private Common.CustomTextBox txtType;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label lblType;
        private Common.CustomTextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private System.Windows.Forms.Label label27;
        private Common.CustomComboBox cmbNameCode;
        private Common.CustomTextBox txtNameCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTypeName;
        private Common.CustomTextBox txtBeforeType;
    }
}