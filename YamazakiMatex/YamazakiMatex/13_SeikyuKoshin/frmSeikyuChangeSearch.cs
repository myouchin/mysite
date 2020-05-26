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
    /// 請求日変更画面
    /// </summary>
    public partial class frmSeikyuChangeSearch : ChildBaseForm
    {
        #region 変数宣言
        private bool flgBtnSearchSelect = false;
        private string dummyCode = "Dummy";
        private DBTokuisakiMaster tokuisakiMaster;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , BillingDateYearMonth = 1
          , BillingDateDay = 2
          , DocumentDateFrom = 3
          , DocumentDateTo = 4
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        /// <summary>
        /// 売上データ検索条件クラス
        /// </summary>
        public class uriageSearchCriteria
        {
            #region 変数宣言
            /// <summary>
            /// 請求日(年)
            /// </summary>
            private string billingDateYears = string.Empty;
            /// <summary>
            /// 請求日(月)
            /// </summary>
            private string billingDateMonth = string.Empty;
            /// <summary>
            /// 請求日(日)
            /// </summary>
            private string billingDateDays = string.Empty;
            /// <summary>
            /// 伝票日付(FROM)(年)
            /// </summary>
            private string documentDateFromYears = string.Empty;
            /// <summary>
            /// 伝票日付(FROM)(月)
            /// </summary>
            private string documentDateFromMonth = string.Empty;
            /// <summary>
            /// 伝票日付(FROM)(日)
            /// </summary>
            private string documentDateFromDays = string.Empty;
            /// <summary>
            /// 伝票日付(TO)(年)
            /// </summary>
            private string documentDateToYears = string.Empty;
            /// <summary>
            /// 伝票日付(TO)(月)
            /// </summary>
            private string documentDateToMonth = string.Empty;
            /// <summary>
            /// 伝票日付(TO)(日)
            /// </summary>
            private string documentDateToDays = string.Empty;
            /// <summary>
            /// 伝票No
            /// </summary>
            private string documentNo = string.Empty;
            /// <summary>
            /// 受注No
            /// </summary>
            private string ordersNo = string.Empty;
            /// <summary>
            /// 得意先コード
            /// </summary>
            private string customerCode = string.Empty;
            /// <summary>
            /// 得意先名
            /// </summary>
            private string customerName = string.Empty;
            /// <summary>
            /// 得意先カナ名
            /// </summary>
            private string customerKanaName = string.Empty;
            /// <summary>
            /// 事業所コード
            /// </summary>
            private string officesCode = string.Empty;
            /// <summary>
            /// 事業所名
            /// </summary>
            private string officesName = string.Empty;
            #endregion

            #region 取得・設定
            /// <summary>
            /// 請求日(年)の取得・設定
            /// </summary>
            public string BillingDateYears
            {
                get { return billingDateYears; }
                set { billingDateYears = value; }
            }
            /// <summary>
            /// 請求日(月)の取得・設定
            /// </summary>
            public string BillingDateMonth
            {
                get { return billingDateMonth; }
                set { billingDateMonth = value; }
            }
            /// <summary>
            /// 請求日(日)の取得・設定
            /// </summary>
            public string BillingDateDays
            {
                get { return billingDateDays; }
                set { billingDateDays = value; }
            }
            /// <summary>
            /// 伝票日付(FROM)(年)の取得・設定
            /// </summary>
            public string DocumentDateFromYears
            {
                get { return documentDateFromYears; }
                set { documentDateFromYears = value; }
            }
            /// <summary>
            /// 伝票日付(FROM)(月)の取得・設定
            /// </summary>
            public string DocumentDateFromMonth
            {
                get { return documentDateFromMonth; }
                set { documentDateFromMonth = value; }
            }
            /// <summary>
            /// 伝票日付(FROM)(日)の取得・設定
            /// </summary>
            public string DocumentDateFromDays
            {
                get { return documentDateFromDays; }
                set { documentDateFromDays = value; }
            }
            /// <summary>
            /// 伝票日付(TO)(年)の取得・設定
            /// </summary>
            public string DocumentDateToYears
            {
                get { return documentDateToYears; }
                set { documentDateToYears = value; }
            }
            /// <summary>
            /// 伝票日付(TO)(月)の取得・設定
            /// </summary>
            public string DocumentDateToMonth
            {
                get { return documentDateToMonth; }
                set { documentDateToMonth = value; }
            }
            /// <summary>
            /// 伝票日付(TO)(日)の取得・設定
            /// </summary>
            public string DocumentDateToDays
            {
                get { return documentDateToDays; }
                set { documentDateToDays = value; }
            }
            /// <summary>
            /// 伝票Noの取得・設定
            /// </summary>
            public string DocumentNo
            {
                get { return documentNo; }
                set { documentNo = value; }
            }
            /// <summary>
            /// 受注Noの取得・設定
            /// </summary>
            public string OrdersNo
            {
                get { return ordersNo; }
                set { ordersNo = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string CustomerCode
            {
                get { return customerCode; }
                set { customerCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string CustomerName
            {
                get { return customerName; }
                set { customerName = value; }
            }
            /// <summary>
            /// 得意先カナ名の取得・設定
            /// </summary>
            public string CustomerKanaName
            {
                get { return customerKanaName; }
                set { customerKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string OfficesCode
            {
                get { return officesCode; }
                set { officesCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string OfficesName
            {
                get { return officesName; }
                set { officesName = value; }
            }
            #endregion

            #region イベント

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public uriageSearchCriteria()
            {
            }
            #endregion

            #endregion
        }

        private uriageSearchCriteria searchCriteria;
        public uriageSearchCriteria SearchCriteria
        {
            get { return searchCriteria; }
            set { searchCriteria = value; }
        }
        private string listDispMessage = string.Empty;
        public string ListDispMessage
        {
            get { return listDispMessage; }
            set { listDispMessage = value; }
        }
        sfrmNouhinsyoSearch sNouhinsyo;
        sfrmJuchuSearch sJuchu;
        sfrmTokuisakiSearch fTokuisaki;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSeikyuChangeSearch()
        {
            InitializeComponent();
            tokuisakiMaster = new DBTokuisakiMaster();
            commonLogic = new CommonLogic();
            sNouhinsyo = new sfrmNouhinsyoSearch(false, CheckMessageType.None);
            sJuchu = new sfrmJuchuSearch(false, CheckMessageType.None);
            fTokuisaki = new sfrmTokuisakiSearch(false);
            searchCriteria = new uriageSearchCriteria();

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtDocumentNo;
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
            CheckMessageType messageType = CheckMessageType.None;

            // 伝票Noを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtDocumentNo.Name))
            {
                // 納品書検索画面を起動
                sNouhinsyo.MType = messageType;
                sNouhinsyo.ShowDialog();

                if (sNouhinsyo.DialogResult == DialogResult.OK)
                {
                    // 納品書Noの設定
                    txtDocumentNo.Text = sNouhinsyo.SelectedNouhinsyoInfos[0].DocumentNo;
                }
                flgSetFocus = true;
            }
            // 受注Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtOrdersNo.Name))
            {
                // 受注検索画面を起動
                sJuchu.MType = messageType;
                sJuchu.ShowDialog();

                if (sJuchu.DialogResult == DialogResult.OK)
                {
                    // 受注Noの設定
                    txtOrdersNo.Text = sJuchu.SelectedJuchuInfos[0].OrdersNo;
                }
                flgSetFocus = true;
            }
            // 得意先ｺｰﾄﾞを編集中の場合
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

        #region 一覧表示ボタン押下イベント
        /// <summary>
        /// 一覧表示ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnListDisp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ListDispMessage) && queryYesNo(ListDispMessage) == DialogResult.No) return;
            setSearchCriteria();
            DialogResult = DialogResult.OK;
            closedForm();
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
            if (!checkDataChange()) return;
            if (queryYesNo(string.Format(Messages.M0033, "処理を継続してよろしいですか？")) == DialogResult.No) return;
            initDisplay(new uriageSearchCriteria());
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
            if (checkDataChange() && queryYesNo(string.Format(Messages.M0033, "処理を継続してよろしいですか？")) == DialogResult.No) return;
            closedForm();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSeikyuChangeSearch_Load(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            // 画面項目の初期化処理
            initDisplay(searchCriteria);
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
                    // 一覧表示処理を実行
                    btnListDisp_Click(null, null);
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

        #region 請求年月のフォーカスインイベント
        /// <summary>
        /// 請求年月のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billingDateYearMonth_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.BillingDateYearMonth)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 請求年月のフォーカスアウトイベント
        /// <summary>
        /// 請求年月のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billingDateYearMonth_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.BillingDateYearMonth;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.BillingDateYearMonth;
            }
        }
        #endregion

        #region 請求日のフォーカスインイベント
        /// <summary>
        /// 請求日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billingDateDay_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.BillingDateDay)
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
        private void billingDateDay_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.BillingDateDay;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.BillingDateDay;
            }
        }
        #endregion

        #region 伝票日付(FROM)のフォーカスインイベント
        /// <summary>
        /// 伝票日付(FROM)のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DocumentDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 伝票日付(FROM)のフォーカスアウトイベント
        /// <summary>
        /// 伝票日付(FROM)のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DocumentDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DocumentDateFrom;
            }
        }
        #endregion

        #region 伝票日付(TO)のフォーカスインイベント
        /// <summary>
        /// 伝票日付(TO)のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DocumentDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 伝票日付(TO)のフォーカスアウトイベント
        /// <summary>
        /// 伝票日付(TO)のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DocumentDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DocumentDateTo;
            }
        }
        #endregion

        #region 伝票Noのフォーカスアウトイベント
        /// <summary>
        /// 伝票Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                string chkString = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                if (!checkExistNouhinsyoData(chkString))
                {
                    errorOK(string.Format(Messages.M0029, lblDocumentNo.Text));
                    text.Focus();
                }
                else
                {
                    text.Text = chkString;
                }
            }
        }
        #endregion

        #region 受注Noのフォーカスアウトイベント
        /// <summary>
        /// 受注Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text) && !checkExistJuchuData(text.Text))
            {
                errorOK(string.Format(Messages.M0029, lblOrdersNo.Text));
                text.Focus();
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
                setOfficesCmb(dummyCode, string.Empty);
            }
            setTokuisakiEnabled();
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
                    case LastInputDateType.BillingDateYearMonth:
                        y = txtBillingDateYears.Text;
                        m = txtBillingDateMonth.Text;
                        if (string.IsNullOrEmpty(y) && string.IsNullOrEmpty(m))
                        {
                            d = string.Empty;
                        }
                        else if (string.IsNullOrEmpty(txtBillingDateDays.Text))
                        {
                            d = decimal.One.ToString();
                        }
                        else
                        {
                            d = txtBillingDateDays.Text;
                        }
                        break;
                    case LastInputDateType.BillingDateDay:
                        d = txtBillingDateDays.Text;
                        if (string.IsNullOrEmpty(d))
                        {
                            y = string.Empty;
                        }
                        else if (string.IsNullOrEmpty(txtBillingDateYears.Text))
                        {
                            y = DateTime.Now.Year.ToString();
                        }
                        else
                        {
                            y = txtBillingDateYears.Text;
                        }
                        if (string.IsNullOrEmpty(d))
                        {
                            m = string.Empty;
                        }
                        else if (string.IsNullOrEmpty(txtBillingDateMonth.Text))
                        {
                            m = DateTime.Now.Month.ToString();
                        }
                        else
                        {
                            m = txtBillingDateMonth.Text;
                        }
                        break;
                    case LastInputDateType.DocumentDateFrom:
                        y = txtDocumentDateFromYears.Text;
                        m = txtDocumentDateFromMonth.Text;
                        d = txtDocumentDateFromDays.Text;
                        inputObj = dtpDocumentDateFrom;
                        break;
                    case LastInputDateType.DocumentDateTo:
                        y = txtDocumentDateToYears.Text;
                        m = txtDocumentDateToMonth.Text;
                        d = txtDocumentDateToDays.Text;
                        inputObj = dtpDocumentDateTo;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.BillingDateYearMonth.Equals(lastInputDateType))
                    {
                        txtBillingDateYears.Focus();
                    }
                    else if (LastInputDateType.BillingDateDay.Equals(lastInputDateType))
                    {
                        txtBillingDateDays.Focus();
                    }
                    else if (LastInputDateType.DocumentDateFrom.Equals(lastInputDateType))
                    {
                        txtDocumentDateFromYears.Focus();
                    }
                    else if (LastInputDateType.DocumentDateTo.Equals(lastInputDateType))
                    {
                        txtDocumentDateToYears.Focus();
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

        #region 開始ボタンオンフォーカスイベント
        /// <summary>
        /// 開始ボタンオンフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            flgBtnSearchSelect = true;
        }
        #endregion

        #region 開始ボタンアウトフォーカスイベント
        /// <summary>
        /// 開始ボタンアウトフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            flgBtnSearchSelect = false;
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

            // 請求年月の場合
            if (c.Name.Equals(txtBillingDateYears.Name) ||
                c.Name.Equals(txtBillingDateMonth.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.billingDateYearMonth_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.billingDateYearMonth_Leave);
            }
            // 請求日の場合
            if (c.Name.Equals(txtBillingDateDays.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.billingDateDay_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.billingDateDay_Leave);
            }
            // 伝票日付(FROM)の場合
            else if (c.Name.Equals(txtDocumentDateFromYears.Name) ||
                     c.Name.Equals(txtDocumentDateFromMonth.Name) ||
                     c.Name.Equals(txtDocumentDateFromDays.Name) ||
                     c.Name.Equals(dtpDocumentDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.documentDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.documentDateFrom_Leave);
            }
            // 伝票日付(TO)の場合
            else if (c.Name.Equals(txtDocumentDateToYears.Name) ||
                     c.Name.Equals(txtDocumentDateToMonth.Name) ||
                     c.Name.Equals(txtDocumentDateToDays.Name) ||
                     c.Name.Equals(dtpDocumentDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.documentDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.documentDateTo_Leave);
            }
            // 伝票Noの場合
            else if (c.Name.Equals(txtDocumentNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            }
            // 受注Noの場合
            else if (c.Name.Equals(txtOrdersNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOrderNo_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
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
                }
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
            }
            else
            {
                txtCustomerCode.Text = tokuisakiCode;
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
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
            // 伝票Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDocumentNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 受注Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtOrdersNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtBillingDateYears.MaxLength = 4;          // 請求日(年)
            txtBillingDateMonth.MaxLength = 2;          // 請求日(月)
            txtBillingDateDays.MaxLength = 2;           // 請求日(日)
            txtDocumentDateFromYears.MaxLength = 4;     // 伝票日付(FROM)(年)
            txtDocumentDateFromMonth.MaxLength = 2;     // 伝票日付(FROM)(月)
            txtDocumentDateFromDays.MaxLength = 2;      // 伝票日付(FROM)(日)
            txtDocumentDateToYears.MaxLength = 4;       // 伝票日付(TO)(年)
            txtDocumentDateToMonth.MaxLength = 2;       // 伝票日付(TO)(月)
            txtDocumentDateToDays.MaxLength = 2;        // 伝票日付(TO)(日)
            txtDocumentNo.MaxLength = 8;                // 伝票No
            txtOrdersNo.MaxLength = 15;                 // 受注No
            txtCustomerCode.MaxLength = 5;              // 得意先コード
            txtCustomerName.MaxLength = 40;             // 得意先名
            txtCustomerKanaName.MaxLength = 80;         // 得意先カナ名

            // 入力制御イベント設定
            txtBillingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 請求日(年)  :数字のみ入力可
            txtBillingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 請求日(月)  :数字のみ入力可
            txtBillingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);          // 請求日(日)  :数字のみ入力可
            txtDocumentDateFromYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 請求日(年)  :数字のみ入力可
            txtDocumentDateFromMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 請求日(月)  :数字のみ入力可
            txtDocumentDateFromDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 請求日(日)  :数字のみ入力可
            txtDocumentDateToYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 請求日(年)  :数字のみ入力可
            txtDocumentDateToMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 請求日(月)  :数字のみ入力可
            txtDocumentDateToDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 請求日(日)  :数字のみ入力可
            txtDocumentNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);               // 伝票ＮＯ    :数字のみ入力可
            txtOrdersNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);                 // 受注ＮＯ    :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 得意先ｺｰﾄﾞ  :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);          // 得意先カナ名:全角カナのみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 得意先情報の編集制御設定処理
        /// <summary>
        /// 得意先情報の編集制御設定処理
        /// </summary>
        private void setTokuisakiEnabled()
        {
            if (Consts.OthersCustomerCode.Equals(txtCustomerCode.Text))
            {
                txtCustomerName.Enabled = true;
                txtCustomerKanaName.Enabled = true;
            }
            else
            {
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
            }
        }
        #endregion

        #region 検索条件設定処理
        /// <summary>
        /// 検索条件設定処理
        /// </summary>
        /// <returns></returns>
        public void setSearchCriteria()
        {
            // 請求日(年)
            searchCriteria.BillingDateYears = txtBillingDateYears.Text;
            // 請求日(月)
            searchCriteria.BillingDateMonth = txtBillingDateMonth.Text;
            // 請求日(日)
            searchCriteria.BillingDateDays = txtBillingDateDays.Text;
            // 伝票日付(FROM)(年)
            searchCriteria.DocumentDateFromYears = txtDocumentDateFromYears.Text;
            // 伝票日付(FROM)(月)
            searchCriteria.DocumentDateFromMonth = txtDocumentDateFromMonth.Text;
            // 伝票日付(FROM)(日)
            searchCriteria.DocumentDateFromDays = txtDocumentDateFromDays.Text;
            // 伝票日付(TO)(年)
            searchCriteria.DocumentDateToYears = txtDocumentDateToYears.Text;
            // 伝票日付(TO)(月)
            searchCriteria.DocumentDateToMonth = txtDocumentDateToMonth.Text;
            // 伝票日付(TO)(日)
            searchCriteria.DocumentDateToDays = txtDocumentDateToDays.Text;
            // 伝票No
            searchCriteria.DocumentNo = txtDocumentNo.Text;
            // 受注No
            searchCriteria.OrdersNo = txtOrdersNo.Text;
            // 得意先コード
            searchCriteria.CustomerCode = txtCustomerCode.Text;
            // 得意先名
            searchCriteria.CustomerName = txtCustomerName.Text;
            // 得意先カナ名
            searchCriteria.CustomerKanaName = txtCustomerKanaName.Text;
            // 事業所コード
            searchCriteria.OfficesCode = Convert.ToString(cmbOffices.SelectedValue);
            // 事業所名
            searchCriteria.OfficesName = cmbOffices.Text;
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

        #region 画面項目の初期化処理
        /// <summary>
        /// 画面項目の初期化処理
        /// </summary>
        private void initDisplay(uriageSearchCriteria initCriteria)
        {
            // 請求日(年)
            txtBillingDateYears.Text = initCriteria.BillingDateYears;
            // 請求日(月)
            txtBillingDateMonth.Text = initCriteria.BillingDateMonth;
            // 請求日(日)
            txtBillingDateDays.Text = initCriteria.BillingDateDays;
            // 伝票日付(FROM)(年)
            txtDocumentDateFromYears.Text = initCriteria.DocumentDateFromYears;
            // 伝票日付(FROM)(月)
            txtDocumentDateFromMonth.Text = initCriteria.DocumentDateFromMonth;
            // 伝票日付(FROM)(日)
            txtDocumentDateFromDays.Text = initCriteria.DocumentDateFromDays;
            // 伝票日付(TO)(年)
            txtDocumentDateToYears.Text = initCriteria.DocumentDateToYears;
            // 伝票日付(TO)(月)
            txtDocumentDateToMonth.Text = initCriteria.DocumentDateToMonth;
            // 伝票日付(TO)(日)
            txtDocumentDateToDays.Text = initCriteria.DocumentDateToDays;
            // 伝票No
            txtDocumentNo.Text = initCriteria.DocumentNo;
            // 受注No
            txtOrdersNo.Text = initCriteria.OrdersNo;
            // 得意先コード
            txtCustomerCode.Text = initCriteria.CustomerCode;
            // 得意先名
            txtCustomerName.Text = initCriteria.CustomerName;
            // 得意先カナ名
            txtCustomerKanaName.Text = initCriteria.CustomerKanaName;
            // 事業所コンボボックス設定
            setOfficesCmb(string.IsNullOrEmpty(txtCustomerCode.Text) ? dummyCode : txtCustomerCode.Text, string.Empty);
            var jigyousyo = ((DataTable)cmbOffices.DataSource).AsEnumerable().Where(p => p.Field<string>(commonLogic.StrCmbKey).Equals(initCriteria.OfficesCode));
            if (jigyousyo.Count() > 0)
            {
                cmbOffices.SelectedValue = initCriteria.OfficesCode;
            }
            else
            {
                cmbOffices.Text = initCriteria.OfficesName;
            }

            // 得意先情報の入力制御設定処理実行
            setTokuisakiEnabled();

        }
        #endregion

        #region データ存在チェック処理
        /// <summary>
        /// データ存在チェック処理
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private bool checkExistData(string sql)
        {
            bool ret = false;

            DBCommon commonDb = new DBCommon();

            DataTable dt = commonDb.executeSelect(sql, false);

            if (dt != null && dt.Rows.Count > 0) ret = true;

            return ret;
        }
        #endregion

        #region 納品書データ存在チェック処理
        /// <summary>
        /// 納品書データ存在チェック処理
        /// </summary>
        /// <param name="documentNo"></param>
        /// <returns></returns>
        private bool checkExistNouhinsyoData(string documentNo)
        {
            string sql = string.Empty;
            sql += "SELECT 1 FROM uriage_header ";
            sql += "WHERE kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "' ";
            sql += "AND denpyoNo = '" + documentNo + "' ";
            return checkExistData(sql);
        }
        #endregion

        #region 受注データ存在チェック処理
        /// <summary>
        /// 受注データ存在チェック処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <returns></returns>
        private bool checkExistJuchuData(string juchuNo)
        {
            string sql = string.Empty;
            sql += "SELECT 1 FROM juchu_header ";
            sql += "WHERE kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "' ";
            sql += "AND CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = '" + juchuNo + "' ";
            return checkExistData(sql);
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

            if (!txtBillingDateYears.Text.Equals(SearchCriteria.BillingDateYears) ||
                !txtBillingDateMonth.Text.Equals(SearchCriteria.BillingDateMonth) ||
                !txtBillingDateDays.Text.Equals(SearchCriteria.BillingDateDays) ||
                !txtDocumentDateFromYears.Text.Equals(SearchCriteria.DocumentDateFromYears) ||
                !txtDocumentDateFromMonth.Text.Equals(SearchCriteria.DocumentDateFromMonth) ||
                !txtDocumentDateFromDays.Text.Equals(SearchCriteria.DocumentDateFromDays) ||
                !txtDocumentDateToYears.Text.Equals(SearchCriteria.DocumentDateToYears) ||
                !txtDocumentDateToMonth.Text.Equals(SearchCriteria.DocumentDateToMonth) ||
                !txtDocumentDateToDays.Text.Equals(SearchCriteria.DocumentDateToDays) ||
                !txtDocumentNo.Text.Equals(SearchCriteria.DocumentNo) ||
                !txtOrdersNo.Text.Equals(SearchCriteria.OrdersNo) ||
                !txtCustomerCode.Text.Equals(SearchCriteria.CustomerCode) ||
                !txtCustomerName.Text.Equals(SearchCriteria.CustomerName) ||
                !txtCustomerKanaName.Text.Equals(SearchCriteria.CustomerKanaName) ||
                !Convert.ToString(cmbOffices.SelectedValue).Equals(SearchCriteria.OfficesCode) ||
                !cmbOffices.Text.Equals(SearchCriteria.OfficesName))
            {
                result = true;
            }

            return result;
        }
        #endregion

        #endregion
    }
}
