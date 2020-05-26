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
    public partial class frmKenmeiM : Common.ChildBaseForm
    {
        #region 変数宣言

        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private DBKenmeiMaster kenmeiMaster;
        private CommonLogic commonLogic;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        DBCommon masterDataSelectDb;
        private bool flgBtnSearchSelect = false;
        sfrmKenmeiSearch fKenmei;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmKenmeiM()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            kenmeiMaster = new DBKenmeiMaster();
            commonLogic = new CommonLogic();
            masterDataSelectDb = new DBCommon();
            fKenmei = new sfrmKenmeiSearch(false, CheckMessageType.None);
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmKenmeiM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtSubjectNo;

            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
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
            //setSearchButtonEnabled();
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

            // 件名Noを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtSubjectNo.Name))
            {
                // 件名検索画面を起動
                if (rdoReference.Checked)
                {
                    fKenmei.FlgDispDeletedData = true;
                }
                fKenmei.ShowDialog();

                // 件名検索画面で確認ボタンが押下された場合
                if (fKenmei.DialogResult == DialogResult.OK)
                {
                    string kenmeiNo = fKenmei.SelectedKenmeiNos[0];
                    // 件名情報設定処理
                    setKenmeiInfo(kenmeiNo);
                    // 画面項目制御処理を実行
                    setEnabled();
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
                string kenmeiNo = string.Empty;
                string sqlkenmeiMasterCommand = createRegistSql(registerDate, ref kenmeiNo);

                // 得意先マスタの更新
                masterDataSelectDb.executeDBUpdate(sqlkenmeiMasterCommand);

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
                    string message1 = "件名No:" + kenmeiNo;
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

        #region 件名Noフォーカスアウトイベント
        /// <summary>
        /// 件名Noフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubjectNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                if (setKenmeiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength)))
                {
                    // 画面項目制御処理を実行
                    setEnabled();
                }
            }
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

            // 件名Noの場合
            if (c.Name.Equals(txtSubjectNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtSubjectNo_Leave);
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
            // 件名Noまたは納入先名称を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtSubjectNo.Name) ||
                     activeControlInfo.Control.Name.Equals(txtDeliveryDestinationName.Name))
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
            txtSubjectNo.MaxLength = 5;                 // 件名No
            txtSubject1.MaxLength = 20;                 // 件名１
            txtSubject2.MaxLength = 20;                 // 件名２
            txtDeliveryDestinationName.MaxLength = 15;  // 納入先名
            txtDeliveryDeploymentName.MaxLength = 10;   // 納入先部署名
            txtContact1.MaxLength = 13;                 // 連絡先１
            txtContact2.MaxLength = 13;                 // 連絡先２
            txtZipCode1.MaxLength = 3;                  // 郵便番号１
            txtZipCode2.MaxLength = 4;                  // 郵便番号２
            txtAddress1.MaxLength = 20;                 // 住所１
            txtAddress2.MaxLength = 20;                 // 住所２
            txtLastUpDateYear.MaxLength = 4;            // 最終更新日(年)
            txtLastUpDateMonth.MaxLength = 2;           // 最終更新日(月)
            txtLastUpDateDay.MaxLength = 2;             // 最終更新日(日)

            // 入力制御イベント設定
            txtSubjectNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 件名No     :数字のみ入力可
            txtContact1.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 連絡先１   :数字のみ入力可
            txtContact2.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 連絡先２   :数字のみ入力可
            txtZipCode1.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 郵便番号１ :数字のみ入力可
            txtZipCode2.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 郵便番号２ :数字のみ入力可
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

            txtSubjectNo.Text = string.Empty;
            txtSubject1.Text = string.Empty;
            txtSubject2.Text = string.Empty;
            txtDeliveryDestinationName.Text = string.Empty;
            txtDeliveryDeploymentName.Text = string.Empty;
            txtContact1.Text = string.Empty;
            txtContact2.Text = string.Empty;
            txtZipCode1.Text = string.Empty;
            txtZipCode2.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
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
                txtSubjectNo.ReadOnly = true;
                txtSubjectNo.Enabled = true;
                txtSubject1.Enabled = true;
                txtSubject2.Enabled = true;
                txtDeliveryDestinationName.Enabled = true;
                txtDeliveryDeploymentName.Enabled = true;
                txtContact1.Enabled = true;
                txtContact2.Enabled = true;
                txtZipCode1.Enabled = true;
                txtZipCode2.Enabled = true;
                txtAddress1.Enabled = true;
                txtAddress2.Enabled = true;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = true;
                btnPrint.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtSubjectNo.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtSubjectNo.Enabled = !flgSearch;
                txtSubject1.Enabled = flgSearch;
                txtSubject2.Enabled = flgSearch;
                txtDeliveryDestinationName.Enabled = flgSearch;
                txtDeliveryDeploymentName.Enabled = flgSearch;
                txtContact1.Enabled = flgSearch;
                txtContact2.Enabled = flgSearch;
                txtZipCode1.Enabled = flgSearch;
                txtZipCode2.Enabled = flgSearch;
                txtAddress1.Enabled = flgSearch;
                txtAddress2.Enabled = flgSearch;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                if (!flgSearch)
                {
                    txtSubjectNo.Focus();
                }
                else
                {
                    txtSubject1.Focus();
                }

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtSubjectNo.Enabled = !flgSearch;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtDeliveryDestinationName.Enabled = false;
                txtDeliveryDeploymentName.Enabled = false;
                txtContact1.Enabled = false;
                txtContact2.Enabled = false;
                txtZipCode1.Enabled = false;
                txtZipCode2.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtSubjectNo.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtSubjectNo.Enabled = !flgSearch;
                txtSubject1.Enabled = flgSearch;
                txtSubject2.Enabled = flgSearch;
                txtDeliveryDestinationName.Enabled = flgSearch;
                txtDeliveryDeploymentName.Enabled = flgSearch;
                txtContact1.Enabled = flgSearch;
                txtContact2.Enabled = flgSearch;
                txtZipCode1.Enabled = flgSearch;
                txtZipCode2.Enabled = flgSearch;
                txtAddress1.Enabled = flgSearch;
                txtAddress2.Enabled = flgSearch;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtSubjectNo.Focus();

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
                if (!string.IsNullOrEmpty(txtSubjectNo.Text) ||
                    !string.IsNullOrEmpty(txtSubject1.Text) ||
                    !string.IsNullOrEmpty(txtSubject2.Text) ||
                    !string.IsNullOrEmpty(txtDeliveryDestinationName.Text) ||
                    !string.IsNullOrEmpty(txtDeliveryDeploymentName.Text) ||
                    !string.IsNullOrEmpty(txtContact1.Text) ||
                    !string.IsNullOrEmpty(txtContact2.Text) ||
                    !string.IsNullOrEmpty(txtZipCode1.Text) ||
                    !string.IsNullOrEmpty(txtZipCode2.Text) ||
                    !string.IsNullOrEmpty(txtAddress1.Text) ||
                    !string.IsNullOrEmpty(txtAddress2.Text) ||
                    !string.IsNullOrEmpty(txtLastUpDateYear.Text) ||
                    !string.IsNullOrEmpty(txtLastUpDateMonth.Text) ||
                    !string.IsNullOrEmpty(txtLastUpDateDay.Text))
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

        #region 件名情報設定処理
        /// <summary>
        /// 件名情報設定処理
        /// </summary>
        /// <param name="kenmeiNo"></param>
        private bool setKenmeiInfo(string kenmeiNo)
        {
            if (!rdoNew.Checked && flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            DBKenmeiMaster kenmeiM = new DBKenmeiMaster();
            // 件名情報を取得
            List<DBFileLayout.KenmeiMasterFile> kenmeiInfo = kenmeiM.getKenmeiInfo(kenmeiNo, true);
            if (kenmeiInfo.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "件名No"));
                txtSubjectNo.Focus();
                return false;
            }
            else if (!rdoReference.Checked && Consts.KanriCodeTypes.TYPE9.Equals(kenmeiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "件名";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtSubjectNo.Focus();
                return false;
            }

            if (!rdoNew.Checked) txtSubjectNo.Text = kenmeiInfo[0].KenmeiNo;
            txtSubject1.Text = kenmeiInfo[0].Kenmei1;
            txtSubject2.Text = kenmeiInfo[0].Kenmei2;
            txtDeliveryDestinationName.Text = kenmeiInfo[0].NonyusakiName;
            txtDeliveryDeploymentName.Text = kenmeiInfo[0].BusyoName;
            txtContact1.Text = kenmeiInfo[0].Renrakusaki1;
            txtContact2.Text = kenmeiInfo[0].Renrakusaki2;
            string zipCode = kenmeiInfo[0].ZipCode.Replace("-", "");
            if (zipCode.Length > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    txtZipCode1.Text += zipCode[i];
                }
            }
            if (zipCode.Length > 4)
            {
                for (int i = 3; i < zipCode.Length; i++)
                {
                    txtZipCode2.Text += zipCode[i];
                }
            }
            txtAddress1.Text = kenmeiInfo[0].Address1;
            txtAddress2.Text = kenmeiInfo[0].Address2;
            if (kenmeiInfo[0].KousinNichizi != null)
            {
                DateTime lastDate = Convert.ToDateTime(kenmeiInfo[0].KousinNichizi);
                txtLastUpDateYear.Text = Convert.ToString(lastDate.Year);
                txtLastUpDateMonth.Text = Convert.ToString(lastDate.Month);
                txtLastUpDateDay.Text = Convert.ToString(lastDate.Day);
            }
            if (Consts.KanriCodeTypes.TYPE9.Equals(kenmeiInfo[0].KanriKubun))
            {
                lblDeletedMessage.Visible = true;
            }
            else
            {
                lblDeletedMessage.Visible = false;
            }

            // 検索実行済みフラグにtrueを設定
            flgSearch = true;

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 件名マスタの更新SQL生成処理
        /// <summary>
        /// 件名マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createRegistSql(DateTime registerDate, ref string kenmeiNo)
        {
            string command = string.Empty;

            kenmeiNo = txtSubjectNo.Text;
            if (string.IsNullOrEmpty(kenmeiNo))
            {
                int wkKwnmeiNo = 1;
                DataTable dt = masterDataSelectDb.executeLockSelect("SELECT MAX(CAST(kenmeiNo AS SIGNED)) AS kenmeiNo FROM kenmei_master");
                if (dt != null && dt.Rows.Count > 0)
                {
                    wkKwnmeiNo = Convert.ToInt16(dt.Rows[0]["kenmeiNo"]) + 1;
                }
                kenmeiNo = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkKwnmeiNo), txtSubjectNo.MaxLength);
            }
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;
            string nonyusakiName = txtDeliveryDestinationName.Text;
            string busyoName = txtDeliveryDeploymentName.Text;
            string renrakusaki1 = txtContact1.Text;
            string renrakusaki2 = txtContact2.Text;
            string zipCode = txtZipCode1.Text + "-" + txtZipCode2.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;

            if (rdoNew.Checked)
            {
                // 件名マスタの登録SQL生成
                command += "INSERT INTO kenmei_master ";
                command += "( ";
                command += "  kenmeiNo ";
                command += ", kenmei1 ";
                command += ", kenmei2 ";
                command += ", nonyusakiName ";
                command += ", busyoName ";
                command += ", renrakusaki1 ";
                command += ", renrakusaki2 ";
                command += ", zipCode ";
                command += ", address1 ";
                command += ", address2 ";
                command += ", kousinNichizi ";
                command += ", kanriKubun ";
                command += ") ";
                command += "VALUES ";
                command += "( ";
                command += "'" + kenmeiNo + "' ";
                command += "," + "'" + kenmei1 + "' ";
                command += "," + "'" + kenmei2 + "' ";
                command += "," + "'" + nonyusakiName + "' ";
                command += "," + "'" + busyoName + "' ";
                command += "," + "'" + renrakusaki1 + "' ";
                command += "," + "'" + renrakusaki2 + "' ";
                command += "," + "'" + zipCode + "' ";
                command += "," + "'" + address1 + "' ";
                command += "," + "'" + address2 + "' ";
                command += "," + "'" + registerDate + "' ";
                command += "," + "'' ";
                command += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 件名マスタの更新SQL生成
                command = "UPDATE kenmei_master SET ";
                command += "  kenmeiNo = '" + kenmeiNo + "' ";
                command += ", kenmei1 = '" + kenmei1 + "' ";
                command += ", kenmei2 = '" + kenmei2 + "' ";
                command += ", nonyusakiName = '" + nonyusakiName + "' ";
                command += ", busyoName = '" + busyoName + "' ";
                command += ", renrakusaki1 = '" + renrakusaki1 + "' ";
                command += ", renrakusaki2 = '" + renrakusaki2 + "' ";
                command += ", zipCode = '" + zipCode + "' ";
                command += ", address1 = '" + address1 + "' ";
                command += ", address2 = '" + address2 + "' ";
                command += ", renrakusaki1 = '" + renrakusaki1 + "' ";
                command += ", renrakusaki2 = '" + renrakusaki2 + "' ";
                command += ", kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '' ";
                command += "WHERE kenmeiNo = '" + kenmeiNo + "' ";
            }
            else
            {
                // 件名マスタの論理削除SQL生成
                command = "UPDATE kenmei_master SET ";
                command += "  kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                command += "WHERE kenmeiNo = '" + kenmeiNo + "' ";
            }

            return command;
        }
        #endregion

        #endregion
    }
}
