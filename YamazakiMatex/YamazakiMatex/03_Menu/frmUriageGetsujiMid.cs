using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrikakeIchiran;
using PrintInstructions;
using Nakakita;
using UriageHibetuSoukatu;

namespace Menu
{
    public partial class frmUriageGetsujiMid : Common.BaseForm
    {
        public frmUriageGetsujiMid()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 得意先別売上一覧表
            frmTokuisakiUriageSyukei form = new frmTokuisakiUriageSyukei(frmTokuisakiUriageSyukei.DisplayType.YM);
            showChildForm(form);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 担当者別売上収支表
            frmUriageSyushiIchiran form = new frmUriageSyushiIchiran();
            showChildForm(form);
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 得意先別売掛一覧表
            //frmUrikakeIchiran form = new frmUrikakeIchiran();
            //showChildForm(form);
            frmTokuisakiUrikakeIchiran form = new frmTokuisakiUrikakeIchiran();
            showChildForm(form);
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 得意先別回収滞留管理表
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 中北電機県別売上一覧
            frmNakakitaKenbetuUriage form = new frmNakakitaKenbetuUriage();
            showChildForm(form);
        }

        private void featuresButton7_Click(object sender, EventArgs e)
        {
            // 中北電機事業所別売上一覧
            frmNakakitaJigyousyobetuUriage form = new frmNakakitaJigyousyobetuUriage();
            showChildForm(form);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 売上日別総括表
            frmUriageHibetuSoukatu form = new frmUriageHibetuSoukatu();
            showChildForm(form);
        }
    }
}
