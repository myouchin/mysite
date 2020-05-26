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
    /// 受注検索画面
    /// </summary>
    public partial class sfrmJuchuSearch : ChildBaseForm
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
        public class SelectedJuchuInfo
        {
            #region 変数宣言
            /// <summary>
            /// 伝票No
            /// </summary>
            private string documentNo;
            /// <summary>
            /// 受注No
            /// </summary>
            private string ordersNo;
            #endregion

            #region データの取得・設定
            /// <summary>
            /// 伝票Noの取得・設定
            /// </summary>
            public string DocumentNo
            {
                get { return documentNo; }
                set { documentNo = value; }
            }

            /// <summary>
            /// 受注Noの取得・設定
            /// </summary>
            public string OrdersNo
            {
                get { return ordersNo; }
                set { ordersNo = value; }
            }
            #endregion
        }
        private List<SelectedJuchuInfo> selectedJuchuInfos;
        public List<SelectedJuchuInfo> SelectedJuchuInfos
        {
            get { return selectedJuchuInfos; }
            set { selectedJuchuInfos = value; }
        }
        private enum LastInputDateType
        {
            None = 0
          , DocumentDateFrom = 1
          , DocumentDateTo = 2
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
        public sfrmJuchuSearch(bool flgMultiSelect, CheckMessageType checkMessageType)
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            SelectedJuchuInfos = new List<SelectedJuchuInfo>();
            messageType = checkMessageType;
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            DateTime defaultDate = Convert.ToDateTime("1900/1/1");
            txtDocumentNoFrom.Text = string.Empty;
            txtDocumentNoTo.Text = string.Empty;
            txtOrdersNoFromTop.Text = string.Empty;
            txtOrdersNoFromMid.Text = string.Empty;
            txtOrdersNoFromBtm.Text = string.Empty;
            txtOrdersNoToTop.Text = string.Empty;
            txtOrdersNoToMid.Text = string.Empty;
            txtOrdersNoToBtm.Text = string.Empty;
            dtpDocumentDateFrom.Value = defaultDate;
            txtDocumentDateFromYears.Text = string.Empty;
            txtDocumentDateFromMonth.Text = string.Empty;
            txtDocumentDateFromDays.Text = string.Empty;
            dtpDocumentDateTo.Value = defaultDate;
            txtDocumentDateToYears.Text = string.Empty;
            txtDocumentDateToMonth.Text = string.Empty;
            txtDocumentDateToDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);            // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmJuchuSearch_Load(object sender, EventArgs e)
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
            txtDocumentNoFrom.Text = string.Empty;
            txtDocumentNoTo.Text = string.Empty;
            txtOrdersNoFromTop.Text = string.Empty;
            txtOrdersNoFromMid.Text = string.Empty;
            txtOrdersNoFromBtm.Text = string.Empty;
            txtOrdersNoToTop.Text = string.Empty;
            txtOrdersNoToMid.Text = string.Empty;
            txtOrdersNoToBtm.Text = string.Empty;
            dtpDocumentDateFrom.Value = defaultDate;
            txtDocumentDateFromYears.Text = string.Empty;
            txtDocumentDateFromMonth.Text = string.Empty;
            txtDocumentDateFromDays.Text = string.Empty;
            dtpDocumentDateTo.Value = defaultDate;
            txtDocumentDateToYears.Text = string.Empty;
            txtDocumentDateToMonth.Text = string.Empty;
            txtDocumentDateToDays.Text = string.Empty;
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
                    case LastInputDateType.DocumentDateFrom:
                        y = txtDocumentDateFromYears.Text;
                        m = txtDocumentDateFromMonth.Text;
                        d = txtDocumentDateFromDays.Text;
                        break;
                    case LastInputDateType.DocumentDateTo:
                        y = txtDocumentDateToYears.Text;
                        m = txtDocumentDateToMonth.Text;
                        d = txtDocumentDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.DocumentDateFrom.Equals(lastInputDateType))
                    {
                        txtDocumentDateFromYears.Focus();
                    }
                    else if (LastInputDateType.DocumentDateTo.Equals(lastInputDateType))
                    {
                        txtDocumentDateToYears.Focus();
                    }
                    return;
                }
            }
        }
        #endregion

        #region 伝票日付(FROM)フォーカスインイベント
        /// <summary>
        /// 伝票日付(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DocumentDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 伝票日付(TO)フォーカスインイベント
        /// <summary>
        /// 伝票日付(TO)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DocumentDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 伝票日付(FROM)フォーカスアウトイベント
        /// <summary>
        /// 伝票日付(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DocumentDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DocumentDateFrom;
            }
        }
        #endregion

        #region 伝票日付(TO)フォーカスアウトイベント
        /// <summary>
        /// 伝票日付(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DocumentDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DocumentDateTo;
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
            SelectedJuchuInfos = new List<SelectedJuchuInfo>();
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

            SelectedJuchuInfo wkSelectedJchuInfo;
            // 選択行情報を格納
            foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
            {
                wkSelectedJchuInfo = new SelectedJuchuInfo();
                wkSelectedJchuInfo.DocumentNo = Convert.ToString(gRow.Cells[clmDocumentNo.DisplayIndex].Value);
                wkSelectedJchuInfo.OrdersNo = Convert.ToString(gRow.Cells[clmOrdersNo.DisplayIndex].Value);
                SelectedJuchuInfos.Add(wkSelectedJchuInfo);
            }

            DialogResult = DialogResult.OK;
            closedForm();
        }
        #endregion

        #endregion

        #region ビジネスロジック
        /// <summary>
        /// 選択状態変更処理
        /// </summary>
        /// <param name="multiSelect"></param>
        private void allSelectionChange(bool multiSelect)
        {
            grdSearchList.MultiSelect = !multiSelect;
            grdSearchList.MultiSelect = multiSelect;
        }

        /// <summary>
        /// 一覧グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;

            DBCommon dbCommon = new DBCommon();
            string selectSql = string.Empty;
            selectSql += "SELECT";
            selectSql += "  denpyoNo";
            selectSql += ", denpyoHizuke ";
            selectSql += ", CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) AS juchuNo ";
            selectSql += ", tokuisakiName ";
            selectSql += ", jigyousyoName ";
            selectSql += ", kenmei1 ";
            selectSql += "FROM juchu_header ";
            selectSql += "WHERE 1 = 1 ";
            // 伝票No(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtDocumentNoFrom.Text))
            {
                selectSql += "AND denpyoNo >= '" + txtDocumentNoFrom.Text + "' ";
            }
            // 伝票No(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtDocumentNoTo.Text))
            {
                selectSql += "AND denpyoNo <= '" + txtDocumentNoTo.Text + "' ";
            }
            // 伝票日付(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtDocumentDateFromYears.Text) &&
                !string.IsNullOrEmpty(txtDocumentDateFromMonth.Text) &&
                !string.IsNullOrEmpty(txtDocumentDateFromDays.Text))
            {
                string estimateDateFrom = txtDocumentDateFromYears.Text;
                estimateDateFrom += "/" + txtDocumentDateFromMonth.Text;
                estimateDateFrom += "/" + txtDocumentDateFromDays.Text;
                selectSql += "AND denpyoHizuke >= '" + estimateDateFrom + "' ";
            }
            // 伝票日付(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtDocumentDateToYears.Text) &&
                !string.IsNullOrEmpty(txtDocumentDateToMonth.Text) &&
                !string.IsNullOrEmpty(txtDocumentDateToDays.Text))
            {
                string estimateDateTo = txtDocumentDateToYears.Text;
                estimateDateTo += "/" + txtDocumentDateToMonth.Text;
                estimateDateTo += "/" + txtDocumentDateToDays.Text;
                selectSql += "AND denpyoHizuke <= '" + estimateDateTo + "' ";
            }
            // 受注No(FROM)(上3桁)が入力されている場合
            if (!string.IsNullOrEmpty(txtOrdersNoFromTop.Text))
            {
                selectSql += "AND juchuNoTop >= '" + txtOrdersNoFromTop.Text + "' ";
            }
            // 受注No(FROM)(中2桁)が入力されている場合
            if (!string.IsNullOrEmpty(txtOrdersNoFromMid.Text))
            {
                selectSql += "AND juchuNoMid >= '" + txtOrdersNoFromMid.Text + "' ";
            }
            // 受注No(FROM)(下5桁)が入力されている場合
            if (!string.IsNullOrEmpty(txtOrdersNoFromBtm.Text))
            {
                selectSql += "AND juchuNoBtm >= '" + txtOrdersNoFromBtm.Text + "' ";
            }
            // 受注No(FROM)(上3桁)が入力されている場合
            if (!string.IsNullOrEmpty(txtOrdersNoToTop.Text))
            {
                selectSql += "AND juchuNoTop <= '" + txtOrdersNoToTop.Text + "' ";
            }
            // 受注No(FROM)(中2桁)が入力されている場合
            if (!string.IsNullOrEmpty(txtOrdersNoToMid.Text))
            {
                selectSql += "AND juchuNoMid <= '" + txtOrdersNoToMid.Text + "' ";
            }
            // 受注No(FROM)(下5桁)が入力されている場合
            if (!string.IsNullOrEmpty(txtOrdersNoToBtm.Text))
            {
                selectSql += "AND juchuNoBtm <= '" + txtOrdersNoToBtm.Text + "' ";
            }
            // 得意先コードが入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                selectSql += "AND tokuisakiCode = '" + txtCustomerCode.Text + "' ";
            }
            // 得意先漢字名が入力されている場合
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
                selectSql += "ORDER BY denpyoHizuke, denpyoNo ";
            }
            else
            {
                selectSql += "ORDER BY denpyoHizuke DESC, denpyoNo DESC ";
            }
            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);

            // 取得データをグリッドに設定
            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // 伝票Noまたは受注Noの場合
            if (c.Name.Equals(txtDocumentNoFrom.Name) ||
                c.Name.Equals(txtDocumentNoTo.Name) ||
                c.Name.Equals(txtOrdersNoFromTop.Name) ||
                c.Name.Equals(txtOrdersNoFromMid.Name) ||
                c.Name.Equals(txtOrdersNoFromBtm.Name) ||
                c.Name.Equals(txtOrdersNoToTop.Name) ||
                c.Name.Equals(txtOrdersNoToMid.Name) ||
                c.Name.Equals(txtOrdersNoToBtm.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtNoInput_Leave);
            }
            // 伝票日付Fromの場合
            else if (c.Name.Equals(txtDocumentDateFromYears.Name) ||
                     c.Name.Equals(txtDocumentDateFromMonth.Name) ||
                     c.Name.Equals(txtDocumentDateFromDays.Name) ||
                     c.Name.Equals(dtpDocumentDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtDocumentDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDocumentDateFrom_Leave);
            }
            // 伝票日付Toの場合
            else if (c.Name.Equals(txtDocumentDateToYears.Name) ||
                     c.Name.Equals(txtDocumentDateToMonth.Name) ||
                     c.Name.Equals(txtDocumentDateToDays.Name) ||
                     c.Name.Equals(dtpDocumentDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtDocumentDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDocumentDateTo_Leave);
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
    }
}
