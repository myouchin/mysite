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
    public partial class CustomTextBox : TextBox
    {
        private Control enterControl = null;
        private Control upControl = null;
        private Control downControl = null;
        private Control leftControl = null;
        private Control rightControl = null;
        private CommonLogic commonLogic;
        private String beforeValue = string.Empty;
        private Label labelControl = null;
        public bool flgFoucasOut = false;
        public CustomTextBox()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
        }

        public void setEvent()
        {
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CustomTextBox_PreviewKeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomTextBox_KeyDown);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void CustomTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void CustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CommonLogic.KeyDownType keyDownType = CommonLogic.KeyDownType.None;
            switch (e.KeyData)
            {
                case Keys.Up:
                    keyDownType = CommonLogic.KeyDownType.Up;
                    flgFoucasOut = true;
                    break;
                case Keys.Down:
                    keyDownType = CommonLogic.KeyDownType.Down;
                    flgFoucasOut = true;
                    break;
                case Keys.Left:
                    if (SelectionStart == 0 && SelectionLength == 0)
                    {
                        keyDownType = CommonLogic.KeyDownType.Left;
                    }
                    flgFoucasOut = true;
                    break;
                case Keys.Right:
                    if (SelectionStart == Text.Length && SelectionLength == 0)
                    {
                        keyDownType = CommonLogic.KeyDownType.Right;
                    }
                    flgFoucasOut = true;
                    break;
                case Keys.Enter:
                    keyDownType = CommonLogic.KeyDownType.Enter;
                    flgFoucasOut = true;
                    break;
                case Keys.Tab:
                    flgFoucasOut = true;
                    break;
            }
            if (!CommonLogic.KeyDownType.None.Equals(keyDownType)) commonLogic.setNextFocus((Control)sender, keyDownType);
            flgFoucasOut = false;
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
        [Description("タイトルとして使用するラベルコントロールを設定します。")]
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

        public String BeforeValue
        {
            get
            {
                return beforeValue;
            }
            set
            {
                beforeValue = value;
            }
        }
    }
}
