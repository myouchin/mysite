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
    public partial class frmShireM : ChildBaseForm
    {
        #region 変数宣言

        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private DBMeisyoMaster meisyoMaster;
        private CommonLogic commonLogic;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        DBCommon masterDataSelectDb;
        private bool flgBtnSearchSelect = false;
        private DBShiresakiMaster shiresakiMaster;
        sfrmShiiresakiSearch fShiiresaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmShireM()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            meisyoMaster = new DBMeisyoMaster();
            commonLogic = new CommonLogic();
            masterDataSelectDb = new DBCommon();
            shiresakiMaster = new DBShiresakiMaster();
            fShiiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
        }
        #endregion

        #region 画面起動時のイベント
        /// <summary>
        /// 画面起動時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShireM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtVendorCode;

            // 締日コンボボックス設定
            setClosingDateCmb();
            // 回収サイトコンボボックス設定
            setPaymentSiteCmb();
            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 入力情報設定
            setInputInfo();
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
                if (rdoReference.Checked)
                {
                    fShiiresaki.FlgDispDeletedData = true;
                }
                fShiiresaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
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
            // 新規作成の場合
            if (rdoNew.Checked)
            {
                // 仕入先コードの存在チェック
                if (checkExistsShiresakiInfo(txtVendorCode.Text))
                {
                    errorOK(Messages.M0050);
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
                string sqlShiresakiMasterCommand = createRegistSql(registerDate);

                // 仕入先マスタの更新
                masterDataSelectDb.executeDBUpdate(sqlShiresakiMasterCommand);

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
                    errorOK(string.Format(Messages.M0011, "仕入先マスタ", processName));
                }
                else
                {
                    string message1 = "仕入先コード:" + txtVendorCode.Text;
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
                txtVendorName.Text = string.Empty;
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
            // 仕入先コードを編集中の場合
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

            // 得意先ｺｰﾄﾞの場合
            if (c.Name.Equals(txtVendorCode.Name))
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

        #region 締日コンボボックスの設定処理
        /// <summary>
        /// 締日コンボボックスの設定処理
        /// </summary>
        private void setClosingDateCmb()
        {
            // 締日取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE006);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbClosingDay, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 回収サイトコンボボックスの設定処理
        /// <summary>
        /// 回収サイトコンボボックスの設定処理
        /// </summary>
        private void setPaymentSiteCmb()
        {
            // 回収サイト取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE013);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPaymentSite, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtVendorCode.MaxLength = 3;        // 仕入先コード
            txtVendorName.MaxLength = 20;       // 仕入先名
            txtVendorKanaName.MaxLength = 30;   // 仕入先カナ名
            txtZipCode.MaxLength = 8;           // 郵便番号
            txtAddress1.MaxLength = 25;         // 住所１
            txtAddress2.MaxLength = 25;         // 住所２
            txtTel.MaxLength = 13;              // 電話番号
            txtFax.MaxLength = 13;              // FAX
            txtLastUpdateYear.MaxLength = 4;    // 最終更新日(年)
            txtLastUpdateMonth.MaxLength = 2;   // 最終更新日(月)
            txtLastUpdateDay.MaxLength = 2;     // 最終更新日(日)

            // 入力制御イベント設定
            txtVendorCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 得意先コード   :数字のみ入力可
            txtVendorKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);    // 得意先カナ名   :全角カナのみ入力可
            txtLastUpdateYear.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 最終更新日(年) :数字のみ入力可
            txtLastUpdateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 最終更新日(月) :数字のみ入力可
            txtLastUpdateDay.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 最終更新日(日) :数字のみ入力可
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
            List<DBFileLayout.ShiresakiMasterFile> shiresakiInfo = shiresakiMaster.getShiresakiInfo(shiresakiCode, true);
            if (shiresakiInfo == null || shiresakiInfo.Count == 0)
            {
                if (!rdoNew.Checked)
                {
                    errorOK(string.Format(Messages.M0003, "仕入先ｺｰﾄﾞ"));
                    txtVendorCode.Focus();
                }
                return;
            }
            else if (!rdoReference.Checked && Consts.KanriCodeTypes.TYPE9.Equals(shiresakiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "仕入先";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtVendorCode.Focus();
                return;
            }

            if (flgUnconditional || txtVendorCode.BeforeValue != shiresakiCode)
            {
                txtVendorCode.Text = shiresakiInfo[0].ShiresakiCode;
                txtVendorName.Text = shiresakiInfo[0].ShiresakiName;
                txtVendorKanaName.Text = shiresakiInfo[0].ShiresakiKanaName;
                txtZipCode.Text = shiresakiInfo[0].ZipCode;
                txtAddress1.Text = shiresakiInfo[0].Address1;
                txtAddress2.Text = shiresakiInfo[0].Address2;
                txtTel.Text = shiresakiInfo[0].Renrakusaki1;
                txtFax.Text = shiresakiInfo[0].Renrakusaki2;
                cmbClosingDay.SelectedValue = shiresakiInfo[0].Shimebi;
                cmbPaymentSite.SelectedValue = shiresakiInfo[0].ShiharaiSaito;
                if (shiresakiInfo[0].KousinNichizi != null)
                {
                    DateTime lastDate = Convert.ToDateTime(shiresakiInfo[0].KousinNichizi);
                    txtLastUpdateYear.Text = Convert.ToString(lastDate.Year);
                    txtLastUpdateMonth.Text = Convert.ToString(lastDate.Month);
                    txtLastUpdateDay.Text = Convert.ToString(lastDate.Day);
                }
                if (Consts.KanriCodeTypes.TYPE9.Equals(shiresakiInfo[0].KanriKubun))
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
                txtVendorCode.Text = shiresakiCode;
            }

            txtVendorCode.BeforeValue = txtVendorCode.Text;

            flgSearch = true;
            if (!rdoNew.Checked)
            {
                setEnabled();
            }
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
                txtVendorCode.Enabled = true;
                txtVendorName.Enabled = true;
                txtVendorKanaName.Enabled = true;
                txtZipCode.Enabled = true;
                txtAddress1.Enabled = true;
                txtAddress2.Enabled = true;
                txtTel.Enabled = true;
                txtFax.Enabled = true;
                cmbClosingDay.Enabled = true;
                cmbPaymentSite.Enabled = true;
                txtLastUpdateYear.ReadOnly = true;
                txtLastUpdateMonth.ReadOnly = true;
                txtLastUpdateDay.ReadOnly = true;
                btnSearch.Enabled = true;
                btnPrint.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtVendorCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtVendorCode.Enabled = !flgSearch;
                txtVendorName.Enabled = flgSearch;
                txtVendorKanaName.Enabled = flgSearch;
                txtZipCode.Enabled = flgSearch;
                txtAddress1.Enabled = flgSearch;
                txtAddress2.Enabled = flgSearch;
                txtTel.Enabled = flgSearch;
                txtFax.Enabled = flgSearch;
                cmbClosingDay.Enabled = flgSearch;
                cmbPaymentSite.Enabled = flgSearch;
                txtLastUpdateYear.ReadOnly = true;
                txtLastUpdateMonth.ReadOnly = true;
                txtLastUpdateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = flgSearch;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtVendorCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtVendorCode.Enabled = !flgSearch;
                txtVendorName.Enabled = false;
                txtVendorKanaName.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtTel.Enabled = false;
                txtFax.Enabled = false;
                cmbClosingDay.Enabled = false;
                cmbPaymentSite.Enabled = false;
                txtLastUpdateYear.ReadOnly = true;
                txtLastUpdateMonth.ReadOnly = true;
                txtLastUpdateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = flgSearch;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtVendorCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtVendorCode.Enabled = !flgSearch;
                txtVendorName.Enabled = false;
                txtVendorKanaName.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtTel.Enabled = false;
                txtFax.Enabled = false;
                cmbClosingDay.Enabled = false;
                cmbPaymentSite.Enabled = false;
                txtLastUpdateYear.ReadOnly = true;
                txtLastUpdateMonth.ReadOnly = true;
                txtLastUpdateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Enabled = false;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = flgSearch;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtVendorCode.Focus();

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
                if (!string.IsNullOrEmpty(txtVendorCode.Text) ||
                    !string.IsNullOrEmpty(txtVendorName.Text) ||
                    !string.IsNullOrEmpty(txtVendorKanaName.Text) ||
                    !string.IsNullOrEmpty(txtZipCode.Text) ||
                    !string.IsNullOrEmpty(txtAddress1.Text) ||
                    !string.IsNullOrEmpty(txtAddress2.Text) ||
                    !string.IsNullOrEmpty(txtTel.Text) ||
                    !string.IsNullOrEmpty(txtFax.Text) ||
                    cmbClosingDay.SelectedIndex != 0 ||
                    cmbPaymentSite.SelectedIndex != 0)
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

            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtVendorKanaName.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtFax.Text = string.Empty;
            cmbClosingDay.SelectedIndex = 0;
            cmbPaymentSite.SelectedIndex = 0;
            lblDeletedMessage.Visible = false;

            #endregion

            flgSearch = false;
            // モード別編集可否設定
            setEnabled();
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

            if (string.IsNullOrEmpty(txtVendorCode.Text))
            {
                errorItem = lblVendorCode.Text;
            }
            else if (string.IsNullOrEmpty(txtVendorName.Text))
            {
                errorItem = lblVendorName.Text;
            }
            else if (string.IsNullOrEmpty(txtVendorKanaName.Text))
            {
                errorItem = "仕入先名（カナ）";
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

        #region 仕入先情報の存在チェック処理
        /// <summary>
        /// 仕入先情報の存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkExistsShiresakiInfo(string shiresakiCode)
        {
            bool ret = false;

            DBShiresakiMaster shiresakiMaster = new DBShiresakiMaster();
            List<DBFileLayout.ShiresakiMasterFile> shiresakiInfos = shiresakiMaster.getShiresakiInfo(shiresakiCode, true);

            if (shiresakiInfos.Count > 0)
            {
                ret = true;
            }

            return ret;
        }
        #endregion

        #region 仕入先マスタの更新SQL生成処理
        /// <summary>
        /// 仕入先マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createRegistSql(DateTime registerDate)
        {
            string command = string.Empty;

            string shiresakiCode = txtVendorCode.Text;
            string shiresakiName = txtVendorName.Text;
            string shiresakiKanaName = txtVendorKanaName.Text;
            string zipCode = txtZipCode.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string renrakusaki1 = txtTel.Text;
            string renrakusaki2 = txtFax.Text;
            string shimebi = Convert.ToString(cmbClosingDay.SelectedValue);
            string shiharaiSaito = Convert.ToString(cmbPaymentSite.SelectedValue);

            if (rdoNew.Checked)
            {
                // 仕入先マスタの登録SQL生成
                command += "INSERT INTO shiresaki_master ";
                command += "( ";
                command += "  shiresakiCode ";
                command += ", shiresakiName ";
                command += ", shiresakiKanaName ";
                command += ", zipCode ";
                command += ", address1 ";
                command += ", address2 ";
                command += ", renrakusaki1 ";
                command += ", renrakusaki2 ";
                command += ", shimebi ";
                command += ", shiharaiSaito ";
                command += ", kousinNichizi ";
                command += ", kanriKubun ";
                command += ") ";
                command += "VALUES ";
                command += "( ";
                command += "'" + shiresakiCode + "' ";
                command += "," + "'" + shiresakiName + "' ";
                command += "," + "'" + shiresakiKanaName + "' ";
                command += "," + "'" + zipCode + "' ";
                command += "," + "'" + address1 + "' ";
                command += "," + "'" + address2 + "' ";
                command += "," + "'" + renrakusaki1 + "' ";
                command += "," + "'" + renrakusaki2 + "' ";
                command += "," + "'" + shimebi + "' ";
                command += "," + "'" + shiharaiSaito + "' ";
                command += "," + "'" + registerDate + "' ";
                command += "," + "'' ";
                command += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 仕入先マスタの更新SQL生成
                command = "UPDATE shiresaki_master SET ";
                command += "  shiresakiCode = '" + shiresakiCode + "' ";
                command += ", shiresakiName = '" + shiresakiName + "' ";
                command += ", shiresakiKanaName = '" + shiresakiKanaName + "' ";
                command += ", zipCode = '" + zipCode + "' ";
                command += ", address1 = '" + address1 + "' ";
                command += ", address2 = '" + address2 + "' ";
                command += ", renrakusaki1 = '" + renrakusaki1 + "' ";
                command += ", renrakusaki2 = '" + renrakusaki2 + "' ";
                command += ", shimebi = '" + shimebi + "' ";
                command += ", shiharaiSaito = '" + shiharaiSaito + "' ";
                command += ", kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '' ";
                command += "WHERE shiresakiCode = '" + shiresakiCode + "' ";
            }
            else
            {
                // 仕入先マスタの論理削除SQL生成
                command = "UPDATE shiresaki_master SET ";
                command += "  kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                command += "WHERE shiresakiCode = '" + shiresakiCode + "' ";
            }

            return command;
        }
        #endregion

        #endregion
    }
}
