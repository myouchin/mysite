using System;

namespace Juchu
{
    partial class frmBikouInput
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
            this.pnlProcessingMode = new System.Windows.Forms.Panel();
            this.btnCheck = new Common.FeaturesButton();
            this.txtRemarks = new Common.CustomTextBox();
            this.lblRemarks = new Common.ItemHeadLabel();
            this.btmBack = new Common.FeaturesButton();
            this.pnlProcessingMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.btmBack);
            this.pnlProcessingMode.Controls.Add(this.txtRemarks);
            this.pnlProcessingMode.Controls.Add(this.lblRemarks);
            this.pnlProcessingMode.Controls.Add(this.btnCheck);
            this.pnlProcessingMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProcessingMode.Location = new System.Drawing.Point(0, 0);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(625, 128);
            this.pnlProcessingMode.TabIndex = 109;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(406, 74);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 30;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BeforeValue = "";
            this.txtRemarks.DownControl = null;
            this.txtRemarks.EnterControl = null;
            this.txtRemarks.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.txtRemarks.LabelControl = null;
            this.txtRemarks.LeftControl = null;
            this.txtRemarks.Location = new System.Drawing.Point(4, 37);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemarks.MaxLength = 30;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightControl = null;
            this.txtRemarks.Size = new System.Drawing.Size(614, 27);
            this.txtRemarks.TabIndex = 103;
            this.txtRemarks.Text = "令令令令令令令令令令令令令令令令令令令令令令令令令令令令令令";
            this.txtRemarks.UpControl = null;
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRemarks.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRemarks.ForeColor = System.Drawing.Color.White;
            this.lblRemarks.Location = new System.Drawing.Point(4, 13);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(614, 24);
            this.lblRemarks.TabIndex = 102;
            this.lblRemarks.Text = "備考";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btmBack
            // 
            this.btmBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btmBack.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btmBack.Location = new System.Drawing.Point(516, 74);
            this.btmBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btmBack.Name = "btmBack";
            this.btmBack.Size = new System.Drawing.Size(102, 40);
            this.btmBack.TabIndex = 104;
            this.btmBack.Text = "戻る";
            this.btmBack.UseVisualStyleBackColor = false;
            this.btmBack.Click += new System.EventHandler(this.btmBack_Click);
            // 
            // frmBikouInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(625, 128);
            this.Controls.Add(this.pnlProcessingMode);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBikouInput";
            this.ShowIcon = false;
            this.Text = "備考入力";
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProcessingMode;
        private Common.FeaturesButton btnCheck;
        private Common.CustomTextBox txtRemarks;
        private Common.ItemHeadLabel lblRemarks;
        private Common.FeaturesButton btmBack;
    }
}