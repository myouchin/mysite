using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shiire;
using Shiharai;
using PrintInstructions;
using Resorce;

namespace Menu
{
    public partial class frmShiireNichijiMid : Common.BaseForm
    {
        public frmShiireNichijiMid()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                featuresButton2.Enabled = false;
                featuresButton2.Visible = false;
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 仕入モニタ
            frmShiireInput form = new frmShiireInput();
            showChildForm(form);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 仕払モニタ
            frmShiharaiInput form = new frmShiharaiInput();
            showChildForm(form);
        }
    }
}
