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
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;

namespace Master
{
    public partial class frmTokuiM : Common.ChildBaseForm
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
        private string ClaimTypeNoValue = "0";
        private string ClaimTypeYesValue = "1";
        private string DefaultOfficeCode = "000";
        private bool flgBtnSearchSelect = false;
        sfrmTokuisakiSearch fTokuisaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmTokuiM()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            meisyoMaster = new DBMeisyoMaster();
            commonLogic = new CommonLogic();
            masterDataSelectDb = new DBCommon();
            fTokuisaki = new sfrmTokuisakiSearch(false);
        }
        #endregion

        #region 画面起動時のイベント
        /// <summary>
        /// 画面起動時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTokuiM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = cmbRegion;

            // 地方コンボボックス設定
            setRegionCmb();
            // 都道府県コンボボックス設定
            setPrefecturesCmb();
            // 締日コンボボックス設定
            setClosingDateCmb();
            // 請求区分コンボボックス設定
            setClaimTypeCmb();
            // 回収サイトコンボボックス設定
            setRecoverySightCmb();
            // 請求出力区分コンボボックス設定
            setClaimDispTypeCmb();
            // 繰越額出力コンボボックス設定
            setCarryForwardAmountDisp();
            // (見積)消費税出力コンボボックス設定
            setEstimatesTaxDispCmb();
            // (納品書)消費税出力コンボボックス設定
            setDeliveryNoteTaxDispCmb();
            // 消費税端数区分コンボボックス設定
            setTaxFractionTypeCmb();
            // 金額端数区分コンボボックス設定
            setAmountFractionTypeCmb();
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
            setSearchButtonEnabled();
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
                if (rdoReference.Checked)
                {
                    fTokuisaki.FlgDispDeletedData = true;
                }
                fTokuisaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fTokuisaki.DialogResult == DialogResult.OK)
                {
                    string tokuisakiCode = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                    string jigyousyoCode = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                    // 得意先情報設定処理
                    setTokuisakiInfo(tokuisakiCode, jigyousyoCode);
                }
                flgSetFocus = true;
            }
            // 請求先ｺｰﾄﾞを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtBillingAddressCode.Name))
            {
                // 得意先検索画面を起動
                fTokuisaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fTokuisaki.DialogResult == DialogResult.OK)
                {
                    txtBillingAddressCode.Text = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                    txtBillingOfficeCode.Text = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
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
            // 事業所コードが未入力の場合
            if (string.IsNullOrEmpty(txtOfficeCode.Text))
            {
                if (queryYesNo(Messages.M0044) == DialogResult.No)
                {
                    flgSaving = false;
                    return;
                }
                txtOfficeCode.Text = DefaultOfficeCode;
            }
            // 必須チェック処理
            if (!checkRequired())
            {
                flgSaving = false;
                return;
            }
            // 新規作成の場合
            if (rdoNew.Checked)
            {
                // 得意先コードおよび事業所コードの存在チェック
                if (checkExistsTokuisakiInfo(txtCustomerCode.Text, txtOfficeCode.Text))
                {
                    errorOK(Messages.M0045);
                    flgSaving = false;
                    return;
                }
            }
            // 新規作成または訂正の場合
            if (rdoNew.Checked || rdoCorrection.Checked)
            {
                // 請求先コードおよび請求先事業所コードの存在チェック
                if (!checkExistsTokuisakiInfo(txtBillingAddressCode.Text, txtBillingOfficeCode.Text) &&
                    (!txtCustomerCode.Text.Equals(txtBillingAddressCode.Text) || !txtOfficeCode.Text.Equals(txtBillingOfficeCode.Text)))
                {
                    errorOK(Messages.M0046);
                    flgSaving = false;
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
                string sqlTokuisakiMasterCommand = createRegistSql(registerDate);

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
                    string message1 = "得意先コード:" + txtCustomerCode.Text + "、事業所コード:" + txtOfficeCode.Text;
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

        #region 数字＆ハイフンのみ入力可能項目の制御処理
        /// <summary>
        /// 数字＆ハイフンのみ入力可能項目の制御処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputDigitalAndHaihunOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字のみ入力可能項目の制御処理を実行
            commonLogic.inputDigitalAndHaihunOnly_KeyPress(e);
        }
        #endregion

        #region 得意先コードの入力値変更イベント
        /// <summary>
        /// 得意先コードの入力値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            //if (ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue)))
            //{
            //    txtBillingAddressCode.Text = txtCustomerCode.Text;
            //}
        }
        #endregion

        #region 事業所コードの入力値変更イベント
        /// <summary>
        /// 事業所コードの入力値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOfficeCode_TextChanged(object sender, EventArgs e)
        {
            //if (ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue)))
            //{
            //    txtBillingOfficeCode.Text = txtOfficeCode.Text;
            //}
        }
        #endregion

        #region 請求区分コンボボックス変更イベント
        /// <summary>
        /// 請求区分コンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClaimTypeNoValue.Equals(Convert.ToString(cmbClaimType.SelectedValue)))
            {
                txtBillingAddressCode.Enabled = false;
                txtBillingOfficeCode.Enabled = false;
                txtBillingAddressCode.Text = string.Empty;
                txtBillingOfficeCode.Text = string.Empty;
            }
            else
            {
                txtBillingAddressCode.Enabled = true;
                txtBillingOfficeCode.Enabled = true;
            }
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

        #endregion

        #region ビジネスロジック

        #region 地方コンボボックスの設定処理
        /// <summary>
        /// 地方コンボボックスの設定処理
        /// </summary>
        private void setRegionCmb()
        {
            // 地方取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE008);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbRegion, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 都道府県コンボボックスの設定処理
        /// <summary>
        /// 都道府県コンボボックスの設定処理
        /// </summary>
        private void setPrefecturesCmb()
        {
            // 都道府県取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE004);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPrefectures, meisyoDt, "kubun", "kubunName");
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
            commonLogic.setComboBoxDataSource(ref cmbClosingDate, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 請求区分コンボボックスの設定処理
        /// <summary>
        /// 請求区分コンボボックスの設定処理
        /// </summary>
        private void setClaimTypeCmb()
        {
            // 請求管理区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE012);
            foreach (DataRow row in meisyoDt.Rows)
            {
                row["kubun"] = Convert.ToInt16(row["kubun"]).ToString();
            }
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbClaimType, meisyoDt, "kubun", "kubunName");
            txtBillingAddressCode.Enabled = false;
            txtBillingOfficeCode.Enabled = false;
            txtBillingAddressCode.Text = string.Empty;
            txtBillingOfficeCode.Text = string.Empty;
        }
        #endregion

        #region 回収サイトコンボボックスの設定処理
        /// <summary>
        /// 回収サイトコンボボックスの設定処理
        /// </summary>
        private void setRecoverySightCmb()
        {
            // 回収サイト取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE010);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbRecoverySight, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 請求出力区分コンボボックスの設定処理
        /// <summary>
        /// 請求出力区分コンボボックスの設定処理
        /// </summary>
        private void setClaimDispTypeCmb()
        {
            // 請求出力区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE009);
            foreach (DataRow row in meisyoDt.Rows)
            {
                row["kubun"] = Convert.ToInt16(row["kubun"]).ToString();
            }
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbClaimDispType, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 繰越額出力コンボボックスの設定処理
        /// <summary>
        /// 繰越額出力コンボボックスの設定処理
        /// </summary>
        private void setCarryForwardAmountDisp()
        {
            // あり・なしコンボボックス設定共通処理
            commonLogic.setYesNoComboBoxDataSource(ref cmbCarryForwardAmountDisp);
        }
        #endregion

        #region (見積)消費税出力コンボボックスの設定処理
        /// <summary>
        /// (見積)消費税出力コンボボックスの設定処理
        /// </summary>
        private void setEstimatesTaxDispCmb()
        {
            // あり・なしコンボボックス設定共通処理
            commonLogic.setYesNoComboBoxDataSource(ref cmbEstimatesTaxDisp);
        }
        #endregion

        #region (納品書)消費税出力コンボボックスの設定処理
        /// <summary>
        /// (納品書)消費税出力コンボボックスの設定処理
        /// </summary>
        private void setDeliveryNoteTaxDispCmb()
        {
            // あり・なしコンボボックス設定共通処理
            commonLogic.setYesNoComboBoxDataSource(ref cmbDeliveryNoteTaxDisp);
        }
        #endregion

        #region 消費税端数区分コンボボックスの設定処理
        /// <summary>
        /// 消費税端数区分コンボボックスの設定処理
        /// </summary>
        private void setTaxFractionTypeCmb()
        {
            // 消費税区分コンボボックス設定共通処理
            commonLogic.setFractionTypeComboBoxDataSource(ref cmbTaxFractionType);
        }
        #endregion

        #region 金額端数区分コンボボックスの設定処理
        /// <summary>
        /// 金額端数区分コンボボックスの設定処理
        /// </summary>
        private void setAmountFractionTypeCmb()
        {
            // 消費税区分コンボボックス設定共通処理
            commonLogic.setFractionTypeComboBoxDataSource(ref cmbAmountFractionType);
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

            // 得意先ｺｰﾄﾞの場合
            if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCode_Leave);
            }
            // 事業所ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtOfficeCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCode_Leave);
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
            // 得意先コードまたは請求先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name) ||
                     activeControlInfo.Control.Name.Equals(txtBillingAddressCode.Name))
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

            activeRadioButton = radio;

            #region 共通初期値設定

            cmbRegion.SelectedIndex = 0;
            cmbPrefectures.SelectedIndex = 0;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            txtOfficeCode.Text = string.Empty;
            txtOfficeName.Text = string.Empty;
            txtZipCode1.Text = string.Empty;
            txtZipCode2.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtContact1.Text = string.Empty;
            txtContact2.Text = string.Empty;
            txtCustomerPersonName.Text = string.Empty;
            cmbClosingDate.SelectedIndex = 0;
            cmbClaimType.SelectedIndex = 0;
            cmbRecoverySight.SelectedIndex = 0;
            txtBillingAddressCode.Text = string.Empty;
            txtBillingOfficeCode.Text = string.Empty;
            cmbClaimDispType.SelectedIndex = 0;
            cmbCarryForwardAmountDisp.SelectedIndex = 0;
            cmbEstimatesTaxDisp.SelectedIndex = 0;
            cmbDeliveryNoteTaxDisp.SelectedIndex = 0;
            cmbTaxFractionType.SelectedIndex = 0;
            cmbAmountFractionType.SelectedIndex = 0;
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
                cmbRegion.Enabled = true;
                cmbPrefectures.Enabled = true;
                txtCustomerCode.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerKanaName.Enabled = true;
                txtOfficeCode.Enabled = true;
                txtOfficeName.Enabled = true;
                txtZipCode1.Enabled = true;
                txtZipCode2.Enabled = true;
                txtAddress1.Enabled = true;
                txtAddress2.Enabled = true;
                txtContact1.Enabled = true;
                txtContact2.Enabled = true;
                txtCustomerPersonName.Enabled = true;
                cmbClosingDate.Enabled = true;
                cmbClaimType.Enabled = true;
                cmbRecoverySight.Enabled = true;
                txtBillingAddressCode.Enabled = ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue));
                txtBillingOfficeCode.Enabled = ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue));
                cmbClaimDispType.Enabled = true;
                cmbCarryForwardAmountDisp.Enabled = true;
                cmbEstimatesTaxDisp.Enabled = true;
                cmbDeliveryNoteTaxDisp.Enabled = true;
                cmbTaxFractionType.Enabled = true;
                cmbAmountFractionType.Enabled = true;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = true;
                btnPreview.Visible = false;
                btnPrint.Visible = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                cmbRegion.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                cmbRegion.Enabled = flgSearch;
                cmbPrefectures.Enabled = flgSearch;
                txtCustomerCode.Enabled = !flgSearch;
                txtCustomerName.Enabled = flgSearch;
                txtCustomerKanaName.Enabled = flgSearch;
                txtOfficeCode.Enabled = false;
                txtOfficeName.Enabled = flgSearch;
                txtZipCode1.Enabled = flgSearch;
                txtZipCode2.Enabled = flgSearch;
                txtAddress1.Enabled = flgSearch;
                txtAddress2.Enabled = flgSearch;
                txtContact1.Enabled = flgSearch;
                txtContact2.Enabled = flgSearch;
                txtCustomerPersonName.Enabled = flgSearch;
                cmbClosingDate.Enabled = flgSearch;
                cmbClaimType.Enabled = flgSearch;
                cmbRecoverySight.Enabled = flgSearch;
                txtBillingAddressCode.Enabled = flgSearch && ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue));
                txtBillingOfficeCode.Enabled = flgSearch && ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue));
                cmbClaimDispType.Enabled = flgSearch;
                cmbCarryForwardAmountDisp.Enabled = flgSearch;
                cmbEstimatesTaxDisp.Enabled = flgSearch;
                cmbDeliveryNoteTaxDisp.Enabled = flgSearch;
                cmbTaxFractionType.Enabled = flgSearch;
                cmbAmountFractionType.Enabled = flgSearch;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = true;
                btnPreview.Visible = true;
                btnPrint.Visible = true;
                btnPreview.Enabled = flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtCustomerCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                cmbRegion.Enabled = false;
                cmbPrefectures.Enabled = false;
                txtCustomerCode.Enabled = !flgSearch;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                txtOfficeCode.Enabled = false;
                txtOfficeName.Enabled = false;
                txtZipCode1.Enabled = false;
                txtZipCode2.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtContact1.Enabled = false;
                txtContact2.Enabled = false;
                txtCustomerPersonName.Enabled = false;
                cmbClosingDate.Enabled = false;
                cmbClaimType.Enabled = false;
                cmbRecoverySight.Enabled = false;
                txtBillingAddressCode.Enabled = false;
                txtBillingOfficeCode.Enabled = false;
                cmbClaimDispType.Enabled = false;
                cmbCarryForwardAmountDisp.Enabled = false;
                cmbEstimatesTaxDisp.Enabled = false;
                cmbDeliveryNoteTaxDisp.Enabled = false;
                cmbTaxFractionType.Enabled = false;
                cmbAmountFractionType.Enabled = false;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPreview.Visible = true;
                btnPrint.Visible = true;
                btnPreview.Enabled = flgSearch;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtCustomerCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                cmbRegion.Enabled = false;
                cmbPrefectures.Enabled = false;
                txtCustomerCode.Enabled = !flgSearch;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                txtOfficeCode.Enabled = false;
                txtOfficeName.Enabled = false;
                txtZipCode1.Enabled = false;
                txtZipCode2.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtContact1.Enabled = false;
                txtContact2.Enabled = false;
                txtCustomerPersonName.Enabled = false;
                cmbClosingDate.Enabled = false;
                cmbClaimType.Enabled = false;
                cmbRecoverySight.Enabled = false;
                txtBillingAddressCode.Enabled = false;
                txtBillingOfficeCode.Enabled = false;
                cmbClaimDispType.Enabled = false;
                cmbCarryForwardAmountDisp.Enabled = false;
                cmbEstimatesTaxDisp.Enabled = false;
                cmbDeliveryNoteTaxDisp.Enabled = false;
                cmbTaxFractionType.Enabled = false;
                cmbAmountFractionType.Enabled = false;
                txtLastUpDateYear.ReadOnly = true;
                txtLastUpDateMonth.ReadOnly = true;
                txtLastUpDateDay.ReadOnly = true;
                btnSearch.Enabled = !flgSearch;
                btnPreview.Visible = false;
                btnPrint.Visible = false;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtCustomerCode.Focus();

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
                if (cmbRegion.SelectedIndex != 0 ||
                    cmbPrefectures.SelectedIndex != 0 ||
                    !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                    !string.IsNullOrEmpty(txtCustomerName.Text) ||
                    !string.IsNullOrEmpty(txtCustomerKanaName.Text) ||
                    !string.IsNullOrEmpty(txtOfficeCode.Text) ||
                    !string.IsNullOrEmpty(txtOfficeName.Text) ||
                    !string.IsNullOrEmpty(txtZipCode1.Text) ||
                    !string.IsNullOrEmpty(txtZipCode2.Text) ||
                    !string.IsNullOrEmpty(txtAddress1.Text) ||
                    !string.IsNullOrEmpty(txtAddress2.Text) ||
                    !string.IsNullOrEmpty(txtContact1.Text) ||
                    !string.IsNullOrEmpty(txtContact2.Text) ||
                    !string.IsNullOrEmpty(txtCustomerPersonName.Text) ||
                    cmbClosingDate.SelectedIndex != 0 ||
                    cmbClaimType.SelectedIndex != 0 ||
                    cmbRecoverySight.SelectedIndex != 0 ||
                    !string.IsNullOrEmpty(txtBillingAddressCode.Text) ||
                    !string.IsNullOrEmpty(txtBillingOfficeCode.Text) ||
                    cmbClaimDispType.SelectedIndex != 0 ||
                    cmbCarryForwardAmountDisp.SelectedIndex != 0 ||
                    cmbEstimatesTaxDisp.SelectedIndex != 0 ||
                    cmbDeliveryNoteTaxDisp.SelectedIndex != 0 ||
                    cmbTaxFractionType.SelectedIndex != 0 ||
                    cmbAmountFractionType.SelectedIndex != 0 ||
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtCustomerCode.MaxLength = 5;          // 得意先コード
            //txtCustomerName.MaxLength = 15;         // 得意先名
            //txtCustomerKanaName.MaxLength = 30;     // 得意先カナ名
            txtCustomerName.MaxLength = 40;       // 得意先名
            txtCustomerKanaName.MaxLength = 80;   // 得意先カナ名
            txtOfficeCode.MaxLength = 3;            // 事業所コード
            txtOfficeName.MaxLength = 30;           // 事業所名
            txtZipCode1.MaxLength = 3;              // 郵便番号(上3桁)
            txtZipCode2.MaxLength = 4;              // 郵便番号(下4桁)
            txtAddress1.MaxLength = 20;             // 住所１
            txtAddress2.MaxLength = 20;             // 住所２
            txtContact1.MaxLength = 15;             // 連絡先１
            txtContact2.MaxLength = 13;             // 連絡先２
            txtCustomerPersonName.MaxLength = 10;   // 得意先担当者名
            txtBillingAddressCode.MaxLength = 5;    // 請求先コード
            txtBillingOfficeCode.MaxLength = 3;     // 請求先事業所コード
            txtLastUpDateYear.MaxLength = 4;        // 最終更新日(年)
            txtLastUpDateMonth.MaxLength = 2;       // 最終更新日(月)
            txtLastUpDateDay.MaxLength = 2;         // 最終更新日(日)


            // 入力制御イベント設定
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 得意先コード       :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);      // 得意先カナ名       :全角カナのみ入力可
            txtOfficeCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 事業所コード       :数字のみ入力可
            txtZipCode1.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 郵便番号(上3桁)    :数字のみ入力可
            txtZipCode2.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 郵便番号(下4桁)    :数字のみ入力可
            txtContact1.KeyPress += new KeyPressEventHandler(inputDigitalAndHaihunOnly_KeyPress);       // 連絡先１           :数字のみ入力可
            txtContact2.KeyPress += new KeyPressEventHandler(inputDigitalAndHaihunOnly_KeyPress);       // 連絡先２           :数字のみ入力可
            txtBillingAddressCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 請求先コード       :数字のみ入力可
            txtBillingOfficeCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 請求先事業所コード :数字のみ入力可
            txtLastUpDateYear.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 最終更新日(年)     :数字のみ入力可
            txtLastUpDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 最終更新日(月)     :数字のみ入力可
            txtLastUpDateDay.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 最終更新日(日)     :数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);            // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfo = tokuisakiM.getTokuisakiInfo(tokuisakiCode, jigyousyoCode, true);
            if (tokuisakiInfo.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerCode.Focus();
                return;
            }
            else if (!rdoReference.Checked && Consts.KanriCodeTypes.TYPE9.Equals(tokuisakiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "得意先";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtCustomerCode.Focus();
                return;
            }

            cmbRegion.SelectedValue = tokuisakiInfo[0].ChihouCode;
            cmbPrefectures.SelectedValue = tokuisakiInfo[0].ChikuCode;
            txtCustomerCode.Text = tokuisakiInfo[0].TokuisakiCode;
            txtCustomerName.Text = tokuisakiInfo[0].TokuisakiName;
            txtCustomerKanaName.Text = tokuisakiInfo[0].TokuisakiKanaName;
            txtOfficeCode.Text = tokuisakiInfo[0].JigyousyoCode;
            txtOfficeName.Text = tokuisakiInfo[0].JigyousyoName;
            string zipCode = tokuisakiInfo[0].ZipCode.Replace("-", "");
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
            txtAddress1.Text = tokuisakiInfo[0].Address1;
            txtAddress2.Text = tokuisakiInfo[0].Address2;
            txtContact1.Text = tokuisakiInfo[0].Renrakusaki1;
            txtContact2.Text = tokuisakiInfo[0].Renrakusaki2;
            txtCustomerPersonName.Text = tokuisakiInfo[0].TokuisakiTantousyaName;
            cmbClosingDate.SelectedValue = tokuisakiInfo[0].Shimebi;
            cmbClaimType.SelectedValue = tokuisakiInfo[0].SeikyuKubun;
            cmbRecoverySight.SelectedValue = tokuisakiInfo[0].KaisyuSaito;
            txtBillingAddressCode.Text = tokuisakiInfo[0].SeikyusakiCode;
            txtBillingOfficeCode.Text = tokuisakiInfo[0].SeikyusakiJigyousyoCode;
            cmbClaimDispType.SelectedValue = tokuisakiInfo[0].SeikyuSyuturyokuKubun;
            cmbCarryForwardAmountDisp.SelectedValue = tokuisakiInfo[0].FlgKurikoshiSyuturyoku;
            cmbEstimatesTaxDisp.SelectedValue = tokuisakiInfo[0].SyohizeiKubun;
            cmbDeliveryNoteTaxDisp.SelectedValue = tokuisakiInfo[0].NouhinsyoSyohizeiKubun;
            cmbTaxFractionType.SelectedValue = tokuisakiInfo[0].SyohizeiHasuKubun;
            cmbAmountFractionType.SelectedValue = tokuisakiInfo[0].KingakuHasuKubun;
            if (tokuisakiInfo[0].KousinNichizi != null)
            {
                DateTime lastDate = Convert.ToDateTime(tokuisakiInfo[0].KousinNichizi);
                txtLastUpDateYear.Text = Convert.ToString(lastDate.Year);
                txtLastUpDateMonth.Text = Convert.ToString(lastDate.Month);
                txtLastUpDateDay.Text = Convert.ToString(lastDate.Day);
            }
            if (Consts.KanriCodeTypes.TYPE9.Equals(tokuisakiInfo[0].KanriKubun))
            {
                lblDeletedMessage.Visible = true;
            }
            else
            {
                lblDeletedMessage.Visible = false;
            }
            flgSearch = true;
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

            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                errorItem = lblCustomerCode.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                errorItem = lblCustomerName.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerKanaName.Text))
            {
                errorItem = lblCustomerKanaName.Text;
            }
            else if (ClaimTypeYesValue.Equals(Convert.ToString(cmbClaimType.SelectedValue)))
            {
                if (string.IsNullOrEmpty(txtBillingAddressCode.Text))
                {
                    errorItem = lblBillingAddressCode.Text;
                }
                else if (string.IsNullOrEmpty(txtBillingOfficeCode.Text))
                {
                    errorItem = lblBillingOfficeCode.Text;
                }
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

        #region 得意先マスタの更新SQL生成処理
        /// <summary>
        /// 得意先マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createRegistSql(DateTime registerDate)
        {
            string command = string.Empty;

            string chihouCode = Convert.ToString(cmbRegion.SelectedValue);
            string chikuCode = Convert.ToString(cmbPrefectures.SelectedValue);
            string tokuisakiCode = txtCustomerCode.Text;
            string jigyousyoCode = txtOfficeCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoName = txtOfficeName.Text;
            string zipCode = txtZipCode1.Text + "-" + txtZipCode2.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string renrakusaki1 = txtContact1.Text;
            string renrakusaki2 = txtContact2.Text;
            string tokuisakiTantousyaName = txtCustomerPersonName.Text;
            //string syukeiCode = string.Empty;
            string shimebi = Convert.ToString(cmbClosingDate.SelectedValue);
            string seikyusakiCode = txtBillingAddressCode.Text;
            string seikyusakiJigyousyoCode = txtBillingOfficeCode.Text;
            string seikyuKubun = Convert.ToString(cmbClaimType.SelectedValue);
            string kaisyuSaito = Convert.ToString(cmbRecoverySight.SelectedValue);
            string syohizeiKubun = Convert.ToString(cmbEstimatesTaxDisp.SelectedValue);
            string nouhinsyoSyohizeiKubun = Convert.ToString(cmbDeliveryNoteTaxDisp.SelectedValue);
            string syohizeiHasuKubun = Convert.ToString(cmbTaxFractionType.SelectedValue);
            string kingakuHasuKubun = Convert.ToString(cmbAmountFractionType.SelectedValue);
            string flgKurikoshiSyuturyoku = Convert.ToString(cmbCarryForwardAmountDisp.SelectedValue);
            string seikyuSyuturyokuKubun = Convert.ToString(cmbClaimDispType.SelectedValue);
            //string tantousyaCode = string.Empty;

            if (rdoNew.Checked)
            {
                // 得意先マスタの登録SQL生成
                command += "INSERT INTO tokuisaki_master ";
                command += "( ";
                command += "  chihouCode ";
                command += ", chikuCode ";
                command += ", tokuisakiCode ";
                command += ", jigyousyoCode ";
                command += ", tokuisakiName ";
                command += ", tokuisakiKanaName ";
                command += ", jigyousyoName ";
                command += ", zipCode ";
                command += ", address1 ";
                command += ", address2 ";
                command += ", renrakusaki1 ";
                command += ", renrakusaki2 ";
                command += ", tokuisakiTantousyaName ";
                command += ", shimebi ";
                command += ", seikyusakiCode ";
                command += ", seikyusakiJigyousyoCode ";
                command += ", seikyuKubun ";
                command += ", kaisyuSaito ";
                command += ", syohizeiKubun ";
                command += ", nouhinsyoSyohizeiKubun ";
                command += ", syohizeiHasuKubun ";
                command += ", kingakuHasuKubun ";
                command += ", flgKurikoshiSyuturyoku ";
                command += ", seikyuSyuturyokuKubun ";
                command += ", kousinNichizi ";
                command += ", kanriKubun ";
                command += ") ";
                command += "VALUES ";
                command += "( ";
                command += "'" + chihouCode + "' ";
                command += "," + "'" + chikuCode + "' ";
                command += "," + "'" + tokuisakiCode + "' ";
                command += "," + "'" + jigyousyoCode + "' ";
                command += "," + "'" + tokuisakiName + "' ";
                command += "," + "'" + tokuisakiKanaName + "' ";
                command += "," + "'" + jigyousyoName + "' ";
                command += "," + "'" + zipCode + "' ";
                command += "," + "'" + address1 + "' ";
                command += "," + "'" + address2 + "' ";
                command += "," + "'" + renrakusaki1 + "' ";
                command += "," + "'" + renrakusaki2 + "' ";
                command += "," + "'" + tokuisakiTantousyaName + "' ";
                command += "," + "'" + shimebi + "' ";
                command += "," + "'" + seikyusakiCode + "' ";
                command += "," + "'" + seikyusakiJigyousyoCode + "' ";
                command += "," + "'" + seikyuKubun + "' ";
                command += "," + "'" + kaisyuSaito + "' ";
                command += "," + "'" + syohizeiKubun + "' ";
                command += "," + "'" + nouhinsyoSyohizeiKubun + "' ";
                command += "," + "'" + syohizeiHasuKubun + "' ";
                command += "," + "'" + kingakuHasuKubun + "' ";
                command += "," + "'" + flgKurikoshiSyuturyoku + "' ";
                command += "," + "'" + seikyuSyuturyokuKubun + "' ";
                command += "," + "'" + registerDate + "' ";
                command += "," + "'' ";
                command += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 得意先マスタの更新SQL生成
                command = "UPDATE tokuisaki_master SET ";
                command += "  chihouCode = '" + chihouCode + "' ";
                command += ", chikuCode = '" + chikuCode + "' ";
                command += ", tokuisakiCode = '" + tokuisakiCode + "' ";
                command += ", jigyousyoCode = '" + jigyousyoCode + "' ";
                command += ", tokuisakiName = '" + tokuisakiName + "' ";
                command += ", tokuisakiKanaName = '" + tokuisakiKanaName + "' ";
                command += ", jigyousyoName = '" + jigyousyoName + "' ";
                command += ", zipCode = '" + zipCode + "' ";
                command += ", address1 = '" + address1 + "' ";
                command += ", address2 = '" + address2 + "' ";
                command += ", renrakusaki1 = '" + renrakusaki1 + "' ";
                command += ", renrakusaki2 = '" + renrakusaki2 + "' ";
                command += ", tokuisakiTantousyaName = '" + tokuisakiTantousyaName + "' ";
                //command += ", syukeiCode = '" + syukeiCode + "' ";
                command += ", shimebi = '" + shimebi + "' ";
                command += ", seikyusakiCode = '" + seikyusakiCode + "' ";
                command += ", seikyusakiJigyousyoCode = '" + seikyusakiJigyousyoCode + "' ";
                command += ", seikyuKubun = '" + seikyuKubun + "' ";
                command += ", kaisyuSaito = '" + kaisyuSaito + "' ";
                command += ", syohizeiKubun = '" + syohizeiKubun + "' ";
                command += ", nouhinsyoSyohizeiKubun = '" + nouhinsyoSyohizeiKubun + "' ";
                command += ", syohizeiHasuKubun = '" + syohizeiHasuKubun + "' ";
                command += ", kingakuHasuKubun = '" + kingakuHasuKubun + "' ";
                command += ", flgKurikoshiSyuturyoku = '" + flgKurikoshiSyuturyoku + "' ";
                command += ", seikyuSyuturyokuKubun = '" + seikyuSyuturyokuKubun + "' ";
                //command += ", tantousyaCode = '" + tantousyaCode + "' ";
                command += ", kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '' ";
                command += "WHERE tokuisakiCode = '" + txtCustomerCode.Text + "' ";
                command += "AND jigyousyoCode = '" + txtOfficeCode.Text + "' ";
            }
            else
            {
                // 得意先マスタの論理削除SQL生成
                command = "UPDATE tokuisaki_master SET ";
                command += "  kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                command += "WHERE tokuisakiCode = '" + txtCustomerCode.Text + "' ";
                command += "AND jigyousyoCode = '" + txtOfficeCode.Text + "' ";
            }

            return command;
        }
        #endregion

        #region 得意先情報の存在チェック処理
        /// <summary>
        /// 得意先情報の存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkExistsTokuisakiInfo(string tokuisakiCode, string jigyousyoCode)
        {
            bool ret = false;

            DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = tokuisakiMaster.getTokuisakiInfo(tokuisakiCode, jigyousyoCode, true);

            if (tokuisakiInfos.Count > 0)
            {
                ret = true;
            }

            return ret;
        }
        #endregion

        #endregion

        #region プレビューボタン押下イベント
        /// <summary>
        /// プレビューボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!btnPreview.Enabled || !btnPreview.Visible) return;
            executePrint(PrintType.Preview);
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
            if (!btnPrint.Enabled || !btnPrint.Visible) return;
            executePrint(PrintType.OutPut);
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            // 帳票データの設定
            rptTokuisakiMaster1.SetDataSource(createPrintData());
            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptTokuisakiMaster1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptTokuisakiMaster1.PrintOptions.PaperOrientation)
                                                                     , rptTokuisakiMaster1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptTokuisakiMaster1.PrintToPrinter(printerSettings
                                                 , pageSettings
                                                 , false);

                }
            }
            else
            {
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptTokuisakiMaster1;
                printView.Size = new Size(1375, 975);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #region 帳票出力データ生成処理
        /// <summary>
        /// 帳票出力データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblTokuisakiMaster createPrintData()
        {
            dtblTokuisakiMaster printData = new dtblTokuisakiMaster();
            string tokuisakiKanaName1 = string.Empty;
            string tokuisakiKanaName2 = string.Empty;
            string saisyuKoushinBi;

            for (int i = 0; i < txtCustomerKanaName.Text.Length; i++)
            {
                if (i < 20)
                {
                    tokuisakiKanaName1 += Convert.ToString(txtCustomerKanaName.Text[i]);
                }
                else
                {
                    tokuisakiKanaName2 += Convert.ToString(txtCustomerKanaName.Text[i]);
                }
            }
            saisyuKoushinBi = txtLastUpDateYear.Text + "年" + txtLastUpDateMonth.Text + "月" + txtLastUpDateDay.Text + "日";
            if (!string.IsNullOrEmpty(lblDeletedMessage.Text)) saisyuKoushinBi += "　" + lblDeletedMessage.Text;

            printData.Tables["dtblTokuisakiMaster"].Rows.Add();
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["tihou"] = cmbRegion.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["todouhuken"] = cmbPrefectures.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["tokuisakiCode"] = txtCustomerCode.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["tokuisakiName"] = txtCustomerName.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["tokuisakiKanaName1"] = tokuisakiKanaName1;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["tokuisakiKanaName2"] = tokuisakiKanaName2;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["jigyousyoCode"] = txtOfficeCode.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["jigyousyoName"] = txtOfficeName.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["yubinNo"] = txtZipCode1.Text + "-" + txtZipCode2.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["jusyo1"] = txtAddress1.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["jusyo2"] = txtAddress2.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["renrakusaki1"] = txtContact1.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["renrakusaki2"] = txtContact2.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["tokuisakiTantousyaName"] = txtCustomerPersonName.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["shimebi"] = cmbClosingDate.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["seikyuKanriKubun"] = cmbClaimType.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["parentTokuisakiCode"] = txtBillingAddressCode.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["parentJigyousyoCode"] = txtBillingOfficeCode.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["kaisyuSaito"] = cmbRecoverySight.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["kurikoshiSyuturyokuKubun"] = cmbCarryForwardAmountDisp.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["seikyuSyuturyokuKubun"] = cmbClaimDispType.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["mitumoriSyouhizei"] = cmbEstimatesTaxDisp.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["nouhinsyoSyouhizei"] = cmbDeliveryNoteTaxDisp.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["hasuKubun"] = cmbTaxFractionType.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["kingakuHasuKubun"] = cmbAmountFractionType.Text;
            printData.Tables["dtblTokuisakiMaster"].Rows[0]["saisyuKoushinBi"] = saisyuKoushinBi;

            return printData;
        }
        #endregion
    }
}
