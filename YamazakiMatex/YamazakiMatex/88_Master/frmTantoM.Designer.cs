namespace Master
{
    partial class frmTantoM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPersonCode = new System.Windows.Forms.Label();
            this.txtPersonCode = new Common.CustomTextBox();
            this.txtPersonName = new Common.CustomTextBox();
            this.txtAuthority = new Common.CustomTextBox();
            this.txtPass = new Common.CustomTextBox();
            this.txtMail = new Common.CustomTextBox();
            this.txtOrderNo = new Common.CustomTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblAuthority = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.grdPersonList = new Common.CustomDataGridView();
            this.clmPersonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAuthority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforePersonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforePersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforeAuthority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforePass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforeMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBeforeOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonList)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(485, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(250, 42);
            this.label19.TabIndex = 34;
            this.label19.Text = "担当者マスタ";
            // 
            // lblPersonCode
            // 
            this.lblPersonCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPersonCode.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonCode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPersonCode.Location = new System.Drawing.Point(37, 131);
            this.lblPersonCode.Name = "lblPersonCode";
            this.lblPersonCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPersonCode.Size = new System.Drawing.Size(132, 29);
            this.lblPersonCode.TabIndex = 43;
            this.lblPersonCode.Text = "担当者コード";
            this.lblPersonCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPersonCode
            // 
            this.txtPersonCode.BeforeValue = "";
            this.txtPersonCode.DownControl = null;
            this.txtPersonCode.EnterControl = this.txtPersonName;
            this.txtPersonCode.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPersonCode.LabelControl = null;
            this.txtPersonCode.LeftControl = null;
            this.txtPersonCode.Location = new System.Drawing.Point(37, 164);
            this.txtPersonCode.Name = "txtPersonCode";
            this.txtPersonCode.RightControl = this.txtPersonName;
            this.txtPersonCode.Size = new System.Drawing.Size(133, 23);
            this.txtPersonCode.TabIndex = 50;
            this.txtPersonCode.UpControl = null;
            // 
            // txtPersonName
            // 
            this.txtPersonName.BeforeValue = "";
            this.txtPersonName.DownControl = null;
            this.txtPersonName.EnterControl = this.txtAuthority;
            this.txtPersonName.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPersonName.LabelControl = null;
            this.txtPersonName.LeftControl = this.txtPersonCode;
            this.txtPersonName.Location = new System.Drawing.Point(169, 164);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.RightControl = this.txtAuthority;
            this.txtPersonName.Size = new System.Drawing.Size(211, 23);
            this.txtPersonName.TabIndex = 60;
            this.txtPersonName.UpControl = null;
            // 
            // txtAuthority
            // 
            this.txtAuthority.BeforeValue = "";
            this.txtAuthority.DownControl = null;
            this.txtAuthority.EnterControl = this.txtPass;
            this.txtAuthority.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAuthority.LabelControl = null;
            this.txtAuthority.LeftControl = this.txtPersonName;
            this.txtAuthority.Location = new System.Drawing.Point(379, 164);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.RightControl = this.txtPass;
            this.txtAuthority.Size = new System.Drawing.Size(65, 23);
            this.txtAuthority.TabIndex = 70;
            this.txtAuthority.UpControl = null;
            // 
            // txtPass
            // 
            this.txtPass.BeforeValue = "";
            this.txtPass.DownControl = null;
            this.txtPass.EnterControl = this.txtMail;
            this.txtPass.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPass.LabelControl = null;
            this.txtPass.LeftControl = this.txtAuthority;
            this.txtPass.Location = new System.Drawing.Point(443, 164);
            this.txtPass.Name = "txtPass";
            this.txtPass.RightControl = this.txtMail;
            this.txtPass.Size = new System.Drawing.Size(101, 23);
            this.txtPass.TabIndex = 80;
            this.txtPass.UpControl = null;
            // 
            // txtMail
            // 
            this.txtMail.BeforeValue = "";
            this.txtMail.DownControl = null;
            this.txtMail.EnterControl = this.txtOrderNo;
            this.txtMail.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMail.LabelControl = null;
            this.txtMail.LeftControl = this.txtPass;
            this.txtMail.Location = new System.Drawing.Point(543, 164);
            this.txtMail.Name = "txtMail";
            this.txtMail.RightControl = this.txtOrderNo;
            this.txtMail.Size = new System.Drawing.Size(491, 23);
            this.txtMail.TabIndex = 90;
            this.txtMail.UpControl = null;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BeforeValue = "";
            this.txtOrderNo.DownControl = null;
            this.txtOrderNo.EnterControl = null;
            this.txtOrderNo.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOrderNo.LabelControl = null;
            this.txtOrderNo.LeftControl = this.txtMail;
            this.txtOrderNo.Location = new System.Drawing.Point(1033, 164);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.RightControl = null;
            this.txtOrderNo.Size = new System.Drawing.Size(82, 23);
            this.txtOrderNo.TabIndex = 100;
            this.txtOrderNo.UpControl = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(40, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 72);
            this.panel1.TabIndex = 120;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(680, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 47);
            this.btnSave.TabIndex = 130;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(810, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 47);
            this.btnCancel.TabIndex = 140;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(940, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 47);
            this.btnClose.TabIndex = 150;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMail
            // 
            this.lblMail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMail.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMail.Location = new System.Drawing.Point(544, 131);
            this.lblMail.Name = "lblMail";
            this.lblMail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMail.Size = new System.Drawing.Size(489, 29);
            this.lblMail.TabIndex = 48;
            this.lblMail.Text = "メールアドレス";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPass
            // 
            this.lblPass.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPass.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPass.Location = new System.Drawing.Point(444, 131);
            this.lblPass.Name = "lblPass";
            this.lblPass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPass.Size = new System.Drawing.Size(99, 29);
            this.lblPass.TabIndex = 47;
            this.lblPass.Text = "パスワード";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAuthority
            // 
            this.lblAuthority.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAuthority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAuthority.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAuthority.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAuthority.Location = new System.Drawing.Point(380, 131);
            this.lblAuthority.Name = "lblAuthority";
            this.lblAuthority.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAuthority.Size = new System.Drawing.Size(63, 29);
            this.lblAuthority.TabIndex = 45;
            this.lblAuthority.Text = "権限";
            this.lblAuthority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPersonName
            // 
            this.lblPersonName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPersonName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPersonName.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPersonName.Location = new System.Drawing.Point(170, 131);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPersonName.Size = new System.Drawing.Size(209, 29);
            this.lblPersonName.TabIndex = 43;
            this.lblPersonName.Text = "担当者名";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOrderNo.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrderNo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOrderNo.Location = new System.Drawing.Point(1034, 131);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderNo.Size = new System.Drawing.Size(81, 29);
            this.lblOrderNo.TabIndex = 53;
            this.lblOrderNo.Text = "注文番号";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.rdoDelete);
            this.panel4.Controls.Add(this.rdoReference);
            this.panel4.Controls.Add(this.rdoCorrection);
            this.panel4.Controls.Add(this.rdoNew);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(37, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(426, 79);
            this.panel4.TabIndex = 1;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoCheck = false;
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(313, 40);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(67, 23);
            this.rdoDelete.TabIndex = 40;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "削除";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoReference
            // 
            this.rdoReference.AutoCheck = false;
            this.rdoReference.AutoSize = true;
            this.rdoReference.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoReference.Location = new System.Drawing.Point(213, 40);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(67, 23);
            this.rdoReference.TabIndex = 30;
            this.rdoReference.TabStop = true;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            this.rdoReference.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoCheck = false;
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(112, 40);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(67, 23);
            this.rdoCorrection.TabIndex = 20;
            this.rdoCorrection.TabStop = true;
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
            this.rdoNew.Location = new System.Drawing.Point(9, 41);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(67, 23);
            this.rdoNew.TabIndex = 10;
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
            this.label27.Location = new System.Drawing.Point(8, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　処理モード　";
            // 
            // grdPersonList
            // 
            this.grdPersonList.AllowUserToAddRows = false;
            this.grdPersonList.AllowUserToDeleteRows = false;
            this.grdPersonList.AllowUserToResizeColumns = false;
            this.grdPersonList.AllowUserToResizeRows = false;
            this.grdPersonList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPersonList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPersonList.ColumnHeadersVisible = false;
            this.grdPersonList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPersonCode,
            this.clmPersonName,
            this.clmAuthority,
            this.clmPass,
            this.clmMail,
            this.clmOrderNo,
            this.clmBeforePersonCode,
            this.clmBeforePersonName,
            this.clmBeforeAuthority,
            this.clmBeforePass,
            this.clmBeforeMail,
            this.clmBeforeOrderNo});
            this.grdPersonList.DownControl = null;
            this.grdPersonList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdPersonList.EnableHeadersVisualStyles = false;
            this.grdPersonList.EnterControl = null;
            this.grdPersonList.FlgSetCurrentCell = true;
            this.grdPersonList.LeftControl = null;
            this.grdPersonList.Location = new System.Drawing.Point(40, 195);
            this.grdPersonList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdPersonList.MultiSelect = false;
            this.grdPersonList.Name = "grdPersonList";
            this.grdPersonList.RightControl = null;
            this.grdPersonList.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdPersonList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdPersonList.RowSegmentCount = 1;
            this.grdPersonList.RowTemplate.Height = 26;
            this.grdPersonList.ScrollRowCount = 3;
            this.grdPersonList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPersonList.Size = new System.Drawing.Size(1093, 367);
            this.grdPersonList.TabIndex = 110;
            this.grdPersonList.UpControl = null;
            this.grdPersonList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPersonList_CellClick);
            // 
            // clmPersonCode
            // 
            this.clmPersonCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmPersonCode.DataPropertyName = "tantousyaCode";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmPersonCode.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmPersonCode.HeaderText = "担当者コード";
            this.clmPersonCode.Name = "clmPersonCode";
            this.clmPersonCode.ReadOnly = true;
            this.clmPersonCode.Width = 128;
            // 
            // clmPersonName
            // 
            this.clmPersonName.DataPropertyName = "tantousyaName";
            this.clmPersonName.HeaderText = "担当者名";
            this.clmPersonName.Name = "clmPersonName";
            this.clmPersonName.ReadOnly = true;
            this.clmPersonName.Width = 210;
            // 
            // clmAuthority
            // 
            this.clmAuthority.DataPropertyName = "kengen";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmAuthority.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmAuthority.HeaderText = "権限";
            this.clmAuthority.Name = "clmAuthority";
            this.clmAuthority.ReadOnly = true;
            this.clmAuthority.Width = 64;
            // 
            // clmPass
            // 
            this.clmPass.DataPropertyName = "passWord";
            this.clmPass.HeaderText = "パスワード";
            this.clmPass.Name = "clmPass";
            this.clmPass.ReadOnly = true;
            // 
            // clmMail
            // 
            this.clmMail.DataPropertyName = "mail";
            this.clmMail.HeaderText = "メールアドレス";
            this.clmMail.Name = "clmMail";
            this.clmMail.ReadOnly = true;
            this.clmMail.Width = 490;
            // 
            // clmOrderNo
            // 
            this.clmOrderNo.DataPropertyName = "chumonNo";
            this.clmOrderNo.HeaderText = "注文No";
            this.clmOrderNo.Name = "clmOrderNo";
            this.clmOrderNo.ReadOnly = true;
            this.clmOrderNo.Width = 80;
            // 
            // clmBeforePersonCode
            // 
            this.clmBeforePersonCode.DataPropertyName = "beforeTantousyaCode";
            this.clmBeforePersonCode.HeaderText = "(変更前)担当者コード";
            this.clmBeforePersonCode.Name = "clmBeforePersonCode";
            this.clmBeforePersonCode.Visible = false;
            // 
            // clmBeforePersonName
            // 
            this.clmBeforePersonName.DataPropertyName = "beforeTantousyaName";
            this.clmBeforePersonName.HeaderText = "(変更前)担当者名";
            this.clmBeforePersonName.Name = "clmBeforePersonName";
            this.clmBeforePersonName.Visible = false;
            // 
            // clmBeforeAuthority
            // 
            this.clmBeforeAuthority.DataPropertyName = "beforeKengen";
            this.clmBeforeAuthority.HeaderText = "(変更前)権限";
            this.clmBeforeAuthority.Name = "clmBeforeAuthority";
            this.clmBeforeAuthority.Visible = false;
            // 
            // clmBeforePass
            // 
            this.clmBeforePass.DataPropertyName = "beforePassWord";
            this.clmBeforePass.HeaderText = "(変更前)パスワード";
            this.clmBeforePass.Name = "clmBeforePass";
            this.clmBeforePass.Visible = false;
            // 
            // clmBeforeMail
            // 
            this.clmBeforeMail.DataPropertyName = "beforeMail";
            this.clmBeforeMail.HeaderText = "(変更前)メールアドレス";
            this.clmBeforeMail.Name = "clmBeforeMail";
            this.clmBeforeMail.Visible = false;
            // 
            // clmBeforeOrderNo
            // 
            this.clmBeforeOrderNo.DataPropertyName = "beforeChumonNo";
            this.clmBeforeOrderNo.HeaderText = "(変更前)注文No";
            this.clmBeforeOrderNo.Name = "clmBeforeOrderNo";
            this.clmBeforeOrderNo.Visible = false;
            // 
            // frmTantoM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 659);
            this.Controls.Add(this.grdPersonList);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtAuthority);
            this.Controls.Add(this.lblAuthority);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.lblPersonCode);
            this.Controls.Add(this.txtPersonCode);
            this.Controls.Add(this.lblPersonName);
            this.Controls.Add(this.label19);
            this.Name = "frmTantoM";
            this.Text = "担当者マスタ";
            this.Load += new System.EventHandler(this.frmTantoM_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPersonCode;
        private Common.CustomTextBox txtPersonCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private Common.CustomTextBox txtMail;
        private Common.CustomTextBox txtPass;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPass;
        private Common.CustomTextBox txtAuthority;
        private System.Windows.Forms.Label lblAuthority;
        private Common.CustomTextBox txtPersonName;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label lblOrderNo;
        private Common.CustomTextBox txtOrderNo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private System.Windows.Forms.Label label27;
        private Common.CustomDataGridView grdPersonList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAuthority;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforePersonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforePersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforeAuthority;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforePass;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforeMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBeforeOrderNo;
    }
}