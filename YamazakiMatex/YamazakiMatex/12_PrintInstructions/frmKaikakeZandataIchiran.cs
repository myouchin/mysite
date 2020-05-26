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
    /// 買掛残高一覧表出力画面
    /// </summary>
    public partial class frmKaikakeZandataIchiran : ChildBaseForm
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
        private bool isYMPrint = false;
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmKaikakeZandataIchiran(bool ymPrint)
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            activeControlInfo = new ActiveControlInfo();
            txtTargetYMYears.Text = string.Empty;
            txtTargetYMMonth.Text = string.Empty;
            commonLogic = new CommonLogic();
            DialogResult = DialogResult.None;
            isYMPrint = ymPrint;

            if (isYMPrint)
            {
                lblTargetY.Visible = false;
                pnlTargetY.Visible = false;
            }
            else
            {
                lblTargetYM.Visible = false;
                pnlTargetYM.Visible = false;
                lblTargetY.Location = new Point(lblTargetY.Location.X, lblTargetYM.Location.Y);
                pnlTargetY.Location = new Point(pnlTargetY.Location.X, pnlTargetYM.Location.Y);
            }

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
                    else if (LastInputDateType.TargetDate.Equals(lastInputDateType))
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

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJyuchachuIchiran_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            txtTargetYMYears.Text = Convert.ToString(syoriDate.Year);
            txtTargetYMMonth.Text = Convert.ToString(syoriDate.Month);
            txtTargetYYears.Text = Convert.ToString(syoriDate.Year);
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
            if (c.Name.Equals(txtTargetYMYears.Name) ||
                c.Name.Equals(txtTargetYMMonth.Name) ||
                c.Name.Equals(dtpTargetYM.Name))
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
        private dtblKaikakeZandakaIchiran getData()
        {
            dtblKaikakeZandakaIchiran zandakaIchiran = new dtblKaikakeZandakaIchiran();
            DBCommon selectDb = new DBCommon();
            string sql = string.Empty;
            int onePageRowCount = 16;
            string printNen;
            string printTuki;

            if (isYMPrint)
            {
                DateTime targetDate = Convert.ToDateTime(txtTargetYMYears.Text + "-" + txtTargetYMMonth.Text + "-01");
                string targetY;
                string targetM = Convert.ToString(targetDate.Month);
                if (targetDate.Month >= 10)
                {
                    targetY = txtTargetYMYears.Text;
                }
                else
                {
                    targetY = Convert.ToString(targetDate.Year - 1);
                }
                string beforeY = Convert.ToString(Convert.ToInt16(targetY) - 1);
                string beforeM = Convert.ToString(targetDate.Month - 1);
                if (beforeM == "0") beforeM = Convert.ToString(12);

                sql += "SELECT sk.shiresakiCode AS shiireCd ";
                sql += "     , sm.shiresakiName AS shiireNm ";
                sql += "     , IFNULL(ask." + beforeM + "GatsuKurikoshi, 0) AS zengetuZan ";
                sql += "     , IFNULL(sk." + targetM + "GatsuShire, 0) AS togetuShiire ";
                sql += "     , IFNULL(sk." + targetM + "GatsuSyouhiZei, 0) AS togetuShohizei ";
                sql += "     , IFNULL(sk." + targetM + "GatsuShire + sk." + targetM + "GatsuSyouhiZei, 0) AS togetuShiireG ";
                sql += "     , IFNULL(sk." + targetM + "GatsuShiharai, 0) AS togetuShiharai ";
                sql += "     , IFNULL(sk." + targetM + "GatsuKurikoshi, 0) AS togetuZan ";
                sql += "FROM (SELECT * FROM shiresaki_kaikake WHERE nendo = '" + targetY + "') sk ";
                sql += "LEFT JOIN (SELECT * FROM shiresaki_master) sm ";
                sql += "ON (sk.shiresakiCode = sm.shiresakiCode) ";
                sql += "LEFT JOIN (SELECT * FROM shiresaki_kaikake WHERE nendo = '" + beforeY + "') ask ";
                sql += "ON (sk.shiresakiCode = ask.shiresakiCode) ";
                sql += "ORDER BY sk.shiresakiCode ";

                printNen = txtTargetYMYears.Text;
                printTuki = txtTargetYMMonth.Text;

            }
            else
            {
                string targetY = txtTargetYYears.Text;
                sql += "SELECT sk.shiresakiCode AS shiireCd ";
                sql += "     , sm.shiresakiName AS shiireNm ";
                sql += "     , IFNULL(sk.zenNenKurikoshi, 0) AS zengetuZan ";
                sql += "     , IFNULL(sk.toNenShiire, 0) AS togetuShiire ";
                sql += "     , IFNULL(sk.toNenShohizei, 0) AS togetuShohizei ";
                sql += "     , IFNULL(sk.toNenShiire, 0) + IFNULL(sk.toNenShohizei, 0) AS togetuShiireG ";
                sql += "     , IFNULL(sk.toNenShiharai, 0) AS togetuShiharai ";
                sql += "     , IFNULL(sk.toNenZan, 0) AS togetuZan ";
                sql += "FROM (SELECT shiresakiCode ";
                sql += "           , zenNenKurikoshi ";
                sql += "           , IFNULL(10GatsuShire, 0) + IFNULL(11GatsuShire, 0) + IFNULL(12GatsuShire, 0) + IFNULL(1GatsuShire, 0) + IFNULL(2GatsuShire, 0) + IFNULL(3GatsuShire, 0) + IFNULL(4GatsuShire, 0) + IFNULL(5GatsuShire, 0) + IFNULL(6GatsuShire, 0) + IFNULL(7GatsuShire, 0) + IFNULL(8GatsuShire, 0) + IFNULL(9GatsuShire, 0) AS toNenShiire ";
                sql += "           , IFNULL(10GatsuSyouhiZei, 0) + IFNULL(11GatsuSyouhiZei, 0) + IFNULL(12GatsuSyouhiZei, 0) + IFNULL(1GatsuSyouhiZei, 0) + IFNULL(2GatsuSyouhiZei, 0) + IFNULL(3GatsuSyouhiZei, 0) + IFNULL(4GatsuSyouhiZei, 0) + IFNULL(5GatsuSyouhiZei, 0) + IFNULL(6GatsuSyouhiZei, 0) + IFNULL(7GatsuSyouhiZei, 0) + IFNULL(8GatsuSyouhiZei, 0) + IFNULL(9GatsuSyouhiZei, 0) AS toNenShohizei ";
                sql += "           , IFNULL(10GatsuShiharai, 0) + IFNULL(11GatsuShiharai, 0) + IFNULL(12GatsuShiharai, 0) + IFNULL(1GatsuShiharai, 0) + IFNULL(2GatsuShiharai, 0) + IFNULL(3GatsuShiharai, 0) + IFNULL(4GatsuShiharai, 0) + IFNULL(5GatsuShiharai, 0) + IFNULL(6GatsuShiharai, 0) + IFNULL(7GatsuShiharai, 0) + IFNULL(8GatsuShiharai, 0) + IFNULL(9GatsuShiharai, 0) AS toNenShiharai ";
                sql += "           , IFNULL(10GatsuKurikoshi, 0) + IFNULL(11GatsuKurikoshi, 0) + IFNULL(12GatsuKurikoshi, 0) + IFNULL(1GatsuKurikoshi, 0) + IFNULL(2GatsuKurikoshi, 0) + IFNULL(3GatsuKurikoshi, 0) + IFNULL(4GatsuKurikoshi, 0) + IFNULL(5GatsuKurikoshi, 0) + IFNULL(6GatsuKurikoshi, 0) + IFNULL(7GatsuKurikoshi, 0) + IFNULL(8GatsuKurikoshi, 0) + IFNULL(9GatsuKurikoshi, 0) AS toNenZan ";
                sql += "      FROM shiresaki_kaikake WHERE nendo = '" + targetY + "') sk ";
                sql += "LEFT JOIN (SELECT * FROM shiresaki_master) sm ";
                sql += "ON (sk.shiresakiCode = sm.shiresakiCode) ";
                sql += "ORDER BY sk.shiresakiCode ";

                printNen = txtTargetYYears.Text;
                printTuki = string.Empty;
            }

            DataTable printData = selectDb.executeNoneLockSelect(sql);
            if (printData == null || printData.Rows.Count == 0) return zandakaIchiran;

            decimal zengetuZan = decimal.Zero, togetuShiire = decimal.Zero, togetuShohizei = decimal.Zero, togetuShiireG = decimal.Zero, togetuShiharai = decimal.Zero, togetuZan = decimal.Zero;
            decimal zengetuZanG = decimal.Zero, togetuShiireG2 = decimal.Zero, togetuShohizeiG = decimal.Zero, togetuShiireGG = decimal.Zero, togetuShiharaiG = decimal.Zero, togetuZanG = decimal.Zero;
            DataRow newRow;
            foreach (DataRow printRow in printData.Rows)
            {
                decimal.TryParse(Convert.ToString(printRow["zengetuZan"]), out zengetuZan);
                decimal.TryParse(Convert.ToString(printRow["togetuShiire"]), out togetuShiire);
                decimal.TryParse(Convert.ToString(printRow["togetuShohizei"]), out togetuShohizei);
                decimal.TryParse(Convert.ToString(printRow["togetuShiireG"]), out togetuShiireG);
                decimal.TryParse(Convert.ToString(printRow["togetuShiharai"]), out togetuShiharai);
                decimal.TryParse(Convert.ToString(printRow["togetuZan"]), out togetuZan);

                zengetuZanG += zengetuZan;
                togetuShiireG2 += togetuShiire;
                togetuShohizeiG += togetuShohizei;
                togetuShiireGG += togetuShiireG;
                togetuShiharaiG += togetuShiharai;
                togetuZanG += togetuZan;

                newRow = zandakaIchiran.Tables["dtblKaikakeZandakaIchiran"].NewRow();
                newRow["nen"] = printNen;
                newRow["tuki"] = printTuki;
                newRow["shiireCd"] = Convert.ToString(printRow["shiireCd"]);
                newRow["shiireNm"] = Convert.ToString(printRow["shiireNm"]);
                newRow["zengetuZan"] = zengetuZan.ToString("#,##0");
                newRow["togetuShiire"] = togetuShiire.ToString("#,##0");
                newRow["togetuShohizei"] = togetuShohizei.ToString("#,##0");
                newRow["togetuShiireG"] = togetuShiireG.ToString("#,##0");
                newRow["togetuShiharai"] = togetuShiharai.ToString("#,##0");
                newRow["togetuZan"] = togetuZan.ToString("#,##0");
                zandakaIchiran.Tables["dtblKaikakeZandakaIchiran"].Rows.Add(newRow.ItemArray);
            }

            int addCount = onePageRowCount - ((zandakaIchiran.Tables["dtblKaikakeZandakaIchiran"].Rows.Count + 1) % onePageRowCount);
            if (addCount == onePageRowCount) addCount = 0;

            while (addCount > 0)
            {
                addCount--;
                newRow = zandakaIchiran.Tables["dtblKaikakeZandakaIchiran"].NewRow();
                newRow["nen"] = printNen;
                newRow["tuki"] = printTuki;
                zandakaIchiran.Tables["dtblKaikakeZandakaIchiran"].Rows.Add(newRow.ItemArray);
            }

            newRow = zandakaIchiran.Tables["dtblKaikakeZandakaIchiranG"].NewRow();
            newRow["nen"] = printNen;
            newRow["tuki"] = printTuki;
            newRow["zengetuZanG"] = zengetuZanG.ToString("#,##0");
            newRow["togetuShiireG"] = togetuShiireG2.ToString("#,##0");
            newRow["togetuShohizeiG"] = togetuShohizeiG.ToString("#,##0");
            newRow["togetuShiireGG"] = togetuShiireGG.ToString("#,##0");
            newRow["togetuShiharaiG"] = togetuShiharaiG.ToString("#,##0");
            newRow["togetuZanG"] = togetuZanG.ToString("#,##0");
            zandakaIchiran.Tables["dtblKaikakeZandakaIchiranG"].Rows.Add(newRow.ItemArray);

            return zandakaIchiran;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (isYMPrint)
            {
                if (string.IsNullOrEmpty(txtTargetYMYears.Text) ||
                    string.IsNullOrEmpty(txtTargetYMMonth.Text))
                {
                    errorOK(string.Format(Messages.M0020, lblTargetYM.Text));
                    return;
                }

                // 仕入先別買掛ファイル更新処理
                registKaikakeData();
            }
            else
            {
                if (string.IsNullOrEmpty(txtTargetYYears.Text))
                {
                    errorOK(string.Format(Messages.M0020, lblTargetY.Text));
                    return;
                }
            }

            dtblKaikakeZandakaIchiran zandakaIchiran = getData();
            if (zandakaIchiran.Tables["dtblKaikakeZandakaIchiran"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }

            if (isYMPrint)
            {
                rptKaikakeZandakaIchiranTuki1.SetDataSource(zandakaIchiran);
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptKaikakeZandakaIchiranTuki1;

                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptKaikakeZandakaIchiranTuki1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKaikakeZandakaIchiranTuki1.PrintOptions.PaperOrientation)
                                                                         , rptKaikakeZandakaIchiranTuki1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptKaikakeZandakaIchiranTuki1.PrintToPrinter(printerSettings
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
            else
            {
                rptKaikakeZandakaIchiranNen1.SetDataSource(zandakaIchiran);
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptKaikakeZandakaIchiranNen1;

                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptKaikakeZandakaIchiranNen1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKaikakeZandakaIchiranNen1.PrintOptions.PaperOrientation)
                                                                         , rptKaikakeZandakaIchiranNen1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptKaikakeZandakaIchiranNen1.PrintToPrinter(printerSettings
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
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTargetYMYears.MaxLength = 4;   // 年月(年)
            txtTargetYMMonth.MaxLength = 2;   // 年月(月)
            txtTargetYYears.MaxLength = 4;   // 年

            // 入力制御イベント設定
            txtTargetYMYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(年):数字のみ入力可
            txtTargetYMMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(月):数字のみ入力可
            txtTargetYYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 年:数字のみ入力可
        }
        #endregion

        #region 仕入先別買掛ファイル更新処理
        /// <summary>
        /// 仕入先別買掛ファイル更新処理
        /// </summary>
        private void registKaikakeData()
        {
            List<string> commands = new List<string>();
            DBCommon db = new DBCommon();
            string sql = string.Empty;

            string targetNendo;
            if (Convert.ToInt16(txtTargetYMMonth.Text) >= 10)
            {
                targetNendo = txtTargetYMYears.Text;
            }
            else
            {
                targetNendo = Convert.ToString(Convert.ToInt16(txtTargetYMYears.Text) - 1);
            }
            string beforeNendo = Convert.ToString(Convert.ToInt16(targetNendo) - 1);
            DateTime targetDateFrom = Convert.ToDateTime(txtTargetYMYears.Text + "-" + txtTargetYMMonth.Text + "-01");
            DateTime targetDateTo = targetDateFrom.AddMonths(1).AddDays(-1);

            DataTable shiresakiDt = db.executeNoneLockSelect("SELECT shiresakiCode FROM shiresaki_master WHERE kanriKubun IS NULL OR kanriKubun <> '9' ");
            DataTable existsDt;
            string shiresakiCode;
            foreach (DataRow shiresakiRow in shiresakiDt.Rows)
            {
                shiresakiCode = Convert.ToString(shiresakiRow["shiresakiCode"]);
                existsDt = db.executeNoneLockSelect("SELECT 1 FROM shiresaki_kaikake WHERE shiresakiCode = '" + shiresakiCode + "' AND nendo = '" + targetNendo + "' ");
                if (existsDt == null || existsDt.Rows.Count == 0) commands.Add("INSERT INTO shiresaki_kaikake (shiresakiCode, nendo) VALUES ('" + shiresakiCode + "', '" + targetNendo + "') ");
            }

            sql = string.Empty;
            sql += "UPDATE shiresaki_kaikake sk, ";
            sql += "( ";
            sql += " SELECT sm.shiresakiCode ";
            sql += "      , sm.shiresakiName ";
            sql += "      , IFNULL(shireData.shireKingaku, 0) AS shireKingaku ";
            sql += "      , IFNULL(shireData.shireShouhizei, 0) AS shireShouhizei ";
            sql += "      , IFNULL(shiharaiData.shiharaiKingaku, 0) AS shiharaiKingaku ";
            sql += "      , IFNULL(shireData.shireKingaku, 0) + IFNULL(shireData.shireShouhizei, 0) - IFNULL(shiharaiData.shiharaiKingaku, 0) AS zandaka ";
            sql += "      , IFNULL(zennen.9GatsuKurikoshi, 0) AS zennenKurikoshi ";
            sql += " FROM (SELECT shiresakiCode, shiresakiName FROM shiresaki_master WHERE kanriKubun IS NULL OR kanriKubun <> '9') sm ";
            sql += " LEFT JOIN (SELECT sh.shiresakiCode ";
            sql += "                 , SUM(sb.kingaku) AS shireKingaku ";
            sql += "                 , TRUNCATE((SUM(sb.kingaku) * (SELECT CASE WHEN STR_TO_DATE(koumoku2, '%Y%m%d') >= STR_TO_DATE('20191001', '%Y%m%d') ";
            sql += "                                                            THEN CAST(koumoku1 AS SIGNED) ";
            sql += "                                                            ELSE CAST(koumoku3 AS SIGNED) ";
            sql += "                                                       END ";
            sql += "                                                FROM kanri_master WHERE kanriCode = '00010') / 100) + 0.5, 0) AS shireShouhizei ";
            sql += "            FROM (SELECT shireNo ";
            sql += "                       , shiresakiCode ";
            sql += "                  FROM shire_header ";
            sql += "                  WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "                  AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "                  AND denpyoHizuke <= '" + targetDateTo + "' ) sh ";
            sql += "            INNER JOIN (SELECT shireNo, kingaku FROM shire_body) sb ";
            sql += "            ON (sh.shireNo = sb.shireNo) ";
            sql += "            GROUP BY sh.shiresakiCode) shireData ";
            sql += " ON (sm.shiresakiCode = shireData.shiresakiCode) ";
            sql += " LEFT JOIN (SELECT shiresakiCode ";
            sql += "                 , SUM(IFNULL(goukei, 0)) AS shiharaiKingaku ";
            sql += "            FROM shiharai ";
            sql += "            WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "            AND shiharaiHizuke >= '" + targetDateFrom + "' ";
            sql += "            AND shiharaiHizuke <= '" + targetDateTo + "' ";
            sql += "            GROUP BY shiresakiCode) shiharaiData ";
            sql += " ON (sm.shiresakiCode = shiharaiData.shiresakiCode) ";
            sql += " LEFT JOIN(SELECT shiresakiCode ";
            sql += "                , 9GatsuKurikoshi ";
            sql += "           FROM shiresaki_kaikake) zennen ";
            sql += " ON(sm.shiresakiCode = zennen.shiresakiCode) ";
            sql += " ORDER BY sm.shiresakiCode ";
            sql += ") syukei ";
            sql += "SET sk." + txtTargetYMMonth.Text + "GatsuShire = syukei.shireKingaku ";
            sql += "  , sk." + txtTargetYMMonth.Text + "GatsuSyouhiZei = syukei.shireShouhizei ";
            sql += "  , sk." + txtTargetYMMonth.Text + "GatsuShiharai = syukei.shiharaiKingaku ";
            sql += "  , sk." + txtTargetYMMonth.Text + "GatsuKurikoshi = syukei.zandaka ";
            if (txtTargetYMMonth.Text == "10") sql += "  , sk.zenNenKurikoshi = syukei.zennenKurikoshi ";
            sql += "WHERE sk.shiresakiCode = syukei.shiresakiCode ";
            sql += "AND sk.nendo = '" + targetNendo + "' ";
            commands.Add(sql);

            db.startTransaction();
            foreach (string command in commands)
            {
                db.executeDBUpdate(command);
            }
            db.endTransaction();
        }
        #endregion

        #endregion
    }
}
