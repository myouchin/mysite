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

namespace Nyukin
{
    public partial class frmNyukinInput : Common.ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private DBShiresakiMaster shiresakiMaster;
        private DBTokuisakiMaster tokuisakiMaster;
        private DBTantousyaMaster tantousyaMaster;
        DBNyukin nyukinDataDb;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , DepositDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private bool flgBtnSearchSelect = false;
        private bool flgSetData = false;
        private string dummyCode = "Dummy";
        private string amountFormat;
        private string totalAmountFormat;
        sfrmNyukinSearch sNyukin;
        sfrmTokuisakiSearch fTokuisaki;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmNyukinInput()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            nyukinDataDb = new DBNyukin();
            shiresakiMaster = new DBShiresakiMaster();
            tokuisakiMaster = new DBTokuisakiMaster();
            tantousyaMaster = new DBTantousyaMaster();
            commonLogic = new CommonLogic();
            sNyukin = new sfrmNyukinSearch(false, CheckMessageType.None);
            fTokuisaki = new sfrmTokuisakiSearch(false);
        }
        #endregion

        #region 画面起動時のイベント
        /// <summary>
        /// 画面起動時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNyukinInput_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtDepositNo;
            // 金額フォーマット文字列取得
            amountFormat = commonLogic.getNumberFormatString(txtTransfer.MaxLength, 0);
            // 合計金額フォーマット文字列取得
            totalAmountFormat = commonLogic.getNumberFormatString(txtTotal.MaxLength, 0);

            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
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

        #region 検索ボタン押下イベント
        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TODO
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
            // 入金Noを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtDepositNo.Name))
            {
                // 入金検索画面を起動
                sNyukin.MType = messageType;
                sNyukin.ShowDialog();

                if (sNyukin.DialogResult == DialogResult.OK)
                {
                    flgSearch = false;
                    // 入金情報の設定
                    setNyukinData(sNyukin.SelectedNyukinInfos[0].NyukinNo);
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                flgSetFocus = true;
            }
            // 得意先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
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

        #region 印刷ボタン押下イベント
        /// <summary>
        /// 印刷ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //TODO
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
                string nyukinNo = txtDepositNo.Text;
                DateTime registerDate = DateTime.Now;
                string sqlNyukinCommand = createNyukinRegistSql(ref nyukinNo, registerDate);
                string sqlKanriMasterCommand = rdoNew.Checked ? createKanriMasterRegistSql(nyukinNo, registerDate) : string.Empty;
                int nyukinRegistResult = 0;
                int kanriMasterRegistResult = 0;
                nyukinDataDb.DBRef = 0;

                if (rdoNew.Checked)
                {
                    nyukinDataDb.startTransaction();
                    // 管理マスタ(入金No)のロック
                    nyukinDataDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.NyukinNo + "'", true);
                    if (nyukinDataDb.DBRef != 0)
                    {
                        nyukinDataDb.endTransaction();
                        errorOK("入金Noロックエラー");
                        flgSaving = false;
                        return;
                    }
                }

                // 入金データの更新
                nyukinRegistResult = nyukinDataDb.executeDBUpdate(sqlNyukinCommand);

                // 管理マスタの更新
                if (nyukinDataDb.DBRef == 0 && !string.IsNullOrEmpty(sqlKanriMasterCommand)) kanriMasterRegistResult = nyukinDataDb.executeDBUpdate(sqlKanriMasterCommand);

                if (nyukinDataDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (nyukinRegistResult < 0 || kanriMasterRegistResult < 0)
                    {
                        tableName = "入金データ";
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
                    if (rdoNew.Checked) nyukinDataDb.endTransaction();
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "入金No:" + nyukinNo;
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
                    if (rdoNew.Checked) nyukinDataDb.endTransaction();
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
            if (nyukinDataDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                nyukinDataDb.endTransaction();
            }
            closedForm();
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

        #region 入金Noのフォーカスアウトイベント
        /// <summary>
        /// 入金Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepositNo_Leave(object sender, EventArgs e)
        {
            if (flgSetData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                flgSetData = true;
                // 入金情報設定処理を実行
                bool ret = setNyukinData(commonLogic.getZeroBuriedNumberText(txtDepositNo.Text, txtDepositNo.MaxLength));

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

        #region 入金日付のフォーカスインイベント
        /// <summary>
        /// 入金日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depositDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DepositDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 入金日付のフォーカスアウトイベント
        /// <summary>
        /// 入金日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depositDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DepositDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DepositDate;
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
                txtPlace.Text = string.Empty;
                txtArea.Text = string.Empty;
                txtZipCode.Text = string.Empty;
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                setOfficesCmb(dummyCode, string.Empty);
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
                    case LastInputDateType.DepositDate:
                        y = txtDepositDateYears.Text;
                        m = txtDepositDateMonth.Text;
                        d = txtDepositDateDays.Text;
                        inputObj = dtpDepositDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.DepositDate.Equals(lastInputDateType))
                    {
                        txtDepositDateYears.Focus();
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

        #endregion

        #region ビジネスロジック

        #region 担当者コンボボックスの設定
        /// <summary>
        /// 担当者コンボボックスの設定
        /// </summary>
        private void setPersonnelCmb()
        {
            // 担当者取得
            DataTable tantousyaDt = tantousyaMaster.getTantousyaDataTable(string.Empty, string.Empty);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPersonnel, tantousyaDt, "tantousyaCode", "tantousyaName");
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
            commonLogic.setComboBoxDataSource(ref cmbOffices, officesDt, "jigyousyoCode", "jigyousyoName");
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

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // キー押下イベントを追加
            c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

            // 入金Noの場合
            if (c.Name.Equals(txtDepositNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDepositNo_Leave);
            }
            // 仕入日付の場合
            else if (c.Name.Equals(txtDepositDateYears.Name) ||
                     c.Name.Equals(txtDepositDateMonth.Name) ||
                     c.Name.Equals(txtDepositDateDays.Name) ||
                     c.Name.Equals(dtpDepositDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.depositDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.depositDate_Leave);
            }
            // 得意先コードの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            }
            // 金額項目の場合
            else if (c.Name.Equals(txtCash.Name) ||
                     c.Name.Equals(txtTransfer.Name) ||
                     c.Name.Equals(txtFee.Name) ||
                     c.Name.Equals(txtCheck.Name) ||
                     c.Name.Equals(txtBills.Name) ||
                     c.Name.Equals(txtBillsDiscount.Name) ||
                     c.Name.Equals(txtOffset.Name) ||
                     c.Name.Equals(txtRebate.Name) ||
                     c.Name.Equals(txtERReceivables.Name) ||
                     c.Name.Equals(txtAdjustment.Name) ||
                     c.Name.Equals(txtOther.Name))
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
            if (nyukinDataDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                nyukinDataDb.endTransaction();
            }

            activeRadioButton = radio;
            #region 共通初期値設定
            txtDepositNo.Text = string.Empty;
            dtpDepositDate.Value = syoriDate.AddDays(1);
            dtpDepositDate.Value = syoriDate;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            cmbPersonnel.SelectedValue = Program.loginUserInfo.UserId;
            txtCash.Text = string.Empty;
            txtTransfer.Text = string.Empty;
            txtFee.Text = string.Empty;
            txtCheck.Text = string.Empty;
            txtBills.Text = string.Empty;
            txtBillsDiscount.Text = string.Empty;
            txtOffset.Text = string.Empty;
            txtRebate.Text = string.Empty;
            txtERReceivables.Text = string.Empty;
            txtAdjustment.Text = string.Empty;
            txtOther.Text = string.Empty;
            txtTotal.Text = string.Empty;
            // 隠し項目
            txtCustomerKanaName.Text = string.Empty;
            txtPlace.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
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
                txtDepositNo.Enabled = true;
                txtDepositNo.ReadOnly = true;
                txtDepositDateYears.Enabled = true;
                txtDepositDateMonth.Enabled = true;
                txtDepositDateDays.Enabled = true;
                dtpDepositDate.Enabled = true;
                txtCustomerCode.Enabled = true;
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                cmbOffices.Enabled = true;
                txtCash.Enabled = true;
                txtTransfer.Enabled = true;
                txtFee.Enabled = true;
                txtCheck.Enabled = true;
                txtBills.Enabled = true;
                txtBillsDiscount.Enabled = true;
                txtOffset.Enabled = true;
                txtRebate.Enabled = true;
                txtERReceivables.Enabled = true;
                txtAdjustment.Enabled = true;
                txtOther.Enabled = true;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtDepositNo.Focus();

                // 背景色設定
                txtDepositDateYears.BackColor = Color.White;
                txtDepositDateMonth.BackColor = Color.White;
                txtDepositDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtDepositNo.Enabled = !flgSearch;
                txtDepositNo.ReadOnly = false;
                txtDepositDateYears.Enabled = flgSearch;
                txtDepositDateMonth.Enabled = flgSearch;
                txtDepositDateDays.Enabled = flgSearch;
                dtpDepositDate.Enabled = flgSearch;
                txtCustomerCode.Enabled = flgSearch;
                txtCustomerName.Enabled = flgSearch && Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                cmbOffices.Enabled = flgSearch;
                txtCash.Enabled = flgSearch;
                txtTransfer.Enabled = flgSearch;
                txtFee.Enabled = flgSearch;
                txtCheck.Enabled = flgSearch;
                txtBills.Enabled = flgSearch;
                txtBillsDiscount.Enabled = flgSearch;
                txtOffset.Enabled = flgSearch;
                txtRebate.Enabled = flgSearch;
                txtERReceivables.Enabled = flgSearch;
                txtAdjustment.Enabled = flgSearch;
                txtOther.Enabled = flgSearch;
                txtTotal.Enabled = flgSearch;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                bool setFocus = !flgSearch ? txtDepositNo.Focus() : txtDepositDateYears.Focus();

                // 背景色設定
                txtDepositDateYears.BackColor = Color.White;
                txtDepositDateMonth.BackColor = Color.White;
                txtDepositDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtDepositNo.Enabled = !flgSearch;
                txtDepositNo.ReadOnly = false;
                txtDepositDateYears.Enabled = false;
                txtDepositDateMonth.Enabled = false;
                txtDepositDateDays.Enabled = false;
                dtpDepositDate.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCash.Enabled = false;
                txtTransfer.Enabled = false;
                txtFee.Enabled = false;
                txtCheck.Enabled = false;
                txtBills.Enabled = false;
                txtBillsDiscount.Enabled = false;
                txtOffset.Enabled = false;
                txtRebate.Enabled = false;
                txtERReceivables.Enabled = false;
                txtAdjustment.Enabled = false;
                txtOther.Enabled = false;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtDepositNo.Focus();

                // 背景色設定
                txtDepositDateYears.BackColor = Color.White;
                txtDepositDateMonth.BackColor = Color.White;
                txtDepositDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtDepositNo.Enabled = !flgSearch;
                txtDepositNo.ReadOnly = false;
                txtDepositDateYears.Enabled = false;
                txtDepositDateMonth.Enabled = false;
                txtDepositDateDays.Enabled = false;
                dtpDepositDate.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCash.Enabled = false;
                txtTransfer.Enabled = false;
                txtFee.Enabled = false;
                txtCheck.Enabled = false;
                txtBills.Enabled = false;
                txtBillsDiscount.Enabled = false;
                txtOffset.Enabled = false;
                txtRebate.Enabled = false;
                txtERReceivables.Enabled = false;
                txtAdjustment.Enabled = false;
                txtOther.Enabled = false;
                txtTotal.Enabled = false;
                btnSearch.Enabled = true;
                btnPrint.Enabled = false;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtDepositNo.Focus();

                // 背景色設定
                txtDepositDateYears.BackColor = Color.White;
                txtDepositDateMonth.BackColor = Color.White;
                txtDepositDateDays.BackColor = Color.White;

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
                string nyukinDate = commonLogic.convertDateTime(txtDepositDateYears.Text, txtDepositDateMonth.Text, txtDepositDateDays.Text).ToString("yyyy/MM/dd");
                if (!string.IsNullOrEmpty(txtDepositNo.Text) ||
                    !nyukinDate.Equals(syoriDate.ToString("yyyy/MM/dd")) ||
                    !Program.loginUserInfo.UserId.Equals(cmbPersonnel.Text) ||
                    !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                    !string.IsNullOrEmpty(txtCustomerName.Text) ||
                    !string.IsNullOrEmpty(cmbOffices.Text) ||
                    !string.IsNullOrEmpty(txtCash.Text) ||
                    !string.IsNullOrEmpty(txtTransfer.Text) ||
                    !string.IsNullOrEmpty(txtFee.Text) ||
                    !string.IsNullOrEmpty(txtCheck.Text) ||
                    !string.IsNullOrEmpty(txtBills.Text) ||
                    !string.IsNullOrEmpty(txtBillsDiscount.Text) ||
                    !string.IsNullOrEmpty(txtOffset.Text) ||
                    !string.IsNullOrEmpty(txtRebate.Text) ||
                    !string.IsNullOrEmpty(txtERReceivables.Text) ||
                    !string.IsNullOrEmpty(txtAdjustment.Text) ||
                    !string.IsNullOrEmpty(txtOther.Text) ||
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

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
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
                    txtPlace.Text = string.Empty;
                    txtArea.Text = string.Empty;
                    txtZipCode.Text = string.Empty;
                    txtAddress1.Text = string.Empty;
                    txtAddress2.Text = string.Empty;
                    // フォーカス設定
                    txtCustomerName.Focus();
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
                    txtPlace.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcChihouCode]);
                    txtArea.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcChikuCode]);
                    txtZipCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcZipCode]);
                    txtAddress1.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcAddress1]);
                    txtAddress2.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcAddress2]);

                }
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
                // 入力可否設定
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
            }
            else
            {
                txtCustomerCode.Text = tokuisakiCode;
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
            cmbOffices.BeforeSelectedValue = Convert.ToString(cmbOffices.SelectedValue);
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
            // 新規作成でないかつ入金Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDepositNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 得意先コードを編集中の場合
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

        #region 入力情報設定処理
        /// <summary>
        /// 入力情報設定処理
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtDepositNo.MaxLength = 8;
            txtDepositDateYears.MaxLength = 4;
            txtDepositDateMonth.MaxLength = 2;
            txtDepositDateDays.MaxLength = 2;
            txtCustomerCode.MaxLength = 5;
            txtCustomerName.MaxLength = 40;
            cmbOffices.MaxLength = 10;
            txtCash.MaxLength = 8;
            txtTransfer.MaxLength = 8;
            txtFee.MaxLength = 8;
            txtCheck.MaxLength = 8;
            txtBills.MaxLength = 8;
            txtBillsDiscount.MaxLength = 8;
            txtOffset.MaxLength = 8;
            txtRebate.MaxLength = 8;
            txtERReceivables.MaxLength = 8;
            txtAdjustment.MaxLength = 8;
            txtOther.MaxLength = 8;
            txtTotal.MaxLength = 15;

            // 入力制御イベント設定
            txtDepositNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 入金No       :数字のみ入力可
            txtDepositDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 入金日付(年) :数字のみ入力可
            txtDepositDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 入金日付(月) :数字のみ入力可
            txtDepositDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 入金日付(日) :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 仕入先コード :数字のみ入力可

            txtCash.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);              // 現金         :数値のみ入力可
            txtTransfer.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);          // 振込         :数値のみ入力可
            txtFee.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);               // 手数料       :数値のみ入力可
            txtCheck.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);             // 小切手       :数値のみ入力可
            txtBills.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);             // 手形         :数値のみ入力可
            txtBillsDiscount.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);     // 手形割引料   :数値のみ入力可
            txtOffset.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);            // 相殺         :数値のみ入力可
            txtRebate.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);            // リベート     :数値のみ入力可
            txtERReceivables.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);     // でんさい     :数値のみ入力可
            txtAdjustment.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);        // 調整         :数値のみ入力可
            txtOther.KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);             // その他       :数値のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 入金データ設定処理
        /// <summary>
        /// 入金データ設定処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <returns></returns>
        private bool setNyukinData(string nyukinNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            // トランザクション開始処理を実行
            nyukinDataDb.startTransaction();
            if (rdoNew.Checked) nyukinDataDb.endTransaction();

            // 取得時にエラーが発生した場合
            if (nyukinDataDb.getNyukiniData(nyukinNo) != DBNyukin.SelectErrorType.None)
            {
                errorOK(string.Format(Messages.M0027, "入金データ"));
                return false;
            }

            DBFileLayout.NyukinFile data = nyukinDataDb.SelectNyukinData;

            // 入金データが存在する場合
            if (data.FlgDataExsit)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(data.KanriKubun)))
                {
                    string msg1 = rdoCorrection.Checked ? "訂正" : rdoReference.Checked ? "参照" : "削除";
                    errorOK(string.Format(Messages.M0013, "削除", "入金データ", msg1));
                    return false;
                }
            }
            // 入金ヘッダデータが存在しない場合
            else
            {
                string messageText = lblDepositNo.Text;
                // エラーメッセージを出力して処理を終了
                errorOK(string.Format(Messages.M0003, messageText));
                return false;
            }

            // 取得した入金データを画面項目に設定します
            if (!rdoNew.Checked) txtDepositNo.Text = data.NyukinNo;
            dtpDepositDate.Value = Convert.ToDateTime(data.NyukinHizuke).AddDays(1);
            dtpDepositDate.Value = Convert.ToDateTime(data.NyukinHizuke);
            var tantosya = ((DataTable)cmbPersonnel.DataSource).AsEnumerable().Where(p => p.Field<string>(commonLogic.StrCmbKey).Equals(data.TantousyaCode));
            if (tantosya.Count() > 0)
            {
                cmbPersonnel.SelectedValue = data.TantousyaCode;
            }
            else
            {
                cmbPersonnel.Text = data.TantousyaName;
            }
            txtCustomerCode.Text = data.TokuisakiCode;
            txtCustomerName.Text = data.TokuisakiName;
            setOfficesCmb(data.TokuisakiCode, string.Empty);
            var jigyousyo = ((DataTable)cmbOffices.DataSource).AsEnumerable().Where(p => p.Field<string>(commonLogic.StrCmbValue).Equals(data.JigyousyoCode));
            if (jigyousyo.Count() > 0)
            {
                cmbOffices.SelectedValue = data.JigyousyoCode;
            }
            else
            {
                cmbOffices.Text = data.JigyousyoName;
            }
            string strGenkin = data.Genkin == null ? string.Empty : Convert.ToDecimal(data.Genkin).ToString(amountFormat);
            string strHurikomi = data.Hurikomi == null ? string.Empty : Convert.ToDecimal(data.Hurikomi).ToString(amountFormat);
            string strTesuryo = data.Tesuryo == null ? string.Empty : Convert.ToDecimal(data.Tesuryo).ToString(amountFormat);
            string strKogitte = data.Kogitte == null ? string.Empty : Convert.ToDecimal(data.Kogitte).ToString(amountFormat);
            string strTegata = data.Tegata == null ? string.Empty : Convert.ToDecimal(data.Tegata).ToString(amountFormat);
            string strTegataWaribiki = data.TegataWaribiki == null ? string.Empty : Convert.ToDecimal(data.TegataWaribiki).ToString(amountFormat);
            string strSousai = data.Sousai == null ? string.Empty : Convert.ToDecimal(data.Sousai).ToString(amountFormat);
            string strRibeto = data.Ribeto == null ? string.Empty : Convert.ToDecimal(data.Ribeto).ToString(amountFormat);
            string strDensai = data.Densai == null ? string.Empty : Convert.ToDecimal(data.Densai).ToString(amountFormat);
            string strTyousei = data.Tyousei == null ? string.Empty : Convert.ToDecimal(data.Tyousei).ToString(amountFormat);
            string strSonota = data.Sonota == null ? string.Empty : Convert.ToDecimal(data.Sonota).ToString(amountFormat);
            string strGoukei = data.Goukei == null ? string.Empty : Convert.ToDecimal(data.Goukei).ToString(amountFormat);
            txtCash.Text = strGenkin;
            txtTransfer.Text = strHurikomi;
            txtFee.Text = strTesuryo;
            txtCheck.Text = strKogitte;
            txtBills.Text = strTegata;
            txtBillsDiscount.Text = strTegataWaribiki;
            txtOffset.Text = strSousai;
            txtRebate.Text = strRibeto;
            txtERReceivables.Text = strDensai;
            txtAdjustment.Text = strTyousei;
            txtOther.Text = strSonota;
            txtTotal.Text = strGoukei;
            txtCustomerKanaName.Text = data.TokuisakiKanaName;
            txtPlace.Text = data.ChihouCode;
            txtArea.Text = data.ChikuCode;
            txtZipCode.Text = data.ZipCode;
            txtAddress1.Text = data.Addres1;
            txtAddress2.Text = data.Addres2;

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
            // 振込集計
            if (decimal.TryParse(txtTransfer.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // 手数料集計
            if (decimal.TryParse(txtFee.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // 小切手集計
            if (decimal.TryParse(txtCheck.Text, out amount))
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
            // 手形割引料集計
            if (decimal.TryParse(txtBillsDiscount.Text, out amount))
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
            // リベート集計
            if (decimal.TryParse(txtRebate.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // でんさい集計
            if (decimal.TryParse(txtERReceivables.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // 調整集計
            if (decimal.TryParse(txtAdjustment.Text, out amount))
            {
                flgAmountCalc = true;
                totalAmount += amount;
            }
            // その他集計
            if (decimal.TryParse(txtOther.Text, out amount))
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

            if (string.IsNullOrEmpty(txtDepositDateYears.Text) ||
                string.IsNullOrEmpty(txtDepositDateMonth.Text) ||
                string.IsNullOrEmpty(txtDepositDateDays.Text))
            {
                errorItem = lblDepositDate.Text;
            }
            else if (string.IsNullOrEmpty(cmbPersonnel.Text))
            {
                errorItem = lblPersonnel.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                errorItem = lblCustomerCode.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                errorItem = lblCustomerName.Text;
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

        #region 入金データ登録・更新SQL生成処理
        /// <summary>
        /// 入金データ登録・更新SQL生成処理
        /// </summary>
        /// <param name="shiharaiNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createNyukinRegistSql(ref string nyukinNo, DateTime registerDate)
        {
            string sql = string.Empty;

            DateTime nyukinHizuke = commonLogic.convertDateTime(txtDepositDateYears.Text, txtDepositDateMonth.Text, txtDepositDateDays.Text);
            string tantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);
            string tantousyaName = cmbPersonnel.Text;
            string tokuisakiCode = txtCustomerCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string jigyousyoName = cmbOffices.Text;
            string chihouCode = txtPlace.Text;
            string chikuCode = txtArea.Text;
            string zipCode = Convert.ToString(txtZipCode.Text);
            string addres1 = Convert.ToString(txtAddress1.Text);
            string addres2 = Convert.ToString(txtAddress2.Text);
            string genkin = Convert.ToString(txtCash.Text);
            string hurikomi = Convert.ToString(txtTransfer.Text);
            string tesuryo = Convert.ToString(txtFee.Text);
            string kogitte = Convert.ToString(txtCheck.Text);
            string tegata = Convert.ToString(txtBills.Text);
            string tegataWaribiki = Convert.ToString(txtBillsDiscount.Text);
            string sousai = Convert.ToString(txtOffset.Text);
            string ribeto = Convert.ToString(txtRebate.Text);
            string densai = Convert.ToString(txtERReceivables.Text);
            string tyousei = Convert.ToString(txtAdjustment.Text);
            string sonota = Convert.ToString(txtOther.Text);
            string goukei = Convert.ToString(txtTotal.Text);

            if (rdoNew.Checked)
            {
                // 入金No採番
                nyukinNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getNyukinNo() + 1).ToString(), txtDepositNo.MaxLength);

                // 入金データの登録SQL生成
                sql += "INSERT INTO nyukin ";
                sql += "( ";
                sql += "  nyukinNo ";
                sql += ", nyukinHizuke ";
                sql += ", tantousyaCode ";
                sql += ", tantousyaName ";
                sql += ", tokuisakiCode ";
                sql += ", tokuisakiName ";
                sql += ", tokuisakiKanaName ";
                sql += ", jigyousyoCode ";
                sql += ", jigyousyoName ";
                sql += ", chihouCode ";
                sql += ", chikuCode ";
                sql += ", zipCode ";
                sql += ", addres1 ";
                sql += ", addres2 ";
                sql += ", genkin ";
                sql += ", hurikomi ";
                sql += ", tesuryo ";
                sql += ", kogitte ";
                sql += ", tegata ";
                sql += ", tegataWaribiki ";
                sql += ", sousai ";
                sql += ", ribeto ";
                sql += ", densai ";
                sql += ", tyousei ";
                sql += ", sonota ";
                sql += ", goukei ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + nyukinNo + "' ";
                sql += "," + "'" + nyukinHizuke + "' ";
                sql += "," + "'" + tantousyaCode + "' ";
                sql += "," + "'" + tantousyaName + "' ";
                sql += "," + "'" + tokuisakiCode + "' ";
                sql += "," + "'" + tokuisakiName + "' ";
                sql += "," + "'" + tokuisakiKanaName + "' ";
                sql += "," + "'" + jigyousyoCode + "' ";
                sql += "," + "'" + jigyousyoName + "' ";
                sql += "," + "'" + chihouCode + "' ";
                sql += "," + "'" + chikuCode + "' ";
                sql += "," + "'" + zipCode + "' ";
                sql += "," + "'" + addres1 + "' ";
                sql += "," + "'" + addres2 + "' ";
                sql += "," + (string.IsNullOrEmpty(genkin) ? "null" : Convert.ToDecimal(genkin).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(hurikomi) ? "null" : Convert.ToDecimal(hurikomi).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(tesuryo) ? "null" : Convert.ToDecimal(tesuryo).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(kogitte) ? "null" : Convert.ToDecimal(kogitte).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(tegata) ? "null" : Convert.ToDecimal(tegata).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(tegataWaribiki) ? "null" : Convert.ToDecimal(tegataWaribiki).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(sousai) ? "null" : Convert.ToDecimal(sousai).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(ribeto) ? "null" : Convert.ToDecimal(ribeto).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(densai) ? "null" : Convert.ToDecimal(densai).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(tyousei) ? "null" : Convert.ToDecimal(tyousei).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(sonota) ? "null" : Convert.ToDecimal(sonota).ToString()) + " ";
                sql += "," + (string.IsNullOrEmpty(goukei) ? "null" : Convert.ToDecimal(goukei).ToString()) + " ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 入金データの更新SQL生成
                sql = "UPDATE nyukin SET ";
                sql += "  nyukinNo = '" + nyukinNo + "' ";
                sql += ", nyukinHizuke = '" + nyukinHizuke + "' ";
                sql += ", tantousyaCode = '" + tantousyaCode + "' ";
                sql += ", tantousyaName = '" + tantousyaName + "' ";
                sql += ", tokuisakiCode = '" + tokuisakiCode + "' ";
                sql += ", tokuisakiName = '" + tokuisakiName + "' ";
                sql += ", tokuisakiKanaName = '" + tokuisakiKanaName + "' ";
                sql += ", jigyousyoCode = '" + jigyousyoCode + "' ";
                sql += ", jigyousyoName = '" + jigyousyoName + "' ";
                sql += ", chihouCode = '" + chihouCode + "' ";
                sql += ", chikuCode = '" + chikuCode + "' ";
                sql += ", zipCode = '" + zipCode + "' ";
                sql += ", addres1 = '" + addres1 + "' ";
                sql += ", addres2 = '" + addres2 + "' ";
                sql += ", genkin = " + (string.IsNullOrEmpty(genkin) ? "null" : Convert.ToDecimal(genkin).ToString()) + " ";
                sql += ", hurikomi = " + (string.IsNullOrEmpty(hurikomi) ? "null" : Convert.ToDecimal(hurikomi).ToString()) + " ";
                sql += ", tesuryo = " + (string.IsNullOrEmpty(tesuryo) ? "null" : Convert.ToDecimal(tesuryo).ToString()) + " ";
                sql += ", kogitte = " + (string.IsNullOrEmpty(kogitte) ? "null" : Convert.ToDecimal(kogitte).ToString()) + " ";
                sql += ", tegata = " + (string.IsNullOrEmpty(tegata) ? "null" : Convert.ToDecimal(tegata).ToString()) + " ";
                sql += ", tegataWaribiki = " + (string.IsNullOrEmpty(tegataWaribiki) ? "null" : Convert.ToDecimal(tegataWaribiki).ToString()) + " ";
                sql += ", sousai = " + (string.IsNullOrEmpty(sousai) ? "null" : Convert.ToDecimal(sousai).ToString()) + " ";
                sql += ", ribeto = " + (string.IsNullOrEmpty(ribeto) ? "null" : Convert.ToDecimal(ribeto).ToString()) + " ";
                sql += ", densai = " + (string.IsNullOrEmpty(densai) ? "null" : Convert.ToDecimal(densai).ToString()) + " ";
                sql += ", tyousei = " + (string.IsNullOrEmpty(tyousei) ? "null" : Convert.ToDecimal(tyousei).ToString()) + " ";
                sql += ", sonota = " + (string.IsNullOrEmpty(sonota) ? "null" : Convert.ToDecimal(sonota).ToString()) + " ";
                sql += ", goukei = " + (string.IsNullOrEmpty(goukei) ? "null" : Convert.ToDecimal(goukei).ToString()) + " ";
                sql += ", kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '' ";
                sql += "WHERE nyukinNo = '" + nyukinNo + "' ";
            }
            else
            {
                // 入金データの論理削除SQL生成
                sql = "UPDATE nyukin SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE nyukinNo = '" + nyukinNo + "' ";
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
            sql += "WHERE kanriCode = '" + Consts.KanriCodes.NyukinNo + "' ";

            return sql;
        }
        #endregion

        #endregion
    }
}
