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
using Resorce;
using DB;

namespace SubForm
{
    /// <summary>
    /// 商品検索画面
    /// </summary>
    public partial class sfrmShouhinSearch : Common.ChildBaseForm
    {
        #region 変数宣言
        List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private bool startSelect = true;
        private CommonLogic commonLogic;
        private DBMeisyoMaster meisyoMaster;
        private string cmbAllValue = "ALL";
        private string cmbAllText = "全て";
        /// <summary>
        /// 商品情報格納クラス
        /// </summary>
        public class ShouhinInfo
        {
            private string shireCode = string.Empty;
            private string topClassification = string.Empty;
            private string btmClassification = string.Empty;
            private string shouhinNo = string.Empty;
            public string ShireCode
            {
                get { return shireCode; }
                set { shireCode = value; }
            }
            public string TopClassification
            {
                get { return topClassification; }
                set { topClassification = value; }
            }
            public string BtmClassification
            {
                get { return btmClassification; }
                set { btmClassification = value; }
            }
            public string ShouhinNo
            {
                get { return shouhinNo; }
                set { shouhinNo = value; }
            }

            public ShouhinInfo(string sCode, string tCode, string bCode, string sNo)
            {
                ShireCode = sCode;
                TopClassification = tCode;
                BtmClassification = bCode;
                ShouhinNo = sNo;
            }

        }
        private List<ShouhinInfo> selectedItemCodes;
        public List<ShouhinInfo> SelectedItemCodes
        {
            get { return selectedItemCodes; }
            set { selectedItemCodes = value; }
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
        public sfrmShouhinSearch(bool flgMultiSelect)
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            meisyoMaster = new DBMeisyoMaster();
            setContorolLayout(this);
            SelectedItemCodes = new List<ShouhinInfo>();
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            setClassificationCodeCmb();
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtVendorKanaName.Text = string.Empty;
            txtItemNo.Text = string.Empty;
            txtItemName.Text = string.Empty;

            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
        }
        #endregion

        #region 
        /// <summary>
        /// グリッドの選択状態変更
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
            selectSql += "  shiresakim.shiresakiName";
            selectSql += ", shouninm.shouhinCode AS shouhinCode ";
            selectSql += ", shouninm.shouhinName ";
            selectSql += ", shouninm.shireCode ";
            selectSql += ", shouninm.topClassification ";
            selectSql += ", shouninm.btmClassification ";
            selectSql += ", shouninm.shouhinCode AS shouhinNo ";
            selectSql += "FROM shouhin_master shouninm ";
            selectSql += "LEFT JOIN shiresaki_master shiresakim ";
            selectSql += "ON(shouninm.shireCode = shiresakim.shiresakiCode) ";
            selectSql += "WHERE 1 = 1 ";


            // 仕入先ｺｰﾄﾞが入力されている場合
            if (!string.IsNullOrEmpty(txtVendorCode.Text))
            {
                selectSql += "AND shiresakim.shiresakiCode = '" + txtVendorCode.Text + "' ";
            }
            // 仕入先名が入力されている場合
            if (!string.IsNullOrEmpty(txtVendorName.Text))
            {
                selectSql += "AND shiresakim.shiresakiName LIKE '%" + txtVendorName.Text + "%' ";
            }
            // 仕入先カナ名が入力されている場合
            if (!string.IsNullOrEmpty(txtVendorKanaName.Text))
            {
                selectSql += "AND shiresakim.shiresakiKanaName LIKE '%" + txtVendorKanaName.Text + "%' ";
            }
            // 分類コードが入力されている場合
            if (!cmbAllValue.Equals(Convert.ToString(cmbClassificationCode.SelectedValue)))
            {
                selectSql += "AND shouninm.topClassification = '" + Convert.ToString(cmbClassificationCode.SelectedValue) + "' ";
            }
            // 商品連番が入力されている場合
            if (!string.IsNullOrEmpty(txtItemNo.Text))
            {
                selectSql += "AND shouninm.shouhinCode = '" + txtItemNo.Text + "' ";
            }
            // 商品名が入力されている場合
            if (!string.IsNullOrEmpty(txtItemName.Text))
            {
                selectSql += "AND shouninm.shouhinName LIKE '%" + txtItemName.Text + "%' ";
            }
            if (!FlgDispDeletedData)
            {
                selectSql += "AND (shouninm.kanriKubun IS NULL OR shouninm.kanriKubun <> '9') ";
            }

            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);

            // 取得データをグリッドに設定
            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }
        #endregion

        #region 戻るボタン押下イベント
        private void btnBack_Click(object sender, EventArgs e)
        {
            closedForm();
        }
        #endregion

        #region グリッド描画イベント
        private void grdSearchList_Paint(object sender, PaintEventArgs e)
        {
            if (flgInitializeGrid && grdSearchList.Rows.Count > 0)
            {
                if (grdSearchList.Rows.Count > 0) grdSearchList.Rows[0].Selected = false;
                flgInitializeGrid = false;
            }
        }
        #endregion

        #region 単一ラジオ変更イベント
        private void rdoSingle_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = false;
            grdSearchList.MultiSelect = true;
            grdSearchList.MultiSelect = false;
        }
        #endregion

        #region 複数ラジオ変更イベント
        private void rdoMulti_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            grdSearchList.MultiSelect = false;
            grdSearchList.MultiSelect = true;
        }
        #endregion

        #region 範囲ラジオ変更イベント
        private void rdoRange_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            grdSearchList.MultiSelect = false;
            grdSearchList.MultiSelect = true;
        }
        #endregion

        #region グリッドセル選択状態変更イベント
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
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gRow in grdSearchList.Rows)
            {
                gRow.Selected = true;
            }
        }
        #endregion

        #region 選択解除ボタン押下イベント
        private void btnSelectCancel_Click(object sender, EventArgs e)
        {
            allSelectionChange(grdSearchList.MultiSelect);
        }
        #endregion

        #region 検索ボタン押下イベント
        private void btnSearch_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
        }
        #endregion

        #region 確認ボタン押下イベント
        private void btnCheck_Click(object sender, EventArgs e)
        {
            SelectedItemCodes = new List<ShouhinInfo>();
            if (grdSearchList.SelectedRows == null || grdSearchList.SelectedRows.Count == 0)
            {
                errorOK(Messages.M0018);
                return;
            }

            // 選択行情報を格納
            foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
            {
                SelectedItemCodes.Add(new ShouhinInfo(Convert.ToString(gRow.Cells[clmVendorCode.Name].Value)
                                                    , Convert.ToString(gRow.Cells[clmTopClassification.Name].Value)
                                                    , Convert.ToString(gRow.Cells[clmBtmClassification.Name].Value)
                                                    , Convert.ToString(gRow.Cells[clmItemNo.Name].Value)));
            }

            DialogResult = DialogResult.OK;
            closedForm();
        }
        #endregion

        #region 0埋め項目のフォーカスアウトイベント
        private void txtZeroBuried_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = commonLogic.getZeroBuriedNumberText(textBox.Text, textBox.MaxLength);
        }
        #endregion

        #region 分類区分コードコンボボックスの設定
        /// <summary>
        /// 分類区分コードコンボボックスの設定
        /// </summary>
        private void setClassificationCodeCmb()
        {
            // 分類区分名取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE007);
            DataRow newRow = meisyoDt.NewRow();
            meisyoDt.Rows.InsertAt(newRow, 0);
            meisyoDt.Rows[0][DBFileLayout.MeisyoMasterFile.dcKubun] = cmbAllValue;
            meisyoDt.Rows[0][DBFileLayout.MeisyoMasterFile.dcKubunName] = cmbAllText;
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbClassificationCode, meisyoDt, DBFileLayout.MeisyoMasterFile.dcKubun, DBFileLayout.MeisyoMasterFile.dcKubunName);
        }
        #endregion

        #region 画面起動時のイベント
        /// <summary>
        /// 画面起動時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmShouhinSearch_Load(object sender, EventArgs e)
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
            setClassificationCodeCmb();
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtVendorKanaName.Text = string.Empty;
            txtItemNo.Text = string.Empty;
            txtItemName.Text = string.Empty;
        }
        #endregion
    }
}
