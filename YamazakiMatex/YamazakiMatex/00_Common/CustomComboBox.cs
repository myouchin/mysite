using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class CustomComboBox : ComboBox
    {
        private Control enterControl = null;
        private Control upControl = null;
        private Control downControl = null;
        private Control leftControl = null;
        private Control rightControl = null;
        private CommonLogic commonLogic;
        private String beforeSelectedValue = string.Empty;
        private Label labelControl = null;
        public CustomComboBox()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
        }

        public void setEvent()
        {
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CustomComboBox_PreviewKeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomComboBox_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CustomComboBox_MouseWheel);
            this.Enter += new EventHandler(this.CustomComboBox_Enter);
        }

        private void CustomComboBox_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            //this.DroppedDown = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void CustomComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void CustomComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            CommonLogic.KeyDownType keyDownType = CommonLogic.KeyDownType.None;
            switch (e.KeyData)
            {
                case Keys.Up:
                    //keyDownType = CommonLogic.KeyDownType.Up;
                    //e.Handled = true;
                    break;
                case Keys.Down:
                    //keyDownType = CommonLogic.KeyDownType.Down;
                    //e.Handled = true;
                    break;
                case Keys.Left:
                    if (DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        e.Handled = true;
                        keyDownType = CommonLogic.KeyDownType.Left;
                    }
                    else if (SelectionStart == 0 && SelectionLength == 0)
                    {
                        keyDownType = CommonLogic.KeyDownType.Left;
                    }
                    break;
                case Keys.Right:
                    if (DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        e.Handled = true;
                        keyDownType = CommonLogic.KeyDownType.Right;
                    }
                    else if (SelectionStart == Text.Length && SelectionLength == 0)
                    {
                        keyDownType = CommonLogic.KeyDownType.Right;
                    }
                    break;
                case Keys.Enter:
                    keyDownType = CommonLogic.KeyDownType.Enter;
                    break;
            }
            //e.Handled = true;
            if (!CommonLogic.KeyDownType.None.Equals(keyDownType)) commonLogic.setNextFocus((Control)sender, keyDownType);
        }

        [Browsable(true)]
        [Description("上キー入力時の遷移先コントロールを設定します。")]
        [Category("フォーカス動作")]
        public Control UpControl
        {
            get
            {
                return upControl;
            }
            set
            {
                upControl = value;
            }
        }
        [Browsable(true)]
        [Description("下キー入力時の遷移先コントロールを設定します。")]
        [Category("フォーカス動作")]
        public Control DownControl
        {
            get
            {
                return downControl;
            }
            set
            {
                downControl = value;
            }
        }
        [Browsable(true)]
        [Description("左キー入力時の遷移先コントロールを設定します。")]
        [Category("フォーカス動作")]
        public Control LeftControl
        {
            get
            {
                return leftControl;
            }
            set
            {
                leftControl = value;
            }
        }
        [Browsable(true)]
        [Description("右キー入力時の遷移先コントロールを設定します。")]
        [Category("フォーカス動作")]
        public Control RightControl
        {
            get
            {
                return rightControl;
            }
            set
            {
                rightControl = value;
            }
        }
        [Browsable(true)]
        [Description("Enterキー入力時の遷移先コントロールを設定します。")]
        [Category("フォーカス動作")]
        public Control EnterControl
        {
            get
            {
                return enterControl;
            }
            set
            {
                enterControl = value;
            }
        }
        [Browsable(true)]
        [Description("タイトルとして使用するコントロールを設定します。")]
        [Category("関連項目")]
        public Label LabelControl
        {
            get
            {
                return labelControl;
            }
            set
            {
                labelControl = value;
            }
        }

        public String BeforeSelectedValue
        {
            get
            {
                return beforeSelectedValue;
            }
            set
            {
                beforeSelectedValue = value;
            }
        }

        /// <summary>
        /// マウスホイール操作時のイベント
        /// </summary>
        private void CustomComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // イベントを処理済みにし、選択値が変わらないようにする
            HandledMouseEventArgs eventArgs = e as HandledMouseEventArgs;
            eventArgs.Handled = true;
        }
    }
}
