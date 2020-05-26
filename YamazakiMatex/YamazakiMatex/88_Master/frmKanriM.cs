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

namespace Master
{
    public partial class frmKanriM : ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , ProcessingDate = 1
          , ClaimTightenDate = 2
          , MonthlyProcessingDate = 3
          , AnnualProcessingDate = 4
          , EndTaxDate = 4
          , StartTaxDate = 5
          , PurchaseTightenDate = 6
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private RadioButton activeRadioButton = null;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private DBCommon masterDataSelectDb;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public frmKanriM()
        {
            InitializeComponent();
            masterDataSelectDb = new DBCommon();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmKanriM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtEstimatesNo;
            // 最大入力桁数設定
            setInputInfo();
            // ラジオボタン変更処理実行
            inputModeChange(rdoCorrection);
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

            // 処理日付の場合
            if (c.Name.Equals(txtProcessingDateYears.Name) ||
                c.Name.Equals(txtProcessingDateMonth.Name) ||
                c.Name.Equals(txtProcessingDateDays.Name) ||
                c.Name.Equals(dtpProcessingDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtProcessingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtProcessingDate_Leave);
            }
            // 請求締日の場合
            else if (c.Name.Equals(txtClaimTightenDateYears.Name) ||
                     c.Name.Equals(txtClaimTightenDateMonth.Name) ||
                     c.Name.Equals(txtClaimTightenDateDays.Name) ||
                     c.Name.Equals(dtpClaimTightenDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtClaimTightenDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtClaimTightenDate_Leave);
            }
            // 月次処理日の場合
            else if (c.Name.Equals(txtMonthlyProcessingDateYears.Name) ||
                     c.Name.Equals(txtMonthlyProcessingDateMonth.Name) ||
                     c.Name.Equals(txtMonthlyProcessingDateDays.Name) ||
                     c.Name.Equals(dtpMonthlyProcessingDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtMonthlyProcessingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtMonthlyProcessingDate_Leave);
            }
            // 年次処理日の場合
            else if (c.Name.Equals(txtAnnualProcessingDateYears.Name) ||
                     c.Name.Equals(txtAnnualProcessingDateMonth.Name) ||
                     c.Name.Equals(txtAnnualProcessingDateDays.Name) ||
                     c.Name.Equals(dtpAnnualProcessingDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtAnnualProcessingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtAnnualProcessingDate_Leave);
            }
            // 終了消費税日付の場合
            else if (c.Name.Equals(txtEndTaxDateYears.Name) ||
                     c.Name.Equals(txtEndTaxDateMonth.Name) ||
                     c.Name.Equals(txtEndTaxDateDays.Name) ||
                     c.Name.Equals(dtpEndTaxDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtEndTaxDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEndTaxDate_Leave);
            }
            // 開始消費税日付の場合
            else if (c.Name.Equals(txtStartTaxDateYears.Name) ||
                     c.Name.Equals(txtStartTaxDateMonth.Name) ||
                     c.Name.Equals(txtStartTaxDateDays.Name) ||
                     c.Name.Equals(dtpStartTaxDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtStartTaxDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtStartTaxDate_Leave);
            }
            // 仕入締日の場合
            else if (c.Name.Equals(txtPurchaseTightenDateYears.Name) ||
                     c.Name.Equals(txtPurchaseTightenDateMonth.Name) ||
                     c.Name.Equals(txtPurchaseTightenDateDays.Name) ||
                     c.Name.Equals(dtpPurchaseTightenDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtPurchaseTightenDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtPurchaseTightenDate_Leave);
            }

            // フォーカスインイベントを追加
            c.Enter += new EventHandler(inputObject_Enter);

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

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.ProcessingDate:
                        y = txtProcessingDateYears.Text;
                        m = txtProcessingDateMonth.Text;
                        d = txtProcessingDateDays.Text;
                        inputObj = dtpProcessingDate;
                        break;
                    case LastInputDateType.ClaimTightenDate:
                        y = txtClaimTightenDateYears.Text;
                        m = txtClaimTightenDateMonth.Text;
                        d = txtClaimTightenDateDays.Text;
                        inputObj = dtpClaimTightenDate;
                        break;
                    case LastInputDateType.EndTaxDate:
                        y = txtEndTaxDateYears.Text;
                        m = txtEndTaxDateMonth.Text;
                        d = txtEndTaxDateDays.Text;
                        inputObj = dtpEndTaxDate;
                        break;
                    case LastInputDateType.StartTaxDate:
                        y = txtStartTaxDateYears.Text;
                        m = txtStartTaxDateMonth.Text;
                        d = txtStartTaxDateDays.Text;
                        inputObj = dtpClaimTightenDate;
                        break;
                    case LastInputDateType.PurchaseTightenDate:
                        y = txtPurchaseTightenDateYears.Text;
                        m = txtPurchaseTightenDateMonth.Text;
                        d = txtPurchaseTightenDateDays.Text;
                        inputObj = dtpPurchaseTightenDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.ProcessingDate.Equals(lastInputDateType))
                    {
                        txtProcessingDateYears.Focus();
                    }
                    else if (LastInputDateType.ClaimTightenDate.Equals(lastInputDateType))
                    {
                        txtClaimTightenDateYears.Focus();
                    }
                    else if (LastInputDateType.EndTaxDate.Equals(lastInputDateType))
                    {
                        txtEndTaxDateYears.Focus();
                    }
                    else if (LastInputDateType.StartTaxDate.Equals(lastInputDateType))
                    {
                        txtStartTaxDateYears.Focus();
                    }
                    else if (LastInputDateType.PurchaseTightenDate.Equals(lastInputDateType))
                    {
                        txtPurchaseTightenDateYears.Focus();
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

            // 処理実行確認
            if (queryYesNo(Messages.M0001) == DialogResult.Yes)
            {
                masterDataSelectDb.startTransaction();
                DateTime registerDate = DateTime.Now;
                List<string> sqlKanriMasterCommands = createRegistSql(registerDate);
                // 管理マスタの更新
                foreach (string command in sqlKanriMasterCommands)
                {
                    masterDataSelectDb.executeDBUpdate(command);
                }

                if (masterDataSelectDb.DBRef < 0)
                {
                    errorOK(string.Format(Messages.M0011, "管理マスタ", "更新処理"));
                    masterDataSelectDb.endTransaction();
                    return;
                }
                else
                {
                    messageOK(string.Format(Messages.M0012, "管理マスタ", "訂正"));
                    masterDataSelectDb.endTransaction();
                    btnCancel_Click(null, null);
                    return;
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
                if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }
            RadioButton activeModeRdo = null;
            if (rdoCorrection.Checked)
            {
                activeModeRdo = rdoCorrection;
            }
            else if (rdoReference.Checked)
            {
                activeModeRdo = rdoReference;
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
                if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
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

        #region 処理日付のフォーカスインイベント
        /// <summary>
        /// 処理日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProcessingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.ProcessingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 処理日付のフォーカスアウトイベント
        /// <summary>
        /// 処理日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProcessingDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.ProcessingDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.ProcessingDate;
            }
        }
        #endregion

        #region 請求締日のフォーカスインイベント
        /// <summary>
        /// 処理日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClaimTightenDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.ClaimTightenDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 請求締日のフォーカスアウトイベント
        /// <summary>
        /// 処理日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClaimTightenDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.ClaimTightenDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.ClaimTightenDate;
            }
        }
        #endregion

        #region 月次処理日のフォーカスインイベント
        /// <summary>
        /// 月次処理日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMonthlyProcessingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.MonthlyProcessingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 月次処理日のフォーカスアウトイベント
        /// <summary>
        /// 月次処理日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMonthlyProcessingDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.MonthlyProcessingDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.MonthlyProcessingDate;
            }
        }
        #endregion

        #region 年次処理日のフォーカスインイベント
        /// <summary>
        /// 年次処理日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnnualProcessingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.AnnualProcessingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 年次処理日のフォーカスアウトイベント
        /// <summary>
        /// 年次処理日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnnualProcessingDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.AnnualProcessingDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.AnnualProcessingDate;
            }
        }
        #endregion

        #region 終了消費税日付のフォーカスインイベント
        /// <summary>
        /// 処理日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndTaxDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.EndTaxDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 終了消費税日付のフォーカスアウトイベント
        /// <summary>
        /// 処理日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndTaxDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.EndTaxDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.EndTaxDate;
            }
        }
        #endregion

        #region 開始消費税日付のフォーカスインイベント
        /// <summary>
        /// 処理日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStartTaxDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.StartTaxDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 開始消費税日付のフォーカスアウトイベント
        /// <summary>
        /// 処理日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStartTaxDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.StartTaxDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.StartTaxDate;
            }
        }
        #endregion

        #region 仕入締日のフォーカスインイベント
        /// <summary>
        /// 処理日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPurchaseTightenDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.PurchaseTightenDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 仕入締日のフォーカスアウトイベント
        /// <summary>
        /// 処理日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPurchaseTightenDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.PurchaseTightenDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.PurchaseTightenDate;
            }
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtEstimatesNo.MaxLength = 8;                   // 見積番号
            txtOrderNo.MaxLength = 8;                       // 受注番号
            txtOrderingNo.MaxLength = 8;                    // 発注番号
            txtDeliveryNo.MaxLength = 8;                    // 納品書番号
            txtConstructionNo.MaxLength = 8;                // 工事番号
            txtProcessingDateYears.MaxLength = 4;           // 処理日付(年)
            txtProcessingDateMonth.MaxLength = 2;           // 処理日付(月)
            txtProcessingDateDays.MaxLength = 2;            // 処理日付(日)
            txtClaimTightenType.MaxLength = 2;              // 請求締区分
            txtClaimTightenDateYears.MaxLength = 4;         // 請求締日(年)
            txtClaimTightenDateMonth.MaxLength = 2;         // 請求締日(月)
            txtClaimTightenDateDays.MaxLength = 2;          // 請求締日(日)
            txtMonthlyProcessingDateYears.MaxLength = 4;    // 月次処理日付(年)
            txtMonthlyProcessingDateMonth.MaxLength = 2;    // 月次処理日付(月)
            txtMonthlyProcessingDateDays.MaxLength = 2;     // 月次処理日付(日)
            txtAnnualProcessingDateYears.MaxLength = 4;     // 年次処理日付(年)
            txtAnnualProcessingDateMonth.MaxLength = 2;     // 年次処理日付(月)
            txtAnnualProcessingDateDays.MaxLength = 2;      // 年次処理日付(日)
            txtEndTax.MaxLength = 2;                        // 消費税１
            txtEndTaxDateYears.MaxLength = 4;               // 消費税１終了日(年)
            txtEndTaxDateMonth.MaxLength = 2;               // 消費税１終了日(月)
            txtEndTaxDateDays.MaxLength = 2;                // 消費税１終了日(日)
            txtStartTax.MaxLength = 2;                      // 消費税２
            txtStartTaxDateYears.MaxLength = 4;             // 消費税２開始日(年)
            txtStartTaxDateMonth.MaxLength = 2;             // 消費税２開始日(月)
            txtStartTaxDateDays.MaxLength = 2;              // 消費税２開始日(日)
            txtPurchaseTightenType.MaxLength = 2;           // 仕入締区分
            txtPurchaseTightenDateYears.MaxLength = 4;      // 仕入締日(年)
            txtPurchaseTightenDateMonth.MaxLength = 2;      // 仕入締日(月)
            txtPurchaseTightenDateDays.MaxLength = 2;       // 仕入締日(日)
            txtClaimNo.MaxLength = 8;                       // 請求番号
            txtPaymentNo.MaxLength = 8;                     // 支払番号
            txtDepositNo.MaxLength = 8;                     // 入金番号
            txtPurchaseNo.MaxLength = 8;                    // 仕入番号

            // 入力制御イベント設定
            txtEstimatesNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                  // 見積番号           :数字のみ入力可
            txtOrderNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                      // 受注番号           :数字のみ入力可
            txtOrderingNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                   // 発注番号           :数字のみ入力可
            txtDeliveryNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                   // 納品書番号         :数字のみ入力可
            txtConstructionNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);               // 工事番号           :数字のみ入力可
            txtProcessingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);          // 処理日付(年)       :数字のみ入力可
            txtProcessingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);          // 処理日付(月)       :数字のみ入力可
            txtProcessingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 処理日付(日)       :数字のみ入力可
            txtClaimTightenDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 請求締日(年)       :数字のみ入力可
            txtClaimTightenDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 請求締日(月)       :数字のみ入力可
            txtClaimTightenDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 請求締日(日)       :数字のみ入力可
            txtMonthlyProcessingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 月次処理日付(年)   :数字のみ入力可
            txtMonthlyProcessingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 月次処理日付(月)   :数字のみ入力可
            txtMonthlyProcessingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 月次処理日付(日)   :数字のみ入力可
            txtAnnualProcessingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 年次処理日付(年)   :数字のみ入力可
            txtAnnualProcessingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 年次処理日付(月)   :数字のみ入力可
            txtAnnualProcessingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 年次処理日付(日)   :数字のみ入力可
            txtEndTax.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                       // 消費税１           :数字のみ入力可
            txtEndTaxDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);              // 消費税１終了日(年) :数字のみ入力可
            txtEndTaxDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);              // 消費税１終了日(月) :数字のみ入力可
            txtEndTaxDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);               // 消費税１終了日(日) :数字のみ入力可
            txtStartTax.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                     // 消費税２           :数字のみ入力可
            txtStartTaxDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);            // 消費税２開始日(年) :数字のみ入力可
            txtStartTaxDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);            // 消費税２開始日(月) :数字のみ入力可
            txtStartTaxDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 消費税２開始日(日) :数字のみ入力可
            txtPurchaseTightenDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 仕入締日(年)       :数字のみ入力可
            txtPurchaseTightenDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 仕入締日(月)       :数字のみ入力可
            txtPurchaseTightenDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 仕入締日(日)       :数字のみ入力可
            txtClaimNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                      // 請求番号           :数字のみ入力可
            txtPaymentNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                    // 支払番号           :数字のみ入力可
            txtDepositNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                    // 入金番号           :数字のみ入力可
            txtPurchaseNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                   // 仕入番号           :数字のみ入力可
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

            txtEstimatesNo.Text = string.Empty;
            txtOrderNo.Text = string.Empty;
            txtOrderingNo.Text = string.Empty;
            txtDeliveryNo.Text = string.Empty;
            txtConstructionNo.Text = string.Empty;
            txtProcessingDateYears.Text = string.Empty;
            txtProcessingDateMonth.Text = string.Empty;
            txtProcessingDateDays.Text = string.Empty;
            txtClaimTightenType.Text = string.Empty;
            txtClaimTightenDateYears.Text = string.Empty;
            txtClaimTightenDateMonth.Text = string.Empty;
            txtClaimTightenDateDays.Text = string.Empty;
            txtMonthlyProcessingDateYears.Text = string.Empty;
            txtMonthlyProcessingDateMonth.Text = string.Empty;
            txtMonthlyProcessingDateDays.Text = string.Empty;
            txtAnnualProcessingDateYears.Text = string.Empty;
            txtAnnualProcessingDateMonth.Text = string.Empty;
            txtAnnualProcessingDateDays.Text = string.Empty;
            txtEndTax.Text = string.Empty;
            txtEndTaxDateYears.Text = string.Empty;
            txtEndTaxDateMonth.Text = string.Empty;
            txtEndTaxDateDays.Text = string.Empty;
            txtStartTax.Text = string.Empty;
            txtStartTaxDateYears.Text = string.Empty;
            txtStartTaxDateMonth.Text = string.Empty;
            txtStartTaxDateDays.Text = string.Empty;
            txtPurchaseTightenType.Text = string.Empty;
            txtPurchaseTightenDateYears.Text = string.Empty;
            txtPurchaseTightenDateMonth.Text = string.Empty;
            txtPurchaseTightenDateDays.Text = string.Empty;
            txtClaimNo.Text = string.Empty;
            txtPaymentNo.Text = string.Empty;
            txtDepositNo.Text = string.Empty;
            txtPurchaseNo.Text = string.Empty;

            #endregion

            // 管理マスタデータ設定処理実行
            setKanriData();

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
            rdoCorrection.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            #region モード別編集可否設定
            // 訂正
            if (rdoCorrection.Checked)
            {
                txtEstimatesNo.ReadOnly = false;
                txtOrderNo.ReadOnly = false;
                txtOrderingNo.ReadOnly = false;
                txtDeliveryNo.ReadOnly = false;
                txtConstructionNo.ReadOnly = false;
                pnlProcessingDate.Enabled = true;
                txtClaimTightenType.ReadOnly = false;
                pnlClaimTightenDate.Enabled = true;
                pnlMonthlyProcessingDate.Enabled = true;
                pnlAnnualProcessingDate.Enabled = true;
                txtEndTax.ReadOnly = false;
                pnlEndTaxDate.Enabled = true;
                txtStartTax.ReadOnly = false;
                pnlStartTaxDate.Enabled = true;
                txtPurchaseTightenType.ReadOnly = false;
                pnlPurchaseTightenDate.Enabled = true;
                txtClaimNo.ReadOnly = false;
                txtPaymentNo.ReadOnly = false;
                txtDepositNo.ReadOnly = false;
                txtPurchaseNo.ReadOnly = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
            // 参照
            else if (rdoReference.Checked)
            {
                txtEstimatesNo.ReadOnly = true;
                txtOrderNo.ReadOnly = true;
                txtOrderingNo.ReadOnly = true;
                txtDeliveryNo.ReadOnly = true;
                txtConstructionNo.ReadOnly = true;
                pnlProcessingDate.Enabled = false;
                txtClaimTightenType.ReadOnly = true;
                pnlClaimTightenDate.Enabled = false;
                pnlMonthlyProcessingDate.Enabled = false;
                pnlAnnualProcessingDate.Enabled = false;
                txtEndTax.ReadOnly = true;
                pnlEndTaxDate.Enabled = false;
                txtStartTax.ReadOnly = true;
                pnlStartTaxDate.Enabled = false;
                txtPurchaseTightenType.ReadOnly = true;
                pnlPurchaseTightenDate.Enabled = false;
                txtClaimNo.ReadOnly = true;
                txtPaymentNo.ReadOnly = true;
                txtDepositNo.ReadOnly = true;
                txtPurchaseNo.ReadOnly = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
            #endregion
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
            flgSettingEnable = false;
        }
        #endregion

        #region 処理モードラジオボタンクリック処理
        /// <summary>
        /// 処理モードラジオボタンクリック処理
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
                if(rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoCorrection.Checked = (rdoCorrection.Name == radio.Name);
            rdoReference.Checked = (rdoReference.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
        }
        #endregion

        #region 処理モード別変更チェック処理
        private bool checkDataChange()
        {
            bool result = false;
            // 処理モード別の変更チェック処理
            if (rdoCorrection.Checked)
            {
                result = true;
            }
            return result;
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

            if (string.IsNullOrEmpty(txtEstimatesNo.Text))
            {
                errorItem = lblEstimatesNo.Text;
            }
            else if (string.IsNullOrEmpty(txtOrderNo.Text))
            {
                errorItem = lblOrderNo.Text;
            }
            else if (string.IsNullOrEmpty(txtOrderingNo.Text))
            {
                errorItem = lblOrderingNo.Text;
            }
            else if (string.IsNullOrEmpty(txtDeliveryNo.Text))
            {
                errorItem = lblDeliveryNo.Text;
            }
            else if (string.IsNullOrEmpty(txtConstructionNo.Text))
            {
                errorItem = lblConstructionNo.Text;
            }
            else if (string.IsNullOrEmpty(txtProcessingDateYears.Text) &&
                     string.IsNullOrEmpty(txtProcessingDateMonth.Text) &&
                     string.IsNullOrEmpty(txtProcessingDateDays.Text))
            {
                errorItem = lblProcessingDate.Text;
            }
            //else if (string.IsNullOrEmpty(txtClaimTightenType.Text))
            //{
            //    errorItem = lblClaimTightenType.Text;
            //}
            //else if (string.IsNullOrEmpty(txtClaimTightenDateYears.Text) &&
            //         string.IsNullOrEmpty(txtClaimTightenDateMonth.Text) &&
            //         string.IsNullOrEmpty(txtClaimTightenDateDays.Text))
            //{
            //    errorItem = lblClaimTightenDateYears.Text;
            //}
            else if (string.IsNullOrEmpty(txtMonthlyProcessingDateYears.Text) &&
                     string.IsNullOrEmpty(txtMonthlyProcessingDateMonth.Text) &&
                     string.IsNullOrEmpty(txtMonthlyProcessingDateDays.Text))
            {
                errorItem = lblMonthlyProcessingDate.Text;
            }
            else if (string.IsNullOrEmpty(txtEndTax.Text))
            {
                errorItem = lblEndTax.Text;
            }
            else if (string.IsNullOrEmpty(txtEndTaxDateYears.Text) &&
                     string.IsNullOrEmpty(txtEndTaxDateMonth.Text) &&
                     string.IsNullOrEmpty(txtEndTaxDateDays.Text))
            {
                errorItem = lblEndTaxDate.Text;
            }
            else if (string.IsNullOrEmpty(txtStartTax.Text))
            {
                errorItem = lblStartTax.Text;
            }
            else if (string.IsNullOrEmpty(txtStartTaxDateYears.Text) &&
                     string.IsNullOrEmpty(txtStartTaxDateMonth.Text) &&
                     string.IsNullOrEmpty(txtStartTaxDateDays.Text))
            {
                errorItem = lblStartTaxDate.Text;
            }
            //else if (string.IsNullOrEmpty(txtPurchaseTightenType.Text))
            //{
            //    errorItem = lblPurchaseTightenType.Text;
            //}
            //else if (string.IsNullOrEmpty(txtPurchaseTightenDateYears.Text) &&
            //         string.IsNullOrEmpty(txtPurchaseTightenDateMonth.Text) &&
            //         string.IsNullOrEmpty(txtPurchaseTightenDateDays.Text))
            //{
            //    errorItem = lblPurchaseTightenDate.Text;
            //}
            else if (string.IsNullOrEmpty(txtClaimNo.Text))
            {
                errorItem = lblClaimNo.Text;
            }
            else if (string.IsNullOrEmpty(txtPaymentNo.Text))
            {
                errorItem = lblPaymentNo.Text;
            }
            else if (string.IsNullOrEmpty(txtDepositNo.Text))
            {
                errorItem = lblDepositNo.Text;
            }
            else if (string.IsNullOrEmpty(txtPurchaseNo.Text))
            {
                errorItem = lblPurchaseNo.Text;
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

        #region 管理マスタデータ設定処理
        /// <summary>
        /// 管理マスタデータ設定処理
        /// </summary>
        private void setKanriData()
        {
            string command = "SELECT * FROM kanri_master ";
            DataTable dt = masterDataSelectDb.executeNoneLockSelect(command);

            string kanriCode;
            string wkDate;
            string wkYear;
            string wkMonth;
            string wkDay;
            DateTime date;
            foreach (DataRow dRow in dt.Rows)
            {
                kanriCode = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKanriCode]);
                wkYear = string.Empty;
                wkMonth = string.Empty;
                wkDay = string.Empty;
                // 見積番号
                if (Consts.KanriCodes.MitumoriNo.Equals(kanriCode))
                {
                    txtEstimatesNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 受注番号
                else if (Consts.KanriCodes.JuchuNo.Equals(kanriCode))
                {
                    txtOrderNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 発注番号
                else if (Consts.KanriCodes.HachuNo.Equals(kanriCode))
                {
                    txtOrderingNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 売上番号
                else if (Consts.KanriCodes.UriageNo.Equals(kanriCode))
                {
                    txtDeliveryNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 工事番号
                else if (Consts.KanriCodes.KenmeiNo.Equals(kanriCode))
                {
                    txtConstructionNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 処理日付
                else if (Consts.KanriCodes.SyoriDate.Equals(kanriCode))
                {
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku2]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpProcessingDate.Value = date.AddDays(1);
                        dtpProcessingDate.Value = date;
                    }
                }
                // 請求締日
                else if (Consts.KanriCodes.SeikyuShimeDate.Equals(kanriCode))
                {
                    txtClaimTightenType.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku2]);
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku4]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpClaimTightenDate.Value = date.AddDays(1);
                        dtpClaimTightenDate.Value = date;
                    }
                }
                // 月次処理日
                else if (Consts.KanriCodes.GetujiSyoriDate.Equals(kanriCode))
                {
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku2]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpMonthlyProcessingDate.Value = date.AddDays(1);
                        dtpMonthlyProcessingDate.Value = date;
                    }
                }
                // 年次処理日
                else if (Consts.KanriCodes.NenjiSyoriDate.Equals(kanriCode))
                {
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku2]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpAnnualProcessingDate.Value = date.AddDays(1);
                        dtpAnnualProcessingDate.Value = date;
                    }
                }
                // 消費税管理
                else if (Consts.KanriCodes.ShouhizeiKanri.Equals(kanriCode))
                {
                    txtEndTax.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku2]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpEndTaxDate.Value = date.AddDays(1);
                        dtpEndTaxDate.Value = date;
                    }
                    txtStartTax.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku3]);
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku4]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpStartTaxDate.Value = date.AddDays(1);
                        dtpStartTaxDate.Value = date;
                    }
                }
                // 仕入締日
                else if (Consts.KanriCodes.ShireShimeDate.Equals(kanriCode))
                {
                    txtPurchaseTightenType.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku2]);
                    wkDate = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku4]);
                    if (!string.IsNullOrEmpty(wkDate))
                    {
                        wkYear = wkDate.Substring(0, 4);
                        wkMonth = wkDate.Substring(4, 2);
                        wkDay = wkDate.Substring(6, 2);
                    }
                    if (DateTime.TryParse(wkYear + "/" + wkMonth + "/" + wkDay, out date))
                    {
                        dtpPurchaseTightenDate.Value = date.AddDays(1);
                        dtpPurchaseTightenDate.Value = date;
                    }
                }
                // 請求番号
                else if (Consts.KanriCodes.SeikyuNo.Equals(kanriCode))
                {
                    txtClaimNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 支払番号
                else if (Consts.KanriCodes.ShiharaiNo.Equals(kanriCode))
                {
                    txtPaymentNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 入金番号
                else if (Consts.KanriCodes.NyukinNo.Equals(kanriCode))
                {
                    txtDepositNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
                // 仕入番号
                else if (Consts.KanriCodes.ShireNo.Equals(kanriCode))
                {
                    txtPurchaseNo.Text = Convert.ToString(dRow[DBFileLayout.KanriMasterFile.dcKoumoku1]);
                }
            }
        }
        #endregion

        #region 管理マスタの更新SQL生成処理
        /// <summary>
        /// 管理マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createRegistSql(DateTime registerDate)
        {
            List<string> commands = new List<string>();
            string command = string.Empty;

            #region 見積番号の更新SQL生成
            string estimatesNo = txtEstimatesNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + estimatesNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.MitumoriNo + "' ";
            commands.Add(command);
            #endregion

            #region 受注番号の更新SQL生成
            string orderNo = txtOrderNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + orderNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.JuchuNo + "' ";
            commands.Add(command);
            #endregion

            #region 発注番号の更新SQL生成
            string orderingNo = txtOrderingNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + orderingNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.HachuNo + "' ";
            commands.Add(command);
            #endregion

            #region 納品書番号の更新SQL生成
            string deliveryNo = txtDeliveryNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + deliveryNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.UriageNo + "' ";
            commands.Add(command);
            #endregion

            #region 件名番号の更新SQL生成
            string constructionNo = txtConstructionNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + constructionNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.KenmeiNo + "' ";
            commands.Add(command);
            #endregion

            #region 処理日付の更新SQL生成
            string processingDateYears = txtProcessingDateYears.Text;
            string processingDateMonth = txtProcessingDateMonth.Text;
            string processingDateDays = txtProcessingDateDays.Text;
            if (processingDateMonth.Length == 1) processingDateMonth = "0" + processingDateMonth;
            if (processingDateDays.Length == 1) processingDateDays = "0" + processingDateDays;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku2 = '" + processingDateYears + processingDateMonth + processingDateDays + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.SyoriDate + "' ";
            commands.Add(command);
            #endregion

            #region 請求締日の更新SQL生成
            string claimTightenType = txtClaimTightenType.Text;
            string claimTightenDateYears = txtClaimTightenDateYears.Text;
            string claimTightenDateMonth = txtClaimTightenDateMonth.Text;
            string claimTightenDateDays = txtClaimTightenDateDays.Text;
            if (claimTightenDateMonth.Length == 1) claimTightenDateMonth = "0" + claimTightenDateMonth;
            if (claimTightenDateDays.Length == 1) claimTightenDateDays = "0" + claimTightenDateDays;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku2 = '" + claimTightenType + "' ";
            command += ", koumoku4 = '" + claimTightenDateYears + claimTightenDateMonth + claimTightenDateDays + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.SeikyuShimeDate + "' ";
            commands.Add(command);
            #endregion

            #region 月次処理日の更新SQL生成
            string monthlyProcessingDateYears = txtMonthlyProcessingDateYears.Text;
            string monthlyProcessingDateMonth = txtMonthlyProcessingDateMonth.Text;
            string monthlyProcessingDateDays = txtMonthlyProcessingDateDays.Text;
            if (monthlyProcessingDateMonth.Length == 1) monthlyProcessingDateMonth = "0" + monthlyProcessingDateMonth;
            if (monthlyProcessingDateDays.Length == 1) monthlyProcessingDateDays = "0" + monthlyProcessingDateDays;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku2 = '" + monthlyProcessingDateYears + monthlyProcessingDateMonth + monthlyProcessingDateDays + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.GetujiSyoriDate + "' ";
            commands.Add(command);
            #endregion

            #region 年次処理日の更新SQL生成
            string annualProcessingDateYears = txtAnnualProcessingDateYears.Text;
            string annualProcessingDateMonth = txtAnnualProcessingDateMonth.Text;
            string annualProcessingDateDays = txtAnnualProcessingDateDays.Text;
            if (annualProcessingDateMonth.Length == 1) annualProcessingDateMonth = "0" + annualProcessingDateMonth;
            if (annualProcessingDateDays.Length == 1) annualProcessingDateDays = "0" + annualProcessingDateDays;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku2 = '" + annualProcessingDateYears + annualProcessingDateMonth + annualProcessingDateDays + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.NenjiSyoriDate + "' ";
            commands.Add(command);
            #endregion

            #region 消費税管理の更新SQL生成
            string endTax = txtEndTax.Text;
            string endTaxDateYears = txtEndTaxDateYears.Text;
            string endTaxDateMonth = txtEndTaxDateMonth.Text;
            string endTaxDateDays = txtEndTaxDateDays.Text;
            if (endTaxDateMonth.Length == 1) endTaxDateMonth = "0" + endTaxDateMonth;
            if (endTaxDateDays.Length == 1) endTaxDateDays = "0" + endTaxDateDays;
            string startTax = txtStartTax.Text;
            string startTaxDateYears = txtStartTaxDateYears.Text;
            string startTaxDateMonth = txtStartTaxDateMonth.Text;
            string startTaxDateDays = txtStartTaxDateDays.Text;
            if (startTaxDateMonth.Length == 1) startTaxDateMonth = "0" + startTaxDateMonth;
            if (startTaxDateDays.Length == 1) startTaxDateDays = "0" + startTaxDateDays;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + endTax + "' ";
            command += ", koumoku2 = '" + endTaxDateYears + endTaxDateMonth + endTaxDateDays + "' ";
            command += ", koumoku3 = '" + startTax + "' ";
            command += ", koumoku4 = '" + startTaxDateYears + startTaxDateMonth + startTaxDateDays + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.ShouhizeiKanri + "' ";
            commands.Add(command);
            #endregion

            #region 仕入締日の更新SQL生成
            string purchaseTightenType = txtPurchaseTightenType.Text;
            string purchaseTightenDateYears = txtPurchaseTightenDateYears.Text;
            string purchaseTightenDateMonth = txtPurchaseTightenDateMonth.Text;
            string purchaseTightenDateDays = txtPurchaseTightenDateDays.Text;
            if (purchaseTightenDateMonth.Length == 1) purchaseTightenDateMonth = "0" + purchaseTightenDateMonth;
            if (purchaseTightenDateDays.Length == 1) purchaseTightenDateDays = "0" + purchaseTightenDateDays;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku2 = '" + purchaseTightenType + "' ";
            command += ", koumoku4 = '" + purchaseTightenDateYears + purchaseTightenDateMonth + purchaseTightenDateDays + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.ShireShimeDate + "' ";
            commands.Add(command);
            #endregion

            #region 請求番号の更新SQL生成
            string claimNo = txtClaimNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + claimNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.SeikyuNo + "' ";
            commands.Add(command);
            #endregion

            #region 支払番号の更新SQL生成
            string paymentNo = txtPaymentNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + paymentNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.ShiharaiNo + "' ";
            commands.Add(command);
            #endregion

            #region 入金番号の更新SQL生成
            string depositNo = txtDepositNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + depositNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.NyukinNo + "' ";
            commands.Add(command);
            #endregion

            #region 仕入番号の更新SQL生成
            string purchaseNo = txtPurchaseNo.Text;
            command = string.Empty;
            command += "UPDATE kanri_master SET ";
            command += "  koumoku1 = '" + purchaseNo + "' ";
            command += ", kousinNichizi = '" + registerDate + "' ";
            command += ", kanriKubun = '' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.ShireNo + "' ";
            commands.Add(command);
            #endregion

            return commands;
        }
        #endregion
    }
}
