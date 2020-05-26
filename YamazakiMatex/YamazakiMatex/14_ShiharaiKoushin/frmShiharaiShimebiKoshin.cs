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

namespace ShiharaiKoushin
{
    /// <summary>
    /// 支払締日更新処理画面
    /// </summary>
    public partial class frmShiharaiShimebiKoshin : ChildBaseForm
    {
        #region 変数宣言
        private bool flgSaving = false;
        private RadioButton activeRadioButton = null;
        private bool flgInit = false;
        private DateTime syoriDate;
        private bool flgSettingEnable = false;
        private DBKanriMaster kanriMaster;
        private DBMeisyoMaster meisyoMaster;
        private DBShiresakiMaster shiresakiMaster;
        private CommonLogic commonLogic;
        private bool flgBtnSearchSelect = false;
        private DBShiharaiShime shiharaiShimeDb;
        private enum LastInputDateType
        {
            None = 0
          , TightenDate = 1
          , BillingDate = 2
          , SalesDateFrom = 3
          , SalesDateTo = 4
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        sfrmShiiresakiSearch fShiiresaki;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmShiharaiShimebiKoshin()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            meisyoMaster = new DBMeisyoMaster();
            shiresakiMaster = new DBShiresakiMaster();
            shiharaiShimeDb = new DBShiharaiShime();
            commonLogic = new CommonLogic();
            fShiiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiharaiShimebiKoshin_Load(object sender, EventArgs e)
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
            // 入力情報設定
            setInputInfo();
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

        #region 仕入先コードのフォーカスアウトイベント
        /// <summary>
        /// 仕入先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 仕入先情報の設定
                setShiresakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), false);

            }
            else
            {
                txtVendorCode.Text = string.Empty;
                txtVendorName.Text = string.Empty;
                cmbTightenType.Enabled = true;
            }
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

            // 仕入先ｺｰﾄﾞを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtVendorCode.Name))
            {
                // 仕入先検索画面を起動
                fShiiresaki.ShowDialog();

                // 仕入先検索画面で確認ボタンが押下された場合
                if (fShiiresaki.DialogResult == DialogResult.OK)
                {
                    string shiresakiCode = fShiiresaki.SelectedShiresakiCodes[0];
                    // 得意先情報設定処理
                    setShiresakiInfo(shiresakiCode, true);
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

            shiharaiShimeDb.startTransaction();

            DBShiharaiShime.UpdateCriteria updateCriteria = new DBShiharaiShime.UpdateCriteria();

            updateCriteria.ProcessType = rdoUpdate.Checked ? DBShiharaiShime.UpdateCriteria.ProcessingType.UpDate : DBShiharaiShime.UpdateCriteria.ProcessingType.Cancel;
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
            updateCriteria.VendorCode = txtVendorCode.Text;
            updateCriteria.VendorName = txtVendorName.Text;

            DBShiharaiShime.UpdateCheckResult chkResult = shiharaiShimeDb.checkShiharaiShime(ref updateCriteria);
            // ロックエラーが発生した場合
            if (DBShiharaiShime.UpdateCheckResult.DataLock.Equals(chkResult))
            {
                errorOK(Messages.M0035);
            }
            // 締日に該当する得意先が存在しない場合
            else if (DBShiharaiShime.UpdateCheckResult.NoMasterData.Equals(chkResult))
            {
                messageOK(Messages.M0036);
            }
            // 更新対象のデータが存在しない場合
            else if (DBShiharaiShime.UpdateCheckResult.NoExistsTargetData.Equals(chkResult))
            {
                messageOK(Messages.M0037);
            }
            // 上記以外の場合
            else if (DBShiharaiShime.UpdateCheckResult.ExistsTargetData.Equals(chkResult))
            {
                // 確認メッセージの表示
                string msgCode = rdoUpdate.Checked ? Messages.M0038 : Messages.M0039;

                if (queryYesNo(string.Format(msgCode, updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth)) == DialogResult.Yes)
                {
                    // 締日更新処理実行
                    DBShiharaiShime.UpdateResult upResult = shiharaiShimeDb.executeShiharaiShime(updateCriteria);
                    if (upResult == DBShiharaiShime.UpdateResult.Normal)
                    {
                        messageOK(string.Format(Messages.M0042, updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth, rdoUpdate.Checked ? "締日更新" : "取消"));
                    }
                    else
                    {
                        errorOK(string.Format(Messages.M0043, updateCriteria.TightenDateYears, updateCriteria.TightenDateMonth, rdoUpdate.Checked ? "締日更新" : "取消"));
                    }
                }
            }

            shiharaiShimeDb.endTransaction();
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
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            closedForm();
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
                        d = txtTightenDateDays.Text;
                        inputObj = dtpTightenDate;
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

        #region 締区分コンボボックス変更イベント
        /// <summary>
        /// 締区分コンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTightenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Consts.FromTimeToTimeValue.Equals(Convert.ToString(cmbTightenType.SelectedValue)))
            {
                txtTightenDateDays.Text = string.Empty;
                txtTightenDateDays.Enabled = true;
            }
            else if (Consts.EndOfMonthValue.Equals(Convert.ToString(cmbTightenType.SelectedValue)))
            {
                // 月末日取得処理を実行
                txtTightenDateDays.Text = commonLogic.GetEndOfMonth(txtTightenDateMonth.Text, txtTightenDateYears.Text);
                txtTightenDateDays.Enabled = false;
            }
            else
            {
                txtTightenDateDays.Text = cmbTightenType.Text;
                txtTightenDateDays.Enabled = false;
            }
        }
        #endregion

        #region 締年月変更イベント
        /// <summary>
        /// 締年月変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTightenMonthYears_TextChanged(object sender, EventArgs e)
        {
            if (Consts.EndOfMonthValue.Equals(Convert.ToString(cmbTightenType.SelectedValue)))
            {
                // 月末日取得処理を実行
                txtTightenDateDays.Text = commonLogic.GetEndOfMonth(txtTightenDateMonth.Text, txtTightenDateYears.Text);
                txtTightenDateDays.Enabled = false;
            }
        }
        #endregion

        #endregion

        #region ビジネスロジック

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
                !string.IsNullOrEmpty(txtVendorCode.Text) ||
                !string.IsNullOrEmpty(txtVendorName.Text))
            {
                result = true;
            }

            return result;
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
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            setTightenTypeCmb();
            #endregion

            // モード別編集可否設定
            setEnabled();
            flgInit = false;
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
                txtVendorCode.Enabled = false;
                txtVendorName.Enabled = false;
                btnSearch.Enabled = true;
                btnExecution.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtTightenDateYears.Focus();

                txtTightenDateDays.BackColor = Color.White;
            }
            // 個別更新
            else if (rdoIndividual.Checked)
            {
                // 入力制御設定
                txtTightenDateYears.Enabled = true;
                txtTightenDateMonth.Enabled = true;
                cmbTightenType.Enabled = true;
                dtpTightenDate.Enabled = true;
                txtVendorCode.Enabled = true;
                txtVendorName.Enabled = Consts.OthersVendorCode.Equals(txtVendorCode.Text); ;
                btnSearch.Enabled = true;
                btnExecution.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtTightenDateYears.Focus();

                txtTightenDateDays.BackColor = Color.White;
            }
            #endregion
            rdoAll.Click += new EventHandler(processingTargetRadio_Click);
            rdoIndividual.Click += new EventHandler(processingTargetRadio_Click);
            rdoUpdate.Click += new EventHandler(processingTypeRadio_Click);
            rdoCancel.Click += new EventHandler(processingTypeRadio_Click);
            flgSettingEnable = false;
        }
        #endregion

        #region 締区分コンボボックスの設定処理
        /// <summary>
        /// 締区分コンボボックスの設定処理
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
                c.Name.Equals(txtTightenDateDays.Name) ||
                c.Name.Equals(dtpTightenDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.tightenDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.tightenDate_Leave);
            }
            // 仕入先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtVendorCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtVendorCode_Leave);
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
            // 仕入先ｺｰﾄﾞを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtVendorCode.Name))
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTightenDateYears.MaxLength = 4;  // 請求締日(年)
            txtTightenDateMonth.MaxLength = 2;  // 請求締日(月)
            txtTightenDateDays.MaxLength = 2;  // 請求締日(日)
            txtVendorCode.MaxLength = 3;        // 仕入先コード
            txtVendorName.MaxLength = 30;       // 仕入先名

            // 入力制御イベント設定
            txtTightenDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求締日(年):数字のみ入力可
            txtTightenDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求締日(月):数字のみ入力可
            txtTightenDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 請求締日(日):数字のみ入力可
            txtVendorCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 得意先ｺｰﾄﾞ  :数字のみ入力可
        }
        #endregion

        #region 仕入先情報設定処理
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setShiresakiInfo(string shiresakiCode, bool flgUnconditional)
        {
            // 仕入先情報の取得
            List<DBFileLayout.ShiresakiMasterFile> shiresakiInfo = shiresakiMaster.getShiresakiInfo(shiresakiCode);
            if (shiresakiInfo == null || shiresakiInfo.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "仕入先ｺｰﾄﾞ"));
                txtVendorCode.Focus();
                return;
            }

            if (flgUnconditional || txtVendorCode.BeforeValue != shiresakiCode)
            {
                if (Consts.OthersVendorCode.Equals(shiresakiCode))
                {
                    txtVendorCode.Text = shiresakiInfo[0].ShiresakiCode;
                    txtVendorName.Text = string.Empty;
                    cmbTightenType.SelectedValue = "99";
                }
                else
                {
                    txtVendorCode.Text = shiresakiInfo[0].ShiresakiCode;
                    txtVendorName.Text = shiresakiInfo[0].ShiresakiName;
                    cmbTightenType.SelectedValue = shiresakiInfo[0].Shimebi;
                }
                // 入力可否設定
                txtVendorName.Enabled = Consts.OthersVendorCode.Equals(txtVendorCode.Text);
                cmbTightenType.Enabled = false;
            }
            else
            {
                txtVendorCode.Text = shiresakiCode;
            }

            txtVendorCode.BeforeValue = txtVendorCode.Text;
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

            // 請求締日が未入力の場合エラー
            if (string.IsNullOrEmpty(txtTightenDateYears.Text) ||
                string.IsNullOrEmpty(txtTightenDateMonth.Text) ||
                string.IsNullOrEmpty(txtTightenDateDays.Text))
            {
                errorItem = lblTightenDate.Text;
            }

            // 処理対象 = "個別更新"の場合
            if (rdoIndividual.Checked)
            {
                // 仕入先が未入力の場合エラー
                if (string.IsNullOrEmpty(txtVendorCode.Text))
                {
                    errorItem = lblVendorCode.Text;
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

        #endregion
    }
}
