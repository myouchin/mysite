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
    /// 見積検索画面
    /// </summary>
    public partial class sfrmMitumoriSearch : ChildBaseForm
    {
        #region 変数宣言
        private List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private bool startSelect = true;
        private List<string> selectedMitumoriNumbers;
        private CheckMessageType messageType;
        private DBTantousyaMaster tantousyaMaster;
        public CheckMessageType MType
        {
            get { return messageType; }
            set { messageType = value; }
        }
        CommonLogic commonLogic;
        public List<string> SelectedMitumoriNumbers
        {
            get { return selectedMitumoriNumbers; }
            set { selectedMitumoriNumbers = value; }
        }
        private enum LastInputDateType
        {
            None = 0
          , EstimateDateFrom = 1
          , EstimateDateTo = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public sfrmMitumoriSearch(bool flgMultiSelect, CheckMessageType checkMessageType)
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            tantousyaMaster = new DBTantousyaMaster();
            selectedMitumoriNumbers = new List<string>();
            messageType = checkMessageType;
            if (!flgMultiSelect)
            {
                rdoMulti.Visible = false;
                rdoRange.Visible = false;
                btnSelectCancel.Location = btnAllSelect.Location;
                btnAllSelect.Visible = false;
            }
            txtEstimateNoFrom.Text = string.Empty;
            txtEstimateNoTo.Text = string.Empty;
            txtEstimateDateFromYears.Text = string.Empty;
            txtEstimateDateFromMonth.Text = string.Empty;
            txtEstimateDateFromDays.Text = string.Empty;
            txtEstimateDateToYears.Text = string.Empty;
            txtEstimateDateToMonth.Text = string.Empty;
            txtEstimateDateToDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            txtSubject1.Text = string.Empty;
            txtSubject2.Text = string.Empty;
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 入力情報設定
            setInputInfo();

            rdoDesc.Location = new Point(172, 3);

            setGridData();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmMitumoriSearch_Load(object sender, EventArgs e)
        {
            setGridData();
        }
        #endregion

        #region 戻るボタン押下処理
        /// <summary>
        /// 戻るボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            closedForm();
        }
        #endregion

        #region 一覧グリッド描画処理
        /// <summary>
        /// 一覧グリッド描画処理
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

        #region 全選択ボタン押下処理
        /// <summary>
        /// 全選択ボタン押下処理
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

        #region 選択解除ボタン押下処理
        /// <summary>
        /// 選択解除ボタン押下処理
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

        #region 一覧グリッドデータ設定処理
        /// <summary>
        /// 一覧グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;

            DBCommon dbCommon = new DBCommon();
            string selectSql = string.Empty;
            selectSql += "SELECT ";
            selectSql += "  mh.mitumoriNo ";
            selectSql += ", mh.mitumoriHizuke ";
            selectSql += ", mh.tokuisakiName ";
            selectSql += ", mh.kenmei1 ";
            selectSql += ", mf.kingaku ";
            selectSql += "FROM mitumori_header mh ";
            selectSql += "INNER JOIN mitumori_footer mf ";
            selectSql += "ON(mh.mitumoriNo = mf.mitumoriNo) ";
            selectSql += "WHERE 1 = 1 ";
            // 見積No(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateNoFrom.Text))
            {
                selectSql += "AND mh.mitumoriNo >= '" + txtEstimateNoFrom.Text + "' ";
            }
            // 見積No(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateNoTo.Text))
            {
                selectSql += "AND mh.mitumoriNo <= '" + txtEstimateNoTo.Text + "' ";
            }
            // 見積日付(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateDateFromYears.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateFromMonth.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateFromDays.Text))
            {
                string estimateDateFrom = txtEstimateDateFromYears.Text;
                estimateDateFrom += "/" + txtEstimateDateFromMonth.Text;
                estimateDateFrom += "/" + txtEstimateDateFromDays.Text;
                selectSql += "AND (mh.mitumoriHizuke IS NOT NULL AND STR_TO_DATE(mh.mitumoriHizuke, '%Y-%m-%d') >= '" + estimateDateFrom + "') ";
            }
            // 見積日付(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateDateToYears.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateToMonth.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateToDays.Text))
            {
                string estimateDateTo = txtEstimateDateToYears.Text;
                estimateDateTo += "/" + txtEstimateDateToMonth.Text;
                estimateDateTo += "/" + txtEstimateDateToDays.Text;
                selectSql += "AND (mh.mitumoriHizuke IS NOT NULL AND STR_TO_DATE(mh.mitumoriHizuke, '%Y-%m-%d') <= '" + estimateDateTo + "') ";
            }
            // 担当者がすべてでない場合
            if (!Convert.ToString(cmbPersonnel.SelectedValue).Equals("ALL"))
            {
                selectSql += "AND mh.tantousyaCode = '" + Convert.ToString(cmbPersonnel.SelectedValue) + "' ";
            }
            // 得意先コードが入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                selectSql += "AND mh.tokuisakiCode = '" + txtCustomerCode.Text + "' ";
            }
            // 得意先漢字名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                selectSql += "AND mh.tokuisakiName Like '%" + txtCustomerName.Text + "%' ";
            }
            // 得意先カナ名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerKanaName.Text))
            {
                selectSql += "AND mh.tokuisakiKanaName Like '%" + txtCustomerKanaName.Text + "%' ";
            }
            // 件名１が入力されている場合
            if (!string.IsNullOrEmpty(txtSubject1.Text))
            {
                selectSql += "AND mh.kenmei1 Like '%" + txtSubject1.Text + "%' ";
            }
            // 件名２が入力されている場合
            if (!string.IsNullOrEmpty(txtSubject2.Text))
            {
                selectSql += "AND mh.kenmei2 Like '%" + txtSubject2.Text + "%' ";
            }
            selectSql += "AND (mh.kanriKubun IS NULL OR mh.kanriKubun <> '9') ";
            if (rdoAsc.Checked)
            {
                selectSql += "ORDER BY mh.mitumoriHizuke, mh.mitumoriNo ";
            }
            else
            {
                selectSql += "ORDER BY mh.mitumoriHizuke DESC, mh.mitumoriNo DESC ";
            }
            // データ取得を実行
            DataTable dt = dbCommon.executeNoneLockSelect(selectSql);

            // 取得データをグリッドに設定
            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }
        #endregion

        #region 検索ボタン押下処理
        private void btnSearch_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
        }
        #endregion

        #region 確認ボタン押下処理
        private void btnCheck_Click(object sender, EventArgs e)
        {
            selectedMitumoriNumbers = new List<string>();
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
                selectedMitumoriNumbers.Add(Convert.ToString(gRow.Cells[clmEstimateNo.DisplayIndex].Value));
            }

            DialogResult = DialogResult.OK;
            closedForm();
        }
        #endregion

        #region 見積日付(FROM)フォーカスアウトイベント
        /// <summary>
        /// 見積日付(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.EstimateDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.EstimateDateFrom;
            }
        }
        #endregion

        #region 見積日付(TO)フォーカスアウトイベント
        /// <summary>
        /// 見積日付(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.EstimateDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.EstimateDateTo;
            }
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
                    case LastInputDateType.EstimateDateFrom:
                        y = txtEstimateDateFromYears.Text;
                        m = txtEstimateDateFromMonth.Text;
                        d = txtEstimateDateFromDays.Text;
                        break;
                    case LastInputDateType.EstimateDateTo:
                        y = txtEstimateDateToYears.Text;
                        m = txtEstimateDateToMonth.Text;
                        d = txtEstimateDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.EstimateDateFrom.Equals(lastInputDateType))
                    {
                        txtEstimateDateFromYears.Focus();
                    }
                    else if (LastInputDateType.EstimateDateTo.Equals(lastInputDateType))
                    {
                        txtEstimateDateToYears.Focus();
                    }
                    return;
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

        #region 見積日付(FROM)フォーカスインイベント
        /// <summary>
        /// 見積日付(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.EstimateDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 見積日付(TO)フォーカスインイベント
        /// <summary>
        /// フ見積日付(TO)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.EstimateDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // 見積日付Fromの場合
            if (c.Name.Equals(txtEstimateDateFromYears.Name) ||
                c.Name.Equals(txtEstimateDateFromMonth.Name) ||
                c.Name.Equals(txtEstimateDateFromDays.Name) ||
                c.Name.Equals(dtpEstimateDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtEstimateDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEstimateDateFrom_Leave);
            }
            // 見積日付Toの場合
            else if (c.Name.Equals(txtEstimateDateToYears.Name) ||
                     c.Name.Equals(txtEstimateDateToMonth.Name) ||
                     c.Name.Equals(txtEstimateDateToDays.Name) ||
                     c.Name.Equals(dtpEstimateDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtEstimateDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEstimateDateTo_Leave);
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

        #region 見積Noフォーカスアウトイベント
        /// <summary>
        /// 見積Noフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateNo_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            int mitumoriNo = 0;

            if (int.TryParse(control.Text, out mitumoriNo))
            {
                control.Text = mitumoriNo.ToString("00000000");
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtEstimateNoFrom.MaxLength = 8;        // 見積NO(FROM)
            txtEstimateNoTo.MaxLength = 8;          // 見積NO(TO
            txtEstimateDateFromYears.MaxLength = 4; // 見積日付(FROM)(年)
            txtEstimateDateFromMonth.MaxLength = 2; // 見積日付(FROM)(月)
            txtEstimateDateFromDays.MaxLength = 2;  // 見積日付(FROM)(日)
            txtEstimateDateToYears.MaxLength = 4;   // 見積日付(TO)(年)
            txtEstimateDateToMonth.MaxLength = 2;   // 見積日付(TO)(月)
            txtEstimateDateToDays.MaxLength = 2;    // 見積日付(TO)(日)
            txtCustomerCode.MaxLength = 5;          // 得意先ｺｰﾄﾞ
            txtCustomerName.MaxLength = 40;         // 得意先名
            txtCustomerKanaName.MaxLength = 80;     // 得意先カナ名
            txtSubject1.MaxLength = 20;             // 件名１
            txtSubject2.MaxLength = 20;             // 件名２

            // 入力制御イベント設定
            txtEstimateNoFrom.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 見積NO(FROM)       :数字のみ入力可
            txtEstimateNoTo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 見積NO(TO)         :数字のみ入力可
            txtEstimateDateFromYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 見積日付(FROM)(年) :数字のみ入力可
            txtEstimateDateFromMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 見積日付(FROM)(月) :数字のみ入力可
            txtEstimateDateFromDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 見積日付(FROM)(日) :数字のみ入力可
            txtEstimateDateToYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 見積日付(TO)(年)   :数字のみ入力可
            txtEstimateDateToMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 見積日付(TO)(月)   :数字のみ入力可
            txtEstimateDateToDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 見積日付(TO)(日)   :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 得意先ｺｰﾄﾞ         :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);          // 得意先カナ名       :全角カナのみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 数字のみ入力可能項目のキー押下イベント
        /// <summary>
        /// 数字のみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDigitalOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字のみ入力可能項目の制御処理を実行
            if (!commonLogic.inputDigitalOnly_KeyPress(e))
            {
            }
        }
        #endregion

        #region 全角カナのみ入力可能項目のキー押下イベント
        /// <summary>
        /// 全角カナのみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmKanaOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 全角カナのみ入力可能項目の制御処理を実行
            if (!commonLogic.inputEmKanaOnly_KeyPress(e))
            {
            }
        }
        #endregion

        #region 担当者コンボボックスの設定
        /// <summary>
        /// 担当者コンボボックスの設定
        /// </summary>
        private void setPersonnelCmb()
        {
            // 担当者取得
            DataTable tantousyaDt = tantousyaMaster.getTantousyaDataTable(string.Empty, string.Empty);
            DataRow newRow = tantousyaDt.NewRow();
            newRow["tantousyaCode"] = "ALL";
            newRow["tantousyaName"] = "全て";
            tantousyaDt.Rows.InsertAt(newRow, 0);
            tantousyaDt.AcceptChanges();
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPersonnel, tantousyaDt, "tantousyaCode", "tantousyaName");
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
            txtEstimateNoFrom.Text = string.Empty;
            txtEstimateNoTo.Text = string.Empty;
            txtEstimateDateFromYears.Text = string.Empty;
            txtEstimateDateFromMonth.Text = string.Empty;
            txtEstimateDateFromDays.Text = string.Empty;
            txtEstimateDateToYears.Text = string.Empty;
            txtEstimateDateToMonth.Text = string.Empty;
            txtEstimateDateToDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            txtSubject1.Text = string.Empty;
            txtSubject2.Text = string.Empty;
        }
        #endregion
    }
}
