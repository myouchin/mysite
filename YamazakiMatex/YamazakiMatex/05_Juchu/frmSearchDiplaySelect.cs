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

namespace Juchu
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
            // 画面特有のイベントを追加
            setEvent(this);
        }
        #endregion

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // キー押下イベントを追加
            c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

            // FormまたはPanelの場合、子階層の項目へイベントを追加
            if (c is Form || c is Panel)
            {
                foreach (Control cc in c.Controls)
                {
                    setEvent(cc);
                }
            }
        }
        #endregion

        #region Enterキー押下イベント
        /// <summary>
        /// Enterキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputObject_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                // Enterキーが押下された場合
                case Keys.Enter:
                    btnCheck_Click(null, null);
                    break;
                default:
                    break;
            }
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
