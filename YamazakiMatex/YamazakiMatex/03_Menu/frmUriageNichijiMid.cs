using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nyukin;
using NouhinSyo;
using PrintInstructions;
using Resorce;
using SubForm;
using UriageIchiran;

namespace Menu
{
    public partial class frmUriageNichijiMid : Common.BaseForm
    {
        public frmUriageNichijiMid()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                featuresButton6.Enabled = false;
                featuresButton6.Visible = false;
                featuresButton7.Enabled = false;
                featuresButton7.Visible = false;
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            //// 納品書発行業務
            //Common.BaseForm btmForm = new frmUriageNichijiBtm();
            //((frmBusinessMenuBase)this.ParentForm).showBtmMenu(btmForm);
            //((frmBusinessMenuBase)this.ParentForm).buttonStyleChange((Button)sender);

            // 納品書発行業務
            frmNouhinsyoInput form = new frmNouhinsyoInput();
            showChildForm(form);

        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 売上モニタ
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 売上日計表
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 得意先別売上日計表
            frmTokuisakiUriageSyukei form = new frmTokuisakiUriageSyukei(frmTokuisakiUriageSyukei.DisplayType.YMD);
            showChildForm(form);
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 入金モニタ
            frmNyukinInput form = new frmNyukinInput();
            showChildForm(form);
        }

        private void featuresButton7_Click(object sender, EventArgs e)
        {
            // 領収書
            frmRyoShuSho form = new frmRyoShuSho();
            showChildForm(form);
        }

        private void featuresButton9_Click(object sender, EventArgs e)
        {
            // 未回収リスト
        }

        private void featuresButton2_Click_1(object sender, EventArgs e)
        {
            // 県別日別売上集計表
            frmKenbetsuHibetsuUriageSyukei form = new frmKenbetsuHibetsuUriageSyukei();
            showChildForm(form);
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 得意先別日別入金一覧表
            frmNyukinIchiran form = new frmNyukinIchiran();
            showChildForm(form);
        }

        private void featuresButton3_Click_1(object sender, EventArgs e)
        {
            // 売上関連データ一覧
            sfrmUriageIchiran form = new sfrmUriageIchiran();
            showChildForm(form);
        }

        private void featuresButton8_Click(object sender, EventArgs e)
        {
            // 売上一覧
            frmUriageIchiran form = new frmUriageIchiran();
            showChildForm(form);
        }
    }
}
