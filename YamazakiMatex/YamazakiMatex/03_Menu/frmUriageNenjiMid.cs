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

namespace Menu
{
    public partial class frmUriageNenjiMid : Common.BaseForm
    {
        public frmUriageNenjiMid()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 得意先別売上一覧表
            frmTokuisakiUriageSyukei form = new frmTokuisakiUriageSyukei(frmTokuisakiUriageSyukei.DisplayType.Y);
            showChildForm(form);
        }
    }
}
