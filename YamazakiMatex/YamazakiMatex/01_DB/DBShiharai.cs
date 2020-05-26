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
    /// 支払DBモジュール
    /// </summary>
    class DBShiharai : DBFileLayout
    {
        #region 変数宣言
        /// <summary>
        /// 支払データ格納変数
        /// </summary>
        private ShiharaiFile selectShiharaiData;
        #endregion

        #region 取得・設定処理
        /// <summary>
        /// 支払データ格納変数の取得・設定
        /// </summary>
        public ShiharaiFile SelectShiharaiData
        {
            get { return selectShiharaiData; }
            set { selectShiharaiData = value; }
        }
        #endregion

        #region データ取得時のエラー区分
        /// <summary>
        /// データ取得時のエラー区分
        /// </summary>
        public enum SelectErrorType
        {
            None = 0
          , Shiharai = 1
        }
        #endregion

        #region 支払データの取得処理
        /// <summary>
        /// 支払データの取得処理
        /// </summary>
        /// <param name="juchuDocumentNo"></param>
        /// <param name="flgInit"></param>
        /// <returns></returns>
        public SelectErrorType getShiharaiData(string shiharaiNo)
        {
            SelectShiharaiData = new ShiharaiFile();

            string sqlCommand = string.Empty;

            sqlCommand += "SELECT * FROM shiharai WHERE shiharaiNo = '" + shiharaiNo + "' ";

            // 支払データ取得処理実行
            DataTable shiharaiData = executeSelect(sqlCommand, true);
            // 取得時にエラーが発生した場合
            if (DBRef < 0)
            {
                return SelectErrorType.Shiharai;
            }

            // 支払データが存在する場合
            if (shiharaiData != null && shiharaiData.Rows.Count > 0)
            {
                // データ存在フラグ
                SelectShiharaiData.FlgDataExsit = true;
                // 仕入No
                SelectShiharaiData.ShiharaiNo = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcShiharaiNo]);
                // 支払日付
                if (string.IsNullOrEmpty(Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcShiharaiHizuke])))
                {
                    SelectShiharaiData.ShiharaiHizuke = null;
                }
                else
                {
                    SelectShiharaiData.ShiharaiHizuke = Convert.ToDateTime(shiharaiData.Rows[0][ShiharaiFile.dcShiharaiHizuke]);
                }
                // 仕入先コード
                SelectShiharaiData.ShiresakiCode = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcShiresakiCode]);
                // 仕入先名
                SelectShiharaiData.ShiresakiName = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcShiresakiName]);
                // 郵便番号
                SelectShiharaiData.ZipCode = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcZipCode]);
                // 住所１
                SelectShiharaiData.Addres1 = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcAddres1]);
                // 住所２
                SelectShiharaiData.Addres2 = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcAddres2]);
                // 現金
                if (string.IsNullOrEmpty(Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcGenkin])))
                {
                    SelectShiharaiData.Genkin = null;
                }
                else
                {
                    SelectShiharaiData.Genkin = Convert.ToDecimal(shiharaiData.Rows[0][ShiharaiFile.dcGenkin]);
                }
                // 手形
                if (string.IsNullOrEmpty(Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcTegata])))
                {
                    SelectShiharaiData.Tegata = null;
                }
                else
                {
                    SelectShiharaiData.Tegata = Convert.ToDecimal(shiharaiData.Rows[0][ShiharaiFile.dcTegata]);
                }
                // 振込
                if (string.IsNullOrEmpty(Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcHurikomi])))
                {
                    SelectShiharaiData.Hurikomi = null;
                }
                else
                {
                    SelectShiharaiData.Hurikomi = Convert.ToDecimal(shiharaiData.Rows[0][ShiharaiFile.dcHurikomi]);
                }
                // 相殺
                if (string.IsNullOrEmpty(Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcSousai])))
                {
                    SelectShiharaiData.Sousai = null;
                }
                else
                {
                    SelectShiharaiData.Sousai = Convert.ToDecimal(shiharaiData.Rows[0][ShiharaiFile.dcSousai]);
                }
                // 合計
                if (string.IsNullOrEmpty(Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcGoukei])))
                {
                    SelectShiharaiData.Goukei = null;
                }
                else
                {
                    SelectShiharaiData.Goukei = Convert.ToDecimal(shiharaiData.Rows[0][ShiharaiFile.dcGoukei]);
                }
                // 更新日付
                SelectShiharaiData.KousinNichizi = CommonLogic.ToDateTime(shiharaiData.Rows[0][ShiharaiFile.dcKousinNichizi]);
                // 管理区分
                SelectShiharaiData.KanriKubun = Convert.ToString(shiharaiData.Rows[0][ShiharaiFile.dcKanriKubun]);
            }

            return SelectErrorType.None;
        }
        #endregion
    }
}
