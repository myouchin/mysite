using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Resorce;

namespace Menu
{
    public partial class frmMainMenu : Common.BaseForm
    {
        private Point startPosition;
        public frmMainMenu()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                btnBasicManagement.Enabled = false;
                btnBasicManagement.Visible = false;
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 売上
            showBusinessMenu(frmBusinessMenuBase.BusinessMenuType.Uriage);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 見積
            showBusinessMenu(frmBusinessMenuBase.BusinessMenuType.Mitumori);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 基本管理
            showBusinessMenu(frmBusinessMenuBase.BusinessMenuType.Kihon);
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 仕入
            showBusinessMenu(frmBusinessMenuBase.BusinessMenuType.Shiire);
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 受注
            showBusinessMenu(frmBusinessMenuBase.BusinessMenuType.Juchu);
        }

        private void showBusinessMenu(frmBusinessMenuBase.BusinessMenuType menuType)
        {
            frmBusinessMenuBase form = new frmBusinessMenuBase(menuType);
            this.Visible = false;
            form.ShowDialog();
            this.Location = startPosition;
            this.Visible = true;
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            closedForm();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            startPosition = this.Location;
        }
    }
}
