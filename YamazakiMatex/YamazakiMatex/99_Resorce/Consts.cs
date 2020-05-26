using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorce
{
    class Consts
    {
        /// <summary>
        /// 管理者権限コード
        /// </summary>
        public const int AdministratorCode = 0;
        /// <summary>
        /// 事務員コード
        /// </summary>
        public const int ClerkCode = 1;
        /// <summary>
        /// 営業員コード
        /// </summary>
        public const int SalespersonCode = 2;

        /// <summary>
        /// 管理区分のコード区分一覧
        /// </summary>
        public class KanriCodeTypes
        {
            /// <summary>
            /// コード区分1
            /// </summary>
            public const string TYPE0 = "";
            /// <summary>
            /// コード区分2
            /// </summary>
            public const string TYPE1 = "1";
            /// <summary>
            /// コード区分3
            /// </summary>
            public const string TYPE9 = "9";
        }

        #region 管理ｺｰﾄﾞ群
        /// <summary>
        /// 管理ｺｰﾄﾞ群
        /// </summary>
        public class KanriCodes
        {
            /// <summary>
            /// 見積番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string MitumoriNo = "00001";
            /// <summary>
            /// 受注番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string JuchuNo = "00002";
            /// <summary>
            /// 発注番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string HachuNo = "00003";
            /// <summary>
            /// 売上番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string UriageNo = "00004";
            /// <summary>
            /// 件名番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string KenmeiNo = "00005";
            /// <summary>
            /// 処理日付の管理ｺｰﾄﾞ
            /// </summary>
            public static string SyoriDate = "00006";
            /// <summary>
            /// 請求締日の管理ｺｰﾄﾞ
            /// </summary>
            public static string SeikyuShimeDate = "00007";
            /// <summary>
            /// 月次処理日の管理ｺｰﾄﾞ
            /// </summary>
            public static string GetujiSyoriDate = "00008";
            /// <summary>
            /// 年次処理日の管理ｺｰﾄﾞ
            /// </summary>
            public static string NenjiSyoriDate = "00009";
            /// <summary>
            /// 消費税管理の管理ｺｰﾄﾞ
            /// </summary>
            public static string ShouhizeiKanri = "00010";
            /// <summary>
            /// 仕入締日の管理ｺｰﾄﾞ
            /// </summary>
            public static string ShireShimeDate = "00011";
            /// <summary>
            /// 請求番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string SeikyuNo = "00012";
            /// <summary>
            /// 支払番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string ShiharaiNo = "00013";
            /// <summary>
            /// 入金番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string NyukinNo = "00014";
            /// <summary>
            /// 仕入番号の管理ｺｰﾄﾞ
            /// </summary>
            public static string ShireNo = "00015";
        }
        #endregion

        /// <summary>
        /// 名称マスタの名称コード一覧
        /// </summary>
        public class MeisyoCode
        {
            /// <summary>
            /// 材料・工事区分の名称コード
            /// </summary>
            public const string CODE001 = "001";
            /// <summary>
            /// 見積区分の名称コード
            /// </summary>
            public const string CODE002 = "002";
            /// <summary>
            /// 単位区分の名称コード
            /// </summary>
            public const string CODE003 = "003";
            /// <summary>
            /// 都道府県の名称コード
            /// </summary>
            public const string CODE004 = "004";
            /// <summary>
            /// 仕入・部材の名称コード
            /// </summary>
            public const string CODE005 = "005";
            /// <summary>
            /// 締区分の名称コード
            /// </summary>
            public const string CODE006 = "006";
            /// <summary>
            /// 分類名の名称コード
            /// </summary>
            public const string CODE007 = "007";
            /// <summary>
            /// 地方の名称コード
            /// </summary>
            public const string CODE008 = "008";
            /// <summary>
            /// 請求出力区分の名称コード
            /// </summary>
            public const string CODE009 = "009";
            /// <summary>
            /// 回収サイトの名称コード
            /// </summary>
            public const string CODE010 = "010";
            /// <summary>
            /// 消費税出力区分の名称コード
            /// </summary>
            public const string CODE011 = "011";
            /// <summary>
            /// 請求管理区分の名称コード
            /// </summary>
            public const string CODE012 = "012";
            /// <summary>
            /// 支払サイト区分の名称コード
            /// </summary>
            public const string CODE013 = "013";
            /// <summary>
            /// 指定伝票コードの名称コード
            /// </summary>
            public const string CODE014 = "014";
            /// <summary>
            /// 敬称の名称コード
            /// </summary>
            public const string CODE015 = "015";
            /// <summary>
            /// 但し書きの名称コード
            /// </summary>
            public const string CODE016 = "016";
        }

        /// <summary>
        /// その他得意先のコード
        /// </summary>
        public const string OthersCustomerCode = "99999";

        /// <summary>
        /// その他商品コード
        /// </summary>
        public const string OthersItemCode = "99999";

        /// <summary>
        /// その他件名のコード
        /// </summary>
        public const string OthersConstructionNo = "999999";

        /// <summary>
        /// その他仕入先のコード
        /// </summary>
        public const string OthersVendorCode = "999";

        /// <summary>
        /// 明細区分
        /// </summary>
        public class OrdersDetailType
        {
            /// <summary>
            /// メッキ代
            /// </summary>
            public const string PlatingAmount = "01";
            /// <summary>
            /// 塗装代
            /// </summary>
            public const string PaintingAmount = "02";
            /// <summary>
            /// 運賃
            /// </summary>
            public const string Fare = "03";
            /// <summary>
            /// 仕入
            /// </summary>
            public const string Purchase = "04";
            /// <summary>
            /// 部材
            /// </summary>
            public const string Parts = "05";
        }

        /// <summary>
        /// 納品区分
        /// </summary>
        public class DeliveryType
        {
            /// <summary>
            /// 未完納コード
            /// </summary>
            public const string NoneDeliveryCode = "000";

            /// <summary>
            /// 完納コード
            /// </summary>
            public const string FinishDeliveryCode = "001";

            /// <summary>
            /// 未完納
            /// </summary>
            public const string NoneDeliveryText = "未完納";

            /// <summary>
            /// 完納
            /// </summary>
            public const string FinishDeliveryText = "完納";
        }

        /// <summary>
        /// 月末
        /// </summary>
        public const string EndOfMonthText = "月末";

        /// <summary>
        /// 月末
        /// </summary>
        public const string EndOfMonthValue = "07";

        /// <summary>
        /// 随時
        /// </summary>
        public const string FromTimeToTimeText = "随時";

        /// <summary>
        /// 随時
        /// </summary>
        public const string FromTimeToTimeValue = "99";

        /// <summary>
        /// 端数処理区分
        /// </summary>
        public enum RoundType
        {
            /// <summary>
            /// 切り捨て
            /// </summary>
            RoundDown = 0
            /// <summary>
            /// 切り上げ
            /// </summary>
            , RoundUp = 1
            /// <summary>
            /// 四捨五入
            /// </summary>
            , RoundOff = 2
        }
    }
}
