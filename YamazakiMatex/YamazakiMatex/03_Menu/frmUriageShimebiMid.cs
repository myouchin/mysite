using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeikyuKoshin;
using PrintInstructions;
using TokuisakiSeikyuKanri;
using Resorce;

namespace Menu
{
    public partial class frmUriageShimebiMid : Common.BaseForm
    {
        public frmUriageShimebiMid()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                featuresButton1.Enabled = false;
                featuresButton1.Visible = false;
                featuresButton2.Enabled = false;
                featuresButton2.Visible = false;
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 請求更新
            frmSeikyuKoshinTop fSeikyuKoushin = new frmSeikyuKoshinTop();
            showChildForm(fSeikyuKoushin);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 請求書
            frmSeikyusyo form = new frmSeikyusyo();
            showChildForm(form);
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 請求一覧表
            frmSeikyuIchiran form = new frmSeikyuIchiran();
            showChildForm(form);
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 得意先別回収予定表
            frmUrikakeKaisyuHyo form = new frmUrikakeKaisyuHyo();
            showChildForm(form);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 得意先別請求管理
            frmTokuisakiSeikyuKanri form = new frmTokuisakiSeikyuKanri();
            showChildForm(form);
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 得意先別売上元帳
            frmTokuisakiUrikakeMototyo form = new frmTokuisakiUrikakeMototyo();
            showChildForm(form);
        }
    }
}
