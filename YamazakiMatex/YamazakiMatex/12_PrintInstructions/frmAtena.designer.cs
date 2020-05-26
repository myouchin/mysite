namespace PrintInstructions
{
    partial class frmAtena
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel panel1;
            this.label2 = new System.Windows.Forms.Label();
            this.txtZipCode2 = new Common.CustomTextBox();
            this.txtAddress1 = new Common.CustomTextBox();
            this.txtAddress2 = new Common.CustomTextBox();
            this.txtCompanyName = new Common.CustomTextBox();
            this.txtBelongs1 = new Common.CustomTextBox();
            this.txtZipCode1 = new Common.CustomTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbBikou = new Common.CustomComboBox();
            this.lblBikou = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTitles1 = new Common.CustomComboBox();
            this.txtTitle = new Common.CustomTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTitles2 = new Common.CustomComboBox();
            this.txtName = new Common.CustomTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.txtBelongs2 = new Common.CustomTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.lblOfficeName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoNaga3 = new System.Windows.Forms.RadioButton();
            this.rdoKaku2 = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.rptAtena3Gou1 = new YamazakiMatex.Print.Report.rptAtena3Gou();
            this.rptAtena2Gou1 = new YamazakiMatex.Print.Report.rptAtena2Gou();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panel1.Controls.Add(this.label2);
            panel1.Controls.Add(this.txtZipCode2);
            panel1.Controls.Add(this.txtZipCode1);
            panel1.Location = new System.Drawing.Point(188, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(432, 31);
            panel1.TabIndex = 152;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(51, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZipCode2
            // 
            this.txtZipCode2.BeforeValue = "";
            this.txtZipCode2.DownControl = this.txtAddress1;
            this.txtZipCode2.EnterControl = this.txtAddress1;
            this.txtZipCode2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZipCode2.LabelControl = null;
            this.txtZipCode2.LeftControl = this.txtZipCode1;
            this.txtZipCode2.Location = new System.Drawing.Point(72, 2);
            this.txtZipCode2.Name = "txtZipCode2";
            this.txtZipCode2.RightControl = null;
            this.txtZipCode2.Size = new System.Drawing.Size(60, 26);
            this.txtZipCode2.TabIndex = 141;
            this.txtZipCode2.Text = "9999";
            this.txtZipCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtZipCode2.UpControl = null;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress1.BeforeValue = "";
            this.txtAddress1.DownControl = this.txtAddress2;
            this.txtAddress1.EnterControl = this.txtAddress2;
            this.txtAddress1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAddress1.LabelControl = null;
            this.txtAddress1.LeftControl = null;
            this.txtAddress1.Location = new System.Drawing.Point(0, 3);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.RightControl = null;
            this.txtAddress1.Size = new System.Drawing.Size(340, 26);
            this.txtAddress1.TabIndex = 151;
            this.txtAddress1.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtAddress1.UpControl = this.txtZipCode1;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress2.BeforeValue = "";
            this.txtAddress2.DownControl = this.txtCompanyName;
            this.txtAddress2.EnterControl = this.txtCompanyName;
            this.txtAddress2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAddress2.LabelControl = null;
            this.txtAddress2.LeftControl = null;
            this.txtAddress2.Location = new System.Drawing.Point(0, 35);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.RightControl = null;
            this.txtAddress2.Size = new System.Drawing.Size(340, 26);
            this.txtAddress2.TabIndex = 161;
            this.txtAddress2.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtAddress2.UpControl = this.txtAddress1;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCompanyName.BeforeValue = "";
            this.txtCompanyName.DownControl = this.txtBelongs1;
            this.txtCompanyName.EnterControl = this.txtBelongs1;
            this.txtCompanyName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCompanyName.LabelControl = null;
            this.txtCompanyName.LeftControl = null;
            this.txtCompanyName.Location = new System.Drawing.Point(0, 0);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.RightControl = null;
            this.txtCompanyName.Size = new System.Drawing.Size(340, 26);
            this.txtCompanyName.TabIndex = 91;
            this.txtCompanyName.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtCompanyName.UpControl = this.txtAddress2;
            // 
            // txtBelongs1
            // 
            this.txtBelongs1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBelongs1.BeforeValue = "";
            this.txtBelongs1.DownControl = null;
            this.txtBelongs1.EnterControl = null;
            this.txtBelongs1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBelongs1.LabelControl = null;
            this.txtBelongs1.LeftControl = null;
            this.txtBelongs1.Location = new System.Drawing.Point(0, 3);
            this.txtBelongs1.Name = "txtBelongs1";
            this.txtBelongs1.RightControl = null;
            this.txtBelongs1.Size = new System.Drawing.Size(340, 26);
            this.txtBelongs1.TabIndex = 121;
            this.txtBelongs1.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtBelongs1.UpControl = this.txtCompanyName;
            // 
            // txtZipCode1
            // 
            this.txtZipCode1.BeforeValue = "";
            this.txtZipCode1.DownControl = this.txtAddress1;
            this.txtZipCode1.EnterControl = this.txtZipCode2;
            this.txtZipCode1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZipCode1.LabelControl = null;
            this.txtZipCode1.LeftControl = null;
            this.txtZipCode1.Location = new System.Drawing.Point(0, 2);
            this.txtZipCode1.Name = "txtZipCode1";
            this.txtZipCode1.RightControl = this.txtZipCode2;
            this.txtZipCode1.Size = new System.Drawing.Size(45, 26);
            this.txtZipCode1.TabIndex = 131;
            this.txtZipCode1.Text = "999";
            this.txtZipCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtZipCode1.UpControl = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.52301F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.47699F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblBikou, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblZipCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOfficeName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCompanyName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(73, 114);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 343);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // panel7
            // 
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel7.Controls.Add(this.cmbBikou);
            this.panel7.Location = new System.Drawing.Point(188, 309);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(526, 29);
            this.panel7.TabIndex = 400;
            // 
            // cmbBikou
            // 
            this.cmbBikou.BeforeSelectedValue = "";
            this.cmbBikou.DownControl = null;
            this.cmbBikou.EnterControl = null;
            this.cmbBikou.Font = new System.Drawing.Font("MS UI Gothic", 13.25F);
            this.cmbBikou.FormattingEnabled = true;
            this.cmbBikou.LabelControl = null;
            this.cmbBikou.LeftControl = null;
            this.cmbBikou.Location = new System.Drawing.Point(0, 0);
            this.cmbBikou.Name = "cmbBikou";
            this.cmbBikou.RightControl = null;
            this.cmbBikou.Size = new System.Drawing.Size(340, 26);
            this.cmbBikou.TabIndex = 161;
            this.cmbBikou.Text = "令令令";
            this.cmbBikou.UpControl = null;
            // 
            // lblBikou
            // 
            this.lblBikou.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBikou.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBikou.Location = new System.Drawing.Point(5, 311);
            this.lblBikou.Name = "lblBikou";
            this.lblBikou.Size = new System.Drawing.Size(155, 25);
            this.lblBikou.TabIndex = 399;
            this.lblBikou.Text = "摘要";
            this.lblBikou.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.cmbTitles1);
            this.panel6.Controls.Add(this.txtCompanyName);
            this.panel6.Location = new System.Drawing.Point(188, 116);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(526, 29);
            this.panel6.TabIndex = 398;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(346, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 161;
            this.label1.Text = "敬称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTitles1
            // 
            this.cmbTitles1.BeforeSelectedValue = "";
            this.cmbTitles1.DownControl = null;
            this.cmbTitles1.EnterControl = null;
            this.cmbTitles1.Font = new System.Drawing.Font("MS UI Gothic", 13.25F);
            this.cmbTitles1.FormattingEnabled = true;
            this.cmbTitles1.LabelControl = null;
            this.cmbTitles1.LeftControl = null;
            this.cmbTitles1.Location = new System.Drawing.Point(433, 0);
            this.cmbTitles1.Name = "cmbTitles1";
            this.cmbTitles1.RightControl = null;
            this.cmbTitles1.Size = new System.Drawing.Size(93, 26);
            this.cmbTitles1.TabIndex = 160;
            this.cmbTitles1.Text = "令令令";
            this.cmbTitles1.UpControl = null;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTitle.BeforeValue = "";
            this.txtTitle.DownControl = this.txtBelongs1;
            this.txtTitle.EnterControl = this.txtBelongs1;
            this.txtTitle.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTitle.LabelControl = null;
            this.txtTitle.LeftControl = null;
            this.txtTitle.Location = new System.Drawing.Point(188, 232);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightControl = null;
            this.txtTitle.Size = new System.Drawing.Size(340, 26);
            this.txtTitle.TabIndex = 158;
            this.txtTitle.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtTitle.UpControl = this.txtAddress2;
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cmbTitles2);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Location = new System.Drawing.Point(188, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 29);
            this.panel3.TabIndex = 397;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(346, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 162;
            this.label3.Text = "敬称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTitles2
            // 
            this.cmbTitles2.BeforeSelectedValue = "";
            this.cmbTitles2.DownControl = null;
            this.cmbTitles2.EnterControl = null;
            this.cmbTitles2.Font = new System.Drawing.Font("MS UI Gothic", 13.25F);
            this.cmbTitles2.FormattingEnabled = true;
            this.cmbTitles2.LabelControl = null;
            this.cmbTitles2.LeftControl = null;
            this.cmbTitles2.Location = new System.Drawing.Point(433, 0);
            this.cmbTitles2.Name = "cmbTitles2";
            this.cmbTitles2.RightControl = null;
            this.cmbTitles2.Size = new System.Drawing.Size(93, 26);
            this.cmbTitles2.TabIndex = 161;
            this.cmbTitles2.Text = "令令令";
            this.cmbTitles2.UpControl = null;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.BeforeValue = "";
            this.txtName.DownControl = this.txtBelongs1;
            this.txtName.EnterControl = this.txtBelongs1;
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.LabelControl = null;
            this.txtName.LeftControl = null;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Name = "txtName";
            this.txtName.RightControl = null;
            this.txtName.Size = new System.Drawing.Size(340, 26);
            this.txtName.TabIndex = 159;
            this.txtName.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtName.UpControl = this.txtAddress2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(5, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 25);
            this.label4.TabIndex = 156;
            this.label4.Text = "役職";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            this.panel17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel17.Controls.Add(this.txtBelongs2);
            this.panel17.Controls.Add(this.txtBelongs1);
            this.panel17.Location = new System.Drawing.Point(188, 154);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(432, 64);
            this.panel17.TabIndex = 155;
            // 
            // txtBelongs2
            // 
            this.txtBelongs2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBelongs2.BeforeValue = "";
            this.txtBelongs2.DownControl = null;
            this.txtBelongs2.EnterControl = null;
            this.txtBelongs2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBelongs2.LabelControl = null;
            this.txtBelongs2.LeftControl = null;
            this.txtBelongs2.Location = new System.Drawing.Point(0, 35);
            this.txtBelongs2.Name = "txtBelongs2";
            this.txtBelongs2.RightControl = null;
            this.txtBelongs2.Size = new System.Drawing.Size(340, 26);
            this.txtBelongs2.TabIndex = 122;
            this.txtBelongs2.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtBelongs2.UpControl = this.txtCompanyName;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.txtAddress2);
            this.panel2.Controls.Add(this.txtAddress1);
            this.panel2.Location = new System.Drawing.Point(188, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 64);
            this.panel2.TabIndex = 154;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAddress.Location = new System.Drawing.Point(5, 41);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(155, 41);
            this.lblAddress.TabIndex = 153;
            this.lblAddress.Text = "住　　所";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblZipCode
            // 
            this.lblZipCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblZipCode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblZipCode.Location = new System.Drawing.Point(5, 10);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(155, 20);
            this.lblZipCode.TabIndex = 151;
            this.lblZipCode.Text = "郵便番号";
            this.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOfficeName
            // 
            this.lblOfficeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOfficeName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOfficeName.Location = new System.Drawing.Point(5, 174);
            this.lblOfficeName.Name = "lblOfficeName";
            this.lblOfficeName.Size = new System.Drawing.Size(155, 25);
            this.lblOfficeName.TabIndex = 9;
            this.lblOfficeName.Text = "所属";
            this.lblOfficeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCompanyName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCompanyName.Location = new System.Drawing.Point(5, 118);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(155, 25);
            this.lblCompanyName.TabIndex = 4;
            this.lblCompanyName.Text = "会社名";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(5, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 25);
            this.label7.TabIndex = 157;
            this.label7.Text = "個人名";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.rdoNaga3);
            this.panel4.Controls.Add(this.rdoKaku2);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(74, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(184, 73);
            this.panel4.TabIndex = 1;
            // 
            // rdoNaga3
            // 
            this.rdoNaga3.AutoSize = true;
            this.rdoNaga3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNaga3.Location = new System.Drawing.Point(96, 37);
            this.rdoNaga3.Name = "rdoNaga3";
            this.rdoNaga3.Size = new System.Drawing.Size(58, 23);
            this.rdoNaga3.TabIndex = 21;
            this.rdoNaga3.Text = "長3";
            this.rdoNaga3.UseVisualStyleBackColor = true;
            // 
            // rdoKaku2
            // 
            this.rdoKaku2.AutoSize = true;
            this.rdoKaku2.Checked = true;
            this.rdoKaku2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoKaku2.Location = new System.Drawing.Point(8, 38);
            this.rdoKaku2.Name = "rdoKaku2";
            this.rdoKaku2.Size = new System.Drawing.Size(58, 23);
            this.rdoKaku2.TabIndex = 11;
            this.rdoKaku2.TabStop = true;
            this.rdoKaku2.Text = "角2";
            this.rdoKaku2.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(3, 2);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(103, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　封筒種類";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnPreview);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Controls.Add(this.btnPrint);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Location = new System.Drawing.Point(74, 463);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(718, 72);
            this.panel5.TabIndex = 391;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(145, 9);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(141, 47);
            this.btnPreview.TabIndex = 503;
            this.btnPreview.Text = "F3：プレビュー";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(445, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 47);
            this.btnCancel.TabIndex = 431;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(576, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 47);
            this.btnClose.TabIndex = 441;
            this.btnClose.Text = "F12：終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(293, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 47);
            this.btnPrint.TabIndex = 411;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(14, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 47);
            this.btnSearch.TabIndex = 401;
            this.btnSearch.Text = "F1：検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAtena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 544);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAtena";
            this.Text = "宛名印刷";
            this.Load += new System.EventHandler(this.frmTokuiM_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Common.CustomTextBox txtCompanyName;
        private Common.CustomTextBox txtBelongs1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoNaga3;
        private System.Windows.Forms.RadioButton rdoKaku2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel5;
        private Common.FeaturesButton btnCancel;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnSearch;
        private System.Windows.Forms.Label lblOfficeName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Panel panel2;
        private Common.CustomTextBox txtAddress2;
        private Common.CustomTextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label2;
        private Common.CustomTextBox txtZipCode2;
        private Common.CustomTextBox txtZipCode1;
        private System.Windows.Forms.Label lblZipCode;
        private Common.FeaturesButton btnPreview;
        private System.Windows.Forms.Panel panel17;
        private Common.CustomTextBox txtBelongs2;
        private System.Windows.Forms.Panel panel6;
        private Common.CustomTextBox txtTitle;
        private System.Windows.Forms.Panel panel3;
        private Common.CustomTextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private Common.CustomComboBox cmbTitles1;
        private Common.CustomComboBox cmbTitles2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private YamazakiMatex.Print.Report.rptAtena2Gou rptAtena2Gou1;
        private YamazakiMatex.Print.Report.rptAtena3Gou rptAtena3Gou1;
        private System.Windows.Forms.Panel panel7;
        private Common.CustomComboBox cmbBikou;
        private System.Windows.Forms.Label lblBikou;
    }
}

