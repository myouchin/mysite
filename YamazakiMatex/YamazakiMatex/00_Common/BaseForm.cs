using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common;

namespace Common
{
    public partial class BaseForm : Form
    {
        private static IntPtr HHook;
        private static IWin32Window parentForm;
        public Boolean flgClosePermission = false;
        public Control activeControl = null;
        /// <summary>
        /// メッセージ区分
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// メッセージ
            /// </summary>
            Message = 0
            /// <summary>
            /// 確認メッセージ
            /// </summary>
            , Query = 1
            /// <summary>
            /// 警告メッセージ
            /// </summary>
            , Warning = 2
            /// <summary>
            /// エラーメッセージ
            /// </summary>
            , Error = 3
        }
        /// <summary>
        /// ボタン区分
        /// </summary>
        public enum ButtonType
        {
            /// <summary>
            /// OKボタン
            /// </summary>
            Ok = 0
            /// <summary>
            /// Yes/Noボタン
            /// </summary>
            , YesNo = 1
            /// <summary>
            /// OK/キャンセルボタン
            /// </summary>
            , OkCancel = 1
        }
        /// <summary>
        /// 帳票出力区分
        /// </summary>
        public enum PrintType
        {
            Preview = 0,
            OutPut = 1
        }

        public class ActiveControlInfo
        {
            private Control control = null;
            private int rowIndex = 0;
            private int clmIndex = 0;
            private bool flgGridEditingControl = false;
            private int integerLength = 0;
            private int decimalLength = 0;
            private bool cancelEdit = false;
            private int maxLength = 0;
            public Control Control
            {
                get
                {
                    return control;
                }
                set
                {
                    control = value;
                }
            }
            public int RowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }
            public int ClmIndex
            {
                get
                {
                    return clmIndex;
                }
                set
                {
                    clmIndex = value;
                }
            }
            public bool FlgGridEditingControl
            {
                get
                {
                    return flgGridEditingControl;
                }
                set
                {
                    flgGridEditingControl = value;
                }
            }
            public int IntegerLength
            {
                get
                {
                    return integerLength;
                }
                set
                {
                    integerLength = value;
                }
            }
            public int DecimalLength
            {
                get
                {
                    return decimalLength;
                }
                set
                {
                    decimalLength = value;
                }
            }
            public bool CancelEdit
            {
                get
                {
                    return cancelEdit;
                }
                set
                {
                    cancelEdit = value;
                }
            }
            public int MaxLength
            {
                get
                {
                    return maxLength;
                }
                set
                {
                    maxLength = value;
                }
            }
            public ActiveControlInfo()
            {
            }
        }
        public ActiveControlInfo activeControlInfo = null;

        public BaseForm()
        {
            InitializeComponent();
        }
        public void messageOK(string msg)
        {
            //SetHook(this);
            //MessageBox.Show(msg, "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showMessageCommon(MessageType.Message, ButtonType.Ok, msg);
        }
        public void errorOK(string msg)
        {
            //SetHook(this);
            //MessageBox.Show(msg, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            showMessageCommon(MessageType.Error, ButtonType.Ok, msg);
        }
        public DialogResult queryYesNo(string msg)
        {
            //SetHook(this);
            //return MessageBox.Show(msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return showMessageCommon(MessageType.Query, ButtonType.YesNo, msg);
        }
        public DialogResult warningYesNo(string msg)
        {
            //SetHook(this);
            //return MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return showMessageCommon(MessageType.Warning, ButtonType.YesNo, msg);
        }

        private DialogResult showMessageCommon(MessageType messageType, ButtonType buttonType, string msg)
        {
            frmMessage message = new frmMessage(messageType, buttonType, msg);
            message.StartPosition = FormStartPosition.CenterScreen;
            return message.ShowDialog();
        }

        public void SetHook(IWin32Window owner)
        {
            parentForm = owner;
            // フック設定
            IntPtr hInstance = WindowsAPI.GetWindowLong(parentForm.Handle, (int)WindowsAPI.WindowLongParam.GWLP_HINSTANCE);
            IntPtr threadId = WindowsAPI.GetCurrentThreadId();
            HHook = WindowsAPI.SetWindowsHookEx((int)WindowsAPI.HookType.WH_CBT, new WindowsAPI.HOOKPROC(CBTProc), hInstance, threadId);
        }

        private IntPtr CBTProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == (int)WindowsAPI.HCBT.HCBT_ACTIVATE)
            {
                WindowsAPI.RECT rectOwner;
                WindowsAPI.RECT rectMsgBox;
                int x, y;

                // オーナーウィンドウの位置と大きさを取得
                WindowsAPI.GetWindowRect(parentForm.Handle, out rectOwner);
                // MessageBoxの位置と大きさを取得
                WindowsAPI.GetWindowRect(wParam, out rectMsgBox);

                // MessageBoxの表示位置を計算
                x = rectOwner.Left + (rectOwner.Width - rectMsgBox.Width) / 2;
                y = rectOwner.Top + (rectOwner.Height - rectMsgBox.Height) / 2;

                //MessageBoxの位置を設定
                WindowsAPI.SetWindowPos(wParam, 0, x, y, 0, 0,
                  (uint)(WindowsAPI.SetWindowPosFlags.SWP_NOSIZE | WindowsAPI.SetWindowPosFlags.SWP_NOZORDER | WindowsAPI.SetWindowPosFlags.SWP_NOACTIVATE));

                // フック解除
                WindowsAPI.UnhookWindowsHookEx(HHook);
            }
            // 次のプロシージャへのポインタ
            return WindowsAPI.CallNextHookEx(HHook, nCode, wParam, lParam);
        }
        public static class WindowsAPI
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetCurrentThreadId();

            [DllImport("user32.dll")]
            public static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hMod, IntPtr dwThreadId);

            [DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

            [DllImport("user32.dll")]
            public static extern bool UnhookWindowsHookEx(IntPtr hHook);

            [DllImport("user32.dll")]
            public static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

            public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left, Top, Right, Bottom;

                public RECT(int left, int top, int right, int bottom)
                {
                    Left = left;
                    Top = top;
                    Right = right;
                    Bottom = bottom;
                }

                public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

                public int X
                {
                    get { return Left; }
                    set { Right -= (Left - value); Left = value; }
                }

                public int Y
                {
                    get { return Top; }
                    set { Bottom -= (Top - value); Top = value; }
                }

                public int Height
                {
                    get { return Bottom - Top; }
                    set { Bottom = value + Top; }
                }

                public int Width
                {
                    get { return Right - Left; }
                    set { Right = value + Left; }
                }

                public System.Drawing.Point Location
                {
                    get { return new System.Drawing.Point(Left, Top); }
                    set { X = value.X; Y = value.Y; }
                }

                public System.Drawing.Size Size
                {
                    get { return new System.Drawing.Size(Width, Height); }
                    set { Width = value.Width; Height = value.Height; }
                }

                public static implicit operator System.Drawing.Rectangle(RECT r)
                {
                    return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
                }

                public static implicit operator RECT(System.Drawing.Rectangle r)
                {
                    return new RECT(r);
                }

                public static bool operator ==(RECT r1, RECT r2)
                {
                    return r1.Equals(r2);
                }

                public static bool operator !=(RECT r1, RECT r2)
                {
                    return !r1.Equals(r2);
                }

                public bool Equals(RECT r)
                {
                    return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
                }

                public override bool Equals(object obj)
                {
                    if (obj is RECT)
                        return Equals((RECT)obj);
                    else if (obj is System.Drawing.Rectangle)
                        return Equals(new RECT((System.Drawing.Rectangle)obj));
                    return false;
                }

                public override int GetHashCode()
                {
                    return ((System.Drawing.Rectangle)this).GetHashCode();
                }

                public override string ToString()
                {
                    return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
                }
            }

            public enum WindowLongParam
            {
                GWL_WNDPROC = -4,
                GWLP_HINSTANCE = -6,
                GWLP_HWNDPARENT = -8,
                GWL_ID = -12,
                GWL_STYLE = -16,
                GWL_EXSTYLE = -20,
                GWL_USERDATA = -21,
                DWLP_MSGRESULT = 0,
                DWLP_USER = 8,
                DWLP_DLGPROC = 4
            }


            [Flags()]
            public enum SetWindowPosFlags : uint
            {
                SWP_ASYNCWINDOWPOS = 0x4000,
                SWP_DEFERERASE = 0x2000,
                SWP_DRAWFRAME = 0x0020,
                SWP_FRAMECHANGED = 0x0020,
                SWP_HIDEWINDOW = 0x0080,
                SWP_NOACTIVATE = 0x0010,
                SWP_NOCOPYBITS = 0x0100,
                SWP_NOMOVE = 0x0002,
                SWP_NOOWNERZORDER = 0x0200,
                SWP_NOREDRAW = 0x0008,
                SWP_NOREPOSITION = 0x0200,
                SWP_NOSENDCHANGING = 0x0400,
                SWP_NOSIZE = 0x0001,
                SWP_NOZORDER = 0x0004,
                SWP_SHOWWINDOW = 0x0040,
            }

            public enum HCBT : int
            {
                HCBT_MOVESIZE = 0,
                HCBT_MINMAX = 1,
                HCBT_QS = 2,
                HCBT_CREATEWND = 3,
                HCBT_DESTROYWND = 4,
                HCBT_ACTIVATE = 5,
                HCBT_CLICKSKIPPED = 6,
                HCBT_KEYSKIPPED = 7,
                HCBT_SYSCOMMAND = 8,
                HCBT_SETFOCUS = 9,
            }


            public enum HookType : int
            {
                WH_MSGFILTER = -1,
                WH_JOURNALRECORD = 0,
                WH_JOURNALPLAYBACK = 1,
                WH_KEYBOARD = 2,
                WH_GETMESSAGE = 3,
                WH_CALLWNDPROC = 4,
                WH_CBT = 5,
                WH_SYSMSGFILTER = 6,
                WH_MOUSE = 7,
                WH_HARDWARE = 8,
                WH_DEBUG = 9,
                WH_SHELL = 10,
                WH_FOREGROUNDIDLE = 11,
                WH_CALLWNDPROCRET = 12,
                WH_KEYBOARD_LL = 13,
                WH_MOUSE_LL = 14,
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= CS_NOCLOSE;
                return createParams;
            }
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!flgClosePermission) e.Cancel = true;
        }

        public void setContorolLayout(Control pCl)
        {
            if (pCl is Form || pCl is Panel)
            {
                pCl.BackColor = SystemColors.ControlLight;
                foreach (Control cl in pCl.Controls)
                {
                    setContorolLayout(cl);
                }
            }
            else if (pCl is DataGridView)
            {
                ((DataGridView)pCl).EnableHeadersVisualStyles = false;
                ((DataGridView)pCl).ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
                ((DataGridView)pCl).ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                ((DataGridView)pCl).ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            }
        }

        public void showChildForm(ChildBaseForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ControlBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (this.ParentForm != null)
            {
                this.ParentForm.Visible = false;
            }
            else
            {
                this.Visible = false;
            }
            form.ShowDialog();
            if (this.ParentForm != null)
            {
                this.ParentForm.Visible = true;
            }
            else
            {
                this.Visible = true;
            }
        }
        public void closedForm()
        {
            flgClosePermission = true;
            this.Close();
        }

        public void setCommonEvent(Control target)
        {
            if (target is Form || target is Panel)
            {
                foreach (Control c in target.Controls)
                {
                    setCommonEvent(c);
                }
            }
            if (target is Common.CustomTextBox)
            {
                ((Common.CustomTextBox)target).setEvent();
            }
            else if (target is Common.CustomComboBox)
            {
                ((Common.CustomComboBox)target).setEvent();
            }
            else if (target is Common.CustomDateTimePicker)
            {
                ((Common.CustomDateTimePicker)target).setEvent();
            }
            else if (target is Common.CustomDataGridView)
            {
                ((Common.CustomDataGridView)target).setEvent();
            }
        }
    }
}
