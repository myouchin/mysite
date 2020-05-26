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

namespace PrintInstructions
{
    /// <summary>
    ///得意先別日別入金一覧表出力画面
    /// </summary>
    public partial class frmNyukinIchiran : ChildBaseForm
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
        /// <summary>
        /// 入金種別
        /// </summary>
        private enum NyukinSyubetu
        {
            Genkin = 0
          , Hurikomi = 1
          , Tesuryo = 2
          , Kogitte = 3
          , Tegata = 4
          , TegataWaribiki = 5
          , Sousai = 6
          , Ribeto = 7
          , Densai = 8
          , Tyousei = 9
          , Sonota = 10
        }

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmNyukinIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetDateYears.Text = string.Empty;
            txtTargetDateMonth.Text = string.Empty;
            commonLogic = new CommonLogic();
            DialogResult = DialogResult.None;

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

        #region 年月フォーカスインイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 年月フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDate_Leave(object sender, EventArgs e)
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
            if (c.Name.Equals(txtTargetDateYears.Name) ||
                c.Name.Equals(txtTargetDateMonth.Name) ||
                c.Name.Equals(dtpTargetDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetDate_Leave);
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
        private dtblTokuisakibetuHibetuNyukinIchiran getData()
        {
            dtblTokuisakibetuHibetuNyukinIchiran nyukinIchiran = new dtblTokuisakibetuHibetuNyukinIchiran();
            DBCommon selectDb = new DBCommon();
            string nen = txtTargetDateYears.Text;
            string tuki = txtTargetDateMonth.Text;
            DateTime targetDateFrom = Convert.ToDateTime(nen + "-" + tuki + "-01");
            DateTime targetDateTo = targetDateFrom.AddMonths(1).AddDays(-1);
            string sql = string.Empty;
            string baseSql = string.Empty;
            baseSql += "SELECT nyukinData.* ";
            baseSql += "     , tm.tokuisakiName ";
            baseSql += "     , tm.jigyousyoName ";
            baseSql += "FROM ( ";
            baseSql += "       {0} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {1} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {2} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {3} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {4} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {5} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {6} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {7} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {8} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {9} ";
            baseSql += "       UNION ALL ";
            baseSql += "       {10} ";
            baseSql += ") nyukinData ";
            baseSql += "INNER JOIN (SELECT * FROM tokuisaki_master) tm ";
            baseSql += "ON(nyukinData.tokuisakiCode = tm.tokuisakiCode AND nyukinData.jigyousyoCode = tm.jigyousyoCode) ";
            baseSql += "ORDER BY nyukinData.nyukinHizuke, nyukinData.tokuisakiCode, nyukinData.jigyousyoCode, nyukinData.nyukinShubetu ";
            string nyukinShubetuSql = string.Empty;
            nyukinShubetuSql += "       SELECT DATE_FORMAT(nyukinHizuke, '%e') AS hi ";
            nyukinShubetuSql += "            , nyukinHizuke ";
            nyukinShubetuSql += "            , tokuisakiCode ";
            nyukinShubetuSql += "            , jigyousyoCode ";
            nyukinShubetuSql += "            , SUM(IFNULL({0}, 0)) AS nyukingaku ";
            nyukinShubetuSql += "            , {1} AS nyukinShubetu ";
            nyukinShubetuSql += "            , '{2}' AS nyukinShubetuName ";
            nyukinShubetuSql += "       FROM nyukin ";
            nyukinShubetuSql += "       WHERE IFNULL({0}, 0) <> 0 ";
            nyukinShubetuSql += "       AND nyukinHizuke >= '" + targetDateFrom + "' ";
            nyukinShubetuSql += "       AND nyukinHizuke <= '" + targetDateTo + "' ";
            nyukinShubetuSql += "       GROUP BY tokuisakiCode, jigyousyoCode, nyukinHizuke ";
            sql = string.Format(baseSql
                              , string.Format(nyukinShubetuSql, "genkin", NyukinSyubetu.Genkin.GetHashCode(), "現金")
                              , string.Format(nyukinShubetuSql, "hurikomi", NyukinSyubetu.Hurikomi.GetHashCode(), "振込")
                              , string.Format(nyukinShubetuSql, "tesuryo", NyukinSyubetu.Tesuryo.GetHashCode(), "手数料")
                              , string.Format(nyukinShubetuSql, "kogitte", NyukinSyubetu.Kogitte.GetHashCode(), "小切手")
                              , string.Format(nyukinShubetuSql, "tegata", NyukinSyubetu.Tegata.GetHashCode(), "手形")
                              , string.Format(nyukinShubetuSql, "tegataWaribiki", NyukinSyubetu.TegataWaribiki.GetHashCode(), "手形割引")
                              , string.Format(nyukinShubetuSql, "sousai", NyukinSyubetu.Sousai.GetHashCode(), "相殺")
                              , string.Format(nyukinShubetuSql, "ribeto", NyukinSyubetu.Ribeto.GetHashCode(), "リベート")
                              , string.Format(nyukinShubetuSql, "densai", NyukinSyubetu.Densai.GetHashCode(), "でんさい")
                              , string.Format(nyukinShubetuSql, "tyousei", NyukinSyubetu.Tyousei.GetHashCode(), "調整")
                              , string.Format(nyukinShubetuSql, "sonota", NyukinSyubetu.Sonota.GetHashCode(), "その他"));
            DataTable nyukinDt = selectDb.executeNoneLockSelect(sql);

            DataRow newRow;
            decimal dec;
            int nyukinShubetu;
            int topPageRowCount = 21;
            int otherPageRowCount = 22;
            string wkTokuisakiCode = string.Empty;
            string wkJigyousyoCode = string.Empty;
            string wkHi = string.Empty;
            decimal genkin = decimal.Zero;
            decimal hurikomi = decimal.Zero;
            decimal tesuryo = decimal.Zero;
            decimal kogitte = decimal.Zero;
            decimal tegata = decimal.Zero;
            decimal tegataWaribiki = decimal.Zero;
            decimal sousai = decimal.Zero;
            decimal ribeto = decimal.Zero;
            decimal densai = decimal.Zero;
            decimal tyousei = decimal.Zero;
            decimal sonota = decimal.Zero;
            decimal goukei = decimal.Zero;
            int pageCount = 0;
            int rowCount = 0;
            foreach (DataRow nyukinRow in nyukinDt.Rows)
            {
                if (rowCount == 0) pageCount++;
                rowCount++;
                newRow = nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukin"].NewRow();
                nyukinShubetu = Convert.ToInt16(nyukinRow["nyukinShubetu"]);
                decimal.TryParse(Convert.ToString(nyukinRow["nyukingaku"]), out dec);
                newRow["nen"] = nen;
                newRow["tuki"] = tuki;
                if (!wkHi.Equals(Convert.ToString(nyukinRow["hi"])) ||
                    !wkTokuisakiCode.Equals(Convert.ToString(nyukinRow["tokuisakiCode"])) ||
                    !wkJigyousyoCode.Equals(Convert.ToString(nyukinRow["jigyousyoCode"])) ||
                    rowCount == 1)
                {
                    newRow["hi"] = Convert.ToString(nyukinRow["hi"]);
                    newRow["tokuisakiCd"] = Convert.ToString(nyukinRow["tokuisakiCode"]);
                    newRow["tokuisakiNm"] = Convert.ToString(nyukinRow["tokuisakiName"]);
                    newRow["jigyoNm"] = Convert.ToString(nyukinRow["jigyousyoName"]);
                    wkHi = Convert.ToString(nyukinRow["hi"]);
                    wkTokuisakiCode = Convert.ToString(nyukinRow["tokuisakiCode"]);
                    wkJigyousyoCode = Convert.ToString(nyukinRow["jigyousyoCode"]);
                }
                newRow["nyukingaku"] = dec.ToString("#,##0");
                newRow["nyukinSyubetu"] = Convert.ToString(nyukinRow["nyukinShubetuName"]);
                nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukin"].Rows.Add(newRow.ItemArray);
                if (NyukinSyubetu.Genkin.GetHashCode() == nyukinShubetu)
                {
                    genkin += dec;
                }
                else if (NyukinSyubetu.Hurikomi.GetHashCode() == nyukinShubetu)
                {
                    hurikomi += dec;
                }
                else if (NyukinSyubetu.Tesuryo.GetHashCode() == nyukinShubetu)
                {
                    tesuryo += dec;
                }
                else if (NyukinSyubetu.Kogitte.GetHashCode() == nyukinShubetu)
                {
                    kogitte += dec;
                }
                else if (NyukinSyubetu.Tegata.GetHashCode() == nyukinShubetu)
                {
                    tegata += dec;
                }
                else if (NyukinSyubetu.TegataWaribiki.GetHashCode() == nyukinShubetu)
                {
                    tegataWaribiki += dec;
                }
                else if (NyukinSyubetu.Sousai.GetHashCode() == nyukinShubetu)
                {
                    sousai += dec;
                }
                else if (NyukinSyubetu.Ribeto.GetHashCode() == nyukinShubetu)
                {
                    ribeto += dec;
                }
                else if (NyukinSyubetu.Densai.GetHashCode() == nyukinShubetu)
                {
                    densai += dec;
                }
                else if (NyukinSyubetu.Tyousei.GetHashCode() == nyukinShubetu)
                {
                    tyousei += dec;
                }
                else if (NyukinSyubetu.Sonota.GetHashCode() == nyukinShubetu)
                {
                    sonota += dec;
                }
                goukei += dec;

                if ((pageCount == 1 && rowCount == topPageRowCount) ||
                    (pageCount > 1 && rowCount == otherPageRowCount))
                {
                    rowCount = 0;
                }
            }
            int addEmptyRowCount = topPageRowCount + ((pageCount - 1) * otherPageRowCount) - (nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukin"].Rows.Count + 2);
            while (addEmptyRowCount > 0)
            {
                newRow = nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukin"].NewRow();
                newRow["nen"] = nen;
                newRow["tuki"] = tuki;
                nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukin"].Rows.Add(newRow.ItemArray);
                addEmptyRowCount--;
            }
             newRow = nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukinG"].NewRow();
            newRow["nen"] = nen;
            newRow["tuki"] = tuki;
            newRow["genkin"] = genkin.ToString("#,##0");
            newRow["furikomi"] = hurikomi.ToString("#,##0");
            newRow["tesuryo"] = tesuryo.ToString("#,##0");
            newRow["kogite"] = kogitte.ToString("#,##0");
            newRow["tegata"] = tegata.ToString("#,##0");
            newRow["tegatawaribiki"] = tegataWaribiki.ToString("#,##0");
            newRow["sosai"] = sousai.ToString("#,##0");
            newRow["rebate"] = ribeto.ToString("#,##0");
            newRow["densai"] = densai.ToString("#,##0");
            newRow["cyosei"] = tyousei.ToString("#,##0");
            newRow["sonota"] = sonota.ToString("#,##0");
            newRow["gokei"] = goukei.ToString("#,##0");
            nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukinG"].Rows.Add(newRow.ItemArray);

            return nyukinIchiran;
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
            dtblTokuisakibetuHibetuNyukinIchiran nyukinIchiran = getData();
            if (nyukinIchiran.Tables["dtblTokuisakibetuHibetuNyukin"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptTokuisakibetuHibetuNyukinIchiran1.SetDataSource(nyukinIchiran);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptTokuisakibetuHibetuNyukinIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptTokuisakibetuHibetuNyukinIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptTokuisakibetuHibetuNyukinIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptTokuisakibetuHibetuNyukinIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptTokuisakibetuHibetuNyukinIchiran1.PrintToPrinter(printerSettings
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
            txtTargetDateYears.MaxLength = 4;   // 年月(年)
            txtTargetDateMonth.MaxLength = 2;   // 年月(月)

            // 入力制御イベント設定
            txtTargetDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(年):数字のみ入力可
            txtTargetDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(月):数字のみ入力可
        }
        #endregion

        #endregion
    }
}
