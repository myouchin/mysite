using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using Common;
using Resorce;
using SubForm;

namespace Common
{
    /// <summary>
    /// メッセージ出力クラス
    /// </summary>
    public partial class frmMessage : Common.ChildBaseForm
    {
        #region 変数宣言
        /// <summary>
        /// メッセージ区分
        /// </summary>
        private MessageType messageType;
        /// <summary>
        /// ボタン区分
        /// </summary>
        private ButtonType buttonType;
        /// <summary>
        /// タイトル出力文字列１
        /// </summary>
        private string strMessage = "メッセージ";
        /// <summary>
        /// タイトル出力文字列２
        /// </summary>
        private string strQuery = "確認";
        /// <summary>
        /// タイトル出力文字列３
        /// </summary>
        private string strWarning = "警告";
        /// <summary>
        /// タイトル出力文字列４
        /// </summary>
        private string strError = "エラー";
        /// <summary>
        /// OKボタン出力文字列
        /// </summary>
        private string strOk = "OK";
        /// <summary>
        /// はいボタン出力文字列
        /// </summary>
        private string strYes = "はい";
        /// <summary>
        /// いいえボタン出力文字列
        /// </summary>
        private string strNo = "いいえ";
        /// <summary>
        /// 1行当たりの最大表示桁数
        /// </summary>
        private int oneLineMaxLength = 30;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMessage(MessageType mType, ButtonType bType, string msg)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            messageType = mType;
            buttonType = bType;

            switch (messageType)
            {
                case MessageType.Message:
                    this.Text = strMessage;
                    this.Icon = SystemIcons.Information;
                    break;
                case MessageType.Query:
                    this.Text = strQuery;
                    this.Icon = SystemIcons.Question;
                    break;
                case MessageType.Warning:
                    this.Text = strWarning;
                    this.Icon = SystemIcons.Warning;
                    break;
                case MessageType.Error:
                    this.Text = strError;
                    this.Icon = SystemIcons.Error;
                    break;
            }
            switch (buttonType)
            {
                case ButtonType.Ok:
                    btn1.Visible = false;
                    btn2.Text = strOk;
                    break;
                case ButtonType.YesNo:
                    btn1.Text = strYes;
                    btn2.Text = strNo;
                    break;
            }

            string[] wkMessages = msg.Split('\r');
            int addLabelCount = 0;
            for (int i = 0; i < wkMessages.Length; i++)
            {
                if (wkMessages[i].Length <= 30)
                {
                    addLabelCount++;
                    createNewMessageLabel(addLabelCount, wkMessages[i]);
                }
                else
                {
                    for (int j = 0; j < (wkMessages[i].Length / oneLineMaxLength) + 1; j++)
                    {
                        addLabelCount++;
                        try
                        {
                            createNewMessageLabel(addLabelCount, wkMessages[i].Substring(j * oneLineMaxLength, oneLineMaxLength));
                        }
                        catch
                        {
                            createNewMessageLabel(addLabelCount, wkMessages[i].Substring(j * oneLineMaxLength, wkMessages[i].Length % oneLineMaxLength));
                        }
                    }
                }
            }
            lblMessageBase.Visible = false;
            this.Height += ((addLabelCount - 1) * lblMessageBase.Height);
            btn1.Location = new Point(btn1.Location.X, btn1.Location.Y + ((addLabelCount - 1) * lblMessageBase.Height));
            btn2.Location = new Point(btn2.Location.X, btn2.Location.Y + ((addLabelCount - 1) * lblMessageBase.Height));

            // 画面特有のイベントを追加
            setEvent(this);
        }
        #endregion

        #region メッセージ出力用ラベル生成処理
        /// <summary>
        /// メッセージ出力用ラベル生成処理
        /// </summary>
        /// <param name="no"></param>
        /// <param name="message"></param>
        private void createNewMessageLabel(int no, string message)
        {
            Label label = new Label();
            label.Name = "lblMessage" + no.ToString();
            label.AutoSize = false;
            label.Size = new Size(lblMessageBase.Width, lblMessageBase.Height);
            label.Text = message;
            pnlMessage.Controls.Add(label);
            label.Location = new Point(lblMessageBase.Location.X, lblMessageBase.Location.Y + ((no - 1) * lblMessageBase.Height));
        }
        #endregion

        #region ボタン1押下イベント
        /// <summary>
        /// ボタン1押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            switch (buttonType)
            {
                case ButtonType.YesNo:
                    DialogResult = DialogResult.Yes;
                    break;
            }
            closedForm();
        }
        #endregion

        #region ボタン2押下イベント
        /// <summary>
        /// ボタン2押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            switch (buttonType)
            {
                case ButtonType.Ok:
                    DialogResult = DialogResult.OK;
                    break;
                case ButtonType.YesNo:
                    DialogResult = DialogResult.No;
                    break;
            }
            closedForm();
        }
        #endregion

        #region 画面終了時の処理
        /// <summary>
        /// 画面終了時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (DialogResult == DialogResult.None) e.Cancel = true;
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
                    btn2_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        #endregion

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

        #endregion
    }
}
