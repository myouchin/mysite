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

namespace SeikyuKoshin
{
    /// <summary>
    /// 請求更新トップ画面
    /// </summary>
    public partial class frmSeikyuKoshinTop : ChildBaseForm
    {
        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSeikyuKoshinTop()
        {
            InitializeComponent();
        }
        #endregion

        #region １．締日更新ボタン押下処理
        /// <summary>
        /// １．締日更新ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosingDateUpDate_Click(object sender, EventArgs e)
        {
            // 締日更新処理画面を起動
            frmSeikyuShimebiKoshin fShimebi = new frmSeikyuShimebiKoshin();
            showChildForm(fShimebi);
        }
        #endregion

        #region ２．請求月変更ボタン押下処理
        /// <summary>
        /// ２．請求月変更ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosingMonthChange_Click(object sender, EventArgs e)
        {
            // 請求日変更画面を起動
            frmSeikyuChange fSeikyu = new frmSeikyuChange();
            showChildForm(fSeikyu);

        }
        #endregion

        #region 閉じるボタン押下処理
        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            closedForm();
        }
        #endregion

        #endregion
    }
}
