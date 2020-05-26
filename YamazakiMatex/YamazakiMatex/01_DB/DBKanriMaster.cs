using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using YamazakiMatex;
using Resorce;

namespace DB
{
    /// <summary>
    /// 管理マスタDBモジュール
    /// </summary>
    class DBKanriMaster : DBFileLayout
    {
        #region 管理情報読み込み処理
        /// <summary>
        /// 管理情報読み込み処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <returns></returns>
        public DataTable getKanriDataTable(string kanriCode)
        {
            string selectSql = "SELECT * FROM kanri_master WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(kanriCode)) selectSql += " AND kanriCode = '" + kanriCode + "' ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 管理情報全件取得処理
        /// <summary>
        /// 得意先情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<KanriMasterFile> getAllKanriInfo()
        {
            return getKanriInfo(string.Empty);
        }
        #endregion

        #region 対象の管理情報取得処理
        /// <summary>
        /// 対象の管理情報取得処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <returns></returns>
        public List<KanriMasterFile> getKanriInfo(string kanriCode)
        {
            List<KanriMasterFile> ret = new List<KanriMasterFile>();
            KanriMasterFile wkKanriInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;
            DataTable tokuisakiDt = getKanriDataTable(kanriCode);
            foreach (DataRow dRow in tokuisakiDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[KanriMasterFile.dcKousinNichizi]);

                wkKanriInfo = new KanriMasterFile();
                // 管理コード
                wkKanriInfo.KanriCode = Convert.ToString(dRow[KanriMasterFile.dcKanriCode]);
                // 管理名称
                wkKanriInfo.KanriName = Convert.ToString(dRow[KanriMasterFile.dcKanriName]);
                // 項目１
                if (!DBNull.Value.Equals(dRow[KanriMasterFile.dcKoumoku1]))
                {
                    wkKanriInfo.Koumoku1 = Convert.ToInt32(dRow[KanriMasterFile.dcKoumoku1]);
                }
                // 項目１名称
                wkKanriInfo.Koumoku1Name = Convert.ToString(dRow[KanriMasterFile.dcKoumoku1Name]);
                // 項目２
                wkKanriInfo.Koumoku2 = Convert.ToString(dRow[KanriMasterFile.dcKoumoku2]);
                // 項目２名称
                wkKanriInfo.Koumoku2Name = Convert.ToString(dRow[KanriMasterFile.dcKoumoku2Name]);
                // 項目３
                if (!DBNull.Value.Equals(dRow[KanriMasterFile.dcKoumoku3]))
                {
                    wkKanriInfo.Koumoku3 = Convert.ToInt32(dRow[KanriMasterFile.dcKoumoku3]);
                }
                // 項目３名称
                wkKanriInfo.Koumoku3Name = Convert.ToString(dRow[KanriMasterFile.dcKoumoku3Name]);
                // 項目４
                wkKanriInfo.Koumoku4 = Convert.ToString(dRow[KanriMasterFile.dcKoumoku4]);
                // 項目４名称
                wkKanriInfo.Koumoku4Name = Convert.ToString(dRow[KanriMasterFile.dcKoumoku4Name]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkKanriInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkKanriInfo.KanriKubun = Convert.ToString(dRow[KanriMasterFile.dcKanriKubun]);

                // 得意先情報リストに追加
                ret.Add(wkKanriInfo);
            }

            return ret;
        }
        #endregion

        #region 見積番号取得処理
        /// <summary>
        /// 見積番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getMitumoriNo()
        {
            return getKanriInfo(Consts.KanriCodes.MitumoriNo)[0].Koumoku1;
        }
        #endregion

        #region 受注番号取得処理
        /// <summary>
        /// 受注番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getJuchuNo()
        {
            return getKanriInfo(Consts.KanriCodes.JuchuNo)[0].Koumoku1;
        }
        #endregion

        #region 発注番号取得処理
        /// <summary>
        /// 発注番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getHachuNo()
        {
            return getKanriInfo(Consts.KanriCodes.HachuNo)[0].Koumoku1;
        }
        #endregion

        #region 仕入番号取得処理
        /// <summary>
        /// 仕入番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getShireNo()
        {
            return getKanriInfo(Consts.KanriCodes.ShireNo)[0].Koumoku1;
        }
        #endregion

        #region 売上番号取得処理
        /// <summary>
        /// 売上番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getUriageNo()
        {
            return getKanriInfo(Consts.KanriCodes.UriageNo)[0].Koumoku1;
        }
        #endregion

        #region 件名番号取得処理
        /// <summary>
        /// 件名番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getKenmeiNo()
        {
            return getKanriInfo(Consts.KanriCodes.KenmeiNo)[0].Koumoku1;
        }
        #endregion

        #region 支払番号取得処理
        /// <summary>
        /// 支払番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getShiharaiNo()
        {
            return getKanriInfo(Consts.KanriCodes.ShiharaiNo)[0].Koumoku1;
        }
        #endregion

        #region 入金番号取得処理
        /// <summary>
        /// 入金番号取得処理
        /// </summary>
        /// <returns></returns>
        public Int32 getNyukinNo()
        {
            return getKanriInfo(Consts.KanriCodes.NyukinNo)[0].Koumoku1;
        }
        #endregion

        #region 処理日付取得処理
        /// <summary>
        /// 処理日付取得処理
        /// </summary>
        /// <returns></returns>
        public DateTime getSyoriDate()
        {
            KanriMasterFile kanriInfo = getKanriInfo(Consts.KanriCodes.SyoriDate)[0];
            string y = kanriInfo.Koumoku2.Substring(0, 4);
            string m = kanriInfo.Koumoku2.Substring(4, 2);
            string d = kanriInfo.Koumoku2.Substring(6, 2);

            return Convert.ToDateTime(y + "/" + m + "/" + d);
        }
        #endregion

        #region 処理日付の消費税率取得処理
        /// <summary>
        /// 処理日付の消費税率取得処理
        /// </summary>
        /// <returns></returns>
        public decimal getNowZeiritu()
        {
            decimal zeiritu = 10;
            decimal sZeiritu = decimal.Zero;
            decimal eZeiritu = decimal.Zero;
            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;

            DateTime syoriDate = getSyoriDate();
            KanriMasterFile kanriInfo = getKanriInfo(Consts.KanriCodes.ShouhizeiKanri)[0];

            try
            {
                sZeiritu = Convert.ToDecimal(kanriInfo.Koumoku1);
                sDate = Convert.ToDateTime(kanriInfo.Koumoku2);
            }
            catch
            {
            }
            try
            {
                sZeiritu = Convert.ToDecimal(kanriInfo.Koumoku3);
                eDate = Convert.ToDateTime(kanriInfo.Koumoku4);
            }
            catch
            {
            }

            if (sDate >= syoriDate)
            {
                zeiritu = sZeiritu;
            }
            else if (eDate <= syoriDate)
            {
                zeiritu = eZeiritu;
            }
            else
            {
                zeiritu = 0;
            }

            return zeiritu;
        }
        #endregion
    }
}
