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
    public partial class ItemHeadLabel : Label
    {
        private BorderStyle borderStyle = BorderStyle.Fixed3D;
        private Color backColor = SystemColors.ControlDark;
        private Color foreColor = Color.White;
        private Font font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        public ItemHeadLabel()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.BorderStyle = borderStyle;
            this.BackColor = backColor;
            this.ForeColor = foreColor;
            this.Font = font;
            this.Size = new System.Drawing.Size(this.Size.Width, 27);
            this.Size = new System.Drawing.Size(130, 27);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
        public new BorderStyle BorderStyle
        {
            get { return borderStyle; }
            set
            {
                base.BorderStyle = borderStyle;
            }
        }
        public new Color BackColor
        {
            get { return backColor; }
            set
            {
                base.BackColor = backColor;
            }
        }
        public new Color ForeColor
        {
            get { return foreColor; }
            set
            {
                base.ForeColor = foreColor;
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
    }
}
