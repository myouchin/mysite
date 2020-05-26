using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using Resorce;
using Common;
using SubForm;

namespace Nakakita
{
    /// <summary>
    /// 中北電機事業所別売上
    /// </summary>
    public partial class frmNakakitaJigyousyobetuUriage : Common.ChildBaseForm
    {
        #region 変数宣言
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private CommonLogic commonLogic;
        private string nen;
        private string tuki;
        private Dictionary<string, int> dicColumnIndex;
        private enum LastInputDateType
        {
            None = 0
          , TargetDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmNakakitaJigyousyobetuUriage()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            createGridColumn();
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNakakitaJigyousyobetuUriage_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtTargetDateYears;
            txtTargetDateYears.Text = Convert.ToString(syoriDate.Year);
            txtTargetDateMonth.Text = Convert.ToString(syoriDate.Month);
            nen = txtTargetDateYears.Text;
            tuki = txtTargetDateMonth.Text;
            // 入力情報設定
            setInputInfo();
            // グリッド再表示
            setGridData();
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
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    break;
                // F1キーが押下された場合
                case Keys.F1:
                    // 一覧表示処理を実行
                    btnDisp_Click(null, null);
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
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.TargetDate:
                        y = txtTargetDateYears.Text;
                        m = txtTargetDateMonth.Text;
                        d = "01";
                        inputObj = dtpTargetDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
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

            if (c is CustomTextBox)
            {
                ((CustomTextBox)c).BeforeValue = ((CustomTextBox)c).Text;
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
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

        #region 閉じるボタン押下イベント
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!btnClose.Enabled) return;
            closedForm();
        }
        #endregion

        #region 一覧表示ボタン押下イベント
        /// <summary>
        /// 一覧表示ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisp_Click(object sender, EventArgs e)
        {
            // グリッド再表示
            setGridData();
        }
        #endregion

        #region 年月のフォーカスインイベント
        /// <summary>
        /// 年月のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void targetDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDate)
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
        private void targetDate_Leave(object sender, EventArgs e)
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

        #endregion

        #region ビジネスロジック

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
                c.Enter += new EventHandler(this.targetDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.targetDate_Leave);
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

        #region グリッド設定処理
        /// <summary>
        /// グリッド設定処理
        /// </summary>
        private void setGridData()
        {
            nen = txtTargetDateYears.Text;
            tuki = txtTargetDateMonth.Text;

            // データ登録処理実行
            registData();

            DBCommon db = new DBCommon();
            string sql = string.Empty;

            sql = string.Empty;
            sql += "SELECT tm.jigyousyoCode ";
            sql += "     , nju.1DayUriage AS office1Day ";
            sql += "     , nju.2DayUriage AS office2Day ";
            sql += "     , nju.3DayUriage AS office3Day ";
            sql += "     , nju.4DayUriage AS office4Day ";
            sql += "     , nju.5DayUriage AS office5Day ";
            sql += "     , nju.6DayUriage AS office6Day ";
            sql += "     , nju.7DayUriage AS office7Day ";
            sql += "     , nju.8DayUriage AS office8Day ";
            sql += "     , nju.9DayUriage AS office9Day ";
            sql += "     , nju.10DayUriage AS office10Day ";
            sql += "     , nju.11DayUriage AS office11Day ";
            sql += "     , nju.12DayUriage AS office12Day ";
            sql += "     , nju.13DayUriage AS office13Day ";
            sql += "     , nju.14DayUriage AS office14Day ";
            sql += "     , nju.15DayUriage AS office15Day ";
            sql += "     , nju.16DayUriage AS office16Day ";
            sql += "     , nju.17DayUriage AS office17Day ";
            sql += "     , nju.18DayUriage AS office18Day ";
            sql += "     , nju.19DayUriage AS office19Day ";
            sql += "     , nju.20DayUriage AS office20Day ";
            sql += "     , nju.21DayUriage AS office21Day ";
            sql += "     , nju.22DayUriage AS office22Day ";
            sql += "     , nju.23DayUriage AS office23Day ";
            sql += "     , nju.24DayUriage AS office24Day ";
            sql += "     , nju.25DayUriage AS office25Day ";
            sql += "     , nju.26DayUriage AS office26Day ";
            sql += "     , nju.27DayUriage AS office27Day ";
            sql += "     , nju.28DayUriage AS office28Day ";
            sql += "     , nju.29DayUriage AS office29Day ";
            sql += "     , nju.30DayUriage AS office30Day ";
            sql += "     , nju.31DayUriage AS office31Day ";
            sql += "FROM (SELECT * FROM nakakita_jigyousyo_uriage WHERE nengetu = '" + nen + tuki + "') nju ";
            sql += "INNER JOIN (SELECT * FROM tokuisaki_master WHERE tokuisakiCode = '10001') tm "; //TODO
            sql += "ON (nju.jigyousyoCode = tm.jigyousyoCode) ";
            sql += "ORDER BY nju.jigyousyoCode ";
            DataTable jigyousyoDt = db.executeNoneLockSelect(sql);

            #region グリッド表示データ追加
            DataTable dataSource = ((DataTable)grdOffice.DataSource).Clone();
            DataRow newRow;
            string jigyousyoCode;
            string amount = string.Empty;
            string total = string.Empty;
            Dictionary<string, string> jigyousyoTotal = new Dictionary<string, string>();
            for (int i = 1; i <= 31; i++)
            {
                newRow = dataSource.NewRow();
                newRow["day"] = Convert.ToString(i);
                amount = string.Empty;
                total = string.Empty;
                foreach (DataRow jigyousyoRow in jigyousyoDt.Rows)
                {
                    jigyousyoCode = Convert.ToString(jigyousyoRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                    if (!jigyousyoTotal.ContainsKey(jigyousyoCode)) jigyousyoTotal.Add(jigyousyoCode, string.Empty);
                    newRow[dicColumnIndex[jigyousyoCode]] = jigyousyoRow["office" + Convert.ToString(i) + "Day"];
                    amount = Convert.ToString(jigyousyoRow["office" + Convert.ToString(i) + "Day"]);
                    if (!string.IsNullOrEmpty(amount))
                    {
                        if (string.IsNullOrEmpty(total))
                        {
                            total = amount;
                        }
                        else
                        {
                            total = Convert.ToString(Convert.ToDecimal(total) + Convert.ToDecimal(amount));
                        }
                        if (string.IsNullOrEmpty(jigyousyoTotal[jigyousyoCode]))
                        {
                            jigyousyoTotal[jigyousyoCode] = amount;
                        }
                        else
                        {
                            jigyousyoTotal[jigyousyoCode] = Convert.ToString(Convert.ToDecimal(jigyousyoTotal[jigyousyoCode]) + Convert.ToDecimal(amount));
                        }
                    }
                }
                if (!string.IsNullOrEmpty(total)) newRow[dicColumnIndex["TOTAL"]] = total;
                dataSource.Rows.InsertAt(newRow, i - 1);
            }
            #endregion

            #region 縦計行追加
            newRow = dataSource.NewRow();
            newRow["day"] = "合計";
            foreach (KeyValuePair<string, int> columIndex in dicColumnIndex)
            {
                if (columIndex.Key.Equals("TOTAL")) continue;
                if (!jigyousyoTotal.ContainsKey(columIndex.Key)) continue;
                amount = jigyousyoTotal[columIndex.Key];
                if (!string.IsNullOrEmpty(amount))
                {
                    newRow[columIndex.Value] = amount;
                    if (string.IsNullOrEmpty(total))
                    {
                        total = amount;
                    }
                    else
                    {
                        total = Convert.ToString(Convert.ToDecimal(total) + Convert.ToDecimal(amount));
                    }
                }
            }
            if (!string.IsNullOrEmpty(total)) newRow[dicColumnIndex["TOTAL"]] = total;
            dataSource.Rows.Add(newRow.ItemArray);
            #endregion

            grdOffice.DataSource = dataSource.Copy();

        }
        #endregion

        #region 中北電機データ登録処理
        /// <summary>
        /// 中北電機データ登録処理
        /// </summary>
        private void registData()
        {
            DBCommon db = new DBCommon();
            string sql = string.Empty;
            DateTime registDate = DateTime.Now;
            DateTime targetDateFrom = Convert.ToDateTime(nen + "-" + tuki + "-01");
            DateTime targetDateTo = Convert.ToDateTime(nen + "-" + tuki + "-" + commonLogic.GetEndOfMonth(nen, tuki));

            #region 得意先情報取得
            sql = string.Empty;
            sql += "SELECT * FROM tokuisaki_master WHERE (kanriKubun IS NULL OR kanriKubun <> '9') AND tokuisakiCode = '10001' ORDER BY jigyousyoCode ";//TODO
            DataTable tokuisakiDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 事業所別データ取得
            sql = string.Empty;
            sql += "SELECT tm.jigyousyoCode ";
            sql += "     , tm.jigyousyoName ";
            sql += "     , uh.year ";
            sql += "     , uh.month ";
            sql += "     , uh.day ";
            sql += "     , SUM(IFNULL(ub.kingaku, 0)) uriageKingaku ";
            sql += "FROM (SELECT * FROM tokuisaki_master WHERE tokuisakiCode = '10001') tm "; // TODO
            sql += "INNER JOIN (SELECT * ";
            sql += "                 , CAST(DATE_FORMAT(denpyoHizuke, '%Y') AS SIGNED) AS year ";
            sql += "                 , CAST(DATE_FORMAT(denpyoHizuke, '%m') AS SIGNED) AS month ";
            sql += "                 , CAST(DATE_FORMAT(denpyoHizuke, '%d') AS SIGNED) AS day ";
            sql += "            FROM uriage_header ";
            sql += "            WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "            AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "            AND denpyoHizuke <= '" + targetDateTo + "' ";
            sql += "           ) uh ";
            sql += "ON (tm.tokuisakiCode = uh.tokuisakiCode AND tm.jigyousyoCode = uh.jigyousyoCode) ";
            sql += "INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            sql += "ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "GROUP BY tm.jigyousyoCode, uh.year, uh.month, uh.day ";
            sql += "ORDER BY tm.jigyousyoCode, uh.year, uh.month, uh.day ";
            DataTable jigyousyoDataDt = db.executeNoneLockSelect(sql);
            #endregion

            List<string> commands = new List<string>();
            string jigyousyoCode;
            string day;
            string day1Uriage = "NULL";
            string day2Uriage = "NULL";
            string day3Uriage = "NULL";
            string day4Uriage = "NULL";
            string day5Uriage = "NULL";
            string day6Uriage = "NULL";
            string day7Uriage = "NULL";
            string day8Uriage = "NULL";
            string day9Uriage = "NULL";
            string day10Uriage = "NULL";
            string day11Uriage = "NULL";
            string day12Uriage = "NULL";
            string day13Uriage = "NULL";
            string day14Uriage = "NULL";
            string day15Uriage = "NULL";
            string day16Uriage = "NULL";
            string day17Uriage = "NULL";
            string day18Uriage = "NULL";
            string day19Uriage = "NULL";
            string day20Uriage = "NULL";
            string day21Uriage = "NULL";
            string day22Uriage = "NULL";
            string day23Uriage = "NULL";
            string day24Uriage = "NULL";
            string day25Uriage = "NULL";
            string day26Uriage = "NULL";
            string day27Uriage = "NULL";
            string day28Uriage = "NULL";
            string day29Uriage = "NULL";
            string day30Uriage = "NULL";
            string day31Uriage = "NULL";

            #region 事業所別データ登録SQL生成
            List<string> jigyousyoCodes = new List<string>();
            commands.Add("DELETE FROM nakakita_jigyousyo_uriage WHERE nengetu = '" + nen + tuki + "' ");
            foreach (DataRow jigyousyoRow in jigyousyoDataDt.Rows)
            {
                jigyousyoCode = Convert.ToString(jigyousyoRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                if (jigyousyoCodes.Contains(jigyousyoCode)) continue;
                day1Uriage = "NULL";
                day2Uriage = "NULL";
                day3Uriage = "NULL";
                day4Uriage = "NULL";
                day5Uriage = "NULL";
                day6Uriage = "NULL";
                day7Uriage = "NULL";
                day8Uriage = "NULL";
                day9Uriage = "NULL";
                day10Uriage = "NULL";
                day11Uriage = "NULL";
                day12Uriage = "NULL";
                day13Uriage = "NULL";
                day14Uriage = "NULL";
                day15Uriage = "NULL";
                day16Uriage = "NULL";
                day17Uriage = "NULL";
                day18Uriage = "NULL";
                day19Uriage = "NULL";
                day20Uriage = "NULL";
                day21Uriage = "NULL";
                day22Uriage = "NULL";
                day23Uriage = "NULL";
                day24Uriage = "NULL";
                day25Uriage = "NULL";
                day26Uriage = "NULL";
                day27Uriage = "NULL";
                day28Uriage = "NULL";
                day29Uriage = "NULL";
                day30Uriage = "NULL";
                day31Uriage = "NULL";
                var query = jigyousyoDataDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode).Equals(jigyousyoCode)).OrderBy(p => jigyousyoDataDt.Rows.IndexOf(p));
                foreach (DataRow row in query)
                {
                    day = Convert.ToString(row["day"]);
                    if ("1".Equals(day))
                    {
                        day1Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("2".Equals(day))
                    {
                        day2Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("3".Equals(day))
                    {
                        day3Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("4".Equals(day))
                    {
                        day4Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("5".Equals(day))
                    {
                        day5Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("6".Equals(day))
                    {
                        day6Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("7".Equals(day))
                    {
                        day7Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("8".Equals(day))
                    {
                        day8Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("9".Equals(day))
                    {
                        day9Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("10".Equals(day))
                    {
                        day10Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("11".Equals(day))
                    {
                        day11Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("12".Equals(day))
                    {
                        day12Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("13".Equals(day))
                    {
                        day13Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("14".Equals(day))
                    {
                        day14Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("15".Equals(day))
                    {
                        day15Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("16".Equals(day))
                    {
                        day16Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("17".Equals(day))
                    {
                        day17Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("18".Equals(day))
                    {
                        day18Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("19".Equals(day))
                    {
                        day19Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("20".Equals(day))
                    {
                        day20Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("21".Equals(day))
                    {
                        day21Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("22".Equals(day))
                    {
                        day22Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("23".Equals(day))
                    {
                        day23Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("24".Equals(day))
                    {
                        day24Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("25".Equals(day))
                    {
                        day25Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("26".Equals(day))
                    {
                        day26Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("27".Equals(day))
                    {
                        day27Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("28".Equals(day))
                    {
                        day28Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("29".Equals(day))
                    {
                        day29Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("30".Equals(day))
                    {
                        day30Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                    else if ("31".Equals(day))
                    {
                        day31Uriage = Convert.ToString(row["uriageKingaku"]);
                    }
                }
                sql = string.Empty;
                sql += "INSERT INTO nakakita_jigyousyo_uriage ";
                sql += "( ";
                sql += "  jigyousyoCode ";
                sql += ", nengetu ";
                sql += ", 1DayUriage ";
                sql += ", 2DayUriage ";
                sql += ", 3DayUriage ";
                sql += ", 4DayUriage ";
                sql += ", 5DayUriage ";
                sql += ", 6DayUriage ";
                sql += ", 7DayUriage ";
                sql += ", 8DayUriage ";
                sql += ", 9DayUriage ";
                sql += ", 10DayUriage ";
                sql += ", 11DayUriage ";
                sql += ", 12DayUriage ";
                sql += ", 13DayUriage ";
                sql += ", 14DayUriage ";
                sql += ", 15DayUriage ";
                sql += ", 16DayUriage ";
                sql += ", 17DayUriage ";
                sql += ", 18DayUriage ";
                sql += ", 19DayUriage ";
                sql += ", 20DayUriage ";
                sql += ", 21DayUriage ";
                sql += ", 22DayUriage ";
                sql += ", 23DayUriage ";
                sql += ", 24DayUriage ";
                sql += ", 25DayUriage ";
                sql += ", 26DayUriage ";
                sql += ", 27DayUriage ";
                sql += ", 28DayUriage ";
                sql += ", 29DayUriage ";
                sql += ", 30DayUriage ";
                sql += ", 31DayUriage ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "  '" + jigyousyoCode + "' ";
                sql += ", '" + nen + tuki + "' ";
                sql += ", " + day1Uriage + " ";
                sql += ", " + day2Uriage + " ";
                sql += ", " + day3Uriage + " ";
                sql += ", " + day4Uriage + " ";
                sql += ", " + day5Uriage + " ";
                sql += ", " + day6Uriage + " ";
                sql += ", " + day7Uriage + " ";
                sql += ", " + day8Uriage + " ";
                sql += ", " + day9Uriage + " ";
                sql += ", " + day10Uriage + " ";
                sql += ", " + day11Uriage + " ";
                sql += ", " + day12Uriage + " ";
                sql += ", " + day13Uriage + " ";
                sql += ", " + day14Uriage + " ";
                sql += ", " + day15Uriage + " ";
                sql += ", " + day16Uriage + " ";
                sql += ", " + day17Uriage + " ";
                sql += ", " + day18Uriage + " ";
                sql += ", " + day19Uriage + " ";
                sql += ", " + day20Uriage + " ";
                sql += ", " + day21Uriage + " ";
                sql += ", " + day22Uriage + " ";
                sql += ", " + day23Uriage + " ";
                sql += ", " + day24Uriage + " ";
                sql += ", " + day25Uriage + " ";
                sql += ", " + day26Uriage + " ";
                sql += ", " + day27Uriage + " ";
                sql += ", " + day28Uriage + " ";
                sql += ", " + day29Uriage + " ";
                sql += ", " + day30Uriage + " ";
                sql += ", " + day31Uriage + " ";
                sql += ", '" + registDate + "' ";
                sql += ", '' ";
                sql += ") ";
                commands.Add(sql);
                jigyousyoCodes.Add(jigyousyoCode);
            }
            #endregion

            #region データ登録実行
            db.startTransaction();
            foreach (string cmd in commands)
            {
                db.executeDBUpdate(cmd);
            }
            db.endTransaction();
            #endregion

        }
        #endregion

        #region グリッド列追加処理
        /// <summary>
        /// グリッド列追加処理
        /// </summary>
        private void createGridColumn()
        {
            DBCommon db = new DBCommon();
            string sql = string.Empty;
            dicColumnIndex = new Dictionary<string, int>();

            #region 得意先情報取得
            sql = string.Empty;
            sql += "SELECT * FROM tokuisaki_master WHERE (kanriKubun IS NULL OR kanriKubun <> '9') AND tokuisakiCode = '10001' ORDER BY jigyousyoCode "; // TODO
            DataTable tokuisakiDt = db.executeNoneLockSelect(sql);
            #endregion

            DataGridViewCellStyle cellstyle = new DataGridViewCellStyle();
            cellstyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellstyle.Format = "N0";
            cellstyle.NullValue = null;
            cellstyle.SelectionBackColor = System.Drawing.Color.White;
            cellstyle.SelectionForeColor = System.Drawing.Color.Black;

            int startIndex = grdOffice.Columns.Count - 1;
            int index = startIndex;
            int maxWidth = 0;
            DataGridViewColumn clm;
            foreach (DataRow jigyousyoRow in tokuisakiDt.Rows)
            {
                index++;
                clm = new DataGridViewColumn();
                clm.CellTemplate = new DataGridViewTextBoxCell();
                clm.DataPropertyName = "jigyousyo" + Convert.ToString(index) + "Uriage";
                clm.DefaultCellStyle = cellstyle;
                clm.HeaderText = Convert.ToString(jigyousyoRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoName]);
                clm.Name = "clmJigyousyo" + Convert.ToString(index);
                clm.ReadOnly = true;
                clm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                grdOffice.Columns.Add(clm);

                dicColumnIndex.Add(Convert.ToString(jigyousyoRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]), index);
                if (maxWidth < clm.HeaderText.Length * 23)
                {
                    maxWidth = clm.HeaderText.Length * 23;
                }
            }
            if (maxWidth <= 100) maxWidth = 100;
            index++;
            clm = new DataGridViewColumn();
            clm.CellTemplate = new DataGridViewTextBoxCell();
            clm.DataPropertyName = "jigyousyoUriageTotal";
            clm.DefaultCellStyle = cellstyle;
            clm.HeaderText = "合計";
            clm.Name = "clmJigyousyoUriageTotal";
            clm.ReadOnly = true;
            clm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            grdOffice.Columns.Add(clm);
            dicColumnIndex.Add("TOTAL", index);
            for (int i = startIndex + 1; i < grdOffice.Columns.Count; i++)
            {
                grdOffice.Columns[i].Width = maxWidth;
            }

            int gridTotalWidth = 21;
            DataTable dataSource = new DataTable();
            foreach (DataGridViewColumn gClm in grdOffice.Columns)
            {
                if (gClm.DataPropertyName.Contains("jigyousyo"))
                {
                    dataSource.Columns.Add(gClm.DataPropertyName, Type.GetType("System.Decimal"));
                }
                else
                {
                    dataSource.Columns.Add(gClm.DataPropertyName, Type.GetType("System.String"));
                }
                gridTotalWidth += gClm.Width;
            }
            grdOffice.DataSource = dataSource.Copy();

            this.Width = gridTotalWidth + 27;
            grdOffice.Width = gridTotalWidth;
            btnClose.Location = new Point(this.Width - 139, btnClose.Location.Y);
        }
        #endregion

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable, Common.CustomDateTimePicker inputObj)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
            {
                ret = true;
            }
            else
            {
                DateTime date;
                DateTime wkdate;
                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
                if (ret && inputObj != null)
                {
                    wkdate = date.AddDays(1);
                    inputObj.Value = wkdate;
                    inputObj.Value = date;
                }
            }
            return ret;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTargetDateYears.MaxLength = 4;    // 対象年月(年)
            txtTargetDateMonth.MaxLength = 2;    // 対象年月(月)

            // 入力制御イベント設定
            txtTargetDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象年度       :数字のみ入力可
            txtTargetDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象年度       :数字のみ入力可
        }
        #endregion

        #endregion

    }
}
