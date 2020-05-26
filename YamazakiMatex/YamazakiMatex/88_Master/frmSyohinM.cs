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
using Common;
using Resorce;
using SubForm;

namespace Master
{
    public partial class frmSyohinM : Common.ChildBaseForm
    {
        #region 変数宣言

        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private CommonLogic commonLogic;
        private bool flgBtnSearchSelect = false;
        private DBMeisyoMaster meisyoMaster;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private int bidIntegerLength = 8;
        private int bidDecimalLength = 0;
        private DBShiresakiMaster shiresakiMaster;
        private DBShouhinMaster shouhinMaster;
        private string bidFormat;
        DBCommon masterDataSelectDb;
        sfrmShouhinSearch fShouhin;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSyohinM()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            meisyoMaster = new DBMeisyoMaster();
            shiresakiMaster = new DBShiresakiMaster();
            shouhinMaster = new DBShouhinMaster();
            masterDataSelectDb = new DBCommon();
            fShouhin = new sfrmShouhinSearch(false);
        }
        #endregion

        #region 画面起動時のイベント
        /// <summary>
        /// 画面起動時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSyohinM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = cmbTopClassificationCode;

            // 分類コードコンボボックス設定
            setClassificationCodeCmb();
            // 単位コンボボックス設定
            setUnitCmb();
            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 入力情報設定
            setInputInfo();
            // 単価フォーマット文字列取得
            bidFormat = commonLogic.getNumberFormatString(bidIntegerLength, bidDecimalLength);
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

            if (c is CustomTextBox)
            {
                ((CustomTextBox)c).BeforeValue = ((CustomTextBox)c).Text;
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
        }
        #endregion

        #region コード項目のフォーカスアウトイベント
        /// <summary>
        /// コード項目のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
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

            // 商品ｺｰﾄﾞを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtItemCode.Name))
            {
                // 商品検索画面を起動
                if (rdoReference.Checked)
                {
                    fShouhin.FlgDispDeletedData = true;
                }
                fShouhin.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fShouhin.DialogResult == DialogResult.OK)
                {
                    setShouhinInfo(fShouhin.SelectedItemCodes[0].ShouhinNo, true);
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
        }
        #endregion

        #region 印刷ボタン押下イベント
        /// <summary>
        /// 印刷ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {

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
            // 必須チェック処理
            if (!checkRequired())
            {
                return;
            }
            // 商品コードが未入力の場合
            if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                if (queryYesNo(Messages.M0047) == DialogResult.No)
                {
                    return;
                }
                //txtItemCode.Text = DefaultOfficeCode;
            }
            // 新規作成の場合
            if (rdoNew.Checked && !string.IsNullOrEmpty(txtItemCode.Text))
            {
                // 商品コードの存在チェック
                if (checkExistsShouhinInfo(txtItemCode.Text))
                {
                    errorOK(Messages.M0048);
                    return;
                }
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
                masterDataSelectDb.startTransaction();
                DateTime registerDate = DateTime.Now;
                string shouhinCode = txtItemCode.Text;
                string sqlTokuisakiMasterCommand = createRegistSql(ref shouhinCode, registerDate);

                // 得意先マスタの更新
                masterDataSelectDb.executeDBUpdate(sqlTokuisakiMasterCommand);

                if (masterDataSelectDb.DBRef < 0)
                {
                    string processName = string.Empty;
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
                    errorOK(string.Format(Messages.M0011, "得意先マスタ", processName));
                }
                else
                {
                    string message1 = "商品コード:" + shouhinCode;
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
                    messageOK(string.Format(Messages.M0012, message1, message2));
                    btnCancel_Click(null, null);
                }
                masterDataSelectDb.endTransaction();
            }
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
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                string queryMeaasage = string.Empty;
                string str1 = "終了してよろしいですか？";
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
            closedForm();
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
            commonLogic.inputNumberOnly_KeyPress(e, (TextBox)sender, bidIntegerLength, bidDecimalLength);
        }
        #endregion

        #region 商品コードのフォーカスアウトイベント
        /// <summary>
        /// 商品コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 商品情報の設定
                setShouhinInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), false);
            }
            else
            {
                txtItemCode.Text = string.Empty;
                txtItemName.Text = string.Empty;
            }
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

            // 商品ｺｰﾄﾞの場合
            if (c.Name.Equals(txtItemCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtItemCode_Leave);
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
            // 得意先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtItemCode.Name))
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

        #region 単位コンボボックスの設定処理
        /// <summary>
        /// 単位コンボボックスの設定処理
        /// </summary>
        private void setUnitCmb()
        {
            // 単位取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE003);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbUnitType, meisyoDt, "kubun", "kubunName");
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

            activeRadioButton = radio;

            #region 共通初期値設定

            cmbTopClassificationCode.SelectedIndex = 0;
            //cmbBtmClassificationCode.SelectedIndex = 0;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            cmbUnitType.SelectedIndex = 0;
            txtBit.Text = string.Empty;
            txtLastUpDateYear.Text = string.Empty;
            txtLastUpDateMonth.Text = string.Empty;
            txtLastUpDateDay.Text = string.Empty;
            lblDeletedMessage.Visible = false;

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
                cmbTopClassificationCode.Enabled = true;
                cmbBtmClassificationCode.Enabled = false;
                txtItemCode.Enabled = true;
                txtItemName.Enabled = true;
                cmbUnitType.Enabled = true;
                txtBit.Enabled = true;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = true;
                btnPrint.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                cmbTopClassificationCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                cmbTopClassificationCode.Enabled = flgSearch;
                cmbBtmClassificationCode.Enabled = false;
                txtItemCode.Enabled = !flgSearch;
                txtItemName.Enabled = flgSearch;
                cmbUnitType.Enabled = flgSearch;
                txtBit.Enabled = flgSearch;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = true;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                if (!flgSearch)
                {
                    txtItemCode.Focus();
                }
                else
                {
                    cmbTopClassificationCode.Focus();
                }

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                cmbTopClassificationCode.Enabled = false;
                cmbBtmClassificationCode.Enabled = false;
                txtItemCode.Enabled = !flgSearch;
                txtItemName.Enabled = false;
                cmbUnitType.Enabled = false;
                txtBit.Enabled = false;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtItemCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                cmbTopClassificationCode.Enabled = false;
                cmbBtmClassificationCode.Enabled = false;
                txtItemCode.Enabled = !flgSearch;
                txtItemName.Enabled = false;
                cmbUnitType.Enabled = false;
                txtBit.Enabled = false;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = (flgSearch && !lblDeletedMessage.Visible);
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtItemCode.Focus();

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
                if (cmbTopClassificationCode.SelectedIndex != 0 ||
                    !string.IsNullOrEmpty(txtItemCode.Text) ||
                    !string.IsNullOrEmpty(txtItemName.Text) ||
                    cmbUnitType.SelectedIndex != 0 ||
                    !string.IsNullOrEmpty(txtBit.Text))
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtItemCode.MaxLength = 5;              // 商品コード
            txtItemName.MaxLength = 30;             // 商品名１
            cmbUnitType.MaxLength = 5;              // 単位
            txtBit.MaxLength = 13;                  // 単価
            txtLastUpDateYear.MaxLength = 4;        // 最終更新日(年)
            txtLastUpDateMonth.MaxLength = 2;       // 最終更新日(月)
            txtLastUpDateDay.MaxLength = 2;         // 最終更新日(日)

            // 入力制御イベント設定
            txtItemCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 商品コード     :数字のみ入力可
            txtBit.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);                   // 単価           :数値のみ入力可
            txtLastUpDateYear.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 最終更新日(年) :数字のみ入力可
            txtLastUpDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 最終更新日(月) :数字のみ入力可
            txtLastUpDateDay.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 最終更新日(日) :数字のみ入力可
        }
        #endregion

        #region 商品情報設定処理
        /// <summary>
        /// 商品情報設定処理
        /// </summary>
        /// <param name="shouhinCode"></param>
        private void setShouhinInfo(string shouhinCode, bool flgUnconditional)
        {
            // 商品情報の取得
            List<DBFileLayout.ShouhinMasterFile> shouhinInfo = shouhinMaster.getShouhinInfo(string.Empty, string.Empty, string.Empty, shouhinCode, true);
            if (shouhinInfo == null || shouhinInfo.Count == 0)
            {
                if (!rdoNew.Checked)
                {
                    errorOK(string.Format(Messages.M0003, lblItemCode.Text));
                    txtItemCode.Focus();
                }
                else
                {
                    txtItemCode.Text = shouhinCode;
                }
                return;
            }
            else if (!rdoReference.Checked && Consts.KanriCodeTypes.TYPE9.Equals(shouhinInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "品名";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtItemCode.Focus();
                return;
            }

            if (flgUnconditional || txtItemCode.BeforeValue != shouhinCode)
            {
                cmbTopClassificationCode.SelectedValue = shouhinInfo[0].TopClassification;
                //cmbBtmClassificationCode.SelectedValue = shouhinInfo[0].BtmClassification;
                txtItemCode.Text = shouhinInfo[0].ShouhinCode;
                txtItemName.Text = shouhinInfo[0].ShouhinName;
                cmbUnitType.SelectedValue = shouhinInfo[0].TaniKubun;
                if (shouhinInfo[0].Tanka != null)
                {
                    txtBit.Text = Convert.ToDecimal(shouhinInfo[0].Tanka).ToString(bidFormat);
                }
                else
                {
                    txtBit.Text = string.Empty;
                }
                if (shouhinInfo[0].KousinNichizi != null)
                {
                    DateTime lastDate = Convert.ToDateTime(shouhinInfo[0].KousinNichizi);
                    txtLastUpDateYear.Text = Convert.ToString(lastDate.Year);
                    txtLastUpDateMonth.Text = Convert.ToString(lastDate.Month);
                    txtLastUpDateDay.Text = Convert.ToString(lastDate.Day);
                }
                else
                {
                    txtLastUpDateYear.Text = string.Empty;
                    txtLastUpDateMonth.Text = string.Empty;
                    txtLastUpDateDay.Text = string.Empty;
                }
                if (Consts.KanriCodeTypes.TYPE9.Equals(shouhinInfo[0].KanriKubun))
                {
                    lblDeletedMessage.Visible = true;
                }
                else
                {
                    lblDeletedMessage.Visible = false;
                }
            }
            else
            {
                txtItemCode.Text = shouhinCode;
            }

            txtItemCode.BeforeValue = txtItemCode.Text;

            flgSearch = true;
            if (!rdoNew.Checked)
            {
                setEnabled();
            }
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
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbTopClassificationCode, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 必須入力チェック処理
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;
            string errorItem = string.Empty;

            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                errorItem = lblItemName.Text;
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

        #region 商品情報の存在チェック処理
        /// <summary>
        /// 商品情報の存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkExistsShouhinInfo(string shouhinCode)
        {
            bool ret = false;

            DBShouhinMaster shouhinMaster = new DBShouhinMaster();
            List<DBFileLayout.ShouhinMasterFile> shouhinInfos = shouhinMaster.getShouhinInfo(string.Empty, string.Empty, string.Empty, shouhinCode, false);

            if (shouhinInfos.Count > 0)
            {
                ret = true;
            }

            return ret;
        }
        #endregion

        #region 商品マスタの更新SQL生成処理
        /// <summary>
        /// 商品マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createRegistSql(ref string shouhinCode, DateTime registerDate)
        {
            string command = string.Empty;

            string shireCode = string.Empty;
            string topClassification = Convert.ToString(cmbTopClassificationCode.SelectedValue);
            string btmClassification = string.Empty;
            //string shouhinCode = txtItemCode.Text;
            string shouhinName = txtItemName.Text;
            string taniKubun = Convert.ToString(cmbUnitType.SelectedValue);
            string tanka = txtBit.Text;

            if (rdoNew.Checked)
            {
                if (string.IsNullOrEmpty(shouhinCode))
                {
                    // 商品コード取得
                    string selectCommand = "SELECT LPAD(IFNULL(MAX(CAST(shouhinCode AS SIGNED)), 0) + 1, 5, '0') AS newShouhinCode FROM shouhin_master WHERE shouhinCode <> '99999'";
                    DataTable dt = masterDataSelectDb.executeNoneLockSelect(selectCommand);
                    shouhinCode = Convert.ToString(dt.Rows[0]["newShouhinCode"]);
                }
                // 商品マスタの登録SQL生成
                command += "INSERT INTO shouhin_master ";
                command += "( ";
                command += "  shireCode ";
                command += ", topClassification ";
                command += ", btmClassification ";
                command += ", shouhinCode ";
                command += ", shouhinName ";
                command += ", taniKubun ";
                command += ", tanka ";
                command += ", kousinNichizi ";
                command += ", kanriKubun ";
                command += ") ";
                command += "VALUES ";
                command += "( ";
                command += "'" + shireCode + "' ";
                command += "," + "'" + topClassification + "' ";
                command += "," + "'" + btmClassification + "' ";
                command += "," + "'" + shouhinCode + "' ";
                command += "," + "'" + shouhinName + "' ";
                command += "," + "'" + taniKubun + "' ";
                command += "," + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                command += "," + "'" + registerDate + "' ";
                command += "," + "'' ";
                command += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 商品マスタの更新SQL生成
                command = "UPDATE shouhin_master SET ";
                command += "  shireCode = '" + shireCode + "' ";
                command += ", topClassification = '" + topClassification + "' ";
                command += ", btmClassification = '" + btmClassification + "' ";
                command += ", shouhinCode = '" + shouhinCode + "' ";
                command += ", shouhinName = '" + shouhinName + "' ";
                command += ", taniKubun = '" + taniKubun + "' ";
                command += ", tanka = " + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                command += ", kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '' ";
                command += "WHERE shouhinCode = '" + shouhinCode + "' ";
            }
            else
            {
                // 商品マスタの論理削除SQL生成
                command = "UPDATE shouhin_master SET ";
                command += "  kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                command += "WHERE shouhinCode = '" + shouhinCode + "' ";
            }

            return command;
        }
        #endregion

        #endregion
    }
}
