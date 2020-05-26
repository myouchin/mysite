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
    public partial class CustomDataGridView : DataGridView
    {
        private Control enterControl = null;
        private Control upControl = null;
        private Control downControl = null;
        private Control leftControl = null;
        private Control rightControl = null;
        private int scrollRowCount = 3;
        private int rowSegmentCount = 1;
        private bool flgMouseWheel = false;
        private CommonLogic commonLogic;
        private int CAPTIONHEIGHT = 21;
        private int BORDERWIDTH = 2;
        public bool flgFoucasOut = false;
        private bool flgSetCurrentCell = true;

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
        [Description("スクロールバー移動時の行移動数を設定します。")]
        [Category("スクロール動作")]
        public int ScrollRowCount
        {
            get
            {
                return scrollRowCount;
            }
            set
            {
                scrollRowCount = value;
            }
        }
        [Browsable(true)]
        [Description("グリッド上における取得データの表示段数を設定します。")]
        [Category("データ")]
        public int RowSegmentCount
        {
            get
            {
                return rowSegmentCount;
            }
            set
            {
                rowSegmentCount = value;
            }
        }
        public bool FlgSetCurrentCell
        {
            get
            {
                return flgSetCurrentCell;
            }
            set
            {
                flgSetCurrentCell = value;
            }
        }
        public CustomDataGridView()
        {
            InitializeComponent();
            this.AutoGenerateColumns = false;
            commonLogic = new CommonLogic();
        }

        public void setEvent()
        {
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CustomDataGridView_PreviewKeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomDataGridView_KeyDown);
            this.VerticalScrollBar.Visible = true;
            this.VerticalScrollBar.VisibleChanged += new EventHandler(ShowScrollBars);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CustomDataGridView_Scroll);
            this.Enter += new System.EventHandler(this.CustomDataGridView_Enter);
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomDataGridView_CellClick);
            this.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomDataGridView_CellDoubleClick);
        }

        public void setDoubleBuffered()
        {
            this.DoubleBuffered = true;
        }

        private void CustomDataGridView_Enter(object sender, EventArgs e)
        {
            if (!FlgSetCurrentCell)
            {
                FlgSetCurrentCell = true;
                return;
            }
            if (this.Rows.Count == 0) return;
            if (this.SelectionMode == DataGridViewSelectionMode.CellSelect)
            {
                if (this.CurrentCell == null)
                {
                    bool flgBreak = false;
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        if (!this.Rows[i].Displayed) continue;
                        for (int j = 0; j < this.Columns.Count; j++)
                        {
                            if (!this.Columns[j].Displayed) continue;
                            if (!this.Rows[i].Cells[j].ReadOnly)
                            {
                                this.CurrentCell = this[j, i];
                                flgBreak = true;
                                break;
                            }
                        }
                        if (flgBreak) break;
                    }
                }
                else
                {
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        if (!this.Rows[this.CurrentCell.RowIndex].Cells[i].ReadOnly)
                        {
                            try { this.CurrentCell = this[i, this.CurrentCell.RowIndex]; }
                            catch { }
                            break;
                        }
                    }
                    this.BeginEdit(true);
                }
            }
            else
            {
                if (this.CurrentCell == null)
                {
                    this.Rows[0].Selected = true;
                }
                else
                {
                    this.Rows[this.CurrentCell.RowIndex].Selected = true;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void CustomDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void CustomDataGridView_KeyDown(object sender, KeyEventArgs e)
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
            if (this.CurrentCell != null && CommonLogic.KeyDownType.Up.Equals(keyDownType) && this.CurrentCell.RowIndex != 0) return;
            if (!CommonLogic.KeyDownType.None.Equals(keyDownType)) commonLogic.setNextFocus((Control)sender, keyDownType);
        }
        private void ShowScrollBars(object sender, EventArgs e)
        {
            if (!this.VerticalScrollBar.Visible)
            {
                int width = this.VerticalScrollBar.Width;
                this.VerticalScrollBar.Location = new Point(this.ClientRectangle.Width - width - BORDERWIDTH + 1, 2);
                this.VerticalScrollBar.Size = new Size(width, this.ClientRectangle.Height - CAPTIONHEIGHT - BORDERWIDTH + 4);
                this.HorizontalScrollBar.Size = new Size(this.HorizontalScrollBar.Size.Width - this.VerticalScrollBar.Size.Width, this.HorizontalScrollBar.Size.Height);
                this.VerticalScrollBar.Show();
            }
        }

        // ホイールマウス制御  
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            flgMouseWheel = true;

            Int32 scroll = SystemInformation.MouseWheelScrollLines;

            int delta = e.Delta / scroll * ScrollRowCount;

            // MouseEventArgsクラスの移動量を変更  
            MouseEventArgs ex = new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, delta);

            base.OnMouseWheel(ex);

            flgMouseWheel = false;
        }

        private void CustomDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (flgMouseWheel) return;
            if (e.NewValue > e.OldValue)
            {
                // 下に移動
                if ((e.NewValue % ScrollRowCount) != 0)
                {
                    e.NewValue++;
                }
            }
            else
            {
                // 上に移動
                if ((e.NewValue % ScrollRowCount) != 0)
                {
                    e.NewValue--;
                }
            }
        }

        bool suppressCellValidating = false;

        [System.Security.Permissions.UIPermission(
           System.Security.Permissions.SecurityAction.LinkDemand,
           Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {
                flgFoucasOut = true;
                suppressCellValidating = false;

                int rowCount = this.Rows.Count;

                if (setCurrentCell(keyData))
                {
                    flgFoucasOut = false;
                    return true;
                }
                flgFoucasOut = false;

                bool ret = base.ProcessDialogKey(keyData);

                if (rowCount == this.Rows.Count)
                {
                    if (keyData == Keys.Escape)
                    {
                        this.BeginEdit(true);
                    }
                    return ret;
                }
                else
                {
                    setCurrentCell(keyData);
                    this.Refresh();
                    this.BeginEdit(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [System.Security.Permissions.SecurityPermission(
           System.Security.Permissions.SecurityAction.LinkDemand,
           Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            suppressCellValidating = false;

            try
            {
                flgFoucasOut = true;
                // ※コンボボックスセルはこっちに来る
                if (setCurrentCell(e.KeyData))
                {
                    flgFoucasOut = false;
                    return true;
                }
                flgFoucasOut = false;


                bool ret= base.ProcessDataGridViewKey(e);

                if (e.KeyData == Keys.Escape)
                {
                    this.BeginEdit(true);
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private bool setCurrentCell(Keys inputKey)
        {
            bool flgSetCurrent = false;
            if (this.Rows.Count == 0) return flgSetCurrent;
            if (this.CurrentCell == null) return flgSetCurrent;
            if (this.SelectionMode != DataGridViewSelectionMode.CellSelect) return flgSetCurrent;

            int startRowIndex = this.CurrentCell.RowIndex;
            int startClmIndex = this.CurrentCell.ColumnIndex;
            DataGridViewCell _CurrentCell = this.CurrentCell;
            string editedFormattedValue = Convert.ToString(this.CurrentCell.EditedFormattedValue);

            if ((inputKey & Keys.KeyCode) == Keys.Enter ||
                (inputKey & Keys.KeyCode) == Keys.Tab)
            {
                int topRowIndex = this.CurrentCell.RowIndex % rowSegmentCount == 0 ? this.CurrentCell.RowIndex : this.CurrentCell.RowIndex - (this.CurrentCell.RowIndex % rowSegmentCount);
                int[] rowIndexs = new int[rowSegmentCount];
                string[] gColumns = new string[this.Columns.Count];
                try
                {
                    this.CurrentCell = null;
                }
                catch
                {
                    return true;
                }
                // Shift+EnterまたはShift+Tabの場合、左に移動
                if (inputKey.ToString() == Keys.Enter.ToString() + ", " + Keys.Shift.ToString() ||
                    inputKey.ToString() == Keys.Tab.ToString() + ", " + Keys.Shift.ToString())
                {
                    for (int i = rowSegmentCount - 1; i >= 0; i--)
                    {
                        rowIndexs[i] = topRowIndex;
                        topRowIndex++;
                    }

                    for (int i = startClmIndex; i >= 0; i--)
                    {
                        for (int j = 0; j < rowIndexs.Length; j++)
                        {
                            if (rowIndexs[j] >= startRowIndex && startClmIndex == i) continue;
                            if (!this.Rows[rowIndexs[j]].Cells[i].ReadOnly)
                            {
                                try
                                {
                                    this.CurrentCell = this.Rows[rowIndexs[j]].Cells[i];
                                }
                                catch
                                {
                                    return true;
                                }
                                flgSetCurrent = true;
                                break;
                            }
                        }
                        if (flgSetCurrent) break;

                        if (i == 0)
                        {
                            if (rowIndexs[rowIndexs.Length - 1] == 0)
                            {
                                break;
                            }
                            for (int k = 0; k < rowIndexs.Length; k++)
                            {
                                rowIndexs[k] -= rowSegmentCount;
                            }
                            i = this.Columns.Count;
                        }
                    }
                    if (!flgSetCurrent)
                    {
                        this.cellValidatingCancel = true;
                    }
                }
                else
                {
                    for (int i = 0; i < rowIndexs.Length; i++)
                    {
                        rowIndexs[i] = topRowIndex;
                        topRowIndex++;
                    }
                    for (int i = startClmIndex; i < this.Columns.Count; i++)
                    {
                        for (int j = 0; j < rowIndexs.Length; j++)
                        {
                            if (rowIndexs[j] <= startRowIndex && startClmIndex == i) continue;
                            if (!this.Rows[rowIndexs[j]].Cells[i].ReadOnly)
                            {
                                try
                                {
                                    this.CurrentCell = this.Rows[rowIndexs[j]].Cells[i];
                                }
                                catch
                                {
                                    return true;
                                }
                                flgSetCurrent = true;
                                break;
                            }
                        }
                        if (flgSetCurrent) break;

                        if (i == this.Columns.Count - 1)
                        {
                            if (rowIndexs[rowIndexs.Length - 1] == this.Rows.Count - 1)
                            {
                                break;
                            }
                            for (int k = 0; k < rowIndexs.Length; k++)
                            {
                                rowIndexs[k] += rowSegmentCount;
                            }
                            i = -1;
                        }
                    }
                    if (!flgSetCurrent && !string.IsNullOrEmpty(editedFormattedValue))
                    {
                        return false;
                    }
                    else if (!flgSetCurrent)
                    {
                        this.cellValidatingCancel = true;
                    }
                }
                flgSetCurrent = true;
                setBeforeCurrentCell(_CurrentCell);
            }
            else if (inputKey == Keys.Up)
            {
                for (int i = startRowIndex - 1; i >= 0; i--)
                {
                    if (!this.Rows[i].Cells[startClmIndex].ReadOnly)
                    {
                        try
                        {
                            this.CurrentCell = this.Rows[i].Cells[startClmIndex];
                        }
                        catch
                        {
                            return true;
                        }
                        flgSetCurrent = true;
                        break;
                    }
                }
                if (!flgSetCurrent && this.upControl != null)
                {
                    this.upControl.Focus();
                    try
                    {
                        this.CurrentCell = null;
                    }
                    catch
                    {
                        return true;
                    }
                }
                flgSetCurrent = true;
                setBeforeCurrentCell(_CurrentCell);
            }
            else if (inputKey == Keys.Down)
            {
                for (int i = startRowIndex + 1; i < this.Rows.Count; i++)
                {
                    if (!this.Rows[i].Cells[startClmIndex].ReadOnly)
                    {
                        try
                        {
                            this.CurrentCell = this.Rows[i].Cells[startClmIndex];
                        }
                        catch
                        {
                            return true;
                        }
                        break;
                    }
                }
                flgSetCurrent = true;
                setBeforeCurrentCell(_CurrentCell);
            }
            else if (inputKey == Keys.Left)
            {
                for (int i = startClmIndex - 1; i >= 0; i--)
                {
                    if (!this.Rows[startRowIndex].Cells[i].ReadOnly)
                    {
                        try
                        {
                            this.CurrentCell = this.Rows[startRowIndex].Cells[i];
                        }
                        catch
                        {
                            return true;
                        }
                        break;
                    }
                }
                flgSetCurrent = true;
                setBeforeCurrentCell(_CurrentCell);
            }
            else if (inputKey == Keys.Right)
            {
                for (int i = startClmIndex + 1; i < this.Columns.Count; i++)
                {
                    if (!this.Rows[startRowIndex].Cells[i].ReadOnly)
                    {
                        try
                        {
                            this.CurrentCell = this.Rows[startRowIndex].Cells[i];
                        }
                        catch
                        {
                            return true;
                        }
                        break;
                    }
                }
                flgSetCurrent = true;
                setBeforeCurrentCell(_CurrentCell);
            }

            return flgSetCurrent;
        }

        bool cellValidatingCancel = false;

        protected override void OnCellValidating(DataGridViewCellValidatingEventArgs e)
        {
            if (suppressCellValidating) return;

            base.OnCellValidating(e);

            cellValidatingCancel = e.Cancel;

            //if (isEnterLast) e.Cancel = false;
        }

        private void setBeforeCurrentCell(DataGridViewCell currentCell)
        {
            if (this.cellValidatingCancel)
            {
                suppressCellValidating = true;
                this.CurrentCell = currentCell;
                BeginEdit(false);
                this.NotifyCurrentCellDirty(true);
                cellValidatingCancel = false;
            }
        }

        #region グリッドのセルクリックイベント
        /// <summary>
        /// グリッドのセルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 行ヘッダまたは列ヘッダをクリックした場合は何もしない
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 編集不可のセルを選択した場合
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
            {
                // 1行下のセルをカレントセルに設定
                setCurrentCell(e.RowIndex, e.ColumnIndex);
            }
        }
        #endregion

        #region グリッドのセルダブルクリックイベント
        /// <summary>
        /// グリッドのセルダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 行ヘッダまたは列ヘッダをクリックした場合は何もしない
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 編集不可のセルを選択した場合
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
            {
                // 1行下のセルをカレントセルに設定
                setCurrentCell(e.RowIndex, e.ColumnIndex);
            }
        }
        #endregion

        #region グリッドのカレントセル設定処理
        /// <summary>
        /// グリッドのカレントセル設定処理
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="clmIndex"></param>
        private void setCurrentCell(int rowIndex, int clmIndex)
        {
            int[] rowIndexs = new int[this.RowSegmentCount];

            rowIndexs[0] = rowIndex % this.RowSegmentCount == 0 ? rowIndex : rowIndex - (rowIndex % this.RowSegmentCount);
            for (int i = 1; i < rowIndexs.Length; i++)
            {
                rowIndexs[i] = rowIndexs[0] + i;
            }

            int topRowIndex = rowIndex % this.RowSegmentCount == 0 ? rowIndex : rowIndex - 1;
            int btmRowIndex = rowIndex % this.RowSegmentCount == 0 ? rowIndex + 1 : rowIndex;
            bool flgBreak = false;

            for (int i = clmIndex; i < this.Columns.Count; i++)
            {
                if (!this.Columns[i].Displayed) continue;
                for (int j = 0; j < rowIndexs.Length; j++)
                {
                    if (!this.Rows[rowIndexs[j]].Displayed) continue;
                    if (!this.Rows[rowIndexs[j]].Cells[i].ReadOnly && !(rowIndexs[j] <= rowIndex && i == clmIndex))
                    {
                        this.CurrentCell = this[i, rowIndexs[j]];
                        flgBreak = true;
                        break;
                    }
                }
                if (flgBreak) break;
            }
        }
        #endregion
    }
}
