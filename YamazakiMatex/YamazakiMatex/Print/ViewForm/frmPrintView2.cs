using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamazakiMatex.Print.ViewForm
{
    public partial class frmPrintView2 : Form
    {
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer1 { get { return crView1; } }
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer2 { get { return crView2; } }
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer3 { get { return crView3; } }
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer4 { get { return crView4; } }
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer5 { get { return crView5; } }
        public frmPrintView2(Dictionary<string, object> dicReportSources)
        {
            InitializeComponent();

            List<string> effectivenessTabPage = new List<string>();

            int sourcesCount = 0;
            foreach (KeyValuePair<string, object> pair in dicReportSources)
            {
                effectivenessTabPage.Add(tabPreview.TabPages[sourcesCount].Name);
                tabPreview.TabPages[sourcesCount].Text = pair.Key;
                ((CrystalDecisions.Windows.Forms.CrystalReportViewer)tabPreview.TabPages[sourcesCount].Controls[0]).ReportSource = pair.Value;
                sourcesCount++;
            }

            for (int i = tabPreview.TabPages.Count - 1; i >= 0; i--)
            {
                if (!effectivenessTabPage.Contains(tabPreview.TabPages[i].Name)) tabPreview.TabPages.Remove(tabPreview.TabPages[i]);
            }
        }
    }
}
