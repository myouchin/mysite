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
    /// 納品残・入荷一覧出力画面
    /// </summary>
    public partial class frmNouhinShireZanIchiran : ChildBaseForm
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
        public frmNouhinShireZanIchiran()
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
            rdoZanAri.Location = new Point(84, 36);
            rdoZanNashi.Location = new Point(166, 36);

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

        #region 帳票出力データ生成処理
        /// <summary>
        /// 帳票出力データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblNouhinShireZanIchiran createPrintData()
        {
            dtblNouhinShireZanIchiran res = new dtblNouhinShireZanIchiran();
            string targetYMDFrom = txtTargetYMDDateFromYears.Text;
            targetYMDFrom += "-" + txtTargetYMDDateFromMonth.Text;
            targetYMDFrom += "-" + txtTargetYMDDateFromDays.Text;
            string targetYMDTo = txtTargetYMDDateToYears.Text;
            targetYMDTo += "-" + txtTargetYMDDateToMonth.Text;
            targetYMDTo += "-" + txtTargetYMDDateToDays.Text;
            string kikanFrom = "    年  月  日";
            string kikanTo = "    年  月  日";
            DateTime wkTargetYMD;

            string sql = string.Empty;
            DBCommon db = new DBCommon();
            #region 受注データ取得
            sql = string.Empty;
            sql += "SELECT jh.denpyoHizuke ";
            sql += "     , jh.denpyoNo ";
            sql += "     , jh.tokuisakiName ";
            sql += "     , jh.jigyousyoName ";
            sql += "     , jh.juchuNoTop ";
            sql += "     , jh.juchuNoMid ";
            sql += "     , jh.juchuNoBtm ";
            sql += "     , jb.rowNo ";
            sql += "     , jb.shouhinName1 ";
            sql += "     , jb.shouhinName2 ";
            sql += "     , IFNULL(jb.juchuSuryo, 0) AS juchuSuryo ";
            sql += "     , IFNULL(jb.juchuKingaku, 0) AS juchuKingaku ";
            sql += "     , IFNULL(jb.shireKingaku, 0) AS shireKingaku ";
            sql += "FROM (SELECT * ";
            sql += "      FROM juchu_header ";
            sql += "      WHERE kanriKubun <> '9' ";

            //sql += "      AND CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = '001030000000006' ";

            if (DateTime.TryParse(targetYMDFrom, out wkTargetYMD))
            {
                sql += "      AND denpyoHizuke >= '" + wkTargetYMD + "' ";
                kikanFrom = txtTargetYMDDateFromYears.Text + "年";
                kikanFrom += txtTargetYMDDateFromMonth.Text + "月";
                kikanFrom += txtTargetYMDDateFromDays.Text + "日";
            }
            if (DateTime.TryParse(targetYMDTo, out wkTargetYMD))
            {
                sql += "      AND denpyoHizuke <= '" + wkTargetYMD + "' ";
                kikanTo = txtTargetYMDDateToYears.Text + "年";
                kikanTo += txtTargetYMDDateToMonth.Text + "月";
                kikanTo += txtTargetYMDDateToDays.Text + "日";
            }
            sql += ") jh ";
            sql += "INNER JOIN (SELECT * FROM juchu_body) jb ";
            sql += "ON (jh.juchuNoTop = jb.juchuNoTop AND jh.juchuNoMid = jb.juchuNoMid AND jh.juchuNoBtm = jb.juchuNoBtm) ";
            sql += "ORDER BY jh.denpyoHizuke, jh.juchuNoTop, jh.juchuNoMid, jh.juchuNoBtm, jb.rowNo ";
            DataTable juchuDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 売上データ取得
            sql = string.Empty;
            sql += "SELECT uh.juchuNoTop ";
            sql += "     , uh.juchuNoMid ";
            sql += "     , uh.juchuNoBtm ";
            sql += "     , ub.juchuRowNo ";
            sql += "     , IFNULL(ub.suryo, 0) AS suryo ";
            sql += "     , IFNULL(ub.kingaku, 0) AS kingaku ";
            sql += "FROM (SELECT * FROM uriage_header WHERE kanriKubun <> '9') uh ";
            sql += "INNER JOIN (SELECT * FROM uriage_body) ub ";
            sql += "ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "WHERE IFNULL(ub.suryo, 0) <> 0 OR IFNULL(ub.kingaku, 0) <> 0 ";
            DataTable uriageDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 仕入データ取得
            sql = string.Empty;
            sql += "SELECT sh.juchuNoTop ";
            sql += "     , sh.juchuNoMid ";
            sql += "     , sh.juchuNoBtm ";
            sql += "     , sb.juchuRowNo ";
            sql += "     , sh.shiresakiName ";
            sql += "     , sb.shouhinName1 ";
            sql += "     , sb.shouhinName2 ";
            sql += "     , IFNULL(sb.suryo, 0) AS suryo ";
            sql += "     , IFNULL(sb.kingaku, 0) AS kingaku ";
            sql += "FROM (SELECT * FROM shire_header WHERE kanriKubun <> '9') sh ";
            sql += "INNER JOIN (SELECT * FROM shire_body) sb ";
            sql += "ON (sh.shireNo = sb.shireNo) ";
            sql += "WHERE IFNULL(sb.suryo, 0) <> 0 OR IFNULL(sb.kingaku, 0) <> 0 ";
            sql += "ORDER BY sh.shireNo, sb.rowNo ";
            DataTable shireDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 帳票ヘッダデータ設定
            res.Tables["dtblNouhinShireZanIchiranHead"].Rows.Add();
            res.Tables["dtblNouhinShireZanIchiranHead"].Rows[0]["kikan"] = kikanFrom + "　～　" + kikanTo;
            #endregion

            string juchuNoTop;
            string juchuNoMid;
            string juchuNoBtm;
            string wkJuchuNoTop = string.Empty;
            string wkJuchuNoMid = string.Empty;
            string wkJuchuNoBtm = string.Empty;
            int juchuRowNo;
            decimal juchuSuryo;
            decimal juchuKingaku;
            decimal shireKingaku;
            decimal nouhinSuryo;
            decimal nouhinKingaku;
            decimal nouhinZanSuryo;
            decimal nouhinZanKingaku;
            decimal nyukaSuryo;
            decimal nyukaKingaku;
            decimal nyukaZanSuryo;
            decimal nyukaZanKingaku;
            decimal wkDec;
            DateTime wkDate;
            string wkShiresakiName;
            DataRow newRow;
            EnumerableRowCollection<DataRow> uriageRows;
            EnumerableRowCollection<DataRow> shireRows;
            DataTable shireDt2 = shireDt.Copy();
            string shiresakiCode = string.Empty;
            string wkShiresakiCode = string.Empty;
            int rowCount;

            #region 帳票ボディデータ設定
            var query = juchuDt.AsEnumerable().GroupBy(p => new {
                key1 = p.Field<string>(DBFileLayout.JuchuHeaderFile.dcJuchuNoTop)
                                                                ,
                key2 = p.Field<string>(DBFileLayout.JuchuHeaderFile.dcJuchuNoMid)
                                                                ,
                key3 = p.Field<string>(DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm)
            });
            foreach (EnumerableRowCollection<DataRow> juchuRows in query)
            {
                rowCount = 0;
                foreach (DataRow juchuRow in juchuRows)
                {
                    rowCount++;
                    nouhinSuryo = decimal.Zero;
                    nouhinKingaku = decimal.Zero;
                    nouhinZanSuryo = decimal.Zero;
                    nouhinZanKingaku = decimal.Zero;
                    nyukaSuryo = decimal.Zero;
                    nyukaKingaku = decimal.Zero;
                    nyukaZanSuryo = decimal.Zero;
                    nyukaZanKingaku = decimal.Zero;
                    wkShiresakiName = string.Empty;
                    juchuNoTop = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
                    juchuNoMid = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
                    juchuNoBtm = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
                    juchuRowNo = Convert.ToInt16(juchuRow[DBFileLayout.JuchuBodyFile.dcRowNo]);
                    decimal.TryParse(Convert.ToString(juchuRow[DBFileLayout.JuchuBodyFile.dcJuchuSuryo]), out juchuSuryo);
                    decimal.TryParse(Convert.ToString(juchuRow[DBFileLayout.JuchuBodyFile.dcJuchuKingaku]), out juchuKingaku);
                    decimal.TryParse(Convert.ToString(juchuRow[DBFileLayout.JuchuBodyFile.dcShireKingaku]), out shireKingaku);
                    DateTime.TryParse(Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcDenpyoHizuke]), out wkDate);

                    // 売上明細の取得
                    uriageRows = uriageDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.UriageHeaderFile.dcJuchuNoTop).Equals(juchuNoTop) &&
                                                                    p.Field<string>(DBFileLayout.UriageHeaderFile.dcJuchuNoMid).Equals(juchuNoMid) &&
                                                                    p.Field<string>(DBFileLayout.UriageHeaderFile.dcJuchuNoBtm).Equals(juchuNoBtm) &&
                                                                    p.Field<Int32>(DBFileLayout.UriageBodyFile.dcJuchuRowNo) == juchuRowNo);
                    foreach (DataRow uriageRow in uriageRows)
                    {
                        decimal.TryParse(Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcSuryo]), out wkDec);
                        nouhinSuryo += wkDec;
                        decimal.TryParse(Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcKingaku]), out wkDec);
                        nouhinKingaku += wkDec;
                    }
                    // 仕入明細の取得
                    shireRows = shireDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoTop).Equals(juchuNoTop) &&
                                                                  p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoMid).Equals(juchuNoMid) &&
                                                                  p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoBtm).Equals(juchuNoBtm) &&
                                                                  p.Field<Int32>(DBFileLayout.ShireBodyFile.dcJuchuRowNo) == juchuRowNo);
                    foreach (DataRow shireRow in shireRows)
                    {
                        wkShiresakiName = Convert.ToString(shireRow[DBFileLayout.ShireHeaderFile.dcShiresakiName]);
                        decimal.TryParse(Convert.ToString(shireRow[DBFileLayout.ShireBodyFile.dcSuryo]), out wkDec);
                        nyukaSuryo += wkDec;
                        decimal.TryParse(Convert.ToString(shireRow[DBFileLayout.ShireBodyFile.dcKingaku]), out wkDec);
                        nyukaKingaku += wkDec;
                    }

                    nouhinZanSuryo = juchuSuryo - nouhinSuryo;
                    nouhinZanKingaku = juchuKingaku - nouhinKingaku;
                    nyukaZanSuryo = juchuSuryo - nyukaSuryo;
                    nyukaZanKingaku = shireKingaku - nyukaKingaku;

                    if (rdoZanAri.Checked &&
                        nouhinZanSuryo == decimal.Zero &&
                        nouhinZanKingaku == decimal.Zero &&
                        nyukaZanSuryo == decimal.Zero &&
                        nyukaZanKingaku == decimal.Zero)
                    {
                        continue;
                    }
                    else if (rdoZanNashi.Checked &&
                             (nouhinZanSuryo != decimal.Zero ||
                              nouhinZanKingaku != decimal.Zero ||
                              nyukaZanSuryo != decimal.Zero ||
                              nyukaZanKingaku != decimal.Zero))
                    {
                        continue;
                    }

                    newRow = res.Tables["dtblNouhinShireZanIchiran"].NewRow();
                    newRow["juchuBi"] = wkDate.Year + "/" + wkDate.Month + "/" + wkDate.Day;
                    newRow["juchuNo"] = juchuNoTop + juchuNoMid + juchuNoBtm;
                    newRow["tokuisakiName"] = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);
                    newRow["jigyousyoName"] = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoName]);
                    newRow["juchuSuryo"] = juchuSuryo.ToString("#,##0");
                    newRow["nouhinZanSuryo"] = nouhinZanSuryo.ToString("#,##0");
                    newRow["juchuKingaku"] = juchuKingaku.ToString("#,##0");
                    newRow["nouhinZanKingaku"] = nouhinZanKingaku.ToString("#,##0");
                    newRow["shiresakiName"] = wkShiresakiName;
                    newRow["shouhinName1"] = Convert.ToString(juchuRow[DBFileLayout.JuchuBodyFile.dcShouhinName1]);
                    newRow["shouhinName2"] = Convert.ToString(juchuRow[DBFileLayout.JuchuBodyFile.dcShouhinName2]);
                    newRow["shireSuryo"] = nyukaSuryo.ToString("#,##0");
                    newRow["shireZanSuryo"] = nyukaZanSuryo.ToString("#,##0");
                    newRow["shireKingaku"] = nyukaKingaku.ToString("#,##0");
                    newRow["shireZanKingaku"] = nyukaZanKingaku.ToString("#,##0");
                    res.Tables["dtblNouhinShireZanIchiran"].Rows.Add(newRow.ItemArray);

                    if (rowCount == juchuRows.Count())
                    {
                        // 仕入明細の取得
                        shireRows = shireDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoTop).Equals(juchuNoTop) &&
                                                                      p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoMid).Equals(juchuNoMid) &&
                                                                      p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoBtm).Equals(juchuNoBtm) &&
                                                                      p.Field<Int32>(DBFileLayout.ShireBodyFile.dcJuchuRowNo) == 0)
                                                          .OrderBy(p => p.Field<string>(DBFileLayout.ShireHeaderFile.dcShiresakiCode));
                        foreach (DataRow shireRow in shireRows)
                        {
                            wkShiresakiCode = Convert.ToString(shireRow[DBFileLayout.ShireHeaderFile.dcShiresakiCode]);
                            if (shiresakiCode.Equals(wkShiresakiCode)) continue;
                            wkShiresakiName = string.Empty;
                            nyukaSuryo = decimal.Zero;
                            nyukaKingaku = decimal.Zero;
                            shiresakiCode = wkShiresakiCode;

                            var shireQuery = shireDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoTop).Equals(juchuNoTop) &&
                                                                      p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoMid).Equals(juchuNoMid) &&
                                                                      p.Field<string>(DBFileLayout.ShireHeaderFile.dcJuchuNoBtm).Equals(juchuNoBtm) &&
                                                                      p.Field<Int32>(DBFileLayout.ShireBodyFile.dcJuchuRowNo) == 0 &&
                                                                      p.Field<string>(DBFileLayout.ShireHeaderFile.dcShiresakiCode).Equals(shiresakiCode));
                            foreach (DataRow shireRow2 in shireQuery)
                            {
                                wkShiresakiName = Convert.ToString(shireRow2[DBFileLayout.ShireHeaderFile.dcShiresakiName]);
                                decimal.TryParse(Convert.ToString(shireRow2[DBFileLayout.ShireBodyFile.dcSuryo]), out wkDec);
                                nyukaSuryo += wkDec;
                                decimal.TryParse(Convert.ToString(shireRow2[DBFileLayout.ShireBodyFile.dcKingaku]), out wkDec);
                                nyukaKingaku += wkDec;
                            }
                            newRow = res.Tables["dtblNouhinShireZanIchiran"].NewRow();
                            newRow["juchuBi"] = wkDate.Year + "/" + wkDate.Month + "/" + wkDate.Day;
                            newRow["juchuNo"] = juchuNoTop + juchuNoMid + juchuNoBtm;
                            newRow["tokuisakiName"] = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);
                            newRow["jigyousyoName"] = Convert.ToString(juchuRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoName]);
                            //newRow["juchuSuryo"] = juchuSuryo.ToString("#,##0");
                            //newRow["nouhinZanSuryo"] = nouhinZanSuryo.ToString("#,##0");
                            //newRow["juchuKingaku"] = juchuKingaku.ToString("#,##0");
                            //newRow["nouhinZanKingaku"] = nouhinZanKingaku.ToString("#,##0");
                            newRow["shiresakiName"] = Convert.ToString(shireRow[DBFileLayout.ShireHeaderFile.dcShiresakiName]);
                            newRow["shouhinName1"] = Convert.ToString(shireRow[DBFileLayout.ShireBodyFile.dcShouhinName1]);
                            newRow["shouhinName2"] = Convert.ToString(shireRow[DBFileLayout.ShireBodyFile.dcShouhinName2]);
                            newRow["shireSuryo"] = nyukaSuryo.ToString("#,##0");
                            newRow["shireZanSuryo"] = nyukaZanSuryo.ToString("#,##0");
                            newRow["shireKingaku"] = nyukaKingaku.ToString("#,##0");
                            newRow["shireZanKingaku"] = nyukaZanKingaku.ToString("#,##0");
                            res.Tables["dtblNouhinShireZanIchiran"].Rows.Add(newRow.ItemArray);
                        }
                    }
                }
            }
            #endregion

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
            rptNouhinShireZanIchiran1.SetDataSource(createPrintData());
            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptNouhinShireZanIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNouhinShireZanIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptNouhinShireZanIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptNouhinShireZanIchiran1.PrintToPrinter(printerSettings
                                                           , pageSettings
                                                           , false);

                }
            }
            else
            {
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptNouhinShireZanIchiran1;
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

        #endregion
    }
}
