using System;

namespace Common
{
    partial class frmMessage
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
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblMessageBase = new System.Windows.Forms.Label();
            this.btn2 = new Common.FeaturesButton();
            this.btn1 = new Common.FeaturesButton();
            this.pnlMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMessage.Controls.Add(this.lblMessageBase);
            this.pnlMessage.Controls.Add(this.btn2);
            this.pnlMessage.Controls.Add(this.btn1);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(628, 86);
            this.pnlMessage.TabIndex = 109;
            // 
            // lblMessageBase
            // 
            this.lblMessageBase.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessageBase.Location = new System.Drawing.Point(10, 7);
            this.lblMessageBase.Name = "lblMessageBase";
            this.lblMessageBase.Size = new System.Drawing.Size(612, 24);
            this.lblMessageBase.TabIndex = 37;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn2.Location = new System.Drawing.Point(531, 39);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(91, 40);
            this.btn2.TabIndex = 33;
            this.btn2.Text = "いいえ";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn1.Location = new System.Drawing.Point(434, 39);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(91, 40);
            this.btn1.TabIndex = 32;
            this.btn1.Text = "はい";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(628, 86);
            this.ControlBox = true;
            this.Controls.Add(this.pnlMessage);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessage";
            this.Text = "メッセージ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMessage_FormClosing);
            this.pnlMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMessage;
        private FeaturesButton btn2;
        private FeaturesButton btn1;
        private System.Windows.Forms.Label lblMessageBase;
    }
}