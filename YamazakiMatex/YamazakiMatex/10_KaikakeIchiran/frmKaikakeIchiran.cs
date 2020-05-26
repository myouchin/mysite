using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using SubForm;

namespace KaikakeIchiran
{
    public partial class frmKaikakeIchiran : Common.ChildBaseForm
    {
        public frmKaikakeIchiran()
        {
            InitializeComponent();
            setContorolLayout(this);
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {

        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            sfrmShiiresakiSearch form = new sfrmShiiresakiSearch(true, CheckMessageType.None);
            showChildForm(form);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closedForm();
        }
    }   
}
