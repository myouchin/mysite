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
    /// 締日更新処理画面
    /// </summary>
    public partial class frmSeikyuShimebiKoshin : ChildBaseForm
    {
        #region 変数宣言
        private bool flgSaving = false;
        private RadioButton activeRadioButton = null;
        private DateTime syoriDate;
        private bool flgBtnSearchSelect = false;
        private string dummyCode = "Dummy";
        private DBKanriMaster kanriMaster;
        private DBTokuisakiMaster tokuisakiMaster;
        private DBMeisyoMaster meisyoMaster;
        private DBSeikyu seikyuDb;
        private CommonLogic commonLogic;
        private bool flgSettingEnable = false;
        private bool flgInit = false;
        private enum LastInputDateType
        {
            None = 0
          , TightenDate=1
          , BillingDate = 2
          , SalesDateFrom = 3
          , SalesDateTo = 4
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        sfrmTokuisakiSearch fTokuisaki;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSeikyuShimebiKoshin()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            tokuisakiMaster = new DBTokuisakiMaster();
            meisyoMaster = new DBMeisyoMaster();
            seikyuDb = new DBSeikyu();
            commonLogic = new CommonLogic();
            fTokuisaki = new sfrmTokuisakiSearch(false);
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
            // 編集中の項目が存在しない場合なにもしない
            if (activeControlInfo.Control == null) return;
            // 検索ボタンが使用不可の場合なにもしない
            if (!btnSearch.Enabled) return;
            bool flgSetFocus = false;

            // 得意先ｺｰﾄﾞを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 得意先検索画面を起動
                fTokuisaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fTokuisaki.DialogResult == DialogResult.OK)
                {
                    string tokuisakiCode = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                    string jigyousyoCode = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                    // 得意先情報設定処理
                    setTokuisakiInfo(tokuisakiCode, jigyousyoCode, true);
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
        }
        #endregion

        #region 実行ボタン押下イベント
        /// <summary>
        /// 実行ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecution_Click(object sender, EventArgs e)
        {
            // 必須入力チェック
            if (checkRequired()) return;
            // 相関チェック
            if (checkCorrelation()) return;

            seikyuDb.startTransaction();

            DBSeikyu.UpdateCriteria updateCriteria = new DBSeikyu.UpdateCriteria();

            updateCriteria.ProcessType = rdoUpdate.Checked ? DBSeikyu.UpdateCriteria.ProcessingType.UpDate : DBSeikyu.UpdateCriteria.ProcessingType.Cancel;
            updateCriteria.TightenDateYears = txtTightenDateYears.Text;
            updateCriteria.TightenDateMonth = txtTightenDateMonth.Text;
            updateCriteria.TightenDateDaysValue = Convert.ToString(cmbTightenType.SelectedValue);
            // 締日 = "月末"の場合
            if (Consts.EndOfMonthText.Equals(cmbTightenType.Text))
            {
                // 月末日取得処理を実行
                updateCriteria.TightenDateDaysText = commonLogic.GetEndOfMonth(updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth);
            }
            else
            {
                updateCriteria.TightenDateDaysText = cmbTightenType.Text;
            }
            updateCriteria.BillingDateYears = txtBillingDateYears.Text;
            updateCriteria.BillingDateMonth = txtBillingDateMonth.Text;
            updateCriteria.BillingDateDays = txtBillingDateDays.Text;
            updateCriteria.CustomerCode = txtCustomerCode.Text;
            updateCriteria.CustomerName = txtCustomerName.Text;
            updateCriteria.CustomerKanaName = txtCustomerKanaName.Text;
            updateCriteria.OfficesCode = Convert.ToString(cmbOffices.SelectedValue);
            updateCriteria.OfficesName = cmbOffices.Text;
            updateCriteria.SalesDateFromYears = txtSalesDateFromYears.Text;
            updateCriteria.SalesDateFromMonth = txtSalesDateFromMonth.Text;
            updateCriteria.SalesDateFromDays = txtSalesDateFromDays.Text;
            updateCriteria.SalesDateToYears = txtSalesDateToYears.Text;
            updateCriteria.SalesDateToMonth = txtSalesDateToMonth.Text;
            updateCriteria.SalesDateToDays = txtSalesDateToDays.Text;

            DBSeikyu.UpdateCheckResult chkResult = seikyuDb.checkUpdateSeikyu(ref updateCriteria);

            // ロックエラーが発生した場合
            if (DBSeikyu.UpdateCheckResult.DataLock.Equals(chkResult))
            {
                errorOK(Messages.M0035);
            }
            // 締日に該当する得意先が存在しない場合
            else if (DBSeikyu.UpdateCheckResult.NoMasterData.Equals(chkResult))
            {
                messageOK(Messages.M0036);
            }
            // 更新対象のデータが存在しない場合
            else if (DBSeikyu.UpdateCheckResult.NoExistsTargetData.Equals(chkResult))
            {
                messageOK(Messages.M0037);
            }
            // 上記以外の場合
            else if (DBSeikyu.UpdateCheckResult.ExistsTargetData.Equals(chkResult))
            {
                // 確認メッセージの表示
                string msgCode = rdoUpdate.Checked ? Messages.M0038 : Messages.M0039;

                if (queryYesNo(string.Format(msgCode, updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth)) == DialogResult.Yes)
                {
                    // 締日更新処理実行
                    DBSeikyu.UpdateResult upResult = seikyuDb.updateSeikyu(updateCriteria);
                    if (upResult == DBSeikyu.UpdateResult.Normal)
                    {
                        messageOK(string.Format(Messages.M0042, updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth, rdoUpdate.Checked ? "締日更新" : "取消"));
                    }
                    else
                    {
                        errorOK(string.Format(Messages.M0043, updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth, rdoUpdate.Checked ? "締日更新" : "取消"));
                    }
                }
            }

            seikyuDb.endTransaction();
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
            if (!btnCancel.Enabled) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                string queryMeaasage = Messages.M0033;
                string str1 = "取消してよろしいですか？";

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }
            RadioButton activeModeRdo = null;
            if (rdoAll.Checked)
            {
                activeModeRdo = rdoAll;
            }
            else if (rdoIndividual.Checked)
            {
                activeModeRdo = rdoIndividual;
            }
            // ラジオボタン変更処理実行
            inputModeChange(activeModeRdo);
        }
        #endregion

        #region 閉じるボタン押下イベント
        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            closedForm();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShimebiKoshin_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
            // ラジオボタン変更処理実行
            inputModeChange(rdoAll);
            // 締区分コンボボックス設定
            setTightenTypeCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 入力情報設定
            setInputInfo();
        }
        #endregion

        #region 画面項目編集中のキーボード押下イベント
        /// <summary>
        /// 画面項目編集中のキーボード押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputObject_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                // Enterキーが押下された場合
                case Keys.Enter:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    break;
                // F1キーが押下された場合
                case Keys.F1:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;

                    // 検索ボタン押下時の処理を実行
                    btnSearch_Click(null, null);
                    break;
                // F10キーが押下された場合
                case Keys.F10:
                    // 保存処理を実行
                    btnExecution_Click(null, null);
                    break;
                // F11キーが押下された場合
                case Keys.F11:
                    // 取消処理を実行
                    btnCancel_Click(null, null);
                    break;
                // F12キーが押下された場合
                case Keys.F12:
                    // 閉じる処理を実行
                    btnClose_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 得意先コードのフォーカスアウトイベント
        /// <summary>
        /// 得意先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 得意先情報の設定
                setTokuisakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), string.Empty, false);

            }
            else
            {
                txtCustomerName.Text = string.Empty;
                txtCustomerKanaName.Text = string.Empty;
                // 事業所コンボボックスの再設定
                setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
                cmbTightenType.Enabled = true;
            }
        }
        #endregion

        #region 締年月日のフォーカスインイベント
        /// <summary>
        /// 締年月日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tightenDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TightenDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 締年月日のフォーカスアウトイベント
        /// <summary>
        /// 締年月日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tightenDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TightenDate;
                if ((sender is TextBox))
                {
                    lastInputDateText = (TextBox)sender;
                }
            }
            else
            {
                lastInputDateType = LastInputDateType.TightenDate;
            }
        }
        #endregion

        #region 請求日のフォーカスインイベント
        /// <summary>
        /// 請求日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.BillingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 請求日のフォーカスアウトイベント
        /// <summary>
        /// 請求日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billingDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.BillingDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.BillingDate;
            }
        }
        #endregion

        #region 対象売上日付(FROM)のフォーカスインイベント
        /// <summary>
        /// 対象売上日付(FROM)のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salesDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.SalesDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象売上日付(FROM)のフォーカスアウトイベント
        /// <summary>
        /// 対象売上日付(FROM)のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salesDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.SalesDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.SalesDateFrom;
            }
        }
        #endregion

        #region 対象売上日付(TO)のフォーカスインイベント
        /// <summary>
        /// 対象売上日付(TO)のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salesDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.SalesDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象売上日付(TO)のフォーカスアウトイベント
        /// <summary>
        /// 対象売上日付(TO)のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salesDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.SalesDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.SalesDateTo;
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

            if (!flgInit && !lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.TightenDate:
                        y = txtTightenDateYears.Text;
                        m = txtTightenDateMonth.Text;
                        d = "01";
                        inputObj = dtpTightenDate;
                        break;
                    case LastInputDateType.BillingDate:
                        y = txtBillingDateYears.Text;
                        m = txtBillingDateMonth.Text;
                        d = txtBillingDateDays.Text;
                        inputObj = dtpBillingDate;
                        break;
                    case LastInputDateType.SalesDateFrom:
                        y = txtSalesDateFromYears.Text;
                        m = txtSalesDateFromMonth.Text;
                        d = txtSalesDateFromDays.Text;
                        inputObj = dtpSalesDateFrom;
                        break;
                    case LastInputDateType.SalesDateTo:
                        y = txtSalesDateToYears.Text;
                        m = txtSalesDateToMonth.Text;
                        d = txtSalesDateToDays.Text;
                        inputObj = dtpSalesDateTo;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.TightenDate.Equals(lastInputDateType))
                    {
                        txtTightenDateYears.Focus();
                    }
                    else if (LastInputDateType.BillingDate.Equals(lastInputDateType))
                    {
                        txtBillingDateYears.Focus();
                    }
                    else if (LastInputDateType.SalesDateFrom.Equals(lastInputDateType))
                    {
                        txtSalesDateFromYears.Focus();
                    }
                    else if (LastInputDateType.SalesDateTo.Equals(lastInputDateType))
                    {
                        txtSalesDateToYears.Focus();
                    }
                    return;
                }
            }

            if (c is CustomTextBox)
            {
                ((CustomTextBox)c).BeforeValue = ((CustomTextBox)c).Text;
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
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
            commonLogic.inputDigitalOnly_KeyPress(e);
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
            commonLogic.inputEmKanaOnly_KeyPress(e);
        }
        #endregion

        #region 検索ボタンオンフォーカスイベント
        /// <summary>
        /// 検索ボタンオンフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            flgBtnSearchSelect = true;
        }
        #endregion

        #region 検索ボタンアウトフォーカスイベント
        /// <summary>
        /// 検索ボタンアウトフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            flgBtnSearchSelect = false;
        }
        #endregion

        #region 処理対象ラジオボタン押下イベント
        /// <summary>
        /// 処理対象ラジオボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processingTargetRadio_Click(object sender, EventArgs e)
        {
            string queryMeaasage = Messages.M0033;
            string str1 = "処理対象を変更してよろしいですか？";
            RadioButton radio = (RadioButton)sender;
            if (!flgSaving && activeRadioButton != null && activeRadioButton.Name == radio.Name) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoAll.Checked = (rdoAll.Name == radio.Name);
            rdoIndividual.Checked = (rdoIndividual.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
        }
        #endregion

        #region 処理区分ラジオボタン押下イベント
        /// <summary>
        /// 処理区分ラジオボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processingTypeRadio_Click(object sender, EventArgs e)
        {
            string queryMeaasage = Messages.M0033;
            string str1 = "処理区分を変更してよろしいですか？";
            RadioButton radio = (RadioButton)sender;
            if (!flgSaving && activeRadioButton != null && activeRadioButton.Name == radio.Name) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoUpdate.Checked = (rdoUpdate.Name == radio.Name);
            rdoCancel.Checked = (rdoCancel.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
        }
        #endregion

        #region 請求締日(年)変更イベント
        /// <summary>
        /// 請求締日(年)変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTightenDateYears_TextChanged(object sender, EventArgs e)
        {
            txtBillingDateYears.Text = txtTightenDateYears.Text;
            string txt = cmbTightenType.Text;
            if (Consts.EndOfMonthText.Equals(txt))
            {
                txtBillingDateDays.Text = commonLogic.GetEndOfMonth(txtBillingDateYears.Text, txtBillingDateMonth.Text);
            }
        }
        #endregion

        #region 請求締日(月)変更イベント
        /// <summary>
        /// 請求締日(月)変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTightenDateMonth_TextChanged(object sender, EventArgs e)
        {
            txtBillingDateMonth.Text = txtTightenDateMonth.Text;
            string txt = cmbTightenType.Text;
            if (Consts.EndOfMonthText.Equals(txt))
            {
                txtBillingDateDays.Text = commonLogic.GetEndOfMonth(txtBillingDateYears.Text, txtBillingDateMonth.Text);
            }
        }
        #endregion

        #region 請求締日(日)変更イベント
        /// <summary>
        /// 請求締日(日)変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTightenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cmbTightenType.SelectedValue);
            string txt = cmbTightenType.Text;
            if (Consts.FromTimeToTimeValue.Equals(val))
            {
                txtBillingDateDays.Text = string.Empty;
            }
            else if (Consts.EndOfMonthText.Equals(txt))
            {
                txtBillingDateDays.Text = commonLogic.GetEndOfMonth(txtBillingDateYears.Text, txtBillingDateMonth.Text);
            }
            else
            {
                txtBillingDateDays.Text = cmbTightenType.Text;
            }
        }
        #endregion

        #region 事業所コンボボックス変更イベント
        /// <summary>
        /// 事業所コンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOffices_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cmbOffices.SelectedValue);
            DataTable sourceDt = (DataTable)cmbOffices.DataSource;
            var query = sourceDt.AsEnumerable().Where(p => val.Equals(p.Field<string>(commonLogic.StrCmbValue)));
            if (query.Count() > 0) cmbTightenType.SelectedValue = query.ElementAt(0)[DBFileLayout.TokuisakiMasterFile.dcShimebi];
        }
        #endregion

        #endregion

        #region ビジネスロジック

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // キー押下イベントを追加
            c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

            // 締年月日の場合
            if (c.Name.Equals(txtTightenDateYears.Name) ||
                c.Name.Equals(txtTightenDateMonth.Name) ||
                c.Name.Equals(cmbTightenType.Name) ||
                c.Name.Equals(dtpTightenDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.tightenDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.tightenDate_Leave);
            }
            // 請求年月日の場合
            else if (c.Name.Equals(txtBillingDateYears.Name) ||
                     c.Name.Equals(txtBillingDateMonth.Name) ||
                     c.Name.Equals(txtBillingDateDays.Name) ||
                     c.Name.Equals(dtpBillingDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.billingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.billingDate_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            }
            // 対象売上日付(FROM)の場合
            else if (c.Name.Equals(txtSalesDateFromYears.Name) ||
                     c.Name.Equals(txtSalesDateFromMonth.Name) ||
                     c.Name.Equals(txtSalesDateFromDays.Name) ||
                     c.Name.Equals(dtpSalesDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.salesDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.salesDateFrom_Leave);
            }
            // 対象売上日付(TO)の場合
            else if (c.Name.Equals(txtSalesDateToYears.Name) ||
                     c.Name.Equals(txtSalesDateToMonth.Name) ||
                     c.Name.Equals(txtSalesDateToDays.Name) ||
                     c.Name.Equals(dtpSalesDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.salesDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.salesDateTo_Leave);
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

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            //juchuKingakuRoundType = CommonLogic.RoundType.RoundOoff;
            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (dt == null || dt.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerCode.Focus();
                return;
            }

            if (flgUnconditional || txtCustomerCode.BeforeValue != tokuisakiCode)
            {
                DataRow dRow = dt.Rows[0];
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    // 入力値クリア設定
                    txtCustomerName.Text = string.Empty;
                    txtCustomerKanaName.Text = string.Empty;
                    // フォーカス設定
                    txtCustomerName.Focus();
                    cmbTightenType.SelectedValue = "99";
                }
                else
                {
                    var query = dt.AsEnumerable().Where(p => p.Field<string>("jigyousyoCode").Equals(jigyousyoCode));
                    if (query.Count() > 0)
                    {
                        dRow = query.ElementAt(0);
                    }
                    // 取得データを画面項目に設定
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
                    txtCustomerKanaName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiKanaName]);
                    cmbTightenType.SelectedValue = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcShimebi]);

                }
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
                // 入力可否設定
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                cmbTightenType.Enabled = false;
            }
            else
            {
                txtCustomerCode.Text = tokuisakiCode;
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
            cmbOffices.BeforeSelectedValue = Convert.ToString(cmbOffices.SelectedValue);
        }
        #endregion

        #region 締区分コンボボックスの設定
        /// <summary>
        /// 締区分コンボボックスの設定
        /// </summary>
        private void setTightenTypeCmb()
        {
            ComboBoxStyle cmbStyle = ComboBoxStyle.DropDownList;
            // 締区分取得
            DataTable tightenTypeDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE006);
            if (rdoAll.Checked)
            {
                var query = tightenTypeDt.AsEnumerable().Where(p => Consts.FromTimeToTimeValue.Equals(p.Field<string>("kubun")));
                if (query.Count() > 0) tightenTypeDt.Rows.Remove(query.ElementAt(0));
            }
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbTightenType, tightenTypeDt, "kubun", "kubunName");
            cmbTightenType.DropDownStyle = cmbStyle;
            cmbTightenType.SelectedIndex = 0;
        }
        #endregion

        #region 事業所コンボボックスの設定
        /// <summary>
        /// 事業所コンボボックスの設定
        /// </summary>
        private void setOfficesCmb(string tokuisakiCode, string jigyousyoCode)
        {
            ComboBoxStyle cmbStyle = ComboBoxStyle.DropDownList;
            // 事業所取得
            if (Consts.OthersCustomerCode.Equals(tokuisakiCode) || dummyCode.Equals(tokuisakiCode))
            {
                tokuisakiCode = dummyCode;
                cmbStyle = ComboBoxStyle.Simple;
            }
            DataTable officesDt = tokuisakiMaster.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            // コンボボックス設定共通処理実行
            string[] option = new string[1];
            option[0] = DBFileLayout.TokuisakiMasterFile.dcShimebi;
            commonLogic.setComboBoxDataSource(ref cmbOffices, officesDt, "jigyousyoCode", "jigyousyoName", option);
            cmbOffices.DropDownStyle = cmbStyle;

            if (!string.IsNullOrEmpty(jigyousyoCode))
            {
                cmbOffices.SelectedValue = jigyousyoCode;
            }
            else if (!Consts.OthersCustomerCode.Equals(tokuisakiCode) && cmbOffices.Items.Count > 0)
            {
                cmbOffices.SelectedIndex = 0;
            }
            else
            {
                cmbOffices.SelectedIndex = -1;
                cmbOffices.Text = string.Empty;
            }
        }
        #endregion

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable, Common.CustomDateTimePicker inputObj)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
            {
                ret = true;
            }
            else
            {
                DateTime date;
                DateTime wkdate;
                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
                if (ret && inputObj != null)
                {
                    wkdate = date.AddDays(1);
                    inputObj.Value = wkdate;
                    inputObj.Value = date;
                }
            }
            return ret;
        }
        #endregion

        #region 検索ボタン入力可否設定
        /// <summary>
        /// 検索ボタン入力可否設定
        /// </summary>
        private void setSearchButtonEnabled()
        {
            bool enabled = true;
            // 編集中の項目が存在しない場合
            if (activeControlInfo.Control == null)
            {
                // 検索ボタン使用不可
                enabled = false;
            }
            // 得意先ｺｰﾄﾞを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 上記以外
            else
            {
                // 検索ボタン使用不可
                enabled = false;
            }
            // 検索ボタンの入力可否設定
            btnSearch.Enabled = enabled;
        }
        #endregion

        #region 処理モードラジオボタン変更処理
        /// <summary>
        /// 処理モードラジオボタン変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputModeChange(RadioButton radio)
        {
            // チェックOFFの場合何もしない
            if (!radio.Checked) return;
            flgInit = true;

            activeRadioButton = radio;
            #region 共通初期値設定
            dtpTightenDate.Value = syoriDate;
            txtTightenDateYears.Text = string.Empty;
            txtTightenDateMonth.Text = string.Empty;
            dtpBillingDate.Value = syoriDate;
            txtBillingDateYears.Text = string.Empty;
            txtBillingDateMonth.Text = string.Empty;
            txtBillingDateDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            dtpSalesDateFrom.Value = syoriDate;
            txtSalesDateFromYears.Text = string.Empty;
            txtSalesDateFromMonth.Text = string.Empty;
            txtSalesDateFromDays.Text = string.Empty;
            dtpSalesDateTo.Value = syoriDate;
            txtSalesDateToYears.Text = string.Empty;
            txtSalesDateToMonth.Text = string.Empty;
            txtSalesDateToDays.Text = string.Empty;
            setTightenTypeCmb();
            setOfficesCmb(dummyCode, string.Empty);
            #endregion

            // モード別編集可否設定
            setEnabled();
            flgInit = false;
        }
        #endregion

        #region 処理モード別項目制御処理
        /// <summary>
        /// 処理モード別項目制御処理
        /// </summary>
        private void setEnabled()
        {
            if (flgSettingEnable) return;
            flgSettingEnable = true;
            rdoAll.Click -= new EventHandler(processingTargetRadio_Click);
            rdoIndividual.Click -= new EventHandler(processingTargetRadio_Click);
            rdoUpdate.Click -= new EventHandler(processingTypeRadio_Click);
            rdoCancel.Click -= new EventHandler(processingTypeRadio_Click);
            #region モード別編集可否設定
            // 全件更新
            if (rdoAll.Checked)
            {
                // 入力制御設定
                txtTightenDateYears.Enabled = true;
                txtTightenDateMonth.Enabled = true;
                cmbTightenType.Enabled = true;
                dtpTightenDate.Enabled = true;
                pnlBillingDate.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                pnlSalesDateFrom.Enabled = false;
                pnlSalesDateTo.Enabled = false;
                btnSearch.Enabled = true;
                btnExecution.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtTightenDateYears.Focus();

                // 背景色設定
                txtBillingDateYears.BackColor = Color.White;
                txtBillingDateMonth.BackColor = Color.White;
                txtBillingDateDays.BackColor = Color.White;
                txtSalesDateFromYears.BackColor = Color.White;
                txtSalesDateFromMonth.BackColor = Color.White;
                txtSalesDateFromDays.BackColor = Color.White;
                txtSalesDateToYears.BackColor = Color.White;
                txtSalesDateToMonth.BackColor = Color.White;
                txtSalesDateToDays.BackColor = Color.White;
            }
            // 個別更新
            else if (rdoIndividual.Checked)
            {
                // 入力制御設定
                txtTightenDateYears.Enabled = true;
                txtTightenDateMonth.Enabled = true;
                cmbTightenType.Enabled = true;
                dtpTightenDate.Enabled = true;
                pnlBillingDate.Enabled = true;
                txtCustomerCode.Enabled = true;
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                cmbOffices.Enabled = true;
                pnlSalesDateFrom.Enabled = true;
                pnlSalesDateTo.Enabled = true;
                btnSearch.Enabled = true;
                btnExecution.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtTightenDateYears.Focus();

                // 背景色設定
                txtBillingDateYears.BackColor = Color.White;
                txtBillingDateMonth.BackColor = Color.White;
                txtBillingDateDays.BackColor = Color.White;
                txtSalesDateFromYears.BackColor = Color.White;
                txtSalesDateFromMonth.BackColor = Color.White;
                txtSalesDateFromDays.BackColor = Color.White;
                txtSalesDateToYears.BackColor = Color.White;
                txtSalesDateToMonth.BackColor = Color.White;
                txtSalesDateToDays.BackColor = Color.White;
            }
            #endregion
            rdoAll.Click += new EventHandler(processingTargetRadio_Click);
            rdoIndividual.Click += new EventHandler(processingTargetRadio_Click);
            rdoUpdate.Click += new EventHandler(processingTypeRadio_Click);
            rdoCancel.Click += new EventHandler(processingTypeRadio_Click);
            flgSettingEnable = false;
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

            if (!string.IsNullOrEmpty(txtTightenDateYears.Text) ||
                !string.IsNullOrEmpty(txtTightenDateMonth.Text) ||
                !string.IsNullOrEmpty(txtBillingDateYears.Text) ||
                !string.IsNullOrEmpty(txtBillingDateMonth.Text) ||
                !string.IsNullOrEmpty(txtBillingDateDays.Text) ||
                !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                !string.IsNullOrEmpty(txtCustomerName.Text) ||
                !string.IsNullOrEmpty(txtCustomerKanaName.Text) ||
                !string.IsNullOrEmpty(cmbOffices.Text) ||
                !string.IsNullOrEmpty(txtSalesDateFromYears.Text) ||
                !string.IsNullOrEmpty(txtSalesDateFromMonth.Text) ||
                !string.IsNullOrEmpty(txtSalesDateFromDays.Text) ||
                !string.IsNullOrEmpty(txtSalesDateToYears.Text) ||
                !string.IsNullOrEmpty(txtSalesDateToMonth.Text) ||
                !string.IsNullOrEmpty(txtSalesDateToDays.Text))
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtBillingDateYears.MaxLength = 4;      // 請求日(年)
            txtBillingDateMonth.MaxLength = 2;      // 請求日(月)
            txtBillingDateDays.MaxLength = 2;       // 請求日(日)
            txtCustomerCode.MaxLength = 5;          // 得意先ｺｰﾄﾞ
            txtCustomerName.MaxLength = 15;         // 得意先名
            txtCustomerKanaName.MaxLength = 30;     // 得意先カナ名
            cmbOffices.MaxLength = 10;              // 事業所
            txtSalesDateFromYears.MaxLength = 4;    // 対象売上日付(FROM)(年)
            txtSalesDateFromMonth.MaxLength = 2;    // 対象売上日付(FROM)(月)
            txtSalesDateFromDays.MaxLength = 2;     // 対象売上日付(FROM)(日)
            txtSalesDateToYears.MaxLength = 4;      // 対象売上日付(TO)(年)
            txtSalesDateToMonth.MaxLength = 2;      // 対象売上日付(TO)(月)
            txtSalesDateToDays.MaxLength = 2;       // 対象売上日付(TO)(日)

            // 入力制御イベント設定
            txtBillingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 請求日(年):数字のみ入力可
            txtBillingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 請求日(月):数字のみ入力可
            txtBillingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 請求日(日):数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 得意先ｺｰﾄﾞ  :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);      // 得意先カナ名:全角カナのみ入力可
            txtSalesDateFromYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象売上日付(FROM)(年):数字のみ入力可
            txtSalesDateFromMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象売上日付(FROM)(月):数字のみ入力可
            txtSalesDateFromDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 対象売上日付(FROM)(日):数字のみ入力可
            txtSalesDateToYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 対象売上日付(TO)(年):数字のみ入力可
            txtSalesDateToMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 対象売上日付(TO)(月):数字のみ入力可
            txtSalesDateToDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 対象売上日付(TO)(日):数字のみ入力可
        }
        #endregion

        #region 必須入力チェック
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = false;
            string errorItem = string.Empty;

            // 処理対象 = "全件更新"の場合
            if (rdoAll.Checked)
            {
                // 請求締日が未入力の場合エラー
                if (string.IsNullOrEmpty(txtTightenDateYears.Text) ||
                    string.IsNullOrEmpty(txtTightenDateMonth.Text))
                {
                    errorItem = lblTightenDate.Text;
                }
                // 請求日が未入力の場合エラー
                else if (string.IsNullOrEmpty(txtBillingDateYears.Text) ||
                         string.IsNullOrEmpty(txtBillingDateMonth.Text) ||
                         string.IsNullOrEmpty(txtBillingDateDays.Text))
                {
                    errorItem = lblBillingDate.Text;
                }
            }
            // 処理対象 = "個別更新"の場合
            else if (rdoIndividual.Checked)
            {
                // 請求締日が未入力の場合エラー
                if (string.IsNullOrEmpty(txtTightenDateYears.Text) ||
                    string.IsNullOrEmpty(txtTightenDateMonth.Text))
                {
                    errorItem = lblTightenDate.Text;
                }
                // 請求日が未入力の場合エラー
                else if (string.IsNullOrEmpty(txtBillingDateYears.Text) ||
                         string.IsNullOrEmpty(txtBillingDateMonth.Text) ||
                         string.IsNullOrEmpty(txtBillingDateDays.Text))
                {
                    errorItem = lblBillingDate.Text;
                }
                // 得意先コードが未入力の場合エラー
                else if (string.IsNullOrEmpty(txtCustomerCode.Text))
                {
                    errorItem = lblCustomerCode.Text;
                }
            }

            // 締日区分が随時の場合
            if (string.IsNullOrEmpty(errorItem) && Consts.FromTimeToTimeValue.Equals(Convert.ToString(cmbTightenType.SelectedValue)))
            {
                // 対象売上日付が未入力の場合エラー
                if (string.IsNullOrEmpty(txtSalesDateFromYears.Text) ||
                    string.IsNullOrEmpty(txtSalesDateFromMonth.Text) ||
                    string.IsNullOrEmpty(txtSalesDateFromDays.Text) ||
                    string.IsNullOrEmpty(txtSalesDateToYears.Text) ||
                    string.IsNullOrEmpty(txtSalesDateToMonth.Text) ||
                    string.IsNullOrEmpty(txtSalesDateToDays.Text))
                {
                    errorItem = lblSalesDate.Text;
                }
                // 得意先が未入力の場合エラー
                if (string.IsNullOrEmpty(txtCustomerCode.Text))
                {
                    errorItem = lblCustomerCode.Text;
                }
            }

            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                ret = true;
            }

            return ret;
        }
        #endregion

        #region 相関チェック
        /// <summary>
        /// 相関チェック
        /// </summary>
        /// <returns></returns>
        private bool checkCorrelation()
        {
            bool ret = false;

            string tightenType;
            // 締日 = "月末"の場合
            if (Consts.EndOfMonthText.Equals(cmbTightenType.Text))
            {
                // 月末日取得処理を実行
                tightenType = commonLogic.GetEndOfMonth(txtTightenDateYears.Text, txtTightenDateMonth.Text);
            }
            else
            {
                tightenType = cmbTightenType.Text;
            }
            DateTime shimebiTo = Convert.ToDateTime(txtTightenDateYears.Text + "/" + txtTightenDateMonth.Text + "/" + tightenType);
            DateTime shimebiFrom = shimebiTo.AddMonths(-1).AddDays(1);
            if (Consts.EndOfMonthText.Equals(cmbTightenType.Text))
            {
                shimebiFrom = Convert.ToDateTime(shimebiTo.Year + "/" + shimebiTo.Month + "/01");
            }
            DateTime seikyubi = Convert.ToDateTime(txtBillingDateYears.Text + "/" + txtBillingDateMonth.Text + "/" + txtBillingDateDays.Text);

            // 請求日が締日範囲外の場合
            if (!(shimebiFrom <= seikyubi && seikyubi <= shimebiTo))
            {
                errorOK(string.Format(Messages.M0040
                                    , shimebiFrom.Year
                                    , shimebiFrom.Month
                                    , shimebiFrom.Day
                                    , shimebiTo.Year
                                    , shimebiTo.Month
                                    , shimebiTo.Day));
                ret = true;
            }

            // 対象売上日付の一部が入力されている場合
            if (!string.IsNullOrEmpty(txtSalesDateFromYears.Text) ||
                !string.IsNullOrEmpty(txtSalesDateFromMonth.Text) ||
                !string.IsNullOrEmpty(txtSalesDateFromDays.Text) ||
                !string.IsNullOrEmpty(txtSalesDateToYears.Text) ||
                !string.IsNullOrEmpty(txtSalesDateToMonth.Text) ||
                !string.IsNullOrEmpty(txtSalesDateToDays.Text))
            {
                if (string.IsNullOrEmpty(txtSalesDateFromYears.Text) ||
                    string.IsNullOrEmpty(txtSalesDateFromMonth.Text) ||
                    string.IsNullOrEmpty(txtSalesDateFromDays.Text) ||
                    string.IsNullOrEmpty(txtSalesDateToYears.Text) ||
                    string.IsNullOrEmpty(txtSalesDateToMonth.Text) ||
                    string.IsNullOrEmpty(txtSalesDateToDays.Text))
                {
                    errorOK(string.Format(Messages.M0041));
                    ret = true;
                }
            }

            // 処理対象 = "個別更新"の場合
            if (rdoIndividual.Checked && rdoCancel.Checked)
            {
                DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
                // 得意先情報を取得
                DataTable dt = tokuisakiM.getTokuisakiDataTable(txtCustomerCode.Text, Convert.ToString(cmbOffices.SelectedValue));
                if (dt != null &&
                    dt.Rows.Count > 0 &&
                    !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcSeikyusakiCode])))
                {
                    errorOK(string.Format(Messages.M0065));
                    ret = true;
                }
            }


            return ret;
        }
        #endregion

        #endregion
    }
}
