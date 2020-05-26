using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using NouhinSyo;

namespace Menu
{
    public partial class frmUriageNichijiBtm : BaseForm
    {
        public enum NouhinIraiType
        {
            Jisya = 0
            , Negurosu = 1
            , NihonDensetsu = 2
            , TouhokuDenki = 3
            , Yudensya = 4
            , AsamiDenki = 5
            , Kandenkou = 6
        }

        public frmUriageNichijiBtm()
        {
            InitializeComponent();
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            // 自社納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.Jisya));
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            // ネグロス納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.Negurosu));
        }

        private void featuresButton3_Click(object sender, EventArgs e)
        {
            // 日本電設納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.NihonDensetsu));
        }

        private void featuresButton4_Click(object sender, EventArgs e)
        {
            // 東北電気納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.TouhokuDenki));
        }

        private void featuresButton6_Click(object sender, EventArgs e)
        {
            // 雄電社納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.Yudensya));
        }

        private void featuresButton7_Click(object sender, EventArgs e)
        {
            // 浅海電機納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.AsamiDenki));
        }

        private void featuresButton8_Click(object sender, EventArgs e)
        {
            // 関電工納品書
            showChildForm(getNouhinsyoForm(NouhinIraiType.Kandenkou));
        }

        private ChildBaseForm getNouhinsyoForm(NouhinIraiType nouhinIraiType)
        {
            ChildBaseForm form = new ChildBaseForm();
            switch (nouhinIraiType)
            {
                case NouhinIraiType.Jisya:
                    form = new frmJisyaNouhinsyoInput();
                    break;
                case NouhinIraiType.Negurosu:
                    form = new frmNegurosuNouhinsyoInput();
                    break;
                case NouhinIraiType.NihonDensetsu:
                    form = new frmNihonDensetsuNouhinsyoInput();
                    break;
                case NouhinIraiType.TouhokuDenki:
                    form = new frmTouhokuDenkiNouhinsyoInput();
                    break;
                case NouhinIraiType.Yudensya:
                    form = new frmYudensyaNouhinsyoInput();
                    break;
                case NouhinIraiType.AsamiDenki:
                    form = new frmAsamiDenkiNouhinsyoInput();
                    break;
                case NouhinIraiType.Kandenkou:
                    form = new frmKandenkouNouhinsyoInput();
                    break;
            }

            return form;
        }
    }
}
