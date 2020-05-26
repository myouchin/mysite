namespace PrintInstructions
{
    partial class frmTokuisakiUriageSyukei
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
            this.pnlTargetYDate = new System.Windows.Forms.Panel();
            this.lblTargetYDateYears = new System.Windows.Forms.Label();
            this.txtTargetYDateYears = new Common.CustomTextBox();
            this.dtpTargetYDateFrom = new Common.CustomDateTimePicker();
            this.lblTargetYDate = new Common.ItemHeadLabel();
            this.pnlTargetYMDate = new System.Windows.Forms.Panel();
            this.lblTargetYMDateMonth = new System.Windows.Forms.Label();
            this.txtTargetYMDateMonth = new Common.CustomTextBox();
            this.txtTargetYMDateYears = new Common.CustomTextBox();
            this.lblTargetYMDateYears = new System.Windows.Forms.Label();
            this.dtpTargetYMDate = new Common.CustomDateTimePicker();
            this.lblTargetYMDate = new Common.ItemHeadLabel();
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
            this.rptTokuisakibetuUriageShukeihyo1 = new YamazakiMatex.Print.Report.rptTokuisakibetuUriageShukeihyo();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetYDate.SuspendLayout();
            this.pnlTargetYMDate.SuspendLayout();
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
            this.pnlHeader.Controls.Add(this.pnlTargetYDate);
            this.pnlHeader.Controls.Add(this.lblTargetYDate);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDate);
            this.pnlHeader.Controls.Add(this.lblTargetYMDate);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateTo);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblTargetYMDDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(648, 186);
            this.pnlHeader.TabIndex = 103;
            // 
            // pnlTargetYDate
            // 
            this.pnlTargetYDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYDate.Controls.Add(this.lblTargetYDateYears);
            this.pnlTargetYDate.Controls.Add(this.txtTargetYDateYears);
            this.pnlTargetYDate.Controls.Add(this.dtpTargetYDateFrom);
            this.pnlTargetYDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYDate.Location = new System.Drawing.Point(344, 81);
            this.pnlTargetYDate.Name = "pnlTargetYDate";
            this.pnlTargetYDate.Size = new System.Drawing.Size(80, 27);
            this.pnlTargetYDate.TabIndex = 144;
            // 
            // lblTargetYDateYears
            // 
            this.lblTargetYDateYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYDateYears.Name = "lblTargetYDateYears";
            this.lblTargetYDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYDateYears.TabIndex = 115;
            this.lblTargetYDateYears.Text = "年";
            this.lblTargetYDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetYDateYears
            // 
            this.txtTargetYDateYears.BeforeValue = "";
            this.txtTargetYDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYDateYears.DownControl = null;
            this.txtTargetYDateYears.EnterControl = null;
            this.txtTargetYDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYDateYears.LabelControl = null;
            this.txtTargetYDateYears.LeftControl = null;
            this.txtTargetYDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYDateYears.Name = "txtTargetYDateYears";
            this.txtTargetYDateYears.RightControl = null;
            this.txtTargetYDateYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYDateYears.TabIndex = 115;
            this.txtTargetYDateYears.Text = "1234";
            this.txtTargetYDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYDateYears.UpControl = null;
            // 
            // dtpTargetYDateFrom
            // 
            this.dtpTargetYDateFrom.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYDateFrom.CustomFormat = " ";
            this.dtpTargetYDateFrom.DaysLinkTextControl = null;
            this.dtpTargetYDateFrom.DownControl = null;
            this.dtpTargetYDateFrom.EnterControl = null;
            this.dtpTargetYDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYDateFrom.LeftControl = null;
            this.dtpTargetYDateFrom.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYDateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYDateFrom.MonthLinkTextControl = null;
            this.dtpTargetYDateFrom.Name = "dtpTargetYDateFrom";
            this.dtpTargetYDateFrom.RightControl = null;
            this.dtpTargetYDateFrom.Size = new System.Drawing.Size(0, 27);
            this.dtpTargetYDateFrom.TabIndex = 132;
            this.dtpTargetYDateFrom.UpControl = null;
            this.dtpTargetYDateFrom.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYDateFrom.Value2 = null;
            this.dtpTargetYDateFrom.YearsLinkTextControl = this.txtTargetYDateYears;
            // 
            // lblTargetYDate
            // 
            this.lblTargetYDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYDate.ForeColor = System.Drawing.Color.White;
            this.lblTargetYDate.Location = new System.Drawing.Point(214, 81);
            this.lblTargetYDate.Name = "lblTargetYDate";
            this.lblTargetYDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetYDate.TabIndex = 142;
            this.lblTargetYDate.Text = "対象年";
            this.lblTargetYDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTargetYMDate
            // 
            this.pnlTargetYMDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetYMDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetYMDate.Controls.Add(this.lblTargetYMDateMonth);
            this.pnlTargetYMDate.Controls.Add(this.txtTargetYMDateMonth);
            this.pnlTargetYMDate.Controls.Add(this.lblTargetYMDateYears);
            this.pnlTargetYMDate.Controls.Add(this.txtTargetYMDateYears);
            this.pnlTargetYMDate.Controls.Add(this.dtpTargetYMDate);
            this.pnlTargetYMDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetYMDate.Location = new System.Drawing.Point(309, 53);
            this.pnlTargetYMDate.Name = "pnlTargetYMDate";
            this.pnlTargetYMDate.Size = new System.Drawing.Size(150, 27);
            this.pnlTargetYMDate.TabIndex = 140;
            // 
            // lblTargetYMDateMonth
            // 
            this.lblTargetYMDateMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDateMonth.Name = "lblTargetYMDateMonth";
            this.lblTargetYMDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDateMonth.TabIndex = 117;
            this.lblTargetYMDateMonth.Text = "月";
            this.lblTargetYMDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetYMDateMonth
            // 
            this.txtTargetYMDateMonth.BeforeValue = "";
            this.txtTargetYMDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDateMonth.DownControl = null;
            this.txtTargetYMDateMonth.EnterControl = null;
            this.txtTargetYMDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDateMonth.LabelControl = null;
            this.txtTargetYMDateMonth.LeftControl = this.txtTargetYMDateYears;
            this.txtTargetYMDateMonth.Location = new System.Drawing.Point(66, 3);
            this.txtTargetYMDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDateMonth.Name = "txtTargetYMDateMonth";
            this.txtTargetYMDateMonth.RightControl = null;
            this.txtTargetYMDateMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetYMDateMonth.TabIndex = 116;
            this.txtTargetYMDateMonth.Text = "12";
            this.txtTargetYMDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDateMonth.UpControl = null;
            // 
            // txtTargetYMDateYears
            // 
            this.txtTargetYMDateYears.BeforeValue = "";
            this.txtTargetYMDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetYMDateYears.DownControl = null;
            this.txtTargetYMDateYears.EnterControl = this.txtTargetYMDateMonth;
            this.txtTargetYMDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetYMDateYears.LabelControl = null;
            this.txtTargetYMDateYears.LeftControl = null;
            this.txtTargetYMDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetYMDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetYMDateYears.Name = "txtTargetYMDateYears";
            this.txtTargetYMDateYears.RightControl = this.txtTargetYMDateMonth;
            this.txtTargetYMDateYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetYMDateYears.TabIndex = 115;
            this.txtTargetYMDateYears.Text = "1234";
            this.txtTargetYMDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetYMDateYears.UpControl = null;
            // 
            // lblTargetYMDateYears
            // 
            this.lblTargetYMDateYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetYMDateYears.Name = "lblTargetYMDateYears";
            this.lblTargetYMDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDateYears.TabIndex = 115;
            this.lblTargetYMDateYears.Text = "年";
            this.lblTargetYMDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetYMDate
            // 
            this.dtpTargetYMDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDate.CustomFormat = " ";
            this.dtpTargetYMDate.DaysLinkTextControl = null;
            this.dtpTargetYMDate.DownControl = null;
            this.dtpTargetYMDate.EnterControl = null;
            this.dtpTargetYMDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetYMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetYMDate.LeftControl = null;
            this.dtpTargetYMDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetYMDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetYMDate.MonthLinkTextControl = this.txtTargetYMDateMonth;
            this.dtpTargetYMDate.Name = "dtpTargetYMDate";
            this.dtpTargetYMDate.RightControl = null;
            this.dtpTargetYMDate.Size = new System.Drawing.Size(150, 27);
            this.dtpTargetYMDate.TabIndex = 132;
            this.dtpTargetYMDate.UpControl = null;
            this.dtpTargetYMDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetYMDate.Value2 = null;
            this.dtpTargetYMDate.YearsLinkTextControl = this.txtTargetYMDateYears;
            // 
            // lblTargetYMDate
            // 
            this.lblTargetYMDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetYMDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetYMDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetYMDate.ForeColor = System.Drawing.Color.White;
            this.lblTargetYMDate.Location = new System.Drawing.Point(179, 53);
            this.lblTargetYMDate.Name = "lblTargetYMDate";
            this.lblTargetYMDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetYMDate.TabIndex = 138;
            this.lblTargetYMDate.Text = "対象年月";
            this.lblTargetYMDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlTargetYMDDateTo.Location = new System.Drawing.Point(409, 25);
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
            this.pnlTargetYMDDateFrom.Location = new System.Drawing.Point(157, 25);
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
            this.lblFromToSeparated1.Location = new System.Drawing.Point(374, 29);
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
            this.lblTargetYMDDate.Location = new System.Drawing.Point(27, 25);
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
            this.panel1.Location = new System.Drawing.Point(0, 186);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 70);
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
            this.btnClose.Location = new System.Drawing.Point(524, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTokuisakiUriageSyukei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(648, 256);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTokuisakiUriageSyukei";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先別売上集計表出力";
            this.Load += new System.EventHandler(this.frmJyuchachuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTargetYDate.ResumeLayout(false);
            this.pnlTargetYDate.PerformLayout();
            this.pnlTargetYMDate.ResumeLayout(false);
            this.pnlTargetYMDate.PerformLayout();
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
        private YamazakiMatex.Print.Report.rptTokuisakibetuUriageShukeihyo rptTokuisakibetuUriageShukeihyo1;
        private Common.CustomTextBox txtTargetYDateYears;
        private System.Windows.Forms.Panel pnlTargetYDate;
        private System.Windows.Forms.Label lblTargetYDateYears;
        private Common.CustomDateTimePicker dtpTargetYDateFrom;
        private Common.ItemHeadLabel lblTargetYDate;
        private Common.CustomTextBox txtTargetYMDateMonth;
        private Common.CustomTextBox txtTargetYMDateYears;
        private System.Windows.Forms.Panel pnlTargetYMDate;
        private System.Windows.Forms.Label lblTargetYMDateMonth;
        private System.Windows.Forms.Label lblTargetYMDateYears;
        private Common.CustomDateTimePicker dtpTargetYMDate;
        private Common.ItemHeadLabel lblTargetYMDate;
    }
}