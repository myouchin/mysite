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
    /// 欠番一覧出力画面
    /// </summary>
    public partial class frmKetubanIchiran : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        public enum DisplayType
        {
            YMD = 0
          , YM = 1
          , Y = 2
        }
        private enum LastInputDateType
        {
            None = 0
          , TargetYMDDateFrom = 1
          , TargetYMDDateTo = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmKetubanIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetYMDDateFromYears.Text = string.Empty;
            txtTargetYMDDateFromMonth.Text = string.Empty;
            txtTargetYMDDateFromDays.Text = string.Empty;
            txtTargetYMDDateToYears.Text = string.Empty;
            txtTargetYMDDateToMonth.Text = string.Empty;
            txtTargetYMDDateToDays.Text = string.Empty;
            commonLogic = new CommonLogic();
            DialogResult = DialogResult.None;
            rdoAll.Location = new Point(15, 36);
            rdoJuchu.Location = new Point(84, 36);
            rdoNouhinsyo.Location = new Point(157, 36);
            rdoSeikyusyo.Location = new Point(250, 36);

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
        private void txtTargetYMDDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYMDDateFrom)
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
        private void txtTargetYMDDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYMDDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYMDDateFrom;
            }
        }
        #endregion

        #region 対象年月日(TO)フォーカスインイベント
        /// <summary>
        /// 対象年月日(TO)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYMDDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月日(TO)フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYMDDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYMDDateTo;
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
                    case LastInputDateType.TargetYMDDateFrom:
                        y = txtTargetYMDDateFromYears.Text;
                        m = txtTargetYMDDateFromMonth.Text;
                        d = txtTargetYMDDateFromDays.Text;
                        break;
                    case LastInputDateType.TargetYMDDateTo:
                        y = txtTargetYMDDateToYears.Text;
                        m = txtTargetYMDDateToMonth.Text;
                        d = txtTargetYMDDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.TargetYMDDateFrom.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateFromYears.Focus();
                    }
                    else if (LastInputDateType.TargetYMDDateTo.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateToYears.Focus();
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

            // 対象年月日(FROM)の場合
            if (c.Name.Equals(txtTargetYMDDateFromYears.Name) ||
                c.Name.Equals(txtTargetYMDDateFromMonth.Name) ||
                c.Name.Equals(txtTargetYMDDateFromDays.Name) ||
                c.Name.Equals(dtpTargetYMDDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetYMDDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetYMDDateFrom_Leave);
            }
            // 対象年月日(TO)の場合
            else if (c.Name.Equals(txtTargetYMDDateToYears.Name) ||
                     c.Name.Equals(txtTargetYMDDateToMonth.Name) ||
                     c.Name.Equals(txtTargetYMDDateToDays.Name) ||
                     c.Name.Equals(dtpTargetYMDDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetYMDDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetYMDDateTo_Leave);
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
        private DataTable getData()
        {
            string sql = string.Empty;
            DBCommon selectDb = new DBCommon();
            return selectDb.executeNoneLockSelect(sql).Copy();
        }
        #endregion

        #region 受注欠番一覧データ生成処理
        /// <summary>
        /// 受注欠番一覧データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblKetuban createJuchuPrintData()
        {
            dtblKetuban res = new dtblKetuban();

            string targetDateFrom = txtTargetYMDDateFromYears.Text;
            targetDateFrom += "-" + txtTargetYMDDateFromMonth.Text;
            targetDateFrom += "-" + txtTargetYMDDateFromDays.Text;
            string targetDateTo = txtTargetYMDDateToYears.Text;
            targetDateTo += "-" + txtTargetYMDDateToMonth.Text;
            targetDateTo += "-" + txtTargetYMDDateToDays.Text;
            string kikanFrom = "    年  月  日";
            string kikanTo = "    年  月  日";
            DateTime date;
            string sql = string.Empty;
            sql += "SELECT CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) AS juchuNo FROM juchu_header WHERE kanriKubun = '9' ";
            if (DateTime.TryParse(targetDateFrom, out date))
            {
                sql += "AND denpyoHizuke >= '" + date + "' ";
                kikanFrom = txtTargetYMDDateFromYears.Text + "年";
                kikanFrom += txtTargetYMDDateFromMonth.Text + "月";
                kikanFrom += txtTargetYMDDateFromDays.Text + "日";
            }
            if (DateTime.TryParse(targetDateTo, out date))
            {
                sql += "AND denpyoHizuke <= '" + date + "' ";
                kikanTo = txtTargetYMDDateToYears.Text + "年";
                kikanTo += txtTargetYMDDateToMonth.Text + "月";
                kikanTo += txtTargetYMDDateToDays.Text + "日";
            }
            sql += "ORDER BY juchuNoTop, juchuNoMid, juchuNoBtm ";
            DBCommon selectDb = new DBCommon();
            DataTable ketubanDt = selectDb.executeNoneLockSelect(sql).Copy();

            #region 帳票ヘッダデータ設定
            res.Tables["dtblKetubanHead"].Rows.Add();
            res.Tables["dtblKetubanHead"].Rows[0]["kikan"] = kikanFrom + "　～　" + kikanTo;
            #endregion

            int rowMaxKetubanCount = 6;
            int ketubanCount = 0;
            for (int i = 0; i < ketubanDt.Rows.Count; i++)
            {
                ketubanCount++;
                if (ketubanCount == 1)
                {
                    res.Tables["dtblKetuban"].Rows.Add();
                }
                res.Tables["dtblKetuban"].Rows[res.Tables["dtblKetuban"].Rows.Count - 1]["ketuban" + ketubanCount] = Convert.ToString(ketubanDt.Rows[i]["juchuNo"]);
                if (ketubanCount == rowMaxKetubanCount)
                {
                    ketubanCount = 0;
                }
            }
            if (res.Tables["dtblKetuban"].Rows.Count == 0) res.Tables["dtblKetuban"].Rows.Add();

            return res;
        }
        #endregion

        #region 納品欠番一覧データ生成処理
        /// <summary>
        /// 納品欠番一覧データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblKetuban createNouhinsyoPrintData()
        {
            dtblKetuban res = new dtblKetuban();

            string targetDateFrom = txtTargetYMDDateFromYears.Text;
            targetDateFrom += "-" + txtTargetYMDDateFromMonth.Text;
            targetDateFrom += "-" + txtTargetYMDDateFromDays.Text;
            string targetDateTo = txtTargetYMDDateToYears.Text;
            targetDateTo += "-" + txtTargetYMDDateToMonth.Text;
            targetDateTo += "-" + txtTargetYMDDateToDays.Text;
            string kikanFrom = "    年  月  日";
            string kikanTo = "    年  月  日";
            DateTime date;
            string sql = string.Empty;
            sql += "SELECT denpyoNo FROM uriage_header WHERE kanriKubun = '9' ";
            if (DateTime.TryParse(targetDateFrom, out date))
            {
                sql += "AND denpyoHizuke >= '" + date + "' ";
                kikanFrom = txtTargetYMDDateFromYears.Text + "年";
                kikanFrom += txtTargetYMDDateFromMonth.Text + "月";
                kikanFrom += txtTargetYMDDateFromDays.Text + "日";
            }
            if (DateTime.TryParse(targetDateTo, out date))
            {
                sql += "AND denpyoHizuke <= '" + date + "' ";
                kikanTo = txtTargetYMDDateToYears.Text + "年";
                kikanTo += txtTargetYMDDateToMonth.Text + "月";
                kikanTo += txtTargetYMDDateToDays.Text + "日";
            }
            sql += "ORDER BY denpyoNo ";
            DBCommon selectDb = new DBCommon();
            DataTable ketubanDt = selectDb.executeNoneLockSelect(sql).Copy();

            #region 帳票ヘッダデータ設定
            res.Tables["dtblKetubanHead"].Rows.Add();
            res.Tables["dtblKetubanHead"].Rows[0]["kikan"] = kikanFrom + "　～　" + kikanTo;
            #endregion

            int rowMaxKetubanCount = 6;
            int ketubanCount = 0;
            for (int i = 0; i < ketubanDt.Rows.Count; i++)
            {
                ketubanCount++;
                if (ketubanCount == 1)
                {
                    res.Tables["dtblKetuban"].Rows.Add();
                }
                res.Tables["dtblKetuban"].Rows[res.Tables["dtblKetuban"].Rows.Count - 1]["ketuban" + ketubanCount] = Convert.ToString(ketubanDt.Rows[i]["denpyoNo"]);
                if (ketubanCount == rowMaxKetubanCount)
                {
                    ketubanCount = 0;
                }
            }
            if (res.Tables["dtblKetuban"].Rows.Count == 0) res.Tables["dtblKetuban"].Rows.Add();

            return res;
        }
        #endregion

        #region 請求欠番一覧データ生成処理
        /// <summary>
        /// 請求欠番一覧データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblKetuban createSeikyusyoPrintData()
        {
            dtblKetuban res = new dtblKetuban();

            string targetDateFrom = txtTargetYMDDateFromYears.Text;
            targetDateFrom += "-" + txtTargetYMDDateFromMonth.Text;
            targetDateFrom += "-" + txtTargetYMDDateFromDays.Text;
            string targetDateTo = txtTargetYMDDateToYears.Text;
            targetDateTo += "-" + txtTargetYMDDateToMonth.Text;
            targetDateTo += "-" + txtTargetYMDDateToDays.Text;
            string kikanFrom = "    年  月  日";
            string kikanTo = "    年  月  日";
            DateTime date;
            string sql = string.Empty;
            sql += "SELECT CAST(seikyuNo AS SIGNED) AS seikyuNo FROM tokuisaki_seikyu WHERE 1 = 1 ";
            if (DateTime.TryParse(targetDateFrom, out date))
            {
                sql += "AND seikyubi >= '" + date + "' ";
                kikanFrom = txtTargetYMDDateFromYears.Text + "年";
                kikanFrom += txtTargetYMDDateFromMonth.Text + "月";
                kikanFrom += txtTargetYMDDateFromDays.Text + "日";
            }
            if (DateTime.TryParse(targetDateTo, out date))
            {
                sql += "AND seikyubi <= '" + date + "' ";
                kikanTo = txtTargetYMDDateToYears.Text + "年";
                kikanTo += txtTargetYMDDateToMonth.Text + "月";
                kikanTo += txtTargetYMDDateToDays.Text + "日";
            }
            sql += "ORDER BY seikyuNo ";
            DBCommon selectDb = new DBCommon();
            DataTable ketubanDt = selectDb.executeNoneLockSelect(sql).Copy();
            #region 帳票ヘッダデータ設定
            res.Tables["dtblKetubanHead"].Rows.Add();
            res.Tables["dtblKetubanHead"].Rows[0]["kikan"] = kikanFrom + "　～　" + kikanTo;
            #endregion
            if (ketubanDt == null || ketubanDt.Rows.Count == 0)
            {
                res.Tables["dtblKetuban"].Rows.Add();
                return res;
            }
            sql = string.Empty;
            sql += "SELECT CAST(seikyuNo AS SIGNED) AS seikyuNo FROM tokuisaki_seikyu ";
            DataTable ketubanDt2 = selectDb.executeNoneLockSelect(sql).Copy();

            int rowMaxKetubanCount = 6;
            int ketubanCount = 0;
            int minSeikyuNo = Convert.ToInt16(ketubanDt.Compute("MIN(seikyuNo)", ""));
            int maxSeikyuNo = Convert.ToInt16(ketubanDt.Compute("MAX(seikyuNo)", ""));
            int seikyuNo = minSeikyuNo;

            while (seikyuNo < maxSeikyuNo)
            {
                seikyuNo++;
                var query = ketubanDt2.AsEnumerable().Where(p => p.Field<Int64>("seikyuNo") == seikyuNo);
                if (query.Count() == 0)
                {
                    ketubanCount++;
                    if (ketubanCount == 1)
                    {
                        res.Tables["dtblKetuban"].Rows.Add();
                    }
                    res.Tables["dtblKetuban"].Rows[res.Tables["dtblKetuban"].Rows.Count - 1]["ketuban" + ketubanCount] = commonLogic.getZeroBuriedNumberText(Convert.ToString(seikyuNo), 8);
                    if (ketubanCount == rowMaxKetubanCount)
                    {
                        ketubanCount = 0;
                    }
                }
            }

            return res;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            int print = 0;
            if (rdoAll.Checked)
            {
                rptKetubanJuchu1.SetDataSource(createJuchuPrintData());
                pairs.Add("受注欠番一覧表", rptKetubanJuchu1);
                rptKetubanNouhinsyo1.SetDataSource(createNouhinsyoPrintData());
                pairs.Add("納品欠番一覧表", rptKetubanNouhinsyo1);
                rptKetubanSeikyusyo1.SetDataSource(createSeikyusyoPrintData());
                pairs.Add("請求欠番一覧表", rptKetubanSeikyusyo1);
            }
            else if (rdoJuchu.Checked)
            {
                rptKetubanJuchu1.SetDataSource(createJuchuPrintData());
                pairs.Add("受注欠番一覧表", rptKetubanJuchu1);
                print = 1;
            }
            else if (rdoNouhinsyo.Checked)
            {
                rptKetubanNouhinsyo1.SetDataSource(createNouhinsyoPrintData());
                pairs.Add("納品書欠番一覧表", rptKetubanNouhinsyo1);
                print = 2;
            }
            else
            {
                rptKetubanSeikyusyo1.SetDataSource(createSeikyusyoPrintData());
                pairs.Add("請求欠番一覧表", rptKetubanSeikyusyo1);
                print = 3;
            }

            frmPrintView2 printView2 = new frmPrintView2(pairs);
            if (PrintType.OutPut.Equals(printType))
            {
                if (rdoAll.Checked)
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptKetubanJuchu1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKetubanJuchu1.PrintOptions.PaperOrientation)
                                                                         , rptKetubanJuchu1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptKetubanJuchu1.PrintToPrinter(printerSettings
                                                      , pageSettings
                                                      , false);

                    }

                    //印刷ダイアログ表示処理実行
                    printerSettings = null;
                    pageSettings = null;
                    result = commonLogic.DisplayedPrintDialog(rptKetubanNouhinsyo1.PrintOptions.PrinterName
                                                            , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKetubanNouhinsyo1.PrintOptions.PaperOrientation)
                                                            , rptKetubanNouhinsyo1.PrintOptions.PaperSize.ToString()
                                                            , ref printerSettings
                                                            , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptKetubanNouhinsyo1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);
                    }

                    //印刷ダイアログ表示処理実行
                    printerSettings = null;
                    pageSettings = null;
                    result = commonLogic.DisplayedPrintDialog(rptKetubanSeikyusyo1.PrintOptions.PrinterName
                                                            , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKetubanSeikyusyo1.PrintOptions.PaperOrientation)
                                                            , rptKetubanSeikyusyo1.PrintOptions.PaperSize.ToString()
                                                            , ref printerSettings
                                                            , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptKetubanSeikyusyo1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);
                    }
                }
                else
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = DialogResult.None;
                    if (print == 1)
                    {
                        result = commonLogic.DisplayedPrintDialog(rptKetubanJuchu1.PrintOptions.PrinterName
                                                                , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKetubanJuchu1.PrintOptions.PaperOrientation)
                                                                , rptKetubanJuchu1.PrintOptions.PaperSize.ToString()
                                                                , ref printerSettings
                                                                , ref pageSettings);
                    }
                    else if (print == 2)
                    {
                        result = commonLogic.DisplayedPrintDialog(rptKetubanNouhinsyo1.PrintOptions.PrinterName
                                                                , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKetubanNouhinsyo1.PrintOptions.PaperOrientation)
                                                                , rptKetubanNouhinsyo1.PrintOptions.PaperSize.ToString()
                                                                , ref printerSettings
                                                                , ref pageSettings);
                    }
                    else if (print == 3)
                    {
                        result = commonLogic.DisplayedPrintDialog(rptKetubanSeikyusyo1.PrintOptions.PrinterName
                                                                , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKetubanSeikyusyo1.PrintOptions.PaperOrientation)
                                                                , rptKetubanSeikyusyo1.PrintOptions.PaperSize.ToString()
                                                                , ref printerSettings
                                                                , ref pageSettings);
                    }
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        if (print == 1)
                        {
                            rptKetubanJuchu1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);
                        }
                        else if (print == 2)
                        {
                            rptKetubanNouhinsyo1.PrintToPrinter(printerSettings
                                                              , pageSettings
                                                              , false);
                        }
                        else if (print == 3)
                        {
                            rptKetubanSeikyusyo1.PrintToPrinter(printerSettings
                                                              , pageSettings
                                                              , false);
                        }
                    }
                }
            }
            else
            {
                printView2.Size = new Size(1375, 975);
                printView2.StartPosition = FormStartPosition.CenterScreen;
                printView2.ShowDialog();
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
            txtTargetYMDDateFromYears.MaxLength = 4;   // 対象年月日(FROM)(年)
            txtTargetYMDDateFromMonth.MaxLength = 2;   // 対象年月日(FROM)(月)
            txtTargetYMDDateFromDays.MaxLength = 2;    // 対象年月日(FROM)(日)
            txtTargetYMDDateToYears.MaxLength = 4;     // 対象年月日(TO)(年)
            txtTargetYMDDateToMonth.MaxLength = 2;     // 対象年月日(TO)(月)
            txtTargetYMDDateToDays.MaxLength = 2;      // 対象年月日(TO)(日)

            // 入力制御イベント設定
            txtTargetYMDDateFromYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 対象年月日(FROM)(年):数字のみ入力可
            txtTargetYMDDateFromMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 対象年月日(FROM)(月):数字のみ入力可
            txtTargetYMDDateFromDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象年月日(FROM)(日):数字のみ入力可
            txtTargetYMDDateToYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 対象年月日(TO)(年)  :数字のみ入力可
            txtTargetYMDDateToMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 対象年月日(TO)(月)  :数字のみ入力可
            txtTargetYMDDateToDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 対象年月日(TO)(日)  :数字のみ入力可
        }
        #endregion

        #endregion
    }
}
