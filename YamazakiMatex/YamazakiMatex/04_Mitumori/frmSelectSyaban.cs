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

namespace Mitumori
{
    /// <summary>
    /// 社判選択画面
    /// </summary>
    public partial class frmSelectSyaban : Common.ChildBaseForm
    {
        /// <summary>
        /// 社判出力区分
        /// </summary>
        public enum SyabanType
        {
            None = 0,
            Ari = 1,
            Nashi = 2
        }
        private SyabanType sType = SyabanType.None;
        public SyabanType SType
        {
            get
            {
                return sType;
            }
            set
            {
                sType = value;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSelectSyaban()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            // 画面特有のイベントを追加
            setEvent(this);
        }

        /// <summary>
        /// 確認ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (rdoNashi.Checked)
            {
                SType = SyabanType.Nashi;
            }
            else
            {
                SType = SyabanType.Ari;
            }
            DialogResult = DialogResult.OK;
            closedForm();
        }

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
    }
}
