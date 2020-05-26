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
    public partial class CustomDateTimePicker : DateTimePicker
    {
        private Control enterControl = null;
        private Control upControl = null;
        private Control downControl = null;
        private Control leftControl = null;
        private Control rightControl = null;
        private Control yearsLinkTextControl = null;
        private Control monthLinkTextControl = null;
        private Control daysLinkTextControl = null;
        private CommonLogic commonLogic;
        private DateTime? value2 = null;
        public DateTime? Value2
        {
            get { return value2; }
            set { value2 = value; }
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
        [Description("カレンダー選択値(年)を設定するテキストボックスを指定します。")]
        [Category("LinkControl")]
        public Control YearsLinkTextControl
        {
            get
            {
                return yearsLinkTextControl;
            }
            set
            {
                yearsLinkTextControl = value;
            }
        }
        [Browsable(true)]
        [Description("カレンダー選択値(月)を設定するテキストボックスを指定します。")]
        [Category("LinkControl")]
        public Control MonthLinkTextControl
        {
            get
            {
                return monthLinkTextControl;
            }
            set
            {
                monthLinkTextControl = value;
            }
        }
        [Browsable(true)]
        [Description("カレンダー選択値(日)を設定するテキストボックスを指定します。")]
        [Category("LinkControl")]
        public Control DaysLinkTextControl
        {
            get
            {
                return daysLinkTextControl;
            }
            set
            {
                daysLinkTextControl = value;
            }
        }
        public CustomDateTimePicker()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
        }

        public void setEvent()
        {
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CustomDateTimePicker_PreviewKeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomDateTimePicker_KeyDown);
            this.ValueChanged += new EventHandler(this.CustomDateTimePicker_ValueChanged);
            this.CloseUp += new EventHandler(CustomDateTimePicker_aaaaa);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void CustomDateTimePicker_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void CustomDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            CommonLogic.KeyDownType keyDownType = CommonLogic.KeyDownType.None;
            switch (e.KeyData)
            {
                case Keys.Up:
                    keyDownType = CommonLogic.KeyDownType.Up;
                    break;
                case Keys.Down:
                    keyDownType = CommonLogic.KeyDownType.Down;
                    break;
                case Keys.Left:
                    keyDownType = CommonLogic.KeyDownType.Left;
                    break;
                case Keys.Right:
                    keyDownType = CommonLogic.KeyDownType.Right;
                    break;
                case Keys.Enter:
                    keyDownType = CommonLogic.KeyDownType.Enter;
                    break;
            }
            if (!CommonLogic.KeyDownType.None.Equals(keyDownType)) commonLogic.setNextFocus((Control)sender, keyDownType);
        }

        private void CustomDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Value2 = this.Value;
            if (YearsLinkTextControl != null)
            {
                string y = this.Value.ToString("yyyy");
                YearsLinkTextControl.Text = y;
            }
            if (MonthLinkTextControl != null)
            {
                try
                {
                    string m = Convert.ToUInt16(this.Value.ToString("MM")).ToString();
                    MonthLinkTextControl.Text = m;
                }
                catch
                {
                }
            }
            if (DaysLinkTextControl != null)
            {
                try
                {
                    string d = Convert.ToUInt16(this.Value.ToString("dd")).ToString();
                    DaysLinkTextControl.Text = d;
                }
                catch
                {
                }
            }
        }

        private void CustomDateTimePicker_aaaaa(object sender, EventArgs e)
        {
        }
    }
}
