using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using Resorce;
using Common;
using SubForm;

namespace Shiharai
{
    /// <summary>
    /// 支払入力
    /// </summary>
    public partial class frmShiharaiInput : Common.ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private DBShiresakiMaster shiresakiMaster;
        DBShiharai shiharaiDataDb;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , PaymentDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private bool flgBtnSearchSelect = false;
        private bool flgSetData = false;
        private string amountFormat;
        private string totalAmountFormat;
        sfrmShiharaiSearch sShiharai;
        sfrmShiiresakiSearch sShiresaki;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmShiharaiInput()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            shiharaiDataDb = new DBShiharai();
            shiresakiMaster = new DBShiresakiMaster();
            commonLogic = new CommonLogic();
            sShiharai = new sfrmShiharaiSearch(false, CheckMessageType.None);
            sShiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiharaiInput_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtPaymentNo;
            // 金額フォーマット文字列取得
            amountFormat = commonLogic.getNumberFormatString(txtTransfer.MaxLength, 0);
            // 合計金額フォーマット文字列取得
            totalAmountFormat = commonLogic.getNumberFormatString(txtTotal.MaxLength, 0);

            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 入力情報設定
            setInputInfo();
        }
        #endregion

        #region 画面モードラジオボタン押下イベント
        /// <summary>
        /// 画面モードラジオボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputModeRadio_Click(object sender, EventArgs e)
        {
            string queryMeaasage = string.Empty;
            string str1 = "処理モードを変更してよろしいですか？";
            RadioButton radio = (RadioButton)sender;
            if (!flgSaving && activeRadioButton != null && activeRadioButton.Name == radio.Name) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoDelete.Checked)
                {
                    queryMeaasage = Messages.M0015;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoNew.Checked = (rdoNew.Name == radio.Name);
            rdoCorrection.Checked = (rdoCorrection.Name == radio.Name);
            rdoReference.Checked = (rdoReference.Name == radio.Name);
            rdoDelete.Checked = (rdoDelete.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
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

        #region 数値のみ入力可能項目のキー押下イベント
        /// <summary>
        /// 数値のみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数値のみ入力可能項目の制御処理を実行
            commonLogic.inputNumberOnly_KeyPress(e, (TextBox)sender, ((TextBox)sender).MaxLength, 0);
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
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.PaymentDate:
                        y = txtPaymentDateYears.Text;
                        m = txtPaymentDateMonth.Text;
                        d = txtPaymentDateDays.Text;
                        inputObj = dtpPaymentDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.PaymentDate.Equals(lastInputDateType))
                    {
                        txtPaymentDateYears.Focus();
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
                    btnSave_Click(null, null);
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

        #region 支払日付のフォーカスインイベント
        /// <summary>
        /// 支払日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paymentDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.PaymentDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 支払日付のフォーカスアウトイベント
        /// <summary>
        /// 支払日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paymentDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.PaymentDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.PaymentDate;
            }
        }
        #endregion

        #region 支払Noのフォーカスアウトイベント
        /// <summary>
        /// 支払Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPaymentNo_Leave(object sender, EventArgs e)
        {
            if (flgSetData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                flgSetData = true;
                // 支払情報設定処理を実行
                bool ret = setShiharaiData(commonLogic.getZeroBuriedNumberText(txtPaymentNo.Text, txtPaymentNo.MaxLength));

                if (ret)
                {
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                else
                {
                    text.Focus();
                }
                flgSetData = false;
            }
        }
        #endregion

        #region 仕入先コードのフォーカスアウトイベント
        /// <summary>
        /// 仕入先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPurchaseCode_Leave(object sender, EventArgs e)
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
                txtPurchaseCode.Text = string.Empty;
                txtZipCode.Text = string.Empty;
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
            }
        }
        #endregion

        #region 金額項目のフォーカスアウトイベント
        /// <summary>
        /// 金額項目コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void amount_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (!text.Enabled) return;

            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                text.Text = Convert.ToDecimal(text.Text).ToString(amountFormat);
            }

            // 合計金額の再計算
            recalcSyukei();
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
            CheckMessageType messageType = CheckMessageType.inputDataUpdateQuery;
            if ((rdoCorrection.Checked && !flgSearch) ||
                rdoReference.Checked ||
                (rdoDelete.Checked && !flgSearch))
            {
                messageType = CheckMessageType.None;
            }
            // 支払Noを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtPaymentNo.Name))
            {
                // 支払検索画面を起動
                sShiharai.MType = messageType;
                sShiharai.ShowDialog();

                if (sShiharai.DialogResult == DialogResult.OK)
                {
                    flgSearch = false;
                    // 支払情報の設定
                    setShiharaiData(sShiharai.SelectedShireInfos[0].ShiharaiNo);
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                flgSetFocus = true;
            }
            // 仕入先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtPurchaseCode.Name))
            {
                // 仕入先検索画面を起動
                sShiresaki.ShowDialog();

                // 仕入先検索画面で確認ボタンが押下された場合
                if (sShiresaki.DialogResult == DialogResult.OK)
                {
                    // 仕入先情報設定処理
                    setShiresakiInfo(sShiresaki.SelectedShiresakiCodes[0], true);
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
        }
        #endregion

        #region 印刷ボタンイベント
        /// <summary>
        /// 印刷ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // TODO
        }
        #endregion

        #region 保存ボタン押下イベント
        /// <summary>
        /// 保存ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;
            flgSaving = true;
            // チェック処理
            if (!checkRequired())
            {
                flgSaving = false;
                return;
            }

            string queryMessage = string.Empty;
            if (rdoNew.Checked)
            {
                queryMessage = Messages.M0001;
            }
            else if (rdoCorrection.Checked)
            {
                queryMessage = Messages.M0001;
            }
            else if (rdoDelete.Checked)
            {
                queryMessage = Messages.M0002;
            }

            // 処理実行確認
            if (queryYesNo(queryMessage) == DialogResult.Yes)
            {
                string shiharaiNo = txtPaymentNo.Text;
                DateTime registerDate = DateTime.Now;
                string sqlShiharaiCommand = createShiharaiRegistSql(ref shiharaiNo, registerDate);
                string sqlKanriMasterCommand = rdoNew.Checked ? createKanriMasterRegistSql(shiharaiNo, registerDate) : string.Empty;
                int shiharaiRegistResult = 0;
                int kanriMasterRegistResult = 0;
                shiharaiDataDb.DBRef = 0;

                if (rdoNew.Checked)
                {
                    shiharaiDataDb.startTransaction();
                    // 管理マスタ(支払No)のロック
                    shiharaiDataDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.ShiharaiNo + "'", true);
                    if (shiharaiDataDb.DBRef != 0)
                    {
                        shiharaiDataDb.endTransaction();
                        errorOK("支払Noロックエラー");
                        flgSaving = false;
                        return;
                    }
                }

                // 支払データの更新
                shiharaiRegistResult = shiharaiDataDb.executeDBUpdate(sqlShiharaiCommand);

                // 管理マスタの更新
                if (shiharaiDataDb.DBRef == 0 && !string.IsNullOrEmpty(sqlKanriMasterCommand)) kanriMasterRegistResult = shiharaiDataDb.executeDBUpdate(sqlKanriMasterCommand);

                if (shiharaiDataDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (shiharaiRegistResult < 0 || kanriMasterRegistResult < 0)
                    {
                        tableName = "支払データ";
                    }
                    if (rdoNew.Checked)
                    {
                        processName = "登録処理";
                    }
                    else if (rdoCorrection.Checked)
                    {
                        processName = "更新処理";
                    }
                    else if (rdoDelete.Checked)
                    {
                        processName = "削除処理";
                    }
                    if (rdoNew.Checked) shiharaiDataDb.endTransaction();
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "支払No:" + shiharaiNo;
                    string message2;
                    if (rdoNew.Checked)
                    {
                        message2 = "登録";
                    }
                    else if (rdoCorrection.Checked)
                    {
                        message2 = "訂正";
                    }
                    else
                    {
                        message2 = "削除";
                    }
                    if (rdoNew.Checked) shiharaiDataDb.endTransaction();
                    messageOK(string.Format(Messages.M0012, message1, message2));
                    btnCancel_Click(null, null);
                }
            }
            flgSaving = false;
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
                string queryMeaasage = string.Empty;
                string str1 = "取消してよろしいですか？";
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoDelete.Checked)
                {
                    queryMeaasage = Messages.M0015;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }
            RadioButton activeModeRdo = null;
            if (rdoNew.Checked)
            {
                activeModeRdo = rdoNew;
            }
            else if (rdoCorrection.Checked)
            {
                activeModeRdo = rdoCorrection;
            }
            else if (rdoReference.Checked)
            {
                activeModeRdo = rdoReference;
            }
            else if (rdoDelete.Checked)
            {
                activeModeRdo = rdoDelete;
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
            if (!btnClose.Enabled) return;
            // トランザクション開始済みの場合
            if (shiharaiDataDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                shiharaiDataDb.endTransaction();
            }
            closedForm();
        }
        #endregion

        #endregion

        #region ビジネスロジック

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

            // トランザクション開始済みの場合
            if (shiharaiDataDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                shiharaiDataDb.endTransaction();
            }

            activeRadioButton = radio;
            #region 共通初期値設定
            txtPaymentNo.Text = string.Empty;
            dtpPaymentDate.Value = syoriDate.AddDays(1);
            dtpPaymentDate.Value = syoriDate;
            txtPurchaseCode.Text = string.Empty;
            txtPurchaseName.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtTransfer.Text = string.Empty;
            txtBills.Text = string.Empty;
            txtCash.Text = string.Empty;
            txtOffset.Text = string.Empty;
            txtTotal.Text = string.Empty;

            #endregion

            flgSearch = false;
            // モード別編集可否設定
            setEnabled();
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
            rdoNew.Click -= new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            rdoDelete.Click -= new EventHandler(inputModeRadio_Click);
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                // 入力制御設定
                txtPaymentNo.Enabled = true;
                txtPaymentNo.ReadOnly = true;
                txtPaymentDateYears.Enabled = true;
                txtPaymentDateMonth.Enabled = true;
                txtPaymentDateDays.Enabled = true;
                dtpPaymentDate.Enabled = true;
                txtPurchaseCode.Enabled = true;
                txtPurchaseName.Enabled = true;
                txtTransfer.Enabled = true;
                txtBills.Enabled = true;
                txtCash.Enabled = true;
                txtOffset.Enabled = true;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPaymentNo.Focus();

                // 背景色設定
                txtPaymentDateYears.BackColor = Color.White;
                txtPaymentDateMonth.BackColor = Color.White;
                txtPaymentDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtPaymentNo.Enabled = !flgSearch;
                txtPaymentNo.ReadOnly = false;
                txtPaymentDateYears.Enabled = flgSearch;
                txtPaymentDateMonth.Enabled = flgSearch;
                txtPaymentDateDays.Enabled = flgSearch;
                dtpPaymentDate.Enabled = flgSearch;
                txtPurchaseCode.Enabled = flgSearch;
                txtPurchaseName.Enabled = flgSearch;
                txtTransfer.Enabled = flgSearch;
                txtBills.Enabled = flgSearch;
                txtCash.Enabled = flgSearch;
                txtOffset.Enabled = flgSearch;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                bool setFocus = !flgSearch ? txtPaymentNo.Focus() : txtPaymentDateYears.Focus();

                // 背景色設定
                txtPaymentDateYears.BackColor = Color.White;
                txtPaymentDateMonth.BackColor = Color.White;
                txtPaymentDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtPaymentNo.Enabled = !flgSearch;
                txtPaymentNo.ReadOnly = false;
                txtPaymentDateYears.Enabled = false;
                txtPaymentDateMonth.Enabled = false;
                txtPaymentDateDays.Enabled = false;
                dtpPaymentDate.Enabled = false;
                txtPurchaseCode.Enabled = false;
                txtPurchaseName.Enabled = false;
                txtTransfer.Enabled = false;
                txtBills.Enabled = false;
                txtCash.Enabled = false;
                txtOffset.Enabled = false;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPaymentNo.Focus();

                // 背景色設定
                txtPaymentDateYears.BackColor = Color.White;
                txtPaymentDateMonth.BackColor = Color.White;
                txtPaymentDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtPaymentNo.Enabled = !flgSearch;
                txtPaymentNo.ReadOnly = false;
                txtPaymentDateYears.Enabled = false;
                txtPaymentDateMonth.Enabled = false;
                txtPaymentDateDays.Enabled = false;
                dtpPaymentDate.Enabled = false;
                txtPurchaseCode.Enabled = false;
                txtPurchaseName.Enabled = false;
                txtTransfer.Enabled = false;
                txtBills.Enabled = false;
                txtCash.Enabled = false;
                txtOffset.Enabled = false;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = false;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPaymentNo.Focus();

                // 背景色設定
                txtPaymentDateYears.BackColor = Color.White;
                txtPaymentDateMonth.BackColor = Color.White;
                txtPaymentDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：実行";
            }
            #endregion
            rdoNew.Click += new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
            rdoDelete.Click += new EventHandler(inputModeRadio_Click);
            flgSettingEnable = false;
        }
        #endregion

        #region 処理モード別変更チェック処理
        /// <summary>
        /// 処理モード別変更チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkDataChange()
        {
            bool result = false;
            // 処理モード別の変更チェック処理
            if (rdoNew.Checked)
            {
                string shiharaiDate = commonLogic.convertDateTime(txtPaymentDateYears.Text, txtPaymentDateMonth.Text, txtPaymentDateDays.Text).ToString("yyyy/MM/dd");
                if (!string.IsNullOrEmpty(txtPaymentNo.Text) ||
                    !shiharaiDate.Equals(syoriDate.ToString("yyyy/MM/dd")) ||
                    !string.IsNullOrEmpty(txtPurchaseCode.Text) ||
                    !string.IsNullOrEmpty(txtPurchaseName.Text) ||
                    !string.IsNullOrEmpty(txtTransfer.Text) ||
                    !string.IsNullOrEmpty(txtBills.Text) ||
                    !string.IsNullOrEmpty(txtCash.Text) ||
                    !string.IsNullOrEmpty(txtOffset.Text) ||
                    !string.IsNullOrEmpty(txtTotal.Text))
                {
                    result = true;
                }
            }
            else if (rdoCorrection.Checked)
            {
                if (flgSearch)
                {
                    result = true;
                }
            }
            else if (rdoDelete.Checked)
            {
                if (flgSearch)
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion

        #region 入力情報設定処理
        /// <summary>
        /// 入力情報設定処理
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtPaymentNo.MaxLength = 8;
            txtPaymentDateYears.MaxLength = 4;
            txtPaymentDateMonth.MaxLength = 2;
            txtPaymentDateDays.MaxLength = 2;
            txtPurchaseCode.MaxLength = 3;
            txtPurchaseName.MaxLength = 15;
            txtTransfer.MaxLength = 8;
            txtBills.MaxLength = 8;
            txtCash.MaxLength = 8;
            txtOffset.MaxLength = 8;
            txtTotal.MaxLength = 15;

            // 入力制御イベント設定
            txtPaymentNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 支払No       :数字のみ入力可
            txtPaymentDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 支払日付(年) :数字のみ入力可
            txtPaymentDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 支払日付(月) :数字のみ入力可
            txtPaymentDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 支払日付(日) :数字のみ入力可
            txtPurchaseCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 仕入先コード :数字のみ入力可
            txtTransfer.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);          // 振込         :数値のみ入力可
            txtBills.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);             // 手形         :数値のみ入力可
            txtCash.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);              // 現金         :数値のみ入力可
            txtOffset.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);            // 相殺         :数値のみ入力可
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

            // 支払Noの場合
            if (c.Name.Equals(txtPaymentNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtPaymentNo_Leave);
            }
            // 支払日付の場合
            else if (c.Name.Equals(txtPaymentDateYears.Name) ||
                     c.Name.Equals(txtPaymentDateMonth.Name) ||
                     c.Name.Equals(txtPaymentDateDays.Name) ||
                     c.Name.Equals(dtpPaymentDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.paymentDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.paymentDate_Leave);
            }
            // 仕入先コードの場合
            else if (c.Name.Equals(txtPurchaseCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtPurchaseCode_Leave);
            }
            // 金額項目の場合
            else if (c.Name.Equals(txtTransfer.Name) ||
                     c.Name.Equals(txtBills.Name) ||
                     c.Name.Equals(txtCash.Name) ||
                     c.Name.Equals(txtOffset.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.amount_Leave);
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
            // 新規作成でないかつ支払Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtPaymentNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 仕入先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtPurchaseCode.Name))
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
                txtPurchaseCode.Focus();
                return;
            }

            if (flgUnconditional || txtPurchaseCode.BeforeValue != shiresakiCode)
            {
                if (Consts.OthersVendorCode.Equals(shiresakiCode))
                {
                    txtPurchaseCode.Text = shiresakiInfo[0].ShiresakiCode;
                    txtPurchaseName.Text = string.Empty;
                    txtZipCode.Text = string.Empty;
                    txtAddress1.Text = string.Empty;
                    txtAddress2.Text = string.Empty;
                }
                else
                {
                    txtPurchaseCode.Text = shiresakiInfo[0].ShiresakiCode;
                    txtPurchaseName.Text = shiresakiInfo[0].ShiresakiName;
                    txtZipCode.Text = shiresakiInfo[0].ZipCode;
                    txtAddress1.Text = shiresakiInfo[0].Address1;
                    txtAddress2.Text = shiresakiInfo[0].Address2;
                }
                // 入力可否設定
                txtPurchaseName.Enabled = Consts.OthersVendorCode.Equals(txtPurchaseCode.Text);
            }
            else
            {
                txtPurchaseCode.Text = shiresakiCode;
            }

            txtPurchaseCode.BeforeValue = txtPurchaseCode.Text;
        }
        #endregion

        #region 支払データ設定処理
        /// <summary>
        /// 支払データ設定処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <returns></returns>
        private bool setShiharaiData(string shiharaiNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            // トランザクション開始処理を実行
            shiharaiDataDb.startTransaction();
            if (rdoNew.Checked) shiharaiDataDb.endTransaction();

            // 取得時にエラーが発生した場合
            if (shiharaiDataDb.getShiharaiData(shiharaiNo) != DBShiharai.SelectErrorType.None)
            {
                errorOK(string.Format(Messages.M0027, "支払データ"));
                return false;
            }

            DBFileLayout.ShiharaiFile data = shiharaiDataDb.SelectShiharaiData;

            // 支払データが存在する場合
            if (data.FlgDataExsit)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(data.KanriKubun)))
                {
                    string msg1 = rdoCorrection.Checked ? "訂正" : rdoReference.Checked ? "参照" : "削除";
                    errorOK(string.Format(Messages.M0013, "削除", "支払データ", msg1));
                    return false;
                }
            }
            // 支払ヘッダデータが存在しない場合
            else
            {
                string messageText = lblPaymentNo.Text;
                // エラーメッセージを出力して処理を終了
                errorOK(string.Format(Messages.M0003, messageText));
                return false;
            }

            // 取得した支払データを画面項目に設定します
            if (!rdoNew.Checked) txtPaymentNo.Text = data.ShiharaiNo;
            dtpPaymentDate.Value = Convert.ToDateTime(data.ShiharaiHizuke);
            txtPurchaseCode.Text = data.ShiresakiCode;
            txtPurchaseName.Text = data.ShiresakiName;
            txtZipCode.Text = data.ZipCode;
            txtAddress1.Text = data.Addres1;
            txtAddress2.Text = data.Addres2;
            string strGenkin = data.Genkin == null ? string.Empty : Convert.ToDecimal(data.Genkin).ToString(amountFormat);
            string strTegata = data.Tegata == null ? string.Empty : Convert.ToDecimal(data.Tegata).ToString(amountFormat);
            string strHurikomi = data.Hurikomi == null ? string.Empty : Convert.ToDecimal(data.Hurikomi).ToString(amountFormat);
            string strSousai = data.Sousai == null ? string.Empty : Convert.ToDecimal(data.Sousai).ToString(amountFormat);
            string strGoukei = data.Goukei == null ? string.Empty : Convert.ToDecimal(data.Goukei).ToString(amountFormat);
            txtTransfer.Text = strHurikomi;
            txtBills.Text = strTegata;
            txtCash.Text = strGenkin;
            txtOffset.Text = strSousai;
            txtTotal.Text = strGoukei;

            // 検索実行済みフラグにtrueを設定
            flgSearch = true;

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 金額集計処理
        /// <summary>
        /// 金額集計処理
        /// </summary>
        private void recalcSyukei()
        {
            bool flgAmountCalc = false;
            decimal amount = decimal.Zero;
            decimal totalAmount = decimal.Zero;

            // 現金集計
            if (decimal.TryParse(txtCash.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // 手形集計
            if (decimal.TryParse(txtBills.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // 振込集計
            if (decimal.TryParse(txtTransfer.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // 相殺集計
            if (decimal.TryParse(txtOffset.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }

            // 何れかの金額が集計されている場合
            if (flgAmountCalc)
            {
                txtTotal.Text = totalAmount.ToString(totalAmountFormat);
            }
            else
            {
                txtTotal.Text = string.Empty;
            }
        }
        #endregion

        #region 必須入力チェック
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;
            string errorItem = string.Empty;

            if (string.IsNullOrEmpty(txtPaymentDateYears.Text) ||
                string.IsNullOrEmpty(txtPaymentDateMonth.Text) ||
                string.IsNullOrEmpty(txtPaymentDateDays.Text))
            {
                errorItem = lblPaymentDate.Text;
            }
            else if (string.IsNullOrEmpty(txtPurchaseCode.Text))
            {
                errorItem = lblPurchaseCode.Text;
            }
            else if (string.IsNullOrEmpty(txtPurchaseName.Text))
            {
                errorItem = lblPurchaseName.Text;
            }
            else if (string.IsNullOrEmpty(txtTotal.Text))
            {
                errorItem = "金額";
            }

            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 支払データ登録・更新SQL生成処理
        /// <summary>
        /// 支払データ登録・更新SQL生成処理
        /// </summary>
        /// <param name="shiharaiNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createShiharaiRegistSql(ref string shiharaiNo, DateTime registerDate)
        {
            string sql = string.Empty;

            DateTime shiharaiHizuke = commonLogic.convertDateTime(txtPaymentDateYears.Text, txtPaymentDateMonth.Text, txtPaymentDateDays.Text);
            string shiresakiCode = Convert.ToString(txtPurchaseCode.Text);
            string shiresakiName = Convert.ToString(txtPurchaseName.Text);
            string zipCode = Convert.ToString(txtZipCode.Text);
            string addres1 = Convert.ToString(txtAddress1.Text);
            string addres2 = Convert.ToString(txtAddress2.Text);
            string genkin = Convert.ToString(txtCash.Text);
            string tegata = Convert.ToString(txtBills.Text);
            string hurikomi = Convert.ToString(txtTransfer.Text);
            string sousai = Convert.ToString(txtOffset.Text);
            string goukei = Convert.ToString(txtTotal.Text);

            if (rdoNew.Checked)
            {
                // 支払No採番
                shiharaiNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getShiharaiNo() + 1).ToString(), txtPaymentNo.MaxLength);

                // 支払データの登録SQL生成
                sql += "INSERT INTO shiharai ";
                sql += "( ";
                sql += "  shiharaiNo ";
                sql += ", shiharaiHizuke ";
                sql += ", shiresakiCode ";
                sql += ", shiresakiName ";
                sql += ", zipCode ";
                sql += ", addres1 ";
                sql += ", addres2 ";
                sql += ", genkin ";
                sql += ", tegata ";
                sql += ", hurikomi ";
                sql += ", sousai ";
                sql += ", goukei ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + shiharaiNo + "' ";
                sql += "," + "'" + shiharaiHizuke + "' ";
                sql += "," + "'" + shiresakiCode + "' ";
                sql += "," + "'" + shiresakiName + "' ";
                sql += "," + "'" + zipCode + "' ";
                sql += "," + "'" + addres1 + "' ";
                sql += "," + "'" + addres2 + "' ";
                sql += "," + (string.IsNullOrEmpty(genkin) ? "null" : Convert.ToDecimal(genkin).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(tegata) ? "null" : Convert.ToDecimal(tegata).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(hurikomi) ? "null" : Convert.ToDecimal(hurikomi).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(sousai) ? "null" : Convert.ToDecimal(sousai).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(goukei) ? "null" : Convert.ToDecimal(goukei).ToString()) + " ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 支払ヘッダの更新SQL生成
                sql = "UPDATE shiharai SET ";
                sql += "  shiharaiNo = '" + shiharaiNo + "' ";
                sql += ", shiharaiHizuke = '" + shiharaiHizuke + "' ";
                sql += ", shiresakiCode = '" + shiresakiCode + "' ";
                sql += ", shiresakiName = '" + shiresakiName + "' ";
                sql += ", zipCode = '" + zipCode + "' ";
                sql += ", addres1 = '" + addres1 + "' ";
                sql += ", addres2 = '" + addres2 + "' ";
                sql += ", genkin = " + (string.IsNullOrEmpty(genkin) ? "null" : Convert.ToDecimal(genkin).ToString()) + " ";
                sql += ", tegata = " + (string.IsNullOrEmpty(tegata) ? "null" : Convert.ToDecimal(tegata).ToString()) + " ";
                sql += ", hurikomi = " + (string.IsNullOrEmpty(hurikomi) ? "null" : Convert.ToDecimal(hurikomi).ToString()) + " ";
                sql += ", sousai = " + (string.IsNullOrEmpty(sousai) ? "null" : Convert.ToDecimal(sousai).ToString()) + " ";
                sql += ", goukei = " + (string.IsNullOrEmpty(goukei) ? "null" : Convert.ToDecimal(goukei).ToString()) + " ";
                sql += ", kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '' ";
                sql += "WHERE shiharaiNo = '" + shiharaiNo + "' ";
            }
            else
            {
                // 支払ヘッダの論理削除SQL生成
                sql = "UPDATE shiharai SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE shiharaiNo = '" + shiharaiNo + "' ";
            }

            return sql;
        }
        #endregion

        #region 管理マスタ更新SQL生成処理
        /// <summary>
        /// 管理マスタ更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createKanriMasterRegistSql(string mitumoriNo, DateTime registerDate)
        {
            string sql = string.Empty;

            sql = "UPDATE kanri_master SET ";
            sql += "  koumoku1 = '" + mitumoriNo + "' ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += "WHERE kanriCode = '" + Consts.KanriCodes.ShiharaiNo+ "' ";

            return sql;
        }
        #endregion

        #endregion
    }
}
