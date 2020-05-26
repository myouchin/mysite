using System;

namespace NouhinSyo
{
    partial class frmSearchDiplaySelect
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
            this.lblProcessingMode = new Common.ItemHeadLabel();
            this.rdoSearchDiplay2 = new System.Windows.Forms.RadioButton();
            this.rdoSearchDiplay1 = new System.Windows.Forms.RadioButton();
            this.pnlProcessingMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProcessingMode
            // 
            this.pnlProcessingMode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcessingMode.Controls.Add(this.btnCheck);
            this.pnlProcessingMode.Controls.Add(this.lblProcessingMode);
            this.pnlProcessingMode.Controls.Add(this.rdoSearchDiplay2);
            this.pnlProcessingMode.Controls.Add(this.rdoSearchDiplay1);
            this.pnlProcessingMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProcessingMode.Location = new System.Drawing.Point(0, 0);
            this.pnlProcessingMode.Name = "pnlProcessingMode";
            this.pnlProcessingMode.Size = new System.Drawing.Size(327, 156);
            this.pnlProcessingMode.TabIndex = 109;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(210, 105);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 40);
            this.btnCheck.TabIndex = 30;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblProcessingMode
            // 
            this.lblProcessingMode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblProcessingMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessingMode.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProcessingMode.ForeColor = System.Drawing.Color.White;
            this.lblProcessingMode.Location = new System.Drawing.Point(5, 2);
            this.lblProcessingMode.Name = "lblProcessingMode";
            this.lblProcessingMode.Size = new System.Drawing.Size(317, 27);
            this.lblProcessingMode.TabIndex = 4;
            this.lblProcessingMode.Text = "どちらの検索画面を起動しますか？";
            this.lblProcessingMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoSearchDiplay2
            // 
            this.rdoSearchDiplay2.AutoSize = true;
            this.rdoSearchDiplay2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoSearchDiplay2.Location = new System.Drawing.Point(185, 58);
            this.rdoSearchDiplay2.Name = "rdoSearchDiplay2";
            this.rdoSearchDiplay2.Size = new System.Drawing.Size(122, 24);
            this.rdoSearchDiplay2.TabIndex = 1;
            this.rdoSearchDiplay2.Text = "検索画面2";
            this.rdoSearchDiplay2.UseVisualStyleBackColor = true;
            // 
            // rdoSearchDiplay1
            // 
            this.rdoSearchDiplay1.AutoSize = true;
            this.rdoSearchDiplay1.Checked = true;
            this.rdoSearchDiplay1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoSearchDiplay1.Location = new System.Drawing.Point(22, 58);
            this.rdoSearchDiplay1.Name = "rdoSearchDiplay1";
            this.rdoSearchDiplay1.Size = new System.Drawing.Size(122, 24);
            this.rdoSearchDiplay1.TabIndex = 0;
            this.rdoSearchDiplay1.TabStop = true;
            this.rdoSearchDiplay1.Text = "検索画面1";
            this.rdoSearchDiplay1.UseVisualStyleBackColor = true;
            // 
            // frmSearchDiplaySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(327, 156);
            this.Controls.Add(this.pnlProcessingMode);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSearchDiplaySelect";
            this.ShowIcon = false;
            this.Text = "検索画面選択";
            this.pnlProcessingMode.ResumeLayout(false);
            this.pnlProcessingMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProcessingMode;
        private Common.ItemHeadLabel lblProcessingMode;
        private System.Windows.Forms.RadioButton rdoSearchDiplay2;
        private System.Windows.Forms.RadioButton rdoSearchDiplay1;
        private Common.FeaturesButton btnCheck;
    }
}