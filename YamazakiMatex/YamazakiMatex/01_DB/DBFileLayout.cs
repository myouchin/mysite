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
    /// DBファイルレイアウトクラス
    /// </summary>
    class DBFileLayout : DBCommon
    {
        #region ファイルレイアウトクラス

        #region 会社マスタファイルレイアウト
        /// <summary>
        /// 会社マスタファイルレイアウト
        /// </summary>
        public class KaisyaMasterFile
        {
            #region 列情報
            /// <summary>
            /// 会社名の物理名
            /// </summary>
            public const string dcKaisyaName = "kaisyaName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所の物理名
            /// </summary>
            public const string dcAddress = "address";
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            public const string dcRenrakusaki1 = "renrakusaki1";
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            public const string dcRenrakusaki2 = "renrakusaki2";
            /// <summary>
            /// 概要の物理名
            /// </summary>
            public const string dcGaiyou = "gaiyou";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 会社名の物理名
            /// </summary>
            private string kaisyaName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所の物理名
            /// </summary>
            private string address = string.Empty;
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            private string renrakusaki1 = string.Empty;
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            private string renrakusaki2 = string.Empty;
            /// <summary>
            /// 概要の物理名
            /// </summary>
            private string gaiyou = string.Empty;
            /// <summary>
            /// 更新日付の物理名
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
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            /// <summary>
            /// 連絡先１の取得・設定
            /// </summary>
            public string Renrakusaki1
            {
                get { return renrakusaki1; }
                set { renrakusaki1 = value; }
            }
            /// <summary>
            /// 連絡先２の取得・設定
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
            public KaisyaMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 管理マスタファイルレイアウト
        /// <summary>
        /// 管理マスタファイルレイアウト
        /// </summary>
        public class KanriMasterFile
        {
            #region 列情報
            /// <summary>
            /// 管理コードの物理名
            /// </summary>
            public const string dcKanriCode = "kanriCode";
            /// <summary>
            /// 管理名称の物理名
            /// </summary>
            public const string dcKanriName = "kanriName";
            /// <summary>
            /// 項目１の物理名
            /// </summary>
            public const string dcKoumoku1 = "koumoku1";
            /// <summary>
            /// 項目１名称の物理名
            /// </summary>
            public const string dcKoumoku1Name = "koumoku1Name";
            /// <summary>
            /// 項目２の物理名
            /// </summary>
            public const string dcKoumoku2 = "koumoku2";
            /// <summary>
            /// 項目２名称の物理名
            /// </summary>
            public const string dcKoumoku2Name = "koumoku2Name";
            /// <summary>
            /// 項目３の物理名
            /// </summary>
            public const string dcKoumoku3 = "koumoku3";
            /// <summary>
            /// 項目３名称の物理名
            /// </summary>
            public const string dcKoumoku3Name = "koumoku3Name";
            /// <summary>
            /// 項目４の物理名
            /// </summary>
            public const string dcKoumoku4 = "koumoku4";
            /// <summary>
            /// 項目４名称の物理名
            /// </summary>
            public const string dcKoumoku4Name = "koumoku4Name";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 管理コードの物理名
            /// </summary>
            private string kanriCode = string.Empty;
            /// <summary>
            /// 管理名称の物理名
            /// </summary>
            private string kanriName = string.Empty;
            /// <summary>
            /// 項目１の物理名
            /// </summary>
            private int koumoku1 = 0;
            /// <summary>
            /// 項目１名称の物理名
            /// </summary>
            private string koumoku1Name = string.Empty;
            /// <summary>
            /// 項目２の物理名
            /// </summary>
            private string koumoku2 = string.Empty;
            /// <summary>
            /// 項目２名称の物理名
            /// </summary>
            private string koumoku2Name = string.Empty;
            /// <summary>
            /// 項目３の物理名
            /// </summary>
            private int koumoku3 = 0;
            /// <summary>
            /// 項目３名称の物理名
            /// </summary>
            private string koumoku3Name = string.Empty;
            /// <summary>
            /// 項目４の物理名
            /// </summary>
            private string koumoku4 = string.Empty;
            /// <summary>
            /// 項目４名称の物理名
            /// </summary>
            private string koumoku4Name = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 管理コードの取得・設定
            /// </summary>
            public string KanriCode
            {
                get { return kanriCode; }
                set { kanriCode = value; }
            }
            /// <summary>
            /// 管理名称の取得・設定
            /// </summary>
            public string KanriName
            {
                get { return kanriName; }
                set { kanriName = value; }
            }
            /// <summary>
            /// 項目１の取得・設定
            /// </summary>
            public int Koumoku1
            {
                get { return koumoku1; }
                set { koumoku1 = value; }
            }
            /// <summary>
            /// 項目１名称の取得・設定
            /// </summary>
            public string Koumoku1Name
            {
                get { return koumoku1Name; }
                set { koumoku1Name = value; }
            }
            /// <summary>
            /// 項目２の取得・設定
            /// </summary>
            public string Koumoku2
            {
                get { return koumoku2; }
                set { koumoku2 = value; }
            }
            /// <summary>
            /// 項目２名称の取得・設定
            /// </summary>
            public string Koumoku2Name
            {
                get { return koumoku2Name; }
                set { koumoku2Name = value; }
            }
            /// <summary>
            /// 項目３の取得・設定
            /// </summary>
            public int Koumoku3
            {
                get { return koumoku3; }
                set { koumoku3 = value; }
            }
            /// <summary>
            /// 項目３名称の取得・設定
            /// </summary>
            public string Koumoku3Name
            {
                get { return koumoku3Name; }
                set { koumoku3Name = value; }
            }
            /// <summary>
            /// 項目４の取得・設定
            /// </summary>
            public string Koumoku4
            {
                get { return koumoku4; }
                set { koumoku4 = value; }
            }
            /// <summary>
            /// 項目４名称の取得・設定
            /// </summary>
            public string Koumoku4Name
            {
                get { return koumoku4Name; }
                set { koumoku4Name = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public KanriMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 件名マスタファイルレイアウト
        /// <summary>
        /// 件名マスタファイルレイアウト
        /// </summary>
        public class KenmeiMasterFile
        {
            #region 列情報
            /// <summary>
            /// 件名Noの物理名
            /// </summary>
            public const string dcKenmeiNo = "kenmeiNo";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 納入先名の物理名
            /// </summary>
            public const string dcNonyusakiName = "nonyusakiName";
            /// <summary>
            /// 部署名の物理名
            /// </summary>
            public const string dcBusyoName = "busyoName";
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            public const string dcRenrakusaki1 = "renrakusaki1";
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            public const string dcRenrakusaki2 = "renrakusaki2";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddress1 = "address1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddress2 = "address2";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 件名Noの物理名
            /// </summary>
            private string kenmeiNo = string.Empty;
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 納入先名の物理名
            /// </summary>
            private string nonyusakiName = string.Empty;
            /// <summary>
            /// 部署名の物理名
            /// </summary>
            private string busyoName = string.Empty;
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            private string renrakusaki1 = string.Empty;
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            private string renrakusaki2 = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string address1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string address2 = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 件名Noの取得・設定
            /// </summary>
            public string KenmeiNo
            {
                get { return kenmeiNo; }
                set { kenmeiNo = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 納入先名の取得・設定
            /// </summary>
            public string NonyusakiName
            {
                get { return nonyusakiName; }
                set { nonyusakiName = value; }
            }
            /// <summary>
            /// 部署名の取得・設定
            /// </summary>
            public string BusyoName
            {
                get { return busyoName; }
                set { busyoName = value; }
            }
            /// <summary>
            /// 連絡先１の取得・設定
            /// </summary>
            public string Renrakusaki1
            {
                get { return renrakusaki1; }
                set { renrakusaki1 = value; }
            }
            /// <summary>
            /// 連絡先２の取得・設定
            /// </summary>
            public string Renrakusaki2
            {
                get { return renrakusaki2; }
                set { renrakusaki2 = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Address1
            {
                get { return address1; }
                set { address1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public KenmeiMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 名称マスタファイルレイアウト
        /// <summary>
        /// 名称マスタファイルレイアウト
        /// </summary>
        public class MeisyoMasterFile
        {
            #region 列情報
            /// <summary>
            /// 名称コードの物理名
            /// </summary>
            public const string dcMeisyoCode = "meisyoCode";
            /// <summary>
            /// 名称の物理名
            /// </summary>
            public const string dcMeisyoName = "meisyoName";
            /// <summary>
            /// 区分の物理名
            /// </summary>
            public const string dcKubun = "kubun";
            /// <summary>
            /// 区分名の物理名
            /// </summary>
            public const string dcKubunName = "kubunName";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 名称コードの物理名
            /// </summary>
            private string meisyoCode = string.Empty;
            /// <summary>
            /// 名称の物理名
            /// </summary>
            private string meisyoName = string.Empty;
            /// <summary>
            /// 区分の物理名
            /// </summary>
            private string kubun = string.Empty;
            /// <summary>
            /// 区分名の物理名
            /// </summary>
            private string kubunName = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 名称コードの取得・設定
            /// </summary>
            public string MeisyoCode
            {
                get { return meisyoCode; }
                set { meisyoCode = value; }
            }
            /// <summary>
            /// 名称の取得・設定
            /// </summary>
            public string MeisyoName
            {
                get { return meisyoName; }
                set { meisyoName = value; }
            }
            /// <summary>
            /// 区分の取得・設定
            /// </summary>
            public string Kubun
            {
                get { return kubun; }
                set { kubun = value; }
            }
            /// <summary>
            /// 区分名の取得・設定
            /// </summary>
            public string KubunName
            {
                get { return kubunName; }
                set { kubunName = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public MeisyoMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 仕入先マスタファイルレイアウト
        /// <summary>
        /// 仕入先マスタファイルレイアウト
        /// </summary>
        public class ShiresakiMasterFile
        {
            #region 列情報
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            public const string dcShiresakiCode = "shiresakiCode";
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            public const string dcShiresakiName = "shiresakiName";
            /// <summary>
            /// 仕入先カナ名の物理名
            /// </summary>
            public const string dcShiresakiKanaName = "shiresakiKanaName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddress1 = "address1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddress2 = "address2";
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            public const string dcRenrakusaki1 = "renrakusaki1";
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            public const string dcRenrakusaki2 = "renrakusaki2";
            /// <summary>
            /// 締日の物理名
            /// </summary>
            public const string dcShimebi = "shimebi";
            /// <summary>
            /// 支払サイトの物理名
            /// </summary>
            public const string dcShiharaiSaito = "shiharaiSaito";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            private string shiresakiCode = string.Empty;
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            private string shiresakiName = string.Empty;
            /// <summary>
            /// 仕入先カナ名の物理名
            /// </summary>
            private string shiresakiKanaName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string address1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string address2 = string.Empty;
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            private string renrakusaki1 = string.Empty;
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            private string renrakusaki2 = string.Empty;
            /// <summary>
            /// 締日の物理名
            /// </summary>
            private string shimebi = string.Empty;
            /// <summary>
            /// 支払サイトの物理名
            /// </summary>
            private string shiharaiSaito = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 仕入先コードの取得・設定
            /// </summary>
            public string ShiresakiCode
            {
                get { return shiresakiCode; }
                set { shiresakiCode = value; }
            }
            /// <summary>
            /// 仕入先名の取得・設定
            /// </summary>
            public string ShiresakiName
            {
                get { return shiresakiName; }
                set { shiresakiName = value; }
            }
            /// <summary>
            /// 仕入先カナ名の取得・設定
            /// </summary>
            public string ShiresakiKanaName
            {
                get { return shiresakiKanaName; }
                set { shiresakiKanaName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Address1
            {
                get { return address1; }
                set { address1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }
            /// <summary>
            /// 連絡先１の取得・設定
            /// </summary>
            public string Renrakusaki1
            {
                get { return renrakusaki1; }
                set { renrakusaki1 = value; }
            }
            /// <summary>
            /// 連絡先２の取得・設定
            /// </summary>
            public string Renrakusaki2
            {
                get { return renrakusaki2; }
                set { renrakusaki2 = value; }
            }
            /// <summary>
            /// 締日の取得・設定
            /// </summary>
            public string Shimebi
            {
                get { return shimebi; }
                set { shimebi = value; }
            }
            /// <summary>
            /// 支払サイトの取得・設定
            /// </summary>
            public string ShiharaiSaito
            {
                get { return shiharaiSaito; }
                set { shiharaiSaito = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShiresakiMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 商品マスタファイルレイアウト
        /// <summary>
        /// 商品マスタファイルレイアウト
        /// </summary>
        public class ShouhinMasterFile
        {
            #region 列情報
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            public const string dcShireCode = "shireCode";
            /// <summary>
            /// 大分類コードの物理名
            /// </summary>
            public const string dcTopClassification = "topClassification";
            /// <summary>
            /// 小分類コードの物理名
            /// </summary>
            public const string dcBtmClassification = "btmClassification";
            /// <summary>
            /// 商品コードの物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 商品名の物理名
            /// </summary>
            public const string dcShouhinName = "shouhinName";
            /// <summary>
            /// 在庫数量の物理名
            /// </summary>
            public const string dcZaikoSuryo = "zaikoSuryo";
            /// <summary>
            /// 単位区分の物理名
            /// </summary>
            public const string dcTaniKubun = "taniKubun";
            /// <summary>
            /// 単価の物理名
            /// </summary>
            public const string dcTanka = "tanka";
            /// <summary>
            /// 最終出庫日の物理名
            /// </summary>
            public const string dcSaisyuSyukobi = "saisyuSyukobi";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            private string shireCode = string.Empty;
            /// <summary>
            /// 大分類コードの物理名
            /// </summary>
            private string topClassification = string.Empty;
            /// <summary>
            /// 小分類コードの物理名
            /// </summary>
            private string btmClassification = string.Empty;
            /// <summary>
            /// 商品コードの物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 商品名の物理名
            /// </summary>
            private string shouhinName = string.Empty;
            /// <summary>
            /// 在庫数量の物理名
            /// </summary>
            private decimal? zaikoSuryo = null;
            /// <summary>
            /// 単位区分の物理名
            /// </summary>
            private string taniKubun = string.Empty;
            /// <summary>
            /// 単価の物理名
            /// </summary>
            private decimal? tanka = null;
            /// <summary>
            /// 最終出庫日の物理名
            /// </summary>
            private DateTime? saisyuSyukobi = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 仕入先コードの取得・設定
            /// </summary>
            public string ShireCode
            {
                get { return shireCode; }
                set { shireCode = value; }
            }
            /// <summary>
            /// 大分類コードの取得・設定
            /// </summary>
            public string TopClassification
            {
                get { return topClassification; }
                set { topClassification = value; }
            }
            /// <summary>
            /// 小分類コードの取得・設定
            /// </summary>
            public string BtmClassification
            {
                get { return btmClassification; }
                set { btmClassification = value; }
            }
            /// <summary>
            /// 商品コードの取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 商品名の取得・設定
            /// </summary>
            public string ShouhinName
            {
                get { return shouhinName; }
                set { shouhinName = value; }
            }
            /// <summary>
            /// 在庫数量の取得・設定
            /// </summary>
            public decimal? ZaikoSuryo
            {
                get { return zaikoSuryo; }
                set { zaikoSuryo = value; }
            }
            /// <summary>
            /// 単位区分の取得・設定
            /// </summary>
            public string TaniKubun
            {
                get { return taniKubun; }
                set { taniKubun = value; }
            }
            /// <summary>
            /// 単価の取得・設定
            /// </summary>
            public decimal? Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 最終出庫日の取得・設定
            /// </summary>
            public DateTime? SaisyuSyukobi
            {
                get { return saisyuSyukobi; }
                set { saisyuSyukobi = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShouhinMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 担当者マスタファイルレイアウト
        /// <summary>
        /// 担当者マスタファイルレイアウト
        /// </summary>
        public class TantousyaMasterFile
        {
            #region 列情報
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 権限の物理名
            /// </summary>
            public const string dcKengen = "kengen";
            /// <summary>
            /// パスワードの物理名
            /// </summary>
            public const string dcPassWord = "passWord";
            /// <summary>
            /// 注文番号の物理名
            /// </summary>
            public const string dcChumonNo = "chumonNo";
            /// <summary>
            /// メールアドレスの物理名
            /// </summary>
            public const string dcMail = "mail";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 権限の物理名
            /// </summary>
            private string kengen = string.Empty;
            /// <summary>
            /// パスワードの物理名
            /// </summary>
            private string passWord = string.Empty;
            /// <summary>
            /// 注文番号の物理名
            /// </summary>
            private int? chumonNo = 0;
            /// <summary>
            /// メールアドレスの物理名
            /// </summary>
            private string mail = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 権限の取得・設定
            /// </summary>
            public string Kengen
            {
                get { return kengen; }
                set { kengen = value; }
            }
            /// <summary>
            /// パスワードの取得・設定
            /// </summary>
            public string PassWord
            {
                get { return passWord; }
                set { passWord = value; }
            }
            /// <summary>
            /// 注文番号の取得・設定
            /// </summary>
            public int? ChumonNo
            {
                get { return chumonNo; }
                set { chumonNo = value; }
            }
            /// <summary>
            /// メールアドレスの取得・設定
            /// </summary>
            public string Mail
            {
                get { return mail; }
                set { mail = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public TantousyaMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 得意先マスタファイルレイアウト
        /// <summary>
        /// 得意先マスタファイルレイアウト
        /// </summary>
        public class TokuisakiMasterFile
        {
            #region 列情報
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先カナ名の物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddress1 = "address1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddress2 = "address2";
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            public const string dcRenrakusaki1 = "renrakusaki1";
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            public const string dcRenrakusaki2 = "renrakusaki2";
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            public const string dcTokuisakiTantousyaName = "tokuisakiTantousyaName";
            /// <summary>
            /// 集計コードの物理名
            /// </summary>
            public const string dcSyukeiCode = "syukeiCode";
            /// <summary>
            /// 締日の物理名
            /// </summary>
            public const string dcShimebi = "shimebi";
            /// <summary>
            /// 請求先コードの物理名
            /// </summary>
            public const string dcSeikyusakiCode = "seikyusakiCode";
            /// <summary>
            /// 請求先事業所コードの物理名
            /// </summary>
            public const string dcSeikyusakiJigyousyoCode = "seikyusakiJigyousyoCode";
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            public const string dcSeikyuKubun = "seikyuKubun";
            /// <summary>
            /// 回収サイトの物理名
            /// </summary>
            public const string dcKaisyuSaito = "kaisyuSaito";
            /// <summary>
            /// 消費税区分の物理名
            /// </summary>
            public const string dcSyohizeiKubun = "syohizeiKubun";
            /// <summary>
            /// 消費税区分（納品書用）の物理名
            /// </summary>
            public const string dcNouhinsyoSyohizeiKubun = "nouhinsyoSyohizeiKubun";
            /// <summary>
            /// 消費税端数区分の物理名
            /// </summary>
            public const string dcSyohizeiHasuKubun = "syohizeiHasuKubun";
            /// <summary>
            /// 金額端数区分の物理名
            /// </summary>
            public const string dcKingakuHasuKubun = "kingakuHasuKubun";
            /// <summary>
            /// 請求出力区分の物理名
            /// </summary>
            public const string dcSeikyuSyuturyokuKubun = "seikyuSyuturyokuKubun";
            /// <summary>
            /// 請求書への繰越額出力フラグの物理名
            /// </summary>
            public const string dcFlgKurikoshiSyuturyoku = "flgKurikoshiSyuturyoku";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先カナ名の物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string address1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string address2 = string.Empty;
            /// <summary>
            /// 連絡先１の物理名
            /// </summary>
            private string renrakusaki1 = string.Empty;
            /// <summary>
            /// 連絡先２の物理名
            /// </summary>
            private string renrakusaki2 = string.Empty;
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            private string tokuisakiTantousyaName = string.Empty;
            /// <summary>
            /// 集計コードの物理名
            /// </summary>
            private string syukeiCode = string.Empty;
            /// <summary>
            /// 締日の物理名
            /// </summary>
            private string shimebi = string.Empty;
            /// <summary>
            /// 請求先コードの物理名
            /// </summary>
            private string seikyusakiCode = string.Empty;
            /// <summary>
            /// 請求先事業所コードの物理名
            /// </summary>
            private string seikyusakiJigyousyoCode = string.Empty;
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            private string seikyuKubun = string.Empty;
            /// <summary>
            /// 回収サイトの物理名
            /// </summary>
            private string kaisyuSaito = string.Empty;
            /// <summary>
            /// 消費税区分の物理名
            /// </summary>
            private string syohizeiKubun = string.Empty;
            /// <summary>
            /// 消費税区分（納品書用）の物理名
            /// </summary>
            private string nouhinsyoSyohizeiKubun = string.Empty;
            /// <summary>
            /// 消費税端数区分の物理名
            /// </summary>
            private string syohizeiHasuKubun = string.Empty;
            /// <summary>
            /// 金額端数区分の物理名
            /// </summary>
            private string kingakuHasuKubun = string.Empty;
            /// <summary>
            /// 請求出力区分の物理名
            /// </summary>
            private string seikyuSyuturyokuKubun = string.Empty;
            /// <summary>
            /// 請求書への繰越額出力フラグの物理名
            /// </summary>
            private string flgKurikoshiSyuturyoku = string.Empty;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先カナ名の取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Address1
            {
                get { return address1; }
                set { address1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }
            /// <summary>
            /// 連絡先１の取得・設定
            /// </summary>
            public string Renrakusaki1
            {
                get { return renrakusaki1; }
                set { renrakusaki1 = value; }
            }
            /// <summary>
            /// 連絡先２の取得・設定
            /// </summary>
            public string Renrakusaki2
            {
                get { return renrakusaki2; }
                set { renrakusaki2 = value; }
            }
            /// <summary>
            /// 得意先担当者名の取得・設定
            /// </summary>
            public string TokuisakiTantousyaName
            {
                get { return tokuisakiTantousyaName; }
                set { tokuisakiTantousyaName = value; }
            }
            /// <summary>
            /// 集計コードの取得・設定
            /// </summary>
            public string SyukeiCode
            {
                get { return syukeiCode; }
                set { syukeiCode = value; }
            }
            /// <summary>
            /// 締日の取得・設定
            /// </summary>
            public string Shimebi
            {
                get { return shimebi; }
                set { shimebi = value; }
            }
            /// <summary>
            /// 請求先コードの取得・設定
            /// </summary>
            public string SeikyusakiCode
            {
                get { return seikyusakiCode; }
                set { seikyusakiCode = value; }
            }
            /// <summary>
            /// 請求先事業所コードの取得・設定
            /// </summary>
            public string SeikyusakiJigyousyoCode
            {
                get { return seikyusakiJigyousyoCode; }
                set { seikyusakiJigyousyoCode = value; }
            }
            /// <summary>
            /// 請求区分の取得・設定
            /// </summary>
            public string SeikyuKubun
            {
                get { return seikyuKubun; }
                set { seikyuKubun = value; }
            }
            /// <summary>
            /// 回収サイトの取得・設定
            /// </summary>
            public string KaisyuSaito
            {
                get { return kaisyuSaito; }
                set { kaisyuSaito = value; }
            }
            /// <summary>
            /// 消費税区分の取得・設定
            /// </summary>
            public string SyohizeiKubun
            {
                get { return syohizeiKubun; }
                set { syohizeiKubun = value; }
            }
            /// <summary>
            /// 消費税区分（納品書用）の取得・設定
            /// </summary>
            public string NouhinsyoSyohizeiKubun
            {
                get { return nouhinsyoSyohizeiKubun; }
                set { nouhinsyoSyohizeiKubun = value; }
            }
            /// <summary>
            /// 消費税端数区分の取得・設定
            /// </summary>
            public string SyohizeiHasuKubun
            {
                get { return syohizeiHasuKubun; }
                set { syohizeiHasuKubun = value; }
            }
            /// <summary>
            /// 金額端数区分の取得・設定
            /// </summary>
            public string KingakuHasuKubun
            {
                get { return kingakuHasuKubun; }
                set { kingakuHasuKubun = value; }
            }
            /// <summary>
            /// 請求出力区分の取得・設定
            /// </summary>
            public string SeikyuSyuturyokuKubun
            {
                get { return seikyuSyuturyokuKubun; }
                set { seikyuSyuturyokuKubun = value; }
            }
            /// <summary>
            /// 請求書への繰越額出力フラグの取得・設定
            /// </summary>
            public string FlgKurikoshiSyuturyoku
            {
                get { return flgKurikoshiSyuturyoku; }
                set { flgKurikoshiSyuturyoku = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public TokuisakiMasterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 発注ヘッダファイルレイアウト
        /// <summary>
        /// 発注ヘッダファイルレイアウト
        /// </summary>
        public class HachuHeaderFile
        {
            #region 列情報
            /// <summary>
            /// 発注NOの物理名
            /// </summary>
            public const string dcHachuNo = "hachuNo";
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            public const string dcDenpyoHizuke = "denpyoHizuke";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 件名NOの物理名
            /// </summary>
            public const string dcKenmeiNo = "kenmeiNo";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            public const string dcShiresakiCode = "shiresakiCode";
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            public const string dcShiresakiName = "shiresakiName";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 発注NOの物理名
            /// </summary>
            private string hachuNo = string.Empty;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            private DateTime? denpyoHizuke = null;
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 件名NOの物理名
            /// </summary>
            private string kenmeiNo = string.Empty;
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            private string shiresakiCode = string.Empty;
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            private string shiresakiName = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 発注NOの取得・設定
            /// </summary>
            public string HachuNo
            {
                get { return hachuNo; }
                set { hachuNo = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 伝票日付の取得・設定
            /// </summary>
            public DateTime? DenpyoHizuke
            {
                get { return denpyoHizuke; }
                set { denpyoHizuke = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 件名NOの取得・設定
            /// </summary>
            public string KenmeiNo
            {
                get { return kenmeiNo; }
                set { kenmeiNo = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 仕入先コードの取得・設定
            /// </summary>
            public string ShiresakiCode
            {
                get { return shiresakiCode; }
                set { shiresakiCode = value; }
            }
            /// <summary>
            /// 仕入先名の取得・設定
            /// </summary>
            public string ShiresakiName
            {
                get { return shiresakiName; }
                set { shiresakiName = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public HachuHeaderFile()
            {
            }
            #endregion
        }
        #endregion

        #region 発注ボディファイルレイアウト
        /// <summary>
        /// 発注ボディファイルレイアウト
        /// </summary>
        public class HachuBodyFile
        {
            #region 列情報
            /// <summary>
            /// 発注NOの物理名
            /// </summary>
            public const string dcHachuNo = "hachuNo";
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            public const string dcRowNo = "rowNo";
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            public const string dcDaiBunruiCode = "daiBunruiCode";
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            public const string dcSyoBunruiCode = "syoBunruiCode";
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            public const string dcShouhinName1 = "shouhinName1";
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            public const string dcShouhinName2 = "shouhinName2";
            /// <summary>
            /// 数量の物理名
            /// </summary>
            public const string dcSuryo = "suryo";
            /// <summary>
            /// 単位の物理名
            /// </summary>
            public const string dcTani = "tani";
            /// <summary>
            /// 単価の物理名
            /// </summary>
            public const string dcTanka = "tanka";
            /// <summary>
            /// 金額の物理名
            /// </summary>
            public const string dcKingaku = "kingaku";
            /// <summary>
            /// 備考の物理名
            /// </summary>
            public const string dcBikou = "bikou";
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            public const string dcJuchuRowNo = "juchuRowNo";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 発注NOの物理名
            /// </summary>
            private string hachuNo = string.Empty;
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            private int rowNo = 0;
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            private string daiBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            private string syoBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            private string shouhinName1 = string.Empty;
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            private string shouhinName2 = string.Empty;
            /// <summary>
            /// 数量の物理名
            /// </summary>
            private decimal? suryo = null;
            /// <summary>
            /// 単位の物理名
            /// </summary>
            private string tani = string.Empty;
            /// <summary>
            /// 単価の物理名
            /// </summary>
            private decimal? tanka = null;
            /// <summary>
            /// 金額の物理名
            /// </summary>
            private decimal? kingaku = null;
            /// <summary>
            /// 備考の物理名
            /// </summary>
            private string bikou = string.Empty;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            private int juchuRowNo = 0;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 発注NOの取得・設定
            /// </summary>
            public string HachuNo
            {
                get { return hachuNo; }
                set { hachuNo = value; }
            }
            /// <summary>
            /// 行番号の取得・設定
            /// </summary>
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            /// <summary>
            /// 商品コード(大分類コード)の取得・設定
            /// </summary>
            public string DaiBunruiCode
            {
                get { return daiBunruiCode; }
                set { daiBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(小類コード)の取得・設定
            /// </summary>
            public string SyoBunruiCode
            {
                get { return syoBunruiCode; }
                set { syoBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(連番)の取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 商品名１の取得・設定
            /// </summary>
            public string ShouhinName1
            {
                get { return shouhinName1; }
                set { shouhinName1 = value; }
            }
            /// <summary>
            /// 商品名２の取得・設定
            /// </summary>
            public string ShouhinName2
            {
                get { return shouhinName2; }
                set { shouhinName2 = value; }
            }
            /// <summary>
            /// 数量の取得・設定
            /// </summary>
            public decimal? Suryo
            {
                get { return suryo; }
                set { suryo = value; }
            }
            /// <summary>
            /// 単位の取得・設定
            /// </summary>
            public string Tani
            {
                get { return tani; }
                set { tani = value; }
            }
            /// <summary>
            /// 単価の取得・設定
            /// </summary>
            public decimal? Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 金額の取得・設定
            /// </summary>
            public decimal? Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }
            /// <summary>
            /// 備考の取得・設定
            /// </summary>
            public string Bikou
            {
                get { return bikou; }
                set { bikou = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 受注行番号の取得・設定
            /// </summary>
            public int JuchuRowNo
            {
                get { return juchuRowNo; }
                set { juchuRowNo = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public HachuBodyFile()
            {
            }
            #endregion
        }
        #endregion

        #region 発注フッタファイルレイアウト
        /// <summary>
        /// 発注フッタファイルレイアウト
        /// </summary>
        public class HachuFooterFile
        {
            #region 列情報
            /// <summary>
            /// 発注NOの物理名
            /// </summary>
            public const string dcHachuNo = "hachuNo";
            /// <summary>
            /// 発注金額の物理名
            /// </summary>
            public const string dcHachuKingaku = "hachuKingaku";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 発注NOの物理名
            /// </summary>
            private string hachuNo = string.Empty;
            /// <summary>
            /// 発注金額の物理名
            /// </summary>
            private decimal? hachuKingaku = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 発注NOの取得・設定
            /// </summary>
            public string HachuNo
            {
                get { return hachuNo; }
                set { hachuNo = value; }
            }
            /// <summary>
            /// 発注金額の取得・設定
            /// </summary>
            public decimal? HachuKingaku
            {
                get { return hachuKingaku; }
                set { hachuKingaku = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public HachuFooterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 受注ヘッダファイルレイアウト
        /// <summary>
        /// 受注ヘッダファイルレイアウト
        /// </summary>
        public class JuchuHeaderFile
        {
            #region 列情報
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            public const string dcDenpyoHizuke = "denpyoHizuke";
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 発行者コードの物理名
            /// </summary>
            public const string dcHakousyaCode = "hakousyaCode";
            /// <summary>
            /// 発行者名の物理名
            /// </summary>
            public const string dcHakousyaName = "hakousyaName";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            public const string dcTokuisakiTantousayName = "tokuisakiTantousayName";
            /// <summary>
            /// 材料・工事区分の物理名
            /// </summary>
            public const string dcZairyoKoujiKubun = "zairyoKoujiKubun";
            /// <summary>
            /// 出荷日の物理名
            /// </summary>
            public const string dcSyukabi = "syukabi";
            /// <summary>
            /// 着日の物理名
            /// </summary>
            public const string dcTyakubi = "tyakubi";
            /// <summary>
            /// 出荷便の物理名
            /// </summary>
            public const string dcSyukabin = "syukabin";
            /// <summary>
            /// 客先注文番号の物理名
            /// </summary>
            public const string dcKyakusakiChuban = "kyakusakiChuban";
            /// <summary>
            /// 件名番号の物理名
            /// </summary>
            public const string dcKenmeiNo = "kenmeiNo";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 納入先名の物理名
            /// </summary>
            public const string dcNounyusakiName = "nounyusakiName";
            /// <summary>
            /// 納入先部署名の物理名
            /// </summary>
            public const string dcBusyoName = "busyoName";
            /// <summary>
            /// 納入先郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 納入先住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 納入先住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 納入先連絡先１の物理名
            /// </summary>
            public const string dcRenrakusaki1 = "renrakusaki1";
            /// <summary>
            /// 納入先連絡先２の物理名
            /// </summary>
            public const string dcRenrakusaki2 = "renrakusaki2";
            /// <summary>
            /// 納入先担当者名の物理名
            /// </summary>
            public const string dcNounyusakiTantousyaName = "nounyusakiTantousyaName";
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            public const string dcMitumoriNo = "mitumoriNo";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            private DateTime? denpyoHizuke = null;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 発行者コードの物理名
            /// </summary>
            private string hakousyaCode = string.Empty;
            /// <summary>
            /// 発行者名の物理名
            /// </summary>
            private string hakousyaName = string.Empty;
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            private string tokuisakiTantousayName = string.Empty;
            /// <summary>
            /// 材料・工事区分の物理名
            /// </summary>
            private string zairyoKoujiKubun = string.Empty;
            /// <summary>
            /// 出荷日の物理名
            /// </summary>
            private DateTime? syukabi = null;
            /// <summary>
            /// 着日の物理名
            /// </summary>
            private DateTime? tyakubi = null;
            /// <summary>
            /// 出荷便の物理名
            /// </summary>
            private string syukabin = string.Empty;
            /// <summary>
            /// 客先注文番号の物理名
            /// </summary>
            private string kyakusakiChuban = string.Empty;
            /// <summary>
            /// 件名番号の物理名
            /// </summary>
            private string kenmeiNo = string.Empty;
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 納入先名の物理名
            /// </summary>
            private string nounyusakiName = string.Empty;
            /// <summary>
            /// 納入先部署名の物理名
            /// </summary>
            private string busyoName = string.Empty;
            /// <summary>
            /// 納入先郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 納入先住所１の物理名
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 納入先住所２の物理名
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 納入先連絡先１の物理名
            /// </summary>
            private string renrakusaki1 = string.Empty;
            /// <summary>
            /// 納入先連絡先２の物理名
            /// </summary>
            private string renrakusaki2 = string.Empty;
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            private string mitumoriNo = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 伝票番号の取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 伝票日付の取得・設定
            /// </summary>
            public DateTime? DenpyoHizuke
            {
                get { return denpyoHizuke; }
                set { denpyoHizuke = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 発行者コードの取得・設定
            /// </summary>
            public string HakousyaCode
            {
                get { return hakousyaCode; }
                set { hakousyaCode = value; }
            }
            /// <summary>
            /// 発行者名の取得・設定
            /// </summary>
            public string HakousyaName
            {
                get { return hakousyaName; }
                set { hakousyaName = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
            }
            /// <summary>
            /// 得意先担当者名の取得・設定
            /// </summary>
            public string TokuisakiTantousayName
            {
                get { return tokuisakiTantousayName; }
                set { tokuisakiTantousayName = value; }
            }
            /// <summary>
            /// 材料・工事区分の取得・設定
            /// </summary>
            public string ZairyoKoujiKubun
            {
                get { return zairyoKoujiKubun; }
                set { zairyoKoujiKubun = value; }
            }
            /// <summary>
            /// 出荷日の取得・設定
            /// </summary>
            public DateTime? Syukabi
            {
                get { return syukabi; }
                set { syukabi = value; }
            }
            /// <summary>
            /// 着日の取得・設定
            /// </summary>
            public DateTime? Tyakubi
            {
                get { return tyakubi; }
                set { tyakubi = value; }
            }
            /// <summary>
            /// 出荷便の取得・設定
            /// </summary>
            public string Syukabin
            {
                get { return syukabin; }
                set { syukabin = value; }
            }
            /// <summary>
            /// 客先注文番号の取得・設定
            /// </summary>
            public string KyakusakiChuban
            {
                get { return kyakusakiChuban; }
                set { kyakusakiChuban = value; }
            }
            /// <summary>
            /// 件名番号の取得・設定
            /// </summary>
            public string KenmeiNo
            {
                get { return kenmeiNo; }
                set { kenmeiNo = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 納入先名の取得・設定
            /// </summary>
            public string NounyusakiName
            {
                get { return nounyusakiName; }
                set { nounyusakiName = value; }
            }
            /// <summary>
            /// 納入先部署名の取得・設定
            /// </summary>
            public string BusyoName
            {
                get { return busyoName; }
                set { busyoName = value; }
            }
            /// <summary>
            /// 納入先郵便番号の取得・設定
            /// </summary>
            public string ZipCode
            {
                get { return zipCode; }
                set { zipCode = value; }
            }
            /// <summary>
            /// 納入先住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 納入先住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 納入先連絡先１の取得・設定
            /// </summary>
            public string Renrakusaki1
            {
                get { return renrakusaki1; }
                set { renrakusaki1 = value; }
            }
            /// <summary>
            /// 納入先連絡先２の取得・設定
            /// </summary>
            public string Renrakusaki2
            {
                get { return renrakusaki2; }
                set { renrakusaki2 = value; }
            }
            /// <summary>
            /// 見積番号の取得・設定
            /// </summary>
            public string MitumoriNo
            {
                get { return mitumoriNo; }
                set { mitumoriNo = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public JuchuHeaderFile()
            {
            }
            #endregion
        }
        #endregion

        #region 受注ボディファイルレイアウト
        /// <summary>
        /// 受注ボディファイルレイアウト
        /// </summary>
        public class JuchuBodyFile
        {
            #region 列情報
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            public const string dcRowNo = "rowNo";
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            public const string dcDaiBunruiCode = "daiBunruiCode";
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            public const string dcSyoBunruiCode = "syoBunruiCode";
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 相手コードの物理名
            /// </summary>
            public const string dcOpponentCode = "opponentCode";
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            public const string dcShouhinName1 = "shouhinName1";
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            public const string dcShouhinName2 = "shouhinName2";
            /// <summary>
            /// (受注)数量の物理名
            /// </summary>
            public const string dcJuchuSuryo = "juchuSuryo";
            /// <summary>
            /// (受注)単位の物理名
            /// </summary>
            public const string dcJuchuTani = "juchuTani";
            /// <summary>
            /// (受注)納品残数量の物理名
            /// </summary>
            public const string dcJuchuNouhinZanSuryo = "juchuNouhinZanSuryo";
            /// <summary>
            /// (受注)納品数量の物理名
            /// </summary>
            public const string dcJuchuNouhinSuryo = "juchuNouhinSuryo";
            /// <summary>
            /// (受注)単価の物理名
            /// </summary>
            public const string dcJuchuTanka = "juchuTanka";
            /// <summary>
            /// (受注)金額の物理名
            /// </summary>
            public const string dcJuchuKingaku = "juchuKingaku";
            /// <summary>
            /// (受注)納入区分の物理名
            /// </summary>
            public const string dcJuchuNonyuKubun = "juchuNonyuKubun";
            /// <summary>
            /// (仕入)仕入先コードの物理名
            /// </summary>
            public const string dcShiresakiCode = "shiresakiCode";
            /// <summary>
            /// (仕入)仕入先名の物理名
            /// </summary>
            public const string dcShiresakiName = "shiresakiName";
            /// <summary>
            /// (仕入)仕入・部材区分の物理名
            /// </summary>
            public const string dcShireBuzaiKubun = "shireBuzaiKubun";
            /// <summary>
            /// (仕入)単価の物理名
            /// </summary>
            public const string dcShireTanka = "shireTanka";
            /// <summary>
            /// (仕入)金額の物理名
            /// </summary>
            public const string dcShireKingaku = "shireKingaku";
            /// <summary>
            /// (仕入)納品残数量の物理名
            /// </summary>
            public const string dcShireNouhinZanSuryo = "shireNouhinZanSuryo";
            /// <summary>
            /// (仕入)納品数量の物理名
            /// </summary>
            public const string dcShireNouhinSuryo = "shireNouhinSuryo";
            /// <summary>
            /// (仕入)発注番号の物理名
            /// </summary>
            public const string dcShireHachuNo = "shireHachuNo";
            /// <summary>
            /// 備考の物理名
            /// </summary>
            public const string dcBikou = "bikou";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            /// <summary>
            /// 納品数量合計の物理名
            /// </summary>
            public const string dcTotalNouhinSuryo = "totalNouhinSuryo";
            /// <summary>
            /// 仕入数量合計の物理名
            /// </summary>
            public const string dcTotalShireSuryo = "totalShireSuryo";
            /// <summary>
            /// 発注書枝番号の物理名
            /// </summary>
            public const string dcHachusyoEdaban = "hachusyoEdaban";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 納品数量合計
            /// </summary>
            private decimal? totalNouhinSuryo = null;
            /// <summary>
            /// 仕入数量合計
            /// </summary>
            private decimal? totalShireSuryo = null;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            private int rowNo = 0;
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            private string daiBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            private string syoBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 相手コードの物理名
            /// </summary>
            private string opponentCode = string.Empty;
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            private string shouhinName1 = string.Empty;
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            private string shouhinName2 = string.Empty;
            /// <summary>
            /// (受注)数量の物理名
            /// </summary>
            private decimal? juchuSuryo = null;
            /// <summary>
            /// (受注)単位の物理名
            /// </summary>
            private string juchuTani = string.Empty;
            /// <summary>
            /// (受注)納品残数量の物理名
            /// </summary>
            private decimal? juchuNouhinZanSuryo = null;
            /// <summary>
            /// (受注)納品数量の物理名
            /// </summary>
            private decimal? juchuNouhinSuryo = null;
            /// <summary>
            /// (受注)単価の物理名
            /// </summary>
            private decimal? juchuTanka = null;
            /// <summary>
            /// (受注)金額の物理名
            /// </summary>
            private decimal? juchuKingaku = null;
            /// <summary>
            /// (受注)納入区分の物理名
            /// </summary>
            private string juchuNonyuKubun = string.Empty;
            /// <summary>
            /// (仕入)仕入先コードの物理名
            /// </summary>
            private string shiresakiCode = string.Empty;
            /// <summary>
            /// (仕入)仕入先名の物理名
            /// </summary>
            private string shiresakiName = string.Empty;
            /// <summary>
            /// (仕入)仕入・部材区分の物理名
            /// </summary>
            private string shireBuzaiKubun = string.Empty;
            /// <summary>
            /// (仕入)単価の物理名
            /// </summary>
            private decimal? shireTanka = null;
            /// <summary>
            /// (仕入)金額の物理名
            /// </summary>
            private decimal? shireKingaku = null;
            /// <summary>
            /// (仕入)納品残数量の物理名
            /// </summary>
            private decimal? shireNouhinZanSuryo = null;
            /// <summary>
            /// (仕入)納品数量の物理名
            /// </summary>
            private decimal? shireNouhinSuryo = null;
            /// <summary>
            /// (仕入)発注番号の物理名
            /// </summary>
            private string shireHachuNo = string.Empty;
            /// <summary>
            /// 備考の物理名
            /// </summary>
            private string bikou = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 納品数量合計の取得・設定
            /// </summary>
            public decimal? TotalNouhinSuryo
            {
                get { return totalNouhinSuryo; }
                set { totalNouhinSuryo = value; }
            }
            /// <summary>
            /// 仕入数量合計の取得・設定
            /// </summary>
            public decimal? TotalShireSuryo
            {
                get { return totalShireSuryo; }
                set { totalShireSuryo = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 行番号の取得・設定
            /// </summary>
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            /// <summary>
            /// 商品コード(大分類コード)の取得・設定
            /// </summary>
            public string DaiBunruiCode
            {
                get { return daiBunruiCode; }
                set { daiBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(小類コード)の取得・設定
            /// </summary>
            public string SyoBunruiCode
            {
                get { return syoBunruiCode; }
                set { syoBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(連番)の取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 相手コードの取得・設定
            /// </summary>
            public string OpponentCode
            {
                get { return opponentCode; }
                set { opponentCode = value; }
            }
            /// <summary>
            /// 商品名１の取得・設定
            /// </summary>
            public string ShouhinName1
            {
                get { return shouhinName1; }
                set { shouhinName1 = value; }
            }
            /// <summary>
            /// 商品名２の取得・設定
            /// </summary>
            public string ShouhinName2
            {
                get { return shouhinName2; }
                set { shouhinName2 = value; }
            }
            /// <summary>
            /// (受注)数量の取得・設定
            /// </summary>
            public decimal? JuchuSuryo
            {
                get { return juchuSuryo; }
                set { juchuSuryo = value; }
            }
            /// <summary>
            /// (受注)単位の取得・設定
            /// </summary>
            public string JuchuTani
            {
                get { return juchuTani; }
                set { juchuTani = value; }
            }
            /// <summary>
            /// (受注)納品残数量の取得・設定
            /// </summary>
            public decimal? JuchuNouhinZanSuryo
            {
                get { return juchuNouhinZanSuryo; }
                set { juchuNouhinZanSuryo = value; }
            }
            /// <summary>
            /// (受注)納品数量の取得・設定
            /// </summary>
            public decimal? JuchuNouhinSuryo
            {
                get { return juchuNouhinSuryo; }
                set { juchuNouhinSuryo = value; }
            }
            /// <summary>
            /// (受注)単価の取得・設定
            /// </summary>
            public decimal? JuchuTanka
            {
                get { return juchuTanka; }
                set { juchuTanka = value; }
            }
            /// <summary>
            /// (受注)金額の取得・設定
            /// </summary>
            public decimal? JuchuKingaku
            {
                get { return juchuKingaku; }
                set { juchuKingaku = value; }
            }
            /// <summary>
            /// (受注)納入区分の取得・設定
            /// </summary>
            public string JuchuNonyuKubun
            {
                get { return juchuNonyuKubun; }
                set { juchuNonyuKubun = value; }
            }
            /// <summary>
            /// (仕入)仕入先コードの取得・設定
            /// </summary>
            public string ShiresakiCode
            {
                get { return shiresakiCode; }
                set { shiresakiCode = value; }
            }
            /// <summary>
            /// (仕入)仕入先名の取得・設定
            /// </summary>
            public string ShiresakiName
            {
                get { return shiresakiName; }
                set { shiresakiName = value; }
            }
            /// <summary>
            /// (仕入)仕入・部材区分の取得・設定
            /// </summary>
            public string ShireBuzaiKubun
            {
                get { return shireBuzaiKubun; }
                set { shireBuzaiKubun = value; }
            }
            /// <summary>
            /// (仕入)単価の取得・設定
            /// </summary>
            public decimal? ShireTanka
            {
                get { return shireTanka; }
                set { shireTanka = value; }
            }
            /// <summary>
            /// (仕入)金額の取得・設定
            /// </summary>
            public decimal? ShireKingaku
            {
                get { return shireKingaku; }
                set { shireKingaku = value; }
            }
            /// <summary>
            /// (仕入)納品残数量の取得・設定
            /// </summary>
            public decimal? ShireNouhinZanSuryo
            {
                get { return shireNouhinZanSuryo; }
                set { shireNouhinZanSuryo = value; }
            }
            /// <summary>
            /// (仕入)納品数量の取得・設定
            /// </summary>
            public decimal? ShireNouhinSuryo
            {
                get { return shireNouhinSuryo; }
                set { shireNouhinSuryo = value; }
            }
            /// <summary>
            /// (仕入)発注番号の取得・設定
            /// </summary>
            public string ShireHachuNo
            {
                get { return shireHachuNo; }
                set { shireHachuNo = value; }
            }
            /// <summary>
            /// 備考の取得・設定
            /// </summary>
            public string Bikou
            {
                get { return bikou; }
                set { bikou = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public JuchuBodyFile()
            {
            }
            #endregion
        }
        #endregion

        #region 受注フッタファイルレイアウト
        /// <summary>
        /// 受注フッタファイルレイアウト
        /// </summary>
        public class JuchuFooterFile
        {
            #region 列情報
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 受注計の物理名
            /// </summary>
            public const string dcJuchuKei = "juchuKei";
            /// <summary>
            /// 仕入計の物理名
            /// </summary>
            public const string dcShireKei = "shireKei";
            /// <summary>
            /// メッキ代の物理名
            /// </summary>
            public const string dcMekkiDai = "mekkiDai";
            /// <summary>
            /// 塗装代の物理名
            /// </summary>
            public const string dcTosouDai = "tosouDai";
            /// <summary>
            /// 運賃代の物理名
            /// </summary>
            public const string dcUnchin = "unchin";
            /// <summary>
            /// 仕入代の物理名
            /// </summary>
            public const string dcShireDai = "shireDai";
            /// <summary>
            /// 部材代の物理名
            /// </summary>
            public const string dcBuzaiDai = "buzaiDai";
            /// <summary>
            /// 仕入合計の物理名
            /// </summary>
            public const string dcShireGoukei = "shireGoukei";
            /// <summary>
            /// 粗利額の物理名
            /// </summary>
            public const string dcArariGaku = "arariGaku";
            /// <summary>
            /// 粗利率の物理名
            /// </summary>
            public const string dcArariRitu = "arariRitu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 受注計の物理名
            /// </summary>
            private decimal? juchuKei = null;
            /// <summary>
            /// 仕入計の物理名
            /// </summary>
            private decimal? shireKei = null;
            /// <summary>
            /// メッキ代の物理名
            /// </summary>
            private decimal? mekkiDai = null;
            /// <summary>
            /// 塗装代の物理名
            /// </summary>
            private decimal? tosouDai = null;
            /// <summary>
            /// 運賃代の物理名
            /// </summary>
            private decimal? unchin = null;
            /// <summary>
            /// 仕入代の物理名
            /// </summary>
            private decimal? shireDai = null;
            /// <summary>
            /// 部材代の物理名
            /// </summary>
            private decimal? buzaiDai = null;
            /// <summary>
            /// 仕入合計の物理名
            /// </summary>
            private decimal? shireGoukei = null;
            /// <summary>
            /// 粗利額の物理名
            /// </summary>
            private decimal? arariGaku = null;
            /// <summary>
            /// 粗利率の物理名
            /// </summary>
            private decimal? arariRitu = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 受注計の取得・設定
            /// </summary>
            public decimal? JuchuKei
            {
                get { return juchuKei; }
                set { juchuKei = value; }
            }
            /// <summary>
            /// 仕入計の取得・設定
            /// </summary>
            public decimal? ShireKei
            {
                get { return shireKei; }
                set { shireKei = value; }
            }
            /// <summary>
            /// メッキ代の取得・設定
            /// </summary>
            public decimal? MekkiDai
            {
                get { return mekkiDai; }
                set { mekkiDai = value; }
            }
            /// <summary>
            /// 塗装代の取得・設定
            /// </summary>
            public decimal? TosouDai
            {
                get { return tosouDai; }
                set { tosouDai = value; }
            }
            /// <summary>
            /// 運賃代の取得・設定
            /// </summary>
            public decimal? Unchin
            {
                get { return unchin; }
                set { unchin = value; }
            }
            /// <summary>
            /// 仕入代の取得・設定
            /// </summary>
            public decimal? ShireDai
            {
                get { return shireDai; }
                set { shireDai = value; }
            }
            /// <summary>
            /// 部材代の取得・設定
            /// </summary>
            public decimal? BuzaiDai
            {
                get { return buzaiDai; }
                set { buzaiDai = value; }
            }
            /// <summary>
            /// 仕入合計の取得・設定
            /// </summary>
            public decimal? ShireGoukei
            {
                get { return shireGoukei; }
                set { shireGoukei = value; }
            }
            /// <summary>
            /// 粗利額の取得・設定
            /// </summary>
            public decimal? ArariGaku
            {
                get { return arariGaku; }
                set { arariGaku = value; }
            }
            /// <summary>
            /// 粗利率の取得・設定
            /// </summary>
            public decimal? ArariRitu
            {
                get { return arariRitu; }
                set { arariRitu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public JuchuFooterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 見積ヘッダファイルレイアウト
        /// <summary>
        /// 見積ヘッダファイルレイアウト
        /// </summary>
        public class MitumoriHeaderFile
        {
            #region 列情報
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            public const string dcMitumoriNo = "mitumoriNo";
            /// <summary>
            /// 見積年月日の物理名
            /// </summary>
            public const string dcMitumoriHizuke = "mitumoriHizuke";
            /// <summary>
            /// 見積区分の物理名
            /// </summary>
            public const string dcMitumoriKubun = "mitumoriKubun";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名敬称の物理名
            /// </summary>
            public const string dcTokuisakiNameOption = "tokuisakiNameOption";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 事業所名敬称の物理名
            /// </summary>
            public const string dcJigyousyoNameOption = "jigyousyoNameOption";
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            public const string dcTokuisakiTantousayName = "tokuisakiTantousayName";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 消費税出力区分の物理名
            /// </summary>
            public const string dcZeiDispType = "zeiDispType";
            /// <summary>
            /// 納期の物理名
            /// </summary>
            public const string dcNouki = "nouki";
            /// <summary>
            /// 取引条件の物理名
            /// </summary>
            public const string dcTorihikiJouken = "torihikiJouken";
            /// <summary>
            /// 有効期限の物理名
            /// </summary>
            public const string dcYuukouKigen = "yuukouKigen";
            /// <summary>
            /// 受渡場所１の物理名
            /// </summary>
            public const string dcUkewatasiBasyo1 = "ukewatasiBasyo1";
            /// <summary>
            /// 受渡場所２の物理名
            /// </summary>
            public const string dcUkewatasiBasyo2 = "ukewatasiBasyo2";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            private string mitumoriNo = string.Empty;
            /// <summary>
            /// 見積年月日の物理名
            /// </summary>
            private string mitumoriHizuke = null;
            /// <summary>
            /// 見積区分の物理名
            /// </summary>
            private string mitumoriKubun = string.Empty;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名敬称の物理名
            /// </summary>
            private string tokuisakiNameOption = string.Empty;
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 事業所名敬称の物理名
            /// </summary>
            private string jigyousyoNameOption = string.Empty;
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            private string tokuisakiTantousayName = string.Empty;
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 消費税出力区分の物理名
            /// </summary>
            private string zeiDispType = null;
            /// <summary>
            /// 納期の物理名
            /// </summary>
            private DateTime? nouki = null;
            /// <summary>
            /// 取引条件の物理名
            /// </summary>
            private string torihikiJouken = string.Empty;
            /// <summary>
            /// 有効期限の物理名
            /// </summary>
            private string yuukouKigen = null;
            /// <summary>
            /// 受渡場所１の物理名
            /// </summary>
            private string ukewatasiBasyo1 = string.Empty;
            /// <summary>
            /// 受渡場所２の物理名
            /// </summary>
            private string ukewatasiBasyo2 = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 見積番号の取得・設定
            /// </summary>
            public string MitumoriNo
            {
                get { return mitumoriNo; }
                set { mitumoriNo = value; }
            }
            /// <summary>
            /// 見積年月日の取得・設定
            /// </summary>
            public string MitumoriHizuke
            {
                get { return mitumoriHizuke; }
                set { mitumoriHizuke = value; }
            }
            /// <summary>
            /// 見積区分の取得・設定
            /// </summary>
            public string MitumoriKubun
            {
                get { return mitumoriKubun; }
                set { mitumoriKubun = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名敬称の取得・設定
            /// </summary>
            public string TokuisakiNameOption
            {
                get { return tokuisakiNameOption; }
                set { tokuisakiNameOption = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
            }
            /// <summary>
            /// 事業所名敬称の取得・設定
            /// </summary>
            public string JigyousyoNameOption
            {
                get { return jigyousyoNameOption; }
                set { jigyousyoNameOption = value; }
            }
            /// <summary>
            /// 得意先担当者名の取得・設定
            /// </summary>
            public string TokuisakiTantousayName
            {
                get { return tokuisakiTantousayName; }
                set { tokuisakiTantousayName = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 貴年月日の取得・設定
            /// </summary>
            public string ZeiDispType
            {
                get { return zeiDispType; }
                set { zeiDispType = value; }
            }
            /// <summary>
            /// 納期の取得・設定
            /// </summary>
            public DateTime? Nouki
            {
                get { return nouki; }
                set { nouki = value; }
            }
            /// <summary>
            /// 取引条件の取得・設定
            /// </summary>
            public string TorihikiJouken
            {
                get { return torihikiJouken; }
                set { torihikiJouken = value; }
            }
            /// <summary>
            /// 有効期限の取得・設定
            /// </summary>
            public string YuukouKigen
            {
                get { return yuukouKigen; }
                set { yuukouKigen = value; }
            }
            /// <summary>
            /// 受渡場所１の取得・設定
            /// </summary>
            public string UkewatasiBasyo1
            {
                get { return ukewatasiBasyo1; }
                set { ukewatasiBasyo1 = value; }
            }
            /// <summary>
            /// 受渡場所２の取得・設定
            /// </summary>
            public string UkewatasiBasyo2
            {
                get { return ukewatasiBasyo2; }
                set { ukewatasiBasyo2 = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public MitumoriHeaderFile()
            {
            }
            #endregion
        }
        #endregion

        #region 見積ボディファイルレイアウト
        /// <summary>
        /// 見積ボディファイルレイアウト
        /// </summary>
        public class MitumoriBodyFile
        {
            #region 列情報
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            public const string dcMitumoriNo = "mitumoriNo";
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            public const string dcRowNo = "rowNo";
            /// <summary>
            /// 商品コードの物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            public const string dcShouhinName1 = "shouhinName1";
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            public const string dcShouhinName2 = "shouhinName2";
            /// <summary>
            /// 数量の物理名
            /// </summary>
            public const string dcSuryo = "suryo";
            /// <summary>
            /// 単位の物理名
            /// </summary>
            public const string dcTani = "tani";
            /// <summary>
            /// 単価の物理名
            /// </summary>
            public const string dcTanka = "tanka";
            /// <summary>
            /// 金額の物理名
            /// </summary>
            public const string dcKingaku = "kingaku";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            private string mitumoriNo = string.Empty;
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            private int rowNo = 0;
            /// <summary>
            /// 商品コードの物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            private string shouhinName1 = string.Empty;
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            private string shouhinName2 = string.Empty;
            /// <summary>
            /// 数量の物理名
            /// </summary>
            private decimal? suryo = null;
            /// <summary>
            /// 単位の物理名
            /// </summary>
            private string tani = string.Empty;
            /// <summary>
            /// 単価の物理名
            /// </summary>
            private decimal? tanka = null;
            /// <summary>
            /// 金額の物理名
            /// </summary>
            private decimal? kingaku = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 見積番号の取得・設定
            /// </summary>
            public string MitumoriNo
            {
                get { return mitumoriNo; }
                set { mitumoriNo = value; }
            }
            /// <summary>
            /// 行番号の取得・設定
            /// </summary>
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            /// <summary>
            /// 商品コードの取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 商品名１の取得・設定
            /// </summary>
            public string ShouhinName1
            {
                get { return shouhinName1; }
                set { shouhinName1 = value; }
            }
            /// <summary>
            /// 商品名２の取得・設定
            /// </summary>
            public string ShouhinName2
            {
                get { return shouhinName2; }
                set { shouhinName2 = value; }
            }
            /// <summary>
            /// 数量の取得・設定
            /// </summary>
            public decimal? Suryo
            {
                get { return suryo; }
                set { suryo = value; }
            }
            /// <summary>
            /// 単位の取得・設定
            /// </summary>
            public string Tani
            {
                get { return tani; }
                set { tani = value; }
            }
            /// <summary>
            /// 単価の取得・設定
            /// </summary>
            public decimal? Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 金額の取得・設定
            /// </summary>
            public decimal? Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public MitumoriBodyFile()
            {
            }
            #endregion
        }
        #endregion

        #region 見積フッタファイルレイアウト
        /// <summary>
        /// 見積フッタファイルレイアウト
        /// </summary>
        public class MitumoriFooterFile
        {
            #region 列情報
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            public const string dcMitumoriNo = "mitumoriNo";
            /// <summary>
            /// 消費税の物理名
            /// </summary>
            public const string dcShouhizei = "shouhizei";
            /// <summary>
            /// 金額の物理名
            /// </summary>
            public const string dcKingaku = "kingaku";
            /// <summary>
            /// 総合計の物理名
            /// </summary>
            public const string dcGoukei = "goukei";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 見積番号の物理名
            /// </summary>
            private string mitumoriNo = string.Empty;
            /// <summary>
            /// 消費税の物理名
            /// </summary>
            private decimal? shouhizei = null;
            /// <summary>
            /// 金額の物理名
            /// </summary>
            private decimal? kingaku = null;
            /// <summary>
            /// 総合計の物理名
            /// </summary>
            private decimal? goukei = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 見積番号の取得・設定
            /// </summary>
            public string MitumoriNo
            {
                get { return mitumoriNo; }
                set { mitumoriNo = value; }
            }
            /// <summary>
            /// 消費税の取得・設定
            /// </summary>
            public decimal? Shouhizei
            {
                get { return shouhizei; }
                set { shouhizei = value; }
            }
            /// <summary>
            /// 金額の取得・設定
            /// </summary>
            public decimal? Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }
            /// <summary>
            /// 総合計の取得・設定
            /// </summary>
            public decimal? Goukei
            {
                get { return goukei; }
                set { goukei = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public MitumoriFooterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 入金ファイルレイアウト
        /// <summary>
        /// 入金ファイルレイアウト
        /// </summary>
        public class NyukinFile
        {
            #region 列情報
            /// <summary>
            /// 入金番号の物理名
            /// </summary>
            public const string dcNyukinNo = "nyukinNo";
            /// <summary>
            /// 入金日付の物理名
            /// </summary>
            public const string dcNyukinHizuke = "nyukinHizuke";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 現金の物理名
            /// </summary>
            public const string dcGenkin = "genkin";
            /// <summary>
            /// 振込の物理名
            /// </summary>
            public const string dcHurikomi = "hurikomi";
            /// <summary>
            /// 手数料の物理名
            /// </summary>
            public const string dcTesuryo = "tesuryo";
            /// <summary>
            /// 小切手の物理名
            /// </summary>
            public const string dcKogitte = "kogitte";
            /// <summary>
            /// 手形の物理名
            /// </summary>
            public const string dcTegata = "tegata";
            /// <summary>
            /// 手形割引料の物理名
            /// </summary>
            public const string dcTegataWaribiki = "tegataWaribiki";
            /// <summary>
            /// 相殺の物理名
            /// </summary>
            public const string dcSousai = "sousai";
            /// <summary>
            /// リベートの物理名
            /// </summary>
            public const string dcRibeto = "ribeto";
            /// <summary>
            /// でんさいの物理名
            /// </summary>
            public const string dcDensai = "densai";
            /// <summary>
            /// 調整の物理名
            /// </summary>
            public const string dcTyousei = "tyousei";
            /// <summary>
            /// その他の物理名
            /// </summary>
            public const string dcSonota = "sonota";
            /// <summary>
            /// 合計の物理名
            /// </summary>
            public const string dcGoukei = "goukei";
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            public const string dcSeikyuHizuke = "seikyuHizuke";
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            public const string dcSeikyuHuragu = "seikyuHuragu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 入金番号の物理名
            /// </summary>
            private string nyukinNo = string.Empty;
            /// <summary>
            /// 入金日付の物理名
            /// </summary>
            private DateTime? nyukinHizuke = null;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 現金の物理名
            /// </summary>
            private decimal? genkin = 0;
            /// <summary>
            /// 振込の物理名
            /// </summary>
            private decimal? hurikomi = 0;
            /// <summary>
            /// 手数料の物理名
            /// </summary>
            private decimal? tesuryo = 0;
            /// <summary>
            /// 小切手の物理名
            /// </summary>
            private decimal? kogitte = 0;
            /// <summary>
            /// 手形の物理名
            /// </summary>
            private decimal? tegata = 0;
            /// <summary>
            /// 手形割引料の物理名
            /// </summary>
            private decimal? tegataWaribiki = 0;
            /// <summary>
            /// 相殺の物理名
            /// </summary>
            private decimal? sousai = 0;
            /// <summary>
            /// リベートの物理名
            /// </summary>
            private decimal? ribeto = 0;
            /// <summary>
            /// でんさいの物理名
            /// </summary>
            private decimal? densai = 0;
            /// <summary>
            /// 調整の物理名
            /// </summary>
            private decimal? tyousei = 0;
            /// <summary>
            /// その他の物理名
            /// </summary>
            private decimal? sonota = 0;
            /// <summary>
            /// 合計の物理名
            /// </summary>
            private decimal? goukei = 0;
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            private DateTime? seikyuHizuke = null;
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            private string seikyuHuragu = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 入金番号の取得・設定
            /// </summary>
            public string NyukinNo
            {
                get { return nyukinNo; }
                set { nyukinNo = value; }
            }
            /// <summary>
            /// 入金日付の取得・設定
            /// </summary>
            public DateTime? NyukinHizuke
            {
                get { return nyukinHizuke; }
                set { nyukinHizuke = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 現金の取得・設定
            /// </summary>
            public decimal? Genkin
            {
                get { return genkin; }
                set { genkin = value; }
            }
            /// <summary>
            /// 振込の取得・設定
            /// </summary>
            public decimal? Hurikomi
            {
                get { return hurikomi; }
                set { hurikomi = value; }
            }
            /// <summary>
            /// 手数料の取得・設定
            /// </summary>
            public decimal? Tesuryo
            {
                get { return tesuryo; }
                set { tesuryo = value; }
            }
            /// <summary>
            /// 小切手の取得・設定
            /// </summary>
            public decimal? Kogitte
            {
                get { return kogitte; }
                set { kogitte = value; }
            }
            /// <summary>
            /// 手形の取得・設定
            /// </summary>
            public decimal? Tegata
            {
                get { return tegata; }
                set { tegata = value; }
            }
            /// <summary>
            /// 手形割引料の取得・設定
            /// </summary>
            public decimal? TegataWaribiki
            {
                get { return tegataWaribiki; }
                set { tegataWaribiki = value; }
            }
            /// <summary>
            /// 相殺の取得・設定
            /// </summary>
            public decimal? Sousai
            {
                get { return sousai; }
                set { sousai = value; }
            }
            /// <summary>
            /// リベートの取得・設定
            /// </summary>
            public decimal? Ribeto
            {
                get { return ribeto; }
                set { ribeto = value; }
            }
            /// <summary>
            /// でんさいの取得・設定
            /// </summary>
            public decimal? Densai
            {
                get { return densai; }
                set { densai = value; }
            }
            /// <summary>
            /// 調整の取得・設定
            /// </summary>
            public decimal? Tyousei
            {
                get { return tyousei; }
                set { tyousei = value; }
            }
            /// <summary>
            /// その他の取得・設定
            /// </summary>
            public decimal? Sonota
            {
                get { return sonota; }
                set { sonota = value; }
            }
            /// <summary>
            /// 合計の取得・設定
            /// </summary>
            public decimal? Goukei
            {
                get { return goukei; }
                set { goukei = value; }
            }
            /// <summary>
            /// 請求日付の取得・設定
            /// </summary>
            public DateTime? SeikyuHizuke
            {
                get { return seikyuHizuke; }
                set { seikyuHizuke = value; }
            }
            /// <summary>
            /// 請求区分の取得・設定
            /// </summary>
            public string SeikyuHuragu
            {
                get { return seikyuHuragu; }
                set { seikyuHuragu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public NyukinFile()
            {
            }
            #endregion
        }
        #endregion

        #region 請求ヘッダファイルレイアウト
        /// <summary>
        /// 請求ヘッダファイルレイアウト
        /// </summary>
        public class SeikyuHeaderFile
        {
            #region 列情報
            /// <summary>
            /// 請求NOの物理名
            /// </summary>
            public const string dcSeikyuNo = "seikyuNo";
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            public const string dcDenpyoHizuke = "denpyoHizuke";
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            public const string dcTokuisakiTantousayName = "tokuisakiTantousayName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 件名番号の物理名
            /// </summary>
            public const string dcKenmeiNo = "kenmeiNo";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 注文日付の物理名
            /// </summary>
            public const string dcChumonHizuke = "chumonHizuke";
            /// <summary>
            /// 指定伝票番号の物理名
            /// </summary>
            public const string dcShiteiDenpyoNo = "shiteiDenpyoNo";
            /// <summary>
            /// 納品日付の物理名
            /// </summary>
            public const string dcNouhinHizuke = "nouhinHizuke";
            /// <summary>
            /// 工番１の物理名
            /// </summary>
            public const string dcKouban1 = "kouban1";
            /// <summary>
            /// 工番２の物理名
            /// </summary>
            public const string dcKouban2 = "kouban2";
            /// <summary>
            /// 工番３の物理名
            /// </summary>
            public const string dcKouban3 = "kouban3";
            /// <summary>
            /// 納品書区分の物理名
            /// </summary>
            public const string dcNouhinsyoKubun = "nouhinsyoKubun";
            /// <summary>
            /// 備考１の物理名
            /// </summary>
            public const string dcBikou1 = "bikou1";
            /// <summary>
            /// 備考２の物理名
            /// </summary>
            public const string dcBikou2 = "bikou2";
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            public const string dcSeikyuHizuke = "seikyuHizuke";
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            public const string dcSeikyuHuragu = "seikyuHuragu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 明細行をまとめて出力フラグの物理名
            /// </summary>
            public const string dcFlgMeisaiIkkatuSyuturyoku = "flgMeisaiIkkatuSyuturyoku";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 請求NOの物理名
            /// </summary>
            private string seikyuNo = string.Empty;
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            private DateTime? denpyoHizuke = null;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            private string tokuisakiTantousayName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 件名番号の物理名
            /// </summary>
            private string kenmeiNo = string.Empty;
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 注文日付の物理名
            /// </summary>
            private DateTime? chumonHizuke = null;
            /// <summary>
            /// 指定伝票番号の物理名
            /// </summary>
            private string shiteiDenpyoNo = string.Empty;
            /// <summary>
            /// 納品日付の物理名
            /// </summary>
            private DateTime? nouhinHizuke = null;
            /// <summary>
            /// 工番１の物理名
            /// </summary>
            private string kouban1 = string.Empty;
            /// <summary>
            /// 工番２の物理名
            /// </summary>
            private string kouban2 = string.Empty;
            /// <summary>
            /// 工番３の物理名
            /// </summary>
            private string kouban3 = string.Empty;
            /// <summary>
            /// 納品書区分の物理名
            /// </summary>
            private string nouhinsyoKubun = string.Empty;
            /// <summary>
            /// 備考１の物理名
            /// </summary>
            private string bikou1 = string.Empty;
            /// <summary>
            /// 備考２の物理名
            /// </summary>
            private string bikou2 = string.Empty;
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            private DateTime? seikyuHizuke = null;
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            private string seikyuHuragu = string.Empty;
            /// <summary>
            /// 明細行をまとめて出力フラグ
            /// </summary>
            private int flgMeisaiIkkatuSyuturyoku = 0;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 請求NOの取得・設定
            /// </summary>
            public string SeikyuNo
            {
                get { return seikyuNo; }
                set { seikyuNo = value; }
            }
            /// <summary>
            /// 伝票番号の取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 伝票日付の取得・設定
            /// </summary>
            public DateTime? DenpyoHizuke
            {
                get { return denpyoHizuke; }
                set { denpyoHizuke = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
            }
            /// <summary>
            /// 得意先担当者名の取得・設定
            /// </summary>
            public string TokuisakiTantousayName
            {
                get { return tokuisakiTantousayName; }
                set { tokuisakiTantousayName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 件名番号の取得・設定
            /// </summary>
            public string KenmeiNo
            {
                get { return kenmeiNo; }
                set { kenmeiNo = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 注文日付の取得・設定
            /// </summary>
            public DateTime? ChumonHizuke
            {
                get { return chumonHizuke; }
                set { chumonHizuke = value; }
            }
            /// <summary>
            /// 指定伝票番号の取得・設定
            /// </summary>
            public string ShiteiDenpyoNo
            {
                get { return shiteiDenpyoNo; }
                set { shiteiDenpyoNo = value; }
            }
            /// <summary>
            /// 納品日付の取得・設定
            /// </summary>
            public DateTime? NouhinHizuke
            {
                get { return nouhinHizuke; }
                set { nouhinHizuke = value; }
            }
            /// <summary>
            /// 工番１の取得・設定
            /// </summary>
            public string Kouban1
            {
                get { return kouban1; }
                set { kouban1 = value; }
            }
            /// <summary>
            /// 工番２の取得・設定
            /// </summary>
            public string Kouban2
            {
                get { return kouban2; }
                set { kouban2 = value; }
            }
            /// <summary>
            /// 工番３の取得・設定
            /// </summary>
            public string Kouban3
            {
                get { return kouban3; }
                set { kouban3 = value; }
            }
            /// <summary>
            /// 納品書区分の取得・設定
            /// </summary>
            public string NouhinsyoKubun
            {
                get { return nouhinsyoKubun; }
                set { nouhinsyoKubun = value; }
            }
            /// <summary>
            /// 備考１の取得・設定
            /// </summary>
            public string Bikou1
            {
                get { return bikou1; }
                set { bikou1 = value; }
            }
            /// <summary>
            /// 備考２の取得・設定
            /// </summary>
            public string Bikou2
            {
                get { return bikou2; }
                set { bikou2 = value; }
            }
            /// <summary>
            /// 請求日付の取得・設定
            /// </summary>
            public DateTime? SeikyuHizuke
            {
                get { return seikyuHizuke; }
                set { seikyuHizuke = value; }
            }
            /// <summary>
            /// 請求区分の取得・設定
            /// </summary>
            public string SeikyuHuragu
            {
                get { return seikyuHuragu; }
                set { seikyuHuragu = value; }
            }
            /// <summary>
            /// 明細行をまとめて出力フラグの取得・設定
            /// </summary>
            public int FlgMeisaiIkkatuSyuturyoku
            {
                get { return flgMeisaiIkkatuSyuturyoku; }
                set { flgMeisaiIkkatuSyuturyoku = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public SeikyuHeaderFile()
            {
            }
            #endregion
        }
        #endregion

        #region 請求ボディファイルレイアウト
        /// <summary>
        /// 請求ボディファイルレイアウト
        /// </summary>
        public class SeikyuBodyFile
        {
            #region 列情報
            /// <summary>
            /// 請求NOの物理名
            /// </summary>
            public const string dcSeikyuNo = "seikyuNo";
            /// <summary>
            /// 伝票NOの物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            public const string dcRowNo = "rowNo";
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            public const string dcJuchuRowNo = "juchuRowNo";
            /// <summary>
            /// 納品書出力フラグの物理名
            /// </summary>
            public const string dcFlgPrint = "flgPrint";
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            public const string dcDaiBunruiCode = "daiBunruiCode";
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            public const string dcSyoBunruiCode = "syoBunruiCode";
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            public const string dcShouhinName1 = "shouhinName1";
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            public const string dcShouhinName2 = "shouhinName2";
            /// <summary>
            /// 数量の物理名
            /// </summary>
            public const string dcSuryo = "suryo";
            /// <summary>
            /// 単位の物理名
            /// </summary>
            public const string dcTani = "tani";
            /// <summary>
            /// 単価の物理名
            /// </summary>
            public const string dcTanka = "tanka";
            /// <summary>
            /// 金額の物理名
            /// </summary>
            public const string dcKingaku = "kingaku";
            /// <summary>
            /// 納品状態の物理名
            /// </summary>
            public const string dcNouhinJoutai = "nouhinJoutai";
            /// <summary>
            /// 備考の物理名
            /// </summary>
            public const string dcBikou = "bikou";
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            public const string dcSeikyuHizuke = "seikyuHizuke";
            /// <summary>
            /// 請求フラグの物理名
            /// </summary>
            public const string dcSeikyuHuragu = "seikyuHuragu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 請求NOの物理名
            /// </summary>
            private string seikyuNo = string.Empty;
            /// <summary>
            /// 伝票NOの物理名
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            private int rowNo = 0;
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            private int juchuRowNo = 0;
            /// <summary>
            /// 納品書出力フラグの物理名
            /// </summary>
            private int flgPrint = 0;
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            private string daiBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            private string syoBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            private string shouhinName1 = string.Empty;
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            private string shouhinName2 = string.Empty;
            /// <summary>
            /// 数量の物理名
            /// </summary>
            private decimal? suryo = null;
            /// <summary>
            /// 単位の物理名
            /// </summary>
            private string tani = string.Empty;
            /// <summary>
            /// 単価の物理名
            /// </summary>
            private decimal? tanka = null;
            /// <summary>
            /// 金額の物理名
            /// </summary>
            private decimal? kingaku = null;
            /// <summary>
            /// 納品状態の物理名
            /// </summary>
            private string nouhinJoutai = string.Empty;
            /// <summary>
            /// 備考の物理名
            /// </summary>
            private string bikou = string.Empty;
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            private DateTime? seikyuHizuke = null;
            /// <summary>
            /// 請求フラグの物理名
            /// </summary>
            private string seikyuHuragu = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 請求NOの取得・設定
            /// </summary>
            public string SeikyuNo
            {
                get { return seikyuNo; }
                set { seikyuNo = value; }
            }
            /// <summary>
            /// 伝票NOの取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 行番号の取得・設定
            /// </summary>
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            /// <summary>
            /// 受注行番号の取得・設定
            /// </summary>
            public int JuchuRowNo
            {
                get { return juchuRowNo; }
                set { juchuRowNo = value; }
            }
            /// <summary>
            /// 納品書出力フラグの取得・設定
            /// </summary>
            public int FlgPrint
            {
                get { return flgPrint; }
                set { flgPrint = value; }
            }
            /// <summary>
            /// 商品コード(大分類コード)の取得・設定
            /// </summary>
            public string DaiBunruiCode
            {
                get { return daiBunruiCode; }
                set { daiBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(小類コード)の取得・設定
            /// </summary>
            public string SyoBunruiCode
            {
                get { return syoBunruiCode; }
                set { syoBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(連番)の取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 商品名１の取得・設定
            /// </summary>
            public string ShouhinName1
            {
                get { return shouhinName1; }
                set { shouhinName1 = value; }
            }
            /// <summary>
            /// 商品名２の取得・設定
            /// </summary>
            public string ShouhinName2
            {
                get { return shouhinName2; }
                set { shouhinName2 = value; }
            }
            /// <summary>
            /// 数量の取得・設定
            /// </summary>
            public decimal? Suryo
            {
                get { return suryo; }
                set { suryo = value; }
            }
            /// <summary>
            /// 単位の取得・設定
            /// </summary>
            public string Tani
            {
                get { return tani; }
                set { tani = value; }
            }
            /// <summary>
            /// 単価の取得・設定
            /// </summary>
            public decimal? Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 金額の取得・設定
            /// </summary>
            public decimal? Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }
            /// <summary>
            /// 納品状態の取得・設定
            /// </summary>
            public string NouhinJoutai
            {
                get { return nouhinJoutai; }
                set { nouhinJoutai = value; }
            }
            /// <summary>
            /// 備考の取得・設定
            /// </summary>
            public string Bikou
            {
                get { return bikou; }
                set { bikou = value; }
            }
            /// <summary>
            /// 請求日付の取得・設定
            /// </summary>
            public DateTime? SeikyuHizuke
            {
                get { return seikyuHizuke; }
                set { seikyuHizuke = value; }
            }
            /// <summary>
            /// 請求フラグの取得・設定
            /// </summary>
            public string SeikyuHuragu
            {
                get { return seikyuHuragu; }
                set { seikyuHuragu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public SeikyuBodyFile()
            {
            }
            #endregion
        }
        #endregion

        #region 請求フッタファイルレイアウト
        /// <summary>
        /// 請求フッタファイルレイアウト
        /// </summary>
        public class SeikyuFooterFile
        {
            #region 列情報
            /// <summary>
            /// 請求NOの物理名
            /// </summary>
            public const string dcSeikyuNo = "seikyuNo";
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 売上金額の物理名
            /// </summary>
            public const string dcUriageKingaku = "uriageKingaku";
            /// <summary>
            /// 消費税の物理名
            /// </summary>
            public const string dcSyouhizei = "syouhizei";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 請求NOの物理名
            /// </summary>
            private string seikyuNo = string.Empty;
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 売上金額の物理名
            /// </summary>
            private decimal? uriageKingaku = null;
            /// <summary>
            /// 消費税の物理名
            /// </summary>
            private decimal? syouhizei = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 請求NOの取得・設定
            /// </summary>
            public string SeikyuNo
            {
                get { return seikyuNo; }
                set { seikyuNo = value; }
            }
            /// <summary>
            /// 伝票番号の取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 売上金額の取得・設定
            /// </summary>
            public decimal? UriageKingaku
            {
                get { return uriageKingaku; }
                set { uriageKingaku = value; }
            }
            /// <summary>
            /// 消費税の取得・設定
            /// </summary>
            public decimal? Syouhizei
            {
                get { return syouhizei; }
                set { syouhizei = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public SeikyuFooterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 支払ファイルレイアウト
        /// <summary>
        /// 支払ファイルレイアウト
        /// </summary>
        public class ShiharaiFile
        {
            #region 列情報
            /// <summary>
            /// 支払番号の物理名
            /// </summary>
            public const string dcShiharaiNo = "shiharaiNo";
            /// <summary>
            /// 支払日付の物理名
            /// </summary>
            public const string dcShiharaiHizuke = "shiharaiHizuke";
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            public const string dcShiresakiCode = "shiresakiCode";
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            public const string dcShiresakiName = "shiresakiName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 現金の物理名
            /// </summary>
            public const string dcGenkin = "genkin";
            /// <summary>
            /// 手形の物理名
            /// </summary>
            public const string dcTegata = "tegata";
            /// <summary>
            /// 振込の物理名
            /// </summary>
            public const string dcHurikomi = "hurikomi";
            /// <summary>
            /// 相殺の物理名
            /// </summary>
            public const string dcSousai = "sousai";
            /// <summary>
            /// 合計の物理名
            /// </summary>
            public const string dcGoukei = "goukei";
            /// <summary>
            /// 締年月日の物理名
            /// </summary>
            public const string dcShimeNengapi = "shimeNengapi";
            /// <summary>
            /// 締更新フラグの物理名
            /// </summary>
            public const string dcShimeKoushinHuragu = "shimeKoushinHuragu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 支払番号の物理名
            /// </summary>
            private string shiharaiNo = string.Empty;
            /// <summary>
            /// 支払日付の物理名
            /// </summary>
            private DateTime? shiharaiHizuke = null;
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            private string shiresakiCode = string.Empty;
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            private string shiresakiName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 現金の物理名
            /// </summary>
            private decimal? genkin = 0;
            /// <summary>
            /// 手形の物理名
            /// </summary>
            private decimal? tegata = 0;
            /// <summary>
            /// 振込の物理名
            /// </summary>
            private decimal? hurikomi = 0;
            /// <summary>
            /// 相殺の物理名
            /// </summary>
            private decimal? sousai = 0;
            /// <summary>
            /// 合計の物理名
            /// </summary>
            private decimal? goukei = 0;
            /// <summary>
            /// 締年月日の物理名
            /// </summary>
            private DateTime? shimeNengapi = null;
            /// <summary>
            /// 締更新フラグの物理名
            /// </summary>
            private string shimeKoushinHuragu = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 支払番号の取得・設定
            /// </summary>
            public string ShiharaiNo
            {
                get { return shiharaiNo; }
                set { shiharaiNo = value; }
            }
            /// <summary>
            /// 支払日付の取得・設定
            /// </summary>
            public DateTime? ShiharaiHizuke
            {
                get { return shiharaiHizuke; }
                set { shiharaiHizuke = value; }
            }
            /// <summary>
            /// 仕入先コードの取得・設定
            /// </summary>
            public string ShiresakiCode
            {
                get { return shiresakiCode; }
                set { shiresakiCode = value; }
            }
            /// <summary>
            /// 仕入先名の取得・設定
            /// </summary>
            public string ShiresakiName
            {
                get { return shiresakiName; }
                set { shiresakiName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 現金の取得・設定
            /// </summary>
            public decimal? Genkin
            {
                get { return genkin; }
                set { genkin = value; }
            }
            /// <summary>
            /// 手形の取得・設定
            /// </summary>
            public decimal? Tegata
            {
                get { return tegata; }
                set { tegata = value; }
            }
            /// <summary>
            /// 振込の取得・設定
            /// </summary>
            public decimal? Hurikomi
            {
                get { return hurikomi; }
                set { hurikomi = value; }
            }
            /// <summary>
            /// 相殺の取得・設定
            /// </summary>
            public decimal? Sousai
            {
                get { return sousai; }
                set { sousai = value; }
            }
            /// <summary>
            /// 合計の取得・設定
            /// </summary>
            public decimal? Goukei
            {
                get { return goukei; }
                set { goukei = value; }
            }
            /// <summary>
            /// 締年月日の取得・設定
            /// </summary>
            public DateTime? ShimeNengapi
            {
                get { return shimeNengapi; }
                set { shimeNengapi = value; }
            }
            /// <summary>
            /// 締更新フラグの取得・設定
            /// </summary>
            public string ShimeKoushinHuragu
            {
                get { return shimeKoushinHuragu; }
                set { shimeKoushinHuragu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShiharaiFile()
            {
            }
            #endregion
        }
        #endregion

        #region 仕入ヘッダファイルレイアウト
        /// <summary>
        /// 仕入ヘッダファイルレイアウト
        /// </summary>
        public class ShireHeaderFile
        {
            #region 列情報
            /// <summary>
            /// 仕入NOの物理名
            /// </summary>
            public const string dcShireNo = "shireNo";
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            public const string dcDenpyoHizuke = "denpyoHizuke";
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 件名NOの物理名
            /// </summary>
            public const string dcKenmeiNo = "kenmeiNo";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 発注番号の物理名
            /// </summary>
            public const string dcHachuNo = "hachuNo";
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            public const string dcShiresakiCode = "shiresakiCode";
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            public const string dcShiresakiName = "shiresakiName";
            /// <summary>
            /// 売上伝票Noの物理名
            /// </summary>
            public const string dcUriageDenpyoNo = "uriageDenpyoNo";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 仕入NOの物理名
            /// </summary>
            private string shireNo = string.Empty;
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            private DateTime? denpyoHizuke = null;
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 件名NOの物理名
            /// </summary>
            private string kenmeiNo = string.Empty;
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 発注番号の物理名
            /// </summary>
            private string hachuNo = string.Empty;
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            private string shiresakiCode = string.Empty;
            /// <summary>
            /// 仕入先名の物理名
            /// </summary>
            private string shiresakiName = string.Empty;
            /// <summary>
            /// 売上伝票Noの物理名
            /// </summary>
            private string uriageDenpyoNo = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 仕入NOの取得・設定
            /// </summary>
            public string ShireNo
            {
                get { return shireNo; }
                set { shireNo = value; }
            }
            /// <summary>
            /// 伝票日付の取得・設定
            /// </summary>
            public DateTime? DenpyoHizuke
            {
                get { return denpyoHizuke; }
                set { denpyoHizuke = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 件名NOの取得・設定
            /// </summary>
            public string KenmeiNo
            {
                get { return kenmeiNo; }
                set { kenmeiNo = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 発注番号の取得・設定
            /// </summary>
            public string HachuNo
            {
                get { return hachuNo; }
                set { hachuNo = value; }
            }
            /// <summary>
            /// 仕入先コードの取得・設定
            /// </summary>
            public string ShiresakiCode
            {
                get { return shiresakiCode; }
                set { shiresakiCode = value; }
            }
            /// <summary>
            /// 仕入先名の取得・設定
            /// </summary>
            public string ShiresakiName
            {
                get { return shiresakiName; }
                set { shiresakiName = value; }
            }
            /// <summary>
            /// 売上伝票Noの取得・設定
            /// </summary>
            public string UriageDenpyoNo
            {
                get { return uriageDenpyoNo; }
                set { uriageDenpyoNo = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShireHeaderFile()
            {
            }
            #endregion
        }
        #endregion

        #region 仕入ボディファイルレイアウト
        /// <summary>
        /// 仕入ボディファイルレイアウト
        /// </summary>
        public class ShireBodyFile
        {
            #region 列情報
            /// <summary>
            /// 仕入番号の物理名
            /// </summary>
            public const string dcShireNo = "shireNo";
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            public const string dcRowNo = "rowNo";
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            public const string dcJuchuRowNo = "juchuRowNo";
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            public const string dcDaiBunruiCode = "daiBunruiCode";
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            public const string dcSyoBunruiCode = "syoBunruiCode";
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            public const string dcShouhinName1 = "shouhinName1";
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            public const string dcShouhinName2 = "shouhinName2";
            /// <summary>
            /// 数量の物理名
            /// </summary>
            public const string dcSuryo = "suryo";
            /// <summary>
            /// 単位の物理名
            /// </summary>
            public const string dcTani = "tani";
            /// <summary>
            /// 単価の物理名
            /// </summary>
            public const string dcTanka = "tanka";
            /// <summary>
            /// 金額の物理名
            /// </summary>
            public const string dcKingaku = "kingaku";
            /// <summary>
            /// 備考の物理名
            /// </summary>
            public const string dcBikou = "bikou";
            /// <summary>
            /// 締年月日の物理名
            /// </summary>
            public const string dcShimeNengapi = "shimeNengapi";
            /// <summary>
            /// 締更新フラグの物理名
            /// </summary>
            public const string dcShimeKoushinHuragu = "shimeKoushinHuragu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 仕入番号の物理名
            /// </summary>
            private string shireNo = string.Empty;
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            private int rowNo = 0;
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            private int juchuRowNo = 0;
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            private string daiBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            private string syoBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            private string shouhinName1 = string.Empty;
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            private string shouhinName2 = string.Empty;
            /// <summary>
            /// 数量の物理名
            /// </summary>
            private decimal? suryo = null;
            /// <summary>
            /// 単位の物理名
            /// </summary>
            private string tani = string.Empty;
            /// <summary>
            /// 単価の物理名
            /// </summary>
            private decimal? tanka = null;
            /// <summary>
            /// 金額の物理名
            /// </summary>
            private decimal? kingaku = null;
            /// <summary>
            /// 備考の物理名
            /// </summary>
            private string bikou = string.Empty;
            /// <summary>
            /// 締年月日の物理名
            /// </summary>
            private DateTime? shimeNengapi = null;
            /// <summary>
            /// 締更新フラグの物理名
            /// </summary>
            private string shimeKoushinHuragu = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 仕入番号の取得・設定
            /// </summary>
            public string ShireNo
            {
                get { return shireNo; }
                set { shireNo = value; }
            }
            /// <summary>
            /// 行番号の取得・設定
            /// </summary>
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            /// <summary>
            /// 受注行番号の取得・設定
            /// </summary>
            public int JuchuRowNo
            {
                get { return juchuRowNo; }
                set { juchuRowNo = value; }
            }
            /// <summary>
            /// 商品コード(大分類コード)の取得・設定
            /// </summary>
            public string DaiBunruiCode
            {
                get { return daiBunruiCode; }
                set { daiBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(小類コード)の取得・設定
            /// </summary>
            public string SyoBunruiCode
            {
                get { return syoBunruiCode; }
                set { syoBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(連番)の取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 商品名１の取得・設定
            /// </summary>
            public string ShouhinName1
            {
                get { return shouhinName1; }
                set { shouhinName1 = value; }
            }
            /// <summary>
            /// 商品名２の取得・設定
            /// </summary>
            public string ShouhinName2
            {
                get { return shouhinName2; }
                set { shouhinName2 = value; }
            }
            /// <summary>
            /// 数量の取得・設定
            /// </summary>
            public decimal? Suryo
            {
                get { return suryo; }
                set { suryo = value; }
            }
            /// <summary>
            /// 単位の取得・設定
            /// </summary>
            public string Tani
            {
                get { return tani; }
                set { tani = value; }
            }
            /// <summary>
            /// 単価の取得・設定
            /// </summary>
            public decimal? Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 金額の取得・設定
            /// </summary>
            public decimal? Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }
            /// <summary>
            /// 備考の取得・設定
            /// </summary>
            public string Bikou
            {
                get { return bikou; }
                set { bikou = value; }
            }
            /// <summary>
            /// 締年月日の取得・設定
            /// </summary>
            public DateTime? ShimeNengapi
            {
                get { return shimeNengapi; }
                set { shimeNengapi = value; }
            }
            /// <summary>
            /// 締更新フラグの取得・設定
            /// </summary>
            public string ShimeKoushinHuragu
            {
                get { return shimeKoushinHuragu; }
                set { shimeKoushinHuragu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShireBodyFile()
            {
            }
            #endregion
        }
        #endregion

        #region 仕入フッタファイルレイアウト
        /// <summary>
        /// 仕入フッタファイルレイアウト
        /// </summary>
        public class ShireFooterFile
        {
            #region 列情報
            /// <summary>
            /// 仕入番号の物理名
            /// </summary>
            public const string dcShireNo = "shireNo";
            /// <summary>
            /// 仕入金額の物理名
            /// </summary>
            public const string dcShireKingaku = "shireKingaku";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 仕入番号の物理名
            /// </summary>
            private string shireNo = string.Empty;
            /// <summary>
            /// 仕入金額の物理名
            /// </summary>
            private decimal? shireKingaku = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 仕入番号の取得・設定
            /// </summary>
            public string ShireNo
            {
                get { return shireNo; }
                set { shireNo = value; }
            }
            /// <summary>
            /// 仕入金額の取得・設定
            /// </summary>
            public decimal? ShireKingaku
            {
                get { return shireKingaku; }
                set { shireKingaku = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShireFooterFile()
            {
            }
            #endregion
        }
        #endregion

        #region 仕入先別買掛ファイルレイアウト
        /// <summary>
        /// 仕入先別買掛ファイルレイアウト
        /// </summary>
        public class ShiresakiKaikakeFile
        {
            #region 列情報
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            public const string dcShiresakiCode = "shiresakiCode";
            /// <summary>
            /// 年度の物理名
            /// </summary>
            public const string dcNendo = "nendo";
            /// <summary>
            /// (月別買掛残)前年繰越の物理名
            /// </summary>
            public const string dcZenNenKurikoshi = "zenNenKurikoshi";
            /// <summary>
            /// (月別買掛残)10月仕入の物理名
            /// </summary>
            public const string dc10GatsuShire = "10GatsuShire";
            /// <summary>
            /// (月別買掛残)10月消費税の物理名
            /// </summary>
            public const string dc10GatsuSyouhiZei = "10GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)10月支払の物理名
            /// </summary>
            public const string dc10GatsuShiharai = "10GatsuShiharai";
            /// <summary>
            /// (月別買掛残)10月繰越の物理名
            /// </summary>
            public const string dc10GatsuKurikoshi = "10GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)11月仕入の物理名
            /// </summary>
            public const string dc11GatsuShire = "11GatsuShire";
            /// <summary>
            /// (月別買掛残)11月消費税の物理名
            /// </summary>
            public const string dc11GatsuSyouhiZei = "11GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)11月支払の物理名
            /// </summary>
            public const string dc11GatsuShiharai = "11GatsuShiharai";
            /// <summary>
            /// (月別買掛残)11月繰越の物理名
            /// </summary>
            public const string dc11GatsuKurikoshi = "11GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)12月仕入の物理名
            /// </summary>
            public const string dc12GatsuShire = "12GatsuShire";
            /// <summary>
            /// (月別買掛残)12月消費税の物理名
            /// </summary>
            public const string dc12GatsuSyouhiZei = "12GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)12月支払の物理名
            /// </summary>
            public const string dc12GatsuShiharai = "12GatsuShiharai";
            /// <summary>
            /// (月別買掛残)12月繰越の物理名
            /// </summary>
            public const string dc12GatsuKurikoshi = "12GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)1月仕入の物理名
            /// </summary>
            public const string dc1GatsuShire = "1GatsuShire";
            /// <summary>
            /// (月別買掛残)1月消費税の物理名
            /// </summary>
            public const string dc1GatsuSyouhiZei = "1GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)1月支払の物理名
            /// </summary>
            public const string dc1GatsuShiharai = "1GatsuShiharai";
            /// <summary>
            /// (月別買掛残)1月繰越の物理名
            /// </summary>
            public const string dc1GatsuKurikoshi = "1GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)2月仕入の物理名
            /// </summary>
            public const string dc2GatsuShire = "2GatsuShire";
            /// <summary>
            /// (月別買掛残)2月消費税の物理名
            /// </summary>
            public const string dc2GatsuSyouhiZei = "2GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)2月支払の物理名
            /// </summary>
            public const string dc2GatsuShiharai = "2GatsuShiharai";
            /// <summary>
            /// (月別買掛残)2月繰越の物理名
            /// </summary>
            public const string dc2GatsuKurikoshi = "2GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)3月仕入の物理名
            /// </summary>
            public const string dc3GatsuShire = "3GatsuShire";
            /// <summary>
            /// (月別買掛残)3月消費税の物理名
            /// </summary>
            public const string dc3GatsuSyouhiZei = "3GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)3月支払の物理名
            /// </summary>
            public const string dc3GatsuShiharai = "3GatsuShiharai";
            /// <summary>
            /// (月別買掛残)3月繰越の物理名
            /// </summary>
            public const string dc3GatsuKurikoshi = "3GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)4月仕入の物理名
            /// </summary>
            public const string dc4GatsuShire = "4GatsuShire";
            /// <summary>
            /// (月別買掛残)4月消費税の物理名
            /// </summary>
            public const string dc4GatsuSyouhiZei = "4GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)4月支払の物理名
            /// </summary>
            public const string dc4GatsuShiharai = "4GatsuShiharai";
            /// <summary>
            /// (月別買掛残)4月繰越の物理名
            /// </summary>
            public const string dc4GatsuKurikoshi = "4GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)5月仕入の物理名
            /// </summary>
            public const string dc5GatsuShire = "5GatsuShire";
            /// <summary>
            /// (月別買掛残)5月消費税の物理名
            /// </summary>
            public const string dc5GatsuSyouhiZei = "5GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)5月支払の物理名
            /// </summary>
            public const string dc5GatsuShiharai = "5GatsuShiharai";
            /// <summary>
            /// (月別買掛残)5月繰越の物理名
            /// </summary>
            public const string dc5GatsuKurikoshi = "5GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)6月仕入の物理名
            /// </summary>
            public const string dc6GatsuShire = "6GatsuShire";
            /// <summary>
            /// (月別買掛残)6月消費税の物理名
            /// </summary>
            public const string dc6GatsuSyouhiZei = "6GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)6月支払の物理名
            /// </summary>
            public const string dc6GatsuShiharai = "6GatsuShiharai";
            /// <summary>
            /// (月別買掛残)6月繰越の物理名
            /// </summary>
            public const string dc6GatsuKurikoshi = "6GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)7月仕入の物理名
            /// </summary>
            public const string dc7GatsuShire = "7GatsuShire";
            /// <summary>
            /// (月別買掛残)7月消費税の物理名
            /// </summary>
            public const string dc7GatsuSyouhiZei = "7GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)7月支払の物理名
            /// </summary>
            public const string dc7GatsuShiharai = "7GatsuShiharai";
            /// <summary>
            /// (月別買掛残)7月繰越の物理名
            /// </summary>
            public const string dc7GatsuKurikoshi = "7GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)8月仕入の物理名
            /// </summary>
            public const string dc8GatsuShire = "8GatsuShire";
            /// <summary>
            /// (月別買掛残)8月消費税の物理名
            /// </summary>
            public const string dc8GatsuSyouhiZei = "8GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)8月支払の物理名
            /// </summary>
            public const string dc8GatsuShiharai = "8GatsuShiharai";
            /// <summary>
            /// (月別買掛残)8月繰越の物理名
            /// </summary>
            public const string dc8GatsuKurikoshi = "8GatsuKurikoshi";
            /// <summary>
            /// (月別買掛残)9月仕入の物理名
            /// </summary>
            public const string dc9GatsuShire = "9GatsuShire";
            /// <summary>
            /// (月別買掛残)9月消費税の物理名
            /// </summary>
            public const string dc9GatsuSyouhiZei = "9GatsuSyouhiZei";
            /// <summary>
            /// (月別買掛残)9月支払の物理名
            /// </summary>
            public const string dc9GatsuShiharai = "9GatsuShiharai";
            /// <summary>
            /// (月別買掛残)9月繰越の物理名
            /// </summary>
            public const string dc9GatsuKurikoshi = "9GatsuKurikoshi";
            /// <summary>
            /// (請求買掛残)前々々回繰越の物理名
            /// </summary>
            public const string dc3TsukiMaeKurikoshi = "3TsukiMaeKurikoshi";
            /// <summary>
            /// (請求買掛残)前々回現金の物理名
            /// </summary>
            public const string dc2TsukiMaeGenkin = "2TsukiMaeGenkin";
            /// <summary>
            /// (請求買掛残)前々回手形の物理名
            /// </summary>
            public const string dc2TsukiMaeTegata = "2TsukiMaeTegata";
            /// <summary>
            /// (請求買掛残)前々回振込の物理名
            /// </summary>
            public const string dc2TsukiMaeHurikomi = "2TsukiMaeHurikomi";
            /// <summary>
            /// (請求買掛残)前々回相殺の物理名
            /// </summary>
            public const string dc2TsukiMaeSousai = "2TsukiMaeSousai";
            /// <summary>
            /// (請求買掛残)前々回仕入の物理名
            /// </summary>
            public const string dc2TsukiMaeShire = "2TsukiMaeShire";
            /// <summary>
            /// (請求買掛残)前々回繰越の物理名
            /// </summary>
            public const string dc2TsukiMaeKurikoshi = "2TsukiMaeKurikoshi";
            /// <summary>
            /// (請求買掛残)前回現金の物理名
            /// </summary>
            public const string dc1TsukiMaeGenkin = "1TsukiMaeGenkin";
            /// <summary>
            /// (請求買掛残)前回手形の物理名
            /// </summary>
            public const string dc1TsukiMaeTegata = "1TsukiMaeTegata";
            /// <summary>
            /// (請求買掛残)前回振込の物理名
            /// </summary>
            public const string dc1TsukiMaeHurikomi = "1TsukiMaeHurikomi";
            /// <summary>
            /// (請求買掛残)前回相殺の物理名
            /// </summary>
            public const string dc1TsukiMaeSousai = "1TsukiMaeSousai";
            /// <summary>
            /// (請求買掛残)前回仕入の物理名
            /// </summary>
            public const string dc1TsukiMaeShire = "1TsukiMaeShire";
            /// <summary>
            /// (請求買掛残)前回繰越の物理名
            /// </summary>
            public const string dc1TsukiMaeKurikoshi = "1TsukiMaeKurikoshi";
            /// <summary>
            /// (請求買掛残)今回現金の物理名
            /// </summary>
            public const string dcTougetsuGenkin = "tougetsuGenkin";
            /// <summary>
            /// (請求買掛残)今回手形の物理名
            /// </summary>
            public const string dcTougetsuTegata = "tougetsuTegata";
            /// <summary>
            /// (請求買掛残)今回振込の物理名
            /// </summary>
            public const string dcTougetsuHurikomi = "tougetsuHurikomi";
            /// <summary>
            /// (請求買掛残)今回相殺の物理名
            /// </summary>
            public const string dcTougetsuSousai = "tougetsuSousai";
            /// <summary>
            /// (請求買掛残)今回仕入の物理名
            /// </summary>
            public const string dcTougetsuShire = "tougetsuShire";
            /// <summary>
            /// (請求買掛残)今回繰越の物理名
            /// </summary>
            public const string dcTougetsuKurikoshi = "tougetsuKurikoshi";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 仕入先コードの物理名
            /// </summary>
            private string shiresakiCode = string.Empty;
            /// <summary>
            /// 年度の物理名
            /// </summary>
            private string nendo = string.Empty;
            /// <summary>
            /// (月別買掛残)前年繰越の物理名
            /// </summary>
            private decimal? zenNenKurikoshi = null;
            /// <summary>
            /// (月別買掛残)10月仕入の物理名
            /// </summary>
            private decimal? dec10GatsuShire = null;
            /// <summary>
            /// (月別買掛残)10月消費税の物理名
            /// </summary>
            private decimal? dec10GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)10月支払の物理名
            /// </summary>
            private decimal? dec10GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)10月繰越の物理名
            /// </summary>
            private decimal? dec10GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)11月仕入の物理名
            /// </summary>
            private decimal? dec11GatsuShire = null;
            /// <summary>
            /// (月別買掛残)11月消費税の物理名
            /// </summary>
            private decimal? dec11GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)11月支払の物理名
            /// </summary>
            private decimal? dec11GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)11月繰越の物理名
            /// </summary>
            private decimal? dec11GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)12月仕入の物理名
            /// </summary>
            private decimal? dec12GatsuShire = null;
            /// <summary>
            /// (月別買掛残)12月消費税の物理名
            /// </summary>
            private decimal? dec12GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)12月支払の物理名
            /// </summary>
            private decimal? dec12GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)12月繰越の物理名
            /// </summary>
            private decimal? dec12GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)1月仕入の物理名
            /// </summary>
            private decimal? dec1GatsuShire = null;
            /// <summary>
            /// (月別買掛残)1月消費税の物理名
            /// </summary>
            private decimal? dec1GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)1月支払の物理名
            /// </summary>
            private decimal? dec1GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)1月繰越の物理名
            /// </summary>
            private decimal? dec1GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)2月仕入の物理名
            /// </summary>
            private decimal? dec2GatsuShire = null;
            /// <summary>
            /// (月別買掛残)2月消費税の物理名
            /// </summary>
            private decimal? dec2GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)2月支払の物理名
            /// </summary>
            private decimal? dec2GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)2月繰越の物理名
            /// </summary>
            private decimal? dec2GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)3月仕入の物理名
            /// </summary>
            private decimal? dec3GatsuShire = null;
            /// <summary>
            /// (月別買掛残)3月消費税の物理名
            /// </summary>
            private decimal? dec3GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)3月支払の物理名
            /// </summary>
            private decimal? dec3GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)3月繰越の物理名
            /// </summary>
            private decimal? dec3GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)4月仕入の物理名
            /// </summary>
            private decimal? dec4GatsuShire = null;
            /// <summary>
            /// (月別買掛残)4月消費税の物理名
            /// </summary>
            private decimal? dec4GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)4月支払の物理名
            /// </summary>
            private decimal? dec4GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)4月繰越の物理名
            /// </summary>
            private decimal? dec4GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)5月仕入の物理名
            /// </summary>
            private decimal? dec5GatsuShire = null;
            /// <summary>
            /// (月別買掛残)5月消費税の物理名
            /// </summary>
            private decimal? dec5GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)5月支払の物理名
            /// </summary>
            private decimal? dec5GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)5月繰越の物理名
            /// </summary>
            private decimal? dec5GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)6月仕入の物理名
            /// </summary>
            private decimal? dec6GatsuShire = null;
            /// <summary>
            /// (月別買掛残)6月消費税の物理名
            /// </summary>
            private decimal? dec6GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)6月支払の物理名
            /// </summary>
            private decimal? dec6GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)6月繰越の物理名
            /// </summary>
            private decimal? dec6GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)7月仕入の物理名
            /// </summary>
            private decimal? dec7GatsuShire = null;
            /// <summary>
            /// (月別買掛残)7月消費税の物理名
            /// </summary>
            private decimal? dec7GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)7月支払の物理名
            /// </summary>
            private decimal? dec7GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)7月繰越の物理名
            /// </summary>
            private decimal? dec7GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)8月仕入の物理名
            /// </summary>
            private decimal? dec8GatsuShire = null;
            /// <summary>
            /// (月別買掛残)8月消費税の物理名
            /// </summary>
            private decimal? dec8GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)8月支払の物理名
            /// </summary>
            private decimal? dec8GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)8月繰越の物理名
            /// </summary>
            private decimal? dec8GatsuKurikoshi = null;
            /// <summary>
            /// (月別買掛残)9月仕入の物理名
            /// </summary>
            private decimal? dec9GatsuShire = null;
            /// <summary>
            /// (月別買掛残)9月消費税の物理名
            /// </summary>
            private decimal? dec9GatsuSyouhiZei = null;
            /// <summary>
            /// (月別買掛残)9月支払の物理名
            /// </summary>
            private decimal? dec9GatsuShiharai = null;
            /// <summary>
            /// (月別買掛残)9月繰越の物理名
            /// </summary>
            private decimal? dec9GatsuKurikoshi = null;
            /// <summary>
            /// (請求買掛残)前々々回繰越の物理名
            /// </summary>
            private decimal? dec3TsukiMaeKurikoshi = null;
                            /// <summary>
            /// (請求買掛残)前々回現金の物理名
            /// </summary>
            private decimal? dec2TsukiMaeGenkin = null;
            /// <summary>
            /// (請求買掛残)前々回手形の物理名
            /// </summary>
            private decimal? dec2TsukiMaeTegata = null;
            /// <summary>
            /// (請求買掛残)前々回振込の物理名
            /// </summary>
            private decimal? dec2TsukiMaeHurikomi = null;
            /// <summary>
            /// (請求買掛残)前々回相殺の物理名
            /// </summary>
            private decimal? dec2TsukiMaeSousai = null;
            /// <summary>
            /// (請求買掛残)前々回仕入の物理名
            /// </summary>
            private decimal? dec2TsukiMaeShire = null;
            /// <summary>
            /// (請求買掛残)前々回繰越の物理名
            /// </summary>
            private decimal? dec2TsukiMaeKurikoshi = null;
            /// <summary>
            /// (請求買掛残)前回現金の物理名
            /// </summary>
            private decimal? dec1TsukiMaeGenkin = null;
            /// <summary>
            /// (請求買掛残)前回手形の物理名
            /// </summary>
            private decimal? dec1TsukiMaeTegata = null;
            /// <summary>
            /// (請求買掛残)前回振込の物理名
            /// </summary>
            private decimal? dec1TsukiMaeHurikomi = null;
            /// <summary>
            /// (請求買掛残)前回相殺の物理名
            /// </summary>
            private decimal? dec1TsukiMaeSousai = null;
            /// <summary>
            /// (請求買掛残)前回仕入の物理名
            /// </summary>
            private decimal? dec1TsukiMaeShire = null;
            /// <summary>
            /// (請求買掛残)前回繰越の物理名
            /// </summary>
            private decimal? dec1TsukiMaeKurikoshi = null;
            /// <summary>
            /// (請求買掛残)今回現金の物理名
            /// </summary>
            private decimal? decTougetsuGenkin = null;
            /// <summary>
            /// (請求買掛残)今回手形の物理名
            /// </summary>
            private decimal? decTougetsuTegata = null;
            /// <summary>
            /// (請求買掛残)今回振込の物理名
            /// </summary>
            private decimal? decTougetsuHurikomi = null;
            /// <summary>
            /// (請求買掛残)今回相殺の物理名
            /// </summary>
            private decimal? decTougetsuSousai = null;
            /// <summary>
            /// (請求買掛残)今回仕入の物理名
            /// </summary>
            private decimal? decTougetsuShire = null;
            /// <summary>
            /// (請求買掛残)今回繰越の物理名
            /// </summary>
            private decimal? decTougetsuKurikoshi = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 仕入先コードの取得・設定
            /// </summary>
            public string ShiresakiCode
            {
                get { return shiresakiCode; }
                set { shiresakiCode = value; }
            }
            /// <summary>
            /// 年度の取得・設定
            /// </summary>
            public string Nendo
            {
                get { return nendo; }
                set { nendo = value; }
            }
            /// <summary>
            /// (月別買掛残)前年繰越の取得・設定
            /// </summary>
            public decimal? ZenNenKurikoshi
            {
                get { return zenNenKurikoshi; }
                set { zenNenKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)10月仕入の取得・設定
            /// </summary>
            public decimal? Dec10GatsuShire
            {
                get { return dec10GatsuShire; }
                set { dec10GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)10月消費税の取得・設定
            /// </summary>
            public decimal? Dec10GatsuSyouhiZei
            {
                get { return dec10GatsuSyouhiZei; }
                set { dec10GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)10月支払の取得・設定
            /// </summary>
            public decimal? Dec10GatsuShiharai
            {
                get { return dec10GatsuShiharai; }
                set { dec10GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)10月繰越の取得・設定
            /// </summary>
            public decimal? Dec10GatsuKurikoshi
            {
                get { return dec10GatsuKurikoshi; }
                set { dec10GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)11月仕入の取得・設定
            /// </summary>
            public decimal? Dec11GatsuShire
            {
                get { return dec11GatsuShire; }
                set { dec11GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)11月消費税の取得・設定
            /// </summary>
            public decimal? Dec11GatsuSyouhiZei
            {
                get { return dec11GatsuSyouhiZei; }
                set { dec11GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)11月支払の取得・設定
            /// </summary>
            public decimal? Dec11GatsuShiharai
            {
                get { return dec11GatsuShiharai; }
                set { dec11GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)11月繰越の取得・設定
            /// </summary>
            public decimal? Dec11GatsuKurikoshi
            {
                get { return dec11GatsuKurikoshi; }
                set { dec11GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)12月仕入の取得・設定
            /// </summary>
            public decimal? Dec12GatsuShire
            {
                get { return dec12GatsuShire; }
                set { dec12GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)12月消費税の取得・設定
            /// </summary>
            public decimal? Dec12GatsuSyouhiZei
            {
                get { return dec12GatsuSyouhiZei; }
                set { dec12GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)12月支払の取得・設定
            /// </summary>
            public decimal? Dec12GatsuShiharai
            {
                get { return dec12GatsuShiharai; }
                set { dec12GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)12月繰越の取得・設定
            /// </summary>
            public decimal? Dec12GatsuKurikoshi
            {
                get { return dec12GatsuKurikoshi; }
                set { dec12GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)1月仕入の取得・設定
            /// </summary>
            public decimal? Dec1GatsuShire
            {
                get { return dec1GatsuShire; }
                set { dec1GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)1月消費税の取得・設定
            /// </summary>
            public decimal? Dec1GatsuSyouhiZei
            {
                get { return dec1GatsuSyouhiZei; }
                set { dec1GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)1月支払の取得・設定
            /// </summary>
            public decimal? Dec1GatsuShiharai
            {
                get { return dec1GatsuShiharai; }
                set { dec1GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)1月繰越の取得・設定
            /// </summary>
            public decimal? Dec1GatsuKurikoshi
            {
                get { return dec1GatsuKurikoshi; }
                set { dec1GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)2月仕入の取得・設定
            /// </summary>
            public decimal? Dec2GatsuShire
            {
                get { return dec2GatsuShire; }
                set { dec2GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)2月消費税の取得・設定
            /// </summary>
            public decimal? Dec2GatsuSyouhiZei
            {
                get { return dec2GatsuSyouhiZei; }
                set { dec2GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)2月支払の取得・設定
            /// </summary>
            public decimal? Dec2GatsuShiharai
            {
                get { return dec2GatsuShiharai; }
                set { dec2GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)2月繰越の取得・設定
            /// </summary>
            public decimal? Dec2GatsuKurikoshi
            {
                get { return dec2GatsuKurikoshi; }
                set { dec2GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)3月仕入の取得・設定
            /// </summary>
            public decimal? Dec3GatsuShire
            {
                get { return dec3GatsuShire; }
                set { dec3GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)3月消費税の取得・設定
            /// </summary>
            public decimal? Dec3GatsuSyouhiZei
            {
                get { return dec3GatsuSyouhiZei; }
                set { dec3GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)3月支払の取得・設定
            /// </summary>
            public decimal? Dec3GatsuShiharai
            {
                get { return dec3GatsuShiharai; }
                set { dec3GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)3月繰越の取得・設定
            /// </summary>
            public decimal? Dec3GatsuKurikoshi
            {
                get { return dec3GatsuKurikoshi; }
                set { dec3GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)4月仕入の取得・設定
            /// </summary>
            public decimal? Dec4GatsuShire
            {
                get { return dec4GatsuShire; }
                set { dec4GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)4月消費税の取得・設定
            /// </summary>
            public decimal? Dec4GatsuSyouhiZei
            {
                get { return dec4GatsuSyouhiZei; }
                set { dec4GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)4月支払の取得・設定
            /// </summary>
            public decimal? Dec4GatsuShiharai
            {
                get { return dec4GatsuShiharai; }
                set { dec4GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)4月繰越の取得・設定
            /// </summary>
            public decimal? Dec4GatsuKurikoshi
            {
                get { return dec4GatsuKurikoshi; }
                set { dec4GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)5月仕入の取得・設定
            /// </summary>
            public decimal? Dec5GatsuShire
            {
                get { return dec5GatsuShire; }
                set { dec5GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)5月消費税の取得・設定
            /// </summary>
            public decimal? Dec5GatsuSyouhiZei
            {
                get { return dec5GatsuSyouhiZei; }
                set { dec5GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)5月支払の取得・設定
            /// </summary>
            public decimal? Dec5GatsuShiharai
            {
                get { return dec5GatsuShiharai; }
                set { dec5GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)5月繰越の取得・設定
            /// </summary>
            public decimal? Dec5GatsuKurikoshi
            {
                get { return dec5GatsuKurikoshi; }
                set { dec5GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)6月仕入の取得・設定
            /// </summary>
            public decimal? Dec6GatsuShire
            {
                get { return dec6GatsuShire; }
                set { dec6GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)6月消費税の取得・設定
            /// </summary>
            public decimal? Dec6GatsuSyouhiZei
            {
                get { return dec6GatsuSyouhiZei; }
                set { dec6GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)6月支払の取得・設定
            /// </summary>
            public decimal? Dec6GatsuShiharai
            {
                get { return dec6GatsuShiharai; }
                set { dec6GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)6月繰越の取得・設定
            /// </summary>
            public decimal? Dec6GatsuKurikoshi
            {
                get { return dec6GatsuKurikoshi; }
                set { dec6GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)7月仕入の取得・設定
            /// </summary>
            public decimal? Dec7GatsuShire
            {
                get { return dec7GatsuShire; }
                set { dec7GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)7月消費税の取得・設定
            /// </summary>
            public decimal? Dec7GatsuSyouhiZei
            {
                get { return dec7GatsuSyouhiZei; }
                set { dec7GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)7月支払の取得・設定
            /// </summary>
            public decimal? Dec7GatsuShiharai
            {
                get { return dec7GatsuShiharai; }
                set { dec7GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)7月繰越の取得・設定
            /// </summary>
            public decimal? Dec7GatsuKurikoshi
            {
                get { return dec7GatsuKurikoshi; }
                set { dec7GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)8月仕入の取得・設定
            /// </summary>
            public decimal? Dec8GatsuShire
            {
                get { return dec8GatsuShire; }
                set { dec8GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)8月消費税の取得・設定
            /// </summary>
            public decimal? Dec8GatsuSyouhiZei
            {
                get { return dec8GatsuSyouhiZei; }
                set { dec8GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)8月支払の取得・設定
            /// </summary>
            public decimal? Dec8GatsuShiharai
            {
                get { return dec8GatsuShiharai; }
                set { dec8GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)8月繰越の取得・設定
            /// </summary>
            public decimal? Dec8GatsuKurikoshi
            {
                get { return dec8GatsuKurikoshi; }
                set { dec8GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (月別買掛残)9月仕入の取得・設定
            /// </summary>
            public decimal? Dec9GatsuShire
            {
                get { return dec9GatsuShire; }
                set { dec9GatsuShire = value; }
            }
            /// <summary>
            /// (月別買掛残)9月消費税の取得・設定
            /// </summary>
            public decimal? Dec9GatsuSyouhiZei
            {
                get { return dec9GatsuSyouhiZei; }
                set { dec9GatsuSyouhiZei = value; }
            }
            /// <summary>
            /// (月別買掛残)9月支払の取得・設定
            /// </summary>
            public decimal? Dec9GatsuShiharai
            {
                get { return dec9GatsuShiharai; }
                set { dec9GatsuShiharai = value; }
            }
            /// <summary>
            /// (月別買掛残)9月繰越の取得・設定
            /// </summary>
            public decimal? Dec9GatsuKurikoshi
            {
                get { return dec9GatsuKurikoshi; }
                set { dec9GatsuKurikoshi = value; }
            }
            /// <summary>
            /// (請求買掛残)前々々回繰越の取得・設定
            /// </summary>
            public decimal? Dec3TsukiMaeKurikoshi
            {
                get { return dec3TsukiMaeKurikoshi; }
                set { dec3TsukiMaeKurikoshi = value; }
            }
            /// <summary>
            /// (請求買掛残)前々回現金の取得・設定
            /// </summary>
            public decimal? Dec2TsukiMaeGenkin
            {
                get { return dec2TsukiMaeGenkin; }
                set { dec2TsukiMaeGenkin = value; }
            }
            /// <summary>
            /// (請求買掛残)前々回手形の取得・設定
            /// </summary>
            public decimal? Dec2TsukiMaeTegata
            {
                get { return dec2TsukiMaeTegata; }
                set { dec2TsukiMaeTegata = value; }
            }
            /// <summary>
            /// (請求買掛残)前々回振込の取得・設定
            /// </summary>
            public decimal? Dec2TsukiMaeHurikomi
            {
                get { return dec2TsukiMaeHurikomi; }
                set { dec2TsukiMaeHurikomi = value; }
            }
            /// <summary>
            /// (請求買掛残)前々回相殺の取得・設定
            /// </summary>
            public decimal? Dec2TsukiMaeSousai
            {
                get { return dec2TsukiMaeSousai; }
                set { dec2TsukiMaeSousai = value; }
            }
            /// <summary>
            /// (請求買掛残)前々回仕入の取得・設定
            /// </summary>
            public decimal? Dec2TsukiMaeShire
            {
                get { return dec2TsukiMaeShire; }
                set { dec2TsukiMaeShire = value; }
            }
            /// <summary>
            /// (請求買掛残)前々回繰越の取得・設定
            /// </summary>
            public decimal? Dec2TsukiMaeKurikoshi
            {
                get { return dec2TsukiMaeKurikoshi; }
                set { dec2TsukiMaeKurikoshi = value; }
            }
            /// <summary>
            /// (請求買掛残)前回現金の取得・設定
            /// </summary>
            public decimal? Dec1TsukiMaeGenkin
            {
                get { return dec1TsukiMaeGenkin; }
                set { dec1TsukiMaeGenkin = value; }
            }
            /// <summary>
            /// (請求買掛残)前回手形の取得・設定
            /// </summary>
            public decimal? Dec1TsukiMaeTegata
            {
                get { return dec1TsukiMaeTegata; }
                set { dec1TsukiMaeTegata = value; }
            }
            /// <summary>
            /// (請求買掛残)前回振込の取得・設定
            /// </summary>
            public decimal? Dec1TsukiMaeHurikomi
            {
                get { return dec1TsukiMaeHurikomi; }
                set { dec1TsukiMaeHurikomi = value; }
            }
            /// <summary>
            /// (請求買掛残)前回相殺の取得・設定
            /// </summary>
            public decimal? Dec1TsukiMaeSousai
            {
                get { return dec1TsukiMaeSousai; }
                set { dec1TsukiMaeSousai = value; }
            }
            /// <summary>
            /// (請求買掛残)前回仕入の取得・設定
            /// </summary>
            public decimal? Dec1TsukiMaeShire
            {
                get { return dec1TsukiMaeShire; }
                set { dec1TsukiMaeShire = value; }
            }
            /// <summary>
            /// (請求買掛残)前回繰越の取得・設定
            /// </summary>
            public decimal? Dec1TsukiMaeKurikoshi
            {
                get { return dec1TsukiMaeKurikoshi; }
                set { dec1TsukiMaeKurikoshi = value; }
            }
            /// <summary>
            /// (請求買掛残)今回現金の取得・設定
            /// </summary>
            public decimal? DecTougetsuGenkin
            {
                get { return decTougetsuGenkin; }
                set { decTougetsuGenkin = value; }
            }
            /// <summary>
            /// (請求買掛残)今回手形の取得・設定
            /// </summary>
            public decimal? DecTougetsuTegata
            {
                get { return decTougetsuTegata; }
                set { decTougetsuTegata = value; }
            }
            /// <summary>
            /// (請求買掛残)今回振込の取得・設定
            /// </summary>
            public decimal? DecTougetsuHurikomi
            {
                get { return decTougetsuHurikomi; }
                set { decTougetsuHurikomi = value; }
            }
            /// <summary>
            /// (請求買掛残)今回相殺の取得・設定
            /// </summary>
            public decimal? DecTougetsuSousai
            {
                get { return decTougetsuSousai; }
                set { decTougetsuSousai = value; }
            }
            /// <summary>
            /// (請求買掛残)今回仕入の取得・設定
            /// </summary>
            public decimal? DecTougetsuShire
            {
                get { return decTougetsuShire; }
                set { decTougetsuShire = value; }
            }
            /// <summary>
            /// (請求買掛残)今回繰越の取得・設定
            /// </summary>
            public decimal? DecTougetsuKurikoshi
            {
                get { return decTougetsuKurikoshi; }
                set { decTougetsuKurikoshi = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShiresakiKaikakeFile()
            {
            }
            #endregion
        }
        #endregion

        #region 得意先別請求管理ファイルレイアウト
        /// <summary>
        /// 得意先別請求管理ファイルレイアウト
        /// </summary>
        public class TokuisakiSeikyuFile
        {
            #region 列情報
            /// <summary>
            /// 請求Noの物理名
            /// </summary>
            public const string dcSeikyuNo = "seikyuNo";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 請求日の物理名
            /// </summary>
            public const string dcSeikyubi = "seikyubi";
            /// <summary>
            /// 締年月の物理名
            /// </summary>
            public const string dcShimeNengetu = "shimeNengetu";
            /// <summary>
            /// 前月請求額の物理名
            /// </summary>
            public const string dcZengetsuSeikyu = "zengetsuSeikyu";
            /// <summary>
            /// ご入金額の物理名
            /// </summary>
            public const string dcNyukin = "nyukin";
            /// <summary>
            /// 繰越額の物理名
            /// </summary>
            public const string dcKurikosi = "kurikosi";
            /// <summary>
            /// 当月税抜お買い上げ額の物理名
            /// </summary>
            public const string dcZeinukiUriage = "zeinukiUriage";
            /// <summary>
            /// 消費税額等の物理名
            /// </summary>
            public const string dcSyouhizei = "syouhizei";
            /// <summary>
            /// 当月税込請求の物理名
            /// </summary>
            public const string dcZeikomiSeikyu = "zeikomiSeikyu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 請求日の物理名
            /// </summary>
            private DateTime? seikyubi = null;
            /// <summary>
            /// 締年月の物理名
            /// </summary>
            private string shimeNengetu = string.Empty;
            /// <summary>
            /// 前月請求額の物理名
            /// </summary>
            private decimal? zengetsuSeikyu = null;
            /// <summary>
            /// ご入金額の物理名
            /// </summary>
            private decimal? nyukin = null;
            /// <summary>
            /// 繰越額の物理名
            /// </summary>
            private decimal? kurikosi = null;
            /// <summary>
            /// 当月税抜お買い上げ額の物理名
            /// </summary>
            private decimal? zeinukiUriage = null;
            /// <summary>
            /// 消費税額等の物理名
            /// </summary>
            private decimal? syouhizei = null;
            /// <summary>
            /// 当月税込請求の物理名
            /// </summary>
            private decimal? zeikomiSeikyu = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 請求日の取得・設定
            /// </summary>
            public DateTime? Seikyubi
            {
                get { return seikyubi; }
                set { seikyubi = value; }
            }
            /// <summary>
            /// 締年月の取得・設定
            /// </summary>
            public string ShimeNengetu
            {
                get { return shimeNengetu; }
                set { shimeNengetu = value; }
            }
            /// <summary>
            /// 前月請求額の取得・設定
            /// </summary>
            public decimal? ZengetsuSeikyu
            {
                get { return zengetsuSeikyu; }
                set { zengetsuSeikyu = value; }
            }
            /// <summary>
            /// ご入金額の取得・設定
            /// </summary>
            public decimal? Nyukin
            {
                get { return nyukin; }
                set { nyukin = value; }
            }
            /// <summary>
            /// 繰越額の取得・設定
            /// </summary>
            public decimal? Kurikosi
            {
                get { return kurikosi; }
                set { kurikosi = value; }
            }
            /// <summary>
            /// 当月税抜お買い上げ額の取得・設定
            /// </summary>
            public decimal? ZeinukiUriage
            {
                get { return zeinukiUriage; }
                set { zeinukiUriage = value; }
            }
            /// <summary>
            /// 消費税額等の取得・設定
            /// </summary>
            public decimal? Syouhizei
            {
                get { return syouhizei; }
                set { syouhizei = value; }
            }
            /// <summary>
            /// 当月税込請求の取得・設定
            /// </summary>
            public decimal? ZeikomiSeikyu
            {
                get { return zeikomiSeikyu; }
                set { zeikomiSeikyu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public TokuisakiSeikyuFile()
            {
            }
            #endregion
        }
        #endregion

        #region 売上ヘッダファイルレイアウト
        /// <summary>
        /// 売上ヘッダファイルレイアウト
        /// </summary>
        public class UriageHeaderFile
        {
            #region 列情報
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 伝票日付の物理名
            /// </summary>
            public const string dcDenpyoHizuke = "denpyoHizuke";
            /// <summary>
            /// 受注NO(担当者コード)の物理名
            /// </summary>
            public const string dcJuchuNoTop = "juchuNoTop";
            /// <summary>
            /// 受注NO(月)の物理名
            /// </summary>
            public const string dcJuchuNoMid = "juchuNoMid";
            /// <summary>
            /// 受注NO(担当者毎受注No)の物理名
            /// </summary>
            public const string dcJuchuNoBtm = "juchuNoBtm";
            /// <summary>
            /// 地方コードの物理名
            /// </summary>
            public const string dcChihouCode = "chihouCode";
            /// <summary>
            /// 地区コードの物理名
            /// </summary>
            public const string dcChikuCode = "chikuCode";
            /// <summary>
            /// 得意先コードの物理名
            /// </summary>
            public const string dcTokuisakiCode = "tokuisakiCode";
            /// <summary>
            /// 得意先名の物理名
            /// </summary>
            public const string dcTokuisakiName = "tokuisakiName";
            /// <summary>
            /// 得意先名カナの物理名
            /// </summary>
            public const string dcTokuisakiKanaName = "tokuisakiKanaName";
            /// <summary>
            /// 事業所コードの物理名
            /// </summary>
            public const string dcJigyousyoCode = "jigyousyoCode";
            /// <summary>
            /// 事業所名の物理名
            /// </summary>
            public const string dcJigyousyoName = "jigyousyoName";
            /// <summary>
            /// 得意先担当者名の物理名
            /// </summary>
            public const string dcTokuisakiTantousayName = "tokuisakiTantousayName";
            /// <summary>
            /// 郵便番号の物理名
            /// </summary>
            public const string dcZipCode = "zipCode";
            /// <summary>
            /// 住所１の物理名
            /// </summary>
            public const string dcAddres1 = "addres1";
            /// <summary>
            /// 住所２の物理名
            /// </summary>
            public const string dcAddres2 = "addres2";
            /// <summary>
            /// 担当者コードの物理名
            /// </summary>
            public const string dcTantousyaCode = "tantousyaCode";
            /// <summary>
            /// 担当者名の物理名
            /// </summary>
            public const string dcTantousyaName = "tantousyaName";
            /// <summary>
            /// 件名番号の物理名
            /// </summary>
            public const string dcKenmeiNo = "kenmeiNo";
            /// <summary>
            /// 件名１の物理名
            /// </summary>
            public const string dcKenmei1 = "kenmei1";
            /// <summary>
            /// 件名２の物理名
            /// </summary>
            public const string dcKenmei2 = "kenmei2";
            /// <summary>
            /// 注文日付の物理名
            /// </summary>
            public const string dcChumonHizuke = "chumonHizuke";
            /// <summary>
            /// 指定伝票番号の物理名
            /// </summary>
            public const string dcShiteiDenpyoNo = "shiteiDenpyoNo";
            /// <summary>
            /// 納品日付の物理名
            /// </summary>
            public const string dcNouhinHizuke = "nouhinHizuke";
            /// <summary>
            /// 工番１の物理名
            /// </summary>
            public const string dcKouban1 = "kouban1";
            /// <summary>
            /// 工番２の物理名
            /// </summary>
            public const string dcKouban2 = "kouban2";
            /// <summary>
            /// 工番３の物理名
            /// </summary>
            public const string dcKouban3 = "kouban3";
            /// <summary>
            /// 納品書区分の物理名
            /// </summary>
            public const string dcNouhinsyoKubun = "nouhinsyoKubun";
            /// <summary>
            /// 備考１の物理名
            /// </summary>
            public const string dcBikou1 = "bikou1";
            /// <summary>
            /// 備考２の物理名
            /// </summary>
            public const string dcBikou2 = "bikou2";
            /// <summary>
            /// 客先注番の物理名
            /// </summary>
            public const string dcKyakusakiChuban = "kyakusakiChuban";
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            public const string dcSeikyuHizuke = "seikyuHizuke";
            /// <summary>
            /// 請求区分の物理名
            /// </summary>
            public const string dcSeikyuHuragu = "seikyuHuragu";
            /// <summary>
            /// 明細行をまとめて出力フラグの物理名
            /// </summary>
            public const string dcFlgMeisaiIkkatuSyuturyoku = "flgMeisaiIkkatuSyuturyoku";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 伝票番号
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 伝票日付
            /// </summary>
            private DateTime? denpyoHizuke = null;
            /// <summary>
            /// 受注NO(担当者コード)
            /// </summary>
            private string juchuNoTop = string.Empty;
            /// <summary>
            /// 受注NO(月)
            /// </summary>
            private string juchuNoMid = string.Empty;
            /// <summary>
            /// 受注NO(担当者毎受注No)
            /// </summary>
            private string juchuNoBtm = string.Empty;
            /// <summary>
            /// 地方コード
            /// </summary>
            private string chihouCode = string.Empty;
            /// <summary>
            /// 地区コード
            /// </summary>
            private string chikuCode = string.Empty;
            /// <summary>
            /// 得意先コード
            /// </summary>
            private string tokuisakiCode = string.Empty;
            /// <summary>
            /// 得意先名
            /// </summary>
            private string tokuisakiName = string.Empty;
            /// <summary>
            /// 得意先名カナ
            /// </summary>
            private string tokuisakiKanaName = string.Empty;
            /// <summary>
            /// 事業所コード
            /// </summary>
            private string jigyousyoCode = string.Empty;
            /// <summary>
            /// 事業所名
            /// </summary>
            private string jigyousyoName = string.Empty;
            /// <summary>
            /// 得意先担当者名
            /// </summary>
            private string tokuisakiTantousayName = string.Empty;
            /// <summary>
            /// 郵便番号
            /// </summary>
            private string zipCode = string.Empty;
            /// <summary>
            /// 住所１
            /// </summary>
            private string addres1 = string.Empty;
            /// <summary>
            /// 住所２
            /// </summary>
            private string addres2 = string.Empty;
            /// <summary>
            /// 担当者コード
            /// </summary>
            private string tantousyaCode = string.Empty;
            /// <summary>
            /// 担当者名
            /// </summary>
            private string tantousyaName = string.Empty;
            /// <summary>
            /// 件名番号
            /// </summary>
            private string kenmeiNo = string.Empty;
            /// <summary>
            /// 件名１
            /// </summary>
            private string kenmei1 = string.Empty;
            /// <summary>
            /// 件名２
            /// </summary>
            private string kenmei2 = string.Empty;
            /// <summary>
            /// 注文日付
            /// </summary>
            private DateTime? chumonHizuke = null;
            /// <summary>
            /// 指定伝票番号
            /// </summary>
            private string shiteiDenpyoNo = string.Empty;
            /// <summary>
            /// 納品日付
            /// </summary>
            private DateTime? nouhinHizuke = null;
            /// <summary>
            /// 工番１
            /// </summary>
            private string kouban1 = string.Empty;
            /// <summary>
            /// 工番２
            /// </summary>
            private string kouban2 = string.Empty;
            /// <summary>
            /// 工番３
            /// </summary>
            private string kouban3 = string.Empty;
            /// <summary>
            /// 納品書区分
            /// </summary>
            private string nouhinsyoKubun = string.Empty;
            /// <summary>
            /// 備考１
            /// </summary>
            private string bikou1 = string.Empty;
            /// <summary>
            /// 備考２
            /// </summary>
            private string bikou2 = string.Empty;
            /// <summary>
            /// 客先注番
            /// </summary>
            private string kyakusakiChuban = string.Empty;
            /// <summary>
            /// 請求日付
            /// </summary>
            private DateTime? seikyuHizuke = null;
            /// <summary>
            /// 請求区分
            /// </summary>
            private string seikyuHuragu = string.Empty;
            /// <summary>
            /// 明細行をまとめて出力フラグ
            /// </summary>
            private int flgMeisaiIkkatuSyuturyoku = 0;
            /// <summary>
            /// 更新日付
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 伝票番号の取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 伝票日付の取得・設定
            /// </summary>
            public DateTime? DenpyoHizuke
            {
                get { return denpyoHizuke; }
                set { denpyoHizuke = value; }
            }
            /// <summary>
            /// 受注NO(担当者コード)の取得・設定
            /// </summary>
            public string JuchuNoTop
            {
                get { return juchuNoTop; }
                set { juchuNoTop = value; }
            }
            /// <summary>
            /// 受注NO(月)の取得・設定
            /// </summary>
            public string JuchuNoMid
            {
                get { return juchuNoMid; }
                set { juchuNoMid = value; }
            }
            /// <summary>
            /// 受注NO(担当者毎受注No)の取得・設定
            /// </summary>
            public string JuchuNoBtm
            {
                get { return juchuNoBtm; }
                set { juchuNoBtm = value; }
            }
            /// <summary>
            /// 地方コードの取得・設定
            /// </summary>
            public string ChihouCode
            {
                get { return chihouCode; }
                set { chihouCode = value; }
            }
            /// <summary>
            /// 地区コードの取得・設定
            /// </summary>
            public string ChikuCode
            {
                get { return chikuCode; }
                set { chikuCode = value; }
            }
            /// <summary>
            /// 得意先コードの取得・設定
            /// </summary>
            public string TokuisakiCode
            {
                get { return tokuisakiCode; }
                set { tokuisakiCode = value; }
            }
            /// <summary>
            /// 得意先名の取得・設定
            /// </summary>
            public string TokuisakiName
            {
                get { return tokuisakiName; }
                set { tokuisakiName = value; }
            }
            /// <summary>
            /// 得意先名カナの取得・設定
            /// </summary>
            public string TokuisakiKanaName
            {
                get { return tokuisakiKanaName; }
                set { tokuisakiKanaName = value; }
            }
            /// <summary>
            /// 事業所コードの取得・設定
            /// </summary>
            public string JigyousyoCode
            {
                get { return jigyousyoCode; }
                set { jigyousyoCode = value; }
            }
            /// <summary>
            /// 事業所名の取得・設定
            /// </summary>
            public string JigyousyoName
            {
                get { return jigyousyoName; }
                set { jigyousyoName = value; }
            }
            /// <summary>
            /// 得意先担当者名の取得・設定
            /// </summary>
            public string TokuisakiTantousayName
            {
                get { return tokuisakiTantousayName; }
                set { tokuisakiTantousayName = value; }
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
            /// 住所１の取得・設定
            /// </summary>
            public string Addres1
            {
                get { return addres1; }
                set { addres1 = value; }
            }
            /// <summary>
            /// 住所２の取得・設定
            /// </summary>
            public string Addres2
            {
                get { return addres2; }
                set { addres2 = value; }
            }
            /// <summary>
            /// 担当者コードの取得・設定
            /// </summary>
            public string TantousyaCode
            {
                get { return tantousyaCode; }
                set { tantousyaCode = value; }
            }
            /// <summary>
            /// 担当者名の取得・設定
            /// </summary>
            public string TantousyaName
            {
                get { return tantousyaName; }
                set { tantousyaName = value; }
            }
            /// <summary>
            /// 件名番号の取得・設定
            /// </summary>
            public string KenmeiNo
            {
                get { return kenmeiNo; }
                set { kenmeiNo = value; }
            }
            /// <summary>
            /// 件名１の取得・設定
            /// </summary>
            public string Kenmei1
            {
                get { return kenmei1; }
                set { kenmei1 = value; }
            }
            /// <summary>
            /// 件名２の取得・設定
            /// </summary>
            public string Kenmei2
            {
                get { return kenmei2; }
                set { kenmei2 = value; }
            }
            /// <summary>
            /// 注文日付の取得・設定
            /// </summary>
            public DateTime? ChumonHizuke
            {
                get { return chumonHizuke; }
                set { chumonHizuke = value; }
            }
            /// <summary>
            /// 指定伝票番号の取得・設定
            /// </summary>
            public string ShiteiDenpyoNo
            {
                get { return shiteiDenpyoNo; }
                set { shiteiDenpyoNo = value; }
            }
            /// <summary>
            /// 納品日付の取得・設定
            /// </summary>
            public DateTime? NouhinHizuke
            {
                get { return nouhinHizuke; }
                set { nouhinHizuke = value; }
            }
            /// <summary>
            /// 工番１の取得・設定
            /// </summary>
            public string Kouban1
            {
                get { return kouban1; }
                set { kouban1 = value; }
            }
            /// <summary>
            /// 工番２の取得・設定
            /// </summary>
            public string Kouban2
            {
                get { return kouban2; }
                set { kouban2 = value; }
            }
            /// <summary>
            /// 工番３の取得・設定
            /// </summary>
            public string Kouban3
            {
                get { return kouban3; }
                set { kouban3 = value; }
            }
            /// <summary>
            /// 納品書区分の取得・設定
            /// </summary>
            public string NouhinsyoKubun
            {
                get { return nouhinsyoKubun; }
                set { nouhinsyoKubun = value; }
            }
            /// <summary>
            /// 備考１の取得・設定
            /// </summary>
            public string Bikou1
            {
                get { return bikou1; }
                set { bikou1 = value; }
            }
            /// <summary>
            /// 備考２の取得・設定
            /// </summary>
            public string Bikou2
            {
                get { return bikou2; }
                set { bikou2 = value; }
            }
            /// <summary>
            /// 客先注番の取得・設定
            /// </summary>
            public string KyakusakiChuban
            {
                get { return kyakusakiChuban; }
                set { kyakusakiChuban = value; }
            }
            /// <summary>
            /// 請求日付の取得・設定
            /// </summary>
            public DateTime? SeikyuHizuke
            {
                get { return seikyuHizuke; }
                set { seikyuHizuke = value; }
            }
            /// <summary>
            /// 請求区分の取得・設定
            /// </summary>
            public string SeikyuHuragu
            {
                get { return seikyuHuragu; }
                set { seikyuHuragu = value; }
            }
            /// <summary>
            /// 明細行をまとめて出力フラグの取得・設定
            /// </summary>
            public int FlgMeisaiIkkatuSyuturyoku
            {
                get { return flgMeisaiIkkatuSyuturyoku; }
                set { flgMeisaiIkkatuSyuturyoku = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public UriageHeaderFile()
            {
            }
            #endregion
        }
        #endregion

        #region 売上ボディファイルレイアウト
        /// <summary>
        /// 売上ボディファイルレイアウト
        /// </summary>
        public class UriageBodyFile
        {
            #region 列情報
            /// <summary>
            /// 伝票NOの物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            public const string dcRowNo = "rowNo";
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            public const string dcJuchuRowNo = "juchuRowNo";
            /// <summary>
            /// 納品書出力フラグの物理名
            /// </summary>
            public const string dcFlgPrint = "flgPrint";
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            public const string dcDaiBunruiCode = "daiBunruiCode";
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            public const string dcSyoBunruiCode = "syoBunruiCode";
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            public const string dcShouhinCode = "shouhinCode";
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            public const string dcShouhinName1 = "shouhinName1";
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            public const string dcShouhinName2 = "shouhinName2";
            /// <summary>
            /// 数量の物理名
            /// </summary>
            public const string dcSuryo = "suryo";
            /// <summary>
            /// 単位の物理名
            /// </summary>
            public const string dcTani = "tani";
            /// <summary>
            /// 単価の物理名
            /// </summary>
            public const string dcTanka = "tanka";
            /// <summary>
            /// 金額の物理名
            /// </summary>
            public const string dcKingaku = "kingaku";
            /// <summary>
            /// 納品状態の物理名
            /// </summary>
            public const string dcNouhinJoutai = "nouhinJoutai";
            /// <summary>
            /// 備考の物理名
            /// </summary>
            public const string dcBikou = "bikou";
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            public const string dcSeikyuHizuke = "seikyuHizuke";
            /// <summary>
            /// 請求フラグの物理名
            /// </summary>
            public const string dcSeikyuHuragu = "seikyuHuragu";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 伝票NOの物理名
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 行番号の物理名
            /// </summary>
            private int rowNo = 0;
            /// <summary>
            /// 受注行番号の物理名
            /// </summary>
            private int juchuRowNo = 0;
            /// <summary>
            /// 納品書出力フラグの物理名
            /// </summary>
            private int flgPrint = 0;
            /// <summary>
            /// 商品コード(大分類コード)の物理名
            /// </summary>
            private string daiBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(小類コード)の物理名
            /// </summary>
            private string syoBunruiCode = string.Empty;
            /// <summary>
            /// 商品コード(連番)の物理名
            /// </summary>
            private string shouhinCode = string.Empty;
            /// <summary>
            /// 商品名１の物理名
            /// </summary>
            private string shouhinName1 = string.Empty;
            /// <summary>
            /// 商品名２の物理名
            /// </summary>
            private string shouhinName2 = string.Empty;
            /// <summary>
            /// 数量の物理名
            /// </summary>
            private decimal? suryo = null;
            /// <summary>
            /// 単位の物理名
            /// </summary>
            private string tani = string.Empty;
            /// <summary>
            /// 単価の物理名
            /// </summary>
            private decimal? tanka = null;
            /// <summary>
            /// 金額の物理名
            /// </summary>
            private decimal? kingaku = null;
            /// <summary>
            /// 納品状態の物理名
            /// </summary>
            private string nouhinJoutai = string.Empty;
            /// <summary>
            /// 備考の物理名
            /// </summary>
            private string bikou = string.Empty;
            /// <summary>
            /// 請求日付の物理名
            /// </summary>
            private DateTime? seikyuHizuke = null;
            /// <summary>
            /// 請求フラグの物理名
            /// </summary>
            private string seikyuHuragu = string.Empty;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 伝票NOの取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 行番号の取得・設定
            /// </summary>
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            /// <summary>
            /// 受注行番号の取得・設定
            /// </summary>
            public int JuchuRowNo
            {
                get { return juchuRowNo; }
                set { juchuRowNo = value; }
            }
            /// <summary>
            /// 納品書出力フラグの取得・設定
            /// </summary>
            public int FlgPrint
            {
                get { return flgPrint; }
                set { flgPrint = value; }
            }
            /// <summary>
            /// 商品コード(大分類コード)の取得・設定
            /// </summary>
            public string DaiBunruiCode
            {
                get { return daiBunruiCode; }
                set { daiBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(小類コード)の取得・設定
            /// </summary>
            public string SyoBunruiCode
            {
                get { return syoBunruiCode; }
                set { syoBunruiCode = value; }
            }
            /// <summary>
            /// 商品コード(連番)の取得・設定
            /// </summary>
            public string ShouhinCode
            {
                get { return shouhinCode; }
                set { shouhinCode = value; }
            }
            /// <summary>
            /// 商品名１の取得・設定
            /// </summary>
            public string ShouhinName1
            {
                get { return shouhinName1; }
                set { shouhinName1 = value; }
            }
            /// <summary>
            /// 商品名２の取得・設定
            /// </summary>
            public string ShouhinName2
            {
                get { return shouhinName2; }
                set { shouhinName2 = value; }
            }
            /// <summary>
            /// 数量の取得・設定
            /// </summary>
            public decimal? Suryo
            {
                get { return suryo; }
                set { suryo = value; }
            }
            /// <summary>
            /// 単位の取得・設定
            /// </summary>
            public string Tani
            {
                get { return tani; }
                set { tani = value; }
            }
            /// <summary>
            /// 単価の取得・設定
            /// </summary>
            public decimal? Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 金額の取得・設定
            /// </summary>
            public decimal? Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }
            /// <summary>
            /// 納品状態の取得・設定
            /// </summary>
            public string NouhinJoutai
            {
                get { return nouhinJoutai; }
                set { nouhinJoutai = value; }
            }
            /// <summary>
            /// 備考の取得・設定
            /// </summary>
            public string Bikou
            {
                get { return bikou; }
                set { bikou = value; }
            }
            /// <summary>
            /// 請求日付の取得・設定
            /// </summary>
            public DateTime? SeikyuHizuke
            {
                get { return seikyuHizuke; }
                set { seikyuHizuke = value; }
            }
            /// <summary>
            /// 請求フラグの取得・設定
            /// </summary>
            public string SeikyuHuragu
            {
                get { return seikyuHuragu; }
                set { seikyuHuragu = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public UriageBodyFile()
            {
            }
            #endregion
        }
        #endregion

        #region 売上フッタファイルレイアウト
        /// <summary>
        /// 売上フッタファイルレイアウト
        /// </summary>
        public class UriageFooterFile
        {
            #region 列情報
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            public const string dcDenpyoNo = "denpyoNo";
            /// <summary>
            /// 売上金額の物理名
            /// </summary>
            public const string dcUriageKingaku = "uriageKingaku";
            /// <summary>
            /// 消費税の物理名
            /// </summary>
            public const string dcSyouhizei = "syouhizei";
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            public const string dcKousinNichizi = "kousinNichizi";
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            public const string dcKanriKubun = "kanriKubun";
            #endregion

            #region 変数宣言
            /// <summary>
            /// データ存在フラグ
            /// </summary>
            private bool flgDataExsit = false;
            /// <summary>
            /// 伝票番号の物理名
            /// </summary>
            private string denpyoNo = string.Empty;
            /// <summary>
            /// 売上金額の物理名
            /// </summary>
            private decimal? uriageKingaku = null;
            /// <summary>
            /// 消費税の物理名
            /// </summary>
            private decimal? syouhizei = null;
            /// <summary>
            /// 更新日付の物理名
            /// </summary>
            private DateTime? kousinNichizi = null;
            /// <summary>
            /// 管理区分の物理名
            /// </summary>
            private string kanriKubun = string.Empty;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// データ存在フラグの取得・設定
            /// </summary>
            public bool FlgDataExsit
            {
                get { return flgDataExsit; }
                set { flgDataExsit = value; }
            }
            /// <summary>
            /// 伝票番号の取得・設定
            /// </summary>
            public string DenpyoNo
            {
                get { return denpyoNo; }
                set { denpyoNo = value; }
            }
            /// <summary>
            /// 売上金額の取得・設定
            /// </summary>
            public decimal? UriageKingaku
            {
                get { return uriageKingaku; }
                set { uriageKingaku = value; }
            }
            /// <summary>
            /// 消費税の取得・設定
            /// </summary>
            public decimal? Syouhizei
            {
                get { return syouhizei; }
                set { syouhizei = value; }
            }
            /// <summary>
            /// 更新日付の取得・設定
            /// </summary>
            public DateTime? KousinNichizi
            {
                get { return kousinNichizi; }
                set { kousinNichizi = value; }
            }
            /// <summary>
            /// 管理区分の取得・設定
            /// </summary>
            public string KanriKubun
            {
                get { return kanriKubun; }
                set { kanriKubun = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public UriageFooterFile()
            {
            }
            #endregion
        }
        #endregion

        #endregion
    }
}
