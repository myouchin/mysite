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
    public partial class frmNouhinsyoInputBase : Common.ChildBaseForm
    {
        private DataTable cmbDt = new DataTable();
        private DataTable cmbDt3 = new DataTable();
        private enum NouhinsyoType
        {
            Jisya= 0
          , Negurosu = 1
          , TouhokuDenki = 2
          , Yuudensya = 3
          , AsamiDenki = 4
          , Kandenkou = 5
        }
        public Panel getPanel1()
        {
            return panel1;
        }
        private RadioButton nowActiveNouhinsyoRadio;
        public frmNouhinsyoInputBase()
        {
            InitializeComponent();
            setContorolLayout(this);

            cmbDt.Columns.Add("KeyValue", Type.GetType("System.String"));
            cmbDt.Columns.Add("DisplayText", Type.GetType("System.String"));
            cmbDt.Rows.Add(new object[] { "1", "Ｘ２" });
            cmbDt.Rows.Add(new object[] { "2", "ＡＡ" });
            cmbDt.Rows.Add(new object[] { "3", "ＢＢ" });

            DataTable cmbDt2 = new DataTable();
            cmbDt2.Columns.Add("KeyValue", Type.GetType("System.String"));
            cmbDt2.Columns.Add("DisplayText", Type.GetType("System.String"));
            cmbDt2.Rows.Add(new object[] { "1", "ＸＸＸＸＸ５" });
            cmbDt2.Rows.Add(new object[] { "2", "8%" });
            cmbDt2.Rows.Add(new object[] { "3", "10%" });
            Column7.ValueMember = "KeyValue";
            Column7.DisplayMember = "DisplayText";
            Column7.DataSource = cmbDt2;

            cmbDt3.Columns.Add("KeyValue", Type.GetType("System.String"));
            cmbDt3.Columns.Add("DisplayText", Type.GetType("System.String"));
            cmbDt3.Rows.Add(new object[] { "1", "未納入" });
            cmbDt3.Rows.Add(new object[] { "2", "納入済" });

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("OrderNo", Type.GetType("System.Decimal"));
            dt2.Columns.Add("ItemCd", Type.GetType("System.String"));
            dt2.Columns.Add("ItemNmTop", Type.GetType("System.String"));
            dt2.Columns.Add("ItemNmBottom", Type.GetType("System.String"));
            dt2.Columns.Add("TaxType", Type.GetType("System.String"));
            dt2.Columns.Add("Quantity", Type.GetType("System.Decimal"));
            dt2.Columns.Add("Unit", Type.GetType("System.String"));
            dt2.Columns.Add("Rate", Type.GetType("System.Decimal"));
            dt2.Columns.Add("Amount", Type.GetType("System.Decimal"));

            dt2.Rows.Add(new object[] { 1                                                                //NO.
                                     , "XXXXX6"                                                          //商品ｺｰﾄﾞ
                                     , "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０"    //商品名(上段)
                                     , "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ３０"    //商品名(下段)
                                     , "1"                                                               //税区分
                                     , 12345678                                                          //数量
                                     , "1"                                                               //単位
                                     , 12345678                                                          //単価
                                     , 12345678                                                          //金額
                                       }
                        );

            for (int i = 0; i < (20 * 2); i++)
            {
                dataGridView1.Rows.Add();
                ((DataGridViewTextBoxCell)dataGridView1[0, i]).Value = Convert.ToString(((Int16)i / 2) + 1);
                if (i % 2 == 0)
                {
                    ((DataGridViewComboBoxCell)dataGridView1[5, i]).DataSource = cmbDt3;
                    ((DataGridViewComboBoxCell)dataGridView1[5, i]).ValueMember = "KeyValue";
                    ((DataGridViewComboBoxCell)dataGridView1[5, i]).DisplayMember = "DisplayText";
                }
                else
                {
                    ((DataGridViewComboBoxCell)dataGridView1[5, i]).DataSource = cmbDt;
                    ((DataGridViewComboBoxCell)dataGridView1[5, i]).ValueMember = "KeyValue";
                    ((DataGridViewComboBoxCell)dataGridView1[5, i]).DisplayMember = "DisplayText";
                }
            }

            int topRowIndex;
            int bottomRowIndex;
            foreach (DataRow row in dt2.Rows)
            {
                topRowIndex = dt2.Rows.IndexOf(row) * 2;
                bottomRowIndex = topRowIndex + 1;
                // 上段行への値出力
                ((DataGridViewTextBoxCell)dataGridView1[2, topRowIndex]).Value = getGridData(row, "ItemNmTop");
                ((DataGridViewComboBoxCell)dataGridView1[5, topRowIndex]).Value = "1";
                // 下段行への値出力
                ((DataGridViewTextBoxCell)dataGridView1[1, bottomRowIndex]).Value = getGridData(row, "ItemCd");
                ((DataGridViewTextBoxCell)dataGridView1[2, bottomRowIndex]).Value = getGridData(row, "ItemNmBottom");
                ((DataGridViewComboBoxCell)dataGridView1[3, bottomRowIndex]).Value = getGridData(row, "TaxType");
                ((DataGridViewTextBoxCell)dataGridView1[4, bottomRowIndex]).Value = getGridData(row, "Quantity");
                ((DataGridViewComboBoxCell)dataGridView1[5, bottomRowIndex]).Value = getGridData(row, "Unit");
                ((DataGridViewTextBoxCell)dataGridView1[6, bottomRowIndex]).Value = getGridData(row, "Rate");
                ((DataGridViewTextBoxCell)dataGridView1[7, bottomRowIndex]).Value = getGridData(row, "Amount");
            }

            dataGridView1.Refresh();

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("TotalTitle", Type.GetType("System.String"));
            dt3.Columns.Add("Total", Type.GetType("System.Decimal"));
            dt3.Rows.Add(new object[] { "合　　　計", 12345678 });
            dataGridView3.DataSource = dt3;

            initializeNouhinsyo(NouhinsyoType.Jisya);

        }

        private object getGridData(DataRow row , String clmName)
        {
            object ret = null;
            if (row.Table.Columns[clmName].DataType == Type.GetType("System.String"))
            {
                ret = Convert.ToString(row[clmName]);
            }
            else
            {
                ret = Convert.ToDecimal(row[clmName]);
            }

            return ret;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly && e.RowIndex % 2 == 0)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex + 1];
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;

            // 行・列共にヘッダは処理しない
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            Rectangle rect;
            DataGridViewCell cell;
            // 1列目の処理
            if (e.ColumnIndex == 0)
            {
                rect = e.CellBounds;
                // 奇数行(1,3,5..行目 = RowIndexは0,2,4..)
                if (e.RowIndex % 2 == 0)
                {
                    cell = dataGridView1[e.ColumnIndex, e.RowIndex + 1];
                    //一つ下の次のセルの高さを足す
                    rect.Height += cell.Size.Height;
                }
                // 偶数行の処理
                else
                {
                    cell = dataGridView1[e.ColumnIndex, e.RowIndex - 1];
                    // 一つ上のセルの高さを足し、矩形の座標も一つ上のセルに合わす
                    rect.Height += cell.Size.Height;
                    rect.Y -= cell.Size.Height;
                }
                // セルボーダーライン分矩形の位置を補正
                rect.X -= 1;
                rect.Y -= 1;

                Color backColor = e.CellStyle.BackColor;
                Color foreColor = e.CellStyle.ForeColor;


                // 背景、セルボーダーライン、セルの値を描画
                e.Graphics.FillRectangle(new SolidBrush(backColor), rect);
                e.Graphics.DrawRectangle(new Pen(dv.GridColor), rect);
                TextRenderer.DrawText(e.Graphics
                                    , cell.FormattedValue.ToString()
                                    , e.CellStyle.Font
                                    , rect
                                    , foreColor
                                    , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                // イベント　ハンドラ内で処理を行ったことを通知
                e.Handled = true;
            }
            // ２列目と３列目の結合処理
            if (e.RowIndex % 2 == 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 7))
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            // ２列目と３列目の結合処理
            else if (e.RowIndex % 2 == 0 && e.ColumnIndex == 3)
            {
                ((DataGridViewComboBoxCell)dataGridView1[e.ColumnIndex, e.RowIndex]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            if (!dataGridView1.CurrentCell.ReadOnly)
            {
                dataGridView1.BeginEdit(true);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            closedForm();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            string[] monthes = { "", "", "", "", "", "納品状態", "", "" };

            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                String headerText = string.Empty;
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                //r1.Width = r1.Width * 2 - 2;
                r1.Width = r1.Width - 2;

                if (!string.IsNullOrEmpty(monthes[j]))
                {
                    headerText = monthes[j];
                    r1.Height = (r1.Height / 2) - 2;
                }
                else
                {
                    headerText = dataGridView1.Columns[j].HeaderText;
                    r1.Height = r1.Height - 2;
                }

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(headerText,

                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);
                if (!string.IsNullOrEmpty(monthes[j])) e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), new Point(r1.X, r1.Bottom), new Point(r1.X + r1.Width, r1.Bottom));


                //j += 2;

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersHeight = (this.dataGridView1.ColumnHeadersHeight + 6) * 2;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }
        private void DataGridView1_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                //該当する列か調べる
                DataGridView dgv = (DataGridView)sender;
                if (dgv.CurrentCell.OwningColumn is DataGridViewComboBoxColumn)
                {
                    //編集のために表示されているコントロールを取得
                    DataGridViewComboBoxEditingControl cb =
                        (DataGridViewComboBoxEditingControl)e.Control;
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }
        }
        //CellValidatingイベントハンドラ
        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //該当する列か調べる
            if (dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgv[e.ColumnIndex, e.RowIndex];

                String displayText = Convert.ToString(e.FormattedValue);
                if (!string.IsNullOrEmpty(displayText))
                {
                    DataTable dt = (DataTable)cbc.DataSource;
                    var query = dt.AsEnumerable().Where(p => p.Field<String>("DisplayText") == displayText);
                    if (query.Count() == 0)
                    {
                        dt.Rows.Add(new object[] { Convert.ToString(dt.Rows.Count + 1), displayText });
                    }

                    var query2 = dt.AsEnumerable().Where(p => p.Field<String>("DisplayText") == displayText);
                    dgv[e.ColumnIndex, e.RowIndex].Value = Convert.ToString(query2.ElementAt(0)["KeyValue"]);
                }
                else
                {
                    dgv[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
        }

        private void Control_Enter(object sender, EventArgs e)
        {
            activeControl = this.ActiveControl;
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            activeControl = null;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //String inputVal = Convert.ToString(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
            //if (e.ColumnIndex == 3 && !string.IsNullOrEmpty(inputVal))
            //{
            //    Decimal inputValDec = decimal.Zero;
            //    if (Decimal.TryParse(inputVal, out inputValDec))
            //    {
            //        dataGridView1[e.ColumnIndex, e.RowIndex].Value = inputValDec;                }
            //    else
            //    {
            //        dataGridView1[e.ColumnIndex, e.RowIndex].Value = null;
            //    }
            //}
        }

        private void nouhinsyoTypeRadio_Click(object sender, EventArgs e)
        {
            setNouhinsyo((RadioButton)sender);
        }

        private void setNouhinsyo(RadioButton radio)
        {
            if (radio.Checked) return;
            if (nouhinsyoChange())
            {
                nowActiveNouhinsyoRadio.Checked = false;
                radio.Checked = true;
                initializeNouhinsyo(getNouhinsyoType(radio.Name));
            }
        }

        private bool nouhinsyoChange()
        {
            DateTime nouTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            
            if (!string.Empty.Equals(customTextBox16.Text) ||
                !string.Empty.Equals(customTextBox17.Text) ||
                !nouTime.Equals(Convert.ToDateTime(customDateTimePicker2.Value.ToString("yyyy/MM/dd"))) ||
                !string.Empty.Equals(customTextBox18.Text) ||
                !string.Empty.Equals(customTextBox19.Text) ||
                !nouTime.Equals(Convert.ToDateTime(customDateTimePicker3.Value.ToString("yyyy/MM/dd"))) ||
                !string.Empty.Equals(customTextBox21.Text) ||
                !string.Empty.Equals(customTextBox20.Text) ||
                !string.Empty.Equals(customTextBox22.Text) ||
                !string.Empty.Equals(customTextBox25.Text) ||
                !string.Empty.Equals(customTextBox24.Text) ||
                !string.Empty.Equals(customTextBox23.Text))
            {
                if (queryYesNo("現在入力中の専用伝票内容が破棄されますがよろしいですか？") == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void initializeNouhinsyo(NouhinsyoType type)
        {
            DateTime nouTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

            // 件名NO
            customTextBox16.Text = string.Empty;
            customTextBox16.Enabled = false;
            // 注文NO
            customTextBox17.Text = string.Empty;
            customTextBox17.Enabled = false;
            // 注文年月日
            customDateTimePicker2.Value = nouTime;
            customDateTimePicker2.Enabled = false;
            // 得意先担当者名
            customTextBox18.Text = string.Empty;
            customTextBox18.Enabled = false;
            // 件名
            customTextBox19.Text = string.Empty;
            customTextBox19.Enabled = false;
            // 納品月日
            customDateTimePicker3.Value = nouTime;
            customDateTimePicker3.Enabled = false;
            // 備考
            customTextBox21.Text = string.Empty;
            customTextBox20.Text = string.Empty;
            customTextBox21.Enabled = false;
            customTextBox20.Enabled = false;
            // 事業者ｺｰﾄﾞ
            customTextBox22.Text = string.Empty;
            customTextBox22.Enabled = false;
            // 工番
            customTextBox25.Text = string.Empty;
            customTextBox24.Text = string.Empty;
            customTextBox23.Text = string.Empty;
            customTextBox25.Enabled = false;
            customTextBox24.Enabled = false;
            customTextBox23.Enabled = false;

            switch (type)
            {
                case NouhinsyoType.Jisya:
                    nowActiveNouhinsyoRadio = radioButton8;
                    customTextBox17.Enabled = true;
                    customTextBox18.Enabled = true;
                    customTextBox19.Enabled = true;
                    customDateTimePicker3.Enabled = true;
                    customTextBox21.Enabled = true;
                    customTextBox20.Enabled = true;
                    break;
                case NouhinsyoType.Negurosu:
                    nowActiveNouhinsyoRadio = radioButton7;
                    customTextBox17.Enabled = true;
                    customTextBox18.Enabled = true;
                    customTextBox21.Enabled = true;
                    customTextBox20.Enabled = true;
                    break;
                case NouhinsyoType.TouhokuDenki:
                    nowActiveNouhinsyoRadio = radioButton6;
                    customTextBox18.Enabled = true;
                    customTextBox21.Enabled = true;
                    customTextBox20.Enabled = true;
                    break;
                case NouhinsyoType.Yuudensya:
                    nowActiveNouhinsyoRadio = radioButton5;
                    customTextBox17.Enabled = true;
                    customTextBox19.Enabled = true;
                    customTextBox22.Enabled = true;
                    customTextBox25.Enabled = true;
                    customTextBox24.Enabled = true;
                    customTextBox23.Enabled = true;
                    break;
                case NouhinsyoType.AsamiDenki:
                    nowActiveNouhinsyoRadio = radioButton9;
                    customTextBox16.Enabled = true;
                    customTextBox19.Enabled = true;
                    break;
                case NouhinsyoType.Kandenkou:
                    nowActiveNouhinsyoRadio = radioButton10;
                    customDateTimePicker2.Enabled = true;
                    customTextBox25.Enabled = true;
                    customTextBox24.Enabled = true;
                    customTextBox23.Enabled = true;
                    break;
            }

        }

        private NouhinsyoType getNouhinsyoType(string radioName)
        {
            NouhinsyoType type = NouhinsyoType.Jisya;

            if (radioButton8.Name.Equals(radioName))
            {
                type = NouhinsyoType.Jisya;
            }
            else if (radioButton7.Name.Equals(radioName))
            {
                type = NouhinsyoType.Negurosu;
            }
            else if (radioButton6.Name.Equals(radioName))
            {
                type = NouhinsyoType.TouhokuDenki;
            }
            else if (radioButton5.Name.Equals(radioName))
            {
                type = NouhinsyoType.Yuudensya;
            }
            else if (radioButton9.Name.Equals(radioName))
            {
                type = NouhinsyoType.AsamiDenki;
            }
            else if (radioButton10.Name.Equals(radioName))
            {
                type = NouhinsyoType.Kandenkou;
            }

            return type;
        }
    }
}
