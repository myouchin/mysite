namespace SubForm
{
    partial class sfrmUriageIchiran
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Common.FeaturesButton();
            this.btnBack = new Common.FeaturesButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDateType = new Common.CustomComboBox();
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
            this.grdSearchList = new System.Windows.Forms.DataGridView();
            this.clmJuchuNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmJuchuDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHachuNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNouhinsyoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNouhinsyoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShireNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Common.FeaturesButton();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetYMDDateTo.SuspendLayout();
            this.pnlTargetYMDDateFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(3, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(167, 40);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "F1：一覧再表示";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(1110, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 40);
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "F12：閉じる";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button10_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSize = true;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Controls.Add(this.grdSearchList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1229, 692);
            this.pnlBody.TabIndex = 104;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.cmbDateType);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateTo);
            this.pnlHeader.Controls.Add(this.pnlTargetYMDDateFrom);
            this.pnlHeader.Controls.Add(this.lblFromToSeparated1);
            this.pnlHeader.Controls.Add(this.lblTargetYMDDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1225, 66);
            this.pnlHeader.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(774, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 23);
            this.label1.TabIndex = 140;
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
            this.cmbDateType.Location = new System.Drawing.Point(147, 17);
            this.cmbDateType.Name = "cmbDateType";
            this.cmbDateType.RightControl = null;
            this.cmbDateType.Size = new System.Drawing.Size(122, 27);
            this.cmbDateType.TabIndex = 139;
            this.cmbDateType.UpControl = null;
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
            this.pnlTargetYMDDateTo.Location = new System.Drawing.Point(520, 17);
            this.pnlTargetYMDDateTo.Name = "pnlTargetYMDDateTo";
            this.pnlTargetYMDDateTo.Size = new System.Drawing.Size(210, 27);
            this.pnlTargetYMDDateTo.TabIndex = 137;
            // 
            // lblTargetYMDDateToDays
            // 
            this.lblTargetYMDDateToDays.BackColor = System.Drawing.Color.White;
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
            this.lblTargetYMDDateToMonth.BackColor = System.Drawing.Color.White;
            this.lblTargetYMDDateToMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDDateToMonth.Name = "lblTargetYMDDateToMonth";
            this.lblTargetYMDDateToMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateToMonth.TabIndex = 117;
            this.lblTargetYMDDateToMonth.Text = "月";
            this.lblTargetYMDDateToMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateToYears
            // 
            this.lblTargetYMDDateToYears.BackColor = System.Drawing.Color.White;
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
            this.pnlTargetYMDDateFrom.Location = new System.Drawing.Point(268, 17);
            this.pnlTargetYMDDateFrom.Name = "pnlTargetYMDDateFrom";
            this.pnlTargetYMDDateFrom.Size = new System.Drawing.Size(210, 27);
            this.pnlTargetYMDDateFrom.TabIndex = 136;
            // 
            // lblTargetYMDDateFromDays
            // 
            this.lblTargetYMDDateFromDays.BackColor = System.Drawing.Color.White;
            this.lblTargetYMDDateFromDays.Location = new System.Drawing.Point(148, 0);
            this.lblTargetYMDDateFromDays.Name = "lblTargetYMDDateFromDays";
            this.lblTargetYMDDateFromDays.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromDays.TabIndex = 119;
            this.lblTargetYMDDateFromDays.Text = "日";
            this.lblTargetYMDDateFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateFromMonth
            // 
            this.lblTargetYMDDateFromMonth.BackColor = System.Drawing.Color.White;
            this.lblTargetYMDDateFromMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetYMDDateFromMonth.Name = "lblTargetYMDDateFromMonth";
            this.lblTargetYMDDateFromMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetYMDDateFromMonth.TabIndex = 117;
            this.lblTargetYMDDateFromMonth.Text = "月";
            this.lblTargetYMDDateFromMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetYMDDateFromYears
            // 
            this.lblTargetYMDDateFromYears.BackColor = System.Drawing.Color.White;
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
            this.lblFromToSeparated1.Location = new System.Drawing.Point(485, 21);
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
            this.lblTargetYMDDate.Location = new System.Drawing.Point(17, 17);
            this.lblTargetYMDDate.Name = "lblTargetYMDDate";
            this.lblTargetYMDDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetYMDDate.TabIndex = 54;
            this.lblTargetYMDDate.Text = "対象年月日";
            this.lblTargetYMDDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdSearchList
            // 
            this.grdSearchList.AllowUserToAddRows = false;
            this.grdSearchList.AllowUserToDeleteRows = false;
            this.grdSearchList.AllowUserToResizeRows = false;
            this.grdSearchList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle81.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle81.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle81.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle81.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle81.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle81.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle81;
            this.grdSearchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmJuchuNo,
            this.clmJuchuDate,
            this.clmHachuNo,
            this.clmSubject,
            this.clmNouhinsyoNo,
            this.clmNouhinsyoDate,
            this.clmShireNo,
            this.clmShireDate});
            this.grdSearchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdSearchList.EnableHeadersVisualStyles = false;
            this.grdSearchList.Location = new System.Drawing.Point(3, 69);
            this.grdSearchList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSearchList.MultiSelect = false;
            this.grdSearchList.Name = "grdSearchList";
            this.grdSearchList.RowHeadersVisible = false;
            dataGridViewCellStyle90.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle90.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle90.SelectionForeColor = System.Drawing.Color.Black;
            this.grdSearchList.RowsDefaultCellStyle = dataGridViewCellStyle90;
            this.grdSearchList.RowTemplate.Height = 26;
            this.grdSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchList.Size = new System.Drawing.Size(1221, 614);
            this.grdSearchList.TabIndex = 24;
            this.grdSearchList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // clmJuchuNo
            // 
            this.clmJuchuNo.DataPropertyName = "JuchuNo";
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle82.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmJuchuNo.DefaultCellStyle = dataGridViewCellStyle82;
            this.clmJuchuNo.HeaderText = "受注No";
            this.clmJuchuNo.Name = "clmJuchuNo";
            this.clmJuchuNo.ReadOnly = true;
            this.clmJuchuNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmJuchuNo.Width = 170;
            // 
            // clmJuchuDate
            // 
            this.clmJuchuDate.DataPropertyName = "JuchuDate";
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle83.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle83.Format = "D";
            dataGridViewCellStyle83.NullValue = null;
            this.clmJuchuDate.DefaultCellStyle = dataGridViewCellStyle83;
            this.clmJuchuDate.HeaderText = "受注日付";
            this.clmJuchuDate.Name = "clmJuchuDate";
            this.clmJuchuDate.ReadOnly = true;
            this.clmJuchuDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmJuchuDate.Width = 160;
            // 
            // clmHachuNo
            // 
            this.clmHachuNo.DataPropertyName = "HachuNo";
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle84.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmHachuNo.DefaultCellStyle = dataGridViewCellStyle84;
            this.clmHachuNo.HeaderText = "発注No";
            this.clmHachuNo.Name = "clmHachuNo";
            this.clmHachuNo.ReadOnly = true;
            this.clmHachuNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmHachuNo.Width = 130;
            // 
            // clmSubject
            // 
            this.clmSubject.DataPropertyName = "HachuDate";
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle85.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle85.Format = "D";
            this.clmSubject.DefaultCellStyle = dataGridViewCellStyle85;
            this.clmSubject.HeaderText = "発注日付";
            this.clmSubject.Name = "clmSubject";
            this.clmSubject.ReadOnly = true;
            this.clmSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubject.Width = 160;
            // 
            // clmNouhinsyoNo
            // 
            this.clmNouhinsyoNo.DataPropertyName = "NouhinsyoNo";
            dataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle86.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmNouhinsyoNo.DefaultCellStyle = dataGridViewCellStyle86;
            this.clmNouhinsyoNo.HeaderText = "納品書No";
            this.clmNouhinsyoNo.Name = "clmNouhinsyoNo";
            this.clmNouhinsyoNo.ReadOnly = true;
            this.clmNouhinsyoNo.Width = 130;
            // 
            // clmNouhinsyoDate
            // 
            this.clmNouhinsyoDate.DataPropertyName = "NouhinsyoDate";
            dataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle87.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle87.Format = "D";
            this.clmNouhinsyoDate.DefaultCellStyle = dataGridViewCellStyle87;
            this.clmNouhinsyoDate.HeaderText = "納品書日付";
            this.clmNouhinsyoDate.Name = "clmNouhinsyoDate";
            this.clmNouhinsyoDate.ReadOnly = true;
            this.clmNouhinsyoDate.Width = 160;
            // 
            // clmShireNo
            // 
            this.clmShireNo.DataPropertyName = "ShireNo";
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle88.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clmShireNo.DefaultCellStyle = dataGridViewCellStyle88;
            this.clmShireNo.HeaderText = "仕入No";
            this.clmShireNo.Name = "clmShireNo";
            this.clmShireNo.ReadOnly = true;
            this.clmShireNo.Width = 130;
            // 
            // clmShireDate
            // 
            this.clmShireDate.DataPropertyName = "ShireDate";
            dataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle89.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle89.Format = "D";
            this.clmShireDate.DefaultCellStyle = dataGridViewCellStyle89;
            this.clmShireDate.HeaderText = "仕入日付";
            this.clmShireDate.Name = "clmShireDate";
            this.clmShireDate.ReadOnly = true;
            this.clmShireDate.Width = 160;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.Add(this.btnBack);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 692);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1229, 70);
            this.pnlBottom.TabIndex = 105;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(987, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 40);
            this.btnCancel.TabIndex = 333;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sfrmUriageIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1229, 762);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sfrmUriageIchiran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "売上関連データ一覧";
            this.Load += new System.EventHandler(this.sfrmHachuSearch_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlTargetYMDDateTo.ResumeLayout(false);
            this.pnlTargetYMDDateTo.PerformLayout();
            this.pnlTargetYMDDateFrom.ResumeLayout(false);
            this.pnlTargetYMDDateFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.FeaturesButton btnSearch;
        private Common.FeaturesButton btnBack;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView grdSearchList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJuchuNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJuchuDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHachuNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNouhinsyoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNouhinsyoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShireNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShireDate;
        private System.Windows.Forms.Panel pnlHeader;
        private Common.CustomComboBox cmbDateType;
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
        private Common.ItemHeadLabel lblTargetYMDDate;
        private System.Windows.Forms.Label label1;
        private Common.FeaturesButton btnCancel;
    }
}