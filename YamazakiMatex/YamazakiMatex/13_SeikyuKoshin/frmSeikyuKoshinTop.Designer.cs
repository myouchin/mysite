namespace SeikyuKoshin
{
    partial class frmSeikyuKoshinTop
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
            this.btnClosingMonthChange = new Common.FeaturesButton();
            this.btnClosingDateUpDate = new Common.FeaturesButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new Common.FeaturesButton();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.btnClosingMonthChange);
            this.pnlHeader.Controls.Add(this.btnClosingDateUpDate);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(432, 165);
            this.pnlHeader.TabIndex = 104;
            // 
            // btnClosingMonthChange
            // 
            this.btnClosingMonthChange.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClosingMonthChange.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClosingMonthChange.Location = new System.Drawing.Point(117, 107);
            this.btnClosingMonthChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClosingMonthChange.Name = "btnClosingMonthChange";
            this.btnClosingMonthChange.Size = new System.Drawing.Size(194, 40);
            this.btnClosingMonthChange.TabIndex = 57;
            this.btnClosingMonthChange.Text = "２．請求月変更";
            this.btnClosingMonthChange.UseVisualStyleBackColor = false;
            this.btnClosingMonthChange.Click += new System.EventHandler(this.btnClosingMonthChange_Click);
            // 
            // btnClosingDateUpDate
            // 
            this.btnClosingDateUpDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClosingDateUpDate.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClosingDateUpDate.Location = new System.Drawing.Point(117, 57);
            this.btnClosingDateUpDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClosingDateUpDate.Name = "btnClosingDateUpDate";
            this.btnClosingDateUpDate.Size = new System.Drawing.Size(194, 40);
            this.btnClosingDateUpDate.TabIndex = 56;
            this.btnClosingDateUpDate.Text = "１．締日更新";
            this.btnClosingDateUpDate.UseVisualStyleBackColor = false;
            this.btnClosingDateUpDate.Click += new System.EventHandler(this.btnClosingDateUpDate_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 40);
            this.label1.TabIndex = 52;
            this.label1.Text = "請求更新";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 165);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(4, 70);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(432, 70);
            this.pnlBottom.TabIndex = 107;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(308, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "F12：閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SeikyuKoshinTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 235);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "SeikyuKoshinTop";
            this.Text = "請求更新";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private Common.FeaturesButton btnClosingMonthChange;
        private Common.FeaturesButton btnClosingDateUpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBottom;
        private Common.FeaturesButton btnClose;
    }
}