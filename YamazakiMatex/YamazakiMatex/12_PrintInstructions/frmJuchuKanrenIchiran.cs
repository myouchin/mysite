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
    /// 受注・納品・仕入関連一覧出力画面
    /// </summary>
    public partial class frmJuchuKanrenIchiran : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        private string dateTypeJuchuKey = "juchu";
        private string dateTypeJuchuValue = "受注日付";
        private string dateTypeNouhinsyoKey = "nouhinsyo";
        private string dateTypeNouhinsyoValue = "納品書日付";
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
        public frmJuchuKanrenIchiran()
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
            rdoNotExistsNouhinShire.Location = new Point(84, 36);
            rdoExistsNouhinShire.Location = new Point(342, 36);
            createDateTypeCommbo();

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

        #region 帳票出力データ生成処理
        /// <summary>
        /// 帳票出力データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblJuchuKanrenIchiran createPrintData()
        {
            dtblJuchuKanrenIchiran res = new dtblJuchuKanrenIchiran();

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
            sql += "SELECT * ";
            sql += "FROM ";
            sql += "( ";
            sql += "  SELECT jh.denpyoHizuke  AS juchuBi " +  "\r ";
            sql += "       , jh.denpyoNo      AS juchuNo " + "\r ";
            sql += "       , jh.tokuisakiName AS tokuisakiName " + "\r ";
            sql += "       , jh.jigyousyoName AS jigyousyoName " + "\r ";
            sql += "       , uh.denpyoHizuke  AS nouhinBi " + "\r ";
            sql += "       , uh.denpyoNo      AS nouhinNo " + "\r ";
            sql += "       , sh.denpyoHizuke  AS shireBi " + "\r ";
            sql += "       , sh.shireNo       AS shireNo " + "\r ";
            sql += "       , CASE WHEN uh.denpyoNo IS NULL " + "\r ";
            sql += "           THEN '' " + "\r ";
            sql += "           ELSE CASE WHEN uh.flgSeikyu > 0 " + "\r ";
            sql += "                  THEN '〇' " + "\r ";
            sql += "                  ELSE '×' " + "\r ";
            sql += "                END " + "\r ";
            sql += "         END              AS shimeStatus " + "\r ";
            sql += "       , CASE WHEN uh.denpyoNo IS NULL OR sh.shireNo IS NULL " + "\r ";
            sql += "           THEN 2 " + "\r ";
            sql += "           ELSE 1 " + "\r ";
            sql += "         END              AS dataType " + "\r ";
            sql += "       , 1                AS sortNo " + "\r ";
            sql += "  FROM (SELECT * FROM juchu_header WHERE kanriKubun <> '9') jh " + "\r ";
            sql += "  LEFT JOIN ( " + "\r ";
            sql += "             SELECT uh.* " + "\r ";
            sql += "                  , ub.flgSeikyu " + "\r ";
            sql += "             FROM (SELECT * FROM uriage_header WHERE kanriKubun <> '9') uh " + "\r ";
            sql += "             INNER JOIN (SELECT denpyoNo " + "\r ";
            sql += "                              , SUM(CASE WHEN IFNULL(seikyuHuragu, '') = '1' " + "\r ";
            sql += "                                      THEN 1 " + "\r ";
            sql += "                                      ELSE 0 " + "\r ";
            sql += "                                END) AS flgSeikyu " + "\r ";
            sql += "                         FROM uriage_body " + "\r ";
            sql += "                         GROUP BY denpyoNo " + "\r ";
            sql += "             ) ub " + "\r ";
            sql += "             ON(uh.denpyoNo = ub.denpyoNo) " + "\r ";
            sql += "  ) uh " + "\r ";
            sql += "  ON (jh.juchuNoTop = uh.juchuNoTop AND jh.juchuNoMid = uh.juchuNoMid AND jh.juchuNoBtm = uh.juchuNoBtm) " + "\r ";
            sql += "  LEFT JOIN (SELECT * FROM shire_header WHERE kanriKubun <> '9') sh " + "\r ";
            sql += "  ON (jh.juchuNoTop = sh.juchuNoTop AND jh.juchuNoMid = sh.juchuNoMid AND jh.juchuNoBtm = sh.juchuNoBtm) " + "\r ";
            sql += "  UNION ALL " + "\r ";
            sql += "  SELECT NULL         AS juchuBi " + "\r ";
            sql += "       , NULL         AS juchuNo " + "\r ";
            sql += "       , NULL         AS tokuisakiName " + "\r ";
            sql += "       , NULL         AS jigyousyoName " + "\r ";
            sql += "       , NULL         AS nouhinBi " + "\r ";
            sql += "       , NULL         AS nouhinNo " + "\r ";
            sql += "       , denpyoHizuke AS shireBi " + "\r ";
            sql += "       , shireNo      AS shireNo " + "\r ";
            sql += "       , ''           AS shimeStatus " + "\r ";
            sql += "       , 3            AS dataType " + "\r ";
            sql += "       , 2            AS sortNo " + "\r ";
            sql += "  FROM shire_header " + "\r ";
            sql += "  WHERE kanriKubun <> '9' " + "\r ";
            sql += "  AND CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = '' " + "\r ";
            sql += ") ichiran " + "\r ";
            sql += "WHERE 1 = 1 " + "\r ";
            if (DateTime.TryParse(targetDateFrom, out date))
            {
                if (dateTypeJuchuKey.Equals(Convert.ToString(cmbDateType.SelectedValue)))
                {
                    sql += "AND juchuBi >= '" + date + "' " + "\r ";
                }
                else
                {
                    sql += "AND nouhinBi >= '" + date + "' " + "\r ";
                }
                kikanFrom = txtTargetYMDDateFromYears.Text + "年";
                kikanFrom += txtTargetYMDDateFromMonth.Text + "月";
                kikanFrom += txtTargetYMDDateFromDays.Text + "日";
            }
            if (DateTime.TryParse(targetDateTo, out date))
            {
                if (dateTypeJuchuKey.Equals(Convert.ToString(cmbDateType.SelectedValue)))
                {
                    sql += "AND juchuBi <= '" + date + "' " + "\r ";
                }
                else
                {
                    sql += "AND nouhinBi <= '" + date + "' " + "\r ";
                }
                kikanTo = txtTargetYMDDateToYears.Text + "年";
                kikanTo += txtTargetYMDDateToMonth.Text + "月";
                kikanTo += txtTargetYMDDateToDays.Text + "日";
            }
            sql += "ORDER BY ichiran.sortNo " + "\r ";
            sql += "       , ichiran.juchuBi " + "\r ";
            sql += "       , ichiran.juchuNo " + "\r ";
            sql += "       , ichiran.nouhinBi " + "\r ";
            sql += "       , ichiran.nouhinNo " + "\r ";
            sql += "       , ichiran.shireBi " + "\r ";
            sql += "       , ichiran.shireNo " + "\r ";
            DBCommon selectDb = new DBCommon();
            DataTable dt = selectDb.executeNoneLockSelect(sql).Copy();

            #region 帳票ヘッダデータ設定
            res.Tables["dtblJuchuKanrenIchiranHead"].Rows.Add();
            res.Tables["dtblJuchuKanrenIchiranHead"].Rows[0]["kikan"] = kikanFrom + "　～　" + kikanTo;
            #endregion

            EnumerableRowCollection<DataRow> query;
            if (rdoAll.Checked)
            {
                query = dt.AsEnumerable().OrderBy(p => dt.Rows.IndexOf(p));
            }
            else if (rdoNotExistsNouhinShire.Checked)
            {
                query = dt.AsEnumerable().Where(p => p.Field<Int64>("dataType") == 2).OrderBy(p => dt.Rows.IndexOf(p));
            }
            else
            {
                query = dt.AsEnumerable().Where(p => p.Field<Int64>("dataType") == 1).OrderBy(p => dt.Rows.IndexOf(p));
            }

            DataRow newRow;
            DateTime wkDate;
            string wkJuchuBi;
            string wkNouhinBi;
            string wkShireBi;
            foreach (DataRow row in query)
            {
                wkJuchuBi = Convert.ToString(row["juchuBi"]);
                wkNouhinBi = Convert.ToString(row["nouhinBi"]);
                wkShireBi = Convert.ToString(row["shireBi"]);
                newRow = res.Tables["dtblJuchuKanrenIchiran"].NewRow();
                if (DateTime.TryParse(wkJuchuBi, out wkDate))
                {
                    newRow["juchuBi"] = wkDate.Year + "/" + wkDate.Month + "/" + wkDate.Day;
                }
                newRow["juchuNo"] = row["juchuNo"];
                newRow["tokuisakiName"] = row["tokuisakiName"];
                newRow["jigyousyoName"] = row["jigyousyoName"];
                if (DateTime.TryParse(wkNouhinBi, out wkDate))
                {
                    newRow["nouhinBi"] = wkDate.Year + "/" + wkDate.Month + "/" + wkDate.Day;
                }
                newRow["nouhinNo"] = row["nouhinNo"];
                if (DateTime.TryParse(wkShireBi, out wkDate))
                {
                    newRow["shireBi"] = wkDate.Year + "/" + wkDate.Month + "/" + wkDate.Day;
                }
                newRow["shireNo"] = row["shireNo"];
                newRow["shimeStatus"] = row["shimeStatus"];
                res.Tables["dtblJuchuKanrenIchiran"].Rows.Add(newRow.ItemArray);
            }
            res.Tables["dtblJuchuKanrenIchiran"].AcceptChanges();

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
            // 帳票データの設定
            rptJuchuKanrenIchiran1.SetDataSource(createPrintData());
            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptJuchuKanrenIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptJuchuKanrenIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptJuchuKanrenIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptJuchuKanrenIchiran1.PrintToPrinter(printerSettings
                                                        , pageSettings
                                                        , false);

                }
            }
            else
            {
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptJuchuKanrenIchiran1;
                printView.Size = new Size(1375, 975);
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

        #region 検索条件日付区分コンボボックス生成処理
        /// <summary>
        /// 検索条件日付区分コンボボックス生成処理
        /// </summary>
        private void createDateTypeCommbo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("value");
            dt.Rows.Add(new object[] { dateTypeJuchuKey, dateTypeJuchuValue });
            dt.Rows.Add(new object[] { dateTypeNouhinsyoKey, dateTypeNouhinsyoValue });
            commonLogic.setComboBoxDataSource(ref cmbDateType, dt, "key", "value");
        }
        #endregion

        #endregion
    }
}
