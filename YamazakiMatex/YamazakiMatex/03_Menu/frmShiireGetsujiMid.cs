using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KaikakeIchiran;
using PrintInstructions;
using Resorce;

namespace Menu
{
    public partial class frmShiireGetsujiMid : Common.BaseForm
    {
        public frmShiireGetsujiMid()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                featuresButton1.Enabled = false;
                featuresButton1.Visible = false;
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 買掛金一覧表
            //frmKaikakeIchiran form = new frmKaikakeIchiran();
            //showChildForm(form);
            frmKaikakeZandataIchiran form = new frmKaikakeZandataIchiran(true);
            showChildForm(form);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 仕入元帳
            frmShireMototyo form = new frmShireMototyo();
            showChildForm(form);
        }
    }
}
