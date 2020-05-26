namespace Master
{
    partial class frmKaisyaM
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
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRenrakusaki2 = new System.Windows.Forms.TextBox();
            this.txtRenrakusaki1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYubinNo = new System.Windows.Forms.TextBox();
            this.lblKaisya = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKaisya = new System.Windows.Forms.TextBox();
            this.txtJyusho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGaiyou = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.rdoCorrection);
            this.panel4.Controls.Add(this.rdoNew);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(78, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 73);
            this.panel4.TabIndex = 8;
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Enabled = false;
            this.rdoCorrection.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoCorrection.Location = new System.Drawing.Point(96, 37);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(67, 23);
            this.rdoCorrection.TabIndex = 2;
            this.rdoCorrection.TabStop = true;
            this.rdoCorrection.Text = "訂正";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            // 
            // rdoNew
            // 
            this.rdoNew.AutoSize = true;
            this.rdoNew.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoNew.Location = new System.Drawing.Point(8, 38);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(67, 23);
            this.rdoNew.TabIndex = 1;
            this.rdoNew.TabStop = true;
            this.rdoNew.Text = "登録";
            this.rdoNew.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(6, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 19);
            this.label27.TabIndex = 0;
            this.label27.Text = "　処理モード　";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.5941F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.4059F));
            this.tableLayoutPanel1.Controls.Add(this.txtRenrakusaki2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtRenrakusaki1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtYubinNo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKaisya, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtKaisya, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtJyusho, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtGaiyou, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(78, 105);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.56097F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.43903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 340);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // txtRenrakusaki2
            // 
            this.txtRenrakusaki2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRenrakusaki2.Font = new System.Drawing.Font("ＭＳ 明朝", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRenrakusaki2.Location = new System.Drawing.Point(194, 188);
            this.txtRenrakusaki2.Name = "txtRenrakusaki2";
            this.txtRenrakusaki2.Size = new System.Drawing.Size(168, 26);
            this.txtRenrakusaki2.TabIndex = 10;
            this.txtRenrakusaki2.Text = "022-999-9999";
            // 
            // txtRenrakusaki1
            // 
            this.txtRenrakusaki1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRenrakusaki1.Font = new System.Drawing.Font("ＭＳ 明朝", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRenrakusaki1.Location = new System.Drawing.Point(194, 140);
            this.txtRenrakusaki1.Name = "txtRenrakusaki1";
            this.txtRenrakusaki1.Size = new System.Drawing.Size(168, 26);
            this.txtRenrakusaki1.TabIndex = 9;
            this.txtRenrakusaki1.Text = "022-999-9999";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("ＭＳ 明朝", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(5, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "連絡先１";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYubinNo
            // 
            this.txtYubinNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtYubinNo.Font = new System.Drawing.Font("ＭＳ 明朝", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYubinNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtYubinNo.Location = new System.Drawing.Point(194, 52);
            this.txtYubinNo.Name = "txtYubinNo";
            this.txtYubinNo.Size = new System.Drawing.Size(94, 26);
            this.txtYubinNo.TabIndex = 3;
            this.txtYubinNo.Text = "9999999";
            // 
            // lblKaisya
            // 
            this.lblKaisya.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKaisya.Font = new System.Drawing.Font("ＭＳ 明朝", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKaisya.Location = new System.Drawing.Point(4, 4);
            this.lblKaisya.Name = "lblKaisya";
            this.lblKaisya.Size = new System.Drawing.Size(183, 34);
            this.lblKaisya.TabIndex = 0;
            this.lblKaisya.Text = "会 社 名";
            this.lblKaisya.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("ＭＳ 明朝", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "郵便番号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKaisya
            // 
            this.txtKaisya.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtKaisya.Font = new System.Drawing.Font("ＭＳ 明朝", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKaisya.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKaisya.Location = new System.Drawing.Point(194, 8);
            this.txtKaisya.MaxLength = 15;
            this.txtKaisya.Name = "txtKaisya";
            this.txtKaisya.Size = new System.Drawing.Size(356, 26);
            this.txtKaisya.TabIndex = 2;
            this.txtKaisya.Text = "株式会社ヤマザキマテックス";
            // 
            // txtJyusho
            // 
            this.txtJyusho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtJyusho.Font = new System.Drawing.Font("ＭＳ 明朝", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtJyusho.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtJyusho.Location = new System.Drawing.Point(194, 97);
            this.txtJyusho.Name = "txtJyusho";
            this.txtJyusho.Size = new System.Drawing.Size(651, 26);
            this.txtJyusho.TabIndex = 4;
            this.txtJyusho.Text = "株式会社ヤマザキマテックス";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("ＭＳ 明朝", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(5, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "住　　所";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("ＭＳ 明朝", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(5, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "連絡先２";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("ＭＳ 明朝", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(5, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 29);
            this.label7.TabIndex = 8;
            this.label7.Text = "概　　要";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGaiyou
            // 
            this.txtGaiyou.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGaiyou.Font = new System.Drawing.Font("ＭＳ 明朝", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtGaiyou.Location = new System.Drawing.Point(194, 234);
            this.txtGaiyou.Multiline = true;
            this.txtGaiyou.Name = "txtGaiyou";
            this.txtGaiyou.Size = new System.Drawing.Size(725, 99);
            this.txtGaiyou.TabIndex = 11;
            this.txtGaiyou.Text = "ＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫＫ";
            this.txtGaiyou.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("ＭＳ 明朝", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(523, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 42);
            this.label3.TabIndex = 10;
            this.label3.Text = "会社マスタ";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Location = new System.Drawing.Point(78, 452);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1028, 72);
            this.panel5.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(609, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 47);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "F10：保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(740, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 47);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "F11：取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(870, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 47);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "F16：終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmKaisyaM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 557);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.KeyPreview = true;
            this.Name = "frmKaisyaM";
            this.Text = "会社マスタ";
            this.Load += new System.EventHandler(this.frmKaisyaM_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoNew;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKaisya;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKaisya;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYubinNo;
        private System.Windows.Forms.TextBox txtRenrakusaki2;
        private System.Windows.Forms.TextBox txtRenrakusaki1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJyusho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGaiyou;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
    }
}