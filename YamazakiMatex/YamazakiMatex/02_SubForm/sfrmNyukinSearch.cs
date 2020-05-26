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
    /// 入金検索画面
    /// </summary>
    public partial class sfrmNyukinSearch : ChildBaseForm
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
        public class SelectedNyukinInfo
        {
            #region 変数宣言
            /// <summary>
            /// 入金No
            /// </summary>
            private string nyukinNo;
            #endregion

            #region データの取得・設定
            /// <summary>
            /// 入金Noの取得・設定
            /// </summary>
            public string NyukinNo
            {
                get { return nyukinNo; }
                set { nyukinNo = value; }
            }
            #endregion
        }
        private List<SelectedNyukinInfo> selectedNyukinInfos;
        public List<SelectedNyukinInfo> SelectedNyukinInfos
        {
            get { return selectedNyukinInfos; }
            set { selectedNyukinInfos = value; }
        }
        private enum LastInputDateType
        {
            None = 0
          , DepositDateFrom = 1
          , DepositDateTo = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        CommonLogic commonLogic;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public sfrmNyukinSearch(bool flgMultiSelect, CheckMessageType checkMessageType)
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            SelectedNyukinInfos = new List<SelectedNyukinInfo>();
            messageType = checkMessageType;
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            DateTime defaultDate = Convert.ToDateTime("1900/1/1");
            txtDepositNoFrom.Text = string.Empty;
            txtDepositNoTo.Text = string.Empty;
            dtpDepositDateFrom.Value = defaultDate;
            txtDepositDateFromYears.Text = string.Empty;
            txtDepositDateFromMonth.Text = string.Empty;
            txtDepositDateFromDays.Text = string.Empty;
            dtpDepositDateTo.Value = defaultDate;
            txtDepositDateToYears.Text = string.Empty;
            txtDepositDateToMonth.Text = string.Empty;
            txtDepositDateToDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            setGridData();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmNyukinSearch_Load(object sender, EventArgs e)
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
            DateTime defaultDate = Convert.ToDateTime("1900/1/1");
            txtDepositNoFrom.Text = string.Empty;
            txtDepositNoTo.Text = string.Empty;
            dtpDepositDateFrom.Value = defaultDate;
            txtDepositDateFromYears.Text = string.Empty;
            txtDepositDateFromMonth.Text = string.Empty;
            txtDepositDateFromDays.Text = string.Empty;
            dtpDepositDateTo.Value = defaultDate;
            txtDepositDateToYears.Text = string.Empty;
            txtDepositDateToMonth.Text = string.Empty;
            txtDepositDateToDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
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

        #region 単一ラジオ選択イベント
        /// <summary>
        /// 単一ラジオ選択イベント
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

        #region 複数ラジオ選択イベント
        /// <summary>
        /// 複数ラジオ選択イベント
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

        #region 範囲ラジオ選択イベント
        /// <summary>
        /// 範囲ラジオ選択イベント
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

        #region 一覧グリッドの選択セル変更イベント
        /// <summary>
        /// 一覧グリッドの選択セル変更イベント
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

        #region 画面入力項目のフォーカスインイベント
        /// <summary>
        /// 画面入力項目のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputObject_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (!(c is TextBox || c is ComboBox || c is DateTimePicker))
            {
                return;
            }

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;

                switch (lastInputDateType)
                {
                    case LastInputDateType.DepositDateFrom:
                        y = txtDepositDateFromYears.Text;
                        m = txtDepositDateFromMonth.Text;
                        d = txtDepositDateFromDays.Text;
                        break;
                    case LastInputDateType.DepositDateTo:
                        y = txtDepositDateToYears.Text;
                        m = txtDepositDateToMonth.Text;
                        d = txtDepositDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.DepositDateFrom.Equals(lastInputDateType))
                    {
                        txtDepositDateFromYears.Focus();
                    }
                    else if (LastInputDateType.DepositDateTo.Equals(lastInputDateType))
                    {
                        txtDepositDateToYears.Focus();
                    }
                    return;
                }
            }
        }
        #endregion

        #region 入金日付(FROM)フォーカスインイベント
        /// <summary>
        /// 入金日付(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepositDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DepositDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 入金日付(TO)フォーカスインイベント
        /// <summary>
        /// 入金日付(TO)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepositDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DepositDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 入金日付(FROM)フォーカスアウトイベント
        /// <summary>
        /// 入金日付(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepositDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DepositDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DepositDateFrom;
            }
        }
        #endregion

        #region 入金日付(TO)フォーカスアウトイベント
        /// <summary>
        /// 入金日付(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepositDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DepositDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DepositDateTo;
            }
        }
        #endregion

        #region No項目フォーカスアウトイベント
        /// <summary>
        /// No項目フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNoInput_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.Text = commonLogic.getZeroBuriedNumberText(control.Text, control.MaxLength);
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

        #region 確認ボタン押下イベント
        /// <summary>
        /// 確認ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            SelectedNyukinInfos = new List<SelectedNyukinInfo>();
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

            SelectedNyukinInfo wkSelectedNyukinInfo;
            // 選択行情報を格納
            foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
            {
                wkSelectedNyukinInfo = new SelectedNyukinInfo();
                wkSelectedNyukinInfo.NyukinNo = Convert.ToString(gRow.Cells[clmDepositNo.DisplayIndex].Value);
                SelectedNyukinInfos.Add(wkSelectedNyukinInfo);
            }

            DialogResult = DialogResult.OK;
            closedForm();
        }
        #endregion

        #endregion

        #region ビジネスロジック

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

        #region 一覧グリッドデータ設定処理
        /// <summary>
        /// 一覧グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;

            DBCommon dbCommon = new DBCommon();
            string selectSql = string.Empty;
            selectSql += "SELECT";
            selectSql += "  nyukinNo";
            selectSql += ", nyukinHizuke ";
            selectSql += ", tokuisakiName ";
            selectSql += ", jigyousyoName ";
            selectSql += "FROM nyukin ";
            selectSql += "WHERE 1 = 1 ";
            // 入金No(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtDepositNoFrom.Text))
            {
                selectSql += "AND nyukinNo >= '" + txtDepositNoFrom.Text + "' ";
            }
            // 入金No(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtDepositNoTo.Text))
            {
                selectSql += "AND nyukinNo <= '" + txtDepositNoTo.Text + "' ";
            }
            // 入金日付(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtDepositDateFromYears.Text) &&
                !string.IsNullOrEmpty(txtDepositDateFromMonth.Text) &&
                !string.IsNullOrEmpty(txtDepositDateFromDays.Text))
            {
                string depositDateFrom = txtDepositDateFromYears.Text;
                depositDateFrom += "/" + txtDepositDateFromMonth.Text;
                depositDateFrom += "/" + txtDepositDateFromDays.Text;
                selectSql += "AND nyukinHizuke >= '" + depositDateFrom + "' ";
            }
            // 入金日付(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtDepositDateToYears.Text) &&
                !string.IsNullOrEmpty(txtDepositDateToMonth.Text) &&
                !string.IsNullOrEmpty(txtDepositDateToDays.Text))
            {
                string depositDateTo = txtDepositDateToYears.Text;
                depositDateTo += "/" + txtDepositDateToMonth.Text;
                depositDateTo += "/" + txtDepositDateToDays.Text;
                selectSql += "AND nyukinHizuke <= '" + depositDateTo + "' ";
            }
            // 得意先コードが入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                selectSql += "AND tokuisakiCode = '" + txtCustomerCode.Text + "' ";
            }
            // 得意先名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                selectSql += "AND tokuisakiName Like '%" + txtCustomerName.Text + "%' ";
            }
            // 得意先カナ名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerKanaName.Text))
            {
                selectSql += "AND tokuisakiKanaName Like '%" + txtCustomerKanaName.Text + "%' ";
            }
            selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";
            if (rdoAsc.Checked)
            {
                selectSql += "ORDER BY nyukinHizuke, nyukinNo ";
            }
            else
            {
                selectSql += "ORDER BY nyukinHizuke DESC, nyukinNo DESC ";
            }
            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);

            // 取得データをグリッドに設定
            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }
        #endregion

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // 伝票Noまたは受注Noの場合
            if (c.Name.Equals(txtDepositNoFrom.Name) ||
                c.Name.Equals(txtDepositNoTo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtNoInput_Leave);
            }
            // 伝票日付Fromの場合
            else if (c.Name.Equals(txtDepositDateFromYears.Name) ||
                     c.Name.Equals(txtDepositDateFromMonth.Name) ||
                     c.Name.Equals(txtDepositDateFromDays.Name) ||
                     c.Name.Equals(dtpDepositDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtDepositDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDepositDateFrom_Leave);
            }
            // 伝票日付Toの場合
            else if (c.Name.Equals(txtDepositDateToYears.Name) ||
                     c.Name.Equals(txtDepositDateToMonth.Name) ||
                     c.Name.Equals(txtDepositDateToDays.Name) ||
                     c.Name.Equals(dtpDepositDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtDepositDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDepositDateTo_Leave);
            }

            // 検索ボタンでない場合
            if (!c.Name.Equals(btnSearch.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(inputObject_Enter);
            }

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

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
            {
                ret = true;
            }
            else
            {
                DateTime date;

                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
            }
            return ret;
        }
        #endregion

        #endregion
    }
}
