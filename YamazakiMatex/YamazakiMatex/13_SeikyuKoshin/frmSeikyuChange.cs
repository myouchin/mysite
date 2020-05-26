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
using DB;
using Resorce;
using SubForm;

namespace SeikyuKoshin
{
    /// <summary>
    /// 請求日変更画面
    /// </summary>
    public partial class frmSeikyuChange : ChildBaseForm
    {
        #region 変数宣言
        private int startGridRowCount = 20;
        DBSeikyu seikyuDataDb;
        frmSeikyuChangeSearch fSeikyuChangeSearch = new frmSeikyuChangeSearch();
        private enum LastInputDateType
        {
            None = 0
          , BillingDate = 1
          , SalesDateFrom = 2
          , SalesDateTo = 3
        }
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSeikyuChange()
        {
            InitializeComponent();
            seikyuDataDb = new DBSeikyu();
        }
        #endregion

        #region 検索条件ボタン押下イベント
        /// <summary>
        /// 検索条件ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchCriteria_Click(object sender, EventArgs e)
        {
            fSeikyuChangeSearch.StartPosition = FormStartPosition.CenterScreen;
            fSeikyuChangeSearch.ListDispMessage = checkDataChange() ? Messages.M0034 : string.Empty;
            fSeikyuChangeSearch.ShowDialog();

            if (fSeikyuChangeSearch.DialogResult == DialogResult.OK)
            {
                setSeikyuList();
            }
        }
        #endregion

        #region 保存ボタン押下イベント
        /// <summary>
        /// 保存ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> commands = createRegistSeikyuListSql();

            foreach (string command in commands)
            {
                seikyuDataDb.executeDBUpdate(command);
                if (seikyuDataDb.DBRef < 0) break;
            }
            seikyuDataDb.endTransaction();

            if (seikyuDataDb.DBRef < 0)
            {
                errorOK(string.Format(Messages.M0011, "請求日", "更新処理"));
            }
            else
            {
                messageOK(string.Format(Messages.M0012, "請求日", "更新"));
                setSeikyuList();
            }
        }
        #endregion

        #region 取消ボタン押下イベント
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!checkDataChange()) return;
            if (queryYesNo(string.Format(Messages.M0033, "処理を継続してよろしいですか？")) == DialogResult.No) return;

            foreach (DataGridViewRow gRow in grdSeikyuList.Rows)
            {
                if (string.IsNullOrEmpty(Convert.ToString(gRow.Cells[clmDocumentNo.Name].Value))) break;
                gRow.Cells[clmBillingDate.Name].Value = gRow.Cells[clmBeforeBillingDate.Name].Value;
            }
        }
        #endregion

        #region 閉じるボタン押下イベント
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (checkDataChange() && queryYesNo(string.Format(Messages.M0033, "処理を継続してよろしいですか？")) == DialogResult.No)
            {
                return;
            }
            closedForm();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSeikyuChange_Load(object sender, EventArgs e)
        {
            setCommonEvent(this);
            setSeikyuList();
        }
        #endregion

        #region セル描画イベント
        /// <summary>
        /// セル描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSeikyuList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            // 行・列共にヘッダは処理しない
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int rowIndex = -1;
            // カレントセルがnull出ない場合
            if (grdSeikyuList.CurrentCell != null)
            {
                // カレントセルから上段行の行インデックを取得
                rowIndex = grdSeikyuList.CurrentCell.RowIndex;
                if (rowIndex % grdSeikyuList.RowSegmentCount == 1) rowIndex--;
            }
            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(rowIndex);
        }
        #endregion

        #region カレントセル変更時イベント
        /// <summary>
        /// カレントセル変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSeikyuList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdSeikyuList.CurrentCell == null) return;
            // カレントセルがTextBoxCellかつ
            // 入力可能セルの場合
            if (clmBillingDate.Name.Equals(grdSeikyuList.Columns[grdSeikyuList.CurrentCell.ColumnIndex].Name))
            {
                // カレントセルの編集モードを開始
                grdSeikyuList.BeginEdit(true);
            }
        }
        #endregion

        #endregion

        #region ビジネスロジック

        #region 請求データ設定処理
        /// <summary>
        /// 請求データ設定処理
        /// </summary>
        private void setSeikyuList()
        {
            seikyuDataDb.startTransaction();
            seikyuDataDb.getSeikyuList(fSeikyuChangeSearch.SearchCriteria);

            DataTable sourceDt = seikyuDataDb.SeikyuData.Copy();
            for (int i = sourceDt.Rows.Count; i < startGridRowCount; i++)
            {
                sourceDt.Rows.Add();
            }
            grdSeikyuList.DataSource = sourceDt;
        }
        #endregion

        #region データグリッドビュー行の背景色・入力可否設定処理
        /// <summary>
        /// データグリッドビュー行の背景色・入力可否設定処理
        /// </summary>
        /// <param name="topRowIndex"></param>
        /// <param name="color"></param>
        private void setGridRowStyle(int topRowIndex)
        {
            Color setBackColor;
            Color setForeColor = Color.Black;
            string documentNo;
            // 全行の背景色を再設定
            foreach (DataGridViewRow gRow in grdSeikyuList.Rows)
            {
                if (grdSeikyuList.CurrentCell != null && grdSeikyuList.CurrentCell.RowIndex == gRow.Index)
                {
                    setBackColor = Color.LightCyan;
                }
                else
                {
                    setBackColor = Color.White;
                }
                documentNo = Convert.ToString(gRow.Cells[clmDocumentNo.Name].Value);
                if (string.IsNullOrEmpty(documentNo)) grdSeikyuList.Rows[gRow.Index].Cells[clmBillingDate.DisplayIndex].ReadOnly = true;
                // セル未選択時の文字色の設定
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentNo.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentDate.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmCustomerName.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmOffice.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingDate.DisplayIndex].Style.ForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingType.DisplayIndex].Style.ForeColor = setForeColor;
                // セル選択時の文字色の設定
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentNo.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentDate.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmCustomerName.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmOffice.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingDate.DisplayIndex].Style.SelectionForeColor = setForeColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingType.DisplayIndex].Style.SelectionForeColor = setForeColor;
                // セル未選択時の背景色の設定
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentNo.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentDate.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmCustomerName.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmOffice.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingDate.DisplayIndex].Style.BackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingType.DisplayIndex].Style.BackColor = setBackColor;
                // セル選択時の背景色の設定
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentNo.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmDocumentDate.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmCustomerName.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmOffice.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingDate.DisplayIndex].Style.SelectionBackColor = setBackColor;
                grdSeikyuList.Rows[gRow.Index].Cells[clmBillingType.DisplayIndex].Style.SelectionBackColor = setBackColor;
            }
        }
        #endregion

        #region 変更チェック処理
        /// <summary>
        /// 変更チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkDataChange()
        {
            bool result = false;

            string billingDate;
            string beforeBillingDate;
            foreach (DataGridViewRow gRow in grdSeikyuList.Rows)
            {
                billingDate = Convert.ToString(gRow.Cells[clmBillingDate.Name].Value);
                beforeBillingDate = Convert.ToString(gRow.Cells[clmBeforeBillingDate.Name].Value);

                if (!billingDate.Equals(beforeBillingDate))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        #endregion

        #region 請求日の更新SQL生成処理
        /// <summary>
        /// 請求日の更新SQL生成処理
        /// </summary>
        /// <returns></returns>
        private List<string> createRegistSeikyuListSql()
        {
            List<string> commands = new List<string>();
            string denpyoNo;
            int rowNo;
            string beforeSeikyuDate;
            string afterSeikyuDate;
            DateTime seikyuDate = DateTime.Now;

            foreach (DataGridViewRow gRow in grdSeikyuList.Rows)
            {
                denpyoNo = Convert.ToString(gRow.Cells[clmDocumentNo.Name].Value);
                if (string.IsNullOrEmpty(denpyoNo)) break;
                beforeSeikyuDate = Convert.ToString(gRow.Cells[clmBeforeBillingDate.Name].Value);
                afterSeikyuDate = Convert.ToString(gRow.Cells[clmBillingDate.Name].Value);
                if (beforeSeikyuDate.Equals(afterSeikyuDate)) continue;
                rowNo = Convert.ToInt16(gRow.Cells[clmRowNo.Name].Value);
                if (!string.IsNullOrEmpty(afterSeikyuDate))
                {
                    try
                    {
                        seikyuDate = Convert.ToDateTime(afterSeikyuDate);
                    }
                    catch
                    {
                        afterSeikyuDate = string.Empty;
                    }
                }
                commands.Add("UPDATE uriage_body SET seikyuHizuke = " + (string.IsNullOrEmpty(afterSeikyuDate) ? "NULL" : "'" + afterSeikyuDate + "'") + " WHERE denpyoNo = '" + denpyoNo + "' AND rowNo = " + rowNo);
            }

            return commands;
        }
        #endregion

        #endregion
    }
}
