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
    /// 件名マスタDBモジュール
    /// </summary>
    class DBKenmeiMaster : DBFileLayout
    {
        #region 件名情報読み込み処理
        /// <summary>
        /// 件名情報読み込み処理
        /// </summary>
        /// <param name="kenmeiNo"></param>
        /// <returns></returns>
        public DataTable getKenmeiDataTable(string kenmeiNo, bool flgGetDeleteData)
        {
            string selectSql = "SELECT * FROM kenmei_master WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(kenmeiNo)) selectSql += "AND kenmeiNo = '" + kenmeiNo + "' ";
            if (!flgGetDeleteData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 件名情報全件取得処理
        /// <summary>
        /// 件名情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<KenmeiMasterFile> getAllKenmeiInfo()
        {
            return getKenmeiInfo(string.Empty, true);
        }
        #endregion

        #region 対象の件名情報取得処理
        /// <summary>
        /// 対象の件名情報取得処理
        /// </summary>
        /// <param name="kenmeiNo"></param>
        /// <returns></returns>
        public List<KenmeiMasterFile> getKenmeiInfo(string kenmeiNo, bool flgGetDeleteData)
        {
            List<KenmeiMasterFile> ret = new List<KenmeiMasterFile>();
            KenmeiMasterFile wkKenmeiInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;
            DataTable tokuisakiDt = getKenmeiDataTable(kenmeiNo, flgGetDeleteData);
            foreach (DataRow dRow in tokuisakiDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[KenmeiMasterFile.dcKousinNichizi]);

                wkKenmeiInfo = new KenmeiMasterFile();
                // 件名No
                wkKenmeiInfo.KenmeiNo = Convert.ToString(dRow[KenmeiMasterFile.dcKenmeiNo]);
                // 件名１
                wkKenmeiInfo.Kenmei1 = Convert.ToString(dRow[KenmeiMasterFile.dcKenmei1]);
                // 件名２
                wkKenmeiInfo.Kenmei2 = Convert.ToString(dRow[KenmeiMasterFile.dcKenmei2]);
                // 納入先名
                wkKenmeiInfo.NonyusakiName = Convert.ToString(dRow[KenmeiMasterFile.dcNonyusakiName]);
                // 部署名
                wkKenmeiInfo.BusyoName = Convert.ToString(dRow[KenmeiMasterFile.dcBusyoName]);
                // 連絡先１
                wkKenmeiInfo.Renrakusaki1 = Convert.ToString(dRow[KenmeiMasterFile.dcRenrakusaki1]);
                // 連絡先２
                wkKenmeiInfo.Renrakusaki2 = Convert.ToString(dRow[KenmeiMasterFile.dcRenrakusaki2]);
                // 郵便番号
                wkKenmeiInfo.ZipCode = Convert.ToString(dRow[KenmeiMasterFile.dcZipCode]);
                // 住所１
                wkKenmeiInfo.Address1 = Convert.ToString(dRow[KenmeiMasterFile.dcAddress1]);
                // 住所２
                wkKenmeiInfo.Address2 = Convert.ToString(dRow[KenmeiMasterFile.dcAddress2]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkKenmeiInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkKenmeiInfo.KanriKubun = Convert.ToString(dRow[KenmeiMasterFile.dcKanriKubun]);

                // 得意先情報リストに追加
                ret.Add(wkKenmeiInfo);
            }

            return ret;
        }
        #endregion
    }
}
