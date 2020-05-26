namespace PrintInstructions
{
    partial class frmBupinHachusyo
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
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOutputUnit = new Common.ItemHeadLabel();
            this.lblVenbor = new Common.ItemHeadLabel();
            this.cmbVenbor = new Common.CustomComboBox();
            this.rdoSelectVendor = new System.Windows.Forms.RadioButton();
            this.rdoAllMeisai = new System.Windows.Forms.RadioButton();
            this.rdoHachu = new System.Windows.Forms.RadioButton();
            this.rdoBuppin = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptBuppinKounyusho1 = new YamazakiMatex.Print.Report.rptBuppinKounyusho();
            this.rptHachusho1 = new YamazakiMatex.Print.Report.rptHachusho();
            this.rptHachushoAllMeisai1 = new YamazakiMatex.Print.Report.rptHachushoAllMeisai();
            this.pnlHeader.SuspendLayout();
            this.pnlProcessingMode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlProcessingMode);
            this.pnlHeader.Controls.Add(this.rdoHachu);
            this.pnlHeader.Controls.Add(this.rdoBuppin);
            this.pnlHeader.Controls.Add(this.rdoAll);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(645, 193);
            this.pnlHeader.TabIndex = 103;
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.label1);
            this.pnlProcessingMode.Controls.Add(this.lblOutputUnit);
            this.pnlProcessingMode.Controls.Add(this.lblVenbor);
            this.pnlProcessingMode.Controls.Add(this.cmbVenbor);
            this.pnlProcessingMode.Controls.Add(this.rdoSelectVendor);
            this.pnlProcessingMode.Controls.Add(this.rdoAllMeisai);
            this.pnlProcessingMode.Location = new System.Drawing.Point(49, 62);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(561, 107);
            this.pnlProcessingMode.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 124;
            this.label1.Text = "発注書詳細設定";
            // 
            // lblOutputUnit
            // 
            this.lblOutputUnit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOutputUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOutputUnit.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOutputUnit.ForeColor = System.Drawing.Color.White;
            this.lblOutputUnit.Location = new System.Drawing.Point(16, 36);
            this.lblOutputUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputUnit.Name = "lblOutputUnit";
            this.lblOutputUnit.Size = new System.Drawing.Size(133, 27);
            this.lblOutputUnit.TabIndex = 123;
            this.lblOutputUnit.Text = "出力単位";
            this.lblOutputUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVenbor
            // 
            this.lblVenbor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblVenbor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVenbor.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVenbor.ForeColor = System.Drawing.Color.White;
            this.lblVenbor.Location = new System.Drawing.Point(16, 63);
            this.lblVenbor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVenbor.Name = "lblVenbor";
            this.lblVenbor.Size = new System.Drawing.Size(133, 27);
            this.lblVenbor.TabIndex = 121;
            this.lblVenbor.Text = "仕入先";
            this.lblVenbor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbVenbor
            // 
            this.cmbVenbor.BeforeSelectedValue = "";
            this.cmbVenbor.DownControl = null;
            this.cmbVenbor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenbor.EnterControl = null;
            this.cmbVenbor.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.cmbVenbor.FormattingEnabled = true;
            this.cmbVenbor.LabelControl = null;
            this.cmbVenbor.LeftControl = null;
            this.cmbVenbor.Location = new System.Drawing.Point(149, 63);
            this.cmbVenbor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVenbor.Name = "cmbVenbor";
            this.cmbVenbor.RightControl = null;
            this.cmbVenbor.Size = new System.Drawing.Size(395, 27);
            this.cmbVenbor.TabIndex = 122;
            this.cmbVenbor.UpControl = null;
            // 
            // rdoSelectVendor
            // 
            this.rdoSelectVendor.AutoSize = true;
            this.rdoSelectVendor.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoSelectVendor.Location = new System.Drawing.Point(374, 37);
            this.rdoSelectVendor.Name = "rdoSelectVendor";
            this.rdoSelectVendor.Size = new System.Drawing.Size(170, 24);
            this.rdoSelectVendor.TabIndex = 20;
            this.rdoSelectVendor.Text = "仕入先毎に出力";
            this.rdoSelectVendor.UseVisualStyleBackColor = true;
            this.rdoSelectVendor.Click += new System.EventHandler(this.rdoOutputUnit_Click);
            // 
            // rdoAllMeisai
            // 
            this.rdoAllMeisai.AutoSize = true;
            this.rdoAllMeisai.Checked = true;
            this.rdoAllMeisai.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoAllMeisai.Location = new System.Drawing.Point(156, 37);
            this.rdoAllMeisai.Name = "rdoAllMeisai";
            this.rdoAllMeisai.Size = new System.Drawing.Size(212, 24);
            this.rdoAllMeisai.TabIndex = 30;
            this.rdoAllMeisai.TabStop = true;
            this.rdoAllMeisai.Text = "全明細をまとめて出力";
            this.rdoAllMeisai.UseVisualStyleBackColor = true;
            this.rdoAllMeisai.Click += new System.EventHandler(this.rdoOutputUnit_Click);
            // 
            // rdoHachu
            // 
            this.rdoHachu.AutoSize = true;
            this.rdoHachu.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.rdoHachu.Location = new System.Drawing.Point(355, 23);
            this.rdoHachu.Name = "rdoHachu";
            this.rdoHachu.Size = new System.Drawing.Size(90, 24);
            this.rdoHachu.TabIndex = 2;
            this.rdoHachu.TabStop = true;
            this.rdoHachu.Text = "発注書";
            this.rdoHachu.UseVisualStyleBackColor = true;
            this.rdoHachu.Click += new System.EventHandler(this.rdoPrintTarget_Click);
            // 
            // rdoBuppin
            // 
            this.rdoBuppin.AutoSize = true;
            this.rdoBuppin.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.rdoBuppin.Location = new System.Drawing.Point(171, 23);
            this.rdoBuppin.Name = "rdoBuppin";
            this.rdoBuppin.Size = new System.Drawing.Size(132, 24);
            this.rdoBuppin.TabIndex = 1;
            this.rdoBuppin.TabStop = true;
            this.rdoBuppin.Text = "物品購入書";
            this.rdoBuppin.UseVisualStyleBackColor = true;
            this.rdoBuppin.Click += new System.EventHandler(this.rdoPrintTarget_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.rdoAll.Location = new System.Drawing.Point(49, 23);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(69, 24);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "両方";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Click += new System.EventHandler(this.rdoPrintTarget_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 193);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 70);
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
            this.btnClose.Location = new System.Drawing.Point(494, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBupinHachusyo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(645, 263);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBupinHachusyo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物品購入書・発注書出力";
            this.Load += new System.EventHandler(this.frmJyuchachuIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
        private Common.FeaturesButton btnPreview;
        private Common.FeaturesButton btnPrint;
        private Common.FeaturesButton btnClose;
        private System.Windows.Forms.RadioButton rdoHachu;
        private System.Windows.Forms.RadioButton rdoBuppin;
        private System.Windows.Forms.RadioButton rdoAll;
        private YamazakiMatex.Print.Report.rptBuppinKounyusho rptBuppinKounyusho1;
        private YamazakiMatex.Print.Report.rptHachusho rptHachusho1;
        private System.Windows.Forms.Panel pnlProcessingMode;
        private System.Windows.Forms.RadioButton rdoSelectVendor;
        private System.Windows.Forms.RadioButton rdoAllMeisai;
        private Common.ItemHeadLabel lblOutputUnit;
        private Common.ItemHeadLabel lblVenbor;
        private Common.CustomComboBox cmbVenbor;
        private System.Windows.Forms.Label label1;
        private YamazakiMatex.Print.Report.rptHachushoAllMeisai rptHachushoAllMeisai1;
    }
}