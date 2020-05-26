using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using YamazakiMatex;
using System.Windows.Forms;

namespace DB
{
    /// <summary>
    /// DB処理基幹モジュール
    /// </summary>
    class DBCommon
    {
        #region 変数宣言
        /// <summary>
        /// 接続文字列
        /// </summary>
        private string connstr = YamazakiMatex.Properties.Settings.Default.connstr;
        /// <summary>
        /// コネクション
        /// </summary>
        private MySqlConnection connection = null;
        /// <summary>
        /// トランザクション
        /// </summary>
        private MySqlTransaction transaction = null;
        /// <summary>
        /// レコードロックコマンド
        /// </summary>
        private string lockCommand = "FOR UPDATE NOWAIT";
        /// <summary>
        /// トランザクション開始フラグ
        /// </summary>
        private bool flgTransactionStarted = false;
        /// <summary>
        /// 処理結果
        /// </summary>
        private int dbRet = 0;
        /// <summary>
        /// 処理結果の取得・設定
        /// </summary>
        public int DBRef
        {
            set { dbRet = value; }
            get { return dbRet; }
        }
        /// <summary>
        /// トランザクション開始フラグの取得・設定
        /// </summary>
        public bool FlgTransactionStarted
        {
            set { flgTransactionStarted = value; }
            get { return flgTransactionStarted; }
        }
        #endregion

        #region DB接続チェック処理
        /// <summary>
        /// DB接続チェック処理
        /// </summary>
        /// <param name="commandText">実行するSQL文</param>
        /// <returns>取得結果</returns>
        public bool checkDBConnection()
        {
            bool result = true;
            DataTable dt = new DataTable();
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                // datatableを設定
                dt = new DataTable();
                // SQL文と接続情報を指定し、データアダプタを作成
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM kaisya_master", conn);
                // 結果をdatatableに格納
                da.Fill(dt);
                dt.AcceptChanges();
            }
            catch (Exception e)
            {
                result = false;
                Console.Write(e.Message);
                DBRef = -1;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region データ取得処理(ロックなし)
        /// <summary>
        /// データ取得処理(ロックなし)
        /// </summary>
        /// <param name="commandText">実行するSQL文</param>
        /// <returns>取得結果</returns>
        public DataTable executeNoneLockSelect(String commandText)
        {
            DataTable dt = new DataTable();
            try
            {
                return executeSelect(commandText, false);
            }
            catch
            {
                return dt;
            }
        }
        #endregion

        #region データ取得処理(ロックあり)
        /// <summary>
        /// データ取得処理(ロックあり)
        /// </summary>
        /// <param name="commandText">実行するSQL文</param>
        /// <returns>取得結果</returns>
        public DataTable executeLockSelect(String commandText)
        {
            DataTable dt = new DataTable();
            try
            {
                return executeSelect(commandText, true);
            }
            catch
            {
                return dt;
            }
        }
        #endregion

        #region データ取得処理
        /// <summary>
        /// データ取得処理
        /// </summary>
        /// <param name="commandText">実行するSQL文</param>
        /// <returns>取得結果</returns>
        public DataTable executeSelect(String commandText, bool flgDataLock)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = null;
            try
            {
                if (flgDataLock)
                {
                    conn = connection;
                }
                else
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                }
                // datatableを設定
                dt = new DataTable();
                // SQL文と接続情報を指定し、データアダプタを作成
                MySqlDataAdapter da = new MySqlDataAdapter(commandText + " " + (flgDataLock ? lockCommand : string.Empty), conn);
                // 結果をdatatableに格納
                da.Fill(dt);
                dt.AcceptChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                DBRef = -1;
            }
            finally
            {
                if (!flgDataLock) conn.Close();
            }
            return dt;
        }
        #endregion

        #region トランザクション開始処理
        /// <summary>
        /// トランザクション開始処理
        /// </summary>
        public void startTransaction()
        {
            try
            {
                // トランザクション開始済みの場合
                if (FlgTransactionStarted)
                {
                    // トランザクション終了処理を実行
                    endTransaction();
                }
                DBRef = 0;
                connection = new MySqlConnection(connstr);
                connection.Open();
                transaction = connection.BeginTransaction();
                FlgTransactionStarted = true;
            }
            catch
            {
                DBRef = -1;
                if(FlgTransactionStarted) connection.Close();
            }
        }
        #endregion

        #region データ更新処理
        /// <summary>
        /// DBの更新処理を実行します。
        /// </summary>
        /// <param name="commandText">実行するSQL文</param>
        /// <returns>処理結果 0:正常終了 0以外:エラー</returns>
        public int executeDBUpdate(String commandText)
        {
            if (connection == null || transaction == null) return -1;
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(commandText, connection);
                //戻り値なしでコマンドを実行
                cmd.CommandTimeout = 99999;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.Write(e.Message);
                ret = -1;
                DBRef = -1;
            }
            return ret;
        }
        #endregion

        #region トランザクション終了処理
        /// <summary>
        /// トランザクション終了処理
        /// </summary>
        /// <param name="commandText">実行するSQL文</param>
        public void endTransaction()
        {
            if (connection == null || transaction == null) return;

            if (DBRef == 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
            connection.Close();
            FlgTransactionStarted = false;
        }
        #endregion
    }
}
