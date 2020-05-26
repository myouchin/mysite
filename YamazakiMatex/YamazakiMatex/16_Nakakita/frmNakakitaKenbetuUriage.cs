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
    /// 中北電機県別売上
    /// </summary>
    public partial class frmNakakitaKenbetuUriage : Common.ChildBaseForm
    {
        #region 変数宣言
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private CommonLogic commonLogic;
        private string displayNendo;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmNakakitaKenbetuUriage()
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
        private void frmNakakitaKenbetuUriage_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtTargetYear;
            txtTargetYear.Text = syoriDate.Month >= 10 ? Convert.ToString(syoriDate.Year) : Convert.ToString(syoriDate.Year - 1);
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
                // F11キーが押下された場合
                case Keys.F11:
                    // 次頁表示処理を実行
                    btnNextPage_Click(null, null);
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

        #region 次頁ボタン押下イベント
        /// <summary>
        /// 次頁ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            frmNakakitaTantousyabetuUriage frm = new frmNakakitaTantousyabetuUriage(displayNendo);
            showChildForm(frm);

            if (frm.DialogResult == DialogResult.OK) closedForm();

            txtTargetYear.Text = displayNendo;
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
            txtTargetYear.MaxLength = 4;    // 対象年度

            // 入力制御イベント設定
            txtTargetYear.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 対象年度       :数字のみ入力可
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
            displayNendo = txtTargetYear.Text;
            // データ登録処理実行
            registData();

            DBCommon db = new DBCommon();
            string sql = string.Empty;
            int shitenMinCount = 11;
            int kenMinCount = 8;
            DataRow newRow;

            sql = string.Empty;
            sql += "SELECT * ";
            sql += "FROM ( ";
            sql += "       SELECT tm.jigyousyoName AS office ";
            sql += "            , nsu.10GatsuUriage AS office10Month ";
            sql += "            , nsu.11GatsuUriage AS office11Month ";
            sql += "            , nsu.12GatsuUriage AS office12Month ";
            sql += "            , nsu.1GatsuUriage AS office1Month ";
            sql += "            , nsu.2GatsuUriage AS office2Month ";
            sql += "            , nsu.3GatsuUriage AS office3Month ";
            sql += "            , nsu.4GatsuUriage AS office4Month ";
            sql += "            , nsu.5GatsuUriage AS office5Month ";
            sql += "            , nsu.6GatsuUriage AS office6Month ";
            sql += "            , nsu.7GatsuUriage AS office7Month ";
            sql += "            , nsu.8GatsuUriage AS office8Month ";
            sql += "            , nsu.9GatsuUriage AS office9Month ";
            sql += "       FROM (SELECT * FROM nakakita_shiten_uriage WHERE nendo = '" + displayNendo + "') nsu ";
            sql += "       INNER JOIN (SELECT * FROM tokuisaki_master) tm ";
            sql += "       ON (nsu.tokuisakiCode = tm.tokuisakiCode AND nsu.jigyousyoCode = tm.jigyousyoCode) ";
            sql += "       ORDER BY tm.jigyousyoCode ";
            sql += "     ) ud ";
            sql += "UNION ALL ";
            sql += "SELECT '合計' AS office ";
            sql += "     , SUM(IFNULL(nsu.10GatsuUriage, 0)) AS office10Month ";
            sql += "     , SUM(IFNULL(nsu.11GatsuUriage, 0)) AS office11Month ";
            sql += "     , SUM(IFNULL(nsu.12GatsuUriage, 0)) AS office12Month ";
            sql += "     , SUM(IFNULL(nsu.1GatsuUriage, 0)) AS office1Month ";
            sql += "     , SUM(IFNULL(nsu.2GatsuUriage, 0)) AS office2Month ";
            sql += "     , SUM(IFNULL(nsu.3GatsuUriage, 0)) AS office3Month ";
            sql += "     , SUM(IFNULL(nsu.4GatsuUriage, 0)) AS office4Month ";
            sql += "     , SUM(IFNULL(nsu.5GatsuUriage, 0)) AS office5Month ";
            sql += "     , SUM(IFNULL(nsu.6GatsuUriage, 0)) AS office6Month ";
            sql += "     , SUM(IFNULL(nsu.7GatsuUriage, 0)) AS office7Month ";
            sql += "     , SUM(IFNULL(nsu.8GatsuUriage, 0)) AS office8Month ";
            sql += "     , SUM(IFNULL(nsu.9GatsuUriage, 0)) AS office9Month ";
            sql += "FROM (SELECT * FROM nakakita_shiten_uriage WHERE nendo = '" + displayNendo + "') nsu ";
            sql += "GROUP BY nsu.tokuisakiCode ";
            DataTable shitenDt = db.executeNoneLockSelect(sql);
            while (shitenDt.Rows.Count < shitenMinCount)
            {
                newRow = shitenDt.NewRow();
                shitenDt.Rows.InsertAt(newRow, shitenDt.Rows.Count - 1);
            }

            sql = string.Empty;
            sql += "SELECT * ";
            sql += "FROM ( ";
            sql += "       SELECT mm.kubunName AS prefectures ";
            sql += "            , nku.10GatsuUriage AS prefectures10Month ";
            sql += "            , nku.11GatsuUriage AS prefectures11Month ";
            sql += "            , nku.12GatsuUriage AS prefectures12Month ";
            sql += "            , nku.1GatsuUriage AS prefectures1Month ";
            sql += "            , nku.2GatsuUriage AS prefectures2Month ";
            sql += "            , nku.3GatsuUriage AS prefectures3Month ";
            sql += "            , nku.4GatsuUriage AS prefectures4Month ";
            sql += "            , nku.5GatsuUriage AS prefectures5Month ";
            sql += "            , nku.6GatsuUriage AS prefectures6Month ";
            sql += "            , nku.7GatsuUriage AS prefectures7Month ";
            sql += "            , nku.8GatsuUriage AS prefectures8Month ";
            sql += "            , nku.9GatsuUriage AS prefectures9Month ";
            sql += "       FROM (SELECT * FROM nakakita_ken_uriage WHERE nendo = '" + displayNendo + "') nku ";
            sql += "       INNER JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '004') mm ";
            sql += "       ON (nku.chikuCode = mm.kubun) ";
            sql += "       ORDER BY nku.rowNo ";
            sql += ") ud ";
            sql += "UNION ALL ";
            sql += "SELECT '合計' AS prefectures ";
            sql += "     , SUM(IFNULL(nku.10GatsuUriage, 0)) AS prefectures10Month ";
            sql += "     , SUM(IFNULL(nku.11GatsuUriage, 0)) AS prefectures11Month ";
            sql += "     , SUM(IFNULL(nku.12GatsuUriage, 0)) AS prefectures12Month ";
            sql += "     , SUM(IFNULL(nku.1GatsuUriage, 0)) AS prefectures1Month ";
            sql += "     , SUM(IFNULL(nku.2GatsuUriage, 0)) AS prefectures2Month ";
            sql += "     , SUM(IFNULL(nku.3GatsuUriage, 0)) AS prefectures3Month ";
            sql += "     , SUM(IFNULL(nku.4GatsuUriage, 0)) AS prefectures4Month ";
            sql += "     , SUM(IFNULL(nku.5GatsuUriage, 0)) AS prefectures5Month ";
            sql += "     , SUM(IFNULL(nku.6GatsuUriage, 0)) AS prefectures6Month ";
            sql += "     , SUM(IFNULL(nku.7GatsuUriage, 0)) AS prefectures7Month ";
            sql += "     , SUM(IFNULL(nku.8GatsuUriage, 0)) AS prefectures8Month ";
            sql += "     , SUM(IFNULL(nku.9GatsuUriage, 0)) AS prefectures9Month ";
            sql += "FROM (SELECT * FROM nakakita_ken_uriage WHERE nendo = '" + displayNendo + "') nku ";
            DataTable kenDt = db.executeNoneLockSelect(sql);
            while (kenDt.Rows.Count < kenMinCount)
            {
                newRow = kenDt.NewRow();
                kenDt.Rows.InsertAt(newRow, kenDt.Rows.Count - 1);
            }

            grdOffice.DataSource = shitenDt.Copy();
            grdPrefectures.DataSource = kenDt.Copy();

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
            DateTime targetDateFrom = Convert.ToDateTime(displayNendo + "-10-01");
            DateTime targetDateTo = Convert.ToDateTime(Convert.ToString(Convert.ToInt16(displayNendo) + 1) + "-10-01").AddDays(-1);

            #region 得意先情報取得
            sql = string.Empty;
            sql += "SELECT * FROM tokuisaki_master WHERE tokuisakiCode = '10001' ORDER BY jigyousyoCode";// TODO
            DataTable tokuisakiDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 県情報取得
            sql = string.Empty;
            sql += "SELECT * FROM meisyo_master WHERE meisyoCode = '004' ";
            DataTable kenDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 支店別データ取得
            sql = string.Empty;
            sql += "SELECT tm.tokuisakiCode ";
            sql += "     , tm.jigyousyoCode ";
            sql += "     , uh.year ";
            sql += "     , uh.month ";
            sql += "     , SUM(IFNULL(ub.kingaku, 0)) uriageKingaku ";
            sql += "FROM (SELECT * FROM tokuisaki_master WHERE tokuisakiCode = '10001') tm ";// TODO
            sql += "INNER JOIN (SELECT * ";
            sql += "                 , DATE_FORMAT(denpyoHizuke, '%Y') AS year ";
            sql += "                 , DATE_FORMAT(denpyoHizuke, '%m') AS month ";
            sql += "            FROM uriage_header ";
            sql += "            WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "            AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "            AND denpyoHizuke <= '" + targetDateTo + "' ";
            sql += ") uh ";
            sql += "ON (tm.tokuisakiCode = uh.tokuisakiCode AND tm.jigyousyoCode = uh.jigyousyoCode) ";
            sql += "INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            sql += "ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "GROUP BY tm.tokuisakiCode, tm.jigyousyoCode, uh.year, uh.month ";
            sql += "ORDER BY tm.tokuisakiCode, tm.jigyousyoCode, uh.year, uh.month ";
            DataTable shitenDataDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 県別データ取得
            sql = string.Empty;
            sql += "SELECT ud.kubun AS chikuCode ";
            sql += "     , ud.kubunName AS chikuName ";
            sql += "     , ud.printOrder ";
            sql += "     , ud.year ";
            sql += "     , ud.month ";
            sql += "     , SUM(IFNULL(ud.uriageKingaku, 0)) uriageKingaku ";
            sql += "FROM ( ";
            sql += "       SELECT CASE WHEN mm.kubun = '02' THEN mm.kubun ";
            sql += "                   WHEN mm.kubun = '03' THEN mm.kubun ";
            sql += "                   WHEN mm.kubun = '04' THEN mm.kubun ";
            sql += "                   WHEN mm.kubun = '05' THEN mm.kubun ";
            sql += "                   WHEN mm.kubun = '06' THEN mm.kubun ";
            sql += "                   WHEN mm.kubun = '07' THEN mm.kubun ";
            sql += "                   ELSE '99' ";
            sql += "              END AS kubun ";
            sql += "            , CASE WHEN mm.kubun = '02' THEN mm.kubunName ";
            sql += "                   WHEN mm.kubun = '03' THEN mm.kubunName ";
            sql += "                   WHEN mm.kubun = '04' THEN mm.kubunName ";
            sql += "                   WHEN mm.kubun = '05' THEN mm.kubunName ";
            sql += "                   WHEN mm.kubun = '06' THEN mm.kubunName ";
            sql += "                   WHEN mm.kubun = '07' THEN mm.kubunName ";
            sql += "                   ELSE '県外' ";
            sql += "              END AS kubunName ";
            sql += "            , CASE WHEN mm.kubun = '02' THEN 1 ";
            sql += "                   WHEN mm.kubun = '03' THEN 2 ";
            sql += "                   WHEN mm.kubun = '04' THEN 4 ";
            sql += "                   WHEN mm.kubun = '05' THEN 3 ";
            sql += "                   WHEN mm.kubun = '06' THEN 5 ";
            sql += "                   WHEN mm.kubun = '07' THEN 6 ";
            sql += "                   ELSE 7 ";
            sql += "              END AS printOrder ";
            sql += "            , uh.year ";
            sql += "            , uh.month ";
            sql += "            , SUM(IFNULL(ub.kingaku, 0)) uriageKingaku ";
            sql += "       FROM (SELECT * FROM meisyo_master WHERE meisyoCode = '004') mm ";
            sql += "       INNER JOIN (SELECT * FROM tokuisaki_master WHERE tokuisakiCode = '10001') tm ";
            sql += "       ON (mm.kubun = tm.chikuCode) ";
            sql += "       INNER JOIN (SELECT * ";
            sql += "                        , DATE_FORMAT(denpyoHizuke, '%Y') AS year ";
            sql += "                        , DATE_FORMAT(denpyoHizuke, '%m') AS month ";
            sql += "                   FROM uriage_header ";
            sql += "                   WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "                   AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "                   AND denpyoHizuke <= '" + targetDateTo + "' ";
            sql += "       ) uh ";
            sql += "       ON (tm.tokuisakiCode = uh.tokuisakiCode AND tm.jigyousyoCode = uh.jigyousyoCode) ";
            sql += "       INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            sql += "       ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "       GROUP BY mm.kubun, uh.year, uh.month ";
            sql += ") ud ";
            sql += "GROUP BY ud.kubun, ud.year, ud.month ";
            sql += "ORDER BY ud.year, ud.month, ud.printOrder ";
            DataTable kenDataDt = db.executeNoneLockSelect(sql);
            #endregion

            List<string> commands = new List<string>();
            string jigyousyoCode;
            string chikuCode;
            string month;
            string month10Uriage = "NULL";
            string month11Uriage = "NULL";
            string month12Uriage = "NULL";
            string month1Uriage = "NULL";
            string month2Uriage = "NULL";
            string month3Uriage = "NULL";
            string month4Uriage = "NULL";
            string month5Uriage = "NULL";
            string month6Uriage = "NULL";
            string month7Uriage = "NULL";
            string month8Uriage = "NULL";
            string month9Uriage = "NULL";

            #region 支店別データ登録SQL生成
            commands.Add("DELETE FROM nakakita_shiten_uriage WHERE tokuisakiCode = '10001' AND nendo = '" + displayNendo + "' ");
            foreach (DataRow tokuisakiRow in tokuisakiDt.Rows)
            {
                jigyousyoCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                month10Uriage = "NULL";
                month11Uriage = "NULL";
                month12Uriage = "NULL";
                month1Uriage = "NULL";
                month2Uriage = "NULL";
                month3Uriage = "NULL";
                month4Uriage = "NULL";
                month5Uriage = "NULL";
                month6Uriage = "NULL";
                month7Uriage = "NULL";
                month8Uriage = "NULL";
                month9Uriage = "NULL";
                var query = shitenDataDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode).Equals(jigyousyoCode)).OrderBy(p => shitenDataDt.Rows.IndexOf(p));
                foreach (DataRow shitenRow in query)
                {
                    month = Convert.ToString(shitenRow["month"]);
                    if ("10".Equals(month))
                    {
                        month10Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("11".Equals(month))
                    {
                        month11Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("12".Equals(month))
                    {
                        month12Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("01".Equals(month))
                    {
                        month1Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("02".Equals(month))
                    {
                        month2Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("03".Equals(month))
                    {
                        month3Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("04".Equals(month))
                    {
                        month4Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("05".Equals(month))
                    {
                        month5Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("06".Equals(month))
                    {
                        month6Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("07".Equals(month))
                    {
                        month7Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("08".Equals(month))
                    {
                        month8Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else
                    {
                        month9Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                }
                sql = string.Empty;
                sql += "INSERT INTO nakakita_shiten_uriage ";
                sql += "( ";
                sql += "  tokuisakiCode ";
                sql += ", jigyousyoCode ";
                sql += ", nendo ";
                sql += ", 10GatsuUriage ";
                sql += ", 11GatsuUriage ";
                sql += ", 12GatsuUriage ";
                sql += ", 1GatsuUriage ";
                sql += ", 2GatsuUriage ";
                sql += ", 3GatsuUriage ";
                sql += ", 4GatsuUriage ";
                sql += ", 5GatsuUriage ";
                sql += ", 6GatsuUriage ";
                sql += ", 7GatsuUriage ";
                sql += ", 8GatsuUriage ";
                sql += ", 9GatsuUriage ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "  '10001' ";//TODO
                sql += ", '" + jigyousyoCode + "' ";
                sql += ", '" + displayNendo + "' ";
                sql += ", " + month10Uriage + " ";
                sql += ", " + month11Uriage + " ";
                sql += ", " + month12Uriage + " ";
                sql += ", " + month1Uriage + " ";
                sql += ", " + month2Uriage + " ";
                sql += ", " + month3Uriage + " ";
                sql += ", " + month4Uriage + " ";
                sql += ", " + month5Uriage + " ";
                sql += ", " + month6Uriage + " ";
                sql += ", " + month7Uriage + " ";
                sql += ", " + month8Uriage + " ";
                sql += ", " + month9Uriage + " ";
                sql += ", '" + registDate + "' ";
                sql += ", '' ";
                sql += ") ";
                commands.Add(sql);
            }
            #endregion

            #region 県別データ登録SQL生成
            commands.Add("DELETE FROM nakakita_ken_uriage WHERE nendo = '" + displayNendo + "' ");
            int rowNo;
            foreach (DataRow kenRow in kenDt.Rows)
            {
                chikuCode = Convert.ToString(kenRow[DBFileLayout.MeisyoMasterFile.dcKubun]);
                if (!"02".Equals(chikuCode) &&
                    !"03".Equals(chikuCode) &&
                    !"04".Equals(chikuCode) &&
                    !"05".Equals(chikuCode) &&
                    !"06".Equals(chikuCode) &&
                    !"07".Equals(chikuCode) &&
                    !"99".Equals(chikuCode))
                {
                    continue;
                }

                rowNo = 0;
                switch (chikuCode)
                {
                    case "02": rowNo = 1; break;
                    case "03": rowNo = 2; break;
                    case "04": rowNo = 4; break;
                    case "05": rowNo = 3; break;
                    case "06": rowNo = 5; break;
                    case "07": rowNo = 6; break;
                    case "99": rowNo = 7; break;
                }

                month10Uriage = "NULL";
                month11Uriage = "NULL";
                month12Uriage = "NULL";
                month1Uriage = "NULL";
                month2Uriage = "NULL";
                month3Uriage = "NULL";
                month4Uriage = "NULL";
                month5Uriage = "NULL";
                month6Uriage = "NULL";
                month7Uriage = "NULL";
                month8Uriage = "NULL";
                month9Uriage = "NULL";
                var query = kenDataDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.TokuisakiMasterFile.dcChikuCode).Equals(chikuCode)).OrderBy(p => shitenDataDt.Rows.IndexOf(p));
                foreach (DataRow kendataRow in query)
                {
                    month = Convert.ToString(kendataRow["month"]);
                    if ("10".Equals(month))
                    {
                        month10Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("11".Equals(month))
                    {
                        month11Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("12".Equals(month))
                    {
                        month12Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("01".Equals(month))
                    {
                        month1Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("02".Equals(month))
                    {
                        month2Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("03".Equals(month))
                    {
                        month3Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("04".Equals(month))
                    {
                        month4Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("05".Equals(month))
                    {
                        month5Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("06".Equals(month))
                    {
                        month6Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("07".Equals(month))
                    {
                        month7Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else if ("08".Equals(month))
                    {
                        month8Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                    else
                    {
                        month9Uriage = Convert.ToString(kendataRow["uriageKingaku"]);
                    }
                }
                sql = string.Empty;
                sql += "INSERT INTO nakakita_ken_uriage ";
                sql += "( ";
                sql += "  chikuCode ";
                sql += ", nendo ";
                sql += ", rowNo ";
                sql += ", 10GatsuUriage ";
                sql += ", 11GatsuUriage ";
                sql += ", 12GatsuUriage ";
                sql += ", 1GatsuUriage ";
                sql += ", 2GatsuUriage ";
                sql += ", 3GatsuUriage ";
                sql += ", 4GatsuUriage ";
                sql += ", 5GatsuUriage ";
                sql += ", 6GatsuUriage ";
                sql += ", 7GatsuUriage ";
                sql += ", 8GatsuUriage ";
                sql += ", 9GatsuUriage ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "  '" + chikuCode + "' ";
                sql += ", '" + displayNendo + "' ";
                sql += ", " + rowNo + " ";
                sql += ", " + month10Uriage + " ";
                sql += ", " + month11Uriage + " ";
                sql += ", " + month12Uriage + " ";
                sql += ", " + month1Uriage + " ";
                sql += ", " + month2Uriage + " ";
                sql += ", " + month3Uriage + " ";
                sql += ", " + month4Uriage + " ";
                sql += ", " + month5Uriage + " ";
                sql += ", " + month6Uriage + " ";
                sql += ", " + month7Uriage + " ";
                sql += ", " + month8Uriage + " ";
                sql += ", " + month9Uriage + " ";
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

        #endregion

    }
}
