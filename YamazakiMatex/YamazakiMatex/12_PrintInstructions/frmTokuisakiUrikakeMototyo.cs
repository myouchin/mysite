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
    /// 得意先別売上元帳出力画面
    /// </summary>
    public partial class frmTokuisakiUrikakeMototyo : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private enum LastInputDateType
        {
            None = 0
          , TightenDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private CommonLogic commonLogic;
        public enum PrintRowType
        {
            /// <summary>
            /// 前回請求額
            /// </summary>
            ZenkaiSeikyu = 1
            /// <summary>
            /// 明細
            /// </summary>
            , Meisai = 2
            /// <summary>
            /// 小計
            /// </summary>
            , Shoukei = 3
            /// <summary>
            /// 消費税
            /// </summary>
            , Shouhizei = 4
            /// <summary>
            /// 入金額
            /// </summary>
            , Nyukin = 5
            /// <summary>
            /// 合計
            /// </summary>
            , Goukei = 6
        }
        private DBMeisyoMaster meisyoMaster;
        /// <summary>
        /// 入金区分
        /// </summary>
        private enum NyukinKingakuType
        {
            /// <summary>
            /// 現金
            /// </summary>
            genkin = 1
            /// <summary>
            /// 振込
            /// </summary>
          , hurikomi = 2
            /// <summary>
            /// 手数料
            /// </summary>
          , tesuryo = 3
            /// <summary>
            /// 小切手
            /// </summary>
          , kogitte = 4
            /// <summary>
            /// 手形
            /// </summary>
          , tegata = 5
            /// <summary>
            /// 手形割引
            /// </summary>
          , tegataWaribiki = 6
            /// <summary>
            /// 相殺
            /// </summary>
          , sousai = 7
            /// <summary>
            /// リベート
            /// </summary>
          , ribeto = 8
            /// <summary>
            /// でんさい
            /// </summary>
          , densai = 9
            /// <summary>
            /// 調整
            /// </summary>
          , tyousei = 10
            /// <summary>
            /// その他
            /// </summary>
          , sonota = 11
        }
        sfrmTokuisakiSearch fTokuisaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmTokuisakiUrikakeMototyo()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            activeControlInfo = new ActiveControlInfo();
            txtTightenDateYears.Text = string.Empty;
            txtTightenDateMonth.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            meisyoMaster = new DBMeisyoMaster();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
        }
        #endregion

        #region 検索ボタン押下イベント
        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 編集中の項目が存在しない場合なにもしない
            if (activeControlInfo.Control == null) return;
            // 検索ボタンが使用不可の場合なにもしない
            if (!btnSearch.Enabled) return;
            bool flgSetFocus = false;

            // 得意先ｺｰﾄﾞを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 得意先検索画面を起動
                fTokuisaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fTokuisaki.DialogResult == DialogResult.OK)
                {
                    string tokuisakiCode = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                    string jigyousyoCode = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                    // 得意先情報設定処理
                    setTokuisakiInfo(tokuisakiCode, jigyousyoCode, true);
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
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
                    case LastInputDateType.TightenDate:
                        y = txtTightenDateYears.Text;
                        m = txtTightenDateMonth.Text;
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
                    else if (LastInputDateType.TightenDate.Equals(lastInputDateType))
                    {
                        txtTightenDateYears.Focus();
                    }
                    return;
                }
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
        }
        #endregion

        #region 得意先コードのフォーカスアウトイベント
        /// <summary>
        /// 得意先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCd_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 得意先情報の設定
                if (setTokuisakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), string.Empty, false))
                {
                    text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                }
            }
            else
            {
                txtCustomerName.Text = string.Empty;
            }
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
                // F1キーが押下された場合
                case Keys.F1:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    // 検索ボタン押下時の処理を実行
                    btnSearch_Click(null, null);
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
            // 締区分コンボボックス設定
            setTightenTypeCmb();
            // 入力情報設定
            setInputInfo();
        }
        #endregion

        #region 締年月日のフォーカスインイベント
        /// <summary>
        /// 締年月日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tightenDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TightenDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 締年月日のフォーカスアウトイベント
        /// <summary>
        /// 締年月日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tightenDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TightenDate;
                if ((sender is TextBox))
                {
                    lastInputDateText = (TextBox)sender;
                }
            }
            else
            {
                lastInputDateType = LastInputDateType.TightenDate;
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

            // 締年月日の場合
            if (c.Name.Equals(txtTightenDateYears.Name) ||
                c.Name.Equals(txtTightenDateMonth.Name) ||
                c.Name.Equals(cmbTightenType.Name) ||
                c.Name.Equals(dtpTightenDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.tightenDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.tightenDate_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCd_Leave);
            }

            // 検索ボタンでない場合
            if (!c.Name.Equals(btnSearch.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(inputObject_Enter);
            }

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
        private dtblTokuisakibetuUriageMotocho getData()
        {
            dtblTokuisakibetuUriageMotocho motocho = new dtblTokuisakibetuUriageMotocho();

            DBCommon selectDb = new DBCommon();
            DataTable baseDt;
            DataTable childDt;
            DataTable uriageDt;
            DataTable nyukinDt;

            string tightenDateYears = txtTightenDateYears.Text;
            string tightenDateMonth = txtTightenDateMonth.Text;
            string tightenDateDaysValue = Convert.ToString(cmbTightenType.SelectedValue);
            string tightenDateDaysText = string.Empty;
            // 締日 = "月末"の場合
            if (Consts.EndOfMonthText.Equals(cmbTightenType.Text))
            {
                // 月末日取得処理を実行
                tightenDateDaysText = commonLogic.GetEndOfMonth(tightenDateYears, tightenDateMonth);
            }
            else
            {
                tightenDateDaysText = cmbTightenType.Text;
            }
            string customerCode = txtCustomerCode.Text;
            DateTime shimeYMDTo = Convert.ToDateTime(tightenDateYears + "/" + tightenDateMonth + "/" + tightenDateDaysText);
            DateTime shimeYMDFrom = shimeYMDTo.AddMonths(-1).AddDays(1);
            if (Consts.EndOfMonthText.Equals(cmbTightenType.Text))
            {
                shimeYMDFrom = Convert.ToDateTime(shimeYMDTo.Year + "/" + shimeYMDTo.Month + "/01");
            }

                string sql = string.Empty;
            sql += "SELECT * ";
            sql += "FROM (SELECT chihouCode " + "\r";
            sql += "           , tokuisakiCode " + "\r";
            sql += "           , tokuisakiName " + "\r";
            sql += "           , jigyousyoCode " + "\r";
            sql += "           , seikyuKubun " + "\r";
            sql += "           , seikyuSyuturyokuKubun " + "\r";
            sql += "      FROM tokuisaki_master " + "\r";
            sql += "      WHERE (kanriKubun IS NULL OR kanriKubun <> '9') " + "\r";
            sql += "      AND shimebi = '" + tightenDateDaysValue + "' " + "\r";
            if (!string.IsNullOrEmpty(customerCode)) sql += "      AND tokuisakiCode ='" + customerCode + "' " + "\r";
            sql += "      AND seikyuKubun = '0' " + "\r";
            sql += ") tm " + "\r";

            //sql += "INNER JOIN (SELECT tokuisakiCode " + "\r";
            //sql += "                 , jigyousyoCode " + "\r";
            //sql += "                 , SUM(IFNULL(kurikosi, 0)) AS kurikosi " + "\r";
            //sql += "            FROM tokuisaki_seikyu " + "\r";
            //sql += "            WHERE seikyubi >= '" + shimeYMDFrom + "'" + "\r";
            //sql += "            AND seikyubi <= '" + shimeYMDTo + "'" + "\r";
            //sql += "            GROUP BY tokuisakiCode, jigyousyoCode" + "\r";
            //sql += "           ) ts " + "\r";

            sql += "INNER JOIN (SELECT ts.tokuisakiCode " + "\r";
            sql += "                 , ts.jigyousyoCode " + "\r";
            sql += "                 , IFNULL(ts.zengetsuSeikyu, 0) AS kurikosi " + "\r";
            sql += "            FROM ( " + "\r";
            sql += "                  SELECT tokuisakiCode , jigyousyoCode , MIN(seikyuNo) AS seikyuNo " + "\r";
            sql += "                  FROM tokuisaki_seikyu " + "\r";
            sql += "                  WHERE seikyubi >= '" + shimeYMDFrom + "' " + "\r";
            sql += "                  AND seikyubi <= '" + shimeYMDTo + "' " + "\r";
            sql += "                  GROUP BY tokuisakiCode, jigyousyoCode " + "\r";
            sql += "                 ) maxSeikyu " + "\r";
            sql += "            INNER JOIN tokuisaki_seikyu ts ON (maxSeikyu.seikyuNo = ts.seikyuNo) " + "\r";
            sql += ") ts " + "\r";

            sql += "ON (tm.tokuisakiCode = ts.tokuisakiCode AND tm.jigyousyoCode = ts.jigyousyoCode) " + "\r";
            baseDt = selectDb.executeSelect(sql, false);
            if (baseDt == null || baseDt.Rows.Count == 0) return motocho;

            string tokuisakiCode;
            string tokuisakiName;
            string jigyousyoCode;
            string jigyousyoName;
            string seikyuKubun;
            string childTokuisakiCode;
            string childJigyousyoCode;
            string nyukinBaseSql1 = string.Empty;
            nyukinBaseSql1 += "SELECT tokuisakiCode " + "\r";
            nyukinBaseSql1 += "     , jigyousyoCode " + "\r";
            nyukinBaseSql1 += "     , 0 AS denpyoNo " + "\r";
            nyukinBaseSql1 += "     , nyukinHizuke AS denpyoHizuke " + "\r";
            nyukinBaseSql1 += "     , '' AS shouhinName1 " + "\r";
            nyukinBaseSql1 += "     , '' AS shouhinName2 " + "\r";
            nyukinBaseSql1 += "     , 0 AS suryo " + "\r";
            nyukinBaseSql1 += "     , '' AS tani " + "\r";
            nyukinBaseSql1 += "     , 0 AS tanka " + "\r";
            nyukinBaseSql1 += "     , {0} AS kingaku " + "\r";
            nyukinBaseSql1 += "     , {1} AS kingakuType " + "\r";
            nyukinBaseSql1 += "     , '' AS jigyousyoName " + "\r";
            nyukinBaseSql1 += "     , '' AS kenmei1 " + "\r";
            nyukinBaseSql1 += "FROM nyukin " + "\r";
            nyukinBaseSql1 += "WHERE tokuisakiCode = '{2}' " + "\r";
            nyukinBaseSql1 += "AND jigyousyoCode = '{3}' " + "\r";
            nyukinBaseSql1 += "AND (seikyuHizuke >= '{4}' " + "\r";
            nyukinBaseSql1 += "AND  seikyuHizuke <= '{5}') " + "\r";
            nyukinBaseSql1 += "AND seikyuHuragu = '1' " + "\r";
            string nyukinBaseSql2 = string.Empty;
            nyukinBaseSql2 += "SELECT '{0}' AS tokuisakiCode " + "\r";
            nyukinBaseSql2 += "     , '{1}' AS jigyousyoCode " + "\r";
            nyukinBaseSql2 += "     , 0 AS denpyoNo " + "\r";
            nyukinBaseSql2 += "     , nyukinHizuke AS denpyoHizuke " + "\r";
            nyukinBaseSql2 += "     , '' AS shouhinName1 " + "\r";
            nyukinBaseSql2 += "     , '' AS shouhinName2 " + "\r";
            nyukinBaseSql2 += "     , 0 AS suryo " + "\r";
            nyukinBaseSql2 += "     , '' AS tani " + "\r";
            nyukinBaseSql2 += "     , 0 AS tanka " + "\r";
            nyukinBaseSql2 += "     , SUM({2}) AS kingaku " + "\r";
            nyukinBaseSql2 += "     , {3} AS kingakuType " + "\r";
            nyukinBaseSql2 += "     , '' AS jigyousyoName " + "\r";
            nyukinBaseSql2 += "     , '' AS kenmei1 " + "\r";
            nyukinBaseSql2 += "FROM nyukin " + "\r";
            nyukinBaseSql2 += "WHERE (seikyuHizuke >= '{4}' " + "\r";
            nyukinBaseSql2 += "AND    seikyuHizuke <= '{5}') " + "\r";
            nyukinBaseSql2 += "AND seikyuHuragu = '1' " + "\r";
            nyukinBaseSql2 += "AND {6} " + "\r";
            nyukinBaseSql2 += "GROUP BY tokuisakiCode, nyukinHizuke " + "\r";
            string nyukinWhere = string.Empty;
            decimal kurikoshi = decimal.Zero;
            decimal suryo = decimal.Zero;
            decimal tanka = decimal.Zero;
            decimal kingaku = decimal.Zero;
            decimal uriageTotal = decimal.Zero;
            int group = 0;
            int page = 0;
            int rowCount;
            string denpyoNo = string.Empty;
            string nengetsu = string.Empty;
            DataRow printRow;
            DateTime uriageDate;
            int pageRowCount = 15;
            int addEmptyRowCount = 0;
            int kingakuType = 0;
            string kenmei = string.Empty;
            string wkJigyousyoCode = string.Empty;
            string wkDenpyouNo = string.Empty;
            bool flgDispSashihiki = false;
            DataRow nextRow;
            bool flgNextRowExists = false;
            string uriageMonth = string.Empty;
            string uriageDay = string.Empty;
            decimal wkDec;
            foreach (DataRow dRow in baseDt.Rows)
            {
                tokuisakiCode = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                tokuisakiName = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
                jigyousyoCode = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                seikyuKubun = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcSeikyuKubun]);
                group++;
                page = 0;
                rowCount = 0;
                uriageTotal = decimal.Zero;
                wkJigyousyoCode = string.Empty;
                flgDispSashihiki = false;
                flgNextRowExists = false;
                decimal.TryParse(Convert.ToString(dRow[DBFileLayout.TokuisakiSeikyuFile.dcKurikosi]), out kurikoshi);
                uriageMonth = string.Empty;
                uriageDay = string.Empty;

                sql = string.Empty;
                sql += "SELECT * " + "\r";
                sql += "FROM tokuisaki_master " + "\r";
                sql += "WHERE (kanriKubun IS NULL OR kanriKubun <> '9') " + "\r";
                sql += "AND seikyusakiCode = '" + tokuisakiCode + "'" + "\r";
                sql += "AND seikyusakiJigyousyoCode = '" + jigyousyoCode + "'" + "\r";
                childDt = selectDb.executeSelect(sql, false);

                #region 売上データ取得
                sql = string.Empty;
                sql += "SELECT uh.tokuisakiCode " + "\r";
                sql += "     , uh.jigyousyoCode " + "\r";
                sql += "     , uh.denpyoNo " + "\r";
                sql += "     , uh.denpyoHizuke " + "\r";
                sql += "     , ub.shouhinName1 " + "\r";
                sql += "     , ub.shouhinName2 " + "\r";
                sql += "     , ub.suryo " + "\r";
                sql += "     , ub.tani " + "\r";
                sql += "     , ub.tanka " + "\r";
                sql += "     , ub.kingaku " + "\r";
                sql += "     , 0 AS kingakuType " + "\r";
                sql += "     , uh.jigyousyoName AS jigyousyoName " + "\r";
                sql += "     , uh.kenmei1 AS kenmei1 " + "\r";
                sql += "FROM (SELECT * " + "\r";
                sql += "      FROM uriage_header " + "\r";
                sql += "      WHERE 1 = 1 " + "\r";
                if (childDt == null || childDt.Rows.Count == 0)
                {
                    sql += "                  AND tokuisakiCode = '" + tokuisakiCode + "' ";
                    sql += "                  AND jigyousyoCode = '" + jigyousyoCode + "' " + "\r";
                }
                else
                {
                    sql += "                  AND ( " + "\r";
                    sql += "                        (tokuisakiCode = '" + tokuisakiCode + "' ";
                    sql += "                     AND jigyousyoCode = '" + jigyousyoCode + "') " + "\r";
                    foreach (DataRow childDRow in childDt.Rows)
                    {
                        childTokuisakiCode = Convert.ToString(childDRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                        childJigyousyoCode = Convert.ToString(childDRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                        sql += "                  OR (tokuisakiCode = '" + childTokuisakiCode + "' ";
                        sql += "                  AND jigyousyoCode = '" + childJigyousyoCode + "') " + "\r";
                    }
                    sql += "                  ) " + "\r";
                }
                sql += "      ) uh " + "\r";
                sql += "      INNER JOIN (SELECT * " + "\r";
                sql += "                  FROM uriage_body " + "\r";
                sql += "                  WHERE (seikyuHizuke >= '" + shimeYMDFrom + "' " + "\r";
                sql += "                  AND seikyuHizuke <= '" + shimeYMDTo + "') " + "\r";
                sql += "                  AND seikyuHuragu = '1') ub " + "\r";
                sql += "      ON (uh.denpyoNo = ub.denpyoNo) " + "\r";
                sql += "      INNER JOIN (SELECT * " + "\r";
                sql += "                  FROM tokuisaki_master) tm " + "\r";
                sql += "      ON (uh.tokuisakiCode = tm.tokuisakiCode AND uh.jigyousyoCode = tm.jigyousyoCode) " + "\r";
                sql += "ORDER BY uh.denpyoHizuke, uh.tokuisakiCode, uh.jigyousyoCode, uh.denpyoNo, ub.rowNo " + "\r";
                uriageDt = selectDb.executeSelect(sql, false);
                #endregion

                #region 入金データ取得
                sql = string.Empty;
                sql += "SELECT MAX(tokuisakiCode) AS tokuisakiCode " + "\r";
                sql += "     , MAX(jigyousyoCode) AS jigyousyoCode " + "\r";
                sql += "     , MAX(denpyoNo) AS denpyoNo " + "\r";
                sql += "     , MAX(denpyoHizuke) AS denpyoHizuke " + "\r";
                sql += "     , MAX(shouhinName1) AS shouhinName1 " + "\r";
                sql += "     , MAX(shouhinName2) AS shouhinName2 " + "\r";
                sql += "     , MAX(suryo) AS suryo " + "\r";
                sql += "     , MAX(tani) AS tani " + "\r";
                sql += "     , MAX(tanka) AS tanka " + "\r";
                sql += "     , SUM(IFNULL(kingaku, 0)) AS kingaku " + "\r";
                sql += "     , kingakuType " + "\r";
                sql += "     , MAX(jigyousyoName) AS jigyousyoName " + "\r";
                sql += "     , MAX(kenmei1) AS kenmei1 " + "\r";
                sql += "FROM ( " + "\r";
                if (childDt == null || childDt.Rows.Count == 0)
                {
                    sql += string.Format(nyukinBaseSql1, "genkin", NyukinKingakuType.genkin.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "hurikomi", NyukinKingakuType.hurikomi.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "tesuryo", NyukinKingakuType.tesuryo.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "kogitte", NyukinKingakuType.kogitte.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "tegata", NyukinKingakuType.tegata.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "tegataWaribiki", NyukinKingakuType.tegataWaribiki.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "sousai", NyukinKingakuType.sousai.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "ribeto", NyukinKingakuType.ribeto.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "densai", NyukinKingakuType.densai.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "tyousei", NyukinKingakuType.tyousei.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql1, "sonota", NyukinKingakuType.sonota.GetHashCode(), tokuisakiCode, jigyousyoCode, shimeYMDFrom, shimeYMDTo) + "\r";
                }
                else
                {
                    nyukinWhere = string.Empty;
                    nyukinWhere += "( " + "\r";
                    nyukinWhere += "                        (tokuisakiCode = '" + tokuisakiCode + "' ";
                    nyukinWhere += "                     AND jigyousyoCode = '" + jigyousyoCode + "') " + "\r";
                    foreach (DataRow childDRow in childDt.Rows)
                    {
                        childTokuisakiCode = Convert.ToString(childDRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                        childJigyousyoCode = Convert.ToString(childDRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                        nyukinWhere += "                  OR (tokuisakiCode = '" + childTokuisakiCode + "' ";
                        nyukinWhere += "                  AND jigyousyoCode = '" + childJigyousyoCode + "') " + "\r";
                    }
                    nyukinWhere += ") " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "genkin", NyukinKingakuType.genkin.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "hurikomi", NyukinKingakuType.hurikomi.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "tesuryo", NyukinKingakuType.tesuryo.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "kogitte", NyukinKingakuType.kogitte.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "tegata", NyukinKingakuType.tegata.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "tegataWaribiki", NyukinKingakuType.tegataWaribiki.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "sousai", NyukinKingakuType.sousai.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "ribeto", NyukinKingakuType.ribeto.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "densai", NyukinKingakuType.densai.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "tyousei", NyukinKingakuType.tyousei.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                    sql += "UNION ALL " + "\r";
                    sql += string.Format(nyukinBaseSql2, tokuisakiCode, jigyousyoCode, "sonota", NyukinKingakuType.sonota.GetHashCode(), shimeYMDFrom, shimeYMDTo, nyukinWhere) + "\r";
                }
                sql += ") n " + "\r";
                sql += "GROUP BY kingakuType " + "\r";
                sql += "ORDER BY kingakuType " + "\r";
                nyukinDt = selectDb.executeSelect(sql, false);
                #endregion

                if (uriageDt.Rows.Count == 0 && nyukinDt.Rows.Count == 0) continue;

                #region 繰越先頭行追加処理
                page++;
                rowCount++;
                printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
                printRow["nen"] = Convert.ToString(shimeYMDTo.Year);
                printRow["tuki"] = Convert.ToString(shimeYMDTo.Month);
                printRow["simebi"] = Convert.ToString(shimeYMDTo.Day);
                printRow["tokuisakiCd"] = tokuisakiCode;
                printRow["tokuisakiNm"] = tokuisakiName;
                printRow["hinmei1"] = "前月繰越";
                printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                printRow["group"] = group;
                printRow["page"] = page;
                motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
                #endregion

                foreach (DataRow nyukinRow in nyukinDt.Rows)
                {
                    decimal.TryParse(Convert.ToString(nyukinRow["kingaku"]), out wkDec);
                    if (wkDec == decimal.Zero) continue;
                    uriageDt.Rows.Add(nyukinRow.ItemArray);
                }

                var sortQuery = uriageDt.AsEnumerable().OrderBy(p => p.Field<DateTime>(DBFileLayout.UriageHeaderFile.dcDenpyoHizuke))
                                                       .OrderBy(p => p.Field<string>(DBFileLayout.UriageHeaderFile.dcJigyousyoCode))
                                                       .OrderBy(p => Convert.ToInt16(p.Field<string>(DBFileLayout.UriageHeaderFile.dcDenpyoNo)))
                                                       .OrderBy(p => p.Field<Int16>("kingakuType"));
                #region 帳票出力データ追加処理
                foreach (DataRow uriageRow in uriageDt.Rows)
                {
                    decimal.TryParse(Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcSuryo]), out suryo);
                    decimal.TryParse(Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcTanka]), out tanka);
                    decimal.TryParse(Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcKingaku]), out kingaku);
                    DateTime.TryParse(Convert.ToString(uriageRow[DBFileLayout.UriageHeaderFile.dcDenpyoHizuke]), out uriageDate);
                    uriageMonth = uriageDate.Month.ToString();
                    uriageDay = uriageDate.Day.ToString();
                    int.TryParse(Convert.ToString(uriageRow["kingakuType"]), out kingakuType);
                    try
                    {
                        nextRow = uriageDt.Rows[uriageDt.Rows.IndexOf(uriageRow) + 1];
                        if (!Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcDenpyoNo]).Equals(nextRow[DBFileLayout.UriageBodyFile.dcDenpyoNo]))
                        {
                            flgDispSashihiki = true;
                        }
                        else
                        {
                            flgDispSashihiki = false;
                        }
                        flgNextRowExists = true;
                    }
                    catch
                    {
                        flgDispSashihiki = true;
                        flgNextRowExists = false;
                    }
                    #region 伝票タイトル行追加処理
                    if (kingakuType == 0 && (!wkJigyousyoCode.Equals(Convert.ToString(uriageRow[DBFileLayout.UriageHeaderFile.dcJigyousyoCode])) || !wkDenpyouNo.Equals(Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcDenpyoNo]))))
                    {
                        if (flgNextRowExists && rowCount + 1 == pageRowCount)
                        {
                            // 繰越行追加処理実行
                            addKurikoshiRow(ref motocho, shimeYMDTo, tokuisakiCode, tokuisakiName, kurikoshi, group,ref page,ref rowCount, uriageMonth, uriageDay);
                        }
                        rowCount++;
                        kenmei = Convert.ToString(uriageRow[DBFileLayout.UriageHeaderFile.dcKenmei1]);
                        jigyousyoName = Convert.ToString(uriageRow[DBFileLayout.UriageHeaderFile.dcJigyousyoName]);
                        printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
                        printRow["nen"] = Convert.ToString(shimeYMDTo.Year);
                        printRow["tuki"] = Convert.ToString(shimeYMDTo.Month);
                        printRow["simebi"] = Convert.ToString(shimeYMDTo.Day);
                        printRow["tokuisakiCd"] = tokuisakiCode;
                        printRow["tokuisakiNm"] = tokuisakiName;
                        printRow["hinmei1"] = kenmei;
                        printRow["group"] = group;
                        printRow["page"] = page;
                        printRow["uriageMD"] = uriageMonth + "月" + uriageDay + "日";
                        printRow["jigyousyoName"] = jigyousyoName;
                        wkDenpyouNo = Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcDenpyoNo]);
                        motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
                        wkJigyousyoCode = Convert.ToString(uriageRow[DBFileLayout.UriageHeaderFile.dcJigyousyoCode]);
                    }
                    #endregion

                    if (flgNextRowExists && rowCount + 1 == pageRowCount)
                    {
                        // 繰越行追加処理実行
                        addKurikoshiRow(ref motocho, shimeYMDTo, tokuisakiCode, tokuisakiName, kurikoshi, group, ref page, ref rowCount, uriageMonth, uriageDay);
                    }
                    rowCount++;
                    printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
                    printRow["nen"] = Convert.ToString(shimeYMDTo.Year);
                    printRow["tuki"] = Convert.ToString(shimeYMDTo.Month);
                    printRow["simebi"] = Convert.ToString(shimeYMDTo.Day);
                    printRow["tokuisakiCd"] = tokuisakiCode;
                    printRow["tokuisakiNm"] = tokuisakiName;

                    switch ((NyukinKingakuType)kingakuType)
                    {
                        case NyukinKingakuType.genkin:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "現金";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.hurikomi:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "振込";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.tesuryo:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "手数料";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.kogitte:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "小切手";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.tegata:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "手形";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.tegataWaribiki:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "手形割引";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.sousai:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "相殺";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.ribeto:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "リベート";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.densai:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "でんさい";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.tyousei:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "調整";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        case NyukinKingakuType.sonota:
                            printRow["nyukin"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = "その他";
                            kurikoshi -= kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                        default:
                            printRow["suryo"] = suryo.ToString("#,##0");
                            printRow["tani"] = Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcTani]);
                            printRow["tanka"] = tanka.ToString("#,##0");
                            printRow["zeinuUriage"] = kingaku.ToString("#,##0");
                            printRow["hinmei1"] = Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcShouhinName1]);
                            printRow["hinmei2"] = Convert.ToString(uriageRow[DBFileLayout.UriageBodyFile.dcShouhinName2]);
                            kurikoshi += kingaku;
                            uriageTotal += kingaku;
                            if (flgDispSashihiki) printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
                            break;
                    }
                    printRow["group"] = group;
                    printRow["page"] = page;
                    motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
                }
                #endregion

                if (flgNextRowExists && rowCount + 1 == pageRowCount)
                {
                    // 繰越行追加処理実行
                    addKurikoshiRow(ref motocho, shimeYMDTo, tokuisakiCode, tokuisakiName, kurikoshi, group, ref page, ref rowCount, uriageMonth, uriageDay);
                }

                #region 消費税行追加処理
                if (rowCount == pageRowCount)
                {
                    page++;
                }
                rowCount++;
                printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
                printRow["nen"] = Convert.ToString(shimeYMDTo.Year);
                printRow["tuki"] = Convert.ToString(shimeYMDTo.Month);
                printRow["simebi"] = Convert.ToString(shimeYMDTo.Day);
                printRow["tokuisakiCd"] = tokuisakiCode;
                printRow["tokuisakiNm"] = tokuisakiName;
                printRow["hinmei1"] = "消費税";
                printRow["zeinuUriage"] = (uriageTotal / 10).ToString("#,##0");
                printRow["sashihikiZandaka"] = (kurikoshi + (uriageTotal / 10)).ToString("#,##0");
                printRow["group"] = group;
                printRow["page"] = page;
                motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
                #endregion

                addEmptyRowCount = pageRowCount - (rowCount % pageRowCount);
                if (rowCount > 0 && (rowCount % pageRowCount) == 0) addEmptyRowCount = 0;
                while (addEmptyRowCount > 0)
                {
                    printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
                    printRow["nen"] = Convert.ToString(shimeYMDTo.Year);
                    printRow["tuki"] = Convert.ToString(shimeYMDTo.Month);
                    printRow["simebi"] = Convert.ToString(shimeYMDTo.Day);
                    printRow["group"] = group;
                    printRow["page"] = page;
                    motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
                    addEmptyRowCount--;
                }
                motocho.Tables["dtblTokuisakibetuUriageMotocho"].AcceptChanges();

                var maxPageQuery = motocho.Tables["dtblTokuisakibetuUriageMotocho"].AsEnumerable().Where(p => p.Field<Int16>("group") == group);
                foreach (DataRow row in maxPageQuery)
                {
                    row["maxPage"] = page;
                }
                motocho.Tables["dtblTokuisakibetuUriageMotocho"].AcceptChanges();
            }

            return motocho;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtTightenDateYears.Text) ||
                string.IsNullOrEmpty(txtTightenDateMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblTightenDate.Text));
                return;
            }
            dtblTokuisakibetuUriageMotocho motocho = getData();
            if (motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Count == 0)
            {
                string msg1 = txtTightenDateYears.Text;
                string msg2 = txtTightenDateMonth.Text;
                errorOK(string.Format(Messages.M0055, msg1, msg2));
                return;
            }
            rptTokuisakiUriageMotocyo1.SetDataSource(motocho);


            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptTokuisakiUriageMotocyo1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptTokuisakiUriageMotocyo1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptTokuisakiUriageMotocyo1.PrintOptions.PaperOrientation)
                                                                     , rptTokuisakiUriageMotocyo1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptTokuisakiUriageMotocyo1.PrintToPrinter(printerSettings
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

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private bool setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (dt == null || dt.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerCode.Focus();
                return false;
            }

            if (flgUnconditional || txtCustomerCode.BeforeValue != tokuisakiCode)
            {
                DataRow dRow = dt.Rows[0];
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Text = string.Empty;
                }
                else
                {
                    var query = dt.AsEnumerable().Where(p => p.Field<string>("jigyousyoCode").Equals(jigyousyoCode));
                    if (query.Count() > 0)
                    {
                        dRow = query.ElementAt(0);
                    }
                    // 取得データを画面項目に設定
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
                }
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;

            return true;
        }
        #endregion

        #region 検索ボタン入力可否設定
        /// <summary>
        /// 検索ボタン入力可否設定
        /// </summary>
        private void setSearchButtonEnabled()
        {
            bool enabled = true;
            // 編集中の項目が存在しない場合
            if (activeControlInfo.Control == null)
            {
                // 検索ボタン使用不可
                enabled = false;
            }
            // 得意先ｺｰﾄﾞを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 上記以外
            else
            {
                // 検索ボタン使用不可
                enabled = false;
            }
            // 検索ボタンの入力可否設定
            btnSearch.Enabled = enabled;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTightenDateYears.MaxLength = 4;  // 締年月日(年)
            txtTightenDateMonth.MaxLength = 2;  // 締年月日(月)
            txtCustomerCode.MaxLength = 5;      // 得意先ｺｰﾄﾞ

            // 入力制御イベント設定
            txtTightenDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 締年月日(年)  :数字のみ入力可
            txtTightenDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 締年月日(月)  :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 得意先ｺｰﾄﾞ    :数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
        }
        #endregion

        #region 締区分コンボボックスの設定
        /// <summary>
        /// 締区分コンボボックスの設定
        /// </summary>
        private void setTightenTypeCmb()
        {
            ComboBoxStyle cmbStyle = ComboBoxStyle.DropDownList;
            // 締区分取得
            DataTable tightenTypeDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE006);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbTightenType, tightenTypeDt, "kubun", "kubunName");
            cmbTightenType.DropDownStyle = cmbStyle;
            cmbTightenType.SelectedIndex = 0;
        }
        #endregion

        #region 繰越行追加処理
        /// <summary>
        /// 繰越行追加処理
        /// </summary>
        /// <param name="motocho"></param>
        /// <param name="shimeYMD"></param>
        /// <param name="tokuisakiCode"></param>
        /// <param name="tokuisakiName"></param>
        /// <param name="kurikoshi"></param>
        /// <param name="group"></param>
        /// <param name="page"></param>
        /// <param name="rowCount"></param>
        /// <param name="uriageMonth"></param>
        /// <param name="uriageDay"></param>
        private void addKurikoshiRow(ref dtblTokuisakibetuUriageMotocho motocho
                                   , DateTime shimeYMD
                                   , string tokuisakiCode
                                   , string tokuisakiName
                                   , decimal kurikoshi
                                   , int group
                                   , ref int page
                                   , ref int rowCount
                                   , string uriageMonth
                                   , string uriageDay)
        {
            DataRow printRow;
            #region 繰越最終行追加処理
            printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
            printRow["nen"] = Convert.ToString(shimeYMD.Year);
            printRow["tuki"] = Convert.ToString(shimeYMD.Month);
            printRow["simebi"] = Convert.ToString(shimeYMD.Day);
            printRow["tokuisakiCd"] = tokuisakiCode;
            printRow["tokuisakiNm"] = tokuisakiName;
            printRow["hinmei1"] = "次頁への繰越";
            printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
            printRow["group"] = group;
            printRow["page"] = page;
            motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
            page++;
            rowCount = 0;
            #endregion

            #region 繰越先頭行追加処理
            rowCount++;
            printRow = motocho.Tables["dtblTokuisakibetuUriageMotocho"].NewRow();
            printRow["nen"] = Convert.ToString(shimeYMD.Year);
            printRow["tuki"] = Convert.ToString(shimeYMD.Month);
            printRow["simebi"] = Convert.ToString(shimeYMD.Day);
            printRow["tokuisakiCd"] = tokuisakiCode;
            printRow["tokuisakiNm"] = tokuisakiName;
            printRow["hinmei1"] = "前頁からの繰越";
            printRow["sashihikiZandaka"] = kurikoshi.ToString("#,##0");
            printRow["group"] = group;
            printRow["page"] = page;
            printRow["uriageMD"] = uriageMonth + "月" + uriageDay + "日";
            motocho.Tables["dtblTokuisakibetuUriageMotocho"].Rows.Add(printRow.ItemArray);
            #endregion

            motocho.Tables["dtblTokuisakibetuUriageMotocho"].AcceptChanges();
        }
        #endregion

        #endregion
    }
}
