﻿using System;
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
    public partial class frmPrintView : Form
    {
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer { get { return crViewer; } }
        public frmPrintView()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
