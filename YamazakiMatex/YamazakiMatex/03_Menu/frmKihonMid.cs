using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mitumori;
using Master;
using TokuisakiSeikyuKanri;
using TokuisakiUrikakeKanri;
using PrintInstructions;

namespace Menu
{
    public partial class frmKihonMid : Common.BaseForm
    {
        public frmKihonMid()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 得意先一覧表
            frmTokuiMIchiran form = new frmTokuiMIchiran();
            showChildForm(form);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 仕入先一覧表
            frmShiresakiIchiran form = new frmShiresakiIchiran();
            showChildForm(form);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 商品一覧表
            frmShouhinMIchiran form = new frmShouhinMIchiran();
            showChildForm(form);
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 件名一覧表
            frmKenmeiIchiran form = new frmKenmeiIchiran();
            showChildForm(form);
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 欠番一覧表
            frmKetubanIchiran form = new frmKetubanIchiran();
            showChildForm(form);
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 受注・納品・仕入関連一覧表
            frmJuchuKanrenIchiran form = new frmJuchuKanrenIchiran();
            showChildForm(form);
        }

        private void featuresButton7_Click(object sender, EventArgs e)
        {
            // 納品残・入荷一覧表
            frmNouhinShireZanIchiran form = new frmNouhinShireZanIchiran();
            showChildForm(form);
        }
    }
}
