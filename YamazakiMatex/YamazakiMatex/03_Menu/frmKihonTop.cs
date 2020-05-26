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

namespace Menu
{
    public partial class frmKihonTop : Common.BaseForm
    {
        public frmKihonTop()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 管理情報
            frmKanriM form = new frmKanriM();
            showChildForm(form);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 担当者マスタメンテ
            frmTantoM form = new frmTantoM();
            showChildForm(form);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 得意先マスタメンテ
            frmTokuiM form = new frmTokuiM();
            showChildForm(form);
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 仕入先マスタメンテ
            frmShireM form = new frmShireM();
            showChildForm(form);
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 品名マスタメンテ
            frmSyohinM form = new frmSyohinM();
            showChildForm(form);
        }

        private void featuresButton7_Click(object sender, EventArgs e)
        {
            // 名称マスタメンテ
            frmMeisyoM form = new frmMeisyoM();
            showChildForm(form);
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 件名マスタメンテ
            frmKenmeiM form = new frmKenmeiM();
            showChildForm(form);
        }

        private void featuresButton10_Click(object sender, EventArgs e)
        {
            // 会社マスタメンテ
            frmKaisyaM form = new frmKaisyaM();
            showChildForm(form);
        }

        private void featuresButton8_Click(object sender, EventArgs e)
        {
            // 得意先別請求管理
            frmTokuisakiSeikyuKanri form = new frmTokuisakiSeikyuKanri();
            showChildForm(form);
        }

        private void featuresButton9_Click(object sender, EventArgs e)
        {
            // 得意先別売掛管理
            frmTokuisakiUrikakeKanri form = new frmTokuisakiUrikakeKanri();
            showChildForm(form);
        }
    }
}
