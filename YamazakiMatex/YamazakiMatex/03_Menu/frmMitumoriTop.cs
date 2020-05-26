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
using PrintInstructions;

namespace Menu
{
    public partial class frmMitumoriTop : Common.BaseForm
    {
        public frmMitumoriTop()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 見積モニタ
            frmEstimateInput form = new frmEstimateInput();
            showChildForm(form);
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // 見積一覧表
            frmMitumoriIchiran form = new frmMitumoriIchiran();
            showChildForm(form);
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 宛名印刷
            frmAtena form = new frmAtena();
            showChildForm(form);
        }
    }
}
