namespace PrintInstructions
{
    partial class frmJuchuKanrenIchiran
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cmbDateType = new Common.CustomComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoExistsNouhinShire = new System.Windows.Forms.RadioButton();
            this.itemHeadLabel1 = new Common.ItemHeadLabel();
            this.rdoNotExistsNouhinShire = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.pnlTargetYMDDateTo = new System.Windows.Forms.Panel();
            this.lblTargetYMDDateToDays = new System.Windows.Forms.Label();
            this.txtTargetYMDDateToDays = new Common.CustomTextBox();
            this.txtTargetYMDDateToMonth = new Common.CustomTextBox();
            this.txtTargetYMDDateToYears = new Common.CustomTextBox();
            this.txtTargetYMDDateFromDays = new Common.CustomTextBox();
            this.txtTargetYMDDateFromMonth = new Common.CustomTextBox();
            this.txtTargetYMDDateFromYears = new Common.CustomTextBox();
            this.lblTargetYMDDateToMonth = new System.Windows.Forms.Label();
            this.lblTargetYMDDateToYears = new System.Windows.Forms.Label();
            this.dtpTargetYMDDateTo = new Common.CustomDateTimePicker();
            this.pnlTargetYMDDateFrom = new System.Windows.Forms.Panel();
            this.lblTargetYMDDateFromDays = new System.Windows.Forms.Label();
            this.lblTargetYMDDateFromMonth = new System.Windows.Forms.Label();
            this.lblTargetYMDDateFromYears = new System.Windows.Forms.Label();
            this.dtpTargetYMDDateFrom = new Common.CustomDateTimePicker();
            this.lblFromToSeparated1 = new System.Windows.Forms.Label();
            this.lblTargetYMDDate = new Common.ItemHeadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptJuchuKanrenIchiran1 = new YamazakiMatex.Print.Report.rptJuchuKanrenIchiran();
            this.pnlHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTargetYMDDateTo.SuspendLayout();
            this.pnlTargetYMDDateFrom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.cmbDateType);
            this.pnlHeader.Controls.Add(this.panel2);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateTo);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblTargetYMDDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(769, 158);
            this.pnlHeader.TabIndex = 103;
            // 
            // cmbDateType
            // 
            this.cmbDateType.BeforeSelectedValue = "";
            this.cmbDateType.DownControl = null;
            this.cmbDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateType.EnterControl = null;
            this.cmbDateType.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbDateType.FormattingEnabled = true;
            this.cmbDateType.LabelControl = null;
            this.cmbDateType.LeftControl = null;
            this.cmbDateType.Location = new System.Drawing.Point(157, 106);
            this.cmbDateType.Name = "cmbDateType";
            this.cmbDateType.RightControl = null;
            this.cmbDateType.Size = new System.Drawing.Size(122, 27);
            this.cmbDateType.TabIndex = 139;
            this.cmbDateType.UpControl = null;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rdoExistsNouhinShire);
            this.panel2.Controls.Add(this.itemHeadLabel1);
            this.panel2.Controls.Add(this.rdoNotExistsNouhinShire);
            this.panel2.Controls.Add(this.rdoAll);
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 73);
            this.panel2.TabIndex = 138;
            // 
            // rdoExistsNouhinShire
            // 
            this.rdoExistsNouhinShire.AutoSize = true;
            this.rdoExistsNouhinShire.Location = new System.Drawing.Point(342, 36);
            this.rdoExistsNouhinShire.Name = "rdoExistsNouhinShire";
            this.rdoExistsNouhinShire.Size = new System.Drawing.Size(217, 24);
            this.rdoExistsNouhinShire.TabIndex = 56;
            this.rdoExistsNouhinShire.Text = "納品書と仕入が作成済";
            this.rdoExistsNouhinShire.UseVisualStyleBackColor = true;
            // 
            // itemHeadLabel1
            // 
            this.itemHeadLabel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.itemHeadLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemHeadLabel1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemHeadLabel1.ForeColor = System.Drawing.Color.White;
            this.itemHeadLabel1.Location = new System.Drawing.Point(7, 6);
            this.itemHeadLabel1.Name = "itemHeadLabel1";
            this.itemHeadLabel1.Size = new System.Drawing.Size(159, 27);
            this.itemHeadLabel1.TabIndex = 55;
            this.itemHeadLabel1.Text = "出力対象選択";
            this.itemHeadLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoNotExistsNouhinShire
            // 
            this.rdoNotExistsNouhinShire.AutoSize = true;
            this.rdoNotExistsNouhinShire.Location = new System.Drawing.Point(84, 36);
            this.rdoNotExistsNouhinShire.Name = "rdoNotExistsNouhinShire";
            this.rdoNotExistsNouhinShire.Size = new System.Drawing.Size(252, 24);
            this.rdoNotExistsNouhinShire.TabIndex = 1;
            this.rdoNotExistsNouhinShire.Text = "納品書または仕入が未作成";
            this.rdoNotExistsNouhinShire.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(15, 36);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(63, 24);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "全て";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // pnlTargetYMDDateTo
            // 
            this.pnlTargetYMDDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYMDDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYMDDateTo.Controls.Add(this.lblTargetYMDDateToDays);
            this.pnlTargetYMDDateTo.Controls.Add(this.txtTargetYMDDateToDays);
            this.pnlTargetYMDDateTo.Controls.Add(this.lblTargetYMDDateToMonth);
            this.pnlTargetYMDDateTo.Controls.Add(this.txtTargetYMDDateToMonth);
            this.pnlTargetYMDDateTo.Controls.Add(this.lblTargetYMDDateToYears);
            this.pnlTargetYMDDateTo.Controls.Add(this.txtTargetYMDDateToYears);
            this.pnlTargetYMDDateTo.Controls.Add(this.dtpTargetYMDDateTo);
            this.pnlTargetYMDDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYMDDateTo.Location = new System.Drawing.Point(530, 106);
            this.pnlTargetYMDDateTo.Name = "pnlTargetYMDDateTo";
            this.pnlTargetYMDDateTo.Size = new System.Drawing.Size(210, 27);
            this.pnlTargetYMDDateTo.TabIndex = 137;
            // 
            // lblTargetYMDDateToDays
            // 
            this.lblTargetYMDDateToDays.Location = new System.Drawing.Point(148, 0);
            this.lblTargetYMDDateToDays.Name = "lblTargetYMDDateToDays";
            this.lblTargetYMDDateToDays.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToDays.TabIndex = 119;
            this.lblTargetYMDDateToDays.Text = "日";
            this.lblTargetYMDDateToDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetYMDDateToDays
            // 
            this.txtTargetYMDDateToDays.BeforeValue = "";
            this.txtTargetYMDDateToDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateToDays.DownControl = null;
            this.txtTargetYMDDateToDays.EnterControl = null;
            this.txtTargetYMDDateToDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateToDays.LabelControl = null;
            this.txtTargetYMDDateToDays.LeftControl = this.txtTargetYMDDateToMonth;
            this.txtTargetYMDDateToDays.Location = new System.Drawing.Point(115, 3);
            this.txtTargetYMDDateToDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateToDays.Name = "txtTargetYMDDateToDays";
            this.txtTargetYMDDateToDays.RightControl = null;
            this.txtTargetYMDDateToDays.Size = new System.Drawing.Size(33, 20);
            this.txtTargetYMDDateToDays.TabIndex = 118;
            this.txtTargetYMDDateToDays.Text = "12";
            this.txtTargetYMDDateToDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateToDays.UpControl = null;
            // 
            // txtTargetYMDDateToMonth
            // 
            this.txtTargetYMDDateToMonth.BeforeValue = "";
            this.txtTargetYMDDateToMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateToMonth.DownControl = null;
            this.txtTargetYMDDateToMonth.EnterControl = this.txtTargetYMDDateToDays;
            this.txtTargetYMDDateToMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateToMonth.LabelControl = null;
            this.txtTargetYMDDateToMonth.LeftControl = this.txtTargetYMDDateToYears;
            this.txtTargetYMDDateToMonth.Location = new System.Drawing.Point(68, 3);
            this.txtTargetYMDDateToMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateToMonth.Name = "txtTargetYMDDateToMonth";
            this.txtTargetYMDDateToMonth.RightControl = this.txtTargetYMDDateToDays;
            this.txtTargetYMDDateToMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetYMDDateToMonth.TabIndex = 116;
            this.txtTargetYMDDateToMonth.Text = "12";
            this.txtTargetYMDDateToMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateToMonth.UpControl = null;
            // 
            // txtTargetYMDDateToYears
            // 
            this.txtTargetYMDDateToYears.BeforeValue = "";
            this.txtTargetYMDDateToYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateToYears.DownControl = null;
            this.txtTargetYMDDateToYears.EnterControl = this.txtTargetYMDDateToMonth;
            this.txtTargetYMDDateToYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateToYears.LabelControl = null;
            this.txtTargetYMDDateToYears.LeftControl = this.txtTargetYMDDateFromDays;
            this.txtTargetYMDDateToYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYMDDateToYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateToYears.Name = "txtTargetYMDDateToYears";
            this.txtTargetYMDDateToYears.RightControl = this.txtTargetYMDDateToMonth;
            this.txtTargetYMDDateToYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYMDDateToYears.TabIndex = 115;
            this.txtTargetYMDDateToYears.Text = "1234";
            this.txtTargetYMDDateToYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateToYears.UpControl = null;
            // 
            // txtTargetYMDDateFromDays
            // 
            this.txtTargetYMDDateFromDays.BeforeValue = "";
            this.txtTargetYMDDateFromDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateFromDays.DownControl = null;
            this.txtTargetYMDDateFromDays.EnterControl = this.txtTargetYMDDateToYears;
            this.txtTargetYMDDateFromDays.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateFromDays.LabelControl = null;
            this.txtTargetYMDDateFromDays.LeftControl = this.txtTargetYMDDateFromMonth;
            this.txtTargetYMDDateFromDays.Location = new System.Drawing.Point(115, 3);
            this.txtTargetYMDDateFromDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateFromDays.Name = "txtTargetYMDDateFromDays";
            this.txtTargetYMDDateFromDays.RightControl = this.txtTargetYMDDateToYears;
            this.txtTargetYMDDateFromDays.Size = new System.Drawing.Size(33, 20);
            this.txtTargetYMDDateFromDays.TabIndex = 118;
            this.txtTargetYMDDateFromDays.Text = "12";
            this.txtTargetYMDDateFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateFromDays.UpControl = null;
            // 
            // txtTargetYMDDateFromMonth
            // 
            this.txtTargetYMDDateFromMonth.BeforeValue = "";
            this.txtTargetYMDDateFromMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateFromMonth.DownControl = null;
            this.txtTargetYMDDateFromMonth.EnterControl = this.txtTargetYMDDateFromDays;
            this.txtTargetYMDDateFromMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateFromMonth.LabelControl = null;
            this.txtTargetYMDDateFromMonth.LeftControl = this.txtTargetYMDDateFromYears;
            this.txtTargetYMDDateFromMonth.Location = new System.Drawing.Point(66, 3);
            this.txtTargetYMDDateFromMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateFromMonth.Name = "txtTargetYMDDateFromMonth";
            this.txtTargetYMDDateFromMonth.RightControl = this.txtTargetYMDDateFromDays;
            this.txtTargetYMDDateFromMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetYMDDateFromMonth.TabIndex = 116;
            this.txtTargetYMDDateFromMonth.Text = "12";
            this.txtTargetYMDDateFromMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateFromMonth.UpControl = null;
            // 
            // txtTargetYMDDateFromYears
            // 
            this.txtTargetYMDDateFromYears.BeforeValue = "";
            this.txtTargetYMDDateFromYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDDateFromYears.DownControl = null;
            this.txtTargetYMDDateFromYears.EnterControl = this.txtTargetYMDDateFromMonth;
            this.txtTargetYMDDateFromYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDDateFromYears.LabelControl = null;
            this.txtTargetYMDDateFromYears.LeftControl = null;
            this.txtTargetYMDDateFromYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYMDDateFromYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDDateFromYears.Name = "txtTargetYMDDateFromYears";
            this.txtTargetYMDDateFromYears.RightControl = this.txtTargetYMDDateFromMonth;
            this.txtTargetYMDDateFromYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYMDDateFromYears.TabIndex = 115;
            this.txtTargetYMDDateFromYears.Text = "1234";
            this.txtTargetYMDDateFromYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDDateFromYears.UpControl = null;
            // 
            // lblTargetYMDDateToMonth
            // 
            this.lblTargetYMDDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDDateToMonth.Name = "lblTargetYMDDateToMonth";
            this.lblTargetYMDDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToMonth.TabIndex = 117;
            this.lblTargetYMDDateToMonth.Text = "月";
            this.lblTargetYMDDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateToYears
            // 
            this.lblTargetYMDDateToYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYMDDateToYears.Name = "lblTargetYMDDateToYears";
            this.lblTargetYMDDateToYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToYears.TabIndex = 115;
            this.lblTargetYMDDateToYears.Text = "年";
            this.lblTargetYMDDateToYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYMDDateTo
            // 
            this.dtpTargetYMDDateTo.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateTo.CustomFormat = " ";
            this.dtpTargetYMDDateTo.DaysLinkTextControl = this.txtTargetYMDDateToDays;
            this.dtpTargetYMDDateTo.DownControl = null;
            this.dtpTargetYMDDateTo.EnterControl = null;
            this.dtpTargetYMDDateTo.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYMDDateTo.LeftControl = this.txtTargetYMDDateToDays;
            this.dtpTargetYMDDateTo.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYMDDateTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYMDDateTo.MonthLinkTextControl = this.txtTargetYMDDateToMonth;
            this.dtpTargetYMDDateTo.Name = "dtpTargetYMDDateTo";
            this.dtpTargetYMDDateTo.RightControl = null;
            this.dtpTargetYMDDateTo.Size = new System.Drawing.Size(210, 27);
            this.dtpTargetYMDDateTo.TabIndex = 132;
            this.dtpTargetYMDDateTo.UpControl = null;
            this.dtpTargetYMDDateTo.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYMDDateTo.Value2 = null;
            this.dtpTargetYMDDateTo.YearsLinkTextControl = this.txtTargetYMDDateToYears;
            // 
            // pnlTargetYMDDateFrom
            // 
            this.pnlTargetYMDDateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYMDDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYMDDateFrom.Controls.Add(this.lblTargetYMDDateFromDays);
            this.pnlTargetYMDDateFrom.Controls.Add(this.txtTargetYMDDateFromDays);
            this.pnlTargetYMDDateFrom.Controls.Add(this.lblTargetYMDDateFromMonth);
            this.pnlTargetYMDDateFrom.Controls.Add(this.txtTargetYMDDateFromMonth);
            this.pnlTargetYMDDateFrom.Controls.Add(this.lblTargetYMDDateFromYears);
            this.pnlTargetYMDDateFrom.Controls.Add(this.txtTargetYMDDateFromYears);
            this.pnlTargetYMDDateFrom.Controls.Add(this.dtpTargetYMDDateFrom);
            this.pnlTargetYMDDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYMDDateFrom.Location = new System.Drawing.Point(278, 106);
            this.pnlTargetYMDDateFrom.Name = "pnlTargetYMDDateFrom";
            this.pnlTargetYMDDateFrom.Size = new System.Drawing.Size(210, 27);
            this.pnlTargetYMDDateFrom.TabIndex = 136;
            // 
            // lblTargetYMDDateFromDays
            // 
            this.lblTargetYMDDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblTargetYMDDateFromDays.Name = "lblTargetYMDDateFromDays";
            this.lblTargetYMDDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromDays.TabIndex = 119;
            this.lblTargetYMDDateFromDays.Text = "日";
            this.lblTargetYMDDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateFromMonth
            // 
            this.lblTargetYMDDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDDateFromMonth.Name = "lblTargetYMDDateFromMonth";
            this.lblTargetYMDDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromMonth.TabIndex = 117;
            this.lblTargetYMDDateFromMonth.Text = "月";
            this.lblTargetYMDDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateFromYears
            // 
            this.lblTargetYMDDateFromYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYMDDateFromYears.Name = "lblTargetYMDDateFromYears";
            this.lblTargetYMDDateFromYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromYears.TabIndex = 115;
            this.lblTargetYMDDateFromYears.Text = "年";
            this.lblTargetYMDDateFromYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYMDDateFrom
            // 
            this.dtpTargetYMDDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateFrom.CustomFormat = " ";
            this.dtpTargetYMDDateFrom.DaysLinkTextControl = this.txtTargetYMDDateFromDays;
            this.dtpTargetYMDDateFrom.DownControl = null;
            this.dtpTargetYMDDateFrom.EnterControl = this.txtTargetYMDDateToYears;
            this.dtpTargetYMDDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYMDDateFrom.LeftControl = this.txtTargetYMDDateFromDays;
            this.dtpTargetYMDDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYMDDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYMDDateFrom.MonthLinkTextControl = this.txtTargetYMDDateFromMonth;
            this.dtpTargetYMDDateFrom.Name = "dtpTargetYMDDateFrom";
            this.dtpTargetYMDDateFrom.RightControl = this.txtTargetYMDDateToYears;
            this.dtpTargetYMDDateFrom.Size = new System.Drawing.Size(210, 27);
            this.dtpTargetYMDDateFrom.TabIndex = 132;
            this.dtpTargetYMDDateFrom.UpControl = null;
            this.dtpTargetYMDDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYMDDateFrom.Value2 = null;
            this.dtpTargetYMDDateFrom.YearsLinkTextControl = this.txtTargetYMDDateFromYears;
            // 
            // lblFromToSeparated1
            // 
            this.lblFromToSeparated1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToSeparated1.Location = new System.Drawing.Point(495, 110);
            this.lblFromToSeparated1.Name = "lblFromToSeparated1";
            this.lblFromToSeparated1.Size = new System.Drawing.Size(29, 20);
            this.lblFromToSeparated1.TabIndex = 135;
            this.lblFromToSeparated1.Text = "～";
            // 
            // lblTargetYMDDate
            // 
            this.lblTargetYMDDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYMDDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYMDDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYMDDate.ForeColor = System.Drawing.Color.White;
            this.lblTargetYMDDate.Location = new System.Drawing.Point(27, 106);
            this.lblTargetYMDDate.Name = "lblTargetYMDDate";
            this.lblTargetYMDDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetYMDDate.TabIndex = 54;
            this.lblTargetYMDDate.Text = "対象年月日";
            this.lblTargetYMDDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 70);
            this.panel1.TabIndex = 451;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPreview.Location = new System.Drawing.Point(3, 15);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(146, 40);
            this.btnPreview.TabIndex = 501;
            this.btnPreview.Text = "F3：プレビュー";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(157, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 40);
            this.btnPrint.TabIndex = 470;
            this.btnPrint.Text = "F4：印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(624, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmJuchuKanrenIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(769, 228);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmJuchuKanrenIchiran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "受注・納品・仕入関連一覧表出力";
            this.Load += new System.EventHandler(this.frmJyuchachuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTargetYMDDateTo.ResumeLayout(false);
            this.pnlTargetYMDDateTo.PerformLayout();
            this.pnlTargetYMDDateFrom.ResumeLayout(false);
            this.pnlTargetYMDDateFrom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private Common.ItemHeadLabel lblTargetYMDDate;
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnClose;
        private System.Windows.Forms.Panel pnlTargetYMDDateTo;
        private System.Windows.Forms.Label lblTargetYMDDateToDays;
        private Common.CustomTextBox txtTargetYMDDateToDays;
        private Common.CustomTextBox txtTargetYMDDateToMonth;
        private Common.CustomTextBox txtTargetYMDDateToYears;
        private Common.CustomTextBox txtTargetYMDDateFromDays;
        private Common.CustomTextBox txtTargetYMDDateFromMonth;
        private Common.CustomTextBox txtTargetYMDDateFromYears;
        private System.Windows.Forms.Label lblTargetYMDDateToMonth;
        private System.Windows.Forms.Label lblTargetYMDDateToYears;
        private Common.CustomDateTimePicker dtpTargetYMDDateTo;
        private System.Windows.Forms.Panel pnlTargetYMDDateFrom;
        private System.Windows.Forms.Label lblTargetYMDDateFromDays;
        private System.Windows.Forms.Label lblTargetYMDDateFromMonth;
        private System.Windows.Forms.Label lblTargetYMDDateFromYears;
        private Common.CustomDateTimePicker dtpTargetYMDDateFrom;
        private System.Windows.Forms.Label lblFromToSeparated1;
        private System.Windows.Forms.Panel panel2;
        private Common.ItemHeadLabel itemHeadLabel1;
        private System.Windows.Forms.RadioButton rdoNotExistsNouhinShire;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoExistsNouhinShire;
        private Common.CustomComboBox cmbDateType;
        private YamazakiMatex.Print.Report.rptJuchuKanrenIchiran rptJuchuKanrenIchiran1;
    }
}