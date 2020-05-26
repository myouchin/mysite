namespace Master
{
    partial class frmSyohinM
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.rdoReference = new System.Windows.Forms.RadioButton();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTopClassificationCode = new Common.CustomComboBox();
            this.cmbBtmClassificationCode = new Common.CustomComboBox();
            this.txtItemCode = new Common.CustomTextBox();
            this.txtItemName = new Common.CustomTextBox();
            this.cmbUnitType = new Common.CustomComboBox();
            this.txtBit = new Common.CustomTextBox();
            this.txtLastUpDateYear = new Common.CustomTextBox();
            this.txtLastUpDateMonth = new Common.CustomTextBox();
            this.txtLastUpDateDay = new Common.CustomTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTopClassificationCode = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblItemName = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblUnitType = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lblBit = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.lblDeletedMessage = new System.Windows.Forms.Label();
            this.lblLastUpDateDay = new System.Windows.Forms.Label();
            this.lblLastUpDateMonth = new System.Windows.Forms.Label();
            this.lblLastUpDateYear = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.lblLastUpDate = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.btnPrint = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.btnSave = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblBtmClassificationCode = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
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
            this.panel4.Location = new System.Drawing.Point(33, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(366, 73);
            this.panel4.TabIndex = 1;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoCheck = false;
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(268, 37);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(67, 23);
            this.rdoDelete.TabIndex = 41;
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
            this.rdoReference.Location = new System.Drawing.Point(183, 37);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(67, 23);
            this.rdoReference.TabIndex = 31;
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
            this.rdoCorrection.Location = new System.Drawing.Point(96, 37);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(67, 23);
            this.rdoCorrection.TabIndex = 21;
            this.rdoCorrection.TabStop = true;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            this.rdoCorrection.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoNew
            // 
            this.rdoNew.AutoCheck = false;
            this.rdoNew.AutoSize = true;
            this.rdoNew.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(8, 38);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(67, 23);
            this.rdoNew.TabIndex = 11;
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
            this.label27.Location = new System.Drawing.Point(7, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　処理モード　";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(455, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "商品マスタ";
            // 
            // cmbTopClassificationCode
            // 
            this.cmbTopClassificationCode.BeforeSelectedValue = "";
            this.cmbTopClassificationCode.DownControl = this.cmbBtmClassificationCode;
            this.cmbTopClassificationCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopClassificationCode.EnterControl = this.cmbBtmClassificationCode;
            this.cmbTopClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTopClassificationCode.FormattingEnabled = true;
            this.cmbTopClassificationCode.LabelControl = null;
            this.cmbTopClassificationCode.LeftControl = null;
            this.cmbTopClassificationCode.Location = new System.Drawing.Point(196, 8);
            this.cmbTopClassificationCode.Name = "cmbTopClassificationCode";
            this.cmbTopClassificationCode.RightControl = null;
            this.cmbTopClassificationCode.Size = new System.Drawing.Size(179, 27);
            this.cmbTopClassificationCode.TabIndex = 81;
            // 
            // cmbBtmClassificationCode
            // 
            this.cmbBtmClassificationCode.BeforeSelectedValue = "";
            this.cmbBtmClassificationCode.DownControl = this.txtItemCode;
            this.cmbBtmClassificationCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBtmClassificationCode.EnterControl = this.txtItemCode;
            this.cmbBtmClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbBtmClassificationCode.FormattingEnabled = true;
            this.cmbBtmClassificationCode.LabelControl = null;
            this.cmbBtmClassificationCode.LeftControl = null;
            this.cmbBtmClassificationCode.Location = new System.Drawing.Point(196, 8);
            this.cmbBtmClassificationCode.Name = "cmbBtmClassificationCode";
            this.cmbBtmClassificationCode.RightControl = null;
            this.cmbBtmClassificationCode.Size = new System.Drawing.Size(179, 27);
            this.cmbBtmClassificationCode.TabIndex = 101;
            this.cmbBtmClassificationCode.UpControl = this.cmbTopClassificationCode;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BeforeValue = "";
            this.txtItemCode.DownControl = this.txtItemName;
            this.txtItemCode.EnterControl = this.txtItemName;
            this.txtItemCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtItemCode.LabelControl = null;
            this.txtItemCode.LeftControl = null;
            this.txtItemCode.Location = new System.Drawing.Point(196, 8);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.RightControl = null;
            this.txtItemCode.Size = new System.Drawing.Size(179, 26);
            this.txtItemCode.TabIndex = 121;
            this.txtItemCode.UpControl = this.cmbBtmClassificationCode;
            // 
            // txtItemName
            // 
            this.txtItemName.BeforeValue = "";
            this.txtItemName.DownControl = this.cmbUnitType;
            this.txtItemName.EnterControl = this.cmbUnitType;
            this.txtItemName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtItemName.LabelControl = null;
            this.txtItemName.LeftControl = null;
            this.txtItemName.Location = new System.Drawing.Point(196, 8);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.RightControl = null;
            this.txtItemName.Size = new System.Drawing.Size(436, 26);
            this.txtItemName.TabIndex = 141;
            this.txtItemName.UpControl = this.txtItemCode;
            // 
            // cmbUnitType
            // 
            this.cmbUnitType.BeforeSelectedValue = "";
            this.cmbUnitType.DownControl = this.txtBit;
            this.cmbUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnitType.EnterControl = this.txtBit;
            this.cmbUnitType.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbUnitType.FormattingEnabled = true;
            this.cmbUnitType.LabelControl = null;
            this.cmbUnitType.LeftControl = null;
            this.cmbUnitType.Location = new System.Drawing.Point(196, 8);
            this.cmbUnitType.Name = "cmbUnitType";
            this.cmbUnitType.RightControl = null;
            this.cmbUnitType.Size = new System.Drawing.Size(179, 27);
            this.cmbUnitType.TabIndex = 161;
            this.cmbUnitType.UpControl = this.txtItemName;
            // 
            // txtBit
            // 
            this.txtBit.BeforeValue = "";
            this.txtBit.DownControl = this.txtLastUpDateYear;
            this.txtBit.EnterControl = this.txtLastUpDateYear;
            this.txtBit.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBit.LabelControl = null;
            this.txtBit.LeftControl = null;
            this.txtBit.Location = new System.Drawing.Point(196, 8);
            this.txtBit.Name = "txtBit";
            this.txtBit.RightControl = null;
            this.txtBit.Size = new System.Drawing.Size(179, 26);
            this.txtBit.TabIndex = 181;
            this.txtBit.Text = "-12,345,678.123";
            this.txtBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBit.UpControl = this.cmbUnitType;
            // 
            // txtLastUpDateYear
            // 
            this.txtLastUpDateYear.BeforeValue = "";
            this.txtLastUpDateYear.DownControl = null;
            this.txtLastUpDateYear.EnterControl = this.txtLastUpDateMonth;
            this.txtLastUpDateYear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLastUpDateYear.LabelControl = null;
            this.txtLastUpDateYear.LeftControl = null;
            this.txtLastUpDateYear.Location = new System.Drawing.Point(196, 8);
            this.txtLastUpDateYear.Name = "txtLastUpDateYear";
            this.txtLastUpDateYear.RightControl = this.txtLastUpDateMonth;
            this.txtLastUpDateYear.Size = new System.Drawing.Size(89, 26);
            this.txtLastUpDateYear.TabIndex = 201;
            this.txtLastUpDateYear.UpControl = this.txtBit;
            // 
            // txtLastUpDateMonth
            // 
            this.txtLastUpDateMonth.BeforeValue = "";
            this.txtLastUpDateMonth.DownControl = null;
            this.txtLastUpDateMonth.EnterControl = this.txtLastUpDateDay;
            this.txtLastUpDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLastUpDateMonth.LabelControl = null;
            this.txtLastUpDateMonth.LeftControl = this.txtLastUpDateYear;
            this.txtLastUpDateMonth.Location = new System.Drawing.Point(327, 9);
            this.txtLastUpDateMonth.Name = "txtLastUpDateMonth";
            this.txtLastUpDateMonth.RightControl = this.txtLastUpDateDay;
            this.txtLastUpDateMonth.Size = new System.Drawing.Size(48, 26);
            this.txtLastUpDateMonth.TabIndex = 211;
            this.txtLastUpDateMonth.UpControl = this.txtBit;
            // 
            // txtLastUpDateDay
            // 
            this.txtLastUpDateDay.BeforeValue = "";
            this.txtLastUpDateDay.DownControl = null;
            this.txtLastUpDateDay.EnterControl = null;
            this.txtLastUpDateDay.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLastUpDateDay.LabelControl = null;
            this.txtLastUpDateDay.LeftControl = this.txtLastUpDateMonth;
            this.txtLastUpDateDay.Location = new System.Drawing.Point(412, 9);
            this.txtLastUpDateDay.Name = "txtLastUpDateDay";
            this.txtLastUpDateDay.RightControl = null;
            this.txtLastUpDateDay.Size = new System.Drawing.Size(48, 26);
            this.txtLastUpDateDay.TabIndex = 221;
            this.txtLastUpDateDay.UpControl = this.txtBit;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbTopClassificationCode);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(47, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(817, 43);
            this.panel3.TabIndex = 71;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblTopClassificationCode);
            this.panel5.Location = new System.Drawing.Point(-1, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(189, 43);
            this.panel5.TabIndex = 0;
            // 
            // lblTopClassificationCode
            // 
            this.lblTopClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTopClassificationCode.Location = new System.Drawing.Point(23, 8);
            this.lblTopClassificationCode.Name = "lblTopClassificationCode";
            this.lblTopClassificationCode.Size = new System.Drawing.Size(139, 25);
            this.lblTopClassificationCode.TabIndex = 0;
            this.lblTopClassificationCode.Text = "大分類コード";
            this.lblTopClassificationCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.txtItemName);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel10.Location = new System.Drawing.Point(47, 237);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(817, 43);
            this.panel10.TabIndex = 131;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.lblItemName);
            this.panel11.Location = new System.Drawing.Point(-1, -1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 43);
            this.panel11.TabIndex = 0;
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItemName.Location = new System.Drawing.Point(23, 8);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(139, 25);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "商品名";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.cmbUnitType);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel12.Location = new System.Drawing.Point(47, 283);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(817, 43);
            this.panel12.TabIndex = 151;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.lblUnitType);
            this.panel13.Location = new System.Drawing.Point(-1, -1);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(189, 43);
            this.panel13.TabIndex = 0;
            // 
            // lblUnitType
            // 
            this.lblUnitType.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUnitType.Location = new System.Drawing.Point(23, 8);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(139, 25);
            this.lblUnitType.TabIndex = 0;
            this.lblUnitType.Text = "単位区分";
            this.lblUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.txtBit);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel14.Location = new System.Drawing.Point(47, 329);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(817, 43);
            this.panel14.TabIndex = 171;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.lblBit);
            this.panel15.Location = new System.Drawing.Point(-1, -1);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(189, 43);
            this.panel15.TabIndex = 0;
            // 
            // lblBit
            // 
            this.lblBit.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBit.Location = new System.Drawing.Point(23, 8);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(139, 25);
            this.lblBit.TabIndex = 0;
            this.lblBit.Text = "単　　価";
            this.lblBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.lblDeletedMessage);
            this.panel16.Controls.Add(this.lblLastUpDateDay);
            this.panel16.Controls.Add(this.lblLastUpDateMonth);
            this.panel16.Controls.Add(this.lblLastUpDateYear);
            this.panel16.Controls.Add(this.txtLastUpDateDay);
            this.panel16.Controls.Add(this.txtLastUpDateMonth);
            this.panel16.Controls.Add(this.txtLastUpDateYear);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel16.Location = new System.Drawing.Point(47, 376);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(817, 43);
            this.panel16.TabIndex = 191;
            // 
            // lblDeletedMessage
            // 
            this.lblDeletedMessage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDeletedMessage.ForeColor = System.Drawing.Color.Red;
            this.lblDeletedMessage.Location = new System.Drawing.Point(504, 10);
            this.lblDeletedMessage.Name = "lblDeletedMessage";
            this.lblDeletedMessage.Size = new System.Drawing.Size(111, 25);
            this.lblDeletedMessage.TabIndex = 23;
            this.lblDeletedMessage.Text = "※削除済み";
            this.lblDeletedMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastUpDateDay
            // 
            this.lblLastUpDateDay.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpDateDay.Location = new System.Drawing.Point(468, 10);
            this.lblLastUpDateDay.Name = "lblLastUpDateDay";
            this.lblLastUpDateDay.Size = new System.Drawing.Size(30, 22);
            this.lblLastUpDateDay.TabIndex = 7;
            this.lblLastUpDateDay.Text = "日";
            this.lblLastUpDateDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastUpDateMonth
            // 
            this.lblLastUpDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpDateMonth.Location = new System.Drawing.Point(378, 10);
            this.lblLastUpDateMonth.Name = "lblLastUpDateMonth";
            this.lblLastUpDateMonth.Size = new System.Drawing.Size(30, 22);
            this.lblLastUpDateMonth.TabIndex = 6;
            this.lblLastUpDateMonth.Text = "月";
            this.lblLastUpDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastUpDateYear
            // 
            this.lblLastUpDateYear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpDateYear.Location = new System.Drawing.Point(293, 10);
            this.lblLastUpDateYear.Name = "lblLastUpDateYear";
            this.lblLastUpDateYear.Size = new System.Drawing.Size(30, 22);
            this.lblLastUpDateYear.TabIndex = 5;
            this.lblLastUpDateYear.Text = "年";
            this.lblLastUpDateYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.lblLastUpDate);
            this.panel17.Location = new System.Drawing.Point(-1, -1);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(189, 43);
            this.panel17.TabIndex = 0;
            // 
            // lblLastUpDate
            // 
            this.lblLastUpDate.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpDate.Location = new System.Drawing.Point(23, 8);
            this.lblLastUpDate.Name = "lblLastUpDate";
            this.lblLastUpDate.Size = new System.Drawing.Size(139, 25);
            this.lblLastUpDate.TabIndex = 0;
            this.lblLastUpDate.Text = "最終更新日";
            this.lblLastUpDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel20.Controls.Add(this.btnPrint);
            this.panel20.Controls.Add(this.btnSearch);
            this.panel20.Controls.Add(this.btnSave);
            this.panel20.Controls.Add(this.btnCancel);
            this.panel20.Controls.Add(this.btnClose);
            this.panel20.Location = new System.Drawing.Point(47, 426);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(816, 72);
            this.panel20.TabIndex = 231;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(153, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 47);
            this.btnPrint.TabIndex = 251;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(17, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 47);
            this.btnSearch.TabIndex = 241;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(413, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 47);
            this.btnSave.TabIndex = 261;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(544, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 47);
            this.btnCancel.TabIndex = 271;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(674, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 47);
            this.btnClose.TabIndex = 281;
            this.btnClose.Text = "F12：終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtItemCode);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(47, 191);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(817, 43);
            this.panel6.TabIndex = 111;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblItemCode);
            this.panel7.Location = new System.Drawing.Point(-1, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(189, 43);
            this.panel7.TabIndex = 0;
            // 
            // lblItemCode
            // 
            this.lblItemCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItemCode.Location = new System.Drawing.Point(23, 8);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(139, 25);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "商品コード";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cmbBtmClassificationCode);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(47, 145);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(817, 43);
            this.panel8.TabIndex = 91;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblBtmClassificationCode);
            this.panel9.Location = new System.Drawing.Point(-1, -1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(189, 43);
            this.panel9.TabIndex = 0;
            // 
            // lblBtmClassificationCode
            // 
            this.lblBtmClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBtmClassificationCode.Location = new System.Drawing.Point(23, 8);
            this.lblBtmClassificationCode.Name = "lblBtmClassificationCode";
            this.lblBtmClassificationCode.Size = new System.Drawing.Size(139, 25);
            this.lblBtmClassificationCode.TabIndex = 0;
            this.lblBtmClassificationCode.Text = "小分類コード";
            this.lblBtmClassificationCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSyohinM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 504);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Name = "frmSyohinM";
            this.Text = "商品マスタ";
            this.Load += new System.EventHandler(this.frmSyohinM_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.RadioButton rdoReference;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTopClassificationCode;
        private System.Windows.Forms.Panel panel10;
        private Common.CustomTextBox txtItemName;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Panel panel12;
        private Common.CustomComboBox cmbUnitType;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblUnitType;
        private System.Windows.Forms.Panel panel14;
        private Common.CustomTextBox txtBit;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label lblBit;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label lblLastUpDate;
        private System.Windows.Forms.Label lblLastUpDateDay;
        private System.Windows.Forms.Label lblLastUpDateMonth;
        private System.Windows.Forms.Label lblLastUpDateYear;
        private Common.CustomTextBox txtLastUpDateDay;
        private Common.CustomTextBox txtLastUpDateMonth;
        private Common.CustomTextBox txtLastUpDateYear;
        private System.Windows.Forms.Panel panel20;
        private Common.FeaturesButton btnSave;
        private Common.FeaturesButton btnCancel;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnSearch;
        private System.Windows.Forms.Panel panel6;
        private Common.CustomTextBox txtItemCode;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblItemCode;
        private Common.CustomComboBox cmbTopClassificationCode;
        private System.Windows.Forms.Panel panel8;
        private Common.CustomComboBox cmbBtmClassificationCode;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblBtmClassificationCode;
        private System.Windows.Forms.Label lblDeletedMessage;
    }
}