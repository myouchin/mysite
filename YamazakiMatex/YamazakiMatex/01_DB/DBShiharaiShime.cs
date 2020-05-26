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

namespace DB
{
    /// <summary>
    /// 支払DBモジュール
    /// </summary>
    class DBShiharaiShime : DBFileLayout
    {
        #region データ更新情報格納クラス
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
            /// 仕入先コード
            /// </summary>
            private string vendorCode = string.Empty;
            /// <summary>
            /// 仕入先名
            /// </summary>
            private string vendorName = string.Empty;
            /// <summary>
            /// 仕入先情報リスト
            /// </summary>
            private List<string[]> vendorInfos = new List<string[]>();
            /// <summary>
            /// 更新対象仕入ボディデータのKey情報
            /// </summary>
            private List<string[]> updShireBodyKey = new List<string[]>();
            /// <summary>
            /// 取消対象仕入ボディデータのKey情報
            /// </summary>
            private List<string[]> cancelShireBodyKey = new List<string[]>();
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
            /// 仕入先コードの取得・設定
            /// </summary>
            public string VendorCode
            {
                get { return vendorCode; }
                set { vendorCode = value; }
            }
            /// <summary>
            /// 仕入先名の取得・設定
            /// </summary>
            public string VendorName
            {
                get { return vendorName; }
                set { vendorName = value; }
            }
            /// <summary>
            /// 得意先情報リストの取得・設定
            /// </summary>
            public List<string[]> VendorInfos
            {
                get { return vendorInfos; }
                set { vendorInfos = value; }
            }
            /// <summary>
            /// 更新対象売上ボディデータのKey情報の取得・設定
            /// </summary>
            public List<string[]> UpdShireBodyKey
            {
                get { return updShireBodyKey; }
                set { updShireBodyKey = value; }
            }
            /// <summary>
            /// 取消対象売上ボディデータのKey情報の取得・設定
            /// </summary>
            public List<string[]> CancelShireBodyKey
            {
                get { return cancelShireBodyKey; }
                set { cancelShireBodyKey = value; }
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

            #region 日付項目の0付加処理
            /// <summary>
            /// 日付項目の0付加処理
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

        #region 支払締更新チェック処理
        /// <summary>
        /// 支払締更新チェック処理
        /// </summary>
        /// <returns></returns>
        public UpdateCheckResult checkShiharaiShime(ref UpdateCriteria updateCriteria)
        {
            UpdateCheckResult ret = UpdateCheckResult.Normal;

            try
            {
                List<string[]> vendorInfos = new List<string[]>();
                string sql = string.Empty;
                // データ更新情報．仕入先先コードが未設定の場合
                if (string.IsNullOrEmpty(updateCriteria.VendorCode))
                {
                    // データ更新情報．請求締日から得意先情報を取得
                    sql += "SELECT shiresakiCode FROM shiresaki_master ";
                    sql += "WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                    sql += "AND shimebi ='" + updateCriteria.TightenDateDaysValue + "' ";
                    sql += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                    DataTable customerDt = executeSelect(sql, true);
                    if (DBRef < 0)
                    {
                        ret = UpdateCheckResult.DataLock;
                        throw null;
                    }

                    foreach (DataRow dRow in customerDt.Rows)
                    {
                        vendorInfos.Add(new string[] { Convert.ToString(dRow[ShiresakiMasterFile.dcShiresakiCode]) });
                    }
                }
                else
                {
                    vendorInfos.Add(new string[] { updateCriteria.VendorCode });
                }

                // 仕入先情報が0件の場合
                if (vendorInfos.Count == 0)
                {
                    ret = UpdateCheckResult.NoMasterData;
                    throw null;
                }

                string updateConditions1 = string.Empty;
                string updateConditions2 = string.Empty;
                string cancelConditions1 = string.Empty;
                string cancelConditions2 = string.Empty;

                #region 処理対象データ取得
                string shireYmdTo = string.Empty;
                shireYmdTo += updateCriteria.TightenDateYears;
                shireYmdTo += "-" + updateCriteria.TightenDateMonth;
                shireYmdTo += "-" + updateCriteria.TightenDateDaysText;

                sql = string.Empty;
                sql += "SELECT sh.shireNo ";
                sql += "     , sb.rowNo ";
                sql += "FROM(SELECT * ";
                sql += "     FROM shire_header ";
                sql += "     WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') )sh ";
                sql += "INNER JOIN(SELECT * ";
                sql += "           FROM shire_body ";
                sql += "           WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') )sb ";
                sql += "ON(sh.shireNo = sb.shireNo) ";
                updateConditions1 += "     sh.denpyoHizuke <= '" + shireYmdTo + "' ";
                updateConditions1 += " AND sb.shimeNengapi IS NULL ";
                updateConditions2 += " (sb.shimeKoushinHuragu IS NULL OR sb.shimeKoushinHuragu = 0) ";
                cancelConditions1 = "     sb.shimeNengapi = '" + shireYmdTo + "' ";
                cancelConditions1 += "AND sb.shimeKoushinHuragu = 1 ";

                // 処理モード別検索条件追加
                string shireUpdateSql = sql;
                shireUpdateSql += "WHERE 1 = 1 ";
                shireUpdateSql += "AND ( ";
                shireUpdateSql += "     ( ";
                shireUpdateSql += updateConditions1;
                shireUpdateSql += "     ) ";
                shireUpdateSql += "     OR ";
                shireUpdateSql += "     ( ";
                shireUpdateSql += updateConditions2;
                shireUpdateSql += "     ) ";
                shireUpdateSql += "	) ";
                string shireCancelSql = sql;
                shireCancelSql += "WHERE 1 = 1 ";
                shireCancelSql += "AND ( " + cancelConditions1 + " ) ";

                // 仕入先検索条件追加
                string shiharaiUpdateSql = "SELECT 1 FROM shiharai WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                string shiharaiCancelSql = shiharaiUpdateSql;
                shireUpdateSql += "AND ( ";
                shireCancelSql += "AND ( ";
                shiharaiUpdateSql += "AND ( ";
                shiharaiCancelSql += "AND ( ";
                //sql += "AND shimeNengapi = '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth + "-" + updateCriteria.TightenDateDaysText + "' ";
                bool isFirst = true;
                foreach (string[] vendorInfo in vendorInfos)
                {
                    if (!isFirst)
                    {
                        shireUpdateSql += " OR ";
                        shireCancelSql += " OR ";
                        shiharaiUpdateSql += " OR ";
                        shiharaiCancelSql += " OR ";
                    }
                    shireUpdateSql += "(sh.shiresakiCode = '" + vendorInfo[0] + "') ";
                    shireCancelSql += "(sh.shiresakiCode = '" + vendorInfo[0] + "') ";
                    shiharaiUpdateSql += "(shiresakiCode = '" + vendorInfo[0] + "') ";
                    shiharaiCancelSql += "(shiresakiCode = '" + vendorInfo[0] + "') ";
                    isFirst = false;
                }
                shireUpdateSql += "	) ";
                shireCancelSql += "	) ";
                shiharaiUpdateSql += "	) ";
                shiharaiCancelSql += "	) ";
                shiharaiUpdateSql += "AND shimeNengapi IS NULL ";
                shiharaiUpdateSql += "AND shiharaiHizuke <= '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth + "-" + updateCriteria.TightenDateDaysText + "' ";
                shiharaiCancelSql += "AND shimeNengapi = '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth + "-" + updateCriteria.TightenDateDaysText + "' ";

                // データ取得実行
                DBCommon dBCommon = new DBCommon();
                DataTable shireUpdateDt = dBCommon.executeSelect(shireUpdateSql, false);
                DataTable shireCancelDt = dBCommon.executeSelect(shireCancelSql, false);
                DataTable shiharaiUpdateDt = dBCommon.executeSelect(shiharaiUpdateSql, false);
                DataTable shiharaiCancelDt = dBCommon.executeSelect(shiharaiCancelSql, false);

                // 処理対象のデータが存在しない場合
                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.UpDate)
                {
                    if ((shireUpdateDt == null || shireUpdateDt.Rows.Count == 0) &&
                        (shireCancelDt == null || shireCancelDt.Rows.Count == 0) &&
                        (shiharaiUpdateDt == null || shiharaiUpdateDt.Rows.Count == 0) &&
                        (shiharaiCancelDt == null || shiharaiCancelDt.Rows.Count == 0))
                    {
                        ret = UpdateCheckResult.NoExistsTargetData;
                        throw null;
                    }
                }
                else
                {
                    if ((shireCancelDt == null || shireCancelDt.Rows.Count == 0) &&
                        (shiharaiCancelDt == null || shiharaiCancelDt.Rows.Count == 0))
                    {
                        ret = UpdateCheckResult.NoExistsTargetData;
                        throw null;
                    }
                }
                #endregion

                #region データロック
                string updShireHeaderLockSql = string.Empty;
                string updShireBodyLockSql = string.Empty;
                string cancelShireHeaderLockSql = string.Empty;
                string cancelShireBodyLockSql = string.Empty;
                string shiharaiLockSql = string.Empty;
                List<string> headersNo = new List<string>();
                updateConditions1 = string.Empty;
                updateConditions2 = string.Empty;
                cancelConditions1 = string.Empty;
                cancelConditions2 = string.Empty;
                string headerNo;
                string rowNo;
                List<string[]> updShireBodyKey = new List<string[]>();
                List<string[]> cancelShireBodyKey = new List<string[]>();

                // 更新対象の取得条件生成
                foreach (DataRow dRow in shireUpdateDt.Rows)
                {
                    headerNo = Convert.ToString(dRow[ShireBodyFile.dcShireNo]);
                    rowNo = Convert.ToString(dRow[ShireBodyFile.dcRowNo]);
                    if (!headersNo.Contains(headerNo))
                    {
                        if (!string.IsNullOrEmpty(updateConditions1)) updateConditions1 += ",";
                        updateConditions1 += "'" + headerNo + "'";
                        headersNo.Add(headerNo);
                    }
                    if (!string.IsNullOrEmpty(updateConditions2)) updateConditions2 += " OR ";
                    updateConditions2 += "(shireNo = '" + headerNo + "' AND rowNo = " + rowNo + ")";
                    updShireBodyKey.Add(new string[] { headerNo, rowNo });
                }
                // 削除対象の取得条件生成
                foreach (DataRow dRow in shireCancelDt.Rows)
                {
                    headerNo = Convert.ToString(dRow[ShireBodyFile.dcShireNo]);
                    rowNo = Convert.ToString(dRow[ShireBodyFile.dcRowNo]);
                    if (!headersNo.Contains(headerNo))
                    {
                        if (!string.IsNullOrEmpty(cancelConditions1)) cancelConditions1 += ",";
                        cancelConditions1 += "'" + headerNo + "'";
                        headersNo.Add(headerNo);
                    }
                    if (!string.IsNullOrEmpty(cancelConditions2)) cancelConditions2 += " OR ";
                    cancelConditions2 += "(shireNo = '" + headerNo + "' AND rowNo = " + rowNo + ")";
                    cancelShireBodyKey.Add(new string[] { headerNo, rowNo });
                }

                // ロック対象の取得SQL生成
                updShireHeaderLockSql = string.IsNullOrEmpty(updateConditions1) ? string.Empty : "SELECT * FROM shire_header WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') AND shireNo IN (" + updateConditions1 + ")";
                updShireBodyLockSql = string.IsNullOrEmpty(updateConditions2) ? string.Empty : "SELECT * FROM shire_body WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') AND " + updateConditions2;
                cancelShireHeaderLockSql = string.IsNullOrEmpty(cancelConditions1) ? string.Empty : "SELECT * FROM shire_header WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') AND shireNo IN (" + cancelConditions1 + ")";
                cancelShireBodyLockSql = string.IsNullOrEmpty(cancelConditions2) ? string.Empty : "SELECT * FROM shire_body WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') AND " + cancelConditions2;
                shiharaiLockSql += "SELECT * FROM shiharai WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                shiharaiLockSql += "AND (";
                isFirst = true;
                foreach (string[] vendorInfo in vendorInfos)
                {
                    if (!isFirst) shiharaiLockSql += " OR ";
                    shiharaiLockSql += "(shiresakiCode = '" + vendorInfo[0] + "') ";
                    isFirst = false;
                }
                shiharaiLockSql += "AND ";
                shiharaiLockSql += "(shimeNengapi = '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth+ "-" + updateCriteria.TightenDateDaysText+ "' ";
                shiharaiLockSql += "OR shimeNengapi IS NULL) ";
                shiharaiLockSql += "    )";

                // ロック処理実行
                DataTable cancelShireHeaderDt = new DataTable();
                if (!string.IsNullOrEmpty(cancelShireHeaderLockSql)) cancelShireHeaderDt = executeSelect(cancelShireHeaderLockSql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable cancelShireBodyDt = new DataTable();
                if (!string.IsNullOrEmpty(cancelShireBodyLockSql)) cancelShireBodyDt = executeSelect(cancelShireBodyLockSql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable shiharaiDt = executeSelect(shiharaiLockSql, true);
                if (DBRef < 0)
                {
                    ret = UpdateCheckResult.DataLock;
                    throw null;
                }
                DataTable updShireHeaderDt = new DataTable();
                DataTable updShireBodyDt = new DataTable();
                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.UpDate)
                {
                    if (!string.IsNullOrEmpty(updShireHeaderLockSql)) updShireHeaderDt = executeSelect(updShireHeaderLockSql, true);
                    if (DBRef < 0)
                    {
                        ret = UpdateCheckResult.DataLock;
                        throw null;
                    }
                    if (!string.IsNullOrEmpty(updShireBodyLockSql)) updShireBodyDt = executeSelect(updShireBodyLockSql, true);
                    if (DBRef < 0)
                    {
                        ret = UpdateCheckResult.DataLock;
                        throw null;
                    }
                }

                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.UpDate &&
                    updShireBodyDt.Rows.Count == 0 &&
                    cancelShireBodyDt.Rows.Count == 0 &&
                    shiharaiDt.Rows.Count == 0)
                {
                    ret = UpdateCheckResult.NoExistsTargetData;
                }
                if (updateCriteria.ProcessType == UpdateCriteria.ProcessingType.Cancel &&
                    cancelShireBodyDt.Rows.Count == 0 &&
                    shiharaiDt.Rows.Count == 0)
                {
                    ret = UpdateCheckResult.NoExistsTargetData;
                }
                else
                {
                    ret = UpdateCheckResult.ExistsTargetData;
                    updateCriteria.VendorInfos = vendorInfos;
                    updateCriteria.UpdShireBodyKey = updShireBodyKey;
                    updateCriteria.CancelShireBodyKey = cancelShireBodyKey;
                }
                #endregion
            }
            catch
            {
                DBRef = -1;
            }

            return ret;
        }
        #endregion

        #region 支払締更新処理
        /// <summary>
        /// 支払締更新処理
        /// </summary>
        /// <param name="updateCriteria"></param>
        /// <returns></returns>
        public UpdateResult executeShiharaiShime(UpdateCriteria updateCriteria)
        {
            UpdateResult ret = UpdateResult.Normal;

            try
            {
                string sql = string.Empty;
                DateTime registerDate = DateTime.Now;
                DBCommon commonDb = new DBCommon();

                #region 既存データクリア処理

                List<string> shiharaiResetSql = new List<string>();
                List<string> shireBodyResetSql = new List<string>();
                List<string> headNoList = new List<string>();
                DateTime shimebi = Convert.ToDateTime(updateCriteria.TightenDateYears + "/" + updateCriteria.TightenDateMonth + "/" + updateCriteria.TightenDateDaysText);
                string touGetu = Convert.ToString(shimebi.Year) + (shimebi.Month < 10 ? "0" : string.Empty) + Convert.ToString(shimebi.Month);
                string zenGetu = Convert.ToString(shimebi.AddMonths(-1).Year) + (shimebi.AddMonths(-1).Month < 10 ? "0" : string.Empty) + Convert.ToString(shimebi.AddMonths(-1).Month);
                string zenzenGetu = Convert.ToString(shimebi.AddMonths(-2).Year) + (shimebi.AddMonths(-2).Month < 10 ? "0" : string.Empty) + Convert.ToString(shimebi.AddMonths(-2).Month);
                string zenzenzenGetu = Convert.ToString(shimebi.AddMonths(-3).Year) + (shimebi.AddMonths(-3).Month < 10 ? "0" : string.Empty) + Convert.ToString(shimebi.AddMonths(-3).Month);

                // 仕入先件数分繰り返す
                foreach (string[] vendorInfo in updateCriteria.VendorInfos)
                {
                    // 支払ファイル初期化sql生成
                    sql = string.Empty;
                    sql += "UPDATE shiharai ";
                    sql += "SET shimeNengapi = NULL ";
                    sql += "  , shimeKoushinHuragu = NULL ";
                    sql += "WHERE shiresakiCode = '" + vendorInfo[0] + "' ";
                    sql += "AND shimeNengapi = '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth + "-" + updateCriteria.TightenDateDaysText + "' ";
                    sql += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                    shiharaiResetSql.Add(sql);
                }

                // 取消対象のデータ件数分繰り返す
                foreach (string[] key in updateCriteria.CancelShireBodyKey)
                {
                    // 仕入ボディファイル初期化sql生成
                    sql = string.Empty;
                    sql += "UPDATE shire_body ";
                    sql += "SET shimeNengapi = NULL ";
                    sql += "  , shimeKoushinHuragu = NULL ";
                    sql += "WHERE shireNo = '" + key[0] + "' ";
                    sql += "AND rowNo = " + key[1] + " ";
                    sql += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                    shireBodyResetSql.Add(sql);
                }

                // 処理区分が更新の場合
                if (UpdateCriteria.ProcessingType.UpDate.Equals(updateCriteria.ProcessType))
                {
                    // 更新対象のデータ件数分繰り返す
                    foreach (string[] key in updateCriteria.UpdShireBodyKey)
                    {
                        // 仕入ボディファイル初期化sql生成
                        sql = string.Empty;
                        sql += "UPDATE shire_body ";
                        sql += "SET shimeNengapi = NULL ";
                        sql += "  , shimeKoushinHuragu = NULL ";
                        sql += "WHERE shireNo = '" + key[0] + "' ";
                        sql += "AND rowNo = " + key[1] + " ";
                        sql += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        shireBodyResetSql.Add(sql);
                    }
                }

                // 支払ファイルクリア処理実行
                foreach (string command in shiharaiResetSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }
                // 仕入ボディファイルクリア処理実行
                foreach (string command in shireBodyResetSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }

                #endregion

                #region 支払請求ファイルクリア処理

                List<string> kaikakeResetSql = new List<string>();
                string tightenDateYearsMonth = updateCriteria.TightenDateYears + updateCriteria.TightenDateMonth;
                DataTable kaikakeDt;
                // 仕入先件数分繰り返す
                foreach (string[] vendorInfo in updateCriteria.VendorInfos)
                {
                    // 支払請求ファイル取得
                    sql = string.Empty;
                    sql += "SELECT 1 FROM shiharai_seikyu ";
                    sql += "WHERE shiresakiCode = '" + vendorInfo[0] + "' ";
                    sql += "AND nengetu = '" + tightenDateYearsMonth + "' ";
                    sql += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                    kaikakeDt = commonDb.executeNoneLockSelect(sql);

                    // 支払請求ファイル初期化sql生成
                    sql = string.Empty;
                    // 対象の支払請求ファイルが存在しない場合
                    if (kaikakeDt == null || kaikakeDt.Rows.Count == 0)
                    {
                        // 登録
                        sql += "INSERT shiharai_seikyu (shiresakiCode,nengetu) ";
                        sql += "VALUES ('" + vendorInfo[0] + "','" + tightenDateYearsMonth + "') ";
                        kaikakeResetSql.Add(sql);
                    }
                    else
                    {
                        // 更新
                        sql += "UPDATE shiharai_seikyu ";
                        sql += "SET tougetsuGenkin = 0 ";
                        sql += "  , tougetsuTegata = 0 ";
                        sql += "  , tougetsuHurikomi = 0 ";
                        sql += "  , tougetsuSousai = 0 ";
                        sql += "  , tougetsuShire = 0 ";
                        sql += "  , tougetsuKurikoshi = 0 ";
                        sql += "WHERE shiresakiCode = '" + vendorInfo[0] + "' ";
                        sql += "AND nengetu = '" + tightenDateYearsMonth + "' ";
                        kaikakeResetSql.Add(sql);
                        sql = string.Empty;
                        sql += "UPDATE shiharai_seikyu ss, ";
                        sql += "(SELECT * FROM shiharai_seikyu WHERE shiresakiCode = '" + vendorInfo[0] + "' AND nengetu = '" + zenGetu + "') zengetu ";
                        sql += "SET ss.tougetsuKurikoshi = IFNULL(zengetu.tougetsuKurikoshi, 0) ";
                        sql += "WHERE ss.shiresakiCode = '" + vendorInfo[0] + "' ";
                        sql += "AND ss.nengetu = '" + tightenDateYearsMonth + "' ";
                        kaikakeResetSql.Add(sql);

                    }
                }

                // 支払請求ファイルクリア処理実行
                foreach (string command in kaikakeResetSql)
                {
                    executeDBUpdate(command);
                    if (DBRef < 0) throw null;
                }

                #endregion

                // 処理区分が更新の場合
                if (UpdateCriteria.ProcessingType.UpDate.Equals(updateCriteria.ProcessType))
                {
                    #region 締日更新処理

                    List<string> shireBodyUpdSql = new List<string>();
                    List<string> shiharaiUpdSql = new List<string>();
                    List<string> kaikakeUpdSql = new List<string>();

                    // 仕入先件数分繰り返す
                    foreach (string[] vendorInfo in updateCriteria.VendorInfos)
                    {
                        #region 支払請求ファイル更新sql生成
                        sql = string.Empty;
                        sql += "UPDATE shiharai_seikyu ss, ";
                        sql += "( ";
                        sql += "  SELECT syukei.* ";
                        sql += "       , syukei.genkinTotal + syukei.tegataTotal + syukei.hurikomiTotal + syukei.sousaiTotal AS shiharaiTotal ";
                        sql += "  FROM ( ";
                        sql += "         SELECT sm.shiresakiCode ";
                        sql += "                , IFNULL(s.genkinTotal, 0)                  AS genkinTotal ";
                        sql += "                , IFNULL(s.tegataTotal, 0)                  AS tegataTotal ";
                        sql += "                , IFNULL(s.hurikomiTotal, 0)                AS hurikomiTotal ";
                        sql += "                , IFNULL(s.sousaiTotal, 0)                  AS sousaiTotal ";
                        sql += "                , IFNULL(sd.shireTotal, 0)                  AS shireTotal ";
                        sql += "                , IFNULL(3montBefore.3TsukiMaeKurikoshi, 0) AS 3TsukiMaeKurikoshi ";
                        sql += "                , IFNULL(2montBefore.2TsukiMaeGenkin, 0)    AS 2TsukiMaeGenkin ";
                        sql += "                , IFNULL(2montBefore.2TsukiMaeTegata, 0)    AS 2TsukiMaeTegata ";
                        sql += "                , IFNULL(2montBefore.2TsukiMaeHurikomi, 0)  AS 2TsukiMaeHurikomi ";
                        sql += "                , IFNULL(2montBefore.2TsukiMaeSousai, 0)    AS 2TsukiMaeSousai ";
                        sql += "                , IFNULL(2montBefore.2TsukiMaeShire, 0)     AS 2TsukiMaeShire ";
                        sql += "                , IFNULL(2montBefore.2TsukiMaeKurikoshi, 0) AS 2TsukiMaeKurikoshi ";
                        sql += "                , IFNULL(1montBefore.1TsukiMaeGenkin, 0)    AS 1TsukiMaeGenkin ";
                        sql += "                , IFNULL(1montBefore.1TsukiMaeTegata, 0)    AS 1TsukiMaeTegata ";
                        sql += "                , IFNULL(1montBefore.1TsukiMaeHurikomi, 0)  AS 1TsukiMaeHurikomi ";
                        sql += "                , IFNULL(1montBefore.1TsukiMaeSousai, 0)    AS 1TsukiMaeSousai ";
                        sql += "                , IFNULL(1montBefore.1TsukiMaeShire, 0)     AS 1TsukiMaeShire ";
                        sql += "                , IFNULL(1montBefore.1TsukiMaeKurikoshi, 0) AS 1TsukiMaeKurikoshi ";
                        sql += "         FROM ( ";
                        sql += "                SELECT * ";
                        sql += "                FROM shiresaki_master ";
                        sql += "                WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        sql += "                AND shiresakiCode = '" + vendorInfo[0] + "' ";
                        sql += "              ) sm ";
                        sql += "         LEFT JOIN ( ";
                        sql += "                     SELECT * ";
                        sql += "                     FROM ( ";
                        sql += "                            SELECT shiresakiCode ";
                        sql += "                                 , SUM(IFNULL(genkin, 0)) AS genkinTotal ";
                        sql += "                                 , SUM(IFNULL(tegata, 0)) AS tegataTotal ";
                        sql += "                                 , SUM(IFNULL(hurikomi, 0)) AS hurikomiTotal ";
                        sql += "                                 , SUM(IFNULL(sousai, 0)) AS sousaiTotal ";
                        sql += "                            FROM shiharai ";
                        sql += "                            WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        sql += "                            AND shimeNengapi = '" + shimebi + "' ";
                        sql += "                            GROUP BY shiresakiCode ";
                        sql += "                          ) s ";
                        sql += "                   ) s ";
                        sql += "         ON (sm.shiresakiCode = s.shiresakiCode) ";
                        sql += "         LEFT JOIN (SELECT sd.shiresakiCode ";
                        sql += "                         , SUM(IFNULL(sd.shireTotal, 0)) AS shireTotal ";
                        sql += "                    FROM (";
                        sql += "                           SELECT sh.shiresakiCode ";
                        sql += "                                , sb.shireTotal ";
                        sql += "                           FROM ( ";
                        sql += "                                  SELECT * ";
                        sql += "                                  FROM shire_header ";
                        sql += "                                  WHERE kanriKubun IS NULL OR kanriKubun <> '9' ";
                        sql += "                                ) sh ";
                        sql += "                                INNER JOIN ( ";
                        sql += "                                             SELECT shireNo ";
                        sql += "                                                  , SUM(IFNULL(kingaku, 0)) AS shireTotal ";
                        sql += "                                             FROM shire_body ";
                        sql += "                                             WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
                        sql += "                                             AND shimeNengapi = '" + shimebi + "' ";
                        sql += "                                             GROUP BY shireNo ";
                        sql += "                                           ) sb ";
                        sql += "                                ON (sh.shireNo = sb.shireNo) ";
                        sql += "                         ) sd ";
                        sql += "                    GROUP BY sd.shiresakiCode ";
                        sql += "                   ) sd ";
                        sql += "         ON(sm.shiresakiCode = sd.shiresakiCode) ";
                        sql += "         LEFT JOIN ( ";
                        sql += "                     SELECT shiresakiCode ";
                        sql += "                          , 3TsukiMaeKurikoshi ";
                        sql += "                     FROM shiharai_seikyu ";
                        sql += "                     WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        sql += "                     AND nengetu = '" + zenzenzenGetu + "' ";
                        sql += "                   ) 3montBefore ";
                        sql += "         ON(sm.shiresakiCode = 3montBefore.shiresakiCode) ";
                        sql += "         LEFT JOIN ( ";
                        sql += "                     SELECT shiresakiCode ";
                        sql += "                          , 2TsukiMaeGenkin ";
                        sql += "                          , 2TsukiMaeTegata ";
                        sql += "                          , 2TsukiMaeHurikomi ";
                        sql += "                          , 2TsukiMaeSousai ";
                        sql += "                          , 2TsukiMaeShire ";
                        sql += "                          , 2TsukiMaeKurikoshi ";
                        sql += "                     FROM shiharai_seikyu ";
                        sql += "                     WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        sql += "                     AND nengetu = '" + zenzenGetu + "' ";
                        sql += "                   ) 2montBefore ";
                        sql += "         ON(sm.shiresakiCode = 2montBefore.shiresakiCode) ";
                        sql += "         LEFT JOIN ( ";
                        sql += "                     SELECT shiresakiCode ";
                        sql += "                          , 1TsukiMaeGenkin ";
                        sql += "                          , 1TsukiMaeTegata ";
                        sql += "                          , 1TsukiMaeHurikomi ";
                        sql += "                          , 1TsukiMaeSousai ";
                        sql += "                          , 1TsukiMaeShire ";
                        sql += "                          , 1TsukiMaeKurikoshi ";
                        sql += "                     FROM shiharai_seikyu ";
                        sql += "                     WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        sql += "                     AND nengetu = '" + zenGetu + "' ";
                        sql += "                   ) 1montBefore ";
                        sql += "         ON(sm.shiresakiCode = 1montBefore.shiresakiCode) ";
                        sql += "  ) syukei ";
                        sql += ") syukei ";
                        sql += "SET ss.3TsukiMaeKurikoshi = syukei.3TsukiMaeKurikoshi ";
                        sql += "  , ss.2TsukiMaeGenkin    = syukei.2TsukiMaeGenkin ";
                        sql += "  , ss.2TsukiMaeTegata    = syukei.2TsukiMaeTegata ";
                        sql += "  , ss.2TsukiMaeHurikomi  = syukei.2TsukiMaeHurikomi ";
                        sql += "  , ss.2TsukiMaeSousai    = syukei.2TsukiMaeSousai ";
                        sql += "  , ss.2TsukiMaeShire     = syukei.2TsukiMaeShire ";
                        sql += "  , ss.2TsukiMaeKurikoshi = syukei.2TsukiMaeKurikoshi ";
                        sql += "  , ss.1TsukiMaeGenkin    = syukei.1TsukiMaeGenkin ";
                        sql += "  , ss.1TsukiMaeTegata    = syukei.1TsukiMaeTegata ";
                        sql += "  , ss.1TsukiMaeHurikomi  = syukei.1TsukiMaeHurikomi ";
                        sql += "  , ss.1TsukiMaeSousai    = syukei.1TsukiMaeSousai ";
                        sql += "  , ss.1TsukiMaeShire     = syukei.1TsukiMaeShire ";
                        sql += "  , ss.1TsukiMaeKurikoshi = syukei.1TsukiMaeKurikoshi ";
                        sql += "  , ss.tougetsuGenkin     = syukei.genkinTotal ";
                        sql += "  , ss.tougetsuTegata     = syukei.tegataTotal ";
                        sql += "  , ss.tougetsuHurikomi   = syukei.hurikomiTotal ";
                        sql += "  , ss.tougetsuSousai     = syukei.sousaiTotal ";
                        sql += "  , ss.tougetsuShire      = syukei.shireTotal ";
                        sql += "  , ss.tougetsuKurikoshi  = (syukei.shireTotal + ss.tougetsuKurikoshi) - (syukei.shiharaiTotal) ";
                        sql += "WHERE ss.shiresakiCode = '" + vendorInfo[0] + "' ";
                        sql += "AND ss.nengetu = '" + touGetu + "' ";
                        sql += "AND ss.nengetu = '" + touGetu + "' ";
                        kaikakeUpdSql.Add(sql);
                        #endregion

                        #region 支払ファイル更新sql生成
                        sql = string.Empty;
                        sql += "UPDATE shiharai ";
                        sql += "SET shimeNengapi = '" + shimebi + "' ";
                        sql += "  , shimeKoushinHuragu = '1' ";
                        sql += "WHERE shiresakiCode = '" + vendorInfo[0] + "' ";
                        sql += "AND shimeNengapi IS NULL ";
                        sql += "AND shiharaiHizuke <= '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth + "-" + updateCriteria.TightenDateDaysText + "' ";
                        sql += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";
                        shiharaiUpdSql.Add(sql);
                        #endregion
                    }

                    #region 仕入ボディファイル更新sql生成

                    string commandBase = string.Empty;
                    commandBase += "UPDATE shire_body ";
                    commandBase += "SET shimeNengapi = '" + updateCriteria.TightenDateYears + "-" + updateCriteria.TightenDateMonth + "-" + updateCriteria.TightenDateDaysText + "' ";
                    commandBase += "  , shimeKoushinHuragu = '1' ";
                    commandBase += "WHERE shireNo = '{0}' ";
                    commandBase += "AND rowNo = {1} ";
                    commandBase += "AND (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') ";

                    // 取消対象のデータ件数分繰り返す
                    foreach (string[] key in updateCriteria.CancelShireBodyKey)
                    {
                        shireBodyUpdSql.Add(string.Format(commandBase, key[0], key[1]));
                    }

                    // 更新対象のデータ件数分繰り返す
                    foreach (string[] key in updateCriteria.UpdShireBodyKey)
                    {
                        shireBodyUpdSql.Add(string.Format(commandBase, key[0], key[1]));
                    }

                    #endregion

                    #endregion

                    // 仕入ボディファイル更新処理実行
                    foreach (string command in shireBodyUpdSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 支払ファイル更新処理実行
                    foreach (string command in shiharaiUpdSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                    // 支払請求ファイル更新処理実行
                    foreach (string command in kaikakeUpdSql)
                    {
                        executeDBUpdate(command);
                        if (DBRef < 0) throw null;
                    }
                }
            }
            catch
            {
                if (DBRef < 0)
                {
                    ret = UpdateResult.Error;
                }
            }

            return ret;
        }
        #endregion
    }
}
