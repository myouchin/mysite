using System;

namespace Common
{
    partial class frmPrintQueryNouhinsyo
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
            this.pnlDeliveryPrintType = new System.Windows.Forms.Panel();
            this.btnFormalPrint = new Common.FeaturesButton();
            this.lblDeliveryPrintType = new Common.ItemHeadLabel();
            this.btnProvisionalPrint = new Common.FeaturesButton();
            this.pnlDeliveryPreviewType = new System.Windows.Forms.Panel();
            this.btnFormalPreview = new Common.FeaturesButton();
            this.lblDeliveryPreviewType = new Common.ItemHeadLabel();
            this.btnProvisionalPreview = new Common.FeaturesButton();
            this.lblMessageBase = new System.Windows.Forms.Label();
            this.btnCheck = new Common.FeaturesButton();
            this.pnlMessage.SuspendLayout();
            this.pnlDeliveryPrintType.SuspendLayout();
            this.pnlDeliveryPreviewType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMessage.Controls.Add(this.pnlDeliveryPrintType);
            this.pnlMessage.Controls.Add(this.pnlDeliveryPreviewType);
            this.pnlMessage.Controls.Add(this.lblMessageBase);
            this.pnlMessage.Controls.Add(this.btnCheck);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(707, 124);
            this.pnlMessage.TabIndex = 109;
            // 
            // pnlDeliveryPrintType
            // 
            this.pnlDeliveryPrintType.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDeliveryPrintType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDeliveryPrintType.Controls.Add(this.btnFormalPrint);
            this.pnlDeliveryPrintType.Controls.Add(this.lblDeliveryPrintType);
            this.pnlDeliveryPrintType.Controls.Add(this.btnProvisionalPrint);
            this.pnlDeliveryPrintType.Location = new System.Drawing.Point(262, 39);
            this.pnlDeliveryPrintType.Name = "pnlDeliveryPrintType";
            this.pnlDeliveryPrintType.Size = new System.Drawing.Size(253, 80);
            this.pnlDeliveryPrintType.TabIndex = 564;
            // 
            // btnFormalPrint
            // 
            this.btnFormalPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFormalPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFormalPrint.Location = new System.Drawing.Point(129, 34);
            this.btnFormalPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFormalPrint.Name = "btnFormalPrint";
            this.btnFormalPrint.Size = new System.Drawing.Size(106, 40);
            this.btnFormalPrint.TabIndex = 561;
            this.btnFormalPrint.Text = "本";
            this.btnFormalPrint.UseVisualStyleBackColor = false;
            this.btnFormalPrint.Click += new System.EventHandler(this.btnFormalPrint_Click);
            // 
            // lblDeliveryPrintType
            // 
            this.lblDeliveryPrintType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDeliveryPrintType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeliveryPrintType.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDeliveryPrintType.ForeColor = System.Drawing.Color.White;
            this.lblDeliveryPrintType.Location = new System.Drawing.Point(5, 2);
            this.lblDeliveryPrintType.Name = "lblDeliveryPrintType";
            this.lblDeliveryPrintType.Size = new System.Drawing.Size(130, 27);
            this.lblDeliveryPrintType.TabIndex = 4;
            this.lblDeliveryPrintType.Text = "納品書印刷";
            this.lblDeliveryPrintType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProvisionalPrint
            // 
            this.btnProvisionalPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProvisionalPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnProvisionalPrint.Location = new System.Drawing.Point(15, 34);
            this.btnProvisionalPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProvisionalPrint.Name = "btnProvisionalPrint";
            this.btnProvisionalPrint.Size = new System.Drawing.Size(106, 40);
            this.btnProvisionalPrint.TabIndex = 551;
            this.btnProvisionalPrint.Text = "仮";
            this.btnProvisionalPrint.UseVisualStyleBackColor = false;
            this.btnProvisionalPrint.Click += new System.EventHandler(this.btnProvisionalPrint_Click);
            // 
            // pnlDeliveryPreviewType
            // 
            this.pnlDeliveryPreviewType.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDeliveryPreviewType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDeliveryPreviewType.Controls.Add(this.btnFormalPreview);
            this.pnlDeliveryPreviewType.Controls.Add(this.lblDeliveryPreviewType);
            this.pnlDeliveryPreviewType.Controls.Add(this.btnProvisionalPreview);
            this.pnlDeliveryPreviewType.Location = new System.Drawing.Point(3, 39);
            this.pnlDeliveryPreviewType.Name = "pnlDeliveryPreviewType";
            this.pnlDeliveryPreviewType.Size = new System.Drawing.Size(253, 80);
            this.pnlDeliveryPreviewType.TabIndex = 563;
            // 
            // btnFormalPreview
            // 
            this.btnFormalPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFormalPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFormalPreview.Location = new System.Drawing.Point(129, 34);
            this.btnFormalPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFormalPreview.Name = "btnFormalPreview";
            this.btnFormalPreview.Size = new System.Drawing.Size(106, 40);
            this.btnFormalPreview.TabIndex = 561;
            this.btnFormalPreview.Text = "本";
            this.btnFormalPreview.UseVisualStyleBackColor = false;
            this.btnFormalPreview.Click += new System.EventHandler(this.btnFormalPreview_Click);
            // 
            // lblDeliveryPreviewType
            // 
            this.lblDeliveryPreviewType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDeliveryPreviewType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeliveryPreviewType.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDeliveryPreviewType.ForeColor = System.Drawing.Color.White;
            this.lblDeliveryPreviewType.Location = new System.Drawing.Point(5, 2);
            this.lblDeliveryPreviewType.Name = "lblDeliveryPreviewType";
            this.lblDeliveryPreviewType.Size = new System.Drawing.Size(167, 27);
            this.lblDeliveryPreviewType.TabIndex = 4;
            this.lblDeliveryPreviewType.Text = "納品書プレビュー";
            this.lblDeliveryPreviewType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProvisionalPreview
            // 
            this.btnProvisionalPreview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProvisionalPreview.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnProvisionalPreview.Location = new System.Drawing.Point(15, 34);
            this.btnProvisionalPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProvisionalPreview.Name = "btnProvisionalPreview";
            this.btnProvisionalPreview.Size = new System.Drawing.Size(106, 40);
            this.btnProvisionalPreview.TabIndex = 551;
            this.btnProvisionalPreview.Text = "仮";
            this.btnProvisionalPreview.UseVisualStyleBackColor = false;
            this.btnProvisionalPreview.Click += new System.EventHandler(this.btnProvisionalPreview_Click);
            // 
            // lblMessageBase
            // 
            this.lblMessageBase.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessageBase.Location = new System.Drawing.Point(10, 7);
            this.lblMessageBase.Name = "lblMessageBase";
            this.lblMessageBase.Size = new System.Drawing.Size(612, 24);
            this.lblMessageBase.TabIndex = 37;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Location = new System.Drawing.Point(592, 75);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(110, 40);
            this.btnCheck.TabIndex = 33;
            this.btnCheck.Text = "確認";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // frmPrintQueryNouhinsyo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(707, 124);
            this.ControlBox = true;
            this.Controls.Add(this.pnlMessage);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintQueryNouhinsyo";
            this.Text = "メッセージ";
            this.pnlMessage.ResumeLayout(false);
            this.pnlDeliveryPrintType.ResumeLayout(false);
            this.pnlDeliveryPreviewType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMessage;
        private FeaturesButton btnCheck;
        private System.Windows.Forms.Label lblMessageBase;
        private System.Windows.Forms.Panel pnlDeliveryPrintType;
        private FeaturesButton btnFormalPrint;
        private ItemHeadLabel lblDeliveryPrintType;
        private FeaturesButton btnProvisionalPrint;
        private System.Windows.Forms.Panel pnlDeliveryPreviewType;
        private FeaturesButton btnFormalPreview;
        private ItemHeadLabel lblDeliveryPreviewType;
        private FeaturesButton btnProvisionalPreview;
    }
}