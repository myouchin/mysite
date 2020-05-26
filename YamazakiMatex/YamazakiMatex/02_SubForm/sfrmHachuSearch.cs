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

namespace SubForm
{
    /// <summary>
    /// 発注検索画面
    /// </summary>
    public partial class sfrmHachuSearch : Common.ChildBaseForm
    {
        List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private bool startSelect = true;
        public sfrmHachuSearch()
        {
            InitializeComponent();
            setContorolLayout(this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            closedForm();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (flgInitializeGrid)
            {
                if (grdSearchList.Rows.Count > 0) grdSearchList.Rows[0].Selected = false;
                flgInitializeGrid = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = false;
            grdSearchList.MultiSelect = true;
            grdSearchList.MultiSelect = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            grdSearchList.MultiSelect = false;
            grdSearchList.MultiSelect = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnAllSelect.Enabled = true;
            grdSearchList.MultiSelect = false;
            grdSearchList.MultiSelect = true;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (flgSetGridData) return;
            if (rdoMulti.Checked)
            {
                if (!gRows.Contains(grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex])) gRows.Add(grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex]);

                foreach (DataGridViewRow gRow in gRows)
                {
                    gRow.Selected = true;
                }
            }
            else if(rdoRange.Checked)
            {
                if (startSelect)
                {
                    gRows = new List<DataGridViewRow>();
                    gRows.Add(grdSearchList.Rows[grdSearchList.CurrentCell.RowIndex]);
                    startSelect = false;
                }
                else
                {
                    int startRowIndex = 0;
                    int endRowIndex = 0;
                    if (gRows[0].Index == grdSearchList.CurrentCell.RowIndex)
                    {
                        return;
                    }
                    else if (gRows[0].Index > grdSearchList.CurrentCell.RowIndex)
                    {
                        startRowIndex = grdSearchList.CurrentCell.RowIndex;
                        endRowIndex = gRows[0].Index;
                    }
                    else
                    {
                        startRowIndex = gRows[0].Index;
                        endRowIndex = grdSearchList.CurrentCell.RowIndex;
                    }

                    for (int i = startRowIndex; i <= endRowIndex; i++)
                    {
                        grdSearchList.Rows[i].Selected = true;
                    }
                    startSelect = true;
                }
            }
        }

        private void featuresButton1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gRow in grdSearchList.Rows)
            {
                gRow.Selected = true;
            }
        }

        private void featuresButton2_Click(object sender, EventArgs e)
        {
            allSelectionChange(grdSearchList.MultiSelect);
        }

        private void allSelectionChange(bool multiSelect)
        {
            grdSearchList.MultiSelect = !multiSelect;
            grdSearchList.MultiSelect = multiSelect;
        }

        private void setGridData()
        {
            flgSetGridData = true;
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn gClm in grdSearchList.Columns)
            {
                if (gClm.DataPropertyName.Equals("MitumoriDate"))
                {
                    dt.Columns.Add(gClm.DataPropertyName, Type.GetType("System.DateTime"));
                }
                else
                {
                    dt.Columns.Add(gClm.DataPropertyName,Type.GetType("System.String"));
                }
            }

            dt.Rows.Add(new object[] { "XXXXXXX8", "XXXXXXX8", DateTime.Now, "ＸＸＸＸＸＸＸＸＸＸＸＸＸ１５", "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ２０" });
            for (int i = 1; i < 30; i++)
            {
                dt.Rows.Add();
            }

            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
        }

        private void sfrmHachuSearch_Load(object sender, EventArgs e)
        {
            setGridData();
        }
    }
}
