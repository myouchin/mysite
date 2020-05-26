using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrintInstructions;
using Resorce;

namespace Menu
{
    public partial class frmShiireNenjiMid : Common.BaseForm
    {
        public frmShiireNenjiMid()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                featuresButton2.Enabled = false;
                featuresButton2.Visible = false;
            }
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 買掛金一覧表
            frmKaikakeZandataIchiran form = new frmKaikakeZandataIchiran(false);
            showChildForm(form);
        }
    }
}
