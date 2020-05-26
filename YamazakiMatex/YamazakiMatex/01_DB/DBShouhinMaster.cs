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
    /// 商品マスタDBモジュール
    /// </summary>
    class DBShouhinMaster : DBFileLayout
    {
        #region 商品情報読み込み処理
        /// <summary>
        /// 商品情報読み込み処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <param name="topClassification"></param>
        /// <param name="btmClassification"></param>
        /// <param name="shouhinCode"></param>
        /// <returns></returns>
        public DataTable getShouhinDataTable(string shiresakiCode, string topClassification, string btmClassification, string shouhinCode, bool flgGetDeleteData)
        {
            string selectSql = string.Empty;
            selectSql = "SELECT * FROM shouhin_master WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(shiresakiCode)) selectSql += "AND shireCode = '" + shiresakiCode + "' ";
            if (!string.IsNullOrEmpty(topClassification)) selectSql += "AND topClassification = '" + topClassification + "' ";
            if (!string.IsNullOrEmpty(btmClassification)) selectSql += "AND btmClassification = '" + btmClassification + "' ";
            if (!string.IsNullOrEmpty(shouhinCode)) selectSql += "AND shouhinCode = '" + shouhinCode + "' ";
            if(!flgGetDeleteData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";
            selectSql += "ORDER BY shireCode, topClassification, btmClassification, btmClassification ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 商品情報全件取得処理
        /// <summary>
        /// 商品情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<ShouhinMasterFile> getAllShouhinInfo()
        {
            return getShouhinInfo(string.Empty, string.Empty, string.Empty, string.Empty, false);
        }
        #endregion

        #region 対象の商品情報取得処理
        /// <summary>
        /// 対象の商品情報取得処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <param name="topClassification"></param>
        /// <param name="btmClassification"></param>
        /// <param name="shouhinCode"></param>
        /// <returns></returns>
        public List<ShouhinMasterFile> getShouhinInfo(string shiresakiCode, string topClassification, string btmClassification, string shouhinCode, bool flgGetDeleteData)
        {
            List<ShouhinMasterFile> ret = new List<ShouhinMasterFile>();
            ShouhinMasterFile wkShouhinInfo;
            string wkStrSuryo;
            string wkStrTanka;
            string wkStrSaisyuSyukobi;
            string wkStrKousinNichizi;
            decimal wkDecimalValue;
            DateTime wkDateTimeValue;

            // 商品データの読み込み
            DataTable shouhinDt = getShouhinDataTable(shiresakiCode, topClassification, btmClassification, shouhinCode, flgGetDeleteData);
            foreach (DataRow dRow in shouhinDt.Rows)
            {
                wkStrSuryo = Convert.ToString(dRow[ShouhinMasterFile.dcZaikoSuryo]);
                wkStrTanka = Convert.ToString(dRow[ShouhinMasterFile.dcTanka]);
                wkStrSaisyuSyukobi = Convert.ToString(dRow[ShouhinMasterFile.dcSaisyuSyukobi]);
                wkStrKousinNichizi = Convert.ToString(dRow[ShouhinMasterFile.dcKousinNichizi]);

                wkShouhinInfo = new ShouhinMasterFile();
                // 仕入先コード
                wkShouhinInfo.ShireCode = Convert.ToString(dRow[ShouhinMasterFile.dcShireCode]);
                // 大分類コード
                wkShouhinInfo.TopClassification = Convert.ToString(dRow[ShouhinMasterFile.dcTopClassification]);
                // 小分類コード
                wkShouhinInfo.BtmClassification = Convert.ToString(dRow[ShouhinMasterFile.dcBtmClassification]);
                // 商品コード
                wkShouhinInfo.ShouhinCode = Convert.ToString(dRow[ShouhinMasterFile.dcShouhinCode]);
                // 商品名
                wkShouhinInfo.ShouhinName = Convert.ToString(dRow[ShouhinMasterFile.dcShouhinName]);
                // 在庫数量
                if (decimal.TryParse(wkStrSuryo, out wkDecimalValue))
                {
                    wkShouhinInfo.ZaikoSuryo = wkDecimalValue;
                }
                // 単位区分
                wkShouhinInfo.TaniKubun = Convert.ToString(dRow[ShouhinMasterFile.dcTaniKubun]);
                // 単価
                if (decimal.TryParse(wkStrTanka, out wkDecimalValue))
                {
                    wkShouhinInfo.Tanka = wkDecimalValue;
                }
                // 最終出庫日
                if (DateTime.TryParse(wkStrSaisyuSyukobi, out wkDateTimeValue))
                {
                    wkShouhinInfo.SaisyuSyukobi = wkDateTimeValue;
                }
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkShouhinInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkShouhinInfo.KanriKubun = Convert.ToString(dRow[ShouhinMasterFile.dcKanriKubun]);

                // 商品情報リストに追加
                ret.Add(wkShouhinInfo);
            }

            return ret;
        }
        #endregion

        #region 商品情報存在チェック処理
        /// <summary>
        /// 商品情報存在チェック処理
        /// </summary>
        /// <param name="shouhinCode"></param>
        /// <returns></returns>
        public bool checkExistShouhinInfo(string shouhinCode)
        {
            string selectSql = string.Empty;
            selectSql = "SELECT * FROM shouhin_master WHERE 1 = 1";
            selectSql += " AND shouhinCode = '" + shouhinCode + "'";
            selectSql += " ORDER BY shireCode, topClassification, btmClassification, btmClassification";

            DataTable shouhinDt = executeNoneLockSelect(selectSql);

            if (shouhinDt == null || shouhinDt.Rows.Count == 0)
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
