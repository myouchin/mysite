using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class frmUriageShiireTop : Common.BaseForm
    {
        private frmBusinessMenuBase.BusinessMenuType menuType;
        public frmUriageShiireTop(frmBusinessMenuBase.BusinessMenuType type)
        {
            InitializeComponent();
            menuType = type;
        }

        private void businessButton_Click(object sender, EventArgs e)
        {
            ((frmBusinessMenuBase)this.ParentForm).showMidMenu(getShowForm(((Button)sender).Name));
            ((frmBusinessMenuBase)this.ParentForm).buttonStyleChange((Button)sender);
        }


        private Common.BaseForm getShowForm(string btnName)
        {
            Common.BaseForm showForm = null;
            switch (menuType)
            {
                case frmBusinessMenuBase.BusinessMenuType.Uriage:
                    // 日次業務
                    if (featuresButton1.Name.Equals(btnName))
                    {
                        showForm = new frmUriageNichijiMid();
                    }
                    // 随時業務
                    else if (featuresButton2.Name.Equals(btnName))
                    {
                        showForm = new frmUriageZuijiMid();
                    }
                    // 締日業務
                    else if (featuresButton3.Name.Equals(btnName))
                    {
                        showForm = new frmUriageShimebiMid();
                    }
                    // 月次業務
                    else if (featuresButton7.Name.Equals(btnName))
                    {
                        showForm = new frmUriageGetsujiMid();
                    }
                    // 年次業務
                    else if (featuresButton8.Name.Equals(btnName))
                    {
                        showForm = new frmUriageNenjiMid();
                    }
                    break;
                case frmBusinessMenuBase.BusinessMenuType.Shiire:
                    // 日次業務
                    if (featuresButton1.Name.Equals(btnName))
                    {
                        showForm = new frmShiireNichijiMid();
                    }
                    // 随時業務
                    else if (featuresButton2.Name.Equals(btnName))
                    {
                    }
                    // 締日業務
                    else if (featuresButton3.Name.Equals(btnName))
                    {
                        showForm = new frmShiireShimebiMid();
                    }
                    // 月次業務
                    else if (featuresButton7.Name.Equals(btnName))
                    {
                        showForm = new frmShiireGetsujiMid();
                    }
                    // 年次業務
                    else if (featuresButton8.Name.Equals(btnName))
                    {
                        showForm = new frmShiireNenjiMid();
                    }
                    break;
            }
            return showForm;
        }
    }
}
