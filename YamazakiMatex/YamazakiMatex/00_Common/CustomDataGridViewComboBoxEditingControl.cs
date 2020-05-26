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
    public partial class CustomDataGridViewComboBoxEditingControl : DataGridViewComboBoxEditingControl
    {
        private int rowIndex = 0;
        private int clmIndex = 0;
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
        public CustomDataGridViewComboBoxEditingControl()
        {
            InitializeComponent();
        }
    }
}
