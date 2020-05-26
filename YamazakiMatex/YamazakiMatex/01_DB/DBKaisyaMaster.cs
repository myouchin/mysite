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
    /// 会社マスタDBモジュール
    /// </summary>
    class DBKaisyaMaster : DBCommon
    {

        #region 列情報
        /// <summary>
        /// 会社名列の物理名
        /// </summary>
        public const string dcKaisyaName = "kaisyaName";
        /// <summary>
        /// 郵便番号列の物理名
        /// </summary>
        public const string dcZipCode = "zipCode";
        /// <summary>
        /// 住所列の物理名
        /// </summary>
        public const string dcAddress = "address";
        /// <summary>
        /// 連絡先1列の物理名
        /// </summary>
        public const string dcRenrakusaki1 = "renrakusaki1";
        /// <summary>
        /// 連絡先2列の物理名
        /// </summary>
        public const string dcRenrakusaki2 = "renrakusaki2";
        /// <summary>
        /// 概要列の物理名
        /// </summary>
        public const string dcGaiyou = "gaiyou";
        /// <summary>
        /// 更新日付列の物理名
        public const string dcKousinNichizi = "kousinNichizi";
        /// </summary>
        #endregion

        #region 会社情報格納クラス
        /// <summary>
        /// 会社情報格納クラス
        /// </summary>
        public class KaisyaInfo
        {
            #region 変数宣言
            /// <summary>
            /// 会社名
            /// </summary>
            private string kaisyaName = string.Empty;
            /// <summary>
            /// 郵便番号
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所
            /// </summary>
            private string address = string.Empty;
            /// <summary>
            /// 連絡先1
            /// </summary>
            private string renrakusaki1 = string.Empty;
            /// <summary>
            /// 連絡先2
            /// </summary>
            private string renrakusaki2 = string.Empty;
            /// <summary>
            /// 概要
            /// </summary>
            private string gaiyou = string.Empty;
            /// <summary>
            /// 更新日付
            /// </summary>
            private DateTime? kousinNichizi = null;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 会社名の取得・設定
            /// </summary>
            public string KaisyaName
            {
                get { return kaisyaName; }
                set { kaisyaName = value; }
            }
            /// <summary>
            /// 郵便番号の取得・設定
            /// </summary>
            public string ZipCode
            {
                get { return zipCode; }
                set { zipCode = value; }
            }
            /// <summary>
            /// 住所の取得・設定
            /// </summary>
            public String Address
            {
                get { return address; }
                set { address = value; }
            }
            /// <summary>
            /// 連絡先1の取得・設定
            /// </summary>
            public string Renrakusaki1
            {
                get { return renrakusaki1; }
                set { renrakusaki1 = value; }
            }
            /// <summary>
            /// 連絡先2の取得・設定
            /// </summary>
            public string Renrakusaki2
            {
                get { return renrakusaki2; }
                set { renrakusaki2 = value; }
            }
            /// <summary>
            /// 概要の取得・設定
            /// </summary>
            public string Gaiyou
            {
                get { return gaiyou; }
                set { gaiyou = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public KaisyaInfo()
            {
            }
            #endregion
        }
        #endregion

        #region 会社情報読み込み処理
        /// <summary>
        /// 会社情報読み込み処理
        /// </summary>
        /// <returns></returns>
        public DataTable getKaisyaDataTable()
        {
            string selectSql = "SELECT * FROM kaisya_master WHERE 1 = 1 ";

            return executeNoneLockSelect(selectSql);
        }
        #endregion

        #region 会社情報取得処理
        /// <summary>
        /// 対象の管理情報取得処理
        /// </summary>
        /// <returns></returns>
        public List<KaisyaInfo> getKaisyaInfo(string kanriCode)
        {
            List<KaisyaInfo> ret = new List<KaisyaInfo>();
            KaisyaInfo wkKaisyaInfo;
            string wkStrKousinNichizi;
            DateTime wkDateTimeValue;
            DataTable kaisyaDt = getKaisyaDataTable();
            foreach (DataRow dRow in kaisyaDt.Rows)
            {
                wkStrKousinNichizi = Convert.ToString(dRow[dcKousinNichizi]);

                wkKaisyaInfo = new KaisyaInfo();
                // 会社名
                wkKaisyaInfo.KaisyaName = Convert.ToString(dRow[dcKaisyaName]);
                // 郵便番号
                wkKaisyaInfo.ZipCode = Convert.ToString(dRow[dcZipCode]);
                // 住所
                wkKaisyaInfo.Address = Convert.ToString(dRow[dcAddress]);
                // 連絡先1
                wkKaisyaInfo.Renrakusaki1 = Convert.ToString(dRow[dcRenrakusaki1]);
                // 連絡先2
                wkKaisyaInfo.Renrakusaki2 = Convert.ToString(dRow[dcRenrakusaki2]);
                // 概要
                wkKaisyaInfo.Gaiyou = Convert.ToString(dRow[dcGaiyou]);
                
                // 最終更新日
                if (DateTime.TryParse(wkStrKousinNichizi, out wkDateTimeValue))
                {
                    wkKaisyaInfo.KousinNichizi = wkDateTimeValue;
                }

                // 会社情報リストに追加
                ret.Add(wkKaisyaInfo);
            }

            return ret;
        }
        #endregion

    }
}
