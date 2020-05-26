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
    ///得意先別売上集計出力画面
    /// </summary>
    public partial class frmTokuisakiUriageSyukei : ChildBaseForm
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
          , TargetYMDate = 3
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DisplayType _displayType;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmTokuisakiUriageSyukei(DisplayType displayType)
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
            _displayType = displayType;

            switch (_displayType)
            {
                case DisplayType.YMD:
                    lblTargetYMDate.Visible = false;
                    pnlTargetYMDate.Visible = false;
                    lblTargetYDate.Visible = false;
                    pnlTargetYDate.Visible = false;
                    break;
                case DisplayType.YM:
                    lblTargetYMDDate.Visible = false;
                    pnlTargetYMDDateFrom.Visible = false;
                    lblFromToSeparated1.Visible = false;
                    pnlTargetYMDDateTo.Visible = false;
                    lblTargetYDate.Visible = false;
                    pnlTargetYDate.Visible = false;
                    lblTargetYMDate.Location = new Point(lblTargetYMDate.Location.X, lblTargetYMDDate.Location.Y);
                    pnlTargetYMDate.Location = new Point(pnlTargetYMDate.Location.X, pnlTargetYMDDateFrom.Location.Y);
                    break;
                case DisplayType.Y:
                    lblTargetYMDDate.Visible = false;
                    pnlTargetYMDDateFrom.Visible = false;
                    lblFromToSeparated1.Visible = false;
                    pnlTargetYMDDateTo.Visible = false;
                    lblTargetYMDate.Visible = false;
                    pnlTargetYMDate.Visible = false;
                    lblTargetYDate.Location = new Point(lblTargetYDate.Location.X, lblTargetYMDDate.Location.Y);
                    pnlTargetYDate.Location = new Point(pnlTargetYDate.Location.X, pnlTargetYMDDateFrom.Location.Y);
                    break;
                default:
                    break;
            }
            this.Size = new Size(664, 186);

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

        #region 対象年月(FROM)フォーカスインイベント
        /// <summary>
        /// 対象年月フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYMDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月(FROM)フォーカスアウトイベント
        /// <summary>
        /// 対象年月(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYMDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYMDate;
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
                    case LastInputDateType.TargetYMDate:
                        y = txtTargetYMDateYears.Text;
                        m = txtTargetYMDateMonth.Text;
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
                    else if (LastInputDateType.TargetYMDDateFrom.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateFromYears.Focus();
                    }
                    else if (LastInputDateType.TargetYMDDateTo.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateToYears.Focus();
                    }
                    else if (LastInputDateType.TargetYMDate.Equals(lastInputDateType))
                    {
                        txtTargetYMDateYears.Focus();
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
            // 対象年月(FROM)の場合
            else if (c.Name.Equals(txtTargetYMDateYears.Name) ||
                c.Name.Equals(txtTargetYMDateMonth.Name) ||
                c.Name.Equals(dtpTargetYMDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetYMDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetYMDateFrom_Leave);
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

            DateTime denpyoHizukeFrom;
            DateTime denpyoHizukeTo;
            if (_displayType == DisplayType.YMD)
            {
                denpyoHizukeFrom = Convert.ToDateTime(txtTargetYMDDateFromYears.Text + "/" + txtTargetYMDDateFromMonth.Text + "/" + txtTargetYMDDateFromDays.Text);
                if (string.IsNullOrEmpty(txtTargetYMDDateToYears.Text))
                {
                    denpyoHizukeTo = denpyoHizukeFrom;
                }
                else
                {
                    denpyoHizukeTo = Convert.ToDateTime(txtTargetYMDDateToYears.Text + "/" + txtTargetYMDDateToMonth.Text + "/" + txtTargetYMDDateToDays.Text);
                }
            }
            else if (_displayType == DisplayType.YM)
            {
                denpyoHizukeFrom = Convert.ToDateTime(txtTargetYMDateYears.Text + "/" + txtTargetYMDateMonth.Text + "/01");
                denpyoHizukeTo = denpyoHizukeFrom.AddMonths(1).AddDays(-1);
            }
            else
            {
                denpyoHizukeFrom = Convert.ToDateTime(txtTargetYDateYears.Text + "/10/01");
                denpyoHizukeTo = denpyoHizukeFrom.AddYears(1).AddDays(-1);
            }

            string hibetuSql = "";
            hibetuSql += "             SELECT chikuCode ";
            hibetuSql += "                  , tokuisakiCode ";
            hibetuSql += "                  , jigyousyoCode ";
            hibetuSql += "                  , CONCAT(nengetu, '{0}') AS nengapi ";
            hibetuSql += "                  , IFNULL(day{1}uriageKingaku, 0) AS kingaku ";
            hibetuSql += "                  , IFNULL(day{1}zei, 0) AS shouhizei ";
            hibetuSql += "             FROM tokuisaki_uriage_syukei ";

            sql += "SELECT tus.chikuCode ";
            sql += "     , tus.tokuisakiCode ";
            sql += "     , tm.tokuisakiName ";
            sql += "     , tus.jigyousyoCode ";
            sql += "     , tm.jigyousyoName ";
            sql += "     , tus.totalKingaku ";
            sql += "     , tus.totalShouhizei ";
            sql += "     , tus.totalKingaku + tus.totalShouhizei AS totalZeikomiKingaku ";
            sql += "FROM (SELECT tus.chikuCode ";
            sql += "           , tus.tokuisakiCode ";
            sql += "           , tus.jigyousyoCode ";
            sql += "           , SUM(kingaku) AS totalKingaku ";
            sql += "           , SUM(shouhizei) AS totalShouhizei ";
            sql += "      FROM ( ";
            sql += "             {0} ";
            sql += "             UNION ALL ";
            sql += "             {1} ";
            sql += "             UNION ALL ";
            sql += "             {2} ";
            sql += "             UNION ALL ";
            sql += "             {3} ";
            sql += "             UNION ALL ";
            sql += "             {4} ";
            sql += "             UNION ALL ";
            sql += "             {5} ";
            sql += "             UNION ALL ";
            sql += "             {6} ";
            sql += "             UNION ALL ";
            sql += "             {7} ";
            sql += "             UNION ALL ";
            sql += "             {8} ";
            sql += "             UNION ALL ";
            sql += "             {9} ";
            sql += "             UNION ALL ";
            sql += "             {10} ";
            sql += "             UNION ALL ";
            sql += "             {11} ";
            sql += "             UNION ALL ";
            sql += "             {12} ";
            sql += "             UNION ALL ";
            sql += "             {13} ";
            sql += "             UNION ALL ";
            sql += "             {14} ";
            sql += "             UNION ALL ";
            sql += "             {15} ";
            sql += "             UNION ALL ";
            sql += "             {16} ";
            sql += "             UNION ALL ";
            sql += "             {17} ";
            sql += "             UNION ALL ";
            sql += "             {18} ";
            sql += "             UNION ALL ";
            sql += "             {19} ";
            sql += "             UNION ALL ";
            sql += "             {20} ";
            sql += "             UNION ALL ";
            sql += "             {21} ";
            sql += "             UNION ALL ";
            sql += "             {22} ";
            sql += "             UNION ALL ";
            sql += "             {23} ";
            sql += "             UNION ALL ";
            sql += "             {24} ";
            sql += "             UNION ALL ";
            sql += "             {25} ";
            sql += "             UNION ALL ";
            sql += "             {26} ";
            sql += "             UNION ALL ";
            sql += "             {27} ";
            sql += "             UNION ALL ";
            sql += "             {28} ";
            sql += "             UNION ALL ";
            sql += "             {29} ";
            sql += "             UNION ALL ";
            sql += "             {30} ";
            sql += "           ) tus ";
            sql += "      WHERE STR_TO_DATE(tus.nengapi, '%Y%m%d') >= '" + denpyoHizukeFrom + "' ";
            sql += "      AND STR_TO_DATE(tus.nengapi, '%Y%m%d') <= '" + denpyoHizukeTo + "' ";
            sql += "      GROUP BY tus.chikuCode ";
            sql += "             , tus.tokuisakiCode ";
            sql += "             , tus.jigyousyoCode ";
            sql += "     ) tus ";
            sql += "LEFT JOIN ( ";
            sql += "            SELECT * FROM tokuisaki_master ";
            sql += "          ) tm ";
            sql += "ON (tus.tokuisakiCode = tm.tokuisakiCode AND tus.jigyousyoCode = tm.jigyousyoCode) ";
            sql += "WHERE IFNULL(tus.totalKingaku, 0) <> 0 ";
            sql += "OR IFNULL(tus.totalShouhizei, 0) <> 0 ";
            sql += "ORDER BY tus.tokuisakiCode, tus.jigyousyoCode ";

            sql = string.Format(sql
                              , string.Format(hibetuSql, "01", "1")
                              , string.Format(hibetuSql, "02", "2")
                              , string.Format(hibetuSql, "03", "3")
                              , string.Format(hibetuSql, "04", "4")
                              , string.Format(hibetuSql, "05", "5")
                              , string.Format(hibetuSql, "06", "6")
                              , string.Format(hibetuSql, "07", "7")
                              , string.Format(hibetuSql, "08", "8")
                              , string.Format(hibetuSql, "09", "9")
                              , string.Format(hibetuSql, "10", "10")
                              , string.Format(hibetuSql, "11", "11")
                              , string.Format(hibetuSql, "12", "12")
                              , string.Format(hibetuSql, "13", "13")
                              , string.Format(hibetuSql, "14", "14")
                              , string.Format(hibetuSql, "15", "15")
                              , string.Format(hibetuSql, "16", "16")
                              , string.Format(hibetuSql, "17", "17")
                              , string.Format(hibetuSql, "18", "18")
                              , string.Format(hibetuSql, "19", "19")
                              , string.Format(hibetuSql, "20", "20")
                              , string.Format(hibetuSql, "21", "21")
                              , string.Format(hibetuSql, "22", "22")
                              , string.Format(hibetuSql, "23", "23")
                              , string.Format(hibetuSql, "24", "24")
                              , string.Format(hibetuSql, "25", "25")
                              , string.Format(hibetuSql, "26", "26")
                              , string.Format(hibetuSql, "27", "27")
                              , string.Format(hibetuSql, "28", "28")
                              , string.Format(hibetuSql, "29", "29")
                              , string.Format(hibetuSql, "30", "30")
                              , string.Format(hibetuSql, "31", "31"));

            DBCommon selectDb = new DBCommon();
            return selectDb.executeNoneLockSelect(sql).Copy();
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (_displayType == DisplayType.YMD)
            {
                if (string.IsNullOrEmpty(txtTargetYMDDateFromYears.Text) ||
                    string.IsNullOrEmpty(txtTargetYMDDateFromMonth.Text) ||
                    string.IsNullOrEmpty(txtTargetYMDDateFromDays.Text))
                {
                    errorOK(string.Format(Messages.M0020, lblTargetYMDDate.Text + "(自)"));
                    return;
                }
            }
            else if (_displayType == DisplayType.YM)
            {
                if (string.IsNullOrEmpty(txtTargetYMDateYears.Text) ||
                    string.IsNullOrEmpty(txtTargetYMDateMonth.Text))
                {
                    errorOK(string.Format(Messages.M0020, lblTargetYMDate.Text + "(自)"));
                    return;
                }
            }
            else if (_displayType == DisplayType.Y)
            {
                if (string.IsNullOrEmpty(txtTargetYDateYears.Text))
                {
                    errorOK(string.Format(Messages.M0020, lblTargetYDate.Text + "(自)"));
                    return;
                }
            }

            // 対象年月日の得意先別売上集計ファイル更新
            registTokuisakiSyukei();

            DataTable tokuisakiSyukeiList = getData();
            if (tokuisakiSyukeiList == null || tokuisakiSyukeiList.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "対象年月日のデータ"));
                return;
            }

            dtblTokuisakibetuUriageShukeihyo tokuisakiUriageSyukei = new dtblTokuisakibetuUriageShukeihyo();

            DateTime kikanFrom;
            DateTime kikanTo;
            if (_displayType == DisplayType.YMD)
            {
                kikanFrom = Convert.ToDateTime(txtTargetYMDDateFromYears.Text + "/" + txtTargetYMDDateFromMonth.Text + "/" + txtTargetYMDDateFromDays.Text);
                if (string.IsNullOrEmpty(txtTargetYMDDateToYears.Text))
                {
                    kikanTo = kikanFrom;
                }
                else
                {
                    kikanTo = Convert.ToDateTime(txtTargetYMDDateToYears.Text + "/" + txtTargetYMDDateToMonth.Text + "/" + txtTargetYMDDateToDays.Text);
                }
            }
            else if (_displayType == DisplayType.YM)
            {
                kikanFrom = Convert.ToDateTime(txtTargetYMDateYears.Text + "/" + txtTargetYMDateMonth.Text + "/01");
                kikanTo = kikanFrom.AddMonths(1).AddDays(-1);
            }
            else
            {
                kikanFrom = Convert.ToDateTime(txtTargetYDateYears.Text + "/10/01");
                kikanTo = kikanFrom.AddYears(1).AddDays(-1);
            }
            string kikan = kikanFrom.Year + "年";
            kikan += kikanFrom.Month + "月";
            kikan += kikanFrom.Day + "日～";
            kikan += kikanTo.Year + "年";
            kikan += kikanTo.Month + "月";
            kikan += kikanTo.Day + "日";
            DataRow listRow;
            decimal uriageGokei = decimal.Zero;
            decimal shohizeiGokei = decimal.Zero;
            decimal zeikomiGokei = decimal.Zero;
            decimal wkUriageGokei = decimal.Zero;
            decimal wkShohizeiGokei = decimal.Zero;
            decimal wkZeikomiGokei = decimal.Zero;
            foreach (DataRow row in tokuisakiSyukeiList.Rows)
            {
                listRow = tokuisakiUriageSyukei.Tables["dtblTokuisakibetuUriageShukeihyo"].NewRow();
                decimal.TryParse(Convert.ToString(row["totalKingaku"]), out wkUriageGokei);
                decimal.TryParse(Convert.ToString(row["totalShouhizei"]), out wkShohizeiGokei);
                decimal.TryParse(Convert.ToString(row["totalZeikomiKingaku"]), out wkZeikomiGokei);
                listRow["kikan"] = kikan;
                listRow["kikanSnen"] = Convert.ToString(kikanFrom.Year);
                listRow["kikanStuki"] = Convert.ToString(kikanFrom.Month);
                listRow["kikanShi"] = Convert.ToString(kikanFrom.Day);
                listRow["kikanEnen"] = Convert.ToString(kikanTo.Year);
                listRow["kikanEtuki"] = Convert.ToString(kikanTo.Month);
                listRow["kikanEhi"] = Convert.ToString(kikanTo.Day);
                listRow["tokuisakiCd"] = row["tokuisakiCode"];
                listRow["jigyoCd"] = row["jigyousyoCode"];
                listRow["tokuisakiNm"] = row["tokuisakiName"];
                listRow["jigyoNm"] = row["jigyousyoName"];
                listRow["uriage"] = wkUriageGokei.ToString("#,##0");
                listRow["shohiZei"] = wkShohizeiGokei.ToString("#,##0");
                listRow["zeikomiG"] = wkZeikomiGokei.ToString("#,##0");
                tokuisakiUriageSyukei.Tables["dtblTokuisakibetuUriageShukeihyo"].Rows.Add(listRow.ItemArray);
                uriageGokei += wkUriageGokei;
                shohizeiGokei += wkShohizeiGokei;
            }
            zeikomiGokei = uriageGokei + shohizeiGokei;

            int maxPageRow = 33;
            int LackRowCount = maxPageRow - ((tokuisakiSyukeiList.Rows.Count + 1) % maxPageRow);
            if (LackRowCount == maxPageRow) LackRowCount = 0;

            while (LackRowCount > 0)
            {
                listRow = tokuisakiUriageSyukei.Tables["dtblTokuisakibetuUriageShukeihyo"].NewRow();
                listRow["kikan"] = kikan;
                listRow["kikanSnen"] = Convert.ToString(kikanFrom.Year);
                listRow["kikanStuki"] = Convert.ToString(kikanFrom.Month);
                listRow["kikanShi"] = Convert.ToString(kikanFrom.Day);
                listRow["kikanEnen"] = Convert.ToString(kikanTo.Year);
                listRow["kikanEtuki"] = Convert.ToString(kikanTo.Month);
                listRow["kikanEhi"] = Convert.ToString(kikanTo.Day);
                tokuisakiUriageSyukei.Tables["dtblTokuisakibetuUriageShukeihyo"].Rows.Add(listRow.ItemArray);
                LackRowCount--;
            }

            DataRow footerRow = tokuisakiUriageSyukei.Tables["dtblTokuisakibetuUriageShukeihyoF"].NewRow();
            footerRow["uriageGokei"] = uriageGokei.ToString("#,##0");
            footerRow["shohizeiGokei"] = shohizeiGokei.ToString("#,##0");
            footerRow["zeikomiGokei"] = zeikomiGokei.ToString("#,##0");
            tokuisakiUriageSyukei.Tables["dtblTokuisakibetuUriageShukeihyoF"].Rows.Add(footerRow.ItemArray);

            rptTokuisakibetuUriageShukeihyo1.SetDataSource(tokuisakiUriageSyukei);

            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptTokuisakibetuUriageShukeihyo1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptTokuisakibetuUriageShukeihyo1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptTokuisakibetuUriageShukeihyo1.PrintOptions.PaperOrientation)
                                                                     , rptTokuisakibetuUriageShukeihyo1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptTokuisakibetuUriageShukeihyo1.PrintToPrinter(printerSettings
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
            txtTargetYMDDateFromYears.MaxLength = 4;   // 対象年月日(FROM)(年)
            txtTargetYMDDateFromMonth.MaxLength = 2;   // 対象年月日(FROM)(月)
            txtTargetYMDDateFromDays.MaxLength = 2;    // 対象年月日(FROM)(日)
            txtTargetYMDDateToYears.MaxLength = 4;     // 対象年月日(TO)(年)
            txtTargetYMDDateToMonth.MaxLength = 2;     // 対象年月日(TO)(月)
            txtTargetYMDDateToDays.MaxLength = 2;      // 対象年月日(TO)(日)
            txtTargetYMDateYears.MaxLength = 4;        // 対象年月(年)
            txtTargetYMDateMonth.MaxLength = 2;        // 対象年月(月)
            txtTargetYDateYears.MaxLength = 4;         // 対象年(年)

            // 入力制御イベント設定
            txtTargetYMDDateFromYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 対象年月日(FROM)(年):数字のみ入力可
            txtTargetYMDDateFromMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 対象年月日(FROM)(月):数字のみ入力可
            txtTargetYMDDateFromDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象年月日(FROM)(日):数字のみ入力可
            txtTargetYMDDateToYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 対象年月日(TO)(年)  :数字のみ入力可
            txtTargetYMDDateToMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 対象年月日(TO)(月)  :数字のみ入力可
            txtTargetYMDDateToDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 対象年月日(TO)(日)  :数字のみ入力可
            txtTargetYMDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 対象年月(年)        :数字のみ入力可
            txtTargetYMDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 対象年月(月)        :数字のみ入力可
            txtTargetYDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 対象年(年)          :数字のみ入力可
        }
        #endregion

        #region 対象年月日の得意先別売上集計ファイル更新
        /// <summary>
        /// 対象年月日の得意先別売上集計ファイル更新
        /// </summary>
        private void registTokuisakiSyukei()
        {
            string sql = string.Empty;

            DateTime denpyoHizukeFrom;
            DateTime denpyoHizukeTo;
            int monthCount = 1;
            if (_displayType == DisplayType.YMD)
            {
                denpyoHizukeFrom = Convert.ToDateTime(txtTargetYMDDateFromYears.Text + "/" + txtTargetYMDDateFromMonth.Text + "/" + txtTargetYMDDateFromDays.Text);
                if (string.IsNullOrEmpty(txtTargetYMDDateToYears.Text))
                {
                    denpyoHizukeTo = denpyoHizukeFrom;
                }
                else
                {
                    denpyoHizukeTo = Convert.ToDateTime(txtTargetYMDDateToYears.Text + "/" + txtTargetYMDDateToMonth.Text + "/" + txtTargetYMDDateToDays.Text);
                }
            }
            else if (_displayType == DisplayType.YM)
            {
                denpyoHizukeFrom = Convert.ToDateTime(txtTargetYMDateYears.Text + "/" + txtTargetYMDateMonth.Text + "/01");
                denpyoHizukeTo = denpyoHizukeFrom.AddMonths(1).AddDays(-1);
            }
            else
            {
                denpyoHizukeFrom = Convert.ToDateTime(txtTargetYDateYears.Text + "/10/01");
                denpyoHizukeTo = denpyoHizukeFrom.AddMonths(1).AddDays(-1);
                monthCount = 12;
            }

            DBCommon db = new DBCommon();
            db.startTransaction();
            db.executeDBUpdate("DELETE FROM tokuisaki_uriage_syukei ");
            db.endTransaction();
            DataTable registBaseDt;
            DataTable existsCheckDt;
            List<string> registSql = new List<string>();
            DateTime kousinNichizi = DateTime.Now;
            while (monthCount > 0)
            {
                sql = string.Empty;
                sql += "SELECT us.chikuCode " + "\r";
                sql += "     , us.tokuisakiCode " + "\r";
                sql += "     , us.jigyousyoCode " + "\r";
                sql += "     , us.ym " + "\r";
                sql += "     , SUM(us.day1uriageKingaku) AS day1uriageKingaku " + "\r";
                sql += "     , SUM(us.day1zei) AS day1zei " + "\r";
                sql += "     , SUM(us.day2uriageKingaku) AS day2uriageKingaku " + "\r";
                sql += "     , SUM(us.day2zei) AS day2zei " + "\r";
                sql += "     , SUM(us.day3uriageKingaku) AS day3uriageKingaku " + "\r";
                sql += "     , SUM(us.day3zei) AS day3zei " + "\r";
                sql += "     , SUM(us.day4uriageKingaku) AS day4uriageKingaku " + "\r";
                sql += "     , SUM(us.day4zei) AS day4zei " + "\r";
                sql += "     , SUM(us.day5uriageKingaku) AS day5uriageKingaku " + "\r";
                sql += "     , SUM(us.day5zei) AS day5zei " + "\r";
                sql += "     , SUM(us.day6uriageKingaku) AS day6uriageKingaku " + "\r";
                sql += "     , SUM(us.day6zei) AS day6zei " + "\r";
                sql += "     , SUM(us.day7uriageKingaku) AS day7uriageKingaku " + "\r";
                sql += "     , SUM(us.day7zei) AS day7zei " + "\r";
                sql += "     , SUM(us.day8uriageKingaku) AS day8uriageKingaku " + "\r";
                sql += "     , SUM(us.day8zei) AS day8zei " + "\r";
                sql += "     , SUM(us.day9uriageKingaku) AS day9uriageKingaku " + "\r";
                sql += "     , SUM(us.day9zei) AS day9zei " + "\r";
                sql += "     , SUM(us.day10uriageKingaku) AS day10uriageKingaku " + "\r";
                sql += "     , SUM(us.day10zei) AS day10zei " + "\r";
                sql += "     , SUM(us.day11uriageKingaku) AS day11uriageKingaku " + "\r";
                sql += "     , SUM(us.day11zei) AS day11zei " + "\r";
                sql += "     , SUM(us.day12uriageKingaku) AS day12uriageKingaku " + "\r";
                sql += "     , SUM(us.day12zei) AS day12zei " + "\r";
                sql += "     , SUM(us.day13uriageKingaku) AS day13uriageKingaku " + "\r";
                sql += "     , SUM(us.day13zei) AS day13zei " + "\r";
                sql += "     , SUM(us.day14uriageKingaku) AS day14uriageKingaku " + "\r";
                sql += "     , SUM(us.day14zei) AS day14zei " + "\r";
                sql += "     , SUM(us.day15uriageKingaku) AS day15uriageKingaku " + "\r";
                sql += "     , SUM(us.day15zei) AS day15zei " + "\r";
                sql += "     , SUM(us.day16uriageKingaku) AS day16uriageKingaku " + "\r";
                sql += "     , SUM(us.day16zei) AS day16zei " + "\r";
                sql += "     , SUM(us.day17uriageKingaku) AS day17uriageKingaku " + "\r";
                sql += "     , SUM(us.day17zei) AS day17zei " + "\r";
                sql += "     , SUM(us.day18uriageKingaku) AS day18uriageKingaku " + "\r";
                sql += "     , SUM(us.day18zei) AS day18zei " + "\r";
                sql += "     , SUM(us.day19uriageKingaku) AS day19uriageKingaku " + "\r";
                sql += "     , SUM(us.day19zei) AS day19zei " + "\r";
                sql += "     , SUM(us.day20uriageKingaku) AS day20uriageKingaku " + "\r";
                sql += "     , SUM(us.day20zei) AS day20zei " + "\r";
                sql += "     , SUM(us.day21uriageKingaku) AS day21uriageKingaku " + "\r";
                sql += "     , SUM(us.day21zei) AS day21zei " + "\r";
                sql += "     , SUM(us.day22uriageKingaku) AS day22uriageKingaku " + "\r";
                sql += "     , SUM(us.day22zei) AS day22zei " + "\r";
                sql += "     , SUM(us.day23uriageKingaku) AS day23uriageKingaku " + "\r";
                sql += "     , SUM(us.day23zei) AS day23zei " + "\r";
                sql += "     , SUM(us.day24uriageKingaku) AS day24uriageKingaku " + "\r";
                sql += "     , SUM(us.day24zei) AS day24zei " + "\r";
                sql += "     , SUM(us.day25uriageKingaku) AS day25uriageKingaku " + "\r";
                sql += "     , SUM(us.day25zei) AS day25zei " + "\r";
                sql += "     , SUM(us.day26uriageKingaku) AS day26uriageKingaku " + "\r";
                sql += "     , SUM(us.day26zei) AS day26zei " + "\r";
                sql += "     , SUM(us.day27uriageKingaku) AS day27uriageKingaku " + "\r";
                sql += "     , SUM(us.day27zei) AS day27zei " + "\r";
                sql += "     , SUM(us.day28uriageKingaku) AS day28uriageKingaku " + "\r";
                sql += "     , SUM(us.day28zei) AS day28zei " + "\r";
                sql += "     , SUM(us.day29uriageKingaku) AS day29uriageKingaku " + "\r";
                sql += "     , SUM(us.day29zei) AS day29zei " + "\r";
                sql += "     , SUM(us.day30uriageKingaku) AS day30uriageKingaku " + "\r";
                sql += "     , SUM(us.day30zei) AS day30zei " + "\r";
                sql += "     , SUM(us.day31uriageKingaku) AS day31uriageKingaku " + "\r";
                sql += "     , SUM(us.day31zei) AS day31zei " + "\r";
                sql += " " + "\r";
                sql += "FROM " + "\r";
                sql += "( " + "\r";
                sql += "  SELECT uhb.chikuCode " + "\r";
                sql += "       , uhb.tokuisakiCode " + "\r";
                sql += "       , uhb.jigyousyoCode " + "\r";
                sql += "       , uhb.ym " + "\r";
                sql += "       , CASE WHEN ud.d = '01' THEN ud.totalKingaku ELSE 0 END AS day1uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '01' THEN ud.totalShouhizei ELSE 0 END AS day1zei " + "\r";
                sql += "       , CASE WHEN ud.d = '02' THEN ud.totalKingaku ELSE 0 END AS day2uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '02' THEN ud.totalShouhizei ELSE 0 END AS day2zei " + "\r";
                sql += "       , CASE WHEN ud.d = '03' THEN ud.totalKingaku ELSE 0 END AS day3uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '03' THEN ud.totalShouhizei ELSE 0 END AS day3zei " + "\r";
                sql += "       , CASE WHEN ud.d = '04' THEN ud.totalKingaku ELSE 0 END AS day4uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '04' THEN ud.totalShouhizei ELSE 0 END AS day4zei " + "\r";
                sql += "       , CASE WHEN ud.d = '05' THEN ud.totalKingaku ELSE 0 END AS day5uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '05' THEN ud.totalShouhizei ELSE 0 END AS day5zei " + "\r";
                sql += "       , CASE WHEN ud.d = '06' THEN ud.totalKingaku ELSE 0 END AS day6uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '06' THEN ud.totalShouhizei ELSE 0 END AS day6zei " + "\r";
                sql += "       , CASE WHEN ud.d = '07' THEN ud.totalKingaku ELSE 0 END AS day7uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '07' THEN ud.totalShouhizei ELSE 0 END AS day7zei " + "\r";
                sql += "       , CASE WHEN ud.d = '08' THEN ud.totalKingaku ELSE 0 END AS day8uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '08' THEN ud.totalShouhizei ELSE 0 END AS day8zei " + "\r";
                sql += "       , CASE WHEN ud.d = '09' THEN ud.totalKingaku ELSE 0 END AS day9uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '09' THEN ud.totalShouhizei ELSE 0 END AS day9zei " + "\r";
                sql += "       , CASE WHEN ud.d = '10' THEN ud.totalKingaku ELSE 0 END AS day10uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '10' THEN ud.totalShouhizei ELSE 0 END AS day10zei " + "\r";
                sql += "       , CASE WHEN ud.d = '11' THEN ud.totalKingaku ELSE 0 END AS day11uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '11' THEN ud.totalShouhizei ELSE 0 END AS day11zei " + "\r";
                sql += "       , CASE WHEN ud.d = '12' THEN ud.totalKingaku ELSE 0 END AS day12uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '12' THEN ud.totalShouhizei ELSE 0 END AS day12zei " + "\r";
                sql += "       , CASE WHEN ud.d = '13' THEN ud.totalKingaku ELSE 0 END AS day13uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '13' THEN ud.totalShouhizei ELSE 0 END AS day13zei " + "\r";
                sql += "       , CASE WHEN ud.d = '14' THEN ud.totalKingaku ELSE 0 END AS day14uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '14' THEN ud.totalShouhizei ELSE 0 END AS day14zei " + "\r";
                sql += "       , CASE WHEN ud.d = '15' THEN ud.totalKingaku ELSE 0 END AS day15uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '15' THEN ud.totalShouhizei ELSE 0 END AS day15zei " + "\r";
                sql += "       , CASE WHEN ud.d = '16' THEN ud.totalKingaku ELSE 0 END AS day16uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '16' THEN ud.totalShouhizei ELSE 0 END AS day16zei " + "\r";
                sql += "       , CASE WHEN ud.d = '17' THEN ud.totalKingaku ELSE 0 END AS day17uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '17' THEN ud.totalShouhizei ELSE 0 END AS day17zei " + "\r";
                sql += "       , CASE WHEN ud.d = '18' THEN ud.totalKingaku ELSE 0 END AS day18uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '18' THEN ud.totalShouhizei ELSE 0 END AS day18zei " + "\r";
                sql += "       , CASE WHEN ud.d = '19' THEN ud.totalKingaku ELSE 0 END AS day19uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '19' THEN ud.totalShouhizei ELSE 0 END AS day19zei " + "\r";
                sql += "       , CASE WHEN ud.d = '20' THEN ud.totalKingaku ELSE 0 END AS day20uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '20' THEN ud.totalShouhizei ELSE 0 END AS day20zei " + "\r";
                sql += "       , CASE WHEN ud.d = '21' THEN ud.totalKingaku ELSE 0 END AS day21uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '21' THEN ud.totalShouhizei ELSE 0 END AS day21zei " + "\r";
                sql += "       , CASE WHEN ud.d = '22' THEN ud.totalKingaku ELSE 0 END AS day22uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '22' THEN ud.totalShouhizei ELSE 0 END AS day22zei " + "\r";
                sql += "       , CASE WHEN ud.d = '23' THEN ud.totalKingaku ELSE 0 END AS day23uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '23' THEN ud.totalShouhizei ELSE 0 END AS day23zei " + "\r";
                sql += "       , CASE WHEN ud.d = '24' THEN ud.totalKingaku ELSE 0 END AS day24uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '24' THEN ud.totalShouhizei ELSE 0 END AS day24zei " + "\r";
                sql += "       , CASE WHEN ud.d = '25' THEN ud.totalKingaku ELSE 0 END AS day25uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '25' THEN ud.totalShouhizei ELSE 0 END AS day25zei " + "\r";
                sql += "       , CASE WHEN ud.d = '26' THEN ud.totalKingaku ELSE 0 END AS day26uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '26' THEN ud.totalShouhizei ELSE 0 END AS day26zei " + "\r";
                sql += "       , CASE WHEN ud.d = '27' THEN ud.totalKingaku ELSE 0 END AS day27uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '27' THEN ud.totalShouhizei ELSE 0 END AS day27zei " + "\r";
                sql += "       , CASE WHEN ud.d = '28' THEN ud.totalKingaku ELSE 0 END AS day28uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '28' THEN ud.totalShouhizei ELSE 0 END AS day28zei " + "\r";
                sql += "       , CASE WHEN ud.d = '29' THEN ud.totalKingaku ELSE 0 END AS day29uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '29' THEN ud.totalShouhizei ELSE 0 END AS day29zei " + "\r";
                sql += "       , CASE WHEN ud.d = '30' THEN ud.totalKingaku ELSE 0 END AS day30uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '30' THEN ud.totalShouhizei ELSE 0 END AS day30zei " + "\r";
                sql += "       , CASE WHEN ud.d = '31' THEN ud.totalKingaku ELSE 0 END AS day31uriageKingaku " + "\r";
                sql += "       , CASE WHEN ud.d = '31' THEN ud.totalShouhizei ELSE 0 END AS day31zei " + "\r";
                sql += "  FROM ( " + "\r";
                sql += "         SELECT chikuCode " + "\r";
                sql += "              , tokuisakiCode " + "\r";
                sql += "              , jigyousyoCode " + "\r";
                sql += "              , DATE_FORMAT(denpyoHizuke,'%Y%m') ym " + "\r";
                sql += "         FROM uriage_header WHERE kanriKubun IS NULL OR kanriKubun <> '9' " + "\r";
                sql += "         GROUP BY tokuisakiCode, jigyousyoCode, DATE_FORMAT(denpyoHizuke,'%Y%m') " + "\r";
                sql += "       ) uhb " + "\r";
                sql += "  INNER JOIN ( " + "\r";
                sql += "               SELECT ud.* " + "\r";
                sql += "                    , CASE tm.syohizeiHasuKubun " + "\r";
                sql += "                          WHEN '0' THEN truncate(IFNULL(IFNULL(ud.totalKingaku, 0), 0) * (tm.zeiritu / 100), 0) " + "\r";
                sql += "                          WHEN '1' THEN truncate(IFNULL(IFNULL(ud.totalKingaku, 0), 0) * (tm.zeiritu / 100) + .9, 0) " + "\r";
                sql += "                          WHEN '2' THEN truncate(IFNULL(IFNULL(ud.totalKingaku, 0), 0) * (tm.zeiritu / 100) + .5, 0) " + "\r";
                sql += "                      END AS totalShouhizei " + "\r";
                sql += "               FROM ( " + "\r";
                sql += "                      SELECT uh.tokuisakiCode " + "\r";
                sql += "                           , uh.jigyousyoCode " + "\r";
                sql += "                           , uh.ym " + "\r";
                sql += "                           , uh.d " + "\r";
                sql += "                           , SUM(IFNULL(ub.kingaku, 0)) AS totalKingaku " + "\r";
                sql += "                      FROM ( " + "\r";
                sql += "                             SELECT * " + "\r";
                sql += "                             FROM uriage_body " + "\r";
                sql += "                             WHERE IFNULL(flgPrint, 0) = 1 " + "\r";
                sql += "                           ) ub " + "\r";
                sql += "                      INNER JOIN ( " + "\r";
                sql += "                                   SELECT denpyoNo " + "\r";
                sql += "                                        , DATE_FORMAT(denpyoHizuke,'%Y%m') ym " + "\r";
                sql += "                                        , DATE_FORMAT(denpyoHizuke,'%d') d " + "\r";
                sql += "                                        , tokuisakiCode " + "\r";
                sql += "                                        , jigyousyoCode " + "\r";
                sql += "                                   FROM uriage_header " + "\r";
                sql += "                                   WHERE (kanriKubun IS NULL OR kanriKubun <> '9') " + "\r";
                sql += "                                   AND denpyoHizuke >= '" + denpyoHizukeFrom + "' " + "\r";
                sql += "                                   AND denpyoHizuke <= '" + denpyoHizukeTo + "' " + "\r";
                sql += "                                 ) uh " + "\r";
                sql += "                      ON (ub.denpyoNo = uh.denpyoNo) " + "\r";
                sql += "                      GROUP BY uh.tokuisakiCode, uh.jigyousyoCode, uh.ym, uh.d " + "\r";
                sql += "                    ) ud " + "\r";
                sql += "               INNER JOIN ( " + "\r";
                sql += "                            SELECT * " + "\r";
                sql += "                                 , ( " + "\r";
                sql += "                                     SELECT CASE WHEN NOW() <= STR_TO_DATE(koumoku2, '%Y%m%d') " + "\r";
                sql += "                                                 THEN CAST(koumoku1 AS SIGNED) " + "\r";
                sql += "                                                 ELSE CAST(koumoku3 AS SIGNED) " + "\r";
                sql += "                                            END zeiritu " + "\r";
                sql += "                                     FROM kanri_master " + "\r";
                sql += "                                     WHERE kanriCode = '" + Consts.KanriCodes.ShouhizeiKanri + "' " + "\r";
                sql += "                                   ) AS zeiritu " + "\r";
                sql += "                            FROM tokuisaki_master " + "\r";
                sql += "                          ) tm " + "\r";
                sql += "               ON (ud.tokuisakiCode = tm.tokuisakiCode AND ud.jigyousyoCode = tm.jigyousyoCode) " + "\r";
                sql += "             ) ud " + "\r";
                sql += "  ON (uhb.tokuisakiCode = ud.tokuisakiCode AND uhb.jigyousyoCode = ud.jigyousyoCode AND uhb.ym = ud.ym) " + "\r";
                sql += ") us " + "\r";
                sql += "GROUP BY us.tokuisakiCode, us.jigyousyoCode, us.ym " + "\r";
                registBaseDt = db.executeNoneLockSelect(sql).Copy();

                foreach (DataRow row in registBaseDt.Rows)
                {
                    sql = string.Empty;
                    sql += "SELECT 1 FROM tokuisaki_uriage_syukei ";
                    sql += "WHERE chikuCode = '" + row["chikuCode"] + "' ";
                    sql += "AND tokuisakiCode = '" + row["tokuisakiCode"] + "' ";
                    sql += "AND jigyousyoCode = '" + row["jigyousyoCode"] + "' ";
                    sql += "AND nengetu = '" + row["ym"] + "' ";
                    existsCheckDt = db.executeNoneLockSelect(sql).Copy();

                    sql = string.Empty;
                    if (existsCheckDt == null || existsCheckDt.Rows.Count == 0)
                    {
                        sql += "INSERT INTO tokuisaki_uriage_syukei (chikuCode ";
                        sql += "           , tokuisakiCode ";
                        sql += "           , jigyousyoCode ";
                        sql += "           , nengetu ";
                        sql += "           , day1buzai ";
                        sql += "           , day1kouji ";
                        sql += "           , day1uriageKingaku ";
                        sql += "           , day1zei ";
                        sql += "           , day2buzai ";
                        sql += "           , day2kouji ";
                        sql += "           , day2uriageKingaku ";
                        sql += "           , day2zei ";
                        sql += "           , day3buzai ";
                        sql += "           , day3kouji ";
                        sql += "           , day3uriageKingaku ";
                        sql += "           , day3zei ";
                        sql += "           , day4buzai ";
                        sql += "           , day4kouji ";
                        sql += "           , day4uriageKingaku ";
                        sql += "           , day4zei ";
                        sql += "           , day5buzai ";
                        sql += "           , day5kouji ";
                        sql += "           , day5uriageKingaku ";
                        sql += "           , day5zei ";
                        sql += "           , day6buzai ";
                        sql += "           , day6kouji ";
                        sql += "           , day6uriageKingaku ";
                        sql += "           , day6zei ";
                        sql += "           , day7buzai ";
                        sql += "           , day7kouji ";
                        sql += "           , day7uriageKingaku ";
                        sql += "           , day7zei ";
                        sql += "           , day8buzai ";
                        sql += "           , day8kouji ";
                        sql += "           , day8uriageKingaku ";
                        sql += "           , day8zei ";
                        sql += "           , day9buzai ";
                        sql += "           , day9kouji ";
                        sql += "           , day9uriageKingaku ";
                        sql += "           , day9zei ";
                        sql += "           , day10buzai ";
                        sql += "           , day10kouji ";
                        sql += "           , day10uriageKingaku ";
                        sql += "           , day10zei ";
                        sql += "           , day11buzai ";
                        sql += "           , day11kouji ";
                        sql += "           , day11uriageKingaku ";
                        sql += "           , day11zei ";
                        sql += "           , day12buzai ";
                        sql += "           , day12kouji ";
                        sql += "           , day12uriageKingaku ";
                        sql += "           , day12zei ";
                        sql += "           , day13buzai ";
                        sql += "           , day13kouji ";
                        sql += "           , day13uriageKingaku ";
                        sql += "           , day13zei ";
                        sql += "           , day14buzai ";
                        sql += "           , day14kouji ";
                        sql += "           , day14uriageKingaku ";
                        sql += "           , day14zei ";
                        sql += "           , day15buzai ";
                        sql += "           , day15kouji ";
                        sql += "           , day15uriageKingaku ";
                        sql += "           , day15zei ";
                        sql += "           , day16buzai ";
                        sql += "           , day16kouji ";
                        sql += "           , day16uriageKingaku ";
                        sql += "           , day16zei ";
                        sql += "           , day17buzai ";
                        sql += "           , day17kouji ";
                        sql += "           , day17uriageKingaku ";
                        sql += "           , day17zei ";
                        sql += "           , day18buzai ";
                        sql += "           , day18kouji ";
                        sql += "           , day18uriageKingaku ";
                        sql += "           , day18zei ";
                        sql += "           , day19buzai ";
                        sql += "           , day19kouji ";
                        sql += "           , day19uriageKingaku ";
                        sql += "           , day19zei ";
                        sql += "           , day20buzai ";
                        sql += "           , day20kouji ";
                        sql += "           , day20uriageKingaku ";
                        sql += "           , day20zei ";
                        sql += "           , day21buzai ";
                        sql += "           , day21kouji ";
                        sql += "           , day21uriageKingaku ";
                        sql += "           , day21zei ";
                        sql += "           , day22buzai ";
                        sql += "           , day22kouji ";
                        sql += "           , day22uriageKingaku ";
                        sql += "           , day22zei ";
                        sql += "           , day23buzai ";
                        sql += "           , day23kouji ";
                        sql += "           , day23uriageKingaku ";
                        sql += "           , day23zei ";
                        sql += "           , day24buzai ";
                        sql += "           , day24kouji ";
                        sql += "           , day24uriageKingaku ";
                        sql += "           , day24zei ";
                        sql += "           , day25buzai ";
                        sql += "           , day25kouji ";
                        sql += "           , day25uriageKingaku ";
                        sql += "           , day25zei ";
                        sql += "           , day26buzai ";
                        sql += "           , day26kouji ";
                        sql += "           , day26uriageKingaku ";
                        sql += "           , day26zei ";
                        sql += "           , day27buzai ";
                        sql += "           , day27kouji ";
                        sql += "           , day27uriageKingaku ";
                        sql += "           , day27zei ";
                        sql += "           , day28buzai ";
                        sql += "           , day28kouji ";
                        sql += "           , day28uriageKingaku ";
                        sql += "           , day28zei ";
                        sql += "           , day29buzai ";
                        sql += "           , day29kouji ";
                        sql += "           , day29uriageKingaku ";
                        sql += "           , day29zei ";
                        sql += "           , day30buzai ";
                        sql += "           , day30kouji ";
                        sql += "           , day30uriageKingaku ";
                        sql += "           , day30zei ";
                        sql += "           , day31buzai ";
                        sql += "           , day31kouji ";
                        sql += "           , day31uriageKingaku ";
                        sql += "           , day31zei ";
                        sql += "           , kousinNichizi ";
                        sql += "           , kanriKubun ";
                        sql += "            ) ";
                        sql += "VALUES ";
                        sql += "            ('" + row["chikuCode"] + "' ";
                        sql += "           , '" + row["tokuisakiCode"] + "' ";
                        sql += "           , '" + row["jigyousyoCode"] + "' ";
                        sql += "           , '" + row["ym"] + "' ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day1uriageKingaku"] + " ";
                        sql += "           , " + row["day1zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day2uriageKingaku"] + " ";
                        sql += "           , " + row["day2zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day3uriageKingaku"] + " ";
                        sql += "           , " + row["day3zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day4uriageKingaku"] + " ";
                        sql += "           , " + row["day4zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day5uriageKingaku"] + " ";
                        sql += "           , " + row["day5zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day6uriageKingaku"] + " ";
                        sql += "           , " + row["day6zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day7uriageKingaku"] + " ";
                        sql += "           , " + row["day7zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day8uriageKingaku"] + " ";
                        sql += "           , " + row["day8zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day9uriageKingaku"] + " ";
                        sql += "           , " + row["day9zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day10uriageKingaku"] + " ";
                        sql += "           , " + row["day10zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day11uriageKingaku"] + " ";
                        sql += "           , " + row["day11zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day12uriageKingaku"] + " ";
                        sql += "           , " + row["day12zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day13uriageKingaku"] + " ";
                        sql += "           , " + row["day13zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day14uriageKingaku"] + " ";
                        sql += "           , " + row["day14zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day15uriageKingaku"] + " ";
                        sql += "           , " + row["day15zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day16uriageKingaku"] + " ";
                        sql += "           , " + row["day16zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day17uriageKingaku"] + " ";
                        sql += "           , " + row["day17zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day18uriageKingaku"] + " ";
                        sql += "           , " + row["day18zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day19uriageKingaku"] + " ";
                        sql += "           , " + row["day19zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day20uriageKingaku"] + " ";
                        sql += "           , " + row["day20zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day21uriageKingaku"] + " ";
                        sql += "           , " + row["day21zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day22uriageKingaku"] + " ";
                        sql += "           , " + row["day22zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day23uriageKingaku"] + " ";
                        sql += "           , " + row["day23zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day24uriageKingaku"] + " ";
                        sql += "           , " + row["day24zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day25uriageKingaku"] + " ";
                        sql += "           , " + row["day25zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day26uriageKingaku"] + " ";
                        sql += "           , " + row["day26zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day27uriageKingaku"] + " ";
                        sql += "           , " + row["day27zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day28uriageKingaku"] + " ";
                        sql += "           , " + row["day28zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day29uriageKingaku"] + " ";
                        sql += "           , " + row["day29zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day30uriageKingaku"] + " ";
                        sql += "           , " + row["day30zei"] + " ";
                        sql += "           , 0 ";
                        sql += "           , 0 ";
                        sql += "           , " + row["day31uriageKingaku"] + " ";
                        sql += "           , " + row["day31zei"] + " ";
                        sql += "           , '" + kousinNichizi + "' ";
                        sql += "           , '' ";
                        sql += "            ) ";
                    }
                    else
                    {
                        sql += "UPDATE tokuisaki_uriage_syukei ";
                        sql += "SET nengetu = '" + row["ym"] + "' ";
                        sql += "  , day1uriageKingaku = " + row["day1uriageKingaku"] + " ";
                        sql += "  , day1zei = " + row["day1zei"] + " ";
                        sql += "  , day2uriageKingaku = " + row["day2uriageKingaku"] + " ";
                        sql += "  , day2zei = " + row["day2zei"] + " ";
                        sql += "  , day3uriageKingaku = " + row["day3uriageKingaku"] + " ";
                        sql += "  , day3zei = " + row["day3zei"] + " ";
                        sql += "  , day4uriageKingaku = " + row["day4uriageKingaku"] + " ";
                        sql += "  , day4zei = " + row["day4zei"] + " ";
                        sql += "  , day5uriageKingaku = " + row["day5uriageKingaku"] + " ";
                        sql += "  , day5zei = " + row["day5zei"] + " ";
                        sql += "  , day6uriageKingaku = " + row["day6uriageKingaku"] + " ";
                        sql += "  , day6zei = " + row["day6zei"] + " ";
                        sql += "  , day7uriageKingaku = " + row["day7uriageKingaku"] + " ";
                        sql += "  , day7zei = " + row["day7zei"] + " ";
                        sql += "  , day8uriageKingaku = " + row["day8uriageKingaku"] + " ";
                        sql += "  , day8zei = " + row["day8zei"] + " ";
                        sql += "  , day9uriageKingaku = " + row["day9uriageKingaku"] + " ";
                        sql += "  , day9zei = " + row["day9zei"] + " ";
                        sql += "  , day10uriageKingaku = " + row["day10uriageKingaku"] + " ";
                        sql += "  , day10zei = " + row["day10zei"] + " ";
                        sql += "  , day11uriageKingaku = " + row["day11uriageKingaku"] + " ";
                        sql += "  , day11zei = " + row["day11zei"] + " ";
                        sql += "  , day12uriageKingaku = " + row["day12uriageKingaku"] + " ";
                        sql += "  , day12zei = " + row["day12zei"] + " ";
                        sql += "  , day13uriageKingaku = " + row["day13uriageKingaku"] + " ";
                        sql += "  , day13zei = " + row["day13zei"] + " ";
                        sql += "  , day14uriageKingaku = " + row["day14uriageKingaku"] + " ";
                        sql += "  , day14zei = " + row["day14zei"] + " ";
                        sql += "  , day15uriageKingaku = " + row["day15uriageKingaku"] + " ";
                        sql += "  , day15zei = " + row["day15zei"] + " ";
                        sql += "  , day16uriageKingaku = " + row["day16uriageKingaku"] + " ";
                        sql += "  , day16zei = " + row["day16zei"] + " ";
                        sql += "  , day17uriageKingaku = " + row["day17uriageKingaku"] + " ";
                        sql += "  , day17zei = " + row["day17zei"] + " ";
                        sql += "  , day18uriageKingaku = " + row["day18uriageKingaku"] + " ";
                        sql += "  , day18zei = " + row["day18zei"] + " ";
                        sql += "  , day19uriageKingaku = " + row["day19uriageKingaku"] + " ";
                        sql += "  , day19zei = " + row["day19zei"] + " ";
                        sql += "  , day20uriageKingaku = " + row["day20uriageKingaku"] + " ";
                        sql += "  , day20zei = " + row["day20zei"] + " ";
                        sql += "  , day21uriageKingaku = " + row["day21uriageKingaku"] + " ";
                        sql += "  , day21zei = " + row["day21zei"] + " ";
                        sql += "  , day22uriageKingaku = " + row["day22uriageKingaku"] + " ";
                        sql += "  , day22zei = " + row["day22zei"] + " ";
                        sql += "  , day23uriageKingaku = " + row["day23uriageKingaku"] + " ";
                        sql += "  , day23zei = " + row["day23zei"] + " ";
                        sql += "  , day24uriageKingaku = " + row["day24uriageKingaku"] + " ";
                        sql += "  , day24zei = " + row["day24zei"] + " ";
                        sql += "  , day25uriageKingaku = " + row["day25uriageKingaku"] + " ";
                        sql += "  , day25zei = " + row["day25zei"] + " ";
                        sql += "  , day26uriageKingaku = " + row["day26uriageKingaku"] + " ";
                        sql += "  , day26zei = " + row["day26zei"] + " ";
                        sql += "  , day27uriageKingaku = " + row["day27uriageKingaku"] + " ";
                        sql += "  , day27zei = " + row["day27zei"] + " ";
                        sql += "  , day28uriageKingaku = " + row["day28uriageKingaku"] + " ";
                        sql += "  , day28zei = " + row["day28zei"] + " ";
                        sql += "  , day29uriageKingaku = " + row["day29uriageKingaku"] + " ";
                        sql += "  , day29zei = " + row["day29zei"] + " ";
                        sql += "  , day30uriageKingaku = " + row["day30uriageKingaku"] + " ";
                        sql += "  , day30zei = " + row["day30zei"] + " ";
                        sql += "  , day31uriageKingaku = " + row["day31uriageKingaku"] + " ";
                        sql += "  , day31zei = " + row["day31zei"] + " ";
                        sql += "  , kousinNichizi = '" + kousinNichizi + "' ";
                        sql += "  , kanriKubun = '' ";
                        sql += "WHERE chikuCode = '" + row["chikuCode"] + "' ";
                        sql += "AND tokuisakiCode = '" + row["tokuisakiCode"] + "' ";
                        sql += "AND jigyousyoCode = '" + row["jigyousyoCode"] + "' ";
                        sql += "AND nengetu = '" + row["ym"] + "' ";
                    }
                    registSql.Add(sql);
                }

                monthCount--;
                denpyoHizukeFrom = denpyoHizukeFrom.AddMonths(1);
                denpyoHizukeTo = denpyoHizukeTo.AddMonths(1);
            }

            db.startTransaction();
            foreach (string command in registSql)
            {
                db.executeDBUpdate(command);
                if (db.DBRef < 0) break;
            }
            db.endTransaction();
        }
        #endregion

        #endregion
    }
}
