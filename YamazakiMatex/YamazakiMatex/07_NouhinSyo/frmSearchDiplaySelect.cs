using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using Common;
using Resorce;
using SubForm;

namespace NouhinSyo
{
    public partial class frmSearchDiplaySelect : Common.ChildBaseForm
    {
        #region 変数定義
        public enum StartDisplayType
        {
            SearchDiplay1 = 0
          , SearchDiplay2 = 1
        }
        private StartDisplayType startDisplayType;
        public StartDisplayType DisplayType
        {
            get { return startDisplayType; }
            set { startDisplayType = value; }
        }
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSearchDiplaySelect(string rdoSearchDiplay1Text, string rdoSearchDiplay2Text)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(rdoSearchDiplay1Text))
            {
                rdoSearchDiplay1.Text = rdoSearchDiplay1Text;
            }
            if (!string.IsNullOrEmpty(rdoSearchDiplay2Text))
            {
                rdoSearchDiplay2.Text = rdoSearchDiplay2Text;
            }
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #endregion

        private void btnCheck_Click(object sender, EventArgs e)
        {
            startDisplayType = rdoSearchDiplay1.Checked ? StartDisplayType.SearchDiplay1 : StartDisplayType.SearchDiplay2;
            DialogResult = DialogResult.OK;
            // 画面終了処理
            closedForm();
        }
    }
}
