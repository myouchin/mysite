using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace Common
{
    public partial class ChildBaseForm : BaseForm
    {
        public enum CheckMessageType
        {
            None = 0
          , inputDataUpdateQuery = 1
        }
        public ChildBaseForm()
        {
            InitializeComponent();
        }

        #region 入力文字数のバイトチェック対象項目のキー押下イベント
        /// <summary>
        /// 入力文字数のバイトチェック対象項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtByteCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            CommonLogic commonLogic = new CommonLogic();
            // 入力文字数のバイトチェックを実行
            commonLogic.inputByteCheck_KeyPress(e, text.Text, text.MaxLength);
        }
        #endregion
        //[SecurityPermission(SecurityAction.Demand,
        //    Flags = SecurityPermissionFlag.UnmanagedCode)]
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_SYSCOMMAND = 0x0112;
        //    const long SC_MOVE = 0xF010L;

        //    if (m.Msg == WM_SYSCOMMAND &&
        //        (m.WParam.ToInt64() & 0xFFF0L) == SC_MOVE)
        //    {
        //        m.Result = IntPtr.Zero;
        //        return;
        //    }

        //    base.WndProc(ref m);
        //}
    }
}
