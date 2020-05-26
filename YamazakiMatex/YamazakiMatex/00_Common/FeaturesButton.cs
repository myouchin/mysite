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
    [System.ComponentModel.ToolboxItemAttribute(typeof(System.Drawing.Design.ToolboxItem))]
    public partial class FeaturesButton : Button
    {
        private Color backColor = SystemColors.ButtonFace;
        private Font font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        public FeaturesButton()
        {
            InitializeComponent();
            this.BackColor = backColor;
            this.Font = font;
            this.TextAlign = textAlign;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        [DefaultValue(false)]
        public override bool AutoSize
        {
            get
            {
                return false;
            }
            set
            {
                base.AutoSize = value;
            }
        }
        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
        }
        public new Color BackColor
        {
            get { return backColor; }
            set
            {
                base.BackColor = backColor;
            }
        }
        public new Font Font
        {
            get { return font; }
            set
            {
                base.Font = font;
            }
        }
        public new ContentAlignment TextAlign
        {
            get { return textAlign; }
            set
            {
                base.TextAlign = textAlign;
            }
        }
    }
}
