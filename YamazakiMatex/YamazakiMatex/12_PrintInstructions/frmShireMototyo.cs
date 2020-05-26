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
    /// 仕入元帳
    /// </summary>
    public partial class frmShireMototyo : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , TargetDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DBTantousyaMaster tantousyaMaster;
        private bool flgBtnSearchSelect = false;
        private DBShiresakiMaster shiresakiMaster;
        sfrmShiiresakiSearch sShiresaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmShireMototyo()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetDateYears.Text = string.Empty;
            txtTargetDateMonth.Text = string.Empty;
            txtVendorCode.Text = string.Empty;
            lblVendorName.Text = string.Empty;
            commonLogic = new CommonLogic();
            tantousyaMaster = new DBTantousyaMaster();
            shiresakiMaster = new DBShiresakiMaster();
            sShiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
            DialogResult = DialogResult.None;
            lblVendorName.Size = new Size(419, 27);

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
        }
        #endregion

        #region プレビューボタン押下処理
        /// <summary>
        /// プレビューボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            executePrint(PrintType.Preview);
        }
        #endregion

        #region 印刷ボタン押下処理
        /// <summary>
        /// 印刷ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            executePrint(PrintType.OutPut);
        }
        #endregion

        #region 閉じるボタン押下処理
        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            closedForm();
        }
        #endregion

        #region 対象年月日(FROM)フォーカスインイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月日(FROM)フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetDate;
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
                lblVendorName.Text = string.Empty;
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
                    case LastInputDateType.TargetDate:
                        y = txtTargetDateYears.Text;
                        m = txtTargetDateMonth.Text;
                        d = "01";
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.TargetDate.Equals(lastInputDateType))
                    {
                        txtTargetDateYears.Focus();
                    }
                    return;
                }
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
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

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJyuchachuIchiran_Load(object sender, EventArgs e)
        {
            // 入力情報設定
            setInputInfo();
            lblVendorName.Location = new Point(364, 56);
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
            // 仕入先コードを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtVendorCode.Name))
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

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m))
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

            // 対象年月日(FROM)の場合
            if (c.Name.Equals(txtTargetDateYears.Name) ||
                c.Name.Equals(txtTargetDateMonth.Name) ||
                c.Name.Equals(dtpTargetDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetDateFrom_Leave);
            }
            // 仕入先コードの場合
            else if (c.Name.Equals(txtVendorCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtVendorCode_Leave);
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

        #region 帳票出力データ取得処理
        /// <summary>
        /// 画面表示・帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblSireMotocho getData()
        {
            dtblSireMotocho result = new dtblSireMotocho();

            DateTime targetDateFrom = Convert.ToDateTime(txtTargetDateYears.Text + "/" + txtTargetDateMonth.Text + "/01");
            DateTime targetDateTo = targetDateFrom.AddMonths(1).AddDays(-1);
            string zenNendo = targetDateFrom.Month < 10 ? Convert.ToString(targetDateFrom.Year - 1) : Convert.ToString(targetDateFrom.Year);
            string zenGetu = targetDateFrom.Month == 12 ? "1" : Convert.ToString(targetDateFrom.Month - 1);
            string shiresakiCode = txtVendorCode.Text;

            DBCommon selectDb = new DBCommon();
            string sql = string.Empty;
            sql += "SELECT shireMototyo.shiresakiCode ";
            sql += "     , shireMototyo.shiresakiName ";
            sql += "     , shireMototyo.denpyoHizuke ";
            sql += "     , shireMototyo.hi ";
            sql += "     , shireMototyo.shouhinName1 ";
            sql += "     , shireMototyo.shouhinName2 ";
            sql += "     , shireMototyo.suryo ";
            sql += "     , shireMototyo.tani ";
            sql += "     , shireMototyo.tanka ";
            sql += "     , shireMototyo.kingaku ";
            sql += "     , shireMototyo.shiharai ";
            sql += "     , shireMototyo.dataType ";
            sql += "     , IFNULL(sk.kurikoshi, 0) AS kurikoshi ";
            sql += "FROM ( ";
            sql += "      SELECT sh.shiresakiCode ";
            sql += "           , sh.shiresakiName ";
            sql += "           , sh.denpyoHizuke ";
            sql += "           , DATE_FORMAT(sh.denpyoHizuke, '%d') AS hi ";
            sql += "           , sb.shouhinName1 ";
            sql += "           , sb.shouhinName2 ";
            sql += "           , sb.suryo ";
            sql += "           , sb.tani ";
            sql += "           , sb.tanka ";
            sql += "           , sb.kingaku ";
            sql += "           , 0 AS shiharai ";
            sql += "           , 0 AS dataType ";
            sql += "      FROM (SELECT * FROM shire_header WHERE (kanriKubun IS NOT NULL AND kanriKubun <> '9')) sh ";
            sql += "      INNER JOIN (SELECT * FROM shire_body) sb ";
            sql += "      ON (sh.shireNo = sb.shireNo) ";
            sql += "      UNION ALL ";
            sql += "      SELECT s1.shiresakiCode ";
            sql += "           , s1.shiresakiName ";
            sql += "           , s1.shiharaiHizuke AS denpyoHizuke ";
            sql += "           , DATE_FORMAT(s1.shiharaiHizuke, '%d') AS hi ";
            sql += "           , '現金' AS shouhinName1 ";
            sql += "           , '' AS shouhinName2 ";
            sql += "           , 0 AS suryo ";
            sql += "           , '' AS tani ";
            sql += "           , 0 AS tanka ";
            sql += "           , 0 AS kingaku ";
            sql += "           , s1.genkin AS shiharai ";
            sql += "           , 1 AS dataType ";
            sql += "      FROM (SELECT * FROM shiharai WHERE (kanriKubun IS NOT NULL AND kanriKubun <> '9')) s1 ";
            sql += "      UNION ALL ";
            sql += "      SELECT s2.shiresakiCode ";
            sql += "           , s2.shiresakiName ";
            sql += "           , s2.shiharaiHizuke AS denpyoHizuke ";
            sql += "           , DATE_FORMAT(s2.shiharaiHizuke, '%d') AS hi ";
            sql += "           , '手形' AS shouhinName1 ";
            sql += "           , '' AS shouhinName2 ";
            sql += "           , 0 AS suryo ";
            sql += "           , '' AS tani ";
            sql += "           , 0 AS tanka ";
            sql += "           , 0 AS kingaku ";
            sql += "           , s2.tegata AS shiharai ";
            sql += "           , 2 AS dataType ";
            sql += "      FROM (SELECT * FROM shiharai WHERE (kanriKubun IS NOT NULL AND kanriKubun <> '9')) s2 ";
            sql += "      UNION ALL ";
            sql += "      SELECT s3.shiresakiCode ";
            sql += "           , s3.shiresakiName ";
            sql += "           , s3.shiharaiHizuke AS denpyoHizuke ";
            sql += "           , DATE_FORMAT(s3.shiharaiHizuke, '%d') AS hi ";
            sql += "           , '振込' AS shouhinName1 ";
            sql += "           , '' AS shouhinName2 ";
            sql += "           , 0 AS suryo ";
            sql += "           , '' AS tani ";
            sql += "           , 0 AS tanka ";
            sql += "           , 0 AS kingaku ";
            sql += "           , s3.hurikomi AS shiharai ";
            sql += "           , 3 AS dataType ";
            sql += "      FROM (SELECT * FROM shiharai WHERE (kanriKubun IS NOT NULL AND kanriKubun <> '9')) s3 ";
            sql += "      UNION ALL ";
            sql += "      SELECT s4.shiresakiCode ";
            sql += "           , s4.shiresakiName ";
            sql += "           , s4.shiharaiHizuke AS denpyoHizuke ";
            sql += "           , DATE_FORMAT(s4.shiharaiHizuke, '%d') AS hi ";
            sql += "           , '相殺' AS shouhinName1 ";
            sql += "           , '' AS shouhinName2 ";
            sql += "           , 0 AS suryo ";
            sql += "           , '' AS tani ";
            sql += "           , 0 AS tanka ";
            sql += "           , 0 AS kingaku ";
            sql += "           , s4.sousai AS shiharai ";
            sql += "           , 4 AS dataType ";
            sql += "      FROM (SELECT * FROM shiharai WHERE (kanriKubun IS NOT NULL AND kanriKubun <> '9')) s4 ";
            sql += "     ) shireMototyo ";
            sql += "     LEFT JOIN ( ";
            sql += "                SELECT shiresakiCode ";
            sql += "                     , " + zenGetu + "GatsuKurikoshi AS kurikoshi ";
            sql += "                FROM shiresaki_kaikake ";
            sql += "                WHERE nendo = '" + zenNendo + "' ";
            sql += "               ) sk ";
            sql += "     ON (shireMototyo.shiresakiCode = sk.shiresakiCode) ";
            sql += "WHERE IFNULL(shireMototyo.shiresakiCode, '') <> '' ";
            sql += "AND shireMototyo.denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "AND shireMototyo.denpyoHizuke <= '" + targetDateTo + "' ";
            sql += "ORDER BY shiresakiCode, denpyoHizuke, dataType ";
            DataTable dt = selectDb.executeNoneLockSelect(sql).Copy();

            var shiresakiQuery = dt.AsEnumerable().GroupBy(p => p.Field<string>("shiresakiCode"));

            string nen = txtTargetDateYears.Text;
            string tuki = txtTargetDateMonth.Text;
            string hi = string.Empty;
            string wkHi = string.Empty;
            string wkNextHi = string.Empty;
            DataRow printRow;
            DataRow nextPrintRow;
            int dataRowNo;
            int printRowNo;
            int shireRowNo;
            int shiharaiRowNo;
            int count = 0;
            decimal sashihiki;
            decimal wkSuryo;
            decimal wkTanka;
            decimal wkKingaku;
            decimal wkShiharai;
            decimal wkDataType;
            decimal wkNextDataType;
            decimal maxRowCount = 37;
            decimal page;
            bool flgDispSashihiki = false;
            bool flgNextRowExists = false;
            foreach (var query in shiresakiQuery)
            {
                dataRowNo = 0;
                printRowNo = 0;
                shireRowNo = 0;
                shiharaiRowNo = 0;
                sashihiki = decimal.Zero;
                hi = string.Empty;
                wkHi = string.Empty;
                flgDispSashihiki = false;
                count = 0;
                page = 0;
                if (!string.IsNullOrEmpty(shiresakiCode) && !shiresakiCode.Equals(query.Key)) continue;
                foreach (DataRow row in query)
                {
                    wkDataType = Convert.ToDecimal(row["dataType"]);
                    hi = Convert.ToString(row["hi"]);
                    flgDispSashihiki = false;
                    try
                    {
                        nextPrintRow = query.ElementAt(dataRowNo + 1);
                        wkNextDataType = Convert.ToDecimal(nextPrintRow["dataType"]);
                        wkNextHi = Convert.ToString(nextPrintRow["hi"]);
                        if (wkDataType == decimal.Zero && wkNextDataType != decimal.Zero) flgDispSashihiki = true;
                        if (!hi.Equals(wkNextHi)) flgDispSashihiki = true;
                        flgNextRowExists = true;
                    }
                    catch
                    {
                        flgDispSashihiki = true;
                        flgNextRowExists = false;
                    }
                    dataRowNo++;
                    printRowNo++;
                    #region 前月繰越行追加処理
                    if (printRowNo == 1)
                    {
                        count++;
                        if (count == 1)
                        {
                            page++;
                        }
                        if (count == maxRowCount)
                        {
                            count = 0;
                        }
                        printRowNo++;
                        printRow = result.Tables["dtblSireMotocho"].NewRow();
                        sashihiki = Convert.ToDecimal(row["kurikoshi"]);
                        printRow["sireCd"] = Convert.ToString(row["shiresakiCode"]);
                        printRow["sireNm"] = Convert.ToString(row["shiresakiName"]);
                        printRow["nen"] = nen;
                        printRow["tuki"] = tuki;
                        printRow["hi"] = string.Empty;
                        printRow["hinmei1"] = "前月繰越";
                        printRow["hinmei2"] = string.Empty;
                        printRow["suryo"] = string.Empty;
                        printRow["tani"] = string.Empty;
                        printRow["tanka"] = string.Empty;
                        printRow["kingaku"] = string.Empty;
                        printRow["siharai"] = string.Empty;
                        printRow["sashihikizan"] = sashihiki.ToString("#,##0");
                        result.Tables["dtblSireMotocho"].Rows.Add(printRow.ItemArray);
                    }
                    #endregion
                    #region 前頁行追加処理
                    else if (printRowNo % maxRowCount == 1)
                    {
                        count++;
                        if (count == 1)
                        {
                            page++;
                        }
                        if (count == maxRowCount)
                        {
                            count = 0;
                        }
                        printRowNo++;
                        printRow = result.Tables["dtblSireMotocho"].NewRow();
                        printRow["sireCd"] = Convert.ToString(row["shiresakiCode"]);
                        printRow["sireNm"] = Convert.ToString(row["shiresakiName"]);
                        printRow["nen"] = nen;
                        printRow["tuki"] = tuki;
                        printRow["hi"] = string.Empty;
                        printRow["hinmei1"] = "前頁からの繰越";
                        printRow["hinmei2"] = string.Empty;
                        printRow["suryo"] = string.Empty;
                        printRow["tani"] = string.Empty;
                        printRow["tanka"] = string.Empty;
                        printRow["kingaku"] = string.Empty;
                        printRow["siharai"] = string.Empty;
                        printRow["sashihikizan"] = sashihiki.ToString("#,##0");
                        result.Tables["dtblSireMotocho"].Rows.Add(printRow.ItemArray);
                    }
                    #endregion
                    #region 明細部出力処理
                    printRow = result.Tables["dtblSireMotocho"].NewRow();
                    if (wkDataType == decimal.Zero)
                    {
                        count++;
                        if (count == 1)
                        {
                            page++;
                        }
                        if (count == maxRowCount)
                        {
                            count = 0;
                        }
                        decimal.TryParse(Convert.ToString(row["suryo"]), out wkSuryo);
                        decimal.TryParse(Convert.ToString(row["tanka"]), out wkTanka);
                        decimal.TryParse(Convert.ToString(row["kingaku"]), out wkKingaku);
                        sashihiki += wkKingaku;
                        printRow["sireCd"] = Convert.ToString(row["shiresakiCode"]);
                        printRow["sireNm"] = Convert.ToString(row["shiresakiName"]);
                        printRow["nen"] = nen;
                        printRow["tuki"] = tuki;
                        if (!hi.Equals(wkHi)) printRow["hi"] = hi;
                        printRow["hinmei1"] = Convert.ToString(row["shouhinName1"]);
                        printRow["hinmei2"] = Convert.ToString(row["shouhinName2"]);
                        printRow["suryo"] = wkSuryo.ToString("#,##0");
                        printRow["tani"] = Convert.ToString(row["tani"]);
                        printRow["tanka"] = wkTanka.ToString("#,##0");
                        printRow["kingaku"] = wkKingaku.ToString("#,##0");
                        printRow["siharai"] = string.Empty;
                        if (flgDispSashihiki)
                        {
                            printRow["sashihikizan"] = sashihiki.ToString("#,##0");
                        }
                        else
                        {
                            printRow["sashihikizan"] = string.Empty;
                        }
                        result.Tables["dtblSireMotocho"].Rows.Add(printRow.ItemArray);
                        wkHi = hi;
                    }
                    else
                    {
                        count++;
                        if (count == 1)
                        {
                            page++;
                        }
                        if (count == maxRowCount)
                        {
                            count = 0;
                        }
                        decimal.TryParse(Convert.ToString(row["shiharai"]), out wkShiharai);
                        sashihiki -= wkShiharai;
                        printRow["sireCd"] = Convert.ToString(row["shiresakiCode"]);
                        printRow["sireNm"] = Convert.ToString(row["shiresakiName"]);
                        printRow["nen"] = nen;
                        printRow["tuki"] = tuki;
                        if (!hi.Equals(wkHi)) printRow["hi"] = hi;
                        printRow["hinmei1"] = Convert.ToString(row["shouhinName1"]);
                        printRow["hinmei2"] = Convert.ToString(row["shouhinName2"]);
                        printRow["suryo"] = string.Empty;
                        printRow["tani"] = string.Empty;
                        printRow["tanka"] = string.Empty;
                        printRow["kingaku"] = string.Empty;
                        printRow["siharai"] = wkShiharai.ToString("#,##0");
                        if (flgDispSashihiki)
                        {
                            printRow["sashihikizan"] = sashihiki.ToString("#,##0");
                        }
                        else
                        {
                            printRow["sashihikizan"] = string.Empty;
                        }
                        result.Tables["dtblSireMotocho"].Rows.Add(printRow.ItemArray);
                        wkHi = hi;
                    }
                    #endregion
                    #region 次頁行追加処理
                    if (flgNextRowExists && printRowNo % maxRowCount == maxRowCount - 1)
                    {
                        count++;
                        if (count == 1)
                        {
                            page++;
                        }
                        if (count == maxRowCount)
                        {
                            count = 0;
                        }
                        printRowNo++;
                        printRow = result.Tables["dtblSireMotocho"].NewRow();
                        printRow["sireCd"] = Convert.ToString(row["shiresakiCode"]);
                        printRow["sireNm"] = Convert.ToString(row["shiresakiName"]);
                        printRow["nen"] = nen;
                        printRow["tuki"] = tuki;
                        printRow["hi"] = string.Empty;
                        printRow["hinmei1"] = "次頁への繰越";
                        printRow["hinmei2"] = string.Empty;
                        printRow["suryo"] = string.Empty;
                        printRow["tani"] = string.Empty;
                        printRow["tanka"] = string.Empty;
                        printRow["kingaku"] = string.Empty;
                        printRow["siharai"] = string.Empty;
                        printRow["sashihikizan"] = sashihiki.ToString("#,##0");
                        result.Tables["dtblSireMotocho"].Rows.Add(printRow.ItemArray);
                    }
                    #endregion
                }
                while (maxRowCount * page > printRowNo)
                {
                    printRow = result.Tables["dtblSireMotocho"].NewRow();
                    printRow["nen"] = nen;
                    printRow["tuki"] = tuki;
                    result.Tables["dtblSireMotocho"].Rows.Add(printRow.ItemArray);
                    printRowNo++;
                }
            }

            return result;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtTargetDateYears.Text) ||
                string.IsNullOrEmpty(txtTargetDateMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblTargetDate.Text));
                return;
            }

            dtblSireMotocho shireMototyo = getData();
            if (shireMototyo == null || shireMototyo.Tables["dtblSireMotocho"].Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "対象年月のデータ"));
                return;
            }
            rptSireMotocho1.SetDataSource(shireMototyo);

            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptSireMotocho1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptSireMotocho1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptSireMotocho1.PrintOptions.PaperOrientation)
                                                                     , rptSireMotocho1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptSireMotocho1.PrintToPrinter(printerSettings
                                                 , pageSettings
                                                 , false);

                }
            }
            else
            {
                printView.Size = new Size(1585, 940);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
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
            txtTargetDateYears.MaxLength = 4;   // 年月(年)
            txtTargetDateMonth.MaxLength = 2;   // 年月(月)
            txtVendorCode.MaxLength = 3;        // 仕入先コード

            // 入力制御イベント設定
            txtTargetDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(年)    :数字のみ入力可
            txtTargetDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(月)    :数字のみ入力可
            txtVendorCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 仕入先コード:数字のみ入力可
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
                    lblVendorName.Text = string.Empty;
                }
                else
                {
                    txtVendorCode.Text = shiresakiInfo[0].ShiresakiCode;
                    lblVendorName.Text = shiresakiInfo[0].ShiresakiName;
                }
            }
            else
            {
                txtVendorCode.Text = shiresakiCode;
            }

            txtVendorCode.BeforeValue = txtVendorCode.Text;
        }
        #endregion

        #endregion
    }
}
