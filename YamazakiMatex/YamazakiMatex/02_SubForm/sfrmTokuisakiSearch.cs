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
    /// 得意先検索画面
    /// </summary>
    public partial class sfrmTokuisakiSearch : Common.ChildBaseForm
    {
        List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private bool startSelect = true;
        private bool flgDispDeletedData = false;
        CommonLogic commonLogic = new CommonLogic();
        DBMeisyoMaster meisyoMaster;
        DBTantousyaMaster tantousyaMaster;
        public class TokuisakiInfo
        {
            private string tokuisakiCode = string.Empty;
            private string jigyousyoCode = string.Empty;
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }

            public TokuisakiInfo(string tCode, string jCode)
            {
                TokuisakiCode = tCode;
                JigyousyoCode = jCode;
            }

        }
        private List<TokuisakiInfo> selectedTokuisakiInfos;
        public List<TokuisakiInfo> SelectedTokuisakiInfos
        {
            get { return selectedTokuisakiInfos; }
            set { selectedTokuisakiInfos = value; }
        }
        public bool FlgDispDeletedData
        {
            get { return flgDispDeletedData; }
            set { flgDispDeletedData = value; }
        }
        public sfrmTokuisakiSearch(bool flgMultiSelect)
        {
            InitializeComponent();
            setContorolLayout(this);
            selectedTokuisakiInfos = new List<TokuisakiInfo>();
            meisyoMaster = new DBMeisyoMaster();
            tantousyaMaster = new DBTantousyaMaster();

            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            // 都道府県コンボボックス設定
            setPrefectureCmb();
            // 担当者コンボボックス設定
            setPersonnelCmb();
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            DialogResult = DialogResult.None;

            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }

        /// <summary>
        /// 都道府県コンボボックスの設定
        /// </summary>
        private void setPrefectureCmb()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(commonLogic.StrCmbKey, Type.GetType("System.String"));
            dt.Columns.Add(commonLogic.StrCmbValue, Type.GetType("System.String"));

            // 都道府県取得
            List<DBFileLayout.MeisyoMasterFile> meisyoList = meisyoMaster.getMeisyoInfo(Consts.MeisyoCode.CODE004);
            dt.Rows.Add(new object[] { "dm", "" });
            foreach (DBFileLayout.MeisyoMasterFile meisyo in meisyoList)
            {
                dt.Rows.Add(new object[] { meisyo.Kubun, meisyo.KubunName });
            }

            // 取得データをコンボボックスのDataSourceへ設定
            cmbPrefecture.DataSource = dt;
            cmbPrefecture.ValueMember = commonLogic.StrCmbKey;
            cmbPrefecture.DisplayMember = commonLogic.StrCmbValue;
            cmbPrefecture.SelectedIndex = -1;
        }

        /// <summary>
        /// 担当者コンボボックスの設定
        /// </summary>
        private void setPersonnelCmb()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(commonLogic.StrCmbKey, Type.GetType("System.String"));
            dt.Columns.Add(commonLogic.StrCmbValue, Type.GetType("System.String"));
            // 担当者取得
            DataTable tantousyaDt = tantousyaMaster.getTantousyaDataTable(string.Empty, string.Empty);
            dt.Rows.Add(new object[] { "dm", "" });
            foreach (DataRow row in tantousyaDt.Rows)
            {
                dt.Rows.Add(new object[] { Convert.ToString(row["tantousyaCode"]), Convert.ToString(row["tantousyaName"]) });
            }

            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPersonnel, tantousyaDt, "tantousyaCode", "tantousyaName");

            // 取得データをコンボボックスのDataSourceへ設定
            cmbPersonnel.DataSource = dt;
            cmbPersonnel.ValueMember = commonLogic.StrCmbKey;
            cmbPersonnel.DisplayMember = commonLogic.StrCmbValue;
            cmbPersonnel.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            closedForm();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = false;
            allSelectionChange(false);
            gRows = new List<DataGridViewRow>();
            startSelect = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            allSelectionChange(true);
            gRows = new List<DataGridViewRow>();
            startSelect = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            allSelectionChange(true);
            gRows = new List<DataGridViewRow>();
            startSelect = true;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (flgInitializeGrid)
            {
                if (grdSearchList.Rows.Count > 0) grdSearchList.Rows[0].Selected = false;
                flgInitializeGrid = false;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gRow in grdSearchList.Rows)
            {
                gRow.Selected = true;
            }
        }

        private void btnSelectCancel_Click(object sender, EventArgs e)
        {
            allSelectionChange(grdSearchList.MultiSelect);
        }

        private void allSelectionChange(bool multiSelect)
        {
            grdSearchList.MultiSelect = !multiSelect;
            grdSearchList.MultiSelect = multiSelect;
        }

        private void setGridData()
        {
            flgSetGridData = true;

            DBCommon dbCommon = new DBCommon();
            string selectSql = string.Empty;
            selectSql += "SELECT";
            selectSql += "  tokuisakiCode";
            selectSql += ", tokuisakiName ";
            selectSql += ", jigyousyoName ";
            selectSql += ", '' AS busyoName ";
            selectSql += ", tokuisakiTantousyaName ";
            selectSql += ", jigyousyoCode ";
            selectSql += "FROM tokuisaki_master ";
            selectSql += "WHERE 1 = 1 ";
            // 都道府県コンボボックスが選択されている場合
            if (!string.IsNullOrEmpty(cmbPrefecture.Text))
            {
                string prefectureCode = "";
                var query = ((DataTable)cmbPrefecture.DataSource).AsEnumerable().Where(p => p.Field<string>(commonLogic.StrCmbValue) == cmbPrefecture.Text);
                if (query.Count() > 0) prefectureCode = Convert.ToString(query.ElementAt(0)[commonLogic.StrCmbKey]);
                selectSql += "AND chikuCode = '" + prefectureCode + "' ";
            }
            // 担当者コンボボックスが選択されている場合
            if (!string.IsNullOrEmpty(cmbPersonnel.Text))
            {
                string personnelCode = "";
                var query = ((DataTable)cmbPersonnel.DataSource).AsEnumerable().Where(p => p.Field<string>(commonLogic.StrCmbValue) == cmbPersonnel.Text);
                if (query.Count() > 0) personnelCode = Convert.ToString(query.ElementAt(0)[commonLogic.StrCmbKey]);
                selectSql += "AND tantousyaCode = '" + personnelCode + "' ";
            }
            // 得意先ｺｰﾄﾞが入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                selectSql += "AND tokuisakiCode = '" + txtCustomerCode.Text + "' ";
            }
            // 得意先漢字名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                selectSql += "AND tokuisakiName LIKE '%" + txtCustomerName.Text + "%' ";
            }
            // 得意先カナ名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerKanaName.Text))
            {
                selectSql += "AND tokuisakiKanaName LIKE '%" + txtCustomerKanaName.Text + "%' ";
            }
            if (!FlgDispDeletedData)
            {
                selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";
            }

            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);

            // 取得データをグリッドに設定
            grdSearchList.DataSource = dt;

            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flgSetGridData) return;
            if (rdoMulti.Checked)
            {
                DataGridViewRow currentgRow = grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex];
                if (!gRows.Contains(currentgRow)) gRows.Add(currentgRow);

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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SelectedTokuisakiInfos = new List<TokuisakiInfo>();
            if (grdSearchList.SelectedRows == null || grdSearchList.SelectedRows.Count == 0)
            {
                messageOK(Messages.M0018);
                return;
            }

            // 選択行情報を格納
            foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
            {
                SelectedTokuisakiInfos.Add(new TokuisakiInfo(Convert.ToString(gRow.Cells[clmCustomerCode.DisplayIndex].Value),
                                                             Convert.ToString(gRow.Cells[clmOfficesCode.DisplayIndex].Value)));
            }
            DialogResult = DialogResult.OK;
            closedForm();
        }

        private void cmb_Leave(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (cmb.SelectedIndex >= 0) return;

            DataTable dt = (DataTable)cmbPrefecture.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToString(dt.Rows[i][commonLogic.StrCmbValue]).Equals(cmb.Text))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            int customerCode = 0;

            if (int.TryParse(txtCustomerCode.Text, out customerCode))
            {
                txtCustomerCode.Text = customerCode.ToString("00000");
            }
        }

        private void sfrmTokuisakiSearch_Load(object sender, EventArgs e)
        {
            setGridData();
        }

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
            // 都道府県コンボボックス設定
            setPrefectureCmb();
            // 担当者コンボボックス設定
            setPersonnelCmb();
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
        }
        #endregion
    }
}
