namespace PrintInstructions
{
    partial class frmRyoShuSho
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
            this.txtCustomerName1 = new Common.CustomTextBox();
            this.txtCustomerName2 = new Common.CustomTextBox();
            this.txtAmount = new Common.CustomTextBox();
            this.txtProviso = new Common.CustomTextBox();
            this.txtOutPutDateYears = new Common.CustomTextBox();
            this.txtOutPutDateMonth = new Common.CustomTextBox();
            this.txtOutPutDateDays = new Common.CustomTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlOutPutDate = new System.Windows.Forms.Panel();
            this.lblOutPutDateDays = new System.Windows.Forms.Label();
            this.lblOutPutDateMonth = new System.Windows.Forms.Label();
            this.lblOutPutDateYears = new System.Windows.Forms.Label();
            this.dtpOutPutDate = new Common.CustomDateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblOutPutDate = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnCancel = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnSearch = new Common.FeaturesButton();
            this.rptRyosyusyo1 = new YamazakiMatex.Print.Report.rptRyosyusyo();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdoGenkin = new System.Windows.Forms.RadioButton();
            this.rdoKogitte = new System.Windows.Forms.RadioButton();
            this.rdoTegata = new System.Windows.Forms.RadioButton();
            this.rdoSousai = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlOutPutDate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerName1
            // 
            this.txtCustomerName1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCustomerName1.BeforeValue = "";
            this.txtCustomerName1.DownControl = this.txtCustomerName2;
            this.txtCustomerName1.EnterControl = this.txtCustomerName2;
            this.txtCustomerName1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCustomerName1.LabelControl = null;
            this.txtCustomerName1.LeftControl = null;
            this.txtCustomerName1.Location = new System.Drawing.Point(3, 3);
            this.txtCustomerName1.Name = "txtCustomerName1";
            this.txtCustomerName1.RightControl = null;
            this.txtCustomerName1.Size = new System.Drawing.Size(264, 26);
            this.txtCustomerName1.TabIndex = 70;
            this.txtCustomerName1.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtCustomerName1.UpControl = this.txtOutPutDateYears;
            // 
            // txtCustomerName2
            // 
            this.txtCustomerName2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCustomerName2.BeforeValue = "";
            this.txtCustomerName2.DownControl = this.txtAmount;
            this.txtCustomerName2.EnterControl = this.txtAmount;
            this.txtCustomerName2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCustomerName2.LabelControl = null;
            this.txtCustomerName2.LeftControl = null;
            this.txtCustomerName2.Location = new System.Drawing.Point(3, 35);
            this.txtCustomerName2.Name = "txtCustomerName2";
            this.txtCustomerName2.RightControl = null;
            this.txtCustomerName2.Size = new System.Drawing.Size(264, 26);
            this.txtCustomerName2.TabIndex = 80;
            this.txtCustomerName2.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtCustomerName2.UpControl = this.txtCustomerName1;
            // 
            // txtAmount
            // 
            this.txtAmount.BeforeValue = "";
            this.txtAmount.DownControl = this.txtProviso;
            this.txtAmount.EnterControl = this.txtProviso;
            this.txtAmount.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAmount.LabelControl = null;
            this.txtAmount.LeftControl = null;
            this.txtAmount.Location = new System.Drawing.Point(3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightControl = null;
            this.txtAmount.Size = new System.Drawing.Size(264, 26);
            this.txtAmount.TabIndex = 100;
            this.txtAmount.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.UpControl = this.txtCustomerName2;
            // 
            // txtProviso
            // 
            this.txtProviso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProviso.BeforeValue = "";
            this.txtProviso.DownControl = null;
            this.txtProviso.EnterControl = null;
            this.txtProviso.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtProviso.LabelControl = null;
            this.txtProviso.LeftControl = null;
            this.txtProviso.Location = new System.Drawing.Point(3, 4);
            this.txtProviso.Name = "txtProviso";
            this.txtProviso.RightControl = null;
            this.txtProviso.Size = new System.Drawing.Size(340, 26);
            this.txtProviso.TabIndex = 120;
            this.txtProviso.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtProviso.UpControl = this.txtAmount;
            // 
            // txtOutPutDateYears
            // 
            this.txtOutPutDateYears.BeforeValue = "";
            this.txtOutPutDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutPutDateYears.DownControl = this.txtCustomerName1;
            this.txtOutPutDateYears.EnterControl = this.txtOutPutDateMonth;
            this.txtOutPutDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOutPutDateYears.LabelControl = null;
            this.txtOutPutDateYears.LeftControl = null;
            this.txtOutPutDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtOutPutDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutPutDateYears.Name = "txtOutPutDateYears";
            this.txtOutPutDateYears.RightControl = this.txtOutPutDateMonth;
            this.txtOutPutDateYears.Size = new System.Drawing.Size(45, 20);
            this.txtOutPutDateYears.TabIndex = 20;
            this.txtOutPutDateYears.Text = "1234";
            this.txtOutPutDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOutPutDateYears.UpControl = null;
            // 
            // txtOutPutDateMonth
            // 
            this.txtOutPutDateMonth.BeforeValue = "";
            this.txtOutPutDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutPutDateMonth.DownControl = this.txtCustomerName1;
            this.txtOutPutDateMonth.EnterControl = this.txtOutPutDateDays;
            this.txtOutPutDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOutPutDateMonth.LabelControl = null;
            this.txtOutPutDateMonth.LeftControl = this.txtOutPutDateYears;
            this.txtOutPutDateMonth.Location = new System.Drawing.Point(66, 3);
            this.txtOutPutDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutPutDateMonth.Name = "txtOutPutDateMonth";
            this.txtOutPutDateMonth.RightControl = this.txtOutPutDateDays;
            this.txtOutPutDateMonth.Size = new System.Drawing.Size(30, 20);
            this.txtOutPutDateMonth.TabIndex = 30;
            this.txtOutPutDateMonth.Text = "12";
            this.txtOutPutDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOutPutDateMonth.UpControl = null;
            // 
            // txtOutPutDateDays
            // 
            this.txtOutPutDateDays.BeforeValue = "";
            this.txtOutPutDateDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutPutDateDays.DownControl = this.txtCustomerName1;
            this.txtOutPutDateDays.EnterControl = this.txtCustomerName1;
            this.txtOutPutDateDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtOutPutDateDays.LabelControl = null;
            this.txtOutPutDateDays.LeftControl = this.txtOutPutDateMonth;
            this.txtOutPutDateDays.Location = new System.Drawing.Point(115, 3);
            this.txtOutPutDateDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutPutDateDays.Name = "txtOutPutDateDays";
            this.txtOutPutDateDays.RightControl = null;
            this.txtOutPutDateDays.Size = new System.Drawing.Size(33, 20);
            this.txtOutPutDateDays.TabIndex = 40;
            this.txtOutPutDateDays.Text = "12";
            this.txtOutPutDateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOutPutDateDays.UpControl = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.64156F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.35844F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAmount, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOutPutDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 4);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 240);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel4.Controls.Add(this.txtAmount);
            this.panel4.Location = new System.Drawing.Point(154, 117);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(270, 34);
            this.panel4.TabIndex = 90;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.Controls.Add(this.pnlOutPutDate);
            this.panel3.Location = new System.Drawing.Point(154, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(235, 32);
            this.panel3.TabIndex = 10;
            // 
            // pnlOutPutDate
            // 
            this.pnlOutPutDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlOutPutDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOutPutDate.Controls.Add(this.lblOutPutDateDays);
            this.pnlOutPutDate.Controls.Add(this.txtOutPutDateDays);
            this.pnlOutPutDate.Controls.Add(this.lblOutPutDateMonth);
            this.pnlOutPutDate.Controls.Add(this.txtOutPutDateMonth);
            this.pnlOutPutDate.Controls.Add(this.lblOutPutDateYears);
            this.pnlOutPutDate.Controls.Add(this.txtOutPutDateYears);
            this.pnlOutPutDate.Controls.Add(this.dtpOutPutDate);
            this.pnlOutPutDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlOutPutDate.Location = new System.Drawing.Point(3, 2);
            this.pnlOutPutDate.Name = "pnlOutPutDate";
            this.pnlOutPutDate.Size = new System.Drawing.Size(228, 27);
            this.pnlOutPutDate.TabIndex = 155;
            // 
            // lblOutPutDateDays
            // 
            this.lblOutPutDateDays.Location = new System.Drawing.Point(148, 0);
            this.lblOutPutDateDays.Name = "lblOutPutDateDays";
            this.lblOutPutDateDays.Size = new System.Drawing.Size(28, 27);
            this.lblOutPutDateDays.TabIndex = 119;
            this.lblOutPutDateDays.Text = "日";
            this.lblOutPutDateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutPutDateMonth
            // 
            this.lblOutPutDateMonth.Location = new System.Drawing.Point(93, 0);
            this.lblOutPutDateMonth.Name = "lblOutPutDateMonth";
            this.lblOutPutDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblOutPutDateMonth.TabIndex = 117;
            this.lblOutPutDateMonth.Text = "月";
            this.lblOutPutDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutPutDateYears
            // 
            this.lblOutPutDateYears.Location = new System.Drawing.Point(44, 0);
            this.lblOutPutDateYears.Name = "lblOutPutDateYears";
            this.lblOutPutDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblOutPutDateYears.TabIndex = 115;
            this.lblOutPutDateYears.Text = "年";
            this.lblOutPutDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpOutPutDate
            // 
            this.dtpOutPutDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpOutPutDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOutPutDate.CustomFormat = " ";
            this.dtpOutPutDate.DaysLinkTextControl = this.txtOutPutDateDays;
            this.dtpOutPutDate.DownControl = this.txtCustomerName1;
            this.dtpOutPutDate.EnterControl = this.txtCustomerName1;
            this.dtpOutPutDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpOutPutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutPutDate.LeftControl = this.txtOutPutDateDays;
            this.dtpOutPutDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpOutPutDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpOutPutDate.MonthLinkTextControl = this.txtOutPutDateMonth;
            this.dtpOutPutDate.Name = "dtpOutPutDate";
            this.dtpOutPutDate.RightControl = null;
            this.dtpOutPutDate.Size = new System.Drawing.Size(228, 27);
            this.dtpOutPutDate.TabIndex = 50;
            this.dtpOutPutDate.UpControl = null;
            this.dtpOutPutDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpOutPutDate.Value2 = null;
            this.dtpOutPutDate.YearsLinkTextControl = this.txtOutPutDateYears;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.txtCustomerName2);
            this.panel1.Controls.Add(this.txtCustomerName1);
            this.panel1.Location = new System.Drawing.Point(154, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 64);
            this.panel1.TabIndex = 60;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAmount.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAmount.Location = new System.Drawing.Point(5, 121);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(141, 25);
            this.lblAmount.TabIndex = 158;
            this.lblAmount.Text = "金額";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOutPutDate
            // 
            this.lblOutPutDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutPutDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOutPutDate.Location = new System.Drawing.Point(5, 11);
            this.lblOutPutDate.Name = "lblOutPutDate";
            this.lblOutPutDate.Size = new System.Drawing.Size(141, 20);
            this.lblOutPutDate.TabIndex = 151;
            this.lblOutPutDate.Text = "年月日";
            this.lblOutPutDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomerName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCustomerName.Location = new System.Drawing.Point(5, 64);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(141, 25);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "宛先";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAddress.Location = new System.Drawing.Point(5, 156);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(141, 40);
            this.lblAddress.TabIndex = 157;
            this.lblAddress.Text = "但し書き";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.txtProviso);
            this.panel2.Location = new System.Drawing.Point(154, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 34);
            this.panel2.TabIndex = 110;
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
            this.panel5.Location = new System.Drawing.Point(12, 258);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(5, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 40);
            this.label1.TabIndex = 159;
            this.label1.Text = "種別";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdoSousai);
            this.panel6.Controls.Add(this.rdoTegata);
            this.panel6.Controls.Add(this.rdoKogitte);
            this.panel6.Controls.Add(this.rdoGenkin);
            this.panel6.Location = new System.Drawing.Point(154, 201);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(549, 34);
            this.panel6.TabIndex = 160;
            // 
            // rdoGenkin
            // 
            this.rdoGenkin.AutoSize = true;
            this.rdoGenkin.Checked = true;
            this.rdoGenkin.Location = new System.Drawing.Point(4, 9);
            this.rdoGenkin.Name = "rdoGenkin";
            this.rdoGenkin.Size = new System.Drawing.Size(62, 18);
            this.rdoGenkin.TabIndex = 0;
            this.rdoGenkin.TabStop = true;
            this.rdoGenkin.Text = "現　金";
            this.rdoGenkin.UseVisualStyleBackColor = true;
            // 
            // rdoKogitte
            // 
            this.rdoKogitte.AutoSize = true;
            this.rdoKogitte.Location = new System.Drawing.Point(72, 9);
            this.rdoKogitte.Name = "rdoKogitte";
            this.rdoKogitte.Size = new System.Drawing.Size(67, 18);
            this.rdoKogitte.TabIndex = 1;
            this.rdoKogitte.TabStop = true;
            this.rdoKogitte.Text = "小切手";
            this.rdoKogitte.UseVisualStyleBackColor = true;
            // 
            // rdoTegata
            // 
            this.rdoTegata.AutoSize = true;
            this.rdoTegata.Location = new System.Drawing.Point(145, 9);
            this.rdoTegata.Name = "rdoTegata";
            this.rdoTegata.Size = new System.Drawing.Size(62, 18);
            this.rdoTegata.TabIndex = 2;
            this.rdoTegata.TabStop = true;
            this.rdoTegata.Text = "手　形";
            this.rdoTegata.UseVisualStyleBackColor = true;
            // 
            // rdoSousai
            // 
            this.rdoSousai.AutoSize = true;
            this.rdoSousai.Location = new System.Drawing.Point(213, 9);
            this.rdoSousai.Name = "rdoSousai";
            this.rdoSousai.Size = new System.Drawing.Size(62, 18);
            this.rdoSousai.TabIndex = 3;
            this.rdoSousai.TabStop = true;
            this.rdoSousai.Text = "相　殺";
            this.rdoSousai.UseVisualStyleBackColor = true;
            // 
            // frmRyoShuSho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 335);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRyoShuSho";
            this.Text = "領収書出力";
            this.Load += new System.EventHandler(this.frmTokuiM_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlOutPutDate.ResumeLayout(false);
            this.pnlOutPutDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Common.CustomTextBox txtCustomerName1;
        private System.Windows.Forms.Panel panel5;
        private Common.FeaturesButton btnCancel;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnSearch;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel panel2;
        private Common.CustomTextBox txtProviso;
        private System.Windows.Forms.Label lblOutPutDate;
        private Common.FeaturesButton btnPreview;
        private System.Windows.Forms.Panel pnlOutPutDate;
        private System.Windows.Forms.Label lblOutPutDateDays;
        private Common.CustomTextBox txtOutPutDateDays;
        private Common.CustomTextBox txtOutPutDateMonth;
        private Common.CustomTextBox txtOutPutDateYears;
        private System.Windows.Forms.Label lblOutPutDateMonth;
        private System.Windows.Forms.Label lblOutPutDateYears;
        private Common.CustomDateTimePicker dtpOutPutDate;
        private System.Windows.Forms.Label lblAddress;
        private YamazakiMatex.Print.Report.rptRyosyusyo rptRyosyusyo1;
        private System.Windows.Forms.Label lblAmount;
        private Common.CustomTextBox txtAmount;
        private System.Windows.Forms.Panel panel1;
        private Common.CustomTextBox txtCustomerName2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rdoSousai;
        private System.Windows.Forms.RadioButton rdoTegata;
        private System.Windows.Forms.RadioButton rdoKogitte;
        private System.Windows.Forms.RadioButton rdoGenkin;
    }
}

