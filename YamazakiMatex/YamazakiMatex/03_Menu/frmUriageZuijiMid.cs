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
    public partial class frmUriageZuijiMid : Common.BaseForm
    {
        public frmUriageZuijiMid()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 宛名印刷
            frmAtena form = new frmAtena();
            showChildForm(form);
        }
    }
}
