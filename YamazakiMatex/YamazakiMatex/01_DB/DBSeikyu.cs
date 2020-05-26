using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using YamazakiMatex;
using Common;
using Resorce;
using SeikyuKoshin;

namespace DB
{
    /// <summary>
    /// 請求DBモジュール
    /// </summary>
    class DBSeikyu : DBFileLayout
    {
        #region 変数宣言
        private DataTable seikyuData;

        /// <summary>
        /// データ更新情報格納クラス
        /// </summary>
        public class UpdateCriteria
        {
            #region 変数宣言
            /// <summary>
            /// データ更新処理区分
            /// </summary>
            public enum ProcessingType
            {
                Default = 0
                , UpDate = 1
                , Cancel = 2
            }
            /// <summary>
            /// 処理区分
            /// </summary>
            private ProcessingType processType = ProcessingType.Default;
            /// <summary>
            /// 請求締日(年)
            /// </summary>
            private string tightenDateYears = string.Empty;
            /// <summary>
            /// 請求締日(月)
            /// </summary>
            private string tightenDateMonth = string.Empty;
            /// <summary>
            /// 請求締日(日)の選択値
            /// </summary>
            private string tightenDateDaysValue = string.Empty;
            /// <summary>
            /// 請求締日(日)の画面表示値
            /// </summary>
            private string tightenDateDaysText = string.Empty;
            /// <summary>
            /// 請求日(年)
            /// </summary>
            private string billingDateYears = string.Empty;
            /// <summary>
            /// 請求日(月)
            /// </summary>
            private string billingDateMonth = string.Empty;
            /// <summary>
            /// 請求日(日)
            /// </summary>
            private string billingDateDays = string.Empty;
            /// <summary>
            /// 得意先コード
            /// </summary>
            private string customerCode = string.Empty;
            /// <summary>
            /// 得意先名
            /// </summary>
            private string customerName = string.Empty;
            /// <summary>
            /// 得意先カナ名
            /// </summary>
            private string customerKanaName = string.Empty;
            /// <summary>
            /// 事業所コード
            /// </summary>
            private string officesCode = string.Empty;
            /// <summary>
            /// 事業所名
            /// </summary>
            private string officesName = string.Empty;
            /// <summary>
            /// 対象売上日付(FROM)(年)
            /// </summary>
            private string salesDateFromYears = string.Empty;
            /// <summary>
            /// 対象売上日付(FROM)(月)
            /// </summary>
            private string salesDateFromMonth = string.Empty;
            /// <summary>
            /// 対象売上日付(FROM)(日)
            /// </summary>
            private string salesDateFromDays = string.Empty;
            /// <summary>
            /// 対象売上日付(TO)(年)
            /// </summary>
            private string salesDateToYears = string.Empty;
            /// <summary>
            /// 対象売上日付(TO)(月)
            /// </summary>
            private string salesDateToMonth = string.Empty;
            /// <summary>
            /// 対象売上日付(TO)(日)
            /// </summary>
            private string salesDateToDays = string.Empty;
            /// <summary>
            /// 得意先情報リスト
            /// </summary>
            private List<string[]> customerInfos = new List<string[]>();
            /// <summary>
            /// 更新対象売上ボディデータのKey情報
            /// </summary>
            private List<string[]> updUriageBodyKey = new List<string[]>();
            /// <summary>
            /// 削除対象売上ボディデータのKey情報
            /// </summary>
            private List<string[]> delUriageBodyKey = new List<string[]>();
            #endregion

            #region 取得・設定
            /// <summary>
            /// 処理区分の取得・設定
            /// </summary>
            public ProcessingType ProcessType
            {
                get { return processType; }
                set { processType = value; }
            }
            /// <summary>
            /// 請求締日(年)の取得・設定
            /// </summary>
            public string TightenDateYears
            {
                get { return tightenDateYears; }
                set { tightenDateYears = value; }
            }
            /// <summary>
            /// 請求締日(月)の取得・設定
            /// </summary>
            public string TightenDateMonth
            {
                get { return tightenDateMonth; }
                set { tightenDateMonth = setDateZero(value, 2); }
            }
            /// <summary>
            /// 請求締日(日)の選択値の取得・設定
            /// </summary>
            public string TightenDateDaysValue
            {
                get { return tightenDateDaysValue; }
                set { tightenDateDaysValue = value; }
            }
            /// <summary>
            /// 請求締日(日)の画面表示値の取得・設定
            /// </summary>
            public string TightenDateDaysText
            {
                get { return tightenDateDaysText; }
                set { tightenDateDaysText = value; }
            }
            /// <summary>
            /// 請求日(年)の取得・設定
            /// </summary>
            public string BillingDateYears
            {
                get { return billingDateYears; }
                set { billingDateYears = value; }
            }
            /// <summary>
            /// 請求日(月)の取得・設定
            /// </summary>
            public string BillingDateMonth
            {
                get { return billingDateMonth; }
                set { billingDateMonth = setDateZero(value, 2); }
            }
            /// <summary>
            /// 請求日(日)の取得・設定
            /// </summary>
            public string BillingDateDays
            {
                get { return billingDateDays; }
                set { billingDateDays = setDateZero(value, 2); }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string CustomerCode
            {
                get { return customerCode; }
                set { customerCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string CustomerName
            {
                get { return customerName; }
                set { customerName = value; }
            }
            /// <summary>
            /// 得意先カナ名の取得・設定
            /// </summary>
            public string CustomerKanaName
            {
                get { return customerKanaName; }
                set { customerKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string OfficesCode
            {
                get { return officesCode; }
                set { officesCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string OfficesName
            {
                get { return officesName; }
                set { officesName = value; }
            }
            /// <summary>
            /// 対象売上日付(FROM)(年)の取得・設定
            /// </summary>
            public string SalesDateFromYears
            {
                get { return salesDateFromYears; }
                set { salesDateFromYears = value; }
            }
            /// <summary>
            /// 対象売上日付(FROM)(月)の取得・設定
            /// </summary>
            public string SalesDateFromMonth
            {
                get { return salesDateFromMonth; }
                set { salesDateFromMonth = setDateZero(value, 2); }
            }
            /// <summary>
            /// 対象売上日付(FROM)(日)の取得・設定
            /// </summary>
            public string SalesDateFromDays
            {
                get { return salesDateFromDays; }
                set { salesDateFromDays = setDateZero(value, 2); }
            }
            /// <summary>
            /// 対象売上日付(TO)(年)の取得・設定
            /// </summary>
            public string SalesDateToYears
            {
                get { return salesDateToYears; }
                set { salesDateToYears = value; }
            }
            /// <summary>
            /// 対象売上日付(TO)(月)の取得・設定
            /// </summary>
            public string SalesDateToMonth
            {
                get { return salesDateToMonth; }
                set { salesDateToMonth = setDateZero(value, 2); }
            }
            /// <summary>
            /// 対象売上日付(TO)(日)の取得・設定
            /// </summary>
            public string SalesDateToDays
            {
                get { return salesDateToDays; }
                set { salesDateToDays = setDateZero(value, 2); }
            }
            /// <summary>
            /// 得意先情報リストの取得・設定
            /// </summary>
            public List<string[]> CustomerInfos
            {
                get { return customerInfos; }
                set { customerInfos = value; }
            }
            /// <summary>
            /// 更新対象売上ボディデータのKey情報の取得・設定
            /// </summary>
            public List<string[]> UpdUriageBodyKey
            {
                get { return updUriageBodyKey; }
                set { updUriageBodyKey = value; }
            }
            /// <summary>
            /// 削除対象売上ボディデータのKey情報の取得・設定
            /// </summary>
            public List<string[]> DelUriageBodyKey
            {
                get { return delUriageBodyKey; }
                set { delUriageBodyKey = value; }
            }
            #endregion

            #region イベント

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public UpdateCriteria()
            {
            }
            #endregion

            #endregion

            #region ビジネスロジック

            #region 日付項目の先頭0付加処理
            /// <summary>
            /// 日付項目の先頭0付加処理
            /// </summary>
            /// <param name="value"></param>
            /// <param name="maxLength"></param>
            private string setDateZero(string value, int maxLength)
            {
                while (value.Length < maxLength)
                {
                    value = "0" + value;
                }

                return value;
            }
            #endregion

            #endregion
        }
        #endregion

        #region 取得・設定処理
        public DataTable SeikyuData
        {
            get { return seikyuData; }
            set { seikyuData = value; }
        }
        #endregion

        #region データ取得時のエラー区分
        /// <summary>
        /// データ取得時のエラー区分
        /// </summary>
        public enum SelectErrorType
        {
            None = 0
          , JuchuHeader = 1
          , JuchuBody = 2
          , JuchuFooter = 3
          , UriageHeader = 4
          , UriageBody = 5
          , UriageFooter = 6
          , ShireHeader = 7
          , ShireBody = 8
          , ShireFooter = 9
        }
        #endregion

        #region 更新チェック処理実行時の処理結果
        /// <summary>
        /// 更新チェック処理実行時の処理結果
        /// </summary>
        public enum UpdateCheckResult
        {
            Normal = 0
          , NoMasterData = 1
          , NoExistsTargetData = 2
          , ExistsTargetData = 3
          , DataLock = 4
          , SelectedChild = 5
        }
        #endregion

        #region 更新処理実行時の処理結果
        /// <summary>
        /// 更新処理実行時の処理結果
        /// </summary>
        public enum UpdateResult
        {
            Normal = 0
          , Error = 1
        }
        #endregion

        #region 請求データの取得処理
        /// <summary>
        /// 請求データの取得処理
        /// </summary>
        /// <param name="juchuDocumentNo"></param>
        /// <param name="flgInit"></param>
        /// <returns></returns>
        public SelectErrorType getSeikyuList(frmSeikyuChangeSearch.uriageSearchCriteria searchCriteria)
        {
            seikyuData = new DataTable();
            string sql = string.Empty;

            // 請求データ取得SQL生成
            sql += "SELECT uh.denpyoNo ";
            sql += "     , uh.denpyoHizuke ";
            sql += "     , uh.tokuisakiName ";
            sql += "     , uh.jigyousyoName ";
            sql += "     , ub.shouhinName1 ";
            sql += "     , ub.suryo ";
            sql += "     , ub.tani ";
            sql += "     , ub.tanka ";
            sql += "     , ub.kingaku ";
            sql += "     , ub.seikyuHizuke ";
            sql += "     , ub.seikyuHuragu ";
            sql += "     , ub.seikyuHizuke AS beforeSeikyuHizuke ";
            sql += "     , ub.rowNo ";
            sql += "FROM(SELECT * FROM uriage_header WHERE kanriKubun IS NULL OR kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "') uh ";
            sql += "INNER JOIN(SELECT * FROM uriage_body WHERE kanriKubun IS NULL OR kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "' AND IFNULL(flgPrint, 0) = 1) ub ";
            sql += "ON(uh.denpyoNo = ub.denpyoNo) ";
            sql += "WHERE 1 = 1 ";
            sql += "AND (ub.seikyuHuragu IS NULL OR ub.seikyuHuragu = '' OR ub.seikyuHuragu = '0') ";

            // 請求日(年)が入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.BillingDateYears))
            {
                sql += "AND DATE_FORMAT(uh.seikyuHizuke, '%Y') = '" + searchCriteria.BillingDateYears + "' ";
            }
            // 請求日(月)が入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.BillingDateMonth))
            {
                sql += "AND DATE_FORMAT(uh.seikyuHizuke, '%m') = '" + searchCriteria.BillingDateMonth + "' ";
            }
            // 請求日(日)が入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.BillingDateDays))
            {
                sql += "AND DATE_FORMAT(uh.seikyuHizuke, '%d') = '" + searchCriteria.BillingDateDays + "' ";
            }
            // 伝票日付(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.DocumentDateFromYears) &&
                !string.IsNullOrEmpty(searchCriteria.DocumentDateFromMonth) &&
                !string.IsNullOrEmpty(searchCriteria.DocumentDateFromDays))
            {
                string documentDateFrom = searchCriteria.DocumentDateFromYears;
                documentDateFrom += "/" + searchCriteria.DocumentDateFromMonth;
                documentDateFrom += "/" + searchCriteria.DocumentDateFromDays;
                sql += "AND uh.denpyoHizuke >= '" + documentDateFrom + "' ";
            }
            // 伝票日付(TO)が入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.DocumentDateToYears) &&
                !string.IsNullOrEmpty(searchCriteria.DocumentDateToMonth) &&
                !string.IsNullOrEmpty(searchCriteria.DocumentDateToDays))
            {
                string documentDateTo = searchCriteria.DocumentDateToYears;
                documentDateTo += "/" + searchCriteria.DocumentDateToMonth;
                documentDateTo += "/" + searchCriteria.DocumentDateToDays;
                sql += "AND uh.denpyoHizuke <= '" + documentDateTo + "' ";
            }
            // 伝票Noが入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.DocumentNo))
            {
                sql += "AND uh.denpyoNo = '" + searchCriteria.DocumentNo + "' ";
            }
            // 受注Noが入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.OrdersNo))
            {
                sql += "AND CONCAT(uh.juchuNoTop, uh.juchuNoMid, uh.juchuNoBtm) = '" + searchCriteria.OrdersNo + "' ";
            }
            // 得意先コードが入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.CustomerCode))
            {
                sql += "AND uh.tokuisakiCode = '" + searchCriteria.CustomerCode + "' ";
            }
            // 事業所コードが入力されている場合
            if (!string.IsNullOrEmpty(searchCriteria.OfficesCode))
            {
                sql += "AND uh.jigyousyoCode = '" + searchCriteria.OfficesCode + "' ";
            }

            // 請求データ取得処理実行
            SeikyuData = executeSelect(sql, true);
            // 取得時にエラーが発生した場合
            if (DBRef < 0)
            {
                return SelectErrorType.JuchuHeader;
            }

            return SelectErrorType.None;
        }
        #endregion

        #region 請求更新チェック処理
        /// <summary>
        /// 請求更新チェック処理
        /// </summary>
        /// <returns></returns>
        public UpdateCheckResult checkUpdateSeikyu(ref UpdateCriteria updateCriteria)
        {
            UpdateCheckResult ret = UpdateCheckResult.Normal;
            try
            {
                List<string[]> customerInfos = new List<string[]>();
                string sql = string.Empty;
                bool flgParentExist = false;
                string seikyusakiCode = string.Empty;
                string seikyusakiJigyousyoCode = string.Empty;
                if (!string.IsNullOrEmpty(updateCriteria.CustomerCode))
                {
                    sql += "SELECT * ";
                    sql += "FROM tokuisaki_master ";
                    sql += "WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                    sql += "AND tokuisakiCode ='" + updateCriteria.CustomerCode + "' ";
                    sql += "AND jigyousyoCode ='" + updateCriteria.OfficesCode + "' ";
                    DataTable chkCustomerDt = executeSelect(sql, true);
                    if (chkCustomerDt != null && chkCustomerDt.Rows.Count > 0)
                    {
                        seikyusakiCode = Convert.ToString(chkCustomerDt.Rows[0][TokuisakiMasterFile.dcSeikyusakiCode]);
                        seikyusakiJigyousyoCode = Convert.ToString(chkCustomerDt.Rows[0][TokuisakiMasterFile.dcSeikyusakiJigyousyoCode]);
                        if (!string.IsNullOrEmpty(seikyusakiCode))
                        {
                            flgParentExist = true;
                        }
                    }
                }

                sql = string.Empty;
                sql += "SELECT tm.chihouCode ";
                sql += "     , tm.tokuisakiCode ";
                sql += "     , tm.jigyousyoCode ";
                sql += "     , CASE tmp.seikyuSyuturyokuKubun WHEN '2' ";
                sql += "            THEN 1 ";
                sql += "            ELSE 0 ";
                sql += "       END AS topPageExsist ";
                sql += "     , tm.seikyuSyuturyokuKubun ";
                sql += "     , CASE WHEN IFNULL(tm.seikyusakiCode, '') = '' THEN 0 ELSE 1 END AS flgChild ";
                sql += "FROM (SELECT * ";
                sql += "      FROM tokuisaki_master ";
                sql += "      WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                sql += "      AND shimebi ='" + updateCriteria.TightenDateDaysValue + "' ";
                if (string.IsNullOrEmpty(updateCriteria.CustomerCode))
                {
                }
                else if (flgParentExist)
                {
                    sql += "      AND (";
                    sql += "            ( tokuisakiCode ='" + updateCriteria.CustomerCode + "' ";
                    sql += "          AND jigyousyoCode ='" + updateCriteria.OfficesCode + "') ";
                    sql += "          OR ";
                    sql += "            ( tokuisakiCode ='" + seikyusakiCode + "' ";
                    sql += "          AND jigyousyoCode ='" + seikyusakiJigyousyoCode + "') ";
                    sql += "          )";
                }
                else
                {
                    sql += "      AND (";
                    sql += "            ( tokuisakiCode ='" + updateCriteria.CustomerCode + "' ";
                    sql += "          AND jigyousyoCode ='" + updateCriteria.OfficesCode + "') ";
                    sql += "          OR ";
                    sql += "            ( seikyusakiCode ='" + updateCriteria.CustomerCode + "' ";
                    sql += "          AND seikyusakiJigyousyoCode ='" + updateCriteria.OfficesCode + "') ";
                    sql += "          )";
                }
                sql += "     ) tm ";
                sql += "LEFT JOIN (SELECT * FROM tokuisaki_master WHERE(kanriKubun IS NULL OR kanriKubun <> '9')) tmp ";
                sql += "ON (tm.seikyusakiCode = tmp.tokuisakiCode AND IFNULL(tm.seikyusakiJigyousyoCode, '') = IFNULL(tmp.jigyousyoCode, '')) ";
                sql += "ORDER BY tm.tokuisakiCode, tm.jigyousyoCode ";
                DataTable customerDt = executeSelect(sql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }

                foreach (DataRow dRow in customerDt.Rows)
                {
                    customerInfos.Add(new string[] { Convert.ToString(dRow[TokuisakiMasterFile.dcChihouCode])
                                                       , Convert.ToString(dRow[TokuisakiMasterFile.dcTokuisakiCode])
                                                       , Convert.ToString(dRow[TokuisakiMasterFile.dcJigyousyoCode])
                                                       , Convert.ToString(dRow["topPageExsist"])
                                                       , Convert.ToString(dRow["seikyuSyuturyokuKubun"])
                                                       , Convert.ToString(dRow["flgChild"]) });
                }

                // 得意先情報が0件の場合
                if (customerInfos.Count == 0)
                {
                    ret = UpdateCheckResult.NoMasterData;
                    throw null;
                }

                // 処理対象のデータ取得実行
                sql = string.Empty;
                string updateConditions1 = string.Empty;
                string updateConditions2 = string.Empty;
                string deleteConditions1 = string.Empty;
                string deleteConditions2 = string.Empty;
                string uriageYmdFrom = string.Empty;
                string uriageYmdTo = string.Empty;
                string seikyuYmd = string.Empty;

                if (!string.IsNullOrEmpty(updateCriteria.SalesDateFromYears) &&
                    !string.IsNullOrEmpty(updateCriteria.SalesDateFromMonth) &&
                    !string.IsNullOrEmpty(updateCriteria.SalesDateFromDays) &&
                    !string.IsNullOrEmpty(updateCriteria.SalesDateToYears) &&
                    !string.IsNullOrEmpty(updateCriteria.SalesDateToMonth) &&
                    !string.IsNullOrEmpty(updateCriteria.SalesDateToDays))
                {
                    uriageYmdFrom += updateCriteria.SalesDateFromYears;
                    uriageYmdFrom += "-" + updateCriteria.SalesDateFromMonth;
                    uriageYmdFrom += "-" + updateCriteria.SalesDateFromDays;
                    uriageYmdTo += updateCriteria.SalesDateToYears;
                    uriageYmdTo += "-" + updateCriteria.SalesDateToMonth;
                    uriageYmdTo += "-" + updateCriteria.SalesDateToDays;
                }
                else
                {
                    uriageYmdTo += updateCriteria.TightenDateYears;
                    uriageYmdTo += "-" + updateCriteria.TightenDateMonth;
                    uriageYmdTo += "-" + updateCriteria.TightenDateDaysText;
                }
                seikyuYmd = updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateDays;
                updateConditions1 += "          uh.denpyoHizuke <= '" + uriageYmdTo + "' ";
                if (!string.IsNullOrEmpty(uriageYmdFrom)) updateConditions1 += "       AND uh.denpyoHizuke >= '" + uriageYmdFrom + "' ";
                updateConditions1 += "      AND ub.seikyuHizuke IS NULL ";
                updateConditions1 += "      AND (ub.seikyuHuragu IS NULL OR ub.seikyuHuragu = 0) ";
                updateConditions2 += "          uh.denpyoHizuke <= '" + uriageYmdTo + "' ";
                if (!string.IsNullOrEmpty(uriageYmdFrom)) updateConditions2 += "       AND uh.denpyoHizuke >= '" + uriageYmdFrom + "' ";
                updateConditions2 += "      AND ub.seikyuHizuke IS NOT NULL ";
                updateConditions2 += "      AND ub.seikyuHizuke = '" + seikyuYmd + "' ";
                updateConditions2 += "      AND (ub.seikyuHuragu IS NULL OR ub.seikyuHuragu = 0) ";
                deleteConditions1 = "     ub.seikyuHizuke = '" + seikyuYmd + "' ";
                deleteConditions1 += "AND ub.seikyuHuragu = 1 ";
                sql += "SELECT uh.denpyoNo ";
                sql += "     , ub.rowNo ";
                sql += "     , uh.tokuisakiCode ";
                sql += "FROM(SELECT * ";
                sql += "     FROM uriage_header ";
                sql += "     WHERE kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "') uh ";
                sql += "INNER JOIN(SELECT * ";
                sql += "           FROM uriage_body ";
                sql += "           WHERE IFNULL(flgPrint, 0) = 1) ub ";                
                sql += "ON(uh.denpyoNo = ub.denpyoNo) ";
                string updateSql = sql;
                updateSql += "WHERE 1 = 1 ";
                updateSql += "AND ( ";
                updateSql += "     ( ";
                updateSql += updateConditions1;
                updateSql += "     ) ";
                updateSql += "     OR ";
                updateSql += "     ( ";
                updateSql += updateConditions2;
                updateSql += "     ) ";
                updateSql += "	) ";
                string deleteSql = sql;
                deleteSql += "WHERE 1 = 1 ";
                deleteSql += "AND ( ";
                deleteSql += deleteConditions1;
                deleteSql += "	  ) ";

                updateSql += "AND ( ";
                deleteSql += "AND ( ";
                bool isFirst = true;
                foreach (string[] customerInfo in customerInfos)
                {
                    if (!isFirst)
                    {
                        updateSql += " OR ";
                        deleteSql += " OR ";
                    }
                    updateSql += "(uh.tokuisakiCode = '" + customerInfo[1] + "' AND uh.jigyousyoCode = '" + customerInfo[2] + "') ";
                    deleteSql += "(uh.tokuisakiCode = '" + customerInfo[1] + "' AND uh.jigyousyoCode = '" + customerInfo[2] + "') ";
                    isFirst = false;
                }
                updateSql += "	) ";
                deleteSql += "	) ";

                DBCommon dBCommon = new DBCommon();
                DataTable updateDt = dBCommon.executeSelect(updateSql, false);
                DataTable deleteDt = dBCommon.executeSelect(deleteSql, false);
                if ((updateCriteria.ProcessType == UpdateCriteria.ProcessingType.UpDate && ((updateDt == null || updateDt.Rows.Count == 0) && (deleteDt == null || deleteDt.Rows.Count == 0))) ||
                    (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.Cancel && (deleteDt == null || deleteDt.Rows.Count == 0)))
                {
                    ret = UpdateCheckResult.NoExistsTargetData;
                    throw null;
                }

                string updUriageHeaderLockSql = string.Empty;
                string updUriageBodyLockSql = string.Empty;
                string delUriageHeaderLockSql = string.Empty;
                string delUriageBodyLockSql = string.Empty;
                string nyukinLockSql = string.Empty;
                List<string> headersNo = new List<string>();
                updateConditions1 = string.Empty;
                updateConditions2 = string.Empty;
                deleteConditions1 = string.Empty;
                deleteConditions2 = string.Empty;
                string headerNo;
                string rowNo;
                string tokuisakiCode;
                List<string[]> updUriageBodyKey = new List<string[]>();
                List<string[]> delUriageBodyKey = new List<string[]>();
                foreach (DataRow dRow in updateDt.Rows)
                {
                    headerNo = Convert.ToString(dRow[UriageHeaderFile.dcDenpyoNo]);
                    rowNo = Convert.ToString(dRow[UriageBodyFile.dcRowNo]);
                    tokuisakiCode = Convert.ToString(dRow[UriageHeaderFile.dcTokuisakiCode]);
                    if (!headersNo.Contains(headerNo))
                    {
                        if (!string.IsNullOrEmpty(updateConditions1)) updateConditions1 += ",";
                        updateConditions1 += "'" + headerNo + "'";
                        headersNo.Add(headerNo);
                    }
                    if (!string.IsNullOrEmpty(updateConditions2)) updateConditions2 += " OR ";
                    updateConditions2 += "(denpyoNo = '" + headerNo + "' AND rowNo = " + rowNo + ")";
                    updUriageBodyKey.Add(new string[] { headerNo, rowNo , tokuisakiCode });
                }
                foreach (DataRow dRow in deleteDt.Rows)
                {
                    headerNo = Convert.ToString(dRow[UriageHeaderFile.dcDenpyoNo]);
                    rowNo = Convert.ToString(dRow[UriageBodyFile.dcRowNo]);
                    tokuisakiCode = Convert.ToString(dRow[UriageHeaderFile.dcTokuisakiCode]);
                    if (!headersNo.Contains(headerNo))
                    {
                        if (!string.IsNullOrEmpty(deleteConditions1)) deleteConditions1 += ",";
                        deleteConditions1 += "'" + headerNo + "'";
                        headersNo.Add(headerNo);
                    }
                    if (!string.IsNullOrEmpty(deleteConditions2)) deleteConditions2 += " OR ";
                    deleteConditions2 += "(denpyoNo = '" + headerNo + "' AND rowNo = " + rowNo + ")";
                    delUriageBodyKey.Add(new string[] { headerNo, rowNo , tokuisakiCode });
                }

                updUriageHeaderLockSql = string.IsNullOrEmpty(updateConditions1) ? string.Empty : "SELECT * FROM uriage_header WHERE denpyoNo IN (" + updateConditions1 + ")";
                updUriageBodyLockSql = string.IsNullOrEmpty(updateConditions2) ? string.Empty : "SELECT * FROM uriage_body WHERE " + updateConditions2;
                delUriageHeaderLockSql = string.IsNullOrEmpty(deleteConditions1) ? string.Empty : "SELECT * FROM uriage_header WHERE denpyoNo IN (" + deleteConditions1 + ")";
                delUriageBodyLockSql = string.IsNullOrEmpty(deleteConditions2) ? string.Empty : "SELECT * FROM uriage_body WHERE " + deleteConditions2;
                nyukinLockSql += "SELECT * FROM nyukin WHERE 1 = 1 ";
                nyukinLockSql += "AND (";
                isFirst = true;
                foreach (string[] customerInfo in customerInfos)
                {
                    if (!isFirst) nyukinLockSql += " OR ";
                    nyukinLockSql += "(tokuisakiCode = '" + customerInfo[1] + "' AND jigyousyoCode = '" + customerInfo[2] + "') ";
                    isFirst = false;
                }
                nyukinLockSql += "AND ";
                nyukinLockSql += "(seikyuHizuke = '" + updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateMonth + "' ";
                nyukinLockSql += "OR seikyuHizuke IS NULL) ";
                nyukinLockSql += "    )";


                DataTable delUriageHeaderDt = new DataTable();
                if (!string.IsNullOrEmpty(delUriageHeaderLockSql)) delUriageHeaderDt = executeSelect(delUriageHeaderLockSql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable delUriageBodyDt = new DataTable();
                if (!string.IsNullOrEmpty(delUriageBodyLockSql)) delUriageBodyDt = executeSelect(delUriageBodyLockSql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable nyukinDt = executeSelect(nyukinLockSql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable updUriageHeaderDt = new DataTable();
                DataTable updUriageBodyDt = new DataTable();
                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.UpDate)
                {
                    if (!string.IsNullOrEmpty(updUriageHeaderLockSql)) updUriageHeaderDt = executeSelect(updUriageHeaderLockSql, true);
                    if (DBRef < 0)
                    {
                        ret = UpdateCheckResult.DataLock;
                        throw null;
                    }
                    if (!string.IsNullOrEmpty(updUriageBodyLockSql)) updUriageBodyDt = executeSelect(updUriageBodyLockSql, true);
                    if (DBRef < 0)
                    {
                        ret = UpdateCheckResult.DataLock;
                        throw null;
                    }
                }
                DataTable seikyuNoDt = executeSelect("SELECT koumoku1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.SeikyuNo + "' ", true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable syouhizeiKanriDt = executeSelect("SELECT koumoku1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.SeikyuShimeDate + "' ", true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }

                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.UpDate &&
                    updUriageBodyDt.Rows.Count == 0 &&
                    delUriageBodyDt.Rows.Count == 0 &&
                    nyukinDt.Rows.Count == 0)
                {
                    ret = UpdateCheckResult.NoExistsTargetData;
                }
                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.Cancel &&
                    delUriageBodyDt.Rows.Count == 0 &&
                    nyukinDt.Rows.Count == 0)
                {
                    ret = UpdateCheckResult.NoExistsTargetData;
                }
                else
                {
                    ret = UpdateCheckResult.ExistsTargetData;
                    updateCriteria.CustomerInfos = customerInfos;
                    updateCriteria.UpdUriageBodyKey = updUriageBodyKey;
                    updateCriteria.DelUriageBodyKey = delUriageBodyKey;
                }
            }
            catch
            {
                DBRef = -1;
            }
            finally
            {
            }

            return ret;
        }
        #endregion

        #region 締日更新・取消処理の実行
        /// <summary>
        /// 締日更新・取消処理の実行
        /// </summary>
        /// <param name="updateCriteria"></param>
        /// <returns></returns>
        public UpdateResult updateSeikyu(UpdateCriteria updateCriteria)
        {
            UpdateResult ret = UpdateResult.Normal;


            try
            {
                string sql = string.Empty;
                DateTime registerDate = DateTime.Now;

                // 既存データのクリア処理実行
                List<string> tokuisakiSeikyuDeleteSql = new List<string>();
                List<string> nyukinResetSql = new List<string>();
                List<string> uriageBodyResetSql = new List<string>();
                List<string> seikyuHeaderDeleteSql = new List<string>();
                List<string> seikyuBodyDeleteSql = new List<string>();
                List<string> seikyuFooterDeleteSql = new List<string>();
                List<string> headNoList = new List<string>();
                DateTime seikyubi = Convert.ToDateTime(updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateDays);
                foreach (string[] customerInfo in updateCriteria.CustomerInfos)
                {
                    // 得意先別請求管理ファイル削除sql生成
                    sql = string.Empty;
                    sql += "DELETE FROM tokuisaki_seikyu ";
                    sql += "WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                    sql += "AND jigyousyoCode = '" + customerInfo[2] + "' ";
                    sql += "AND seikyubi = '" + seikyubi + "' ";
                    tokuisakiSeikyuDeleteSql.Add(sql);

                    // 入金ファイル初期化sql生成
                    sql = string.Empty;
                    sql += "UPDATE nyukin ";
                    sql += "SET seikyuHizuke = NULL ";
                    sql += "  , seikyuHuragu = NULL ";
                    sql += "WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                    sql += "AND jigyousyoCode = '" + customerInfo[2] + "' ";
                    sql += "AND seikyuHizuke = '" + updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateDays + "' ";
                    sql += "AND (kanrikubun IS NULL OR kanriKubun <> '9') ";
                    nyukinResetSql.Add(sql);
                }
                foreach (string[] key in updateCriteria.DelUriageBodyKey)
                {
                    if (!headNoList.Contains(key[0]))
                    {
                        // 請求ヘッダファイル削除sql生成
                        sql = string.Empty;
                        sql += "DELETE FROM seikyu_header ";
                        sql += "WHERE denpyoNo = '" + key[0] + "' ";
                        seikyuHeaderDeleteSql.Add(sql);
                        // 請求ボディファイル削除sql生成
                        sql = string.Empty;
                        sql += "DELETE FROM seikyu_body ";
                        sql += "WHERE denpyoNo = '" + key[0] + "' ";
                        seikyuBodyDeleteSql.Add(sql);
                        // 請求フッタファイル削除sql生成
                        sql = string.Empty;
                        sql += "DELETE FROM seikyu_footer ";
                        sql += "WHERE denpyoNo = '" + key[0] + "' ";
                        seikyuFooterDeleteSql.Add(sql);
                        headNoList.Add(key[0]);
                    }
                    // 売上ボディファイル初期化sql生成
                    sql = string.Empty;
                    sql += "UPDATE uriage_body ";
                    sql += "SET seikyuHizuke = NULL ";
                    sql += "  , seikyuHuragu = NULL ";
                    sql += "WHERE denpyoNo = '" + key[0] + "' ";
                    sql += "AND rowNo = '" + key[1] + "' ";
                    sql += "AND (kanrikubun IS NULL OR kanriKubun <> '9') ";
                    uriageBodyResetSql.Add(sql);
                }
                // 処理区分が更新の場合
                if (UpdateCriteria.ProcessingType.UpDate.Equals(updateCriteria.ProcessType))
                {
                    foreach (string[] key in updateCriteria.UpdUriageBodyKey)
                    {
                        if (!headNoList.Contains(key[0]))
                        {
                            // 請求ヘッダファイル削除sql生成
                            sql = string.Empty;
                            sql += "DELETE FROM seikyu_header ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuHeaderDeleteSql.Add(sql);
                            // 請求ボディファイル削除sql生成
                            sql = string.Empty;
                            sql += "DELETE FROM seikyu_body ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuBodyDeleteSql.Add(sql);
                            // 請求フッタファイル削除sql生成
                            sql = string.Empty;
                            sql += "DELETE FROM seikyu_footer ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuFooterDeleteSql.Add(sql);
                            headNoList.Add(key[0]);
                        }
                        // 売上ボディファイル初期化sql生成
                        sql = string.Empty;
                        sql += "UPDATE uriage_body ";
                        sql += "SET seikyuHizuke = NULL ";
                        sql += "  , seikyuHuragu = NULL ";
                        sql += "WHERE denpyoNo = '" + key[0] + "' ";
                        sql += "AND rowNo = '" + key[1] + "' ";
                        uriageBodyResetSql.Add(sql);
                    }
                }

                // 得意先別請求管理ファイル削除処理実行
                foreach (string command in tokuisakiSeikyuDeleteSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }
                // 入金ファイル初期化処理実行
                foreach (string command in nyukinResetSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }
                // 売上ボディファイル初期化処理実行
                foreach (string command in uriageBodyResetSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }
                // 請求ヘッダファイル削除処理実行
                foreach (string command in seikyuHeaderDeleteSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }
                // 請求ボディファイル削除処理実行
                foreach (string command in seikyuBodyDeleteSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }
                // 請求フッタファイル削除処理実行
                foreach (string command in seikyuFooterDeleteSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }

                // 処理区分が更新の場合
                if (UpdateCriteria.ProcessingType.UpDate.Equals(updateCriteria.ProcessType))
                {
                    // 締日更新処理実行
                    CommonLogic commonLogic = new CommonLogic();
                    List<string> tokuisakiSeikyuInsertSql = new List<string>();
                    List<string> tokuisakiSeikyuUpdateSql = new List<string>();
                    List<string> tokuisakiSeikyuPaternityUpdateSql = new List<string>();
                    List<string> uriageBodyUpdateSql = new List<string>();
                    List<string> nyukinUpdateSql = new List<string>();
                    List<string> seikyuHeaderInsertSql = new List<string>();
                    List<string> seikyuBodyInsertSql = new List<string>();
                    List<string> seikyuFooterInsertSql = new List<string>();

                    DateTime seikyuDate = Convert.ToDateTime(updateCriteria.BillingDateYears + "/" + updateCriteria.BillingDateMonth + "/" + updateCriteria.BillingDateDays);
                    DateTime zengetuSeikyuNengetu = Convert.ToDateTime(updateCriteria.TightenDateYears + "/" + updateCriteria.TightenDateMonth + "/" + "01").AddMonths(-1);

                    // 得意先マスタの親子関係を取得
                    string parentCommand = string.Empty;
                    parentCommand += "SELECT * ";
                    parentCommand += "FROM tokuisaki_master ";
                    parentCommand += "WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                    parentCommand += "AND (jigyousyoCode = '000' OR seikyuKubun = '0') ";
                    string childCommand = string.Empty;
                    childCommand += "SELECT * ";
                    childCommand += "FROM tokuisaki_master ";
                    childCommand += "WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                    childCommand += "AND (seikyuKubun = '1') ";
                    DataTable parentDt = executeNoneLockSelect(parentCommand);
                    DataTable childDt = executeNoneLockSelect(childCommand);
                    List<string> parentList = new List<string>();
                    List<string> childList = new List<string>();

                    string wkValue;
                    foreach (DataRow pRow in parentDt.Rows)
                    {
                        wkValue = Convert.ToString(pRow[TokuisakiMasterFile.dcTokuisakiCode]);
                        wkValue += ",";
                        wkValue += Convert.ToString(pRow[TokuisakiMasterFile.dcJigyousyoCode]);
                        parentList.Add(wkValue);
                    }
                    foreach (DataRow pRow in childDt.Rows)
                    {
                        wkValue = Convert.ToString(pRow[TokuisakiMasterFile.dcTokuisakiCode]);
                        wkValue += ",";
                        wkValue += Convert.ToString(pRow[TokuisakiMasterFile.dcJigyousyoCode]);
                        childList.Add(wkValue);
                    }

                    headNoList = new List<string>();
                    DataTable seikyuNoDt2 = executeSelect("SELECT IFNULL(MAX(CAST(seikyuNo AS SIGNED)), 0) AS seikyuNo FROM seikyu_header ", false);
                    int seikyuNo2 = Convert.ToInt16(seikyuNoDt2.Rows[0]["seikyuNo"]);
                    foreach (string[] key in updateCriteria.DelUriageBodyKey)
                    {
                        if (!headNoList.Contains(key[0]))
                        {
                            seikyuNo2++;

                            #region 請求ヘッダファイル追加sql生成
                            sql = string.Empty;
                            sql += "INSERT INTO ";
                            sql += "seikyu_header(seikyuNo ";
                            sql += "            , denpyoNo ";
                            sql += "            , denpyoHizuke ";
                            sql += "            , juchuNoTop ";
                            sql += "            , juchuNoMid ";
                            sql += "            , juchuNoBtm ";
                            sql += "            , chihouCode ";
                            sql += "            , chikuCode ";
                            sql += "            , tokuisakiCode ";
                            sql += "            , tokuisakiName ";
                            sql += "            , tokuisakiKanaName ";
                            sql += "            , jigyousyoCode ";
                            sql += "            , jigyousyoName ";
                            sql += "            , tokuisakiTantousayName ";
                            sql += "            , zipCode ";
                            sql += "            , addres1 ";
                            sql += "            , addres2 ";
                            sql += "            , tantousyaCode ";
                            sql += "            , tantousyaName ";
                            sql += "            , kenmeiNo ";
                            sql += "            , kenmei1 ";
                            sql += "            , kenmei2 ";
                            sql += "            , chumonHizuke ";
                            sql += "            , shiteiDenpyoNo ";
                            sql += "            , nouhinHizuke ";
                            sql += "            , kouban1 ";
                            sql += "            , kouban2 ";
                            sql += "            , kouban3 ";
                            sql += "            , nouhinsyoKubun ";
                            sql += "            , bikou1 ";
                            sql += "            , bikou2 ";
                            sql += "            , kyakusakiChuban ";
                            sql += "            , seikyuHizuke ";
                            sql += "            , seikyuHuragu ";
                            sql += "            , flgMeisaiIkkatuSyuturyoku ";
                            sql += "            , kousinNichizi ";
                            sql += "            , kanriKubun) ";
                            sql += "SELECT '" + commonLogic.getZeroBuriedNumberText(seikyuNo2.ToString(), 8) + "' AS seikyuNo ";
                            sql += "     , denpyoNo ";
                            sql += "     , denpyoHizuke ";
                            sql += "     , juchuNoTop ";
                            sql += "     , juchuNoMid ";
                            sql += "     , juchuNoBtm ";
                            sql += "     , chihouCode ";
                            sql += "     , chikuCode ";
                            sql += "     , tokuisakiCode ";
                            sql += "     , tokuisakiName ";
                            sql += "     , tokuisakiKanaName ";
                            sql += "     , jigyousyoCode ";
                            sql += "     , jigyousyoName ";
                            sql += "     , tokuisakiTantousayName ";
                            sql += "     , zipCode ";
                            sql += "     , addres1 ";
                            sql += "     , addres2 ";
                            sql += "     , tantousyaCode ";
                            sql += "     , tantousyaName ";
                            sql += "     , kenmeiNo ";
                            sql += "     , kenmei1 ";
                            sql += "     , kenmei2 ";
                            sql += "     , chumonHizuke ";
                            sql += "     , shiteiDenpyoNo ";
                            sql += "     , nouhinHizuke ";
                            sql += "     , kouban1 ";
                            sql += "     , kouban2 ";
                            sql += "     , kouban3 ";
                            sql += "     , nouhinsyoKubun ";
                            sql += "     , bikou1 ";
                            sql += "     , bikou2 ";
                            sql += "     , kyakusakiChuban ";
                            sql += "     , seikyuHizuke ";
                            sql += "     , seikyuHuragu ";
                            sql += "     , flgMeisaiIkkatuSyuturyoku ";
                            sql += "     , kousinNichizi ";
                            sql += "     , kanriKubun ";
                            sql += "FROM uriage_header ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuHeaderInsertSql.Add(sql);
                            #endregion

                            #region 請求フッタファイル追加sql生成
                            sql = string.Empty;
                            sql += "INSERT INTO ";
                            sql += "seikyu_footer(seikyuNo ";
                            sql += "            , denpyoNo ";
                            sql += "            , uriageKingaku ";
                            sql += "            , syouhizei ";
                            sql += "            , kousinNichizi ";
                            sql += "            , kanriKubun) ";
                            sql += "SELECT '" + commonLogic.getZeroBuriedNumberText(seikyuNo2.ToString(), 8) + "' AS seikyuNo ";
                            sql += "     , denpyoNo ";
                            sql += "     , uriageKingaku ";
                            sql += "     , syouhizei ";
                            sql += "     , kousinNichizi ";
                            sql += "     , kanriKubun ";
                            sql += "FROM uriage_footer ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuFooterInsertSql.Add(sql);
                            #endregion

                            headNoList.Add(key[0]);
                        }

                        #region 請求ボディファイル追加sql生成
                        sql = string.Empty;
                        sql += "INSERT INTO ";
                        sql += "seikyu_body(seikyuNo ";
                        sql += "          , denpyoNo ";
                        sql += "          , rowNo ";
                        sql += "          , juchuRowNo ";
                        sql += "          , flgPrint ";
                        sql += "          , daiBunruiCode ";
                        sql += "          , syoBunruiCode ";
                        sql += "          , shouhinCode ";
                        sql += "          , shouhinName1 ";
                        sql += "          , shouhinName2 ";
                        sql += "          , suryo ";
                        sql += "          , tani ";
                        sql += "          , tanka ";
                        sql += "          , kingaku ";
                        sql += "          , nouhinJoutai ";
                        sql += "          , bikou ";
                        sql += "          , seikyuHizuke ";
                        sql += "          , seikyuHuragu ";
                        sql += "          , kousinNichizi ";
                        sql += "          , kanriKubun) ";
                        sql += "SELECT '" + commonLogic.getZeroBuriedNumberText(seikyuNo2.ToString(), 8) + "' AS seikyuNo ";
                        sql += "     , denpyoNo ";
                        sql += "     , rowNo ";
                        sql += "     , juchuRowNo ";
                        sql += "     , flgPrint ";
                        sql += "     , daiBunruiCode ";
                        sql += "     , syoBunruiCode ";
                        sql += "     , shouhinCode ";
                        sql += "     , shouhinName1 ";
                        sql += "     , shouhinName2 ";
                        sql += "     , suryo ";
                        sql += "     , tani ";
                        sql += "     , tanka ";
                        sql += "     , kingaku ";
                        sql += "     , nouhinJoutai ";
                        sql += "     , bikou ";
                        sql += "     , seikyuHizuke ";
                        sql += "     , seikyuHuragu ";
                        sql += "     , kousinNichizi ";
                        sql += "     , kanriKubun ";
                        sql += "FROM uriage_body ";
                        sql += "WHERE denpyoNo = '" + key[0] + "'";
                        sql += "AND rowNo = '" + key[1] + "'";
                        seikyuBodyInsertSql.Add(sql);
                        #endregion

                        #region 売上ボディファイル更新sql生成
                        sql = string.Empty;
                        sql += "UPDATE uriage_body ";
                        sql += "SET seikyuHizuke = '" + updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateDays + "' ";
                        sql += "  , seikyuHuragu = '1' ";
                        sql += "WHERE denpyoNo = '" + key[0] + "' ";
                        sql += "AND rowNo = '" + key[1] + "' ";
                        uriageBodyUpdateSql.Add(sql);
                        #endregion
                    }
                    foreach (string[] key in updateCriteria.UpdUriageBodyKey)
                    {
                        if (!headNoList.Contains(key[0]))
                        {
                            seikyuNo2++;

                            #region 請求ヘッダファイル追加sql生成
                            sql = string.Empty;
                            sql += "INSERT INTO ";
                            sql += "seikyu_header(seikyuNo ";
                            sql += "            , denpyoNo ";
                            sql += "            , denpyoHizuke ";
                            sql += "            , juchuNoTop ";
                            sql += "            , juchuNoMid ";
                            sql += "            , juchuNoBtm ";
                            sql += "            , chihouCode ";
                            sql += "            , chikuCode ";
                            sql += "            , tokuisakiCode ";
                            sql += "            , tokuisakiName ";
                            sql += "            , tokuisakiKanaName ";
                            sql += "            , jigyousyoCode ";
                            sql += "            , jigyousyoName ";
                            sql += "            , tokuisakiTantousayName ";
                            sql += "            , zipCode ";
                            sql += "            , addres1 ";
                            sql += "            , addres2 ";
                            sql += "            , tantousyaCode ";
                            sql += "            , tantousyaName ";
                            sql += "            , kenmeiNo ";
                            sql += "            , kenmei1 ";
                            sql += "            , kenmei2 ";
                            sql += "            , chumonHizuke ";
                            sql += "            , shiteiDenpyoNo ";
                            sql += "            , nouhinHizuke ";
                            sql += "            , kouban1 ";
                            sql += "            , kouban2 ";
                            sql += "            , kouban3 ";
                            sql += "            , nouhinsyoKubun ";
                            sql += "            , bikou1 ";
                            sql += "            , bikou2 ";
                            sql += "            , kyakusakiChuban ";
                            sql += "            , seikyuHizuke ";
                            sql += "            , seikyuHuragu ";
                            sql += "            , flgMeisaiIkkatuSyuturyoku ";
                            sql += "            , kousinNichizi ";
                            sql += "            , kanriKubun) ";
                            sql += "SELECT '" + commonLogic.getZeroBuriedNumberText(seikyuNo2.ToString(), 8) + "' AS seikyuNo ";
                            sql += "     , denpyoNo ";
                            sql += "     , denpyoHizuke ";
                            sql += "     , juchuNoTop ";
                            sql += "     , juchuNoMid ";
                            sql += "     , juchuNoBtm ";
                            sql += "     , chihouCode ";
                            sql += "     , chikuCode ";
                            sql += "     , tokuisakiCode ";
                            sql += "     , tokuisakiName ";
                            sql += "     , tokuisakiKanaName ";
                            sql += "     , jigyousyoCode ";
                            sql += "     , jigyousyoName ";
                            sql += "     , tokuisakiTantousayName ";
                            sql += "     , zipCode ";
                            sql += "     , addres1 ";
                            sql += "     , addres2 ";
                            sql += "     , tantousyaCode ";
                            sql += "     , tantousyaName ";
                            sql += "     , kenmeiNo ";
                            sql += "     , kenmei1 ";
                            sql += "     , kenmei2 ";
                            sql += "     , chumonHizuke ";
                            sql += "     , shiteiDenpyoNo ";
                            sql += "     , nouhinHizuke ";
                            sql += "     , kouban1 ";
                            sql += "     , kouban2 ";
                            sql += "     , kouban3 ";
                            sql += "     , nouhinsyoKubun ";
                            sql += "     , bikou1 ";
                            sql += "     , bikou2 ";
                            sql += "     , kyakusakiChuban ";
                            sql += "     , seikyuHizuke ";
                            sql += "     , seikyuHuragu ";
                            sql += "     , flgMeisaiIkkatuSyuturyoku ";
                            sql += "     , kousinNichizi ";
                            sql += "     , kanriKubun ";
                            sql += "FROM uriage_header ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuHeaderInsertSql.Add(sql);
                            #endregion

                            #region 請求フッタファイル追加sql生成
                            sql = string.Empty;
                            sql += "INSERT INTO ";
                            sql += "seikyu_footer(seikyuNo ";
                            sql += "            , denpyoNo ";
                            sql += "            , uriageKingaku ";
                            sql += "            , syouhizei ";
                            sql += "            , kousinNichizi ";
                            sql += "            , kanriKubun) ";
                            sql += "SELECT '" + commonLogic.getZeroBuriedNumberText(seikyuNo2.ToString(), 8) + "' AS seikyuNo ";
                            sql += "     , denpyoNo ";
                            sql += "     , uriageKingaku ";
                            sql += "     , syouhizei ";
                            sql += "     , kousinNichizi ";
                            sql += "     , kanriKubun ";
                            sql += "FROM uriage_footer ";
                            sql += "WHERE denpyoNo = '" + key[0] + "' ";
                            seikyuFooterInsertSql.Add(sql);
                            #endregion

                            headNoList.Add(key[0]);
                        }

                        #region 請求ボディファイル追加sql生成
                        sql = string.Empty;
                        sql += "INSERT INTO ";
                        sql += "seikyu_body(seikyuNo ";
                        sql += "          , denpyoNo ";
                        sql += "          , rowNo ";
                        sql += "          , juchuRowNo ";
                        sql += "          , flgPrint ";
                        sql += "          , daiBunruiCode ";
                        sql += "          , syoBunruiCode ";
                        sql += "          , shouhinCode ";
                        sql += "          , shouhinName1 ";
                        sql += "          , shouhinName2 ";
                        sql += "          , suryo ";
                        sql += "          , tani ";
                        sql += "          , tanka ";
                        sql += "          , kingaku ";
                        sql += "          , nouhinJoutai ";
                        sql += "          , bikou ";
                        sql += "          , seikyuHizuke ";
                        sql += "          , seikyuHuragu ";
                        sql += "          , kousinNichizi ";
                        sql += "          , kanriKubun) ";
                        sql += "SELECT '" + commonLogic.getZeroBuriedNumberText(seikyuNo2.ToString(), 8) + "' AS seikyuNo ";
                        sql += "     , denpyoNo ";
                        sql += "     , rowNo ";
                        sql += "     , juchuRowNo ";
                        sql += "     , flgPrint ";
                        sql += "     , daiBunruiCode ";
                        sql += "     , syoBunruiCode ";
                        sql += "     , shouhinCode ";
                        sql += "     , shouhinName1 ";
                        sql += "     , shouhinName2 ";
                        sql += "     , suryo ";
                        sql += "     , tani ";
                        sql += "     , tanka ";
                        sql += "     , kingaku ";
                        sql += "     , nouhinJoutai ";
                        sql += "     , bikou ";
                        sql += "     , seikyuHizuke ";
                        sql += "     , seikyuHuragu ";
                        sql += "     , kousinNichizi ";
                        sql += "     , kanriKubun ";
                        sql += "FROM uriage_body ";
                        sql += "WHERE denpyoNo = '" + key[0] + "'";
                        sql += "AND rowNo = '" + key[1] + "'";
                        seikyuBodyInsertSql.Add(sql);
                        #endregion

                        #region 売上ボディファイル更新sql生成
                        sql = string.Empty;
                        sql += "UPDATE uriage_body ";
                        sql += "SET seikyuHizuke = '" + updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateDays + "' ";
                        sql += "  , seikyuHuragu = '1' ";
                        sql += "WHERE denpyoNo = '" + key[0] + "' ";
                        sql += "AND rowNo = '" + key[1] + "' ";
                        uriageBodyUpdateSql.Add(sql);
                        #endregion
                    }

                    foreach (string[] customerInfo in updateCriteria.CustomerInfos)
                    {
                        #region 入金ファイル更新sql生成
                        sql = string.Empty;
                        sql += "UPDATE nyukin ";
                        sql += "SET seikyuHizuke = '" + updateCriteria.BillingDateYears + "-" + updateCriteria.BillingDateMonth + "-" + updateCriteria.BillingDateDays + "' ";
                        sql += "  , seikyuHuragu = '1' ";
                        sql += "WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                        sql += "AND jigyousyoCode = '" + customerInfo[2] + "' ";
                        sql += "AND seikyuHizuke IS NULL ";
                        sql += "AND (kanrikubun IS NULL OR kanriKubun <> '9') ";
                        nyukinUpdateSql.Add(sql);
                        #endregion
                    }

                    // 売上ボディファイル更新処理実行
                    foreach (string command in uriageBodyUpdateSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 入金ファイル更新処理実行
                    foreach (string command in nyukinUpdateSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 請求ヘッダファイル追加処理実行
                    foreach (string command in seikyuHeaderInsertSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 請求ボディファイル追加処理実行
                    foreach (string command in seikyuBodyInsertSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 請求フッタファイル追加処理実行
                    foreach (string command in seikyuFooterInsertSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }

                    DataTable seikyuNoDt = executeSelect("SELECT IFNULL(MAX(CAST(seikyuNo AS SIGNED)), 0) AS seikyuNo FROM tokuisaki_seikyu ", true);
                    int seikyuNo = Convert.ToInt16(seikyuNoDt.Rows[0]["seikyuNo"]);
                    int sSeikyuNo = seikyuNo;
                    int eSeikyuNo = seikyuNo;
                    string kenmeiSql;
                    int wkCnt;
                    DataTable kenmeiDt;
                    string kenmeiNo;
                    DataTable insertCheckDt;
                    decimal wkDec1;
                    decimal wkDec2;
                    decimal wkDec3;
                    decimal wkDec4;
                    decimal wkDec5;
                    decimal wkDec6;
                    foreach (string[] customerInfo in updateCriteria.CustomerInfos)
                    {
                        if (customerInfo[4] == "4")
                        {
                            kenmeiSql = string.Empty;
                            kenmeiSql += "SELECT kenmeiNo ";
                            kenmeiSql += "FROM (SELECT * FROM uriage_header ";
                            kenmeiSql += "      WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                            kenmeiSql += "      AND   jigyousyoCode = '" + customerInfo[2] + "' ";
                            kenmeiSql += "      AND (kanriKubun IS NULL OR kanriKubun <> '9')) uh ";
                            kenmeiSql += "INNER JOIN (SELECT * FROM uriage_body WHERE 1 = 1 AND ";
                            kenmeiSql += "(";
                            wkCnt = 0;
                            foreach (string[] updInfo in updateCriteria.UpdUriageBodyKey)
                            {
                                if (!customerInfo[1].Equals(updInfo[2])) continue;
                                if (wkCnt > 0) kenmeiSql += " OR ";
                                kenmeiSql += "(";
                                kenmeiSql += "denpyoNo = '" + updInfo[0] + "' AND rowNo = " + updInfo[1];
                                kenmeiSql += ")";
                                wkCnt++;
                            }
                            foreach (string[] delInfo in updateCriteria.DelUriageBodyKey)
                            {
                                if (!customerInfo[1].Equals(delInfo[2])) continue;
                                if (wkCnt > 0) kenmeiSql += " OR ";
                                kenmeiSql += "(";
                                kenmeiSql += "denpyoNo = '" + delInfo[0] + "' AND rowNo = " + delInfo[1];
                                kenmeiSql += ")";
                                wkCnt++;
                            }
                            kenmeiSql += ") ";
                            kenmeiSql += ") ub ";
                            kenmeiSql += "ON (uh.denpyoNo = ub.denpyoNo) ";
                            kenmeiSql += "GROUP BY uh.kenmeiNo";
                            kenmeiDt = executeSelect(kenmeiSql, false);
                            wkCnt = 0;
                            foreach (DataRow kenmeiRow in kenmeiDt.Rows)
                            {
                                kenmeiNo = Convert.ToString(kenmeiRow[UriageHeaderFile.dcKenmeiNo]);
                                sql = string.Empty;
                                sql += "SELECT syukei.tokuisakiCode ";
                                sql += "      , syukei.jigyousyoCode ";
                                sql += "      , syukei.zengetsuSeikyu AS zengetsuSeikyuGaku ";
                                sql += "      , syukei.nyukingaku AS nyukinGaku ";
                                sql += "      , syukei.kurikosi AS kurikosiGaku ";
                                sql += "      , syukei.zeinukiUriageGoukei AS tougetsuZeinukiOkaiageGaku ";
                                sql += "      , syukei.syouhizeiGoukei AS syouhizeiGakuTou ";
                                sql += "      , syukei.kurikosi + syukei.zeinukiUriageGoukei + syukei.syouhizeiGoukei AS tougetuZeikomiSeikyu ";
                                sql += "      , '" + updateCriteria.TightenDateYears + updateCriteria.TightenDateMonth + "' AS shimeNengetu ";
                                sql += "FROM (SELECT tm.tokuisakiCode ";
                                sql += "           , tm.jigyousyoCode ";
                                sql += "           , IFNULL(zts.zeikomiSeikyu, 0) AS zengetsuSeikyu ";
                                sql += "           , IFNULL(n.nyukingaku, 0) AS nyukingaku ";
                                sql += "           , IFNULL(zts.zeikomiSeikyu, 0) - IFNULL(n.nyukingaku, 0) AS kurikosi ";
                                sql += "           , IFNULL(u.uriageGoukei, 0) AS zeinukiUriageGoukei ";
                                sql += "           , IFNULL(u.syouhizeiGoukei, 0) AS syouhizeiGoukei ";
                                sql += "      FROM (SELECT tokuisakiCode ";
                                sql += "                 , jigyousyoCode ";
                                sql += "                 , syohizeiHasuKubun ";
                                sql += "            FROM tokuisaki_master ";
                                sql += "            WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                                sql += "            AND jigyousyoCode = '" + customerInfo[2] + "') tm";
                                sql += "      LEFT JOIN (SELECT ts.tokuisakiCode, ts.jigyousyoCode, ts.zeikomiSeikyu " + " \r";
                                sql += "                 FROM (SELECT tokuisakiCode , jigyousyoCode , MAX(seikyuNo) AS seikyuNo " + " \r";
                                sql += "                       FROM tokuisaki_seikyu " + " \r";
                                sql += "                       WHERE tokuisakiCode = '" + customerInfo[1] + "' " + " \r";
                                sql += "                       AND jigyousyoCode = '" + customerInfo[2] + "' " + " \r";
                                sql += "                       AND kenmeiNo = '" + kenmeiNo + "' ";
                                sql += "                       AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                                sql += "                       GROUP BY tokuisakiCode, jigyousyoCode " + " \r";
                                sql += "                      ) maxSeikyu " + " \r";
                                sql += "                 INNER JOIN (SELECT seikyuNo, tokuisakiCode, jigyousyoCode, IFNULL(zeikomiSeikyu, 0) AS zeikomiSeikyu FROM tokuisaki_seikyu) ts " + " \r";
                                sql += "                 ON (maxSeikyu.seikyuNo = ts.seikyuNo) " + " \r";
                                sql += "      ) zts " + " \r";
                                sql += "      ON (tm.tokuisakiCode = zts.tokuisakiCode " + " \r";
                                sql += "      AND tm.jigyousyoCode = zts.jigyousyoCode) " + " \r";

                                sql += "      LEFT JOIN (SELECT tokuisakiCode ";
                                sql += "                      , jigyousyoCode ";
                                if (wkCnt == 1)
                                {
                                    sql += "                      , SUM(IFNULL(goukei, 0)) AS nyukingaku ";
                                }
                                else
                                {
                                    sql += "                      , 0 AS nyukingaku ";
                                }
                                sql += "                 FROM nyukin ";
                                sql += "                 WHERE seikyuHizuke = '" + seikyuDate + "' ";
                                sql += "                 AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') ";
                                sql += "                 GROUP BY tokuisakiCode ";
                                sql += "                        , jigyousyoCode) n ";
                                sql += "      ON (tm.tokuisakiCode = n.tokuisakiCode ";
                                sql += "      AND tm.jigyousyoCode = n.jigyousyoCode) ";
                                sql += "      LEFT JOIN (SELECT u.tokuisakiCode ";
                                sql += "                      , u.jigyousyoCode ";
                                sql += "                      , SUM(IFNULL(u.uriageGoukei, 0)) AS uriageGoukei";
                                sql += "                      , SUM(IFNULL(u.syouhizei, 0)) AS syouhizeiGoukei";
                                sql += "                 FROM ( ";
                                sql += "                        SELECT tm.tokuisakiCode ";
                                sql += "                             , tm.jigyousyoCode ";
                                sql += "                             , SUM(IFNULL(ub.kingaku, 0)) AS uriageGoukei ";
                                sql += "                             , CASE tm.syohizeiHasuKubun ";
                                sql += "                                    WHEN '0' THEN truncate(IFNULL(SUM(IFNULL(ub.kingaku, 0)), 0) * (tm.zeiritu / 100), 0) ";
                                sql += "                                    WHEN '1' THEN truncate(IFNULL(SUM(IFNULL(ub.kingaku, 0)), 0) * (tm.zeiritu / 100) + .9, 0) ";
                                sql += "                                    WHEN '2' THEN truncate(IFNULL(SUM(IFNULL(ub.kingaku, 0)), 0) * (tm.zeiritu / 100) + .5, 0) ";
                                sql += "                               END AS syouhizei ";
                                sql += "                        FROM ( ";
                                sql += "                               SELECT tokuisakiCode ";
                                sql += "                                    , jigyousyoCode ";
                                sql += "                                    , syohizeiHasuKubun ";
                                sql += "                                    , (SELECT CASE WHEN NOW() <= STR_TO_DATE(koumoku2, '%Y%m%d') ";
                                sql += "                                                   THEN CAST(koumoku1 AS SIGNED) ";
                                sql += "                                                   ELSE CAST(koumoku3 AS SIGNED) ";
                                sql += "                                              END zeiritu ";
                                sql += "                                       FROM kanri_master ";
                                sql += "                                       WHERE kanriCode = '" + Consts.KanriCodes.ShouhizeiKanri + "') AS zeiritu ";
                                sql += "                               FROM tokuisaki_master ";
                                sql += "                               WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                                sql += "                               AND jigyousyoCode = '" + customerInfo[2] + "' ";
                                sql += "                               AND (nouhinsyoSyohizeiKubun IS NULL OR nouhinsyoSyohizeiKubun = '' OR nouhinsyoSyohizeiKubun = '0') ";
                                sql += "                               AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') ";
                                sql += "                             ) tm ";
                                sql += "                        INNER JOIN ( ";
                                sql += "                                     SELECT * ";
                                sql += "                                     FROM uriage_header ";
                                sql += "                                     WHERE (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') AND kenmeiNo = '" + kenmeiNo + "' ";
                                sql += "                                   ) uh ";
                                sql += "                        ON (tm.tokuisakiCode = uh.tokuisakiCode AND tm.jigyousyoCode = uh.jigyousyoCode) ";
                                sql += "                        INNER JOIN ( ";
                                sql += "                                     SELECT * ";
                                sql += "                                     FROM uriage_body ";
                                sql += "                                     WHERE seikyuHizuke = '" + seikyuDate + "' ";
                                sql += "                                   ) ub ";
                                sql += "                        ON (uh.denpyoNo = ub.denpyoNo) ";
                                sql += "                        GROUP BY tm.tokuisakiCode, tm.jigyousyoCode ";
                                sql += "                 UNION ALL ";
                                sql += "                        SELECT tm.tokuisakiCode ";
                                sql += "                             , tm.jigyousyoCode ";
                                sql += "                             , SUM(IFNULL(ud.kingaku, 0)) AS uriageGoukei ";
                                sql += "                             , CASE tm.syohizeiHasuKubun ";
                                sql += "                                    WHEN '0' THEN truncate(IFNULL(SUM(IFNULL(ud.kingaku, 0)), 0) * (tm.zeiritu / 100), 0) ";
                                sql += "                                    WHEN '1' THEN truncate(IFNULL(SUM(IFNULL(ud.kingaku, 0)), 0) * (tm.zeiritu / 100) + .9, 0) ";
                                sql += "                                    WHEN '2' THEN truncate(IFNULL(SUM(IFNULL(ud.kingaku, 0)), 0) * (tm.zeiritu / 100) + .5, 0) ";
                                sql += "                               END AS syouhizei ";
                                sql += "                        FROM ( ";
                                sql += "                               SELECT tokuisakiCode ";
                                sql += "                                    , jigyousyoCode ";
                                sql += "                                    , syohizeiHasuKubun ";
                                sql += "                                    , (SELECT CASE WHEN NOW() <= STR_TO_DATE(koumoku2, '%Y%m%d') ";
                                sql += "                                                   THEN CAST(koumoku1 AS SIGNED) ";
                                sql += "                                                   ELSE CAST(koumoku3 AS SIGNED) ";
                                sql += "                                              END zeiritu ";
                                sql += "                                       FROM kanri_master ";
                                sql += "                                       WHERE kanriCode = '" + Consts.KanriCodes.ShouhizeiKanri + "') AS zeiritu ";
                                sql += "                               FROM tokuisaki_master ";
                                sql += "                               WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                                sql += "                               AND jigyousyoCode = '" + customerInfo[2] + "' ";
                                sql += "                               AND nouhinsyoSyohizeiKubun = '1' ";
                                sql += "                               AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') ";
                                sql += "                             ) tm ";
                                sql += "                        INNER JOIN ( ";
                                sql += "                                     SELECT uh.tokuisakiCode ";
                                sql += "                                          , uh.jigyousyoCode ";
                                sql += "                                          , SUM(ub.kingaku) AS kingaku ";
                                sql += "                                     FROM ( ";
                                sql += "                                            SELECT * ";
                                sql += "                                            FROM uriage_header  ";
                                sql += "                                            WHERE (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') AND kenmeiNo = '" + kenmeiNo + "' ";
                                sql += "                                          ) uh ";
                                sql += "                                     INNER JOIN ( ";
                                sql += "                                                  SELECT * ";
                                sql += "                                                  FROM uriage_body ";
                                sql += "                                                  WHERE seikyuHizuke = '" + seikyuDate + "' ";
                                sql += "                                                ) ub ";
                                sql += "                                     ON (uh.denpyoNo = ub.denpyoNo) ";
                                sql += "                                     GROUP BY uh.denpyoNo, uh.tokuisakiCode, uh.jigyousyoCode ";
                                sql += "                                   ) ud ";
                                sql += "                        ON (tm.tokuisakiCode = ud.tokuisakiCode AND tm.jigyousyoCode = ud.jigyousyoCode) ";
                                sql += "                        GROUP BY tm.tokuisakiCode, tm.jigyousyoCode ";
                                sql += "                      ) u ";
                                sql += "                 GROUP BY u.tokuisakiCode, u.jigyousyoCode ";
                                sql += "                ) u ";
                                sql += "      ON (tm.tokuisakiCode = u.tokuisakiCode ";
                                sql += "      AND tm.jigyousyoCode = u.jigyousyoCode) ";
                                sql += "     ) syukei ";
                                insertCheckDt = executeSelect(sql, false);
                                if (insertCheckDt == null || insertCheckDt.Rows.Count == 0)
                                {
                                    wkDec1 = decimal.Zero;
                                    wkDec2 = decimal.Zero;
                                    wkDec3 = decimal.Zero;
                                    wkDec4 = decimal.Zero;
                                    wkDec5 = decimal.Zero;
                                    wkDec6 = decimal.Zero;
                                }
                                else
                                {
                                    decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["zengetsuSeikyuGaku"]), out wkDec1);
                                    decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["nyukinGaku"]), out wkDec2);
                                    decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["kurikosiGaku"]), out wkDec3);
                                    decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["tougetsuZeinukiOkaiageGaku"]), out wkDec4);
                                    decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["syouhizeiGakuTou"]), out wkDec5);
                                    decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["tougetuZeikomiSeikyu"]), out wkDec6);
                                }
                                if (customerInfo[5] == "1" &&
                                    wkDec1 == decimal.Zero &&
                                    wkDec2 == decimal.Zero &&
                                    wkDec3 == decimal.Zero &&
                                    wkDec4 == decimal.Zero &&
                                    wkDec5 == decimal.Zero &&
                                    wkDec6 == decimal.Zero)
                                {
                                    continue;
                                }

                                wkCnt++;
                                #region 得意先別請求管理ファイル追加sql生成
                                seikyuNo++;
                                sql = string.Empty;
                                sql += "INSERT INTO ";
                                sql += "tokuisaki_seikyu (seikyuNo ";
                                sql += "                , tokuisakiCode ";
                                sql += "                , jigyousyoCode ";
                                sql += "                , seikyubi ";
                                sql += "                , kenmeiNo ";
                                sql += "                , shimeNengetu) ";
                                sql += "VALUES ( '" + commonLogic.getZeroBuriedNumberText(seikyuNo.ToString(), 8) + "' ";
                                sql += "       , '" + customerInfo[1] + "' ";
                                sql += "       , '" + customerInfo[2] + "' ";
                                sql += "       , '" + seikyubi + "' ";
                                sql += "       , '" + kenmeiNo + "' ";
                                sql += "       , '" + updateCriteria.TightenDateYears + updateCriteria.TightenDateMonth + "' ";
                                sql += ") ";
                                tokuisakiSeikyuInsertSql.Add(sql);
                                #endregion

                                #region 得意先別請求管理ファイル更新sql生成
                                sql = string.Empty;
                                sql += "UPDATE tokuisaki_seikyu ";
                                sql += "SET zengetsuSeikyu = " + wkDec1 + " ";
                                sql += "  , nyukin = " + wkDec2 + " ";
                                sql += "  , kurikosi = " + wkDec3 + " ";
                                sql += "  , zeinukiUriage = " + wkDec4 + " ";
                                sql += "  , syouhizei = " + wkDec5 + " ";
                                sql += "  , zeikomiSeikyu = " + wkDec6 + " ";
                                sql += "WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                                sql += "AND jigyousyoCode = '" + customerInfo[2] + "' ";
                                sql += "AND seikyubi = '" + seikyubi + "' ";
                                sql += "AND kenmeiNo = '" + kenmeiNo + "' ";
                                tokuisakiSeikyuUpdateSql.Add(sql);
                                #endregion
                            }
                        }
                        else
                        {
                            sql = string.Empty;
                            sql += "SELECT syukei.tokuisakiCode " + " \r";
                            sql += "      , syukei.jigyousyoCode " + " \r";
                            sql += "      , syukei.zengetsuSeikyu AS zengetsuSeikyuGaku " + " \r";
                            sql += "      , syukei.nyukingaku AS nyukinGaku " + " \r";
                            sql += "      , syukei.kurikosi AS kurikosiGaku " + " \r";
                            sql += "      , syukei.zeinukiUriageGoukei AS tougetsuZeinukiOkaiageGaku " + " \r";
                            sql += "      , syukei.syouhizeiGoukei AS syouhizeiGakuTou " + " \r";
                            sql += "      , syukei.kurikosi + syukei.zeinukiUriageGoukei + syukei.syouhizeiGoukei AS tougetuZeikomiSeikyu " + " \r";
                            sql += "      , '" + updateCriteria.TightenDateYears + updateCriteria.TightenDateMonth + "' AS shimeNengetu " + " \r";
                            sql += "FROM (SELECT tm.tokuisakiCode " + " \r";
                            sql += "           , tm.jigyousyoCode " + " \r";
                            sql += "           , IFNULL(zts.zeikomiSeikyu, 0) AS zengetsuSeikyu " + " \r";
                            sql += "           , IFNULL(n.nyukingaku, 0) AS nyukingaku " + " \r";
                            sql += "           , IFNULL(zts.zeikomiSeikyu, 0) - IFNULL(n.nyukingaku, 0) AS kurikosi " + " \r";
                            sql += "           , IFNULL(u.uriageGoukei, 0) AS zeinukiUriageGoukei " + " \r";
                            sql += "           , IFNULL(u.syouhizeiGoukei, 0) AS syouhizeiGoukei " + " \r";
                            sql += "      FROM (SELECT tokuisakiCode " + " \r";
                            sql += "                 , jigyousyoCode " + " \r";
                            sql += "                 , syohizeiHasuKubun " + " \r";
                            sql += "            FROM tokuisaki_master " + " \r";
                            sql += "            WHERE tokuisakiCode = '" + customerInfo[1] + "' " + " \r";
                            sql += "            AND jigyousyoCode = '" + customerInfo[2] + "') tm" + " \r";
                            sql += "      LEFT JOIN (SELECT ts.tokuisakiCode, ts.jigyousyoCode, ts.zeikomiSeikyu " + " \r";
                            sql += "                 FROM (SELECT tokuisakiCode , jigyousyoCode , MAX(seikyuNo) AS seikyuNo " + " \r";
                            sql += "                       FROM tokuisaki_seikyu " + " \r";
                            sql += "                       WHERE tokuisakiCode = '" + customerInfo[1] + "' " + " \r";
                            sql += "                       AND jigyousyoCode = '" + customerInfo[2] + "' " + " \r";
                            sql += "                       AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                            sql += "                       GROUP BY tokuisakiCode, jigyousyoCode " + " \r";
                            sql += "                      ) maxSeikyu " + " \r";
                            sql += "                 INNER JOIN (SELECT seikyuNo, tokuisakiCode, jigyousyoCode, IFNULL(zeikomiSeikyu, 0) AS zeikomiSeikyu FROM tokuisaki_seikyu) ts " + " \r";
                            sql += "                 ON (maxSeikyu.seikyuNo = ts.seikyuNo) " + " \r";
                            sql += "      ) zts " + " \r";
                            sql += "      ON (tm.tokuisakiCode = zts.tokuisakiCode " + " \r";
                            sql += "      AND tm.jigyousyoCode = zts.jigyousyoCode) " + " \r";
                            sql += "      LEFT JOIN (SELECT tokuisakiCode " + " \r";
                            sql += "                      , jigyousyoCode " + " \r";
                            sql += "                      , SUM(IFNULL(goukei, 0)) AS nyukingaku " + " \r";
                            sql += "                 FROM nyukin " + " \r";
                            sql += "                 WHERE seikyuHizuke = '" + seikyuDate + "' " + " \r";
                            sql += "                 AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                            sql += "                 GROUP BY tokuisakiCode " + " \r";
                            sql += "                        , jigyousyoCode) n " + " \r";
                            sql += "      ON (tm.tokuisakiCode = n.tokuisakiCode " + " \r";
                            sql += "      AND tm.jigyousyoCode = n.jigyousyoCode) " + " \r";
                            sql += "      LEFT JOIN (SELECT u.tokuisakiCode " + " \r";
                            sql += "                      , u.jigyousyoCode " + " \r";
                            sql += "                      , SUM(IFNULL(u.uriageGoukei, 0)) AS uriageGoukei" + " \r";
                            sql += "                      , SUM(IFNULL(u.syouhizei, 0)) AS syouhizeiGoukei" + " \r";
                            sql += "                 FROM ( " + " \r";
                            sql += "                        SELECT tm.tokuisakiCode " + " \r";
                            sql += "                             , tm.jigyousyoCode " + " \r";
                            sql += "                             , SUM(IFNULL(ub.kingaku, 0)) AS uriageGoukei " + " \r";
                            sql += "                             , CASE tm.syohizeiHasuKubun " + " \r";
                            sql += "                                    WHEN '0' THEN truncate(IFNULL(SUM(IFNULL(ub.kingaku, 0)), 0) * (tm.zeiritu / 100), 0) " + " \r";
                            sql += "                                    WHEN '1' THEN truncate(IFNULL(SUM(IFNULL(ub.kingaku, 0)), 0) * (tm.zeiritu / 100) + .9, 0) " + " \r";
                            sql += "                                    WHEN '2' THEN truncate(IFNULL(SUM(IFNULL(ub.kingaku, 0)), 0) * (tm.zeiritu / 100) + .5, 0) " + " \r";
                            sql += "                               END AS syouhizei " + " \r";
                            sql += "                        FROM ( " + " \r";
                            sql += "                               SELECT tokuisakiCode " + " \r";
                            sql += "                                    , jigyousyoCode " + " \r";
                            sql += "                                    , syohizeiHasuKubun " + " \r";
                            sql += "                                    , (SELECT CASE WHEN NOW() <= STR_TO_DATE(koumoku2, '%Y%m%d') " + " \r";
                            sql += "                                                   THEN CAST(koumoku1 AS SIGNED) " + " \r";
                            sql += "                                                   ELSE CAST(koumoku3 AS SIGNED) " + " \r";
                            sql += "                                              END zeiritu " + " \r";
                            sql += "                                       FROM kanri_master " + " \r";
                            sql += "                                       WHERE kanriCode = '" + Consts.KanriCodes.ShouhizeiKanri + "') AS zeiritu " + " \r";
                            sql += "                               FROM tokuisaki_master " + " \r";
                            sql += "                               WHERE tokuisakiCode = '" + customerInfo[1] + "' " + " \r";
                            sql += "                               AND jigyousyoCode = '" + customerInfo[2] + "' " + " \r";
                            sql += "                               AND (nouhinsyoSyohizeiKubun IS NULL OR nouhinsyoSyohizeiKubun = '' OR nouhinsyoSyohizeiKubun = '0') " + " \r";
                            sql += "                               AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                            sql += "                             ) tm " + " \r";
                            sql += "                        INNER JOIN ( " + " \r";
                            sql += "                                     SELECT * " + " \r";
                            sql += "                                     FROM uriage_header " + " \r";
                            sql += "                                     WHERE (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                            sql += "                                   ) uh " + " \r";
                            sql += "                        ON (tm.tokuisakiCode = uh.tokuisakiCode AND tm.jigyousyoCode = uh.jigyousyoCode) " + " \r";
                            sql += "                        INNER JOIN ( " + " \r";
                            sql += "                                     SELECT * " + " \r";
                            sql += "                                     FROM uriage_body " + " \r";
                            sql += "                                     WHERE seikyuHizuke = '" + seikyuDate + "' " + " \r";
                            sql += "                                   ) ub " + " \r";
                            sql += "                        ON (uh.denpyoNo = ub.denpyoNo) " + " \r";
                            sql += "                        GROUP BY tm.tokuisakiCode, tm.jigyousyoCode " + " \r";
                            sql += "                 UNION ALL " + " \r";
                            sql += "                        SELECT tm.tokuisakiCode " + " \r";
                            sql += "                             , tm.jigyousyoCode " + " \r";
                            sql += "                             , SUM(IFNULL(ud.kingaku, 0)) AS uriageGoukei " + " \r";
                            sql += "                             , CASE tm.syohizeiHasuKubun " + " \r";
                            sql += "                                    WHEN '0' THEN truncate(IFNULL(SUM(IFNULL(ud.kingaku, 0)), 0) * (tm.zeiritu / 100), 0) " + " \r";
                            sql += "                                    WHEN '1' THEN truncate(IFNULL(SUM(IFNULL(ud.kingaku, 0)), 0) * (tm.zeiritu / 100) + .9, 0) " + " \r";
                            sql += "                                    WHEN '2' THEN truncate(IFNULL(SUM(IFNULL(ud.kingaku, 0)), 0) * (tm.zeiritu / 100) + .5, 0) " + " \r";
                            sql += "                               END AS syouhizei " + " \r";
                            sql += "                        FROM ( " + " \r";
                            sql += "                               SELECT tokuisakiCode " + " \r";
                            sql += "                                    , jigyousyoCode " + " \r";
                            sql += "                                    , syohizeiHasuKubun " + " \r";
                            sql += "                                    , (SELECT CASE WHEN NOW() <= STR_TO_DATE(koumoku2, '%Y%m%d') " + " \r";
                            sql += "                                                   THEN CAST(koumoku1 AS SIGNED) " + " \r";
                            sql += "                                                   ELSE CAST(koumoku3 AS SIGNED) " + " \r";
                            sql += "                                              END zeiritu " + " \r";
                            sql += "                                       FROM kanri_master " + " \r";
                            sql += "                                       WHERE kanriCode = '" + Consts.KanriCodes.ShouhizeiKanri + "') AS zeiritu " + " \r";
                            sql += "                               FROM tokuisaki_master " + " \r";
                            sql += "                               WHERE tokuisakiCode = '" + customerInfo[1] + "' " + " \r";
                            sql += "                               AND jigyousyoCode = '" + customerInfo[2] + "' " + " \r";
                            sql += "                               AND nouhinsyoSyohizeiKubun = '1' " + " \r";
                            sql += "                               AND (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                            sql += "                             ) tm " + " \r";
                            sql += "                        INNER JOIN ( " + " \r";
                            sql += "                                     SELECT uh.tokuisakiCode " + " \r";
                            sql += "                                          , uh.jigyousyoCode " + " \r";
                            sql += "                                          , SUM(ub.kingaku) AS kingaku " + " \r";
                            sql += "                                     FROM ( " + " \r";
                            sql += "                                            SELECT * " + " \r";
                            sql += "                                            FROM uriage_header  " + " \r";
                            sql += "                                            WHERE (kanriKubun IS NULL OR kanriKubun = '' OR kanriKubun = '0') " + " \r";
                            sql += "                                          ) uh " + " \r";
                            sql += "                                     INNER JOIN ( " + " \r";
                            sql += "                                                  SELECT * " + " \r";
                            sql += "                                                  FROM uriage_body " + " \r";
                            sql += "                                                  WHERE seikyuHizuke = '" + seikyuDate + "' " + " \r";
                            sql += "                                                ) ub " + " \r";
                            sql += "                                     ON (uh.denpyoNo = ub.denpyoNo) " + " \r";
                            sql += "                                     GROUP BY uh.denpyoNo, uh.tokuisakiCode, uh.jigyousyoCode " + " \r";
                            sql += "                                   ) ud " + " \r";
                            sql += "                        ON (tm.tokuisakiCode = ud.tokuisakiCode AND tm.jigyousyoCode = ud.jigyousyoCode) " + " \r";
                            sql += "                        GROUP BY tm.tokuisakiCode, tm.jigyousyoCode " + " \r";
                            sql += "                      ) u " + " \r";
                            sql += "                 GROUP BY u.tokuisakiCode, u.jigyousyoCode " + " \r";
                            sql += "                ) u " + " \r";
                            sql += "      ON (tm.tokuisakiCode = u.tokuisakiCode " + " \r";
                            sql += "      AND tm.jigyousyoCode = u.jigyousyoCode) " + " \r";
                            sql += "     ) syukei " + " \r";
                            insertCheckDt = executeSelect(sql, true);
                            if (insertCheckDt == null || insertCheckDt.Rows.Count == 0)
                            {
                                wkDec1 = decimal.Zero;
                                wkDec2 = decimal.Zero;
                                wkDec3 = decimal.Zero;
                                wkDec4 = decimal.Zero;
                                wkDec5 = decimal.Zero;
                                wkDec6 = decimal.Zero;
                            }
                            else
                            {
                                decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["zengetsuSeikyuGaku"]), out wkDec1);
                                decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["nyukinGaku"]), out wkDec2);
                                decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["kurikosiGaku"]), out wkDec3);
                                decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["tougetsuZeinukiOkaiageGaku"]), out wkDec4);
                                decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["syouhizeiGakuTou"]), out wkDec5);
                                decimal.TryParse(Convert.ToString(insertCheckDt.Rows[0]["tougetuZeikomiSeikyu"]), out wkDec6);
                            }
                            if (customerInfo[5] == "1" &&
                                wkDec1 == decimal.Zero &&
                                wkDec2 == decimal.Zero &&
                                wkDec3 == decimal.Zero &&
                                wkDec4 == decimal.Zero &&
                                wkDec5 == decimal.Zero &&
                                wkDec6 == decimal.Zero)
                            {
                                continue;
                            }
                            #region 得意先別請求管理ファイル追加sql生成
                            seikyuNo++;
                            sql = string.Empty;
                            sql += "INSERT INTO ";
                            sql += "tokuisaki_seikyu (seikyuNo ";
                            sql += "                , tokuisakiCode ";
                            sql += "                , jigyousyoCode ";
                            sql += "                , seikyubi ";
                            sql += "                , shimeNengetu) ";
                            sql += "VALUES ( '" + commonLogic.getZeroBuriedNumberText(seikyuNo.ToString(), 8) + "' ";
                            sql += "       , '" + customerInfo[1] + "' ";
                            sql += "       , '" + customerInfo[2] + "' ";
                            sql += "       , '" + seikyubi + "' ";
                            sql += "       , '" + updateCriteria.TightenDateYears + updateCriteria.TightenDateMonth + "' ";
                            sql += ") ";
                            tokuisakiSeikyuInsertSql.Add(sql);
                            #endregion

                            #region 得意先別請求管理ファイル更新sql生成
                            sql = string.Empty;
                            sql += "UPDATE tokuisaki_seikyu ";
                            sql += "SET zengetsuSeikyu = " + wkDec1 + " ";
                            sql += "  , nyukin = " + wkDec2 + " ";
                            sql += "  , kurikosi = " + wkDec3 + " ";
                            sql += "  , zeinukiUriage = " + wkDec4 + " ";
                            sql += "  , syouhizei = " + wkDec5 + " ";
                            sql += "  , zeikomiSeikyu = " + wkDec6 + " ";
                            sql += "WHERE tokuisakiCode = '" + customerInfo[1] + "' ";
                            sql += "AND jigyousyoCode = '" + customerInfo[2] + "' ";
                            sql += "AND seikyubi = '" + seikyubi + "' ";
                            tokuisakiSeikyuUpdateSql.Add(sql);
                            #endregion
                        }

                        #region 請求先得意先(親)の得意先別請求管理ファイル更新
                        if (parentList.Contains(customerInfo[1] + "," + customerInfo[2]))
                        {
                            sql = string.Empty;
                            sql += "UPDATE tokuisaki_seikyu ts, ";
                            sql += "( ";
                            sql += " SELECT tokuisakiCode ";
                            sql += "      , SUM(IFNULL(zengetsuSeikyu, 0)) AS zengetsuSeikyu ";
                            sql += "      , SUM(IFNULL(nyukin, 0)) AS nyukin ";
                            sql += "      , SUM(IFNULL(kurikosi, 0)) AS kurikosi ";
                            sql += "      , SUM(IFNULL(zeinukiUriage, 0)) AS zeinukiUriage ";
                            sql += "      , SUM(IFNULL(syouhizei, 0)) AS syouhizei ";
                            sql += "      , SUM(IFNULL(zeikomiSeikyu, 0)) AS zeikomiSeikyu ";
                            if (customerInfo[4] == "4")
                            {
                                sql += "  , kenmeiNo ";
                            }
                            sql += " FROM tokuisaki_seikyu ";
                            sql += " WHERE tokuisakiCode = '" + customerInfo[1] + "' ";

                            sql += " AND (jigyousyoCode = '" + customerInfo[2] + "' ";
                            sql += "   OR jigyousyoCode IN (SELECT jigyousyoCode ";
                            sql += "                        FROM tokuisaki_master ";
                            sql += "                        WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                            sql += "                        AND seikyusakiCode = '" + customerInfo[1] + "' ";
                            sql += "                        AND seikyusakiJigyousyoCode = '" + customerInfo[2] + "' ";
                            if (customerInfo[4] == "4")
                            {
                                sql += "                        AND IFNULL(seikyusakiCode, '') <> '' ";
                                sql += "                        AND IFNULL(seikyusakiJigyousyoCode, '') <> '' ";
                            }
                            sql += "                        )) ";

                            sql += " AND seikyubi = '" + seikyubi + "' ";
                            sql += " GROUP BY tokuisakiCode ";
                            if (customerInfo[4] == "4")
                            {
                                sql += "  , kenmeiNo ";
                            }
                            sql += ") tts ";
                            //sql += "SET ts.zengetsuSeikyu = tts.zengetsuSeikyu ";
                            //sql += "  , ts.nyukin = tts.nyukin ";
                            //sql += "  , ts.kurikosi = tts.kurikosi ";
                            //sql += "  , ts.zeinukiUriage = tts.zeinukiUriage ";
                            //sql += "  , ts.syouhizei = tts.syouhizei ";
                            //sql += "  , ts.zeikomiSeikyu = tts.zeikomiSeikyu ";
                            sql += "SET ts.nyukin = tts.nyukin ";
                            sql += "  , ts.kurikosi = ts.zengetsuSeikyu - tts.nyukin ";
                            sql += "  , ts.zeinukiUriage = tts.zeinukiUriage ";
                            sql += "  , ts.syouhizei = tts.syouhizei ";
                            sql += "  , ts.zeikomiSeikyu = (ts.zengetsuSeikyu - tts.nyukin) + tts.zeinukiUriage + tts.syouhizei ";
                            sql += "WHERE ts.tokuisakiCode = '" + customerInfo[1] + "' ";
                            sql += "AND ts.jigyousyoCode = '" + customerInfo[2] + "' ";
                            sql += "AND ts.seikyubi = '" + seikyubi + "' ";
                            if (customerInfo[4] == "4")
                            {
                                sql += "AND ts.kenmeiNo = tts.kenmeiNo ";
                            }
                            tokuisakiSeikyuPaternityUpdateSql.Add(sql);
                        }
                        #endregion

                        #region 請求先得意元(子)の得意先別請求管理ファイル更新
                        if (childList.Contains(customerInfo[1] + "," + customerInfo[2]))
                        {
                            sql = string.Empty;
                            sql += "UPDATE tokuisaki_seikyu ts ";
                            sql += "SET zengetsuSeikyu = 0 ";
                            sql += "  , nyukin = 0 ";
                            sql += "  , kurikosi = 0 ";
                            sql += "  , zeikomiSeikyu = kurikosi + zeinukiUriage + syouhizei ";
                            sql += "WHERE ts.tokuisakiCode = '" + customerInfo[1] + "' ";
                            sql += "AND ts.jigyousyoCode = '" + customerInfo[2] + "' ";
                            sql += "AND ts.seikyubi = '" + seikyubi + "' ";
                            tokuisakiSeikyuPaternityUpdateSql.Add(sql);
                        }
                        #endregion
                    }

                    // 得意先別請求管理ファイル追加処理実行
                    foreach (string command in tokuisakiSeikyuInsertSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 得意先別請求管理ファイル更新処理実行
                    foreach (string command in tokuisakiSeikyuUpdateSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 得意先別請求管理ファイル更新処理実行
                    foreach (string command in tokuisakiSeikyuPaternityUpdateSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }

                    sql = string.Empty;
                    sql += "DELETE ts FROM tokuisaki_seikyu ts " + " \r";
                    sql += "INNER JOIN (SELECT * FROM tokuisaki_master) tm " + " \r";
                    sql += "ON (ts.tokuisakiCode = tm.tokuisakiCode AND ts.jigyousyoCode = tm.jigyousyoCode) " + " \r";
                    sql += "WHERE IFNULL(ts.zengetsuSeikyu, 0) = 0 " + " \r";
                    sql += "AND IFNULL(ts.nyukin, 0) = 0 " + " \r";
                    sql += "AND IFNULL(ts.kurikosi, 0) = 0 " + " \r";
                    sql += "AND IFNULL(ts.zeinukiUriage, 0) = 0 " + " \r";
                    sql += "AND IFNULL(ts.syouhizei, 0) = 0 " + " \r";
                    sql += "AND IFNULL(ts.zeikomiSeikyu, 0) = 0 " + " \r";
                    sql += "AND seikyubi = '" + seikyubi + "' " + " \r";
                    executeDBUpdate(sql);

                    eSeikyuNo = seikyuNo;
                    sql = string.Empty;
                    sql += "SELECT * FROM tokuisaki_seikyu " + " \r";
                    sql += "WHERE seikyuNo >= '" + commonLogic.getZeroBuriedNumberText((sSeikyuNo + 1).ToString(), 8) + "' " + " \r";
                    sql += "AND seikyuNo <= '" + commonLogic.getZeroBuriedNumberText(eSeikyuNo.ToString(), 8) + "' " + " \r";
                    DataTable seikyuNoUpdataDt = executeSelect(sql, true);
                    string wkSeikyuNo;
                    foreach (DataRow row in seikyuNoUpdataDt.Rows)
                    {
                        sSeikyuNo++;
                        wkSeikyuNo = Convert.ToString(row["seikyuNo"]);
                        sql = string.Empty;
                        sql += "UPDATE tokuisaki_seikyu SET ";
                        sql += "  seikyuNo = '" + commonLogic.getZeroBuriedNumberText(sSeikyuNo.ToString(), 8) + "' ";
                        sql += "WHERE seikyuNo = '" + wkSeikyuNo + "' ";
                        executeDBUpdate(sql);
                    }

                    // 管理マスタの更新処理実行
                    sql = string.Empty;
                    sql += "UPDATE kanri_master SET ";
                    sql += "  koumoku1 = '" + seikyuNo + "' ";
                    sql += ", kousinNichizi = '" + registerDate + "' ";
                    sql += "WHERE kanriCode = '" + Consts.KanriCodes.SeikyuNo + "' ";
                    executeDBUpdate(sql);
                    if (DBRef < 0) throw null;
                    sql = string.Empty;
                    sql += "UPDATE kanri_master SET ";
                    sql += "  koumoku2 = '" + updateCriteria.TightenDateDaysValue + "' ";
                    sql += ", koumoku4 = '" + updateCriteria.BillingDateYears + updateCriteria.BillingDateMonth+ updateCriteria.BillingDateDays+ "' ";
                    sql += ", kousinNichizi = '" + registerDate + "' ";
                    sql += "WHERE kanriCode = '" + Consts.KanriCodes.SeikyuShimeDate + "' ";
                    executeDBUpdate(sql);
                    if (DBRef < 0) throw null;
                }
            }
            catch
            {
                if (DBRef < 0)
                {
                    ret = UpdateResult.Error;
                }
            }
            finally
            {
            }

            return ret;
        }
        #endregion
    }
}
