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
    /// 担当者マスタDBモジュール
    /// </summary>
    class DBTantousyaMaster : DBFileLayout
    {
        #region 担当者情報読み込み処理
        /// <summary>
        /// 担当者情報読み込み処理
        /// </summary>
        /// <param name="tantousyaCode"></param>
        /// <returns></returns>
        public DataTable getTantousyaDataTable(string tantousyaCode, string passWord)
        {
            return getTantousyaDataTable(tantousyaCode, passWord, false);
        }

        /// <summary>
        /// 担当者情報読み込み処理
        /// </summary>
        /// <param name="tantousyaCode"></param>
        /// <returns></returns>
        public DataTable getTantousyaDataTable(string tantousyaCode, string passWord, bool flgGetDeleteData)
        {
            string selectSql = string.Empty;
            selectSql = "SELECT * FROM tantousya_master WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(tantousyaCode)) selectSql += "AND tantousyaCode ='" + tantousyaCode + "' ";
            if (!string.IsNullOrEmpty(passWord)) selectSql += "AND passWord ='" + passWord + "' ";
            if (!flgGetDeleteData) selectSql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 担当者情報全件取得処理
        /// <summary>
        /// 担当者情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public List<TantousyaMasterFile> getAllTantousyaInfo()
        {
            return getTantousyaInfo(string.Empty);
        }
        #endregion

        #region 対象の担当者情報取得処理
        /// <summary>
        /// 対象の担当者情報取得処理
        /// </summary>
        /// <param name="meisyoCode"></param>
        /// <returns></returns>
        public List<TantousyaMasterFile> getTantousyaInfo(string tantousyaCode)
        {
            return getTantousyaInfo(tantousyaCode, false);
        }

        /// <summary>
        /// 対象の担当者情報取得処理
        /// </summary>
        /// <param name="tantousyaCode"></param>
        /// <param name="flgGetDeleteData"></param>
        /// <returns></returns>
        public List<TantousyaMasterFile> getTantousyaInfo(string tantousyaCode, bool flgGetDeleteData)
        {
            List<TantousyaMasterFile> ret = new List<TantousyaMasterFile>();
            TantousyaMasterFile wkTantousyaInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;

            DataTable tantousyaDt = getTantousyaDataTable(tantousyaCode, string.Empty, flgGetDeleteData);
            foreach (DataRow dRow in tantousyaDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[TantousyaMasterFile.dcKousinNichizi]);

                wkTantousyaInfo = new TantousyaMasterFile();
                // 担当者コード
                wkTantousyaInfo.TantousyaCode = Convert.ToString(dRow[TantousyaMasterFile.dcTantousyaCode]);
                // 担当者名
                wkTantousyaInfo.TantousyaName = Convert.ToString(dRow[TantousyaMasterFile.dcTantousyaName]);
                // 権限
                wkTantousyaInfo.Kengen = Convert.ToString(dRow[TantousyaMasterFile.dcKengen]);
                // パスワード
                wkTantousyaInfo.PassWord = Convert.ToString(dRow[TantousyaMasterFile.dcPassWord]);
                // 注文番号
                wkTantousyaInfo.ChumonNo = Convert.ToInt16(dRow[TantousyaMasterFile.dcChumonNo]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkTantousyaInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkTantousyaInfo.KanriKubun = Convert.ToString(dRow[TantousyaMasterFile.dcKanriKubun]);

                // 担当者情報リストに追加
                ret.Add(wkTantousyaInfo);
            }

            return ret;
        }
        #endregion

        #region ログインユーザ情報読み込み処理
        /// <summary>
        /// ログインユーザ情報読み込み処理
        /// </summary>
        /// <param name="tantousyaCode"></param>
        /// <returns></returns>
        public List<TantousyaMasterFile> getLoginUserInfo(string tantousyaCode, string passWord)
        {
            return getLoginUserInfo(tantousyaCode, passWord, false);
        }

        /// <summary>
        /// ログインユーザ情報読み込み処理
        /// </summary>
        /// <param name="tantousyaCode"></param>
        /// <returns></returns>
        public List<TantousyaMasterFile> getLoginUserInfo(string tantousyaCode, string passWord, bool flgGetDeleteData)
        {
            List<TantousyaMasterFile> ret = new List<TantousyaMasterFile>();
            TantousyaMasterFile wkTantousyaInfo;
            if (string.IsNullOrEmpty(tantousyaCode) || string.IsNullOrEmpty(passWord)) return ret;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;

            DataTable tantousyaDt = getTantousyaDataTable(tantousyaCode, passWord, flgGetDeleteData);
            if (tantousyaDt != null && tantousyaDt.Rows.Count > 0)
            {
                DataRow dRow = tantousyaDt.Rows[0];
                wkStrKousinNichizi = Convert.ToString(dRow[TantousyaMasterFile.dcKousinNichizi]);

                wkTantousyaInfo = new TantousyaMasterFile();
                // 担当者コード
                wkTantousyaInfo.TantousyaCode = Convert.ToString(dRow[TantousyaMasterFile.dcTantousyaCode]);
                // 担当者名
                wkTantousyaInfo.TantousyaName = Convert.ToString(dRow[TantousyaMasterFile.dcTantousyaName]);
                // 権限
                wkTantousyaInfo.Kengen = Convert.ToString(dRow[TantousyaMasterFile.dcKengen]);
                // パスワード
                wkTantousyaInfo.PassWord = Convert.ToString(dRow[TantousyaMasterFile.dcPassWord]);
                // 注文番号
                wkTantousyaInfo.ChumonNo = Convert.ToInt16(dRow[TantousyaMasterFile.dcChumonNo]);
                // 更新日付
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkTantousyaInfo.KousinNichizi = wkDateTimeValue;
                }
                // 管理区分
                wkTantousyaInfo.KanriKubun = Convert.ToString(dRow[TantousyaMasterFile.dcKanriKubun]);
                ret.Add(wkTantousyaInfo);
            }

            return ret;
        }
        #endregion

        #region 対象ユーザの注文No取得処理
        /// <summary>
        /// 対象ユーザの注文No取得処理
        /// </summary>
        /// <param name="tantousyaCode"></param>
        /// <returns></returns>
        public int getUserChumonNo(string tantousyaCode)
        {
            int chumonNo = 0;

            DataTable tantousyaDt = getTantousyaDataTable(tantousyaCode, string.Empty, false);
            if (tantousyaDt != null && tantousyaDt.Rows.Count > 0)
            {
                int.TryParse(Convert.ToString(tantousyaDt.Rows[0][TantousyaMasterFile.dcChumonNo]), out chumonNo);
            }

            return chumonNo;
        }
        #endregion
    }
}
