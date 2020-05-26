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
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;
using SubForm;

namespace PrintInstructions
{
    /// <summary>
    /// 請求書出力画面
    /// </summary>
    public partial class frmSeikyusyo : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private enum LastInputDateType
        {
            None = 0
          , TightenDate = 1
          , BillingDate = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private CommonLogic commonLogic;
        private string dummyCode = "Dummy";
        private string cmbAllValue = "ALL";
        private string cmbAllText = "全て";
        public enum PrintRowType
        {
            /// <summary>
            /// 前回請求額
            /// </summary>
            ZenkaiSeikyu = 1
            /// <summary>
            /// 明細
            /// </summary>
            , Meisai = 2
            /// <summary>
            /// 小計
            /// </summary>
            , Shoukei = 3
            /// <summary>
            /// 消費税
            /// </summary>
            , Shouhizei = 4
            /// <summary>
            /// 入金額
            /// </summary>
            , Nyukin = 5
            /// <summary>
            /// 合計
            /// </summary>
            , Goukei = 6
        }
        private DBMeisyoMaster meisyoMaster;
        sfrmTokuisakiSearch fTokuisaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmSeikyusyo()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            activeControlInfo = new ActiveControlInfo();
            txtTightenDateYears.Text = string.Empty;
            txtTightenDateMonth.Text = string.Empty;
            txtBillingDateYears.Text = string.Empty;
            txtBillingDateMonth.Text = string.Empty;
            txtBillingDateDays.Text = string.Empty;
            pnlBillingDate.Enabled = false;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            meisyoMaster = new DBMeisyoMaster();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
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

        #region プレビューボタン押下イベント
        /// <summary>
        /// プレビューボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
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
            executePrint(PrintType.OutPut);
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

        #region 請求年月日フォーカスインイベント
        /// <summary>
        /// 請求年月日フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBillingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.BillingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 請求年月日フォーカスアウトイベント
        /// <summary>
        /// 請求年月日フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBillingDate_Leave(object sender, EventArgs e)
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

                switch (lastInputDateType)
                {
                    case LastInputDateType.TightenDate:
                        y = txtTightenDateYears.Text;
                        m = txtTightenDateMonth.Text;
                        d = "01";
                        break;
                    case LastInputDateType.BillingDate:
                        y = txtBillingDateYears.Text;
                        m = txtBillingDateMonth.Text;
                        d = txtBillingDateDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
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
                    return;
                }
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
        }
        #endregion

        #region 得意先コードのフォーカスアウトイベント
        /// <summary>
        /// 得意先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCd_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 得意先情報の設定
                if (setTokuisakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), string.Empty, false))
                {
                    text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                }
                pnlBillingDate.Enabled = true;
            }
            else
            {
                txtCustomerName.Text = string.Empty;
                // 事業所コンボボックス設定
                setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
                pnlBillingDate.Enabled = false;
                txtBillingDateYears.Text = string.Empty;
                txtBillingDateMonth.Text = string.Empty;
                txtBillingDateDays.Text = string.Empty;
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
                    break;
                // F1キーが押下された場合
                case Keys.F1:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    // 検索ボタン押下時の処理を実行
                    btnSearch_Click(null, null);
                    break;
                // F3キーが押下された場合
                case Keys.F3:
                    // TODO:プレビュー処理を実行
                    btnPreview_Click(null, null);
                    break;
                // F4キーが押下された場合
                case Keys.F4:
                    // TODO:印刷処理を実行
                    btnPrint_Click(null, null);
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

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSeikyuIchiran_Load(object sender, EventArgs e)
        {
            // 締区分コンボボックス設定
            setTightenTypeCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 入力情報設定
            setInputInfo();
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

        #endregion

        #region ビジネスロジック

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
            {
                ret = true;
            }
            else
            {
                DateTime date;

                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
            }
            return ret;
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
                c.Enter += new EventHandler(this.txtBillingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtBillingDate_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCd_Leave);
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

        #region 帳票出力データ取得処理
        /// <summary>
        /// 帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblSeikyusyo getData()
        {
            dtblSeikyusyo seikyusyo = new dtblSeikyusyo();
            DBCommon selectDb = new DBCommon();
            DataTable kaisyaDt;
            DataTable headDt;
            DataTable bodyDt;

            DataSet headDs = new DataSet();
            DataSet bodyDs = new DataSet();

            string tightenDateYears = txtTightenDateYears.Text;
            string tightenDateMonth = txtTightenDateMonth.Text;
            string tightenDateDaysValue = Convert.ToString(cmbTightenType.SelectedValue);
            string tightenDateDaysText = string.Empty;
            // 締日 = "月末"の場合
            if (Consts.EndOfMonthText.Equals(cmbTightenType.Text))
            {
                // 月末日取得処理を実行
                tightenDateDaysText = commonLogic.GetEndOfMonth(tightenDateYears, tightenDateMonth);
            }
            else
            {
                tightenDateDaysText = cmbTightenType.Text;
            }
            string customerCode = txtCustomerCode.Text;
            string officesCode = Convert.ToString(cmbOffices.SelectedValue);

            string sql = string.Empty;

            List<string[]> customerInfos = new List<string[]>();
            // データ更新情報．得意先コードが未設定の場合
            if (string.IsNullOrEmpty(customerCode) || cmbAllValue.Equals(officesCode))
            {
                // データ更新情報．請求締日から得意先情報を取得
                sql = string.Empty;
                sql += "SELECT chihouCode, tokuisakiCode, jigyousyoCode FROM tokuisaki_master ";
                sql += "WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                sql += "AND shimebi ='" + tightenDateDaysValue + "' ";
                if (!string.IsNullOrEmpty(customerCode)) sql += "AND tokuisakiCode ='" + customerCode + "' ";
                sql += "ORDER BY tokuisakiCode, jigyousyoCode ";
                DataTable customerDt = selectDb.executeSelect(sql, false);

                foreach (DataRow dRow in customerDt.Rows)
                {
                    customerInfos.Add(new string[] { Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcChihouCode])
                                                   , Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode])
                                                   , Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]) });
                }
            }
            else
            {
                customerInfos.Add(new string[] { "", customerCode, officesCode });
            }

            DateTime baseTargetDate;
            DateTime targetDateFrom;
            DateTime targetDateTo;

            if (string.IsNullOrEmpty(txtBillingDateYears.Text) &&
                string.IsNullOrEmpty(txtBillingDateMonth.Text) &&
                string.IsNullOrEmpty(txtBillingDateDays.Text))
            {
                baseTargetDate = Convert.ToDateTime(tightenDateYears + "-" + tightenDateMonth + "-" + tightenDateDaysText);
            }
            else
            {
                baseTargetDate = Convert.ToDateTime(txtBillingDateYears.Text + "-" + txtBillingDateMonth.Text + "-" + txtBillingDateDays.Text);
            }
            targetDateFrom = baseTargetDate.AddMonths(-1).AddDays(1);
            targetDateTo = baseTargetDate;

            #region 会社マスタデータ取得
            sql = string.Empty;
            sql += "SELECT * FROM kaisya_master ";
            kaisyaDt = selectDb.executeNoneLockSelect(sql).Copy();
            #endregion

            #region ヘッダデータ取得
            sql = string.Empty;
            sql += "SELECT ts.seikyuNo " + "\r";
            sql += "     , ts.tokuisakiCode " + "\r";
            sql += "     , ts.jigyousyoCode " + "\r";
            sql += "     , mm.kubunName " + "\r";
            sql += "     , DATE_FORMAT(ts.seikyubi, '%Y') AS y " + "\r";
            sql += "     , DATE_FORMAT(ts.seikyubi, '%m') AS m " + "\r";
            sql += "     , DATE_FORMAT(ts.seikyubi, '%d') AS d " + "\r";
            sql += "     , tm.zipCode " + "\r";
            sql += "     , tm.address1 " + "\r";
            sql += "     , tm.address2 " + "\r";
            sql += "     , tm.tokuisakiName " + "\r";
            sql += "     , tm.jigyousyoName " + "\r";
            sql += "     , ts.zengetsuSeikyu " + "\r";
            sql += "     , ts.nyukin " + "\r";
            sql += "     , ts.kurikosi " + "\r";
            sql += "     , ts.zeinukiUriage " + "\r";
            sql += "     , ts.syouhizei " + "\r";
            sql += "     , ts.zeikomiSeikyu " + "\r";
            sql += "     , tm.nouhinsyoSyohizeiKubun " + "\r";
            sql += "     , tm.flgKurikoshiSyuturyoku " + "\r";
            sql += "     , IFNULL(tm.seikyuSyuturyokuKubun, '3') AS seikyuSyuturyokuKubun " + "\r";
            sql += "     , tm.seikyusakiCode " + "\r";
            sql += "     , tm.seikyusakiJigyousyoCode " + "\r";
            sql += "     , jh.kyakusakiChuban " + "\r";
            sql += "     , CASE WHEN IFNULL(tm.seikyuSyuturyokuKubun, '3') = '4' THEN sd2.kenmei1 ELSE sd.kenmei1 END AS kenmei1 " + "\r";
            sql += "     , ts.kenmeiNo " + "\r";
            sql += "FROM tokuisaki_seikyu ts " + "\r";
            sql += "LEFT JOIN ( " + "\r";
            sql += "            SELECT sh.tokuisakiCode " + "\r";
            sql += "                 , sh.jigyousyoCode " + "\r";
            sql += "                 , sb.seikyuNo " + "\r";
            sql += "                 , sb.seikyuHizuke " + "\r";
            sql += "                 , sh.zipCode " + "\r";
            sql += "                 , sh.addres1 " + "\r";
            sql += "                 , sh.addres2 " + "\r";
            sql += "                 , sh.tokuisakiName " + "\r";
            sql += "                 , sh.jigyousyoName " + "\r";
            sql += "                 , sh.juchuNoTop " + "\r";
            sql += "                 , sh.juchuNoMid " + "\r";
            sql += "                 , sh.juchuNoBtm " + "\r";
            sql += "                 , sh.kenmei1 " + "\r";
            sql += "                 , sh.kenmeiNo " + "\r";
            sql += "            FROM seikyu_header sh " + "\r";
            sql += "            INNER JOIN (SELECT seikyuNo, seikyuHizuke FROM seikyu_body) sb " + "\r";
            sql += "            ON (sh.seikyuNo = sb.seikyuNo) " + "\r";
            sql += "            GROUP BY sh.tokuisakiCode, sh.jigyousyoCode, sb.seikyuHizuke " + "\r";
            sql += ") sd " + "\r";
            sql += "ON (ts.tokuisakiCode = sd.tokuisakiCode AND ts.jigyousyoCode = sd.jigyousyoCode AND ts.seikyubi = sd.seikyuHizuke) " + "\r";
            sql += "LEFT JOIN ( " + "\r";
            sql += "            SELECT sh.tokuisakiCode " + "\r";
            sql += "                 , sh.jigyousyoCode " + "\r";
            sql += "                 , sb.seikyuNo " + "\r";
            sql += "                 , sb.seikyuHizuke " + "\r";
            sql += "                 , sh.juchuNoTop " + "\r";
            sql += "                 , sh.juchuNoMid " + "\r";
            sql += "                 , sh.juchuNoBtm " + "\r";
            sql += "                 , sh.kenmei1 " + "\r";
            sql += "                 , sh.kenmeiNo " + "\r";
            sql += "            FROM seikyu_header sh " + "\r";
            sql += "            INNER JOIN (SELECT seikyuNo, seikyuHizuke FROM seikyu_body) sb " + "\r";
            sql += "            ON (sh.seikyuNo = sb.seikyuNo) " + "\r";
            sql += "            GROUP BY sh.tokuisakiCode, sh.jigyousyoCode, sb.seikyuHizuke, kenmeiNo " + "\r";
            sql += ") sd2 " + "\r";
            sql += "ON (ts.tokuisakiCode = sd2.tokuisakiCode AND ts.jigyousyoCode = sd2.jigyousyoCode AND ts.seikyubi = sd2.seikyuHizuke AND ts.kenmeiNo = sd2.kenmeiNo) " + "\r";
            sql += "LEFT JOIN (SELECT * FROM juchu_header) jh ";
            sql += "ON (sd.juchuNoTop = jh.juchuNoTop AND sd.juchuNoMid = jh.juchuNoMid AND sd.juchuNoBtm = jh.juchuNoBtm) ";
            sql += "LEFT JOIN (SELECT * FROM juchu_header) jh2 ";
            sql += "ON (sd2.juchuNoTop = jh2.juchuNoTop AND sd2.juchuNoMid = jh2.juchuNoMid AND sd2.juchuNoBtm = jh2.juchuNoBtm) ";
            sql += "LEFT JOIN tokuisaki_master tm " + "\r";
            sql += "ON (ts.tokuisakiCode = tm.tokuisakiCode AND ts.jigyousyoCode = tm.jigyousyoCode) " + "\r";
            sql += "LEFT JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '006') mm " + "\r";
            sql += "ON (tm.shimebi = mm.kubun) " + "\r";
            sql += "WHERE 1 = 1 " + "\r";
            sql += "AND ( " + "\r";
            int customer = 0;
            foreach (string[] customerInfo in customerInfos)
            {
                customer++;
                if (customer > 1) sql += "OR " + "\r";
                sql += "( ";
                sql += "ts.tokuisakiCode =  '" + customerInfo[1] + "' ";
                sql += "AND ";
                sql += "ts.jigyousyoCode =  '" + customerInfo[2] + "' ";
                sql += ") ";
            }
            sql += ") " + "\r";
            sql += "AND ts.seikyubi >= ' " + targetDateFrom + "' " + "\r";
            sql += "AND ts.seikyubi <= ' " + targetDateTo + "' " + "\r";
            sql += "AND (tm.seikyuSyuturyokuKubun = '2' OR (tm.seikyuSyuturyokuKubun = '3' AND sd.seikyuNo IS NOT NULL) OR tm.seikyuSyuturyokuKubun = '4') " + "\r";
            sql += "ORDER BY ts.tokuisakiCode, ts.jigyousyoCode, ts.seikyubi " + "\r";
            headDt = selectDb.executeNoneLockSelect(sql).Copy();
            #endregion

            #region ボディデータ取得
            sql = string.Empty;
            sql += "SELECT sh.seikyuNo ";
            sql += "     , sh.tokuisakiCode ";
            sql += "     , sh.jigyousyoCode ";
            sql += "     , sb.rowNo ";
            sql += "     , DATE_FORMAT(sh.denpyoHizuke, '%Y') AS y ";
            sql += "     , DATE_FORMAT(sh.denpyoHizuke, '%m') AS m ";
            sql += "     , DATE_FORMAT(sh.denpyoHizuke, '%d') AS d ";
            sql += "     , sh.denpyoNo ";
            sql += "     , sb.shouhinName1 ";
            sql += "     , sb.shouhinName2 ";
            sql += "     , sb.suryo ";
            sql += "     , sb.tani ";
            sql += "     , sb.tanka ";
            sql += "     , sb.kingaku ";
            //sql += "     , jh.kyakusakiChuban ";
            sql += "     , sf.syouhizei ";
            sql += "     , sh.flgMeisaiIkkatuSyuturyoku ";
            sql += "     , sh.kenmeiNo ";
            sql += "FROM seikyu_header sh ";
            sql += "INNER JOIN (SELECT * FROM seikyu_body) sb ";
            sql += "ON (sh.seikyuNo = sb.seikyuNo AND sh.denpyoNo = sb.denpyoNo) ";
            sql += "INNER JOIN (SELECT * FROM seikyu_footer) sf ";
            sql += "ON (sh.seikyuNo = sf.seikyuNo AND sh.denpyoNo = sf.denpyoNo) ";
            //sql += "INNER JOIN (SELECT * FROM juchu_header) jh ";
            //sql += "ON (sh.juchuNoTop = jh.juchuNoTop AND sh.juchuNoMid = jh.juchuNoMid AND sh.juchuNoBtm = jh.juchuNoBtm) ";
            sql += "WHERE 1 = 1 ";
            sql += "AND ( ";
            customer = 0;
            foreach (string[] customerInfo in customerInfos)
            {
                customer++;
                if (customer > 1) sql += "OR ";
                sql += "( ";
                sql += "sh.tokuisakiCode =  '" + customerInfo[1] + "' ";
                sql += "AND ";
                sql += "sh.jigyousyoCode =  '" + customerInfo[2] + "' ";
                sql += ") ";
            }
            sql += ") ";
            sql += "AND sb.seikyuHizuke >= ' " + targetDateFrom + "' ";
            sql += "AND sb.seikyuHizuke <= ' " + targetDateTo + "' ";
            bodyDt = selectDb.executeNoneLockSelect(sql).Copy();
            #endregion

            DataRow headRow;
            DataRow bodyRow;
            string kaisyaJyusyo = Convert.ToString(kaisyaDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcAddress]);
            string kaisyaYubin = Convert.ToString(kaisyaDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcZipCode]);
            string kaisyaTel = Convert.ToString(kaisyaDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcRenrakusaki1]);
            string kaisyaFax = Convert.ToString(kaisyaDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcRenrakusaki2]);
            string wkTokuisakiCode;
            string wkJigyousyoCode;
            string wkChildTokuisakiCode;
            string wkChildJigyousyoCode;
            string wkKenmeiNo;
            string seikyuNo;
            int groupNo = 0;
            int rowNo = 0;
            int denpyoRowNo = 0;
            int page = 0;
            decimal dec;
            decimal dec2;
            decimal nouhinsyoSyohizeiKubun;
            decimal flgKurikoshiSyuturyoku;
            decimal totalZei = decimal.Zero;
            int topMaxRowCount = 18;
            int atherMaxRowCount = 25;
            int maxRowCount;
            bool flgMeisaiIkkatuSyuturyoku;
            string seikyuSyuturyokuKubun;
            string wkShouhizai;
            decimal denpyoUriage;
            decimal uriageGoukei;
            string kenmei;
            string kyakusakiChuban;

            Dictionary<string, List<string>> parentList = new Dictionary<string, List<string>>();
            List<string> childList = new List<string>();
            foreach (DataRow hdRow in headDt.Rows)
            {
                seikyuSyuturyokuKubun = Convert.ToString(hdRow[DBFileLayout.TokuisakiMasterFile.dcSeikyuSyuturyokuKubun]);
                if (seikyuSyuturyokuKubun == "1") continue;

                maxRowCount = topMaxRowCount;
                groupNo++;
                page++;
                rowNo = 0;

                seikyuNo = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcSeikyuNo]);
                wkTokuisakiCode = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode]);
                wkJigyousyoCode = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode]);
                wkKenmeiNo = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcKenmeiNo]);
                flgKurikoshiSyuturyoku = Convert.ToDecimal(hdRow[DBFileLayout.TokuisakiMasterFile.dcFlgKurikoshiSyuturyoku]);
                nouhinsyoSyohizeiKubun = Convert.ToDecimal(hdRow[DBFileLayout.TokuisakiMasterFile.dcNouhinsyoSyohizeiKubun]);
                kenmei = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcKenmei1]);
                kyakusakiChuban = Convert.ToString(hdRow[DBFileLayout.JuchuHeaderFile.dcKyakusakiChuban]);

                headRow = seikyusyo.Tables["dtblSeikyusyoH"].NewRow();
                headRow["grpNo"] = groupNo;
                headRow["seikyuNo"] = seikyuNo;
                headRow["tokuisakiCd"] = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode]);
                headRow["jigyosyoCd"] = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode]);
                headRow["simeBi"] = Convert.ToString(hdRow[DBFileLayout.MeisyoMasterFile.dcKubunName]);
                headRow["seikyuNen"] = Convert.ToString(hdRow["y"]);
                headRow["seikyuTuki"] = Convert.ToString(hdRow["m"]);
                headRow["seikyuBi"] = Convert.ToString(hdRow["d"]);
                headRow["yubinNo"] = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcZipCode]);
                headRow["jyusyo1"] = Convert.ToString(hdRow[DBFileLayout.TokuisakiMasterFile.dcAddress1]);
                headRow["jyusyo2"] = Convert.ToString(hdRow[DBFileLayout.TokuisakiMasterFile.dcAddress2]);
                headRow["tokuisakiNm"] = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiName]);
                headRow["jigyosyoNm"] = Convert.ToString(hdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoName]);
                headRow["kaisyaJyusyo"] = kaisyaJyusyo;
                headRow["kaisyaJyusyo"] = kaisyaJyusyo;
                headRow["kaisyaTel"] = kaisyaTel;
                headRow["kaisyaFax"] = kaisyaFax;
                headRow["kaisyaYubin"] = kaisyaYubin;
                if (flgKurikoshiSyuturyoku == decimal.One && decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcZengetsuSeikyu]), out dec)) headRow["zengetuGoseikyu"] = dec.ToString("#,##0");
                if (flgKurikoshiSyuturyoku == decimal.One && decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcNyukin]), out dec)) headRow["gonyukin"] = dec.ToString("#,##0");
                if (flgKurikoshiSyuturyoku == decimal.One && decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcKurikosi]), out dec)) headRow["kurikoshi"] = dec.ToString("#,##0");
                if (decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcZeinukiUriage]), out dec)) headRow["tougetuZeinuki"] = dec.ToString("#,##0");
                if (decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcSyouhizei]), out dec)) headRow["syohizei"] = dec.ToString("#,##0");
                if (decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcZeikomiSeikyu]), out dec)) headRow["togetuZeikomi"] = dec.ToString("#,##0");
                seikyusyo.Tables["dtblSeikyusyoH"].Rows.Add(headRow.ItemArray);

                if (seikyuSyuturyokuKubun == "2")
                {
                    EnumerableRowCollection<DataRow> query;
                    query = headDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.TokuisakiMasterFile.dcSeikyusakiCode).Equals(wkTokuisakiCode) &&
                                                             p.Field<string>(DBFileLayout.TokuisakiMasterFile.dcSeikyusakiJigyousyoCode).Equals(wkJigyousyoCode));

                    if (query.Count() == 0) continue;

                    if (!parentList.ContainsKey(wkTokuisakiCode + "," + wkJigyousyoCode))
                    {
                        childList = new List<string>();
                        parentList.Add(wkTokuisakiCode + "," + wkJigyousyoCode, childList);
                    }

                    decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcZengetsuSeikyu]), out dec);
                    // 前回請求行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , dec
                                 , PrintRowType.ZenkaiSeikyu);

                    foreach (DataRow bdRow in query)
                    {
                        wkChildTokuisakiCode = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode]);
                        wkChildJigyousyoCode = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode]);
                        if (childList.Contains(wkChildTokuisakiCode + "," + wkChildJigyousyoCode)) continue;
                        if (rowNo == maxRowCount)
                        {
                            maxRowCount = atherMaxRowCount;
                            rowNo = 0;
                            page++;
                        }
                        rowNo++;
                        bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                        bodyRow["grpNo"] = groupNo;
                        bodyRow["seikyuNo"] = seikyuNo;
                        bodyRow["page"] = page;
                        bodyRow["tokuisakiCd"] = wkTokuisakiCode;
                        bodyRow["jigyosyoCd"] = wkJigyousyoCode;
                        bodyRow["gyoNo"] = rowNo;
                        bodyRow["dpyNen"] = string.Empty;
                        bodyRow["dnyTuki"] = string.Empty;
                        bodyRow["dpyHi"] = string.Empty;
                        bodyRow["denpyoNo"] = string.Empty;
                        bodyRow["hinmei1"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiName]);
                        bodyRow["hinmei1"] += "　" + Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoName]);
                        bodyRow["rowType"] = 2;
                        bodyRow["baseTokuisakiCd"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode]);
                        bodyRow["baseJigyosyoCd"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode]);
                        seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);

                        childList.Add(Convert.ToString(wkChildTokuisakiCode + "," + wkChildJigyousyoCode));
                    }
                    // 小計行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , decimal.Zero
                                 , PrintRowType.Shoukei);
                    // 消費税行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , decimal.Zero
                                 , PrintRowType.Shouhizei);
                    decimal.TryParse(Convert.ToString(hdRow[DBFileLayout.TokuisakiSeikyuFile.dcNyukin]), out dec);
                    // 入金額行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , dec
                                 , PrintRowType.Nyukin);
                    // 合計行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , decimal.Zero
                                 , PrintRowType.Goukei);
                    parentList[wkTokuisakiCode + "," + wkJigyousyoCode] = childList;
                }
                else if (seikyuSyuturyokuKubun == "3")
                {
                    var groupQuery = bodyDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode).Equals(wkTokuisakiCode) &&
                                                                 p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode).Equals(wkJigyousyoCode))
                                                          .GroupBy(p => p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcDenpyoNo));
                    uriageGoukei = decimal.Zero;
                    totalZei = decimal.Zero;
                    foreach (var query in groupQuery)
                    {
                        denpyoRowNo = 0;
                        denpyoUriage = decimal.Zero;
                        wkShouhizai = string.Empty;

                        foreach (DataRow bdRow in query)
                        {
                            if (rowNo == maxRowCount)
                            {
                                maxRowCount = atherMaxRowCount;
                                rowNo = 0;
                                page++;
                            }
                            flgMeisaiIkkatuSyuturyoku = Convert.ToDecimal(bdRow[DBFileLayout.SeikyuHeaderFile.dcFlgMeisaiIkkatuSyuturyoku]) == decimal.One;
                            denpyoRowNo++;
                            if (!flgMeisaiIkkatuSyuturyoku || (flgMeisaiIkkatuSyuturyoku && denpyoRowNo == 1))
                            {
                                if (denpyoRowNo == 1)
                                {
                                    // 伝票タイトル行追加
                                    denpyoRowNo++;
                                    rowNo++;
                                    bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                                    bodyRow["grpNo"] = groupNo;
                                    bodyRow["seikyuNo"] = seikyuNo;
                                    bodyRow["page"] = page;
                                    bodyRow["tokuisakiCd"] = wkTokuisakiCode;
                                    bodyRow["jigyosyoCd"] = wkJigyousyoCode;
                                    bodyRow["gyoNo"] = rowNo;
                                    bodyRow["dpyNen"] = Convert.ToString(bdRow["y"]);
                                    bodyRow["dnyTuki"] = Convert.ToString(bdRow["m"]);
                                    bodyRow["dpyHi"] = Convert.ToString(bdRow["d"]);
                                    bodyRow["denpyoNo"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcDenpyoNo]);
                                    bodyRow["hinmei1"] = kenmei;
                                    bodyRow["kyakuakiDenpyoNo"] = kyakusakiChuban;
                                    bodyRow["rowType"] = PrintRowType.Meisai.GetHashCode();
                                    seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                                }

                                if (rowNo == maxRowCount)
                                {
                                    maxRowCount = atherMaxRowCount;
                                    rowNo = 0;
                                    page++;
                                }
                                rowNo++;
                                bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                                bodyRow["grpNo"] = groupNo;
                                bodyRow["seikyuNo"] = seikyuNo;
                                bodyRow["page"] = page;
                                bodyRow["tokuisakiCd"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode]);
                                bodyRow["jigyosyoCd"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode]);
                                bodyRow["gyoNo"] = rowNo;
                                bodyRow["hinmei1"] = Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcShouhinName1]);
                                bodyRow["hinmei2"] = Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcShouhinName2]);
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcSuryo]), out dec)) bodyRow["suryo"] = dec.ToString("#,##0");
                                bodyRow["tani"] = Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcTani]);
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcTanka]), out dec)) bodyRow["tanka"] = dec.ToString("#,##0");
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec)) bodyRow["kingaku"] = dec.ToString("#,##0");
                                denpyoUriage += dec;
                                uriageGoukei += dec;
                                bodyRow["kyakuakiDenpyoNo"] = string.Empty;
                                bodyRow["rowType"] = PrintRowType.Meisai.GetHashCode();
                                seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                                wkShouhizai = Convert.ToString(bdRow[DBFileLayout.SeikyuFooterFile.dcSyouhizei]);
                            }
                            else
                            {
                                bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].Rows[seikyusyo.Tables["dtblSeikyusyoB"].Rows.Count - 1];
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec))
                                {
                                    decimal.TryParse(Convert.ToString(bodyRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec2);
                                    bodyRow[DBFileLayout.SeikyuBodyFile.dcKingaku] = (dec + dec2).ToString("#,##0");
                                }
                                bodyRow["tanka"] = bodyRow["kingaku"];
                                if (decimal.TryParse(Convert.ToString(bodyRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec2))
                                {
                                    if (dec2 == decimal.Zero)
                                    {
                                        bodyRow["suryo"] = decimal.Zero;
                                    }
                                    else
                                    {
                                        bodyRow["suryo"] = decimal.One;
                                    }
                                }
                                else
                                {
                                    bodyRow["suryo"] = string.Empty;
                                }
                                denpyoUriage += dec;
                                uriageGoukei += dec;
                                wkShouhizai = Convert.ToString(bdRow[DBFileLayout.SeikyuFooterFile.dcSyouhizei]);
                            }
                        }
                        if (decimal.Zero == nouhinsyoSyohizeiKubun)
                        {
                            totalZei += (denpyoUriage * 10 / 100);
                        }
                        else
                        {
                            if (rowNo == maxRowCount)
                            {
                                maxRowCount = atherMaxRowCount;
                                rowNo = 0;
                                page++;
                            }
                            rowNo++;
                            bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                            bodyRow["grpNo"] = groupNo;
                            bodyRow["seikyuNo"] = seikyuNo;
                            bodyRow["page"] = page;
                            bodyRow["tokuisakiCd"] = wkTokuisakiCode;
                            bodyRow["jigyosyoCd"] = wkJigyousyoCode;
                            bodyRow["gyoNo"] = rowNo;
                            bodyRow["hinmei1"] = "消費税";
                            if (decimal.TryParse(wkShouhizai, out dec)) bodyRow["kingaku"] = dec.ToString("#,##0");
                            bodyRow["rowType"] = 1;
                            seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                            totalZei += dec;
                        }
                        // 小計行追加
                        setPrintSumRow(ref rowNo
                                     , ref maxRowCount
                                     , atherMaxRowCount
                                     , ref page
                                     , ref seikyusyo
                                     , groupNo
                                     , seikyuNo
                                     , wkTokuisakiCode
                                     , wkJigyousyoCode
                                     , denpyoUriage
                                     , PrintRowType.Shoukei);
                    }
                    // 消費税行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , totalZei
                                 , PrintRowType.Shouhizei);
                    // 合計行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , uriageGoukei + totalZei
                                 , PrintRowType.Goukei);
                }
                else if (seikyuSyuturyokuKubun == "4")
                {
                    var groupQuery = bodyDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode).Equals(wkTokuisakiCode) &&
                                                                 p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode).Equals(wkJigyousyoCode) &&
                                                                 p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcKenmeiNo).Equals(wkKenmeiNo))
                                                          .GroupBy(p => p.Field<string>(DBFileLayout.SeikyuHeaderFile.dcDenpyoNo));
                    uriageGoukei = decimal.Zero;
                    totalZei = decimal.Zero;
                    foreach (var query in groupQuery)
                    {
                        denpyoRowNo = 0;
                        denpyoUriage = decimal.Zero;
                        wkShouhizai = string.Empty;

                        foreach (DataRow bdRow in query)
                        {
                            if (rowNo == maxRowCount)
                            {
                                maxRowCount = atherMaxRowCount;
                                rowNo = 0;
                                page++;
                            }
                            flgMeisaiIkkatuSyuturyoku = Convert.ToDecimal(bdRow[DBFileLayout.SeikyuHeaderFile.dcFlgMeisaiIkkatuSyuturyoku]) == decimal.One;
                            denpyoRowNo++;
                            if (!flgMeisaiIkkatuSyuturyoku || (flgMeisaiIkkatuSyuturyoku && denpyoRowNo == 1))
                            {
                                if (denpyoRowNo == 1)
                                {
                                    // 伝票タイトル行追加
                                    denpyoRowNo++;
                                    rowNo++;
                                    bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                                    bodyRow["grpNo"] = groupNo;
                                    bodyRow["seikyuNo"] = seikyuNo;
                                    bodyRow["page"] = page;
                                    bodyRow["tokuisakiCd"] = wkTokuisakiCode;
                                    bodyRow["jigyosyoCd"] = wkJigyousyoCode;
                                    bodyRow["gyoNo"] = rowNo;
                                    bodyRow["dpyNen"] = Convert.ToString(bdRow["y"]);
                                    bodyRow["dnyTuki"] = Convert.ToString(bdRow["m"]);
                                    bodyRow["dpyHi"] = Convert.ToString(bdRow["d"]);
                                    bodyRow["denpyoNo"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcDenpyoNo]);
                                    bodyRow["hinmei1"] = kenmei;
                                    bodyRow["kyakuakiDenpyoNo"] = kyakusakiChuban;
                                    bodyRow["rowType"] = PrintRowType.Meisai.GetHashCode();
                                    seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                                }

                                if (rowNo == maxRowCount)
                                {
                                    maxRowCount = atherMaxRowCount;
                                    rowNo = 0;
                                    page++;
                                }
                                rowNo++;
                                bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                                bodyRow["grpNo"] = groupNo;
                                bodyRow["seikyuNo"] = seikyuNo;
                                bodyRow["page"] = page;
                                bodyRow["tokuisakiCd"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcTokuisakiCode]);
                                bodyRow["jigyosyoCd"] = Convert.ToString(bdRow[DBFileLayout.SeikyuHeaderFile.dcJigyousyoCode]);
                                bodyRow["gyoNo"] = rowNo;
                                bodyRow["hinmei1"] = Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcShouhinName1]);
                                bodyRow["hinmei2"] = Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcShouhinName2]);
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcSuryo]), out dec)) bodyRow["suryo"] = dec.ToString("#,##0");
                                bodyRow["tani"] = Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcTani]);
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcTanka]), out dec)) bodyRow["tanka"] = dec.ToString("#,##0");
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec)) bodyRow["kingaku"] = dec.ToString("#,##0");
                                denpyoUriage += dec;
                                uriageGoukei += dec;
                                bodyRow["kyakuakiDenpyoNo"] = string.Empty;
                                bodyRow["rowType"] = PrintRowType.Meisai.GetHashCode();
                                seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                                wkShouhizai = Convert.ToString(bdRow[DBFileLayout.SeikyuFooterFile.dcSyouhizei]);
                            }
                            else
                            {
                                bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].Rows[seikyusyo.Tables["dtblSeikyusyoB"].Rows.Count - 1];
                                if (decimal.TryParse(Convert.ToString(bdRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec))
                                {
                                    decimal.TryParse(Convert.ToString(bodyRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec2);
                                    bodyRow[DBFileLayout.SeikyuBodyFile.dcKingaku] = (dec + dec2).ToString("#,##0");
                                }
                                bodyRow["tanka"] = bodyRow["kingaku"];
                                if (decimal.TryParse(Convert.ToString(bodyRow[DBFileLayout.SeikyuBodyFile.dcKingaku]), out dec2))
                                {
                                    if (dec2 == decimal.Zero)
                                    {
                                        bodyRow["suryo"] = decimal.Zero;
                                    }
                                    else
                                    {
                                        bodyRow["suryo"] = decimal.One;
                                    }
                                }
                                else
                                {
                                    bodyRow["suryo"] = string.Empty;
                                }
                                denpyoUriage += dec;
                                uriageGoukei += dec;
                                wkShouhizai = Convert.ToString(bdRow[DBFileLayout.SeikyuFooterFile.dcSyouhizei]);
                            }
                        }
                        if (decimal.Zero == nouhinsyoSyohizeiKubun)
                        {
                            totalZei += (denpyoUriage * 10 / 100);
                        }
                        else
                        {
                            if (rowNo == maxRowCount)
                            {
                                maxRowCount = atherMaxRowCount;
                                rowNo = 0;
                                page++;
                            }
                            rowNo++;
                            bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                            bodyRow["grpNo"] = groupNo;
                            bodyRow["seikyuNo"] = seikyuNo;
                            bodyRow["page"] = page;
                            bodyRow["tokuisakiCd"] = wkTokuisakiCode;
                            bodyRow["jigyosyoCd"] = wkJigyousyoCode;
                            bodyRow["gyoNo"] = rowNo;
                            bodyRow["hinmei1"] = "消費税";
                            if (decimal.TryParse(wkShouhizai, out dec)) bodyRow["kingaku"] = dec.ToString("#,##0");
                            bodyRow["rowType"] = 1;
                            seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                            totalZei += dec;
                        }
                        // 小計行追加
                        setPrintSumRow(ref rowNo
                                     , ref maxRowCount
                                     , atherMaxRowCount
                                     , ref page
                                     , ref seikyusyo
                                     , groupNo
                                     , seikyuNo
                                     , wkTokuisakiCode
                                     , wkJigyousyoCode
                                     , denpyoUriage
                                     , PrintRowType.Shoukei);
                    }
                    // 消費税行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , totalZei
                                 , PrintRowType.Shouhizei);
                    // 合計行追加
                    setPrintSumRow(ref rowNo
                                 , ref maxRowCount
                                 , atherMaxRowCount
                                 , ref page
                                 , ref seikyusyo
                                 , groupNo
                                 , seikyuNo
                                 , wkTokuisakiCode
                                 , wkJigyousyoCode
                                 , uriageGoukei + totalZei
                                 , PrintRowType.Goukei);
                }
                while (rowNo < maxRowCount)
                {
                    rowNo++;
                    bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
                    bodyRow["grpNo"] = groupNo;
                    bodyRow["seikyuNo"] = seikyuNo;
                    bodyRow["page"] = page;
                    bodyRow["tokuisakiCd"] = wkTokuisakiCode;
                    bodyRow["jigyosyoCd"] = wkJigyousyoCode;
                    bodyRow["gyoNo"] = rowNo;
                    bodyRow["rowType"] = 1;
                    seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
                }
            }

            decimal parentShoukei = decimal.Zero;
            decimal parentShouhizei = decimal.Zero;
            decimal childShoukei = decimal.Zero;
            string cTokuisakiCode;
            string cJigyousyoCode;
            foreach (KeyValuePair<string, List<string>> pair in parentList)
            {
                wkTokuisakiCode = pair.Key.Split(',')[0];
                wkJigyousyoCode = pair.Key.Split(',')[1];
                var parentShoukeiQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().Where(p => p.Field<Int16>("rowType") == PrintRowType.Shoukei.GetHashCode() &&
                                                                                                      p.Field<string>("tokuisakiCd").Equals(wkTokuisakiCode) &&
                                                                                                      p.Field<string>("jigyosyoCd").Equals(wkJigyousyoCode));
                var parentShouhizeiQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().Where(p => p.Field<Int16>("rowType") == PrintRowType.Shouhizei.GetHashCode() &&
                                                                                                        p.Field<string>("tokuisakiCd").Equals(wkTokuisakiCode) &&
                                                                                                        p.Field<string>("jigyosyoCd").Equals(wkJigyousyoCode));
                var parentGoukeiQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().Where(p => p.Field<Int16>("rowType") == PrintRowType.Goukei.GetHashCode() &&
                                                                                                     p.Field<string>("tokuisakiCd").Equals(wkTokuisakiCode) &&
                                                                                                     p.Field<string>("jigyosyoCd").Equals(wkJigyousyoCode));
                foreach (string cCode in pair.Value)
                {
                    cTokuisakiCode = cCode.Split(',')[0];
                    cJigyousyoCode = cCode.Split(',')[1];
                    childShoukei = decimal.Zero;
                    var childShoukeiQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().Where(p => p.Field<Int16>("rowType") == PrintRowType.Shoukei.GetHashCode() &&
                                                                                                    p.Field<string>("tokuisakiCd").Equals(cTokuisakiCode) &&
                                                                                                    p.Field<string>("jigyosyoCd").Equals(cJigyousyoCode));
                    var childShouhizeiQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().Where(p => p.Field<Int16>("rowType") == PrintRowType.Shouhizei.GetHashCode() &&
                                                                                                    p.Field<string>("tokuisakiCd").Equals(cTokuisakiCode) &&
                                                                                                    p.Field<string>("jigyosyoCd").Equals(cJigyousyoCode));
                    foreach (DataRow cRow in childShoukeiQuery)
                    {
                        decimal.TryParse(Convert.ToString(cRow["kingaku"]), out dec);
                        parentShoukei += dec;
                        childShoukei += dec;
                    }
                    foreach (DataRow cRow in childShouhizeiQuery)
                    {
                        decimal.TryParse(Convert.ToString(cRow["kingaku"]), out dec);
                        parentShouhizei += dec;
                    }
                    var childMeisaiQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().Where(p => p.Field<Int16>("rowType") == PrintRowType.Meisai.GetHashCode() &&
                                                                                                        p.Field<string>("tokuisakiCd").Equals(wkTokuisakiCode) &&
                                                                                                        p.Field<string>("jigyosyoCd").Equals(wkJigyousyoCode) &&
                                                                                                        p.Field<string>("baseTokuisakiCd").Equals(cTokuisakiCode) &&
                                                                                                        p.Field<string>("baseJigyosyoCd").Equals(cJigyousyoCode));
                    if (childMeisaiQuery.Count() > 0)
                    {
                        childMeisaiQuery.ElementAt(0)["kingaku"] = childShoukei.ToString("#,##0");
                    }
                }

                if (parentShoukeiQuery.Count() > 0)
                {
                    parentShoukeiQuery.ElementAt(0)["kingaku"] = parentShoukei.ToString("#,##0");
                }
                if (parentShouhizeiQuery.Count() > 0)
                {
                    parentShouhizeiQuery.ElementAt(0)["kingaku"] = parentShouhizei.ToString("#,##0");
                }
                if (parentGoukeiQuery.Count() > 0)
                {
                    parentGoukeiQuery.ElementAt(0)["kingaku"] = (parentShoukei + parentShouhizei).ToString("#,##0");
                }
            }

            DataTable wkDtblSeikyusyoH = seikyusyo.Tables["dtblSeikyusyoH"].Copy();
            DataTable wkDtblSeikyusyoB = seikyusyo.Tables["dtblSeikyusyoB"].Copy();
            int newGroupNo = 0;
            int newPage = 0;
            foreach (DataRow dRow in wkDtblSeikyusyoH.Rows)
            {
                newGroupNo = Convert.ToInt16(dRow["grpNo"]) + groupNo;
                dRow["grpNo"] = newGroupNo;
                dRow["titleOption"] = "（控）";
                seikyusyo.Tables["dtblSeikyusyoH"].Rows.Add(dRow.ItemArray);
            }
            foreach (DataRow dRow in wkDtblSeikyusyoB.Rows)
            {
                newGroupNo = Convert.ToInt16(dRow["grpNo"]) + groupNo;
                newPage = Convert.ToInt16(dRow["page"]) + page;
                dRow["grpNo"] = newGroupNo;
                dRow["page"] = newPage;
                seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(dRow.ItemArray);
            }

            int dispPage = 0;
            int dispMaxPage = 0;
            int wkPage = 0;
            int rowCount = 0;
            var pageQuery = seikyusyo.Tables["dtblSeikyusyoB"].AsEnumerable().OrderBy(p => seikyusyo.Tables["dtblSeikyusyoB"].Rows.IndexOf(p)).GroupBy(p => p.Field<Int16>("grpNo"));
            foreach (var query in pageQuery)
            {
                dispMaxPage = 1;
                rowCount = query.Count() - topMaxRowCount;
                wkPage = 0;
                if (rowCount > 0)
                {
                    wkPage = rowCount / atherMaxRowCount;
                }
                dispMaxPage += wkPage;
                rowCount = 0;
                foreach (DataRow pageRow in query)
                {
                    rowCount++;
                    dispPage = 1;
                    if (topMaxRowCount < rowCount)
                    {
                        dispPage += (rowCount - topMaxRowCount) / atherMaxRowCount;
                        if ((rowCount - topMaxRowCount) % atherMaxRowCount != 0)
                        {
                            dispPage++;
                        }
                    }
                    pageRow["dispMaxPage"] = dispMaxPage;
                    pageRow["dispPage"] = dispPage;
                }
            }

            return seikyusyo;
        }
        #endregion

        #region 集計行出力処理
        /// <summary>
        /// 集計行出力処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="maxRowCount"></param>
        /// <param name="newMaxRowCount"></param>
        /// <param name="page"></param>
        /// <param name="seikyusyo"></param>
        /// <param name="groupNo"></param>
        /// <param name="seikyuNo"></param>
        /// <param name="wkTokuisakiCode"></param>
        /// <param name="wkJigyousyoCode"></param>
        /// <param name="kingaku"></param>
        /// <param name="printRowType"></param>
        private void setPrintSumRow(ref int rowNo
                                  , ref int maxRowCount
                                  , int newMaxRowCount
                                  , ref int page
                                  , ref dtblSeikyusyo seikyusyo
                                  , int groupNo
                                  , string seikyuNo
                                  , string wkTokuisakiCode
                                  , string wkJigyousyoCode
                                  , decimal kingaku
                                  , PrintRowType printRowType)
        {
            if (rowNo == maxRowCount)
            {
                maxRowCount = newMaxRowCount;
                rowNo = 0;
                page++;
            }
            rowNo++;
            DataRow bodyRow = seikyusyo.Tables["dtblSeikyusyoB"].NewRow();
            bodyRow["grpNo"] = groupNo;
            bodyRow["seikyuNo"] = Convert.ToString(seikyuNo);
            bodyRow["page"] = page;
            bodyRow["tokuisakiCd"] = wkTokuisakiCode;
            bodyRow["jigyosyoCd"] = wkJigyousyoCode;
            bodyRow["gyoNo"] = rowNo;
            switch (printRowType)
            {
                case PrintRowType.ZenkaiSeikyu:
                    bodyRow["hinmei1"] = "※ ※ 前回請求額 ※ ※";
                    break;
                case PrintRowType.Shoukei:
                    bodyRow["hinmei1"] = "※ ※ 小計 ※ ※";
                    break;
                case PrintRowType.Shouhizei:
                    bodyRow["hinmei1"] = "※ ※ 消費税 ※ ※";
                    break;
                case PrintRowType.Nyukin:
                    bodyRow["hinmei1"] = "※ ※ 入金額 ※ ※";
                    break;
                case PrintRowType.Goukei:
                    bodyRow["hinmei1"] = "※ ※ 合　計 ※ ※";
                    break;
            }
            bodyRow["rowType"] = printRowType.GetHashCode();
            bodyRow["kingaku"] = kingaku.ToString("#,##0");
            seikyusyo.Tables["dtblSeikyusyoB"].Rows.Add(bodyRow.ItemArray);
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtTightenDateYears.Text) ||
                string.IsNullOrEmpty(txtTightenDateMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblTightenDate.Text));
                return;
            }
            dtblSeikyusyo seikyusyo = getData();
            if (seikyusyo.Tables["dtblSeikyusyoH"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptSeikyusyo1.SetDataSource(seikyusyo);


            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptSeikyusyo1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptSeikyusyo1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptSeikyusyo1.PrintOptions.PaperOrientation)
                                                                     , rptSeikyusyo1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptSeikyusyo1.PrintToPrinter(printerSettings
                                               , pageSettings
                                               , false);

                }
            }
            else
            {
                printView.Size = new Size(1180, 945);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private bool setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (dt == null || dt.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerCode.Focus();
                return false;
            }

            if (flgUnconditional || txtCustomerCode.BeforeValue != tokuisakiCode)
            {
                DataRow dRow = dt.Rows[0];
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Text = string.Empty;
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
                }
                setOfficesCmb(txtCustomerCode.Text, string.Empty);
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;

            return true;
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTightenDateYears.MaxLength = 4;  // 請求締日(年)
            txtTightenDateMonth.MaxLength = 2;  // 請求締日(月)
            txtBillingDateYears.MaxLength = 4;  // 請求年月日(年)
            txtBillingDateMonth.MaxLength = 2;  // 請求年月日(月)
            txtBillingDateDays.MaxLength = 2;   // 請求年月日(日)
            txtCustomerCode.MaxLength = 5;      // 得意先ｺｰﾄﾞ

            // 入力制御イベント設定
            txtTightenDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求締日(年)  :数字のみ入力可
            txtTightenDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求締日(月)  :数字のみ入力可
            txtBillingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(年):数字のみ入力可
            txtBillingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(月):数字のみ入力可
            txtBillingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 請求年月日(日):数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 得意先ｺｰﾄﾞ    :数字のみ入力可
        }
        #endregion

        #region 事業所コンボボックスの設定
        /// <summary>
        /// 事業所コンボボックスの設定
        /// </summary>
        private void setOfficesCmb(string tokuisakiCode, string jigyousyoCode)
        {
            // 事業所取得
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
            {
                tokuisakiCode = dummyCode;
            }
            DataTable officesDt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (officesDt != null && officesDt.Rows.Count > 1)
            {
                DataRow newRow = officesDt.NewRow();
                newRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode] = cmbAllValue;
                newRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoName] = cmbAllText;
                officesDt.Rows.InsertAt(newRow, 0);
            }
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbOffices, officesDt
                                            , DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode
                                            , DBFileLayout.TokuisakiMasterFile.dcJigyousyoName);

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

        #region 締区分コンボボックスの設定
        /// <summary>
        /// 締区分コンボボックスの設定
        /// </summary>
        private void setTightenTypeCmb()
        {
            ComboBoxStyle cmbStyle = ComboBoxStyle.DropDownList;
            // 締区分取得
            DataTable tightenTypeDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE006);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbTightenType, tightenTypeDt, "kubun", "kubunName");
            cmbTightenType.DropDownStyle = cmbStyle;
            cmbTightenType.SelectedIndex = 0;
        }
        #endregion

        #endregion
    }
}
