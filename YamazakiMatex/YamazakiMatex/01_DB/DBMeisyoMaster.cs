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
    /// 名称マスタDBモジュール
    /// </summary>
    class DBMeisyoMaster : DBFileLayout
    {
        #region 名称情報読み込み処理
        /// <summary>
        /// 名称情報読み込み処理
        /// </summary>
        /// <param name="meisyoCode"></param>
        /// <returns></returns>
        public DataTable getMeisyoDataTable(string meisyoCode)
        {
            return getMeisyoDataTable(meisyoCode, false);
        }

        /// <summary>
        /// 名称情報読み込み処理
        /// </summary>
        /// <param name="meisyoCode"></param>
        /// <param name="flgGetDeleteData"></param>
        /// <returns></returns>
        public DataTable getMeisyoDataTable(string meisyoCode, bool flgGetDeleteData)
        {
            string selectSql = string.Empty;
            selectSql = "SELECT * FROM meisyo_master WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            if (!string.IsNullOrEmpty(meisyoCode)) selectSql += "AND meisyoCode ='" + meisyoCode + "' ";
            if(!flgGetDeleteData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 名称全件取得処理
        /// <summary>
        /// 名称情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<MeisyoMasterFile> getAllMeisyoInfo()
        {
            return getMeisyoInfo(string.Empty);
        }
        #endregion

        #region 対象の名称情報取得処理
        /// <summary>
        /// 対象の名称情報取得処理
        /// </summary>
        /// <param name="meisyoCode"></param>
        /// <returns></returns>
        public List<MeisyoMasterFile> getMeisyoInfo(string meisyoCode)
        {
            return getMeisyoInfo(meisyoCode, false);
        }

        /// <summary>
        /// 対象の名称情報取得処理
        /// </summary>
        /// <param name="meisyoCode"></param>
        /// <param name="flgGetDeleteData"></param>
        /// <returns></returns>
        public List<MeisyoMasterFile> getMeisyoInfo(string meisyoCode, bool flgGetDeleteData)
        {
            List<MeisyoMasterFile> ret = new List<MeisyoMasterFile>();
            MeisyoMasterFile wkMeisyoInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;

            DataTable meisyoDt = getMeisyoDataTable(meisyoCode, flgGetDeleteData);
            foreach (DataRow dRow in meisyoDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[MeisyoMasterFile.dcKousinNichizi]);

                wkMeisyoInfo = new MeisyoMasterFile();
                // 名称コード
                wkMeisyoInfo.MeisyoCode = Convert.ToString(dRow[MeisyoMasterFile.dcMeisyoCode]);
                // 名称
                wkMeisyoInfo.MeisyoName = Convert.ToString(dRow[MeisyoMasterFile.dcMeisyoName]);
                // 区分
                wkMeisyoInfo.Kubun = Convert.ToString(dRow[MeisyoMasterFile.dcKubun]);
                // 区分名
                wkMeisyoInfo.KubunName = Convert.ToString(dRow[MeisyoMasterFile.dcKubunName]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkMeisyoInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkMeisyoInfo.KanriKubun = Convert.ToString(dRow[MeisyoMasterFile.dcKanriKubun]);

                // 名称情報リストに追加
                ret.Add(wkMeisyoInfo);
            }

            return ret;
        }
        #endregion
    }
}
