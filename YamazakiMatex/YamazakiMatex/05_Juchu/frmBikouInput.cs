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
    public partial class frmBikouInput : Common.ChildBaseForm
    {
        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmBikouInput(string defaultBikouText, bool flgReference)
        {
            InitializeComponent();
            txtRemarks.Text = defaultBikouText;
            DialogResult = DialogResult.Cancel;
            if (flgReference)
            {
                txtRemarks.ReadOnly = true;
                btnCheck.Visible = false;
            }
        }
        #endregion

        #region 確認ボタン押下イベント
        private void btnCheck_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            // 画面終了処理
            closedForm();
        }
        #endregion

        #region 戻るボタン押下イベント
        private void btmBack_Click(object sender, EventArgs e)
        {
            // 画面終了処理
            closedForm();
        }
        #endregion

        #endregion

        #region ビジネスロジック

        #region 備考テキスト取得処理
        /// <summary>
        /// 備考テキスト取得処理
        /// </summary>
        /// <returns></returns>
        public string getBikouText()
        {
            return txtRemarks.Text;
        }
        #endregion

        #endregion
    }
}
