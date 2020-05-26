namespace UriageHibetuSoukatu
{
    partial class frmUriageHibetuSoukatu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTargetDate = new System.Windows.Forms.Panel();
            this.lblTargetDateMonth = new System.Windows.Forms.Label();
            this.txtTargetDateMonth = new Common.CustomTextBox();
            this.txtTargetDateYears = new Common.CustomTextBox();
            this.lblTargetDateYears = new System.Windows.Forms.Label();
            this.dtpTargetDate = new Common.CustomDateTimePicker();
            this.lblTargetDate = new Common.ItemHeadLabel();
            this.grdDayList1 = new Common.CustomDataGridView();
            this.clmDay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUriage1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRuikei1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody1 = new System.Windows.Forms.Panel();
            this.lblShireUriage2 = new System.Windows.Forms.Label();
            this.lblKoujiUriage2 = new System.Windows.Forms.Label();
            this.lblShireUriage = new Common.ItemHeadLabel();
            this.lblKoujiUriage = new Common.ItemHeadLabel();
            this.grdDayList2 = new Common.CustomDataGridView();
            this.clmGoukei2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUriage2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRuikei2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDisp = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlTargetDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayList1)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayList2)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlTargetDate);
            this.pnlHeader.Controls.Add(this.lblTargetDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(827, 40);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlTargetDate
            // 
            this.pnlTargetDate.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTargetDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetDate.Controls.Add(this.lblTargetDateMonth);
            this.pnlTargetDate.Controls.Add(this.txtTargetDateMonth);
            this.pnlTargetDate.Controls.Add(this.lblTargetDateYears);
            this.pnlTargetDate.Controls.Add(this.txtTargetDateYears);
            this.pnlTargetDate.Controls.Add(this.dtpTargetDate);
            this.pnlTargetDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTargetDate.Location = new System.Drawing.Point(134, 6);
            this.pnlTargetDate.Name = "pnlTargetDate";
            this.pnlTargetDate.Size = new System.Drawing.Size(157, 27);
            this.pnlTargetDate.TabIndex = 10;
            // 
            // lblTargetDateMonth
            // 
            this.lblTargetDateMonth.Location = new System.Drawing.Point(93, 0);
            this.lblTargetDateMonth.Name = "lblTargetDateMonth";
            this.lblTargetDateMonth.Size = new System.Drawing.Size(28, 27);
            this.lblTargetDateMonth.TabIndex = 117;
            this.lblTargetDateMonth.Text = "月";
            this.lblTargetDateMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetDateMonth
            // 
            this.txtTargetDateMonth.BeforeValue = "";
            this.txtTargetDateMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetDateMonth.DownControl = null;
            this.txtTargetDateMonth.EnterControl = null;
            this.txtTargetDateMonth.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetDateMonth.LabelControl = null;
            this.txtTargetDateMonth.LeftControl = this.txtTargetDateYears;
            this.txtTargetDateMonth.Location = new System.Drawing.Point(66, 3);
            this.txtTargetDateMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetDateMonth.Name = "txtTargetDateMonth";
            this.txtTargetDateMonth.RightControl = null;
            this.txtTargetDateMonth.Size = new System.Drawing.Size(30, 20);
            this.txtTargetDateMonth.TabIndex = 30;
            this.txtTargetDateMonth.Text = "12";
            this.txtTargetDateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetDateMonth.UpControl = null;
            // 
            // txtTargetDateYears
            // 
            this.txtTargetDateYears.BeforeValue = "";
            this.txtTargetDateYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetDateYears.DownControl = null;
            this.txtTargetDateYears.EnterControl = this.txtTargetDateMonth;
            this.txtTargetDateYears.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtTargetDateYears.LabelControl = null;
            this.txtTargetDateYears.LeftControl = null;
            this.txtTargetDateYears.Location = new System.Drawing.Point(0, 3);
            this.txtTargetDateYears.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetDateYears.Name = "txtTargetDateYears";
            this.txtTargetDateYears.RightControl = this.txtTargetDateMonth;
            this.txtTargetDateYears.Size = new System.Drawing.Size(45, 20);
            this.txtTargetDateYears.TabIndex = 20;
            this.txtTargetDateYears.Text = "1234";
            this.txtTargetDateYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetDateYears.UpControl = null;
            // 
            // lblTargetDateYears
            // 
            this.lblTargetDateYears.Location = new System.Drawing.Point(44, 0);
            this.lblTargetDateYears.Name = "lblTargetDateYears";
            this.lblTargetDateYears.Size = new System.Drawing.Size(28, 27);
            this.lblTargetDateYears.TabIndex = 115;
            this.lblTargetDateYears.Text = "年";
            this.lblTargetDateYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTargetDate
            // 
            this.dtpTargetDate.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetDate.CustomFormat = " ";
            this.dtpTargetDate.DaysLinkTextControl = null;
            this.dtpTargetDate.DownControl = null;
            this.dtpTargetDate.EnterControl = null;
            this.dtpTargetDate.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.dtpTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTargetDate.LeftControl = null;
            this.dtpTargetDate.Location = new System.Drawing.Point(-1, -1);
            this.dtpTargetDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTargetDate.MonthLinkTextControl = this.txtTargetDateMonth;
            this.dtpTargetDate.Name = "dtpTargetDate";
            this.dtpTargetDate.RightControl = null;
            this.dtpTargetDate.Size = new System.Drawing.Size(157, 27);
            this.dtpTargetDate.TabIndex = 40;
            this.dtpTargetDate.UpControl = null;
            this.dtpTargetDate.Value = new System.DateTime(2019, 12, 31, 17, 37, 0, 0);
            this.dtpTargetDate.Value2 = null;
            this.dtpTargetDate.YearsLinkTextControl = this.txtTargetDateYears;
            // 
            // lblTargetDate
            // 
            this.lblTargetDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTargetDate.ForeColor = System.Drawing.Color.White;
            this.lblTargetDate.Location = new System.Drawing.Point(4, 6);
            this.lblTargetDate.Name = "lblTargetDate";
            this.lblTargetDate.Size = new System.Drawing.Size(130, 27);
            this.lblTargetDate.TabIndex = 139;
            this.lblTargetDate.Text = "年月";
            this.lblTargetDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdDayList1
            // 
            this.grdDayList1.AllowUserToAddRows = false;
            this.grdDayList1.AllowUserToDeleteRows = false;
            this.grdDayList1.AllowUserToResizeRows = false;
            this.grdDayList1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDayList1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDayList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDayList1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDay1,
            this.clmUriage1,
            this.clmRuikei1});
            this.grdDayList1.DownControl = null;
            this.grdDayList1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdDayList1.EnableHeadersVisualStyles = false;
            this.grdDayList1.EnterControl = null;
            this.grdDayList1.FlgSetCurrentCell = true;
            this.grdDayList1.LeftControl = null;
            this.grdDayList1.Location = new System.Drawing.Point(4, 4);
            this.grdDayList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdDayList1.MultiSelect = false;
            this.grdDayList1.Name = "grdDayList1";
            this.grdDayList1.RightControl = null;
            this.grdDayList1.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdDayList1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdDayList1.RowSegmentCount = 2;
            this.grdDayList1.RowTemplate.Height = 26;
            this.grdDayList1.ScrollRowCount = 3;
            this.grdDayList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDayList1.Size = new System.Drawing.Size(283, 443);
            this.grdDayList1.TabIndex = 24;
            this.grdDayList1.UpControl = null;
            // 
            // clmDay1
            // 
            this.clmDay1.DataPropertyName = "day";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.clmDay1.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmDay1.HeaderText = "日";
            this.clmDay1.Name = "clmDay1";
            this.clmDay1.ReadOnly = true;
            this.clmDay1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDay1.Width = 80;
            // 
            // clmUriage1
            // 
            this.clmUriage1.DataPropertyName = "uriage";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.clmUriage1.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmUriage1.HeaderText = "売上";
            this.clmUriage1.Name = "clmUriage1";
            this.clmUriage1.ReadOnly = true;
            this.clmUriage1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmRuikei1
            // 
            this.clmRuikei1.DataPropertyName = "ruikei";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.clmRuikei1.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmRuikei1.HeaderText = "累計";
            this.clmRuikei1.Name = "clmRuikei1";
            this.clmRuikei1.ReadOnly = true;
            this.clmRuikei1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlBody1
            // 
            this.pnlBody1.AutoSize = true;
            this.pnlBody1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody1.Controls.Add(this.lblShireUriage2);
            this.pnlBody1.Controls.Add(this.lblKoujiUriage2);
            this.pnlBody1.Controls.Add(this.lblShireUriage);
            this.pnlBody1.Controls.Add(this.lblKoujiUriage);
            this.pnlBody1.Controls.Add(this.grdDayList2);
            this.pnlBody1.Controls.Add(this.grdDayList1);
            this.pnlBody1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.pnlBody1.Location = new System.Drawing.Point(0, 40);
            this.pnlBody1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody1.Name = "pnlBody1";
            this.pnlBody1.Size = new System.Drawing.Size(827, 456);
            this.pnlBody1.TabIndex = 50;
            // 
            // lblShireUriage2
            // 
            this.lblShireUriage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShireUriage2.Location = new System.Drawing.Point(655, 84);
            this.lblShireUriage2.Name = "lblShireUriage2";
            this.lblShireUriage2.Size = new System.Drawing.Size(165, 27);
            this.lblShireUriage2.TabIndex = 217;
            this.lblShireUriage2.Text = "label2";
            this.lblShireUriage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKoujiUriage2
            // 
            this.lblKoujiUriage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKoujiUriage2.Location = new System.Drawing.Point(655, 28);
            this.lblKoujiUriage2.Name = "lblKoujiUriage2";
            this.lblKoujiUriage2.Size = new System.Drawing.Size(165, 27);
            this.lblKoujiUriage2.TabIndex = 216;
            this.lblKoujiUriage2.Text = "label1";
            this.lblKoujiUriage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblShireUriage
            // 
            this.lblShireUriage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblShireUriage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShireUriage.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShireUriage.ForeColor = System.Drawing.Color.White;
            this.lblShireUriage.Location = new System.Drawing.Point(655, 60);
            this.lblShireUriage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShireUriage.Name = "lblShireUriage";
            this.lblShireUriage.Size = new System.Drawing.Size(166, 24);
            this.lblShireUriage.TabIndex = 214;
            this.lblShireUriage.Text = "仕入売上";
            this.lblShireUriage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKoujiUriage
            // 
            this.lblKoujiUriage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblKoujiUriage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKoujiUriage.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKoujiUriage.ForeColor = System.Drawing.Color.White;
            this.lblKoujiUriage.Location = new System.Drawing.Point(655, 4);
            this.lblKoujiUriage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKoujiUriage.Name = "lblKoujiUriage";
            this.lblKoujiUriage.Size = new System.Drawing.Size(166, 24);
            this.lblKoujiUriage.TabIndex = 212;
            this.lblKoujiUriage.Text = "工事売上";
            this.lblKoujiUriage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdDayList2
            // 
            this.grdDayList2.AllowUserToAddRows = false;
            this.grdDayList2.AllowUserToDeleteRows = false;
            this.grdDayList2.AllowUserToResizeRows = false;
            this.grdDayList2.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDayList2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdDayList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDayList2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmGoukei2,
            this.clmUriage2,
            this.clmRuikei2});
            this.grdDayList2.DownControl = null;
            this.grdDayList2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdDayList2.EnableHeadersVisualStyles = false;
            this.grdDayList2.EnterControl = null;
            this.grdDayList2.FlgSetCurrentCell = true;
            this.grdDayList2.LeftControl = null;
            this.grdDayList2.Location = new System.Drawing.Point(321, 4);
            this.grdDayList2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdDayList2.MultiSelect = false;
            this.grdDayList2.Name = "grdDayList2";
            this.grdDayList2.RightControl = null;
            this.grdDayList2.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.grdDayList2.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grdDayList2.RowSegmentCount = 2;
            this.grdDayList2.RowTemplate.Height = 26;
            this.grdDayList2.ScrollRowCount = 3;
            this.grdDayList2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDayList2.Size = new System.Drawing.Size(283, 443);
            this.grdDayList2.TabIndex = 25;
            this.grdDayList2.UpControl = null;
            // 
            // clmGoukei2
            // 
            this.clmGoukei2.DataPropertyName = "day";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.clmGoukei2.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmGoukei2.HeaderText = "日";
            this.clmGoukei2.Name = "clmGoukei2";
            this.clmGoukei2.ReadOnly = true;
            this.clmGoukei2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmGoukei2.Width = 80;
            // 
            // clmUriage2
            // 
            this.clmUriage2.DataPropertyName = "uriage";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.clmUriage2.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmUriage2.HeaderText = "売上";
            this.clmUriage2.Name = "clmUriage2";
            this.clmUriage2.ReadOnly = true;
            this.clmUriage2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmRuikei2
            // 
            this.clmRuikei2.DataPropertyName = "ruikei";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.clmRuikei2.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmRuikei2.HeaderText = "累計";
            this.clmRuikei2.Name = "clmRuikei2";
            this.clmRuikei2.ReadOnly = true;
            this.clmRuikei2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnDisp);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 496);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(827, 70);
            this.pnlBottom.TabIndex = 60;
            // 
            // btnDisp
            // 
            this.btnDisp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDisp.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDisp.Location = new System.Drawing.Point(4, 15);
            this.btnDisp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisp.Name = "btnDisp";
            this.btnDisp.Size = new System.Drawing.Size(139, 40);
            this.btnDisp.TabIndex = 70;
            this.btnDisp.Text = "F1：一覧表示";
            this.btnDisp.UseVisualStyleBackColor = false;
            this.btnDisp.Click += new System.EventHandler(this.btnDisp_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(705, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUriageHibetuSoukatu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(827, 566);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUriageHibetuSoukatu";
            this.ShowIcon = false;
            this.Text = "売上日別総括表";
            this.Load += new System.EventHandler(this.frmUriageHibetuSoukatu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTargetDate.ResumeLayout(false);
            this.pnlTargetDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayList1)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDayList2)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody1;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.CustomDataGridView grdDayList1;
        private Common.FeaturesButton btnClose;
        private Common.FeaturesButton btnDisp;
        private System.Windows.Forms.Panel pnlTargetDate;
        private System.Windows.Forms.Label lblTargetDateMonth;
        private Common.CustomTextBox txtTargetDateMonth;
        private Common.CustomTextBox txtTargetDateYears;
        private System.Windows.Forms.Label lblTargetDateYears;
        private Common.CustomDateTimePicker dtpTargetDate;
        private Common.ItemHeadLabel lblTargetDate;
        private Common.CustomDataGridView grdDayList2;
        private Common.ItemHeadLabel lblShireUriage;
        private Common.ItemHeadLabel lblKoujiUriage;
        private System.Windows.Forms.Label lblShireUriage2;
        private System.Windows.Forms.Label lblKoujiUriage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUriage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRuikei1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGoukei2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUriage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRuikei2;
    }
}