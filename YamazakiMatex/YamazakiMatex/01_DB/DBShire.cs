using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using YamazakiMatex;
using Common;
using Resorce;

namespace DB
{
    /// <summary>
    /// 仕入DBモジュール
    /// </summary>
    class DBShire : DBFileLayout
    {
        #region 変数宣言
        /// <summary>
        /// 受注データ格納変数
        /// </summary>
        private JuchuDataClass selectJuchuData;

        /// <summary>
        /// 売上データ格納変数
        /// </summary>
        private UriageDataClass selectUriageData;

        /// <summary>
        /// 仕入データ格納変数
        /// </summary>
        private ShireDataClass selectShireData;
        #endregion

        #region 取得・設定処理
        /// <summary>
        /// 受注データ格納変数の取得・設定
        /// </summary>
        public JuchuDataClass SelectJuchuData
        {
            get { return selectJuchuData; }
            set { selectJuchuData = value; }
        }

        /// <summary>
        /// 売上データ格納変数の取得・設定
        /// </summary>
        public UriageDataClass SelectUriageData
        {
            get { return selectUriageData; }
            set { selectUriageData = value; }
        }

        /// <summary>
        /// 仕入データ格納変数の取得・設定
        /// </summary>
        public ShireDataClass SelectShireData
        {
            get { return selectShireData; }
            set { selectShireData = value; }
        }
        #endregion

        #region データ取得時のエラー区分
        /// <summary>
        /// データ取得時のエラー区分
        /// </summary>
        public enum SelectErrorType
        {
            None = 0
          , JuchuHeader = 1
          , JuchuBody = 2
          , JuchuFooter = 3
          , UriageHeader = 4
          , UriageBody = 5
          , UriageFooter = 6
          , ShireHeader = 7
          , ShireBody = 8
          , ShireFooter = 9
        }
        #endregion

        #region 受注データ格納クラス
        /// <summary>
        /// 受注データ格納クラス
        /// </summary>
        public class JuchuDataClass
        {
            #region 変数宣言
            /// <summary>
            /// ヘッダデータ
            /// </summary>
            private JuchuHeaderFile headerData;
            /// <summary>
            /// ボディデータ
            /// </summary>
            private List<JuchuBodyFile> bodyDatas;
            /// <summary>
            /// フッタデータ
            /// </summary>
            private JuchuFooterFile footerData;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// ヘッダデータの取得・設定
            /// </summary>
            public JuchuHeaderFile HeaderData
            {
                get { return headerData; }
                set { headerData = value; }
            }
            /// <summary>
            /// ボディデータの取得・設定
            /// </summary>
            public List<JuchuBodyFile> BodyDatas
            {
                get { return bodyDatas; }
                set { bodyDatas = value; }
            }
            /// <summary>
            /// フッタデータの取得・設定
            /// </summary>
            public JuchuFooterFile FooterData
            {
                get { return footerData; }
                set { footerData = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public JuchuDataClass()
            {
                HeaderData = new JuchuHeaderFile();
                BodyDatas = new List<JuchuBodyFile>();
                FooterData= new JuchuFooterFile();
            }
            #endregion

            #region ヘッダデータ設定処理
            /// <summary>
            /// ヘッダデータ設定処理
            /// </summary>
            /// <param name="headerRow"></param>
            public void setHeaderData(DataTable headerData)
            {
                if (headerData == null || headerData.Rows.Count == 0) return;

                DataRow headerRow = headerData.Rows[0];

                // データ存在フラグ
                HeaderData.FlgDataExsit = true;
                // 伝票NO
                HeaderData.DenpyoNo = Convert.ToString(headerRow[JuchuHeaderFile.dcDenpyoNo]);
                // 伝票日付
                HeaderData.Syukabi = CommonLogic.ToDateTime(headerRow[JuchuHeaderFile.dcDenpyoHizuke]);
                // 受注NO(担当者コード)
                HeaderData.JuchuNoTop = Convert.ToString(headerRow[JuchuHeaderFile.dcJuchuNoTop]);
                // 受注NO(月)
                HeaderData.JuchuNoMid = Convert.ToString(headerRow[JuchuHeaderFile.dcJuchuNoMid]);
                // 受注NO(担当者毎受注No)
                HeaderData.JuchuNoBtm = Convert.ToString(headerRow[JuchuHeaderFile.dcJuchuNoBtm]);
                // 担当者コード
                HeaderData.TantousyaCode = Convert.ToString(headerRow[JuchuHeaderFile.dcTantousyaCode]);
                // 担当者名
                HeaderData.TantousyaName = Convert.ToString(headerRow[JuchuHeaderFile.dcTantousyaName]);
                // 発行者コード
                HeaderData.HakousyaCode = Convert.ToString(headerRow[JuchuHeaderFile.dcHakousyaCode]);
                // 発行者名
                HeaderData.HakousyaName = Convert.ToString(headerRow[JuchuHeaderFile.dcHakousyaName]);
                // 得意先コード
                HeaderData.TokuisakiCode = Convert.ToString(headerRow[JuchuHeaderFile.dcTokuisakiCode]);
                // 得意先名
                HeaderData.TokuisakiName = Convert.ToString(headerRow[JuchuHeaderFile.dcTokuisakiName]);
                // 得意先名カナ
                HeaderData.TokuisakiKanaName = Convert.ToString(headerRow[JuchuHeaderFile.dcTokuisakiKanaName]);
                // 得意先名カナ
                HeaderData.JigyousyoCode = Convert.ToString(headerRow[JuchuHeaderFile.dcJigyousyoCode]);
                // 事業所名
                HeaderData.JigyousyoName = Convert.ToString(headerRow[JuchuHeaderFile.dcJigyousyoName]);
                // 得意先担当者名
                HeaderData.TokuisakiTantousayName = Convert.ToString(headerRow[JuchuHeaderFile.dcTokuisakiTantousayName]);
                // 材料・工事区分
                HeaderData.ZairyoKoujiKubun = Convert.ToString(headerRow[JuchuHeaderFile.dcZairyoKoujiKubun]);
                // 出荷日
                HeaderData.Syukabi = CommonLogic.ToDateTime(headerRow[JuchuHeaderFile.dcSyukabi]);
                // 着日
                HeaderData.Syukabi = CommonLogic.ToDateTime(headerRow[JuchuHeaderFile.dcTyakubi]);
                // 出荷便
                HeaderData.Syukabin = Convert.ToString(headerRow[JuchuHeaderFile.dcSyukabin]);
                // 客先注番
                HeaderData.KyakusakiChuban = Convert.ToString(headerRow[JuchuHeaderFile.dcKyakusakiChuban]);
                // 件名NO
                HeaderData.KenmeiNo = Convert.ToString(headerRow[JuchuHeaderFile.dcKenmeiNo]);
                // 件名１
                HeaderData.Kenmei1 = Convert.ToString(headerRow[JuchuHeaderFile.dcKenmei1]);
                // 件名２
                HeaderData.Kenmei2 = Convert.ToString(headerRow[JuchuHeaderFile.dcKenmei2]);
                // 納入先名
                HeaderData.NounyusakiName = Convert.ToString(headerRow[JuchuHeaderFile.dcNounyusakiName]);
                // 部署名
                HeaderData.BusyoName = Convert.ToString(headerRow[JuchuHeaderFile.dcBusyoName]);
                // 連絡先１
                HeaderData.Renrakusaki1 = Convert.ToString(headerRow[JuchuHeaderFile.dcRenrakusaki1]);
                // 連絡先２
                HeaderData.Renrakusaki2 = Convert.ToString(headerRow[JuchuHeaderFile.dcRenrakusaki2]);
                // 郵便番号
                HeaderData.ZipCode = Convert.ToString(headerRow[JuchuHeaderFile.dcZipCode]);
                // 住所１
                HeaderData.Addres1 = Convert.ToString(headerRow[JuchuHeaderFile.dcAddres1]);
                // 住所２
                HeaderData.Addres2 = Convert.ToString(headerRow[JuchuHeaderFile.dcAddres2]);
                // 地方コード
                HeaderData.ChihouCode = Convert.ToString(headerRow[JuchuHeaderFile.dcChihouCode]);
                // 地区コード
                HeaderData.ChikuCode = Convert.ToString(headerRow[JuchuHeaderFile.dcChikuCode]);
                // 見積番号
                HeaderData.MitumoriNo = Convert.ToString(headerRow[JuchuHeaderFile.dcMitumoriNo]);
                // 更新日付
                HeaderData.KousinNichizi = CommonLogic.ToDateTime(headerRow[JuchuHeaderFile.dcKousinNichizi]);
                // 管理区分
                HeaderData.KanriKubun = Convert.ToString(headerRow[JuchuHeaderFile.dcKanriKubun]);
            }
            #endregion

            #region ボディデータ設定処理
            /// <summary>
            /// ボディデータ設定処理
            /// </summary>
            /// <param name="bodyData"></param>
            public void setBodyData(DataTable bodyData)
            {
                if (bodyData == null || bodyData.Rows.Count == 0) return;

                DataRow bodyRow;
                JuchuBodyFile wkJuchuBodyInfo;
                for (int i = 0; i < bodyData.Rows.Count; i++)
                {
                    bodyRow = bodyData.Rows[i];
                    wkJuchuBodyInfo = new JuchuBodyFile();

                    // データ存在フラグ
                    wkJuchuBodyInfo.FlgDataExsit = true;
                    // 受注NO(担当者コード)
                    wkJuchuBodyInfo.JuchuNoTop = Convert.ToString(bodyRow[JuchuBodyFile.dcJuchuNoTop]);
                    // 受注NO(月)
                    wkJuchuBodyInfo.JuchuNoMid = Convert.ToString(bodyRow[JuchuBodyFile.dcJuchuNoMid]);
                    // 受注NO(担当者毎受注No)
                    wkJuchuBodyInfo.JuchuNoBtm = Convert.ToString(bodyRow[JuchuBodyFile.dcJuchuNoBtm]);
                    // 行番号
                    wkJuchuBodyInfo.RowNo = Convert.ToInt16(bodyRow[JuchuBodyFile.dcRowNo]);
                    // 商品コード(大分類コード)
                    wkJuchuBodyInfo.DaiBunruiCode = Convert.ToString(bodyRow[JuchuBodyFile.dcDaiBunruiCode]);
                    // 商品コード(小類コード)
                    wkJuchuBodyInfo.SyoBunruiCode = Convert.ToString(bodyRow[JuchuBodyFile.dcSyoBunruiCode]);
                    // 商品コード(連番)
                    wkJuchuBodyInfo.ShouhinCode = Convert.ToString(bodyRow[JuchuBodyFile.dcShouhinCode]);
                    // 商品名１
                    wkJuchuBodyInfo.ShouhinName1 = Convert.ToString(bodyRow[JuchuBodyFile.dcShouhinName1]);
                    // 商品名２
                    wkJuchuBodyInfo.ShouhinName2 = Convert.ToString(bodyRow[JuchuBodyFile.dcShouhinName2]);
                    // (受注)数量
                    wkJuchuBodyInfo.JuchuSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcJuchuSuryo]);
                    // (受注)単位
                    wkJuchuBodyInfo.JuchuTani = Convert.ToString(bodyRow[JuchuBodyFile.dcJuchuTani]);
                    // (受注)納品残数量
                    wkJuchuBodyInfo.JuchuNouhinZanSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcJuchuNouhinZanSuryo]);
                    // (受注)納品数量
                    wkJuchuBodyInfo.JuchuNouhinSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcJuchuNouhinSuryo]);
                    // (受注)単価
                    wkJuchuBodyInfo.JuchuTanka = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcJuchuTanka]);
                    // (受注)金額
                    wkJuchuBodyInfo.JuchuKingaku = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcJuchuKingaku]);
                    // (受注)納入区分
                    wkJuchuBodyInfo.JuchuNonyuKubun = Convert.ToString(bodyRow[JuchuBodyFile.dcJuchuNonyuKubun]);
                    // (仕入)仕入先コード
                    wkJuchuBodyInfo.ShiresakiCode = Convert.ToString(bodyRow[JuchuBodyFile.dcShiresakiCode]);
                    // (仕入)仕入先名
                    wkJuchuBodyInfo.ShiresakiName = Convert.ToString(bodyRow[JuchuBodyFile.dcShiresakiName]);
                    // (仕入)仕入・部材区分
                    wkJuchuBodyInfo.ShireBuzaiKubun = Convert.ToString(bodyRow[JuchuBodyFile.dcShireBuzaiKubun]);
                    // (仕入)単価
                    wkJuchuBodyInfo.ShireTanka = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcShireTanka]);
                    // (仕入)金額
                    wkJuchuBodyInfo.ShireKingaku = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcShireKingaku]);
                    // (仕入)納品残数量
                    wkJuchuBodyInfo.ShireNouhinZanSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcShireNouhinZanSuryo]);
                    // (仕入)納品数量
                    wkJuchuBodyInfo.ShireNouhinSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcShireNouhinSuryo]);
                    // (仕入)発注番号
                    wkJuchuBodyInfo.ShireHachuNo = Convert.ToString(bodyRow[JuchuBodyFile.dcShireHachuNo]);
                    // 備考
                    wkJuchuBodyInfo.Bikou = Convert.ToString(bodyRow[JuchuBodyFile.dcBikou]);
                    // 更新日付
                    wkJuchuBodyInfo.KousinNichizi = CommonLogic.ToDateTime(bodyRow[JuchuBodyFile.dcKousinNichizi]);
                    // 管理区分
                    wkJuchuBodyInfo.KanriKubun = Convert.ToString(bodyRow[JuchuBodyFile.dcKanriKubun]);
                    // 納品数量合計
                    wkJuchuBodyInfo.TotalNouhinSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcTotalNouhinSuryo]);
                    // 仕入数量合計
                    wkJuchuBodyInfo.TotalShireSuryo = CommonLogic.ToDecimal(bodyRow[JuchuBodyFile.dcTotalShireSuryo]);

                    BodyDatas.Add(wkJuchuBodyInfo);
                }
            }
            #endregion

            #region フッタデータ設定処理
            /// <summary>
            /// フッタデータ設定処理
            /// </summary>
            /// <param name="footerData"></param>
            public void setFooterData(DataTable footerData)
            {
                if (footerData == null || footerData.Rows.Count == 0) return;

                DataRow footerRow = footerData.Rows[0];

                // データ存在フラグ
                FooterData.FlgDataExsit = true;
                // 受注NO(担当者コード)
                FooterData.JuchuNoTop = Convert.ToString(footerRow[JuchuFooterFile.dcJuchuNoTop]);
                // 受注NO(月)
                FooterData.JuchuNoMid = Convert.ToString(footerRow[JuchuFooterFile.dcJuchuNoMid]);
                // 受注NO(担当者毎受注No)
                FooterData.JuchuNoBtm = Convert.ToString(footerRow[JuchuFooterFile.dcJuchuNoBtm]);
                // 受注計
                FooterData.JuchuKei = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcJuchuKei]);
                // 仕入計
                FooterData.ShireKei = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcShireKei]);
                // メッキ代
                FooterData.MekkiDai = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcMekkiDai]);
                // 塗装代
                FooterData.TosouDai = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcTosouDai]);
                // 運賃代
                FooterData.Unchin = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcUnchin]);
                // 仕入台
                FooterData.ShireDai = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcShireDai]);
                // 部材代
                FooterData.BuzaiDai = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcBuzaiDai]);
                // 仕入合計
                FooterData.ShireGoukei = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcShireGoukei]);
                // 粗利額
                FooterData.ArariGaku = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcArariGaku]);
                // 粗利率
                FooterData.ArariRitu = CommonLogic.ToDecimal(footerRow[JuchuFooterFile.dcArariRitu]);
                // 更新日付
                FooterData.KousinNichizi = CommonLogic.ToDateTime(footerRow[JuchuFooterFile.dcKousinNichizi]);
                // 管理区分
                FooterData.KanriKubun = Convert.ToString(footerRow[JuchuFooterFile.dcKanriKubun]);
            }
            #endregion
        }
        #endregion

        #region 売上データ格納クラス
        /// <summary>
        /// 売上データ格納クラス
        /// </summary>
        public class UriageDataClass
        {
            #region 変数宣言
            /// <summary>
            /// ヘッダデータ
            /// </summary>
            private UriageHeaderFile headerData;
            /// <summary>
            /// ボディデータ
            /// </summary>
            private List<UriageBodyFile> bodyDatas;
            /// <summary>
            /// フッタデータ
            /// </summary>
            private UriageFooterFile footerData;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// ヘッダデータの取得・設定
            /// </summary>
            public UriageHeaderFile HeaderData
            {
                get { return headerData; }
                set { headerData = value; }
            }
            /// <summary>
            /// ボディデータの取得・設定
            /// </summary>
            public List<UriageBodyFile> BodyDatas
            {
                get { return bodyDatas; }
                set { bodyDatas = value; }
            }
            /// <summary>
            /// フッタデータの取得・設定
            /// </summary>
            public UriageFooterFile FooterData
            {
                get { return footerData; }
                set { footerData = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public UriageDataClass()
            {
                HeaderData = new UriageHeaderFile();
                BodyDatas = new List<UriageBodyFile>();
                FooterData = new UriageFooterFile();
            }
            #endregion

            #region ヘッダデータ設定処理
            /// <summary>
            /// ヘッダデータ設定処理
            /// </summary>
            /// <param name="headerRow"></param>
            public void setHeaderData(DataTable headerData)
            {
                if (headerData == null || headerData.Rows.Count == 0) return;

                DataRow headerRow = headerData.Rows[0];

                // データ存在フラグ
                HeaderData.FlgDataExsit = true;
                // 伝票NO
                HeaderData.DenpyoNo = Convert.ToString(headerRow[UriageHeaderFile.dcDenpyoNo]);
                // 伝票日付
                HeaderData.DenpyoHizuke = CommonLogic.ToDateTime(headerRow[UriageHeaderFile.dcDenpyoHizuke]);
                // 受注NO(担当者コード)
                HeaderData.JuchuNoTop = Convert.ToString(headerRow[UriageHeaderFile.dcJuchuNoTop]);
                // 受注NO(月)
                HeaderData.JuchuNoMid = Convert.ToString(headerRow[UriageHeaderFile.dcJuchuNoMid]);
                // 受注NO(担当者毎受注No)
                HeaderData.JuchuNoBtm = Convert.ToString(headerRow[UriageHeaderFile.dcJuchuNoBtm]);
                // 地方コード
                HeaderData.ChihouCode = Convert.ToString(headerRow[UriageHeaderFile.dcChihouCode]);
                // 地区コード
                HeaderData.ChikuCode = Convert.ToString(headerRow[UriageHeaderFile.dcChikuCode]);
                // 得意先コード
                HeaderData.TokuisakiCode = Convert.ToString(headerRow[UriageHeaderFile.dcTokuisakiCode]);
                // 得意先名
                HeaderData.TokuisakiName = Convert.ToString(headerRow[UriageHeaderFile.dcTokuisakiName]);
                // 得意先名カナ
                HeaderData.TokuisakiKanaName = Convert.ToString(headerRow[UriageHeaderFile.dcTokuisakiKanaName]);
                // 事業所コード
                HeaderData.JigyousyoCode = Convert.ToString(headerRow[UriageHeaderFile.dcJigyousyoCode]);
                // 事業所名
                HeaderData.JigyousyoName = Convert.ToString(headerRow[UriageHeaderFile.dcJigyousyoName]);
                // 得意先担当者名
                HeaderData.TokuisakiTantousayName = Convert.ToString(headerRow[UriageHeaderFile.dcTokuisakiTantousayName]);
                // 郵便番号
                HeaderData.ZipCode = Convert.ToString(headerRow[UriageHeaderFile.dcZipCode]);
                // 住所１
                HeaderData.Addres1 = Convert.ToString(headerRow[UriageHeaderFile.dcAddres1]);
                // 住所２
                HeaderData.Addres2 = Convert.ToString(headerRow[UriageHeaderFile.dcAddres2]);
                // 担当者コード
                HeaderData.TantousyaCode = Convert.ToString(headerRow[UriageHeaderFile.dcTantousyaCode]);
                // 担当者名
                HeaderData.TantousyaName = Convert.ToString(headerRow[UriageHeaderFile.dcTantousyaName]);
                // 件名NO
                HeaderData.KenmeiNo = Convert.ToString(headerRow[UriageHeaderFile.dcKenmeiNo]);
                // 件名１
                HeaderData.Kenmei1 = Convert.ToString(headerRow[UriageHeaderFile.dcKenmei1]);
                // 件名２
                HeaderData.Kenmei2 = Convert.ToString(headerRow[UriageHeaderFile.dcKenmei2]);
                // 注文日付
                HeaderData.ChumonHizuke = CommonLogic.ToDateTime(headerRow[UriageHeaderFile.dcChumonHizuke]);
                // 指定伝票NO
                HeaderData.ShiteiDenpyoNo = Convert.ToString(headerRow[UriageHeaderFile.dcShiteiDenpyoNo]);
                // 納品日付
                HeaderData.NouhinHizuke = CommonLogic.ToDateTime(headerRow[UriageHeaderFile.dcNouhinHizuke]);
                // 工番１
                HeaderData.Kouban1 = Convert.ToString(headerRow[UriageHeaderFile.dcKouban1]);
                // 工番２
                HeaderData.Kouban2 = Convert.ToString(headerRow[UriageHeaderFile.dcKouban2]);
                // 工番３
                HeaderData.Kouban3 = Convert.ToString(headerRow[UriageHeaderFile.dcKouban3]);
                // 納品書区分
                HeaderData.NouhinsyoKubun = Convert.ToString(headerRow[UriageHeaderFile.dcNouhinsyoKubun]);
                // 備考１
                HeaderData.Bikou1 = Convert.ToString(headerRow[UriageHeaderFile.dcBikou1]);
                // 備考２
                HeaderData.Bikou2 = Convert.ToString(headerRow[UriageHeaderFile.dcBikou2]);
                // 請求日付
                HeaderData.SeikyuHizuke = CommonLogic.ToDateTime(headerRow[UriageHeaderFile.dcSeikyuHizuke]);
                // 請求区分
                HeaderData.SeikyuHuragu = Convert.ToString(headerRow[UriageHeaderFile.dcSeikyuHuragu]);
                // 明細行をまとめて出力フラグ
                HeaderData.FlgMeisaiIkkatuSyuturyoku = Convert.ToInt16(headerRow[UriageHeaderFile.dcFlgMeisaiIkkatuSyuturyoku]);
                // 更新日付
                HeaderData.KousinNichizi = CommonLogic.ToDateTime(headerRow[UriageHeaderFile.dcKousinNichizi]);
                // 管理区分
                HeaderData.KanriKubun = Convert.ToString(headerRow[UriageHeaderFile.dcKanriKubun]);
            }
            #endregion

            #region ボディデータ設定処理
            /// <summary>
            /// ボディデータ設定処理
            /// </summary>
            /// <param name="bodyData"></param>
            public void setBodyData(DataTable bodyData)
            {
                if (bodyData == null || bodyData.Rows.Count == 0) return;

                DataRow bodyRow;
                UriageBodyFile wkUriageBodyInfo;
                for (int i = 0; i < bodyData.Rows.Count; i++)
                {
                    bodyRow = bodyData.Rows[i];
                    wkUriageBodyInfo = new UriageBodyFile();

                    // データ存在フラグ
                    wkUriageBodyInfo.FlgDataExsit = true;
                    // 伝票NO
                    wkUriageBodyInfo.DenpyoNo = Convert.ToString(bodyRow[UriageBodyFile.dcDenpyoNo]);
                    // 行番号
                    wkUriageBodyInfo.RowNo = Convert.ToInt16(bodyRow[UriageBodyFile.dcRowNo]);
                    // 受注行番号
                    wkUriageBodyInfo.JuchuRowNo = Convert.ToInt16(bodyRow[UriageBodyFile.dcJuchuRowNo]);
                    // 納品書出力フラグ
                    wkUriageBodyInfo.FlgPrint = Convert.ToInt16(bodyRow[UriageBodyFile.dcFlgPrint]);
                    // 商品コード(大分類コード)
                    wkUriageBodyInfo.DaiBunruiCode = Convert.ToString(bodyRow[UriageBodyFile.dcDaiBunruiCode]);
                    // 商品コード(小類コード)
                    wkUriageBodyInfo.SyoBunruiCode = Convert.ToString(bodyRow[UriageBodyFile.dcSyoBunruiCode]);
                    // 商品コード(連番)
                    wkUriageBodyInfo.ShouhinCode = Convert.ToString(bodyRow[UriageBodyFile.dcShouhinCode]);
                    // 商品名１
                    wkUriageBodyInfo.ShouhinName1 = Convert.ToString(bodyRow[UriageBodyFile.dcShouhinName1]);
                    // 商品名２
                    wkUriageBodyInfo.ShouhinName2 = Convert.ToString(bodyRow[UriageBodyFile.dcShouhinName2]);
                    // 数量
                    wkUriageBodyInfo.Suryo = CommonLogic.ToDecimal(bodyRow[UriageBodyFile.dcSuryo]);
                    // 単位
                    wkUriageBodyInfo.Tani = Convert.ToString(bodyRow[UriageBodyFile.dcTani]);
                    // 単価
                    wkUriageBodyInfo.Tanka = CommonLogic.ToDecimal(bodyRow[UriageBodyFile.dcTanka]);
                    // 金額
                    wkUriageBodyInfo.Kingaku = CommonLogic.ToDecimal(bodyRow[UriageBodyFile.dcKingaku]);
                    // 納品状態
                    wkUriageBodyInfo.NouhinJoutai = Convert.ToString(bodyRow[UriageBodyFile.dcNouhinJoutai]);
                    // 備考
                    wkUriageBodyInfo.Bikou = Convert.ToString(bodyRow[UriageBodyFile.dcBikou]);
                    // 請求日付
                    wkUriageBodyInfo.SeikyuHizuke = CommonLogic.ToDateTime(bodyRow[UriageBodyFile.dcSeikyuHizuke]);
                    // 請求フラグ
                    wkUriageBodyInfo.SeikyuHuragu = Convert.ToString(bodyRow[UriageBodyFile.dcSeikyuHuragu]);
                    // 更新日付
                    wkUriageBodyInfo.KousinNichizi = CommonLogic.ToDateTime(bodyRow[UriageBodyFile.dcKousinNichizi]);
                    // 管理区分
                    wkUriageBodyInfo.KanriKubun = Convert.ToString(bodyRow[UriageBodyFile.dcKanriKubun]);

                    BodyDatas.Add(wkUriageBodyInfo);
                }
            }
            #endregion

            #region フッタデータ設定処理
            /// <summary>
            /// フッタデータ設定処理
            /// </summary>
            /// <param name="footerData"></param>
            public void setFooterData(DataTable footerData)
            {
                if (footerData == null || footerData.Rows.Count == 0) return;

                DataRow footerRow = footerData.Rows[0];

                // データ存在フラグ
                FooterData.FlgDataExsit = true;
                // 伝票NO
                FooterData.DenpyoNo = Convert.ToString(footerRow[UriageFooterFile.dcDenpyoNo]);
                // 売上金額
                FooterData.UriageKingaku = CommonLogic.ToDecimal(footerRow[UriageFooterFile.dcUriageKingaku]);
                // 更新日付
                FooterData.KousinNichizi = CommonLogic.ToDateTime(footerRow[UriageFooterFile.dcKousinNichizi]);
                // 管理区分
                FooterData.KanriKubun = Convert.ToString(footerRow[UriageFooterFile.dcKanriKubun]);
            }
            #endregion
        }
        #endregion

        #region 仕入データ格納クラス
        /// <summary>
        /// 仕入データ格納クラス
        /// </summary>
        public class ShireDataClass
        {
            #region 変数宣言
            /// <summary>
            /// ヘッダデータ
            /// </summary>
            private ShireHeaderFile headerData;
            /// <summary>
            /// ボディデータ
            /// </summary>
            private List<ShireBodyFile> bodyDatas;
            /// <summary>
            /// フッタデータ
            /// </summary>
            private ShireFooterFile footerData;
            #endregion

            #region 取得・設定処理
            /// <summary>
            /// ヘッダデータの取得・設定
            /// </summary>
            public ShireHeaderFile HeaderData
            {
                get { return headerData; }
                set { headerData = value; }
            }
            /// <summary>
            /// ボディデータの取得・設定
            /// </summary>
            public List<ShireBodyFile> BodyDatas
            {
                get { return bodyDatas; }
                set { bodyDatas = value; }
            }
            /// <summary>
            /// フッタデータの取得・設定
            /// </summary>
            public ShireFooterFile FooterData
            {
                get { return footerData; }
                set { footerData = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShireDataClass()
            {
                HeaderData = new ShireHeaderFile();
                BodyDatas = new List<ShireBodyFile>();
                FooterData = new ShireFooterFile();
            }
            #endregion

            #region ヘッダデータ設定処理
            /// <summary>
            /// ヘッダデータ設定処理
            /// </summary>
            /// <param name="headerRow"></param>
            public void setHeaderData(DataTable headerData)
            {
                if (headerData == null || headerData.Rows.Count == 0) return;

                DataRow headerRow = headerData.Rows[0];

                // データ存在フラグ
                HeaderData.FlgDataExsit = true;
                // 仕入NO
                HeaderData.ShireNo = Convert.ToString(headerRow[ShireHeaderFile.dcShireNo]);
                // 伝票日付
                HeaderData.DenpyoHizuke = CommonLogic.ToDateTime(headerRow[ShireHeaderFile.dcDenpyoHizuke]);
                // 受注NO(担当者コード)
                HeaderData.JuchuNoTop = Convert.ToString(headerRow[ShireHeaderFile.dcJuchuNoTop]);
                // 受注NO(月)
                HeaderData.JuchuNoMid = Convert.ToString(headerRow[ShireHeaderFile.dcJuchuNoMid]);
                // 受注NO(担当者毎受注No)
                HeaderData.JuchuNoBtm = Convert.ToString(headerRow[ShireHeaderFile.dcJuchuNoBtm]);
                // 地方コード
                HeaderData.ChihouCode = Convert.ToString(headerRow[ShireHeaderFile.dcChihouCode]);
                // 地区コード
                HeaderData.ChikuCode = Convert.ToString(headerRow[ShireHeaderFile.dcChikuCode]);
                // 得意先コード
                HeaderData.TokuisakiCode = Convert.ToString(headerRow[ShireHeaderFile.dcTokuisakiCode]);
                // 得意先名
                HeaderData.TokuisakiName = Convert.ToString(headerRow[ShireHeaderFile.dcTokuisakiName]);
                // 得意先名カナ
                HeaderData.TokuisakiKanaName = Convert.ToString(headerRow[ShireHeaderFile.dcTokuisakiKanaName]);
                // 事業所コード
                HeaderData.JigyousyoCode = Convert.ToString(headerRow[ShireHeaderFile.dcJigyousyoCode]);
                // 事業所名
                HeaderData.JigyousyoName = Convert.ToString(headerRow[ShireHeaderFile.dcJigyousyoName]);
                // 郵便番号
                HeaderData.ZipCode = Convert.ToString(headerRow[ShireHeaderFile.dcZipCode]);
                // 住所１
                HeaderData.Addres1 = Convert.ToString(headerRow[ShireHeaderFile.dcAddres1]);
                // 住所２
                HeaderData.Addres2 = Convert.ToString(headerRow[ShireHeaderFile.dcAddres2]);
                // 担当者コード
                HeaderData.TantousyaCode = Convert.ToString(headerRow[ShireHeaderFile.dcTantousyaCode]);
                // 担当者名
                HeaderData.TantousyaName = Convert.ToString(headerRow[ShireHeaderFile.dcTantousyaName]);
                // 件名NO
                HeaderData.KenmeiNo = Convert.ToString(headerRow[ShireHeaderFile.dcKenmeiNo]);
                // 件名１
                HeaderData.Kenmei1 = Convert.ToString(headerRow[ShireHeaderFile.dcKenmei1]);
                // 件名２
                HeaderData.Kenmei2 = Convert.ToString(headerRow[ShireHeaderFile.dcKenmei2]);
                // 発注番号
                HeaderData.HachuNo = Convert.ToString(headerRow[ShireHeaderFile.dcHachuNo]);
                // 仕入先コード
                HeaderData.ShiresakiCode = Convert.ToString(headerRow[ShireHeaderFile.dcShiresakiCode]);
                // 仕入先名
                HeaderData.ShiresakiName = Convert.ToString(headerRow[ShireHeaderFile.dcShiresakiName]);
                // 売上伝票No
                HeaderData.UriageDenpyoNo = Convert.ToString(headerRow[ShireHeaderFile.dcUriageDenpyoNo]);
                // 更新日付
                HeaderData.KousinNichizi = CommonLogic.ToDateTime(headerRow[ShireHeaderFile.dcKousinNichizi]);
                // 管理区分
                HeaderData.KanriKubun = Convert.ToString(headerRow[ShireHeaderFile.dcKanriKubun]);
            }
            #endregion

            #region ボディデータ設定処理
            /// <summary>
            /// ボディデータ設定処理
            /// </summary>
            /// <param name="bodyData"></param>
            public void setBodyData(DataTable bodyData)
            {
                if (bodyData == null || bodyData.Rows.Count == 0) return;

                DataRow bodyRow;
                ShireBodyFile wkShireBodyInfo;
                DateTime shimebi;
                for (int i = 0; i < bodyData.Rows.Count; i++)
                {
                    bodyRow = bodyData.Rows[i];
                    wkShireBodyInfo = new ShireBodyFile();

                    // データ存在フラグ
                    wkShireBodyInfo.FlgDataExsit = true;
                    // 仕入NO
                    wkShireBodyInfo.ShireNo = Convert.ToString(bodyRow[ShireBodyFile.dcShireNo]);
                    // 行番号
                    wkShireBodyInfo.RowNo = Convert.ToInt16(bodyRow[ShireBodyFile.dcRowNo]);
                    // 受注行番号
                    wkShireBodyInfo.JuchuRowNo = Convert.ToInt16(bodyRow[ShireBodyFile.dcJuchuRowNo]);
                    // 商品コード(大分類コード)
                    wkShireBodyInfo.DaiBunruiCode = Convert.ToString(bodyRow[ShireBodyFile.dcDaiBunruiCode]);
                    // 商品コード(小類コード)
                    wkShireBodyInfo.SyoBunruiCode = Convert.ToString(bodyRow[ShireBodyFile.dcSyoBunruiCode]);
                    // 商品コード(連番)
                    wkShireBodyInfo.ShouhinCode = Convert.ToString(bodyRow[ShireBodyFile.dcShouhinCode]);
                    // 商品名１
                    wkShireBodyInfo.ShouhinName1 = Convert.ToString(bodyRow[ShireBodyFile.dcShouhinName1]);
                    // 商品名２
                    wkShireBodyInfo.ShouhinName2 = Convert.ToString(bodyRow[ShireBodyFile.dcShouhinName2]);
                    // 数量
                    wkShireBodyInfo.Suryo = CommonLogic.ToDecimal(bodyRow[ShireBodyFile.dcSuryo]);
                    // 単位
                    wkShireBodyInfo.Tani = Convert.ToString(bodyRow[ShireBodyFile.dcTani]);
                    // 単価
                    wkShireBodyInfo.Tanka = CommonLogic.ToDecimal(bodyRow[ShireBodyFile.dcTanka]);
                    // 金額
                    wkShireBodyInfo.Kingaku = CommonLogic.ToDecimal(bodyRow[ShireBodyFile.dcKingaku]);
                    // 備考
                    wkShireBodyInfo.Bikou = Convert.ToString(bodyRow[ShireBodyFile.dcBikou]);
                    // 締年月日
                    if (DateTime.TryParse(Convert.ToString(bodyRow[ShireBodyFile.dcShimeNengapi]), out shimebi))
                    {
                        wkShireBodyInfo.ShimeNengapi = shimebi;
                    }
                    else
                    {
                        wkShireBodyInfo.ShimeNengapi = null;
                    }
                    // 締更新区分
                    wkShireBodyInfo.ShimeKoushinHuragu = Convert.ToString(bodyRow[ShireBodyFile.dcShimeKoushinHuragu]);
                    // 更新日付
                    wkShireBodyInfo.KousinNichizi = CommonLogic.ToDateTime(bodyRow[ShireBodyFile.dcKousinNichizi]);
                    // 管理区分
                    wkShireBodyInfo.KanriKubun = Convert.ToString(bodyRow[ShireBodyFile.dcKanriKubun]);

                    BodyDatas.Add(wkShireBodyInfo);
                }
            }
            #endregion

            #region フッタデータ設定処理
            /// <summary>
            /// フッタデータ設定処理
            /// </summary>
            /// <param name="footerData"></param>
            public void setFooterData(DataTable footerData)
            {
                if (footerData == null || footerData.Rows.Count == 0) return;

                DataRow footerRow = footerData.Rows[0];

                // データ存在フラグ
                FooterData.FlgDataExsit = true;
                // 仕入NO
                FooterData.ShireNo = Convert.ToString(footerRow[ShireFooterFile.dcShireNo]);
                // 仕入金額
                FooterData.ShireKingaku = CommonLogic.ToDecimal(footerRow[ShireFooterFile.dcShireKingaku]);
                // 更新日付
                FooterData.KousinNichizi = CommonLogic.ToDateTime(footerRow[ShireFooterFile.dcKousinNichizi]);
                // 管理区分
                FooterData.KanriKubun = Convert.ToString(footerRow[ShireFooterFile.dcKanriKubun]);
            }
            #endregion
        }
        #endregion

        #region 受注データの取得処理
        /// <summary>
        /// 受注データの取得処理
        /// </summary>
        /// <param name="juchuDocumentNo"></param>
        /// <param name="flgInit"></param>
        /// <returns></returns>
        public SelectErrorType getJuchuData(string juchuDocumentNo, string ordersNo, bool flgInit)
        {
            if (flgInit)
            {
                SelectJuchuData = new JuchuDataClass();
                SelectUriageData = new UriageDataClass();
                SelectShireData = new ShireDataClass();
            }
            string sqlHeaderCommand = string.Empty;
            string sqlBodyCommand = string.Empty;
            string sqlFooterCommand = string.Empty;

            if (!string.IsNullOrEmpty(juchuDocumentNo))
            {
                // 受注ヘッダデータ取得SQL生成
                sqlHeaderCommand += "SELECT * FROM juchu_header WHERE denpyoNo = '" + juchuDocumentNo + "' ";
            }
            else
            {
                // 受注ヘッダデータ取得SQL生成
                sqlHeaderCommand += "SELECT * FROM juchu_header WHERE CONCAT(juchunoTop, juchunoMid, juchunoBtm) = '" + ordersNo + "' ";
            }

            // 受注ヘッダデータ取得処理実行
            DataTable juchuHeaderData = executeSelect(sqlHeaderCommand, true);
            // 取得時にエラーが発生した場合
            if (DBRef < 0)
            {
                return SelectErrorType.JuchuHeader;
            }
            DataTable juchuBodyData;
            DataTable juchuFooterData;

            // 受注ヘッダデータが存在する場合
            if (juchuHeaderData != null && juchuHeaderData.Rows.Count > 0)
            {
                DataRow dRow = juchuHeaderData.Rows[0];
                string juchuNoTop = Convert.ToString(juchuHeaderData.Rows[0][JuchuHeaderFile.dcJuchuNoTop]);
                string juchuNoMid = Convert.ToString(juchuHeaderData.Rows[0][JuchuHeaderFile.dcJuchuNoMid]);
                string juchuNoBtm = Convert.ToString(juchuHeaderData.Rows[0][JuchuHeaderFile.dcJuchuNoBtm]);
                // 受注ボディデータおよび受注フッタデータ取得SQL生成
                sqlBodyCommand = string.Empty;
                sqlBodyCommand += "SELECT jb.* ";
                sqlBodyCommand += "     , nouhinTotal.totalNouhinSuryo ";
                sqlBodyCommand += "     , shireTotal.totalShireSuryo ";
                sqlBodyCommand += "FROM ";
                sqlBodyCommand += "(SELECT * FROM juchu_body ";
                sqlBodyCommand += " WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sqlBodyCommand += " AND juchuNoMid = '" + juchuNoMid + "' ";
                sqlBodyCommand += " AND juchuNoBtm = '" + juchuNoBtm + "') jb ";
                sqlBodyCommand += "LEFT JOIN(SELECT ub.juchuRowNo, SUM(ub.suryo) AS totalNouhinSuryo ";
                sqlBodyCommand += "          FROM(SELECT * ";
                sqlBodyCommand += "               FROM uriage_header ";
                sqlBodyCommand += "               WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sqlBodyCommand += "               AND juchuNoMid = '" + juchuNoMid + "' ";
                sqlBodyCommand += "               AND juchuNoBtm = '" + juchuNoBtm + "' ";
                sqlBodyCommand += "               AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "') uh ";
                sqlBodyCommand += "          INNER JOIN(SELECT * ";
                sqlBodyCommand += "                     FROM uriage_body ";
                sqlBodyCommand += "                     WHERE suryo IS NOT NULL ";
                sqlBodyCommand += "                     AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "') ub ";
                sqlBodyCommand += "          ON(uh.denpyoNo = ub.denpyoNo) ";
                sqlBodyCommand += "          GROUP BY ub.juchuRowNo ";
                sqlBodyCommand += ") nouhinTotal ";
                sqlBodyCommand += "ON(jb.rowNo = nouhinTotal.juchuRowNo) ";
                sqlBodyCommand += "LEFT JOIN(SELECT sb.juchuRowNo, SUM(sb.suryo) AS totalShireSuryo ";
                sqlBodyCommand += "FROM (SELECT* ";
                sqlBodyCommand += "      FROM shire_header ";
                sqlBodyCommand += "      WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sqlBodyCommand += "      AND juchuNoMid = '" + juchuNoMid + "' ";
                sqlBodyCommand += "      AND juchuNoBtm = '" + juchuNoBtm + "' ";
                sqlBodyCommand += "      AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "') sh ";
                sqlBodyCommand += "      INNER JOIN(SELECT * ";
                sqlBodyCommand += "                 FROM shire_body ";
                sqlBodyCommand += "                 WHERE suryo IS NOT NULL ";
                sqlBodyCommand += "                 AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "') sb ";
                sqlBodyCommand += "      ON(sh.shireNo = sb.shireNo) ";
                sqlBodyCommand += "      GROUP BY sb.juchuRowNo ";
                sqlBodyCommand += ") shireTotal ";
                sqlBodyCommand += "ON(jb.rowNo = shireTotal.juchuRowNo) ";
                sqlBodyCommand += "ORDER BY jb.rowNo ";
                sqlFooterCommand += "SELECT * FROM juchu_footer ";
                sqlFooterCommand += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sqlFooterCommand += "AND juchunoMid = '" + juchuNoMid + "' ";
                sqlFooterCommand += "AND juchunoBtm = '" + juchuNoBtm + "' ";
                // 受注ボディデータ取得処理実行
                juchuBodyData = executeSelect(sqlBodyCommand, true);
                // 取得時にエラーが発生した場合
                if (DBRef < 0) return SelectErrorType.JuchuBody;
                // 受注フッタデータ取得処理実行
                juchuFooterData = executeSelect(sqlFooterCommand, true);
                // 取得時にエラーが発生した場合
                if (DBRef < 0) return SelectErrorType.JuchuFooter;

                // 受注ヘッダデータ設定処理実行
                SelectJuchuData.setHeaderData(juchuHeaderData);
                // 受注ボディデータ設定処理実行
                SelectJuchuData.setBodyData(juchuBodyData);
                // 受注フッタデータ設定処理実行
                SelectJuchuData.setFooterData(juchuFooterData);
            }

            return SelectErrorType.None;
        }
        #endregion

        #region 納品書関連データの取得処理
        /// <summary>
        /// 納品書関連データの取得処理
        /// </summary>
        /// <param name="nouhinDocumentNo"></param>
        /// <returns></returns>
        public SelectErrorType getNouhinsyoData(string nouhinDocumentNo, bool flgInit)
        {
            SelectErrorType res = SelectErrorType.None;
            if (flgInit)
            {
                SelectJuchuData = new JuchuDataClass();
                SelectUriageData = new UriageDataClass();
                SelectShireData = new ShireDataClass();
            }
            string sqlUriageHeaderCommand = string.Empty;
            string sqlUriageBodyCommand = string.Empty;
            string sqlUriageFooterCommand = string.Empty;

            // 売上ヘッダデータ取得SQL生成
            sqlUriageHeaderCommand += "SELECT * FROM uriage_header WHERE denpyoNo = '" + nouhinDocumentNo + "' ";
            // 売上ヘッダデータ取得処理実行
            DataTable uriageHeaderData = executeSelect(sqlUriageHeaderCommand, true);
            // 取得時にエラーが発生した場合
            if (DBRef < 0)
            {
                return SelectErrorType.UriageHeader;
            }
            DataTable uriageBodyData;
            DataTable uriageFooterData;

            // 売上ヘッダデータが存在する場合
            if (uriageHeaderData != null && uriageHeaderData.Rows.Count > 0)
            {
                // 売上ボディデータおよび納品書フッタデータ取得SQL生成
                sqlUriageBodyCommand = "SELECT * FROM uriage_body ";
                sqlUriageBodyCommand += "WHERE denpyoNo = '" + nouhinDocumentNo + "' ";
                sqlUriageBodyCommand += "ORDER BY rowNo ";
                sqlUriageFooterCommand = "SELECT * FROM uriage_footer ";
                sqlUriageFooterCommand += "WHERE denpyoNo = '" + nouhinDocumentNo + "' ";
                // 売上ボディデータ取得処理実行
                uriageBodyData = executeSelect(sqlUriageBodyCommand, true);
                // 取得時にエラーが発生した場合
                if (DBRef < 0) return SelectErrorType.UriageBody;
                // 売上フッタデータ取得処理実行
                uriageFooterData = executeSelect(sqlUriageFooterCommand, true);
                // 取得時にエラーが発生した場合
                if (DBRef < 0) return SelectErrorType.UriageFooter;

                // 受注ヘッダデータ設定処理実行
                SelectUriageData.setHeaderData(uriageHeaderData);
                // 受注ボディデータ設定処理実行
                SelectUriageData.setBodyData(uriageBodyData);
                // 受注フッタデータ設定処理実行
                SelectUriageData.setFooterData(uriageFooterData);
            }

            return res;
        }
        #endregion

        #region 受注ヘッダの伝票NO取得処理
        /// <summary>
        /// 受注ヘッダの伝票NO取得処理
        /// </summary>
        /// <param name="juchuNoTop"></param>
        /// <param name="juchuNoMid"></param>
        /// <param name="juchuNoBtm"></param>
        /// <returns></returns>
        private string getJuchuDocumentNo(string juchuNoTop, string juchuNoMid, string juchuNoBtm)
        {
            string result = string.Empty;
            string sql = "SELECT * FROM juchu_header ";
            sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
            sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";

            DataTable dt = executeSelect(sql, true);
            if (dt != null && dt.Rows.Count > 0) result = Convert.ToString(dt.Rows[0][JuchuHeaderFile.dcDenpyoNo]);

            return result;
        }
        #endregion

        #region 仕入データの取得処理
        /// <summary>
        /// 仕入データの取得処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <param name="nouhinDocumentNo"></param>
        /// <param name="flgInit"></param>
        /// <returns></returns>
        public SelectErrorType getShireData(string shireNo)
        {
            SelectErrorType res = SelectErrorType.None;
            SelectJuchuData = new JuchuDataClass();
            SelectUriageData = new UriageDataClass();
            SelectShireData = new ShireDataClass();
            string sqlHeaderCommand = string.Empty;
            string sqlBodyCommand = string.Empty;
            string sqlFooterCommand = string.Empty;

            // 仕入ヘッダデータ取得SQL生成
            sqlHeaderCommand = "SELECT * FROM shire_header WHERE shireNo = '" + shireNo + "' ";

            // 仕入ヘッダデータ取得処理実行
            DataTable shireHeaderData = executeSelect(sqlHeaderCommand, true);
            // 取得時にエラーが発生した場合
            if (DBRef < 0)
            {
                return SelectErrorType.ShireHeader;
            }
            DataTable shireBodyData;
            DataTable shireFooterData;

            // 仕入ヘッダデータが存在する場合
            if (shireHeaderData != null && shireHeaderData.Rows.Count > 0)
            {
                // 受注ボディデータおよび受注フッタデータ取得SQL生成
                sqlBodyCommand += "SELECT * FROM shire_body ";
                sqlBodyCommand += "WHERE shireNo = '" + shireNo + "' ";
                sqlBodyCommand += "ORDER BY rowNo ";
                sqlFooterCommand += "SELECT * FROM shire_footer ";
                sqlFooterCommand += "WHERE shireNo = '" + shireNo + "' ";
                // 仕入ボディデータ取得処理実行
                shireBodyData = executeSelect(sqlBodyCommand, false);
                // 取得時にエラーが発生した場合
                if (DBRef < 0) return SelectErrorType.ShireBody;
                // 仕入フッタデータ取得処理実行
                shireFooterData = executeSelect(sqlFooterCommand, false);
                // 取得時にエラーが発生した場合
                if (DBRef < 0) return SelectErrorType.ShireFooter;

                // 仕入ヘッダデータ設定処理実行
                SelectShireData.setHeaderData(shireHeaderData);
                // 仕入ボディデータ設定処理実行
                SelectShireData.setBodyData(shireBodyData);
                // 仕入フッタデータ設定処理実行
                SelectShireData.setFooterData(shireFooterData);
            }

            string juchuOrderNo = SelectShireData.HeaderData.JuchuNoTop;
            juchuOrderNo += SelectShireData.HeaderData.JuchuNoMid;
            juchuOrderNo += SelectShireData.HeaderData.JuchuNoBtm;
            // 受注データ取得処理を実行
            res = getJuchuData(string.Empty, juchuOrderNo, false);

            // 納品書データ取得処理を実行
            string nouhinDocumentNo = SelectShireData.HeaderData.UriageDenpyoNo;
            res = getNouhinsyoData(nouhinDocumentNo, false);

            return res;
        }
        #endregion
    }
}
