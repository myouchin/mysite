namespace PrintInstructions
{
    partial class frmShouhinMIchiran
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoTopClassificationCode = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbTopClassificationCode = new Common.CustomComboBox();
            this.lblTopClassificationCode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new Common.FeaturesButton();
            this.btnPrint = new Common.FeaturesButton();
            this.btnClose = new Common.FeaturesButton();
            this.rptShohinIchiran1 = new YamazakiMatex.Print.Report.rptShohinIchiran();
            this.pnlHeader.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.panel4);
            this.pnlHeader.Controls.Add(this.cmbTopClassificationCode);
            this.pnlHeader.Controls.Add(this.lblTopClassificationCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(447, 174);
            this.pnlHeader.TabIndex = 103;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.rdoTopClassificationCode);
            this.panel4.Controls.Add(this.rdoAll);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(253, 73);
            this.panel4.TabIndex = 74;
            // 
            // rdoTopClassificationCode
            // 
            this.rdoTopClassificationCode.AutoSize = true;
            this.rdoTopClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoTopClassificationCode.Location = new System.Drawing.Point(96, 33);
            this.rdoTopClassificationCode.Name = "rdoTopClassificationCode";
            this.rdoTopClassificationCode.Size = new System.Drawing.Size(147, 23);
            this.rdoTopClassificationCode.TabIndex = 21;
            this.rdoTopClassificationCode.Text = "商品分類指定";
            this.rdoTopClassificationCode.UseVisualStyleBackColor = true;
            this.rdoTopClassificationCode.Click += new System.EventHandler(this.printModeRadio_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoAll.Location = new System.Drawing.Point(8, 34);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(67, 23);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "全件";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Click += new System.EventHandler(this.printModeRadio_Click);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(3, 2);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　出力対象";
            // 
            // cmbTopClassificationCode
            // 
            this.cmbTopClassificationCode.BeforeSelectedValue = "";
            this.cmbTopClassificationCode.DownControl = null;
            this.cmbTopClassificationCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopClassificationCode.EnterControl = null;
            this.cmbTopClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTopClassificationCode.FormattingEnabled = true;
            this.cmbTopClassificationCode.LabelControl = null;
            this.cmbTopClassificationCode.LeftControl = null;
            this.cmbTopClassificationCode.Location = new System.Drawing.Point(203, 113);
            this.cmbTopClassificationCode.Name = "cmbTopClassificationCode";
            this.cmbTopClassificationCode.RightControl = null;
            this.cmbTopClassificationCode.Size = new System.Drawing.Size(128, 27);
            this.cmbTopClassificationCode.TabIndex = 73;
            this.cmbTopClassificationCode.UpControl = null;
            // 
            // lblTopClassificationCode
            // 
            this.lblTopClassificationCode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTopClassificationCode.Location = new System.Drawing.Point(121, 115);
            this.lblTopClassificationCode.Name = "lblTopClassificationCode";
            this.lblTopClassificationCode.Size = new System.Drawing.Size(76, 25);
            this.lblTopClassificationCode.TabIndex = 72;
            this.lblTopClassificationCode.Text = "商品分類";
            this.lblTopClassificationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 174);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.MinimumSize = new System.Drawing.Size(4, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 70);
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
            this.btnClose.Location = new System.Drawing.Point(323, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 500;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShouhinMIchiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(447, 244);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmShouhinMIchiran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先一覧表出力";
            this.Load += new System.EventHandler(this.frmShouhinMIchiran_Load);
            this.pnlHeader.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private Common.CustomComboBox cmbTopClassificationCode;
        private System.Windows.Forms.Label lblTopClassificationCode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoTopClassificationCode;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.Label label27;
        private YamazakiMatex.Print.Report.rptShohinIchiran rptShohinIchiran1;
    }
}