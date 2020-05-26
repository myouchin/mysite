using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using YamazakiMatex;

namespace DB
{
    /// <summary>
    /// 仕入先マスタDBモジュール
    /// </summary>
    class DBShiresakiMaster : DBFileLayout
    {
        #region 仕入先情報読み込み処理
        /// <summary>
        /// 仕入先情報読み込み処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <returns></returns>
        public DataTable getShiresakiDataTable(string shiresakiCode)
        {
            return getShiresakiDataTable(shiresakiCode, false);
        }

        /// <summary>
        /// 仕入先情報読み込み処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <returns></returns>
        public DataTable getShiresakiDataTable(string shiresakiCode, bool flgGetDeleteData)
        {
            string selectSql = "SELECT * FROM shiresaki_master WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(shiresakiCode)) selectSql += "AND shiresakiCode = '" + shiresakiCode + "' ";
            if (!flgGetDeleteData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 仕入先情報全件取得処理
        /// <summary>
        /// 仕入先情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<ShiresakiMasterFile> getAllShiresakiInfo()
        {
            return getShiresakiInfo(string.Empty);
        }
        #endregion

        #region 対象の仕入先情報取得処理
        /// <summary>
        /// 対象の得意先情報取得処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <returns></returns>
        public List<ShiresakiMasterFile> getShiresakiInfo(string shiresakiCode)
        {
            return getShiresakiInfo(shiresakiCode, false);
        }

        /// <summary>
        /// 対象の仕入先情報取得処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <param name="flgGetDeleteData"></param>
        /// <returns></returns>
        public List<ShiresakiMasterFile> getShiresakiInfo(string shiresakiCode, bool flgGetDeleteData)
        {
            List<ShiresakiMasterFile> ret = new List<ShiresakiMasterFile>();
            ShiresakiMasterFile wkShiresakiInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;
            DataTable shiresakiDt = getShiresakiDataTable(shiresakiCode, flgGetDeleteData);
            foreach (DataRow dRow in shiresakiDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[ShiresakiMasterFile.dcKousinNichizi]);

                wkShiresakiInfo = new ShiresakiMasterFile();
                // 仕入先コード
                wkShiresakiInfo.ShiresakiCode = Convert.ToString(dRow[ShiresakiMasterFile.dcShiresakiCode]);
                // 仕入先名
                wkShiresakiInfo.ShiresakiName = Convert.ToString(dRow[ShiresakiMasterFile.dcShiresakiName]);
                // 仕入先カナ名
                wkShiresakiInfo.ShiresakiKanaName = Convert.ToString(dRow[ShiresakiMasterFile.dcShiresakiKanaName]);
                // 郵便番号
                wkShiresakiInfo.ZipCode = Convert.ToString(dRow[ShiresakiMasterFile.dcZipCode]);
                // 住所１
                wkShiresakiInfo.Address1 = Convert.ToString(dRow[ShiresakiMasterFile.dcAddress1]);
                // 住所２
                wkShiresakiInfo.Address2 = Convert.ToString(dRow[ShiresakiMasterFile.dcAddress2]);
                // 連絡先１
                wkShiresakiInfo.Renrakusaki1 = Convert.ToString(dRow[ShiresakiMasterFile.dcRenrakusaki1]);
                // 連絡先２
                wkShiresakiInfo.Renrakusaki2 = Convert.ToString(dRow[ShiresakiMasterFile.dcRenrakusaki2]);
                // 締日
                wkShiresakiInfo.Shimebi = Convert.ToString(dRow[ShiresakiMasterFile.dcShimebi]);
                // 支払サイト
                wkShiresakiInfo.ShiharaiSaito = Convert.ToString(dRow[ShiresakiMasterFile.dcShiharaiSaito]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkShiresakiInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkShiresakiInfo.KanriKubun = Convert.ToString(dRow[ShiresakiMasterFile.dcKanriKubun]);

                // 得意先情報リストに追加
                ret.Add(wkShiresakiInfo);
            }

            return ret;
        }
        #endregion

        #region 仕入先情報存在チェック処理
        /// <summary>
        /// 仕入先情報存在チェック処理
        /// </summary>
        /// <param name="shouhinCode"></param>
        /// <returns></returns>
        public bool checkExistShiresakiInfo(string shiresakiCode)
        {
            DataTable shiresakiDt = getShiresakiDataTable(shiresakiCode);

            if (shiresakiDt == null || shiresakiDt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
