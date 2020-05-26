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
    public partial class frmUrikakeKaisyuHyo : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private enum LastInputDateType
        {
            None = 0
          , BillingDate = 1
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
        public frmUrikakeKaisyuHyo()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            activeControlInfo = new ActiveControlInfo();
            txtBillingDateYears.Text = string.Empty;
            txtBillingDateMonth.Text = string.Empty;
            txtBillingDateYears.Text = string.Empty;
            txtBillingDateMonth.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            meisyoMaster = new DBMeisyoMaster();
            fTokuisaki = new sfrmTokuisakiSearch(false);
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
                    case LastInputDateType.BillingDate:
                        y = txtBillingDateYears.Text;
                        m = txtBillingDateMonth.Text;
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
            }
            else
            {
                txtCustomerName.Text = string.Empty;
                // 事業所コンボボックス設定
                setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
                cmbBillingDateType.Enabled = true;
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

            // 請求年月日の場合
            if (c.Name.Equals(txtBillingDateYears.Name) ||
                c.Name.Equals(txtBillingDateMonth.Name) ||
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
        private dtblUrikakekinKaisyuhyo getData()
        {
            dtblUrikakekinKaisyuhyo kaisyuhyo = new dtblUrikakekinKaisyuhyo();
            DBCommon selectDb = new DBCommon();
            string sql = string.Empty;

            DateTime seikyubi;
            string billingDateType = Convert.ToString(cmbBillingDateType.SelectedValue);
            if (billingDateType.Equals(Consts.EndOfMonthValue))
            {
                int month = Convert.ToInt16(txtBillingDateMonth.Text);
                seikyubi = Convert.ToDateTime(txtBillingDateYears.Text + "/" + Convert.ToString(month) + "/01").AddMonths(1).AddDays(-1);
            }
            else if (billingDateType.Equals(Consts.FromTimeToTimeValue))
            {
                seikyubi = Convert.ToDateTime(txtBillingDateYears.Text + "/" + txtBillingDateMonth.Text + "/01");//TODO
            }
            else
            {
                seikyubi = Convert.ToDateTime(txtBillingDateYears.Text + "/" + txtBillingDateMonth.Text + "/" + cmbBillingDateType.Text);
            }
            string tokuisakiCode = txtCustomerCode.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string tougetu = txtBillingDateYears.Text;
            int tuki;
            int.TryParse(txtBillingDateMonth.Text, out tuki);
            if (tuki < 10) tougetu += "0";
            tougetu += txtBillingDateMonth.Text;

            sql = string.Empty;
            sql += "SELECT tm.* " + "\r";
            sql += "     , mm.kubunName " + "\r";
            sql += "FROM(SELECT * FROM tokuisaki_master) tm " + "\r";
            sql += "INNER JOIN(SELECT * FROM meisyo_master WHERE meisyoCode = '010') mm " + "\r";
            sql += "ON(tm.kaisyuSaito = mm.kubun) " + "\r";
            sql += "WHERE 1 = 1 " + "\r";
            if (!string.IsNullOrEmpty(tokuisakiCode)) sql += "AND tm.tokuisakiCode = '" + tokuisakiCode + "' " + "\r";
            if (!string.IsNullOrEmpty(jigyousyoCode) && !cmbAllValue.Equals(jigyousyoCode)) sql += "AND tm.jigyousyoCode = '" + jigyousyoCode + "' " + "\r";
            sql += "AND tm.shimebi = '" + billingDateType + "' " + "\r";
            DataTable tokuisakiDt = selectDb.executeNoneLockSelect(sql);

            if (tokuisakiDt == null || tokuisakiDt.Rows.Count == 0) return kaisyuhyo;

            sql = string.Empty;
            sql += "SELECT '" + Convert.ToString(seikyubi.Year) + "' AS nen " + "\r";
            sql += "     , '" + Convert.ToString(seikyubi.Month) + "' AS tuki " + "\r";
            sql += "     , '" + Convert.ToString(seikyubi.Day) + "' AS shimebi " + "\r";
            sql += "     , tm.tokuisakiCode AS tokuisakiCd " + "\r";
            sql += "     , tm.jigyousyoCode AS jigyoshoCd " + "\r";
            sql += "     , tm.tokuisakiName AS tokuisakiNm " + "\r";
            sql += "     , tm.jigyousyoName AS jigyoshoNm " + "\r";
            sql += "     , IFNULL(ts.kurikosi, 0) AS zengetuZan " + "\r";
            sql += "     , IFNULL(ts.zeikomiSeikyu, 0) AS kaisyusubekiKingaku " + "\r";
            sql += "     , IFNULL(ts2.nyukin, 0) AS tougetukaishuzakak " + "\r";
            sql += "     , CASE WHEN IFNULL(ts.zeikomiSeikyu, 0) = 0 " + "\r";
            sql += "            THEN 0 " + "\r";
            sql += "            ELSE TRUNCATE((IFNULL(ts2.nyukin, 0) / (IFNULL(ts.zeikomiSeikyu, 0)) * 100) + 0.5, 0) " + "\r";
            sql += "       END AS kaishuritu " + "\r";
            sql += "     , mm.kubunName AS saito " + "\r";
            sql += "FROM (SELECT * FROM tokuisaki_master WHERE seikyuKubun = '0') tm " + "\r";
            sql += "INNER JOIN ( " + "\r";
            sql += "            SELECT ts.tokuisakiCode " + "\r";
            sql += "                 , ts.jigyousyoCode " + "\r";
            sql += "                 , ts.shimeNengetu " + "\r";
            sql += "                 , ts2.kurikosi " + "\r";
            sql += "                 , ts2.zeikomiSeikyu " + "\r";
            sql += "            FROM (SELECT tokuisakiCode " + "\r";
            sql += "                       , jigyousyoCode " + "\r";
            sql += "                       , shimeNengetu " + "\r";
            sql += "                       , MAX(seikyuNo) AS seikyuNo " + "\r";
            sql += "                  FROM tokuisaki_seikyu " + "\r";
            sql += "                  GROUP BY tokuisakiCode, jigyousyoCode, shimeNengetu) ts " + "\r";
            sql += "                  INNER JOIN tokuisaki_seikyu ts2 " + "\r";
            sql += "                  ON (ts.seikyuNo = ts2.seikyuNo) " + "\r";
            sql += "           ) ts " + "\r";
            sql += "ON (tm.tokuisakiCode = ts.tokuisakiCode AND tm.jigyousyoCode = ts.jigyousyoCode) " + "\r";
            sql += "LEFT JOIN ( " + "\r";
            sql += "            SELECT tokuisakiCode " + "\r";
            sql += "                 , jigyousyoCode " + "\r";
            sql += "                 , SUM(IFNULL(nyukin, 0)) AS nyukin " + "\r";
            sql += "            FROM tokuisaki_seikyu " + "\r";
            sql += "            WHERE shimeNengetu = '" + tougetu + "' " + "\r";
            sql += "            GROUP BY tokuisakiCode, jigyousyoCode " + "\r";
            sql += "          ) ts2 " + "\r";
            sql += "ON (tm.tokuisakiCode = ts2.tokuisakiCode AND tm.jigyousyoCode = ts2.jigyousyoCode) " + "\r";
            sql += "LEFT JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '010') mm " + "\r";
            sql += "ON(tm.kaisyuSaito = mm.kubun) " + "\r";
            sql += "WHERE 1 = 1 " + "\r";
            sql += "AND ( " + "\r";
            int kaisyuSaito;
            int beforeMonth;
            DateTime targetYMD;
            string targetYM;
            int rowIndex = 0;
            foreach (DataRow dRow in tokuisakiDt.Rows)
            {
                kaisyuSaito = Convert.ToInt16(dRow[DBFileLayout.MeisyoMasterFile.dcKubunName]);
                tokuisakiCode = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                jigyousyoCode = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                beforeMonth = ((int)commonLogic.RoundKingaku((kaisyuSaito / 30), Consts.RoundType.RoundUp)) * -1;
                targetYMD = seikyubi.AddMonths(beforeMonth);
                targetYM = Convert.ToString(targetYMD.Year);
                targetYM += (targetYMD.Month < 10 ? "0" : string.Empty) + Convert.ToString(targetYMD.Month);
                sql += (rowIndex == 0 ? "      " : "   OR ") + "(tm.tokuisakiCode = '"+ tokuisakiCode + "' ";
                sql += "AND tm.jigyousyoCode = '" + jigyousyoCode + "' ";
                sql += "AND ts.shimeNengetu = '" + targetYM + "') " + "\r";
                rowIndex++;
            }
            sql += "    ) ";


            DataTable kaisyuhyoDt = selectDb.executeNoneLockSelect(sql);

            DataRow newRow;
            foreach (DataRow dRow in kaisyuhyoDt.Rows)
            {
                newRow = kaisyuhyo.Tables["dtblUrikakekinKaisyuhyo"].NewRow();
                newRow["nen"] = Convert.ToString(dRow["nen"]);
                newRow["tuki"] = Convert.ToString(dRow["tuki"]);
                newRow["shimebi"] = Convert.ToString(dRow["shimebi"]);
                newRow["tokuisakiCd"] = Convert.ToString(dRow["tokuisakiCd"]);
                newRow["jigyoshoCd"] = Convert.ToString(dRow["jigyoshoCd"]);
                newRow["tokuisakiNm"] = Convert.ToString(dRow["tokuisakiNm"]);
                newRow["jigyoshoNm"] = Convert.ToString(dRow["jigyoshoNm"]);
                newRow["zengetuZan"] = Convert.ToDecimal(dRow["zengetuZan"]).ToString("#,##0");
                newRow["kaisyusubekiKingaku"] = Convert.ToDecimal(dRow["kaisyusubekiKingaku"]).ToString("#,##0");
                newRow["tougetukaishuzakak"] = Convert.ToDecimal(dRow["tougetukaishuzakak"]).ToString("#,##0");
                newRow["kaishuritu"] = Convert.ToDecimal(dRow["kaishuritu"]).ToString("#,##0") + "％";
                newRow["saito"] = Convert.ToString(dRow["saito"]);
                kaisyuhyo.Tables["dtblUrikakekinKaisyuhyo"].Rows.Add(newRow.ItemArray);
            }

            int maxPageRow = 23;
            int LackRowCount = maxPageRow - (kaisyuhyo.Tables["dtblUrikakekinKaisyuhyo"].Rows.Count % maxPageRow);
            if (LackRowCount == maxPageRow) LackRowCount = 0;

            while (LackRowCount > 0)
            {
                kaisyuhyo.Tables["dtblUrikakekinKaisyuhyo"].Rows.Add();
                LackRowCount--;
            }

            return kaisyuhyo;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtBillingDateYears.Text) ||
                string.IsNullOrEmpty(txtBillingDateMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblBillingDate.Text));
                return;
            }
            dtblUrikakekinKaisyuhyo kaisyuhyo = getData();
            if (kaisyuhyo.Tables["dtblUrikakekinKaisyuhyo"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptUrikakekinKaishuhyo1.SetDataSource(kaisyuhyo);


            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptUrikakekinKaishuhyo1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptUrikakekinKaishuhyo1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptUrikakekinKaishuhyo1.PrintOptions.PaperOrientation)
                                                                     , rptUrikakekinKaishuhyo1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptUrikakekinKaishuhyo1.PrintToPrinter(printerSettings
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
            cmbBillingDateType.Enabled = true;
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
                    cmbBillingDateType.SelectedValue = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcShimebi]);
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
                    cmbBillingDateType.SelectedValue = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcShimebi]);
                }
                setOfficesCmb(txtCustomerCode.Text, string.Empty);
                cmbBillingDateType.Enabled = false;
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
            txtBillingDateYears.MaxLength = 4;  // 請求年月日(年)
            txtBillingDateMonth.MaxLength = 2;  // 請求年月日(月)
            txtCustomerCode.MaxLength = 5;      // 得意先ｺｰﾄﾞ

            // 入力制御イベント設定
            txtBillingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(年):数字のみ入力可
            txtBillingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(月):数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 得意先ｺｰﾄﾞ    :数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
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
            commonLogic.setComboBoxDataSource(ref cmbBillingDateType, tightenTypeDt, "kubun", "kubunName");
            cmbBillingDateType.DropDownStyle = cmbStyle;
            cmbBillingDateType.SelectedIndex = 0;
        }
        #endregion

        #endregion
    }
}
