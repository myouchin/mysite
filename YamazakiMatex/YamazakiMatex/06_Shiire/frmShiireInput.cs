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

namespace Shiire
{
    /// <summary>
    /// 仕入入力
    /// </summary>
    public partial class frmShiireInput : Common.ChildBaseForm
    {
        #region 変数宣言
        bool prosessing = false;
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private enum LastInputDateType
        {
            None = 0
          , PurchaseDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DBTantousyaMaster tantousyaMaster;
        private CommonLogic commonLogic;
        private DBTokuisakiMaster tokuisakiMaster;
        private DBMeisyoMaster meisyoMaster;
        private DBShouhinMaster shouhinMaster;
        private DBShiresakiMaster shiresakiMaster;
        private string dummyCode = "Dummy";
        DBShire shireDataDb;
        private RadioButton activeRadioButton = null;
        private int gridStartRowCount = 5;
        private enum GridErrorStatus
        {
            None = 0
          , ItemCodeError = 1
          , ItemNameError = 2
          , MultiError = 3
        }
        private DataGridViewRow copyGridTopRow = null;
        private DataGridViewRow copyGridBtmRow = null;
        private string detailsTotalTitle = "仕　入　計";
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private int quantityIntegerLength = 8;
        private int quantityDecimalLength = 0;
        private int bidIntegerLength = 8;
        private int bidDecimalLength = 0;
        private int amountIntegerLength = 8;
        private int amountDecimalLength = 0;
        private string quantityFormat;
        private string bidFormat;
        private string amountFormat;
        private string beforeCellValue;
        private bool flgBtnSearchSelect = false;
        private bool flgSetData = false;
        private bool flgNohinsyoExsits = false;
        bool flgDeletingRow = false;
        sfrmShireSearch sShire;
        sfrmShiiresakiSearch sShiresaki;
        sfrmJuchuSearch sJuchu;
        sfrmTokuisakiSearch fTokuisaki;
        sfrmShouhinSearch fShouhin;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmShiireInput()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            tantousyaMaster = new DBTantousyaMaster();
            tokuisakiMaster = new DBTokuisakiMaster();
            meisyoMaster = new DBMeisyoMaster();
            shireDataDb = new DBShire();
            shouhinMaster = new DBShouhinMaster();
            shiresakiMaster = new DBShiresakiMaster();
            commonLogic = new CommonLogic();
            sShire = new sfrmShireSearch(false, CheckMessageType.None);
            sShiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
            sJuchu = new sfrmJuchuSearch(false, CheckMessageType.None);
            fTokuisaki = new sfrmTokuisakiSearch(false);
            fShouhin = new sfrmShouhinSearch(false);
            if (Program.loginUserInfo.Kengen > Consts.ClerkCode)
            {
                rdoNew.Enabled = false;
                rdoCorrection.Enabled = false;
                rdoDelete.Enabled = false;
                rdoReference.Checked = true;
            }
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiireInput_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtPurchaseNo;
            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 単位コンボボックス設定
            setUnitCmb();
            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 入力情報設定
            setInputInfo();
            // 数量フォーマット文字列取得
            quantityFormat = commonLogic.getNumberFormatString(quantityIntegerLength, quantityDecimalLength);
            // 単価フォーマット文字列取得
            bidFormat = commonLogic.getNumberFormatString(bidIntegerLength, bidDecimalLength);
            // 金額フォーマット文字列取得
            amountFormat = commonLogic.getNumberFormatString(amountIntegerLength, amountDecimalLength);
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

        #region 行複写ボタン押下イベント
        /// <summary>
        /// 行複写ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力して処理を終了
            if (grdPurchaseDetails.CurrentRow == null)
            {
                errorOK(Messages.M0004);
                return;
            }

            // 選択行から上段行のINDEXを取得
            int selectedGridTopRowIndex = grdPurchaseDetails.CurrentRow.Index;
            if (selectedGridTopRowIndex % grdPurchaseDetails.RowSegmentCount != 0)
            {
                selectedGridTopRowIndex = grdPurchaseDetails.CurrentRow.Index - 1;
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
                copyGridTopRow = grdPurchaseDetails.Rows[selectedGridTopRowIndex];
                copyGridBtmRow = grdPurchaseDetails.Rows[selectedGridTopRowIndex + 1];
            }
            // 行複写ボタンのテキスト設定
            setRowCopyBtnText();
            grdPurchaseDetails.Focus();
            grdPurchaseDetails.Refresh();
            if (flgCancelCopy)
            {
                grdPurchaseDetails.CurrentCell = grdPurchaseDetails[clmItemCode.DisplayIndex, selectedGridTopRowIndex + 1];
                grdPurchaseDetails.BeginEdit(true);
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
            if (grdPurchaseDetails.CurrentRow == null ||
                copyGridTopRow.Index == grdPurchaseDetails.CurrentCell.RowIndex ||
                copyGridBtmRow.Index == grdPurchaseDetails.CurrentCell.RowIndex)
            {
                errorOK(Messages.M0006);
                return;
            }

            // 貼付対象行が入力済みの場合、確認メッセージを出力する
            int currentTopRowIndex;
            int currentBtmRowIndex;
            if (grdPurchaseDetails.CurrentCell.RowIndex % grdPurchaseDetails.RowSegmentCount == 0)
            {
                currentTopRowIndex = grdPurchaseDetails.CurrentCell.RowIndex;
                currentBtmRowIndex = grdPurchaseDetails.CurrentCell.RowIndex + 1;
            }
            else
            {
                currentTopRowIndex = grdPurchaseDetails.CurrentCell.RowIndex - 1;
                currentBtmRowIndex = grdPurchaseDetails.CurrentCell.RowIndex;
            }

            // 入力済みの行を選択している場合、確認メッセージを出力
            if (!checkEmptyRow(currentTopRowIndex) &&
                queryYesNo(Messages.M0007) == DialogResult.No)
            {
                return;
            }

            // 貼り付け処理を実行
            string afterItemCd = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmItemCode.Name].Value);
            string afterItemNm1 = Convert.ToString(grdPurchaseDetails.Rows[copyGridTopRow.Index].Cells[clmItemName.Name].Value);
            string afterItemNm2 = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmItemName.Name].Value);
            string afterJuchuSuryo = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmQuantity.Name].Value);
            string afterTani = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmUnit.Name].Value); ;
            string afterJuchuTanka = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmBid.Name].Value);
            string afterJuchuKingaku = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmAmount.Name].Value);
            string afterTopClassification = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmTopClassificationCode.Name].Value);
            string afterBtmClassification = Convert.ToString(grdPurchaseDetails.Rows[copyGridBtmRow.Index].Cells[clmbtmClassificationCode.Name].Value);

            // 商品ｺｰﾄﾞ
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmItemCode.Name].Value = afterItemCd;
            // 商品名(上段)
            grdPurchaseDetails.Rows[currentTopRowIndex].Cells[clmItemName.Name].Value = afterItemNm1;
            // 商品名(下段)
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmItemName.Name].Value = afterItemNm2;
            // 受注数量
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmQuantity.Name].Value = afterJuchuSuryo;
            // 単位
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmUnit.Name].Value = afterTani;
            // 単価
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmBid.Name].Value = afterJuchuTanka;
            // 金額
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmAmount.Name].Value = afterJuchuKingaku;
            // 大分類コード
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmTopClassificationCode.Name].Value = afterTopClassification;
            // 小分類コード
            grdPurchaseDetails.Rows[currentBtmRowIndex].Cells[clmbtmClassificationCode.Name].Value = afterBtmClassification;

            // 最終行に貼り付けを行った場合、行追加
            addLastEmptyRow();

            if (grdPurchaseDetails.CurrentCell != null)
            {
                grdPurchaseDetails.BeginEdit(true);
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
            if (grdPurchaseDetails.CurrentRow == null)
            {
                errorOK(Messages.M0008);
                return;
            }

            // 行挿入
            int insertIndex = grdPurchaseDetails.CurrentRow.Index % grdPurchaseDetails.RowSegmentCount == 0 ? grdPurchaseDetails.CurrentRow.Index : grdPurchaseDetails.CurrentRow.Index - 1;
            // 受注グリッドへ空行を追加
            insertEmptyGridRow(insertIndex);

            // 受注グリッドの再描画
            grdPurchaseDetails.CurrentCell = grdPurchaseDetails[clmItemCode.DisplayIndex, insertIndex + 1];
            grdPurchaseDetails.BeginEdit(true);
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
            if (grdPurchaseDetails.CurrentRow == null)
            {
                errorOK(Messages.M0009);
                return;
            }
            int deleteIndex = grdPurchaseDetails.CurrentRow.Index % grdPurchaseDetails.RowSegmentCount == 0 ? grdPurchaseDetails.CurrentRow.Index : grdPurchaseDetails.CurrentRow.Index - 1;
            // 複写中の行を選択している場合、エラーメッセージを出力し処理を終了する
            if (copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == deleteIndex || copyGridBtmRow.Index == deleteIndex))
            {
                errorOK(string.Format(Messages.M0016, "複写中", "削除", "(削除する場合は、複写行を選択し取消ボタンを押下してください。)"));
                return;
            }

            flgDeletingRow = true;
            grdPurchaseDetails.Rows.Remove(grdPurchaseDetails.Rows[deleteIndex + 1]);
            grdPurchaseDetails.Rows.Remove(grdPurchaseDetails.Rows[deleteIndex]);
            flgDeletingRow = false;

            // 不足分の空行追加処理
            addInsufficientEmptyGridRow(); ;
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();

            if (grdPurchaseDetails.Rows.Count == 0)
            {
            }
            //else if (grdPurchaseDetails.Rows.Count >= deleteIndex + 1)
            else if (deleteIndex == 0)
            {
                grdPurchaseDetails.CurrentCell = grdPurchaseDetails[clmItemCode.DisplayIndex, deleteIndex + 1];
            }
            else
            {
                grdPurchaseDetails.CurrentCell = grdPurchaseDetails[clmItemCode.DisplayIndex, deleteIndex - 1];
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
            if (prosessing) return;
            prosessing = true;
            CheckMessageType messageType = CheckMessageType.inputDataUpdateQuery;
            if ((rdoCorrection.Checked && !flgSearch) ||
                rdoReference.Checked ||
                (rdoDelete.Checked && !flgSearch))
            {
                messageType = CheckMessageType.None;
            }
            // 仕入Noを編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtPurchaseNo.Name))
            {
                // 仕入検索画面を起動
                sShire.MType = messageType;
                sShire.ShowDialog();

                if (sShire.DialogResult == DialogResult.OK)
                {
                    flgSearch = false;
                    // 仕入情報の設定
                    setShireData(sShire.SelectedShireInfos[0].ShireNo);
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                flgSetFocus = true;
            }
            // 仕入先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtVendorCode.Name))
            {
                // 仕入先検索画面を起動
                sShiresaki.ShowDialog();

                // 仕入先検索画面で確認ボタンが押下された場合
                if (sShiresaki.DialogResult == DialogResult.OK)
                {
                    // 仕入先情報設定処理
                    setShiresakiInfo(sShiresaki.SelectedShiresakiCodes[0], true);
                    beforeCellValue = sShiresaki.SelectedShiresakiCodes[0];
                }
                flgSetFocus = true;
            }
            // 受注Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtOrderNo.Name))
            {
                // 受注検索画面を起動
                sJuchu.MType = messageType;
                sJuchu.ShowDialog();

                if (sJuchu.DialogResult == DialogResult.OK)
                {
                    flgSearch = false;
                    // 受注情報の設定
                    setJuchuData(sJuchu.SelectedJuchuInfos[0].DocumentNo, string.Empty);
                    // 画面項目制御処理を実行
                    setEnabled();
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
            // 見積グリッドを編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞ列の場合
                if (activeControlInfo.RowIndex % grdPurchaseDetails.RowSegmentCount != 0 &&
                    activeControlInfo.ClmIndex == clmItemCode.DisplayIndex)
                {
                    grdPurchaseDetails.CancelEdit();
                    // 商品検索画面を起動
                    fShouhin.ShowDialog();

                    // 商品検索画面で確認ボタンが押下された場合
                    if (fShouhin.DialogResult == DialogResult.OK)
                    {
                        // 商品情報設定処理
                        setShouhinInfo(activeControlInfo.RowIndex
                                     , fShouhin.SelectedItemCodes[0].ShireCode
                                     , fShouhin.SelectedItemCodes[0].TopClassification
                                     , fShouhin.SelectedItemCodes[0].BtmClassification
                                     , fShouhin.SelectedItemCodes[0].ShouhinNo);
                        beforeCellValue = fShouhin.SelectedItemCodes[0].ShouhinNo;
                        grdPurchaseDetails.EndEdit();
                    }
                    grdPurchaseDetails.BeginEdit(true);
                }
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
            prosessing = false;
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
            // TODO
            if (!btnSave.Enabled) return;
            flgSaving = true;
            // チェック処理
            if (!checkRequired())
            {
                return;
            }

            // 空行全削除処理実行
            if (!flgNohinsyoExsits && checkMiddleEmptyRowExist())
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
                string shireNo = txtPurchaseNo.Text;
                string ordersNo = txtOrderNo.Text;
                DateTime registerDate = DateTime.Now;
                string sqlHeaderCommand = createHeaderRegistSql(ref shireNo, registerDate);
                List<string> sqlBodyCommands = createBodyRegistSql(shireNo, registerDate);
                string sqlFooterCommand = createFooterRegistSql(shireNo, registerDate);
                string sqlHachuNoCommand = string.Empty;
                // 受注明細の更新
                string sqlJuchuCommands = createJuchuBodyUpdateSql(registerDate);
                string sqlShireNoCommand = rdoNew.Checked ? createShireNoRegistSql(shireNo, registerDate) : string.Empty;
                int headerRegistResult = 0;
                int bodyRegistResult = 0;
                int footerRegistResult = 0;
                int juchuRegistResult = 0;
                int kanriMasterRegistResult = 0;
                shireDataDb.DBRef = 0;

                if (rdoNew.Checked)
                {
                    shireDataDb.startTransaction();
                    // 管理マスタ(仕入No)のロック
                    shireDataDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.ShireNo + "'", true);
                    if (shireDataDb.DBRef != 0)
                    {
                        shireDataDb.endTransaction();
                        errorOK("仕入Noロックエラー");
                        return;
                    }
                }

                // 仕入ヘッダの更新
                headerRegistResult = shireDataDb.executeDBUpdate(sqlHeaderCommand);

                if (shireDataDb.DBRef == 0)
                {
                    // 仕入ボディの更新
                    foreach (string bodyCommand in sqlBodyCommands)
                    {
                        bodyRegistResult = shireDataDb.executeDBUpdate(bodyCommand);
                        if (shireDataDb.DBRef != 0) break;
                    }
                }

                // 仕入フッターの更新
                if (shireDataDb.DBRef == 0) footerRegistResult = shireDataDb.executeDBUpdate(sqlFooterCommand);

                // 受注情報の更新
                if (shireDataDb.DBRef == 0) juchuRegistResult = shireDataDb.executeDBUpdate(sqlJuchuCommands);

                // 管理マスタ(仕入No)の更新
                if (shireDataDb.DBRef == 0 && !string.IsNullOrEmpty(sqlShireNoCommand)) kanriMasterRegistResult = shireDataDb.executeDBUpdate(sqlShireNoCommand);

                if (shireDataDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (headerRegistResult < 0 || kanriMasterRegistResult < 0)
                    {
                        tableName = "仕入ヘッダ";
                    }
                    else if (bodyRegistResult < 0)
                    {
                        tableName = "仕入明細";
                    }
                    else if (footerRegistResult < 0)
                    {
                        tableName = "仕入集計";
                    }
                    else if (juchuRegistResult == -1)
                    {
                        tableName = "受注ヘッダ";
                    }
                    else if (juchuRegistResult == -2)
                    {
                        tableName = "受注明細";
                    }
                    else if (juchuRegistResult == -3)
                    {
                        tableName = "受注集計";
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
                    if (rdoNew.Checked) shireDataDb.endTransaction();
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "仕入No:" + shireNo;
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
                    messageOK(string.Format(Messages.M0012, message1, message2));
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
            if (shireDataDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                shireDataDb.endTransaction();
            }
            closedForm();
        }
        #endregion

        #region 仕入Noのフォーカスアウトイベント
        /// <summary>
        /// 仕入Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPurchaseNo_Leave(object sender, EventArgs e)
        {
            if (flgSetData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                flgSetData = true;
                // 受注データ取得処理を実行
                bool ret = setShireData(commonLogic.getZeroBuriedNumberText(txtPurchaseNo.Text, txtPurchaseNo.MaxLength));

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
        #endregion

        #region 仕入先コードのフォーカスアウトイベント
        /// <summary>
        /// 仕入先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 仕入先情報の設定
                setShiresakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), false);
            }
            else
            {
                txtVendorName.Text = string.Empty;
            }
        }
        #endregion

        #region 受注Noのフォーカスアウトイベント
        /// <summary>
        /// 受注Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderNo_Leave(object sender, EventArgs e)
        {
            if (flgSetData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                flgSetData = true;
                // 受注データ取得処理を実行
                bool ret = setJuchuData(string.Empty, commonLogic.getZeroBuriedNumberText(txtOrderNo.Text, txtOrderNo.MaxLength));

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
        #endregion

        #region 得意先コードのフォーカスアウトイベント
        /// <summary>
        /// 得意先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 得意先情報の設定
                setTokuisakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), string.Empty, false);

            }
            else
            {
                txtCustomerName.Text = string.Empty;
                txtCustomerKanaName.Text = string.Empty;
                txtZipCode.Text = string.Empty;
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                setOfficesCmb(dummyCode, string.Empty);
            }
        }
        #endregion

        #region 仕入日付のフォーカスインイベント
        /// <summary>
        /// 仕入日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void purchaseDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.PurchaseDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 仕入日付のフォーカスアウトイベント
        /// <summary>
        /// 仕入日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void purchaseDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.PurchaseDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.PurchaseDate;
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

            if (grdPurchaseDetails.CurrentCell != null)
            {
                try { grdPurchaseDetails.CurrentCell = null; } catch { }
            }

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.PurchaseDate:
                        y = txtPurchaseDateYears.Text;
                        m = txtPurchaseDateMonth.Text;
                        d = txtPurchaseDateDays.Text;
                        inputObj = dtpPurchaseDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.PurchaseDate.Equals(lastInputDateType))
                    {
                        txtPurchaseDateYears.Focus();
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

        #region 画面モードラジオボタン押下イベント
        /// <summary>
        /// 画面モードラジオボタン押下イベント
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

        #region グリッドの選択セル変更イベント
        /// <summary>
        /// グリッドの選択セル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_CurrentCellChanged(object sender, EventArgs e)
        {
            // 行複写ボタンのテキスト設定
            setRowCopyBtnText();
            // カレントセルがnullの場合何もしない
            if (grdPurchaseDetails.CurrentCell == null) return;

            // カレントセルインデックスから上段行のインデックスを取得
            int selectedGridTopRowIndex = 0;
            if (grdPurchaseDetails.CurrentCell.RowIndex % grdPurchaseDetails.RowSegmentCount == 0)
            {
                selectedGridTopRowIndex = grdPurchaseDetails.CurrentCell.RowIndex;
            }
            else
            {
                selectedGridTopRowIndex = grdPurchaseDetails.CurrentCell.RowIndex - 1;
            }

            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(selectedGridTopRowIndex);
            activeControlInfo = new ActiveControlInfo();
            // カレントセルがTextBoxCellかつ
            // 入力可能セルの場合
            if ((grdPurchaseDetails.CurrentCell.OwningColumn is DataGridViewTextBoxColumn ||
                grdPurchaseDetails.CurrentCell.OwningColumn is DataGridViewComboBoxColumn) &&
                !grdPurchaseDetails.CurrentCell.ReadOnly)
            {
                beforeCellValue = Convert.ToString(grdPurchaseDetails.CurrentCell.Value);
                // カレントセルの編集モードを開始
                grdPurchaseDetails.BeginEdit(true);
            }
        }
        #endregion

        #region グリッドのセル描画イベント
        /// <summary>
        /// グリッドのセル描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;

            // 行・列共にヘッダは処理しない
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int rowIndex = -1;
            // カレントセルがnull出ない場合
            if (grdPurchaseDetails.CurrentCell != null)
            {
                // カレントセルから上段行の行インデックを取得
                rowIndex = grdPurchaseDetails.CurrentCell.RowIndex;
                if (rowIndex % grdPurchaseDetails.RowSegmentCount == 1) rowIndex--;
            }
            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(rowIndex);

            Rectangle rect;
            DataGridViewCell cell;
            // 行No列の処理
            if (e.ColumnIndex == 0)
            {
                int rowNo = (int)(e.RowIndex / grdPurchaseDetails.RowSegmentCount) + 1;
                rect = e.CellBounds;
                // 奇数行(1,3,5..行目 = RowIndexは0,2,4..)
                if (e.RowIndex % grdPurchaseDetails.RowSegmentCount == 0)
                {
                    cell = grdPurchaseDetails[e.ColumnIndex, e.RowIndex];
                    //一つ下の次のセルの高さを足す
                    rect.Height += cell.Size.Height;
                }
                // 偶数行の処理
                else
                {
                    cell = grdPurchaseDetails[e.ColumnIndex, e.RowIndex - 1];
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
            // 下段入力のみ可能な列の処理
            else if (e.RowIndex % grdPurchaseDetails.RowSegmentCount == 0 &&
                     (e.ColumnIndex == clmRowNo.DisplayIndex ||
                     e.ColumnIndex == clmItemCode.DisplayIndex ||
                     e.ColumnIndex == clmQuantity.DisplayIndex ||
                     e.ColumnIndex == clmUnit.DisplayIndex ||
                     e.ColumnIndex == clmBid.DisplayIndex ||
                     e.ColumnIndex == clmAmount.DisplayIndex))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
        }
        #endregion

        #region グリッド描画イベント
        /// <summary>
        /// グリッド描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_Paint(object sender, PaintEventArgs e)
        {
            //string[] monthes = { "", "", "", "", "", "", "", "", "", "" };

            //for (int j = 0; j < grdPurchaseDetails.ColumnCount; j++)
            //{
            //    String headerText = string.Empty;
            //    Rectangle r1 = this.grdPurchaseDetails.GetCellDisplayRectangle(j, -1, true); //get the column header cell

            //    r1.X += 1;

            //    r1.Y += 1;

            //    r1.Width = r1.Width - 2;

            //    if (!string.IsNullOrEmpty(monthes[j]))
            //    {
            //        headerText = monthes[j];
            //        r1.Height = (r1.Height / 2) - 2;
            //    }
            //    else
            //    {
            //        headerText = grdPurchaseDetails.Columns[j].HeaderText;
            //        r1.Height = r1.Height - 2;
            //    }

            //    e.Graphics.FillRectangle(new SolidBrush(this.grdPurchaseDetails.ColumnHeadersDefaultCellStyle.BackColor), r1);

            //    StringFormat format = new StringFormat();

            //    format.Alignment = StringAlignment.Center;

            //    format.LineAlignment = StringAlignment.Center;

            //    e.Graphics.DrawString(headerText,

            //        this.grdPurchaseDetails.ColumnHeadersDefaultCellStyle.Font,

            //        new SolidBrush(this.grdPurchaseDetails.ColumnHeadersDefaultCellStyle.ForeColor),

            //        r1,

            //        format);
            //    if (!string.IsNullOrEmpty(monthes[j])) e.Graphics.DrawLine(new Pen(Color.DarkGray), new Point(r1.X, r1.Bottom), new Point(r1.X + r1.Width, r1.Bottom));
            //}
        }
        #endregion

        #region グリッドの入力用コントロール表示時イベント
        /// <summary>
        /// グリッドの入力用コントロール表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            Common.CustomDataGridView dgv = (Common.CustomDataGridView)sender;
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = e.Control;
            activeControlInfo.RowIndex = dgv.CurrentCell.RowIndex;
            activeControlInfo.ClmIndex = dgv.CurrentCell.ColumnIndex;
            activeControlInfo.FlgGridEditingControl = true;

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                // 該当位置のセルの場合
                if ((dgv.CurrentCell.RowIndex % dgv.RowSegmentCount != 0) && (dgv.CurrentCell.ColumnIndex == clmUnit.DisplayIndex))
                {
                    // 最大入力桁数を設定
                    ((DataGridViewComboBoxEditingControl)e.Control).MaxLength = 3;
                    activeControlInfo.MaxLength = ((DataGridViewComboBoxEditingControl)e.Control).MaxLength;
                    // DropDownStyleをドロップダウンに変更
                    ((DataGridViewComboBoxEditingControl)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                }
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
                // キー押下イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown -= new KeyEventHandler(inputObject_KeyDown);
                // キー押下イベントを追加
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown += new KeyEventHandler(inputObject_KeyDown);
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

        #region グリッドのセル検証イベント
        /// <summary>
        /// グリッドのセル検証イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
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

        #region グリッドの入力確定時イベント
        /// <summary>
        /// グリッドの入力確定時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string inputValue = Convert.ToString(grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
            bool flgRecalcMeisai = false;
            bool flgRecalcSyukei = false;
            bool flgUnconditionalSyukei = false;

            // 商品ｺｰﾄﾞ列の場合
            if (e.ColumnIndex == clmItemCode.DisplayIndex && !flgDeletingRow)
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
                    grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = quantity.ToString(quantityFormat);
                }
                else
                {
                    grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
                flgRecalcSyukei = true;
            }
            // 単価セルの場合
            else if (e.ColumnIndex == clmBid.DisplayIndex)
            {
                decimal bid = decimal.Zero;
                if (decimal.TryParse(inputValue, out bid))
                {
                    grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bid.ToString(bidFormat);
                }
                else
                {
                    grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
                flgRecalcSyukei = true;
            }
            // 金額セルの場合
            else if (e.ColumnIndex == clmAmount.DisplayIndex)
            {
                decimal amount = decimal.Zero;
                if (decimal.TryParse(inputValue, out amount))
                {
                    grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount.ToString(amountFormat);
                }
                else
                {
                    grdPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
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

            // 集計グリッドの再計算が必要なセルへの入力を行った場合
            if (flgRecalcSyukei)
            {
                decimal beforeValue = decimal.Zero;
                decimal afterValue = decimal.Zero;
                decimal.TryParse(beforeCellValue, out beforeValue);
                decimal.TryParse(inputValue, out afterValue);

                if (beforeValue != afterValue)
                {
                    // 明細金額の集計処理を実行
                    recalcDetailsTotal();
                }
            }

            if (flgUnconditionalSyukei)
            {
                // 明細金額の集計処理を実行
                recalcDetailsTotal();
            }

            // 空白でない値を入力した場合
            if (!flgNohinsyoExsits && !string.IsNullOrEmpty(inputValue))
            {
                // 最終行に空行を追加
                addLastEmptyRow();
            }

            grdPurchaseDetails.Refresh();
        }
        #endregion

        #region データグリッドビューのデータエラーイベント
        /// <summary>
        /// データグリッドビューのデータエラーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPurchaseDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #endregion

        #region ビジネスロジック

        #region 画面項目へのイベント設定処理
        /// <summary>
        /// 画面項目へのイベント設定処理
        /// </summary>
        /// <param name="c"></param>
        private void setEvent(Control c)
        {
            // キー押下イベントを追加
            c.KeyDown += new KeyEventHandler(inputObject_KeyDown);

            // 仕入Noの場合
            if (c.Name.Equals(txtPurchaseNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtPurchaseNo_Leave);
            }
            // 仕入日付の場合
            else if (c.Name.Equals(txtPurchaseDateYears.Name) ||
                     c.Name.Equals(txtPurchaseDateMonth.Name) ||
                     c.Name.Equals(txtPurchaseDateDays.Name) ||
                     c.Name.Equals(dtpPurchaseDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.purchaseDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.purchaseDate_Leave);
            }
            // 仕入先コードの場合
            else if (c.Name.Equals(txtVendorCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtVendorCode_Leave);
            }
            // 受注Noの場合
            else if (c.Name.Equals(txtOrderNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOrderNo_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            }
            // 受注Noの場合
            else if (c.Name.Equals(txtOrderNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOrderNo_Leave);
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
            // 新規作成でないかつ仕入Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtPurchaseNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 仕入先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtVendorCode.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 受注Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtOrderNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 得意先コードを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 売上Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtSalesNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 受注グリッド編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞの場合
                if (activeControlInfo.RowIndex % grdPurchaseDetails.RowSegmentCount != 0 &&
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
            ComboBoxStyle cmbStyle = ComboBoxStyle.DropDownList;
            // 事業所取得
            if (Consts.OthersCustomerCode.Equals(tokuisakiCode) || dummyCode.Equals(tokuisakiCode))
            {
                tokuisakiCode = dummyCode;
                cmbStyle = ComboBoxStyle.Simple;
            }
            DataTable officesDt = tokuisakiMaster.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbOffices, officesDt, "jigyousyoCode", "jigyousyoName");
            cmbOffices.DropDownStyle = cmbStyle;

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
            commonLogic.setGridComboBoxDataSource(ref clmUnit, meisyoDt, "kubun", "kubunName");
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
            if (shireDataDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                shireDataDb.endTransaction();
            }

            activeRadioButton = radio;
            #region 共通初期値設定
            txtPurchaseNo.Text = string.Empty;
            dtpPurchaseDate.Value = syoriDate.AddDays(1);
            dtpPurchaseDate.Value = syoriDate;
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            if (rdoNew.Checked)
            {
                cmbPersonnel.SelectedValue = Program.loginUserInfo.UserId;
            }
            else
            {
                cmbPersonnel.SelectedIndex = -1;
                cmbPersonnel.Text = string.Empty;
            }
            txtOrderNo.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtSalesNo.Text = string.Empty;
            setOfficesCmb(dummyCode, string.Empty);

            // グリッド初期化処理実行
            initGridData();
            #endregion

            flgSearch = false;
            flgNohinsyoExsits = true;
            // モード別編集可否設定
            setEnabled();
        }
        #endregion

        #region 仕入グリッド初期化処理
        /// <summary>
        /// 仕入グリッド初期化処理
        /// </summary>
        private void initGridData()
        {
            // 仕入明細グリッドの初期化
            grdPurchaseDetails.Rows.Clear();
            for (int i = 0; i < (gridStartRowCount + 1); i++)
            {
                // 仕入グリッドへ空行を追加
                addEmptyGridRow();
            }
            grdPurchaseDetails.Rows.RemoveAt(grdPurchaseDetails.Rows.Count - 1);
            grdPurchaseDetails.Rows.RemoveAt(grdPurchaseDetails.Rows.Count - 1);
            grdPurchaseDetails.CurrentCell = null;
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 仕入明細合計グリッドの初期化
            DataTable dtPurchaseDetailsTotal = new DataTable();
            dtPurchaseDetailsTotal.Columns.Add(grdPurchaseDetailsTotal.Columns[clmTotalAmountTitle.Name].DataPropertyName, Type.GetType("System.String"));
            dtPurchaseDetailsTotal.Columns.Add(grdPurchaseDetailsTotal.Columns[clmTotalAmount.Name].DataPropertyName, Type.GetType("System.Decimal"));
            dtPurchaseDetailsTotal.Rows.Add(new object[] { detailsTotalTitle, null });
            grdPurchaseDetailsTotal.DataSource = dtPurchaseDetailsTotal;
        }
        #endregion

        #region 仕入グリッドへの空行追加処理
        /// <summary>
        /// 仕入グリッドへの空行追加処理
        /// </summary>
        private void addEmptyGridRow()
        {
            insertEmptyGridRow(grdPurchaseDetails.Rows.Count);
        }
        #endregion

        #region 仕入グリッドへの空行挿入処理
        /// <summary>
        /// 仕入グリッドへの空行挿入処理
        /// </summary>
        /// <param name="insertIndex"></param>
        private void insertEmptyGridRow(int insertIndex)
        {
            grdPurchaseDetails.Rows.Insert(insertIndex);
            grdPurchaseDetails.Rows[insertIndex].Cells[clmUnit.Name] = new DataGridViewTextBoxCell();
            grdPurchaseDetails.Rows[insertIndex].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            grdPurchaseDetails.Rows.Insert(insertIndex + 1);
            grdPurchaseDetails.Rows[insertIndex + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
        }
        #endregion

        #region 仕入グリッドへの不足分行追加処理
        /// <summary>
        /// 仕入グリッドへの不足分行追加処理
        /// </summary>
        private void addInsufficientEmptyGridRow()
        {
            // 取得した仕入ボディデータが初期表示件数未満の場合、不足データ分の空行を仕入グリッドに追加します
            for (int i = grdPurchaseDetails.Rows.Count / grdPurchaseDetails.RowSegmentCount; i < gridStartRowCount; i++)
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
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
            grdPurchaseDetails.Focus();
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                // 入力制御設定
                txtPurchaseNo.Enabled = true;
                txtPurchaseNo.ReadOnly = true;
                txtPurchaseDateYears.Enabled = true;
                txtPurchaseDateMonth.Enabled = true;
                txtPurchaseDateDays.Enabled = true;
                txtVendorCode.Enabled = true;
                txtVendorName.Enabled = Consts.OthersVendorCode.Equals(txtVendorCode.Text);
                cmbPersonnel.Enabled = true;
                txtOrderNo.Enabled = true;
                txtOrderNo.ReadOnly = false;
                txtCustomerCode.Enabled = true;
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                cmbOffices.Enabled = true;
                txtZipCode.Enabled = true;
                txtAddress1.Enabled = true;
                txtAddress2.Enabled = true;
                btnCopyRow.Enabled = true;
                btnPasteRow.Enabled = true;
                btnInsertRow.Enabled = true;
                btnDeleteRow.Enabled = true;
                btnSearch.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPurchaseNo.Focus();

                // 背景色設定
                txtPurchaseDateYears.BackColor = Color.White;
                txtPurchaseDateMonth.BackColor = Color.White;
                txtPurchaseDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtPurchaseNo.Enabled = !flgSearch;
                txtPurchaseNo.ReadOnly = false;
                txtPurchaseDateYears.Enabled = flgSearch && !flgNohinsyoExsits;
                txtPurchaseDateMonth.Enabled = flgSearch && !flgNohinsyoExsits;
                txtPurchaseDateDays.Enabled = flgSearch && !flgNohinsyoExsits;
                dtpPurchaseDate.Enabled = flgSearch && !flgNohinsyoExsits;
                txtVendorCode.Enabled = flgSearch && !flgNohinsyoExsits;
                txtVendorName.Enabled = Consts.OthersVendorCode.Equals(txtVendorCode.Text) && !flgNohinsyoExsits;
                cmbPersonnel.Enabled = flgSearch && !flgNohinsyoExsits;
                txtOrderNo.Enabled = false;
                txtCustomerCode.Enabled = flgSearch && !flgNohinsyoExsits;
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text) && !flgNohinsyoExsits;
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text) && !flgNohinsyoExsits;
                cmbOffices.Enabled = flgSearch && !flgNohinsyoExsits;
                txtZipCode.Enabled = flgSearch && !flgNohinsyoExsits;
                txtAddress1.Enabled = flgSearch && !flgNohinsyoExsits;
                txtAddress2.Enabled = flgSearch && !flgNohinsyoExsits;
                if (string.IsNullOrEmpty(txtSalesNo.Text))
                {
                    btnCopyRow.Enabled = true;
                    btnPasteRow.Enabled = true;
                    btnInsertRow.Enabled = true;
                    btnDeleteRow.Enabled = true;
                }
                else
                {
                    btnCopyRow.Enabled = false;
                    btnPasteRow.Enabled = false;
                    btnInsertRow.Enabled = false;
                    btnDeleteRow.Enabled = false;
                }
                btnSearch.Enabled = !flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                bool setFocus = !flgSearch ? txtPurchaseNo.Focus() : txtPurchaseDateYears.Focus();

                // 背景色設定
                txtPurchaseDateYears.BackColor = Color.White;
                txtPurchaseDateMonth.BackColor = Color.White;
                txtPurchaseDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtPurchaseNo.Enabled = !flgSearch;
                txtPurchaseNo.ReadOnly = false;
                txtPurchaseDateYears.Enabled = false;
                txtPurchaseDateMonth.Enabled = false;
                txtPurchaseDateDays.Enabled = false;
                txtVendorCode.Enabled = false;
                txtVendorName.Enabled = false;
                cmbPersonnel.Enabled = false;
                txtOrderNo.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = !flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                bool setFocus = !flgSearch ? txtPurchaseNo.Focus() : txtPurchaseDateYears.Focus();

                // 背景色設定
                txtPurchaseDateYears.BackColor = Color.White;
                txtPurchaseDateMonth.BackColor = Color.White;
                txtPurchaseDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtPurchaseNo.Enabled = !flgSearch;
                txtPurchaseNo.ReadOnly = false;
                txtPurchaseDateYears.Enabled = false;
                txtPurchaseDateMonth.Enabled = false;
                txtPurchaseDateDays.Enabled = false;
                txtVendorCode.Enabled = false;
                txtVendorName.Enabled = false;
                cmbPersonnel.Enabled = false;
                txtOrderNo.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = !flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                bool setFocus = !flgSearch ? txtPurchaseNo.Focus() : txtPurchaseDateYears.Focus();

                // 背景色設定
                txtPurchaseDateYears.BackColor = Color.White;
                txtPurchaseDateMonth.BackColor = Color.White;
                txtPurchaseDateDays.BackColor = Color.White;

                // 表示文字列設定
                btnSave.Text = "F10：実行";
            }
            #endregion
            rdoNew.Click += new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
            rdoDelete.Click += new EventHandler(inputModeRadio_Click);
            flgSettingEnable = false;
        }
        #endregion

        #region 処理モード別変更チェック処理
        /// <summary>
        /// 処理モード別変更チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkDataChange()
        {
            bool result = false;
            // 処理モード別の変更チェック処理
            if (rdoNew.Checked)
            {
                string shireDate = commonLogic.convertDateTime(txtPurchaseDateYears.Text, txtPurchaseDateMonth.Text, txtPurchaseDateDays.Text).ToString("yyyy/MM/dd");
                if (//!string.IsNullOrEmpty(txtPurchaseNo.Text) ||
                    !shireDate.Equals(syoriDate.ToString("yyyy/MM/dd")) ||
                    !string.IsNullOrEmpty(txtVendorCode.Text) ||
                    !string.IsNullOrEmpty(txtVendorName.Text) ||
                    !Program.loginUserInfo.UserId.Equals(cmbPersonnel.SelectedValue) ||
                    //!string.IsNullOrEmpty(txtOrderNo.Text) ||
                    !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                    !string.IsNullOrEmpty(txtCustomerName.Text) ||
                    !string.IsNullOrEmpty(txtCustomerKanaName.Text) ||
                    //!string.IsNullOrEmpty(cmbOffices.Text) ||
                    //!string.IsNullOrEmpty(txtCustomerPersonnel.Text) ||
                    //!string.IsNullOrEmpty(txtZipCode.Text) ||
                    //!string.IsNullOrEmpty(txtAddress1.Text) ||
                    //!string.IsNullOrEmpty(txtAddress2.Text) ||
                    //!string.IsNullOrEmpty(txtSalesNo.Text) ||
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

        #region 仕入明細グリッドの空白行チェック処理
        /// <summary>
        /// 仕入明細グリッドの空白行チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkAllEmptyRow()
        {
            bool flgAllEmptyRow = true;
            for (int i = 0; i < grdPurchaseDetails.Rows.Count; i++)
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

        #region 対象行の未入力チェック処理
        /// <summary>
        /// 対象行の未入力チェック処理
        /// </summary>
        /// <param name="topRowIndex">チェック対象の上段行INDEX</param>
        /// <returns></returns>
        private bool checkEmptyRow(int topRowIndex)
        {
            bool res = false;

            DataGridViewRow topRow = grdPurchaseDetails.Rows[topRowIndex];
            DataGridViewRow btmRow = grdPurchaseDetails.Rows[topRowIndex + 1];

            string itemCd = Convert.ToString(btmRow.Cells[clmItemCode.Name].Value);         // 商品ｺｰﾄﾞ
            string itemNm1 = Convert.ToString(topRow.Cells[clmItemName.Name].Value);        // 商品名(上段)
            string itemNm2 = Convert.ToString(btmRow.Cells[clmItemName.Name].Value);        // 商品名(下段)
            string juchuSuryo = Convert.ToString(btmRow.Cells[clmQuantity.Name].Value);     // 数量
            string tani = Convert.ToString(btmRow.Cells[clmUnit.Name].Value);               // 単位
            string juchuTanka = Convert.ToString(topRow.Cells[clmBid.Name].Value);          // 単価
            string juchuKingaku = Convert.ToString(btmRow.Cells[clmAmount.Name].Value);     // 金額

            // 全項目が未入力の場合
            if (string.IsNullOrEmpty(itemCd) &&
                string.IsNullOrEmpty(itemNm1) &&
                string.IsNullOrEmpty(itemNm2) &&
                string.IsNullOrEmpty(juchuSuryo) &&
                string.IsNullOrEmpty(tani) &&
                string.IsNullOrEmpty(juchuTanka) &&
                string.IsNullOrEmpty(juchuKingaku))
            {
                res = true;
            }
            return res;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtPurchaseNo.MaxLength = 8;                // 仕入No
            txtPurchaseDateYears.MaxLength = 4;         // 仕入日付(年)
            txtPurchaseDateMonth.MaxLength = 2;         // 仕入日付(月)
            txtPurchaseDateDays.MaxLength = 2;          // 仕入日付(日)
            txtVendorCode.MaxLength = 3;                // 仕入コード
            txtVendorName.MaxLength = 15;               // 仕入名
            cmbPersonnel.MaxLength = 10;                // 担当者
            txtOrderNo.MaxLength = 15;                  // 受注No
            txtCustomerCode.MaxLength = 5;              // 得意先ｺｰﾄﾞ
            txtCustomerName.MaxLength = 40;             // 得意先名
            txtCustomerKanaName.MaxLength = 80;         // 得意先カナ名
            cmbOffices.MaxLength = 10;                  // 事業所
            txtZipCode.MaxLength = 8;                   // 郵便番号
            txtAddress1.MaxLength = 25;                 // 住所１
            txtAddress2.MaxLength = 25;                 // 住所２

            // 入力制御イベント設定
            txtPurchaseNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 仕入No       :数字のみ入力可
            txtPurchaseDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 仕入日付(年) :数字のみ入力可
            txtPurchaseDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 仕入日付(月) :数字のみ入力可
            txtPurchaseDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 仕入日付(日) :数字のみ入力可
            txtVendorCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 仕入コード   :数字のみ入力可
            txtOrderNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);              // 受注No       :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 得意先ｺｰﾄﾞ   :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);      // 得意先カナ名 :全角カナのみ入力可
            txtZipCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);              // 郵便番号     :数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 行複写ボタンのテキスト設定
        /// <summary>
        /// 行複写ボタンのテキスト設定
        /// </summary>
        private void setRowCopyBtnText()
        {
            string strBtnCopyRow = "行複写";
            // 複写中の行を選択している場合
            if (grdPurchaseDetails.CurrentCell != null &&
                copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == grdPurchaseDetails.CurrentCell.RowIndex || copyGridBtmRow.Index == grdPurchaseDetails.CurrentCell.RowIndex))
            {
                strBtnCopyRow = "取消";
            }
            btnCopyRow.Text = strBtnCopyRow;
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
            decimal bid;
            // 複写中の行インデックスを取得
            int copyGridTopRowIndex = -1;
            int copyGridBtmRowIndex = -1;
            if (copyGridTopRow != null && copyGridBtmRow != null)
            {
                copyGridTopRowIndex = copyGridTopRow.Index;
                copyGridBtmRowIndex = copyGridBtmRow.Index;
            }
            // 全行の背景色を再設定
            foreach (DataGridViewRow gRow in grdPurchaseDetails.Rows)
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
                    if (gRow.Index % grdPurchaseDetails.RowSegmentCount == 0)
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
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;       // 行No     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;    // 商品ｺｰﾄﾞ ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;    // 商品名   ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;    // 数量     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;        // 単位     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;         // 単価     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;      // 金額     ：編集不可
                }
                // 複写中の行の場合
                else if (copyGridTopRowIndex == gRow.Index || copyGridBtmRowIndex == gRow.Index)
                {
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;       // 行No     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;    // 商品ｺｰﾄﾞ ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;    // 商品名   ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;    // 数量     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;        // 単位     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;         // 単価     ：編集不可
                    grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;      // 金額     ：編集不可
                }
                // 上段行の場合
                else if (gRow.Index % grdPurchaseDetails.RowSegmentCount == 0)
                {
                    if (grdPurchaseDetails.Rows.Count - 1 == gRow.Index)
                    {
                        itemCode = string.Empty;
                    }
                    else
                    {
                        itemCode = Convert.ToString(grdPurchaseDetails.Rows[gRow.Index + 1].Cells[clmItemCode.Name].Value);
                    }
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;           // 行No     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;        // 商品ｺｰﾄﾞ ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;        // 商品名   ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;        // 数量     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;            // 単位     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;             // 単価     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;          // 金額     ：編集不可
                    }
                    else
                    {
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;           // 行No     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = true;        // 商品ｺｰﾄﾞ ：編集不可
                        // 商品ｺｰﾄﾞが"99999"の場合
                        if (Consts.OthersItemCode.Equals(itemCode))
                        {
                            grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = false;   // 商品名   ：編集可
                        }
                        else
                        {
                            grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;    // 商品名   ：編集不可
                        }
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;        // 数量     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;            // 単位     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;             // 単価     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;          // 金額     ：編集不可
                    }
                }
                // 下段行の場合
                else
                {
                    itemCode = Convert.ToString(grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].Value);
                    decimal.TryParse(Convert.ToString(grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].Value), out bid);
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;       // 行No     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = false;   // 商品ｺｰﾄﾞ ：編集可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;    // 商品名   ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = true;    // 数量     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;        // 単位     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = true;         // 単価     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;      // 金額     ：編集不可
                    }
                    else
                    {
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;       // 行No     ：編集不可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].ReadOnly = false;   // 商品ｺｰﾄﾞ ：編集可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = false;   // 商品名   ：編集可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].ReadOnly = false;   // 数量     ：編集可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = false;       // 単位     ：編集可
                        grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].ReadOnly = false;        // 単価     ：編集可
                        // 受注単価が0の場合
                        if (bid == decimal.Zero)
                        {
                            grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = false; // 金額     ：編集可
                        }
                        else
                        {
                            grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].ReadOnly = true;  // 金額     ：編集不可
                        }
                    }
                }

                // セル未選択時の背景色の設定
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].Style.BackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].Style.BackColor = setItemCodeColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].Style.BackColor = setItemNameColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].Style.BackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].Style.BackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].Style.BackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].Style.BackColor = setColor;
                // セル選択時の背景色の設定
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmRowNo.Name].Style.SelectionBackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemCode.Name].Style.SelectionBackColor = setItemCodeColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmItemName.Name].Style.SelectionBackColor = setItemNameColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmQuantity.Name].Style.SelectionBackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmUnit.Name].Style.SelectionBackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmBid.Name].Style.SelectionBackColor = setColor;
                grdPurchaseDetails.Rows[gRow.Index].Cells[clmAmount.Name].Style.SelectionBackColor = setColor;
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
            List< DBFileLayout.ShouhinMasterFile> shouhinInfo = shouhinMaster.getShouhinInfo(shiresakiCode, topClassification, btmClassification, shouhinCode, false);

            int topRowIndex = rowIndex;
            int btmRowIndex = 0;
            if (topRowIndex % grdPurchaseDetails.RowSegmentCount != 0)
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
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
                grdPurchaseDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            }
            // 対象の商品情報が取得できた場合
            else if (shouhinInfo.Count > 0)
            {
                // 商品情報の設定
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = shouhinInfo[0].ShouhinCode;
                if (!Consts.OthersItemCode.Equals(shouhinInfo[0].ShouhinCode))
                {
                    grdPurchaseDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = shouhinInfo[0].ShouhinName;
                }
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = shouhinInfo[0].TopClassification;
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = shouhinInfo[0].BtmClassification;
            }
            else if (dummyCode.Equals(shouhinCode))
            {
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmItemCode.Name].Value = string.Empty;
                grdPurchaseDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            }
        }
        #endregion

        #region グリッド行の初期化処理
        /// <summary>
        /// グリッド行の初期化処理
        /// </summary>
        /// <param name="gridRowIndex"></param>
        private void clearGridRow(int gridRowIndex)
        {
            int topRowIndex = gridRowIndex % grdPurchaseDetails.RowSegmentCount == 0 ? gridRowIndex : gridRowIndex - 1;
            int btmRowIndex = topRowIndex + 1;

            // 上段行の初期化
            grdPurchaseDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;

            // 下段行の初期化
            grdPurchaseDetails.Rows[btmRowIndex].Cells[clmQuantity.Name].Value = null;
            grdPurchaseDetails.Rows[btmRowIndex].Cells[clmUnit.Name].Value = string.Empty;
            grdPurchaseDetails.Rows[btmRowIndex].Cells[clmBid.Name].Value = null;
            grdPurchaseDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
        }
        #endregion

        #region 明細の再計算処理
        /// <summary>
        /// 明細の再計算処理
        /// </summary>
        /// <param name="rowIndex"></param>
        private void recalcMeisai(int rowIndex)
        {
            // 金額の再計算
            int topRowIndex = rowIndex % grdPurchaseDetails.RowSegmentCount == 0 ? rowIndex : rowIndex - 1;
            int btmRowIndex = topRowIndex + 1;
            string strQuantity = Convert.ToString(grdPurchaseDetails.Rows[btmRowIndex].Cells[clmQuantity.Name].Value);
            string strBid = Convert.ToString(grdPurchaseDetails.Rows[btmRowIndex].Cells[clmBid.Name].Value);
            string strAmount = string.Empty;
            decimal quantity = decimal.Zero;
            decimal bid = decimal.Zero;
            decimal amount = decimal.Zero;

            // 受注金額の再設定
            if (string.IsNullOrEmpty(strQuantity) || string.IsNullOrEmpty(strBid))
            {
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = null;
            }
            else
            {
                decimal.TryParse(strQuantity, out quantity);
                decimal.TryParse(strBid, out bid);
                amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, quantity * bid);
                grdPurchaseDetails.Rows[btmRowIndex].Cells[clmAmount.Name].Value = amount.ToString(amountFormat);
            }
        }
        #endregion

        #region 明細金額の集計処理
        /// <summary>
        /// 明細金額の集計処理
        /// </summary>
        private void recalcDetailsTotal()
        {
            DataGridViewRow btmRow;
            string strAmount;
            decimal amount;
            bool flgAmountCalc = false;
            decimal amountTotal = decimal.Zero;

            for (int i = 0; i < grdPurchaseDetails.Rows.Count; i++)
            {
                if (i % grdPurchaseDetails.RowSegmentCount == 0) continue;
                btmRow = grdPurchaseDetails.Rows[i];
                strAmount = Convert.ToString(btmRow.Cells[clmAmount.Name].Value);

                if (decimal.TryParse(strAmount, out amount))
                {
                    amountTotal += amount;
                    flgAmountCalc = true;
                }
                i++;
            }

            DataTable dt = (DataTable)grdPurchaseDetailsTotal.DataSource;
            // 金額集計済みフラグがtrueの場合
            if (flgAmountCalc)
            {
                dt.Rows[0][clmTotalAmount.DataPropertyName] = amountTotal;
            }
            else
            {
                dt.Rows[0][clmTotalAmount.DataPropertyName] = DBNull.Value;
            }
        }
        #endregion

        #region 仕入グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// <summary>
        /// 仕入グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// </summary>
        private void addLastEmptyRow()
        {
            // 最終行が空行でない場合、行追加
            if (!checkEmptyRow(grdPurchaseDetails.Rows.Count - 2))
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (dt == null || dt.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerCode.Focus();
                return;
            }

            if (flgUnconditional || txtCustomerCode.BeforeValue != tokuisakiCode)
            {
                DataRow dRow = dt.Rows[0];
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    // 入力値クリア設定
                    txtCustomerName.Text = string.Empty;
                    txtCustomerKanaName.Text = string.Empty;
                    txtZipCode.Text = string.Empty;
                    txtAddress1.Text = string.Empty;
                    txtAddress2.Text = string.Empty;
                    // フォーカス設定
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
                    txtZipCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcZipCode]);
                    txtAddress1.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcAddress1]);
                    txtAddress2.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcAddress2]);

                }
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
                // 入力可否設定
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
            }
            else
            {
                txtCustomerCode.Text = tokuisakiCode;
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
            cmbOffices.BeforeSelectedValue = Convert.ToString(cmbOffices.SelectedValue);
        }
        #endregion

        #region 仕入先情報設定処理
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setShiresakiInfo(string shiresakiCode, bool flgUnconditional)
        {
            // 仕入先情報の取得
            List< DBFileLayout.ShiresakiMasterFile> shiresakiInfo = shiresakiMaster.getShiresakiInfo(shiresakiCode);
            if (shiresakiInfo == null || shiresakiInfo.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "仕入先ｺｰﾄﾞ"));
                txtVendorCode.Focus();
                return;
            }

            if (flgUnconditional || txtVendorCode.BeforeValue != shiresakiCode)
            {
                if (Consts.OthersVendorCode.Equals(shiresakiCode))
                {
                    txtVendorCode.Text = shiresakiInfo[0].ShiresakiCode;
                    txtVendorName.Text = string.Empty;
                }
                else
                {
                    txtVendorCode.Text = shiresakiInfo[0].ShiresakiCode;
                    txtVendorName.Text = shiresakiInfo[0].ShiresakiName;
                }
                // 入力可否設定
                txtVendorName.Enabled = Consts.OthersVendorCode.Equals(txtVendorCode.Text);
            }
            else
            {
                txtVendorCode.Text = shiresakiCode;
            }

            txtVendorCode.BeforeValue = txtVendorCode.Text;
        }
        #endregion

        #region 仕入データ設定処理
        /// <summary>
        /// 仕入データ設定処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <returns></returns>
        private bool setShireData(string shireNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            // トランザクション開始処理を実行
            shireDataDb.startTransaction();
            if (rdoNew.Checked) shireDataDb.endTransaction();

            // 取得時にエラーが発生した場合
            if (shireDataDb.getShireData(shireNo) != DBShire.SelectErrorType.None)
            {
                errorOK(string.Format(Messages.M0027, "仕入データ"));
                return false;
            }

            DBFileLayout.ShireHeaderFile headerData = shireDataDb.SelectShireData.HeaderData;
            List< DBFileLayout.ShireBodyFile> bodyData = shireDataDb.SelectShireData.BodyDatas;
            DBFileLayout.ShireFooterFile footerData = shireDataDb.SelectShireData.FooterData;

            // 仕入ヘッダデータが存在する場合
            if (headerData.FlgDataExsit)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(headerData.KanriKubun)))
                {
                    string msg1 = rdoCorrection.Checked ? "訂正" : rdoReference.Checked ? "参照" : "削除";
                    errorOK(string.Format(Messages.M0013, "削除", "仕入データ", msg1));
                    return false;
                }
            }
            // 仕入ヘッダデータが存在しない場合
            else
            {
                string messageText = lblPurchaseNo.Text;
                // エラーメッセージを出力して処理を終了
                errorOK(string.Format(Messages.M0003, messageText));
                return false;
            }

            // 納品書存在フラグを設定
            flgNohinsyoExsits = !string.IsNullOrEmpty(headerData.UriageDenpyoNo);

            if (flgNohinsyoExsits && rdoDelete.Checked)
            {
                // エラーメッセージを出力して処理を終了
                errorOK(Messages.M0056);
                return false;
            }

            // 取得した仕入ヘッダデータを画面項目に設定します
            if (!rdoNew.Checked) txtPurchaseNo.Text = headerData.ShireNo;
            dtpPurchaseDate.Value = Convert.ToDateTime(headerData.DenpyoHizuke).AddDays(1);
            dtpPurchaseDate.Value = Convert.ToDateTime(headerData.DenpyoHizuke);
            txtVendorCode.Text = headerData.ShiresakiCode;
            txtVendorName.Text = headerData.ShiresakiName;
            if (!string.IsNullOrEmpty(headerData.TantousyaCode))
            {
                cmbPersonnel.SelectedValue = headerData.TantousyaCode;
            }
            cmbPersonnel.Text = headerData.TantousyaName;
            txtOrderNo.Text = headerData.JuchuNoTop + headerData.JuchuNoMid + headerData.JuchuNoBtm;
            txtCustomerCode.Text = headerData.TokuisakiCode;
            txtCustomerName.Text = headerData.TokuisakiName;
            txtCustomerKanaName.Text = headerData.TokuisakiKanaName;
            if (!string.IsNullOrEmpty(headerData.JigyousyoCode))
            {
                cmbOffices.SelectedValue = headerData.JigyousyoCode;
            }
            cmbOffices.Text = headerData.JigyousyoName;
            txtZipCode.Text = headerData.ZipCode;
            txtAddress1.Text = headerData.Addres1;
            txtAddress2.Text = headerData.Addres2;
            txtSalesNo.Text = headerData.UriageDenpyoNo;

            // 取得した仕入ボディデータを仕入明細グリッドに設定します
            grdPurchaseDetails.Rows.Clear();
            int gridRowIndex = 0;
            string unitValue;
            string unitText;
            DataGridViewRow topRow;
            DataGridViewRow btmRow;
            // 単位コンボボックス設定
            setUnitCmb();
            DataTable unitDt = (DataTable)clmUnit.DataSource;
            DBFileLayout.ShireBodyFile wkBodyData;
            for (int i = 0; i < bodyData.Count; i++)
            {
                gridRowIndex = i * grdPurchaseDetails.RowSegmentCount;
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
                topRow = grdPurchaseDetails.Rows[gridRowIndex];
                btmRow = grdPurchaseDetails.Rows[gridRowIndex + 1];
                wkBodyData = bodyData[i];

                // 上段行への値設定
                // 商品名(上段)
                topRow.Cells[clmItemName.Name].Value = wkBodyData.ShouhinName1;
                // エラー状態
                topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                // 下段行への値設定
                // 商品ｺｰﾄﾞ
                btmRow.Cells[clmItemCode.Name].Value = wkBodyData.ShouhinCode;
                // 商品名(下段)
                btmRow.Cells[clmItemName.Name].Value = wkBodyData.ShouhinName2;
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
                unitText = Convert.ToString(wkBodyData.Tani);
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
                btmRow.Cells[clmUnit.Name].Value = unitValue;
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
            }
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 明細金額の集計処理を実行します。
            recalcDetailsTotal();

            // 検索実行済みフラグにtrueを設定
            flgSearch = true;

            if (!flgNohinsyoExsits || rdoNew.Checked)
            {
                // 取得した仕入ボディデータが初期表示件数未満の場合、不足データ分の空行を仕入グリッドに追加します
                addInsufficientEmptyGridRow();
                // 最終行が空行でない場合、行追加
                addLastEmptyRow();
            }
            grdPurchaseDetails.CurrentCell = null;

            // 納品書存在フラグがtrueの場合、メッセージを出力
            if (flgNohinsyoExsits && !rdoReference.Checked && !rdoNew.Checked)
            {
                messageOK(Messages.M0032);
            }

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 受注データ設定処理
        /// <summary>
        /// 受注データ設定処理
        /// </summary>
        /// <param name="juchuDenpyoNo"></param>
        /// <param name="juchuNo"></param>
        /// <returns></returns>
        private bool setJuchuData(string juchuDenpyoNo, string juchuNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            // トランザクション開始処理を実行
            //if (!rdoNew.Checked) shireDataDb.startTransaction();
            shireDataDb.startTransaction();

            // 取得時にエラーが発生した場合
            if (shireDataDb.getJuchuData(juchuDenpyoNo, juchuNo, true) != DBShire.SelectErrorType.None)
            {
                errorOK(string.Format(Messages.M0027, "受注データ"));
                return false;
            }

            DBFileLayout.JuchuHeaderFile headerData = shireDataDb.SelectJuchuData.HeaderData;
            List<DBFileLayout.JuchuBodyFile> bodyData = shireDataDb.SelectJuchuData.BodyDatas;
            DBFileLayout.JuchuFooterFile footerData = shireDataDb.SelectJuchuData.FooterData;

            // 受注ヘッダデータが存在する場合
            if (headerData.FlgDataExsit)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(headerData.KanriKubun)))
                {
                    string msg1 = rdoCorrection.Checked ? "訂正" : rdoReference.Checked ? "参照" : "削除";
                    errorOK(string.Format(Messages.M0013, "削除", "受注データ", msg1));
                    return false;
                }
            }
            // 仕入ヘッダデータが存在しない場合
            else
            {
                string messageText = lblOrderNo.Text;
                // エラーメッセージを出力して処理を終了
                errorOK(string.Format(Messages.M0003, messageText));
                return false;
            }

            // 取得した受注ヘッダデータを画面項目に設定します
            //if (!rdoNew.Checked) txtPurchaseNo.Text = headerData.ShireNo;
            //dtpPurchaseDate.Value = Convert.ToDateTime(headerData.DenpyoHizuke).AddDays(1);
            //dtpPurchaseDate.Value = Convert.ToDateTime(headerData.DenpyoHizuke);
            dtpPurchaseDate.Value = syoriDate.AddDays(1);
            dtpPurchaseDate.Value = syoriDate;
            //txtVendorCode.Text = headerData.ShiresakiCode;
            //txtVendorName.Text = headerData.ShiresakiName;
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            if (!string.IsNullOrEmpty(headerData.TantousyaCode))
            {
                cmbPersonnel.SelectedValue = headerData.TantousyaCode;
            }
            cmbPersonnel.Text = headerData.TantousyaName;
            txtOrderNo.Text = headerData.JuchuNoTop + headerData.JuchuNoMid + headerData.JuchuNoBtm;
            txtCustomerCode.Text = headerData.TokuisakiCode;
            txtCustomerName.Text = headerData.TokuisakiName;
            txtCustomerKanaName.Text = headerData.TokuisakiKanaName;
            if (!string.IsNullOrEmpty(headerData.JigyousyoCode))
            {
                cmbOffices.SelectedValue = headerData.JigyousyoCode;
            }
            cmbOffices.Text = headerData.JigyousyoName;
            txtZipCode.Text = headerData.ZipCode;
            txtAddress1.Text = headerData.Addres1;
            txtAddress2.Text = headerData.Addres2;
            //txtSalesNo.Text = headerData.UriageDenpyoNo;
            txtSalesNo.Text = string.Empty;

            // 取得した受注ボディデータを仕入明細グリッドに設定します
            grdPurchaseDetails.Rows.Clear();
            int gridRowIndex = 0;
            string unitValue;
            string unitText;
            DataGridViewRow topRow;
            DataGridViewRow btmRow;
            // 単位コンボボックス設定
            setUnitCmb();
            DataTable unitDt = (DataTable)clmUnit.DataSource;
            DBFileLayout.JuchuBodyFile wkBodyData;
            for (int i = 0; i < bodyData.Count; i++)
            {
                gridRowIndex = i * grdPurchaseDetails.RowSegmentCount;
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
                topRow = grdPurchaseDetails.Rows[gridRowIndex];
                btmRow = grdPurchaseDetails.Rows[gridRowIndex + 1];
                wkBodyData = bodyData[i];

                // 上段行への値設定
                // 商品名(上段)
                topRow.Cells[clmItemName.Name].Value = wkBodyData.ShouhinName1;
                // エラー状態
                topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                // 下段行への値設定
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
                unitText = Convert.ToString(wkBodyData.JuchuTani);
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
                btmRow.Cells[clmUnit.Name].Value = unitValue;
                // 単価
                if (wkBodyData.ShireTanka == null)
                {
                    btmRow.Cells[clmBid.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmBid.Name].Value = Convert.ToDecimal(wkBodyData.ShireTanka).ToString(bidFormat);
                }
                // 金額
                if (wkBodyData.ShireKingaku == null)
                {
                    btmRow.Cells[clmAmount.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmAmount.Name].Value = Convert.ToDecimal(wkBodyData.ShireKingaku).ToString(amountFormat);
                }
                btmRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;
                btmRow.Cells[clmTopClassificationCode.Name].Value = Convert.ToString(wkBodyData.DaiBunruiCode);
                btmRow.Cells[clmbtmClassificationCode.Name].Value = Convert.ToString(wkBodyData.SyoBunruiCode);
            }
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 取得した仕入ボディデータが初期表示件数未満の場合、不足データ分の空行を仕入グリッドに追加します
            addInsufficientEmptyGridRow();
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();
            grdPurchaseDetails.CurrentCell = null;

            // 明細金額の集計処理を実行します。
            recalcDetailsTotal();

            // 検索実行済みフラグにtrueを設定
            flgSearch = true;

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
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

            // TODO

            return ret;
        }
        #endregion

        #region 仕入グリッドの中間空白行存在チェック処理
        /// <summary>
        /// 仕入グリッドの中間空白行存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkMiddleEmptyRowExist()
        {
            bool flgEmptyRow = false;
            for (int i = 0; i < grdPurchaseDetails.Rows.Count; i++)
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

        #region 仕入グリッドの中間空白行削除処理
        /// <summary>
        /// 仕入グリッドの中間空白行削除処理
        /// </summary>
        private void deleteAllEmptyRow()
        {
            for (int i = grdPurchaseDetails.Rows.Count - 1; i >= 0; i--)
            {
                if (checkEmptyRow(i - 1))
                {
                    grdPurchaseDetails.Rows.Remove(grdPurchaseDetails.Rows[i]);
                    grdPurchaseDetails.Rows.Remove(grdPurchaseDetails.Rows[i - 1]);
                }
                i--;
            }

            // 仕入ボディデータが初期表示件数未満の場合、不足データ分の空行を仕入グリッドに追加します
            addInsufficientEmptyGridRow();

            // 最終行が空行でない場合、行追加
            addLastEmptyRow();
        }
        #endregion

        #region 仕入ヘッダ登録・更新SQL生成処理
        /// <summary>
        /// 仕入ヘッダ登録・更新SQL生成処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createHeaderRegistSql(ref string shireNo, DateTime registerDate)
        {
            // TODO
            string sql = string.Empty;
            DateTime denpyoHizuke = commonLogic.convertDateTime(txtPurchaseDateYears.Text, txtPurchaseDateMonth.Text, txtPurchaseDateDays.Text);
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            string chihouCode = string.Empty;
            string chikuCode = string.Empty;
            string tokuisakiCode = txtCustomerCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string jigyousyoName = cmbOffices.Text;
            string zipCode = txtZipCode.Text;
            string addres1 = txtAddress1.Text;
            string addres2 = txtAddress2.Text;
            string tantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);
            string tantousyaName = cmbPersonnel.Text;
            //string kenmeiNo = txtConstructionNo.Text;
            //string kenmei1 = txtSubject1.Text;
            //string kenmei2 = txtSubject2.Text;
            string hachuNo = txtOrderNo.Text;
            if (!string.IsNullOrEmpty(hachuNo))
            {
                commonLogic.SubStringJuchuNo(hachuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            }
            string shiresakiCode = txtVendorCode.Text;
            string shiresakiName = txtVendorName.Text;
            string uriageDenpyoNo = txtSalesNo.Text;
            DBTokuisakiMaster dBTokuisaki = new DBTokuisakiMaster();
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = dBTokuisaki.getTokuisakiInfo(tokuisakiCode, jigyousyoCode);
            if (tokuisakiInfos != null && tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
            }

            if (rdoNew.Checked)
            {
                // 伝票No採番
                shireNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getShireNo() + 1).ToString(), txtPurchaseNo.MaxLength);

                // 仕入ヘッダの登録SQL生成
                sql += "INSERT INTO shire_header ";
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
                //sql += ", kenmeiNo ";
                //sql += ", kenmei1 ";
                //sql += ", kenmei2 ";
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
                //sql += "," + "'" + kenmeiNo + "' ";
                //sql += "," + "'" + kenmei1 + "' ";
                //sql += "," + "'" + kenmei2 + "' ";
                sql += "," + "'" + hachuNo + "' ";
                sql += "," + "'" + shiresakiCode + "' ";
                sql += "," + "'" + shiresakiName + "' ";
                sql += "," + "'" + uriageDenpyoNo + "' ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 仕入ヘッダの更新SQL生成
                sql = "UPDATE shire_header SET ";
                sql += "  shireNo = '" + shireNo + "' ";
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
                sql += ", zipCode = '" + zipCode + "' ";
                sql += ", addres1 = '" + addres1 + "' ";
                sql += ", addres2 = '" + addres2 + "' ";
                sql += ", tantousyaCode = '" + tantousyaCode + "' ";
                sql += ", tantousyaName = '" + tantousyaName + "' ";
                //sql += ", kenmeiNo = '" + kenmeiNo + "' ";
                //sql += ", kenmei1 = '" + kenmei1 + "' ";
                //sql += ", kenmei2 = '" + kenmei2 + "' ";
                sql += ", hachuNo = '" + hachuNo + "' ";
                sql += ", shiresakiCode = '" + shiresakiCode + "' ";
                sql += ", shiresakiName = '" + shiresakiName + "' ";
                sql += ", uriageDenpyoNo = '" + uriageDenpyoNo + "' ";
                sql += ", kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '' ";
                sql += "WHERE shireNo = '" + shireNo + "' ";
            }
            else
            {
                // 仕入ヘッダの論理削除SQL生成
                sql = "UPDATE shire_header SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE shireNo = '" + shireNo + "' ";
            }

            return sql;
        }
        #endregion

        #region 仕入ボディ登録・更新SQL生成処理
        /// <summary>
        /// 仕入ボディ登録・更新SQL生成処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createBodyRegistSql(string shireNo, DateTime registerDate)
        {
            List<string> sqlBodys = new List<string>();
            string sql = string.Empty;

            if (rdoDelete.Checked)
            {
                // 仕入ボディの論理削除SQL生成
                sql = "UPDATE shire_body SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE shireNo = '" + shireNo + "' ";
                sqlBodys.Add(sql);
            }
            else
            {
                // 仕入ボディの登録・更新SQL生成
                int rowNo = 0;
                int juchuRowNo = 0;
                string daiBunruiCode = string.Empty;
                string syoBunruiCode = string.Empty;
                string shouhinCode = string.Empty;
                string shouhinName1 = string.Empty;
                string shouhinName2 = string.Empty;
                string suryo = string.Empty;
                string tani = string.Empty;
                string tanka = string.Empty;
                string kingaku = string.Empty;
                string bikou = string.Empty;
                string selectCommand = string.Empty;
                DataTable selectRes;
                for (int i = 0; i < grdPurchaseDetails.Rows.Count; i++)
                {
                    if (checkEmptyRow(i))
                    {
                        break;
                    }

                    rowNo = ((int)(i / grdPurchaseDetails.RowSegmentCount) + 1);
                    //juchuRowNo = Convert.ToInt16(grdPurchaseDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                    daiBunruiCode = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                    syoBunruiCode = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmbtmClassificationCode.Name].Value);
                    shouhinCode = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmItemCode.Name].Value);
                    shouhinName1 = Convert.ToString(grdPurchaseDetails.Rows[i].Cells[clmItemName.Name].Value);
                    shouhinName2 = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmItemName.Name].Value);
                    suryo = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmQuantity.Name].Value);
                    tani = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmUnit.Name].Value);
                    tanka = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmBid.Name].FormattedValue);
                    kingaku = Convert.ToString(grdPurchaseDetails.Rows[i + 1].Cells[clmAmount.Name].Value);

                    selectCommand = "SELECT 1 FROM shire_body ";
                    selectCommand += "WHERE shireNo = '" + shireNo + "' ";
                    selectCommand += "AND rowNo = " + rowNo;
                    selectRes = shireDataDb.executeSelect(selectCommand, false);
                    if (selectRes != null && selectRes.Rows.Count > 0)
                    {
                        // 同一行番号のデータが登録済みのため更新処理
                        sql = "UPDATE shire_body SET ";
                        sql += "  shireNo = " + "'" + shireNo + "' ";
                        sql += ", rowNo = " + rowNo + " ";
                        sql += ", juchuRowNo = " + juchuRowNo + " ";
                        sql += ", daiBunruiCode = " + "'" + daiBunruiCode + "' ";
                        sql += ", syoBunruiCode = " + "'" + syoBunruiCode + "' ";
                        sql += ", shouhinCode = " + "'" + shouhinCode + "' ";
                        sql += ", shouhinName1 = " + "'" + shouhinName1 + "' ";
                        sql += ", shouhinName2 = " + "'" + shouhinName2 + "' ";
                        sql += ", suryo = " + (string.IsNullOrEmpty(suryo) ? "null" : Convert.ToDecimal(suryo).ToString()) + " ";
                        sql += ", tani = " + "'" + tani + "' ";
                        sql += ", tanka = " + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                        sql += ", kingaku = " + (string.IsNullOrEmpty(kingaku) ? "null" : Convert.ToDecimal(kingaku).ToString()) + " ";
                        sql += ", bikou = " + "'" + bikou + "' ";
                        sql += ", kousinNichizi = '" + registerDate + "' ";
                        sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE0 + "' ";
                        sql += "WHERE shireNo = '" + shireNo + "' ";
                        sql += "AND rowNo = " + rowNo;
                    }
                    else
                    {
                        // 同一行番号のデータが未登録のため登録処理
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
                        sql += "," + rowNo + " ";
                        sql += "," + juchuRowNo + " ";
                        sql += "," + "'" + daiBunruiCode + "' ";
                        sql += "," + "'" + syoBunruiCode + "' ";
                        sql += "," + "'" + shouhinCode + "' ";
                        sql += "," + "'" + shouhinName1 + "' ";
                        sql += "," + "'" + shouhinName2 + "' ";
                        sql += "," + (string.IsNullOrEmpty(suryo) ? "null" : Convert.ToDecimal(suryo).ToString()) + " ";
                        sql += "," + "'" + tani + "' ";
                        sql += "," + (string.IsNullOrEmpty(tanka) ? "null" : Convert.ToDecimal(tanka).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(kingaku) ? "null" : Convert.ToDecimal(kingaku).ToString()) + " ";
                        sql += "," + "'" + bikou + "' ";
                        sql += "," + "'" + registerDate + "' ";
                        sql += "," + "'' ";
                        sql += ") ";
                    }
                    sqlBodys.Add(sql);

                    i++;
                }

                // 今回登録以外のデータを削除
                sql = "DELETE FROM shire_body ";
                sql += "WHERE shireNo = '" + shireNo + "' ";
                sql += "AND rowNo > " + rowNo;

                sqlBodys.Add(sql);
            }

            return sqlBodys;
        }
        #endregion

        #region 仕入フッタ登録・更新SQL生成処理
        /// <summary>
        /// 仕入フッタ登録・更新SQL生成処理
        /// </summary>
        /// <param name="shireNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createFooterRegistSql(string shireNo, DateTime registerDate)
        {
            string sql = string.Empty;

            if (rdoDelete.Checked)
            {
                // 仕入フッタの論理削除SQL生成
                sql = "UPDATE shire_footer SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE shireNo = '" + shireNo + "' ";
            }
            else
            {
                string shireKingaku = Convert.ToString(grdPurchaseDetailsTotal.Rows[0].Cells[clmTotalAmount.Name].Value);

                if (rdoNew.Checked)
                {
                    // 仕入フッタの登録SQL生成
                    sql += "INSERT INTO shire_footer ";
                    sql += "( ";
                    sql += "  shireNo ";
                    sql += ", shireKingaku ";
                    sql += ", kousinNichizi ";
                    sql += ", kanriKubun ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "'" + shireNo + "' ";
                    sql += "," + (string.IsNullOrEmpty(shireKingaku) ? "null" : Convert.ToDecimal(shireKingaku).ToString()) + " ";
                    sql += "," + "'" + registerDate + "' ";
                    sql += "," + "'' ";
                    sql += ") ";
                }
                else
                {
                    // 仕入フッタの更新SQL生成
                    sql = "UPDATE shire_footer SET ";
                    sql += "  shireNo = '" + shireNo + "' ";
                    sql += ", shireKingaku = " + (string.IsNullOrEmpty(shireKingaku) ? "null" : Convert.ToDecimal(shireKingaku).ToString()) + " ";
                    sql += ", kousinNichizi = '" + registerDate + "' ";
                    sql += ", kanriKubun = '' ";
                    sql += "WHERE shireNo = '" + shireNo + "' ";
                }
            }

            return sql;
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
            sql += "UPDATE juchu_body jb ";
            sql += "LEFT JOIN (SELECT sh.juchuNoTop ";
            sql += "                , sh.juchuNoMid ";
            sql += "                , sh.juchuNoBtm ";
            sql += "                , sb.juchuRowNo ";
            sql += "                , SUM(IFNULL(suryo, 0)) AS shireSuryo ";
            sql += "           FROM ( ";
            sql += "                  SELECT * ";
            sql += "                  FROM shire_header ";
            sql += "                  WHERE juchuNoTop='" + juchuNoTop + "' ";
            sql += "                  AND juchuNoMid='" + juchuNoMid + "' ";
            sql += "                  AND juchuNoBtm='" + juchuNoBtm + "' ";
            sql += "                  AND kanriKubun != '" + Consts.KanriCodeTypes.TYPE9 + "' ";
            sql += "		        ) sh ";
            sql += "           INNER JOIN ( ";
            sql += "                        SELECT * ";
            sql += "                        FROM shire_body ";
            sql += "			          ) sb ";
            sql += "           ON(sh.shireNo = sb.shireNo) ";
            sql += "           GROUP BY sh.juchuNoTop ";
            sql += "                  , sh.juchuNoMid ";
            sql += "                  , sh.juchuNoBtm ";
            sql += "                  , sb.juchuRowNo ";
            sql += "          ) ss ";
            sql += "ON (jb.juchuNoTop = ss.juchuNoTop ";
            sql += "AND jb.juchuNoMid = ss.juchuNoMid ";
            sql += "AND jb.juchuNoBtm = ss.juchuNoBtm ";
            sql += "AND jb.rowNo = ss.juchuRowNo) ";
            sql += "SET jb.shireNouhinZanSuryo = CASE WHEN jb.juchuSuryo - ss.shireSuryo < 0 THEN 0 ELSE jb.juchuSuryo - ss.shireSuryo END ";
            sql += "  , jb.shireNouhinSuryo = ss.shireSuryo ";
            sql += "  , jb.kousinNichizi = '" + registerDate + "' ";

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

        #endregion
    }
}
