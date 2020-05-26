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
    public partial class frmBusinessMenuBase : Common.BaseForm
    {
        private Common.BaseForm activeMidForm = null;
        private Common.BaseForm activeBtmForm = null;
        private bool flgInProgress = false;
        private BusinessMenuType menuType;
        public enum BusinessMenuType
        {
            Uriage = 0
            , Mitumori = 1
            , Shiire = 2
            , Juchu = 3
            , Kihon = 4
        }
        public frmBusinessMenuBase(BusinessMenuType type)
        {
            InitializeComponent();
            menuType = type;
            showTopMenu();
        }

        public void showTopMenu()
        {
            Common.BaseForm topMenu = null;
            String title = string.Empty;
            switch (menuType)
            {
                case BusinessMenuType.Uriage:
                    title = "売上管理";
                    topMenu = new frmUriageShiireTop(menuType);
                    break;
                case BusinessMenuType.Mitumori:
                    title = "見積管理";
                    topMenu = new frmMitumoriTop();
                    break;
                case BusinessMenuType.Shiire:
                    title = "仕入管理";
                    topMenu = new frmUriageShiireTop(menuType);
                    break;
                case BusinessMenuType.Juchu:
                    title = "受注管理";
                    topMenu = new frmJuchuTop();
                    break;
                case BusinessMenuType.Kihon:
                    title = "基本管理";
                    topMenu = new frmKihonTop();
                    break;
            }
            this.Text = title;
            this.label1.Text = title;
            if (topMenu == null) return;
            topMenu.TopLevel = false;
            topMenu.Location = new Point(0, 0);
            topMenu.Dock = DockStyle.Fill;
            this.pnlTopMenu.Controls.Add(topMenu);
            topMenu.Show();
            this.pnlMidMenu.Visible = false;
            this.pnlBtmMenu.Visible = false;
            if (BusinessMenuType.Kihon.Equals(menuType))
            {
                showMidMenu(new frmKihonMid());
            }
        }

        public void showMidMenu(Common.BaseForm midForm)
        {
            if (flgInProgress) return;
            flgInProgress = true;
            if (activeMidForm != null) activeMidForm.closedForm();
            if (activeBtmForm != null) activeBtmForm.closedForm();
            this.pnlMidMenu.Visible = false;
            this.pnlBtmMenu.Visible = false;
            foreach (Control c in this.pnlMidMenu.Controls)
            {
                this.pnlMidMenu.Controls.Remove(c);
            }
            foreach (Control c in this.pnlBtmMenu.Controls)
            {
                this.pnlBtmMenu.Controls.Remove(c);
            }

            if (midForm != null)
            {
                midForm.TopLevel = false;
                midForm.Location = new Point(0, 0);
                midForm.Dock = DockStyle.Fill;
                this.pnlMidMenu.Controls.Add(midForm);
                midForm.Show();
                this.pnlMidMenu.Visible = true;
            }

            activeMidForm = midForm;
            activeBtmForm = null;
            flgInProgress = false;
        }

        public void showBtmMenu(Common.BaseForm btmForm)
        {
            if (flgInProgress) return;
            flgInProgress = true;
            if (activeBtmForm != null) activeBtmForm.closedForm();
            this.pnlBtmMenu.Visible = false;
            foreach (Control c in this.pnlBtmMenu.Controls)
            {
                this.pnlBtmMenu.Controls.Remove(c);
            }

            if (btmForm != null)
            {
                btmForm.TopLevel = false;
                btmForm.Location = new Point(0, 0);
                btmForm.Dock = DockStyle.Fill;
                this.pnlBtmMenu.Controls.Add(btmForm);
                btmForm.Show();
                this.pnlBtmMenu.Visible = true;
            }

            activeBtmForm = btmForm;
            flgInProgress = false;
        }

        public void buttonStyleChange(Button clickedButton)
        {
            Control parentControl = clickedButton.Parent;

            foreach (Control c in parentControl.Controls)
            {
                if (c.Name.Equals(clickedButton.Name))
                {
                    //c.BackColor = Color.Red;
                }
                else
                {
                    c.BackColor = SystemColors.ButtonFace;
                }
            }
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // メインメニュー
            closedForm();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
