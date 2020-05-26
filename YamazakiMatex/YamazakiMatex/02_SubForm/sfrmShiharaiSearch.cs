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
    /// 支払検索画面
    /// </summary>
    public partial class sfrmShiharaiSearch : ChildBaseForm
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
        public class SelectedShiharaiInfo
        {
            #region 変数宣言
            /// <summary>
            /// 支払No
            /// </summary>
            private string shiharaiNo;
            #endregion

            #region データの取得・設定
            /// <summary>
            /// 支払Noの取得・設定
            /// </summary>
            public string ShiharaiNo
            {
                get { return shiharaiNo; }
                set { shiharaiNo = value; }
            }
            #endregion
        }
        private List<SelectedShiharaiInfo> selectedShiharaiInfos;
        public List<SelectedShiharaiInfo> SelectedShireInfos
        {
            get { return selectedShiharaiInfos; }
            set { selectedShiharaiInfos = value; }
        }
        private enum LastInputDateType
        {
            None = 0
          , PaymentDateFrom = 1
          , PaymentDateTo = 2
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
        public sfrmShiharaiSearch(bool flgMultiSelect, CheckMessageType checkMessageType)
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            SelectedShireInfos = new List<SelectedShiharaiInfo>();
            messageType = checkMessageType;
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            DateTime defaultDate = Convert.ToDateTime("1900/1/1");
            txtPaymentNoFrom.Text = string.Empty;
            txtPaymentNoTo.Text = string.Empty;
            txtPaymentNoFrom.Text = string.Empty;
            txtPaymentNoTo.Text = string.Empty;
            dtpPaymentDateFrom.Value = defaultDate;
            txtPaymentDateFromYears.Text = string.Empty;
            txtPaymentDateFromMonth.Text = string.Empty;
            txtPaymentDateFromDays.Text = string.Empty;
            dtpPaymentDateTo.Value = defaultDate;
            txtPaymentDateToYears.Text = string.Empty;
            txtPaymentDateToMonth.Text = string.Empty;
            txtPaymentDateToDays.Text = string.Empty;
            txtPurchaseCode.Text = string.Empty;
            txtPurchaseName.Text = string.Empty;
            setGridData();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
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
        private void sfrmShiharaiSearch_Load(object sender, EventArgs e)
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
            txtPaymentNoFrom.Text = string.Empty;
            txtPaymentNoTo.Text = string.Empty;
            txtPaymentNoFrom.Text = string.Empty;
            txtPaymentNoTo.Text = string.Empty;
            dtpPaymentDateFrom.Value = defaultDate;
            txtPaymentDateFromYears.Text = string.Empty;
            txtPaymentDateFromMonth.Text = string.Empty;
            txtPaymentDateFromDays.Text = string.Empty;
            dtpPaymentDateTo.Value = defaultDate;
            txtPaymentDateToYears.Text = string.Empty;
            txtPaymentDateToMonth.Text = string.Empty;
            txtPaymentDateToDays.Text = string.Empty;
            txtPurchaseCode.Text = string.Empty;
            txtPurchaseName.Text = string.Empty;
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
                    case LastInputDateType.PaymentDateFrom:
                        y = txtPaymentDateFromYears.Text;
                        m = txtPaymentDateFromMonth.Text;
                        d = txtPaymentDateFromDays.Text;
                        break;
                    case LastInputDateType.PaymentDateTo:
                        y = txtPaymentDateToYears.Text;
                        m = txtPaymentDateToMonth.Text;
                        d = txtPaymentDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.PaymentDateFrom.Equals(lastInputDateType))
                    {
                        txtPaymentDateFromYears.Focus();
                    }
                    else if (LastInputDateType.PaymentDateTo.Equals(lastInputDateType))
                    {
                        txtPaymentDateToYears.Focus();
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
        private void txtPaymentDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.PaymentDateFrom)
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
        private void txtPaymentDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.PaymentDateTo)
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
        private void txtPaymentDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.PaymentDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.PaymentDateFrom;
            }
        }
        #endregion

        #region 伝票日付(TO)フォーカスアウトイベント
        /// <summary>
        /// 伝票日付(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPaymentDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.PaymentDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.PaymentDateTo;
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
            SelectedShireInfos = new List<SelectedShiharaiInfo>();
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

            SelectedShiharaiInfo wkSelectedShiharaiInfo;
            // 選択行情報を格納
            foreach (DataGridViewRow gRow in grdSearchList.SelectedRows)
            {
                wkSelectedShiharaiInfo = new SelectedShiharaiInfo();
                wkSelectedShiharaiInfo.ShiharaiNo = Convert.ToString(gRow.Cells[clmPaymentNo.Name].Value);
                SelectedShireInfos.Add(wkSelectedShiharaiInfo);
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
            selectSql += "  shiharaiNo";
            selectSql += ", shiharaiHizuke ";
            selectSql += ", shiresakiName ";
            selectSql += "FROM shiharai ";
            selectSql += "WHERE 1 = 1 ";
            // 支払No(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtPaymentNoFrom.Text))
            {
                selectSql += "AND shiharaiNo >= '" + txtPaymentNoFrom.Text + "' ";
            }
            // 支払No(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtPaymentNoTo.Text))
            {
                selectSql += "AND shiharaiNo <= '" + txtPaymentNoTo.Text + "' ";
            }
            // 支払日付(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtPaymentDateFromYears.Text) &&
                !string.IsNullOrEmpty(txtPaymentDateFromMonth.Text) &&
                !string.IsNullOrEmpty(txtPaymentDateFromDays.Text))
            {
                string paymentDateFrom = txtPaymentDateFromYears.Text;
                paymentDateFrom += "/" + txtPaymentDateFromMonth.Text;
                paymentDateFrom += "/" + txtPaymentDateFromDays.Text;
                selectSql += "AND shiharaiHizuke >= '" + paymentDateFrom + "' ";
            }
            // 支払日付(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtPaymentDateToYears.Text) &&
                !string.IsNullOrEmpty(txtPaymentDateToMonth.Text) &&
                !string.IsNullOrEmpty(txtPaymentDateToDays.Text))
            {
                string paymentDateTo = txtPaymentDateToYears.Text;
                paymentDateTo += "/" + txtPaymentDateToMonth.Text;
                paymentDateTo += "/" + txtPaymentDateToDays.Text;
                selectSql += "AND shiharaiHizuke <= '" + paymentDateTo + "' ";
            }
            // 仕入先コードが入力されている場合
            if (!string.IsNullOrEmpty(txtPurchaseCode.Text))
            {
                selectSql += "AND shiresakiCode >= '" + txtPurchaseCode.Text + "' ";
            }
            // 仕入先名が入力されている場合
            if (!string.IsNullOrEmpty(txtPurchaseName.Text))
            {
                selectSql += "AND shiresakiName Like '%" + txtPurchaseName.Text + "%' ";
            }
            selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";
            if (rdoAsc.Checked)
            {
                selectSql += "ORDER BY shiharaiHizuke, shiharaiNo ";
            }
            else
            {
                selectSql += "ORDER BY shiharaiHizuke DESC, shiharaiNo DESC ";
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
            // 支払Noまたはの場合
            if (c.Name.Equals(txtPaymentNoFrom.Name) ||
                c.Name.Equals(txtPaymentNoTo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtNoInput_Leave);
            }
            // 支払日付Fromの場合
            else if (c.Name.Equals(txtPaymentDateFromYears.Name) ||
                     c.Name.Equals(txtPaymentDateFromMonth.Name) ||
                     c.Name.Equals(txtPaymentDateFromDays.Name) ||
                     c.Name.Equals(dtpPaymentDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtPaymentDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtPaymentDateFrom_Leave);
            }
            // 支払日付Toの場合
            else if (c.Name.Equals(txtPaymentDateToYears.Name) ||
                     c.Name.Equals(txtPaymentDateToMonth.Name) ||
                     c.Name.Equals(txtPaymentDateToDays.Name) ||
                     c.Name.Equals(dtpPaymentDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtPaymentDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtPaymentDateTo_Leave);
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
