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
    /// 入金DBモジュール
    /// </summary>
    class DBNyukin : DBFileLayout
    {
        #region 変数宣言
        /// <summary>
        /// 入金データ格納変数
        /// </summary>
        private NyukinFile selectNyukinData;
        #endregion

        #region 取得・設定処理
        /// <summary>
        /// 支払データ格納変数の取得・設定
        /// </summary>
        public NyukinFile SelectNyukinData
        {
            get { return selectNyukinData; }
            set { selectNyukinData = value; }
        }
        #endregion

        #region データ取得時のエラー区分
        /// <summary>
        /// データ取得時のエラー区分
        /// </summary>
        public enum SelectErrorType
        {
            None = 0
          , Nyukin = 1
        }
        #endregion

        #region 入金データの取得処理
        /// <summary>
        /// 入金データの取得処理
        /// </summary>
        /// <param name="nyukinNo"></param>
        /// <returns></returns>
        public SelectErrorType getNyukiniData(string nyukinNo)
        {
            SelectNyukinData = new NyukinFile();

            string sqlCommand = string.Empty;

            sqlCommand += "SELECT * FROM nyukin WHERE (kanriKubun IS NULL OR kanriKubun <> '" + Consts.KanriCodeTypes.TYPE9 + "') AND nyukinNo = '" + nyukinNo + "' ";

            // 入金データ取得処理実行
            DataTable nyukinData = executeSelect(sqlCommand, true);
            // 取得時にエラーが発生した場合
            if (DBRef < 0)
            {
                return SelectErrorType.Nyukin;
            }

            // 支払データが存在する場合
            if (nyukinData != null && nyukinData.Rows.Count > 0)
            {
                // データ存在フラグ
                SelectNyukinData.FlgDataExsit = true;
                // 入金No
                SelectNyukinData.NyukinNo = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcNyukinNo]);
                // 支払日付
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcNyukinHizuke])))
                {
                    SelectNyukinData.NyukinHizuke = null;
                }
                else
                {
                    SelectNyukinData.NyukinHizuke = Convert.ToDateTime(nyukinData.Rows[0][NyukinFile.dcNyukinHizuke]);
                }
                // 得意先コード
                SelectNyukinData.TokuisakiCode = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTokuisakiCode]);
                // 得意先名
                SelectNyukinData.TokuisakiName = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTokuisakiName]);
                // 得意先カナ名
                SelectNyukinData.TokuisakiKanaName = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTokuisakiKanaName]);
                // 事業所コード
                SelectNyukinData.JigyousyoCode = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcJigyousyoCode]);
                // 事業所名
                SelectNyukinData.JigyousyoName = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcJigyousyoName]);
                // 地方コード
                SelectNyukinData.ChihouCode = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcChihouCode]);
                // 地区コード
                SelectNyukinData.ChikuCode = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcChikuCode]);
                // 郵便番号
                SelectNyukinData.ZipCode = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcZipCode]);
                // 住所１
                SelectNyukinData.Addres1 = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcAddres1]);
                // 住所２
                SelectNyukinData.Addres2 = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcAddres2]);
                // 担当者コード
                SelectNyukinData.TantousyaCode = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTantousyaCode]);
                // 担当者名
                SelectNyukinData.TantousyaName = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTantousyaName]);
                // 現金
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcGenkin])))
                {
                    SelectNyukinData.Genkin = null;
                }
                else
                {
                    SelectNyukinData.Genkin = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcGenkin]);
                }
                // 振込
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcHurikomi])))
                {
                    SelectNyukinData.Hurikomi = null;
                }
                else
                {
                    SelectNyukinData.Hurikomi = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcHurikomi]);
                }
                // 手数料
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTesuryo])))
                {
                    SelectNyukinData.Tesuryo = null;
                }
                else
                {
                    SelectNyukinData.Tesuryo = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcTesuryo]);
                }
                // 小切手
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcKogitte])))
                {
                    SelectNyukinData.Kogitte = null;
                }
                else
                {
                    SelectNyukinData.Kogitte = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcKogitte]);
                }
                // 手形
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTegata])))
                {
                    SelectNyukinData.Tegata = null;
                }
                else
                {
                    SelectNyukinData.Tegata = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcTegata]);
                }
                // 手形割引料
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTegataWaribiki])))
                {
                    SelectNyukinData.TegataWaribiki = null;
                }
                else
                {
                    SelectNyukinData.TegataWaribiki = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcTegataWaribiki]);
                }
                // 相殺
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcSousai])))
                {
                    SelectNyukinData.Sousai = null;
                }
                else
                {
                    SelectNyukinData.Sousai = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcSousai]);
                }
                // リベート
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcRibeto])))
                {
                    SelectNyukinData.Ribeto = null;
                }
                else
                {
                    SelectNyukinData.Ribeto = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcRibeto]);
                }
                // でんさい
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcDensai])))
                {
                    SelectNyukinData.Densai = null;
                }
                else
                {
                    SelectNyukinData.Densai = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcDensai]);
                }
                // 調整
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcTyousei])))
                {
                    SelectNyukinData.Tyousei = null;
                }
                else
                {
                    SelectNyukinData.Tyousei = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcTyousei]);
                }
                // その他
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcSonota])))
                {
                    SelectNyukinData.Sonota = null;
                }
                else
                {
                    SelectNyukinData.Sonota = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcSonota]);
                }
                // 合計
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcGoukei])))
                {
                    SelectNyukinData.Goukei = null;
                }
                else
                {
                    SelectNyukinData.Goukei = Convert.ToDecimal(nyukinData.Rows[0][NyukinFile.dcGoukei]);
                }
                // 請求日付
                if (string.IsNullOrEmpty(Convert.ToString(nyukinData.Rows[0][NyukinFile.dcSeikyuHizuke])))
                {
                    SelectNyukinData.SeikyuHizuke = null;
                }
                else
                {
                    SelectNyukinData.SeikyuHizuke = CommonLogic.ToDateTime(nyukinData.Rows[0][NyukinFile.dcSeikyuHizuke]);
                }
                // 請求区分
                SelectNyukinData.SeikyuHuragu = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcSeikyuHuragu]);
                // 更新日付
                SelectNyukinData.KousinNichizi = CommonLogic.ToDateTime(nyukinData.Rows[0][NyukinFile.dcKousinNichizi]);
                // 管理区分
                SelectNyukinData.KanriKubun = Convert.ToString(nyukinData.Rows[0][NyukinFile.dcKanriKubun]);
            }

            return SelectErrorType.None;
        }
        #endregion
    }
}
