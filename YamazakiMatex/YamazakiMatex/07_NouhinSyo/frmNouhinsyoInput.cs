using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using Resorce;
using Common;
using SubForm;
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;

namespace NouhinSyo
{
    public partial class frmNouhinsyoInput : Common.ChildBaseForm
    {
        #region 変数宣言
        private string wkJuchuDocumentNo = string.Empty;
        /// <summary>
        /// 納品書グリッドの初期行件数
        /// </summary>
        private int gridStartRowCount = 5;
        /// <summary>
        /// グリッド行のエラー区分
        /// </summary>
        private enum GridErrorStatus
        {
            None = 0
          , ItemCodeError = 1
          , ItemNameError = 2
          , MultiError = 3
        }
        /// <summary>
        /// 管理マスタDBモジュール
        /// </summary>
        private DBKanriMaster kanriMaster;
        /// <summary>
        /// 担当者マスタDBモジュール
        /// </summary>
        private DBTantousyaMaster tantousyaMaster;
        /// <summary>
        /// 名称マスタDBモジュール
        /// </summary>
        private DBMeisyoMaster meisyoMaster;
        /// <summary>
        /// 商品マスタDBモジュール
        /// </summary>
        private DBShouhinMaster shouhinMaster;
        /// <summary>
        /// 処理日付
        /// </summary>
        private DateTime syoriDate;
        /// <summary>
        /// 納品書区分
        /// </summary>
        private enum NouhinsyoType
        {
            Jisya = 0
          , Negurosu = 1
          , TouhokuDenki = 2
          , Yuudensya = 3
          , AsamiDenki = 4
          , Kandenkou = 5
        }
        /// <summary>
        /// 選択中の納品書ラジオボタン
        /// </summary>
        private RadioButton nowActiveNouhinsyoRadio = null;
        /// <summary>
        /// 合計行への出力文字列
        /// </summary>
        private string strTotalAmountTitle = "合　　　計";
        /// <summary>
        /// 最終編集日付項目区分
        /// </summary>
        private enum LastInputDateType
        {
            None = 0
          , DocumentDate = 1
          , OrderDate = 2
          , DeliveryDate = 3
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private CommonLogic commonLogic;
        private string dummyCode = "Dummy";
        private bool flgSetData = false;
        private bool flgSaving = false;
        private RadioButton activeModeRadioButton = null;
        private bool flgSearch = false;
        private bool flgBtnSearchSelect = false;
        private DataGridViewRow copyGridTopRow = null;
        private DataGridViewRow copyGridBtmRow = null;
        private string beforeCellValue;
        private DBNouhinsyo dataSelectDb;
        private int quantityIntegerLength = 8;
        private int quantityDecimalLength = 0;
        private int bidIntegerLength = 8;
        private int bidDecimalLength = 0;
        private int amountIntegerLength = 8;
        private int amountDecimalLength = 0;
        private string quantityFormat;
        private string bidFormat;
        private string amountFormat;
        private bool flgInitializing = false;
        private bool flgNouhinsyoDataSet = false;
        bool flgDeletingRow = false;
        sfrmJuchuSearch sJuchu;
        sfrmNouhinsyoSearch sNouhinsyo;
        sfrmTokuisakiSearch fTokuisaki;
        sfrmKenmeiSearch sKenmei;
        sfrmShouhinSearch fShouhin;

        #region 仕入ファイル登録SQLクラス
        /// <summary>
        /// 仕入ファイル登録SQLクラス
        /// </summary>
        public class ShireRegistClass
        {
            /// <summary>
            /// 仕入ヘッダ登録SQL
            /// </summary>
            string headerSql;
            /// <summary>
            /// 仕入ボディ登録SQLリスト
            /// </summary>
            List<string> bodySqlList;
            /// <summary>
            /// 仕入フッタ登録SQL
            /// </summary>
            string footerSql;
            /// <summary>
            /// 仕入No
            /// </summary>
            string shireNo;
            /// <summary>
            /// 仕入数量
            /// </summary>
            string suryo;
            /// <summary>
            /// 仕入単価
            /// </summary>
            string tanka;
            /// <summary>
            /// 仕入金額
            /// </summary>
            string kingaku;

            /// <summary>
            /// 仕入ヘッダ登録SQL取得・設定
            /// </summary>
            public string HeaderSql
            {
                get { return headerSql; }
                set { headerSql = value; }
            }
            /// <summary>
            /// 仕入ボディ登録SQLリスト
            /// </summary>
            public List<string> BodySqlList
            {
                get { return bodySqlList; }
                set { bodySqlList = value; }
            }
            /// <summary>
            /// 仕入フッタ登録SQL取得・設定
            /// </summary>
            public string FooterSql
            {
                get { return footerSql; }
                set { footerSql = value; }
            }
            /// <summary>
            /// 仕入No取得・設定
            /// </summary>
            public string ShireNo
            {
                get { return shireNo; }
                set { shireNo = value; }
            }
            /// <summary>
            /// 仕入数量取得・設定
            /// </summary>
            public string Suryo
            {
                get { return suryo; }
                set { suryo = value; }
            }
            /// <summary>
            /// 仕入単価取得・設定
            /// </summary>
            public string Tanka
            {
                get { return tanka; }
                set { tanka = value; }
            }
            /// <summary>
            /// 仕入金額取得・設定
            /// </summary>
            public string Kingaku
            {
                get { return kingaku; }
                set { kingaku = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ShireRegistClass()
            {
                HeaderSql = string.Empty;
                BodySqlList = new List<string>();
                FooterSql = string.Empty;
                ShireNo = string.Empty;
                Suryo = string.Empty;
                Tanka = string.Empty;
                Kingaku = string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// 仮伝・本伝区分 
        /// </summary>
        private enum DenpyoType
        {
            Provisional = 0
            , Formal = 1
        }

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmNouhinsyoInput()
        {
            InitializeComponent();
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                rdoNew.Enabled = false;
                rdoCorrection.Enabled = false;
                rdoDelete.Enabled = false;
                rdoReference.Checked = true;
            }
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtDocumentNo;

            commonLogic = new CommonLogic();
            kanriMaster = new DBKanriMaster();
            tantousyaMaster = new DBTantousyaMaster();
            meisyoMaster = new DBMeisyoMaster();
            shouhinMaster = new DBShouhinMaster();
            dataSelectDb = new DBNouhinsyo();
            sJuchu = new sfrmJuchuSearch(false, CheckMessageType.None);
            sNouhinsyo = new sfrmNouhinsyoSearch(false, CheckMessageType.None);
            fTokuisaki = new sfrmTokuisakiSearch(false);
            sKenmei = new sfrmKenmeiSearch(false, CheckMessageType.None);
            fShouhin = new sfrmShouhinSearch(false);

            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 単位コンボボックス設定
            setUnitCmb();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNouhinsyoInput_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            this.grdDeliveryDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDeliveryDetails.ColumnHeadersHeight = (this.grdDeliveryDetails.ColumnHeadersHeight + 6) * 2;
            this.grdDeliveryDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdDeliveryDetails.setDoubleBuffered();

            // 数量フォーマット文字列取得
            quantityFormat = commonLogic.getNumberFormatString(quantityIntegerLength, quantityDecimalLength);
            // 単価フォーマット文字列取得
            bidFormat = commonLogic.getNumberFormatString(bidIntegerLength, bidDecimalLength);
            // 金額フォーマット文字列取得
            amountFormat = commonLogic.getNumberFormatString(amountIntegerLength, amountDecimalLength);
            // 入力情報設定
            setInputInfo();

            // 画面初期化イベント実行
            initializeNouhinsyo(NouhinsyoType.Jisya);

            chkDetailPutTogether.Location = new Point(4, 11);
            chkDetailPutTogether.Size = new Size(229, 24);
        }
        #endregion

        #region 納品書明細グリッドセルクリックイベント
        /// <summary>
        /// 納品書明細グリッドセルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (grdDeliveryDetails[e.ColumnIndex, e.RowIndex].ReadOnly && e.RowIndex % 2 == 0)
            {
                grdDeliveryDetails.CurrentCell = grdDeliveryDetails[e.ColumnIndex, e.RowIndex + 1];
            }
        }
        #endregion

        #region 納品書グリッドセル描画イベント
        /// <summary>
        /// 納品書グリッドセル描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;

            // 行・列共にヘッダは処理しない
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int rowIndex = -1;
            // カレントセルがnull出ない場合
            if (grdDeliveryDetails.CurrentCell != null)
            {
                // カレントセルから上段行の行インデックを取得
                rowIndex = grdDeliveryDetails.CurrentCell.RowIndex;
                if (rowIndex % grdDeliveryDetails.RowSegmentCount == 1) rowIndex--;
            }
            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(rowIndex);

            Rectangle rect;
            DataGridViewCell cell;
            // 1列目の処理
            if (e.ColumnIndex == 0)
            {
                int rowNo = (int)(e.RowIndex / grdDeliveryDetails.RowSegmentCount) + 1;
                rect = e.CellBounds;
                // 奇数行(1,3,5..行目 = RowIndexは0,2,4..)
                if (e.RowIndex % 2 == 0)
                {
                    cell = grdDeliveryDetails[e.ColumnIndex, e.RowIndex + 1];
                    //一つ下の次のセルの高さを足す
                    rect.Height += cell.Size.Height;
                }
                // 偶数行の処理
                else
                {
                    cell = grdDeliveryDetails[e.ColumnIndex, e.RowIndex - 1];
                    // 一つ上のセルの高さを足し、矩形の座標も一つ上のセルに合わす
                    rect.Height += cell.Size.Height;
                    rect.Y -= cell.Size.Height;
                }
                // セルボーダーライン分矩形の位置を補正
                rect.X -= 1;
                rect.Y -= 1;
                cell.Value = rowNo;

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
        }
        #endregion

        #region 納品書グリッド選択セル変更イベント
        /// <summary>
        /// 納品書グリッド選択セル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdDeliveryDetails.CurrentCell == null) return;
            if (!grdDeliveryDetails.CurrentCell.ReadOnly)
            {
                beforeCellValue = Convert.ToString(grdDeliveryDetails.CurrentCell.Value);
                grdDeliveryDetails.BeginEdit(true);
            }
        }
        #endregion

        #region 納品書グリッド描画処理
        /// <summary>
        /// 納品書グリッド描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_Paint(object sender, PaintEventArgs e)
        {

            string[] monthes = { "", "", "", "", "", "", "納品状態", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            for (int j = 0; j < grdDeliveryDetails.ColumnCount; j++)
            {
                String headerText = string.Empty;
                Rectangle r1 = this.grdDeliveryDetails.GetCellDisplayRectangle(j, -1, true); //get the column header cell

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
                    headerText = grdDeliveryDetails.Columns[j].HeaderText;
                    r1.Height = r1.Height - 2;
                }

                e.Graphics.FillRectangle(new SolidBrush(this.grdDeliveryDetails.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(headerText,

                    this.grdDeliveryDetails.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.grdDeliveryDetails.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);
                if (!string.IsNullOrEmpty(monthes[j])) e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), new Point(r1.X, r1.Bottom), new Point(r1.X + r1.Width, r1.Bottom));


                //j += 2;

            }
        }
        #endregion

        #region 納品書グリッド編集開始イベント
        /// <summary>
        /// 納品書グリッド編集開始イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            CustomDataGridView dgv = (CustomDataGridView)sender;

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = e.Control;
            activeControlInfo.RowIndex = dgv.CurrentCell.RowIndex;
            activeControlInfo.ClmIndex = dgv.CurrentCell.ColumnIndex;
            activeControlInfo.FlgGridEditingControl = true;

            // コントロールがDataGridViewComboBoxEditingControlの場合
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                // 最大入力桁数を設定
                ((DataGridViewComboBoxEditingControl)e.Control).MaxLength = 3;
                activeControlInfo.MaxLength = ((DataGridViewComboBoxEditingControl)e.Control).MaxLength;
                // DropDownStyleをドロップダウンに変更
                ((DataGridViewComboBoxEditingControl)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            }
            else if (e.Control is DataGridViewTextBoxEditingControl)
            {
                // 入力制御イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyPress -= new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);
                ((DataGridViewTextBoxEditingControl)e.Control).KeyPress -= new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                // 商品ｺｰﾄﾞセルの場合
                if (activeControlInfo.ClmIndex == clmItemCode.Index)
                {
                    // 最大入力桁数を設定
                    ((DataGridViewTextBoxEditingControl)e.Control).MaxLength = 5;
                    activeControlInfo.MaxLength = ((DataGridViewTextBoxEditingControl)e.Control).MaxLength;
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);
                }
                // 商品名セルの場合
                else if (activeControlInfo.ClmIndex == clmItemName.Index)
                {
                    // 最大入力桁数を設定
                    ((DataGridViewTextBoxEditingControl)e.Control).MaxLength = 30;
                    activeControlInfo.MaxLength = ((DataGridViewTextBoxEditingControl)e.Control).MaxLength;
                }
                // 数量セルの場合
                else if (activeControlInfo.ClmIndex == clmQuantity.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = quantityIntegerLength;
                    activeControlInfo.DecimalLength = quantityDecimalLength;
                }
                // 単価セルの場合
                else if (activeControlInfo.ClmIndex == clmBid.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = bidIntegerLength;
                    activeControlInfo.DecimalLength = bidDecimalLength;
                }
                // 金額セルの場合
                else if (activeControlInfo.ClmIndex == clmAmount.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = amountIntegerLength;
                    activeControlInfo.DecimalLength = amountDecimalLength;
                }
            }
            setSearchButtonEnabled();
        }
        #endregion

        #region 納品書グリッドセル検証イベント
        /// <summary>
        /// 納品書グリッドセル検証イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CustomDataGridView dgv = (CustomDataGridView)sender;
            if (rdoReference.Checked || rdoDelete.Checked) return;
            if (dgv.CurrentCell.ReadOnly) return;
            // 単位セルの場合
            if ((dgv.CurrentCell.RowIndex % dgv.RowSegmentCount != 0) && (dgv.CurrentCell.ColumnIndex == clmDeliveryStatusAndUnit.DisplayIndex))
            {
                // コンボボックス内のリストを更新
                UpdateCmbList(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, e.FormattedValue, ref dgv);
            }
            // 商品ｺｰﾄﾞセルの場合
            else if (dgv.CurrentCell.ColumnIndex == clmItemCode.DisplayIndex)
            {
                activeControlInfo.CancelEdit = false;
                if (flgBtnSearchSelect && !dgv.flgFoucasOut)
                {
                    activeControlInfo.CancelEdit = true;
                    dgv.CancelEdit();
                    return;
                }
                string inputText = Convert.ToString(e.FormattedValue);
                string inputItemCode = inputText;
                decimal dec;
                if (!string.IsNullOrEmpty(inputText) && decimal.TryParse(inputText, out dec))
                {
                    inputItemCode = commonLogic.getZeroBuriedNumberText(inputText, activeControlInfo.MaxLength);
                }
                // 入力した商品ｺｰﾄﾞが存在しない場合
                if (!string.IsNullOrEmpty(inputItemCode) && !shouhinMaster.checkExistShouhinInfo(inputItemCode))
                {
                    errorOK(string.Format(Messages.M0003, "商品ｺｰﾄﾞ"));
                    e.Cancel = true;
                    dgv.FlgSetCurrentCell = false;
                }
            }
        }
        #endregion

        #region 画面項目フォーカスインイベント
        /// <summary>
        /// 画面項目フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Enter(object sender, EventArgs e)
        {
            activeControl = this.ActiveControl;
        }
        #endregion

        #region 画面項目フォーカスアウトイベント
        /// <summary>
        /// 画面項目フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Leave(object sender, EventArgs e)
        {
            activeControl = null;
        }
        #endregion

        #region 納品書グリッド編集確定処理
        /// <summary>
        /// 納品書グリッド編集確定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDeliveryDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string inputValue = Convert.ToString(grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
            bool flgRecalcMeisai = false;
            bool flgRecalcSyukei = false;
            if (flgInitializing) return;

            // 出力セルの場合
            if (grdDeliveryDetails.Columns[e.ColumnIndex].Name == clmCheckPrint.Name)
            {
                recalcSyukei();
            }
            // 商品ｺｰﾄﾞ列の場合
            else if (e.ColumnIndex == clmItemCode.DisplayIndex && !flgDeletingRow)
            {
                if (activeControlInfo.CancelEdit) return;
                string inputItemCode = inputValue;
                decimal dec;
                if (decimal.TryParse(inputValue, out dec))
                {
                    inputItemCode = commonLogic.getZeroBuriedNumberText(inputValue, activeControlInfo.MaxLength);
                }
                // 商品情報の再設定
                setShouhinInfo(e.RowIndex, string.Empty, string.Empty, string.Empty, inputItemCode);
            }
            // 数量セルの場合
            else if (e.ColumnIndex == clmQuantity.DisplayIndex)
            {
                decimal quantity = decimal.Zero;
                if (decimal.TryParse(inputValue, out quantity))
                {
                    grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = quantity.ToString(quantityFormat);
                }
                else
                {
                    grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
            }
            // 単価セルの場合
            else if (e.ColumnIndex == clmBid.DisplayIndex)
            {
                decimal bid = decimal.Zero;
                if (decimal.TryParse(inputValue, out bid))
                {
                    grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bid.ToString(bidFormat);
                }
                else
                {
                    grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
            }
            // 金額セルの場合
            else if (e.ColumnIndex == clmAmount.DisplayIndex)
            {
                decimal amount = decimal.Zero;
                if (decimal.TryParse(inputValue, out amount))
                {
                    grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount.ToString(amountFormat);
                }
                else
                {
                    grdDeliveryDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcSyukei = true;
            }
            // 数量または単価列への入力を行った場合
            if (flgRecalcMeisai)
            {
                decimal beforeValue = decimal.Zero;
                decimal afterValue = decimal.Zero;
                decimal.TryParse(beforeCellValue, out beforeValue);
                decimal.TryParse(inputValue, out afterValue);

                if (((string.IsNullOrEmpty(beforeCellValue) || string.IsNullOrEmpty(inputValue)) && beforeCellValue != inputValue) ||
                    beforeValue != afterValue)
                {
                    // 金額の再計算処理を実行
                    recalcMeisai(e.RowIndex);
                }
            }

            if (flgRecalcSyukei)
            {
                // 合計金額の再計算処理実行
                recalcSyukei();
            }

            // 空白でない値を入力した場合
            if (!string.IsNullOrEmpty(inputValue))
            {
                // 最終行に空行を追加
                addLastEmptyRow();
            }
            grdDeliveryDetails.Refresh();
        }
        #endregion

        #region 納品書区分ラジオクリックイベント
        /// <summary>
        /// 納品書区分ラジオクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nouhinsyoTypeRadio_Click(object sender, EventArgs e)
        {
            setNouhinsyoBase((RadioButton)sender);
        }
        #endregion

        #region 閉じるボタン押下イベント
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!btnClose.Enabled) return;
            // トランザクション開始済みの場合
            if (dataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                dataSelectDb.endTransaction();
            }
            closedForm();
        }
        #endregion

        #region 行複写ボタン押下イベント
        /// <summary>
        /// 行複写ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力して処理を終了
            if (grdDeliveryDetails.CurrentRow == null)
            {
                errorOK(Messages.M0004);
                return;
            }

            // 選択行から上段行のINDEXを取得
            int selectedGridTopRowIndex = grdDeliveryDetails.CurrentRow.Index;
            if (selectedGridTopRowIndex % grdDeliveryDetails.RowSegmentCount != 0)
            {
                selectedGridTopRowIndex = grdDeliveryDetails.CurrentRow.Index - 1;
            }

            bool flgCancelCopy = false;
            // 複写中の行を選択時は複写を取り消す
            if (copyGridTopRow != null && copyGridTopRow.Index == selectedGridTopRowIndex)
            {
                copyGridTopRow = null;
                copyGridBtmRow = null;
                flgCancelCopy = true;
            }
            else
            {
                copyGridTopRow = grdDeliveryDetails.Rows[selectedGridTopRowIndex];
                copyGridBtmRow = grdDeliveryDetails.Rows[selectedGridTopRowIndex + 1];
            }
            // 行複写ボタンのテキスト設定
            setRowCopyBtmText();
            grdDeliveryDetails.Focus();
            grdDeliveryDetails.Refresh();

            if (flgCancelCopy)
            {
                grdDeliveryDetails.CurrentCell = grdDeliveryDetails[clmItemCode.DisplayIndex, selectedGridTopRowIndex + 1];
                grdDeliveryDetails.BeginEdit(true);
            }
        }
        #endregion

        #region 行貼付ボタン押下イベント
        /// <summary>
        /// 行貼付ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPasteRow_Click(object sender, EventArgs e)
        {
            // 行複写が実行されていない場合、エラーメッセージを出力する
            if (copyGridTopRow == null || copyGridBtmRow == null)
            {
                errorOK(Messages.M0005);
                return;
            }
            // 貼付対象行が未選択の場合、エラーメッセージを出力する
            if (grdDeliveryDetails.CurrentRow == null ||
                copyGridTopRow.Index == grdDeliveryDetails.CurrentCell.RowIndex ||
                copyGridBtmRow.Index == grdDeliveryDetails.CurrentCell.RowIndex)
            {
                errorOK(Messages.M0006);
                return;
            }

            // 貼付対象行が入力済みの場合、確認メッセージを出力する
            int currentTopRowIndex;
            int currentBtmRowIndex;
            if (grdDeliveryDetails.CurrentCell.RowIndex % grdDeliveryDetails.RowSegmentCount == 0)
            {
                currentTopRowIndex = grdDeliveryDetails.CurrentCell.RowIndex;
                currentBtmRowIndex = grdDeliveryDetails.CurrentCell.RowIndex + 1;
            }
            else
            {
                currentTopRowIndex = grdDeliveryDetails.CurrentCell.RowIndex - 1;
                currentBtmRowIndex = grdDeliveryDetails.CurrentCell.RowIndex;
            }

            // 入力済みの行を選択している場合、確認メッセージを出力
            if (!checkEmptyRow(currentTopRowIndex) &&
                queryYesNo(Messages.M0007) == DialogResult.No)
            {
                return;
            }

            // 貼り付け処理を実行
            string afterItemCd = Convert.ToString(grdDeliveryDetails.Rows[copyGridBtmRow.Index].Cells[clmItemCode.Name].Value);
            string afterItemNm1 = Convert.ToString(grdDeliveryDetails.Rows[copyGridTopRow.Index].Cells[clmItemName.Name].Value);
            string afterItemNm2 = Convert.ToString(grdDeliveryDetails.Rows[copyGridBtmRow.Index].Cells[clmItemName.Name].Value);
            string afterSuryo = Convert.ToString(grdDeliveryDetails.Rows[copyGridBtmRow.Index].Cells[clmQuantity.Name].Value);
            string afterTani = Convert.ToString(grdDeliveryDetails.Rows[copyGridBtmRow.Index].Cells[clmDeliveryStatusAndUnit.Name].Value);
            string afterTanka = Convert.ToString(grdDeliveryDetails.Rows[copyGridBtmRow.Index].Cells[clmBid.Name].Value);
            string afterKingaku = Convert.ToString(grdDeliveryDetails.Rows[copyGridBtmRow.Index].Cells[clmAmount.Name].Value);
            decimal decAfterKingaku;
            decimal.TryParse(afterKingaku, out decAfterKingaku);

            // 商品ｺｰﾄﾞ
            grdDeliveryDetails.Rows[currentBtmRowIndex].Cells[clmItemCode.Name].Value = afterItemCd;
            // 商品名(上段)
            grdDeliveryDetails.Rows[currentTopRowIndex].Cells[clmItemName.Name].Value = afterItemNm1;
            // 商品名(下段)
            grdDeliveryDetails.Rows[currentBtmRowIndex].Cells[clmItemName.Name].Value = afterItemNm2;
            // 数量
            grdDeliveryDetails.Rows[currentBtmRowIndex].Cells[clmQuantity.Name].Value = afterSuryo;
            // 単位
            grdDeliveryDetails.Rows[currentBtmRowIndex].Cells[clmDeliveryStatusAndUnit.Name].Value = afterTani;
            // 単価
            grdDeliveryDetails.Rows[currentBtmRowIndex].Cells[clmBid.Name].Value = afterTanka;
            // 金額
            grdDeliveryDetails.Rows[currentBtmRowIndex].Cells[clmAmount.Name].Value = afterKingaku;

            // 合計金額の再計算処理実行
            recalcSyukei();

            // 最終行に貼り付けを行った場合、行追加
            addLastEmptyRow();

            if (grdDeliveryDetails.CurrentCell != null)
            {
                grdDeliveryDetails.BeginEdit(true);
            }
        }
        #endregion

        #region 行挿入ボタン押下イベント
        /// <summary>
        /// 行挿入ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力する
            if (grdDeliveryDetails.CurrentRow == null)
            {
                errorOK(Messages.M0008);
                return;
            }

            // 行挿入
            int insertIndex = grdDeliveryDetails.CurrentRow.Index % grdDeliveryDetails.RowSegmentCount == 0 ? grdDeliveryDetails.CurrentRow.Index : grdDeliveryDetails.CurrentRow.Index - 1;
            // 受注グリッドへ空行を追加
            insertEmptyGridRow(insertIndex);

            // 受注グリッドの再描画
            grdDeliveryDetails.CurrentCell = grdDeliveryDetails[clmItemCode.DisplayIndex, insertIndex + 1];
            grdDeliveryDetails.BeginEdit(true);
        }
        #endregion

        #region 行削除ボタン押下イベント
        /// <summary>
        /// 行削除ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力し処理を終了する
            if (grdDeliveryDetails.CurrentRow == null)
            {
                errorOK(Messages.M0009);
                return;
            }
            int deleteIndex = grdDeliveryDetails.CurrentRow.Index % grdDeliveryDetails.RowSegmentCount == 0 ? grdDeliveryDetails.CurrentRow.Index : grdDeliveryDetails.CurrentRow.Index - 1;
            // 複写中の行を選択している場合、エラーメッセージを出力し処理を終了する
            if (copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == deleteIndex || copyGridBtmRow.Index == deleteIndex))
            {
                errorOK(string.Format(Messages.M0016, "複写中", "削除", "(削除する場合は、複写行を選択し取消ボタンを押下してください。)"));
                return;
            }
            // 受注入力画面で作成した明細を選択している場合、エラーメッセージを出力し処理を終了する
            if (Convert.ToInt16(grdDeliveryDetails.Rows[deleteIndex + 1].Cells[clmOrderRowNo.Name].Value) > 0)
            {
                errorOK(string.Format(Messages.M0030));
                return;
            }

            flgDeletingRow = true;
            grdDeliveryDetails.Rows.Remove(grdDeliveryDetails.Rows[deleteIndex + 1]);
            grdDeliveryDetails.Rows.Remove(grdDeliveryDetails.Rows[deleteIndex]);
            flgDeletingRow = false;

            // 合計金額の再計算処理実行
            recalcSyukei();

            // 不足分の空行追加処理
            addInsufficientEmptyGridRow(); ;
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();

            if (grdDeliveryDetails.Rows.Count == 0)
            {
            }
            //else if (grdDeliveryDetails.Rows.Count >= deleteIndex + 1)
            else if (deleteIndex == 0)
            {
                grdDeliveryDetails.CurrentCell = grdDeliveryDetails[clmItemCode.DisplayIndex, deleteIndex + 1];
            }
            else
            {
                grdDeliveryDetails.CurrentCell = grdDeliveryDetails[clmItemCode.DisplayIndex, deleteIndex - 1];
            }
        }
        #endregion

        #region 検索ボタン押下イベント
        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 編集中の項目が存在しない場合なにもしない
            if (activeControlInfo.Control == null) return;
            // 検索ボタンが使用不可の場合なにもしない
            if (!btnSearch.Enabled) return;
            bool flgSetFocus = false;
            CheckMessageType messageType = CheckMessageType.inputDataUpdateQuery;
            if ((rdoCorrection.Checked && !flgSearch) ||
                rdoReference.Checked ||
                (rdoDelete.Checked && !flgSearch))
            {
                messageType = CheckMessageType.None;
            }

            // 伝票Noを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtDocumentNo.Name))
            {
                // 新規モードの場合
                if (rdoNew.Checked)
                {
                    // 受注検索画面を起動
                    sJuchu.MType = messageType;
                    sJuchu.ShowDialog();

                    if (sJuchu.DialogResult == DialogResult.OK)
                    {
                        flgSearch = false;
                        // 受注情報の設定
                        setJuchuData(sJuchu.SelectedJuchuInfos[0].DocumentNo);
                        // 画面項目制御処理を実行
                        setEnabled();
                    }
                }
                else
                {
                    // 納品書検索画面を起動
                    sNouhinsyo.MType = messageType;
                    sNouhinsyo.ShowDialog();

                    if (sNouhinsyo.DialogResult == DialogResult.OK)
                    {
                        flgSearch = false;
                        // 納品書情報の設定
                        setNouhinsyoData(sNouhinsyo.SelectedNouhinsyoInfos[0].DocumentNo);
                        // 画面項目制御処理を実行
                        setEnabled();
                    }
                }
                flgSetFocus = true;
            }
            // 得意先ｺｰﾄﾞを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 得意先検索画面を起動
                fTokuisaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fTokuisaki.DialogResult == DialogResult.OK)
                {
                    string tokuisakiCode = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                    string jigyousyoCode = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                    // 得意先情報設定処理
                    setTokuisakiInfo(tokuisakiCode, jigyousyoCode, true);
                }
                flgSetFocus = true;
            }
            // 件名Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtSubjectNo.Name))
            {
                // 件名検索画面を起動
                sKenmei.MType = messageType;
                sKenmei.ShowDialog();

                if (sKenmei.DialogResult == DialogResult.OK)
                {
                    // 納入先情報設定
                    setKenmeiInfo(sKenmei.SelectedKenmeiNos[0], true);
                }
                flgSetFocus = true;
            }
            // 納品書グリッドを編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞ列の場合
                if (activeControlInfo.RowIndex % grdDeliveryDetails.RowSegmentCount != 0 &&
                    activeControlInfo.ClmIndex == clmItemCode.DisplayIndex)
                {
                    grdDeliveryDetails.CancelEdit();
                    // 商品検索画面を起動
                    fShouhin.ShowDialog();

                    // 商品検索画面で確認ボタンが押下された場合
                    if (fShouhin.DialogResult == DialogResult.OK)
                    {
                        // 商品情報設定処理
                        setShouhinInfo(grdDeliveryDetails.CurrentCell.RowIndex
                                     , fShouhin.SelectedItemCodes[0].ShireCode
                                     , fShouhin.SelectedItemCodes[0].TopClassification
                                     , fShouhin.SelectedItemCodes[0].BtmClassification
                                     , fShouhin.SelectedItemCodes[0].ShouhinNo);
                        beforeCellValue = fShouhin.SelectedItemCodes[0].ShouhinNo;
                        grdDeliveryDetails.EndEdit();
                    }
                    grdDeliveryDetails.BeginEdit(true);
                }
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
        }
        #endregion

        #region 仮プレビューボタン押下イベント
        /// <summary>
        /// 仮プレビューボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProvisionalPreview_Click(object sender, EventArgs e)
        {
            if (!btnProvisionalPreview.Enabled || !btnProvisionalPreview.Visible) return;
            executePrint(PrintType.Preview, DenpyoType.Provisional, txtDocumentNo.Text);
        }
        #endregion

        #region 本プレビューボタン押下イベント
        /// <summary>
        /// 本プレビューボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFormalPreview_Click(object sender, EventArgs e)
        {
            if (!btnFormalPreview.Enabled || !btnFormalPreview.Visible) return;
            executePrint(PrintType.Preview, DenpyoType.Formal, txtDocumentNo.Text);
        }
        #endregion

        #region 仮印刷ボタン押下イベント
        /// <summary>
        /// 仮印刷ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProvisionalPrint_Click(object sender, EventArgs e)
        {
            if (!btnProvisionalPrint.Enabled || !btnProvisionalPrint.Visible) return;
            executePrint(PrintType.OutPut, DenpyoType.Provisional, txtDocumentNo.Text);
        }
        #endregion

        #region 本印刷ボタン押下イベント
        /// <summary>
        /// 本印刷ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFormalPrint_Click(object sender, EventArgs e)
        {
            if (!btnFormalPrint.Enabled || !btnFormalPrint.Visible) return;
            executePrint(PrintType.OutPut, DenpyoType.Formal, txtDocumentNo.Text);
        }
        #endregion

        #region 保存ボタン押下イベント
        /// <summary>
        /// 保存ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;
            flgSaving = true;

            // 必須チェック処理
            if (!checkRequired())
            {
                return;
            }

            // 空行全削除処理実行
            if (checkMiddleEmptyRowExist())
            {
                if (queryYesNo(Messages.M0010) == DialogResult.Yes)
                {
                    deleteAllEmptyRow();
                }
                else
                {
                    flgSaving = false;
                    return;
                }
            }

            string queryMessage = string.Empty;
            if (rdoNew.Checked)
            {
                queryMessage = Messages.M0001;
            }
            else if (rdoCorrection.Checked)
            {
                queryMessage = Messages.M0001;
            }
            else if (rdoDelete.Checked)
            {
                queryMessage = Messages.M0002;
            }

            // 処理実行確認
            if (queryYesNo(queryMessage) == DialogResult.Yes)
            {
                string documentNo = txtDocumentNo.Text;
                string ordersNo = txtOrderNo.Text;
                string shireNo = string.Empty;
                DateTime registerDate = DateTime.Now;
                // 売上ヘッダ登録SQL生成処理実行
                string sqlUriageHeaderCommand = createUriageHeaderRegistSql(ref documentNo, ordersNo, registerDate);
                // 売上ボディ登録SQL生成処理実行
                List<string> sqlUriageBodyCommands = createUriageBodyRegistSql(documentNo, registerDate);
                // 売上フッタ登録SQL生成処理実行
                string sqlUriageFooterCommand = createUriageFooterRegistSql(documentNo, registerDate);
                // 受注ボディ更新SQL生成処理実行
                string sqlJuchuBodyCommands = createJuchuBodyUpdateSql(registerDate);
                // 仕入データ更新SQL生成処理実行
                Dictionary<string, ShireRegistClass> sqlShireCommands = createShireRegistSql(documentNo, ordersNo, registerDate, ref shireNo);
                // 売上No更新SQL生成処理実行
                string sqlUriageNoCommand = rdoNew.Checked ? createUriageNoRegistSql(documentNo, registerDate) : string.Empty;
                // 仕入No更新SQL生成処理実行
                string sqlShireNoCommand = (rdoNew.Checked && sqlShireCommands.Count > 0) ? createShireNoRegistSql(shireNo, registerDate) : string.Empty;
                int uriageHeaderRegistResult = 0;
                int uriageBodyRegistResult = 0;
                int uriageFooterRegistResult = 0;
                int shireHeaderRegistResult = 0;
                int shireBodyRegistResult = 0;
                int shireFooterRegistResult = 0;
                int juchuRegistResult = 0;
                int uriageNoRegistResult = 0;
                int shireNoRegistResult = 0;
                dataSelectDb.DBRef = 0;

                // 新規作成時の場合
                if (rdoNew.Checked)
                {
                    // 管理マスタ(売上No)のロック
                    dataSelectDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.UriageNo + "'", true);
                    if (dataSelectDb.DBRef != 0)
                    {
                        errorOK("売上Noロックエラー");
                        return;
                    }
                    // 管理マスタ(仕入No)のロック
                    dataSelectDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.ShireNo + "'", true);
                    if (dataSelectDb.DBRef != 0)
                    {
                        errorOK("仕入Noロックエラー");
                        return;
                    }
                }

                // 納品書ヘッダの更新
                uriageHeaderRegistResult = dataSelectDb.executeDBUpdate(sqlUriageHeaderCommand);

                // 納品書ボディの更新
                if (dataSelectDb.DBRef == 0)
                {
                    foreach (string bodyCommand in sqlUriageBodyCommands)
                    {
                        uriageBodyRegistResult = dataSelectDb.executeDBUpdate(bodyCommand);
                        if (dataSelectDb.DBRef != 0) break;
                    }
                }

                // 納品書フッターの更新
                if (dataSelectDb.DBRef == 0) uriageFooterRegistResult = dataSelectDb.executeDBUpdate(sqlUriageFooterCommand);

                // 仕入データの更新
                if (dataSelectDb.DBRef == 0)
                {
                    foreach (KeyValuePair<string, ShireRegistClass> shireCommands in sqlShireCommands)
                    {
                        // 仕入ヘッダ更新処理実行
                        shireHeaderRegistResult = dataSelectDb.executeDBUpdate(shireCommands.Value.HeaderSql);
                        if (shireHeaderRegistResult != 0) break;
                        // 仕入ボディ更新処理実行
                        foreach (string bodySql in shireCommands.Value.BodySqlList)
                        {
                            shireBodyRegistResult = dataSelectDb.executeDBUpdate(bodySql);
                            if (shireBodyRegistResult != 0) break;
                        }
                        if (shireBodyRegistResult != 0) break;
                        // 仕入フッタ更新処理実行
                        if (!string.IsNullOrEmpty(shireCommands.Value.FooterSql)) shireFooterRegistResult = dataSelectDb.executeDBUpdate(shireCommands.Value.FooterSql);
                        if (shireFooterRegistResult != 0) break;
                    }
                }

                // 受注ボディの更新
                if (dataSelectDb.DBRef == 0) juchuRegistResult = dataSelectDb.executeDBUpdate(sqlJuchuBodyCommands);

                // 管理マスタ(売上No)の更新
                if (dataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlUriageNoCommand)) uriageNoRegistResult = dataSelectDb.executeDBUpdate(sqlUriageNoCommand);

                // 管理マスタ(仕入No)の更新
                if (dataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlShireNoCommand)) shireNoRegistResult = dataSelectDb.executeDBUpdate(sqlShireNoCommand);

                if (dataSelectDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (uriageHeaderRegistResult < 0 || uriageNoRegistResult < 0)
                    {
                        tableName = "納品書ヘッダ";
                    }
                    else if (uriageBodyRegistResult < 0)
                    {
                        tableName = "納品書明細";
                    }
                    else if (uriageFooterRegistResult < 0)
                    {
                        tableName = "納品書集計";
                    }
                    else if (shireHeaderRegistResult < 0 || shireNoRegistResult < 0)
                    {
                        tableName = "仕入ヘッダ";
                    }
                    else if (shireBodyRegistResult < 0)
                    {
                        tableName = "仕入明細";
                    }
                    else if (shireFooterRegistResult < 0)
                    {
                        tableName = "仕入集計";
                    }
                    if (rdoNew.Checked)
                    {
                        processName = "登録処理";
                    }
                    else if (rdoCorrection.Checked)
                    {
                        processName = "更新処理";
                    }
                    else if (rdoDelete.Checked)
                    {
                        processName = "削除処理";
                    }
                    if (juchuRegistResult == -1)
                    {
                        tableName = "受注ボディ";
                        processName = "更新処理";
                    }
                    if (rdoNew.Checked)
                    {
                        dataSelectDb.endTransaction();
                        dataSelectDb.startTransaction();
                        // 受注データ取得処理実行
                        DBNouhinsyo.SelectErrorType selectResult = dataSelectDb.getJuchuData(wkJuchuDocumentNo, true);
                    }
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "伝票No:" + documentNo;
                    string message2;
                    if (rdoNew.Checked)
                    {
                        message2 = "登録";
                    }
                    else if (rdoCorrection.Checked)
                    {
                        message2 = "訂正";
                    }
                    else
                    {
                        message2 = "削除";
                    }
                    frmPrintQueryNouhinsyo printQuery = new frmPrintQueryNouhinsyo(MessageType.Message, string.Format(Messages.M0012, message1, message2), "納品書");
                    if (rdoNew.Checked || rdoCorrection.Checked)
                    {
                        // トランザクション終了処理を実行
                        dataSelectDb.endTransaction();
                        printQuery.StartPosition = FormStartPosition.CenterScreen;
                        printQuery.ShowDialog();
                    }
                    else
                    {
                        messageOK(string.Format(Messages.M0012, message1, message2));
                    }
                    if (printQuery.ClosedResult != frmPrintQueryNouhinsyo.ClosedType.Close &&
                        printQuery.ClosedResult != frmPrintQueryNouhinsyo.ClosedType.None)
                    {
                        PrintType printType;
                        DenpyoType denpyoType;
                        if (printQuery.ClosedResult == frmPrintQueryNouhinsyo.ClosedType.ProvisionalPreview)
                        {
                            printType = PrintType.Preview;
                            denpyoType = DenpyoType.Provisional;
                        }
                        else if (printQuery.ClosedResult == frmPrintQueryNouhinsyo.ClosedType.ProvisionalPrint)
                        {
                            printType = PrintType.OutPut;
                            denpyoType = DenpyoType.Provisional;
                        }
                        else if (printQuery.ClosedResult == frmPrintQueryNouhinsyo.ClosedType.FormalPreview)
                        {
                            printType = PrintType.Preview;
                            denpyoType = DenpyoType.Formal;
                        }
                        else
                        {
                            printType = PrintType.OutPut;
                            denpyoType = DenpyoType.Formal;
                        }
                        executePrint(printType, denpyoType, documentNo);
                    }

                    btnCancel_Click(null, null);
                }
            }

            flgSaving = false;
        }
        #endregion

        #region 取消ボタン押下イベント
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!btnCancel.Enabled) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                string queryMeaasage = string.Empty;
                string str1 = "取消してよろしいですか？";
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoDelete.Checked)
                {
                    queryMeaasage = Messages.M0015;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }
            RadioButton activeModeRdo = null;
            if (rdoNew.Checked)
            {
                activeModeRdo = rdoNew;
            }
            else if (rdoCorrection.Checked)
            {
                activeModeRdo = rdoCorrection;
            }
            else if (rdoReference.Checked)
            {
                activeModeRdo = rdoReference;
            }
            else if (rdoDelete.Checked)
            {
                activeModeRdo = rdoDelete;
            }
            // ラジオボタン変更処理実行
            inputModeChange(activeModeRdo);
        }
        #endregion

        #region 画面項目編集中のキーボード押下イベント
        /// <summary>
        /// 画面項目編集中のキーボード押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputObject_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                // Enterキーが押下された場合
                case Keys.Enter:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    break;
                // F1キーが押下された場合
                case Keys.F1:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;

                    // 検索ボタン押下時の処理を実行
                    btnSearch_Click(null, null);
                    break;
                // F5キーが押下された場合
                case Keys.F5:
                    // TODO:印刷処理を実行
                    btnProvisionalPreview_Click(null, null);
                    break;
                // F6キーが押下された場合
                case Keys.F6:
                    // TODO:印刷処理を実行
                    btnFormalPreview_Click(null, null);
                    break;
                // F7キーが押下された場合
                case Keys.F7:
                    // TODO:印刷処理を実行
                    btnProvisionalPrint_Click(null, null);
                    break;
                // F8キーが押下された場合
                case Keys.F8:
                    // TODO:印刷処理を実行
                    btnFormalPrint_Click(null, null);
                    break;
                // F10キーが押下された場合
                case Keys.F10:
                    // 保存処理を実行
                    btnSave_Click(null, null);
                    break;
                // F11キーが押下された場合
                case Keys.F11:
                    // 取消処理を実行
                    btnCancel_Click(null, null);
                    break;
                // F12キーが押下された場合
                case Keys.F12:
                    // 閉じる処理を実行
                    btnClose_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 画面入力項目のフォーカスインイベント
        /// <summary>
        /// 画面入力項目のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputObject_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (!(c is TextBox || c is ComboBox || c is DateTimePicker))
            {
                return;
            }

            if (grdDeliveryDetails.CurrentCell != null)
            {
                try { grdDeliveryDetails.CurrentCell = null; } catch { }
            }

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.DocumentDate:
                        y = txtDocumentDateYears.Text;
                        m = txtDocumentDateMonth.Text;
                        d = txtDocumentDateDays.Text;
                        inputObj = dtpDocumentDate;
                        break;
                    case LastInputDateType.OrderDate:
                        y = txtOrderDateYears.Text;
                        m = txtOrderDateMonth.Text;
                        d = txtOrderDateDays.Text;
                        inputObj = dtpOrderDate;
                        break;
                    case LastInputDateType.DeliveryDate:
                        y = txtDeliveryDateYears.Text;
                        m = txtDeliveryDateMonth.Text;
                        d = txtDeliveryDateDays.Text;
                        inputObj = dtpDeliveryDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.DocumentDate.Equals(lastInputDateType))
                    {
                        txtDocumentDateYears.Focus();
                    }
                    else if (LastInputDateType.OrderDate.Equals(lastInputDateType))
                    {
                        txtOrderDateYears.Focus();
                    }
                    else if (LastInputDateType.DeliveryDate.Equals(lastInputDateType))
                    {
                        txtDeliveryDateYears.Focus();
                    }
                    return;
                }
            }

            if (c is CustomTextBox)
            {
                ((CustomTextBox)c).BeforeValue = ((CustomTextBox)c).Text;
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
        }
        #endregion

        #region 伝票Noのフォーカスアウトイベント
        /// <summary>
        /// 伝票Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            if (flgSetData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                if (rdoNew.Checked || rdoCorrection.Checked && flgSearch)
                {
                    text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                }
                else
                {
                    flgSetData = true;
                    // 納品書データ取得処理を実行
                    bool ret = setNouhinsyoData(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength));
                    if (ret)
                    {
                        // 画面項目制御処理を実行
                        setEnabled();
                    }
                    else
                    {
                        text.Focus();
                    }
                    flgSetData = false;
                }
            }
        }
        #endregion

        #region 処理モードラジオボタンクリック処理
        /// <summary>
        /// 処理モードラジオボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputModeRadio_Click(object sender, EventArgs e)
        {
            string queryMeaasage = string.Empty;
            string str1 = "処理モードを変更してよろしいですか？";
            RadioButton radio = (RadioButton)sender;
            if (!flgSaving && activeModeRadioButton != null && activeModeRadioButton.Name == radio.Name) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoDelete.Checked)
                {
                    queryMeaasage = Messages.M0015;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoNew.Checked = (rdoNew.Name == radio.Name);
            rdoCorrection.Checked = (rdoCorrection.Name == radio.Name);
            rdoReference.Checked = (rdoReference.Name == radio.Name);
            rdoDelete.Checked = (rdoDelete.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
        }
        #endregion

        #region 処理モード別変更チェック処理
        private bool checkDataChange()
        {
            bool result = false;
            // 処理モード別の変更チェック処理
            if (rdoNew.Checked)
            {
                if (!string.Empty.Equals(txtDocumentNo.Text) ||
                    !syoriDate.Equals(Convert.ToDateTime(dtpDocumentDate.Value.ToString("yyyy/MM/dd"))) ||
                    !string.Empty.Equals(cmbPersonnel.Text) ||
                    !string.Empty.Equals(txtSpecifiedDocumentNo.Text) ||
                    !string.Empty.Equals(txtOrderNo.Text) ||
                    !syoriDate.Equals(Convert.ToDateTime(dtpOrderDate.Value.ToString("yyyy/MM/dd"))) ||
                    !string.Empty.Equals(txtCustomerCode.Text) ||
                    !string.Empty.Equals(txtCustomerName.Text) ||
                    !string.Empty.Equals(txtCustomerKanaName.Text) ||
                    !string.Empty.Equals(cmbOffices.Text) ||
                    !string.Empty.Equals(txtCustomerPersonnel.Text) ||
                    !string.Empty.Equals(txtSubjectNo.Text) ||
                    !string.Empty.Equals(txtSubject1.Text) ||
                    !string.Empty.Equals(txtSubject2.Text) ||
                    !string.Empty.Equals(txtWork1.Text) ||
                    !string.Empty.Equals(txtWork2.Text) ||
                    !string.Empty.Equals(txtWork3.Text) ||
                    !syoriDate.Equals(Convert.ToDateTime(dtpDeliveryDate.Value.ToString("yyyy/MM/dd"))) ||
                    !string.Empty.Equals(txtRemarks1.Text) ||
                    !string.Empty.Equals(txtRemarks2.Text) ||
                    !string.Empty.Equals(txtGuestNoteNumber.Text))
                {
                    result = true;
                }
            }
            else if (rdoCorrection.Checked)
            {
                if (flgSearch)
                {
                    result = true;
                }
            }
            else if (rdoDelete.Checked)
            {
                if (flgSearch)
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion

        #region 得意先ｺｰﾄﾞフォーカスアウトイベント
        /// <summary>
        /// フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCd_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 得意先情報の設定
                if (setTokuisakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), string.Empty, false))
                {
                    text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                }
            }
            else
            {
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                txtCustomerName.Text = string.Empty;
                txtCustomerKanaName.Text = string.Empty;
                txtCustomerPersonnel.Text = string.Empty;
                setOfficesCmb(dummyCode, string.Empty);
            }
        }
        #endregion

        #region 伝票日付フォーカスインイベント
        /// <summary>
        /// 伝票日付フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DocumentDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 伝票日付フォーカスアウトイベント
        /// <summary>
        /// 伝票日付フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumentDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DocumentDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DocumentDate;
            }
        }
        #endregion

        #region 注文日付フォーカスインイベント
        /// <summary>
        /// 注文日付フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.OrderDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 注文日付フォーカスアウトイベント
        /// <summary>
        /// 注文日付フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.OrderDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.OrderDate;
            }
        }
        #endregion

        #region 納品日付フォーカスインイベント
        /// <summary>
        /// 納品日付フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeliveryDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DeliveryDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 納品日付フォーカスアウトイベント
        /// <summary>
        /// 納品日付フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeliveryDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.DeliveryDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.DeliveryDate;
            }
        }
        #endregion

        #region 件名Noのフォーカスアウトイベント
        /// <summary>
        /// 件名Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubjectNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 件名情報の設定
                setKenmeiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), false);
            }
        }
        #endregion

        #region 検索ボタンオンフォーカスイベント
        /// <summary>
        /// 検索ボタンオンフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            flgBtnSearchSelect = true;
        }
        #endregion

        #region 検索ボタンアウトフォーカスイベント
        /// <summary>
        /// 検索ボタンアウトフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            flgBtnSearchSelect = false;
        }
        #endregion

        #region 数字のみ入力可能項目のキー押下イベント
        /// <summary>
        /// 数字のみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDigitalOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字のみ入力可能項目の制御処理を実行
            commonLogic.inputDigitalOnly_KeyPress(e);
        }
        #endregion

        #region 全角カナのみ入力可能項目のキー押下イベント
        /// <summary>
        /// 全角カナのみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmKanaOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 全角カナのみ入力可能項目の制御処理を実行
            commonLogic.inputEmKanaOnly_KeyPress(e);
        }
        #endregion

        #region 数値のみ入力可能項目のキー押下イベント
        /// <summary>
        /// 数値のみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数値のみ入力可能項目の制御処理を実行
            commonLogic.inputNumberOnly_KeyPress(e, (TextBox)sender, activeControlInfo.IntegerLength, activeControlInfo.DecimalLength);
        }
        #endregion

        #endregion

        #region ビジネスロジック

        #region 納品書設定処理
        /// <summary>
        /// 納品書設定処理
        /// </summary>
        /// <param name="radio"></param>
        private void setNouhinsyoBase(RadioButton radio)
        {
            if (radio.Checked) return;
            bool flgDataChange = checkDataChange();
            if (flgNouhinsyoDataSet || !flgDataChange || queryYesNo("現在入力中の内容が破棄されますがよろしいですか？") == DialogResult.Yes)
            {
                nowActiveNouhinsyoRadio.Checked = false;
                radio.Checked = true;
                initializeNouhinsyo(getNouhinsyoType(radio.Name));
            }
        }
        #endregion

        #region 納品書初期化処理
        /// <summary>
        /// 納品書初期化処理
        /// </summary>
        /// <param name="type"></param>
        private void initializeNouhinsyo(NouhinsyoType type)
        {
            flgSearch = false;
            // 伝票NO
            txtDocumentNo.Text = string.Empty;
            // 伝票日付
            dtpDocumentDate.Value = syoriDate;
            // 担当者
            cmbPersonnel.Text = string.Empty;
            // 指定伝票NO
            txtSpecifiedDocumentNo.Text = string.Empty;
            // 注文NO
            txtOrderNo.Text = string.Empty;
            // 注文日付
            dtpOrderDate.Value = syoriDate;
            // 得意先ｺｰﾄﾞ
            txtCustomerCode.Text = string.Empty;
            // 得意先名
            txtCustomerName.Text = string.Empty;
            // 得意先カナ名
            txtCustomerKanaName.Text = string.Empty;
            // 事業所
            cmbOffices.Text = string.Empty;
            // 得意先担当者名
            txtCustomerPersonnel.Text = string.Empty;
            // 件名NO
            txtSubjectNo.Text = string.Empty;
            // 件名１
            txtSubject1.Text = string.Empty;
            // 件名２
            txtSubject2.Text = string.Empty;
            // 工番１
            txtWork1.Text = string.Empty;
            // 工番２
            txtWork2.Text = string.Empty;
            // 工番３
            txtWork3.Text = string.Empty;
            // 納品日付
            dtpDeliveryDate.Value = syoriDate;
            // 備考１
            txtRemarks1.Text = string.Empty;
            // 備考２
            txtRemarks2.Text = string.Empty;
            // 客先注番
            txtGuestNoteNumber.Text = string.Empty;
            // 明細を1行にまとめて出力
            chkDetailPutTogether.Checked = false;

            // グリッドの初期化処理実行
            initGridData();

            switch (type)
            {
                case NouhinsyoType.Jisya:
                    nowActiveNouhinsyoRadio = rdoTheir;
                    //txtOrderNo.Enabled = true;
                    //txtCustomerPersonnel.Enabled = true;
                    //txtSubject1.Enabled = true;
                    //dtpDeliveryDate.Enabled = true;
                    //txtRemarks1.Enabled = true;
                    //txtRemarks2.Enabled = true;
                    break;
                case NouhinsyoType.Negurosu:
                    nowActiveNouhinsyoRadio = rdoNegurosu;
                    //txtOrderNo.Enabled = true;
                    //txtCustomerPersonnel.Enabled = true;
                    //txtRemarks1.Enabled = true;
                    //txtRemarks2.Enabled = true;
                    break;
                case NouhinsyoType.TouhokuDenki:
                    nowActiveNouhinsyoRadio = rdoTouhokuDenki;
                    //txtCustomerPersonnel.Enabled = true;
                    //txtRemarks1.Enabled = true;
                    //txtRemarks2.Enabled = true;
                    break;
                case NouhinsyoType.Yuudensya:
                    nowActiveNouhinsyoRadio = rdoYuudennsya;
                    //txtOrderNo.Enabled = true;
                    //txtSubject1.Enabled = true;
                    //cmbOffices.Enabled = true;
                    //txtWork1.Enabled = true;
                    //txtWork2.Enabled = true;
                    //txtWork3.Enabled = true;
                    break;
                case NouhinsyoType.AsamiDenki:
                    nowActiveNouhinsyoRadio = rdoAsamiDenki;
                    //txtConstructionNo.Enabled = true;
                    //txtSubject1.Enabled = true;
                    break;
                case NouhinsyoType.Kandenkou:
                    nowActiveNouhinsyoRadio = rdoKandenkou;
                    //dtpOrderDate.Enabled = true;
                    //txtWork1.Enabled = true;
                    //txtWork2.Enabled = true;
                    //txtWork3.Enabled = true;
                    break;
            }
            // 画面項目の編集制御設定処理実行
            setEnabled();
        }
        #endregion

        #region 納品書区分取得処理
        /// <summary>
        /// 納品書区分取得処理
        /// </summary>
        /// <param name="radioName"></param>
        /// <returns></returns>
        private NouhinsyoType getNouhinsyoType(string radioName)
        {
            NouhinsyoType type = NouhinsyoType.Jisya;

            if (rdoTheir.Name.Equals(radioName))
            {
                type = NouhinsyoType.Jisya;
            }
            else if (rdoNegurosu.Name.Equals(radioName))
            {
                type = NouhinsyoType.Negurosu;
            }
            else if (rdoTouhokuDenki.Name.Equals(radioName))
            {
                type = NouhinsyoType.TouhokuDenki;
            }
            else if (rdoYuudennsya.Name.Equals(radioName))
            {
                type = NouhinsyoType.Yuudensya;
            }
            else if (rdoAsamiDenki.Name.Equals(radioName))
            {
                type = NouhinsyoType.AsamiDenki;
            }
            else if (rdoKandenkou.Name.Equals(radioName))
            {
                type = NouhinsyoType.Kandenkou;
            }

            return type;
        }
        #endregion

        #region 納品書グリッド取得処理
        /// <summary>
        /// 納品書グリッド取得処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="clmName"></param>
        /// <returns></returns>
        private object getGridData(DataRow row, String clmName)
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
        #endregion

        #region 納品書グリッド初期化処理
        /// <summary>
        /// 納品書グリッド初期化処理
        /// </summary>
        private void initGridData()
        {
            grdDeliveryDetails.Rows.Clear();
            for (int i = 0; i < (gridStartRowCount + 1); i++)
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
            grdDeliveryDetails.Rows.RemoveAt(grdDeliveryDetails.Rows.Count - 1);
            grdDeliveryDetails.Rows.RemoveAt(grdDeliveryDetails.Rows.Count - 1);
            grdDeliveryDetails.CurrentCell = null;
            copyGridTopRow = null;
            copyGridBtmRow = null;

            DataTable dtTotalDetails = new DataTable();
            dtTotalDetails.Columns.Add(clmTotalAmountTitle.DataPropertyName, Type.GetType("System.String"));
            dtTotalDetails.Columns.Add(clmTotalAmount.DataPropertyName, Type.GetType("System.Decimal"));
            dtTotalDetails.Rows.Add(new object[] { strTotalAmountTitle, DBNull.Value });
            grdDeliveryTotalDetails.DataSource = dtTotalDetails;
        }
        #endregion

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // キー押下イベントを追加
            c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

            // 伝票Noの場合
            if (c.Name.Equals(txtDocumentNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            }
            // 伝票日付の場合
            else if (c.Name.Equals(txtDocumentDateYears.Name) ||
                     c.Name.Equals(txtDocumentDateMonth.Name) ||
                     c.Name.Equals(txtDocumentDateDays.Name) ||
                     c.Name.Equals(dtpDocumentDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtDocumentDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDocumentDate_Leave);
            }
            // 注文日付の場合
            else if (c.Name.Equals(txtOrderDateYears.Name) ||
                     c.Name.Equals(txtOrderDateMonth.Name) ||
                     c.Name.Equals(txtOrderDateDays.Name) ||
                     c.Name.Equals(dtpOrderDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtOrderDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOrderDate_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCd_Leave);
            }
            // 件名Noの場合
            else if (c.Name.Equals(txtSubjectNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtSubjectNo_Leave);
            }
            // 納品日付の場合
            else if (c.Name.Equals(txtDeliveryDateYears.Name) ||
                     c.Name.Equals(txtDeliveryDateMonth.Name) ||
                     c.Name.Equals(txtDeliveryDateDays.Name) ||
                     c.Name.Equals(dtpDeliveryDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtDeliveryDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDeliveryDate_Leave);
            }

            // 検索ボタンでない場合
            if (!c.Name.Equals(btnSearch.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(inputObject_Enter);
            }

            // FormまたはPanelの場合、子階層の項目へイベントを追加
            if (c is Form || c is Panel)
            {
                foreach (Control cc in c.Controls)
                {
                    setEvent(cc);
                }
            }
        }
        #endregion

        #region 検索ボタン入力可否設定
        /// <summary>
        /// 検索ボタン入力可否設定
        /// </summary>
        private void setSearchButtonEnabled()
        {
            bool enabled = true;
            // 編集中の項目が存在しない場合
            if (activeControlInfo.Control == null)
            {
                // 検索ボタン使用不可
                enabled = false;
            }
            // 伝票Noまたは
            // 得意先ｺｰﾄﾞまたは
            // 件名Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDocumentNo.Name) ||
                     activeControlInfo.Control.Name.Equals(txtCustomerCode.Name) ||
                     activeControlInfo.Control.Name.Equals(txtSubjectNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 納品書グリッド編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞの場合
                if (activeControlInfo.ClmIndex == clmItemCode.DisplayIndex)
                {
                    // 検索ボタン使用可
                    enabled = true;
                }
                else
                {
                    // 検索ボタン使用不可
                    enabled = false;
                }
            }
            // 上記以外
            else
            {
                // 検索ボタン使用不可
                enabled = false;
            }
            // 検索ボタンの入力可否設定
            btnSearch.Enabled = enabled;
        }
        #endregion

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable, Common.CustomDateTimePicker inputObj)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
            {
                ret = true;
            }
            else
            {
                DateTime date;
                DateTime wkdate;
                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
                if (ret && inputObj != null)
                {
                    wkdate = date.AddDays(1);
                    inputObj.Value = wkdate;
                    inputObj.Value = date;
                }
            }
            return ret;
        }
        #endregion

        #region 担当者コンボボックスの設定
        /// <summary>
        /// 担当者コンボボックスの設定
        /// </summary>
        private void setPersonnelCmb()
        {
            // 担当者取得
            DataTable tantousyaDt = tantousyaMaster.getTantousyaDataTable(string.Empty, string.Empty);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPersonnel, tantousyaDt, "tantousyaCode", "tantousyaName");
        }
        #endregion

        #region 事業所コンボボックスの設定
        /// <summary>
        /// 事業所コンボボックスの設定
        /// </summary>
        private void setOfficesCmb(string tokuisakiCode, string jigyousyoCode)
        {
            // 事業所取得
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
            {
                tokuisakiCode = dummyCode;
            }
            DataTable officesDt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbOffices, officesDt, "jigyousyoCode", "jigyousyoName");

            if (!string.IsNullOrEmpty(jigyousyoCode))
            {
                cmbOffices.SelectedValue = jigyousyoCode;
            }
            else if (!Consts.OthersCustomerCode.Equals(tokuisakiCode) && cmbOffices.Items.Count > 0)
            {
                cmbOffices.SelectedIndex = 0;
            }
            else
            {
                cmbOffices.SelectedIndex = -1;
                cmbOffices.Text = string.Empty;
            }
        }
        #endregion

        #region 単位コンボボックスの設定
        /// <summary>
        /// 単位コンボボックスの設定
        /// </summary>
        private void setUnitCmb()
        {
            // 単位取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE003);
            // コンボボックス設定共通処理実行
            commonLogic.setGridComboBoxDataSource(ref clmDeliveryStatusAndUnit, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private bool setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (dt == null || dt.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerCode.Focus();
                return false;
            }

            if (flgUnconditional || txtCustomerCode.BeforeValue != tokuisakiCode)
            {
                DataRow dRow = dt.Rows[0];
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Enabled = true;
                    txtCustomerKanaName.Enabled = true;
                    txtCustomerName.Text = string.Empty;
                    txtCustomerKanaName.Text = string.Empty;
                    txtCustomerPersonnel.Text = string.Empty;
                    txtCustomerName.Focus();
                }
                else
                {
                    var query = dt.AsEnumerable().Where(p => p.Field<string>("jigyousyoCode").Equals(jigyousyoCode));
                    if (query.Count() > 0)
                    {
                        dRow = query.ElementAt(0);
                    }
                    // 取得データを画面項目に設定
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
                    txtCustomerKanaName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiKanaName]);
                    txtCustomerPersonnel.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiTantousyaName]);
                    txtCustomerName.Enabled = false;
                    txtCustomerKanaName.Enabled = false;
                }
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
            cmbOffices.BeforeSelectedValue = Convert.ToString(cmbOffices.SelectedValue);

            return true;
        }
        #endregion

        #region 処理モード別項目制御処理
        /// <summary>
        /// 処理モード別項目制御処理
        /// </summary>
        private void setEnabled()
        {
            if (flgInitializing) return;
            flgInitializing = true;
            rdoNew.Click -= new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            rdoDelete.Click -= new EventHandler(inputModeRadio_Click);
            grdDeliveryDetails.Focus();
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                // 入力制御設定
                txtDocumentNo.Enabled = true;
                txtDocumentNo.ReadOnly = true;
                txtDocumentDateYears.Enabled = flgSearch;
                txtDocumentDateMonth.Enabled = flgSearch;
                txtDocumentDateDays.Enabled = flgSearch;
                dtpDocumentDate.Enabled = flgSearch;
                cmbPersonnel.Enabled = flgSearch;
                txtSpecifiedDocumentNo.Enabled = flgSearch;
                txtOrderNo.Enabled = false;
                txtOrderDateYears.Enabled = flgSearch;
                txtOrderDateMonth.Enabled = flgSearch;
                txtOrderDateDays.Enabled = flgSearch;
                dtpOrderDate.Enabled = flgSearch;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCustomerPersonnel.Enabled = flgSearch;
                txtSubjectNo.Enabled = flgSearch;
                txtSubject1.Enabled = flgSearch;
                txtSubject2.Enabled = flgSearch;
                txtWork1.Enabled = flgSearch;
                txtWork2.Enabled = flgSearch;
                txtWork3.Enabled = flgSearch;
                txtDeliveryDateYears.Enabled = flgSearch;
                txtDeliveryDateMonth.Enabled = flgSearch;
                txtDeliveryDateDays.Enabled = flgSearch;
                dtpDeliveryDate.Enabled = flgSearch;
                txtRemarks1.Enabled = flgSearch;
                txtRemarks2.Enabled = flgSearch;
                txtGuestNoteNumber.Enabled = flgSearch;
                btnCopyRow.Enabled = flgSearch;
                btnPasteRow.Enabled = flgSearch;
                btnInsertRow.Enabled = flgSearch;
                btnDeleteRow.Enabled = flgSearch;
                btnSearch.Enabled = true;
                pnlDeliveryPreviewType.Visible = false;
                pnlDeliveryPrintType.Visible = false;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                grdDeliveryDetails.ReadOnly = !flgSearch;

                // 初期フォーカス設定
                txtDocumentNo.Focus();

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtOrderDateYears.BackColor = Color.White;
                txtOrderDateMonth.BackColor = Color.White;
                txtOrderDateDays.BackColor = Color.White;
                txtDeliveryDateYears.BackColor = Color.White;
                txtDeliveryDateMonth.BackColor = Color.White;
                txtDeliveryDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtDocumentNo.Enabled = !flgSearch;
                txtDocumentNo.ReadOnly = false;
                txtDocumentDateYears.Enabled = flgSearch;
                txtDocumentDateMonth.Enabled = flgSearch;
                txtDocumentDateDays.Enabled = flgSearch;
                dtpDocumentDate.Enabled = flgSearch;
                cmbPersonnel.Enabled = flgSearch;
                txtSpecifiedDocumentNo.Enabled = flgSearch;
                txtOrderNo.Enabled = false;
                txtOrderDateYears.Enabled = flgSearch;
                txtOrderDateMonth.Enabled = flgSearch;
                txtOrderDateDays.Enabled = flgSearch;
                dtpOrderDate.Enabled = flgSearch;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCustomerPersonnel.Enabled = flgSearch;
                txtSubjectNo.Enabled = flgSearch;
                txtSubject1.Enabled = flgSearch;
                txtSubject2.Enabled = flgSearch;
                txtWork1.Enabled = flgSearch;
                txtWork2.Enabled = flgSearch;
                txtWork3.Enabled = flgSearch;
                txtDeliveryDateYears.Enabled = flgSearch;
                txtDeliveryDateMonth.Enabled = flgSearch;
                txtDeliveryDateDays.Enabled = flgSearch;
                dtpDeliveryDate.Enabled = flgSearch;
                txtRemarks1.Enabled = flgSearch;
                txtRemarks2.Enabled = flgSearch;
                txtGuestNoteNumber.Enabled = flgSearch;
                btnCopyRow.Enabled = flgSearch;
                btnPasteRow.Enabled = flgSearch;
                btnInsertRow.Enabled = flgSearch;
                btnDeleteRow.Enabled = flgSearch;
                btnSearch.Enabled = true;
                pnlDeliveryPreviewType.Visible = flgSearch;
                pnlDeliveryPrintType.Visible = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                grdDeliveryDetails.ReadOnly = !flgSearch;

                // 初期フォーカス設定
                if (!flgSearch)
                {
                    txtDocumentNo.Focus();
                }
                else
                {
                    txtDocumentDateYears.Focus();
                }

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtOrderDateYears.BackColor = Color.White;
                txtOrderDateMonth.BackColor = Color.White;
                txtOrderDateDays.BackColor = Color.White;
                txtDeliveryDateYears.BackColor = Color.White;
                txtDeliveryDateMonth.BackColor = Color.White;
                txtDeliveryDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtDocumentNo.Enabled = !flgSearch;
                txtDocumentNo.ReadOnly = false;
                txtDocumentDateYears.Enabled = false;
                txtDocumentDateMonth.Enabled = false;
                txtDocumentDateDays.Enabled = false;
                dtpDocumentDate.Enabled = false;
                cmbPersonnel.Enabled = false;
                txtSpecifiedDocumentNo.Enabled = false;
                txtOrderNo.Enabled = false;
                txtOrderDateYears.Enabled = false;
                txtOrderDateMonth.Enabled = false;
                txtOrderDateDays.Enabled = false;
                dtpOrderDate.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCustomerPersonnel.Enabled = false;
                txtSubjectNo.Enabled = false;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtWork1.Enabled = false;
                txtWork2.Enabled = false;
                txtWork3.Enabled = false;
                txtDeliveryDateYears.Enabled = false;
                txtDeliveryDateMonth.Enabled = false;
                txtDeliveryDateDays.Enabled = false;
                dtpDeliveryDate.Enabled = false;
                txtRemarks1.Enabled = false;
                txtRemarks2.Enabled = false;
                txtGuestNoteNumber.Enabled = false;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = !flgSearch;
                pnlDeliveryPreviewType.Visible = flgSearch;
                pnlDeliveryPrintType.Visible = flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                grdDeliveryDetails.ReadOnly = true;

                // 初期フォーカス設定
                if (!flgSearch)
                {
                    txtDocumentNo.Focus();
                }

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtOrderDateYears.BackColor = Color.White;
                txtOrderDateMonth.BackColor = Color.White;
                txtOrderDateDays.BackColor = Color.White;
                txtDeliveryDateYears.BackColor = Color.White;
                txtDeliveryDateMonth.BackColor = Color.White;
                txtDeliveryDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtDocumentNo.Enabled = !flgSearch;
                txtDocumentNo.ReadOnly = false;
                txtDocumentDateYears.Enabled = false;
                txtDocumentDateMonth.Enabled = false;
                txtDocumentDateDays.Enabled = false;
                dtpDocumentDate.Enabled = false;
                cmbPersonnel.Enabled = false;
                txtSpecifiedDocumentNo.Enabled = false;
                txtOrderNo.Enabled = false;
                txtOrderDateYears.Enabled = false;
                txtOrderDateMonth.Enabled = false;
                txtOrderDateDays.Enabled = false;
                dtpOrderDate.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCustomerPersonnel.Enabled = false;
                txtSubjectNo.Enabled = false;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtWork1.Enabled = false;
                txtWork2.Enabled = false;
                txtWork3.Enabled = false;
                txtDeliveryDateYears.Enabled = false;
                txtDeliveryDateMonth.Enabled = false;
                txtDeliveryDateDays.Enabled = false;
                dtpDeliveryDate.Enabled = false;
                txtRemarks1.Enabled = false;
                txtRemarks2.Enabled = false;
                txtGuestNoteNumber.Enabled = false;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = !flgSearch;
                pnlDeliveryPreviewType.Visible = flgSearch;
                pnlDeliveryPrintType.Visible = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                grdDeliveryDetails.ReadOnly = true;

                // 初期フォーカス設定
                if (!flgSearch)
                {
                    txtDocumentNo.Focus();
                }

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtOrderDateYears.BackColor = Color.White;
                txtOrderDateMonth.BackColor = Color.White;
                txtOrderDateDays.BackColor = Color.White;
                txtDeliveryDateYears.BackColor = Color.White;
                txtDeliveryDateMonth.BackColor = Color.White;
                txtDeliveryDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：実行";
            }
            #endregion
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                pnlDeliveryPreviewType.Enabled = false;
                pnlDeliveryPreviewType.Visible = false;
                pnlDeliveryPrintType.Enabled = false;
                pnlDeliveryPrintType.Visible = false;
            }
            rdoNew.Click += new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
            rdoDelete.Click += new EventHandler(inputModeRadio_Click);
            flgInitializing = false;
        }
        #endregion

        #region 件名情報設定処理
        /// <summary>
        /// 件名情報設定処理
        /// </summary>
        /// <param name="kenmeiNo"></param>
        private void setKenmeiInfo(string kenmeiNo, bool flgUnconditional)
        {
            string kenmei1 = string.Empty;
            string kenmei2 = string.Empty;
            DBKenmeiMaster kenmeiMaster = new DBKenmeiMaster();
            List<DBFileLayout.KenmeiMasterFile> kenmeiInfo = kenmeiMaster.getKenmeiInfo(kenmeiNo, false);
            if (kenmeiInfo.Count > 0)
            {
                kenmeiNo = kenmeiInfo[0].KenmeiNo;
                kenmei1 = kenmeiInfo[0].Kenmei1;
                kenmei2 = kenmeiInfo[0].Kenmei2;
            }
            else
            {
                errorOK(string.Format(Messages.M0003, "件名No"));
                txtSubjectNo.Focus();
                return;
            }
            if (flgUnconditional || txtSubjectNo.BeforeValue != kenmeiNo)
            {
                txtSubjectNo.Text = kenmeiNo;
                txtSubject1.Text = kenmei1;
                txtSubject2.Text = kenmei2;
                txtSubjectNo.BeforeValue = txtSubjectNo.Text;
            }
        }
        #endregion

        #region 行複写ボタンのテキスト設定
        /// <summary>
        /// 行複写ボタンのテキスト設定
        /// </summary>
        private void setRowCopyBtmText()
        {
            string strBtnCopyRow = "行複写";
            // 複写中の行を選択している場合
            if (grdDeliveryDetails.CurrentCell != null &&
                copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == grdDeliveryDetails.CurrentCell.RowIndex || copyGridBtmRow.Index == grdDeliveryDetails.CurrentCell.RowIndex))
            {
                strBtnCopyRow = "取消";
            }
            btnCopyRow.Text = strBtnCopyRow;
        }
        #endregion

        #region 対象行の未入力チェック処理
        /// <summary>
        /// 対象行の未入力チェック処理
        /// </summary>
        /// <param name="topRowIndex">チェック対象の上段行INDEX</param>
        /// <returns></returns>
        private bool checkEmptyRow(int topRowIndex)
        {
            bool res = false;

            DataGridViewRow topRow = grdDeliveryDetails.Rows[topRowIndex];
            DataGridViewRow btmRow = grdDeliveryDetails.Rows[topRowIndex + 1];

            string itemCd = Convert.ToString(btmRow.Cells[clmItemCode.Name].Value);             // 商品ｺｰﾄﾞ
            string itemNm1 = Convert.ToString(topRow.Cells[clmItemName.Name].Value);            // 商品名(上段)
            string itemNm2 = Convert.ToString(btmRow.Cells[clmItemName.Name].Value);            // 商品名(下段)
            string suryo = Convert.ToString(btmRow.Cells[clmQuantity.Name].Value);              // 数量
            string tani = Convert.ToString(btmRow.Cells[clmDeliveryStatusAndUnit.Name].Value);  // 単位
            string tanka = Convert.ToString(btmRow.Cells[clmBid.Name].Value);                   // 単価
            string kingaku = Convert.ToString(btmRow.Cells[clmAmount.Name].Value);              // 受注金額

            // 全項目が未入力の場合
            if (string.IsNullOrEmpty(itemCd) &&
                string.IsNullOrEmpty(itemNm1) &&
                string.IsNullOrEmpty(itemNm2) &&
                string.IsNullOrEmpty(suryo) &&
                string.IsNullOrEmpty(tani) &&
                string.IsNullOrEmpty(tanka) &&
                string.IsNullOrEmpty(kingaku))
            {
                res = true;
            }
            return res;
        }
        #endregion

        #region 納品書グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// <summary>
        /// 納品書グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// </summary>
        private void addLastEmptyRow()
        {
            // 最終行が空行でない場合、行追加
            if (!checkEmptyRow(grdDeliveryDetails.Rows.Count - 2))
            {
                // 納品書グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 納品書グリッドへの空行追加処理
        /// <summary>
        /// 納品書グリッドへの空行追加処理
        /// </summary>
        private void addEmptyGridRow()
        {
            insertEmptyGridRow(grdDeliveryDetails.Rows.Count);
        }
        #endregion

        #region 納品書グリッドへの空行挿入処理
        /// <summary>
        /// 納品書グリッドへの空行挿入処理
        /// </summary>
        /// <param name="insertIndex"></param>
        private void insertEmptyGridRow(int insertIndex)
        {
            grdDeliveryDetails.Rows.Insert(insertIndex);
            grdDeliveryDetails.Rows[insertIndex].Cells[clmCheckPrint.Name] = new DataGridViewTextBoxCell();
            grdDeliveryDetails.Rows[insertIndex].Cells[clmCheckPrint.Name].Value = string.Empty;
            grdDeliveryDetails.Rows[insertIndex].Cells[clmDeliveryStatusAndUnit.Name] = new DataGridViewTextBoxCell();
            grdDeliveryDetails.Rows[insertIndex].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            grdDeliveryDetails.Rows.Insert(insertIndex + 1);
            grdDeliveryDetails.Rows[insertIndex + 1].Cells[clmCheckPrint.Name].Value = false;
            grdDeliveryDetails.Rows[insertIndex + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            grdDeliveryDetails.Rows[insertIndex + 1].Cells[clmOrderRowNo.Name].Value = 0;
            grdDeliveryDetails.Rows[insertIndex + 1].Cells[clmOrderQuantity.Name].Value = decimal.Zero;
            grdDeliveryDetails.Rows[insertIndex + 1].Cells[clmOrdersDeliveryQuantity.Name].Value = decimal.Zero;
        }
        #endregion

        #region 納品書グリッドへの不足分行追加処理
        /// <summary>
        /// 納品書グリッドへの不足分行追加処理
        /// </summary>
        private void addInsufficientEmptyGridRow()
        {
            // 納品書グリッド行数が初期表示件数未満の場合、不足データ分の空行を納品書グリッドに追加します
            for (int i = grdDeliveryDetails.Rows.Count / grdDeliveryDetails.RowSegmentCount; i < gridStartRowCount; i++)
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 商品情報設定処理
        /// <summary>
        /// 商品情報設定処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <param name="topClassification"></param>
        /// <param name="btmClassification"></param>
        /// <param name="shouhinCode"></param>
        private void setShouhinInfo(int rowIndex, string shiresakiCode, string topClassification, string btmClassification, string shouhinCode)
        {
            // 商品情報の取得
            List<DBFileLayout.ShouhinMasterFile> shouhinInfo = shouhinMaster.getShouhinInfo(shiresakiCode, topClassification, btmClassification, shouhinCode, false);

            int topRowIndex = rowIndex;
            int btmRowIndex = 0;
            if (topRowIndex % grdDeliveryDetails.RowSegmentCount != 0)
            {
                btmRowIndex = topRowIndex;
                topRowIndex--;
            }
            else
            {
                btmRowIndex = topRowIndex + 1;
            }
            if (string.IsNullOrEmpty(shouhinCode))
            {
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
                grdDeliveryDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            }
            // 対象の商品情報が取得できた場合
            else if (shouhinInfo.Count > 0)
            {
                // 商品情報の設定
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = shouhinInfo[0].ShouhinCode;
                if (!Consts.OthersItemCode.Equals(shouhinInfo[0].ShouhinCode))
                {
                    grdDeliveryDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = shouhinInfo[0].ShouhinName;
                }
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = shouhinInfo[0].TopClassification;
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = shouhinInfo[0].BtmClassification;
            }
            else if (dummyCode.Equals(shouhinCode))
            {
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
                grdDeliveryDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            }
        }
        #endregion

        #region データグリッドビュー行の背景色・入力可否設定処理
        /// <summary>
        /// データグリッドビュー行の背景色・入力可否設定処理
        /// </summary>
        /// <param name="topRowIndex"></param>
        /// <param name="color"></param>
        private void setGridRowStyle(int topRowIndex)
        {
            flgInitializing = true;
            Color setColor;
            Color setItemCodeColor;
            Color setItemNameColor;
            int rowStatus = GridErrorStatus.None.GetHashCode();
            string itemCode;
            string bid;
            decimal wkBid;
            // 複写中の行インデックスを取得
            int copyGridTopRowIndex = -1;
            int copyGridBtmRowIndex = -1;
            if (copyGridTopRow != null && copyGridBtmRow != null)
            {
                copyGridTopRowIndex = copyGridTopRow.Index;
                copyGridBtmRowIndex = copyGridBtmRow.Index;
            }
            // 全行の背景色を再設定
            foreach (DataGridViewRow gRow in grdDeliveryDetails.Rows)
            {
                // 複写中の行の場合
                if (copyGridTopRowIndex == gRow.Index || copyGridBtmRowIndex == gRow.Index)
                {
                    // 背景色に薄緑を設定
                    setColor = Color.PaleGreen;
                    setItemCodeColor = Color.PaleGreen;
                    setItemNameColor = Color.PaleGreen;
                }
                else
                {
                    // 訂正・参照・削除モードかつ
                    // 検索処理実行前の場合
                    if ((rdoCorrection.Checked || rdoReference.Checked || rdoDelete.Checked) && !flgSearch)
                    {
                        // 背景色に白を設定
                        setColor = Color.White;
                        setItemCodeColor = Color.White;
                        setItemNameColor = Color.White;
                    }
                    // 指定行より上段に位置する行の場合
                    else if (topRowIndex < 0)
                    {
                        // 背景色に白を設定
                        setColor = Color.White;
                        setItemCodeColor = Color.White;
                        setItemNameColor = Color.White;
                    }
                    // 指定行または指定行の1行下に位置する行の場合
                    else if (gRow.Index == topRowIndex || gRow.Index == topRowIndex + 1)
                    {
                        // 背景色に水色を設定
                        setColor = Color.LightCyan;
                        setItemCodeColor = Color.LightCyan;
                        setItemNameColor = Color.LightCyan;
                    }
                    // 上記以外
                    else
                    {
                        // 背景色に白を設定
                        setColor = Color.White;
                        setItemCodeColor = Color.White;
                        setItemNameColor = Color.White;
                    }

                    rowStatus = Convert.ToInt32(gRow.Cells[clmRowStatus.Name].Value);
                    if (gRow.Index % grdDeliveryDetails.RowSegmentCount == 0)
                    {
                        // 行ステータスに応じて背景色を変更
                        switch ((GridErrorStatus)rowStatus)
                        {
                            // 商品名未入力エラーの場合
                            case GridErrorStatus.ItemNameError:
                                setItemNameColor = Color.Red;
                                break;
                            // 商品ｺｰﾄﾞ、商品名未入力エラーの場合
                            case GridErrorStatus.MultiError:
                                setItemNameColor = Color.Red;
                                break;
                            default: break;
                        }
                    }
                    else
                    {
                        // 行ステータスに応じて背景色を変更
                        switch ((GridErrorStatus)rowStatus)
                        {
                            // 商品ｺｰﾄﾞ未入力エラーの場合
                            case GridErrorStatus.ItemCodeError:
                                setItemCodeColor = Color.Red;
                                break;
                            // 商品ｺｰﾄﾞ、商品名未入力エラーの場合
                            case GridErrorStatus.MultiError:
                                setItemCodeColor = Color.Red;
                                break;
                            default: break;
                        }
                    }
                }

                // 訂正モードかつ検索処理実行前 または
                // 参照モード または
                // 削除モードの場合
                if ((rdoCorrection.Checked && !flgSearch) ||
                    rdoReference.Checked ||
                    rdoDelete.Checked)
                {
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                   // 行No          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmCheckPrint.Name].ReadOnly = true;              // 出力          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;                // 商品ｺｰﾄﾞ      ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                // 商品名        ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;                // 受注数量      ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmDeliveryStatusAndUnit.Name].ReadOnly = true;   // 単位          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;                     // 受注単価/金額 ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;                  // 仕入先ｺｰﾄﾞ/名 ：編集不可
                }
                // 複写中の行の場合
                else if (copyGridTopRowIndex == gRow.Index || copyGridBtmRowIndex == gRow.Index)
                {
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                   // 行No          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmCheckPrint.Name].ReadOnly = true;              // 出力          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;                // 商品ｺｰﾄﾞ      ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                // 商品名        ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;                // 受注数量      ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmDeliveryStatusAndUnit.Name].ReadOnly = true;   // 単位          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;                     // 受注単価/金額 ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;                  // 仕入先ｺｰﾄﾞ/名 ：編集不可
                }
                // 上段行の場合
                else if (gRow.Index % grdDeliveryDetails.RowSegmentCount == 0)
                {
                    if (grdDeliveryDetails.Rows.Count - 1 == gRow.Index)
                    {
                        itemCode = string.Empty;
                    }
                    else
                    {
                        itemCode = Convert.ToString(grdDeliveryDetails.Rows[gRow.Index + 1].Cells[clmItemCode.Name].Value);
                    }
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                   // 行No          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmCheckPrint.Name].ReadOnly = true;              // 出力          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;                // 商品ｺｰﾄﾞ      ：編集不可
                    // 商品ｺｰﾄﾞが"99999"の場合
                    if (Consts.OthersItemCode.Equals(itemCode))
                    {
                        grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = false;           // 商品名        ：編集可
                    }
                    else
                    {
                        grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;            // 商品名        ：編集不可
                    }
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;                // 数量          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmDeliveryStatusAndUnit.Name].ReadOnly = true;   // 単位          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;                     // 単価          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;                  // 金額          ：編集不可
                }
                // 下段行の場合
                else
                {
                    bid = Convert.ToString(grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].Value);
                    decimal.TryParse(bid, out wkBid);
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                   // 行No          ：編集不可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmCheckPrint.Name].ReadOnly = false;             // 出力          ：編集可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = false;               // 商品ｺｰﾄﾞ      ：編集可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = false;               // 商品名        ：編集可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = false;               // 数量          ：編集可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmDeliveryStatusAndUnit.Name].ReadOnly = false;  // 単位          ：編集可
                    grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = false;                    // 単価          ：編集可
                    // 単価が0の場合
                    if (wkBid == decimal.Zero)
                    {
                        grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = false;             // 金額          ：編集可
                    }
                    else
                    {
                        grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;              // 金額          ：編集不可
                    }
                }

                // セル未選択時の背景色の設定
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowNo.Name].Style.BackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmCheckPrint.Name].Style.BackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemCode.Name].Style.BackColor = setItemCodeColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].Style.BackColor = setItemNameColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmQuantity.Name].Style.BackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmDeliveryStatusAndUnit.Name].Style.BackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].Style.BackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].Style.BackColor = setColor;
                // セル選択時の背景色の設定
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowNo.Name].Style.SelectionBackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmCheckPrint.Name].Style.SelectionBackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemCode.Name].Style.SelectionBackColor = setItemCodeColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmItemName.Name].Style.SelectionBackColor = setItemNameColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmQuantity.Name].Style.SelectionBackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmDeliveryStatusAndUnit.Name].Style.SelectionBackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmBid.Name].Style.SelectionBackColor = setColor;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmAmount.Name].Style.SelectionBackColor = setColor;

                grdDeliveryDetails.Rows[gRow.Index].Cells[clmRowStatus.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmTopClassificationCode.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmbtmClassificationCode.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmOrderRowNo.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmOrderQuantity.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmOrdersDeliveryQuantity.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmVenderCode.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmVenderName.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmOrderNo.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmVenderQuantity.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmVenderBid.Name].ReadOnly = true;
                grdDeliveryDetails.Rows[gRow.Index].Cells[clmVenderAmount.Name].ReadOnly = true;
            }
            flgInitializing = false;
        }
        #endregion

        #region 受注データ設定処理
        /// <summary>
        /// 受注データ設定処理
        /// </summary>
        /// <param name="ordersNo"></param>
        /// <returns></returns>
        private bool setJuchuData(string juchuDocumentNo)
        {
            bool flgEndTransaction = false;
            try
            {
                if (flgSearch) return false;
                // 元のカーソルを保持
                Cursor preCursor = Cursor.Current;

                // カーソルを待機カーソルに変更
                Cursor.Current = Cursors.WaitCursor;

                // トランザクション開始処理を実行
                dataSelectDb.startTransaction();

                // 受注データ取得処理実行
                DBNouhinsyo.SelectErrorType selectResult = dataSelectDb.getJuchuData(juchuDocumentNo, true);
                wkJuchuDocumentNo = juchuDocumentNo;

                // 取得時にエラーが発生した場合
                if (selectResult != DBNouhinsyo.SelectErrorType.None)
                {
                    errorOK(string.Format(Messages.M0027, "受注データ"));
                    flgEndTransaction = true;
                    return false;
                }

                DBFileLayout.JuchuHeaderFile headerData = dataSelectDb.SelectJuchuData.HeaderData;
                List<DBFileLayout.JuchuBodyFile> bodyData = dataSelectDb.SelectJuchuData.BodyDatas;
                DBFileLayout.JuchuFooterFile footerData = dataSelectDb.SelectJuchuData.FooterData;

                // 受注ヘッダデータが存在する場合
                if (headerData.FlgDataExsit)
                {
                    // 既に削除されている場合、エラーメッセージを出力して処理を終了
                    if (Consts.KanriCodeTypes.TYPE9.Equals(headerData.KanriKubun))
                    {
                        errorOK(string.Format(Messages.M0013, "削除", "受注データ", "処理を継続"));
                        flgEndTransaction = true;
                        return false;
                    }
                }
                // 受注ヘッダデータが存在しない場合
                else
                {
                    // エラーメッセージを出力して処理を終了
                    errorOK(string.Format(Messages.M0029, "受注No"));
                    flgEndTransaction = true;
                    return false;
                }

                // 得意先コードが99999の場合
                if (headerData.TokuisakiCode.Equals(Consts.OthersCustomerCode))
                {
                    if (warningYesNo(Messages.M0062) == DialogResult.No)
                    {
                        flgEndTransaction = true;
                        return false;
                    }
                }

                // 取得した受注ヘッダデータを画面項目に設定します
                if (string.IsNullOrEmpty(headerData.TantousyaCode))
                {
                    cmbPersonnel.Text = headerData.TantousyaName;                // 担当者
                }
                else
                {
                    cmbPersonnel.SelectedValue = headerData.TantousyaCode;       // 担当者
                    cmbPersonnel.Text = headerData.TantousyaName;
                }
                txtOrderNo.Text = headerData.JuchuNoTop;                         // 受注NO(担当者コード)
                txtOrderNo.Text += headerData.JuchuNoMid;                        // 受注NO(月)
                txtOrderNo.Text += headerData.JuchuNoBtm;                        // 受注NO(担当者毎受注No)
                txtCustomerCode.Text = headerData.TokuisakiCode;                 // 得意先コード
                txtCustomerName.Text = headerData.TokuisakiName;                 // 得意先名
                txtCustomerKanaName.Text = headerData.TokuisakiKanaName;         // 得意先カナ名
                setOfficesCmb(txtCustomerCode.Text, headerData.JigyousyoCode);   // 事業所
                txtCustomerPersonnel.Text = headerData.TokuisakiTantousayName;   // 得意先担当者名
                txtSubjectNo.Text = headerData.KenmeiNo;                         // 件名No
                txtSubject1.Text = headerData.Kenmei1;                           // 件名1
                txtSubject2.Text = headerData.Kenmei2;                           // 件名2
                txtGuestNoteNumber.Text = headerData.KyakusakiChuban;            // 客先注番

                // 取得した受注ボディデータを受注明細グリッドに設定します
                grdDeliveryDetails.Rows.Clear();
                int gridRowIndex = 0;
                string unitValue;
                string unitText;
                DataGridViewRow topRow;
                DataGridViewRow btmRow;
                // 単位コンボボックス設定
                setUnitCmb();
                DataTable unitDt = (DataTable)clmDeliveryStatusAndUnit.DataSource;
                DBFileLayout.JuchuBodyFile wkBodyData;
                for (int i = 0; i < bodyData.Count; i++)
                {
                    gridRowIndex = i * grdDeliveryDetails.RowSegmentCount;
                    // 受注グリッドへ空行を追加
                    addEmptyGridRow();
                    topRow = grdDeliveryDetails.Rows[gridRowIndex];
                    btmRow = grdDeliveryDetails.Rows[gridRowIndex + 1];
                    wkBodyData = bodyData[i];

                    // 上段行への値設定
                    // 商品名(上段)
                    topRow.Cells[clmItemName.Name].Value = wkBodyData.ShouhinName1;
                    // エラー状態
                    topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                    // 下段行への値設定
                    // 出力
                    btmRow.Cells[clmCheckPrint.Name].Value = true;
                    // 商品ｺｰﾄﾞ
                    btmRow.Cells[clmItemCode.Name].Value = wkBodyData.ShouhinCode;
                    // 商品名(下段)
                    btmRow.Cells[clmItemName.Name].Value = wkBodyData.ShouhinName2;
                    // 数量
                    if (wkBodyData.JuchuSuryo == null)
                    {
                        btmRow.Cells[clmQuantity.Name].Value = null;
                    }
                    else
                    {
                        btmRow.Cells[clmQuantity.Name].Value = Convert.ToDecimal(wkBodyData.JuchuSuryo).ToString(quantityFormat);
                    }
                    // 単位
                    unitText = wkBodyData.JuchuTani;
                    var query = unitDt.AsEnumerable().Where(p => p.Field<String>(commonLogic.StrCmbValue) == unitText);
                    if (query.Count() > 0)
                    {
                        unitValue = Convert.ToString(query.ElementAt(0)[commonLogic.StrCmbKey]);
                    }
                    else if (string.IsNullOrEmpty(unitText))
                    {
                        unitValue = string.Empty;
                    }
                    else
                    {
                        unitValue = (unitDt.Rows.Count >= 9 ? string.Empty : "0") + Convert.ToString(unitDt.Rows.Count + 1);
                        unitDt.Rows.Add(new object[] { unitValue, unitText });
                        unitDt.AcceptChanges();
                    }
                    btmRow.Cells[clmDeliveryStatusAndUnit.Name].Value = unitValue;
                    // 単価
                    if (wkBodyData.JuchuTanka == null)
                    {
                        btmRow.Cells[clmBid.Name].Value = null;
                    }
                    else
                    {
                        btmRow.Cells[clmBid.Name].Value = Convert.ToDecimal(wkBodyData.JuchuTanka).ToString(bidFormat);
                    }
                    // 金額
                    if (wkBodyData.JuchuKingaku == null)
                    {
                        btmRow.Cells[clmAmount.Name].Value = null;
                    }
                    else
                    {
                        btmRow.Cells[clmAmount.Name].Value = Convert.ToDecimal(wkBodyData.JuchuKingaku).ToString(amountFormat);
                    }
                    btmRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;
                    btmRow.Cells[clmTopClassificationCode.Name].Value = wkBodyData.DaiBunruiCode;
                    btmRow.Cells[clmbtmClassificationCode.Name].Value = wkBodyData.SyoBunruiCode;
                    btmRow.Cells[clmOrderRowNo.Name].Value = wkBodyData.RowNo;
                    btmRow.Cells[clmOrderNo.Name].Value = wkBodyData.ShireHachuNo;
                    btmRow.Cells[clmVenderCode.Name].Value = wkBodyData.ShiresakiCode;
                    btmRow.Cells[clmVenderName.Name].Value = wkBodyData.ShiresakiName;
                    if (wkBodyData.JuchuSuryo == null)
                    {
                        btmRow.Cells[clmOrderQuantity.Name].Value = decimal.Zero;
                    }
                    else
                    {
                        btmRow.Cells[clmOrderQuantity.Name].Value = wkBodyData.JuchuSuryo;
                    }
                    if (wkBodyData.JuchuNouhinSuryo == null)
                    {
                        btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value = decimal.Zero;
                    }
                    else
                    {
                        btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value = wkBodyData.JuchuNouhinSuryo;
                    }
                    if (wkBodyData.JuchuSuryo == null)
                    {
                        btmRow.Cells[clmVenderQuantity.Name].Value = decimal.Zero;
                    }
                    else
                    {
                        btmRow.Cells[clmVenderQuantity.Name].Value = wkBodyData.JuchuSuryo;
                    }
                    if (wkBodyData.ShireTanka == null)
                    {
                        btmRow.Cells[clmVenderBid.Name].Value = decimal.Zero;
                    }
                    else
                    {
                        btmRow.Cells[clmVenderBid.Name].Value = wkBodyData.ShireTanka;
                    }
                    if (wkBodyData.ShireKingaku == null)
                    {
                        btmRow.Cells[clmVenderAmount.Name].Value = decimal.Zero;
                    }
                    else
                    {
                        btmRow.Cells[clmVenderAmount.Name].Value = wkBodyData.ShireKingaku;
                    }

                    // 対象行への納品状態設定処理実行
                    setNouhinJotai(gridRowIndex);
                }
                copyGridTopRow = null;
                copyGridBtmRow = null;

                // 合計金額の再計算処理実行
                recalcSyukei();

                // 取得した受注ボディデータが初期表示件数未満の場合、不足データ分の空行を受注グリッドに追加します
                addInsufficientEmptyGridRow();
                // 最終行が空行でない場合、行追加
                addLastEmptyRow();
                grdDeliveryDetails.CurrentCell = null;

                // 検索実行済みフラグにtrueを設定
                flgSearch = true;

                // カーソルを元に戻す
                Cursor.Current = preCursor;

                return true;
            }
            finally
            {
                if (flgEndTransaction) dataSelectDb.endTransaction();
            }
        }
        #endregion

        #region 納品書データ設定処理
        /// <summary>
        /// 納品書データ設定処理
        /// </summary>
        /// <param name="documentNo"></param>
        /// <returns></returns>
        private bool setNouhinsyoData(string denpyoNo)
        {
            bool flgEndTransaction = false;
            try
            {
                if (flgSearch) return false;
                flgNouhinsyoDataSet = true;
                // 元のカーソルを保持
                Cursor preCursor = Cursor.Current;

                // カーソルを待機カーソルに変更
                Cursor.Current = Cursors.WaitCursor;

                // トランザクション開始処理を実行
                dataSelectDb.startTransaction();

                // 納品データ取得処理実行
                DBNouhinsyo.SelectErrorType selectResult = dataSelectDb.getNouhinsyoData(denpyoNo);

                // データ取得時にエラーが発生した場合
                switch (selectResult)
                {
                    case DBNouhinsyo.SelectErrorType.JuchuHeader:
                    case DBNouhinsyo.SelectErrorType.JuchuBody:
                    case DBNouhinsyo.SelectErrorType.JuchuFooter:
                        errorOK(string.Format(Messages.M0031, "伝票No", "受注データ"));
                        flgEndTransaction = true;
                        return false;
                    case DBNouhinsyo.SelectErrorType.UriageHeader:
                    case DBNouhinsyo.SelectErrorType.UriageBody:
                    case DBNouhinsyo.SelectErrorType.UriageFooter:
                        errorOK(string.Format(Messages.M0031, "伝票No", "売上データ"));
                        flgEndTransaction = true;
                        return false;
                    case DBNouhinsyo.SelectErrorType.ShireHeader:
                    case DBNouhinsyo.SelectErrorType.ShireBody:
                    case DBNouhinsyo.SelectErrorType.ShireFooter:
                        errorOK(string.Format(Messages.M0031, "伝票No", "仕入データ"));
                        flgEndTransaction = true;
                        return false;
                    default:
                        break;
                }

                DBFileLayout.UriageHeaderFile uriageHeaderData = dataSelectDb.SelectUriageData.HeaderData;
                List<DBFileLayout.UriageBodyFile> uriageBodyData = dataSelectDb.SelectUriageData.BodyDatas;
                DBFileLayout.UriageFooterFile uriageFooterData = dataSelectDb.SelectUriageData.FooterData;
                DBFileLayout.JuchuHeaderFile juchuHeaderData = dataSelectDb.SelectJuchuData.HeaderData;
                List<DBFileLayout.JuchuBodyFile> juchuBodyData = dataSelectDb.SelectJuchuData.BodyDatas;
                DBFileLayout.JuchuFooterFile juchuFooterData = dataSelectDb.SelectJuchuData.FooterData;

                // 納品書ヘッダデータが存在する場合
                if (uriageHeaderData.FlgDataExsit)
                {
                    // 既に削除されている場合、エラーメッセージを出力して処理を終了
                    if (Consts.KanriCodeTypes.TYPE9.Equals(uriageHeaderData.KanriKubun))
                    {
                        errorOK(string.Format(Messages.M0013, "削除", "納品書データ", "処理を継続"));
                        flgEndTransaction = true;
                        return false;
                    }
                }
                // 納品書ヘッダデータが存在しない場合
                else
                {
                    // エラーメッセージを出力して処理を終了
                    errorOK(string.Format(Messages.M0029, "伝票No"));
                    flgEndTransaction = true;
                    return false;
                }
                // 締処理済みチェック
                if (rdoCorrection.Checked || rdoDelete.Checked)
                {
                    foreach (DBFileLayout.UriageBodyFile uriage in uriageBodyData)
                    {
                        if (Convert.ToString(decimal.One).Equals(uriage.SeikyuHuragu))
                        {
                            errorOK(string.Format(Messages.M0058));
                            flgEndTransaction = true;
                            return false;
                        }
                    }
                }

                // 取得した受注ヘッダデータを画面項目に設定します
                int nouhinsyoKubun = Convert.ToInt16(uriageHeaderData.NouhinsyoKubun);
                setNouhinsyoBase(getNouhinsyoRadio((NouhinsyoType)nouhinsyoKubun));

                txtDocumentNo.Text = uriageHeaderData.DenpyoNo;                             // 伝票NO
                dtpDocumentDate.Value = Convert.ToDateTime(uriageHeaderData.DenpyoHizuke);  // 伝票日付
                if (string.IsNullOrEmpty(uriageHeaderData.TantousyaCode))
                {
                    cmbPersonnel.Text = uriageHeaderData.TantousyaName;                     // 担当者
                }
                else
                {
                    cmbPersonnel.SelectedValue = uriageHeaderData.TantousyaCode;            // 担当者
                    cmbPersonnel.Text = uriageHeaderData.TantousyaName;
                }
                txtSpecifiedDocumentNo.Text = uriageHeaderData.ShiteiDenpyoNo;              // 指定伝票NO
                txtOrderNo.Text = uriageHeaderData.JuchuNoTop;                              // 受注NO(担当者コード)
                txtOrderNo.Text += uriageHeaderData.JuchuNoMid;                             // 受注NO(月)
                txtOrderNo.Text += uriageHeaderData.JuchuNoBtm;                             // 受注NO(担当者毎受注No)
                dtpOrderDate.Value = Convert.ToDateTime(uriageHeaderData.ChumonHizuke);     // 注文日付
                txtCustomerCode.Text = uriageHeaderData.TokuisakiCode;                      // 得意先コード
                txtCustomerName.Text = uriageHeaderData.TokuisakiName;                      // 得意先名
                txtCustomerKanaName.Text = uriageHeaderData.TokuisakiKanaName;              // 得意先カナ名
                setOfficesCmb(txtCustomerCode.Text, uriageHeaderData.JigyousyoCode);        // 事業所
                txtCustomerPersonnel.Text = uriageHeaderData.TokuisakiTantousayName;        // 得意先担当者名
                txtSubjectNo.Text = uriageHeaderData.KenmeiNo;                              // 件名No
                txtSubject1.Text = uriageHeaderData.Kenmei1;                                // 件名1
                txtSubject2.Text = uriageHeaderData.Kenmei2;                                // 件名2
                txtWork1.Text = uriageHeaderData.Kouban1;                                   // 工番１
                txtWork2.Text = uriageHeaderData.Kouban2;                                   // 工番２
                txtWork3.Text = uriageHeaderData.Kouban3;                                   // 工番３
                try
                {
                    dtpDeliveryDate.Value = Convert.ToDateTime(uriageHeaderData.NouhinHizuke);  // 納品日付
                }
                catch
                {
                    txtDeliveryDateYears.Text = string.Empty;
                    txtDeliveryDateMonth.Text = string.Empty;
                    txtDeliveryDateDays.Text = string.Empty;
                }
                txtRemarks1.Text = uriageHeaderData.Bikou1;                                 // 備考１
                txtRemarks2.Text = uriageHeaderData.Bikou2;                                 // 備考２
                txtGuestNoteNumber.Text = uriageHeaderData.KyakusakiChuban;                 // 客先注番
                if (decimal.Zero.Equals(uriageHeaderData.FlgMeisaiIkkatuSyuturyoku))        // 明細行をまとめて出力フラグ
                {
                    chkDetailPutTogether.Checked = false;
                }
                else
                {
                    chkDetailPutTogether.Checked = true;
                }

                // 取得した受注ボディデータを受注明細グリッドに設定します
                grdDeliveryDetails.Rows.Clear();
                int gridRowIndex = 0;
                string unitValue;
                string unitText;
                DataGridViewRow topRow;
                DataGridViewRow btmRow;
                // 単位コンボボックス設定
                setUnitCmb();
                DataTable unitDt = (DataTable)clmDeliveryStatusAndUnit.DataSource;
                DBFileLayout.UriageBodyFile wkBodyData;
                for (int i = 0; i < uriageBodyData.Count; i++)
                {
                    gridRowIndex = i * grdDeliveryDetails.RowSegmentCount;
                    // 受注グリッドへ空行を追加
                    addEmptyGridRow();
                    topRow = grdDeliveryDetails.Rows[gridRowIndex];
                    btmRow = grdDeliveryDetails.Rows[gridRowIndex + 1];
                    wkBodyData = uriageBodyData[i];

                    // 上段行への値設定
                    // 商品名(上段)
                    topRow.Cells[clmItemName.Name].Value = Convert.ToString(wkBodyData.ShouhinName1);
                    // エラー状態
                    topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                    // 下段行への値設定
                    // 出力
                    btmRow.Cells[clmCheckPrint.Name].Value = wkBodyData.FlgPrint == 0 ? false : true;
                    // 商品ｺｰﾄﾞ
                    btmRow.Cells[clmItemCode.Name].Value = Convert.ToString(wkBodyData.ShouhinCode);
                    // 商品名(下段)
                    btmRow.Cells[clmItemName.Name].Value = Convert.ToString(wkBodyData.ShouhinName2);
                    // 数量
                    if (wkBodyData.Suryo == null)
                    {
                        btmRow.Cells[clmQuantity.Name].Value = null;
                    }
                    else
                    {
                        btmRow.Cells[clmQuantity.Name].Value = Convert.ToDecimal(wkBodyData.Suryo).ToString(quantityFormat);
                    }
                    // 単位
                    unitText = wkBodyData.Tani;
                    var query = unitDt.AsEnumerable().Where(p => p.Field<String>(commonLogic.StrCmbValue) == unitText);
                    if (query.Count() > 0)
                    {
                        unitValue = Convert.ToString(query.ElementAt(0)[commonLogic.StrCmbKey]);
                    }
                    else if (string.IsNullOrEmpty(unitText))
                    {
                        unitValue = string.Empty;
                    }
                    else
                    {
                        unitValue = (unitDt.Rows.Count >= 9 ? string.Empty : "0") + Convert.ToString(unitDt.Rows.Count + 1);
                        unitDt.Rows.Add(new object[] { unitValue, unitText });
                        unitDt.AcceptChanges();
                    }
                    btmRow.Cells[clmDeliveryStatusAndUnit.Name].Value = unitValue;
                    // 単価
                    if (wkBodyData.Tanka == null)
                    {
                        btmRow.Cells[clmBid.Name].Value = null;
                    }
                    else
                    {
                        btmRow.Cells[clmBid.Name].Value = Convert.ToDecimal(wkBodyData.Tanka).ToString(bidFormat);
                    }
                    // 金額
                    if (wkBodyData.Kingaku == null)
                    {
                        btmRow.Cells[clmAmount.Name].Value = null;
                    }
                    else
                    {
                        btmRow.Cells[clmAmount.Name].Value = Convert.ToDecimal(wkBodyData.Kingaku).ToString(amountFormat);
                    }
                    btmRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;
                    btmRow.Cells[clmTopClassificationCode.Name].Value = Convert.ToString(wkBodyData.DaiBunruiCode);
                    btmRow.Cells[clmbtmClassificationCode.Name].Value = Convert.ToString(wkBodyData.SyoBunruiCode);
                    btmRow.Cells[clmOrderRowNo.Name].Value = wkBodyData.JuchuRowNo;

                    if (wkBodyData.JuchuRowNo > 0)
                    {
                        for (int j = 0; j < juchuBodyData.Count; j++)
                        {
                            if (juchuBodyData[j].RowNo != wkBodyData.JuchuRowNo) continue;

                            if (juchuBodyData[j].JuchuSuryo == null)
                            {
                                btmRow.Cells[clmOrderQuantity.Name].Value = decimal.Zero;
                            }
                            else
                            {
                                btmRow.Cells[clmOrderQuantity.Name].Value = juchuBodyData[j].JuchuSuryo;
                            }
                            if (juchuBodyData[j].JuchuNouhinSuryo == null)
                            {
                                btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value = decimal.Zero;
                            }
                            else
                            {
                                btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value = juchuBodyData[j].JuchuNouhinSuryo;
                            }
                            btmRow.Cells[clmOrderNo.Name].Value = juchuBodyData[j].ShireHachuNo;
                            btmRow.Cells[clmVenderCode.Name].Value = juchuBodyData[j].ShiresakiCode;
                            btmRow.Cells[clmVenderName.Name].Value = juchuBodyData[j].ShiresakiName;
                        }
                        foreach (DBFileLayout.ShireBodyFile shireBodyFile in dataSelectDb.SelectShireData.BodyDatas)
                        {
                            if (shireBodyFile.RowNo != wkBodyData.JuchuRowNo) continue;
                            btmRow.Cells[clmVenderBid.Name].Value = shireBodyFile.Tanka;
                            btmRow.Cells[clmVenderAmount.Name].Value = shireBodyFile.Kingaku;
                        }
                    }

                    // 対象行への納品状態設定処理実行
                    setNouhinJotai(gridRowIndex);
                }
                copyGridTopRow = null;
                copyGridBtmRow = null;

                // 合計金額の再計算処理実行
                recalcSyukei();

                // 取得した納品書ボディデータが初期表示件数未満の場合、不足データ分の空行を納品書グリッドに追加します
                addInsufficientEmptyGridRow();
                // 最終行が空行でない場合、行追加
                addLastEmptyRow();
                grdDeliveryDetails.CurrentCell = null;

                // 検索実行済みフラグにtrueを設定
                flgSearch = true;

                // カーソルを元に戻す
                Cursor.Current = preCursor;
                flgNouhinsyoDataSet = false;

                return true;
            }
            finally
            {
                if (flgEndTransaction) dataSelectDb.endTransaction();
            }
        }
        #endregion

        #region 処理モードラジオボタン変更処理
        /// <summary>
        /// 処理モードラジオボタン変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputModeChange(RadioButton radio)
        {
            // チェックOFFの場合何もしない
            if (!radio.Checked) return;

            // トランザクション開始済みの場合
            if (dataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                dataSelectDb.endTransaction();
            }
            activeModeRadioButton = radio;
            initializeNouhinsyo(getNouhinsyoType(nowActiveNouhinsyoRadio.Name));

        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtDocumentNo.MaxLength = 8;            // 伝票ＮＯ
            txtDocumentDateYears.MaxLength = 4;     // 伝票日付(年)
            txtDocumentDateMonth.MaxLength = 2;     // 伝票日付(月)
            txtDocumentDateDays.MaxLength = 2;      // 伝票日付(日)
            cmbPersonnel.MaxLength = 10;            // 担当者
            txtSpecifiedDocumentNo.MaxLength = 8;   // 指定伝票番号
            txtOrderNo.MaxLength = 15;              // 発注No
            txtOrderDateYears.MaxLength = 4;        // 発注日付(年)
            txtOrderDateMonth.MaxLength = 2;        // 発注日付(月)
            txtOrderDateDays.MaxLength = 2;         // 発注日付(日)
            txtCustomerCode.MaxLength = 5;          // 得意先ｺｰﾄﾞ
            txtCustomerName.MaxLength = 40;         // 得意先名
            txtCustomerKanaName.MaxLength = 80;     // 得意先カナ名
            cmbOffices.MaxLength = 10;              // 事業所
            txtCustomerPersonnel.MaxLength = 15;    // 得意先担当者名
            txtSubjectNo.MaxLength = 5;             // 件名No
            txtSubject1.MaxLength = 20;             // 件名１
            txtSubject2.MaxLength = 20;             // 件名２
            txtWork1.MaxLength = 15;                // 工番１
            txtWork2.MaxLength = 15;                // 工番２
            txtWork3.MaxLength = 15;                // 工番３
            txtDeliveryDateYears.MaxLength = 4;     // 納品日付(年)
            txtDeliveryDateMonth.MaxLength = 2;     // 納品日付(月)
            txtDeliveryDateDays.MaxLength = 2;      // 納品日付(日)
            txtRemarks1.MaxLength = 25;             // 備考１
            txtRemarks2.MaxLength = 25;             // 備考２
            txtGuestNoteNumber.MaxLength = 20;      // 客先注番

            // 入力制御イベント設定
            txtDocumentNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 伝票ＮＯ    :数字のみ入力可
            txtDocumentDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 伝票日付(年):数字のみ入力可
            txtDocumentDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 伝票日付(月):数字のみ入力可
            txtDocumentDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 伝票日付(日):数字のみ入力可
            txtSpecifiedDocumentNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 指定伝票番号:数字のみ入力可
            txtOrderNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);              // 発注No      :数字のみ入力可
            txtOrderDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 発注日付(年):数字のみ入力可
            txtOrderDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 発注日付(月):数字のみ入力可
            txtOrderDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 発注日付(日):数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 得意先ｺｰﾄﾞ  :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);      // 得意先カナ名:全角カナのみ入力可
            txtSubjectNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);            // 件名NO      :数字のみ入力可
            txtDeliveryDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 納品日付(年):数字のみ入力可
            txtDeliveryDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 納品日付(月):数字のみ入力可
            txtDeliveryDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 納品日付(日):数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region DataGridViewのコンボボックス更新処理
        /// <summary>
        /// DataGridViewのコンボボックス更新処理
        /// </summary>
        /// <param name="colIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="value"></param>
        /// <param name="dgv"></param>
        private void UpdateCmbList(int colIndex, int rowIndex, object value, ref CustomDataGridView dgv)
        {
            // 値を文字列に変換
            string formattedValue = string.Empty;
            if (value != null)
            {
                formattedValue = value.ToString();
            }
            string newValue;
            if (!string.IsNullOrEmpty(formattedValue))
            {
                DataTable dt = ((DataTable)clmDeliveryStatusAndUnit.DataSource);
                var query = dt.AsEnumerable().Where(p => formattedValue.Equals(p.Field<String>(commonLogic.StrCmbValue)));
                if (query.Count() == 0)
                {
                    newValue = Convert.ToString(dt.Rows.Count + 1);
                    dt.Rows.Add(new object[] { newValue, formattedValue });
                    // 一度コミットする(リストへの追加を有効にするため)
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else
                {
                    newValue = Convert.ToString(query.ElementAt(0)[commonLogic.StrCmbKey]);
                }
            }
            else
            {
                newValue = formattedValue;
            }
            try
            {
                // セルのValueを更新
                ((DataGridViewComboBoxCell)dgv.Rows[rowIndex].Cells[colIndex]).Value = newValue;
            }
            catch
            {
            }
        }
        #endregion

        #region 明細の再計算処理
        /// <summary>
        /// 明細の再計算処理
        /// </summary>
        private void recalcMeisai(int rowIndex)
        {
            // 金額の再計算
            int topRowIndex = rowIndex % grdDeliveryDetails.RowSegmentCount == 0 ? rowIndex : rowIndex - 1;
            int btmRowIndex = topRowIndex + 1;
            string strQuantity = Convert.ToString(grdDeliveryDetails.Rows[btmRowIndex].Cells[clmQuantity.Name].Value);
            string strBid = Convert.ToString(grdDeliveryDetails.Rows[btmRowIndex].Cells[clmBid.Name].Value);
            decimal quantity = decimal.Zero;
            decimal bid = decimal.Zero;
            decimal amount = decimal.Zero;

            if (decimal.TryParse(strQuantity, out quantity) && decimal.TryParse(strBid, out bid))
            {
                amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, quantity * bid);
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = amount.ToString(amountFormat);
            }
            else
            {
                grdDeliveryDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
            }

            // 合計金額の再計算処理実行
            recalcSyukei();

            //　納品状況設定処理実行
            setNouhinJotai(topRowIndex);
        }
        #endregion

        #region 合計金額の再計算処理
        /// <summary>
        /// 合計金額の再計算処理
        /// </summary>
        private void recalcSyukei()
        {
            DataTable syukeiDt = (DataTable)grdDeliveryTotalDetails.DataSource;

            string strAmount;
            decimal amount = decimal.Zero;
            decimal totalAmount = decimal.Zero;
            bool flgTotalCalc = false;
            string checkPrint;
            for (int i = 0; i < grdDeliveryDetails.Rows.Count; i++)
            {
                if (i % grdDeliveryDetails.RowSegmentCount == 0) continue;
                checkPrint = Convert.ToString(grdDeliveryDetails.Rows[i].Cells[clmCheckPrint.Name].Value);
                if (string.IsNullOrEmpty(checkPrint)) continue;
                if (!Convert.ToBoolean(checkPrint)) continue;
                strAmount = Convert.ToString(grdDeliveryDetails.Rows[i].Cells[clmAmount.Name].Value);
                if (decimal.TryParse(strAmount, out amount))
                {
                    totalAmount += amount;
                    flgTotalCalc = true;
                }
            }

            if (flgTotalCalc)
            {
                syukeiDt.Rows[0][clmTotalAmount.DataPropertyName] = totalAmount;
            }
            else
            {
                syukeiDt.Rows[0][clmTotalAmount.DataPropertyName] = DBNull.Value;
            }
            grdDeliveryDetails.Refresh();
        }
        #endregion

        #region 納品書グリッドの中間空白行存在チェック処理
        /// <summary>
        /// 納品書グリッドの中間空白行存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkMiddleEmptyRowExist()
        {
            bool flgEmptyRow = false;
            for (int i = 0; i < grdDeliveryDetails.Rows.Count; i++)
            {
                if (checkEmptyRow(i))
                {
                    flgEmptyRow = true;
                }
                else if (flgEmptyRow)
                {
                    return true;
                }
                else
                {
                    flgEmptyRow = false;
                }
                i++;
            }

            return false;
        }
        #endregion

        #region 納品書グリッドの中間空白行削除処理
        /// <summary>
        /// 納品書グリッドの中間空白行削除処理
        /// </summary>
        private void deleteAllEmptyRow()
        {
            for (int i = grdDeliveryDetails.Rows.Count - 1; i >= 0; i--)
            {
                if (checkEmptyRow(i - 1))
                {
                    grdDeliveryDetails.Rows.Remove(grdDeliveryDetails.Rows[i]);
                    grdDeliveryDetails.Rows.Remove(grdDeliveryDetails.Rows[i - 1]);
                }
                i--;
            }

            // 納品書グリッドが初期表示件数未満の場合、不足データ分の空行を追加します
            addInsufficientEmptyGridRow();

            // 最終行が空行でない場合、行追加
            addLastEmptyRow();
        }
        #endregion

        #region 納品書ヘッダ登録・更新SQL生成処理
        /// <summary>
        /// 納品書ヘッダ登録・更新SQL生成処理
        /// </summary>
        /// <param name="denpyoNo"></param>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createUriageHeaderRegistSql(ref string denpyoNo, string juchuNo, DateTime registerDate)
        {
            string sql = string.Empty;
            denpyoNo = txtDocumentNo.Text;
            DateTime denpyoHizuke = commonLogic.convertDateTime(txtDocumentDateYears.Text, txtDocumentDateMonth.Text, txtDocumentDateDays.Text);
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            string chihouCode = string.Empty;
            string chikuCode = string.Empty;
            string tokuisakiCode = txtCustomerCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string jigyousyoName = cmbOffices.Text;
            string tokuisakiTantousayName = txtCustomerPersonnel.Text;
            string zipCode = string.Empty;
            string addres1 = string.Empty;
            string addres2 = string.Empty;
            DBTokuisakiMaster dBTokuisaki = new DBTokuisakiMaster();
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = dBTokuisaki.getTokuisakiInfo(tokuisakiCode, jigyousyoCode);
            if (tokuisakiInfos != null && tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
                zipCode = tokuisakiInfos[0].ZipCode;
                addres1 = tokuisakiInfos[0].Address1;
                addres2 = tokuisakiInfos[0].Address2;
            }
            string tantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);
            string tantousyaName = cmbPersonnel.Text;
            string kenmeiNo = txtSubjectNo.Text;
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;
            DateTime chumonHizuke = commonLogic.convertDateTime(txtOrderDateYears.Text, txtOrderDateMonth.Text, txtOrderDateDays.Text);
            string shiteiDenpyoNo = txtSpecifiedDocumentNo.Text;
            DateTime nouhinHizuke = commonLogic.convertDateTime(txtDeliveryDateYears.Text, txtDeliveryDateMonth.Text, txtDeliveryDateDays.Text);
            string kouban1 = txtWork1.Text;
            string kouban2 = txtWork2.Text;
            string kouban3 = txtWork3.Text;
            string nouhinsyoKubun = getNouhinsyoType(nowActiveNouhinsyoRadio.Name).GetHashCode().ToString();
            string bikou1 = txtRemarks1.Text;
            string bikou2 = txtRemarks2.Text;
            string kyakusakiChuban = txtGuestNoteNumber.Text;
            int flgMeisaiIkkatuSyuturyoku = chkDetailPutTogether.Checked ? 1 : 0;

            if (rdoNew.Checked)
            {
                // 伝票No採番
                if (string.IsNullOrEmpty(denpyoNo))
                {
                    denpyoNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getUriageNo() + 1).ToString(), txtDocumentNo.MaxLength);
                }

                // 納品書ヘッダの登録SQL生成
                sql += "INSERT INTO uriage_header ";
                sql += "( ";
                sql += "  denpyoNo ";
                sql += ", denpyoHizuke ";
                sql += ", juchuNoTop ";
                sql += ", juchuNoMid ";
                sql += ", juchuNoBtm ";
                sql += ", chihouCode ";
                sql += ", chikuCode ";
                sql += ", tokuisakiCode ";
                sql += ", tokuisakiName ";
                sql += ", tokuisakiKanaName ";
                sql += ", jigyousyoCode ";
                sql += ", jigyousyoName ";
                sql += ", tokuisakiTantousayName ";
                sql += ", zipCode ";
                sql += ", addres1 ";
                sql += ", addres2 ";
                sql += ", tantousyaCode ";
                sql += ", tantousyaName ";
                sql += ", kenmeiNo ";
                sql += ", kenmei1 ";
                sql += ", kenmei2 ";
                sql += ", chumonHizuke ";
                sql += ", shiteiDenpyoNo ";
                sql += ", nouhinHizuke ";
                sql += ", kouban1 ";
                sql += ", kouban2 ";
                sql += ", kouban3 ";
                sql += ", nouhinsyoKubun ";
                sql += ", bikou1 ";
                sql += ", bikou2 ";
                sql += ", kyakusakiChuban ";
                sql += ", flgMeisaiIkkatuSyuturyoku ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + denpyoNo + "' ";
                sql += "," + "'" + denpyoHizuke + "' ";
                sql += "," + "'" + juchuNoTop + "' ";
                sql += "," + "'" + juchuNoMid + "' ";
                sql += "," + "'" + juchuNoBtm + "' ";
                sql += "," + "'" + chihouCode + "' ";
                sql += "," + "'" + chikuCode + "' ";
                sql += "," + "'" + tokuisakiCode + "' ";
                sql += "," + "'" + tokuisakiName + "' ";
                sql += "," + "'" + tokuisakiKanaName + "' ";
                sql += "," + "'" + jigyousyoCode + "' ";
                sql += "," + "'" + jigyousyoName + "' ";
                sql += "," + "'" + tokuisakiTantousayName + "' ";
                sql += "," + "'" + zipCode + "' ";
                sql += "," + "'" + addres1 + "' ";
                sql += "," + "'" + addres2 + "' ";
                sql += "," + "'" + tantousyaCode + "' ";
                sql += "," + "'" + tantousyaName + "' ";
                sql += "," + "'" + kenmeiNo + "' ";
                sql += "," + "'" + kenmei1 + "' ";
                sql += "," + "'" + kenmei2 + "' ";
                sql += "," + "'" + chumonHizuke + "' ";
                sql += "," + "'" + shiteiDenpyoNo + "' ";
                sql += "," + (nouhinHizuke == null ? "NULL " : "'" + nouhinHizuke + "' ");
                sql += "," + "'" + kouban1 + "' ";
                sql += "," + "'" + kouban2 + "' ";
                sql += "," + "'" + kouban3 + "' ";
                sql += "," + "'" + nouhinsyoKubun + "' ";
                sql += "," + "'" + bikou1 + "' ";
                sql += "," + "'" + bikou2 + "' ";
                sql += "," + "'" + kyakusakiChuban + "' ";
                sql += "," + flgMeisaiIkkatuSyuturyoku + " ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 納品書ヘッダの更新SQL生成
                sql = "UPDATE uriage_header SET ";
                sql += "  denpyoNo = '" + denpyoNo + "' ";
                sql += ", denpyoHizuke = '" + denpyoHizuke + "' ";
                sql += ", juchuNoTop = '" + juchuNoTop + "' ";
                sql += ", juchuNoMid = '" + juchuNoMid + "' ";
                sql += ", juchuNoBtm = '" + juchuNoBtm + "' ";
                sql += ", chihouCode = '" + chihouCode + "' ";
                sql += ", chikuCode = '" + chikuCode + "' ";
                sql += ", tokuisakiCode = '" + tokuisakiCode + "' ";
                sql += ", tokuisakiName = '" + tokuisakiName + "' ";
                sql += ", tokuisakiKanaName = '" + tokuisakiKanaName + "' ";
                sql += ", jigyousyoCode = '" + jigyousyoCode + "' ";
                sql += ", jigyousyoName = '" + jigyousyoName + "' ";
                sql += ", tokuisakiTantousayName = '" + tokuisakiTantousayName + "' ";
                sql += ", zipCode = '" + zipCode + "' ";
                sql += ", addres1 = '" + addres1 + "' ";
                sql += ", addres2 = '" + addres2 + "' ";
                sql += ", tantousyaCode = '" + tantousyaCode + "' ";
                sql += ", tantousyaName = '" + tantousyaName + "' ";
                sql += ", kenmeiNo = '" + kenmeiNo + "' ";
                sql += ", kenmei1 = '" + kenmei1 + "' ";
                sql += ", kenmei2 = '" + kenmei2 + "' ";
                sql += ", chumonHizuke = '" + chumonHizuke + "' ";
                sql += ", shiteiDenpyoNo = '" + shiteiDenpyoNo + "' ";
                sql += ", nouhinHizuke = " + (nouhinHizuke == null ? "NULL " : "'" + nouhinHizuke + "' ");
                sql += ", kouban1 = '" + kouban1 + "' ";
                sql += ", kouban2 = '" + kouban2 + "' ";
                sql += ", kouban3 = '" + kouban3 + "' ";
                sql += ", nouhinsyoKubun = '" + nouhinsyoKubun + "' ";
                sql += ", bikou1 = '" + bikou1 + "' ";
                sql += ", bikou2 = '" + bikou2 + "' ";
                sql += ", kyakusakiChuban = '" + kyakusakiChuban + "' ";
                sql += ", flgMeisaiIkkatuSyuturyoku = " + flgMeisaiIkkatuSyuturyoku + " ";
                sql += ", kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '' ";
                sql += "WHERE denpyoNo = '" + denpyoNo + "' ";
            }
            else
            {
                // 納品書ヘッダの論理削除SQL生成
                sql = "UPDATE uriage_header SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE denpyoNo = '" + denpyoNo + "' ";
            }

            return sql;
        }
        #endregion

        #region 納品書ボディ登録・更新SQL生成処理
        /// <summary>
        /// 納品書ボディ登録・更新SQL生成処理
        /// </summary>
        /// <param name="denpyoNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createUriageBodyRegistSql(string denpyoNo, DateTime registerDate)
        {
            List<string> sqlBodys = new List<string>();
            string sql = string.Empty;
            string beforeDenpyoNo = txtDocumentNo.Text;

            if (rdoDelete.Checked)
            {
                // 納品書ボディの論理削除SQL生成
                sql = "UPDATE uriage_body SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE denpyoNo = '" + beforeDenpyoNo + "' ";
                sqlBodys.Add(sql);
            }
            else
            {
                // 納品書ボディの登録・更新SQL生成
                int rowNo = 0;
                int juchuRowNo = 0;
                int flgPrint = 0;
                string daiBunruiCode = string.Empty;
                string syoBunruiCode = string.Empty;
                string shouhinCode = string.Empty;
                string shouhinName1 = string.Empty;
                string shouhinName2 = string.Empty;
                string suryo = string.Empty;
                string tani = string.Empty;
                string tanka = string.Empty;
                string kingaku = string.Empty;
                string nouhinJoutai = string.Empty;
                string bikou = string.Empty;
                string seikyuHuragu = string.Empty;
                string selectCommand = string.Empty;
                DataTable selectRes;
                for (int i = 0; i < grdDeliveryDetails.Rows.Count; i++)
                {
                    if (checkEmptyRow(i))
                    {
                        i++;
                        continue;
                    }

                    juchuRowNo = Convert.ToInt16(grdDeliveryDetails.Rows[i + 1].Cells[clmOrderRowNo.Name].Value);
                    flgPrint = !Convert.ToBoolean(grdDeliveryDetails.Rows[i + 1].Cells[clmCheckPrint.Name].Value) ? 0 : 1;
                    daiBunruiCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                    syoBunruiCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmbtmClassificationCode.Name].Value);
                    shouhinCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmItemCode.Name].Value);
                    shouhinName1 = Convert.ToString(grdDeliveryDetails.Rows[i].Cells[clmItemName.Name].Value);
                    shouhinName2 = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmItemName.Name].Value);
                    suryo = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmQuantity.Name].Value);
                    nouhinJoutai = commonLogic.getNouhinsyoType(Convert.ToString(grdDeliveryDetails.Rows[i].Cells[clmDeliveryStatusAndUnit.Name].Value));
                    tani = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmDeliveryStatusAndUnit.Name].FormattedValue);
                    tanka = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmBid.Name].Value);
                    kingaku = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmAmount.Name].Value);
                    rowNo = ((int)(i / grdDeliveryDetails.RowSegmentCount) + 1);

                    selectCommand = "SELECT 1 FROM uriage_body ";
                    selectCommand += "WHERE denpyoNo = '" + beforeDenpyoNo + "' ";
                    selectCommand += "AND rowNo = " + rowNo;
                    selectRes = dataSelectDb.executeSelect(selectCommand, false);
                    if (selectRes != null && selectRes.Rows.Count > 0)
                    {
                        // 同一行番号のデータが登録済みのため更新処理
                        sql = "UPDATE uriage_body SET ";
                        sql += "  denpyoNo = " + "'" + denpyoNo + "' ";
                        sql += ", rowNo = " + rowNo + " ";
                        sql += ", juchuRowNo = " + juchuRowNo + " ";
                        sql += ", flgPrint = " + flgPrint + " ";
                        sql += ", daiBunruiCode = " + "'" + daiBunruiCode + "' ";
                        sql += ", syoBunruiCode = " + "'" + syoBunruiCode + "' ";
                        sql += ", shouhinCode = " + "'" + shouhinCode + "' ";
                        sql += ", shouhinName1 = " + "'" + shouhinName1 + "' ";
                        sql += ", shouhinName2 = " + "'" + shouhinName2 + "' ";
                        sql += ", suryo = " + (string.IsNullOrEmpty(suryo) ? "null" : Convert.ToDecimal(suryo).ToString()) + " ";
                        sql += ", tani = " + "'" + tani + "' ";
                        sql += ", tanka = " + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                        sql += ", kingaku = " + (string.IsNullOrEmpty(kingaku) ? "null" : Convert.ToDecimal(kingaku).ToString()) + " ";
                        sql += ", nouhinJoutai = " + "'" + nouhinJoutai + "' ";
                        sql += ", bikou = " + "'" + bikou + "' ";
                        //sql += ", seikyuHizuke = " + "'" + seikyuHizuke + "' ";
                        //sql += ", seikyuHuragu = " + "'" + seikyuHuragu + "' ";
                        sql += ", kousinNichizi = '" + registerDate + "' ";
                        sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE0 + "' ";
                        sql += "WHERE denpyoNo = '" + beforeDenpyoNo + "' ";
                        sql += "AND rowNo = " + rowNo;
                    }
                    else
                    {
                        // 同一行番号のデータが未登録のため登録処理
                        sql = "INSERT INTO uriage_body ";
                        sql += "( ";
                        sql += "  denpyoNo ";
                        sql += ", rowNo ";
                        sql += ", juchuRowNo ";
                        sql += ", flgPrint ";
                        sql += ", daiBunruiCode ";
                        sql += ", syoBunruiCode ";
                        sql += ", shouhinCode ";
                        sql += ", shouhinName1 ";
                        sql += ", shouhinName2 ";
                        sql += ", suryo ";
                        sql += ", tani ";
                        sql += ", tanka ";
                        sql += ", kingaku ";
                        sql += ", nouhinJoutai ";
                        sql += ", bikou ";
                        //sql += ", seikyuHizuke ";
                        //sql += ", seikyuHuragu ";
                        sql += ", kousinNichizi ";
                        sql += ", kanriKubun ";
                        sql += ") ";
                        sql += "VALUES ";
                        sql += "( ";
                        sql += "'" + denpyoNo + "' ";
                        sql += "," + rowNo + " ";
                        sql += "," + juchuRowNo + " ";
                        sql += "," + flgPrint + " ";
                        sql += "," + "'" + daiBunruiCode + "' ";
                        sql += "," + "'" + syoBunruiCode + "' ";
                        sql += "," + "'" + shouhinCode + "' ";
                        sql += "," + "'" + shouhinName1 + "' ";
                        sql += "," + "'" + shouhinName2 + "' ";
                        sql += "," + (string.IsNullOrEmpty(suryo) ? "null" : Convert.ToDecimal(suryo).ToString()) + " ";
                        sql += "," + "'" + tani + "' ";
                        sql += "," + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(kingaku) ? "null" : Convert.ToDecimal(kingaku).ToString()) + " ";
                        sql += "," + "'" + nouhinJoutai + "' ";
                        sql += "," + "'" + bikou + "' ";
                        //sql += "," + "'" + seikyuHizuke + "' ";
                        //sql += "," + "'" + seikyuHuragu + "' ";
                        sql += "," + "'" + registerDate + "' ";
                        sql += "," + "'' ";
                        sql += ") ";
                    }
                    sqlBodys.Add(sql);

                    i++;
                }

                // 今回登録以外のデータを削除
                sql = "DELETE FROM uriage_body ";
                sql += "WHERE denpyoNo = '" + beforeDenpyoNo + "' ";
                sql += "AND rowNo > " + rowNo;

                sqlBodys.Add(sql);
            }

            return sqlBodys;
        }
        #endregion

        #region 納品書フッタ登録・更新SQL生成処理
        /// <summary>
        /// 納品書フッタ登録・更新SQL生成処理
        /// </summary>
        /// <param name="denpyoNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createUriageFooterRegistSql(string denpyoNo, DateTime registerDate)
        {
            string sql = string.Empty;

            if (rdoDelete.Checked)
            {
                // 納品書フッタの論理削除SQL生成
                sql = "UPDATE uriage_footer SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE denpyoNo = '" + denpyoNo + "' ";
            }
            else
            {
                string tokuisakiCode = txtCustomerCode.Text;
                string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
                DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
                List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = tokuisakiMaster.getTokuisakiInfo(tokuisakiCode, jigyousyoCode);
                string strUriageKingaku = string.Empty;
                decimal uriageKingaku = decimal.Zero;
                string wkShouhizei = string.Empty;
                decimal shouhizei = decimal.Zero;

                strUriageKingaku = Convert.ToString(grdDeliveryTotalDetails.Rows[0].Cells[clmTotalAmount.Name].Value);
                decimal.TryParse(strUriageKingaku, out uriageKingaku);

                if (tokuisakiInfos[0].NouhinsyoSyohizeiKubun == "1")
                {
                    shouhizei = commonLogic.TokuisakiRoundKingaku(tokuisakiCode, (uriageKingaku * kanriMaster.getNowZeiritu() / 100));
                    wkShouhizei = Convert.ToString(shouhizei);
                }

                if (rdoNew.Checked)
                {
                    // 納品書フッタの登録SQL生成
                    sql += "INSERT INTO uriage_footer ";
                    sql += "( ";
                    sql += "  denpyoNo ";
                    sql += ", uriageKingaku ";
                    sql += ", syouhizei ";
                    sql += ", kousinNichizi ";
                    sql += ", kanriKubun ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "'" + denpyoNo + "' ";
                    sql += "," + (string.IsNullOrEmpty(strUriageKingaku) ? "null" : Convert.ToDecimal(strUriageKingaku).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(wkShouhizei) ? "null" : Convert.ToDecimal(shouhizei).ToString()) + " ";
                    sql += "," + "'" + registerDate + "' ";
                    sql += "," + "'' ";
                    sql += ") ";
                }
                else
                {
                    // 納品書フッタの更新SQL生成
                    sql = "UPDATE uriage_footer SET ";
                    sql += "  denpyoNo = '" + denpyoNo + "' ";
                    sql += ", uriageKingaku = " + (string.IsNullOrEmpty(strUriageKingaku) ? "null" : Convert.ToDecimal(strUriageKingaku).ToString()) + " ";
                    sql += ", syouhizei = " + (string.IsNullOrEmpty(wkShouhizei) ? "null" : Convert.ToDecimal(shouhizei).ToString()) + " ";
                    sql += ", kousinNichizi = '" + registerDate + "' ";
                    sql += ", kanriKubun = '' ";
                    sql += "WHERE denpyoNo = '" + denpyoNo + "' ";
                }
            }

            return sql;
        }
        #endregion

        #region 仕入データ登録・更新SQL生成処理
        /// <summary>
        /// 仕入データ登録・更新SQL生成処理
        /// </summary>
        /// <param name="denpyoNo"></param>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <param name="maxShireNo"></param>
        /// <returns></returns>
        private Dictionary<string, ShireRegistClass> createShireRegistSql(string uriageDenpyoNo, string juchuNo, DateTime registerDate, ref string maxShireNo)
        {
            string sql = string.Empty;
            DateTime denpyoHizuke = commonLogic.convertDateTime(txtDocumentDateYears.Text, txtDocumentDateMonth.Text, txtDocumentDateDays.Text);
            string shireNo;
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            string chihouCode = string.Empty;
            string chikuCode = string.Empty;
            string tokuisakiCode = txtCustomerCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string jigyousyoName = cmbOffices.Text;
            string zipCode = string.Empty;
            string addres1 = string.Empty;
            string addres2 = string.Empty;
            string tantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);
            string tantousyaName = cmbPersonnel.Text;
            string kenmeiNo = txtSubjectNo.Text;
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;
            Dictionary<string, ShireRegistClass> dicShireRegistList = new Dictionary<string, ShireRegistClass>();
            string daiBunruiCode;
            string syoBunruiCode;
            string shouhinCode;
            string shouhinName1;
            string shouhinName2;
            string suryo;
            string tani;
            string tanka;
            string kingaku;
            string bikou;
            decimal s;
            decimal b;
            decimal a;
            decimal totals;
            decimal totalb;
            decimal totala;
            DBTokuisakiMaster dBTokuisaki = new DBTokuisakiMaster();
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = dBTokuisaki.getTokuisakiInfo(tokuisakiCode, jigyousyoCode);
            if (tokuisakiInfos != null && tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
                zipCode = tokuisakiInfos[0].ZipCode;
                addres1 = tokuisakiInfos[0].Address1;
                addres2 = tokuisakiInfos[0].Address2;
            }

            sql = "SELECT 1 FROM shire_header ";
            sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
            sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
            sql += "AND IFNULL(uriageDenpyoNo, '') <> '' ";
            sql += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";

            DBCommon db = new DBCommon();
            DataTable shireDt = db.executeNoneLockSelect(sql);
            if (shireDt != null && shireDt.Rows.Count > 0) { return dicShireRegistList; }

            if (rdoNew.Checked)
            {
                List<string> venderList = new List<string>();
                string hachuNo;
                string shiresakiCode;
                string shiresakiName;
                ShireRegistClass wkShireRegistClass;
                decimal registShireSuryo;
                decimal registShireTanka;
                decimal registShireKingaku;
                int juchuRowNo;
                for (int i = 0; i < grdDeliveryDetails.Rows.Count; i++)
                {
                    if (i % grdDeliveryDetails.RowSegmentCount != 0) continue;
                    hachuNo = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmOrderNo.Name].Value);
                    shiresakiCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmVenderCode.Name].Value);
                    shiresakiName = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmVenderName.Name].Value);
                    juchuRowNo = Convert.ToInt16(grdDeliveryDetails.Rows[i + 1].Cells[clmOrderRowNo.Name].Value);
                    if (string.IsNullOrEmpty(shiresakiCode)) continue;
                    if (!venderList.Contains(shiresakiCode))
                    {
                        // 仕入No採番
                        shireNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getShireNo() + venderList.Count + 1).ToString(), 8);
                        maxShireNo = shireNo;
                        wkShireRegistClass = new ShireRegistClass();
                        wkShireRegistClass.ShireNo = shireNo;
                        // ヘッダSQLの設定
                        sql = "INSERT INTO shire_header ";
                        sql += "( ";
                        sql += "  shireNo ";
                        sql += ", denpyoHizuke ";
                        sql += ", juchuNoTop ";
                        sql += ", juchuNoMid ";
                        sql += ", juchuNoBtm ";
                        sql += ", chihouCode ";
                        sql += ", chikuCode ";
                        sql += ", tokuisakiCode ";
                        sql += ", tokuisakiName ";
                        sql += ", tokuisakiKanaName ";
                        sql += ", jigyousyoCode ";
                        sql += ", jigyousyoName ";
                        sql += ", zipCode ";
                        sql += ", addres1 ";
                        sql += ", addres2 ";
                        sql += ", tantousyaCode ";
                        sql += ", tantousyaName ";
                        sql += ", kenmeiNo ";
                        sql += ", kenmei1 ";
                        sql += ", kenmei2 ";
                        sql += ", hachuNo ";
                        sql += ", shiresakiCode ";
                        sql += ", shiresakiName ";
                        sql += ", uriageDenpyoNo ";
                        sql += ", kousinNichizi ";
                        sql += ", kanriKubun ";
                        sql += ") ";
                        sql += "VALUES ";
                        sql += "( ";
                        sql += "'" + shireNo + "' ";
                        sql += "," + "'" + denpyoHizuke + "' ";
                        sql += "," + "'" + juchuNoTop + "' ";
                        sql += "," + "'" + juchuNoMid + "' ";
                        sql += "," + "'" + juchuNoBtm + "' ";
                        sql += "," + "'" + chihouCode + "' ";
                        sql += "," + "'" + chikuCode + "' ";
                        sql += "," + "'" + tokuisakiCode + "' ";
                        sql += "," + "'" + tokuisakiName + "' ";
                        sql += "," + "'" + tokuisakiKanaName + "' ";
                        sql += "," + "'" + jigyousyoCode + "' ";
                        sql += "," + "'" + jigyousyoName + "' ";
                        sql += "," + "'" + zipCode + "' ";
                        sql += "," + "'" + addres1 + "' ";
                        sql += "," + "'" + addres2 + "' ";
                        sql += "," + "'" + tantousyaCode + "' ";
                        sql += "," + "'" + tantousyaName + "' ";
                        sql += "," + "'" + kenmeiNo + "' ";
                        sql += "," + "'" + kenmei1 + "' ";
                        sql += "," + "'" + kenmei2 + "' ";
                        sql += "," + "'" + hachuNo + "' ";
                        sql += "," + "'" + shiresakiCode + "' ";
                        sql += "," + "'" + shiresakiName + "' ";
                        sql += "," + "'" + uriageDenpyoNo + "' ";
                        sql += "," + "'" + registerDate + "' ";
                        sql += "," + "'' ";
                        sql += ") ";
                        wkShireRegistClass.HeaderSql = sql;
                        dicShireRegistList.Add(shiresakiCode, wkShireRegistClass);
                        venderList.Add(shiresakiCode);
                    }
                    else
                    {
                        shireNo = dicShireRegistList[shiresakiCode].ShireNo;
                    }

                    // 受注ボディに存在しない明細は仕入ボディに登録しない
                    if (juchuRowNo == 0) continue;
                    daiBunruiCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                    syoBunruiCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmbtmClassificationCode.Name].Value);
                    shouhinCode = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmItemCode.Name].Value);
                    shouhinName1 = Convert.ToString(grdDeliveryDetails.Rows[i].Cells[clmItemName.Name].Value);
                    shouhinName2 = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmItemName.Name].Value);
                    suryo = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmVenderQuantity.Name].Value);
                    tani = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmDeliveryStatusAndUnit.Name].FormattedValue);
                    tanka = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmVenderBid.Name].Value);
                    kingaku = Convert.ToString(grdDeliveryDetails.Rows[i + 1].Cells[clmVenderAmount.Name].Value);
                    bikou = string.Empty;

                    // 登録用仕入数量算出処理実行
                    //registShireSuryo = calcRegistShireSuryo(juchuRowNo, suryo);
                    if (string.IsNullOrEmpty(suryo))
                    {
                        registShireSuryo = decimal.Zero;
                    }
                    else
                    {
                        registShireSuryo = Convert.ToDecimal(suryo);
                    }

                    decimal.TryParse(tanka, out registShireTanka);
                    // 登録用仕入数量が0の場合、仕入ボディデータの登録は行わない
                    if (registShireSuryo == decimal.Zero)
                    {
                        if (!string.IsNullOrEmpty(kingaku) && Convert.ToDecimal(kingaku) != decimal.Zero)
                        {
                            registShireKingaku = Convert.ToDecimal(kingaku);
                        }
                        else
                        {
                            registShireKingaku = decimal.Zero;
                        }
                    }
                    else
                    {
                        registShireKingaku = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, registShireSuryo * registShireTanka);
                    }

                    // ボディSQLの設定
                    sql = "INSERT INTO shire_body ";
                    sql += "( ";
                    sql += "  shireNo ";
                    sql += ", rowNo ";
                    sql += ", juchuRowNo ";
                    sql += ", daiBunruiCode ";
                    sql += ", syoBunruiCode ";
                    sql += ", shouhinCode ";
                    sql += ", shouhinName1 ";
                    sql += ", shouhinName2 ";
                    sql += ", suryo ";
                    sql += ", tani ";
                    sql += ", tanka ";
                    sql += ", kingaku ";
                    sql += ", bikou ";
                    sql += ", kousinNichizi ";
                    sql += ", kanriKubun ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "'" + shireNo + "' ";
                    sql += "," + "'" + (dicShireRegistList[shiresakiCode].BodySqlList.Count + 1) + "' ";
                    sql += "," + "'" + juchuRowNo + "' ";
                    sql += "," + "'" + daiBunruiCode + "' ";
                    sql += "," + "'" + syoBunruiCode + "' ";
                    sql += "," + "'" + shouhinCode + "' ";
                    sql += "," + "'" + shouhinName1 + "' ";
                    sql += "," + "'" + shouhinName2 + "' ";
                    sql += "," + registShireSuryo.ToString();
                    sql += "," + "'" + tani + "' ";
                    sql += "," + registShireTanka.ToString();
                    sql += "," + registShireKingaku.ToString();
                    sql += "," + "'" + bikou + "' ";
                    sql += "," + "'" + registerDate + "' ";
                    sql += "," + "'' ";
                    sql += ") ";
                    dicShireRegistList[shiresakiCode].BodySqlList.Add(sql);

                    if (decimal.TryParse(suryo, out s))
                    {
                        decimal.TryParse(dicShireRegistList[shiresakiCode].Suryo, out totals);
                        dicShireRegistList[shiresakiCode].Suryo = Convert.ToString(s + totals);
                    }
                    if (decimal.TryParse(tanka, out b))
                    {
                        decimal.TryParse(dicShireRegistList[shiresakiCode].Tanka, out totalb);
                        dicShireRegistList[shiresakiCode].Tanka = Convert.ToString(b + totalb);
                    }
                    if (decimal.TryParse(kingaku, out a))
                    {
                        decimal.TryParse(dicShireRegistList[shiresakiCode].Kingaku, out totala);
                        dicShireRegistList[shiresakiCode].Kingaku = Convert.ToString(a + totala);
                    }
                }

                // フッタSQLの設定
                foreach (KeyValuePair<string, ShireRegistClass> pair in dicShireRegistList)
                {
                    pair.Value.FooterSql = "INSERT INTO shire_footer ";
                    pair.Value.FooterSql += "( ";
                    pair.Value.FooterSql += "  shireNo ";
                    pair.Value.FooterSql += ", shireKingaku ";
                    pair.Value.FooterSql += ", kousinNichizi ";
                    pair.Value.FooterSql += ", kanriKubun ";
                    pair.Value.FooterSql += ") ";
                    pair.Value.FooterSql += "VALUES ";
                    pair.Value.FooterSql += "( ";
                    pair.Value.FooterSql += "'" + pair.Value.ShireNo + "' ";
                    pair.Value.FooterSql += "," + (string.IsNullOrEmpty(pair.Value.Kingaku) ? "null" : Convert.ToDecimal(pair.Value.Kingaku).ToString());
                    pair.Value.FooterSql += "," + "'" + registerDate + "' ";
                    pair.Value.FooterSql += "," + "'' ";
                    pair.Value.FooterSql += ") ";
                }

            }
            //else if (rdoCorrection.Checked)
            //{
            //    sql = "SELECT shireNo FROM shire_header ";
            //    sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            //    sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
            //    sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
            //    sql += "AND uriageDenpyoNo = '" + uriageDenpyoNo + "' ";
            //    DataTable dt = dataSelectDb.executeSelect(sql, true);
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        shireNo = Convert.ToString(dt.Rows[0][DBFileLayout.ShireHeaderFile.dcShireNo]);
            //        ShireRegistClass wkShireRegistClass = new ShireRegistClass();
            //        // ヘッダSQLの設定
            //        wkShireRegistClass.HeaderSql = "UPDATE shire_header SET ";
            //        wkShireRegistClass.HeaderSql += "  uriageDenpyoNo = '" + uriageDenpyoNo + "' ";
            //        wkShireRegistClass.HeaderSql += ", kousinNichizi = '" + registerDate + "' ";
            //        wkShireRegistClass.HeaderSql += "WHERE shireNo = '" + shireNo + "' ";

            //        dicShireRegistList.Add("ALL", wkShireRegistClass);
            //    }
            //}
            else if(rdoDelete.Checked)
            {
                sql = "SELECT shireNo FROM shire_header ";
                sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                sql += "AND uriageDenpyoNo = '" + uriageDenpyoNo + "' ";
                DataTable dt = dataSelectDb.executeSelect(sql, true);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;
                    ShireRegistClass wkShireRegistClass;
                    foreach (DataRow shireHeaderRow in dt.Rows)
                    {
                        count++;
                        shireNo = Convert.ToString(shireHeaderRow[DBFileLayout.ShireHeaderFile.dcShireNo]);
                        wkShireRegistClass = new ShireRegistClass();
                        // ヘッダSQLの設定
                        wkShireRegistClass.HeaderSql = "UPDATE shire_header SET ";
                        wkShireRegistClass.HeaderSql += "  kousinNichizi = '" + registerDate + "' ";
                        wkShireRegistClass.HeaderSql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                        wkShireRegistClass.HeaderSql += "WHERE shireNo = '" + shireNo + "' ";
                        // ボディSQLの設定
                        sql = "UPDATE shire_body SET ";
                        sql += "  kousinNichizi = '" + registerDate + "' ";
                        sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                        sql += "WHERE shireNo = '" + shireNo + "' ";
                        wkShireRegistClass.BodySqlList.Add(sql);
                        // フッタSQLの設定
                        wkShireRegistClass.FooterSql = "UPDATE shire_footer SET ";
                        wkShireRegistClass.FooterSql += "  kousinNichizi = '" + registerDate + "' ";
                        wkShireRegistClass.FooterSql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                        wkShireRegistClass.FooterSql += "WHERE shireNo = '" + shireNo + "' ";

                        dicShireRegistList.Add("ALL" + count, wkShireRegistClass);
                    }
                }
            }

            return dicShireRegistList;
        }
        #endregion

        #region 登録用仕入数量算出処理
        /// <summary>
        /// 登録用仕入数量算出処理
        /// </summary>
        /// <param name="juchuRowNo"></param>
        /// <param name="nowSuryo"></param>
        /// <returns></returns>
        private decimal calcRegistShireSuryo(int juchuRowNo, string nowSuryo)
        {
            decimal ret = decimal.Zero;
            decimal suryo;
            decimal totalNouhinSuryo = decimal.Zero;
            decimal totalShireSuryo = decimal.Zero;
            decimal.TryParse(Convert.ToString(nowSuryo), out suryo);

            // 今回数量が未入力または0の場合
            if (suryo == decimal.Zero) return ret;

            // 対象行の納品数量合計および仕入数量合計を取得
            foreach (DBFileLayout.JuchuBodyFile bodyInfo in dataSelectDb.SelectJuchuData.BodyDatas)
            {
                if (bodyInfo.RowNo != juchuRowNo) continue;
                decimal.TryParse(Convert.ToString(bodyInfo.TotalNouhinSuryo), out totalNouhinSuryo);
                decimal.TryParse(Convert.ToString(bodyInfo.TotalShireSuryo), out totalShireSuryo);
                break;
            }

            ret = totalNouhinSuryo - totalShireSuryo + suryo;
            if (ret < 0) ret = decimal.Zero;

            return ret;
        }
        #endregion

        #region 受注ボディ更新SQL生成処理
        /// <summary>
        /// 受注ボディ更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createJuchuBodyUpdateSql(DateTime registerDate)
        {
            string sql = string.Empty;
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(txtOrderNo.Text, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            sql += "UPDATE juchu_body jb " + " \r ";
            sql += "LEFT JOIN(SELECT uh.juchuNoTop " + " \r ";
            sql += "               , uh.juchuNoMid " + " \r ";
            sql += "               , uh.juchuNoBtm " + " \r ";
            sql += "               , ub.juchuRowNo " + " \r ";
            sql += "               , SUM(IFNULL(suryo, 0)) AS uriageSuryo " + " \r ";
            sql += "          FROM( " + " \r ";
            sql += "                SELECT * " + " \r ";
            sql += "                FROM uriage_header " + " \r ";
            sql += "                WHERE juchuNoTop = '" + juchuNoTop + "' " + " \r ";
            sql += "                AND juchuNoMid = '" + juchuNoMid + "' " + " \r ";
            sql += "                AND juchuNoBtm = '" + juchuNoBtm + "' " + " \r ";
            sql += "                AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "' " + " \r ";
            sql += "               ) uh " + " \r ";
            sql += "          INNER JOIN( " + " \r ";
            sql += "                      SELECT * " + " \r ";
            sql += "                      FROM uriage_body " + " \r ";
            sql += "                    ) ub " + " \r ";
            sql += "          ON(uh.denpyoNo = ub.denpyoNo) " + " \r ";
            sql += "          GROUP BY uh.juchuNoTop " + " \r ";
            sql += "                 , uh.juchuNoMid " + " \r ";
            sql += "                 , uh.juchuNoBtm " + " \r ";
            sql += "                 , ub.juchuRowNo " + " \r ";
            sql += "          ) us " + " \r ";
            sql += "ON(jb.juchuNoTop = us.juchuNoTop " + " \r ";
            sql += "AND jb.juchuNoMid = us.juchuNoMid " + " \r ";
            sql += "AND jb.juchuNoBtm = us.juchuNoBtm " + " \r ";
            sql += "AND jb.rowNo = us.juchuRowNo) " + " \r ";
            sql += "SET jb.juchuNouhinZanSuryo = jb.juchuSuryo - us.uriageSuryo " + " \r ";
            sql += "  , jb.juchuNouhinSuryo = us.uriageSuryo " + " \r ";
            sql += "  , jb.shireNouhinZanSuryo = 0 " + " \r ";
            sql += "  , jb.shireNouhinSuryo = jb.juchuSuryo " + " \r ";
            sql += "  , jb.kousinNichizi = '" + registerDate + "' " + " \r ";
            sql += "WHERE jb.juchuNoTop = '" + juchuNoTop + "' " + " \r ";
            sql += "AND jb.juchuNoMid = '" + juchuNoMid + "' " + " \r ";
            sql += "AND jb.juchuNoBtm = '" + juchuNoBtm + "' " + " \r ";


            //sql += "UPDATE (SELECT * FROM juchu_body WHERE juchuNoTop = '" + juchuNoTop + "' AND juchuNoMid = '" + juchuNoMid + "' AND juchuNoBtm = '" + juchuNoBtm + "') jb " + " \r ";
            //sql += ", (SELECT uh.juchuNoTop " + " \r ";
            //sql += "        , uh.juchuNoMid " + " \r ";
            //sql += "        , uh.juchuNoBtm " + " \r ";
            //sql += "        , ub.juchuRowNo " + " \r ";
            //sql += "        , SUM(IFNULL(suryo, 0)) AS uriageSuryo " + " \r ";
            //sql += "   FROM( " + " \r ";
            //sql += "         SELECT * " + " \r ";
            //sql += "         FROM uriage_header " + " \r ";
            //sql += "         WHERE juchuNoTop = '" + juchuNoTop + "' " + " \r ";
            //sql += "         AND juchuNoMid = '" + juchuNoMid + "' " + " \r ";
            //sql += "         AND juchuNoBtm = '" + juchuNoBtm + "' " + " \r ";
            //sql += "         AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "' " + " \r ";
            //sql += "       ) uh " + " \r ";
            //sql += "   INNER JOIN( " + " \r ";
            //sql += "               SELECT * " + " \r ";
            //sql += "               FROM uriage_body " + " \r ";
            //sql += "             ) ub " + " \r ";
            //sql += "   ON(uh.denpyoNo = ub.denpyoNo) " + " \r ";
            //sql += "   GROUP BY uh.juchuNoTop " + " \r ";
            //sql += "          , uh.juchuNoMid " + " \r ";
            //sql += "          , uh.juchuNoBtm " + " \r ";
            //sql += "          , ub.juchuRowNo " + " \r ";
            //sql += "   ) us " + " \r ";
            //sql += "SET jb.juchuNouhinZanSuryo = CASE WHEN jb.juchuSuryo - us.uriageSuryo < 0 THEN 0 ELSE jb.juchuSuryo - us.uriageSuryo END " + " \r ";
            //sql += "  , jb.juchuNouhinSuryo = us.uriageSuryo " + " \r ";
            //sql += "  , jb.kousinNichizi = '" + registerDate + "' " + " \r ";
            //sql += "WHERE jb.juchuNoTop = us.juchuNoTop " + " \r ";
            //sql += "AND   jb.juchuNoMid = us.juchuNoMid " + " \r ";
            //sql += "AND   jb.juchuNoBtm = us.juchuNoBtm " + " \r ";
            //sql += "AND   jb.rowNo = us.juchuRowNo " + " \r ";

            return sql;
        }
        #endregion

        #region 売上No更新SQL生成処理
        /// <summary>
        /// 売上No更新SQL生成処理
        /// </summary>
        /// <param name="uriageNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createUriageNoRegistSql(string uriageNo, DateTime registerDate)
        {
            string sql = string.Empty;

            sql = "UPDATE kanri_master SET ";
            sql += "  koumoku1 = '" + uriageNo + "' ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += "WHERE kanriCode = '" + Consts.KanriCodes.UriageNo + "' ";

            return sql;
        }
        #endregion

        #region 仕入No更新SQL生成処理
        /// <summary>
        /// 仕入No更新SQL生成処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createShireNoRegistSql(string shireNo, DateTime registerDate)
        {
            string sql = string.Empty;

            sql = "UPDATE kanri_master SET ";
            sql += "  koumoku1 = '" + shireNo + "' ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += "WHERE kanriCode = '" + Consts.KanriCodes.ShireNo + "' ";

            return sql;
        }
        #endregion

        #region 納品書区分ラジオボタン取得処理
        /// <summary>
        /// 納品書区分ラジオボタン取得処理
        /// </summary>
        /// <param name="nouhinsyoType"></param>
        /// <returns></returns>
        private RadioButton getNouhinsyoRadio(NouhinsyoType nouhinsyoType)
        {
            if (NouhinsyoType.Jisya.Equals(nouhinsyoType))
            {
                return rdoTheir;
            }
            else if (NouhinsyoType.Negurosu.Equals(nouhinsyoType))
            {
                return rdoNegurosu;
            }
            else if (NouhinsyoType.TouhokuDenki.Equals(nouhinsyoType))
            {
                return rdoTouhokuDenki;
            }
            else if (NouhinsyoType.Yuudensya.Equals(nouhinsyoType))
            {
                return rdoYuudennsya;
            }
            else if (NouhinsyoType.AsamiDenki.Equals(nouhinsyoType))
            {
                return rdoAsamiDenki;
            }
            else
            {
                return rdoKandenkou;
            }
        }
        #endregion

        #region 対象行への納品状況設定処理
        /// <summary>
        /// 対象行への納品状況設定処理
        /// </summary>
        /// <param name="gridRowIndex"></param>
        private void setNouhinJotai(int gridRowIndex)
        {
            int topRowindex = gridRowIndex % grdDeliveryDetails.RowSegmentCount == 0 ? gridRowIndex : gridRowIndex - 1;
            int btmRowindex = topRowindex + 1;

            string nouhinJokyo = string.Empty;
            decimal suryo = Convert.ToDecimal(grdDeliveryDetails.Rows[btmRowindex].Cells[clmQuantity.Name].Value);
            decimal juchuSuryo = Convert.ToDecimal(grdDeliveryDetails.Rows[btmRowindex].Cells[clmOrderQuantity.Name].Value);
            decimal nouhinzumiSuryo = Convert.ToDecimal(grdDeliveryDetails.Rows[btmRowindex].Cells[clmOrdersDeliveryQuantity.Name].Value);

            if (juchuSuryo == decimal.Zero)
            {
                nouhinJokyo = string.Empty;
            }
            else if (juchuSuryo <= suryo + nouhinzumiSuryo)
            {
                nouhinJokyo = Consts.DeliveryType.FinishDeliveryText;
            }
            else
            {
                nouhinJokyo = Consts.DeliveryType.NoneDeliveryText;
            }
            grdDeliveryDetails.Rows[topRowindex].Cells[clmDeliveryStatusAndUnit.Name].Value = nouhinJokyo;
        }
        #endregion

        #region 全行への納品状況設定処理
        /// <summary>
        /// 全行への納品状況設定処理
        /// </summary>
        private void setAllNouhinJotai()
        {
            for (int i = 0; i < grdDeliveryDetails.Rows.Count; i++)
            {
                // 対象行への納品状況設定処理実行
                setNouhinJotai(i);
                i++;
            }
        }
        #endregion

        #region 必須入力チェック処理
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;
            string errorItem = string.Empty;

            if (rdoCorrection.Checked && string.IsNullOrEmpty(txtDocumentNo.Text))
            {
                errorItem = lblDocumentNo.Text;
            }
            else if (string.IsNullOrEmpty(txtDocumentDateYears.Text) ||
                     string.IsNullOrEmpty(txtDocumentDateMonth.Text) ||
                     string.IsNullOrEmpty(txtDocumentDateDays.Text))
            {
                errorItem = lblDocumentDate.Text;
            }
            else if (string.IsNullOrEmpty(cmbPersonnel.Text))
            {
                errorItem = lblPersonnel.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                errorItem = lblCustomerCode.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                errorItem = lblCustomerName.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerKanaName.Text))
            {
                errorItem = lblCustomerKanaName.Text;
            }

            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 伝票番号の重複チェック
        /// <summary>
        /// 伝票番号の重複チェック
        /// </summary>
        /// <returns></returns>
        private bool checkExisitsDocumentNo()
        {
            bool ret = true;

            if(rdoReference.Checked || rdoDelete.Checked) return ret;

            if (string.IsNullOrEmpty((txtDocumentNo.Text))) return ret;

            int newDocumentNo = kanriMaster.getUriageNo() + 1;
            int documentNo = Convert.ToInt16(txtDocumentNo.Text);

            if (newDocumentNo > documentNo)
            {
                errorOK(string.Format(Messages.M0049, commonLogic.getZeroBuriedNumberText(Convert.ToString(newDocumentNo), txtDocumentNo.MaxLength)));
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType, DenpyoType denpyoType, string documentNo)
        {
            object dataSource = createNouhinsyoPrintData(printType, denpyoType, documentNo);
            frmPrintView printView = new frmPrintView();
            printView.Size = new Size(1375, 975);
            printView.StartPosition = FormStartPosition.CenterScreen;
            if (rdoTheir.Checked)
            {
                // 帳票データの設定
                rptNouhinsyo1.SetDataSource(dataSource);
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptNouhinsyo1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNouhinsyo1.PrintOptions.PaperOrientation)
                                                                         , rptNouhinsyo1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptNouhinsyo1.PrintToPrinter(printerSettings
                                                   , pageSettings
                                                   , false);

                    }
                }
                else
                {
                    printView.CrViewer.ReportSource = rptNouhinsyo1;
                    printView.ShowDialog();
                }
            }
            else if (rdoNegurosu.Checked)
            {
                // 帳票データの設定
                rptNohinshoNegurosu1.SetDataSource(dataSource);
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptNohinshoNegurosu1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNohinshoNegurosu1.PrintOptions.PaperOrientation)
                                                                         , "A5Rotated"
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptNohinshoNegurosu1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);

                    }
                }
                else
                {
                    printView.CrViewer.ReportSource = rptNohinshoNegurosu1;
                    printView.ShowDialog();
                }
            }
            else if (rdoTouhokuDenki.Checked)
            {
                // 帳票データの設定
                rptNouhinshoTohokudenki1.SetDataSource(dataSource);
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptNouhinshoTohokudenki1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNouhinshoTohokudenki1.PrintOptions.PaperOrientation)
                                                                         , "A5Rotated"
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptNouhinshoTohokudenki1.PrintToPrinter(printerSettings
                                                              , pageSettings
                                                              , false);

                    }
                }
                else
                {
                    printView.CrViewer.ReportSource = rptNouhinshoTohokudenki1;
                    printView.ShowDialog();
                }
            }
            else if (rdoKandenkou.Checked)
            {
                // 帳票データの設定
                rptNohinshoKandenko1.SetDataSource(dataSource);
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptNohinshoKandenko1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNohinshoKandenko1.PrintOptions.PaperOrientation)
                                                                         , "A5Rotated"
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptNohinshoKandenko1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);

                    }
                }
                else
                {
                    printView.CrViewer.ReportSource = rptNohinshoKandenko1;
                    printView.ShowDialog();
                }
            }
            else if (rdoAsamiDenki.Checked)
            {
                // 帳票データの設定
                rptNohinshoAsami1.SetDataSource(dataSource);
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptNohinshoAsami1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNohinshoAsami1.PrintOptions.PaperOrientation)
                                                                         , "A5Rotated"
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptNohinshoAsami1.PrintToPrinter(printerSettings
                                                       , pageSettings
                                                       , false);

                    }
                }
                else
                {
                    printView.CrViewer.ReportSource = rptNohinshoAsami1;
                    printView.ShowDialog();
                }
            }
            else if (rdoYuudennsya.Checked)
            {
                // 帳票データの設定
                rptNohinshoYudensha1.SetDataSource(dataSource);
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptNohinshoYudensha1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptNohinshoYudensha1.PrintOptions.PaperOrientation)
                                                                         , "A5Rotated"
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptNohinshoYudensha1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);

                    }
                }
                else
                {
                    printView.CrViewer.ReportSource = rptNohinshoYudensha1;
                    printView.ShowDialog();
                }
            }
        }
        #endregion

        #region 帳票出力データ生成処理
        /// <summary>
        /// 帳票出力データ生成処理
        /// </summary>
        /// <returns></returns>
        private object createNouhinsyoPrintData(PrintType printType, DenpyoType denpyoType, string documentNo)
        {
            #region 変数宣言
            DataTable masterDt;
            DataTable headDt;
            DataTable bodyDt;
            DataTable footDt;
            int pageRowCount = 6;
            #endregion

            string masterSql = "SELECT * FROM kaisya_master ";
            string headSql = string.Empty;
            headSql += "SELECT uh.denpyoNo ";
            headSql += "     , uh.denpyoHizuke ";
            headSql += "     , tm.zipCode ";
            headSql += "     , tm.address1 ";
            headSql += "     , tm.address2 ";
            headSql += "     , tm.tokuisakiCode ";
            headSql += "     , tm.tokuisakiName ";
            headSql += "     , tm.jigyousyoName ";
            headSql += "     , uh.bikou1 ";
            headSql += "     , uh.bikou2 ";
            headSql += "     , uh.kyakusakiChuban ";
            headSql += "     , uh.tokuisakiTantousayName ";
            headSql += "     , uh.kenmei1 ";
            headSql += "     , uh.kenmei2 ";
            headSql += "     , uh.flgMeisaiIkkatuSyuturyoku ";
            headSql += "     , mm.kubunName ";
            headSql += "     , uh.shiteiDenpyoNo ";
            headSql += "     , jh.denpyoHizuke AS juchuHizuke ";
            headSql += "     , uh.kouban1 ";
            headSql += "     , uh.kouban2 ";
            headSql += "     , uh.kouban3 ";
            headSql += "FROM uriage_header uh ";
            headSql += "LEFT JOIN(SELECT * FROM tokuisaki_master) tm ";
            headSql += "ON (uh.tokuisakiCode = tm.tokuisakiCode AND uh.jigyousyoCode = tm.jigyousyoCode) ";
            headSql += "LEFT JOIN (SELECT * FROM juchu_header) jh ";
            headSql += "ON (uh.juchuNoTop = jh.juchuNoTop AND uh.juchuNoMid = jh.juchuNoMid AND uh.juchuNoBtm = jh.juchuNoBtm) ";
            headSql += "INNER JOIN(SELECT * FROM meisyo_master WHERE meisyoCode = '006') mm ";
            headSql += "ON (tm.shimebi = mm.kubun) ";
            headSql += "WHERE uh.denpyoNo = '" + documentNo + "' ";

            string bodySql = "SELECT * FROM uriage_body WHERE denpyoNo = '" + documentNo + "' AND IFNULL(flgPrint, 0) = 1 ORDER BY rowNo ";
            string footSql = "SELECT * FROM uriage_footer WHERE denpyoNo = '" + documentNo + "' ";

            masterDt = dataSelectDb.executeNoneLockSelect(masterSql);
            headDt = dataSelectDb.executeNoneLockSelect(headSql);
            bodyDt = dataSelectDb.executeNoneLockSelect(bodySql);
            footDt = dataSelectDb.executeNoneLockSelect(footSql);

            string dennpyouNo = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcDenpyoNo]);
            DateTime denpyoHiduke = Convert.ToDateTime(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcDenpyoHizuke]);
            DateTime juchuHizuke = Convert.ToDateTime(headDt.Rows[0]["juchuHizuke"]);
            string nen = Convert.ToString(denpyoHiduke.Year);
            string tuki = Convert.ToString(denpyoHiduke.Month);
            string hi = Convert.ToString(denpyoHiduke.Day);
            string yubinNo = Convert.ToString(headDt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcZipCode]);
            string tokuisakiJyusyo1 = Convert.ToString(headDt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcAddress1]);
            string tokuisakijyusyo2 = Convert.ToString(headDt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcAddress2]);
            string tokuisakiCd = Convert.ToString(headDt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
            string tokuisakiNm = Convert.ToString(headDt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
            string jigyosyoNm = Convert.ToString(headDt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcJigyousyoName]);
            string kaisyaYubinNo = Convert.ToString(masterDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcZipCode]);
            string kaisyajyusyo = Convert.ToString(masterDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcAddress]);
            string syamei = Convert.ToString(masterDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcKaisyaName]);
            string kaisyaTel = Convert.ToString(masterDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcRenrakusaki1]);
            string kaisyaFax = Convert.ToString(masterDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcRenrakusaki2]);
            string bikou1 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcBikou1]);
            string bikou2 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcBikou2]);
            string bikou3 = string.Empty;
            string bikou4 = string.Empty;
            string kyakuCyumonNo = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcKyakusakiChuban]);
            string kyakuTantoNm = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcTokuisakiTantousayName]);
            string kenmei1 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcKenmei1]);
            string kenmei2 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcKenmei2]);
            string nonyuTuki = txtDeliveryDateMonth.Text;
            string nounyuBi = txtDeliveryDateDays.Text;
            int flgMeisaiIkkatuSyuturyoku = Convert.ToInt16(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcFlgMeisaiIkkatuSyuturyoku]);
            string shiteiDenpyoNo = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcShiteiDenpyoNo]);
            string kouban1 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcKouban1]);
            string kouban2 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcKouban2]);
            string kouban3 = Convert.ToString(headDt.Rows[0][DBFileLayout.UriageHeaderFile.dcKouban3]);
            DataRow headRow;
            int headRowIndex = 0;
            int bodyRowIndex = 0;
            int bodyRowCount = 0;
            int bodyRowNo = 0;
            string clmGyoNo1 = "gyoNo{0}";
            string clmHinmei11 = "hinmei{0}1";
            string clmHinmei12 = "hinmei{0}2";
            string clmSuryo1 = "suryo{0}";
            string clmTani1 = "tani{0}";
            string clmTanka1 = "tanka{0}";
            string clmKingaku1 = "kingaku{0}";
            string wkSuryo;
            string wkTanka;
            string wkKingaku;
            decimal suryo;
            decimal tanka;
            decimal kingaku;
            decimal totalKingaku = decimal.Zero;
            decimal totalShouhizei = decimal.Zero;
            decimal totalGoukei = decimal.Zero;
            if (!string.IsNullOrEmpty(Convert.ToString(footDt.Rows[0][DBFileLayout.UriageFooterFile.dcSyouhizei])))
            {
                totalShouhizei = Convert.ToDecimal(footDt.Rows[0][DBFileLayout.UriageFooterFile.dcSyouhizei]);
            }

            int addRowCount = 0;
            #region 自社納品書設定
            if (rdoTheir.Checked)
            {
                dtblNouhinsyo printData = new dtblNouhinsyo();
                if (flgMeisaiIkkatuSyuturyoku == 0)
                {
                    addRowCount = (int)(bodyDt.Rows.Count / pageRowCount);
                    if (bodyDt.Rows.Count % pageRowCount != 0) addRowCount++;
                }
                else
                {
                    addRowCount = 1;
                }
                for (int i = 0; i < addRowCount; i++)
                {
                    printData.Tables["dtblNouhinsyo1"].Rows.Add();
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["dennpyouNo"] = dennpyouNo;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["subTitle"] = DenpyoType.Provisional.Equals(denpyoType) ? "仮" : string.Empty;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["page"] = i + 1;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["nen"] = nen;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["tuki"] = tuki;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["hi"] = hi;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["yubinNo"] = yubinNo;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["tokuisakiJyusyo1"] = tokuisakiJyusyo1;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["tokuisakijyusyo2"] = tokuisakijyusyo2;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["tokuisakiNm"] = tokuisakiNm;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["jigyosyoNm"] = jigyosyoNm;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kaisyaYubinNo"] = kaisyaYubinNo;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kaisyajyusyo"] = kaisyajyusyo;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kaisyaTel"] = kaisyaTel;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kaisyaFax"] = kaisyaFax;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["bikou1"] = bikou1;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["bikou2"] = bikou2;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["bikou3"] = bikou3;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["bikou4"] = bikou4;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kyakuCyumonNo"] = kyakuCyumonNo;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kyakuTantoNm"] = kyakuTantoNm;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kenmei"] = kenmei1;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["kenmei2"] = kenmei2;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["nonyuTuki"] = nonyuTuki;
                    printData.Tables["dtblNouhinsyo1"].Rows[i]["nounyuBi"] = nounyuBi;
                }

                foreach (DataRow row in bodyDt.Rows)
                {
                    headRow = printData.Tables["dtblNouhinsyo1"].Rows[headRowIndex];
                    bodyRowCount++;
                    wkSuryo = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcSuryo]);
                    wkTanka = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcTanka]);
                    wkKingaku = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcKingaku]);

                    kingaku = decimal.Zero;
                    if (flgMeisaiIkkatuSyuturyoku == 0)
                    {
                        bodyRowNo++;
                        headRow[string.Format(clmGyoNo1, bodyRowNo)] = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcRowNo]);
                        headRow[string.Format(clmHinmei11, bodyRowNo)] = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcShouhinName1]);
                        headRow[string.Format(clmHinmei12, bodyRowNo)] = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcShouhinName2]);
                        if (decimal.TryParse(wkSuryo, out suryo)) headRow[string.Format(clmSuryo1, bodyRowNo)] = suryo.ToString("#,##0");
                        headRow[string.Format(clmTani1, bodyRowNo)] = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcTani]);
                        if (decimal.TryParse(wkTanka, out tanka)) headRow[string.Format(clmTanka1, bodyRowNo)] = tanka.ToString("#,##0");
                        if (decimal.TryParse(wkKingaku, out kingaku)) headRow[string.Format(clmKingaku1, bodyRowNo)] = kingaku.ToString("#,##0");
                    }
                    else
                    {
                        decimal.TryParse(wkKingaku, out kingaku);
                    }
                    totalKingaku += kingaku;

                    if (bodyRowNo == pageRowCount || bodyDt.Rows.Count == bodyRowCount)
                    {
                        if (flgMeisaiIkkatuSyuturyoku == 1)
                        {
                            bodyRowNo++;
                            DataRow topRow = bodyDt.Rows[0];
                            headRow[string.Format(clmGyoNo1, 1)] = Convert.ToString(topRow[DBFileLayout.UriageBodyFile.dcRowNo]);
                            headRow[string.Format(clmHinmei11, 1)] = Convert.ToString(topRow[DBFileLayout.UriageBodyFile.dcShouhinName1]);
                            headRow[string.Format(clmHinmei12, 1)] = Convert.ToString(topRow[DBFileLayout.UriageBodyFile.dcShouhinName2]);
                            headRow[string.Format(clmSuryo1, 1)] = decimal.One.ToString("#,##0");
                            headRow[string.Format(clmTani1, 1)] = Convert.ToString(row[DBFileLayout.UriageBodyFile.dcTani]);
                            headRow[string.Format(clmTanka1, 1)] = totalKingaku.ToString("#,##0");
                            headRow[string.Format(clmKingaku1, 1)] = totalKingaku.ToString("#,##0");
                        }
                        if (headRowIndex + 1 == addRowCount)
                        {
                            headRow["goukeiKingaku"] = totalKingaku.ToString("#,##0");
                        }
                        else
                        {
                            headRow["goukeiKingaku"] = "次ページへ";
                        }
                        headRowIndex++;
                        bodyRowNo = 0;
                    }
                }

                printData.Tables["dtblNouhinsyo2"].Merge(printData.Tables["dtblNouhinsyo1"].Copy());

                return printData;
            }
            #endregion
            #region ネグロス納品書設定
            else if (rdoNegurosu.Checked)
            {
                dtblNohinshoNegurosu printData = new dtblNohinshoNegurosu();
                pageRowCount = 8;
                if (flgMeisaiIkkatuSyuturyoku == 0)
                {
                    addRowCount = (int)(bodyDt.Rows.Count / pageRowCount);
                    if (bodyDt.Rows.Count % pageRowCount != 0) addRowCount++;
                }
                else
                {
                    addRowCount = 1;
                }
                for (int i = 0; i < addRowCount; i++)
                {
                    printData.Tables["dtblNohinshoNegurosu"].Rows.Add();
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["nen"] = nen;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["tuki"] = tuki;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["hi"] = hi;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["yubinNo"] = kaisyaYubinNo;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["jyusho"] = kaisyajyusyo;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["syamei"] = syamei;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["tel"] = kaisyaTel;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["fax"] = kaisyaFax;
                    printData.Tables["dtblNohinshoNegurosu"].Rows[i]["denNo"] = shiteiDenpyoNo;
                    if (!string.IsNullOrEmpty(jigyosyoNm + kyakuTantoNm))
                    {
                        printData.Tables["dtblNohinshoNegurosu"].Rows[i]["jigyousyoName"] = jigyosyoNm + " " + kyakuTantoNm + "様";
                    }
                }
                string strKingaku;
                string strTotalKingaku;
                int kingakuNo = 0;
                totalKingaku = decimal.Zero;
                for (int i = 0; i < bodyDt.Rows.Count; i++)
                {
                    headRowIndex = (int)(i / pageRowCount);
                    bodyRowIndex = (i % pageRowCount) + 1;
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcSuryo]), out suryo);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTanka]), out tanka);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcKingaku]), out kingaku);
                    strKingaku = kingaku.ToString();
                    totalKingaku += kingaku;
                    headRow = printData.Tables["dtblNohinshoNegurosu"].Rows[headRowIndex];
                    headRow["hinmei" + Convert.ToString(bodyRowIndex) + "1"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName1]);
                    headRow["hinmei" + Convert.ToString(bodyRowIndex) + "2"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName2]);
                    headRow["suryo" + Convert.ToString(bodyRowIndex) + ""] = suryo.ToString("#,##0");
                    headRow["tani" + Convert.ToString(bodyRowIndex) + ""] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTani]);
                    headRow["tanka" + Convert.ToString(bodyRowIndex) + ""] = tanka.ToString("#,##0");
                    kingakuNo = 8;
                    for (int j = strKingaku.Length - 1; j >= 0; j--)
                    {
                        headRow["kingaku" + Convert.ToString(bodyRowIndex) + Convert.ToString(kingakuNo)] = strKingaku[j];
                        kingakuNo--;
                    }
                    if (pageRowCount == (i + 1) || bodyDt.Rows.Count == (i + 1))
                    {
                        strTotalKingaku = totalKingaku.ToString();
                        kingakuNo = 8;
                        for (int j = strTotalKingaku.Length - 1; j >= 0; j--)
                        {
                            headRow["gokei" + Convert.ToString(kingakuNo)] = strTotalKingaku[j];
                            kingakuNo--;
                        }
                        totalKingaku = decimal.Zero;
                    }
                }

                return printData;
            }
            #endregion
            #region 東北電機納品書設定
            else if (rdoTouhokuDenki.Checked)
            {
                dtblNohinshoToHokudenki printData = new dtblNohinshoToHokudenki();
                pageRowCount = 5;
                if (flgMeisaiIkkatuSyuturyoku == 0)
                {
                    addRowCount = (int)(bodyDt.Rows.Count / pageRowCount);
                    if (bodyDt.Rows.Count % pageRowCount != 0) addRowCount++;
                }
                else
                {
                    addRowCount = 1;
                }
                for (int i = 0; i < addRowCount; i++)
                {
                    printData.Tables["dtblNohinshoTohokudenki"].Rows.Add();
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["nen"] = nen;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["tuki"] = tuki;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["hi"] = hi;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["yubinNo"] = kaisyaYubinNo;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["jyusho"] = kaisyajyusyo;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["syamei"] = syamei;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["kyakuCyumonNo"] = kyakuCyumonNo;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["kenmei"] = kenmei1;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["tel"] = kaisyaTel;
                    printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["fax"] = kaisyaFax;
                    if (!string.IsNullOrEmpty(jigyosyoNm + kyakuTantoNm))
                    {
                        printData.Tables["dtblNohinshoTohokudenki"].Rows[i]["kyakuCyumonNo"] = jigyosyoNm + " " + kyakuTantoNm + "様";
                    }
                }
                string strKingaku;
                string strTotalKingaku;
                int kingakuNo = 0;
                totalKingaku = decimal.Zero;
                for (int i = 0; i < bodyDt.Rows.Count; i++)
                {
                    headRowIndex = (int)(i / pageRowCount);
                    bodyRowIndex = (i % pageRowCount) + 1;
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcSuryo]), out suryo);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTanka]), out tanka);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcKingaku]), out kingaku);
                    strKingaku = kingaku.ToString();
                    totalKingaku += kingaku;
                    headRow = printData.Tables["dtblNohinshoTohokudenki"].Rows[headRowIndex];
                    headRow["hinmei" + Convert.ToString(bodyRowIndex) + "1"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName1]);
                    headRow["hinmei" + Convert.ToString(bodyRowIndex) + "2"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName2]);
                    headRow["suryo" + Convert.ToString(bodyRowIndex) + ""] = suryo.ToString("#,##0");
                    headRow["tani" + Convert.ToString(bodyRowIndex) + ""] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTani]);
                    headRow["tanka" + Convert.ToString(bodyRowIndex) + ""] = tanka.ToString("#,##0");
                    kingakuNo = 9;
                    for (int j = strKingaku.Length - 1; j >= 0; j--)
                    {
                        headRow["kingaku" + Convert.ToString(bodyRowIndex) + Convert.ToString(kingakuNo)] = strKingaku[j];
                        kingakuNo--;
                    }
                    if (pageRowCount == (i + 1) || bodyDt.Rows.Count == (i + 1))
                    {
                        strTotalKingaku = totalKingaku.ToString();
                        kingakuNo = 9;
                        for (int j = strTotalKingaku.Length - 1; j >= 0; j--)
                        {
                            headRow["kingakuG" + Convert.ToString(kingakuNo)] = strTotalKingaku[j];
                            kingakuNo--;
                        }
                        totalKingaku = decimal.Zero;
                    }
                }

                return printData;
            }
            #endregion
            #region 関電工納品書設定
            else if (rdoKandenkou.Checked)
            {
                dtblNohnshoKandenko printData = new dtblNohnshoKandenko();
                pageRowCount = 7;
                if (flgMeisaiIkkatuSyuturyoku == 0)
                {
                    addRowCount = (int)(bodyDt.Rows.Count / pageRowCount);
                    if (bodyDt.Rows.Count % pageRowCount != 0) addRowCount++;
                }
                else
                {
                    addRowCount = 1;
                }
                DateTime shimeDate;
                string shimeDay = Convert.ToString(headDt.Rows[0][DBFileLayout.MeisyoMasterFile.dcKubunName]);
                if (Consts.EndOfMonthText.Equals(shimeDay))
                {
                    shimeDate = Convert.ToDateTime(nen + "-" + tuki + "-" + commonLogic.GetEndOfMonth(nen, tuki));
                }
                else if (Consts.FromTimeToTimeText.Equals(shimeDay))
                {
                    shimeDate = Convert.ToDateTime(nen + "-" + tuki + "-" + hi);
                }
                else
                {
                    shimeDate = Convert.ToDateTime(nen + "-" + tuki + "-" + shimeDay);
                }
                if (denpyoHiduke > shimeDate) shimeDate = shimeDate.AddMonths(1);
                string kyakusakiCyumonNo1 = string.Empty;
                string kyakusakiCyumonNo2 = string.Empty;
                string kyakusakiCyumonNo3 = string.Empty;
                string kyakusakiCyumonNo4 = string.Empty;
                string kyakusakiCyumonNo5 = string.Empty;
                string kyakusakiCyumonNo6 = string.Empty;
                string kyakusakiCyumonNo7 = string.Empty;
                string kyakusakiCyumonNo8 = string.Empty;
                string kyakusakiCyumonNo9 = string.Empty;
                try
                {
                    kyakusakiCyumonNo1 = Convert.ToString(kyakuCyumonNo[0]);
                    kyakusakiCyumonNo2 = Convert.ToString(kyakuCyumonNo[1]);
                    kyakusakiCyumonNo3 = Convert.ToString(kyakuCyumonNo[2]);
                    kyakusakiCyumonNo4 = Convert.ToString(kyakuCyumonNo[3]);
                    kyakusakiCyumonNo5 = Convert.ToString(kyakuCyumonNo[4]);
                    kyakusakiCyumonNo6 = Convert.ToString(kyakuCyumonNo[5]);
                    kyakusakiCyumonNo7 = Convert.ToString(kyakuCyumonNo[6]);
                    kyakusakiCyumonNo8 = Convert.ToString(kyakuCyumonNo[7]);
                    kyakusakiCyumonNo9 = Convert.ToString(kyakuCyumonNo[8]);
                }
                catch
                {
                }
                string kouban11 = string.Empty;
                string kouban12 = string.Empty;
                string kouban21 = string.Empty;
                string kouban22 = string.Empty;
                string kouban23 = string.Empty;
                string kouban24 = string.Empty;
                string kouban25 = string.Empty;
                string kouban26 = string.Empty;
                string kouban31 = string.Empty;
                string kouban32 = string.Empty;
                string kouban33 = string.Empty;
                try
                {
                    kouban11 = Convert.ToString(kouban1[0]);
                    kouban12 = Convert.ToString(kouban1[1]);
                    kouban21 = Convert.ToString(kouban2[0]);
                    kouban22 = Convert.ToString(kouban2[1]);
                    kouban23 = Convert.ToString(kouban2[2]);
                    kouban24 = Convert.ToString(kouban2[3]);
                    kouban25 = Convert.ToString(kouban2[4]);
                    kouban26 = Convert.ToString(kouban2[5]);
                    kouban31 = Convert.ToString(kouban3[0]);
                    kouban32 = Convert.ToString(kouban3[1]);
                    kouban33 = Convert.ToString(kouban3[2]);
                }
                catch
                {
                }
                for (int i = 0; i < addRowCount; i++)
                {
                    printData.Tables["dtblNohinshoKandenko"].Rows.Add();

                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["simeNen"] = Convert.ToString(shimeDate.Year);
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["simeTuki"] = Convert.ToString(shimeDate.Month);
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["simeBi"] = Convert.ToString(shimeDate.Day);
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo1"] = kyakusakiCyumonNo1;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo2"] = kyakusakiCyumonNo2;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo3"] = kyakusakiCyumonNo3;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo4"] = kyakusakiCyumonNo4;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo5"] = kyakusakiCyumonNo5;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo6"] = kyakusakiCyumonNo6;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo7"] = kyakusakiCyumonNo7;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo8"] = kyakusakiCyumonNo8;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kyakusakiCyumonNo9"] = kyakusakiCyumonNo9;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["denpyoNen"] = Convert.ToString(juchuHizuke.Year);
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["denpyoTuki"] = Convert.ToString(juchuHizuke.Month);
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["denpyoHi"] = Convert.ToString(juchuHizuke.Day);
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kasyaYubin"] = kaisyaYubinNo;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kaisyaJyusho"] = kaisyajyusyo;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["syamei"] = syamei;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kenmei1"] = kenmei1;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kenmei2"] = kenmei2;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban1_1"] = kouban11;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban1_2"] = kouban12;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban2_1"] = kouban21;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban2_2"] = kouban22;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban2_3"] = kouban23;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban2_4"] = kouban24;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban2_5"] = kouban25;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban2_6"] = kouban26;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban3_1"] = kouban31;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban3_2"] = kouban32;
                    printData.Tables["dtblNohinshoKandenko"].Rows[i]["kouban3_3"] = kouban33;
                }
                string strKingaku;
                totalKingaku = decimal.Zero;
                decimal syouhiZei = decimal.Zero;
                for (int i = 0; i < bodyDt.Rows.Count; i++)
                {
                    headRowIndex = (int)(i / pageRowCount);
                    bodyRowIndex = (i % pageRowCount) + 1;
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcSuryo]), out suryo);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTanka]), out tanka);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcKingaku]), out kingaku);
                    strKingaku = kingaku.ToString();
                    totalKingaku += kingaku;
                    headRow = printData.Tables["dtblNohinshoKandenko"].Rows[headRowIndex];
                    headRow["hinmei" + Convert.ToString(bodyRowIndex) + "1"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName1]);
                    headRow["hinmei" + Convert.ToString(bodyRowIndex) + "2"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName2]);
                    headRow["suryo" + Convert.ToString(bodyRowIndex) + ""] = suryo.ToString("#,##0");
                    headRow["tani" + Convert.ToString(bodyRowIndex) + ""] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTani]);
                    headRow["tanka" + Convert.ToString(bodyRowIndex) + ""] = tanka.ToString("#,##0");
                    headRow["kingaku" + Convert.ToString(bodyRowIndex)] = kingaku.ToString("#,##0");
                    if (pageRowCount == (i + 1) || bodyDt.Rows.Count == (i + 1))
                    {
                        syouhiZei = commonLogic.TokuisakiRoundKingaku(tokuisakiCd, (totalKingaku * kanriMaster.getNowZeiritu() / 100));
                        headRow["seikyuKingaku"] = (totalKingaku + syouhiZei).ToString("#,##0");
                        headRow["syohizei"] = syouhiZei.ToString("#,##0");
                        headRow["kingakuG"] = totalKingaku.ToString("#,##0");
                        totalKingaku = decimal.Zero;
                    }
                }

                return printData;
            }
            #endregion
            #region 浅海電機納品書設定
            else if (rdoAsamiDenki.Checked)
            {
                dtblNohinshoAsami printData = new dtblNohinshoAsami();
                pageRowCount = 9;
                if (flgMeisaiIkkatuSyuturyoku == 0)
                {
                    addRowCount = (int)(bodyDt.Rows.Count / pageRowCount);
                    if (bodyDt.Rows.Count % pageRowCount != 0) addRowCount++;
                }
                else
                {
                    addRowCount = 1;
                }
                string shiteiDenpyoNo1 = string.Empty;
                string shiteiDenpyoNo2 = string.Empty;
                string shiteiDenpyoNo3 = string.Empty;
                string shiteiDenpyoNo4 = string.Empty;
                string shiteiDenpyoNo5 = string.Empty;
                try
                {
                    shiteiDenpyoNo1 = Convert.ToString(shiteiDenpyoNo[0]);
                    shiteiDenpyoNo2 = Convert.ToString(shiteiDenpyoNo[1]);
                    shiteiDenpyoNo3 = Convert.ToString(shiteiDenpyoNo[2]);
                    shiteiDenpyoNo4 = Convert.ToString(shiteiDenpyoNo[3]);
                    shiteiDenpyoNo5 = Convert.ToString(shiteiDenpyoNo[4]);
                }
                catch
                {
                }
                for (int i = 0; i < addRowCount; i++)
                {
                    printData.Tables["dtblNohinshoAsami"].Rows.Add();

                    printData.Tables["dtblNohinshoAsami"].Rows[i]["nen"] = nen;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["tuki"] = tuki;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["hi"] = hi;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["kojiNm1"] = kenmei1;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["kojiNm2"] = kenmei2;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["kaisyaNm"] = syamei;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["kaisyaJusho"] = kaisyajyusyo;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["denpyouNo1"] = shiteiDenpyoNo1;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["denpyouNo2"] = shiteiDenpyoNo2;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["denpyouNo3"] = shiteiDenpyoNo3;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["denpyouNo4"] = shiteiDenpyoNo4;
                    printData.Tables["dtblNohinshoAsami"].Rows[i]["denpyouNo5"] = shiteiDenpyoNo5;
                }
                string strKingaku;
                string strTotalKingaku;
                string strShouhizei;
                string strGoukei;
                totalKingaku = decimal.Zero;
                int kingakuNo = 0;
                for (int i = 0; i < bodyDt.Rows.Count; i++)
                {
                    headRowIndex = (int)(i / pageRowCount);
                    bodyRowIndex = (i % pageRowCount) + 1;
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcSuryo]), out suryo);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTanka]), out tanka);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcKingaku]), out kingaku);
                    strKingaku = kingaku.ToString();
                    totalKingaku += kingaku;
                    totalGoukei += kingaku;
                    headRow = printData.Tables["dtblNohinshoAsami"].Rows[headRowIndex];
                    headRow["shohinNm" + Convert.ToString(bodyRowIndex) + "1"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName1]);
                    headRow["shohinNm" + Convert.ToString(bodyRowIndex) + "2"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName2]);
                    headRow["suryo" + Convert.ToString(bodyRowIndex) + ""] = suryo.ToString("#,##0");
                    headRow["tani" + Convert.ToString(bodyRowIndex) + ""] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTani]);
                    headRow["tanka" + Convert.ToString(bodyRowIndex) + ""] = tanka.ToString("#,##0");
                    kingakuNo = 9;
                    for (int j = strKingaku.Length - 1; j >= 0; j--)
                    {
                        headRow["kingaku" + Convert.ToString(bodyRowIndex) + Convert.ToString(kingakuNo)] = strKingaku[j];
                        kingakuNo--;
                    }

                    //if (pageRowCount == (i + 1) || bodyDt.Rows.Count == (i + 1))
                    if (pageRowCount == (i + 1) && bodyDt.Rows.Count != (i + 1))
                    {
                        strTotalKingaku = totalKingaku.ToString();
                        kingakuNo = 9;
                        for (int j = strTotalKingaku.Length - 1; j >= 0; j--)
                        {
                            headRow["shokei" + Convert.ToString(kingakuNo)] = strTotalKingaku[j];
                            kingakuNo--;
                        }
                        totalKingaku = decimal.Zero;
                        headRow["gokei7"] = "次";
                        headRow["gokei8"] = "頁";
                        headRow["gokei9"] = "へ";
                    }
                    else if (bodyDt.Rows.Count == (i + 1))
                    {
                        strTotalKingaku = totalKingaku.ToString();
                        //totalShouhizei = commonLogic.TokuisakiRoundKingaku(tokuisakiCd, (totalKingaku * kanriMaster.getNowZeiritu() / 100));
                        totalGoukei += totalShouhizei;
                        strShouhizei = totalShouhizei.ToString();
                        kingakuNo = 9;
                        for (int j = strTotalKingaku.Length - 1; j >= 0; j--)
                        {
                            headRow["shokei" + Convert.ToString(kingakuNo)] = strTotalKingaku[j];
                            kingakuNo--;
                        }
                        kingakuNo = 9;
                        for (int j = strShouhizei.Length - 1; j >= 0; j--)
                        {
                            headRow["shohizei" + Convert.ToString(kingakuNo)] = strShouhizei[j];
                            kingakuNo--;
                        }
                        strGoukei = totalGoukei.ToString();
                        kingakuNo = 9;
                        for (int j = strGoukei.Length - 1; j >= 0; j--)
                        {
                            headRow["gokei" + Convert.ToString(kingakuNo)] = strGoukei[j];
                            kingakuNo--;
                        }
                        totalKingaku = decimal.Zero;
                    }
                }

                return printData;
            }
            #endregion
            #region 雄電社納品書設定
            else if (rdoYuudennsya.Checked)
            {
                dtblNohinshoYudensha printData = new dtblNohinshoYudensha();
                pageRowCount = 8;
                if (flgMeisaiIkkatuSyuturyoku == 0)
                {
                    addRowCount = (int)(bodyDt.Rows.Count / pageRowCount);
                    if (bodyDt.Rows.Count % pageRowCount != 0) addRowCount++;
                }
                else
                {
                    addRowCount = 1;
                }
                string kyakusakiCyumonNo1 = string.Empty;
                string kyakusakiCyumonNo2 = string.Empty;
                string kyakusakiCyumonNo3 = string.Empty;
                string kyakusakiCyumonNo4 = string.Empty;
                string kyakusakiCyumonNo5 = string.Empty;
                string kyakusakiCyumonNo6 = string.Empty;
                string kyakusakiCyumonNo7 = string.Empty;
                string kyakusakiCyumonNo8 = string.Empty;
                string kyakusakiCyumonNo9 = string.Empty;
                try
                {
                    kyakusakiCyumonNo1 = Convert.ToString(kyakuCyumonNo[0]);
                    kyakusakiCyumonNo2 = Convert.ToString(kyakuCyumonNo[1]);
                    kyakusakiCyumonNo3 = Convert.ToString(kyakuCyumonNo[2]);
                    kyakusakiCyumonNo4 = Convert.ToString(kyakuCyumonNo[3]);
                    kyakusakiCyumonNo5 = Convert.ToString(kyakuCyumonNo[4]);
                    kyakusakiCyumonNo6 = Convert.ToString(kyakuCyumonNo[5]);
                    kyakusakiCyumonNo7 = Convert.ToString(kyakuCyumonNo[6]);
                    kyakusakiCyumonNo8 = Convert.ToString(kyakuCyumonNo[7]);
                    kyakusakiCyumonNo9 = Convert.ToString(kyakuCyumonNo[8]);
                }
                catch
                {
                }
                for (int i = 0; i < addRowCount; i++)
                {
                    printData.Tables["dtblNohinoYudensha"].Rows.Add();

                    printData.Tables["dtblNohinoYudensha"].Rows[i]["nen"] = nen;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["tuki"] = tuki;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["hi"] = hi;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo1"] = kyakusakiCyumonNo1;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo2"] = kyakusakiCyumonNo2;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo3"] = kyakusakiCyumonNo3;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo4"] = kyakusakiCyumonNo4;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo5"] = kyakusakiCyumonNo5;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo6"] = kyakusakiCyumonNo6;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo7"] = kyakusakiCyumonNo7;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo8"] = kyakusakiCyumonNo8;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["cyumonNo9"] = kyakusakiCyumonNo9;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["jyusho"] = kaisyajyusyo;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["kaishaNm"] = syamei;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["kenmei1"] = kenmei1;
                    printData.Tables["dtblNohinoYudensha"].Rows[i]["kenmei2"] = kenmei2;
                }
                string strTanka;
                string strKingaku;
                string strTotalKingaku;
                string strShouhizei;
                string strGoukei;
                totalKingaku = decimal.Zero;
                int tankaNo = 0;
                int kingakuNo = 0;
                for (int i = 0; i < bodyDt.Rows.Count; i++)
                {
                    headRowIndex = (int)(i / pageRowCount);
                    bodyRowIndex = (i % pageRowCount) + 1;
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcSuryo]), out suryo);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTanka]), out tanka);
                    decimal.TryParse(Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcKingaku]), out kingaku);
                    strTanka = tanka.ToString();
                    strKingaku = kingaku.ToString();
                    totalKingaku += kingaku;
                    headRow = printData.Tables["dtblNohinoYudensha"].Rows[headRowIndex];
                    headRow["shohinNm" + Convert.ToString(bodyRowIndex) + "1"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName1]);
                    headRow["shohinNm" + Convert.ToString(bodyRowIndex) + "2"] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcShouhinName2]);
                    headRow["suryo" + Convert.ToString(bodyRowIndex) + ""] = suryo.ToString("#,##0");
                    headRow["tani" + Convert.ToString(bodyRowIndex) + ""] = Convert.ToString(bodyDt.Rows[i][DBFileLayout.UriageBodyFile.dcTani]);
                    tankaNo = 7;
                    for (int j = strTanka.Length - 1; j >= 0; j--)
                    {
                        headRow["tanka" + Convert.ToString(bodyRowIndex) + Convert.ToString(tankaNo)] = strTanka[j];
                        tankaNo--;
                    }
                    kingakuNo = 9;
                    for (int j = strKingaku.Length - 1; j >= 0; j--)
                    {
                        headRow["kingaku" + Convert.ToString(bodyRowIndex) + Convert.ToString(kingakuNo)] = strKingaku[j];
                        kingakuNo--;
                    }

                    if (pageRowCount == (i + 1) && bodyDt.Rows.Count != (i + 1))
                    {
                        headRow["gokei7"] = "次";
                        headRow["gokei8"] = "頁";
                        headRow["gokei9"] = "へ";
                    }
                    else if (bodyDt.Rows.Count == (i + 1))
                    {
                        strTotalKingaku = totalKingaku.ToString();
                        //totalShouhizei = commonLogic.TokuisakiRoundKingaku(tokuisakiCd, (totalKingaku * kanriMaster.getNowZeiritu() / 100));
                        totalGoukei = totalKingaku + totalShouhizei;
                        strShouhizei = totalShouhizei.ToString();
                        kingakuNo = 9;
                        for (int j = strTotalKingaku.Length - 1; j >= 0; j--)
                        {
                            headRow["kei" + Convert.ToString(kingakuNo)] = strTotalKingaku[j];
                            kingakuNo--;
                        }
                        kingakuNo = 9;
                        for (int j = strShouhizei.Length - 1; j >= 0; j--)
                        {
                            headRow["shohizei" + Convert.ToString(kingakuNo)] = strShouhizei[j];
                            kingakuNo--;
                        }
                        totalKingaku = decimal.Zero;
                    }
                    if (bodyDt.Rows.Count == (i + 1))
                    {
                        strGoukei = totalGoukei.ToString();
                        kingakuNo = 9;
                        for (int j = strGoukei.Length - 1; j >= 0; j--)
                        {
                            headRow["gokei" + Convert.ToString(kingakuNo)] = strGoukei[j];
                            kingakuNo--;
                        }
                    }
                }
                return printData;
            }
            #endregion
            return null;
        }
        #endregion

        #endregion
    }
}
