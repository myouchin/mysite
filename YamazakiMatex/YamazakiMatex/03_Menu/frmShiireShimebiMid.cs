using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShiharaiKoushin;
using PrintInstructions;
using Resorce;

namespace Menu
{
    public partial class frmShiireShimebiMid : Common.BaseForm
    {
        public frmShiireShimebiMid()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                featuresButton1.Enabled = false;
                featuresButton1.Visible = false;
                featuresButton4.Enabled = false;
                featuresButton4.Visible = false;
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 締日更新
            frmShiharaiShimebiKoshin form = new frmShiharaiShimebiKoshin();
            showChildForm(form);
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 支払予定表
            frmShiharaiYotei form = new frmShiharaiYotei();
            showChildForm(form);
        }
    }
}
