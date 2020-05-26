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
    /// 得意先マスタDBモジュール
    /// </summary>
    class DBTokuisakiMaster : DBFileLayout
    {
        #region 得意先情報読み込み処理
        /// <summary>
        /// 得意先情報読み込み処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <returns></returns>
        public DataTable getTokuisakiDataTable(string tokuisakiCode, string jigyousyoCode)
        {
            return getTokuisakiDataTable(tokuisakiCode, jigyousyoCode, false);
        }

        /// <summary>
        /// 得意先情報読み込み処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <returns></returns>
        public DataTable getTokuisakiDataTable(string tokuisakiCode, string jigyousyoCode, bool flgGetDeleteData)
        {
            string selectSql = "SELECT * FROM tokuisaki_master WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(tokuisakiCode)) selectSql += "AND tokuisakiCode = '" + tokuisakiCode + "' ";
            if (!string.IsNullOrEmpty(jigyousyoCode)) selectSql += "AND jigyousyoCode = '" + jigyousyoCode + "' ";
            if (!flgGetDeleteData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 得意先情報全件取得処理
        /// <summary>
        /// 得意先情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<TokuisakiMasterFile> getAllTokuisakiInfo()
        {
            return getTokuisakiInfo(string.Empty, string.Empty);
        }
        #endregion

        #region 対象の得意先情報取得処理
        /// <summary>
        /// 対象の得意先情報取得処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <returns></returns>
        public List<TokuisakiMasterFile> getTokuisakiInfo(string tokuisakiCode, string jigyousyoCode)
        {
            return getTokuisakiInfo(tokuisakiCode, jigyousyoCode, false);
        }

        /// <summary>
        /// 対象の得意先情報取得処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <returns></returns>
        public List<TokuisakiMasterFile> getTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgGetDeleteData)
        {
            List<TokuisakiMasterFile> ret = new List<TokuisakiMasterFile>();
            TokuisakiMasterFile wkTokuisakiInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;
            DataTable tokuisakiDt = getTokuisakiDataTable(tokuisakiCode, jigyousyoCode, flgGetDeleteData);
            foreach (DataRow dRow in tokuisakiDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[TokuisakiMasterFile.dcKousinNichizi]);

                wkTokuisakiInfo = new TokuisakiMasterFile();
                // 地方コード
                wkTokuisakiInfo.ChihouCode = Convert.ToString(dRow[TokuisakiMasterFile.dcChihouCode]);
                // 地区コード
                wkTokuisakiInfo.ChikuCode = Convert.ToString(dRow[TokuisakiMasterFile.dcChikuCode]);
                // 得意先コード
                wkTokuisakiInfo.TokuisakiCode = Convert.ToString(dRow[TokuisakiMasterFile.dcTokuisakiCode]);
                // 事業所コード
                wkTokuisakiInfo.JigyousyoCode = Convert.ToString(dRow[TokuisakiMasterFile.dcJigyousyoCode]);
                // 得意先名
                wkTokuisakiInfo.TokuisakiName = Convert.ToString(dRow[TokuisakiMasterFile.dcTokuisakiName]);
                // 得意先カナ名
                wkTokuisakiInfo.TokuisakiKanaName = Convert.ToString(dRow[TokuisakiMasterFile.dcTokuisakiKanaName]);
                // 事業所名
                wkTokuisakiInfo.JigyousyoName = Convert.ToString(dRow[TokuisakiMasterFile.dcJigyousyoName]);
                // 郵便番号
                wkTokuisakiInfo.ZipCode = Convert.ToString(dRow[TokuisakiMasterFile.dcZipCode]);
                // 住所１
                wkTokuisakiInfo.Address1 = Convert.ToString(dRow[TokuisakiMasterFile.dcAddress1]);
                // 住所２
                wkTokuisakiInfo.Address2 = Convert.ToString(dRow[TokuisakiMasterFile.dcAddress2]);
                // 連絡先１
                wkTokuisakiInfo.Renrakusaki1 = Convert.ToString(dRow[TokuisakiMasterFile.dcRenrakusaki1]);
                // 連絡先２
                wkTokuisakiInfo.Renrakusaki2 = Convert.ToString(dRow[TokuisakiMasterFile.dcRenrakusaki2]);
                // 得意先担当者名
                wkTokuisakiInfo.TokuisakiTantousyaName = Convert.ToString(dRow[TokuisakiMasterFile.dcTokuisakiTantousyaName]);
                // 集計コード
                wkTokuisakiInfo.SyukeiCode = Convert.ToString(dRow[TokuisakiMasterFile.dcSyukeiCode]);
                // 締日
                wkTokuisakiInfo.Shimebi = Convert.ToString(dRow[TokuisakiMasterFile.dcShimebi]);
                // 請求先コード
                wkTokuisakiInfo.SeikyusakiCode = Convert.ToString(dRow[TokuisakiMasterFile.dcSeikyusakiCode]);
                // 請求先事業所コード
                wkTokuisakiInfo.SeikyusakiJigyousyoCode = Convert.ToString(dRow[TokuisakiMasterFile.dcSeikyusakiJigyousyoCode]);
                // 請求区分
                wkTokuisakiInfo.SeikyuKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcSeikyuKubun]);
                // 回収サイト
                wkTokuisakiInfo.KaisyuSaito = Convert.ToString(dRow[TokuisakiMasterFile.dcKaisyuSaito]);
                // 消費税区分
                wkTokuisakiInfo.SyohizeiKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcSyohizeiKubun]);
                // 消費税区分（納品書用）
                wkTokuisakiInfo.NouhinsyoSyohizeiKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcNouhinsyoSyohizeiKubun]);
                // 消費税端数区分
                wkTokuisakiInfo.SyohizeiHasuKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcSyohizeiHasuKubun]);
                // 金額端数区分
                wkTokuisakiInfo.KingakuHasuKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcKingakuHasuKubun]);
                // 請求書への繰越額出力フラグ
                wkTokuisakiInfo.FlgKurikoshiSyuturyoku = Convert.ToString(dRow[TokuisakiMasterFile.dcFlgKurikoshiSyuturyoku]);
                // 請求出力区分
                wkTokuisakiInfo.SeikyuSyuturyokuKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcSeikyuSyuturyokuKubun]);
                // 担当者コード
                wkTokuisakiInfo.TantousyaCode = Convert.ToString(dRow[TokuisakiMasterFile.dcTantousyaCode]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkTokuisakiInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkTokuisakiInfo.KanriKubun = Convert.ToString(dRow[TokuisakiMasterFile.dcKanriKubun]);

                // 得意先情報リストに追加
                ret.Add(wkTokuisakiInfo);
            }

            return ret;
        }
        #endregion
    }
}
