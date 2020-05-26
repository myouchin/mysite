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

namespace UriageHibetuSoukatu
{
    /// <summary>
    /// 売上日別総括表
    /// </summary>
    public partial class frmUriageHibetuSoukatu : Common.ChildBaseForm
    {
        #region 変数宣言
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private CommonLogic commonLogic;
        private string nen;
        private string tuki;
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
        public frmUriageHibetuSoukatu()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUriageHibetuSoukatu_Load(object sender, EventArgs e)
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

        #region 必須入力チェック処理
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;

            // TODO

            return ret;
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
            sql += "SELECT hi AS day ";
            sql += "     , uriage AS uriage ";
            sql += "     , ruikei AS ruikei ";
            sql += "FROM uriage_soukatu ";
            sql += "WHERE nengetu = " + nen + tuki + " ";
            sql += "AND hi {0} 15 ";
            sql += "ORDER BY hi ";
            DataTable dataSource1 = db.executeNoneLockSelect(string.Format(sql, "<="));
            DataTable dataSource2 = db.executeNoneLockSelect(string.Format(sql, ">"));
            dataSource1.Rows.Add();
            grdDayList1.DataSource = dataSource1.Copy();
            grdDayList2.DataSource = dataSource2.Copy();

            sql = string.Empty;
            sql += "SELECT SUM(IFNULL(koujiUriage, 0)) AS koujiUriageGoukei ";
            sql += "     , SUM(IFNULL(shireUriage, 0)) AS shireUriageGoukei ";
            sql += "FROM uriage_soukatu ";
            sql += "WHERE nengetu = " + nen + tuki + " ";
            DataTable totalDt = db.executeNoneLockSelect(sql);
            if (totalDt.Rows.Count > 0)
            {
                lblKoujiUriage2.Text = Convert.ToDecimal(totalDt.Rows[0]["koujiUriageGoukei"]).ToString("#,##0");
                lblShireUriage2.Text = Convert.ToDecimal(totalDt.Rows[0]["shireUriageGoukei"]).ToString("#,##0");
            }
            else
            {
                lblKoujiUriage2.Text = string.Empty;
                lblShireUriage2.Text = string.Empty;
            }
        }
        #endregion

        #region 売上日別総括表データ登録処理
        /// <summary>
        /// 売上日別総括表データ登録処理
        /// </summary>
        private void registData()
        {
            DBCommon db = new DBCommon();
            string sql = string.Empty;
            DateTime registDate = DateTime.Now;
            DateTime targetDateFrom = Convert.ToDateTime(nen + "-" + tuki + "-01");
            DateTime targetDateTo = Convert.ToDateTime(nen + "-" + tuki + "-" + commonLogic.GetEndOfMonth(nen, tuki));

            #region 売上日別総括表データ取得
            sql += "SELECT souketu.year ";
            sql += "     , souketu.month ";
            sql += "     , souketu.day ";
            sql += "     , CASE WHEN SUM(IFNULL(souketu.koujiUriage, 0)) = 0 ";
            sql += "               THEN NULL ";
            sql += "               ELSE SUM(IFNULL(souketu.koujiUriage, 0)) ";
            sql += "        END AS koujiUriage ";
            sql += "      , CASE WHEN SUM(IFNULL(souketu.shireUriage, 0)) = 0 ";
            sql += "               THEN NULL ";
            sql += "               ELSE SUM(IFNULL(souketu.shireUriage, 0)) ";
            sql += "        END AS shireUriage ";
            sql += "      , CASE WHEN SUM(IFNULL(souketu.uriageKingaku, 0)) = 0 ";
            sql += "               THEN NULL ";
            sql += "               ELSE SUM(IFNULL(souketu.uriageKingaku, 0)) ";
            sql += "        END AS uriageKingaku ";
            sql += "FROM ( ";
            sql += "      SELECT uh.year AS year ";
            sql += "           , uh.month AS month ";
            sql += "           , uh.day AS day ";
            sql += "           , CASE WHEN jh.zairyoKoujiKubun = '02' ";
            sql += "                    THEN SUM(IFNULL(ub.kingaku, 0)) ";
            sql += "                    ELSE 0 ";
            sql += "             END AS koujiUriage ";
            sql += "           , CASE WHEN jh.zairyoKoujiKubun <> '02' ";
            sql += "                    THEN SUM(IFNULL(ub.kingaku, 0)) ";
            sql += "                    ELSE 0 ";
            sql += "             END AS shireUriage ";
            sql += "           , SUM(IFNULL(ub.kingaku, 0)) AS uriageKingaku ";
            sql += "      FROM (SELECT * ";
            sql += "                 , CAST(DATE_FORMAT(denpyoHizuke, '%Y') AS SIGNED) AS year ";
            sql += "                 , CAST(DATE_FORMAT(denpyoHizuke, '%m') AS SIGNED) AS month ";
            sql += "                 , CAST(DATE_FORMAT(denpyoHizuke, '%d') AS SIGNED) AS day ";
            sql += "            FROM uriage_header ";
            sql += "            WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "            AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "            AND denpyoHizuke <= '" + targetDateTo + "' ";
            sql += "           ) uh ";
            sql += "      INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            sql += "      ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "      INNER JOIN (SELECT * FROM juchu_header) jh ";
            sql += "      ON (uh.juchuNoTop = jh.juchuNoTop AND uh.juchuNoMid = jh.juchuNoMid AND uh.juchuNoBtm = jh.juchuNoBtm) ";
            sql += "      GROUP BY uh.year, uh.month, uh.day, jh.zairyoKoujiKubun ";
            sql += "     ) souketu ";
            sql += "GROUP BY souketu.year, souketu.month, souketu.day ";
            sql += "ORDER BY souketu.year, souketu.month, souketu.day ";
            DataTable soukatuDataDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 売上日別総括表データ登録SQL生成
            string koujiUriage = string.Empty;
            string shireUriage = string.Empty;
            string uriage = string.Empty;
            string ruikei = string.Empty;
            int maxDay = 0;
            if (soukatuDataDt.Rows.Count > 0) maxDay = Convert.ToInt16(soukatuDataDt.Rows[soukatuDataDt.Rows.Count - 1]["day"]);
            List<string> commands = new List<string>();
            commands.Add("DELETE FROM uriage_soukatu WHERE nengetu = '" + nen + tuki + "' ");
            for (int i = 1; i <= 31; i++)
            {
                koujiUriage = string.Empty;
                shireUriage = string.Empty;
                uriage = string.Empty;
                var query = soukatuDataDt.AsEnumerable().Where(p => p.Field<int>("day") == i);
            if (query.Count() > 0)
                {
                    koujiUriage = Convert.ToString(query.ElementAt(0)["koujiUriage"]);
                    shireUriage = Convert.ToString(query.ElementAt(0)["shireUriage"]);
                    uriage = Convert.ToString(query.ElementAt(0)["uriageKingaku"]);
                    if (!string.IsNullOrEmpty(uriage))
                    {
                        if (string.IsNullOrEmpty(ruikei))
                        {
                            ruikei = uriage;
                        }
                        else
                        {
                            ruikei = Convert.ToString(Convert.ToDecimal(ruikei) + Convert.ToDecimal(uriage));
                        }
                    }
                }
                sql = string.Empty;
                sql += "INSERT INTO uriage_soukatu ";
                sql += "( ";
                sql += "  nengetu ";
                sql += ", hi ";
                sql += ", koujiUriage ";
                sql += ", shireUriage ";
                sql += ", uriage ";
                sql += ", ruikei ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "  " + nen + tuki + " ";
                sql += ", " + Convert.ToString(i) + " ";
                sql += ", " + (!string.IsNullOrEmpty(koujiUriage) ? koujiUriage : "NULL") + " ";
                sql += ", " + (!string.IsNullOrEmpty(shireUriage) ? shireUriage : "NULL") + " ";
                sql += ", " + (!string.IsNullOrEmpty(uriage) ? uriage : "NULL") + " ";
                sql += ", " + (!string.IsNullOrEmpty(ruikei) && i <= maxDay ? ruikei : "NULL") + " ";
                sql += ", '" + registDate + "' ";
                sql += ", '' ";
                sql += ") ";
                commands.Add(sql);
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

        #endregion

    }
}
