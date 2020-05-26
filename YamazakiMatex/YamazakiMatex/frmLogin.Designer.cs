
partial class frmLogin
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
        this.txtID = new System.Windows.Forms.TextBox();
        this.lblID = new Common.ItemHeadLabel();
        this.lblPassWord = new Common.ItemHeadLabel();
        this.txtPassWord = new System.Windows.Forms.TextBox();
        this.pnlBody = new System.Windows.Forms.Panel();
        this.lblInfomation = new System.Windows.Forms.Label();
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.btnEnd = new Common.FeaturesButton();
        this.btnCheck = new Common.FeaturesButton();
        this.lblSystemTitle = new System.Windows.Forms.Label();
        this.pnlBody.SuspendLayout();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();
        // 
        // txtID
        // 
        this.txtID.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.txtID.Location = new System.Drawing.Point(232, 59);
        this.txtID.Name = "txtID";
        this.txtID.Size = new System.Drawing.Size(285, 27);
        this.txtID.TabIndex = 0;
        // 
        // lblID
        // 
        this.lblID.BackColor = System.Drawing.SystemColors.ControlDark;
        this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblID.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.lblID.ForeColor = System.Drawing.Color.White;
        this.lblID.Location = new System.Drawing.Point(150, 59);
        this.lblID.Name = "lblID";
        this.lblID.Size = new System.Drawing.Size(76, 27);
        this.lblID.TabIndex = 1;
        this.lblID.Text = "ID：";
        this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPassWord
        // 
        this.lblPassWord.BackColor = System.Drawing.SystemColors.ControlDark;
        this.lblPassWord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblPassWord.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.lblPassWord.ForeColor = System.Drawing.Color.White;
        this.lblPassWord.Location = new System.Drawing.Point(150, 105);
        this.lblPassWord.Name = "lblPassWord";
        this.lblPassWord.Size = new System.Drawing.Size(76, 27);
        this.lblPassWord.TabIndex = 3;
        this.lblPassWord.Text = "Pass：";
        this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // txtPassWord
        // 
        this.txtPassWord.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.txtPassWord.Location = new System.Drawing.Point(232, 105);
        this.txtPassWord.Name = "txtPassWord";
        this.txtPassWord.Size = new System.Drawing.Size(285, 27);
        this.txtPassWord.TabIndex = 2;
        this.txtPassWord.UseSystemPasswordChar = true;
        // 
        // pnlBody
        // 
        this.pnlBody.BackColor = System.Drawing.Color.LightSteelBlue;
        this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.pnlBody.Controls.Add(this.lblInfomation);
        this.pnlBody.Controls.Add(this.lblID);
        this.pnlBody.Controls.Add(this.txtID);
        this.pnlBody.Controls.Add(this.lblPassWord);
        this.pnlBody.Controls.Add(this.txtPassWord);
        this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlBody.Location = new System.Drawing.Point(0, 80);
        this.pnlBody.Name = "pnlBody";
        this.pnlBody.Size = new System.Drawing.Size(690, 160);
        this.pnlBody.TabIndex = 4;
        // 
        // lblInfomation
        // 
        this.lblInfomation.AutoSize = true;
        this.lblInfomation.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.lblInfomation.Location = new System.Drawing.Point(150, 20);
        this.lblInfomation.Name = "lblInfomation";
        this.lblInfomation.Size = new System.Drawing.Size(286, 20);
        this.lblInfomation.TabIndex = 5;
        this.lblInfomation.Text = "ID・パスワードを入力してください。";
        // 
        // pnlBottom
        // 
        this.pnlBottom.BackColor = System.Drawing.Color.LightSteelBlue;
        this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.pnlBottom.Controls.Add(this.btnEnd);
        this.pnlBottom.Controls.Add(this.btnCheck);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlBottom.Location = new System.Drawing.Point(0, 240);
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new System.Drawing.Size(690, 70);
        this.pnlBottom.TabIndex = 5;
        // 
        // btnEnd
        // 
        this.btnEnd.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.btnEnd.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.btnEnd.Location = new System.Drawing.Point(415, 15);
        this.btnEnd.Name = "btnEnd";
        this.btnEnd.Size = new System.Drawing.Size(102, 40);
        this.btnEnd.TabIndex = 1;
        this.btnEnd.Text = "終了";
        this.btnEnd.UseVisualStyleBackColor = false;
        this.btnEnd.Click += new System.EventHandler(this.featuresButton2_Click);
        // 
        // btnCheck
        // 
        this.btnCheck.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.btnCheck.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.btnCheck.Location = new System.Drawing.Point(307, 15);
        this.btnCheck.Name = "btnCheck";
        this.btnCheck.Size = new System.Drawing.Size(102, 40);
        this.btnCheck.TabIndex = 0;
        this.btnCheck.Text = "確認";
        this.btnCheck.UseVisualStyleBackColor = false;
        this.btnCheck.Click += new System.EventHandler(this.featuresButton1_Click);
        // 
        // lblSystemTitle
        // 
        this.lblSystemTitle.BackColor = System.Drawing.Color.RoyalBlue;
        this.lblSystemTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblSystemTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblSystemTitle.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.lblSystemTitle.ForeColor = System.Drawing.Color.White;
        this.lblSystemTitle.Location = new System.Drawing.Point(0, 0);
        this.lblSystemTitle.Name = "lblSystemTitle";
        this.lblSystemTitle.Size = new System.Drawing.Size(690, 80);
        this.lblSystemTitle.TabIndex = 6;
        this.lblSystemTitle.Text = "株式会社ヤマザキマテックス売上管理";
        this.lblSystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // frmLogin
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(690, 309);
        this.ControlBox = false;
        this.Controls.Add(this.pnlBottom);
        this.Controls.Add(this.pnlBody);
        this.Controls.Add(this.lblSystemTitle);
        this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
        this.Name = "frmLogin";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "ログイン";
        this.pnlBody.ResumeLayout(false);
        this.pnlBody.PerformLayout();
        this.pnlBottom.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtID;
    private Common.ItemHeadLabel lblID;
    private Common.ItemHeadLabel lblPassWord;
    private System.Windows.Forms.TextBox txtPassWord;
    private System.Windows.Forms.Panel pnlBody;
    private System.Windows.Forms.Panel pnlBottom;
    private Common.FeaturesButton btnCheck;
    private Common.FeaturesButton btnEnd;
    private System.Windows.Forms.Label lblInfomation;
    private System.Windows.Forms.Label lblSystemTitle;
}