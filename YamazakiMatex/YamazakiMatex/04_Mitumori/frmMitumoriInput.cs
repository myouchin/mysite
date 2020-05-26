using Common;
using DB;
using Resorce;
using SubForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;
using System.IO;

namespace Mitumori
{
    /// <summary>
    /// 見積モニタ画面
    /// </summary>
    public partial class frmEstimateInput : ChildBaseForm
    {
        #region 変数定義
        private bool flgSaving = false;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private DataGridViewRow copyGridTopRow = null;
        private DataGridViewRow copyGridBtmRow = null;
        private int gridStartRowCount = 5;
        private RadioButton activeRadioButton = null;
        private CommonLogic commonLogic;
        private string beforeCellValue;
        private string dummyCode = "Dummy";
        private bool flgBtnSearchSelect = false;
        private DBCommon mitumoriDataSelectDb;
        sfrmTokuisakiSearch fTokuisaki;
        sfrmMitumoriSearch fMitumori;
        sfrmKenmeiSearch sKenmei;
        sfrmShouhinSearch fShouhin;
        sfrmJuchuSearch sJuchu;
        private enum LastInputDateType
        {
            None = 0
          , EstimateDate = 1
          , Date = 2
          , ExpirationDate = 3
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DBMeisyoMaster meisyoMaster;
        private DBTantousyaMaster tantousyaMaster;
        private DBTokuisakiMaster tokuisakiMaster;
        private DBShouhinMaster shouhinMaster;
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private int quantityIntegerLength = 8;
        private int quantityDecimalLength = 0;
        private int bidIntegerLength = 8;
        private int bidDecimalLength = 0;
        private int amountIntegerLength = 8;
        private int amountDecimalLength = 0;
        private string quantityFormat;
        private string bidFormat;
        private string amountFormat;
        private enum GridErrorStatus
        {
            None = 0
          , ItemCodeError = 1
          , ItemNameError = 2
          , MultiError = 3
        }
        private enum RecalcMeisaiTYpe
        {
            /// <summary>
            /// 全項目再計算
            /// </summary>
            All = 0
            /// <summary>
            /// 数量入力時の再計算
            /// </summary>
          , QuantityInput = 1
            /// <summary>
            /// 単価入力時の再計算
            /// </summary>
          , BidInput = 2
        }
        bool flgDeletingRow = false;
        string printMitumoriNo = string.Empty;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmEstimateInput()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            meisyoMaster = new DBMeisyoMaster();
            tantousyaMaster = new DBTantousyaMaster();
            tokuisakiMaster = new DBTokuisakiMaster();
            shouhinMaster = new DBShouhinMaster();
            kanriMaster = new DBKanriMaster();
            mitumoriDataSelectDb = new DBCommon();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            fMitumori = new sfrmMitumoriSearch(false, CheckMessageType.None);
            sKenmei = new sfrmKenmeiSearch(false, CheckMessageType.None);
            fShouhin = new sfrmShouhinSearch(false);
            sJuchu = new sfrmJuchuSearch(false, CheckMessageType.None);
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEstimateInput_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtEstimateNo;
            // 見積区分コンボボックス設定
            setEstimateTypeCmb();
            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 消費税出力区分コンボボックス設定
            setTaxDispTypeCmb();
            // 単位コンボボックス設定
            setUnitCmb();
            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 最大入力桁数設定
            setInputInfo();
            // 数量フォーマット文字列取得
            quantityFormat = commonLogic.getNumberFormatString(quantityIntegerLength, quantityDecimalLength);
            // 単価フォーマット文字列取得
            bidFormat = commonLogic.getNumberFormatString(bidIntegerLength, bidDecimalLength);
            // 金額フォーマット文字列取得
            amountFormat = commonLogic.getNumberFormatString(amountIntegerLength, amountDecimalLength);

            grdEstimateDetails.CellValidating += new DataGridViewCellValidatingEventHandler(grdEstimateDetails_CellValidating);
        }
        #endregion

        #region セル描画イベント
        /// <summary>
        /// セル描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEstimateDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            // 行・列共にヘッダは処理しない
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int rowIndex = -1;
            // カレントセルがnull出ない場合
            if (grdEstimateDetails.CurrentCell != null)
            {
                // カレントセルから上段行の行インデックを取得
                rowIndex = grdEstimateDetails.CurrentCell.RowIndex;
                if (rowIndex % grdEstimateDetails.RowSegmentCount == 1) rowIndex--;
            }
            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(rowIndex);

            Rectangle rect;
            DataGridViewCell cell;
            // 行No列の処理
            if (e.ColumnIndex == clmRowNo.DisplayIndex)
            {
                int rowNo = (int)(e.RowIndex / grdEstimateDetails.RowSegmentCount) + 1;
                rect = e.CellBounds;
                // 奇数行(1,3,5..行目 = RowIndexは0,2,4..)
                if (e.RowIndex % grdEstimateDetails.RowSegmentCount == 0)
                {
                    cell = grdEstimateDetails[e.ColumnIndex, e.RowIndex];
                    //一つ下の次のセルの高さを足す
                    rect.Height += cell.Size.Height;
                }
                // 偶数行の処理
                else
                {
                    cell = grdEstimateDetails[e.ColumnIndex, e.RowIndex - 1];
                    if (grdEstimateDetails.Rows[e.RowIndex - 1].Displayed)
                    {
                        // 一つ上のセルの高さを足し、矩形の座標も一つ上のセルに合わす
                        rect.Height += cell.Size.Height;
                        rect.Y -= cell.Size.Height;
                    }
                    else
                    {
                    }
                }
                // セルボーダーライン分矩形の位置を補正
                rect.X -= 1;
                rect.Y -= 1;
                cell.Value = rowNo;
                // 背景、セルボーダーライン、セルの値を描画
                e.Graphics.FillRectangle(
                new SolidBrush(e.CellStyle.BackColor), rect);
                e.Graphics.DrawRectangle(
                new Pen(dv.GridColor), rect);
                TextRenderer.DrawText(e.Graphics,
                cell.FormattedValue.ToString(),
                e.CellStyle.Font, rect, e.CellStyle.ForeColor,
                TextFormatFlags.HorizontalCenter
                | TextFormatFlags.VerticalCenter);
                // イベント　ハンドラ内で処理を行ったことを通知
                e.Handled = true;
            }
            // 商品名でない列の処理
            if (e.RowIndex % grdEstimateDetails.RowSegmentCount == 0 && e.ColumnIndex != clmItemName.DisplayIndex)
            {
                grdEstimateDetails[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
        }
        #endregion

        #region カレントセル変更時イベント
        /// <summary>
        /// カレントセル変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEstimateDetails_CurrentCellChanged(object sender, EventArgs e)
        {
            // 行複写ボタンのテキスト設定
            setRowCopyBtmText();
            // カレントセルがnullの場合何もしない
            if (grdEstimateDetails.CurrentCell == null) return;

            // カレントセルインデックスから上段行のインデックスを取得
            int selectedGridTopRowIndex = 0;
            if (grdEstimateDetails.CurrentCell.RowIndex % grdEstimateDetails.RowSegmentCount == 0)
            {
                selectedGridTopRowIndex = grdEstimateDetails.CurrentCell.RowIndex;
            }
            else
            {
                selectedGridTopRowIndex = grdEstimateDetails.CurrentCell.RowIndex - 1;
            }

            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(selectedGridTopRowIndex);
            activeControlInfo = new ActiveControlInfo();
            // カレントセルがTextBoxCellかつ
            // 入力可能セルの場合
            if (grdEstimateDetails.CurrentCell.OwningColumn is DataGridViewTextBoxColumn &&
                !grdEstimateDetails.CurrentCell.ReadOnly)
            {
                beforeCellValue = Convert.ToString(grdEstimateDetails.CurrentCell.Value);
                // カレントセルの編集モードを開始
                grdEstimateDetails.BeginEdit(true);
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
            Color setColor;
            Color setItemCodeColor;
            Color setItemNameColor;
            int rowStatus = GridErrorStatus.None.GetHashCode();
            string itemCode;
            decimal tanka;
            // 複写中の行インデックスを取得
            int copyGridTopRowIndex = -1;
            int copyGridBtmRowIndex = -1;
            if (copyGridTopRow != null && copyGridBtmRow != null)
            {
                copyGridTopRowIndex = copyGridTopRow.Index;
                copyGridBtmRowIndex = copyGridBtmRow.Index;
            }
            // 全行の背景色を再設定
            foreach (DataGridViewRow gRow in grdEstimateDetails.Rows)
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
                    if ((rdoCorrection.Checked && !flgSearch) || rdoReference.Checked || rdoDelete.Checked)
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
                    if (gRow.Index % grdEstimateDetails.RowSegmentCount == 0)
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
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].ReadOnly = true;           // 行No    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].ReadOnly = true;        // 商品ｺｰﾄﾞ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = true;        // 商品名  ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].ReadOnly = true;        // 数量    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].ReadOnly = true;            // 単位    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].ReadOnly = true;             // 単価    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = true;          // 金額    ：編集不可
                }
                // 複写中の行の場合
                else if (copyGridTopRowIndex == gRow.Index || copyGridBtmRowIndex == gRow.Index)
                {
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].ReadOnly = true;           // 行No    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].ReadOnly = true;        // 商品ｺｰﾄﾞ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = true;        // 商品名  ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].ReadOnly = true;        // 数量    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].ReadOnly = true;            // 単位    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].ReadOnly = true;             // 単価    ：編集不可
                    grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = true;          // 金額    ：編集不可
                }
                // 上段行の場合
                else if (gRow.Index % grdEstimateDetails.RowSegmentCount == 0)
                {
                    if (grdEstimateDetails.Rows.Count - 1 == gRow.Index)
                    {
                        itemCode = string.Empty;
                    }
                    else
                    {
                        itemCode = Convert.ToString(grdEstimateDetails.Rows[gRow.Index + 1].Cells[clmItemCode.DisplayIndex].Value);
                    }
                    // 商品コードが未入力の場合
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].ReadOnly = true;           // 行No    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].ReadOnly = true;        // 商品ｺｰﾄﾞ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = true;        // 商品名  ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].ReadOnly = true;        // 数量    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].ReadOnly = true;            // 単位    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].ReadOnly = true;             // 単価    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = true;          // 金額    ：編集不可
                    }
                    else
                    {
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].ReadOnly = true;           // 行No    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].ReadOnly = true;        // 商品ｺｰﾄﾞ：編集不可
                                                                                                                    // 商品ｺｰﾄﾞが"9999"の場合
                        if (Consts.OthersItemCode.Equals(itemCode))
                        {
                            grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = false;   // 商品名  ：編集不可
                        }
                        else
                        {
                            grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = true;    // 商品名  ：編集可
                        }
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].ReadOnly = true;        // 数量    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].ReadOnly = true;            // 単位    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].ReadOnly = true;             // 単価    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = true;          // 金額    ：編集不可
                    }
                }
                // 下段行の場合
                else
                {
                    itemCode = Convert.ToString(grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].Value);
                    // 商品コードが未入力の場合
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].ReadOnly = true;           // 行No    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].ReadOnly = false;       // 商品ｺｰﾄﾞ：編集可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = true;        // 商品名  ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].ReadOnly = true;        // 数量    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].ReadOnly = true;            // 単位    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].ReadOnly = true;             // 単価    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = true;          // 金額    ：編集不可
                    }
                    else
                    {
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].ReadOnly = true;           // 行No    ：編集不可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].ReadOnly = false;       // 商品ｺｰﾄﾞ：編集可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].ReadOnly = false;       // 商品名  ：編集可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].ReadOnly = false;       // 数量    ：編集可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].ReadOnly = false;           // 単位    ：編集可
                        grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].ReadOnly = false;            // 単価    ：編集可
                        decimal.TryParse(Convert.ToString(grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Value), out tanka);
                        if (decimal.Zero == tanka)
                        {
                            grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = false;     // 金額    ：編集可
                        }
                        else
                        {
                            grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].ReadOnly = true;      // 金額    ：編集可
                        }
                    }
                }

                // セル未選択時の背景色の設定
                grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].Style.BackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].Style.BackColor = setItemCodeColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].Style.BackColor = setItemNameColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].Style.BackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].Style.BackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Style.BackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].Style.BackColor = setColor;
                // セル選択時の背景色の設定
                grdEstimateDetails.Rows[gRow.Index].Cells[clmRowNo.DisplayIndex].Style.SelectionBackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmItemCode.DisplayIndex].Style.SelectionBackColor = setItemCodeColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmItemName.DisplayIndex].Style.SelectionBackColor = setItemNameColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmQuantity.DisplayIndex].Style.SelectionBackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmUnit.DisplayIndex].Style.SelectionBackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmBid.DisplayIndex].Style.SelectionBackColor = setColor;
                grdEstimateDetails.Rows[gRow.Index].Cells[clmAmount.DisplayIndex].Style.SelectionBackColor = setColor;
            }
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
            if (mitumoriDataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                mitumoriDataSelectDb.endTransaction();
            }
            closedForm();
        }
        #endregion

        #region フォーカスアウトイベント
        /// <summary>
        /// フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCd_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
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

        /// <summary>
        /// フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 見積データ取得処理を実行
                bool ret = setMitumoriData(txtEstimateNo.Text);

                if (ret)
                {
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                else
                {
                    text.Focus();
                }
            }
        }

        /// <summary>
        /// フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.EstimateDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.EstimateDate;
            }
        }

        /// <summary>
        /// フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.EstimateDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }

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

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // キー押下イベントを追加
            c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

            // 得意先ｺｰﾄﾞの場合
            if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCd_Leave);
            }
            // 見積Noの場合
            else if (c.Name.Equals(txtEstimateNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEstimateNo_Leave);
            }
            // 見積日付の場合
            else if (c.Name.Equals(txtEstimateDateYears.Name) ||
                     c.Name.Equals(txtEstimateDateMonth.Name) ||
                     c.Name.Equals(txtEstimateDateDays.Name) ||
                     c.Name.Equals(dtpEstimateDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtEstimateDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEstimateDate_Leave);
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

            if (grdEstimateDetails.CurrentCell != null)
            {
                try { grdEstimateDetails.CurrentCell = null; } catch { }
            }

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.EstimateDate:
                        y = txtEstimateDateYears.Text;
                        m = txtEstimateDateMonth.Text;
                        d = txtEstimateDateDays.Text;
                        inputObj = dtpEstimateDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.EstimateDate.Equals(lastInputDateType))
                    {
                        txtEstimateDateYears.Focus();
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
            // 得意先ｺｰﾄﾞまたは
            // 見積Noまたは
            // 件名を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name) ||
                     activeControlInfo.Control.Name.Equals(txtEstimateNo.Name) ||
                     activeControlInfo.Control.Name.Equals(txtSubject1.Name) ||
                     activeControlInfo.Control.Name.Equals(txtSubject2.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 見積グリッド編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞの場合
                if (activeControlInfo.RowIndex % grdEstimateDetails.RowSegmentCount != 0 &&
                    activeControlInfo.ClmIndex == clmItemCode.DisplayIndex)
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
                // F3キーが押下された場合
                case Keys.F3:
                    // TODO:印刷処理を実行
                    btnPreview_Click(null, null);
                    break;
                // F4キーが押下された場合
                case Keys.F4:
                    // TODO:印刷処理を実行
                    btnPrint_Click(null, null);
                    break;
                // F5キーが押下された場合
                case Keys.F5:
                    // TODO:受注検索処理を実行
                    btnOrdersSearch_Click(null, null);
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

        #region 検索ボタン押下時イベント
        /// <summary>
        /// 検索ボタン押下時イベント
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

            // 得意先ｺｰﾄﾞを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
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
            // 見積Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtEstimateNo.Name))
            {
                // 見積検索画面を起動
                fMitumori.MType = messageType;
                fMitumori.ShowDialog();

                if (fMitumori.DialogResult == DialogResult.OK)
                {
                    flgSearch = false;
                    // 見積データ取得処理を実行
                    setMitumoriData(fMitumori.SelectedMitumoriNumbers[0]);
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                flgSetFocus = true;
            }
            // 件名を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtSubject1.Name) || activeControlInfo.Control.Name.Equals(txtSubject2.Name))
            {
                // 件名検索画面を起動
                sKenmei.MType = messageType;
                sKenmei.ShowDialog();

                if (sKenmei.DialogResult == DialogResult.OK)
                {
                    // 件名情報設定
                    setKenmeiInfo(sKenmei.SelectedKenmeiNos[0]);
                }
                flgSetFocus = true;
            }
            // 見積グリッドを編集中の場合
            else if(activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞ列の場合
                if (activeControlInfo.RowIndex % grdEstimateDetails.RowSegmentCount != 0 &&
                    activeControlInfo.ClmIndex == clmItemCode.DisplayIndex)
                {
                    grdEstimateDetails.CancelEdit();
                    // 商品検索画面を起動
                    fShouhin.ShowDialog();

                    // 商品検索画面で確認ボタンが押下された場合
                    if (fShouhin.DialogResult == DialogResult.OK)
                    {
                        // 商品情報設定処理
                        setShouhinInfo(fShouhin.SelectedItemCodes[0].ShireCode
                                     , fShouhin.SelectedItemCodes[0].TopClassification
                                     , fShouhin.SelectedItemCodes[0].BtmClassification
                                     , fShouhin.SelectedItemCodes[0].ShouhinNo);
                        beforeCellValue = fShouhin.SelectedItemCodes[0].ShouhinNo;
                        grdEstimateDetails.EndEdit();
                    }
                    grdEstimateDetails.BeginEdit(true);
                }
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
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
        private void setShouhinInfo(string shiresakiCode, string topClassification, string btmClassification, string shouhinCode)
        {
            // 商品情報の取得
            List<DBFileLayout.ShouhinMasterFile> shouhinInfo = shouhinMaster.getShouhinInfo(shiresakiCode, topClassification, btmClassification, shouhinCode, false);

            int topRowIndex = grdEstimateDetails.CurrentCell.RowIndex;
            int btmRowIndex = 0;
            if (topRowIndex % grdEstimateDetails.RowSegmentCount != 0)
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
                grdEstimateDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
                grdEstimateDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
            }
            // 対象の商品情報が取得できた場合
            else if (shouhinInfo.Count > 0)
            {
                // 商品情報の設定
                grdEstimateDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = shouhinInfo[0].ShouhinCode;
                if (!Consts.OthersItemCode.Equals(shouhinInfo[0].ShouhinCode))
                {
                    grdEstimateDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = shouhinInfo[0].ShouhinName;
                }
            }
            else if (dummyCode.Equals(shouhinCode))
            {
                grdEstimateDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
                grdEstimateDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
            }
            grdEstimateDetails.Refresh();
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
            if (mitumoriDataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                mitumoriDataSelectDb.endTransaction();
            }

            activeRadioButton = radio;
            #region 共通初期値設定
            txtEstimateNo.Text = string.Empty;
            dtpEstimateDate.Value = syoriDate;
            cmbEstimateType.SelectedIndex = -1;
            cmbPersonnel.SelectedValue = Program.loginUserInfo.UserId;
            txtOrdersDocumentNo.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            cmbOffices.SelectedIndex = -1;
            txtCustomerPersonnel.Text = string.Empty;
            txtSubject1.Text = string.Empty;
            txtSubject2.Text = string.Empty;
            txtDelivery.Text = string.Empty;
            txtTradingConditions.Text = string.Empty;
            if (rdoNew.Checked)
            {
                txtExpirationDateDays.Text = "60";
            }
            else
            {
                txtExpirationDateDays.Text = string.Empty;
            }
            txtDeliveryPlace1.Text = string.Empty;
            setOfficesCmb(dummyCode, string.Empty);

            if (rdoNew.Checked)
            {
                txtCustomerNameOption.Text = "御中";
                txtOfficesNameOption.Text = "様";
            }
            else
            {
                txtCustomerNameOption.Text = string.Empty;
                txtOfficesNameOption.Text = string.Empty;
            }
            cmbTaxDispType.SelectedIndex = 1;
            lblEstimateTotalAmount.Text = Convert.ToString(decimal.Zero);

            // グリッド初期化処理実行
            initGridData();
            #endregion

            flgSearch = false;
            // モード別編集可否設定
            setEnabled();
        }
        #endregion

        #region 処理モード別項目制御処理
        /// <summary>
        /// 処理モード別項目制御処理
        /// </summary>
        private void setEnabled()
        {
            if (flgSettingEnable) return;
            flgSettingEnable = true;
            rdoNew.Click -= new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            rdoDelete.Click -= new EventHandler(inputModeRadio_Click);
            grdEstimateDetails.Focus();
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                txtEstimateNo.Enabled = true;
                txtEstimateNo.Focus();
                txtEstimateNo.ReadOnly = true;

                txtCustomerCode.Enabled = true;
                if (Consts.OthersCustomerCode.Equals(txtCustomerCode.Text))
                {
                    txtCustomerName.Enabled = true;
                    txtCustomerKanaName.Enabled = true;
                }
                else
                {
                    txtCustomerName.Enabled = false;
                    txtCustomerKanaName.Enabled = false;
                }
                txtCustomerNameOption.Enabled = true;
                cmbOffices.Enabled = true;
                txtOfficesNameOption.Enabled = true;
                txtCustomerPersonnel.Enabled = true;
                txtSubject1.Enabled = true;
                txtSubject2.Enabled = true;
                txtDelivery.Enabled = true;
                txtTradingConditions.Enabled = true;
                pnlExpirationDate.Enabled = true;
                txtDeliveryPlace1.Enabled = true;
                pnlEstimateDate.Enabled = true;
                cmbEstimateType.Enabled = true;
                cmbPersonnel.Enabled = true;
                cmbTaxDispType.Enabled = true;
                btnCopyRow.Enabled = true;
                btnPasteRow.Enabled = true;
                btnInsertRow.Enabled = true;
                btnDeleteRow.Enabled = true;
                btnSearch.Enabled = true;
                btnPreview.Visible = false;
                btnPrint.Visible = false;
                btnOrdersSearch.Visible = true;
                btnSave.Enabled = true;
                btnSave.Text = "F10：保存";
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                btnOrdersSearch.Location = new Point(btnPreview.Location.X, btnPreview.Location.Y);
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                txtEstimateNo.Enabled = !flgSearch;
                txtEstimateNo.ReadOnly = false;
                txtCustomerCode.Enabled = flgSearch;
                if (Consts.OthersCustomerCode.Equals(txtCustomerCode.Text))
                {
                    txtCustomerName.Enabled = true;
                    txtCustomerKanaName.Enabled = true;
                }
                else
                {
                    txtCustomerName.Enabled = false;
                    txtCustomerKanaName.Enabled = false;
                }
                txtCustomerNameOption.Enabled = flgSearch;
                cmbOffices.Enabled = flgSearch;
                txtOfficesNameOption.Enabled = flgSearch;
                txtCustomerPersonnel.Enabled = flgSearch;
                txtSubject1.Enabled = flgSearch;
                txtSubject2.Enabled = flgSearch;
                txtDelivery.Enabled = flgSearch;
                txtTradingConditions.Enabled = flgSearch;
                pnlExpirationDate.Enabled = flgSearch;
                txtExpirationDateDays.BackColor = Color.White;
                txtDeliveryPlace1.Enabled = flgSearch;
                pnlEstimateDate.Enabled = flgSearch;
                txtEstimateDateYears.BackColor = Color.White;
                txtEstimateDateMonth.BackColor = Color.White;
                txtEstimateDateDays.BackColor = Color.White;
                cmbEstimateType.Enabled = flgSearch;
                cmbPersonnel.Enabled = flgSearch;
                cmbTaxDispType.Enabled = flgSearch;
                btnCopyRow.Enabled = flgSearch;
                btnPasteRow.Enabled = flgSearch;
                btnInsertRow.Enabled = flgSearch;
                btnDeleteRow.Enabled = flgSearch;
                btnSearch.Enabled = true;
                btnPreview.Visible = true;
                btnPrint.Visible = true;
                btnPreview.Enabled = flgSearch;
                btnPrint.Enabled = flgSearch;
                btnOrdersSearch.Visible = false;
                btnSave.Enabled = flgSearch;
                btnSave.Text = "F10：保存";
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
                if (!flgSearch)
                {
                    txtEstimateNo.Focus();
                }
                else
                {
                    txtCustomerCode.Focus();
                }

                btnOrdersSearch.Location = new Point(380, 15);
            }
            // 参照
            else if (rdoReference.Checked)
            {
                txtEstimateNo.Enabled = !flgSearch;
                txtEstimateNo.ReadOnly = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerNameOption.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtOfficesNameOption.Enabled = false;
                txtCustomerPersonnel.Enabled = false;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtDelivery.Enabled = false;
                txtTradingConditions.Enabled = false;
                pnlExpirationDate.Enabled = false;
                txtExpirationDateDays.BackColor = Color.White;
                txtDeliveryPlace1.Enabled = false;
                pnlEstimateDate.Enabled = false;
                txtEstimateDateYears.BackColor = Color.White;
                txtEstimateDateMonth.BackColor = Color.White;
                txtEstimateDateDays.BackColor = Color.White;
                cmbEstimateType.Enabled = false;
                cmbPersonnel.Enabled = false;
                cmbTaxDispType.Enabled = false;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = true;
                btnPreview.Visible = true;
                btnPrint.Visible = true;
                btnPreview.Enabled = flgSearch;
                btnPrint.Enabled = flgSearch;
                btnOrdersSearch.Visible = false;
                btnSave.Enabled = false;
                btnSave.Text = "F10：保存";
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
                if (!flgSearch)
                {
                    txtEstimateNo.Focus();
                }

                btnOrdersSearch.Location = new Point(380, 15);
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                txtEstimateNo.Enabled = !flgSearch;
                txtEstimateNo.ReadOnly = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerNameOption.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtOfficesNameOption.Enabled = false;
                txtCustomerPersonnel.Enabled = false;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtDelivery.Enabled = false;
                txtTradingConditions.Enabled = false;
                pnlExpirationDate.Enabled = false;
                txtExpirationDateDays.BackColor = Color.White;
                txtDeliveryPlace1.Enabled = false;
                pnlEstimateDate.Enabled = false;
                txtEstimateDateYears.BackColor = Color.White;
                txtEstimateDateMonth.BackColor = Color.White;
                txtEstimateDateDays.BackColor = Color.White;
                cmbEstimateType.Enabled = false;
                cmbPersonnel.Enabled = false;
                cmbTaxDispType.Enabled = false;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = true;
                btnPreview.Visible = false;
                btnPrint.Visible = false;
                btnOrdersSearch.Visible = false;
                btnSave.Enabled = flgSearch;
                btnSave.Text = "F10：実行";
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
                if (!flgSearch)
                {
                    txtEstimateNo.Focus();
                }

                btnOrdersSearch.Location = new Point(380, 15);
            }
            #endregion
            rdoNew.Click += new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
            rdoDelete.Click += new EventHandler(inputModeRadio_Click);
            flgSettingEnable = false;
        }
        #endregion

        #region 見積グリッド初期化処理
        /// <summary>
        /// 見積グリッド初期化処理
        /// </summary>
        private void initGridData()
        {
            grdEstimateDetails.Rows.Clear();
            for (int i = 0; i < gridStartRowCount + 1; i++)
            {
                // 見積グリッドへ空行を追加
                addEmptyGridRow();
            }
            grdEstimateDetails.CurrentCell = null;
            grdEstimateDetails.Refresh();
            grdEstimateDetails.Rows.RemoveAt(grdEstimateDetails.Rows.Count - 1);
            grdEstimateDetails.Rows.RemoveAt(grdEstimateDetails.Rows.Count - 1);
        }
        #endregion

        #region 見積区分コンボボックスの設定
        /// <summary>
        /// 見積区分コンボボックスの設定
        /// </summary>
        private void setEstimateTypeCmb()
        {
            // 見積区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE002);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbEstimateType, meisyoDt, "kubun", "kubunName");
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

        #region 単位コンボボックスの設定
        /// <summary>
        /// 単位コンボボックスの設定
        /// </summary>
        private void setUnitCmb()
        {
            // 単位取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE003);
            // コンボボックス設定共通処理実行
            commonLogic.setGridComboBoxDataSource(ref clmUnit, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 消費税出力区分コンボボックスの設定
        /// <summary>
        /// 消費税出力区分コンボボックスの設定
        /// </summary>
        private void setTaxDispTypeCmb()
        {
            // 消費税出力区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE011);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbTaxDispType, meisyoDt, "kubun", "kubunName");
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

        #region 行複写ボタン押下処理
        /// <summary>
        /// 行複写ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力して処理を終了
            if (grdEstimateDetails.CurrentRow == null)
            {
                errorOK(Messages.M0004);
                return;
            }

            // 選択行から上段行のINDEXを取得
            int selectedGridTopRowIndex = grdEstimateDetails.CurrentRow.Index;
            if (selectedGridTopRowIndex % grdEstimateDetails.RowSegmentCount != 0)
            {
                selectedGridTopRowIndex = grdEstimateDetails.CurrentRow.Index - 1;
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
                copyGridTopRow = grdEstimateDetails.Rows[selectedGridTopRowIndex];
                copyGridBtmRow = grdEstimateDetails.Rows[selectedGridTopRowIndex + 1];
            }
            // 行複写ボタンのテキスト設定
            setRowCopyBtmText();
            grdEstimateDetails.Focus();
            // グリッド再描画
            grdEstimateDetails.Refresh();
            if (flgCancelCopy)
            {
                grdEstimateDetails.CurrentCell = grdEstimateDetails[clmItemCode.DisplayIndex, selectedGridTopRowIndex + 1];
                grdEstimateDetails.BeginEdit(true);
            }
        }
        #endregion

        #region 行貼付ボタン押下処理
        /// <summary>
        /// 行貼付ボタン押下処理
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
            if (grdEstimateDetails.CurrentRow == null ||
                copyGridTopRow.Index == grdEstimateDetails.CurrentCell.RowIndex ||
                copyGridBtmRow.Index == grdEstimateDetails.CurrentCell.RowIndex)
            {
                errorOK(Messages.M0006);
                return;
            }

            // 貼付対象行が入力済みの場合、確認メッセージを出力する
            int currentTopRowIndex;
            int currentBtmRowIndex;
            if (grdEstimateDetails.CurrentCell.RowIndex % grdEstimateDetails.RowSegmentCount == 0)
            {
                currentTopRowIndex = grdEstimateDetails.CurrentCell.RowIndex;
                currentBtmRowIndex = grdEstimateDetails.CurrentCell.RowIndex + 1;
            }
            else
            {
                currentTopRowIndex = grdEstimateDetails.CurrentCell.RowIndex - 1;
                currentBtmRowIndex = grdEstimateDetails.CurrentCell.RowIndex;
            }

            // 入力済みの行を選択している場合、確認メッセージを出力
            if (!checkEmptyRow(currentTopRowIndex) &&
                queryYesNo(Messages.M0007) == DialogResult.No)
            {
                return;
            }

            // 貼り付け処理を実行
            string afterItemCd = Convert.ToString(grdEstimateDetails.Rows[copyGridBtmRow.Index].Cells[clmItemCode.DisplayIndex].Value);
            string afterItemNm1 = Convert.ToString(grdEstimateDetails.Rows[copyGridTopRow.Index].Cells[clmItemName.DisplayIndex].Value);
            string afterItemNm2 = Convert.ToString(grdEstimateDetails.Rows[copyGridBtmRow.Index].Cells[clmItemName.DisplayIndex].Value);
            string afterSuryo = Convert.ToString(grdEstimateDetails.Rows[copyGridBtmRow.Index].Cells[clmQuantity.DisplayIndex].Value);
            string afterTani = Convert.ToString(grdEstimateDetails.Rows[copyGridBtmRow.Index].Cells[clmUnit.DisplayIndex].Value); ;
            string afterTanka = Convert.ToString(grdEstimateDetails.Rows[copyGridBtmRow.Index].Cells[clmBid.DisplayIndex].Value);
            string afterKingaku = Convert.ToString(grdEstimateDetails.Rows[copyGridBtmRow.Index].Cells[clmAmount.DisplayIndex].Value);
            // 商品ｺｰﾄﾞ
            grdEstimateDetails.Rows[currentBtmRowIndex].Cells[clmItemCode.DisplayIndex].Value = afterItemCd;
            // 商品名(上段)
            grdEstimateDetails.Rows[currentTopRowIndex].Cells[clmItemName.DisplayIndex].Value = afterItemNm1;
            // 商品名(下段)
            grdEstimateDetails.Rows[currentBtmRowIndex].Cells[clmItemName.DisplayIndex].Value = afterItemNm2;
            // 数量
            grdEstimateDetails.Rows[currentBtmRowIndex].Cells[clmQuantity.DisplayIndex].Value = getDbNumberValue(afterSuryo);
            // 単位
            grdEstimateDetails.Rows[currentBtmRowIndex].Cells[clmUnit.DisplayIndex].Value = afterTani;
            // 単価
            grdEstimateDetails.Rows[currentBtmRowIndex].Cells[clmBid.DisplayIndex].Value = getDbNumberValue(afterTanka);
            // 金額
            grdEstimateDetails.Rows[currentBtmRowIndex].Cells[clmAmount.DisplayIndex].Value = getDbNumberValue(afterKingaku);

            //　見積グリッドの最終行が空白行でない場合、空白行を追加
            addLastEmptyRow();

            lblEstimateTotalAmount.Text = getTotalAmount().ToString("#,##0");

            if (grdEstimateDetails.CurrentCell != null)
            {
                grdEstimateDetails.BeginEdit(true);
            }
        }
        #endregion

        #region 行挿入ボタン押下処理
        /// <summary>
        /// 行挿入ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力する
            if (grdEstimateDetails.CurrentRow == null)
            {
                errorOK(Messages.M0008);
                return;
            }
            int insertIndex = grdEstimateDetails.CurrentRow.Index % grdEstimateDetails.RowSegmentCount == 0 ? grdEstimateDetails.CurrentRow.Index : grdEstimateDetails.CurrentRow.Index - 1;
            // 見積グリッドへ空行を追加
            insertEmptyGridRow(insertIndex);
            grdEstimateDetails.CurrentCell = grdEstimateDetails[clmItemCode.DisplayIndex, insertIndex + 1];
            grdEstimateDetails.Refresh();
            grdEstimateDetails.BeginEdit(true);
        }
        #endregion

        #region 行削除ボタン押下処理
        /// <summary>
        /// 行削除ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力し処理を終了する
            if (grdEstimateDetails.CurrentRow == null)
            {
                errorOK(Messages.M0009);
                return;
            }
            int deleteIndex = grdEstimateDetails.CurrentRow.Index % grdEstimateDetails.RowSegmentCount == 0 ? grdEstimateDetails.CurrentRow.Index : grdEstimateDetails.CurrentRow.Index - 1;
            // 複写中の行を選択している場合、エラーメッセージを出力し処理を終了する
            if (copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == deleteIndex || copyGridBtmRow.Index == deleteIndex))
            {
                errorOK(string.Format(Messages.M0016, "複写中", "削除", "(削除する場合は、複写行を選択し取消ボタンを押下してください。)"));
                return;
            }

            flgDeletingRow = true;
            grdEstimateDetails.Rows.Remove(grdEstimateDetails.Rows[deleteIndex + 1]);
            grdEstimateDetails.Rows.Remove(grdEstimateDetails.Rows[deleteIndex]);
            flgDeletingRow = false;

            // 見積グリッドへの不足分行追加処理実行
            addInsufficientEmptyGridRow();

            //　見積グリッドの最終行が空白行でない場合、空白行を追加
            addLastEmptyRow();

            lblEstimateTotalAmount.Text = getTotalAmount().ToString("#,##0");

            if (grdEstimateDetails.Rows.Count == 0)
            {
            }
            //else if (grdEstimateDetails.Rows.Count >= deleteIndex + 1)
            else if (deleteIndex == 0)
            {
                grdEstimateDetails.CurrentCell = grdEstimateDetails[clmItemCode.DisplayIndex, deleteIndex + 1];
            }
            else
            {
                grdEstimateDetails.CurrentCell = grdEstimateDetails[clmItemCode.DisplayIndex, deleteIndex - 1];
            }
            grdEstimateDetails.Refresh();
        }
        #endregion

        #region プレビューボタン押下イベント
        /// <summary>
        /// プレビューボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!btnPreview.Enabled || !btnPreview.Visible) return;
            executePrint(PrintType.Preview, txtEstimateNo.Text);
        }
        #endregion

        #region 印刷ボタン押下イベント
        /// <summary>
        /// 印刷ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!btnPrint.Enabled || !btnPrint.Visible) return;
            executePrint(PrintType.OutPut, txtEstimateNo.Text);
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType, string mitumoriNo)
        {
            frmSelectSyaban frm = new frmSelectSyaban();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            bool flgSyaban = (frm.SType == frmSelectSyaban.SyabanType.Ari);
            // 帳票データの設定
            rptMitumorisho1.SetDataSource(createMitumoriPrintData(mitumoriNo, flgSyaban));
            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptMitumorisho1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptMitumorisho1.PrintOptions.PaperOrientation)
                                                                     , rptMitumorisho1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptMitumorisho1.PrintToPrinter(printerSettings
                                                 , pageSettings
                                                 , false);

                }
            }
            else
            {
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptMitumorisho1;
                printView.Size = new Size(1375, 975);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #region 帳票出力データ生成処理
        /// <summary>
        /// 帳票出力データ生成処理
        /// </summary>
        /// <returns></returns>
        private dtblMitumorisho createMitumoriPrintData(string mitumoriNo, bool flgSyaban)
        {
            dtblMitumorisho printData = new dtblMitumorisho();

            #region 変数宣言
            DataTable masterDt;
            DataTable headDt;
            DataTable bodyDt;
            DataTable footDt;
            DataRow newHeadRow;
            DataRow newBodyRow;
            DataRow newFootRow;
            int topPageMaxRowCount = 17;
            int otherPageMaxRowCount = 28;
            int rowCount = 0;
            int page = 0;
            int maxPage = 0;
            int LackRowCount = 0;

            string masterSql = "SELECT * FROM kaisya_master ";
            string headSql = string.Empty;
            headSql += "SELECT mh.* ";
            headSql += "     , DATE_FORMAT(STR_TO_DATE(mh.mitumoriHizuke,'%Y-%m-%d'), '%Y年%c月%e日') AS mitumoriHizukeFormat ";
            headSql += "     , mm.tantousyaName ";
            headSql += "     , mm.mail ";
            headSql += "     , DATE_FORMAT(mh.nouki, '%Y年%c月%e日') AS noukiFormat ";
            headSql += "FROM mitumori_header mh ";
            headSql += "INNER JOIN (SELECT * FROM tantousya_master) mm ";
            headSql += "ON (mh.tantousyaCode = mm.tantousyaCode) ";
            headSql += "WHERE mh.mitumoriNo = '" + mitumoriNo + "' ";
            string bodySql = "SELECT * FROM mitumori_body WHERE mitumoriNo = '" + mitumoriNo + "' ORDER BY rowNo ";
            string footSql = "SELECT * FROM mitumori_footer WHERE mitumoriNo = '" + mitumoriNo + "' ";

            masterDt = mitumoriDataSelectDb.executeNoneLockSelect(masterSql);
            headDt = mitumoriDataSelectDb.executeNoneLockSelect(headSql);
            bodyDt = mitumoriDataSelectDb.executeNoneLockSelect(bodySql);
            footDt = mitumoriDataSelectDb.executeNoneLockSelect(footSql);

            mitumoriNo = Convert.ToString(headDt.Rows[0]["mitumoriNo"]);
            string mitumorihiduke = Convert.ToString(headDt.Rows[0]["mitumoriHizukeFormat"]);
            string tokuisakiName = Convert.ToString(headDt.Rows[0]["tokuisakiName"]);
            string tokuisakiNameOption = Convert.ToString(headDt.Rows[0][DBFileLayout.MitumoriHeaderFile.dcTokuisakiNameOption]);
            string jigyousyoName = Convert.ToString(headDt.Rows[0]["jigyousyoName"]);
            string jigyousyoNameOption = Convert.ToString(headDt.Rows[0][DBFileLayout.MitumoriHeaderFile.dcJigyousyoNameOption]);
            string tokuisakiTantousyaName = Convert.ToString(headDt.Rows[0][DBFileLayout.MitumoriHeaderFile.dcTokuisakiTantousayName]);
            string kenmei = Convert.ToString(headDt.Rows[0]["kenmei1"]);
            string kenmei2 = Convert.ToString(headDt.Rows[0]["kenmei2"]);
            string nouki = Convert.ToString(headDt.Rows[0]["nouki"]);
            string ukewatasiBasyo1 = Convert.ToString(headDt.Rows[0]["ukewatasiBasyo1"]);
            string torihikiJouken = Convert.ToString(headDt.Rows[0]["torihikiJouken"]);
            string yuukouKigen = Convert.ToString(headDt.Rows[0]["yuukouKigen"]);
            string yuubinnNo = Convert.ToString(masterDt.Rows[0]["zipCode"]);
            string jyuusho1 = Convert.ToString(masterDt.Rows[0]["address"]);
            string jyuusho2 = Convert.ToString(masterDt.Rows[0]["address"]);
            string tell = Convert.ToString(masterDt.Rows[0]["renrakusaki1"]);
            string fax = Convert.ToString(masterDt.Rows[0]["renrakusaki2"]);
            string tantousya = Convert.ToString(headDt.Rows[0]["tantousyaName"]);
            string email = Convert.ToString(headDt.Rows[0]["mail"]);
            bool flgTnakaMitumori = Convert.ToString(headDt.Rows[0]["mitumoriKubun"]).Equals("02") ? true : false;
            string wkSuryou;
            string wkTanka;
            string wkKingaku;
            decimal suryou;
            decimal tanka;
            decimal kingaku;
            decimal totalKingaku = decimal.Zero;
            #endregion

            // イメージファイル読み込み
            FileStream fs = new FileStream("C:\\Release\\Resorce\\companyStamp.jpg", FileMode.Open);
            //FileStream fs = new FileStream("C:\\Release\\Resorce\\companyStamp.png", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            for (int i = 0; i < bodyDt.Rows.Count; i++)
            {
                rowCount++;
                page = printData.Tables["dtblMitumoriHeder"].Rows.Count + 1;
                wkSuryou = Convert.ToString(bodyDt.Rows[i]["suryo"]);
                wkTanka = Convert.ToString(bodyDt.Rows[i]["tanka"]);
                wkKingaku = Convert.ToString(bodyDt.Rows[i]["kingaku"]);
                decimal.TryParse(wkSuryou, out suryou);
                decimal.TryParse(wkTanka, out tanka);
                decimal.TryParse(wkKingaku, out kingaku);

                #region ボディデータ生成処理
                newBodyRow = printData.Tables["dtblMitumoriBody"].NewRow();
                newBodyRow["mitumoriNo"] = mitumoriNo;
                newBodyRow["page"] = page;
                newBodyRow["gyo"] = (i + 1);
                newBodyRow["hinmei1"] = Convert.ToString(bodyDt.Rows[i]["shouhinName1"]);
                newBodyRow["hinmei2"] = Convert.ToString(bodyDt.Rows[i]["shouhinName2"]);
                if (!string.IsNullOrEmpty(wkSuryou))
                {
                    newBodyRow["suryou"] = suryou.ToString("#,##0");
                }
                newBodyRow["tani"] = Convert.ToString(bodyDt.Rows[i]["tani"]);
                if (!string.IsNullOrEmpty(wkTanka))
                {
                    newBodyRow["tanka"] = tanka.ToString("#,##0");
                }
                if (!string.IsNullOrEmpty(wkKingaku))
                {
                    newBodyRow["kingaku"] = kingaku.ToString("#,##0");
                }
                printData.Tables["dtblMitumoriBody"].Rows.Add(newBodyRow.ItemArray);
                #endregion

                totalKingaku += kingaku;

                if ((page == 1 && topPageMaxRowCount == rowCount) ||
                    (page != 1 && otherPageMaxRowCount == rowCount) ||
                    (i + 1 == bodyDt.Rows.Count))
                {
                    #region ヘッダデータ生成処理
                    newHeadRow = printData.Tables["dtblMitumoriHeder"].NewRow();
                    newHeadRow["page"] = page;
                    newHeadRow["mitumoriNo"] = mitumoriNo;
                    newHeadRow["mitumorihiduke"] = mitumorihiduke;
                    if (string.IsNullOrEmpty(jigyousyoName + tokuisakiTantousyaName))
                    {
                        newHeadRow["torihikisakiNm2"] = tokuisakiName + "　" + tokuisakiNameOption;
                    }
                    else
                    {
                        newHeadRow["torihikisakiNm1"] = tokuisakiName + "　" + tokuisakiNameOption;
                        newHeadRow["torihikisakiNm2"] = jigyousyoName;
                        if (!string.IsNullOrEmpty(jigyousyoName)) newHeadRow["torihikisakiNm2"] += "　";
                        newHeadRow["torihikisakiNm2"] += tokuisakiTantousyaName + "　" + jigyousyoNameOption;
                    }
                    if (string.IsNullOrEmpty(kenmei2))
                    {
                        newHeadRow["kenmei"] = string.Empty;
                        newHeadRow["kenmei2"] = kenmei;
                    }
                    else
                    {
                        newHeadRow["kenmei"] = kenmei;
                        newHeadRow["kenmei2"] = kenmei2;
                    }
                    newHeadRow["nouki"] = nouki;
                    newHeadRow["ukewatasi"] = ukewatasiBasyo1;
                    newHeadRow["jyouken"] = torihikiJouken;
                    newHeadRow["mitumorikigen"] = yuukouKigen + "日";
                    newHeadRow["yuubinnNo"] = yuubinnNo;
                    newHeadRow["jyuusho1"] = jyuusho1;
                    newHeadRow["jyuusho2"] = jyuusho2;
                    newHeadRow["tell"] = tell;
                    newHeadRow["fax"] = fax;
                    newHeadRow["tantousya"] = tantousya;
                    newHeadRow["email"] = email;
                    newHeadRow["goukeikingaku"] = 0;
                    if (printData.Tables["dtblMitumoriHeder"].Rows.Count > 0)
                    {
                        newHeadRow["mitumoriNoOther"] = "No." + mitumoriNo;
                        newHeadRow["mitumorihidukeOther"] = mitumorihiduke;
                        newHeadRow["kenmeiOther"] = "件名：" + kenmei;
                    }
                    if (flgSyaban)
                    {
                        newHeadRow["companyStamp"] = br.ReadBytes((int)br.BaseStream.Length);
                    }
                    printData.Tables["dtblMitumoriHeder"].Rows.Add(newHeadRow.ItemArray);
                    #endregion

                    #region フッタデータ生成処理
                    newFootRow = printData.Tables["dtblMitumoriF"].NewRow();
                    newFootRow["page"] = page;
                    newFootRow["mitumoriNo"] = mitumoriNo;
                    if ((i + 1 == bodyDt.Rows.Count) && !flgTnakaMitumori)
                    {
                        newFootRow["title"] = "合　　　　　　　　　　計";
                        newFootRow["goukei"] = totalKingaku.ToString("#,##0");
                    }
                    else if (flgTnakaMitumori)
                    {
                        newFootRow["title"] = "合　　　　　　　　　　計";
                        newFootRow["goukei"] = string.Empty;
                    }
                    else
                    {
                        newFootRow["title"] = "次ページに続きます";
                    }
                    printData.Tables["dtblMitumoriF"].Rows.Add(newFootRow.ItemArray);
                    #endregion

                    maxPage = page;
                    rowCount = 0;
                }
            }

            #region 不足分のボディデータ追加
            if (printData.Tables["dtblMitumoriBody"].Rows.Count <= topPageMaxRowCount)
            {
                LackRowCount = topPageMaxRowCount - (printData.Tables["dtblMitumoriBody"].Rows.Count % topPageMaxRowCount);
                if (LackRowCount == topPageMaxRowCount) LackRowCount = 0;
            }
            else
            {
                LackRowCount = otherPageMaxRowCount - ((printData.Tables["dtblMitumoriBody"].Rows.Count - topPageMaxRowCount) % otherPageMaxRowCount);
                if (LackRowCount == otherPageMaxRowCount) LackRowCount = 0;
            }
            while (LackRowCount > 0)
            {
                printData.Tables["dtblMitumoriBody"].Rows.Add();
                printData.Tables["dtblMitumoriBody"].Rows[printData.Tables["dtblMitumoriBody"].Rows.Count - 1]["page"] = printData.Tables["dtblMitumoriHeder"].Rows.Count;
                printData.Tables["dtblMitumoriBody"].Rows[printData.Tables["dtblMitumoriBody"].Rows.Count - 1]["gyo"] = printData.Tables["dtblMitumoriBody"].Rows.Count;
                LackRowCount--;
            }
            #endregion

            #region 総合計金額設定
            foreach (DataRow row in printData.Tables["dtblMitumoriHeder"].Rows)
            {
                if (flgTnakaMitumori)
                {
                    row["goukeikingaku"] = "単価見積";
                }
                else
                {
                    row["goukeikingaku"] = "￥" + totalKingaku.ToString("#,##0");
                }
                row["maxPage"] = maxPage;
            }
            #endregion

            return printData;
        }
        #endregion

        #region 見積グリッドの空白行チェック処理
        /// <summary>
        /// 見積グリッドの空白行チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkAllEmptyRow()
        {
            bool flgAllEmptyRow = true;
            for (int i = 0; i < grdEstimateDetails.Rows.Count; i++)
            {
                // 対象行が入力済みの場合
                if (!checkEmptyRow(i))
                {
                    flgAllEmptyRow = false;
                    break;
                }
                i++;
            }

            return flgAllEmptyRow;
        }
        #endregion

        #region 見積グリッドの中間空白行存在チェック処理
        /// <summary>
        /// 見積グリッドの中間空白行存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkMiddleEmptyRowExist()
        {
            bool flgEmptyRow = false;
            for (int i = 0; i < grdEstimateDetails.Rows.Count; i++)
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

        #region 見積グリッドの中間空白行削除処理
        /// <summary>
        /// 見積グリッドの中間空白行削除処理
        /// </summary>
        private void deleteAllEmptyRow()
        {
            int delRowCnt = 0;
            for (int i = grdEstimateDetails.Rows.Count - 1; i >= 0; i--)
            {
                if (checkEmptyRow(i - 1))
                {
                    grdEstimateDetails.Rows.Remove(grdEstimateDetails.Rows[i]);
                    grdEstimateDetails.Rows.Remove(grdEstimateDetails.Rows[i - 1]);
                    delRowCnt += grdEstimateDetails.RowSegmentCount;
                }
                i--;
            }

            // 見積グリッドへの不足分行追加処理実行
            addInsufficientEmptyGridRow();

            //　見積グリッドの最終行が空白行でない場合、空白行を追加
            addLastEmptyRow();
        }
        #endregion

        #region 保存ボタン押下処理
        /// <summary>
        /// 保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;
            flgSaving = true;
            // チェック処理
            if (!checkRequired())
            {
                flgSaving = false;
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
                string mitumoriNo = txtEstimateNo.Text;
                DateTime registerDate = DateTime.Now;
                // 見積ヘッダ更新SQL生成処理実行
                string sqlHeaderCommand = createHeaderRegistSql(ref mitumoriNo, registerDate);
                // 受注ヘッダ更新SQL生成処理実行
                string sqlJuchuHeaderCommand = !string.IsNullOrEmpty(txtOrdersDocumentNo.Text) ? createJuchuHeaderRegistSql(mitumoriNo, txtOrdersDocumentNo.Text, registerDate) : string.Empty;
                // 見積ボディ更新SQL生成処理実行
                List<string> sqlBodyCommands = createBodyRegistSql(mitumoriNo, registerDate);
                // 見積フッタ更新SQL生成処理実行
                string sqlFooterCommand = createFooterRegistSql(mitumoriNo, registerDate);
                // 管理マスタ更新SQL生成処理実行
                string sqlKanriMasterCommand = rdoNew.Checked ? createKanriMasterRegistSql(mitumoriNo, registerDate) : string.Empty;
                int headerRegistResult = 0;
                int juchuHeaderRegistResult = 0;
                int bodyRegistResult = 0;
                int footerRegistResult = 0;
                int kanriMasterRegistResult = 0;
                mitumoriDataSelectDb.DBRef = 0;

                if (rdoNew.Checked)
                {
                    mitumoriDataSelectDb.startTransaction();
                    // 管理マスタ(見積No)のロック
                    mitumoriDataSelectDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.MitumoriNo + "'", true);
                    if (mitumoriDataSelectDb.DBRef != 0)
                    {
                        errorOK("見積Noロックエラー");
                        mitumoriDataSelectDb.endTransaction();
                        flgSaving = false;
                        return;
                    }
                }

                // 見積ヘッダの更新
                headerRegistResult = mitumoriDataSelectDb.executeDBUpdate(sqlHeaderCommand);

                if (mitumoriDataSelectDb.DBRef == 0)
                {
                    // 見積ボディの更新
                    foreach (string bodyCommand in sqlBodyCommands)
                    {
                        bodyRegistResult = mitumoriDataSelectDb.executeDBUpdate(bodyCommand);
                        if (mitumoriDataSelectDb.DBRef != 0) break;
                    }
                }

                // 見積フッターの更新
                if (mitumoriDataSelectDb.DBRef == 0) footerRegistResult = mitumoriDataSelectDb.executeDBUpdate(sqlFooterCommand);

                // 受注ヘッダの更新
                if (mitumoriDataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlJuchuHeaderCommand)) juchuHeaderRegistResult = mitumoriDataSelectDb.executeDBUpdate(sqlJuchuHeaderCommand);
                
                // 管理マスタの更新
                if (mitumoriDataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlKanriMasterCommand)) kanriMasterRegistResult = mitumoriDataSelectDb.executeDBUpdate(sqlKanriMasterCommand);


                if (mitumoriDataSelectDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (headerRegistResult < 0)
                    {
                        tableName = "見積ヘッダ";
                    }
                    else if (bodyRegistResult < 0)
                    {
                        tableName = "見積明細";
                    }
                    else if (footerRegistResult < 0)
                    {
                        tableName = "見積集計";
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
                    if (juchuHeaderRegistResult < 0)
                    {
                        tableName = "受注ヘッダ";
                        processName = "更新処理";
                    }
                    if (rdoNew.Checked) mitumoriDataSelectDb.endTransaction();
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "見積No:" + mitumoriNo;
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

                    frmPrintQuery printQuery = new frmPrintQuery(MessageType.Message, string.Format(Messages.M0012, message1, message2), "見積書");
                    if (rdoNew.Checked || rdoCorrection.Checked)
                    {
                        // トランザクション終了処理を実行
                        mitumoriDataSelectDb.endTransaction();
                        printQuery.StartPosition = FormStartPosition.CenterScreen;
                        printQuery.ShowDialog();
                    }
                    else
                    {
                        messageOK(string.Format(Messages.M0012, message1, message2));
                    }
                    if (printQuery.ClosedResult == frmPrintQuery.ClosedType.Preview)
                    {
                        executePrint(PrintType.Preview, mitumoriNo);
                    }
                    else if (printQuery.ClosedResult == frmPrintQuery.ClosedType.Print)
                    {
                        executePrint(PrintType.OutPut, mitumoriNo);
                    }
                    btnCancel_Click(null, null);
                }
            }
            flgSaving = false;
        }
        #endregion

        #region 見積ヘッダ登録・更新SQL生成処理
        /// <summary>
        /// 見積ヘッダ登録・更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createHeaderRegistSql(ref string mitumoriNo, DateTime registerDate)
        {
            string sql = string.Empty;

            string mitumoriHizuke = string.Empty;
            if (!string.IsNullOrEmpty(txtEstimateDateYears.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateMonth.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateDays.Text))
            {
                mitumoriHizuke = txtEstimateDateYears.Text;
                mitumoriHizuke += "-" + (txtEstimateDateMonth.Text.Length == 1 ? "0" : string.Empty) + txtEstimateDateMonth.Text;
                mitumoriHizuke += "-" + (txtEstimateDateDays.Text.Length == 1 ? "0" : string.Empty) + txtEstimateDateDays.Text;
            }
            string mitumoriKubun = Convert.ToString(cmbEstimateType.SelectedValue);
            string tantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);
            string chihouCode = string.Empty;
            string chikuCode = string.Empty;
            string tokuisakiCode = txtCustomerCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiNameOption = txtCustomerNameOption.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string jigyousyoName = cmbOffices.Text;
            string jigyousyoNameOption = txtOfficesNameOption.Text;
            string tokuisakiTantousya = txtCustomerPersonnel.Text;
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;
            string zeiDispType = Convert.ToString(cmbTaxDispType.SelectedValue);
            string nouki = txtDelivery.Text;
            string torihikiJouken = txtTradingConditions.Text;
            string yuukouKigen = txtExpirationDateDays.Text;
            string ukewatasiBasyo1 = txtDeliveryPlace1.Text;
            string ukewatasiBasyo2 =string.Empty;
            DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = tokuisakiMaster.getTokuisakiInfo(txtCustomerCode.Text, Convert.ToString(cmbOffices.SelectedValue));
            if (tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
            }
            if (rdoNew.Checked)
            {
                // 見積No採番
                mitumoriNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getMitumoriNo() + 1).ToString(), txtEstimateNo.MaxLength);

                // 見積ヘッダの登録SQL生成
                sql += "INSERT INTO mitumori_header ";
                sql += "( ";
                sql += "  mitumoriNo ";
                sql += ", mitumoriHizuke ";
                sql += ", mitumoriKubun ";
                sql += ", tantousyaCode ";
                sql += ", chihouCode ";
                sql += ", chikuCode ";
                sql += ", tokuisakiCode ";
                sql += ", tokuisakiName ";
                sql += ", tokuisakiNameOption ";
                sql += ", tokuisakiKanaName ";
                sql += ", jigyousyoCode ";
                sql += ", jigyousyoName ";
                sql += ", jigyousyoNameOption ";
                sql += ", tokuisakiTantousayName ";
                sql += ", kenmei1 ";
                sql += ", kenmei2 ";
                sql += ", zeiDispType ";
                sql += ", nouki ";
                sql += ", torihikiJouken ";
                sql += ", yuukouKigen ";
                sql += ", ukewatasiBasyo1 ";
                sql += ", ukewatasiBasyo2 ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + mitumoriNo + "' ";
                sql += "," + (string.IsNullOrEmpty(mitumoriHizuke) ? "NULL " : "'" + mitumoriHizuke + "' ");
                sql += "," + "'" + mitumoriKubun + "' ";
                sql += "," + "'" + tantousyaCode + "' ";
                sql += "," + "'" + chihouCode + "' ";
                sql += "," + "'" + chikuCode + "' ";
                sql += "," + "'" + tokuisakiCode + "' ";
                sql += "," + "'" + tokuisakiName + "' ";
                sql += "," + "'" + tokuisakiNameOption + "' ";
                sql += "," + "'" + tokuisakiKanaName + "' ";
                sql += "," + "'" + jigyousyoCode + "' ";
                sql += "," + "'" + jigyousyoName + "' ";
                sql += "," + "'" + jigyousyoNameOption + "' ";
                sql += "," + "'" + tokuisakiTantousya + "' ";
                sql += "," + "'" + kenmei1 + "' ";
                sql += "," + "'" + kenmei2 + "' ";
                sql += "," + "'" + "" + "' ";
                sql += "," + "'" + nouki + "' ";
                sql += "," + "'" + torihikiJouken + "' ";
                sql += "," + "'" + yuukouKigen + "' ";
                sql += "," + "'" + ukewatasiBasyo1 + "' ";
                sql += "," + "'" + ukewatasiBasyo2 + "' ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 見積ヘッダの更新SQL生成
                sql = "UPDATE mitumori_header SET ";
                sql += "  mitumoriNo = '" + mitumoriNo + "' ";
                sql += ", mitumoriHizuke = " + (string.IsNullOrEmpty(mitumoriHizuke) ? "NULL " : "'" + mitumoriHizuke + "' ");
                sql += ", mitumoriKubun = '" + mitumoriKubun + "' ";
                sql += ", tantousyaCode = '" + tantousyaCode + "' ";
                sql += ", chihouCode = '" + chihouCode + "' ";
                sql += ", chikuCode = '" + chikuCode + "' ";
                sql += ", tokuisakiCode = '" + tokuisakiCode + "' ";
                sql += ", tokuisakiName = '" + tokuisakiName + "' ";
                sql += ", tokuisakiNameOption = '" + tokuisakiNameOption + "' ";
                sql += ", tokuisakiKanaName = '" + tokuisakiKanaName + "' ";
                sql += ", jigyousyoCode = '" + jigyousyoCode + "' ";
                sql += ", jigyousyoName = '" + jigyousyoName + "' ";
                sql += ", jigyousyoNameOption = '" + jigyousyoNameOption + "' ";
                sql += ", tokuisakiTantousayName = '" + tokuisakiTantousya + "' ";
                sql += ", kenmei1 = '" + kenmei1 + "' ";
                sql += ", kenmei2 = '" + kenmei2 + "' ";
                sql += ", zeiDispType = '" + zeiDispType + "' ";
                sql += ", nouki = '" + nouki + "' ";
                sql += ", torihikiJouken = '" + torihikiJouken + "' ";
                sql += ", yuukouKigen = '" + yuukouKigen + "' ";
                sql += ", ukewatasiBasyo1 = '" + ukewatasiBasyo1 + "' ";
                sql += ", ukewatasiBasyo2 = '" + ukewatasiBasyo2 + "' ";
                sql += ", kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '' ";
                sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
            }
            else
            {
                // 見積ヘッダの論理削除SQL生成
                sql = "UPDATE mitumori_header SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
            }

            return sql;
        }
        #endregion

        #region 見積ボディ登録・更新SQL生成処理
        /// <summary>
        /// 見積ボディ登録・更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createBodyRegistSql(string mitumoriNo, DateTime registerDate)
        {
            List<string> sqlBodys = new List<string>();
            string sql = string.Empty;

            if (rdoDelete.Checked)
            {
                // 見積ボディの論理削除SQL生成
                sql = "UPDATE mitumori_body SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
                sqlBodys.Add(sql);
            }
            else
            {
                // 見積ボディの登録・更新SQL生成
                string itemCd = string.Empty;
                string itemNm1 = string.Empty;
                string itemNm2 = string.Empty;
                string suryo = string.Empty;
                string unit = string.Empty;
                string tanka = string.Empty;
                string kingaku = string.Empty;
                string selectCommand = string.Empty;
                int rowNo = 0;
                DataTable selectRes;
                for (int i = 0; i < grdEstimateDetails.Rows.Count; i++)
                {
                    if (checkEmptyRow(i))
                    {
                        break;
                    }

                    itemCd = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmItemCode.DisplayIndex].Value);
                    itemNm1 = Convert.ToString(grdEstimateDetails.Rows[i].Cells[clmItemName.DisplayIndex].Value);
                    itemNm2 = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmItemName.DisplayIndex].Value);
                    suryo = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmQuantity.DisplayIndex].Value);
                    unit = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmUnit.DisplayIndex].FormattedValue);
                    tanka = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmBid.DisplayIndex].Value);
                    kingaku = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmAmount.DisplayIndex].Value);
                    rowNo = ((int)(i / grdEstimateDetails.RowSegmentCount) + 1);

                    selectCommand = "SELECT 1 FROM mitumori_body ";
                    selectCommand += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
                    selectCommand += "AND rowNo = " + rowNo;
                    selectRes = mitumoriDataSelectDb.executeSelect(selectCommand, !rdoNew.Checked);
                    if (selectRes != null && selectRes.Rows.Count > 0)
                    {
                        // 同一行番号のデータが登録済みのため更新処理
                        sql = "UPDATE mitumori_body SET ";
                        sql += "  mitumoriNo = " + "'" + mitumoriNo + "' ";
                        sql += ", rowNo = " + rowNo + " ";
                        sql += ", shouhinCode = '" + itemCd + "' ";
                        sql += ", shouhinName1 = '" + itemNm1 + "' ";
                        sql += ", shouhinName2 = '" + itemNm2 + "' ";
                        sql += ", suryo = " + (string.IsNullOrEmpty(suryo) ? "null" : Convert.ToDecimal(suryo).ToString()) + " ";
                        sql += ", tani = '" + unit + "' ";
                        sql += ", tanka = " + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                        sql += ", kingaku = " + (string.IsNullOrEmpty(kingaku) ? "null" : Convert.ToDecimal(kingaku).ToString()) + " ";
                        sql += ", kousinNichizi = '" + registerDate + "' ";
                        sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                        sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
                        sql += "AND rowNo = " + rowNo;
                    }
                    else
                    {
                        // 同一行番号のデータが未登録のため登録処理
                        sql = "INSERT INTO mitumori_body ";
                        sql += "( ";
                        sql += "  mitumoriNo ";
                        sql += ", rowNo ";
                        sql += ", shouhinCode ";
                        sql += ", shouhinName1 ";
                        sql += ", shouhinName2 ";
                        sql += ", suryo ";
                        sql += ", tani ";
                        sql += ", tanka ";
                        sql += ", kingaku ";
                        sql += ", kousinNichizi ";
                        sql += ", kanriKubun ";
                        sql += ") ";
                        sql += "VALUES ";
                        sql += "( ";
                        sql += "'" + mitumoriNo + "' ";
                        sql += "," + rowNo + " ";
                        sql += "," + "'" + itemCd + "' ";
                        sql += "," + "'" + itemNm1 + "' ";
                        sql += "," + "'" + itemNm2 + "' ";
                        sql += "," + (string.IsNullOrEmpty(suryo) ? "null" : Convert.ToDecimal(suryo).ToString()) + " ";
                        sql += "," + "'" + unit + "' ";
                        sql += "," + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(kingaku) ? "null" : Convert.ToDecimal(kingaku).ToString()) + " ";
                        sql += "," + "'" + registerDate + "' ";
                        sql += "," + "'' ";
                        sql += ") ";
                    }
                    sqlBodys.Add(sql);

                    i++;
                }

                // 今回登録以外のデータを削除
                sql = "DELETE FROM mitumori_body ";
                sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
                sql += "AND rowNo > " + rowNo;

                sqlBodys.Add(sql);
            }

            return sqlBodys;
        }
        #endregion

        #region 見積フッタ登録・更新SQL生成処理
        /// <summary>
        /// 見積フッタ登録・更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createFooterRegistSql(string mitumoriNo, DateTime registerDate)
        {
            string sql = string.Empty;

            if (rdoDelete.Checked)
            {
                // 見積フッタの論理削除SQL生成
                sql = "UPDATE mitumori_footer SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '"+ Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
            }
            else
            {
                DBCommon dbCommon = new DBCommon();
                decimal? kingaku = null;
                string selectCommand = string.Empty;
                decimal? footerShouhiZei = null;
                decimal? footerKingaku = null;
                decimal? footerGoukei = null;
                decimal? rate = (decimal?)kanriMaster.getNowZeiritu();
                string strFooterShouhiZei = string.Empty;
                string strFooterKingaku = string.Empty;
                string strFooterGoukei = string.Empty;
                for (int i = 0; i < grdEstimateDetails.Rows.Count; i++)
                {
                    kingaku = getDbNumberValue(grdEstimateDetails.Rows[i + 1].Cells[clmAmount.DisplayIndex].Value);
                    if (!string.IsNullOrEmpty(Convert.ToString(kingaku)))
                    {
                        if (footerShouhiZei == null) footerShouhiZei = decimal.Zero;
                        if (footerKingaku == null) footerKingaku = decimal.Zero;
                        // TODO:端数処理
                        footerShouhiZei += Convert.ToDecimal(Math.Round(Convert.ToDouble((kingaku * rate / 100).ToString()), MidpointRounding.AwayFromZero));
                        footerKingaku += kingaku;
                    }

                    i++;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(footerKingaku)))
                {
                    footerGoukei = footerShouhiZei + footerKingaku;
                }

                strFooterShouhiZei = Convert.ToString(footerShouhiZei);
                strFooterKingaku = Convert.ToString(footerKingaku);
                strFooterGoukei = Convert.ToString(footerGoukei);

                if (rdoNew.Checked)
                {
                    // 見積フッタの登録SQL生成
                    sql += "INSERT INTO mitumori_footer ";
                    sql += "( ";
                    sql += "  mitumoriNo ";
                    sql += ", shouhizei ";
                    sql += ", kingaku ";
                    sql += ", goukei ";
                    sql += ", kousinNichizi ";
                    sql += ", kanriKubun ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "'" + mitumoriNo + "' ";
                    sql += "," + (string.IsNullOrEmpty(strFooterShouhiZei) ? "null" : strFooterShouhiZei) + " ";
                    sql += "," + (string.IsNullOrEmpty(strFooterKingaku) ? "null" : strFooterKingaku) + " ";
                    sql += "," + (string.IsNullOrEmpty(strFooterGoukei) ? "null" : strFooterGoukei) + " ";
                    sql += "," + "'" + registerDate + "' ";
                    sql += "," + "'' ";
                    sql += ") ";
                }
                else
                {
                    // 見積フッタの更新SQL生成
                    sql = "UPDATE mitumori_footer SET ";
                    sql += "  mitumoriNo = '" + mitumoriNo + "' ";
                    sql += ", shouhizei = " + (string.IsNullOrEmpty(strFooterShouhiZei) ? "null" : strFooterShouhiZei) + " ";
                    sql += ", kingaku = " + (string.IsNullOrEmpty(strFooterKingaku) ? "null" : strFooterKingaku) + " ";
                    sql += ", goukei = " + (string.IsNullOrEmpty(strFooterGoukei) ? "null" : strFooterGoukei) + " ";
                    sql += ", kousinNichizi = '" + registerDate + "' ";
                    sql += ", kanriKubun = '' ";
                    sql += "WHERE mitumoriNo = '" + mitumoriNo + "' ";
                }

            }

            return sql;
        }
        #endregion

        #region 受注ヘッダ更新SQL生成処理
        /// <summary>
        /// 受注ヘッダ更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="ordersDocumentNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createJuchuHeaderRegistSql(string mitumoriNo, string ordersDocumentNo, DateTime registerDate)
        {
            string sql = string.Empty;

            // 受注ヘッダの更新SQL生成
            sql = "UPDATE juchu_header SET ";
            sql += "  mitumoriNo = '" + mitumoriNo + "' ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += ", kanriKubun = '' ";
            sql += "WHERE denpyoNo = '" + ordersDocumentNo + "' ";

            return sql;
        }
        #endregion

        #region 管理マスタ更新SQL生成処理
        /// <summary>
        /// 管理マスタ更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createKanriMasterRegistSql(string mitumoriNo, DateTime registerDate)
        {
            string sql = string.Empty;

            sql = "UPDATE kanri_master SET ";
            sql += "  koumoku1 = '" + mitumoriNo + "' ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += "WHERE kanriCode = '" + Consts.KanriCodes.MitumoriNo + "' ";

            return sql;
        }
        #endregion

        #region 数値項目のDB登録値取得処理
        /// <summary>
        /// 数値項目のDB登録値取得処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private decimal? getDbNumberValue(object value)
        {
            decimal? ret = null;
            decimal wkRet = decimal.Zero;

            if (!string.IsNullOrEmpty(Convert.ToString(value)) &&
                Decimal.TryParse(Convert.ToString(value), out wkRet))
            {
                ret = wkRet;
            }

            return ret;
        }
        #endregion

        #region 見積データ設定処理
        /// <summary>
        /// 見積データ設定処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        private bool setMitumoriData(string mitumoriNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            string sqlHeaderCommand = string.Empty;
            string sqlBodyCommand = string.Empty;
            string sqlFooterCommand = string.Empty;
            mitumoriNo = commonLogic.getZeroBuriedNumberText(mitumoriNo, txtEstimateNo.MaxLength);

            // 見積Noから見積ヘッダデータを取得
            sqlHeaderCommand += "SELECT * FROM mitumori_header WHERE mitumoriNo = '" + mitumoriNo + "' ";

            // トランザクション開始処理を実行
            mitumoriDataSelectDb.startTransaction();
            DataTable headerData = mitumoriDataSelectDb.executeSelect(sqlHeaderCommand, !rdoNew.Checked);
            DataTable bodyData;
            DataTable footerData;

            // 取得時にエラーが発生した場合
            if (mitumoriDataSelectDb.DBRef < 0)
            {
                errorOK(string.Format(Messages.M0027, "見積データ"));
                return false;
            }

            // 見積ヘッダデータが存在する場合
            if (headerData != null && headerData.Rows.Count > 0)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(headerData.Rows[0][DBFileLayout.MitumoriHeaderFile.dcKanriKubun])))
                {
                    string msg1 = rdoCorrection.Checked ? "訂正" : rdoReference.Checked ? "参照" : "削除";
                    errorOK(string.Format(Messages.M0013, "削除", "見積データ", msg1));
                    txtEstimateNo.Text = string.Empty;
                    return false;
                }
                // 見積ボディデータおよび見積フッタデータを取得
                sqlBodyCommand += "SELECT * FROM mitumori_body WHERE mitumoriNo = '" + mitumoriNo + "' ORDER BY rowNo ";
                sqlFooterCommand += "SELECT * FROM mitumori_footer WHERE mitumoriNo = '" + mitumoriNo + "' ";
                //bodyData = mitumoriDataSelectDb.executeSelect(sqlBodyCommand, !rdoNew.Checked);
                //footerData = mitumoriDataSelectDb.executeSelect(sqlFooterCommand, !rdoNew.Checked);
                bodyData = mitumoriDataSelectDb.executeSelect(sqlBodyCommand, false);
                footerData = mitumoriDataSelectDb.executeSelect(sqlFooterCommand, false);
            }
            // 見積ヘッダデータが存在しない場合
            else
            {
                // エラーメッセージを出力して処理を終了
                errorOK(string.Format(Messages.M0003, "見積No"));
                return false;
            }

            grdEstimateDetails.Rows.Clear();
            // 単位コンボボックス設定
            setUnitCmb();

            // 取得した見積ヘッダデータを画面項目に設定します
            DataRow dRow = headerData.Rows[0];
            txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiCode]);
            txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiName]);
            txtCustomerNameOption.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiNameOption]);
            txtCustomerKanaName.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiKanaName]);
            setOfficesCmb(txtCustomerCode.Text, Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcJigyousyoCode]));
            txtOfficesNameOption.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcJigyousyoNameOption]);
            if (Consts.OthersCustomerCode.Equals(txtCustomerCode.Text)) cmbOffices.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcJigyousyoName]);
            txtCustomerPersonnel.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiTantousayName]);
            if (!rdoNew.Checked) txtEstimateNo.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcMitumoriNo]);
            txtSubject1.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcKenmei1]);
            txtSubject2.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcKenmei2]);
            cmbTaxDispType.SelectedValue = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcZeiDispType]);
            if (!string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcMitumoriHizuke])))
            {
                dtpEstimateDate.Value = Convert.ToDateTime(dRow[DBFileLayout.MitumoriHeaderFile.dcMitumoriHizuke]);
            }
            else
            {
                txtEstimateDateYears.Text = string.Empty;
                txtEstimateDateMonth.Text = string.Empty;
                txtEstimateDateDays.Text = string.Empty;
            }
            txtDelivery.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcNouki]);
            cmbEstimateType.SelectedValue = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcMitumoriKubun]);
            cmbPersonnel.SelectedValue = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTantousyaCode]);
            txtTradingConditions.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTorihikiJouken]);
            txtExpirationDateDays.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcYuukouKigen]);
            txtDeliveryPlace1.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcUkewatasiBasyo1]);

            // 取得した見積ボディデータを見積グリッドに設定します
            grdEstimateDetails.Rows.Clear();
            int gridRowIndex = 0;
            string unitValue;
            string unitText;
            DataGridViewRow topRow;
            DataGridViewRow midRow;
            // 単位コンボボックス設定
            setUnitCmb();
            DataTable unitDt = (DataTable)clmUnit.DataSource;
            for (int i = 0; i < bodyData.Rows.Count; i++)
            {
                gridRowIndex = i * grdEstimateDetails.RowSegmentCount;
                // 見積グリッドへ空行を追加
                addEmptyGridRow();
                topRow = grdEstimateDetails.Rows[gridRowIndex];
                midRow = grdEstimateDetails.Rows[gridRowIndex + 1];
                dRow = bodyData.Rows[i];

                // 上段行への値設定
                topRow.Cells[clmItemName.DisplayIndex].Value = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcShouhinName1]);
                topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();

                // 下段行への値設定
                midRow.Cells[clmRowNo.DisplayIndex].Value = (i + 1);
                midRow.Cells[clmItemCode.DisplayIndex].Value = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcShouhinCode]);
                midRow.Cells[clmItemName.DisplayIndex].Value = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcShouhinName2]);
                midRow.Cells[clmQuantity.DisplayIndex].Value = getDbNumberValue(dRow[DBFileLayout.MitumoriBodyFile.dcSuryo]);
                midRow.Cells[clmBid.DisplayIndex].Value = getDbNumberValue(dRow[DBFileLayout.MitumoriBodyFile.dcTanka]);
                midRow.Cells[clmAmount.DisplayIndex].Value = getDbNumberValue(dRow[DBFileLayout.MitumoriBodyFile.dcKingaku]);
                unitText = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcTani]);
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
                midRow.Cells[clmUnit.DisplayIndex].Value = unitValue;
                midRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            }

            // 見積グリッドへの不足分行追加処理実行
            addInsufficientEmptyGridRow();

            //　見積グリッドの最終行が空白行でない場合、空白行を追加
            addLastEmptyRow();
            grdEstimateDetails.CurrentCell = null;
            grdEstimateDetails.Refresh();

            lblEstimateTotalAmount.Text = getTotalAmount().ToString("#,##0");

            // 検索実行済みフラグにtrueを設定
            flgSearch = true;

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
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
            if (grdEstimateDetails.CurrentCell != null &&
                copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == grdEstimateDetails.CurrentCell.RowIndex || copyGridBtmRow.Index == grdEstimateDetails.CurrentCell.RowIndex))
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

            DataGridViewRow topRow = grdEstimateDetails.Rows[topRowIndex];
            DataGridViewRow btmRow = grdEstimateDetails.Rows[topRowIndex + 1];

            string itemCd = Convert.ToString(btmRow.Cells[clmItemCode.DisplayIndex].Value);       // 商品ｺｰﾄﾞ
            string itemNm1 = Convert.ToString(topRow.Cells[clmItemName.DisplayIndex].Value);    // 商品名(上段)
            string itemNm2 = Convert.ToString(btmRow.Cells[clmItemName.DisplayIndex].Value);    // 商品名(下段)
            string suryo = Convert.ToString(btmRow.Cells[clmQuantity.DisplayIndex].Value);      // 数量
            string tani = Convert.ToString(btmRow.Cells[clmUnit.DisplayIndex].Value);           // 単位
            string tanka = Convert.ToString(btmRow.Cells[clmBid.DisplayIndex].Value);           // 単価
            string kingaku = Convert.ToString(btmRow.Cells[clmAmount.DisplayIndex].Value);      // 金額

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

        #region 処理モード別変更チェック処理
        private bool checkDataChange()
        {
            bool result = false;
            // 処理モード別の変更チェック処理
            if (rdoNew.Checked)
            {
                string estimateDate = commonLogic.convertDateTime(txtEstimateDateYears.Text, txtEstimateDateMonth.Text, txtEstimateDateDays.Text).ToString("yyyy/MM/dd");
                if (!string.IsNullOrEmpty(txtEstimateNo.Text) ||
                    !estimateDate.Equals(syoriDate.ToString("yyyy/MM/dd"))  ||
                    !string.IsNullOrEmpty(cmbEstimateType.Text) ||
                    !string.IsNullOrEmpty(cmbPersonnel.Text) ||
                    !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                    !string.IsNullOrEmpty(txtCustomerName.Text) ||
                    !string.IsNullOrEmpty(txtCustomerKanaName.Text) ||
                    !string.IsNullOrEmpty(txtCustomerPersonnel.Text) ||
                    !string.IsNullOrEmpty(txtSubject1.Text) ||
                    !string.IsNullOrEmpty(txtSubject2.Text) ||
                    !string.IsNullOrEmpty(txtDelivery.Text) ||
                    !string.IsNullOrEmpty(txtTradingConditions.Text) ||
                    !string.IsNullOrEmpty(txtDeliveryPlace1.Text) ||
                    !checkAllEmptyRow())
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
            if (!flgSaving && activeRadioButton != null && activeRadioButton.Name == radio.Name) return;
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

        #region 画面終了時イベント
        /// <summary>
        /// 画面終了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEstimateInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 処理モード別の変更チェック処理
            if (checkDataChange())
            {
                string queryMeaasage = string.Empty;
                string str1 = "終了してよろしいですか？";
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
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region グリッドセルの入力開始処理
        /// <summary>
        /// グリッドセルの入力開始処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEstimateDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
                // 該当位置のセルの場合
                if ((dgv.CurrentCell.RowIndex % dgv.RowSegmentCount != 0) && (dgv.CurrentCell.ColumnIndex == clmUnit.DisplayIndex))
                {
                    // 最大入力桁数を設定
                    ((DataGridViewComboBoxEditingControl)e.Control).MaxLength = 3;
                    // DropDownStyleをドロップダウンに変更
                    ((DataGridViewComboBoxEditingControl)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                    // Enrerキーイベントを捕まえるためのイベントを削除
                    ((DataGridViewComboBoxEditingControl)e.Control).PreviewKeyDown -= new PreviewKeyDownEventHandler(comboBoxCell_PreviewKeyDown);
                    // Enrerキーイベントを捕まえるためのイベントを登録
                    ((DataGridViewComboBoxEditingControl)e.Control).PreviewKeyDown += new PreviewKeyDownEventHandler(comboBoxCell_PreviewKeyDown);
                }
            }
            else if (e.Control is DataGridViewTextBoxEditingControl)
            {
                // 入力制御イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyPress -= new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);
                ((DataGridViewTextBoxEditingControl)e.Control).KeyPress -= new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                // 商品ｺｰﾄﾞ列の場合
                if (activeControlInfo.ClmIndex == clmItemCode.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);
                }
                else if (activeControlInfo.ClmIndex == clmQuantity.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = quantityIntegerLength;
                    activeControlInfo.DecimalLength = quantityDecimalLength;
                }
                else if (activeControlInfo.ClmIndex == clmBid.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = bidIntegerLength;
                    activeControlInfo.DecimalLength = bidDecimalLength;
                }
                else if (activeControlInfo.ClmIndex == clmAmount.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = amountIntegerLength;
                    activeControlInfo.DecimalLength = amountDecimalLength;
                }
                // キー押下イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown -= new KeyEventHandler(inputObject_KeyDown);
                // キー押下イベントを追加
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown += new KeyEventHandler(inputObject_KeyDown);
            }
            setSearchButtonEnabled();
        }
        #endregion

        #region DataGridViewComboBoxEditingControlのキーイベントを処理する
        /// <summary>
        /// DataGridViewComboBoxEditingControlのキーイベントを処理する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comboBoxCell_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Enterキーの場合
            if (e.KeyCode == Keys.Enter)
            {
                // カレントセルをバックアップ
                DataGridViewCell curCell = ((DataGridViewComboBoxEditingControl)sender).EditingControlDataGridView.CurrentCell;
                // カレントセルをクリア
                ((DataGridViewComboBoxEditingControl)sender).EditingControlDataGridView.CurrentCell = null;
                // カレントセルを再設定(これでCellValidatingイベントが発行される)
                ((DataGridViewComboBoxEditingControl)sender).EditingControlDataGridView.CurrentCell = curCell;
            }
        }
        #endregion

        #region DataGridViewのCellValidatingイベントを処理する
        /// <summary>
        /// DataGridViewのCellValidatingイベントを処理する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEstimateDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CustomDataGridView dgv = (CustomDataGridView)sender;
            if (rdoReference.Checked || rdoDelete.Checked) return;
            if (dgv.CurrentCell.ReadOnly) return;

            // 単位セルの場合
            if ((dgv.CurrentCell.RowIndex % dgv.RowSegmentCount != 0) && (dgv.CurrentCell.ColumnIndex == clmUnit.DisplayIndex))
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
                    inputItemCode = commonLogic.getZeroBuriedNumberText(inputText, clmItemCode.MaxInputLength);
                }
                // 入力した商品ｺｰﾄﾞが存在しない場合
                if (!string.IsNullOrEmpty(inputItemCode) && !shouhinMaster.checkExistShouhinInfo(inputItemCode))
                {
                    errorOK(string.Format(Messages.M0003, "商品ｺｰﾄﾞ"));
                    e.Cancel = true;
                }
            }
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
                DataTable dt = ((DataTable)clmUnit.DataSource);
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
            // セルのValueを更新
            ((DataGridViewComboBoxCell)dgv.Rows[rowIndex].Cells[colIndex]).Value = newValue;
        }
        #endregion

        #region 見積グリッドの入力確定処理
        /// <summary>
        /// 見積グリッドの入力確定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEstimateDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string inputValue = Convert.ToString(grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
            RecalcMeisaiTYpe type = RecalcMeisaiTYpe.All;
            // 数量列の場合
            if (e.ColumnIndex == clmQuantity.DisplayIndex)
            {
                decimal quantity = decimal.Zero;
                if (decimal.TryParse(inputValue, out quantity))
                {
                    grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = quantity.ToString(quantityFormat);
                }
                else
                {
                    grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                type = RecalcMeisaiTYpe.QuantityInput;
            }
            // 単価列の場合
            else if (e.ColumnIndex == clmBid.DisplayIndex)
            {
                decimal bid = decimal.Zero;
                if (decimal.TryParse(inputValue, out bid))
                {
                    grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bid.ToString(bidFormat);
                }
                else
                {
                    grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                type = RecalcMeisaiTYpe.BidInput;
            }
            // 金額列の場合
            else if (e.ColumnIndex == clmAmount.DisplayIndex)
            {
                decimal amount = decimal.Zero;
                if (decimal.TryParse(inputValue, out amount))
                {
                    grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount.ToString(amountFormat);
                }
                else
                {
                    grdEstimateDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
            // 商品ｺｰﾄﾞ列の場合
            else if (e.ColumnIndex == clmItemCode.DisplayIndex && !flgDeletingRow && !flgSettingEnable)
            {
                if (activeControlInfo.CancelEdit) return;
                string inputItemCode = inputValue;
                decimal dec;
                if (decimal.TryParse(inputValue, out dec))
                {
                    inputItemCode = commonLogic.getZeroBuriedNumberText(inputValue, clmItemCode.MaxInputLength);
                }
                // 商品情報の再設定
                setShouhinInfo(string.Empty, string.Empty, string.Empty, inputItemCode);
            }
            // 数量または単価列の場合
            if (e.ColumnIndex == clmQuantity.DisplayIndex ||
                e.ColumnIndex == clmBid.DisplayIndex)
            {
                decimal beforeValue = decimal.Zero;
                decimal afterValue = decimal.Zero;
                decimal.TryParse(beforeCellValue, out beforeValue);
                decimal.TryParse(inputValue, out afterValue);

                if (beforeValue != afterValue)
                {
                    // 金額の再計算処理を実行
                    recalcMeisai(e.RowIndex, type);
                }
            }

            //　見積グリッドの最終行が空白行でない場合、空白行を追加
            addLastEmptyRow();

            lblEstimateTotalAmount.Text = getTotalAmount().ToString("#,##0");
        }
        #endregion

        #region 全明細の再計算処理
        /// <summary>
        /// 全明細の再計算処理
        /// </summary>
        private void recalcMeisaiAll()
        {
            for (int i = 0; i < grdEstimateDetails.Rows.Count; i++)
            {
                // 下段行の場合
                if (i % grdEstimateDetails.RowSegmentCount != 0)
                {
                    // 金額の再計算処理を実行
                    recalcMeisai(i, RecalcMeisaiTYpe.All);
                }
            }
        }
        #endregion

        #region 明細の再計算処理
        /// <summary>
        /// 明細の再計算処理
        /// </summary>
        private void recalcMeisai(int btmRowIndex, RecalcMeisaiTYpe type)
        {
            // 金額の再計算
            string strSuryo = Convert.ToString(grdEstimateDetails.Rows[btmRowIndex].Cells[clmQuantity.Name].Value);
            string strTanka = Convert.ToString(grdEstimateDetails.Rows[btmRowIndex].Cells[clmBid.Name].Value);
            string strAmount = string.Empty;
            decimal suryo = decimal.Zero;
            decimal tanka = decimal.Zero;
            decimal amount = decimal.Zero;
            switch (type)
            {
                case RecalcMeisaiTYpe.All:
                    if (!string.IsNullOrEmpty(strSuryo) &&
                        !string.IsNullOrEmpty(strTanka) &&
                        decimal.TryParse(strSuryo, out suryo) &&
                        decimal.TryParse(strTanka, out tanka))
                    {
                        amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, suryo * tanka);
                        grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = amount.ToString(amountFormat);
                    }
                    else
                    {
                        grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
                    }
                    break;
                case RecalcMeisaiTYpe.QuantityInput:
                    // 受注金額の再設定
                    if (string.IsNullOrEmpty(strTanka))
                    {
                    }
                    else if (string.IsNullOrEmpty(strSuryo))
                    {
                        grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
                    }
                    else
                    {
                        decimal.TryParse(strSuryo, out suryo);
                        decimal.TryParse(strTanka, out tanka);
                        amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, suryo * tanka);
                        grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = amount.ToString(amountFormat);
                    }
                    break;
                case RecalcMeisaiTYpe.BidInput:
                    // 受注金額の再設定
                    if (string.IsNullOrEmpty(strSuryo) || string.IsNullOrEmpty(strTanka))
                    {
                        grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
                    }
                    else
                    {
                        decimal.TryParse(strSuryo, out suryo);
                        decimal.TryParse(strTanka, out tanka);
                        amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, suryo * tanka);
                        grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = amount.ToString(amountFormat);
                    }
                    break;
            }
        }
        #endregion

        #region 必須入力チェック
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;
            string errorItem = string.Empty;
            bool flgHeadError = false;

            if (string.IsNullOrEmpty(cmbEstimateType.Text))
            {
                errorItem = lblEstimateType.Text;
            }
            else if (string.IsNullOrEmpty(cmbPersonnel.Text))
            {
                errorItem = lblPersonnel.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                errorItem = lblCustomerCd.Text;
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                errorItem = lblCustomerName.Text;
            }
            else if (string.IsNullOrEmpty(txtDelivery.Text))
            {
                errorItem = lblDelivery.Text;
            }
            else if (string.IsNullOrEmpty(txtExpirationDateDays.Text))
            {
                errorItem = lblExpirationDate.Text;
            }

            if (!string.IsNullOrEmpty(errorItem)) flgHeadError = true;

            string itemCode;
            for (int i = 0; i < grdEstimateDetails.Rows.Count; i++)
            {
                if (i % grdEstimateDetails.RowSegmentCount != 0) continue;

                // エラーステータスを初期化
                grdEstimateDetails.Rows[i].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
                grdEstimateDetails.Rows[i + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();

                // ヘッダ項目でエラーが発生している場合
                if (flgHeadError) continue;

                // 空白行はチェック対象外
                if (checkEmptyRow(i)) continue;

                itemCode = Convert.ToString(grdEstimateDetails.Rows[i + 1].Cells[clmItemCode.Name].Value);
                if (string.IsNullOrEmpty(itemCode))
                {
                    grdEstimateDetails.Rows[i].Cells[clmRowStatus.Name].Value = GridErrorStatus.ItemCodeError.GetHashCode();
                    grdEstimateDetails.Rows[i + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.ItemCodeError.GetHashCode();
                    errorItem = clmItemCode.HeaderText + "、" + clmItemName.HeaderText;
                }
            }
            grdEstimateDetails.Refresh();

            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtEstimateNo.MaxLength = 8;            // 見積NO
            txtEstimateDateYears.MaxLength = 4;     // 見積日付(年)
            txtEstimateDateMonth.MaxLength = 2;     // 見積日付(月)
            txtEstimateDateDays.MaxLength = 2;      // 見積日付(日)
            cmbPersonnel.MaxLength = 10;            // 担当者
            txtCustomerCode.MaxLength = 5;          // 得意先ｺｰﾄﾞ
            txtCustomerName.MaxLength = 40;         // 得意先名
            txtCustomerNameOption.MaxLength = 3;
            txtCustomerKanaName.MaxLength = 80;     // 得意先カナ名
            cmbOffices.MaxLength = 10;              // 事業所
            txtOfficesNameOption.MaxLength = 3;
            txtCustomerPersonnel.MaxLength = 15;    // 得意先担当者名
            txtSubject1.MaxLength = 20;             // 件名１
            txtSubject2.MaxLength = 20;             // 件名２
            txtDelivery.MaxLength = 15;             // 納期
            txtTradingConditions.MaxLength = 15;    // 取引条件
            txtExpirationDateDays.MaxLength = 4;    // 有効期限(日)
            txtDeliveryPlace1.MaxLength = 20;       // 受渡場所１
            clmItemCode.MaxInputLength = 5;         // 商品ｺｰﾄﾞ
            clmItemName.MaxInputLength = 30;        // 商品名

            // 入力制御イベント設定
            txtEstimateNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 見積NO      :数字のみ入力可
            txtEstimateDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 見積日付(年):数字のみ入力可
            txtEstimateDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 見積日付(月):数字のみ入力可
            txtEstimateDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 見積日付(日):数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 得意先ｺｰﾄﾞ  :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);      // 得意先カナ名:全角カナのみ入力可
            txtExpirationDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 有効期限(日):数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
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
            if (!commonLogic.inputDigitalOnly_KeyPress(e))
            {
                showInputControlErrorMessage((Control)sender, "数字");
            }
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
            if (!commonLogic.inputEmKanaOnly_KeyPress(e))
            {
                showInputControlErrorMessage((Control)sender, "全角カナ");
            }
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
            if (!commonLogic.inputNumberOnly_KeyPress(e, (TextBox)sender, activeControlInfo.IntegerLength, activeControlInfo.DecimalLength))
            {
                showInputControlErrorMessage((Control)sender, "数値");
            }
        }
        #endregion

        #region 入力チェックエラー時のメッセージ出力処理
        /// <summary>
        /// 入力チェックエラー時のメッセージ出力
        /// </summary>
        /// <param name="target"></param>
        /// <param name="strPattern"></param>
        private void showInputControlErrorMessage(Control target, string strPattern)
        {
            //Control label = null;
            //if (target is CustomTextBox && ((CustomTextBox)target).LabelControl != null) label = ((CustomTextBox)target).LabelControl;
            //if (target is CustomComboBox && ((CustomComboBox)target).LabelControl != null) label = ((CustomComboBox)target).LabelControl;
            //if (label != null)
            //{
            //    errorOK(string.Format(Messages.M0022, label.Text, strPattern));
            //}
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

        #region 受注検索ボタン押下イベント
        /// <summary>
        /// 受注検索ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrdersSearch_Click(object sender, EventArgs e)
        {
            if (!btnOrdersSearch.Visible) return;
            CheckMessageType messageType = CheckMessageType.inputDataUpdateQuery;
            if ((rdoCorrection.Checked && !flgSearch) ||
                rdoReference.Checked ||
                (rdoDelete.Checked && !flgSearch))
            {
                messageType = CheckMessageType.None;
            }
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
        #endregion

        #region 受注データ設定処理
        /// <summary>
        /// 受注データ設定処理
        /// </summary>
        /// <param name="documentNo"></param>
        /// <param name="ordersNo"></param>
        /// <param name="inputObject"></param>
        /// <returns></returns>
        private bool setJuchuData(string documentNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            string sqlHeaderCommand = string.Empty;
            string sqlBodyCommand = string.Empty;

            // 伝票Noから受注ヘッダデータを取得
            sqlHeaderCommand += "SELECT * FROM juchu_header WHERE denpyoNo = '" + documentNo + "' ";

            // トランザクション開始済みの場合
            if (mitumoriDataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                mitumoriDataSelectDb.endTransaction();
            }
            // トランザクション開始処理を実行
            mitumoriDataSelectDb.startTransaction();
            DataTable headerData = mitumoriDataSelectDb.executeSelect(sqlHeaderCommand, true);

            // 取得時にエラーが発生した場合
            if (mitumoriDataSelectDb.DBRef < 0)
            {
                errorOK(string.Format(Messages.M0027, "受注データ"));
                return false;
            }
            DataTable bodyData;

            // 受注ヘッダデータが存在する場合
            if (headerData != null && headerData.Rows.Count > 0)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcKanriKubun])))
                {
                    errorOK(string.Format(Messages.M0013, "削除", "受注データ", "使用"));
                    return false;
                }
            }

            DataRow dRow = headerData.Rows[0];
            string juchuNoTop = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
            string juchuNoMid = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
            string juchuNoBtm = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            // 受注ボディデータを取得
            sqlBodyCommand += "SELECT * FROM juchu_body ";
            sqlBodyCommand += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            sqlBodyCommand += "AND juchunoMid = '" + juchuNoMid + "' ";
            sqlBodyCommand += "AND juchunoBtm = '" + juchuNoBtm + "' ";
            sqlBodyCommand += "ORDER BY rowNo ";
            bodyData = mitumoriDataSelectDb.executeSelect(sqlBodyCommand, false);

            // 取得した受注ヘッダデータを画面項目に設定します
            if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcDenpyoHizuke])))               // 見積日付
            {
                dtpEstimateDate.Text = string.Empty;
                dtpEstimateDate.Text = string.Empty;
                dtpEstimateDate.Text = string.Empty;
            }
            else
            {
                DateTime estimateDate = Convert.ToDateTime(dRow[DBFileLayout.JuchuHeaderFile.dcDenpyoHizuke]);
                dtpEstimateDate.Value = estimateDate.AddDays(1);
                dtpEstimateDate.Value = estimateDate;
            }
            cmbEstimateType.SelectedIndex = -1;                                                                         // 見積区分
            cmbPersonnel.SelectedValue = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTantousyaCode]);          // 担当者
            txtOrdersDocumentNo.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcDenpyoNo]);                 // 受注伝票No
            txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiCode]);                // 得意先コード
            txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);                // 得意先名
            txtCustomerKanaName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiKanaName]);        // 得意先カナ名
            setOfficesCmb(txtCustomerCode.Text, Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoCode]));  // 事業所
            if (Consts.OthersCustomerCode.Equals(txtCustomerCode.Text)) cmbOffices.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoName]);
            txtCustomerPersonnel.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiTantousayName]);  // 得意先担当者名
            txtSubject1.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcKenmei1]);                          // 件名１
            txtSubject2.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcKenmei2]);                          // 件名２
            txtDelivery.Text = string.Empty;                                                                            // 納期
            txtTradingConditions.Text = string.Empty;                                                                   // 取引条件
            txtDeliveryPlace1.Text = string.Empty;                                                                      // 受渡場所１

            // 取得した受注ボディデータを見積明細グリッドに設定します
            grdEstimateDetails.Rows.Clear();
            int gridRowIndex = 0;
            DataTable unitDt = (DataTable)clmUnit.DataSource;
            string unitValue;
            string unitText;
            DataGridViewRow topRow;
            DataGridViewRow btmRow;
            // 単位コンボボックス設定
            setUnitCmb();
            for (int i = 0; i < bodyData.Rows.Count; i++)
            {
                gridRowIndex = i * grdEstimateDetails.RowSegmentCount;
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
                topRow = grdEstimateDetails.Rows[gridRowIndex];
                btmRow = grdEstimateDetails.Rows[gridRowIndex + 1];
                dRow = bodyData.Rows[i];

                // 上段行への値設定
                // 商品名(上段)
                topRow.Cells[clmItemName.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShouhinName1]);
                // エラー状態
                topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                // 下段行への値設定
                // 商品ｺｰﾄﾞ
                btmRow.Cells[clmItemCode.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShouhinCode]);
                // 商品名(下段)
                btmRow.Cells[clmItemName.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShouhinName2]);
                // 数量
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuSuryo])))
                {
                    btmRow.Cells[clmQuantity.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuSuryo]).ToString(quantityFormat);
                }
                // 単位
                unitText = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuTani]);
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
                    unitValue = Convert.ToString(unitDt.Rows.Count + 1);
                    unitDt.Rows.Add(new object[] { unitValue, unitText });
                    unitDt.AcceptChanges();
                }
                btmRow.Cells[clmUnit.Name].Value = unitValue;
                // 単価
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuTanka])))
                {
                    btmRow.Cells[clmBid.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmBid.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuTanka]).ToString(bidFormat);
                }
                // 金額
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuKingaku])))
                {
                    btmRow.Cells[clmAmount.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuKingaku]).ToString(amountFormat);
                }
                btmRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;
            }
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 取得した受注ボディデータが初期表示件数未満の場合、不足データ分の空行を見積グリッドに追加します
            addInsufficientEmptyGridRow();
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();
            lblEstimateTotalAmount.Text = getTotalAmount().ToString("#,##0");
            grdEstimateDetails.CurrentCell = null;

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 見積グリッドへの空行追加処理
        /// <summary>
        /// 見積グリッドへの空行追加処理
        /// </summary>
        private void addEmptyGridRow()
        {
            insertEmptyGridRow(grdEstimateDetails.Rows.Count);
        }
        #endregion

        #region 見積グリッドへの空行挿入処理
        /// <summary>
        /// 見積グリッドへの空行挿入処理
        /// </summary>
        /// <param name="insertIndex"></param>
        private void insertEmptyGridRow(int insertIndex)
        {
            grdEstimateDetails.Rows.Insert(insertIndex);
            grdEstimateDetails.Rows[insertIndex].Cells[clmUnit.Name] = new DataGridViewTextBoxCell();
            grdEstimateDetails.Rows[insertIndex].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            grdEstimateDetails.Rows.Insert(insertIndex + 1);
            grdEstimateDetails.Rows[insertIndex + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
        }
        #endregion

        #region 見積グリッドへの不足分行追加処理
        /// <summary>
        /// 見積グリッドへの不足分行追加処理
        /// </summary>
        private void addInsufficientEmptyGridRow()
        {
            // 不足分の空行を見積グリッドに追加します
            for (int i = grdEstimateDetails.Rows.Count / grdEstimateDetails.RowSegmentCount; i < gridStartRowCount; i++)
            {
                // 見積グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 見積グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// <summary>
        /// 見積グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// </summary>
        private void addLastEmptyRow()
        {
            // 最終行が空行でない場合、行追加
            if (!checkEmptyRow(grdEstimateDetails.Rows.Count - 2))
            {
                // 見積グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 件名情報設定処理
        /// <summary>
        /// 件名情報設定処理
        /// </summary>
        /// <param name="kenmeiNo"></param>
        /// <returns></returns>
        private bool setKenmeiInfo(string kenmeiNo)
        {
            string kenmei1 = string.Empty;
            string kenmei2 = string.Empty;
            DBKenmeiMaster kenmeiMaster = new DBKenmeiMaster();
            List<DBFileLayout.KenmeiMasterFile> kenmeiInfo = kenmeiMaster.getKenmeiInfo(kenmeiNo, false);
            if (kenmeiInfo.Count > 0)
            {
                kenmei1 = kenmeiInfo[0].Kenmei1;
                kenmei2 = kenmeiInfo[0].Kenmei2;
            }
            txtSubject1.Text = kenmei1;
            txtSubject2.Text = kenmei2;
            return true;
        }
        #endregion

        #region グリッド行の初期化処理
        /// <summary>
        /// グリッド行の初期化処理
        /// </summary>
        /// <param name="gridRowIndex"></param>
        private void clearGridRow(int gridRowIndex)
        {
            int topRowIndex = gridRowIndex % grdEstimateDetails.RowSegmentCount == 0 ? gridRowIndex : gridRowIndex - 1;
            int btmRowIndex = topRowIndex + 1;

            // 上段行の初期化
            grdEstimateDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;

            // 下段行の初期化
            grdEstimateDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
            grdEstimateDetails.Rows[btmRowIndex].Cells[clmItemName.Name].Value = string.Empty;
            grdEstimateDetails.Rows[btmRowIndex].Cells[clmQuantity.Name].Value = null;
            grdEstimateDetails.Rows[btmRowIndex].Cells[clmUnit.Name].Value = string.Empty;
            grdEstimateDetails.Rows[btmRowIndex].Cells[clmBid.Name].Value = null;
            grdEstimateDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
        }
        #endregion

        #region 合計金額取得処理
        /// <summary>
        /// 合計金額取得処理
        /// </summary>
        /// <returns></returns>
        private decimal getTotalAmount()
        {
            decimal res = decimal.Zero;

            decimal amount = decimal.Zero;
            for (int i = 0; i < grdEstimateDetails.Rows.Count - 1; i++)
            {
                if (i % 2 == 0) continue;
                decimal.TryParse(Convert.ToString(grdEstimateDetails.Rows[i].Cells[clmAmount.Name].Value), out amount);
                res += amount;
            }

            return res;
        }
        #endregion
    }
}
