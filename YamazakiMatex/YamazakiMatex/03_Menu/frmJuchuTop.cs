using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Juchu;
using PrintInstructions;

namespace Menu
{
    public partial class frmJuchuTop : Common.BaseForm
    {
        public frmJuchuTop()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 受注モニタ
            frmJuchuInput form = new frmJuchuInput();
            showChildForm(form);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 受注一覧表
            frmJyuchachuIchiran form = new frmJyuchachuIchiran();
            showChildForm(form);
        }

        private void featuresButton5_Click(object sender, EventArgs e)
        {
            // 得意先別受注一覧表
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 発注一覧表
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // メインメニュー
            ((frmBusinessMenuBase)this.ParentForm).closedForm();
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 送り状
            frmOkurijou form = new frmOkurijou();
            showChildForm(form);
        }

        private void featuresButton4_Click_1(object sender, EventArgs e)
        {
            // 宛名印刷
            frmAtena form = new frmAtena();
            showChildForm(form);
        }
    }
}
