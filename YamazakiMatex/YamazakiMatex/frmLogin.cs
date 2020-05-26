using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu;
using DB;
using Resorce;

public partial class frmLogin : Common.BaseForm
{
    /// <summary>
    /// ID：メッセージ出力用文字列
    /// </summary>
    private string strId = "ID";
    /// <summary>
    /// PassWord：メッセージ出力用文字列
    /// </summary>
    private string strPassword = "PassWord";
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
    private LoginUserInfo userInfo;
    public LoginUserInfo UserInfo
    {
        get { return userInfo; }
        set { userInfo = value; }
    }
    public frmLogin()
    {
        InitializeComponent();
        // 画面特有のイベントを追加
        setEvent(this);
    }

    private void featuresButton1_Click(object sender, EventArgs e)
    {
        // IDが未入力かつPassWordが未入力の場合
        if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtPassWord.Text))
        {
            errorOK(string.Format(Messages.M0023, strId, strPassword));
        }
        // IDが未入力の場合
        else if (string.IsNullOrEmpty(txtID.Text))
        {
            errorOK(string.Format(Messages.M0020, strId));
        }
        // PassWordが未入力の場合
        else if (string.IsNullOrEmpty(txtPassWord.Text))
        {
            errorOK(string.Format(Messages.M0020, strPassword));
        }
        else
        {
            UserInfo = new LoginUserInfo();
            DBTantousyaMaster dbTantousyaMaster = new DBTantousyaMaster();
            List<DBFileLayout.TantousyaMasterFile> wkUserInfo = dbTantousyaMaster.getLoginUserInfo(txtID.Text, txtPassWord.Text);
            if (wkUserInfo.Count() > 0)
            {
                UserInfo.UserId = wkUserInfo[0].TantousyaCode;
                UserInfo.UserName = wkUserInfo[0].TantousyaName;
                UserInfo.Kengen = Convert.ToInt16(wkUserInfo[0].Kengen);
                DialogResult = DialogResult.OK;


                // 管理者がログインした場合
                if (Consts.ClerkCode >= UserInfo.Kengen)
                {
                    // 処理日変更画面を起動
                    frmSyoribiChange frmSyoribi = new frmSyoribiChange();
                    frmSyoribi.StartPosition = FormStartPosition.CenterScreen;
                    frmSyoribi.ShowDialog();
                }

                featuresButton2_Click(null, null);
            }
            else
            {
                errorOK(Messages.M0024);
            }
        }
    }

    private void featuresButton2_Click(object sender, EventArgs e)
    {
        closedForm();
    }

    #region 画面項目へのイベント設定処理
    /// <summary>
    /// 画面項目へのイベント設定処理
    /// </summary>
    /// <param name="c"></param>
    private void setEvent(Control c)
    {
        // キー押下イベントを追加
        c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

        // FormまたはPanelの場合、子階層の項目へイベントを追加
        if (c is Form || c is Panel)
        {
            foreach (Control cc in c.Controls)
            {
                setEvent(cc);
            }
        }
    }
    #endregion

    #region Enterキー押下イベント
    /// <summary>
    /// Enterキー押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void inputObject_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyData)
        {
            // Enterキーが押下された場合
            case Keys.Enter:
                featuresButton1_Click(null, null);
                break;
            default:
                break;
        }
    }
    #endregion
}
