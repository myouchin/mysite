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
using Common;
using Resorce;
using SubForm;
using PrintInstructions;

namespace Juchu
{
    public partial class frmJuchuInput : ChildBaseForm
    {
        #region 変数定義
        private string detailsTotalTitle1 = "受　注　計";
        private string detailsTotalTitle2 = "仕　入　計";
        private string mitumoriSearchText = "見積検索";
        private string juchuSearchText = "受注検索";
        private string tokuisakiSearchText = "得意先検索";
        private string kenmeiSearchText = "件名検索";
        private bool flgSaving = false;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private DataGridViewRow copyGridTopRow = null;
        private DataGridViewRow copyGridBtmRow = null;
        private int gridStartRowCount = 5;
        private RadioButton activeRadioButton = null;
        private CommonLogic commonLogic;
        private string dummyCode = "Dummy";
        private string beforeCellValue;
        private bool flgBtnSearchSelect = false;
        private bool flgOfficeCmbChanged = false;
        private bool flgNouhinsyoOutput = false;
        DBCommon juchuDataSelectDb;
        private string strAllDelete = "ALLDELETE";
        private string printDocumentNo = string.Empty;
        private enum LastInputDateType
        {
            None = 0
          , DocumentDate = 1
          , ShipDate = 2
          , OnTheDay = 3
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DBMeisyoMaster meisyoMaster;
        private DBTantousyaMaster tantousyaMaster;
        private DBTokuisakiMaster tokuisakiMaster;
        private DBShiresakiMaster shiresakiMaster;
        private DBShouhinMaster shouhinMaster;
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private int ordersQuantityIntegerLength = 8;
        private int ordersQuantityDecimalLength = 0;
        private int ordersBidIntegerLength = 8;
        private int ordersBidDecimalLength = 0;
        private int ordersAmountIntegerLength = 8;
        private int ordersAmountDecimalLength = 0;
        private int purchaseBidIntegerLength = 8;
        private int purchaseBidDecimalLength = 0;
        private int purchaseAmountIntegerLength = 8;
        private int purchaseAmountDecimalLength = 0;
        private int purchaseDeliveryQuantityIntegerLength = 8;
        private int purchaseDeliveryQuantityDecimalLength = 0;
        private string ordersQuantityFormat;
        private string ordersBidFormat;
        private string ordersAmountFormat;
        private string purchaseBidFormat;
        private string purchaseAmountFormat;
        private string purchaseDeliveryQuantityFormat;
        private bool flgSetJuchuData = false;
        bool flgSetOfficesCmb = false;
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
            /// 受注数量入力時の再計算
            /// </summary>
          , OrdersQuantityInput = 1
            /// <summary>
            /// 受注単価入力時の再計算
            /// </summary>
          , OrdersBidInput = 2
            /// <summary>
            /// 仕入単価入力時の再計算
            /// </summary>
          , PurchaseBidInput = 3
        }
        bool flgDeletingRow = false;
        sfrmTokuisakiSearch fTokuisaki;
        sfrmMitumoriSearch fMitumori;
        sfrmJuchuSearch sJuchu;
        sfrmKenmeiSearch sKenmei;
        sfrmShouhinSearch fShouhin;
        sfrmShiiresakiSearch sShiresaki;
        #endregion

        #region 発注情報登録SQLクラス
        /// <summary>
        /// 発注情報登録SQLクラス
        /// </summary>
        private class HachuRegistSqlClass
        {
            #region 変数宣言
            /// <summary>
            /// 発注No
            /// </summary>
            private string hachuNo;
            /// <summary>
            /// 発注金額
            /// </summary>
            private string hachuKingaku;
            /// <summary>
            /// 発注ヘッダ登録SQL
            /// </summary>
            private string headerSql;
            /// <summary>
            /// 発注ボディ登録SQL
            /// </summary>
            private List<string> bodySql;
            /// <summary>
            /// 発注フッタ登録SQL
            /// </summary>
            private string footerSql;
            #endregion

            #region 取得・設定
            /// <summary>
            /// 発注No取得・設定
            /// </summary>
            public string HachuNo
            {
                get { return hachuNo; }
                set { hachuNo = value; }
            }

            /// <summary>
            /// 発注金額取得・設定
            /// </summary>
            public string HachuKingaku
            {
                get { return hachuKingaku; }
                set { hachuKingaku = value; }
            }

            /// <summary>
            /// 発注ヘッダ登録SQL取得・設定
            /// </summary>
            public string HeaderSql
            {
                get { return headerSql; }
                set { headerSql = value; }
            }

            /// <summary>
            /// 発注ボディ登録SQL取得・設定
            /// </summary>
            public List<string> BodySql
            {
                get { return bodySql; }
                set { bodySql = value; }
            }

            /// <summary>
            /// 発注フッタ登録SQL取得・設定
            /// </summary>
            public string FooterSql
            {
                get { return footerSql; }
                set { footerSql = value; }
            }
            #endregion

            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public HachuRegistSqlClass()
            {
                HachuNo = null;
                HachuKingaku = null;
                HeaderSql = string.Empty;
                BodySql = new List<string>();
                FooterSql = string.Empty;
            }
            #endregion
        }
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmJuchuInput()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            tantousyaMaster = new DBTantousyaMaster();
            meisyoMaster = new DBMeisyoMaster();
            shouhinMaster = new DBShouhinMaster();
            tokuisakiMaster = new DBTokuisakiMaster();
            shiresakiMaster = new DBShiresakiMaster();
            commonLogic = new CommonLogic();
            juchuDataSelectDb = new DBCommon();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            fMitumori = new sfrmMitumoriSearch(false, CheckMessageType.None);
            sJuchu = new sfrmJuchuSearch(false, CheckMessageType.None);
            sKenmei = new sfrmKenmeiSearch(false, CheckMessageType.None);
            fShouhin = new sfrmShouhinSearch(false);
            sShiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJuchuInput_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtDocumentNo;
            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 発行者コンボボックス設定
            setPublisherCmb();
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 材料・工事区分コンボボックス設定
            setMaterialsConstructionTypeCmb();
            // 単位コンボボックス設定
            setUnitCmb();
            // 仕入・部材区分コンボボックス設定
            setPurchasePartsTypeCmb();
            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 入力情報設定
            setInputInfo();
            // 受注数量フォーマット文字列取得
            ordersQuantityFormat = commonLogic.getNumberFormatString(ordersQuantityIntegerLength, ordersQuantityDecimalLength);
            // 受注単価フォーマット文字列取得
            ordersBidFormat = commonLogic.getNumberFormatString(ordersBidIntegerLength, ordersBidDecimalLength);
            // 受注金額フォーマット文字列取得
            ordersAmountFormat = commonLogic.getNumberFormatString(ordersAmountIntegerLength, ordersAmountDecimalLength);
            // 仕入単価フォーマット文字列取得
            purchaseBidFormat = commonLogic.getNumberFormatString(purchaseBidIntegerLength, purchaseBidDecimalLength);
            // 仕入金額フォーマット文字列取得
            purchaseAmountFormat = commonLogic.getNumberFormatString(purchaseAmountIntegerLength, purchaseAmountDecimalLength);
            // 仕入先納品数フォーマット文字列取得
            purchaseDeliveryQuantityFormat = commonLogic.getNumberFormatString(purchaseDeliveryQuantityIntegerLength, purchaseDeliveryQuantityDecimalLength);

            this.grdOrdersDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdOrdersDetails.ColumnHeadersHeight = (this.grdOrdersDetails.ColumnHeadersHeight + 6) * grdOrdersDetails.RowSegmentCount;
            this.grdOrdersDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            grdOrdersDetails.setDoubleBuffered();
        }
        #endregion

        #region 画面モードラジオボタン押下処理
        /// <summary>
        /// 画面モードラジオボタン押下処理
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

        #region 備考入力ボタン押下イベント
        /// <summary>
        /// 備考入力ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputRemark_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力し処理を終了する
            if (grdOrdersDetails.CurrentCell == null)
            {
                errorOK(Messages.M0025);
                return;
            }

            int bikouRowIndex = grdOrdersDetails.CurrentCell.RowIndex;
            if (grdOrdersDetails.CurrentCell.RowIndex % grdOrdersDetails.RowSegmentCount == 0) bikouRowIndex++;
            DataGridViewRow bikouRow = grdOrdersDetails.Rows[bikouRowIndex];
            string bikou = Convert.ToString(bikouRow.Cells[clmRemarks.Name].Value);
            frmBikouInput bikouInput = new frmBikouInput(bikou, (rdoReference.Checked || rdoDelete.Checked));
            bikouInput.StartPosition = FormStartPosition.CenterScreen;
            if (bikouInput.ShowDialog() == DialogResult.OK)
            {
                bikouRow.Cells[clmRemarks.Name].Value = bikouInput.getBikouText();
            }
            grdOrdersDetails.Refresh();
            grdOrdersDetails.BeginEdit(true);
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
            if (grdOrdersDetails.CurrentRow == null)
            {
                errorOK(Messages.M0004);
                return;
            }

            // 選択行から上段行のINDEXを取得
            int selectedGridTopRowIndex = grdOrdersDetails.CurrentRow.Index;
            if (selectedGridTopRowIndex % grdOrdersDetails.RowSegmentCount != 0)
            {
                selectedGridTopRowIndex = grdOrdersDetails.CurrentRow.Index - 1;
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
                copyGridTopRow = grdOrdersDetails.Rows[selectedGridTopRowIndex];
                copyGridBtmRow = grdOrdersDetails.Rows[selectedGridTopRowIndex + 1];
            }
            // 行複写ボタンのテキスト設定
            setRowCopyBtnText();
            grdOrdersDetails.Focus();
            grdOrdersDetails.Refresh();
            if (flgCancelCopy)
            {
                grdOrdersDetails.CurrentCell = grdOrdersDetails[clmItemAndOpponentCode.DisplayIndex, selectedGridTopRowIndex + 1];
                grdOrdersDetails.BeginEdit(true);
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
            if (grdOrdersDetails.CurrentRow == null ||
                copyGridTopRow.Index == grdOrdersDetails.CurrentCell.RowIndex ||
                copyGridBtmRow.Index == grdOrdersDetails.CurrentCell.RowIndex)
            {
                errorOK(Messages.M0006);
                return;
            }
            Int16 nouhinRowCount;
            Int16.TryParse(Convert.ToString(grdOrdersDetails.CurrentRow.Cells[clmNouhinRowCount.Name].Value), out nouhinRowCount);
            // 貼付対象行が納品書作成済みの場合、エラーメッセージを出力する
            if (nouhinRowCount == 1)
            {
                errorOK(Messages.M0059);
                return;
            }

            // 貼付対象行が入力済みの場合、確認メッセージを出力する
            int currentTopRowIndex;
            int currentBtmRowIndex;
            if (grdOrdersDetails.CurrentCell.RowIndex % grdOrdersDetails.RowSegmentCount == 0)
            {
                currentTopRowIndex = grdOrdersDetails.CurrentCell.RowIndex;
                currentBtmRowIndex = grdOrdersDetails.CurrentCell.RowIndex + 1;
            }
            else
            {
                currentTopRowIndex = grdOrdersDetails.CurrentCell.RowIndex - 1;
                currentBtmRowIndex = grdOrdersDetails.CurrentCell.RowIndex;
            }

            // 入力済みの行を選択している場合、確認メッセージを出力
            if (!checkEmptyRow(currentTopRowIndex) &&
                queryYesNo(Messages.M0007) == DialogResult.No)
            {
                return;
            }

            // 貼り付け処理を実行
            string afterItemCd = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmItemAndOpponentCode.Name].Value);
            string afterItemNm1 = Convert.ToString(grdOrdersDetails.Rows[copyGridTopRow.Index].Cells[clmItemName.Name].Value);
            string afterItemNm2 = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmItemName.Name].Value);
            string afterJuchuSuryo = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmOrdersQuantity.Name].Value);
            string afterTani = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmUnit.Name].Value); ;
            string afterJuchuTanka = Convert.ToString(grdOrdersDetails.Rows[copyGridTopRow.Index].Cells[clmOrdersBidAndAmount.Name].Value);
            string afterJuchuKingaku = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmOrdersBidAndAmount.Name].Value);
            string afterShireCode = Convert.ToString(grdOrdersDetails.Rows[copyGridTopRow.Index].Cells[clmVendorCodeAndName.Name].Value);
            string afterShireName = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmVendorCodeAndName.Name].Value);
            string afterShireBuzai = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmPurchasePartsType.Name].Value);
            string afterShireTanka = Convert.ToString(grdOrdersDetails.Rows[copyGridTopRow.Index].Cells[clmPurchaseBidAndAmount.Name].Value);
            string afterShireKingaku = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmPurchaseBidAndAmount.Name].Value);
            string afterTopClassification = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmTopClassificationCode.Name].Value);
            string afterBtmClassification = Convert.ToString(grdOrdersDetails.Rows[copyGridBtmRow.Index].Cells[clmbtmClassificationCode.Name].Value);

            // 商品ｺｰﾄﾞ
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmItemAndOpponentCode.Name].Value = afterItemCd;
            // 商品名(上段)
            grdOrdersDetails.Rows[currentTopRowIndex].Cells[clmItemName.Name].Value = afterItemNm1;
            // 商品名(下段)
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmItemName.Name].Value = afterItemNm2;
            // 受注数量
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmOrdersQuantity.Name].Value = afterJuchuSuryo;
            // 単位
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmUnit.Name].Value = afterTani;
            // 受注単価
            grdOrdersDetails.Rows[currentTopRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = afterJuchuTanka;
            // 受注金額
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = afterJuchuKingaku;
            // 仕入先ｺｰﾄﾞ
            grdOrdersDetails.Rows[currentTopRowIndex].Cells[clmVendorCodeAndName.Name].Value = afterShireCode;
            // 仕入先名
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmVendorCodeAndName.Name].Value = afterShireName;
            // 仕入・部材
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmPurchasePartsType.Name].Value = afterShireBuzai;
            // 仕入単価
            grdOrdersDetails.Rows[currentTopRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = afterShireTanka;
            // 仕入金額
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = afterShireKingaku;
            // 大分類コード
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmTopClassificationCode.Name].Value = afterTopClassification;
            // 小分類コード
            grdOrdersDetails.Rows[currentBtmRowIndex].Cells[clmbtmClassificationCode.Name].Value = afterBtmClassification;

            // 明細金額の集計処理を実行
            recalcDetailsTotal();
            // 受注金額の集計処理を実行
            recalcOrdersTotal();

            // 最終行に貼り付けを行った場合、行追加
            addLastEmptyRow();

            if (grdOrdersDetails.CurrentCell != null)
            {
                grdOrdersDetails.BeginEdit(true);
            }
        }
        #endregion

        #region 行挿入ボタン押下処理
        /// <summary>
        /// 行挿入押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            // 行未選択の場合、エラーメッセージを出力する
            if (grdOrdersDetails.CurrentRow == null)
            {
                errorOK(Messages.M0008);
                return;
            }

            Int16 nouhinRowCount;
            Int16.TryParse(Convert.ToString(grdOrdersDetails.CurrentRow.Cells[clmNouhinRowCount.Name].Value), out nouhinRowCount);
            // 貼付対象行が納品書作成済みの場合、エラーメッセージを出力する
            if (nouhinRowCount == 1)
            {
                errorOK(Messages.M0060);
                return;
            }

            // 行挿入
            int insertIndex = grdOrdersDetails.CurrentRow.Index % grdOrdersDetails.RowSegmentCount == 0 ? grdOrdersDetails.CurrentRow.Index : grdOrdersDetails.CurrentRow.Index - 1;
            // 受注グリッドへ空行を追加
            insertEmptyGridRow(insertIndex);

            // 受注グリッドの再描画
            grdOrdersDetails.CurrentCell = grdOrdersDetails[clmItemAndOpponentCode.DisplayIndex, insertIndex + 1];
            //grdOrdersDetails.Refresh();
            grdOrdersDetails.BeginEdit(true);
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
            if (grdOrdersDetails.CurrentRow == null)
            {
                errorOK(Messages.M0009);
                return;
            }
            Int16 nouhinRowCount;
            Int16.TryParse(Convert.ToString(grdOrdersDetails.CurrentRow.Cells[clmNouhinRowCount.Name].Value), out nouhinRowCount);
            // 貼付対象行が納品書作成済みの場合、エラーメッセージを出力する
            if (nouhinRowCount == 1)
            {
                errorOK(Messages.M0061);
                return;
            }
            int deleteIndex = grdOrdersDetails.CurrentRow.Index % grdOrdersDetails.RowSegmentCount == 0 ? grdOrdersDetails.CurrentRow.Index : grdOrdersDetails.CurrentRow.Index - 1;
            // 複写中の行を選択している場合、エラーメッセージを出力し処理を終了する
            if (copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == deleteIndex || copyGridBtmRow.Index == deleteIndex))
            {
                errorOK(string.Format(Messages.M0016, "複写中", "削除", "(削除する場合は、複写行を選択し取消ボタンを押下してください。)"));
                return;
            }

            flgDeletingRow = true;
            grdOrdersDetails.Rows.Remove(grdOrdersDetails.Rows[deleteIndex + 1]);
            grdOrdersDetails.Rows.Remove(grdOrdersDetails.Rows[deleteIndex]);
            flgDeletingRow = false;

            // 明細金額の集計処理を実行
            recalcDetailsTotal();
            // 受注金額の集計処理を実行
            recalcOrdersTotal();

            // 不足分の空行追加処理
            addInsufficientEmptyGridRow(); ;
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();

            if (grdOrdersDetails.Rows.Count == 0)
            {
            }
            //else if (grdOrdersDetails.Rows.Count >= deleteIndex + 1)
            else if (deleteIndex == 0)
            {
                grdOrdersDetails.CurrentCell = grdOrdersDetails[clmItemAndOpponentCode.DisplayIndex, deleteIndex + 1];
            }
            else
            {
                grdOrdersDetails.CurrentCell = grdOrdersDetails[clmItemAndOpponentCode.DisplayIndex, deleteIndex - 1];
            }
            //grdOrdersDetails.Refresh();
        }
        #endregion

        #region 検索ボタン押下処理
        /// <summary>
        /// 検索ボタン押下処理
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
            // 伝票Noを編集中 または
            // 受注Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDocumentNo.Name) ||
                     activeControlInfo.Control.Name.Equals(txtOrdersNo.Name))
            {
                bool flgMitumoriSearch = false;
                if (rdoNew.Checked)
                {
                    // 見積検索または受注検索の選択画面を表示
                    frmSearchDiplaySelect searchDiplaySelect = new frmSearchDiplaySelect(mitumoriSearchText, juchuSearchText);
                    searchDiplaySelect.StartPosition = FormStartPosition.CenterScreen;
                    searchDiplaySelect.ShowDialog();
                    flgMitumoriSearch = (searchDiplaySelect.DisplayType == frmSearchDiplaySelect.StartDisplayType.SearchDiplay1);
                }

                if (flgMitumoriSearch)
                {
                    // 見積検索画面を起動
                    fMitumori.MType = messageType;
                    fMitumori.ShowDialog();

                    if (fMitumori.DialogResult == DialogResult.OK)
                    {
                        flgSearch = false;
                        // 見積情報の設定
                        setMitumoriData(fMitumori.SelectedMitumoriNumbers[0]);
                        // 画面項目制御処理を実行
                        setEnabled();
                    }
                    flgSetFocus = true;
                }
                else
                {
                    // 受注検索画面を起動
                    sJuchu.MType = messageType;
                    sJuchu.ShowDialog();

                    if (sJuchu.DialogResult == DialogResult.OK)
                    {
                        flgSearch = false;
                        // 受注情報の設定
                        setJuchuData(sJuchu.SelectedJuchuInfos[0].DocumentNo, string.Empty, true);
                        // 画面項目制御処理を実行
                        setEnabled();
                    }
                    flgSetFocus = true;
                }
            }
            // 件名Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtConstructionNo.Name))
            {
                // 件名検索画面を起動
                sKenmei.MType = messageType;
                sKenmei.ShowDialog();

                if (sKenmei.DialogResult == DialogResult.OK)
                {
                    // 納入先情報設定
                    setNonyuSakiInfo(string.Empty, string.Empty, sKenmei.SelectedKenmeiNos[0], true, true);
                }
                flgSetFocus = true;
            }
            // 納入先名を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDeliveredName.Name))
            {
                DialogResult dialogResult = DialogResult.None;
                bool flgTokuisakiSearch = false;
                string tokuisakiCode = string.Empty;
                string jugyousyoCode = string.Empty;
                string kenmeiNo = string.Empty;
                // 得意先検索または件名検索の選択画面を表示
                frmSearchDiplaySelect searchDiplaySelect = new frmSearchDiplaySelect(tokuisakiSearchText, kenmeiSearchText);
                searchDiplaySelect.StartPosition = FormStartPosition.CenterScreen;
                searchDiplaySelect.ShowDialog();
                flgTokuisakiSearch = (searchDiplaySelect.DisplayType == frmSearchDiplaySelect.StartDisplayType.SearchDiplay1);

                if (flgTokuisakiSearch)
                {
                    // 得意先検索画面を起動
                    dialogResult = fTokuisaki.ShowDialog();

                    // 得意先検索画面で確認ボタンが押下された場合
                    if (fTokuisaki.DialogResult == DialogResult.OK)
                    {
                        tokuisakiCode = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                        jugyousyoCode = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                    }
                }
                else
                {
                    // 件名検索画面を起動
                    sKenmei.MType = messageType;
                    dialogResult = sKenmei.ShowDialog();

                    // 件名検索画面で確認ボタンが押下された場合
                    if (sKenmei.DialogResult == DialogResult.OK)
                    {
                        kenmeiNo = sKenmei.SelectedKenmeiNos[0];
                    }
                }
                if (dialogResult == DialogResult.OK)
                {
                    // 納入先情報設定
                    setNonyuSakiInfo(tokuisakiCode, jugyousyoCode, kenmeiNo, true, false);
                }
                flgSetFocus = true;
            }
            // 見積グリッドを編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞ列の場合
                if (activeControlInfo.RowIndex % grdOrdersDetails.RowSegmentCount != 0 &&
                    activeControlInfo.ClmIndex == clmItemAndOpponentCode.DisplayIndex)
                {
                    grdOrdersDetails.CancelEdit();
                    // 商品検索画面を起動
                    fShouhin.ShowDialog();

                    // 商品検索画面で確認ボタンが押下された場合
                    if (fShouhin.DialogResult == DialogResult.OK)
                    {
                        // 商品情報設定処理
                        setShouhinInfo(grdOrdersDetails.CurrentCell.RowIndex
                                     , fShouhin.SelectedItemCodes[0].ShireCode
                                     , fShouhin.SelectedItemCodes[0].TopClassification
                                     , fShouhin.SelectedItemCodes[0].BtmClassification
                                     , fShouhin.SelectedItemCodes[0].ShouhinNo);
                        beforeCellValue = fShouhin.SelectedItemCodes[0].ShouhinNo;
                        grdOrdersDetails.EndEdit();
                    }
                    grdOrdersDetails.BeginEdit(true);
                }
                // 仕入先ｺｰﾄﾞ列の場合
                else if (activeControlInfo.RowIndex % grdOrdersDetails.RowSegmentCount == 0 &&
                         activeControlInfo.ClmIndex == clmVendorCodeAndName.DisplayIndex)
                {
                    grdOrdersDetails.CancelEdit();
                    // 仕入先検索画面を起動
                    sShiresaki.ShowDialog();

                    // 仕入先検索画面で確認ボタンが押下された場合
                    if (sShiresaki.DialogResult == DialogResult.OK)
                    {
                        // 仕入先情報設定処理
                        setShiresakiInfo(sShiresaki.SelectedShiresakiCodes[0]);
                        beforeCellValue = sShiresaki.SelectedShiresakiCodes[0];
                        grdOrdersDetails.EndEdit();
                    }
                    grdOrdersDetails.BeginEdit(true);
                }
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
        }
        #endregion

        #region 印刷ボタン押下処理
        /// <summary>
        /// 印刷ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(printDocumentNo))
            {
            }
            else if (!btnPrint.Enabled || !btnPrint.Visible)
            {
                return;
            }
            bool flgClose = true;
            if (string.IsNullOrEmpty(printDocumentNo))
            {
                printDocumentNo = txtDocumentNo.Text;
                flgClose = false;
            }

            // 発注番号採番処理実行
            updateHachuNo();

            frmBupinHachusyo frmPrint = new frmBupinHachusyo(printDocumentNo, flgClose);
            frmPrint.StartPosition = FormStartPosition.CenterScreen;
            frmPrint.ShowDialog();
            printDocumentNo = string.Empty;
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
                string ordersNo = txtOrdersNo.Text;
                DateTime registerDate = DateTime.Now;
                string sqlHeaderCommand = createHeaderRegistSql(ref documentNo, ref ordersNo, registerDate);
                List<string> sqlBodyCommands = createBodyRegistSql(ordersNo, registerDate);
                string sqlFooterCommand = createFooterRegistSql(ordersNo, registerDate);
                string sqlMitumoriHeaderCommand = createMitumoriHeaderUpdateSql(txtEstimateNo.Text, registerDate);
                string sqlHachuNoCommand = string.Empty;
                Dictionary<string, HachuRegistSqlClass> sqlHachuCommands = createHachuRegistSql(ordersNo, registerDate, ref sqlHachuNoCommand);
                string sqlJuchuNoCommand = rdoNew.Checked ? createJuchuNoRegistSql(documentNo, registerDate) : string.Empty;
                List<string> sqlShireCommand = (flgNouhinsyoOutput && rdoCorrection.Checked) ? createShireRegistSql(ordersNo, registerDate) : new List<string>();
                string sqlTantousyaMasterCommand = rdoNew.Checked ? createTantousyaMasterRegistSql(ordersNo, registerDate) : string.Empty;
                List<string> sqlHachuEdaCommand = new List<string>();
                int headerRegistResult = 0;
                int bodyRegistResult = 0;
                int footerRegistResult = 0;
                int mitumoriHeaderRegistResult = 0;
                int hachuRegistResult = 0;
                int shireRegistResult = 0;
                int kanriMasterRegistResult = 0;
                int tantousyaMasterRegistResult = 0;
                juchuDataSelectDb.DBRef = 0;

                if (rdoNew.Checked)
                {
                    juchuDataSelectDb.startTransaction();
                    // 管理マスタ(受注No)のロック
                    juchuDataSelectDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.JuchuNo + "'", true);
                    if (juchuDataSelectDb.DBRef != 0)
                    {
                        errorOK("受注Noロックエラー");
                        juchuDataSelectDb.endTransaction();
                        return;
                    }
                    // 管理マスタ(発注No)のロック
                    juchuDataSelectDb.executeSelect("SELECT 1 FROM kanri_master WHERE kanriCode = '" + Consts.KanriCodes.HachuNo + "'", true);
                    if (juchuDataSelectDb.DBRef != 0)
                    {
                        errorOK("発注Noロックエラー");
                        juchuDataSelectDb.endTransaction();
                        return;
                    }
                    // 担当者マスタのロック
                    juchuDataSelectDb.executeSelect("SELECT 1 FROM tantousya_master WHERE tantousyaCode = '" + Program.loginUserInfo.UserId + "'", true);
                    if (juchuDataSelectDb.DBRef != 0)
                    {
                        errorOK("担当者マスタロックエラー");
                        juchuDataSelectDb.endTransaction();
                        return;
                    }
                }

                // 受注ヘッダの更新
                headerRegistResult = juchuDataSelectDb.executeDBUpdate(sqlHeaderCommand);

                if (juchuDataSelectDb.DBRef == 0)
                {
                    // 受注ボディの更新
                    foreach (string bodyCommand in sqlBodyCommands)
                    {
                        bodyRegistResult = juchuDataSelectDb.executeDBUpdate(bodyCommand);
                        if (juchuDataSelectDb.DBRef != 0) break;
                    }
                }

                // 受注フッターの更新
                if (juchuDataSelectDb.DBRef == 0) footerRegistResult = juchuDataSelectDb.executeDBUpdate(sqlFooterCommand);

                // 受注ボディの更新
                if (juchuDataSelectDb.DBRef == 0)
                {
                    if (!rdoDelete.Checked) sqlHachuEdaCommand = updateHachuEdaban(documentNo);
                    foreach (string bodyCommand in sqlHachuEdaCommand)
                    {
                        bodyRegistResult = juchuDataSelectDb.executeDBUpdate(bodyCommand);
                        if (juchuDataSelectDb.DBRef != 0) break;
                    }
                }

                // 見積ヘッダの更新
                if (juchuDataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlMitumoriHeaderCommand)) mitumoriHeaderRegistResult = juchuDataSelectDb.executeDBUpdate(sqlMitumoriHeaderCommand);
                
                // 発注情報の更新
                if (juchuDataSelectDb.DBRef == 0) hachuRegistResult = hachuRegist(ordersNo, sqlHachuCommands);

                // 仕入情報の更新
                if (juchuDataSelectDb.DBRef == 0)
                {
                    foreach (string shireCommand in sqlShireCommand)
                    {
                        shireRegistResult = juchuDataSelectDb.executeDBUpdate(shireCommand);
                        if (juchuDataSelectDb.DBRef != 0) break;
                    }
                }
                
                // 管理マスタ(受注No)の更新
                if (juchuDataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlJuchuNoCommand)) kanriMasterRegistResult = juchuDataSelectDb.executeDBUpdate(sqlJuchuNoCommand);

                // 管理マスタ(発注No)の更新
                if (juchuDataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlHachuNoCommand)) kanriMasterRegistResult = juchuDataSelectDb.executeDBUpdate(sqlHachuNoCommand);

                // 担当者マスタの更新
                if (juchuDataSelectDb.DBRef == 0 && !string.IsNullOrEmpty(sqlTantousyaMasterCommand)) tantousyaMasterRegistResult = juchuDataSelectDb.executeDBUpdate(sqlTantousyaMasterCommand);

                if (juchuDataSelectDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (headerRegistResult < 0 || kanriMasterRegistResult < 0 || tantousyaMasterRegistResult < 0)
                    {
                        tableName = "受注ヘッダ";
                    }
                    else if (bodyRegistResult < 0)
                    {
                        tableName = "受注明細";
                    }
                    else if (footerRegistResult < 0)
                    {
                        tableName = "受注集計";
                    }
                    else if (mitumoriHeaderRegistResult == -1)
                    {
                        tableName = "見積ヘッダ";
                    }
                    else if (hachuRegistResult == -1)
                    {
                        tableName = "発注ヘッダ";
                    }
                    else if (hachuRegistResult == -2)
                    {
                        tableName = "発注明細";
                    }
                    else if (hachuRegistResult == -3)
                    {
                        tableName = "発注集計";
                    }
                    else if (shireRegistResult < 0)
                    {
                        tableName = "仕入情報";
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
                    if (rdoNew.Checked) juchuDataSelectDb.endTransaction();
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "受注No:" + documentNo;
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

                    if (rdoNew.Checked || rdoCorrection.Checked)
                    {
                        // トランザクション終了処理を実行
                        if (rdoNew.Checked) juchuDataSelectDb.endTransaction();
                        frmPrintQuery printQuery = new frmPrintQuery(MessageType.Message, string.Format(Messages.M0012, message1, message2), string.Empty);
                        printQuery.StartPosition = FormStartPosition.CenterScreen;
                        printQuery.ShowDialog();
                        printDocumentNo = documentNo;
                        btnPrint_Click(null, null);
                    }
                    else
                    {
                        messageOK(string.Format(Messages.M0012, message1, message2));
                    }

                    btnCancel_Click(null, null);
                }
            }
            flgSaving = false;
        }
        #endregion

        #region 取消ボタン押下処理
        /// <summary>
        /// 取消ボタン押下処理
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

        #region 閉じるボタン押下処理
        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!btnClose.Enabled) return;
            // トランザクション開始済みの場合
            if (juchuDataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                juchuDataSelectDb.endTransaction();
            }
            closedForm();
        }
        #endregion

        #region グリッドへの出力データ取得処理
        /// <summary>
        /// グリッドへの出力データ取得処理
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

        #region グリッドのセル描画イベント
        /// <summary>
        /// グリッドのセル描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrdersDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;

            // 行・列共にヘッダは処理しない
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int rowIndex = -1;
            // カレントセルがnull出ない場合
            if (grdOrdersDetails.CurrentCell != null)
            {
                // カレントセルから上段行の行インデックを取得
                rowIndex = grdOrdersDetails.CurrentCell.RowIndex;
                if (rowIndex % grdOrdersDetails.RowSegmentCount == 1) rowIndex--;
            }
            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(rowIndex);

            Rectangle rect;
            DataGridViewCell cell;
            // 行No列の処理
            if (e.ColumnIndex == 0)
            {
                int rowNo = (int)(e.RowIndex / grdOrdersDetails.RowSegmentCount) + 1;
                rect = e.CellBounds;
                // 奇数行(1,3,5..行目 = RowIndexは0,2,4..)
                if (e.RowIndex % grdOrdersDetails.RowSegmentCount == 0)
                {
                    cell = grdOrdersDetails[e.ColumnIndex, e.RowIndex];
                    //一つ下の次のセルの高さを足す
                    rect.Height += cell.Size.Height;
                }
                // 偶数行の処理
                else
                {
                    cell = grdOrdersDetails[e.ColumnIndex, e.RowIndex - 1];
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
            else if (e.RowIndex % grdOrdersDetails.RowSegmentCount == 0 &&
                     (e.ColumnIndex == clmRowNo.DisplayIndex ||
                     e.ColumnIndex == clmItemAndOpponentCode.DisplayIndex ||
                     e.ColumnIndex == clmPurchasePartsType.DisplayIndex ||
                     e.ColumnIndex == clmRemarks.DisplayIndex))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            else if (grdOrdersDetails[e.ColumnIndex, e.RowIndex] is DataGridViewComboBoxCell &&
                     grdOrdersDetails[e.ColumnIndex, e.RowIndex].ReadOnly)
            {
                ((DataGridViewComboBoxCell)grdOrdersDetails[e.ColumnIndex, e.RowIndex]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            }
        }
        #endregion

        #region グリッドの選択セル変更イベント
        /// <summary>
        /// グリッドの選択セル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrdersDetails_CurrentCellChanged(object sender, EventArgs e)
        {
            // 行複写ボタンのテキスト設定
            setRowCopyBtnText();
            // カレントセルがnullの場合何もしない
            if (grdOrdersDetails.CurrentCell == null) return;

            // カレントセルインデックスから上段行のインデックスを取得
            int selectedGridTopRowIndex = 0;
            if (grdOrdersDetails.CurrentCell.RowIndex % grdOrdersDetails.RowSegmentCount == 0)
            {
                selectedGridTopRowIndex = grdOrdersDetails.CurrentCell.RowIndex;
            }
            else
            {
                selectedGridTopRowIndex = grdOrdersDetails.CurrentCell.RowIndex - 1;
            }

            // データグリッドビュー行の背景色および入力可否設定
            setGridRowStyle(selectedGridTopRowIndex);
            activeControlInfo = new ActiveControlInfo();
            // カレントセルがTextBoxCellかつ
            // 入力可能セルの場合
            if ((grdOrdersDetails.CurrentCell.OwningColumn is DataGridViewTextBoxColumn ||
                grdOrdersDetails.CurrentCell.OwningColumn is DataGridViewComboBoxColumn) &&
                !grdOrdersDetails.CurrentCell.ReadOnly)
            {
                beforeCellValue = Convert.ToString(grdOrdersDetails.CurrentCell.Value);
                // カレントセルの編集モードを開始
                grdOrdersDetails.BeginEdit(true);
            }
        }
        #endregion

        #region グリッド描画イベント
        /// <summary>
        /// グリッド描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrdersDetails_Paint(object sender, PaintEventArgs e)
        {
            string[] monthes = { "", "", "", "納品残", "納品状態", "受注単価", "仕入先ｺｰﾄﾞ", "", "仕入単価", "仕入先納品残", "", "", "", "", "", "" };

            grdOrdersDetails.SuspendLayout();
            for (int j = 0; j < grdOrdersDetails.ColumnCount; j++)
            {
                String headerText = string.Empty;
                Rectangle r1 = this.grdOrdersDetails.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width - grdOrdersDetails.RowSegmentCount;

                if (!string.IsNullOrEmpty(monthes[j]))
                {
                    headerText = monthes[j];
                    r1.Height = (r1.Height / grdOrdersDetails.RowSegmentCount) - grdOrdersDetails.RowSegmentCount;
                }
                else
                {
                    headerText = grdOrdersDetails.Columns[j].HeaderText;
                    r1.Height = r1.Height - grdOrdersDetails.RowSegmentCount;
                }

                e.Graphics.FillRectangle(new SolidBrush(this.grdOrdersDetails.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(headerText,

                    this.grdOrdersDetails.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.grdOrdersDetails.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);
                if (!string.IsNullOrEmpty(monthes[j])) e.Graphics.DrawLine(new Pen(Color.DarkGray), new Point(r1.X, r1.Bottom), new Point(r1.X + r1.Width, r1.Bottom));
            }
            grdOrdersDetails.ResumeLayout();
        }
        #endregion

        #region グリッドの入力用コントロール表示時イベント
        /// <summary>
        /// グリッドの入力用コントロール表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrdersDetails_EditingControlShowing(object sender,
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
                if (activeControlInfo.ClmIndex == clmItemAndOpponentCode.Index)
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
                // 受注数量セルの場合
                else if (activeControlInfo.ClmIndex == clmOrdersQuantity.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = ordersQuantityIntegerLength;
                    activeControlInfo.DecimalLength = ordersQuantityDecimalLength;
                }
                // 受注単価セルの場合
                else if (activeControlInfo.ClmIndex == clmOrdersBidAndAmount.Index &&
                         activeControlInfo.RowIndex % dgv.RowSegmentCount == 0)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = ordersBidIntegerLength;
                    activeControlInfo.DecimalLength = ordersBidDecimalLength;
                }
                // 受注金額セルの場合
                else if (activeControlInfo.ClmIndex == clmOrdersBidAndAmount.Index &&
                         activeControlInfo.RowIndex % dgv.RowSegmentCount != 0)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = ordersAmountIntegerLength;
                    activeControlInfo.DecimalLength = ordersAmountDecimalLength;
                }
                // 仕入先ｺｰﾄﾞセルの場合
                else if (activeControlInfo.ClmIndex == clmVendorCodeAndName.Index &&
                         activeControlInfo.RowIndex % dgv.RowSegmentCount == 0)
                {
                    // 最大入力桁数を設定
                    ((DataGridViewTextBoxEditingControl)e.Control).MaxLength = 3;
                    activeControlInfo.MaxLength = ((DataGridViewTextBoxEditingControl)e.Control).MaxLength;
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);
                }
                // 仕入先名セルの場合
                else if (activeControlInfo.ClmIndex == clmVendorCodeAndName.Index &&
                         activeControlInfo.RowIndex % dgv.RowSegmentCount != 0)
                {
                    // 最大入力桁数を設定
                    ((DataGridViewTextBoxEditingControl)e.Control).MaxLength = 16;
                    activeControlInfo.MaxLength = ((DataGridViewTextBoxEditingControl)e.Control).MaxLength;
                }
                // 仕入単価セルの場合
                else if (activeControlInfo.ClmIndex == clmPurchaseBidAndAmount.Index &&
                         activeControlInfo.RowIndex % dgv.RowSegmentCount == 0)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = purchaseBidIntegerLength;
                    activeControlInfo.DecimalLength = purchaseBidDecimalLength;
                }
                // 仕入金額セルの場合
                else if (activeControlInfo.ClmIndex == clmPurchaseBidAndAmount.Index &&
                         activeControlInfo.RowIndex % dgv.RowSegmentCount != 0)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = purchaseAmountIntegerLength;
                    activeControlInfo.DecimalLength = purchaseAmountDecimalLength;
                }
                // 仕入先納品数数量セルの場合
                else if (activeControlInfo.ClmIndex == clmPurchaseDeliveryQuantity.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = purchaseDeliveryQuantityIntegerLength;
                    activeControlInfo.DecimalLength = purchaseDeliveryQuantityDecimalLength;
                }
                // キー押下イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown -= new KeyEventHandler(inputObject_KeyDown);
                // キー押下イベントを追加
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown += new KeyEventHandler(inputObject_KeyDown);
            }
            setSearchButtonEnabled();
        }
        #endregion

        #region グリッドのセル検証イベント
        /// <summary>
        /// グリッドのセル検証イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrdersDetails_CellValidating(object sender,
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
            else if (dgv.CurrentCell.ColumnIndex == clmItemAndOpponentCode.DisplayIndex)
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
            // 仕入先ｺｰﾄﾞセルの場合
            else if (dgv.CurrentCell.ColumnIndex == clmVendorCodeAndName.DisplayIndex &&
                     dgv.CurrentCell.RowIndex % grdOrdersDetails.RowSegmentCount == 0)
            {
                activeControlInfo.CancelEdit = false;
                if (flgBtnSearchSelect && !dgv.flgFoucasOut)
                {
                    activeControlInfo.CancelEdit = true;
                    dgv.CancelEdit();
                    return;
                }
                string inputText = Convert.ToString(e.FormattedValue);
                string inputVendorCode = inputText;
                decimal dec;
                if (!string.IsNullOrEmpty(inputText) && decimal.TryParse(inputText, out dec))
                {
                    inputVendorCode = commonLogic.getZeroBuriedNumberText(inputText, activeControlInfo.MaxLength);
                }
                // 入力した仕入先ｺｰﾄﾞが存在しない場合
                if (!string.IsNullOrEmpty(inputVendorCode) && !shiresakiMaster.checkExistShiresakiInfo(inputVendorCode))
                {
                    errorOK(string.Format(Messages.M0003, "仕入先ｺｰﾄﾞ"));
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
        private void grdOrdersDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string inputValue = Convert.ToString(grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
            bool flgRecalcMeisai = false;
            bool flgRecalcSyukei = false;
            bool flgUnconditionalSyukei = false;
            RecalcMeisaiTYpe recalcType = RecalcMeisaiTYpe.All;

            // 商品ｺｰﾄﾞ列の場合
            if (e.ColumnIndex == clmItemAndOpponentCode.DisplayIndex && !flgDeletingRow)
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
            // 受注数量セルの場合
            else if (e.ColumnIndex == clmOrdersQuantity.DisplayIndex)
            {
                decimal quantity = decimal.Zero;
                if (decimal.TryParse(inputValue, out quantity))
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = quantity.ToString(ordersQuantityFormat);
                }
                else
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
                flgRecalcSyukei = true;
                recalcType = RecalcMeisaiTYpe.OrdersQuantityInput;
            }
            // 受注単価セルの場合
            else if (e.ColumnIndex == clmOrdersBidAndAmount.DisplayIndex && e.RowIndex % grdOrdersDetails.RowSegmentCount == 0)
            {
                decimal bid = decimal.Zero;
                if (decimal.TryParse(inputValue, out bid))
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bid.ToString(ordersBidFormat);
                }
                else
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
                flgRecalcSyukei = true;
                recalcType = RecalcMeisaiTYpe.OrdersBidInput;
            }
            // 受注金額セルの場合
            else if (e.ColumnIndex == clmOrdersBidAndAmount.DisplayIndex && e.RowIndex % grdOrdersDetails.RowSegmentCount != 0)
            {
                decimal amount = decimal.Zero;
                if (decimal.TryParse(inputValue, out amount))
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount.ToString(ordersAmountFormat);
                }
                else
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcSyukei = true;
            }
            // 仕入先ｺｰﾄﾞセルの場合
            else if (e.ColumnIndex == clmVendorCodeAndName.DisplayIndex && e.RowIndex % grdOrdersDetails.RowSegmentCount == 0 && !flgDeletingRow)
            {
                if (activeControlInfo.CancelEdit) return;
                string inputVendorCode = inputValue;
                decimal dec;
                if (string.IsNullOrEmpty(inputValue))
                {
                    inputVendorCode = Consts.OthersVendorCode;
                }
                else if (decimal.TryParse(inputValue, out dec))
                {
                    inputVendorCode = commonLogic.getZeroBuriedNumberText(inputValue, activeControlInfo.MaxLength);
                }
                // 仕入先情報の再設定
                setShiresakiInfo(inputVendorCode);
            }
            // 仕入・部材区分セルの場合
            else if (e.ColumnIndex == clmPurchasePartsType.DisplayIndex)
            {
                inputValue = Convert.ToString(grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                flgRecalcSyukei = true;
            }
            // 仕入単価セルの場合
            else if (e.ColumnIndex == clmPurchaseBidAndAmount.DisplayIndex && e.RowIndex % grdOrdersDetails.RowSegmentCount == 0)
            {
                decimal bid = decimal.Zero;
                if (decimal.TryParse(inputValue, out bid))
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bid.ToString(purchaseBidFormat);
                }
                else
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcMeisai = true;
                flgRecalcSyukei = true;
                recalcType = RecalcMeisaiTYpe.PurchaseBidInput;
            }
            // 仕入金額セルの場合
            else if (e.ColumnIndex == clmPurchaseBidAndAmount.DisplayIndex && e.RowIndex % grdOrdersDetails.RowSegmentCount != 0)
            {
                decimal bid = decimal.Zero;
                if (decimal.TryParse(inputValue, out bid))
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bid.ToString(purchaseAmountFormat);
                }
                else
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                flgRecalcSyukei = true;
            }
            // 仕入先納品数セルの場合
            else if (e.ColumnIndex == clmPurchaseDeliveryQuantity.DisplayIndex)
            {
                decimal quantity = decimal.Zero;
                if (decimal.TryParse(inputValue, out quantity))
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = quantity.ToString(purchaseDeliveryQuantityFormat);
                }
                else
                {
                    grdOrdersDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                // 納品残数量の再計算処理実行
                recalcDeliveryResidualQuantity(e.RowIndex);
                grdOrdersDetails.Refresh();
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
                    recalcMeisai(e.RowIndex, recalcType);
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
                    // 受注金額の集計処理を実行
                    recalcOrdersTotal();
                }
            }

            if (flgUnconditionalSyukei)
            {
                // 明細金額の集計処理を実行
                recalcDetailsTotal();
                // 受注金額の集計処理を実行
                recalcOrdersTotal();
            }

            // 空白でない値を入力した場合
            if (!string.IsNullOrEmpty(inputValue))
            {
                // 最終行に空行を追加
                addLastEmptyRow();
            }
            grdOrdersDetails.Refresh();
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
                txtCustomerPersonnel.Text = string.Empty;
                txtDeliveredName.Text = string.Empty;
                txtDeliveredDeploymentName.Text = string.Empty;
                txtContact1.Text = string.Empty;
                txtContact2.Text = string.Empty;
                txtZipCode.Text = string.Empty;
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                txtDeliveredPersonnelName.Text = string.Empty;
                setOfficesCmb(dummyCode, string.Empty);
            }
        }
        #endregion

        #region 件名Noのフォーカスアウトイベント
        /// <summary>
        /// 件名Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConstructionNo_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            if (flgBtnSearchSelect && !text.flgFoucasOut) return;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 件名情報の設定
                setKenmeiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength));
            }
        }
        #endregion

        #region 伝票日付のフォーカスインイベント
        /// <summary>
        /// 伝票日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.DocumentDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 伝票日付のフォーカスアウトイベント
        /// <summary>
        /// 伝票日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentDate_Leave(object sender, EventArgs e)
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

        #region 出荷日のフォーカスインイベント
        /// <summary>
        /// 出荷日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.ShipDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 出荷日のフォーカスアウトイベント
        /// <summary>
        /// 出荷日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.ShipDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.ShipDate;
            }
        }
        #endregion

        #region 着日のフォーカスインイベント
        /// <summary>
        /// 着日のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTheDay_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.OnTheDay)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 着日のフォーカスアウトイベント
        /// <summary>
        /// 着日のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTheDay_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.OnTheDay;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.OnTheDay;
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

            if (grdOrdersDetails.CurrentCell != null)
            {
                try { grdOrdersDetails.CurrentCell = null; } catch { }
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
                    case LastInputDateType.ShipDate:
                        y = txtShipDateYears.Text;
                        m = txtShipDateMonth.Text;
                        d = txtShipDateDays.Text;
                        inputObj = dtpShipDate;
                        break;
                    case LastInputDateType.OnTheDay:
                        y = txtOnTheDayYears.Text;
                        m = txtOnTheDayMonth.Text;
                        d = txtOnTheDayDays.Text;
                        inputObj = dtpOnTheDay;
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
                    else if (LastInputDateType.ShipDate.Equals(lastInputDateType))
                    {
                        txtShipDateYears.Focus();
                    }
                    else if (LastInputDateType.OnTheDay.Equals(lastInputDateType))
                    {
                        txtOnTheDayYears.Focus();
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
                // F4キーが押下された場合
                case Keys.F4:
                    // TODO:印刷処理を実行
                    btnPrint_Click(null, null);
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

        #region 数字＆ハイフンのみ入力可能項目のキー押下イベント
        /// <summary>
        /// 数字＆ハイフンのみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDigitalAndHaihunOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字＆ハイフンのみ入力可能項目の制御処理を実行
            commonLogic.inputDigitalAndHaihunOnly_KeyPress(e);
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

        #region 事業所コンボボックス変更イベント
        /// <summary>
        /// 事業所コンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOffices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flgOfficeCmbChanged) return;
            if (((CustomComboBox)sender).BeforeSelectedValue.Equals(Convert.ToString(cmbOffices.SelectedValue))) return;

            flgOfficeCmbChanged = true;
            // 得意先情報の再設定
            setTokuisakiInfo(txtCustomerCode.Text, Convert.ToString(cmbOffices.SelectedValue), true);
            flgOfficeCmbChanged = false;
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
            if (flgSetJuchuData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                flgSetJuchuData = true;
                // 受注データ取得処理を実行
                bool ret = setJuchuData(txtDocumentNo.Text, string.Empty, true);

                if (ret)
                {
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                else
                {
                    text.Focus();
                }
                flgSetJuchuData = false;
            }
        }
        #endregion

        #region 受注Noのフォーカスアウトイベント
        /// <summary>
        /// 受注Noのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrdersNo_Leave(object sender, EventArgs e)
        {
            if (flgSetJuchuData) return;
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                flgSetJuchuData = true;
                // 受注データ取得処理を実行
                bool ret = setJuchuData(string.Empty, txtOrdersNo.Text, false);

                if (ret)
                {
                    // 画面項目制御処理を実行
                    setEnabled();
                }
                else
                {
                    text.Focus();
                }
                flgSetJuchuData = false;
            }
        }
        #endregion

        #region データグリッドビューのデータエラーイベント
        /// <summary>
        /// データグリッドビューのデータエラーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrdersDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #endregion

        #region ビジネスロジック

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

        #region 発行者コンボボックスの設定
        /// <summary>
        /// 発行者コンボボックスの設定
        /// </summary>
        private void setPublisherCmb()
        {
            // 発行者取得
            DataTable tantousyaDt = tantousyaMaster.getTantousyaDataTable(string.Empty, string.Empty);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPublisher, tantousyaDt, "tantousyaCode", "tantousyaName");
        }
        #endregion

        #region 事業所コンボボックスの設定
        /// <summary>
        /// 事業所コンボボックスの設定
        /// </summary>
        private void setOfficesCmb(string tokuisakiCode, string jigyousyoCode)
        {
            if (flgSetOfficesCmb) return;
            flgSetOfficesCmb = true;
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

            flgSetOfficesCmb = false;
        }
        #endregion

        #region 材料・工事区分コンボボックスの設定
        /// <summary>
        /// 材料・工事区分コンボボックスの設定
        /// </summary>
        private void setMaterialsConstructionTypeCmb()
        {
            // 材料・工事区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE001);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbMaterialsConstructionType, meisyoDt, "kubun", "kubunName");
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

        #region 仕入・部材区分コンボボックスの設定
        /// <summary>
        /// 仕入・部材区分コンボボックスの設定
        /// </summary>
        private void setPurchasePartsTypeCmb()
        {
            // 仕入・部材区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE005);
            DataRow emptyRow = meisyoDt.NewRow();
            emptyRow[DBFileLayout.MeisyoMasterFile.dcKubun] = string.Empty;
            emptyRow[DBFileLayout.MeisyoMasterFile.dcKubunName] = string.Empty;
            meisyoDt.Rows.InsertAt(emptyRow, 0);
            // コンボボックス設定共通処理実行
            commonLogic.setGridComboBoxDataSource(ref clmPurchasePartsType, meisyoDt, DBFileLayout.MeisyoMasterFile.dcKubun, DBFileLayout.MeisyoMasterFile.dcKubunName);
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
            if (juchuDataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                juchuDataSelectDb.endTransaction();
            }

            activeRadioButton = radio;
            #region 共通初期値設定
            txtDocumentNo.Text = string.Empty;
            dtpDocumentDate.Value = syoriDate;
            txtOrdersNo.Text = string.Empty;
            cmbPersonnel.SelectedValue = Program.loginUserInfo.UserId;
            cmbPublisher.SelectedValue = Program.loginUserInfo.UserId;
            txtEstimateNo.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            txtCustomerPersonnel.Text = string.Empty;
            cmbMaterialsConstructionType.SelectedIndex = -1;
            dtpShipDate.Value = syoriDate.AddDays(-1);
            txtShipDateYears.Text = string.Empty;
            txtShipDateMonth.Text = string.Empty;
            txtShipDateDays.Text = string.Empty;
            dtpOnTheDay.Value = syoriDate.AddDays(-1);
            txtOnTheDayYears.Text = string.Empty;
            txtOnTheDayMonth.Text = string.Empty;
            txtOnTheDayDays.Text = string.Empty;
            txtShippingFlights.Text = string.Empty;
            txtGuestNoteNumber.Text = string.Empty;
            txtConstructionNo.Text = string.Empty;
            txtSubject1.Text = string.Empty;
            txtSubject2.Text = string.Empty;
            txtDeliveredName.Text = string.Empty;
            txtDeliveredDeploymentName.Text = string.Empty;
            txtContact1.Text = string.Empty;
            txtContact2.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtDeliveredPersonnelName.Text = string.Empty;
            setOfficesCmb(dummyCode, string.Empty);

            // グリッド初期化処理実行
            initGridData();
            #endregion

            flgSearch = false;
            flgNouhinsyoOutput = false;
            // モード別編集可否設定
            setEnabled();
        }
        #endregion

        #region 受注グリッド初期化処理
        /// <summary>
        /// 受注グリッド初期化処理
        /// </summary>
        private void initGridData()
        {
            // 受注明細グリッドの初期化
            grdOrdersDetails.Rows.Clear();
            for (int i = 0; i < (gridStartRowCount + 1); i++)
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
            grdOrdersDetails.Rows.RemoveAt(grdOrdersDetails.Rows.Count - 1);
            grdOrdersDetails.Rows.RemoveAt(grdOrdersDetails.Rows.Count - 1);
            grdOrdersDetails.CurrentCell = null;
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 受注明細合計グリッドの初期化
            DataTable dtOrdersDetailsTotal = new DataTable();
            dtOrdersDetailsTotal.Columns.Add(grdOrdersDetailsTotal.Columns[0].DataPropertyName, Type.GetType("System.String"));
            dtOrdersDetailsTotal.Columns.Add(grdOrdersDetailsTotal.Columns[1].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersDetailsTotal.Columns.Add(grdOrdersDetailsTotal.Columns[2].DataPropertyName, Type.GetType("System.String"));
            dtOrdersDetailsTotal.Columns.Add(grdOrdersDetailsTotal.Columns[3].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersDetailsTotal.Rows.Add(new object[] { detailsTotalTitle1, null, detailsTotalTitle2, null });
            grdOrdersDetailsTotal.DataSource = dtOrdersDetailsTotal;

            // 受注合計グリッドの初期化
            DataTable dtOrdersTotal = new DataTable();
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[0].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[1].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[2].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[3].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[4].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[5].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[6].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Columns.Add(grdOrdersTotal.Columns[7].DataPropertyName, Type.GetType("System.Decimal"));
            dtOrdersTotal.Rows.Add(new object[] { null, null, null, null, null, null, null, null });
            grdOrdersTotal.DataSource = dtOrdersTotal;
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
            grdOrdersDetails.Focus();
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                // 入力制御設定
                txtDocumentNo.Enabled = true;
                txtDocumentNo.ReadOnly = true;
                txtDocumentDateYears.Enabled = true;
                txtDocumentDateMonth.Enabled = true;
                txtDocumentDateDays.Enabled = true;
                dtpDocumentDate.Enabled = true;
                txtOrdersNo.Enabled = true;
                txtOrdersNo.ReadOnly = true;
                cmbPersonnel.Enabled = true;
                cmbPublisher.Enabled = true;
                txtEstimateNo.Enabled = true;
                txtCustomerCode.Enabled = true;
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text);
                cmbOffices.Enabled = true;
                txtCustomerPersonnel.Enabled = true;
                cmbMaterialsConstructionType.Enabled = true;
                txtShipDateYears.Enabled = true;
                txtShipDateMonth.Enabled = true;
                txtShipDateDays.Enabled = true;
                dtpShipDate.Enabled = true;
                txtOnTheDayYears.Enabled = true;
                txtOnTheDayMonth.Enabled = true;
                txtOnTheDayDays.Enabled = true;
                dtpOnTheDay.Enabled = true;
                txtShippingFlights.Enabled = true;
                txtGuestNoteNumber.Enabled = true;
                txtConstructionNo.Enabled = true;
                txtSubject1.Enabled = true;
                txtSubject2.Enabled = true;
                txtDeliveredName.Enabled = true;
                txtDeliveredDeploymentName.Enabled = true;
                txtContact1.Enabled = true;
                txtContact2.Enabled = true;
                txtZipCode.Enabled = true;
                txtAddress1.Enabled = true;
                txtAddress2.Enabled = true;
                txtDeliveredPersonnelName.Enabled = true;
                btnInputRemark.Enabled = true;
                btnCopyRow.Enabled = true;
                btnPasteRow.Enabled = true;
                btnInsertRow.Enabled = true;
                btnDeleteRow.Enabled = true;
                btnSearch.Enabled = true;
                btnPrint.Visible = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtDocumentNo.Focus();

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtShipDateYears.BackColor = Color.White;
                txtShipDateMonth.BackColor = Color.White;
                txtShipDateDays.BackColor = Color.White;
                txtOnTheDayYears.BackColor = Color.White;
                txtOnTheDayMonth.BackColor = Color.White;
                txtOnTheDayDays.BackColor = Color.White;

                // 表示文字列設定
                btnInputRemark.Text = "備考入力";
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtDocumentNo.Enabled = !flgSearch;
                txtDocumentNo.ReadOnly = false;
                txtDocumentDateYears.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtDocumentDateMonth.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtDocumentDateDays.Enabled = flgSearch && !flgNouhinsyoOutput;
                dtpDocumentDate.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtOrdersNo.Enabled = !flgSearch;
                txtOrdersNo.ReadOnly = false;
                cmbPersonnel.Enabled = flgSearch && !flgNouhinsyoOutput;
                cmbPublisher.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtEstimateNo.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtCustomerCode.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtCustomerName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text) && !flgNouhinsyoOutput;
                txtCustomerKanaName.Enabled = Consts.OthersCustomerCode.Equals(txtCustomerCode.Text) && !flgNouhinsyoOutput;
                cmbOffices.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtCustomerPersonnel.Enabled = flgSearch && !flgNouhinsyoOutput;
                cmbMaterialsConstructionType.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtShipDateYears.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtShipDateMonth.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtShipDateDays.Enabled = flgSearch && !flgNouhinsyoOutput;
                dtpShipDate.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtOnTheDayYears.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtOnTheDayMonth.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtOnTheDayDays.Enabled = flgSearch && !flgNouhinsyoOutput;
                dtpOnTheDay.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtShippingFlights.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtGuestNoteNumber.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtConstructionNo.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtSubject1.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtSubject2.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtDeliveredName.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtDeliveredDeploymentName.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtContact1.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtContact2.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtZipCode.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtAddress1.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtAddress2.Enabled = flgSearch && !flgNouhinsyoOutput;
                txtDeliveredPersonnelName.Enabled = flgSearch && !flgNouhinsyoOutput;
                btnInputRemark.Enabled = flgSearch && !flgNouhinsyoOutput;
                //btnCopyRow.Enabled = flgSearch && !flgNouhinsyoOutput;
                //btnPasteRow.Enabled = flgSearch && !flgNouhinsyoOutput;
                //btnInsertRow.Enabled = flgSearch && !flgNouhinsyoOutput;
                //btnDeleteRow.Enabled = flgSearch && !flgNouhinsyoOutput;
                btnCopyRow.Enabled = flgSearch;
                btnPasteRow.Enabled = flgSearch;
                btnInsertRow.Enabled = flgSearch;
                btnDeleteRow.Enabled = flgSearch;
                btnSearch.Enabled = true;
                btnPrint.Visible = true;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                bool setFocus = !flgSearch ? txtDocumentNo.Focus() : txtDocumentDateYears.Focus();

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtShipDateYears.BackColor = Color.White;
                txtShipDateMonth.BackColor = Color.White;
                txtShipDateDays.BackColor = Color.White;
                txtOnTheDayYears.BackColor = Color.White;
                txtOnTheDayMonth.BackColor = Color.White;
                txtOnTheDayDays.BackColor = Color.White;

                // 表示文字列設定
                btnInputRemark.Text = "備考入力";
                btnSave.Text = "F10：保存";

                // 表示位置設定
                this.btnPrint.Location = new System.Drawing.Point(118, 15);
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
                txtOrdersNo.Enabled = !flgSearch;
                txtOrdersNo.ReadOnly = false;
                cmbPersonnel.Enabled = false;
                cmbPublisher.Enabled = false;
                txtEstimateNo.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCustomerPersonnel.Enabled = false;
                cmbMaterialsConstructionType.Enabled = false;
                txtShipDateYears.Enabled = false;
                txtShipDateMonth.Enabled = false;
                txtShipDateDays.Enabled = false;
                dtpShipDate.Enabled = false;
                txtOnTheDayYears.Enabled = false;
                txtOnTheDayMonth.Enabled = false;
                txtOnTheDayDays.Enabled = false;
                dtpOnTheDay.Enabled = false;
                txtShippingFlights.Enabled = false;
                txtGuestNoteNumber.Enabled = false;
                txtConstructionNo.Enabled = false;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtDeliveredName.Enabled = false;
                txtDeliveredDeploymentName.Enabled = false;
                txtContact1.Enabled = false;
                txtContact2.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtDeliveredPersonnelName.Enabled = false;
                btnInputRemark.Enabled = flgSearch;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Visible = true;
                btnPrint.Enabled = flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtDocumentNo.Focus();

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtShipDateYears.BackColor = Color.White;
                txtShipDateMonth.BackColor = Color.White;
                txtShipDateDays.BackColor = Color.White;
                txtOnTheDayYears.BackColor = Color.White;
                txtOnTheDayMonth.BackColor = Color.White;
                txtOnTheDayDays.BackColor = Color.White;

                // 表示文字列設定
                btnInputRemark.Text = "備考参照";
                btnSave.Text = "F10：保存";

                // 表示位置設定
                this.btnPrint.Location = new System.Drawing.Point(118, 15);
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
                txtOrdersNo.Enabled = !flgSearch;
                txtOrdersNo.ReadOnly = false;
                cmbPersonnel.Enabled = false;
                cmbPublisher.Enabled = false;
                txtEstimateNo.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerKanaName.Enabled = false;
                cmbOffices.Enabled = false;
                txtCustomerPersonnel.Enabled = false;
                cmbMaterialsConstructionType.Enabled = false;
                txtShipDateYears.Enabled = false;
                txtShipDateMonth.Enabled = false;
                txtShipDateDays.Enabled = false;
                dtpShipDate.Enabled = false;
                txtOnTheDayYears.Enabled = false;
                txtOnTheDayMonth.Enabled = false;
                txtOnTheDayDays.Enabled = false;
                dtpOnTheDay.Enabled = false;
                txtShippingFlights.Enabled = false;
                txtGuestNoteNumber.Enabled = false;
                txtConstructionNo.Enabled = false;
                txtSubject1.Enabled = false;
                txtSubject2.Enabled = false;
                txtDeliveredName.Enabled = false;
                txtDeliveredDeploymentName.Enabled = false;
                txtContact1.Enabled = false;
                txtContact2.Enabled = false;
                txtZipCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtDeliveredPersonnelName.Enabled = false;
                btnInputRemark.Enabled = flgSearch;
                btnCopyRow.Enabled = false;
                btnPasteRow.Enabled = false;
                btnInsertRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                btnSearch.Enabled = !flgSearch;
                btnPrint.Visible = false;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtDocumentNo.Focus();

                // 背景色設定
                txtDocumentDateYears.BackColor = Color.White;
                txtDocumentDateMonth.BackColor = Color.White;
                txtDocumentDateDays.BackColor = Color.White;
                txtShipDateYears.BackColor = Color.White;
                txtShipDateMonth.BackColor = Color.White;
                txtShipDateDays.BackColor = Color.White;
                txtOnTheDayYears.BackColor = Color.White;
                txtOnTheDayMonth.BackColor = Color.White;
                txtOnTheDayDays.BackColor = Color.White;

                // 表示文字列設定
                btnInputRemark.Text = "備考参照";
                btnSave.Text = "F10：実行";

                // 表示位置設定
                this.btnPrint.Location = new System.Drawing.Point(118, 15);
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
                string documentDate = commonLogic.convertDateTime(txtDocumentDateYears.Text, txtDocumentDateMonth.Text, txtDocumentDateDays.Text).ToString("yyyy/MM/dd");
                string shipDate = commonLogic.convertDateTime(txtShipDateYears.Text, txtShipDateMonth.Text, txtShipDateDays.Text).ToString("yyyy/MM/dd");
                string onTheDay = commonLogic.convertDateTime(txtOnTheDayYears.Text, txtOnTheDayMonth.Text, txtOnTheDayDays.Text).ToString("yyyy/MM/dd");
                if (!string.IsNullOrEmpty(txtDocumentNo.Text) ||
                    !documentDate.Equals(syoriDate.ToString("yyyy/MM/dd")) ||
                    !string.IsNullOrEmpty(txtOrdersNo.Text) ||
                    !string.IsNullOrEmpty(cmbPersonnel.Text) ||
                    !string.IsNullOrEmpty(cmbPublisher.Text) ||
                    !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                    !string.IsNullOrEmpty(txtCustomerName.Text) ||
                    !string.IsNullOrEmpty(txtCustomerKanaName.Text) ||
                    !string.IsNullOrEmpty(txtCustomerPersonnel.Text) ||
                    !string.IsNullOrEmpty(cmbMaterialsConstructionType.Text) ||
                    !shipDate.Equals(syoriDate.ToString("yyyy/MM/dd")) ||
                    !onTheDay.Equals(syoriDate.ToString("yyyy/MM/dd")) ||
                    !string.IsNullOrEmpty(txtShippingFlights.Text) ||
                    !string.IsNullOrEmpty(txtGuestNoteNumber.Text) ||
                    !string.IsNullOrEmpty(txtConstructionNo.Text) ||
                    !string.IsNullOrEmpty(txtSubject1.Text) ||
                    !string.IsNullOrEmpty(txtSubject2.Text) ||
                    !string.IsNullOrEmpty(txtDeliveredName.Text) ||
                    !string.IsNullOrEmpty(txtDeliveredDeploymentName.Text) ||
                    !string.IsNullOrEmpty(txtContact1.Text) ||
                    !string.IsNullOrEmpty(txtContact2.Text) ||
                    !string.IsNullOrEmpty(txtZipCode.Text) ||
                    !string.IsNullOrEmpty(txtAddress1.Text) ||
                    !string.IsNullOrEmpty(txtAddress2.Text) ||
                    !string.IsNullOrEmpty(txtDeliveredPersonnelName.Text) ||
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

        #region 受注明細グリッドの空白行チェック処理
        /// <summary>
        /// 受注明細グリッドの空白行チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkAllEmptyRow()
        {
            bool flgAllEmptyRow = true;
            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
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

            DataGridViewRow topRow = grdOrdersDetails.Rows[topRowIndex];
            DataGridViewRow btmRow = grdOrdersDetails.Rows[topRowIndex + 1];

            string itemCd = Convert.ToString(btmRow.Cells[clmItemAndOpponentCode.Name].Value);                  // 商品ｺｰﾄﾞ
            string itemNm1 = Convert.ToString(topRow.Cells[clmItemName.Name].Value);                            // 商品名(上段)
            string itemNm2 = Convert.ToString(btmRow.Cells[clmItemName.Name].Value);                            // 商品名(下段)
            string juchuSuryo = Convert.ToString(btmRow.Cells[clmOrdersQuantity.Name].Value);                   // 受注数量
            string tani = Convert.ToString(btmRow.Cells[clmUnit.Name].Value);                                   // 単位
            string juchuTanka = Convert.ToString(topRow.Cells[clmOrdersBidAndAmount.Name].Value);               // 受注単価
            string juchuKingaku = Convert.ToString(btmRow.Cells[clmOrdersBidAndAmount.Name].Value);             // 受注金額
            string shireCode = Convert.ToString(topRow.Cells[clmVendorCodeAndName.Name].Value);                 // 仕入先ｺｰﾄﾞ
            string shireName = Convert.ToString(btmRow.Cells[clmVendorCodeAndName.Name].Value);                 // 仕入先名
            string shireBuzai = Convert.ToString(btmRow.Cells[clmPurchasePartsType.Name].Value);                // 仕入・部材
            string shireTanka = Convert.ToString(topRow.Cells[clmPurchaseBidAndAmount.Name].Value);             // 仕入単価
            string shireKingaku = Convert.ToString(btmRow.Cells[clmPurchaseBidAndAmount.Name].Value);           // 仕入金額
            string shireNouhinSuryo = Convert.ToString(btmRow.Cells[clmPurchaseDeliveryQuantity.Name].Value);   // 仕入先納品数
            string remarksText1 = Convert.ToString(topRow.Cells[clmRemarks.Name].Value);                        // 備考１
            string remarksText2 = Convert.ToString(btmRow.Cells[clmRemarks.Name].Value);                        // 備考２

            // 全項目が未入力の場合
            if (string.IsNullOrEmpty(itemCd) &&
                string.IsNullOrEmpty(itemNm1) &&
                string.IsNullOrEmpty(itemNm2) &&
                string.IsNullOrEmpty(juchuSuryo) &&
                string.IsNullOrEmpty(tani) &&
                string.IsNullOrEmpty(juchuTanka) &&
                string.IsNullOrEmpty(juchuKingaku) &&
                string.IsNullOrEmpty(shireCode) &&
                string.IsNullOrEmpty(shireName) &&
                string.IsNullOrEmpty(shireBuzai) &&
                string.IsNullOrEmpty(shireTanka) &&
                string.IsNullOrEmpty(shireKingaku) &&
                string.IsNullOrEmpty(shireNouhinSuryo) &&
                string.IsNullOrEmpty(remarksText1) &&
                string.IsNullOrEmpty(remarksText2))
            {
                res = true;
            }
            return res;
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
            if (grdOrdersDetails.CurrentCell != null &&
                copyGridTopRow != null &&
                copyGridBtmRow != null &&
                (copyGridTopRow.Index == grdOrdersDetails.CurrentCell.RowIndex || copyGridBtmRow.Index == grdOrdersDetails.CurrentCell.RowIndex))
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
            string vendorCode;
            string ordersBid;
            string purchaseBid;
            decimal wkPurchaseBid;
            decimal wkOrdersBid;
            Int16 nouhinRowCount;
            // 複写中の行インデックスを取得
            int copyGridTopRowIndex = -1;
            int copyGridBtmRowIndex = -1;
            if (copyGridTopRow != null && copyGridBtmRow != null)
            {
                copyGridTopRowIndex = copyGridTopRow.Index;
                copyGridBtmRowIndex = copyGridBtmRow.Index;
            }
            // 全行の背景色を再設定
            foreach (DataGridViewRow gRow in grdOrdersDetails.Rows)
            {
                Int16.TryParse(Convert.ToString(gRow.Cells[clmNouhinRowCount.Name].Value), out nouhinRowCount);
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
                    if (gRow.Index % grdOrdersDetails.RowSegmentCount == 0)
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
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                     // 行No          ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].ReadOnly = true;       // 商品ｺｰﾄﾞ      ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                  // 商品名        ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].ReadOnly = true;            // 受注数量      ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;                      // 単位          ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = true;        // 受注単価/金額 ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = true;         // 仕入先ｺｰﾄﾞ/名 ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;         // 仕入・部材    ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;      // 仕入単価/金額 ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;  // 仕入先納品数  ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].ReadOnly = true;                   // 備考          ：編集不可
                }
                // 複写中の行の場合
                else if (copyGridTopRowIndex == gRow.Index || copyGridBtmRowIndex == gRow.Index)
                {
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                     // 行No          ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].ReadOnly = true;       // 商品ｺｰﾄﾞ      ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                  // 商品名        ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].ReadOnly = true;            // 受注数量      ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;                      // 単位          ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = true;        // 受注単価/金額 ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = true;         // 仕入先ｺｰﾄﾞ/名 ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;         // 仕入・部材    ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;      // 仕入単価/金額 ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;  // 仕入先納品数  ：編集不可
                    grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].ReadOnly = true;                   // 備考          ：編集不可
                }
                // 上段行の場合
                else if (gRow.Index % grdOrdersDetails.RowSegmentCount == 0)
                {
                    if (grdOrdersDetails.Rows.Count - 1 == gRow.Index)
                    {
                        itemCode = string.Empty;
                        vendorCode = string.Empty;
                    }
                    else
                    {
                        itemCode = Convert.ToString(grdOrdersDetails.Rows[gRow.Index + 1].Cells[clmItemAndOpponentCode.Name].Value);
                        vendorCode = Convert.ToString(grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].Value);
                    }
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                                 // 行No          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].ReadOnly = true;                   // 商品ｺｰﾄﾞ      ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                              // 商品名        ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].ReadOnly = true;                        // 受注数量      ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;                                  // 単位          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = true;                    // 受注単価/金額 ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = true;                     // 仕入先ｺｰﾄﾞ/名 ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;                     // 仕入・部材    ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;                  // 仕入単価/金額 ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;              // 仕入先納品数  ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].ReadOnly = true;                               // 備考          ：編集不可
                    }
                    else
                    {
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                                 // 行No          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].ReadOnly = true;                   // 商品ｺｰﾄﾞ      ：編集不可
                        // 商品ｺｰﾄﾞが"99999"の場合
                        if (Consts.OthersItemCode.Equals(itemCode))
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = (nouhinRowCount == 1);         // 商品名        ：編集可
                        }
                        else
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                          // 商品名        ：編集不可
                        }
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].ReadOnly = true;                        // 受注数量      ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;                                  // 単位          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = flgNouhinsyoOutput;      // 受注単価/金額 ：編集可

                        if (string.IsNullOrEmpty(vendorCode))
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = (nouhinRowCount == 1);// 仕入先ｺｰﾄﾞ/名 ：編集可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;                 // 仕入・部材    ：編集不可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;              // 仕入単価/金額 ：編集不可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;          // 仕入先納品数  ：編集不可
                        }
                        else
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = (nouhinRowCount == 1);// 仕入先ｺｰﾄﾞ/名 ：編集可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;                 // 仕入・部材    ：編集不可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = false;             // 仕入単価/金額 ：編集可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;          // 仕入先納品数  ：編集不可
                        }
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].ReadOnly = true;                               // 備考          ：編集不可
                    }
                }
                // 下段行の場合
                else
                {
                    ordersBid = Convert.ToString(grdOrdersDetails.Rows[gRow.Index - 1].Cells[clmOrdersBidAndAmount.Name].Value);
                    decimal.TryParse(ordersBid, out wkOrdersBid);
                    itemCode = Convert.ToString(grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].Value);
                    vendorCode = Convert.ToString(grdOrdersDetails.Rows[gRow.Index - 1].Cells[clmVendorCodeAndName.Name].Value);
                    purchaseBid = Convert.ToString(grdOrdersDetails.Rows[gRow.Index - 1].Cells[clmPurchaseBidAndAmount.Name].Value);
                    decimal.TryParse(purchaseBid, out wkPurchaseBid);
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                                         // 行No          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].ReadOnly = false;                          // 商品ｺｰﾄﾞ      ：編集可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = true;                                      // 商品名        ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].ReadOnly = true;                                // 受注数量      ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = true;                                          // 単位          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = true;                            // 受注単価/金額 ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = true;                             // 仕入先ｺｰﾄﾞ/名 ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;                             // 仕入・部材    ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;                          // 仕入単価/金額 ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;                      // 仕入先納品数  ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].ReadOnly = true;                                       // 備考          ：編集不可
                    }
                    else
                    {
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].ReadOnly = true;                                         // 行No          ：編集不可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].ReadOnly = (nouhinRowCount == 1);          // 商品ｺｰﾄﾞ      ：編集可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].ReadOnly = (nouhinRowCount == 1);                     // 商品名        ：編集可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].ReadOnly = (nouhinRowCount == 1);               // 受注数量      ：編集可
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].ReadOnly = flgNouhinsyoOutput;                            // 単位          ：編集可
                        grdOrdersDetails.Rows[gRow.Index - 1].Cells[clmUnit.Name].Value = getDeliveryType(gRow.Index);
                        // 受注単価が0の場合
                        if (wkOrdersBid == decimal.Zero)
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = flgNouhinsyoOutput;          // 受注単価/金額 ：編集可
                        }
                        else
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].ReadOnly = true;                        // 受注単価/金額 ：編集不可
                        }

                        if (string.IsNullOrEmpty(vendorCode))
                        {
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = true;                         // 仕入先ｺｰﾄﾞ/名 ：編集不可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = true;                         // 仕入・部材    ：編集不可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;                      // 仕入単価/金額 ：編集不可
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;                  // 仕入先納品数  ：編集不可
                        }
                        else
                        {
                            // 仕入先ｺｰﾄﾞが"999"の場合
                            if (Consts.OthersVendorCode.Equals(vendorCode))
                            {
                                grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = (nouhinRowCount == 1);    // 仕入先ｺｰﾄﾞ/名 ：編集可
                            }
                            else
                            {
                                grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].ReadOnly = true;                     // 仕入先ｺｰﾄﾞ/名 ：編集不可
                            }
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].ReadOnly = (nouhinRowCount == 1);        // 仕入・部材    ：編集可
                                                                                                                                        // 仕入単価が0の場合
                            if (wkPurchaseBid == decimal.Zero)
                            {
                                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = false;                 // 仕入単価/金額 ：編集可
                            }
                            else
                            {
                                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].ReadOnly = true;                  // 仕入単価/金額 ：編集不可
                            }
                            grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].ReadOnly = true;                  // 仕入先納品数  ：編集不可
                        }
                        grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].ReadOnly = true;                                       // 備考          ：編集不可
                    }
                }

                // セル未選択時の背景色の設定
                grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].Style.BackColor = setItemCodeColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].Style.BackColor = setItemNameColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].Style.BackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].Style.BackColor = setColor;
                // セル選択時の背景色の設定
                grdOrdersDetails.Rows[gRow.Index].Cells[clmRowNo.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmItemAndOpponentCode.Name].Style.SelectionBackColor = setItemCodeColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmItemName.Name].Style.SelectionBackColor = setItemNameColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersQuantity.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmUnit.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmOrdersBidAndAmount.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmVendorCodeAndName.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchasePartsType.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseBidAndAmount.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmPurchaseDeliveryQuantity.Name].Style.SelectionBackColor = setColor;
                grdOrdersDetails.Rows[gRow.Index].Cells[clmRemarks.Name].Style.SelectionBackColor = setColor;
            }
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
                c.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            }
            // 伝票Noの場合
            else if (c.Name.Equals(txtDocumentNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            }
            // 受注Noの場合
            else if (c.Name.Equals(txtOrdersNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOrdersNo_Leave);
            }
            // 件名Noの場合
            else if (c.Name.Equals(txtConstructionNo.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtConstructionNo_Leave);
            }
            // 伝票日付の場合
            else if (c.Name.Equals(txtDocumentDateYears.Name) ||
                     c.Name.Equals(txtDocumentDateMonth.Name) ||
                     c.Name.Equals(txtDocumentDateDays.Name) ||
                     c.Name.Equals(dtpDocumentDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.documentDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.documentDate_Leave);
            }
            // 出荷日の場合
            else if (c.Name.Equals(txtShipDateYears.Name) ||
                     c.Name.Equals(txtShipDateMonth.Name) ||
                     c.Name.Equals(txtShipDateDays.Name) ||
                     c.Name.Equals(dtpShipDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.shipDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.shipDate_Leave);
            }
            // 着日の場合
            else if (c.Name.Equals(txtOnTheDayYears.Name) ||
                     c.Name.Equals(txtOnTheDayMonth.Name) ||
                     c.Name.Equals(txtOnTheDayDays.Name) ||
                     c.Name.Equals(dtpOnTheDay.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.onTheDay_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.onTheDay_Leave);
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
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
                DataRow dRow = dt.Rows[0];
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    // 入力値クリア設定
                    txtCustomerName.Text = string.Empty;
                    txtCustomerKanaName.Text = string.Empty;
                    txtCustomerPersonnel.Text = string.Empty;
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
                    txtCustomerPersonnel.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiTantousyaName]);

                }
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

        #region 件名情報設定処理
        /// <summary>
        /// 件名情報設定処理
        /// </summary>
        /// <param name="kenmeiNo"></param>
        private void setKenmeiInfo(string kenmeiNo)
        {
            // 納入先情報設定処理実行
            if (setNonyuSakiInfo(string.Empty, string.Empty, kenmeiNo, false, true))
            {
                txtConstructionNo.BeforeValue = txtConstructionNo.Text;
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
            // 得意先ｺｰﾄﾞを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerCode.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 伝票Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDocumentNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 受注Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtOrdersNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 件名Noを編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtConstructionNo.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 納入先名を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtDeliveredName.Name))
            {
                // 検索ボタン使用可
                enabled = true;
            }
            // 受注グリッド編集中の場合
            else if (activeControlInfo.FlgGridEditingControl)
            {
                // 商品ｺｰﾄﾞの場合
                if (activeControlInfo.RowIndex % grdOrdersDetails.RowSegmentCount != 0 &&
                    activeControlInfo.ClmIndex == clmItemAndOpponentCode.DisplayIndex)
                {
                    // 検索ボタン使用可
                    enabled = true;
                }
                // 仕入先ｺｰﾄﾞの場合
                else if (activeControlInfo.RowIndex % grdOrdersDetails.RowSegmentCount == 0 &&
                         activeControlInfo.ClmIndex == clmVendorCodeAndName.DisplayIndex)
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

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtDocumentNo.MaxLength = 8;                // 伝票ＮＯ
            txtDocumentDateYears.MaxLength = 4;         // 伝票日付(年)
            txtDocumentDateMonth.MaxLength = 2;         // 伝票日付(月)
            txtDocumentDateDays.MaxLength = 2;          // 伝票日付(日)
            txtOrdersNo.MaxLength = 15;                 // 受注ＮＯ
            cmbPersonnel.MaxLength = 10;                // 担当者
            cmbPublisher.MaxLength = 10;                // 発行者
            txtCustomerCode.MaxLength = 5;              // 得意先ｺｰﾄﾞ
            txtCustomerName.MaxLength = 40;             // 得意先名
            txtCustomerKanaName.MaxLength = 80;         // 得意先カナ名
            cmbOffices.MaxLength = 10;                  // 事業所
            txtCustomerPersonnel.MaxLength = 15;        // 得意先担当者名
            cmbMaterialsConstructionType.MaxLength = 5; // 材料・工事区分
            txtShipDateYears.MaxLength = 4;             // 出荷日(年)
            txtShipDateMonth.MaxLength = 2;             // 出荷日(月)
            txtShipDateDays.MaxLength = 2;              // 出荷日(日)
            txtOnTheDayYears.MaxLength = 4;             // 着日(年)
            txtOnTheDayMonth.MaxLength = 2;             // 着日(月)
            txtOnTheDayDays.MaxLength = 2;              // 着日(日)
            txtShippingFlights.MaxLength = 10;          // 出荷便
            txtGuestNoteNumber.MaxLength = 20;          // 客先注番
            txtConstructionNo.MaxLength = 5;            // 件名NO
            txtSubject1.MaxLength = 20;                 // 件名１
            txtSubject2.MaxLength = 20;                 // 件名２
            txtDeliveredName.MaxLength = 30;            // 納入先名
            txtDeliveredDeploymentName.MaxLength = 10;  // 部署名
            txtContact1.MaxLength = 13;                 // ＴＥＬ
            txtContact2.MaxLength = 13;                 // ＦＡＸ
            txtZipCode.MaxLength = 8;                   // 郵便番号
            txtAddress1.MaxLength = 25;                 // 住所１
            txtAddress2.MaxLength = 25;                 // 住所２
            txtDeliveredPersonnelName.MaxLength = 15;   // 納入先担当者名

            // 入力制御イベント設定
            txtDocumentNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 伝票ＮＯ    :数字のみ入力可
            txtDocumentDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 伝票日付(年):数字のみ入力可
            txtDocumentDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 伝票日付(月):数字のみ入力可
            txtDocumentDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 伝票日付(日):数字のみ入力可
            txtOrdersNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 受注ＮＯ    :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 得意先ｺｰﾄﾞ  :数字のみ入力可
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtEmKanaOnlyInput_KeyPress);      // 得意先カナ名:全角カナのみ入力可
            txtShipDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 出荷日(年)  :数字のみ入力可
            txtShipDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 出荷日(月)  :数字のみ入力可
            txtShipDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 出荷日(日)  :数字のみ入力可
            txtOnTheDayYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 着日(年)    :数字のみ入力可
            txtOnTheDayMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 着日(月)    :数字のみ入力可
            txtOnTheDayDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);         // 着日(日)    :数字のみ入力可
            txtConstructionNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);       // 件名NO      :数字のみ入力可
            txtContact1.KeyPress += new KeyPressEventHandler(txtDigitalAndHaihunOnlyInput_KeyPress);    // ＴＥＬ      :数字のみ入力可
            txtContact2.KeyPress += new KeyPressEventHandler(txtDigitalAndHaihunOnlyInput_KeyPress);    // ＦＡＸ      :数字のみ入力可
            txtZipCode.KeyPress += new KeyPressEventHandler(txtDigitalAndHaihunOnlyInput_KeyPress);     // 郵便番号    :数字のみ入力可

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
            List<DBFileLayout.ShouhinMasterFile> shouhinInfo = shouhinMaster.getShouhinInfo(shiresakiCode, topClassification, btmClassification, shouhinCode, false);

            int topRowIndex = rowIndex;
            int btmRowIndex = 0;
            if (topRowIndex % grdOrdersDetails.RowSegmentCount != 0)
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
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmItemAndOpponentCode.Name].Value = string.Empty;
                grdOrdersDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            }
            // 対象の商品情報が取得できた場合
            else if (shouhinInfo.Count > 0)
            {
                // 商品情報の設定
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmItemAndOpponentCode.Name].Value = shouhinInfo[0].ShouhinCode;
                if (!Consts.OthersItemCode.Equals(shouhinInfo[0].ShouhinCode))
                {
                    grdOrdersDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = shouhinInfo[0].ShouhinName;
                }
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = shouhinInfo[0].TopClassification;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = shouhinInfo[0].BtmClassification;
            }
            else if (dummyCode.Equals(shouhinCode))
            {
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmItemAndOpponentCode.Name].Value = string.Empty;
                grdOrdersDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            }
        }
        #endregion

        #region 仕入先情報設定処理
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        private void setShiresakiInfo(string shiresakiCode)
        {
            // 仕入先情報の取得
            List< DBFileLayout.ShiresakiMasterFile> shiresakiInfo = shiresakiMaster.getShiresakiInfo(shiresakiCode);

            int topRowIndex = grdOrdersDetails.CurrentCell.RowIndex;
            int btmRowIndex = 0;
            if (topRowIndex % grdOrdersDetails.RowSegmentCount != 0)
            {
                btmRowIndex = topRowIndex;
                topRowIndex--;
            }
            else
            {
                btmRowIndex = topRowIndex + 1;
            }
            // 対象の商品情報が取得できた場合
            if (shiresakiInfo.Count > 0)
            {
                // 商品情報の設定
                grdOrdersDetails.Rows[topRowIndex].Cells[clmVendorCodeAndName.Name].Value = shiresakiInfo[0].ShiresakiCode;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmVendorCodeAndName.Name].Value = shiresakiInfo[0].ShiresakiName;
            }
            else if (dummyCode.Equals(shiresakiCode))
            {
                grdOrdersDetails.Rows[topRowIndex].Cells[clmVendorCodeAndName.Name].Value = string.Empty;
                grdOrdersDetails.Rows[btmRowIndex].Cells[clmVendorCodeAndName.Name].Value = string.Empty;
            }
        }
        #endregion

        #region 全明細の再計算処理
        /// <summary>
        /// 全明細の再計算処理
        /// </summary>
        private void recalcMeisaiAll()
        {
            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
            {
                // 下段行の場合
                if (i % grdOrdersDetails.RowSegmentCount != 0)
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
        private void recalcMeisai(int rowIndex, RecalcMeisaiTYpe type)
        {
            // 金額の再計算
            int topRowIndex = rowIndex % grdOrdersDetails.RowSegmentCount == 0 ? rowIndex : rowIndex - 1;
            int btmRowIndex = topRowIndex + 1;
            string strOrdersQuantity = Convert.ToString(grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersQuantity.Name].Value);
            string strOrdersBid = Convert.ToString(grdOrdersDetails.Rows[topRowIndex].Cells[clmOrdersBidAndAmount.Name].Value);
            string strOrdersAmount = string.Empty;
            string strPurchaseBid = Convert.ToString(grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value);
            string strPurchaseAmount = string.Empty;
            decimal quantity = decimal.Zero;
            decimal bid = decimal.Zero;
            decimal amount = decimal.Zero;

            switch (type)
            {
                case RecalcMeisaiTYpe.All:
                    break;
                case RecalcMeisaiTYpe.OrdersQuantityInput:
                    // 受注金額の再設定
                    if (string.IsNullOrEmpty(strOrdersBid))
                    {
                    }
                    else if (string.IsNullOrEmpty(strOrdersQuantity))
                    {
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = null;
                    }
                    else
                    {
                        decimal.TryParse(strOrdersQuantity, out quantity);
                        decimal.TryParse(strOrdersBid, out bid);
                        amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, quantity * bid);
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = amount.ToString(ordersAmountFormat);
                    }
                    // 仕入金額の再設定
                    if (string.IsNullOrEmpty(strPurchaseBid))
                    {
                    }
                    else if (string.IsNullOrEmpty(strOrdersQuantity))
                    {
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = null;
                    }
                    else
                    {
                        decimal.TryParse(strOrdersQuantity, out quantity);
                        decimal.TryParse(strPurchaseBid, out bid);
                        //TODO
                        amount = commonLogic.ShiresakiRoundKingaku(txtCustomerCode.Text, quantity * bid);
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = amount.ToString(purchaseAmountFormat);
                    }
                    break;
                case RecalcMeisaiTYpe.OrdersBidInput:
                    // 受注金額の再設定
                    if (string.IsNullOrEmpty(strOrdersQuantity) || string.IsNullOrEmpty(strOrdersBid))
                    {
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = null;
                    }
                    else
                    {
                        decimal.TryParse(strOrdersQuantity, out quantity);
                        decimal.TryParse(strOrdersBid, out bid);
                        amount = commonLogic.TokuisakiRoundKingaku(txtCustomerCode.Text, quantity * bid);
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = amount.ToString(ordersAmountFormat);
                    }
                    break;
                case RecalcMeisaiTYpe.PurchaseBidInput:
                    // 仕入金額の再設定
                    if (string.IsNullOrEmpty(strOrdersQuantity) || string.IsNullOrEmpty(strPurchaseBid))
                    {
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = null;
                    }
                    else
                    {
                        decimal.TryParse(strOrdersQuantity, out quantity);
                        decimal.TryParse(strPurchaseBid, out bid);
                        //TODO
                        amount = commonLogic.ShiresakiRoundKingaku(txtCustomerCode.Text, quantity * bid);
                        grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = amount.ToString(purchaseAmountFormat);
                    }
                    break;
            }
            // 納品残数量の再計算処理を実行
            recalcDeliveryResidualQuantity(rowIndex);
            grdOrdersDetails.Refresh();
        }
        #endregion

        #region 明細金額の集計処理
        /// <summary>
        /// 明細金額の集計処理
        /// </summary>
        private void recalcDetailsTotal()
        {
            DataGridViewRow btmRow;
            string ordersAmount;
            string purchaseAmount;
            decimal amount;
            bool flgOrdersAmountCalc = false;
            bool flgPurchaseAmountCalc = false;
            decimal ordersAmountTotal = decimal.Zero;
            decimal purchaseAmountTotal = decimal.Zero;

            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
            {
                if (i % grdOrdersDetails.RowSegmentCount == 0) continue;
                btmRow = grdOrdersDetails.Rows[i];
                ordersAmount = Convert.ToString(btmRow.Cells[clmOrdersBidAndAmount.Name].Value);
                purchaseAmount = Convert.ToString(btmRow.Cells[clmPurchaseBidAndAmount.Name].Value);

                if (decimal.TryParse(ordersAmount, out amount))
                {
                    ordersAmountTotal += amount;
                    flgOrdersAmountCalc = true;
                }
                if (decimal.TryParse(purchaseAmount, out amount))
                {
                    purchaseAmountTotal += amount;
                    flgPurchaseAmountCalc = true;
                }
                i++;
            }

            DataTable dt = (DataTable)grdOrdersDetailsTotal.DataSource;
            // 受注金額集計済みフラグがtrueの場合
            if (flgOrdersAmountCalc)
            {
                dt.Rows[0][clmDetailsOrdersTotal.DataPropertyName] = ordersAmountTotal;
            }
            else
            {
                dt.Rows[0][clmDetailsOrdersTotal.DataPropertyName] = DBNull.Value;
            }

            // 仕入金額集計済みフラグがtrueの場合
            if (flgPurchaseAmountCalc)
            {
                dt.Rows[0][clmDetailsPurchaseTotal.DataPropertyName] = purchaseAmountTotal;
            }
            else
            {
                dt.Rows[0][clmDetailsPurchaseTotal.DataPropertyName] = DBNull.Value;
            }
            //grdOrdersDetailsTotal.Refresh();
        }
        #endregion

        #region 受注金額の集計処理
        /// <summary>
        /// 受注金額の集計処理
        /// </summary>
        private void recalcOrdersTotal()
        {
            DataGridViewRow btmRow;
            string detailType;
            string ordersAmount;
            string purchaseAmount;
            decimal amount;
            bool flgPlatingFeeCalc = false;
            decimal platingFeeTotal = decimal.Zero;
            bool flgPaintingFeeCalc = false;
            decimal paintingFeeTotal = decimal.Zero;
            bool flgFareCalc = false;
            decimal fareTotal = decimal.Zero;
            bool flgPurchaseAmountCalc = false;
            decimal purchaseAmountTotal = decimal.Zero;
            bool flgPartsAmountCalc = false;
            decimal partsAmountTotal = decimal.Zero;

            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
            {
                if (i % grdOrdersDetails.RowSegmentCount == 0) continue;
                btmRow = grdOrdersDetails.Rows[i];

                detailType = Convert.ToString(btmRow.Cells[clmPurchasePartsType.Name].Value);
                ordersAmount = Convert.ToString(btmRow.Cells[clmOrdersBidAndAmount.Name].Value);
                purchaseAmount = Convert.ToString(btmRow.Cells[clmPurchaseBidAndAmount.Name].Value);

                // 明細区分がメッキ代の場合
                if (Consts.OrdersDetailType.PlatingAmount.Equals(detailType))
                {
                    if (decimal.TryParse(purchaseAmount, out amount))
                    {
                        platingFeeTotal += amount;
                        flgPlatingFeeCalc = true;
                    }
                }
                // 明細区分が塗装代の場合
                else if (Consts.OrdersDetailType.PaintingAmount.Equals(detailType))
                {
                    if (decimal.TryParse(purchaseAmount, out amount))
                    {
                        paintingFeeTotal += amount;
                        flgPaintingFeeCalc = true;
                    }
                }
                // 明細区分が運賃の場合
                else if (Consts.OrdersDetailType.Fare.Equals(detailType))
                {
                    if (decimal.TryParse(purchaseAmount, out amount))
                    {
                        fareTotal += amount;
                        flgFareCalc = true;
                    }
                }
                // 明細区分が仕入の場合
                else if (Consts.OrdersDetailType.Purchase.Equals(detailType))
                {
                    if (decimal.TryParse(purchaseAmount, out amount))
                    {
                        purchaseAmountTotal += amount;
                        flgPurchaseAmountCalc = true;
                    }
                }
                // 明細区分が部材の場合
                else if (Consts.OrdersDetailType.Parts.Equals(detailType))
                {
                    if (decimal.TryParse(purchaseAmount, out amount))
                    {
                        partsAmountTotal += amount;
                        flgPartsAmountCalc = true;
                    }
                }
            }

            DataTable dt = (DataTable)grdOrdersTotal.DataSource;
            // メッキ代集計済みフラグがtrueの場合
            if (flgPlatingFeeCalc)
            {
                dt.Rows[0][clmPlatingAmount.DataPropertyName] = platingFeeTotal;
            }
            else
            {
                dt.Rows[0][clmPlatingAmount.DataPropertyName] = DBNull.Value;
            }
            // 塗装代集計済みフラグがtrueの場合
            if (flgPaintingFeeCalc)
            {
                dt.Rows[0][clmPaintAmount.DataPropertyName] = paintingFeeTotal;
            }
            else
            {
                dt.Rows[0][clmPaintAmount.DataPropertyName] = DBNull.Value;
            }
            // 運賃集計済みフラグがtrueの場合
            if (flgFareCalc)
            {
                dt.Rows[0][clmFare.DataPropertyName] = fareTotal;
            }
            else
            {
                dt.Rows[0][clmFare.DataPropertyName] = DBNull.Value;
            }
            // 仕入金額集計済みフラグがtrueの場合
            if (flgPurchaseAmountCalc)
            {
                dt.Rows[0][clmPurchase.DataPropertyName] = purchaseAmountTotal;
            }
            else
            {
                dt.Rows[0][clmPurchase.DataPropertyName] = DBNull.Value;
            }
            // 部材金額集計済みフラグがtrueの場合
            if (flgPartsAmountCalc)
            {
                dt.Rows[0][clmParts.DataPropertyName] = partsAmountTotal;
            }
            else
            {
                dt.Rows[0][clmParts.DataPropertyName] = DBNull.Value;
            }

            // メッキ代、塗装代、運賃、仕入金額、部材金額の何れかが集計済みの場合
            if (flgPlatingFeeCalc || flgPaintingFeeCalc || flgFareCalc || flgPurchaseAmountCalc || flgPartsAmountCalc)
            {
                dt.Rows[0][clmPurchaseTotal.DataPropertyName] = platingFeeTotal + paintingFeeTotal + fareTotal + purchaseAmountTotal + partsAmountTotal;
            }
            else
            {
                dt.Rows[0][clmPurchaseTotal.DataPropertyName] = DBNull.Value;
            }

            bool flgOrdersCalc = false;
            bool flgPurchaseCalc = false;
            decimal ordersTotal;
            decimal purchaseTotal;

            ordersAmount = Convert.ToString(((DataTable)grdOrdersDetailsTotal.DataSource).Rows[0][clmDetailsOrdersTotal.DataPropertyName]);
            purchaseAmount = Convert.ToString(((DataTable)grdOrdersDetailsTotal.DataSource).Rows[0][clmDetailsPurchaseTotal.DataPropertyName]);
            if (decimal.TryParse(ordersAmount, out ordersTotal))
            {
                flgOrdersCalc = true;
            }
            if (decimal.TryParse(purchaseAmount, out purchaseTotal))
            {
                flgPurchaseCalc = true;
            }
            
            // 受注金額が空白かつ仕入金額が空白の場合
            if (!flgOrdersCalc && !flgPurchaseCalc)
            {
                dt.Rows[0][clmGrossMarginAmount.DataPropertyName] = DBNull.Value;
                dt.Rows[0][clmGrossMarginRate.DataPropertyName] = DBNull.Value;
            }
            // 受注金額が0より大きい場合
            else if (ordersTotal != decimal.Zero)
            {
                dt.Rows[0][clmGrossMarginAmount.DataPropertyName] = ordersTotal - purchaseTotal;
                dt.Rows[0][clmGrossMarginRate.DataPropertyName] = ((ordersTotal - purchaseTotal) / ordersTotal);
            }
            // 上記以外の場合
            else
            {
                dt.Rows[0][clmGrossMarginAmount.DataPropertyName] = ordersTotal - purchaseTotal;
                dt.Rows[0][clmGrossMarginRate.DataPropertyName] = DBNull.Value;
            }
        }
        #endregion

        #region 受注ヘッダ登録・更新SQL生成処理
        /// <summary>
        /// 受注ヘッダ登録・更新SQL生成処理
        /// </summary>
        /// <param name="denpyoNo"></param>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createHeaderRegistSql(ref string denpyoNo, ref string juchuNo, DateTime registerDate)
        {
            string sql = string.Empty;
            DateTime denpyoHizuke = commonLogic.convertDateTime(txtDocumentDateYears.Text, txtDocumentDateMonth.Text, txtDocumentDateDays.Text);
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            string tantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);
            string tantousyaName = cmbPersonnel.Text;
            string hakousyaCode = Convert.ToString(cmbPublisher.SelectedValue);
            string hakousyaName = cmbPublisher.Text;
            string chihouCode = string.Empty;
            string chikuCode = string.Empty;
            DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
            List< DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = tokuisakiMaster.getTokuisakiInfo(txtCustomerCode.Text, Convert.ToString(cmbOffices.SelectedValue));
            if (tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
            }
            string tokuisakiCode = txtCustomerCode.Text;
            string tokuisakiName = txtCustomerName.Text;
            string tokuisakiKanaName = txtCustomerKanaName.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string jigyousyoName = cmbOffices.Text;
            string tokuisakiTantousayName = txtCustomerPersonnel.Text;
            string zairyoKoujiKubun = Convert.ToString(cmbMaterialsConstructionType.SelectedValue);
            string syukabi = "NULL";
            string tyakubi = "NULL";
            if (!string.IsNullOrEmpty(txtShipDateYears.Text + txtShipDateMonth.Text + txtShipDateDays.Text))
            {
                syukabi = "'" + txtShipDateYears.Text + "-" + txtShipDateMonth.Text + "-" + txtShipDateDays.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtOnTheDayYears.Text + txtOnTheDayMonth.Text + txtOnTheDayDays.Text))
            {
                tyakubi = "'" + txtOnTheDayYears.Text + "-" + txtOnTheDayMonth.Text + "-" + txtOnTheDayDays.Text + "'";
            }
            string syukabin = txtShippingFlights.Text;
            string kyakusakiChuban = txtGuestNoteNumber.Text;
            string kenmeiNo = txtConstructionNo.Text;
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;
            string nounyusakiName = txtDeliveredName.Text;
            string busyoName = txtDeliveredDeploymentName.Text;
            string zipCode = txtZipCode.Text;
            string addres1 = txtAddress1.Text;
            string addres2 = txtAddress2.Text;
            string renrakusaki1 = txtContact1.Text;
            string renrakusaki2 = txtContact2.Text;
            string mitumoriNo = txtEstimateNo.Text;
            string nounyusakiTantousyaName = txtDeliveredPersonnelName.Text;
            if (rdoNew.Checked)
            {
                // 伝票No採番
                denpyoNo = commonLogic.getZeroBuriedNumberText((kanriMaster.getJuchuNo() + 1).ToString(), txtDocumentNo.MaxLength);
                // 受注No採番
                juchuNoTop = Program.loginUserInfo.UserId;
                juchuNoMid = registerDate.Month < 10 ? "0" + registerDate.Month.ToString() : registerDate.Month.ToString();
                juchuNoBtm = commonLogic.getZeroBuriedNumberText((tantousyaMaster.getUserChumonNo(Program.loginUserInfo.UserId) + 1).ToString(), 10);
                juchuNo = juchuNoTop + juchuNoMid + juchuNoBtm;

                // 受注ヘッダの登録SQL生成
                sql += "INSERT INTO juchu_header ";
                sql += "( ";
                sql += "  denpyoNo ";
                sql += ", denpyoHizuke ";
                sql += ", juchuNoTop ";
                sql += ", juchuNoMid ";
                sql += ", juchuNoBtm ";
                sql += ", tantousyaCode ";
                sql += ", tantousyaName ";
                sql += ", hakousyaCode ";
                sql += ", hakousyaName ";
                sql += ", chihouCode ";
                sql += ", chikuCode ";
                sql += ", tokuisakiCode ";
                sql += ", tokuisakiName ";
                sql += ", tokuisakiKanaName ";
                sql += ", jigyousyoCode ";
                sql += ", jigyousyoName ";
                sql += ", tokuisakiTantousayName ";
                sql += ", zairyoKoujiKubun ";
                sql += ", syukabi ";
                sql += ", tyakubi ";
                sql += ", syukabin ";
                sql += ", kyakusakiChuban ";
                sql += ", kenmeiNo ";
                sql += ", kenmei1 ";
                sql += ", kenmei2 ";
                sql += ", nounyusakiName ";
                sql += ", busyoName ";
                sql += ", zipCode ";
                sql += ", addres1 ";
                sql += ", addres2 ";
                sql += ", renrakusaki1 ";
                sql += ", renrakusaki2 ";
                sql += ", nounyusakiTantousyaName ";
                sql += ", mitumoriNo ";
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
                sql += "," + "'" + tantousyaCode + "' ";
                sql += "," + "'" + tantousyaName + "' ";
                sql += "," + "'" + hakousyaCode + "' ";
                sql += "," + "'" + hakousyaName + "' ";
                sql += "," + "'" + chihouCode + "' ";
                sql += "," + "'" + chikuCode + "' ";
                sql += "," + "'" + tokuisakiCode + "' ";
                sql += "," + "'" + tokuisakiName + "' ";
                sql += "," + "'" + tokuisakiKanaName + "' ";
                sql += "," + "'" + jigyousyoCode + "' ";
                sql += "," + "'" + jigyousyoName + "' ";
                sql += "," + "'" + tokuisakiTantousayName + "' ";
                sql += "," + "'" + zairyoKoujiKubun + "' ";
                sql += "," + syukabi + " ";
                sql += "," + tyakubi + " ";
                sql += "," + "'" + syukabin + "' ";
                sql += "," + "'" + kyakusakiChuban + "' ";
                sql += "," + "'" + kenmeiNo + "' ";
                sql += "," + "'" + kenmei1 + "' ";
                sql += "," + "'" + kenmei2 + "' ";
                sql += "," + "'" + nounyusakiName + "' ";
                sql += "," + "'" + busyoName + "' ";
                sql += "," + "'" + zipCode + "' ";
                sql += "," + "'" + addres1 + "' ";
                sql += "," + "'" + addres2 + "' ";
                sql += "," + "'" + renrakusaki1 + "' ";
                sql += "," + "'" + renrakusaki2 + "' ";
                sql += "," + "'" + nounyusakiTantousyaName + "' ";
                sql += "," + "'" + mitumoriNo + "' ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                commonLogic.SubStringJuchuNo(juchuNo,ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
                // 受注ヘッダの更新SQL生成
                sql = "UPDATE juchu_header SET ";
                sql += "  denpyoNo = '" + denpyoNo + "' ";
                sql += ", denpyoHizuke = '" + denpyoHizuke + "' ";
                sql += ", juchuNoTop = '" + juchuNoTop + "' ";
                sql += ", juchuNoMid = '" + juchuNoMid + "' ";
                sql += ", juchuNoBtm = '" + juchuNoBtm + "' ";
                sql += ", tantousyaCode = '" + tantousyaCode + "' ";
                sql += ", tantousyaName = '" + tantousyaName + "' ";
                sql += ", hakousyaCode = '" + hakousyaCode + "' ";
                sql += ", hakousyaName = '" + hakousyaName + "' ";
                sql += ", tokuisakiCode = '" + tokuisakiCode + "' ";
                sql += ", tokuisakiName = '" + tokuisakiName + "' ";
                sql += ", tokuisakiKanaName = '" + tokuisakiKanaName + "' ";
                sql += ", jigyousyoCode = '" + jigyousyoCode + "' ";
                sql += ", jigyousyoName = '" + jigyousyoName + "' ";
                sql += ", tokuisakiTantousayName = '" + tokuisakiTantousayName + "' ";
                sql += ", zairyoKoujiKubun = '" + zairyoKoujiKubun + "' ";
                sql += ", syukabi = " + syukabi + " ";
                sql += ", tyakubi = " + tyakubi + " ";
                sql += ", syukabin = '" + syukabin + "' ";
                sql += ", kyakusakiChuban = '" + kyakusakiChuban + "' ";
                sql += ", kenmeiNo = '" + kenmeiNo + "' ";
                sql += ", kenmei1 = '" + kenmei1 + "' ";
                sql += ", kenmei2 = '" + kenmei2 + "' ";
                sql += ", nounyusakiName = '" + nounyusakiName + "' ";
                sql += ", busyoName = '" + busyoName + "' ";
                sql += ", zipCode = '" + zipCode + "' ";
                sql += ", addres1 = '" + addres1 + "' ";
                sql += ", addres2 = '" + addres2 + "' ";
                sql += ", renrakusaki1 = '" + renrakusaki1 + "' ";
                sql += ", renrakusaki2 = '" + renrakusaki2 + "' ";
                sql += ", nounyusakiTantousyaName = '" + nounyusakiTantousyaName + "' ";
                sql += ", mitumoriNo = '" + mitumoriNo + "' ";
                sql += ", kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '' ";
                sql += "WHERE denpyoNo = '" + denpyoNo + "' ";
            }
            else
            {
                // 受注ヘッダの論理削除SQL生成
                sql = "UPDATE juchu_header SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE denpyoNo = '" + denpyoNo + "' ";
            }

            return sql;
        }
        #endregion

        #region 受注ボディ登録・更新SQL生成処理
        /// <summary>
        /// 受注ボディ登録・更新SQL生成処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createBodyRegistSql(string juchuNo, DateTime registerDate)
        {
            List<string> sqlBodys = new List<string>();
            string sql = string.Empty;
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);

            if (rdoDelete.Checked)
            {
                // 受注ボディの論理削除SQL生成
                sql = "UPDATE juchu_body SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                sqlBodys.Add(sql);
            }
            else
            {
                // 受注ボディの登録・更新SQL生成
                string daiBunruiCode = string.Empty;
                string syoBunruiCode = string.Empty;
                string shouhinCode = string.Empty;
                string shouhinName1 = string.Empty;
                string shouhinName2 = string.Empty;
                string juchuSuryo = string.Empty;
                string juchuTani = string.Empty;
                string juchuNouhinZanSuryo = string.Empty;
                string juchuTanka = string.Empty;
                string juchuKingaku = string.Empty;
                string juchuNonyuKubun = string.Empty;
                string shiresakiCode = string.Empty;
                string shiresakiName = string.Empty;
                string shireBuzaiKubun = string.Empty;
                string shireTanka = string.Empty;
                string shireKingaku = string.Empty;
                string shireNouhinZanSuryo = string.Empty;
                string shireNouhinSuryo = string.Empty;
                string bikou = string.Empty;
                string selectCommand = string.Empty;
                int maxHachuPageRow = 12;
                int rowNo = 0;
                DataTable selectRes;
                for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
                {
                    if (checkEmptyRow(i))
                    {
                        break;
                    }

                    daiBunruiCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                    syoBunruiCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmbtmClassificationCode.Name].Value);
                    shouhinCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemAndOpponentCode.Name].Value);
                    shouhinName1 = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmItemName.Name].Value);
                    shouhinName2 = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemName.Name].Value);
                    juchuSuryo = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmOrdersQuantity.Name].Value);
                    juchuNouhinZanSuryo = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmOrdersQuantity.Name].Value);
                    juchuTani = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmUnit.Name].FormattedValue);
                    juchuTanka = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmOrdersBidAndAmount.Name].Value);
                    juchuKingaku = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmOrdersBidAndAmount.Name].Value);
                    juchuNonyuKubun = commonLogic.getNouhinsyoType(Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmUnit.Name].FormattedValue));
                    shiresakiCode = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmVendorCodeAndName.Name].Value);
                    shiresakiName = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmVendorCodeAndName.Name].Value);
                    shireBuzaiKubun = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchasePartsType.Name].Value);
                    shireTanka = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmPurchaseBidAndAmount.Name].Value);
                    shireKingaku = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchaseBidAndAmount.Name].Value);
                    shireNouhinZanSuryo = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmPurchaseDeliveryQuantity.Name].Value);
                    shireNouhinSuryo = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchaseDeliveryQuantity.Name].Value);
                    bikou = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmRemarks.Name].Value);
                    rowNo = ((int)(i / grdOrdersDetails.RowSegmentCount) + 1);

                    selectCommand = "SELECT 1 FROM juchu_body ";
                    selectCommand += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                    selectCommand += "AND juchuNoMid = '" + juchuNoMid + "' ";
                    selectCommand += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                    selectCommand += "AND rowNo = " + rowNo;
                    selectRes = juchuDataSelectDb.executeSelect(selectCommand, !rdoNew.Checked);
                    if (selectRes != null && selectRes.Rows.Count > 0)
                    {
                        // 同一行番号のデータが登録済みのため更新処理
                        sql = "UPDATE juchu_body SET ";
                        sql += "  juchuNoTop = " + "'" + juchuNoTop + "' ";
                        sql += ", juchuNoMid = " + "'" + juchuNoMid + "' ";
                        sql += ", juchuNoBtm = " + "'" + juchuNoBtm + "' ";
                        sql += ", rowNo = " + rowNo + " ";
                        sql += ", daiBunruiCode = " + "'" + daiBunruiCode + "' ";
                        sql += ", syoBunruiCode = " + "'" + syoBunruiCode + "' ";
                        sql += ", shouhinCode = " + "'" + shouhinCode + "' ";
                        sql += ", shouhinName1 = " + "'" + shouhinName1 + "' ";
                        sql += ", shouhinName2 = " + "'" + shouhinName2 + "' ";
                        sql += ", juchuSuryo = " + (string.IsNullOrEmpty(juchuSuryo) ? "null" : Convert.ToDecimal(juchuSuryo).ToString()) + " ";
                        sql += ", juchuTani = " + "'" + juchuTani + "' ";
                        sql += ", juchuNouhinZanSuryo = " + (string.IsNullOrEmpty(juchuNouhinZanSuryo) ? "null" : Convert.ToDecimal(juchuNouhinZanSuryo).ToString()) + " ";
                        sql += ", juchuTanka = " + (string.IsNullOrEmpty(juchuTanka) ? "null" : Convert.ToDecimal(juchuTanka).ToString()) + " ";
                        sql += ", juchuKingaku = " + (string.IsNullOrEmpty(juchuKingaku) ? "null" : Convert.ToDecimal(juchuKingaku).ToString()) + " ";
                        sql += ", juchuNonyuKubun = " + "'" + juchuNonyuKubun + "' ";
                        sql += ", shireHachuNo = CASE WHEN shiresakiCode <> '" + shiresakiCode + "' THEN '' ELSE shireHachuNo END ";
                        sql += ", shiresakiCode = " + "'" + shiresakiCode + "' ";
                        sql += ", shiresakiName = " + "'" + shiresakiName + "' ";
                        sql += ", shireBuzaiKubun = " + "'" + shireBuzaiKubun + "' ";
                        sql += ", shireTanka = " + (string.IsNullOrEmpty(shireTanka) ? "null" : Convert.ToDecimal(shireTanka).ToString()) + " ";
                        sql += ", shireKingaku = " + (string.IsNullOrEmpty(shireKingaku) ? "null" : Convert.ToDecimal(shireKingaku).ToString()) + " ";
                        sql += ", shireNouhinZanSuryo = " + (string.IsNullOrEmpty(shireNouhinZanSuryo) ? "null" : Convert.ToDecimal(shireNouhinZanSuryo).ToString()) + " ";
                        sql += ", shireNouhinSuryo = " + (string.IsNullOrEmpty(shireNouhinSuryo) ? "null" : Convert.ToDecimal(shireNouhinSuryo).ToString()) + " ";
                        sql += ", bikou = " + "'" + bikou + "' ";
                        sql += ", kousinNichizi = '" + registerDate + "' ";
                        sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE0 + "' ";
                        sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                        sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                        sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                        sql += "AND rowNo = " + rowNo;
                    }
                    else
                    {
                        // 同一行番号のデータが未登録のため登録処理
                        sql = "INSERT INTO juchu_body ";
                        sql += "( ";
                        sql += "  juchuNoTop ";
                        sql += ", juchuNoMid ";
                        sql += ", juchuNoBtm ";
                        sql += ", rowNo ";
                        sql += ", daiBunruiCode ";
                        sql += ", syoBunruiCode ";
                        sql += ", shouhinCode ";
                        sql += ", shouhinName1 ";
                        sql += ", shouhinName2 ";
                        sql += ", juchuSuryo ";
                        sql += ", juchuTani ";
                        sql += ", juchuNouhinZanSuryo ";
                        sql += ", juchuTanka ";
                        sql += ", juchuKingaku ";
                        sql += ", juchuNonyuKubun ";
                        sql += ", shiresakiCode ";
                        sql += ", shiresakiName ";
                        sql += ", shireBuzaiKubun ";
                        sql += ", shireTanka ";
                        sql += ", shireKingaku ";
                        sql += ", shireNouhinZanSuryo ";
                        sql += ", shireNouhinSuryo ";
                        sql += ", bikou ";
                        sql += ", kousinNichizi ";
                        sql += ", kanriKubun ";
                        sql += ") ";
                        sql += "VALUES ";
                        sql += "( ";
                        sql += "'" + juchuNoTop + "' ";
                        sql += "," + "'" + juchuNoMid + "' ";
                        sql += "," + "'" + juchuNoBtm + "' ";
                        sql += "," + rowNo + " ";
                        sql += "," + "'" + daiBunruiCode + "' ";
                        sql += "," + "'" + syoBunruiCode + "' ";
                        sql += "," + "'" + shouhinCode + "' ";
                        sql += "," + "'" + shouhinName1 + "' ";
                        sql += "," + "'" + shouhinName2 + "' ";
                        sql += "," + (string.IsNullOrEmpty(juchuSuryo) ? "null" : Convert.ToDecimal(juchuSuryo).ToString()) + " ";
                        sql += "," + "'" + juchuTani + "' ";
                        sql += "," + (string.IsNullOrEmpty(juchuNouhinZanSuryo) ? "null" : Convert.ToDecimal(juchuNouhinZanSuryo).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(juchuTanka) ? "null" : Convert.ToDecimal(juchuTanka).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(juchuKingaku) ? "null" : Convert.ToDecimal(juchuKingaku).ToString()) + " ";
                        sql += "," + "'" + juchuNonyuKubun + "' ";
                        sql += "," + "'" + shiresakiCode + "' ";
                        sql += "," + "'" + shiresakiName + "' ";
                        sql += "," + "'" + shireBuzaiKubun + "' ";
                        sql += "," + (string.IsNullOrEmpty(shireTanka) ? "null" : Convert.ToDecimal(shireTanka).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(shireKingaku) ? "null" : Convert.ToDecimal(shireKingaku).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(shireNouhinZanSuryo) ? "null" : Convert.ToDecimal(shireNouhinZanSuryo).ToString()) + " ";
                        sql += "," + (string.IsNullOrEmpty(shireNouhinSuryo) ? "null" : Convert.ToDecimal(shireNouhinSuryo).ToString()) + " ";
                        sql += "," + "'" + bikou + "' ";
                        sql += "," + "'" + registerDate + "' ";
                        sql += "," + "'' ";
                        sql += ") ";
                    }
                    sqlBodys.Add(sql);

                    i++;
                }

                // 今回登録以外のデータを削除
                sql = "DELETE FROM juchu_body ";
                sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                sql += "AND rowNo > " + rowNo;

                sqlBodys.Add(sql);
            }

            return sqlBodys;
        }
        #endregion

        #region 受注フッタ登録・更新SQL生成処理
        /// <summary>
        /// 受注フッタ登録・更新SQL生成処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createFooterRegistSql(string juchuNo, DateTime registerDate)
        {
            string sql = string.Empty;
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);

            if (rdoDelete.Checked)
            {
                // 見積フッタの論理削除SQL生成
                sql = "UPDATE juchu_footer SET ";
                sql += "  kousinNichizi = '" + registerDate + "' ";
                sql += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
            }
            else
            {
                string juchuKei = Convert.ToString(grdOrdersDetailsTotal.Rows[0].Cells[clmDetailsOrdersTotal.Name].Value);
                string shireKei = Convert.ToString(grdOrdersDetailsTotal.Rows[0].Cells[clmDetailsPurchaseTotal.Name].Value);
                string mekkiDai = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmPlatingAmount.Name].Value);
                string tosouDai = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmPaintAmount.Name].Value);
                string unchin = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmFare.Name].Value);
                string shireDai = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmPurchase.Name].Value);
                string buzaiDai = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmParts.Name].Value);
                string shireGoukei = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmPurchaseTotal.Name].Value);
                string arariGaku = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmGrossMarginAmount.Name].Value);
                //string arariRitu = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmGrossMarginRate.Name].Value).Replace("%", string.Empty);
                string arariRitu = Convert.ToString(grdOrdersTotal.Rows[0].Cells[clmGrossMarginRate.Name].Value);

                if (rdoNew.Checked)
                {
                    // 受注フッタの登録SQL生成
                    sql += "INSERT INTO juchu_footer ";
                    sql += "( ";
                    sql += "  juchuNoTop ";
                    sql += ", juchuNoMid ";
                    sql += ", juchuNoBtm ";
                    sql += ", juchuKei ";
                    sql += ", shireKei ";
                    sql += ", mekkiDai ";
                    sql += ", tosouDai ";
                    sql += ", unchin ";
                    sql += ", shireDai ";
                    sql += ", buzaiDai ";
                    sql += ", shireGoukei ";
                    sql += ", arariGaku ";
                    sql += ", arariRitu ";
                    sql += ", kousinNichizi ";
                    sql += ", kanriKubun ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "'" + juchuNoTop + "' ";
                    sql += "," + "'" + juchuNoMid + "' ";
                    sql += "," + "'" + juchuNoBtm + "' ";
                    sql += "," + (string.IsNullOrEmpty(juchuKei) ? "null" : Convert.ToDecimal(juchuKei).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(shireKei) ? "null" : Convert.ToDecimal(shireKei).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(mekkiDai) ? "null" : Convert.ToDecimal(mekkiDai).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(tosouDai) ? "null" : Convert.ToDecimal(tosouDai).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(unchin) ? "null" : Convert.ToDecimal(unchin).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(shireDai) ? "null" : Convert.ToDecimal(shireDai).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(buzaiDai) ? "null" : Convert.ToDecimal(buzaiDai).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(shireGoukei) ? "null" : Convert.ToDecimal(shireGoukei).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(arariGaku) ? "null" : Convert.ToDecimal(arariGaku).ToString()) + " ";
                    sql += "," + (string.IsNullOrEmpty(arariRitu) ? "null" : Convert.ToDecimal(arariRitu).ToString()) + " ";
                    sql += "," + "'" + registerDate + "' ";
                    sql += "," + "'' ";
                    sql += ") ";
                }
                else
                {
                    // 受注フッタの更新SQL生成
                    sql = "UPDATE juchu_footer SET ";
                    sql += "  juchuNoTop = '" + juchuNoTop + "' ";
                    sql += ", juchuNoMid = '" + juchuNoMid + "' ";
                    sql += ", juchuNoBtm = '" + juchuNoBtm + "' ";
                    sql += ", juchuKei = " + (string.IsNullOrEmpty(juchuKei) ? "null" : Convert.ToDecimal(juchuKei).ToString()) + " ";
                    sql += ", shireKei = " + (string.IsNullOrEmpty(shireKei) ? "null" : Convert.ToDecimal(shireKei).ToString()) + " ";
                    sql += ", mekkiDai = " + (string.IsNullOrEmpty(mekkiDai) ? "null" : Convert.ToDecimal(mekkiDai).ToString()) + " ";
                    sql += ", tosouDai = " + (string.IsNullOrEmpty(tosouDai) ? "null" : Convert.ToDecimal(tosouDai).ToString()) + " ";
                    sql += ", unchin = " + (string.IsNullOrEmpty(unchin) ? "null" : Convert.ToDecimal(unchin).ToString()) + " ";
                    sql += ", shireDai = " + (string.IsNullOrEmpty(shireDai) ? "null" : Convert.ToDecimal(shireDai).ToString()) + " ";
                    sql += ", buzaiDai = " + (string.IsNullOrEmpty(buzaiDai) ? "null" : Convert.ToDecimal(buzaiDai).ToString()) + " ";
                    sql += ", shireGoukei = " + (string.IsNullOrEmpty(shireGoukei) ? "null" : Convert.ToDecimal(shireGoukei).ToString()) + " ";
                    sql += ", arariGaku = " + (string.IsNullOrEmpty(arariGaku) ? "null" : Convert.ToDecimal(arariGaku).ToString()) + " ";
                    sql += ", arariRitu = " + (string.IsNullOrEmpty(arariRitu) ? "null" : Convert.ToDecimal(arariRitu).ToString()) + " ";
                    sql += ", kousinNichizi = '" + registerDate + "' ";
                    sql += ", kanriKubun = '' ";
                    sql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                    sql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                    sql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                }
            }

            return sql;
        }
        #endregion

        #region 見積ヘッダ更新SQL生成処理
        /// <summary>
        /// 見積ヘッダ更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createMitumoriHeaderUpdateSql(string mitumoriNo, DateTime registerDate)
        {
            string sql = string.Empty;

            if(string.IsNullOrEmpty(mitumoriNo)) return sql;

            // 見積ヘッダの更新SQL生成
            //sql += "UPDATE mitumori_header mh ";
            //sql += ", (SELECT COUNT(1) AS joinCount FROM juchu_header WHERE (kanriKubun IS NULL OR kanriKubun <> '9') AND mitumoriNo = '" + mitumoriNo + "') jh ";
            //sql += "SET mh.kousinNichizi = '" + registerDate + "' ";
            //sql += "  , mh.kanriKubun = CASE WHEN jh.joinCount > 0 THEN '1' ELSE '' END ";
            //sql += "WHERE (mh.kanriKubun IS NULL OR kanriKubun <> '9') ";
            //sql += "AND mh.mitumoriNo = '" + mitumoriNo + "' ";

            return sql;
        }
        #endregion

        #region 発注情報登録SQL生成処理
        /// <summary>
        /// 発注情報登録SQL生成処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private Dictionary<string, HachuRegistSqlClass> createHachuRegistSql(string juchuNo, DateTime registerDate, ref string hachuNoUpdateSql)
        {
            Dictionary<string, HachuRegistSqlClass> dicHachuRegistSql = new Dictionary<string, HachuRegistSqlClass>();
            HachuRegistSqlClass wkHachuRegistSqlClass;
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            if (rdoDelete.Checked)
            {
                wkHachuRegistSqlClass = new HachuRegistSqlClass();
                // 発注情報の論理削除SQL生成
                string deleteHeaderSql = "UPDATE hachu_header SET ";
                deleteHeaderSql += "          kousinNichizi = '" + registerDate + "' ";
                deleteHeaderSql += "        , kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                deleteHeaderSql += "      WHERE juchuNoTop = '" + juchuNoTop + "' ";
                deleteHeaderSql += "      AND juchuNoMid = '" + juchuNoMid + "' ";
                deleteHeaderSql += "      AND juchuNoBtm = '" + juchuNoBtm + "' ";

                string deleteBodySql = "UPDATE hachu_body SET ";
                deleteBodySql += "          kousinNichizi = '" + registerDate + "' ";
                deleteBodySql += "        , kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                deleteBodySql += "      WHERE hachuNo IN (SELECT hachuNo FROM hachu_header";
                deleteBodySql += "                        WHERE juchuNoTop = '" + juchuNoTop + "' ";
                deleteBodySql += "                        AND juchuNoMid = '" + juchuNoMid + "' ";
                deleteBodySql += "                        AND juchuNoBtm = '" + juchuNoBtm + "') ";

                string deleteFooterSql = "UPDATE hachu_footer SET ";
                deleteFooterSql += "          kousinNichizi = '" + registerDate + "' ";
                deleteFooterSql += "        , kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                deleteFooterSql += "      WHERE hachuNo IN (SELECT hachuNo FROM hachu_header";
                deleteFooterSql += "                        WHERE juchuNoTop = '" + juchuNoTop + "' ";
                deleteFooterSql += "                        AND juchuNoMid = '" + juchuNoMid + "' ";
                deleteFooterSql += "                        AND juchuNoBtm = '" + juchuNoBtm + "') ";

                wkHachuRegistSqlClass.HeaderSql = deleteHeaderSql;
                wkHachuRegistSqlClass.BodySql.Add(deleteBodySql);
                wkHachuRegistSqlClass.FooterSql = deleteFooterSql;
                dicHachuRegistSql.Add(strAllDelete, wkHachuRegistSqlClass);
                return dicHachuRegistSql;
            }
            string sql = string.Empty;

            string shireNo = string.Empty;
            DateTime denpyoHizuke = commonLogic.convertDateTime(txtDocumentDateYears.Text, txtDocumentDateMonth.Text, txtDocumentDateDays.Text);
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
            string kenmeiNo = txtConstructionNo.Text;
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;
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
            DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
            List< DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = tokuisakiMaster.getTokuisakiInfo(txtCustomerCode.Text, Convert.ToString(cmbOffices.SelectedValue));
            if (tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
            }

            Dictionary<string, string> dicShireCode = new Dictionary<string, string>();
            string shireCode;
            string shireName;
            string dataExistSql;
            bool flgBodyOnly = false;
            DBCommon commonDB = new DBCommon();
            DataTable dataExistDt;
            int newHachuNo = kanriMaster.getHachuNo();
            string wkHachuNo;
            string wkStrKingaku;
            decimal wkKingaku1;
            decimal wkKingaku2;
            int juchuRowNo;
            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
            {
                if (checkEmptyRow(i))
                {
                    break;
                }
                flgBodyOnly = false;
                juchuRowNo = ((int)(i / grdOrdersDetails.RowSegmentCount) + 1);
                shireCode = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmVendorCodeAndName.Name].Value);
                // 仕入先ｺｰﾄﾞが空白の場合
                if (string.IsNullOrEmpty(shireCode))
                {
                    i++;
                    continue;
                }
                shireName = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmVendorCodeAndName.Name].Value);
                wkStrKingaku = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchaseBidAndAmount.Name].Value);
                if (dicHachuRegistSql.ContainsKey(shireCode))
                {
                    flgBodyOnly = true;
                }
                else
                {
                    dataExistSql = "SELECT hachuNo FROM hachu_header ";
                    dataExistSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                    dataExistSql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                    dataExistSql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                    dataExistSql += "AND shiresakiCode = '" + shireCode + "' ";
                    dataExistDt = juchuDataSelectDb.executeSelect(dataExistSql, false);
                    if (dataExistDt == null || dataExistDt.Rows.Count == 0)
                    {
                        newHachuNo++;
                        wkHachuNo = commonLogic.getZeroBuriedNumberText(newHachuNo.ToString(), 8);
                        hachuNoUpdateSql = "UPDATE kanri_master SET koumoku1 = '" + wkHachuNo + "' WHERE kanriCode = '" + Consts.KanriCodes.HachuNo + "'";
                    }
                    else
                    {
                        wkHachuNo = Convert.ToString(dataExistDt.Rows[0][DBFileLayout.HachuHeaderFile.dcHachuNo]);
                    }
                    wkHachuRegistSqlClass = new HachuRegistSqlClass();
                    wkHachuRegistSqlClass.HachuNo = wkHachuNo;
                    dicHachuRegistSql.Add(shireCode, wkHachuRegistSqlClass);
                }

                if (!flgBodyOnly)
                {
                    // 発注ヘッダの登録SQL生成
                    sql = "INSERT INTO hachu_header ";
                    sql += "( ";
                    sql += "  hachuNo ";
                    sql += ", juchuNoTop ";
                    sql += ", juchuNoMid ";
                    sql += ", juchuNoBtm ";
                    sql += ", denpyoHizuke ";
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
                    sql += ", shiresakiCode ";
                    sql += ", shiresakiName ";
                    sql += ", kousinNichizi ";
                    sql += ", kanriKubun ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "'" + dicHachuRegistSql[shireCode].HachuNo + "' ";
                    sql += "," + "'" + juchuNoTop + "' ";
                    sql += "," + "'" + juchuNoMid + "' ";
                    sql += "," + "'" + juchuNoBtm + "' ";
                    sql += "," + "'" + denpyoHizuke + "' ";
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
                    sql += "," + "'" + shireCode + "' ";
                    sql += "," + "'" + shireName + "' ";
                    sql += "," + "'" + registerDate + "' ";
                    sql += "," + "'' ";
                    sql += ") ";
                    dicHachuRegistSql[shireCode].HeaderSql = sql;
                }

                // 発注ボディの登録SQL生成
                daiBunruiCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                syoBunruiCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmbtmClassificationCode.Name].Value);
                shouhinCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemAndOpponentCode.Name].Value);
                shouhinName1 = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmItemName.Name].Value);
                shouhinName2 = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemName.Name].Value);
                suryo = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmOrdersQuantity.Name].Value);
                tani = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmUnit.Name].FormattedValue);
                tanka = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmPurchaseBidAndAmount.Name].Value);
                kingaku = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchaseBidAndAmount.Name].Value);
                bikou = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmRemarks.Name].Value);
                sql = "INSERT INTO hachu_body ";
                sql += "( ";
                sql += "  hachuNo ";
                sql += ", rowNo ";
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
                sql += ", juchuNoTop ";
                sql += ", juchuNoMid ";
                sql += ", juchuNoBtm ";
                sql += ", juchuRowNo ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + dicHachuRegistSql[shireCode].HachuNo + "' ";
                sql += "," + "'" + (dicHachuRegistSql[shireCode].BodySql.Count + 1) + "' ";
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
                sql += "," + "'" + juchuNoTop + "' ";
                sql += "," + "'" + juchuNoMid + "' ";
                sql += "," + "'" + juchuNoBtm + "' ";
                sql += "," + "'" + juchuRowNo + "' ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
                dicHachuRegistSql[shireCode].BodySql.Add(sql);
                // 仕入金額が入力されている場合
                if (!string.IsNullOrEmpty(wkStrKingaku))
                {
                    decimal.TryParse(dicHachuRegistSql[shireCode].HachuKingaku, out wkKingaku1);
                    decimal.TryParse(wkStrKingaku, out wkKingaku2);
                    dicHachuRegistSql[shireCode].HachuKingaku = (wkKingaku1 + wkKingaku2).ToString();
                }

                i++;
            }

            // 発注フッタの登録SQL生成
            foreach (KeyValuePair<string, HachuRegistSqlClass> pair in dicHachuRegistSql)
            {
                sql = "INSERT INTO hachu_footer ";
                sql += "( ";
                sql += "  hachuNo ";
                sql += ", hachuKingaku ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + pair.Value.HachuNo + "' ";
                sql += "," + (string.IsNullOrEmpty(pair.Value.HachuKingaku) ? "null" : Convert.ToDecimal(pair.Value.HachuKingaku).ToString()) + " ";
                sql += "," + "'" + registerDate + "' ";
                sql += "," + "'' ";
                sql += ") ";
                pair.Value.FooterSql = sql;
            }

            return dicHachuRegistSql;
        }
        #endregion

        #region 受注No更新SQL生成処理
        /// <summary>
        /// 受注No更新SQL生成処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createJuchuNoRegistSql(string juchuNo, DateTime registerDate)
        {
            string sql = string.Empty;

            sql = "UPDATE kanri_master SET ";
            sql += "  koumoku1 = '" + juchuNo + "' ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += "WHERE kanriCode = '" + Consts.KanriCodes.JuchuNo + "' ";

            return sql;
        }
        #endregion

        private class ShireInsertInfo
        {
            private string shireNo;
            private int rowNo;
            private int juchuRowNo;
            public string ShireNo
            {
                get { return shireNo; }
                set { shireNo = value; }
            }
            public int RowNo
            {
                get { return rowNo; }
                set { rowNo = value; }
            }
            public int JuchuRowNo
            {
                get { return juchuRowNo; }
                set { juchuRowNo = value; }
            }
            public ShireInsertInfo()
            {
            }
        }
        #region 仕入データ登録・更新SQL生成処理
        /// <summary>
        /// 仕入データ登録・更新SQL生成処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createShireRegistSql(string juchuNo, DateTime registerDate)
        {
            List<string> sqlShire = new List<string>();
            string sql = string.Empty;
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            registerDate = DateTime.Now;


            DateTime denpyoHizuke = commonLogic.convertDateTime(txtDocumentDateYears.Text, txtDocumentDateMonth.Text, txtDocumentDateDays.Text);
            DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfos = tokuisakiMaster.getTokuisakiInfo(txtCustomerCode.Text, Convert.ToString(cmbOffices.SelectedValue));
            string chihouCode = string.Empty;
            string chikuCode = string.Empty;
            if (tokuisakiInfos.Count > 0)
            {
                chihouCode = tokuisakiInfos[0].ChihouCode;
                chikuCode = tokuisakiInfos[0].ChikuCode;
            }
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
            string kenmeiNo = txtConstructionNo.Text;
            string kenmei1 = txtSubject1.Text;
            string kenmei2 = txtSubject2.Text;

            // 受注ボディの登録・更新SQL生成
            string daiBunruiCode = string.Empty;
            string syoBunruiCode = string.Empty;
            string shouhinCode = string.Empty;
            string shouhinName1 = string.Empty;
            string shouhinName2 = string.Empty;
            string juchuSuryo = string.Empty;
            string juchuTani = string.Empty;
            string juchuNouhinZanSuryo = string.Empty;
            string juchuTanka = string.Empty;
            string juchuKingaku = string.Empty;
            string juchuNonyuKubun = string.Empty;
            string shiresakiCode = string.Empty;
            string shiresakiName = string.Empty;
            string shireBuzaiKubun = string.Empty;
            string shireTanka = string.Empty;
            string shireKingaku = string.Empty;
            string shireNouhinZanSuryo = string.Empty;
            string shireNouhinSuryo = string.Empty;
            string bikou = string.Empty;
            string selectCommand = string.Empty;
            int rowNo = 0;
            DataTable selectRes;
            Dictionary<string, int> delKeys = new Dictionary<string, int>();
            Dictionary<string, ShireInsertInfo> insertKeys = new Dictionary<string, ShireInsertInfo>();
            ShireInsertInfo shireInsertInfo;
            string shireNo;
            string uriageDenpyoNo = string.Empty;
            int shireRowNo;
            int wkShireNo = kanriMaster.getShireNo();
            bool flgUpdShireNo = false;
            List<string> updShireNos = new List<string>();
            List<string> newShireNos = new List<string>();
            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
            {
                if (checkEmptyRow(i))
                {
                    break;
                }

                daiBunruiCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmTopClassificationCode.Name].Value);
                syoBunruiCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmbtmClassificationCode.Name].Value);
                shouhinCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemAndOpponentCode.Name].Value);
                shouhinName1 = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmItemName.Name].Value);
                shouhinName2 = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemName.Name].Value);
                juchuSuryo = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmOrdersQuantity.Name].Value);
                juchuNouhinZanSuryo = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmOrdersQuantity.Name].Value);
                juchuTani = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmUnit.Name].FormattedValue);
                juchuTanka = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmOrdersBidAndAmount.Name].Value);
                juchuKingaku = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmOrdersBidAndAmount.Name].Value);
                juchuNonyuKubun = commonLogic.getNouhinsyoType(Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmUnit.Name].FormattedValue));
                shiresakiCode = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmVendorCodeAndName.Name].Value);
                shiresakiName = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmVendorCodeAndName.Name].Value);
                shireBuzaiKubun = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchasePartsType.Name].Value);
                shireTanka = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmPurchaseBidAndAmount.Name].Value);
                shireKingaku = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchaseBidAndAmount.Name].Value);
                shireNouhinZanSuryo = Convert.ToString(grdOrdersDetails.Rows[i].Cells[clmPurchaseDeliveryQuantity.Name].Value);
                shireNouhinSuryo = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmPurchaseDeliveryQuantity.Name].Value);
                bikou = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmRemarks.Name].Value);
                rowNo = ((int)(i / grdOrdersDetails.RowSegmentCount) + 1);

                selectCommand = "SELECT sh.shireNo, sh.uriageDenpyoNo, sb.rowNo ";
                selectCommand += "FROM (SELECT * ";
                selectCommand += "      FROM shire_header ";
                selectCommand += "      WHERE kanriKubun <> '9' ";
                selectCommand += "      AND juchuNoTop = '" + juchuNoTop + "' ";
                selectCommand += "      AND juchuNoMid = '" + juchuNoMid + "' ";
                selectCommand += "      AND juchuNoBtm = '" + juchuNoBtm + "' ";
                selectCommand += "      AND shiresakiCode = '" + shiresakiCode + "' ";
                selectCommand += ") sh ";
                selectCommand += "INNER JOIN (SELECT * FROM shire_body WHERE kanriKubun <> '9') sb ";
                selectCommand += "ON (sh.shireNo = sb.shireNo) ";
                selectCommand += "WHERE sb.juchuRowNo = " + rowNo;
                selectRes = juchuDataSelectDb.executeSelect(selectCommand, true);
                if (selectRes != null && selectRes.Rows.Count > 0)
                {
                    // 同一行番号のデータが登録済みのため更新処理
                    sql = "UPDATE shire_body sb, " + " \r ";
                    sql += "(SELECT * FROM shire_header " + " \r ";
                    sql += " WHERE kanriKubun <> '9' " + " \r ";
                    sql += " AND juchuNoTop = '" + juchuNoTop + "' " + " \r ";
                    sql += " AND juchuNoMid = '" + juchuNoMid + "' " + " \r ";
                    sql += " AND juchuNoBtm = '" + juchuNoBtm + "' " + " \r ";
                    sql += ") sh " + " \r ";
                    sql += "SET sb.daiBunruiCode = '" + daiBunruiCode + "' " + " \r ";
                    sql += "  , sb.syoBunruiCode = '" + syoBunruiCode + "' " + " \r ";
                    sql += "  , sb.shouhinCode = '" + shouhinCode + "' " + " \r ";
                    sql += "  , sb.shouhinName1 = '"+ shouhinName1 + "' " + " \r ";
                    sql += "  , sb.shouhinName2 = '"+ shouhinName2 + "' " + " \r ";
                    sql += "  , sb.suryo = " + (string.IsNullOrEmpty(juchuSuryo) ? "NULL" : juchuSuryo.Replace(",", "")) + " " + " \r ";
                    sql += "  , sb.tani = '" + juchuTani + "' " + " \r ";
                    sql += "  , sb.tanka = " + (string.IsNullOrEmpty(shireTanka) ? "NULL" : shireTanka.Replace(",", "")) + " " + " \r ";
                    sql += "  , sb.kingaku = " + (string.IsNullOrEmpty(shireKingaku) ? "NULL" : shireKingaku.Replace(",", "")) + " " + " \r ";
                    sql += "  , sb.kousinNichizi = '" + registerDate + "' " + " \r ";
                    sql += "  , sb.kanriKubun = '" + Consts.KanriCodeTypes.TYPE0 + "' " + " \r ";
                    sql += "WHERE sb.shireNo = sh.shireNo " + " \r ";
                    sql += "AND sb.juchuRowNo = " + rowNo + " \r ";
                    sql += "AND sb.kanriKubun <> '9' " + " \r ";
                    shireNo = Convert.ToString(selectRes.Rows[0]["shireNo"]);
                    uriageDenpyoNo = Convert.ToString(selectRes.Rows[0]["uriageDenpyoNo"]);
                    shireRowNo = Convert.ToInt16(selectRes.Rows[0]["rowNo"]);
                    if (delKeys.ContainsKey(shireNo))
                    {
                        if (delKeys[shireNo] < shireRowNo)
                        {
                            delKeys[shireNo] = shireRowNo;
                        }
                    }
                    else
                    {
                        delKeys.Add(shireNo, shireRowNo);
                    }
                }
                else
                {
                    selectCommand = "SELECT sh.shireNo, MAX(IFNULL(rowNo, 0)) AS shireRowNo ";
                    selectCommand += "FROM (SELECT * FROM shire_header ";
                    selectCommand += "      WHERE kanriKubun <> 9 ";
                    selectCommand += "      AND juchuNoTop = '" + juchuNoTop + "' ";
                    selectCommand += "      AND juchuNoMid = '" + juchuNoMid + "' ";
                    selectCommand += "      AND juchuNoBtm = '" + juchuNoBtm + "' ";
                    selectCommand += "      AND shiresakiCode = '" + shiresakiCode + "' ";
                    selectCommand += "      AND uriageDenpyoNo = '" + uriageDenpyoNo + "' ";
                    selectCommand += ") sh ";
                    selectCommand += "LEFT JOIN (SELECT * FROM shire_body WHERE kanriKubun <> 9) sb ";
                    selectCommand += "ON (sh.shireNo = sb.shireNo) ";
                    selectCommand += "GROUP BY sh.shireNo ";
                    selectRes = juchuDataSelectDb.executeSelect(selectCommand, true);
                    // 同一行番号のデータが未登録のため登録処理
                    if (insertKeys.ContainsKey(shiresakiCode))
                    {
                        insertKeys[shiresakiCode].RowNo++;
                        shireNo = insertKeys[shiresakiCode].ShireNo;
                        shireRowNo = insertKeys[shiresakiCode].RowNo;
                    }
                    else if (selectRes.Rows.Count > 0)
                    {
                        shireNo = Convert.ToString(selectRes.Rows[0]["shireNo"]);
                        shireRowNo = Convert.ToInt16(selectRes.Rows[0]["shireRowNo"]) + 1;
                        shireInsertInfo = new ShireInsertInfo();
                        shireInsertInfo.ShireNo = shireNo;
                        shireInsertInfo.RowNo = shireRowNo;
                        shireInsertInfo.JuchuRowNo = rowNo;
                        insertKeys.Add(shiresakiCode, shireInsertInfo);
                    }
                    else
                    {
                        wkShireNo++;
                        shireNo = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkShireNo), 8);
                        shireRowNo = 1;
                        shireInsertInfo = new ShireInsertInfo();
                        shireInsertInfo.ShireNo = shireNo;
                        shireInsertInfo.RowNo = shireRowNo;
                        shireInsertInfo.JuchuRowNo = rowNo;
                        insertKeys.Add(shiresakiCode, shireInsertInfo);
                        sql = "INSERT INTO shire_header " + " \r ";
                        sql += "( " + " \r ";
                        sql += "  shireNo " + " \r ";
                        sql += ", denpyoHizuke " + " \r ";
                        sql += ", juchuNoTop " + " \r ";
                        sql += ", juchuNoMid " + " \r ";
                        sql += ", juchuNoBtm " + " \r ";
                        sql += ", chihouCode " + " \r ";
                        sql += ", chikuCode " + " \r ";
                        sql += ", tokuisakiCode " + " \r ";
                        sql += ", tokuisakiName " + " \r ";
                        sql += ", tokuisakiKanaName " + " \r ";
                        sql += ", jigyousyoCode " + " \r ";
                        sql += ", jigyousyoName " + " \r ";
                        sql += ", zipCode " + " \r ";
                        sql += ", addres1 " + " \r ";
                        sql += ", addres2 " + " \r ";
                        sql += ", tantousyaCode " + " \r ";
                        sql += ", tantousyaName " + " \r ";
                        sql += ", kenmeiNo " + " \r ";
                        sql += ", kenmei1 " + " \r ";
                        sql += ", kenmei2 " + " \r ";
                        sql += ", hachuNo " + " \r ";
                        sql += ", shiresakiCode " + " \r ";
                        sql += ", shiresakiName " + " \r ";
                        sql += ", uriageDenpyoNo " + " \r ";
                        sql += ", kousinNichizi " + " \r ";
                        sql += ", kanriKubun " + " \r ";
                        sql += ") " + " \r ";
                        sql += "VALUES " + " \r ";
                        sql += "( " + " \r ";
                        sql += "'" + shireNo + "' " + " \r ";
                        sql += ",'" + denpyoHizuke + "' " + " \r ";
                        sql += ",'" + juchuNoTop + "' " + " \r ";
                        sql += ",'" + juchuNoMid + "' " + " \r ";
                        sql += ",'" + juchuNoBtm + "' " + " \r ";
                        sql += ",'" + chihouCode + "' " + " \r ";
                        sql += ",'" + chikuCode + "' " + " \r ";
                        sql += ",'" + tokuisakiCode + "' " + " \r ";
                        sql += ",'" + tokuisakiName + "' " + " \r ";
                        sql += ",'" + tokuisakiKanaName + "' " + " \r ";
                        sql += ",'" + jigyousyoCode + "' " + " \r ";
                        sql += ",'" + jigyousyoName + "' " + " \r ";
                        sql += ",'" + zipCode + "' " + " \r ";
                        sql += ",'" + addres1 + "' " + " \r ";
                        sql += ",'" + addres2 + "' " + " \r ";
                        sql += ",'" + tantousyaCode + "' " + " \r ";
                        sql += ",'" + tantousyaName + "' " + " \r ";
                        sql += ",'" + kenmeiNo + "' " + " \r ";
                        sql += ",'" + kenmei1 + "' " + " \r ";
                        sql += ",'" + kenmei2 + "' " + " \r ";
                        sql += ",'' " + " \r ";
                        sql += ",'" + shiresakiCode + "' " + " \r ";
                        sql += ",'" + shiresakiName + "' " + " \r ";
                        sql += ",'" + uriageDenpyoNo + "' " + " \r ";
                        sql += "," + "'" + registerDate + "' " + " \r ";
                        sql += "," + "'' " + " \r ";
                        sql += ") " + " \r ";
                        sqlShire.Add(sql);
                        sql = "INSERT INTO shire_footer " + " \r ";
                        sql += "( " + " \r ";
                        sql += "  shireNo " + " \r ";
                        sql += ", kousinNichizi " + " \r ";
                        sql += ", kanriKubun " + " \r ";
                        sql += ") " + " \r ";
                        sql += "VALUES " + " \r ";
                        sql += "( " + " \r ";
                        sql += "'" + shireNo + "' " + " \r ";
                        sql += "," + "'" + registerDate + "' " + " \r ";
                        sql += "," + "'' " + " \r ";
                        sql += ") " + " \r ";
                        sqlShire.Add(sql);
                        flgUpdShireNo = true;
                        newShireNos.Add(shireNo);
                    }
                    sql = "INSERT INTO shire_body " + " \r ";
                    sql += "( " + " \r ";
                    sql += "  shireNo " + " \r ";
                    sql += ", rowNo " + " \r ";
                    sql += ", juchuRowNo " + " \r ";
                    sql += ", daiBunruiCode " + " \r ";
                    sql += ", syoBunruiCode " + " \r ";
                    sql += ", shouhinCode " + " \r ";
                    sql += ", shouhinName1 " + " \r ";
                    sql += ", shouhinName2 " + " \r ";
                    sql += ", suryo " + " \r ";
                    sql += ", tani " + " \r ";
                    sql += ", tanka " + " \r ";
                    sql += ", kingaku " + " \r ";
                    sql += ", bikou " + " \r ";
                    sql += ", shimeNengapi " + " \r ";
                    sql += ", shimeKoushinHuragu " + " \r ";
                    sql += ", kousinNichizi " + " \r ";
                    sql += ", kanriKubun " + " \r ";
                    sql += ") " + " \r ";
                    sql += "VALUES " + " \r ";
                    sql += "( " + " \r ";
                    sql += "'" + shireNo + "' " + " \r ";
                    sql += "," + shireRowNo + " " + " \r ";
                    sql += "," + rowNo + " " + " \r ";
                    sql += "," + "'" + daiBunruiCode + "' " + " \r ";
                    sql += "," + "'" + syoBunruiCode + "' " + " \r ";
                    sql += "," + "'" + shouhinCode + "' " + " \r ";
                    sql += "," + "'" + shouhinName1 + "' " + " \r ";
                    sql += "," + "'" + shouhinName2 + "' " + " \r ";
                    sql += "," + (string.IsNullOrEmpty(juchuSuryo) ? "null" : Convert.ToDecimal(juchuSuryo).ToString()) + " " + " \r ";
                    sql += "," + "'" + juchuTani + "' " + " \r ";
                    sql += "," + (string.IsNullOrEmpty(shireTanka) ? "null" : Convert.ToDecimal(shireTanka).ToString()) + " " + " \r ";
                    sql += "," + (string.IsNullOrEmpty(shireKingaku) ? "null" : Convert.ToDecimal(shireKingaku).ToString()) + " " + " \r ";
                    sql += "," + "'' " + " \r ";
                    sql += "," + "null " + " \r ";
                    sql += "," + "null " + " \r ";
                    sql += "," + "'" + registerDate + "' " + " \r ";
                    sql += "," + "'' " + " \r ";
                    sql += ") ";
                    if (delKeys.ContainsKey(shireNo))
                    {
                        if (delKeys[shireNo] < shireRowNo)
                        {
                            delKeys[shireNo] = shireRowNo;
                        }
                    }
                    else
                    {
                        delKeys.Add(shireNo, shireRowNo);
                    }
                }
                sqlShire.Add(sql);
                updShireNos.Add(shireNo);

                i++;
            }

            foreach (KeyValuePair<string, int> pair in delKeys)
            {
                // 今回登録以外のデータを削除
                sql = "DELETE FROM shire_body " + " \r ";
                sql += "WHERE shireNo = '" + pair.Key + "' " + " \r ";
                sql += "AND rowNo > " + pair.Value + " \r ";
                sqlShire.Add(sql);
            }

            if (flgUpdShireNo)
            {
                sql = "UPDATE kanri_master SET " + " \r ";
                sql += "  koumoku1 = '" + wkShireNo + "' " + " \r ";
                sql += ", kousinNichizi = '" + registerDate + "' " + " \r ";
                sql += "WHERE kanriCode = '" + Consts.KanriCodes.ShireNo + "' " + " \r ";
                sqlShire.Add(sql);
            }

            selectCommand = "SELECT shireNo ";
            selectCommand += "FROM shire_header ";
            selectCommand += "WHERE kanriKubun <> 9 ";
            selectCommand += "AND uriageDenpyoNo = '" + uriageDenpyoNo + "' ";
            foreach (string updShireNo in updShireNos)
            {
                selectCommand += "AND shireNo <> '" + updShireNo + "' ";
            }
            foreach (string newShireNo in newShireNos)
            {
                selectCommand += "AND shireNo <> '" + newShireNo + "' ";
            }
            selectRes = juchuDataSelectDb.executeSelect(selectCommand, true);

            foreach (DataRow row in selectRes.Rows)
            {
                // 今回登録以外のデータを削除
                sql = "DELETE FROM shire_header " + " \r ";
                sql += "WHERE shireNo = '" + Convert.ToString(row["shireNo"]) + "' " + " \r ";
                sqlShire.Add(sql);
                sql = "DELETE FROM shire_body " + " \r ";
                sql += "WHERE shireNo = '" + Convert.ToString(row["shireNo"]) + "' " + " \r ";
                sqlShire.Add(sql);
                sql = "DELETE FROM shire_footer " + " \r ";
                sql += "WHERE shireNo = '" + Convert.ToString(row["shireNo"]) + "' " + " \r ";
                sqlShire.Add(sql);
            }

            sql = "UPDATE shire_footer sf " + " \r ";
            sql += "     , (SELECT sh.shireNo " + " \r ";
            sql += "             , SUM(IFNULL(sb.kingaku, 0)) AS shireKingaku " + " \r ";
            sql += "        FROM (SELECT * FROM shire_header WHERE (kanriKubun IS NULL OR kanriKubun <> '9')) sh " + " \r ";
            sql += "        INNER JOIN (SELECT * FROM shire_body) sb " + " \r ";
            sql += "        ON (sh.shireNo = sb.shireNo) " + " \r ";
            sql += "        GROUP BY sh.shireNo " + " \r ";
            sql += ") sd " + " \r ";
            sql += "SET sf.shireKingaku = sd.shireKingaku " + " \r ";
            sql += "WHERE sf.shireNo = sd.shireNo " + " \r ";
            sqlShire.Add(sql);

            return sqlShire;
        }
        #endregion

        #region 担当者マスタ更新SQL生成処理
        /// <summary>
        /// 担当者マスタ更新SQL生成処理
        /// </summary>
        /// <param name="ordersNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createTantousyaMasterRegistSql(string ordersNo, DateTime registerDate)
        {
            string sql = string.Empty;
            int chumonNo = Convert.ToInt32(ordersNo.Substring(5, 10));

            sql = "UPDATE tantousya_master SET ";
            sql += "  chumonNo = " + chumonNo + " ";
            sql += ", kousinNichizi = '" + registerDate + "' ";
            sql += "WHERE tantousyaCode = '" + Program.loginUserInfo.UserId + "' ";

            return sql;
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
        private bool setJuchuData(string documentNo, string ordersNo, bool flgDocumentNoInput)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            string sqlHeaderCommand = string.Empty;
            string sqlBodyCommand = string.Empty;
            string sqlDetailsSumCommand = string.Empty;
            string sqlTotalSumCommand = string.Empty;

            // 伝票Noが空白でない場合
            if (!string.IsNullOrEmpty(documentNo))
            {
                // 伝票Noから受注ヘッダデータを取得
                sqlHeaderCommand += "SELECT * FROM juchu_header WHERE denpyoNo = '" + commonLogic.getZeroBuriedNumberText(documentNo, txtDocumentNo.MaxLength) + "' ";
            }
            else
            {
                // 受注Noから受注ヘッダデータを取得
                string wkSqlHeaderCommand = "SELECT * FROM juchu_header WHERE CONCAT(juchunoTop, juchunoMid, juchunoBtm) = '" + ordersNo + "' ";
                DataTable wkHeaderData = juchuDataSelectDb.executeSelect(wkSqlHeaderCommand, false);
                sqlHeaderCommand += "SELECT * FROM juchu_header WHERE denpyoNo = '" + Convert.ToString(wkHeaderData.Rows[0][DBFileLayout.JuchuHeaderFile.dcDenpyoNo]) + "' ";
            }

            // トランザクション開始処理を実行
            juchuDataSelectDb.startTransaction();
            DataTable headerData = juchuDataSelectDb.executeSelect(sqlHeaderCommand, !rdoNew.Checked);
            if (headerData != null && headerData.Rows.Count > 0 && (rdoCorrection.Checked || rdoDelete.Checked))
            {
                string wkJuchuNoTop = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
                string wkJuchuNoMid = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
                string wkJuchuNoBtm = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
                string nouhinshoExsitsCmmand = "SELECT 1 FROM uriage_header ";
                nouhinshoExsitsCmmand += "WHERE juchuNoTop = '" + wkJuchuNoTop + "' ";
                nouhinshoExsitsCmmand += "AND juchuNoMid = '" + wkJuchuNoMid + "' ";
                nouhinshoExsitsCmmand += "AND juchuNoBtm = '" + wkJuchuNoBtm + "' ";
                nouhinshoExsitsCmmand += "AND (kanriKubun IS NULL OR kanriKubun <> '9') ";
                DataTable nouhinshoExsitsDt = juchuDataSelectDb.executeSelect(nouhinshoExsitsCmmand, false);
                // 納品書出力済みフラグ設定
                flgNouhinsyoOutput = (nouhinshoExsitsDt != null && nouhinshoExsitsDt.Rows.Count > 0);
                if (flgNouhinsyoOutput && rdoDelete.Checked)
                {
                    messageOK(Messages.M0057);
                }
            }
            DataTable bodyData;
            DataTable detailsSumData;
            DataTable totalSumData;

            // 取得時にエラーが発生した場合
            if (juchuDataSelectDb.DBRef < 0)
            {
                errorOK(string.Format(Messages.M0027, "受注データ"));
                return false;
            }
            // 受注ヘッダデータが存在する場合
            if (headerData != null && headerData.Rows.Count > 0)
            {
                // 既に削除されている場合、エラーメッセージを出力して処理を終了
                if (Consts.KanriCodeTypes.TYPE9.Equals(Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcKanriKubun])))
                {
                    string msg1 = rdoCorrection.Checked ? "訂正" : rdoReference.Checked ? "参照" : "削除";
                    errorOK(string.Format(Messages.M0013, "削除", "受注データ", msg1));
                    if (flgDocumentNoInput)
                    {
                        txtDocumentNo.Text = string.Empty;
                    }
                    else
                    {
                        txtOrdersNo.Text = string.Empty;
                    }
                    return false;
                }
            }
            // 受注ヘッダデータが存在しない場合
            else
            {
                string messageText = flgDocumentNoInput ? txtDocumentNo.LabelControl.Text : txtOrdersNo.LabelControl.Text;
                // エラーメッセージを出力して処理を終了
                errorOK(string.Format(Messages.M0003, messageText));
                return false;
            }

            DataRow dRow = headerData.Rows[0];
            string juchuNoTop = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
            string juchuNoMid = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
            string juchuNoBtm = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            // 受注ボディデータおよび受注フッタデータを取得
            //sqlBodyCommand += "SELECT * FROM juchu_body ";
            //sqlBodyCommand += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            //sqlBodyCommand += "AND juchunoMid = '" + juchuNoMid + "' ";
            //sqlBodyCommand += "AND juchunoBtm = '" + juchuNoBtm + "' ";
            //sqlBodyCommand += "ORDER BY rowNo ";
            sqlBodyCommand += "SELECT jb.*, IFNULL(ud.count, 0) AS nouhinRowCount ";
            sqlBodyCommand += "FROM (SELECT * ";
            sqlBodyCommand += "      FROM juchu_body ";
            sqlBodyCommand += "      WHERE kanriKubun <> '9' ";
            sqlBodyCommand += "      AND juchuNoTop = '" + juchuNoTop + "' ";
            sqlBodyCommand += "      AND juchunoMid = '" + juchuNoMid + "' ";
            sqlBodyCommand += "      AND juchunoBtm = '" + juchuNoBtm + "') jb ";
            sqlBodyCommand += "LEFT JOIN (SELECT uh.juchuNoTop ";
            sqlBodyCommand += "                , uh.juchuNoMid ";
            sqlBodyCommand += "                , uh.juchuNoBtm ";
            sqlBodyCommand += "                , ub.juchuRowNo ";
            sqlBodyCommand += "                , 1 AS count ";
            sqlBodyCommand += "           FROM (SELECT * FROM uriage_header WHERE kanriKubun <> '9') uh ";
            sqlBodyCommand += "           INNER JOIN (SELECT * FROM uriage_body WHERE kanriKubun <> '9') ub ";
            sqlBodyCommand += "           ON (uh.denpyoNo = ub.denpyoNo) ";
            sqlBodyCommand += "           GROUP BY uh.juchuNoTop, uh.juchuNoMid, uh.juchuNoBtm, ub.juchuRowNo ";
            sqlBodyCommand += ") ud ";
            sqlBodyCommand += "ON (jb.juchuNoTop = ud.juchuNoTop AND jb.juchuNoMid = ud.juchuNoMid AND jb.juchuNoBtm = ud.juchuNoBtm AND jb.rowNo = ud.juchuRowNo) ";
            sqlDetailsSumCommand += "SELECT '" + detailsTotalTitle1 + "' AS ordersTotalTitle ";
            sqlDetailsSumCommand += "     , juchuKei AS ordersTotalAmount ";
            sqlDetailsSumCommand += "     , '" + detailsTotalTitle2 + "' AS vendorTotalTitle ";
            sqlDetailsSumCommand += "     , shireKei AS vendorTotalAmount ";
            sqlDetailsSumCommand += "FROM juchu_footer ";
            sqlDetailsSumCommand += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            sqlDetailsSumCommand += "AND juchunoMid = '" + juchuNoMid + "' ";
            sqlDetailsSumCommand += "AND juchunoBtm = '" + juchuNoBtm + "' ";
            sqlTotalSumCommand += "SELECT mekkiDai AS  sumClm1 ";
            sqlTotalSumCommand += "     , tosouDai AS  sumClm2 ";
            sqlTotalSumCommand += "     , unchin AS  sumClm3 ";
            sqlTotalSumCommand += "     , shireDai AS  sumClm4 ";
            sqlTotalSumCommand += "     , buzaiDai AS  sumClm5 ";
            sqlTotalSumCommand += "     , shireGoukei AS  sumClm6 ";
            sqlTotalSumCommand += "     , arariGaku AS  sumClm7 ";
            sqlTotalSumCommand += "     , arariRitu AS  sumClm8 ";
            sqlTotalSumCommand += "FROM juchu_footer ";
            sqlTotalSumCommand += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            sqlTotalSumCommand += "AND juchunoMid = '" + juchuNoMid + "' ";
            sqlTotalSumCommand += "AND juchunoBtm = '" + juchuNoBtm + "' ";
            bodyData = juchuDataSelectDb.executeSelect(sqlBodyCommand, false);
            detailsSumData = juchuDataSelectDb.executeSelect(sqlDetailsSumCommand, false);
            totalSumData = juchuDataSelectDb.executeSelect(sqlTotalSumCommand, false);

            // 取得した受注ヘッダデータを画面項目に設定します
            if (!rdoNew.Checked) txtDocumentNo.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcDenpyoNo]);
            dtpDocumentDate.Value = Convert.ToDateTime(dRow[DBFileLayout.JuchuHeaderFile.dcDenpyoHizuke]);
            if (!rdoNew.Checked) txtOrdersNo.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
            if (!rdoNew.Checked) txtOrdersNo.Text += Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
            if (!rdoNew.Checked) txtOrdersNo.Text += Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            cmbPersonnel.SelectedValue = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTantousyaCode]);
            cmbPublisher.SelectedValue = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcHakousyaCode]);
            txtEstimateNo.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcMitumoriNo]);
            txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiCode]);
            txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);
            txtCustomerKanaName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiKanaName]);
            setOfficesCmb(txtCustomerCode.Text, Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoCode]));
            txtCustomerPersonnel.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiTantousayName]);
            cmbMaterialsConstructionType.SelectedValue = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcZairyoKoujiKubun]);
            if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcSyukabi])))
            {
                txtShipDateYears.Text = string.Empty;
                txtShipDateMonth.Text = string.Empty;
                txtShipDateDays.Text = string.Empty;
            }
            else
            {
                try
                {
                    dtpShipDate.Value = Convert.ToDateTime(dRow[DBFileLayout.JuchuHeaderFile.dcSyukabi]);
                }
                catch
                {
                    txtShipDateYears.Text = string.Empty;
                    txtShipDateMonth.Text = string.Empty;
                    txtShipDateDays.Text = string.Empty;
                }
            }
            if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcTyakubi])))
            {
                txtOnTheDayYears.Text = string.Empty;
                txtOnTheDayMonth.Text = string.Empty;
                txtOnTheDayDays.Text = string.Empty;
            }
            else
            {
                try
                {
                    dtpOnTheDay.Value = Convert.ToDateTime(dRow[DBFileLayout.JuchuHeaderFile.dcTyakubi]);
                }
                catch
                {
                    txtOnTheDayYears.Text = string.Empty;
                    txtOnTheDayMonth.Text = string.Empty;
                    txtOnTheDayDays.Text = string.Empty;
                }
            }
            txtShippingFlights.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcSyukabin]);
            txtGuestNoteNumber.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcKyakusakiChuban]);
            txtConstructionNo.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcKenmeiNo]);
            txtSubject1.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcKenmei1]);
            txtSubject2.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcKenmei2]);
            txtDeliveredName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiName]);
            txtDeliveredDeploymentName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcBusyoName]);
            txtZipCode.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcZipCode]);
            txtAddress1.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcAddres1]);
            txtAddress2.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcAddres2]);
            txtContact1.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki1]);
            txtContact2.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki2]);
            txtDeliveredPersonnelName.Text = Convert.ToString(dRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName]);

            // 取得した受注ボディデータを受注明細グリッドに設定します
            grdOrdersDetails.Rows.Clear();
            int gridRowIndex = 0;
            string unitValue;
            string unitText;
            DataGridViewRow topRow;
            DataGridViewRow btmRow;
            // 単位コンボボックス設定
            setUnitCmb();
            DataTable unitDt = (DataTable)clmUnit.DataSource;
            for (int i = 0; i < bodyData.Rows.Count; i++)
            {
                gridRowIndex = i * grdOrdersDetails.RowSegmentCount;
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
                topRow = grdOrdersDetails.Rows[gridRowIndex];
                btmRow = grdOrdersDetails.Rows[gridRowIndex + 1];
                dRow = bodyData.Rows[i];

                // 上段行への値設定
                // 商品名(上段)
                topRow.Cells[clmItemName.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShouhinName1]);
                // 受注単価
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuTanka])))
                {
                    topRow.Cells[clmOrdersBidAndAmount.Name].Value = null;
                }
                else
                {
                    topRow.Cells[clmOrdersBidAndAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuTanka]).ToString(ordersBidFormat);
                }
                // 仕入先ｺｰﾄﾞ
                topRow.Cells[clmVendorCodeAndName.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShiresakiCode]);
                // 仕入単価
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShireTanka])))
                {
                    topRow.Cells[clmPurchaseBidAndAmount.Name].Value = null;
                }
                else
                {
                    topRow.Cells[clmPurchaseBidAndAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcShireTanka]).ToString(purchaseBidFormat);
                }
                // エラー状態
                topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;
                if (!rdoNew.Checked)
                {
                    topRow.Cells[clmNouhinRowCount.Name].Value = Convert.ToInt16(dRow["nouhinRowCount"]);
                }

                // 下段行への値設定
                // 商品ｺｰﾄﾞ
                btmRow.Cells[clmItemAndOpponentCode.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShouhinCode]);
                // 商品名(下段)
                btmRow.Cells[clmItemName.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShouhinName2]);
                // 受注数量
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuSuryo])))
                {
                    if (rdoNew.Checked) topRow.Cells[clmOrdersQuantity.Name].Value = null;
                    btmRow.Cells[clmOrdersQuantity.Name].Value = null;
                }
                else
                {
                    if (rdoNew.Checked) topRow.Cells[clmOrdersQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuSuryo]).ToString(ordersQuantityFormat);
                    btmRow.Cells[clmOrdersQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuSuryo]).ToString(ordersQuantityFormat);
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
                    unitValue = (unitDt.Rows.Count >= 9 ? string.Empty : "0") + Convert.ToString(unitDt.Rows.Count + 1);
                    unitDt.Rows.Add(new object[] { unitValue, unitText });
                    unitDt.AcceptChanges();
                }
                btmRow.Cells[clmUnit.Name].Value = unitValue;
                // 受注金額
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuKingaku])))
                {
                    btmRow.Cells[clmOrdersBidAndAmount.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmOrdersBidAndAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuKingaku]).ToString(ordersAmountFormat);
                }
                // 仕入先名
                btmRow.Cells[clmVendorCodeAndName.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShiresakiName]);
                // 仕入・部材
                btmRow.Cells[clmPurchasePartsType.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShireBuzaiKubun]);
                // 仕入金額
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShireKingaku])))
                {
                    btmRow.Cells[clmPurchaseBidAndAmount.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmPurchaseBidAndAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcShireKingaku]).ToString(purchaseAmountFormat);
                }
                // 仕入納品数量
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShireNouhinSuryo])))
                {
                    if (rdoNew.Checked) topRow.Cells[clmPurchaseDeliveryQuantity.Name].Value = null;
                    btmRow.Cells[clmPurchaseDeliveryQuantity.Name].Value = null;
                }
                else
                {
                    if (rdoNew.Checked) topRow.Cells[clmPurchaseDeliveryQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcShireNouhinSuryo]).ToString(ordersQuantityFormat);
                    btmRow.Cells[clmPurchaseDeliveryQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcShireNouhinSuryo]).ToString(ordersQuantityFormat);
                }
                // 受注納品数量
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcJuchuNouhinSuryo])) || rdoNew.Checked)
                {
                    btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.JuchuBodyFile.dcJuchuNouhinSuryo]).ToString(ordersQuantityFormat);
                }
                btmRow.Cells[clmRemarks.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcBikou]);
                btmRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;
                btmRow.Cells[clmTopClassificationCode.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcDaiBunruiCode]);
                btmRow.Cells[clmbtmClassificationCode.Name].Value = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcSyoBunruiCode]);
                if (!rdoNew.Checked)
                {
                    btmRow.Cells[clmNouhinRowCount.Name].Value = Convert.ToInt16(dRow["nouhinRowCount"]);
                }
                // 納品残数量の再計算処理実行
                recalcDeliveryResidualQuantity(gridRowIndex);
            }
            grdOrdersDetails.Refresh();
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 取得した受注ボディデータが初期表示件数未満の場合、不足データ分の空行を受注グリッドに追加します
            addInsufficientEmptyGridRow();
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();
            grdOrdersDetails.CurrentCell = null;

            // 取得した受注フッタデータを受注集計グリッドに設定します
            grdOrdersDetailsTotal.DataSource = detailsSumData;
            grdOrdersTotal.DataSource = totalSumData;

            // 検索実行済みフラグにtrueを設定
            flgSearch = true;

            // 納品書が出力済みの受注データを訂正する場合
            if (flgNouhinsyoOutput)
            {
                messageOK(Messages.M0028);
            }

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 見積データ設定処理
        /// <summary>
        /// 見積データ設定処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <returns></returns>
        private bool setMitumoriData(string mitumoriNo)
        {
            if (flgSearch) return false;
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            DBCommon dbCommon = new DBCommon();
            string sqlHeaderCommand = string.Empty;
            string sqlBodyCommand = string.Empty;

            // 見積Noから見積ヘッダデータを取得
            sqlHeaderCommand += "SELECT * FROM mitumori_header WHERE mitumoriNo = '" + mitumoriNo + "' ";
            DataTable headerData = dbCommon.executeNoneLockSelect(sqlHeaderCommand);
            // 見積ボディデータおよび見積フッタデータを取得
            sqlBodyCommand += "SELECT * FROM mitumori_body WHERE mitumoriNo = '" + mitumoriNo + "' ORDER BY rowNo ";
            DataTable bodyData = dbCommon.executeNoneLockSelect(sqlBodyCommand);

            DataRow dRow = headerData.Rows[0];

            inputModeChange(rdoNew);

            // 取得した見積ヘッダデータを画面項目に設定します
            txtEstimateNo.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcMitumoriNo]);
            cmbPersonnel.SelectedValue = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTantousyaCode]);
            cmbPublisher.SelectedValue = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTantousyaCode]);
            txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiCode]);
            setTokuisakiInfo(txtCustomerCode.Text, Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcJigyousyoCode]), true);
            if (Consts.OthersCustomerCode.Equals(txtCustomerCode.Text))
            {
                txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiName]);
                txtCustomerKanaName.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiKanaName]);
                cmbOffices.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcJigyousyoName]);
            }
            txtCustomerPersonnel.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcTokuisakiTantousayName]);
            txtSubject1.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcKenmei1]);
            txtSubject2.Text = Convert.ToString(dRow[DBFileLayout.MitumoriHeaderFile.dcKenmei2]);

            // 取得した見積ボディデータを受注明細グリッドに設定します
            grdOrdersDetails.Rows.Clear();
            int gridRowIndex = 0;
            string unitValue;
            string unitText;
            DataGridViewRow topRow;
            DataGridViewRow btmRow;
            string itemCode;
            // 単位コンボボックス設定
            setUnitCmb();
            DataTable unitDt = (DataTable)clmUnit.DataSource;
            for (int i = 0; i < bodyData.Rows.Count; i++)
            {
                gridRowIndex = i * grdOrdersDetails.RowSegmentCount;
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
                topRow = grdOrdersDetails.Rows[gridRowIndex];
                btmRow = grdOrdersDetails.Rows[gridRowIndex + 1];
                dRow = bodyData.Rows[i];
                itemCode = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcShouhinCode]);

                // 上段行への値設定
                // 受注単価
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcTanka])))
                {
                    topRow.Cells[clmOrdersBidAndAmount.Name].Value = null;
                }
                else
                {
                    topRow.Cells[clmOrdersBidAndAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.MitumoriBodyFile.dcTanka]).ToString(ordersBidFormat);
                }
                // エラー状態
                topRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                // 下段行への値設定
                // 商品ｺｰﾄﾞ
                btmRow.Cells[clmItemAndOpponentCode.Name].Value = itemCode;
                // 受注数量
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcSuryo])))
                {
                    btmRow.Cells[clmOrdersQuantity.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmOrdersQuantity.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.MitumoriBodyFile.dcSuryo]).ToString(ordersQuantityFormat);
                }
                // 単位
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
                btmRow.Cells[clmUnit.Name].Value = unitValue;
                // 受注金額
                if (string.IsNullOrEmpty(Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcKingaku])))
                {
                    btmRow.Cells[clmOrdersBidAndAmount.Name].Value = null;
                }
                else
                {
                    btmRow.Cells[clmOrdersBidAndAmount.Name].Value = Convert.ToDecimal(dRow[DBFileLayout.MitumoriBodyFile.dcKingaku]).ToString(ordersAmountFormat);
                }
                btmRow.Cells[clmRowStatus.Name].Value = GridErrorStatus.None;

                // 商品情報設定処理実行
                setShouhinInfo(gridRowIndex, string.Empty, string.Empty, string.Empty, itemCode);
                if (Consts.OthersItemCode.Equals(itemCode))
                {
                    // 商品名(上段)
                    topRow.Cells[clmItemName.Name].Value = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcShouhinName1]);
                }
                // 商品名(下段)
                btmRow.Cells[clmItemName.Name].Value = Convert.ToString(dRow[DBFileLayout.MitumoriBodyFile.dcShouhinName2]);

                // 納品残数量の再計算処理実行
                recalcDeliveryResidualQuantity(gridRowIndex);
            }
            grdOrdersDetails.Refresh();
            copyGridTopRow = null;
            copyGridBtmRow = null;

            // 見積した受注ボディデータが初期表示件数未満の場合、不足データ分の空行を受注グリッドに追加します
            addInsufficientEmptyGridRow();
            // 最終行が空行でない場合、行追加
            addLastEmptyRow();

            // 明細金額の集計処理を実行
            recalcDetailsTotal();
            // 受注金額の集計処理を実行
            recalcOrdersTotal();

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 受注グリッドへの空行追加処理
        /// <summary>
        /// 受注グリッドへの空行追加処理
        /// </summary>
        private void addEmptyGridRow()
        {
            insertEmptyGridRow(grdOrdersDetails.Rows.Count);
        }
        #endregion

        #region 受注グリッドへの空行挿入処理
        /// <summary>
        /// 受注グリッドへの空行挿入処理
        /// </summary>
        /// <param name="insertIndex"></param>
        private void insertEmptyGridRow(int insertIndex)
        {
            grdOrdersDetails.Rows.Insert(insertIndex);
            grdOrdersDetails.Rows[insertIndex].Cells[clmUnit.Name] = new DataGridViewTextBoxCell();
            grdOrdersDetails.Rows[insertIndex].Cells[clmPurchasePartsType.Name] = new DataGridViewTextBoxCell();
            grdOrdersDetails.Rows[insertIndex].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            grdOrdersDetails.Rows[insertIndex].Cells[clmNouhinRowCount.Name].Value = 0;
            grdOrdersDetails.Rows.Insert(insertIndex + 1);
            grdOrdersDetails.Rows[insertIndex + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
            grdOrdersDetails.Rows[insertIndex + 1].Cells[clmNouhinRowCount.Name].Value = 0;
        }
        #endregion

        #region 受注グリッドへの不足分行追加処理
        /// <summary>
        /// 受注グリッドへの不足分行追加処理
        /// </summary>
        private void addInsufficientEmptyGridRow()
        {
            // 取得した見積ボディデータが初期表示件数未満の場合、不足データ分の空行を受注グリッドに追加します
            for (int i = grdOrdersDetails.Rows.Count / grdOrdersDetails.RowSegmentCount; i < gridStartRowCount; i++)
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 受注グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// <summary>
        /// 受注グリッドの最終行が空白行でない場合、空白行を追加する処理
        /// </summary>
        private void addLastEmptyRow()
        {
            // 最終行が空行でない場合、行追加
            if (!checkEmptyRow(grdOrdersDetails.Rows.Count - 2))
            {
                // 受注グリッドへ空行を追加
                addEmptyGridRow();
            }
        }
        #endregion

        #region 納品状態取得処理
        /// <summary>
        /// 納品状態取得処理
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private string getDeliveryType(int rowIndex)
        {
            string ret = string.Empty;

            int topRowIndex = rowIndex % grdOrdersDetails.RowSegmentCount == 0 ? rowIndex : rowIndex - 1;
            int btmRowIndex = rowIndex % grdOrdersDetails.RowSegmentCount == 0 ? rowIndex + 1 : rowIndex;
            DataGridViewRow topRow = grdOrdersDetails.Rows[topRowIndex];
            DataGridViewRow btmRow = grdOrdersDetails.Rows[topRowIndex + 1];

            string itemCd = Convert.ToString(btmRow.Cells[clmItemAndOpponentCode.Name].Value);                  // 商品ｺｰﾄﾞ
            string itemNm1 = Convert.ToString(topRow.Cells[clmItemName.Name].Value);                            // 商品名(上段)
            string itemNm2 = Convert.ToString(btmRow.Cells[clmItemName.Name].Value);                            // 商品名(下段)
            string juchuSuryo = Convert.ToString(btmRow.Cells[clmOrdersQuantity.Name].Value);                   // 受注数量
            string nouhinZanSuryo = Convert.ToString(topRow.Cells[clmOrdersQuantity.Name].Value);               // 受注納品残数量
            string tani = Convert.ToString(btmRow.Cells[clmUnit.Name].Value);                                   // 単位
            string juchuTanka = Convert.ToString(topRow.Cells[clmOrdersBidAndAmount.Name].Value);               // 受注単価
            string juchuKingaku = Convert.ToString(btmRow.Cells[clmOrdersBidAndAmount.Name].Value);             // 受注金額
            string shireCode = Convert.ToString(topRow.Cells[clmVendorCodeAndName.Name].Value);                 // 仕入先ｺｰﾄﾞ
            string shireName = Convert.ToString(btmRow.Cells[clmVendorCodeAndName.Name].Value);                 // 仕入先名
            string shireBuzai = Convert.ToString(btmRow.Cells[clmPurchasePartsType.Name].Value);                // 仕入・部材
            string shireTanka = Convert.ToString(topRow.Cells[clmPurchaseBidAndAmount.Name].Value);             // 仕入単価
            string shireKingaku = Convert.ToString(btmRow.Cells[clmPurchaseBidAndAmount.Name].Value);           // 仕入金額
            string shireNouhinZanSuryo = Convert.ToString(topRow.Cells[clmPurchaseDeliveryQuantity.Name].Value);// 仕入先納品残
            string shireNouhinSuryo = Convert.ToString(btmRow.Cells[clmPurchaseDeliveryQuantity.Name].Value);   // 仕入先納品数
            string remarksText = Convert.ToString(btmRow.Cells[clmRemarks.Name].Value);                         // 備考

            // 全項目が未入力の場合
            if (string.IsNullOrEmpty(itemCd) &&
                string.IsNullOrEmpty(itemNm1) &&
                string.IsNullOrEmpty(itemNm2) &&
                string.IsNullOrEmpty(juchuSuryo) &&
                string.IsNullOrEmpty(nouhinZanSuryo) &&
                string.IsNullOrEmpty(tani) &&
                string.IsNullOrEmpty(juchuTanka) &&
                string.IsNullOrEmpty(juchuKingaku) &&
                string.IsNullOrEmpty(shireCode) &&
                string.IsNullOrEmpty(shireName) &&
                string.IsNullOrEmpty(shireBuzai) &&
                string.IsNullOrEmpty(shireTanka) &&
                string.IsNullOrEmpty(shireKingaku) &&
                string.IsNullOrEmpty(shireNouhinZanSuryo) &&
                string.IsNullOrEmpty(shireNouhinSuryo) &&
                string.IsNullOrEmpty(remarksText))
            {
            }
            else
            {
                decimal jSuryo;
                decimal nSuryo;
                string nouhinSuryo = Convert.ToString(btmRow.Cells[clmOrdersDeliveryQuantity.Name].Value);                  // 受注納品数量
                decimal.TryParse(juchuSuryo, out jSuryo);
                decimal.TryParse(nouhinSuryo, out nSuryo);
                if (jSuryo == decimal.Zero && nSuryo == decimal.Zero)
                {
                    ret = Consts.DeliveryType.NoneDeliveryText;
                }
                else if (jSuryo <= nSuryo)
                {
                    ret = Consts.DeliveryType.FinishDeliveryText;
                }
                else
                {
                    ret = Consts.DeliveryType.NoneDeliveryText;
                }
            }

            return ret;
        }
        #endregion

        #region 納品残数量の再計算処理
        /// <summary>
        /// 納品残数量の再計算処理
        /// </summary>
        private void recalcDeliveryResidualQuantity(int rowIndex)
        {
            int topRowIndex = rowIndex % grdOrdersDetails.RowSegmentCount == 0 ? rowIndex : rowIndex - 1;
            int btmRowIndex = topRowIndex + 1;
            string strJuchuNouhinSuryo = Convert.ToString(grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersDeliveryQuantity.Name].Value);
            string strJuchuSuryo = Convert.ToString(grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersQuantity.Name].Value);
            string strShireNouhinSuryo = Convert.ToString(grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value);
            decimal juchuNouhinSuryo;
            decimal juchuSuryo;
            decimal shireNouhinSuryo;
            decimal.TryParse(strJuchuNouhinSuryo, out juchuNouhinSuryo);
            decimal.TryParse(strJuchuSuryo, out juchuSuryo);
            decimal.TryParse(strShireNouhinSuryo, out shireNouhinSuryo);
            string strJuchuNouhinZanSuryo = string.Empty;
            string strShireNouhinZanSuryo = string.Empty;
            decimal juchuNouhinZanSuryo = decimal.Zero;
            decimal shireNouhinZanSuryo = decimal.Zero;

            // 受注数量が空白でない かつ
            // 受注納品数量が空白でない場合
            if (!string.IsNullOrEmpty(strJuchuSuryo) ||
                !string.IsNullOrEmpty(strJuchuNouhinSuryo))
            {
                // 受注数量 - 受注納品数量
                juchuNouhinZanSuryo = juchuSuryo - juchuNouhinSuryo;
                strJuchuNouhinZanSuryo = juchuNouhinZanSuryo.ToString(ordersQuantityFormat);
            }
            // 受注数量が空白でない かつ
            // 仕入先納品数量が空白でない場合
            if (!string.IsNullOrEmpty(strJuchuSuryo) ||
                !string.IsNullOrEmpty(strShireNouhinSuryo))
            {
                // 受注数量 - 仕入先納品数量
                shireNouhinZanSuryo = juchuSuryo - shireNouhinSuryo;
                strShireNouhinZanSuryo = shireNouhinZanSuryo.ToString(purchaseDeliveryQuantityFormat);
            }

            // 画面出力用受注納品残数量が空白の場合
            if (string.IsNullOrEmpty(strJuchuNouhinZanSuryo))
            {
                grdOrdersDetails.Rows[topRowIndex].Cells[clmOrdersQuantity.Name].Value = null;
            }
            else
            {
                grdOrdersDetails.Rows[topRowIndex].Cells[clmOrdersQuantity.Name].Value = strJuchuNouhinZanSuryo;
            }
            // 画面出力用仕入先納品残数量が空白の場合
            if (string.IsNullOrEmpty(strShireNouhinZanSuryo))
            {
                grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value = null;
            }
            else
            {
                grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value = strShireNouhinZanSuryo;
            }
        }
        #endregion

        #region 受注グリッドの中間空白行存在チェック処理
        /// <summary>
        /// 受注グリッドの中間空白行存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkMiddleEmptyRowExist()
        {
            bool flgEmptyRow = false;
            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
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

        #region 受注グリッドの中間空白行削除処理
        /// <summary>
        /// 受注グリッドの中間空白行削除処理
        /// </summary>
        private void deleteAllEmptyRow()
        {
            int delRowCnt = 0;
            for (int i = grdOrdersDetails.Rows.Count - 1; i >= 0; i--)
            {
                if (checkEmptyRow(i - 1))
                {
                    grdOrdersDetails.Rows.Remove(grdOrdersDetails.Rows[i]);
                    grdOrdersDetails.Rows.Remove(grdOrdersDetails.Rows[i - 1]);
                    delRowCnt += grdOrdersDetails.RowSegmentCount;
                }
                i--;
            }

            // 受注ボディデータが初期表示件数未満の場合、不足データ分の空行を見積グリッドに追加します
            addInsufficientEmptyGridRow();

            // 最終行が空行でない場合、行追加
            addLastEmptyRow();
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
            bool flgHeadError = false;

            if (string.IsNullOrEmpty(txtDocumentDateYears.Text) ||
                string.IsNullOrEmpty(txtDocumentDateMonth.Text) ||
                string.IsNullOrEmpty(txtDocumentDateDays.Text))
            {
                errorItem = lblDocumentDate.Text;
            }
            else if (string.IsNullOrEmpty(cmbPersonnel.Text))
            {
                errorItem = lblPersonnel.Text;
            }
            else if (string.IsNullOrEmpty(cmbPublisher.Text))
            {
                errorItem = lblPublisher.Text;
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
            else if (string.IsNullOrEmpty(cmbMaterialsConstructionType.Text))
            {
                errorItem = lblMaterialsConstructionType.Text;
            }

            if (!string.IsNullOrEmpty(errorItem)) flgHeadError = true;

            //TODO
            string itemCode;
            for (int i = 0; i < grdOrdersDetails.Rows.Count; i++)
            {
                if (i % grdOrdersDetails.RowSegmentCount != 0) continue;

                // エラーステータスを初期化
                grdOrdersDetails.Rows[i].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();
                grdOrdersDetails.Rows[i + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.None.GetHashCode();

                // ヘッダ項目でエラーが発生している場合
                if (flgHeadError) continue;

                // 空白行はチェック対象外
                if (checkEmptyRow(i)) continue;

                itemCode = Convert.ToString(grdOrdersDetails.Rows[i + 1].Cells[clmItemAndOpponentCode.Name].Value);
                if (string.IsNullOrEmpty(itemCode))
                {
                    grdOrdersDetails.Rows[i].Cells[clmRowStatus.Name].Value = GridErrorStatus.ItemCodeError.GetHashCode();
                    grdOrdersDetails.Rows[i + 1].Cells[clmRowStatus.Name].Value = GridErrorStatus.ItemCodeError.GetHashCode();
                    errorItem = clmItemAndOpponentCode.HeaderText + "、" + clmItemName.HeaderText;
                }
            }
            grdOrdersDetails.Refresh();

            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 納入先情報設定処理
        /// <summary>
        /// 納入先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        /// <param name="kenmeiNo"></param>
        /// <param name="flgUnconditional"></param>
        /// <param name="flgKenmeiSet"></param>
        /// <returns></returns>
        private bool setNonyuSakiInfo(string tokuisakiCode, string jigyousyoCode, string kenmeiNo, bool flgUnconditional, bool flgKenmeiSet)
        {
            string kenmei1 = string.Empty;
            string kenmei2 = string.Empty;
            string nonyusakiName = string.Empty;
            string busyoName = string.Empty;
            string renrakusaki1 = string.Empty;
            string renrakusaki2 = string.Empty;
            string zipCode = string.Empty;
            string address1 = string.Empty;
            string address2 = string.Empty;
            if (string.IsNullOrEmpty(kenmeiNo))
            {
                DBTokuisakiMaster tokuisakiMaster = new DBTokuisakiMaster();
                List< DBFileLayout.TokuisakiMasterFile> tokuisakiInfo = tokuisakiMaster.getTokuisakiInfo(tokuisakiCode, jigyousyoCode);
                if (tokuisakiInfo.Count > 0)
                {
                    nonyusakiName = tokuisakiInfo[0].TokuisakiName;
                    busyoName = tokuisakiInfo[0].JigyousyoName;
                    zipCode = tokuisakiInfo[0].ZipCode;
                    address1 = tokuisakiInfo[0].Address1;
                    address2 = tokuisakiInfo[0].Address2;
                    renrakusaki1 = tokuisakiInfo[0].Renrakusaki1;
                    renrakusaki2 = tokuisakiInfo[0].Renrakusaki2;
                }
            }
            else
            {
                DBKenmeiMaster kenmeiMaster = new DBKenmeiMaster();
                List< DBFileLayout.KenmeiMasterFile> kenmeiInfo = kenmeiMaster.getKenmeiInfo(kenmeiNo, false);
                if (kenmeiInfo.Count > 0)
                {
                    if (flgKenmeiSet)
                    {
                        kenmeiNo = kenmeiInfo[0].KenmeiNo;
                        kenmei1 = kenmeiInfo[0].Kenmei1;
                        kenmei2 = kenmeiInfo[0].Kenmei2;
                    }
                    nonyusakiName = kenmeiInfo[0].NonyusakiName;
                    busyoName = kenmeiInfo[0].BusyoName;
                    zipCode = kenmeiInfo[0].ZipCode;
                    address1 = kenmeiInfo[0].Address1;
                    address2 = kenmeiInfo[0].Address2;
                    renrakusaki1 = kenmeiInfo[0].Renrakusaki1;
                    renrakusaki2 = kenmeiInfo[0].Renrakusaki2;
                }
                else
                {
                    errorOK(string.Format(Messages.M0003, "件名No"));
                    txtConstructionNo.Focus();
                    return false;
                }
            }
            if (flgUnconditional || txtConstructionNo.BeforeValue != kenmeiNo)
            {
                if (flgKenmeiSet)
                {
                    txtConstructionNo.Text = kenmeiNo;
                    txtSubject1.Text = kenmei1;
                    txtSubject2.Text = kenmei2;
                }
                txtDeliveredName.Text = nonyusakiName;
                txtDeliveredDeploymentName.Text = busyoName;
                txtZipCode.Text = zipCode;
                txtAddress1.Text = address1;
                txtAddress2.Text = address2;
                txtContact1.Text = renrakusaki1;
                txtContact2.Text = renrakusaki2;
            }
            return true;
        }
        #endregion

        #region 発注情報の更新処理
        /// <summary>
        /// 発注情報の更新処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="hachuRegistSql"></param>
        /// <returns></returns>
        private int hachuRegist(string juchuNo, Dictionary<string, HachuRegistSqlClass> hachuRegistSql)
        {
            int ret = 0;

            if (hachuRegistSql.ContainsKey(strAllDelete))
            {
                // 発注ヘッダの削除処理実行
                if (juchuDataSelectDb.executeDBUpdate(hachuRegistSql[strAllDelete].HeaderSql) != 0)
                {
                    return -1;
                }
                // 発注ボディの削除処理実行
                if (juchuDataSelectDb.executeDBUpdate(hachuRegistSql[strAllDelete].BodySql[0]) != 0)
                {
                    return -2;
                }
                // 発注フッタの削除処理実行
                if (juchuDataSelectDb.executeDBUpdate(hachuRegistSql[strAllDelete].FooterSql) != 0)
                {
                    return -3;
                }
            }
            else
            {
                // 発注情報の削除処理実行
                string juchuNoTop = string.Empty;
                string juchuNoMid = string.Empty;
                string juchuNoBtm = string.Empty;
                commonLogic.SubStringJuchuNo(juchuNo, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
                string deleteHeaderSql = "DELETE FROM hachu_header ";
                deleteHeaderSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                deleteHeaderSql += "AND juchuNoMid = '" + juchuNoMid + "' ";
                deleteHeaderSql += "AND juchuNoBtm = '" + juchuNoBtm + "' ";
                string deleteBodySql = "DELETE FROM hachu_body ";
                deleteBodySql += "      WHERE hachuNo IN (SELECT hachuNo FROM hachu_header";
                deleteBodySql += "                        WHERE juchuNoTop = '" + juchuNoTop + "' ";
                deleteBodySql += "                        AND juchuNoMid = '" + juchuNoMid + "' ";
                deleteBodySql += "                        AND juchuNoBtm = '" + juchuNoBtm + "') ";
                string deleteFooterSql = "DELETE FROM hachu_footer ";
                deleteFooterSql += "      WHERE hachuNo IN (SELECT hachuNo FROM hachu_header";
                deleteFooterSql += "                        WHERE juchuNoTop = '" + juchuNoTop + "' ";
                deleteFooterSql += "                        AND juchuNoMid = '" + juchuNoMid + "' ";
                deleteFooterSql += "                        AND juchuNoBtm = '" + juchuNoBtm + "') ";
                // 発注フッタの削除処理実行
                juchuDataSelectDb.executeDBUpdate(deleteFooterSql);
                // 発注ボディの削除処理実行
                juchuDataSelectDb.executeDBUpdate(deleteBodySql);
                // 発注ヘッダの削除処理実行
                juchuDataSelectDb.executeDBUpdate(deleteHeaderSql);

                foreach (KeyValuePair<string, HachuRegistSqlClass> pair in hachuRegistSql)
                {
                    // 発注ヘッダ更新処理実行
                    if (juchuDataSelectDb.executeDBUpdate(pair.Value.HeaderSql) != 0)
                    {
                        ret = -1;
                        break;
                    }

                    // 発注ボディ更新処理実行
                    foreach (string bodySql in pair.Value.BodySql)
                    {
                        if (juchuDataSelectDb.executeDBUpdate(bodySql) != 0)
                        {
                            ret = -2;
                            break;
                        }
                    }
                    if (ret != 0) break;

                    // 発注フッタ更新処理実行
                    if (juchuDataSelectDb.executeDBUpdate(pair.Value.FooterSql) != 0)
                    {
                        ret = -3;
                        break;
                    }
                }
            }

            return ret;
        }
        #endregion

        #region グリッド行の初期化処理
        /// <summary>
        /// グリッド行の初期化処理
        /// </summary>
        /// <param name="gridRowIndex"></param>
        private void clearGridRow(int gridRowIndex)
        {
            int topRowIndex = gridRowIndex % grdOrdersDetails.RowSegmentCount == 0 ? gridRowIndex : gridRowIndex - 1;
            int btmRowIndex = topRowIndex + 1;

            // 上段行の初期化
            grdOrdersDetails.Rows[topRowIndex].Cells[clmItemName.Name].Value = string.Empty;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmOrdersQuantity.Name].Value = null;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = null;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmUnit.Name].Value = string.Empty;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmVendorCodeAndName.Name].Value = string.Empty;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = null;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value = null;

            // 下段行の初期化
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmTopClassificationCode.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmbtmClassificationCode.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmItemAndOpponentCode.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmItemName.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersQuantity.Name].Value = null;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmUnit.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmOrdersBidAndAmount.Name].Value = null;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmVendorCodeAndName.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchasePartsType.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = null;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value = null;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmRemarks.Name].Value = string.Empty;
        }
        #endregion

        #region グリッド行の初期化処理
        /// <summary>
        /// グリッド行の初期化処理
        /// </summary>
        /// <param name="gridRowIndex"></param>
        private void clearGridRow2(int gridRowIndex)
        {
            int topRowIndex = gridRowIndex % grdOrdersDetails.RowSegmentCount == 0 ? gridRowIndex : gridRowIndex - 1;
            int btmRowIndex = topRowIndex + 1;

            // 上段行の初期化
            grdOrdersDetails.Rows[topRowIndex].Cells[clmVendorCodeAndName.Name].Value = string.Empty;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = null;
            grdOrdersDetails.Rows[topRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value = null;

            // 下段行の初期化
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmVendorCodeAndName.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchasePartsType.Name].Value = string.Empty;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseBidAndAmount.Name].Value = null;
            grdOrdersDetails.Rows[btmRowIndex].Cells[clmPurchaseDeliveryQuantity.Name].Value = null;
        }
        #endregion

        #region 発注番号採番処理
        /// <summary>
        /// 発注番号採番処理
        /// </summary>
        private void updateHachuNo()
        {
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            string lockSql = "SELECT * FROM juchu_header WHERE denpyoNo = '" + printDocumentNo + "' ";
            if (rdoNew.Checked)
            {
                // トランザクション開始処理を実行
                juchuDataSelectDb.startTransaction();
                DataTable headerData = juchuDataSelectDb.executeSelect(lockSql, !rdoNew.Checked);
                DataRow dRow = headerData.Rows[0];
                juchuNoTop = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
                juchuNoMid = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
                juchuNoBtm = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            }
            else
            {
                commonLogic.SubStringJuchuNo(txtOrdersNo.Text, ref juchuNoTop, ref juchuNoMid, ref juchuNoBtm);
            }
            string selectSql = "SELECT * FROM juchu_body ";
            selectSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            selectSql += "AND juchunoMid = '" + juchuNoMid + "' ";
            selectSql += "AND juchunoBtm = '" + juchuNoBtm + "' ";
            selectSql += "AND (shireHachuNo IS NULL OR shireHachuNo = '') ";
            selectSql += "ORDER BY IFNULL(shiresakiCode, '') ";
            DataTable updateTarget = juchuDataSelectDb.executeSelect(selectSql, !rdoNew.Checked);

            string updateSql;
            List<string> updateSqls = new List<string>();
            string wkShiresakiCode;
            string wkHachuNo;
            Dictionary<string, string> dicHachuNos = new Dictionary<string, string>();
            DataTable hachuNoDt;
            int hachuNo = kanriMaster.getHachuNo();
            bool setNewHachuNo = false;
            int result = 0;
            foreach (DataRow dRow in updateTarget.Rows)
            {
                wkShiresakiCode = Convert.ToString(dRow[DBFileLayout.JuchuBodyFile.dcShiresakiCode]);
                if (!dicHachuNos.ContainsKey(wkShiresakiCode))
                {
                    selectSql = string.Empty;
                    selectSql += "SELECT * FROM juchu_body ";
                    selectSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                    selectSql += "AND juchunoMid = '" + juchuNoMid + "' ";
                    selectSql += "AND juchunoBtm = '" + juchuNoBtm + "' ";
                    selectSql += "AND (shireHachuNo IS NOT NULL AND shireHachuNo <> '') ";
                    selectSql += "AND shiresakiCode = '" + wkShiresakiCode + "' ";
                    hachuNoDt = juchuDataSelectDb.executeSelect(selectSql, !rdoNew.Checked);
                    if (hachuNoDt == null || hachuNoDt.Rows.Count == 0)
                    {
                        hachuNo++;
                        wkHachuNo = commonLogic.getZeroBuriedNumberText(hachuNo.ToString(), txtDocumentNo.MaxLength);
                        setNewHachuNo = true;
                    }
                    else
                    {
                        wkHachuNo = Convert.ToString(hachuNoDt.Rows[0][DBFileLayout.JuchuBodyFile.dcShireHachuNo]);
                    }
                    dicHachuNos.Add(wkShiresakiCode, wkHachuNo);
                }

                updateSql = string.Empty;
                updateSql += "UPDATE juchu_body ";
                updateSql += "SET shireHachuNo = '" + dicHachuNos[wkShiresakiCode] + "' ";
                updateSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                updateSql += "AND juchunoMid = '" + juchuNoMid + "' ";
                updateSql += "AND juchunoBtm = '" + juchuNoBtm + "' ";
                updateSql += "AND rowNo = " + Convert.ToInt16(dRow[DBFileLayout.JuchuBodyFile.dcRowNo]) + " ";
                result = juchuDataSelectDb.executeDBUpdate(updateSql);
                if (result < 0) break;
            }

            if (result == 0 && setNewHachuNo)
            {
                updateSql = string.Empty;
                updateSql = "UPDATE kanri_master SET ";
                updateSql += "  koumoku1 = '" + hachuNo + "' ";
                updateSql += ", kousinNichizi = '" + DateTime.Now + "' ";
                updateSql += "WHERE kanriCode = '" + Consts.KanriCodes.HachuNo + "' ";
                result = juchuDataSelectDb.executeDBUpdate(updateSql);
            }

            juchuDataSelectDb.endTransaction();

            if (!rdoNew.Checked)
            {
                // トランザクション開始処理を実行
                juchuDataSelectDb.startTransaction();
                juchuDataSelectDb.executeSelect(lockSql, !rdoNew.Checked);
            }

        }
        #endregion

        #region 発注枝番号更新処理
        /// <summary>
        /// 発注枝番号更新処理
        /// </summary>
        private List<string> updateHachuEdaban(string documentNo)
        {
            List<string> command = new List<string>();
            string juchuNoTop = string.Empty;
            string juchuNoMid = string.Empty;
            string juchuNoBtm = string.Empty;
            string headSql = "SELECT * FROM juchu_header WHERE denpyoNo = '" + documentNo + "' ";
            // トランザクション開始処理を実行
            DataTable headerData = juchuDataSelectDb.executeLockSelect(headSql);
            juchuNoTop = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
            juchuNoMid = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
            juchuNoBtm = Convert.ToString(headerData.Rows[0][DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            string selectSql = "SELECT *, IFNULL(shiresakiCode, '') AS fmShiresakiCode FROM juchu_body ";
            selectSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
            selectSql += "AND juchunoMid = '" + juchuNoMid + "' ";
            selectSql += "AND juchunoBtm = '" + juchuNoBtm + "' ";
            selectSql += "ORDER BY IFNULL(shiresakiCode, '') ";
            DataTable updateTarget = juchuDataSelectDb.executeLockSelect(selectSql);
            // 取得データの仕入れ先件数をカウント
            var query = updateTarget.AsEnumerable().GroupBy(p => p.Field<string>("fmShiresakiCode"));

            string updateSql;
            // 仕入先が1社以下の場合、枝番をクリアする
            if (query.Count() <= 1)
            {
                updateSql = string.Empty;
                updateSql += "UPDATE juchu_body ";
                updateSql += "SET hachusyoEdaban = NULL ";
                updateSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                updateSql += "AND juchunoMid = '" + juchuNoMid + "' ";
                updateSql += "AND juchunoBtm = '" + juchuNoBtm + "' ";
                command.Add(updateSql);
            }
            else
            {
                string shiresakiCode = "Dummy";
                int edaBan = 0;
                int rowCount = 0;
                foreach (DataRow targetRow in updateTarget.Rows)
                {
                    if (!shiresakiCode.Equals(Convert.ToString(targetRow[DBFileLayout.JuchuBodyFile.dcShiresakiCode])))
                    {
                        edaBan++;
                        rowCount = 0;
                        shiresakiCode = Convert.ToString(targetRow[DBFileLayout.JuchuBodyFile.dcShiresakiCode]);
                    }
                    rowCount++;
                    updateSql = string.Empty;
                    updateSql += "UPDATE juchu_body ";
                    updateSql += "SET hachusyoEdaban = '" + edaBan + "' ";
                    updateSql += "WHERE juchuNoTop = '" + juchuNoTop + "' ";
                    updateSql += "AND juchunoMid = '" + juchuNoMid + "' ";
                    updateSql += "AND juchunoBtm = '" + juchuNoBtm + "' ";
                    updateSql += "AND rowNo = " + Convert.ToInt16(targetRow[DBFileLayout.JuchuBodyFile.dcRowNo]) + " ";
                    command.Add(updateSql);
                }
            }
            return command;

        }
        #endregion

        #endregion
    }
}
