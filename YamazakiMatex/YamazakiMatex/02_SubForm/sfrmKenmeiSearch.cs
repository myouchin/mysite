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

namespace SubForm
{
    /// <summary>
    /// 件名検索画面
    /// </summary>
    public partial class sfrmKenmeiSearch : Common.ChildBaseForm
    {
        #region 変数宣言
        List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private bool startSelect = true;
        private CheckMessageType messageType;
        public CheckMessageType MType
        {
            get { return messageType; }
            set { messageType = value; }
        }
        CommonLogic commonLogic;
        private List<string> selectedKenmeiNos;
        public List<string> SelectedKenmeiNos
        {
            get { return selectedKenmeiNos; }
            set { selectedKenmeiNos = value; }
        }
        private bool flgDispDeletedData = false;
        public bool FlgDispDeletedData
        {
            get { return flgDispDeletedData; }
            set { flgDispDeletedData = value; }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public sfrmKenmeiSearch(bool flgMultiSelect, CheckMessageType checkMessageType)
        {
            InitializeComponent();
            setCommonEvent(this);
            commonLogic = new CommonLogic();
            messageType = checkMessageType;
            SelectedKenmeiNos = new List<string>();
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            txtConstructionNoFrom.Text = string.Empty;
            txtConstructionNoTo.Text = string.Empty;
            txtSubject.Text = string.Empty;
            DialogResult = DialogResult.None;
        }
        #endregion

        #region 戻るボタン押下イベント
        /// <summary>
        /// 戻るボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            closedForm();
        }
        #endregion

        #region 検索一覧グリッド描画イベント
        /// <summary>
        /// 検索一覧グリッド描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSearchList_Paint(object sender, PaintEventArgs e)
        {
            if (flgInitializeGrid)
            {
                if (grdSearchList.Rows.Count > 0) grdSearchList.Rows[0].Selected = false;
                flgInitializeGrid = false;
            }
        }
        #endregion

        #region 単一ラジオ変更イベント
        /// <summary>
        /// 単一ラジオ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoSingle_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = false;
            grdSearchList.MultiSelect = true;
            grdSearchList.MultiSelect = false;
        }
        #endregion

        #region 複数ラジオ変更イベント
        /// <summary>
        /// 複数ラジオ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoMulti_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            grdSearchList.MultiSelect = false;
            grdSearchList.MultiSelect = true;
        }
        #endregion

        #region 範囲ラジオ変更イベント
        /// <summary>
        /// 範囲ラジオ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoRange_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            grdSearchList.MultiSelect = false;
            grdSearchList.MultiSelect = true;
        }
        #endregion

        #region 検索一覧グリッドの選択セル変更イベント
        /// <summary>
        /// 検索一覧グリッドの選択セル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSearchList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (flgSetGridData) return;
            if (rdoMulti.Checked)
            {
                if (!gRows.Contains(grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex])) gRows.Add(grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex]);

                foreach (DataGridViewRow gRow in gRows)
                {
                    gRow.Selected = true;
                }
            }
            else if (rdoRange.Checked)
            {
                if (startSelect)
                {
                    gRows = new List<DataGridViewRow>();
                    gRows.Add(grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex]);
                    startSelect = false;
                }
                else
                {
                    int startRowIndex = 0;
                    int endRowIndex = 0;
                    if (gRows[0].Index == grdSearchList.CurrentCell.RowIndex)
                    {
                        return;
                    }
                    else if (gRows[0].Index > grdSearchList.CurrentCell.RowIndex)
                    {
                        startRowIndex = grdSearchList.CurrentCell.RowIndex;
                        endRowIndex = gRows[0].Index;
                    }
                    else
                    {
                        startRowIndex = gRows[0].Index;
                        endRowIndex = grdSearchList.CurrentCell.RowIndex;
                    }

                    for (int i = startRowIndex; i <= endRowIndex; i++)
                    {
                        grdSearchList.Rows[i].Selected = true;
                    }
                    startSelect = true;
                }
            }
        }
        #endregion

        #region 全選択ボタン押下イベント
        /// <summary>
        /// 全選択ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gRow in grdSearchList.Rows)
            {
                gRow.Selected = true;
            }
        }
        #endregion

        #region 選択解除ボタン押下イベント
        /// <summary>
        /// 選択解除ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCancel_Click(object sender, EventArgs e)
        {
            allSelectionChange(grdSearchList.MultiSelect);
        }
        #endregion

        #region 選択状態変更処理
        /// <summary>
        /// 選択状態変更処理
        /// </summary>
        /// <param name="multiSelect"></param>
        private void allSelectionChange(bool multiSelect)
        {
            grdSearchList.MultiSelect = !multiSelect;
            grdSearchList.MultiSelect = multiSelect;
        }
        #endregion

        #region 検索一覧データ設定処理
        /// <summary>
        /// 検索一覧データ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;

            DBCommon dbCommon = new DBCommon();
            string selectSql = string.Empty;
            selectSql += "SELECT";
            selectSql += "  kenmeiNo";
            selectSql += ", kenmei1 ";
            selectSql += "FROM kenmei_master ";
            selectSql += "WHERE 1 = 1 ";
            // 件名No(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtConstructionNoFrom.Text))
            {
                selectSql += "AND kenmeiNo >= '" + txtConstructionNoFrom.Text + "' ";
            }
            // 件名No(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtConstructionNoTo.Text))
            {
                selectSql += "AND kenmeiNo <= '" + txtConstructionNoTo.Text + "' ";
            }
            // 件名名が入力されている場合
            if (!string.IsNullOrEmpty(txtSubject.Text))
            {
                selectSql += "AND kenmei1 Like '%" + txtSubject.Text + "%' ";
            }
            if(!FlgDispDeletedData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";
            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);

            // 取得データをグリッドに設定
            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }
        #endregion

        #region 検索ボタン押下イベント
        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
        }
        #endregion

        #region 確認ボタン押下イベント
        /// <summary>
        /// 確認ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            selectedKenmeiNos = new List<string>();
            if (grdSearchList.SelectedRows == null || grdSearchList.SelectedRows.Count == 0)
            {
                errorOK(Messages.M0018);
                return;
            }

            switch (messageType)
            {
                case CheckMessageType.inputDataUpdateQuery:
                    if (queryYesNo(string.Format(Messages.M0021)) == DialogResult.No)
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }

            // 選択行情報を格納
            foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
            {
                selectedKenmeiNos.Add(Convert.ToString(gRow.Cells[clmConstructionNo.DisplayIndex].Value));
            }

            DialogResult = DialogResult.OK;
            closedForm();
        }
        #endregion

        #region 件名Noフォーカスアウトイベント
        /// <summary>
        /// 件名Noフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConstructionNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmKenmeiSearch_Load(object sender, EventArgs e)
        {
            setGridData();
        }
        #endregion

        #region 一覧グリッドのセルダブルクリックイベント
        /// <summary>
        /// 一覧グリッドのセルダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSearchList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCheck_Click(null, null);
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
            txtConstructionNoFrom.Text = string.Empty;
            txtConstructionNoTo.Text = string.Empty;
            txtSubject.Text = string.Empty;
        }
        #endregion
    }
}
