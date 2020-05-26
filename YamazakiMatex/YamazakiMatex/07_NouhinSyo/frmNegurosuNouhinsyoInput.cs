using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NouhinSyo
{
    public partial class frmNegurosuNouhinsyoInput : frmNouhinsyoInputBase
    {
        public frmNegurosuNouhinsyoInput()
        {
            InitializeComponent();
            setContorolLayout(this);

            this.Size = new Size(1339, 631);
        }
    }
}
