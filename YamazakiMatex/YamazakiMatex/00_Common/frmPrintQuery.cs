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
    public partial class frmPrintQuery : Common.ChildBaseForm
    {
        #region 変数宣言
        /// <summary>
        /// メッセージ区分
        /// </summary>
        private MessageType messageType;
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
        /// 1行当たりの最大表示桁数
        /// </summary>
        private int oneLineMaxLength = 30;
        /// <summary>
        /// 帳票出力確認メッセージ1
        /// </summary>
        private const string printMessage1 = "";
        /// <summary>
        /// 帳票出力確認メッセージ2
        /// </summary>
        private const string printMessage2 = "※続けて{0}を出力する場合、プレビューまたは印刷ボタンを押下してください。";
        /// <summary>
        /// 帳票出力確認メッセージ3
        /// </summary>
        private const string printMessage3 = "　出力が不要の場合は、閉じるボタンを押下してください。";
        /// <summary>
        /// 帳票出力確認メッセージリスト
        /// </summary>
        private List<string> printMessages = new List<string> { printMessage1, printMessage2, printMessage3 };
        /// <summary>
        /// 画面終了区分リスト
        /// </summary>
        public enum ClosedType
        {
            None = 0
            , Close = 1
            , Preview = 2
            , Print = 3
        }
        /// <summary>
        /// 画面終了区分
        /// </summary>
        private ClosedType closedResult;
        /// <summary>
        /// 画面終了区分の取得・設定
        /// </summary>
        public ClosedType ClosedResult
        {
            get { return closedResult; }
            set { closedResult = value; }
        }
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmPrintQuery(MessageType mType, string msg, string printName)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            ClosedResult = ClosedType.None;
            messageType = mType;

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

            if (!string.IsNullOrEmpty(printName))
            {
                string wkPMsg = string.Empty;
                string wkSplitPMsg = string.Empty;
                foreach (string pMsg in printMessages)
                {
                    wkPMsg = string.Format(pMsg, printName);
                    if (wkPMsg.Length <= 30)
                    {
                        addLabelCount++;
                        createNewMessageLabel(addLabelCount, wkPMsg);
                    }
                    else
                    {
                        for (int j = 0; j < (wkPMsg.Length / oneLineMaxLength) + 1; j++)
                        {
                            addLabelCount++;
                            try
                            {
                                createNewMessageLabel(addLabelCount, wkPMsg.Substring(j * oneLineMaxLength, oneLineMaxLength));
                            }
                            catch
                            {
                                createNewMessageLabel(addLabelCount, wkPMsg.Substring(j * oneLineMaxLength, wkPMsg.Length % oneLineMaxLength));
                            }
                        }
                    }
                }
            }
            else
            {
                btnPreview.Visible = false;
                btnPrint.Visible = false;
            }

            lblMessageBase.Visible = false;
            this.Height += ((addLabelCount - 1) * lblMessageBase.Height);
            btnPreview.Location = new Point(btnPreview.Location.X, btnPreview.Location.Y + ((addLabelCount - 1) * lblMessageBase.Height));
            btnPrint.Location = new Point(btnPrint.Location.X, btnPrint.Location.Y + ((addLabelCount - 1) * lblMessageBase.Height));
            btnCheck.Location = new Point(btnCheck.Location.X, btnCheck.Location.Y + ((addLabelCount - 1) * lblMessageBase.Height));
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

        #region 確認ボタン押下イベント
        /// <summary>
        /// 確認ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            ClosedResult = ClosedType.Close;
            closedForm();
        }
        #endregion

        #region プレビューボタン押下イベント
        /// <summary>
        /// プレビューボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ClosedResult = ClosedType.Preview;
            closedForm();
        }
        #endregion

        #region 印刷ボタン押下イベント
        /// <summary>
        /// 印刷ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClosedResult = ClosedType.Print;
            closedForm();
        }
        #endregion

        #endregion
    }
}
