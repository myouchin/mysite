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
    /// 仕入先検索画面
    /// </summary>
    public partial class sfrmShiiresakiSearch : Common.ChildBaseForm
    {
        #region 変数宣言
        List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private bool startSelect = true;
        private List<string> selectedShiresakiCodes;
        private CheckMessageType messagerType;
        public List<string> SelectedShiresakiCodes
        {
            get { return selectedShiresakiCodes; }
            set { selectedShiresakiCodes = value; }
        }
        private CommonLogic commonLogic;
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
        public sfrmShiiresakiSearch(bool flgMultiSelect, CheckMessageType checkMessageType)
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            selectedShiresakiCodes = new List<string>();
            messagerType = checkMessageType;
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            // 検索条件初期化処理
            initializeSearchConditions();
            DialogResult = DialogResult.None;

            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmShiiresakiSearch_Load(object sender, EventArgs e)
        {
            setGridData();
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
            // 検索条件初期化処理
            initializeSearchConditions();
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

        #region 一覧グリッド描画イベント
        /// <summary>
        /// 一覧グリッド描画イベント
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

        #region 単一ラジオボタン変更イベント
        /// <summary>
        /// 単一ラジオボタン変更イベント
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

        #region 複数ラジオボタン変更イベント
        /// <summary>
        /// 複数ラジオボタン変更イベント
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

        #region 範囲ラジオボタン変更イベント
        /// <summary>
        /// 範囲ラジオボタン変更イベント
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

        #region 選択セル変更イベント
        /// <summary>
        /// 選択セル変更イベント
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

        #region グリッドデータ設定処理
        /// <summary>
        /// グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;

            DBCommon dbCommon = new DBCommon();
            string selectSql = string.Empty;
            selectSql += "SELECT";
            selectSql += "  sm.shiresakiCode";
            selectSql += ", sm.shiresakiName ";
            selectSql += ", sm.shiresakiKanaName ";
            selectSql += ", mm1.kubunName AS shimebi ";
            selectSql += ", mm2.kubunName AS shiharaiSaito ";
            selectSql += "FROM (SELECT * FROM shiresaki_master) sm ";
            selectSql += "LEFT JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '006') mm1 ";
            selectSql += "ON (sm.shimebi = mm1.kubun) ";
            selectSql += "LEFT JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '013') mm2 ";
            selectSql += "ON (sm.shiharaiSaito = mm2.kubun) ";
            selectSql += "WHERE 1 = 1 ";
            // 仕入先ｺｰﾄﾞが入力されている場合
            if (!string.IsNullOrEmpty(txtVendorCode.Text))
            {
                selectSql += "AND sm.shiresakiCode = '" + txtVendorCode.Text + "'";
            }
            // 仕入先名が入力されている場合
            if (!string.IsNullOrEmpty(txtVendorName.Text))
            {
                selectSql += "AND sm.shiresakiName LIKE '%" + txtVendorName.Text + "%'";
            }
            // 仕入先カナ名が入力されている場合
            if (!string.IsNullOrEmpty(txtVendorKanaName.Text))
            {
                selectSql += "AND sm.shiresakiKanaName LIKE '%" + txtVendorKanaName.Text + "%'";
            }
            if (!FlgDispDeletedData)
            {
                selectSql += "AND (sm.kanriKubun IS NULL OR sm.kanriKubun <> '9') ";
            }

            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);
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
            selectedShiresakiCodes = new List<string>();
            if (grdSearchList.SelectedRows == null || grdSearchList.SelectedRows.Count == 0)
            {
                errorOK(Messages.M0018);
                return;
            }

            switch (messagerType)
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
                selectedShiresakiCodes.Add(Convert.ToString(gRow.Cells[clmVendorCode.DisplayIndex].Value));
            }

            DialogResult = DialogResult.OK;
            closedForm();
        }
        #endregion

        #region 検索条件初期化処理
        private void initializeSearchConditions()
        {
            // 初期値設定
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtVendorKanaName.Text = string.Empty;

            // 最大入力値設定
            txtVendorCode.MaxLength = 3;
            txtVendorName.MaxLength = 15;
            txtVendorKanaName.MaxLength = 30;

            // フォーカスインイベント追加
            txtVendorCode.Enter -= new EventHandler(txtBox_Enter);
            txtVendorName.Enter -= new EventHandler(txtBox_Enter);
            txtVendorKanaName.Enter -= new EventHandler(txtBox_Enter);
            txtVendorCode.Enter += new EventHandler(txtBox_Enter);
            txtVendorName.Enter += new EventHandler(txtBox_Enter);
            txtVendorKanaName.Enter += new EventHandler(txtBox_Enter);

        }
        #endregion

        #region 仕入先ｺｰﾄﾞのフォーカスアウトイベント
        /// <summary>
        /// 仕入先ｺｰﾄﾞのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.Text = commonLogic.getZeroBuriedNumberText(control.Text, control.MaxLength);
        }
        #endregion

        #region テキストボックスのフォーカスインイベント
        /// <summary>
        /// テキストボックスのフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_Enter(object sender, EventArgs e)
        {
            if (grdSearchList.Rows.Count > 0 && grdSearchList.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
                {
                    gRow.Selected = false;
                }
            }
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
    }
}
