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
    public partial class frmKenbetsuHibetsuUriageSyukei : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgSetGridData = false;
        private enum LastInputDateType
        {
            None = 0
          , TargetYM = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private CommonLogic commonLogic;
        private DBMeisyoMaster meisyoMaster;

        #region 帳票金額集計クラス
        /// <summary>
        /// 帳票金額集計クラス
        /// </summary>
        public class PrintKingakuInfo
        {
            private decimal aomori = decimal.Zero;
            private decimal iwate = decimal.Zero;
            private decimal akita = decimal.Zero;
            private decimal miyagi = decimal.Zero;
            private decimal yamagata = decimal.Zero;
            private decimal fukushima = decimal.Zero;
            private decimal kengai = decimal.Zero;
            private decimal goukei = decimal.Zero;
            private decimal kouji = decimal.Zero;
            private decimal shire = decimal.Zero;
            public decimal Aomori { get { return aomori; } set { aomori = value; } }
            public decimal Iwate { get { return iwate; } set { iwate = value; } }
            public decimal Akita { get { return akita; } set { akita = value; } }
            public decimal Miyagi { get { return miyagi; } set { miyagi = value; } }
            public decimal Yamagata { get { return yamagata; } set { yamagata = value; } }
            public decimal Fukushima { get { return fukushima; } set { fukushima = value; } }
            public decimal Kengai { get { return kengai; } set { kengai = value; } }
            public decimal Goukei { get { return goukei; } set { goukei = value; } }
            public decimal Kouji { get { return kouji; } set { kouji = value; } }
            public decimal Shire { get { return shire; } set { shire = value; } }
        }
        #endregion

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmKenbetsuHibetsuUriageSyukei()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            activeControlInfo = new ActiveControlInfo();
            txtTargetYMYears.Text = string.Empty;
            txtTargetYMMonth.Text = string.Empty;
            meisyoMaster = new DBMeisyoMaster();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
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
                    case LastInputDateType.TargetYM:
                        y = txtTargetYMYears.Text;
                        m = txtTargetYMMonth.Text;
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
                    else if (LastInputDateType.TargetYM.Equals(lastInputDateType))
                    {
                        txtTargetYMYears.Focus();
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
            // 入力情報設定
            setInputInfo();
        }
        #endregion

        #region 年月のフォーカスインイベント
        /// <summary>
        /// 年月のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tightenDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYM)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 年月のフォーカスアウトイベント
        /// <summary>
        /// 年月のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tightenDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYM;
                if ((sender is TextBox))
                {
                    lastInputDateText = (TextBox)sender;
                }
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYM;
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

            // 年月の場合
            if (c.Name.Equals(txtTargetYMYears.Name) ||
                c.Name.Equals(txtTargetYMMonth.Name) ||
                c.Name.Equals(dtpTargetYM.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.tightenDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.tightenDate_Leave);
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
        /// 帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblKenbetuUriagNikkeihyo getData()
        {
            dtblKenbetuUriagNikkeihyo result = new dtblKenbetuUriagNikkeihyo();
            DBCommon selectDb = new DBCommon();
            DataTable printDt;
            DateTime targetDateFrom = Convert.ToDateTime(txtTargetYMYears.Text + "-" + txtTargetYMMonth.Text + "-" + "01");
            DateTime targetDateTo = targetDateFrom.AddMonths(1).AddDays(-1);
            DateTime wkDate = targetDateFrom;

            string sql = string.Empty;
            sql += "SELECT uh.denpyoHizuke ";
            sql += "     , CAST(DATE_FORMAT(uh.denpyoHizuke, '%d') AS SIGNED) AS day ";
            sql += "     , uh.chikuCode ";
            sql += "     , jh.flgKouji ";
            sql += "     , SUM(IFNULL(ub.kingaku, 0)) AS kingaku ";
            sql += "FROM ( ";
            sql += "      SELECT denpyoNo ";
            sql += "           , denpyoHizuke ";
            sql += "           , juchuNoTop ";
            sql += "           , juchuNoMid ";
            sql += "           , juchuNoBtm ";
            sql += "           , chikuCode ";
            sql += "      FROM uriage_header ";
            sql += "      WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "      AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "      AND denpyoHizuke <= '" + targetDateTo + "' ";
            sql += "     ) uh ";
            sql += "INNER JOIN ( ";
            sql += "            SELECT kubun ";
            sql += "                 , kubunName ";
            sql += "            FROM meisyo_master ";
            sql += "            WHERE meisyoCode = '004' ";
            sql += "           ) mm ";
            sql += "ON (uh.chikuCode = mm.kubun) ";
            sql += "INNER JOIN ( ";
            sql += "            SELECT juchuNoTop ";
            sql += "                 , juchuNoMid ";
            sql += "                 , juchuNoBtm ";
            sql += "                 , CASE WHEN zairyoKoujiKubun = '02' ";
            sql += "                        THEN 1 ";
            sql += "                        ELSE 0 ";
            sql += "                   END AS flgKouji ";
            sql += "            FROM juchu_header ";
            sql += "           ) jh ";
            sql += "ON (uh.juchuNoTop = jh.juchuNoTop AND uh.juchuNoMid = jh.juchuNoMid AND uh.juchuNoBtm = jh.juchuNoBtm) ";
            sql += "INNER JOIN ( ";
            sql += "            SELECT * ";
            sql += "            FROM uriage_body ";
            sql += "            WHERE IFNULL(flgPrint, 0) = 1 ";
            sql += "           ) ub ";
            sql += "ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "GROUP BY uh.denpyoHizuke, uh.chikuCode, jh.flgKouji ";
            sql += "ORDER BY uh.denpyoHizuke, uh.chikuCode, jh.flgKouji ";
            printDt = selectDb.executeNoneLockSelect(sql).Copy();

            DataRow newRow;
            PrintKingakuInfo printKingakuInfo;
            decimal aomoriTotal = decimal.Zero;
            decimal iwateTotal = decimal.Zero;
            decimal akitaTotal = decimal.Zero;
            decimal mitagiTotal = decimal.Zero;
            decimal yamagataTotal = decimal.Zero;
            decimal fukushimaTotal = decimal.Zero;
            decimal kengaiTotal = decimal.Zero;
            decimal goukeiTotal = decimal.Zero;
            decimal koujiTotal = decimal.Zero;
            decimal shireTotal = decimal.Zero;
            while (wkDate <= targetDateTo)
            {
                // 県別日別金額集計処理実行
                printKingakuInfo = getPrintKingaku(printDt, wkDate.Day);

                newRow = result.Tables["dtblKenbetuUriageNikkeihyo"].NewRow();
                newRow["nen"] = Convert.ToString(wkDate.Year);
                newRow["tuki"] = Convert.ToString(wkDate.Month);
                newRow["hi"] = Convert.ToString(wkDate.Day);
                newRow["aomori"] = printKingakuInfo.Aomori.ToString("#,##0");
                newRow["iwate"] = printKingakuInfo.Iwate.ToString("#,##0");
                newRow["akita"] = printKingakuInfo.Akita.ToString("#,##0");
                newRow["miyagi"] = printKingakuInfo.Miyagi.ToString("#,##0");
                newRow["yamagata"] = printKingakuInfo.Yamagata.ToString("#,##0");
                newRow["fukishima"] = printKingakuInfo.Fukushima.ToString("#,##0");
                newRow["kengai"] = printKingakuInfo.Kengai.ToString("#,##0");
                newRow["goukei"] = printKingakuInfo.Goukei.ToString("#,##0");
                newRow["kouji"] = printKingakuInfo.Kouji.ToString("#,##0");
                newRow["siiresaki"] = printKingakuInfo.Shire.ToString("#,##0");
                result.Tables["dtblKenbetuUriageNikkeihyo"].Rows.Add(newRow.ItemArray);

                aomoriTotal += printKingakuInfo.Aomori;
                iwateTotal += printKingakuInfo.Iwate;
                akitaTotal += printKingakuInfo.Akita;
                mitagiTotal += printKingakuInfo.Miyagi;
                yamagataTotal += printKingakuInfo.Yamagata;
                fukushimaTotal += printKingakuInfo.Fukushima;
                kengaiTotal += printKingakuInfo.Kengai;
                goukeiTotal += printKingakuInfo.Goukei;
                koujiTotal += printKingakuInfo.Kouji;
                shireTotal += printKingakuInfo.Shire;

                wkDate = wkDate.AddDays(1);
            }

            newRow = result.Tables["dtblKenbetuUriageNikkeihyoTotal"].NewRow();
            newRow["aomori"] = aomoriTotal.ToString("#,##0");
            newRow["iwate"] = iwateTotal.ToString("#,##0");
            newRow["akita"] = akitaTotal.ToString("#,##0");
            newRow["miyagi"] = mitagiTotal.ToString("#,##0");
            newRow["yamagata"] = yamagataTotal.ToString("#,##0");
            newRow["fukushima"] = fukushimaTotal.ToString("#,##0");
            newRow["kengai"] = kengaiTotal.ToString("#,##0");
            newRow["goukei"] = goukeiTotal.ToString("#,##0");
            newRow["kouji"] = koujiTotal.ToString("#,##0");
            newRow["shire"] = shireTotal.ToString("#,##0");
            result.Tables["dtblKenbetuUriageNikkeihyoTotal"].Rows.Add(newRow.ItemArray);

            return result;
        }
        #endregion

        #region 県別日別金額集計処理
        /// <summary>
        /// 県別日別金額集計処理
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private PrintKingakuInfo getPrintKingaku(DataTable dt, int day)
        {
            PrintKingakuInfo printKingakuInfo = new PrintKingakuInfo();
            decimal wkDec;
            int wkFlgKouji = 0;
            bool flgKouji = false;

            var aomoriQuery = dt.AsEnumerable().Where(p => "02".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) && p.Field<int>("day") == day);
            var iwateQuery = dt.AsEnumerable().Where(p => "03".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) && p.Field<int>("day") == day);
            var akitaQuery = dt.AsEnumerable().Where(p => "05".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) && p.Field<int>("day") == day);
            var miyagiQuery = dt.AsEnumerable().Where(p => "04".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) && p.Field<int>("day") == day);
            var yamagataQuery = dt.AsEnumerable().Where(p => "06".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) && p.Field<int>("day") == day);
            var fukushimaQuery = dt.AsEnumerable().Where(p => "07".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) && p.Field<int>("day") == day);
            var kengaiQuery = dt.AsEnumerable().Where(p => !"02".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) &&
                                                           !"03".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) &&
                                                           !"05".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) &&
                                                           !"04".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) &&
                                                           !"06".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) &&
                                                           !"07".Equals(p.Field<string>(DBFileLayout.UriageHeaderFile.dcChikuCode)) &&
                                                           p.Field<int>("day") == day);

            #region 青森金額集計
            foreach (DataRow aomoriRow in aomoriQuery)
            {
                int.TryParse(Convert.ToString(aomoriRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(aomoriRow["kingaku"]), out wkDec);
                printKingakuInfo.Aomori += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            #region 岩手金額集計
            foreach (DataRow iwateRow in iwateQuery)
            {
                int.TryParse(Convert.ToString(iwateRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(iwateRow["kingaku"]), out wkDec);
                printKingakuInfo.Iwate += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            #region 秋田金額集計
            foreach (DataRow akitaRow in akitaQuery)
            {
                int.TryParse(Convert.ToString(akitaRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(akitaRow["kingaku"]), out wkDec);
                printKingakuInfo.Akita += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            #region 宮城金額集計
            foreach (DataRow miyagiRow in miyagiQuery)
            {
                int.TryParse(Convert.ToString(miyagiRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(miyagiRow["kingaku"]), out wkDec);
                printKingakuInfo.Miyagi += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            #region 山形金額集計
            foreach (DataRow yamagataRow in yamagataQuery)
            {
                int.TryParse(Convert.ToString(yamagataRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(yamagataRow["kingaku"]), out wkDec);
                printKingakuInfo.Yamagata += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            #region 福島金額集計
            foreach (DataRow fukushimaRow in fukushimaQuery)
            {
                int.TryParse(Convert.ToString(fukushimaRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(fukushimaRow["kingaku"]), out wkDec);
                printKingakuInfo.Fukushima += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            #region 県外金額集計
            foreach (DataRow kengaiRow in kengaiQuery)
            {
                int.TryParse(Convert.ToString(kengaiRow["flgKouji"]), out wkFlgKouji);
                flgKouji = wkFlgKouji == 0 ? false : true;
                decimal.TryParse(Convert.ToString(kengaiRow["kingaku"]), out wkDec);
                printKingakuInfo.Kengai += wkDec;
                printKingakuInfo.Goukei += wkDec;
                if (flgKouji)
                {
                    printKingakuInfo.Kouji += wkDec;
                }
                else
                {
                    printKingakuInfo.Shire += wkDec;
                }
            }
            #endregion

            return printKingakuInfo;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtTargetYMYears.Text) ||
                string.IsNullOrEmpty(txtTargetYMMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblTargetYM.Text));
                return;
            }
            dtblKenbetuUriagNikkeihyo seikyusyo = getData();
            if (seikyusyo.Tables["dtblKenbetuUriageNikkeihyo"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptKenbetuUriageNikkeihyo1.SetDataSource(seikyusyo);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptKenbetuUriageNikkeihyo1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptKenbetuUriageNikkeihyo1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKenbetuUriageNikkeihyo1.PrintOptions.PaperOrientation)
                                                                     , rptKenbetuUriageNikkeihyo1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptKenbetuUriageNikkeihyo1.PrintToPrinter(printerSettings
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTargetYMYears.MaxLength = 4;  // 年月(年)
            txtTargetYMMonth.MaxLength = 2;  // 年月(月)

            // 入力制御イベント設定
            txtTargetYMYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 年月(年)  :数字のみ入力可
            txtTargetYMMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 年月(月)  :数字のみ入力可
        }
        #endregion

        #endregion
    }
}
