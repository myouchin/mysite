using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu;
using System.IO;
using DB;

static class Program
{
    /// <summary>
    /// ログインユーザ情報情報クラス
    /// </summary>
    public class LoginUserInfo
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        private string userId = string.Empty;
        /// <summary>
        /// ユーザー名
        /// </summary>
        private string userName = string.Empty;
        /// <summary>
        /// 権限
        /// </summary>
        private int kengen = 0;

        /// <summary>
        /// ユーザーIDの取得/設定
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        /// <summary>
        /// ユーザー名の取得/設定
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        /// <summary>
        /// 権限の取得/設定
        /// </summary>
        public int Kengen
        {
            get { return kengen; }
            set { kengen = value; }
        }
    }
    static public LoginUserInfo loginUserInfo = null;

    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        string[] allText1 = new string[3];
        Dictionary<string, string> dicDBInfo = new Dictionary<string, string>();
        try
        {
            allText1 = File.ReadAllLines("C:\\Release\\uriage.ini");
        }
        catch
        {
            MessageBox.Show("uriage.iniが存在しないため起動できません。");
            return;
        }
        string[] wkDbInfo;
        try
        {
            foreach (string dbInfo in allText1)
            {
                wkDbInfo = dbInfo.Split('=');
                dicDBInfo.Add(wkDbInfo[0], wkDbInfo[1]);
            }
            YamazakiMatex.Properties.Settings.Default.connstr = string.Empty;
            YamazakiMatex.Properties.Settings.Default.connstr += "userid=" + dicDBInfo["USR"] + "; ";
            YamazakiMatex.Properties.Settings.Default.connstr += "password=" + dicDBInfo["PAS"] + "; ";
            YamazakiMatex.Properties.Settings.Default.connstr += "database=" + dicDBInfo["DTB"] + "; ";
            YamazakiMatex.Properties.Settings.Default.connstr += "Host=" + dicDBInfo["HST"] + "";
            DBCommon common = new DBCommon();
            if (!common.checkDBConnection()) throw new Exception();
        }
        catch
        {
            MessageBox.Show("uriage.iniの設定に不備があるため起動できません。");
            return;
        }
        frmLogin login = new frmLogin();
        if (login.ShowDialog() == DialogResult.OK)
        {
            loginUserInfo = new LoginUserInfo();
            loginUserInfo.UserId = login.UserInfo.UserId;
            loginUserInfo.UserName = login.UserInfo.UserName;
            loginUserInfo.Kengen = login.UserInfo.Kengen;
            Application.Run(new frmMainMenu());
        }

        //Application.Run(new YamazakiMatex.Form1());
        
    }
}
