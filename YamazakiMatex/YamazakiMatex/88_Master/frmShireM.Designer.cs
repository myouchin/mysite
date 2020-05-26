namespace Master
{
    partial class frmShireM
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVendorCode = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.txtZipCode = new Common.CustomTextBox();
            this.txtAddress1 = new Common.CustomTextBox();
            this.txtAddress2 = new Common.CustomTextBox();
            this.txtTel = new Common.CustomTextBox();
            this.cmbClosingDay = new Common.CustomComboBox();
            this.txtLastUpdateYear = new Common.CustomTextBox();
            this.txtLastUpdateMonth = new Common.CustomTextBox();
            this.txtLastUpdateDay = new Common.CustomTextBox();
            this.cmbPaymentSite = new Common.CustomComboBox();
            this.txtFax = new Common.CustomTextBox();
            this.txtVendorKanaName = new Common.CustomTextBox();
            this.txtVendorName = new Common.CustomTextBox();
            this.txtVendorCode = new Common.CustomTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblVendorKanaName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFax = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPaymentSite = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblClosingDay = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblDeletedMessage = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblLastUpdateDay = new System.Windows.Forms.Label();
            this.lblLastUpdateMonth = new System.Windows.Forms.Label();
            this.lblLastUpdateYear = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel11.SuspendLayout();
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
            this.panel4.Location = new System.Drawing.Point(38, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(366, 73);
            this.panel4.TabIndex = 1;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoCheck = false;
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoDelete.Location = new System.Drawing.Point(268, 37);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(67, 23);
            this.rdoDelete.TabIndex = 40;
            this.rdoDelete.Text = "削除";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoReference
            // 
            this.rdoReference.AutoCheck = false;
            this.rdoReference.AutoSize = true;
            this.rdoReference.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoReference.Location = new System.Drawing.Point(183, 37);
            this.rdoReference.Name = "rdoReference";
            this.rdoReference.Size = new System.Drawing.Size(67, 23);
            this.rdoReference.TabIndex = 30;
            this.rdoReference.Text = "参照";
            this.rdoReference.UseVisualStyleBackColor = true;
            this.rdoReference.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoCheck = false;
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(96, 37);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(67, 23);
            this.rdoCorrection.TabIndex = 20;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            this.rdoCorrection.Click += new System.EventHandler(this.inputModeRadio_Click);
            // 
            // rdoNew
            // 
            this.rdoNew.AutoCheck = false;
            this.rdoNew.AutoSize = true;
            this.rdoNew.Checked = true;
            this.rdoNew.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(8, 38);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(67, 23);
            this.rdoNew.TabIndex = 10;
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
            this.label27.Location = new System.Drawing.Point(3, 2);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　処理モード　";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(474, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "仕入先マスタ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.94118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 865F));
            this.tableLayoutPanel1.Controls.Add(this.lblVendorCode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblVendorName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblZipCode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtZipCode, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress2, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress1, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblVendorKanaName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtVendorKanaName, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtVendorName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtVendorCode, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.67442F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1036, 220);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVendorCode.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorCode.Location = new System.Drawing.Point(23, 9);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(122, 25);
            this.lblVendorCode.TabIndex = 0;
            this.lblVendorCode.Text = "仕入先コード";
            this.lblVendorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorName
            // 
            this.lblVendorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVendorName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorName.Location = new System.Drawing.Point(27, 43);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(115, 25);
            this.lblVendorName.TabIndex = 2;
            this.lblVendorName.Text = "仕入先名";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZipCode
            // 
            this.lblZipCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZipCode.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblZipCode.Location = new System.Drawing.Point(26, 112);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(117, 25);
            this.lblZipCode.TabIndex = 4;
            this.lblZipCode.Text = "郵便番号";
            this.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtZipCode.BeforeValue = "";
            this.txtZipCode.DownControl = this.txtAddress1;
            this.txtZipCode.EnterControl = this.txtAddress1;
            this.txtZipCode.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZipCode.LabelControl = null;
            this.txtZipCode.LeftControl = null;
            this.txtZipCode.Location = new System.Drawing.Point(173, 113);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.RightControl = null;
            this.txtZipCode.Size = new System.Drawing.Size(138, 23);
            this.txtZipCode.TabIndex = 90;
            this.txtZipCode.UpControl = this.txtVendorKanaName;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress1.BeforeValue = "";
            this.txtAddress1.DownControl = this.txtAddress2;
            this.txtAddress1.EnterControl = this.txtAddress2;
            this.txtAddress1.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAddress1.LabelControl = null;
            this.txtAddress1.LeftControl = null;
            this.txtAddress1.Location = new System.Drawing.Point(173, 151);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.RightControl = null;
            this.txtAddress1.Size = new System.Drawing.Size(408, 23);
            this.txtAddress1.TabIndex = 100;
            this.txtAddress1.UpControl = this.txtZipCode;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress2.BeforeValue = "";
            this.txtAddress2.DownControl = this.txtTel;
            this.txtAddress2.EnterControl = this.txtTel;
            this.txtAddress2.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAddress2.LabelControl = null;
            this.txtAddress2.LeftControl = null;
            this.txtAddress2.Location = new System.Drawing.Point(173, 189);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.RightControl = null;
            this.txtAddress2.Size = new System.Drawing.Size(408, 23);
            this.txtAddress2.TabIndex = 110;
            this.txtAddress2.UpControl = this.txtAddress1;
            // 
            // txtTel
            // 
            this.txtTel.BeforeValue = "";
            this.txtTel.DownControl = this.cmbClosingDay;
            this.txtTel.EnterControl = this.txtFax;
            this.txtTel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTel.LabelControl = null;
            this.txtTel.LeftControl = null;
            this.txtTel.Location = new System.Drawing.Point(175, 5);
            this.txtTel.Name = "txtTel";
            this.txtTel.RightControl = this.txtFax;
            this.txtTel.Size = new System.Drawing.Size(198, 23);
            this.txtTel.TabIndex = 130;
            this.txtTel.UpControl = this.txtAddress2;
            // 
            // cmbClosingDay
            // 
            this.cmbClosingDay.BeforeSelectedValue = "";
            this.cmbClosingDay.DownControl = this.txtLastUpdateYear;
            this.cmbClosingDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClosingDay.EnterControl = this.cmbPaymentSite;
            this.cmbClosingDay.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbClosingDay.FormattingEnabled = true;
            this.cmbClosingDay.LabelControl = null;
            this.cmbClosingDay.LeftControl = null;
            this.cmbClosingDay.Location = new System.Drawing.Point(175, 6);
            this.cmbClosingDay.Name = "cmbClosingDay";
            this.cmbClosingDay.RightControl = this.cmbPaymentSite;
            this.cmbClosingDay.Size = new System.Drawing.Size(61, 24);
            this.cmbClosingDay.TabIndex = 160;
            this.cmbClosingDay.TabStop = false;
            this.cmbClosingDay.UpControl = this.txtTel;
            // 
            // txtLastUpdateYear
            // 
            this.txtLastUpdateYear.BeforeValue = "";
            this.txtLastUpdateYear.DownControl = null;
            this.txtLastUpdateYear.EnterControl = this.txtLastUpdateMonth;
            this.txtLastUpdateYear.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLastUpdateYear.LabelControl = null;
            this.txtLastUpdateYear.LeftControl = null;
            this.txtLastUpdateYear.Location = new System.Drawing.Point(175, 7);
            this.txtLastUpdateYear.Name = "txtLastUpdateYear";
            this.txtLastUpdateYear.RightControl = this.txtLastUpdateMonth;
            this.txtLastUpdateYear.Size = new System.Drawing.Size(82, 23);
            this.txtLastUpdateYear.TabIndex = 190;
            this.txtLastUpdateYear.UpControl = this.cmbClosingDay;
            // 
            // txtLastUpdateMonth
            // 
            this.txtLastUpdateMonth.BeforeValue = "";
            this.txtLastUpdateMonth.DownControl = null;
            this.txtLastUpdateMonth.EnterControl = this.txtLastUpdateDay;
            this.txtLastUpdateMonth.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLastUpdateMonth.LabelControl = null;
            this.txtLastUpdateMonth.LeftControl = this.txtLastUpdateYear;
            this.txtLastUpdateMonth.Location = new System.Drawing.Point(307, 7);
            this.txtLastUpdateMonth.Name = "txtLastUpdateMonth";
            this.txtLastUpdateMonth.RightControl = this.txtLastUpdateDay;
            this.txtLastUpdateMonth.Size = new System.Drawing.Size(55, 23);
            this.txtLastUpdateMonth.TabIndex = 200;
            this.txtLastUpdateMonth.UpControl = this.cmbClosingDay;
            // 
            // txtLastUpdateDay
            // 
            this.txtLastUpdateDay.BeforeValue = "";
            this.txtLastUpdateDay.DownControl = null;
            this.txtLastUpdateDay.EnterControl = null;
            this.txtLastUpdateDay.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLastUpdateDay.LabelControl = null;
            this.txtLastUpdateDay.LeftControl = this.txtLastUpdateMonth;
            this.txtLastUpdateDay.Location = new System.Drawing.Point(398, 7);
            this.txtLastUpdateDay.Name = "txtLastUpdateDay";
            this.txtLastUpdateDay.RightControl = null;
            this.txtLastUpdateDay.Size = new System.Drawing.Size(59, 23);
            this.txtLastUpdateDay.TabIndex = 210;
            this.txtLastUpdateDay.UpControl = this.cmbClosingDay;
            // 
            // cmbPaymentSite
            // 
            this.cmbPaymentSite.BeforeSelectedValue = "";
            this.cmbPaymentSite.DownControl = this.txtLastUpdateYear;
            this.cmbPaymentSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentSite.EnterControl = this.txtLastUpdateYear;
            this.cmbPaymentSite.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbPaymentSite.FormattingEnabled = true;
            this.cmbPaymentSite.LabelControl = null;
            this.cmbPaymentSite.LeftControl = this.cmbClosingDay;
            this.cmbPaymentSite.Location = new System.Drawing.Point(396, 6);
            this.cmbPaymentSite.Name = "cmbPaymentSite";
            this.cmbPaymentSite.RightControl = null;
            this.cmbPaymentSite.Size = new System.Drawing.Size(61, 24);
            this.cmbPaymentSite.TabIndex = 170;
            this.cmbPaymentSite.TabStop = false;
            this.cmbPaymentSite.UpControl = this.txtTel;
            // 
            // txtFax
            // 
            this.txtFax.BeforeValue = "";
            this.txtFax.DownControl = this.cmbClosingDay;
            this.txtFax.EnterControl = this.cmbClosingDay;
            this.txtFax.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFax.LabelControl = null;
            this.txtFax.LeftControl = this.txtTel;
            this.txtFax.Location = new System.Drawing.Point(549, 5);
            this.txtFax.Name = "txtFax";
            this.txtFax.RightControl = null;
            this.txtFax.Size = new System.Drawing.Size(198, 23);
            this.txtFax.TabIndex = 140;
            this.txtFax.UpControl = this.txtAddress2;
            // 
            // txtVendorKanaName
            // 
            this.txtVendorKanaName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtVendorKanaName.BeforeValue = "";
            this.txtVendorKanaName.DownControl = this.txtZipCode;
            this.txtVendorKanaName.EnterControl = this.txtZipCode;
            this.txtVendorKanaName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtVendorKanaName.LabelControl = null;
            this.txtVendorKanaName.LeftControl = null;
            this.txtVendorKanaName.Location = new System.Drawing.Point(173, 76);
            this.txtVendorKanaName.Name = "txtVendorKanaName";
            this.txtVendorKanaName.RightControl = null;
            this.txtVendorKanaName.Size = new System.Drawing.Size(492, 23);
            this.txtVendorKanaName.TabIndex = 80;
            this.txtVendorKanaName.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtVendorKanaName.UpControl = this.txtVendorName;
            // 
            // txtVendorName
            // 
            this.txtVendorName.AcceptsReturn = true;
            this.txtVendorName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtVendorName.BeforeValue = "";
            this.txtVendorName.DownControl = this.txtVendorKanaName;
            this.txtVendorName.EnterControl = this.txtVendorKanaName;
            this.txtVendorName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtVendorName.LabelControl = null;
            this.txtVendorName.LeftControl = null;
            this.txtVendorName.Location = new System.Drawing.Point(173, 46);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.RightControl = null;
            this.txtVendorName.Size = new System.Drawing.Size(492, 23);
            this.txtVendorName.TabIndex = 70;
            this.txtVendorName.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtVendorName.UpControl = this.txtVendorCode;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtVendorCode.BeforeValue = "";
            this.txtVendorCode.DownControl = this.txtVendorName;
            this.txtVendorCode.EnterControl = this.txtVendorName;
            this.txtVendorCode.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtVendorCode.LabelControl = null;
            this.txtVendorCode.LeftControl = null;
            this.txtVendorCode.Location = new System.Drawing.Point(173, 10);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightControl = null;
            this.txtVendorCode.Size = new System.Drawing.Size(102, 23);
            this.txtVendorCode.TabIndex = 60;
            this.txtVendorCode.UpControl = null;
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAddress.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAddress.Location = new System.Drawing.Point(26, 150);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(117, 25);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "住　　所";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendorKanaName
            // 
            this.lblVendorKanaName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVendorKanaName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVendorKanaName.Location = new System.Drawing.Point(48, 75);
            this.lblVendorKanaName.Name = "lblVendorKanaName";
            this.lblVendorKanaName.Size = new System.Drawing.Size(117, 25);
            this.lblVendorKanaName.TabIndex = 9;
            this.lblVendorKanaName.Text = "（カナ）";
            this.lblVendorKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.lblFax);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(42, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 38);
            this.panel1.TabIndex = 120;
            // 
            // lblFax
            // 
            this.lblFax.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFax.Location = new System.Drawing.Point(437, 7);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(117, 25);
            this.lblFax.TabIndex = 2;
            this.lblFax.Text = "ＦＡＸ番号";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTel);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 38);
            this.panel2.TabIndex = 0;
            // 
            // lblTel
            // 
            this.lblTel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTel.Location = new System.Drawing.Point(23, 5);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(117, 25);
            this.lblTel.TabIndex = 0;
            this.lblTel.Text = "電話番号";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbPaymentSite);
            this.panel3.Controls.Add(this.cmbClosingDay);
            this.panel3.Controls.Add(this.lblPaymentSite);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(42, 361);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1036, 38);
            this.panel3.TabIndex = 150;
            // 
            // lblPaymentSite
            // 
            this.lblPaymentSite.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPaymentSite.Location = new System.Drawing.Point(279, 7);
            this.lblPaymentSite.Name = "lblPaymentSite";
            this.lblPaymentSite.Size = new System.Drawing.Size(117, 25);
            this.lblPaymentSite.TabIndex = 2;
            this.lblPaymentSite.Text = "支払サイト";
            this.lblPaymentSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblClosingDay);
            this.panel5.Location = new System.Drawing.Point(-1, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(171, 38);
            this.panel5.TabIndex = 0;
            // 
            // lblClosingDay
            // 
            this.lblClosingDay.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblClosingDay.Location = new System.Drawing.Point(23, 5);
            this.lblClosingDay.Name = "lblClosingDay";
            this.lblClosingDay.Size = new System.Drawing.Size(117, 25);
            this.lblClosingDay.TabIndex = 0;
            this.lblClosingDay.Text = "締　　日";
            this.lblClosingDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Controls.Add(this.btnCancel);
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Location = new System.Drawing.Point(42, 440);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1039, 72);
            this.panel6.TabIndex = 220;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(619, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 47);
            this.btnSave.TabIndex = 250;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(750, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 47);
            this.btnCancel.TabIndex = 260;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(881, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 47);
            this.btnClose.TabIndex = 270;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(149, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 47);
            this.btnPrint.TabIndex = 240;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(14, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 47);
            this.btnSearch.TabIndex = 230;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblDeletedMessage);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.lblLastUpdateDay);
            this.panel7.Controls.Add(this.lblLastUpdateMonth);
            this.panel7.Controls.Add(this.lblLastUpdateYear);
            this.panel7.Controls.Add(this.txtLastUpdateDay);
            this.panel7.Controls.Add(this.txtLastUpdateMonth);
            this.panel7.Controls.Add(this.txtLastUpdateYear);
            this.panel7.Location = new System.Drawing.Point(42, 398);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1036, 38);
            this.panel7.TabIndex = 180;
            // 
            // lblDeletedMessage
            // 
            this.lblDeletedMessage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDeletedMessage.ForeColor = System.Drawing.Color.Red;
            this.lblDeletedMessage.Location = new System.Drawing.Point(503, 5);
            this.lblDeletedMessage.Name = "lblDeletedMessage";
            this.lblDeletedMessage.Size = new System.Drawing.Size(129, 27);
            this.lblDeletedMessage.TabIndex = 23;
            this.lblDeletedMessage.Text = "※削除済み";
            this.lblDeletedMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.lblLastUpdate);
            this.panel11.Location = new System.Drawing.Point(-1, -1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(171, 38);
            this.panel11.TabIndex = 0;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpdate.Location = new System.Drawing.Point(23, 8);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(117, 25);
            this.lblLastUpdate.TabIndex = 0;
            this.lblLastUpdate.Text = "最終更新日";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastUpdateDay
            // 
            this.lblLastUpdateDay.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpdateDay.Location = new System.Drawing.Point(461, 7);
            this.lblLastUpdateDay.Name = "lblLastUpdateDay";
            this.lblLastUpdateDay.Size = new System.Drawing.Size(35, 25);
            this.lblLastUpdateDay.TabIndex = 5;
            this.lblLastUpdateDay.Text = "日";
            this.lblLastUpdateDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastUpdateMonth
            // 
            this.lblLastUpdateMonth.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpdateMonth.Location = new System.Drawing.Point(370, 7);
            this.lblLastUpdateMonth.Name = "lblLastUpdateMonth";
            this.lblLastUpdateMonth.Size = new System.Drawing.Size(27, 25);
            this.lblLastUpdateMonth.TabIndex = 4;
            this.lblLastUpdateMonth.Text = "月";
            this.lblLastUpdateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastUpdateYear
            // 
            this.lblLastUpdateYear.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastUpdateYear.Location = new System.Drawing.Point(265, 7);
            this.lblLastUpdateYear.Name = "lblLastUpdateYear";
            this.lblLastUpdateYear.Size = new System.Drawing.Size(35, 25);
            this.lblLastUpdateYear.TabIndex = 3;
            this.lblLastUpdateYear.Text = "年";
            this.lblLastUpdateYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmShireM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 537);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Name = "frmShireM";
            this.Text = "仕入先マスタ";
            this.Load += new System.EventHandler(this.frmShireM_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel11.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblVendorCode;
        private Common.CustomTextBox txtVendorCode;
        private System.Windows.Forms.Label lblVendorName;
        private Common.CustomTextBox txtVendorKanaName;
        private System.Windows.Forms.Label lblZipCode;
        private Common.CustomTextBox txtZipCode;
        private System.Windows.Forms.Label lblAddress;
        private Common.CustomTextBox txtAddress2;
        private Common.CustomTextBox txtAddress1;
        private System.Windows.Forms.Panel panel1;
        private Common.CustomTextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private Common.CustomTextBox txtTel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Panel panel3;
        private Common.CustomComboBox cmbPaymentSite;
        private Common.CustomComboBox cmbClosingDay;
        private System.Windows.Forms.Label lblPaymentSite;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblClosingDay;
        private System.Windows.Forms.Label lblVendorKanaName;
        private Common.CustomTextBox txtVendorName;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblLastUpdateDay;
        private System.Windows.Forms.Label lblLastUpdateMonth;
        private System.Windows.Forms.Label lblLastUpdateYear;
        private Common.CustomTextBox txtLastUpdateDay;
        private Common.CustomTextBox txtLastUpdateMonth;
        private Common.CustomTextBox txtLastUpdateYear;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblDeletedMessage;
    }
}