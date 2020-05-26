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
using DB;
using Resorce;
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;

namespace PrintInstructions
{
    /// <summary>
    /// 物品購入書・発注書出力画面
    /// </summary>
    public partial class frmBupinHachusyo : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        private CommonLogic commonLogic;
        private string documentNo = string.Empty;
        private bool flgClose = true;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="jNo"></param>
        public frmBupinHachusyo(string dNo, bool fClose)
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            commonLogic = new CommonLogic();
            DialogResult = DialogResult.None;
            documentNo = dNo;
            flgClose = fClose;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
            // 仕入先コンボボックス生成処理実行
            setVendorCombo();
        }
        #endregion

        #region プレビューボタン押下処理
        /// <summary>
        /// プレビューボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            executePrint(PrintType.Preview);
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
            executePrint(PrintType.OutPut);
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
            closedForm();
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
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
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
                    break;
                // F3キーが押下された場合
                case Keys.F3:
                    // TODO:プレビュー処理を実行
                    btnPreview_Click(null, null);
                    break;
                // F4キーが押下された場合
                case Keys.F4:
                    // TODO:印刷処理を実行
                    btnPrint_Click(null, null);
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

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJyuchachuIchiran_Load(object sender, EventArgs e)
        {
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

        #region 印刷対象ラジオボタン押下イベント
        /// <summary>
        /// 印刷対象ラジオボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoPrintTarget_Click(object sender, EventArgs e)
        {
            if (rdoBuppin.Checked)
            {
                pnlProcessingMode.Enabled = false;
            }
            else
            {
                pnlProcessingMode.Enabled = true;
                if (rdoSelectVendor.Checked)
                {
                    cmbVenbor.Enabled = true;
                }
                else
                {
                    cmbVenbor.Enabled = false;
                }
            }
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

            // フォーカスインイベントを追加
            c.Enter += new EventHandler(inputObject_Enter);

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

        #region 物品購入書出力データ取得処理
        /// <summary>
        /// 物品購入書出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblBuppin createBupinPrintData()
        {
            dtblBuppin buppinIchiran = new dtblBuppin();

            DBCommon selectDb = new DBCommon();
            string headCommand = string.Empty;
            string bodyCommand = string.Empty;
            string footerCommand = string.Empty;
            DataTable selectHeadDt;
            DataTable selectBodyDt;
            DataTable selectFooterDt;
            DataTable printHeadDt = buppinIchiran.Tables["dtblBuppinHeader"].Clone();
            DataTable printBodyDt = buppinIchiran.Tables["dtblBuppinBody"].Clone();
            DataTable printFooterDt = buppinIchiran.Tables["dtblBuppinF"].Clone();

            #region 受注ヘッダデータ取得
            headCommand += "SELECT jh.denpyoHizuke " + "\r";
            headCommand += "     , jh.tokuisakiCode " + "\r";
            headCommand += "     , jh.tokuisakiName " + "\r";
            headCommand += "     , jh.jigyousyoName " + "\r";
            headCommand += "     , mm2.kubunName AS shimebi " + "\r";
            headCommand += "     , mm.kubunName " + "\r";
            headCommand += "     , jh.tantousyaName " + "\r";
            headCommand += "     , jh.hakousyaName " + "\r";
            headCommand += "     , jh.denpyoNo " + "\r";
            headCommand += "     , jh.kenmei1 " + "\r";
            headCommand += "     , jh.kenmei2 " + "\r";
            headCommand += "     , jh.juchuNoTop " + "\r";
            headCommand += "     , jh.juchuNoMid " + "\r";
            headCommand += "     , jh.juchuNoBtm " + "\r";
            headCommand += "     , DATE_FORMAT(jh.syukabi, '%Y年%c月%e日') AS syukabi " + "\r";
            headCommand += "     , DATE_FORMAT(jh.tyakubi, '%Y年%c月%e日') AS tyakubi " + "\r";
            headCommand += "     , jh.syukabin " + "\r";
            headCommand += "     , jh.kyakusakiChuban " + "\r";
            headCommand += "     , jh.nounyusakiName " + "\r";
            headCommand += "     , jh.zipCode " + "\r";
            headCommand += "     , jh.addres1 " + "\r";
            headCommand += "     , jh.addres2 " + "\r";
            headCommand += "     , jh.renrakusaki1 " + "\r";
            headCommand += "     , jh.renrakusaki2 " + "\r";
            headCommand += "     , jh.nounyusakiTantousyaName " + "\r";
            headCommand += "FROM (SELECT * FROM juchu_header WHERE (kanriKubun IS NULL OR kanriKubun != '9') AND denpyoNo = '" + documentNo + "') jh " + "\r";
            headCommand += "LEFT JOIN (SELECT * FROM tokuisaki_master WHERE(kanriKubun IS NULL OR kanriKubun != '9')) tm " + "\r";
            headCommand += "ON (jh.tokuisakiCode = tm.tokuisakiCode AND jh.jigyousyoCode = tm.jigyousyoCode) " + "\r";
            headCommand += "LEFT JOIN (SELECT * FROM meisyo_master WHERE(kanriKubun IS NULL OR kanriKubun != '9') AND meisyoCode = '001') mm " + "\r";
            headCommand += "ON (jh.zairyoKoujiKubun = mm.kubun) " + "\r";
            headCommand += "LEFT JOIN (SELECT * FROM meisyo_master WHERE(kanriKubun IS NULL OR kanriKubun != '9') AND meisyoCode = '006') mm2 " + "\r";
            headCommand += "ON (tm.shimebi = mm2.kubun) " + "\r";
            selectHeadDt = selectDb.executeNoneLockSelect(headCommand);
            #endregion

            #region 受注ボディデータ取得
            bodyCommand += "SELECT * ";
            bodyCommand += "FROM juchu_body ";
            bodyCommand += "WHERE CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = ( ";
            bodyCommand += "                                                     SELECT CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) ";
            bodyCommand += "                                                     FROM juchu_header ";
            bodyCommand += "                                                     WHERE(kanriKubun IS NULL OR kanriKubun != '9') ";
            bodyCommand += "                                                     AND denpyoNo = '" + documentNo + "' ";
            bodyCommand += "                                                   ) ";
            bodyCommand += "ORDER BY rowNo ";
            selectBodyDt = selectDb.executeNoneLockSelect(bodyCommand);
            #endregion

            #region 受注フッタデータ取得
            footerCommand += "SELECT * ";
            footerCommand += "FROM juchu_footer ";
            footerCommand += "WHERE CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = ( ";
            footerCommand += "                                                     SELECT CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) ";
            footerCommand += "                                                     FROM juchu_header ";
            footerCommand += "                                                     WHERE(kanriKubun IS NULL OR kanriKubun != '9') ";
            footerCommand += "                                                     AND denpyoNo = '" + "documentNo" + "' ";
            footerCommand += "                                                   ) ";
            selectFooterDt = selectDb.executeNoneLockSelect(footerCommand);
            #endregion

            DataRow headRow = selectHeadDt.Rows[0];
            int maxBupinPageRow = 12;
            int bupinRow = 0;
            int page = 1;
            int maxPage = 0;
            string denpyoNo = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcDenpyoNo]);
            string shireBuzaiKubun = string.Empty;
            decimal juchuGoukei = decimal.Zero;
            decimal mekki = decimal.Zero;
            decimal tosou = decimal.Zero;
            decimal unchin = decimal.Zero;
            decimal shire = decimal.Zero;
            decimal buzai = decimal.Zero;
            decimal shireGoukei = decimal.Zero;
            string arariRitu = string.Empty;
            string strWkKingaku = string.Empty;
            decimal decWkKingaku = decimal.Zero;
            DateTime juchuDate = Convert.ToDateTime(headRow[DBFileLayout.JuchuHeaderFile.dcDenpyoHizuke]);
            string chumonNo = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
            chumonNo += "-" + Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
            chumonNo += "-" + Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            string renrakusaki1;
            string renrakusaki2;
            int printBodyRowIndex = 0;
            decimal wkMaxPage1 = (decimal)selectBodyDt.Rows.Count / (decimal)maxBupinPageRow;
            maxPage = (int)(selectBodyDt.Rows.Count / maxBupinPageRow);
            if (wkMaxPage1 > maxPage)
            {
                maxPage++;
            }
            foreach (DataRow row in selectBodyDt.Rows)
            {
                #region ボディデータ生成
                bupinRow++;
                printBodyDt.Rows.Add();
                printBodyRowIndex = printBodyDt.Rows.Count - 1;
                printBodyDt.Rows[printBodyRowIndex]["page"] = page;
                printBodyDt.Rows[printBodyRowIndex]["denpyoNo"] = denpyoNo;
                printBodyDt.Rows[printBodyRowIndex]["gyoNo"] = bupinRow;
                printBodyDt.Rows[printBodyRowIndex]["hinmeiCd"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinCode]);
                printBodyDt.Rows[printBodyRowIndex]["hinmei1"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinName1]);
                printBodyDt.Rows[printBodyRowIndex]["hinmei2"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinName2]);
                if (row["juchuSuryo"] != DBNull.Value)
                {
                    printBodyDt.Rows[printBodyRowIndex]["suryo"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuSuryo])).ToString("#,##0");
                }
                printBodyDt.Rows[printBodyRowIndex]["tani"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuTani]);
                if (row["juchuTanka"] != DBNull.Value)
                {
                    printBodyDt.Rows[printBodyRowIndex]["tanka"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuTanka])).ToString("#,##0");
                }
                if (row["juchuKingaku"] != DBNull.Value)
                {
                    printBodyDt.Rows[printBodyRowIndex]["kingaku"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuKingaku])).ToString("#,##0");
                }
                printBodyDt.Rows[printBodyRowIndex]["siiresakiNm"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShiresakiName]);
                if (row["shireTanka"] != DBNull.Value)
                {
                    printBodyDt.Rows[printBodyRowIndex]["siireTanka"] = CommonLogic.ToDecimal2(Convert.ToString(row["shireTanka"])).ToString("#,##0");
                }
                if (row["shireKingaku"] != DBNull.Value)
                {
                    printBodyDt.Rows[printBodyRowIndex]["siirekakaku"] = CommonLogic.ToDecimal2(Convert.ToString(row["shireKingaku"])).ToString("#,##0");
                }
                #endregion

                #region 受注金額集計
                strWkKingaku = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuKingaku]);
                decimal.TryParse(strWkKingaku, out decWkKingaku);
                juchuGoukei += decWkKingaku;
                #endregion

                #region 仕入金額集計
                shireBuzaiKubun = Convert.ToString(row["shireBuzaiKubun"]);
                strWkKingaku = Convert.ToString(row["shireKingaku"]);
                decimal.TryParse(strWkKingaku, out decWkKingaku);
                shireGoukei += decWkKingaku;
                // 明細区分がメッキ代の場合
                if (Consts.OrdersDetailType.PlatingAmount.Equals(shireBuzaiKubun))
                {
                    mekki += decWkKingaku;
                }
                // 明細区分が塗装代の場合
                else if (Consts.OrdersDetailType.PaintingAmount.Equals(shireBuzaiKubun))
                {
                    tosou += decWkKingaku;
                }
                // 明細区分が運賃の場合
                else if (Consts.OrdersDetailType.Fare.Equals(shireBuzaiKubun))
                {
                    unchin += decWkKingaku;
                }
                // 明細区分が仕入の場合
                else if (Consts.OrdersDetailType.Purchase.Equals(shireBuzaiKubun))
                {
                    shire += decWkKingaku;
                }
                // 明細区分が部材の場合
                else if (Consts.OrdersDetailType.Parts.Equals(shireBuzaiKubun))
                {
                    buzai += decWkKingaku;
                }
                #endregion

                if (bupinRow == maxBupinPageRow || printBodyRowIndex + 1 == selectBodyDt.Rows.Count)
                {
                    #region 不足分のボディデータ生成
                    while (bupinRow < maxBupinPageRow)
                    {
                        bupinRow++;
                        printBodyDt.Rows.Add();
                        printBodyRowIndex = printBodyDt.Rows.Count - 1;
                        printBodyDt.Rows[printBodyRowIndex]["page"] = page;
                        printBodyDt.Rows[printBodyRowIndex]["denpyoNo"] = denpyoNo;
                        printBodyDt.Rows[printBodyRowIndex]["gyoNo"] = bupinRow;
                    }
                    #endregion

                    #region ヘッダデータ生成
                    printHeadDt.Rows.Add();
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["page"] = page;
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kounyuNen"] = juchuDate.Year;
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kounyuTuki"] = juchuDate.Month;
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kounyuBi"] = juchuDate.Day;
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuiCd"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiCode]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuisakiNm1"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuisakiNm2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoName]);//事業所名
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["simeBi"] = Convert.ToString(headRow[DBFileLayout.TokuisakiMasterFile.dcShimebi]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["zairyokoujiKbn"] = Convert.ToString(headRow[DBFileLayout.MeisyoMasterFile.dcKubunName]);
                    //printHeadDt.Rows[printHeadDt.Rows.Count - 1]["bikou"] = Convert.ToString(headRow[""]);//保留
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tantoushaNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTantousyaName]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hakkoushaNM"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcHakousyaName]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["denpyoNo"] = denpyoNo;
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kenmei"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKenmei1]);//件名1
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kenmei2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKenmei2]);//件名1
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["chumonNo"] = chumonNo;
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["syuka"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcSyukabi]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["cyaku"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTyakubi]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["syukabin"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcSyukabin]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kyakusakichuNo"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKyakusakiChuban]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiName]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["yubinNo"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcZipCode]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["jyusho1"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcAddres1]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["jyusho2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcAddres2]);
                    renrakusaki1 = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki1]);
                    renrakusaki2 = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki2]);
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tell"] = renrakusaki1;
                    if (!string.IsNullOrEmpty(renrakusaki1) && !string.IsNullOrEmpty(renrakusaki2))
                    {
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tell"] += "　";
                    }
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tell"] += renrakusaki2;
                    if (string.IsNullOrEmpty(Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName])))
                    {
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTantousyaNm"] = string.Empty;
                    }
                    else
                    {
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTantousyaNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName]) + "　様";
                    }
                    printHeadDt.Rows[printHeadDt.Rows.Count - 1]["maxPage"] = maxPage;
                    #endregion

                    #region フッタデータ生成
                    printFooterDt.Rows.Add();
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["page"] = page;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["denpyoNo"] = denpyoNo;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["goukei"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["mekki"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["tosou"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["unchin"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["siire"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["buzai"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["siireGoukei"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["arari"] = string.Empty;
                    printFooterDt.Rows[printHeadDt.Rows.Count - 1]["arariritu"] = string.Empty;
                    #endregion

                    bupinRow = 0;
                    page++;
                }
            }

            if (printFooterDt.Rows.Count > 0)
            {
                printFooterDt.Rows[0]["goukei"] = juchuGoukei.ToString("#,##0"); ;
                printFooterDt.Rows[0]["mekki"] = mekki.ToString("#,##0"); ;
                printFooterDt.Rows[0]["tosou"] = tosou.ToString("#,##0"); ;
                printFooterDt.Rows[0]["unchin"] = unchin.ToString("#,##0"); ;
                printFooterDt.Rows[0]["siire"] = shire.ToString("#,##0"); ;
                printFooterDt.Rows[0]["buzai"] = buzai.ToString("#,##0"); ;
                printFooterDt.Rows[0]["siireGoukei"] = shireGoukei.ToString("#,##0"); ;
                printFooterDt.Rows[0]["arari"] = (juchuGoukei - shireGoukei).ToString("#,##0");
                printFooterDt.Rows[0]["arariritu"] = (juchuGoukei == decimal.Zero ? string.Empty : ((juchuGoukei - shireGoukei) / juchuGoukei * 100).ToString("###.#0") + "%");
            }

            buppinIchiran.Tables["dtblBuppinHeader"].Merge(printHeadDt.Copy());
            buppinIchiran.Tables["dtblBuppinBody"].Merge(printBodyDt.Copy());
            buppinIchiran.Tables["dtblBuppinF"].Merge(printFooterDt.Copy());

            string sql = string.Empty;

            return buppinIchiran;
        }
        #endregion

        #region 発注書出力データ取得処理
        /// <summary>
        /// 発注書出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblHachusho createHachuPrintData()
        {
            dtblHachusho hachuIchiran = new dtblHachusho();

            DBCommon selectDb = new DBCommon();
            string headCommand = string.Empty;
            string bodyCommand = string.Empty;
            string footerCommand = string.Empty;
            string sql = string.Empty;
            DataTable selectHeadDt;
            DataTable selectBodyDt;
            DataTable selectFooterDt;
            DataTable printHeadDt = hachuIchiran.Tables["dtblHachushoHead"].Clone();
            DataTable printBodyDt = hachuIchiran.Tables["dtblHachushoBody"].Clone();
            DataTable printFooterDt = hachuIchiran.Tables["dtblHachushoF"].Clone();

            #region 受注ヘッダデータ取得
            headCommand += "SELECT jh.denpyoHizuke ";
            headCommand += "     , jh.tokuisakiCode ";
            headCommand += "     , jh.tokuisakiName ";
            headCommand += "     , jh.tokuisakiTantousayName ";
            headCommand += "     , jh.jigyousyoName ";
            headCommand += "     , mm2.kubunName AS shimebi ";
            headCommand += "     , mm.kubunName ";
            headCommand += "     , jh.tantousyaName ";
            headCommand += "     , jh.hakousyaName ";
            headCommand += "     , jh.denpyoNo ";
            headCommand += "     , jh.kenmei1 ";
            headCommand += "     , jh.kenmei2 ";
            headCommand += "     , jh.juchuNoTop ";
            headCommand += "     , jh.juchuNoMid ";
            headCommand += "     , jh.juchuNoBtm ";
            headCommand += "     , DATE_FORMAT(jh.syukabi, '%Y年%c月%e日') AS syukabi ";
            headCommand += "     , DATE_FORMAT(jh.tyakubi, '%Y年%c月%e日') AS tyakubi ";
            headCommand += "     , jh.syukabin ";
            headCommand += "     , jh.kyakusakiChuban ";
            headCommand += "     , jh.nounyusakiName ";
            headCommand += "     , jh.zipCode ";
            headCommand += "     , jh.addres1 ";
            headCommand += "     , jh.addres2 ";
            headCommand += "     , jh.renrakusaki1 ";
            headCommand += "     , jh.renrakusaki2 ";
            headCommand += "     , jh.nounyusakiTantousyaName ";
            headCommand += "     , jh.mitumoriNo ";
            headCommand += "FROM (SELECT * FROM juchu_header WHERE (kanriKubun IS NULL OR kanriKubun != '9') AND denpyoNo = '" + documentNo + "') jh ";
            headCommand += "LEFT JOIN (SELECT * FROM tokuisaki_master WHERE(kanriKubun IS NULL OR kanriKubun != '9')) tm ";
            headCommand += "ON (jh.tokuisakiCode = tm.tokuisakiCode AND jh.jigyousyoCode = tm.jigyousyoCode) ";
            headCommand += "LEFT JOIN (SELECT * FROM meisyo_master WHERE(kanriKubun IS NULL OR kanriKubun != '9') AND meisyoCode = '001') mm ";
            headCommand += "ON (jh.zairyoKoujiKubun = mm.kubun) ";
            headCommand += "LEFT JOIN (SELECT * FROM meisyo_master WHERE(kanriKubun IS NULL OR kanriKubun != '9') AND meisyoCode = '006') mm2 ";
            headCommand += "ON (tm.shimebi = mm2.kubun) ";
            selectHeadDt = selectDb.executeNoneLockSelect(headCommand);
            #endregion

            #region 受注ボディデータ取得
            bodyCommand += "SELECT * ";
            bodyCommand += "FROM juchu_body ";
            bodyCommand += "WHERE CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = ( ";
            bodyCommand += "                                                     SELECT CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) ";
            bodyCommand += "                                                     FROM juchu_header ";
            bodyCommand += "                                                     WHERE(kanriKubun IS NULL OR kanriKubun != '9') ";
            bodyCommand += "                                                     AND denpyoNo = '" + documentNo + "' ";
            bodyCommand += "                                                   ) ";
            if (rdoSelectVendor.Checked)
            {
                bodyCommand += "ORDER BY shireHachuNo, rowNo ";
            }
            else
            {
                bodyCommand += "ORDER BY rowNo ";
            }
            selectBodyDt = selectDb.executeNoneLockSelect(bodyCommand);
            #endregion

            #region 受注フッタデータ取得
            footerCommand += "SELECT * ";
            footerCommand += "FROM juchu_footer ";
            footerCommand += "WHERE CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) = ( ";
            footerCommand += "                                                     SELECT CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm) ";
            footerCommand += "                                                     FROM juchu_header ";
            footerCommand += "                                                     WHERE(kanriKubun IS NULL OR kanriKubun != '9') ";
            footerCommand += "                                                     AND denpyoNo = '" + "documentNo" + "' ";
            footerCommand += "                                                   ) ";
            selectFooterDt = selectDb.executeNoneLockSelect(footerCommand);
            #endregion

            #region 会社マスタデータ取得
            sql = string.Empty;
            sql += "SELECT * FROM kaisya_master ";
            DataTable kaisyaDt = selectDb.executeNoneLockSelect(sql).Copy();
            #endregion

            string selectedVendorCode = Convert.ToString(cmbVenbor.SelectedValue);
            DataRow headRow = selectHeadDt.Rows[0];
            int maxHachuPageRow = 12;
            int hachuRow = 0;
            int LackRowCount = 0;
            string denpyoNo = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcDenpyoNo]);
            string shireHachuNo;
            string mitumoriNo = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcMitumoriNo]);
            string hachusakiNm;
            string hachusyoEdaban;
            DateTime juchuDate = Convert.ToDateTime(headRow[DBFileLayout.JuchuHeaderFile.dcDenpyoHizuke]);
            string chumonNo = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoTop]);
            chumonNo += "-" + Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoMid]);
            chumonNo += "-" + Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJuchuNoBtm]);
            int printBodyRowIndex = 0;
            List<string> shiresakiList = new List<string>();
            string wkShiresakiCode;
            foreach (DataRow row in selectBodyDt.Rows)
            {
                wkShiresakiCode = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShiresakiCode]);
                if (!shiresakiList.Contains(wkShiresakiCode)) shiresakiList.Add(wkShiresakiCode);
            }
            string jigyousyoName;
            string kaisyaJyusyo = Convert.ToString(kaisyaDt.Rows[0][DBFileLayout.KaisyaMasterFile.dcAddress]);
            int wkDenpyoNo = 1;
            int rowCount = 0;
            string renrakusaki1;
            string renrakusaki2;

            int page = 0;
            decimal maxPage = 0;
            if (rdoSelectVendor.Checked)
            {
                foreach (string shiresakiCode in shiresakiList)
                {
                    if (!selectedVendorCode.Equals("ALL") && !selectedVendorCode.Equals(shiresakiCode))
                    {
                        continue;
                    }
                    var query = selectBodyDt.AsEnumerable().Where(p => shiresakiCode.Equals(p.Field<string>(DBFileLayout.JuchuBodyFile.dcShiresakiCode))).OrderBy(p => p.Field<int>(DBFileLayout.JuchuBodyFile.dcRowNo));
                    page = 1;
                    rowCount = 0;
                    foreach (DataRow row in query)
                    {
                        maxPage = commonLogic.RoundKingaku(query.Count() / maxHachuPageRow, Consts.RoundType.RoundOff);
                        if (maxPage == 0 || query.Count() % maxHachuPageRow > 0) maxPage++;
                        #region ボディデータ生成
                        hachuRow++;
                        rowCount++;
                        shireHachuNo = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShireHachuNo]);
                        hachusakiNm = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShiresakiName]);
                        hachusyoEdaban = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcHachusyoEdaban]);
                        printBodyDt.Rows.Add();
                        printBodyRowIndex = printBodyDt.Rows.Count - 1;
                        printBodyDt.Rows[printBodyRowIndex]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                        printBodyDt.Rows[printBodyRowIndex]["gyouNo"] = hachuRow;
                        printBodyDt.Rows[printBodyRowIndex]["shohinCd"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinCode]);
                        printBodyDt.Rows[printBodyRowIndex]["shohiNm1"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinName1]);
                        printBodyDt.Rows[printBodyRowIndex]["shohinNm2"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinName2]);
                        if (row["juchuSuryo"] != DBNull.Value)
                        {
                            printBodyDt.Rows[printBodyRowIndex]["suryou"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuSuryo])).ToString("#,##0");
                        }
                        printBodyDt.Rows[printBodyRowIndex]["tani"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuTani]);
                        if (row[DBFileLayout.JuchuBodyFile.dcShireTanka] != DBNull.Value)
                        {
                            printBodyDt.Rows[printBodyRowIndex]["tanka"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShireTanka])).ToString("#,##0");
                        }
                        if (row[DBFileLayout.JuchuBodyFile.dcShireKingaku] != DBNull.Value)
                        {
                            printBodyDt.Rows[printBodyRowIndex]["kingaku"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShireKingaku])).ToString("#,##0");
                        }
                        printBodyDt.Rows[printBodyRowIndex]["page"] = Convert.ToString(page);
                        #endregion

                        if (rowCount == query.Count() || hachuRow == maxHachuPageRow)
                        {
                            #region 不足分のボディデータ生成
                            LackRowCount = maxHachuPageRow - (hachuRow % maxHachuPageRow);
                            if (LackRowCount == maxHachuPageRow) LackRowCount = 0;
                            while (LackRowCount > 0)
                            {
                                hachuRow++;
                                printBodyDt.Rows.Add();
                                printBodyRowIndex = printBodyDt.Rows.Count - 1;
                                printBodyDt.Rows[printBodyRowIndex]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                                printBodyDt.Rows[printBodyRowIndex]["gyouNo"] = hachuRow;
                                LackRowCount--;
                            }
                            #endregion

                            #region ヘッダデータ生成
                            printHeadDt.Rows.Add();
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachusakiNm"] = hachusakiNm + "　御中";
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachuNen"] = juchuDate.Year;
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachuTuki"] = juchuDate.Month;
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachuBi"] = juchuDate.Day;
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuisakiCd"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiCode]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuisakiNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);
                            jigyousyoName = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoName]);
                            if (!string.IsNullOrEmpty(Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiTantousayName])))
                            {
                                jigyousyoName += " " + Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiTantousayName]) + "　様";
                            }
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["jigyousyoNm"] = jigyousyoName;
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["shimebi"] = Convert.ToString(headRow[DBFileLayout.TokuisakiMasterFile.dcShimebi]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["zairyoukoujiKbn"] = Convert.ToString(headRow[DBFileLayout.MeisyoMasterFile.dcKubunName]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tantousha"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTantousyaName]);
                            //printHeadDt.Rows[printHeadDt.Rows.Count - 1]["bikou"] = "";
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hakkousha"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcHakousyaName]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kenmei"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKenmei1]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kenmei2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKenmei2]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["cyumonNo"] = chumonNo;
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["syukabi"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcSyukabi]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["cyakubi"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTyakubi]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["syukabin"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcSyukabin]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kyakusakicyuban"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKyakusakiChuban]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiName]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiYubinNo"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiName]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiJyusho1"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcAddres1]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakijyusho2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcAddres2]);
                            renrakusaki1 = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki1]);
                            renrakusaki2 = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki2]);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTell"] = renrakusaki1;
                            if (!string.IsNullOrEmpty(renrakusaki1) && !string.IsNullOrEmpty(renrakusaki2))
                            {
                                printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTell"] += "　";
                            }
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTell"] += renrakusaki2;
                            if (string.IsNullOrEmpty(Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName])))
                            {
                                printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTantousyaNm"] = string.Empty;
                            }
                            else
                            {
                                printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTantousyaNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName]) + "　様";
                            }
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kaisayJusho"] = kaisyaJyusyo;
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["maxPage"] = Convert.ToString(maxPage);
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["dispDenpyouNo"] = denpyoNo + (string.IsNullOrEmpty(hachusyoEdaban) ? string.Empty : ("-" + hachusyoEdaban));
                            #endregion

                            #region フッタデータ生成
                            printFooterDt.Rows.Add();
                            printFooterDt.Rows[printHeadDt.Rows.Count - 1]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                            printFooterDt.Rows[printHeadDt.Rows.Count - 1]["mitumoriNo"] = mitumoriNo;
                            #endregion

                            hachuRow = 0;
                            wkDenpyoNo++;
                            page++;
                        }
                    }
                }
            }
            else
            {
                page = 1;
                decimal totalJuchuKingaku = decimal.Zero;
                decimal totalShireKingaku = decimal.Zero;
                decimal wkKingaku = decimal.Zero;
                foreach (DataRow row in selectBodyDt.Rows)
                {
                    #region ボディデータ生成
                    hachuRow++;
                    rowCount++;
                    hachusakiNm = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShiresakiName]);
                    hachusyoEdaban = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcHachusyoEdaban]);
                    printBodyDt.Rows.Add();
                    printBodyRowIndex = printBodyDt.Rows.Count - 1;
                    printBodyDt.Rows[printBodyRowIndex]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                    printBodyDt.Rows[printBodyRowIndex]["gyouNo"] = hachuRow;
                    printBodyDt.Rows[printBodyRowIndex]["shohinCd"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinCode]);
                    printBodyDt.Rows[printBodyRowIndex]["shohiNm1"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinName1]);
                    printBodyDt.Rows[printBodyRowIndex]["shohinNm2"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShouhinName2]);
                    if (row["juchuSuryo"] != DBNull.Value)
                    {
                        printBodyDt.Rows[printBodyRowIndex]["suryou"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuSuryo])).ToString("#,##0");
                    }
                    printBodyDt.Rows[printBodyRowIndex]["tani"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuTani]);
                    //if (row["juchuTanka"] != DBNull.Value)
                    //{
                    //    printBodyDt.Rows[printBodyRowIndex]["tanka"] = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuTanka])).ToString("#,##0");
                    //}
                    //if (row["juchuKingaku"] != DBNull.Value)
                    //{
                    //    wkKingaku = CommonLogic.ToDecimal2(Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcJuchuKingaku]));
                    //    totalJuchuKingaku += wkKingaku;
                    //    printBodyDt.Rows[printBodyRowIndex]["kingaku"] = wkKingaku.ToString("#,##0");
                    //}
                    printBodyDt.Rows[printBodyRowIndex]["siiresakiNm"] = Convert.ToString(row[DBFileLayout.JuchuBodyFile.dcShiresakiName]);
                    if (row["shireTanka"] != DBNull.Value)
                    {
                        printBodyDt.Rows[printBodyRowIndex]["siireTanka"] = CommonLogic.ToDecimal2(Convert.ToString(row["shireTanka"])).ToString("#,##0");
                    }
                    if (row["shireKingaku"] != DBNull.Value)
                    {
                        wkKingaku = CommonLogic.ToDecimal2(Convert.ToString(row["shireKingaku"]));
                        totalShireKingaku += wkKingaku;
                        printBodyDt.Rows[printBodyRowIndex]["siirekakaku"] = wkKingaku.ToString("#,##0");
                    }
                    printBodyDt.Rows[printBodyRowIndex]["page"] = Convert.ToString(page);
                    #endregion

                    if (rowCount == selectBodyDt.Rows.Count || maxHachuPageRow == hachuRow)
                    {
                        #region 不足分のボディデータ生成
                        LackRowCount = maxHachuPageRow - (hachuRow % maxHachuPageRow);
                        if (LackRowCount == maxHachuPageRow) LackRowCount = 0;
                        while (LackRowCount > 0)
                        {
                            hachuRow++;
                            printBodyDt.Rows.Add();
                            printBodyRowIndex = printBodyDt.Rows.Count - 1;
                            printBodyDt.Rows[printBodyRowIndex]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                            printBodyDt.Rows[printBodyRowIndex]["gyouNo"] = hachuRow;
                            LackRowCount--;
                        }
                        #endregion

                        maxPage = page;

                        #region ヘッダデータ生成
                        printHeadDt.Rows.Add();
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachuNen"] = juchuDate.Year;
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachuTuki"] = juchuDate.Month;
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hachuBi"] = juchuDate.Day;
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuisakiCd"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiCode]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tokuisakiNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiName]);
                        jigyousyoName = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcJigyousyoName]);
                        if (!string.IsNullOrEmpty(Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiTantousayName])))
                        {
                            jigyousyoName += " " + Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTokuisakiTantousayName]) + "　様";
                        }
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["jigyousyoNm"] = jigyousyoName;
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["shimebi"] = Convert.ToString(headRow[DBFileLayout.TokuisakiMasterFile.dcShimebi]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["zairyoukoujiKbn"] = Convert.ToString(headRow[DBFileLayout.MeisyoMasterFile.dcKubunName]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["tantousha"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTantousyaName]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["hakkousha"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcHakousyaName]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kenmei"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKenmei1]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kenmei2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKenmei2]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["cyumonNo"] = chumonNo;
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["syukabi"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcSyukabi]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["cyakubi"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcTyakubi]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["syukabin"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcSyukabin]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kyakusakicyuban"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcKyakusakiChuban]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiName]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiYubinNo"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiName]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiJyusho1"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcAddres1]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakijyusho2"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcAddres2]);
                        renrakusaki1 = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki1]);
                        renrakusaki2 = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcRenrakusaki2]);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTell"] = renrakusaki1;
                        if (!string.IsNullOrEmpty(renrakusaki1) && !string.IsNullOrEmpty(renrakusaki2))
                        {
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTell"] += "　";
                        }
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTell"] += renrakusaki2;
                        if (string.IsNullOrEmpty(Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName])))
                        {
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTantousyaNm"] = string.Empty;
                        }
                        else
                        {
                            printHeadDt.Rows[printHeadDt.Rows.Count - 1]["nounyusakiTantousyaNm"] = Convert.ToString(headRow[DBFileLayout.JuchuHeaderFile.dcNounyusakiTantousyaName]) + "　様";
                        }
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["kaisayJusho"] = kaisyaJyusyo;
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["maxPage"] = Convert.ToString(maxPage);
                        printHeadDt.Rows[printHeadDt.Rows.Count - 1]["dispDenpyouNo"] = denpyoNo;
                        #endregion

                        #region フッタデータ生成
                        printFooterDt.Rows.Add();
                        printFooterDt.Rows[printHeadDt.Rows.Count - 1]["denpyouNo"] = commonLogic.getZeroBuriedNumberText(Convert.ToString(wkDenpyoNo), 8);
                        printFooterDt.Rows[printHeadDt.Rows.Count - 1]["mitumoriNo"] = mitumoriNo;
                        printFooterDt.Rows[printHeadDt.Rows.Count - 1]["toutalJuchuKingaku"] = string.Empty;
                        if (rowCount == selectBodyDt.Rows.Count)
                        {
                            printFooterDt.Rows[printHeadDt.Rows.Count - 1]["toutalShireKingaku"] = totalShireKingaku.ToString("#,##0");
                        }
                        else
                        {
                            printFooterDt.Rows[printHeadDt.Rows.Count - 1]["toutalShireKingaku"] = "次頁へ";
                        }
                        #endregion

                        hachuRow = 0;
                        page++;
                        wkDenpyoNo++;
                    }
                }

                foreach (DataRow hRow in printHeadDt.Rows)
                {
                    hRow["maxPage"] = Convert.ToString(maxPage);
                }
            }

            hachuIchiran.Tables["dtblHachushoHead"].Merge(printHeadDt.Copy());
            hachuIchiran.Tables["dtblHachushoBody"].Merge(printBodyDt.Copy());
            hachuIchiran.Tables["dtblHachushoF"].Merge(printFooterDt.Copy());

            return hachuIchiran;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            int print = 0;
            if (rdoAll.Checked || rdoBuppin.Checked)
            {
                rptBuppinKounyusho1.SetDataSource(createBupinPrintData());
                pairs.Add("物品購入書", rptBuppinKounyusho1);
                print = 1;
            }
            if (rdoAll.Checked || rdoHachu.Checked)
            {
                if (rdoSelectVendor.Checked)
                {
                    rptHachusho1.SetDataSource(createHachuPrintData());
                    pairs.Add("発注書", rptHachusho1);
                }
                else
                {
                    rptHachushoAllMeisai1.SetDataSource(createHachuPrintData());
                    pairs.Add("発注書", rptHachushoAllMeisai1);
                }
                print = 2;
            }
            frmPrintView2 printView2 = new frmPrintView2(pairs);
            if (PrintType.OutPut.Equals(printType))
            {
                if (rdoAll.Checked)
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptBuppinKounyusho1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptBuppinKounyusho1.PrintOptions.PaperOrientation)
                                                                         , rptBuppinKounyusho1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptBuppinKounyusho1.PrintToPrinter(printerSettings
                                                         , pageSettings
                                                         , false);

                    }

                    if (rdoSelectVendor.Checked)
                    {
                        //印刷ダイアログ表示処理実行
                        printerSettings = null;
                        pageSettings = null;
                        result = DialogResult.None;
                        result = commonLogic.DisplayedPrintDialog(rptHachusho1.PrintOptions.PrinterName
                                                                , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptHachusho1.PrintOptions.PaperOrientation)
                                                                , rptHachusho1.PrintOptions.PaperSize.ToString()
                                                                , ref printerSettings
                                                                , ref pageSettings);
                        //印刷の選択ダイアログを表示する
                        if (result == DialogResult.OK)
                        {
                            //OKがクリックされた時は印刷する
                            rptHachusho1.PrintToPrinter(printerSettings
                                                      , pageSettings
                                                      , false);

                        }
                    }
                    else
                    {
                        //印刷ダイアログ表示処理実行
                        printerSettings = null;
                        pageSettings = null;
                        result = DialogResult.None;
                        result = commonLogic.DisplayedPrintDialog(rptHachushoAllMeisai1.PrintOptions.PrinterName
                                                                , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptHachushoAllMeisai1.PrintOptions.PaperOrientation)
                                                                , rptHachushoAllMeisai1.PrintOptions.PaperSize.ToString()
                                                                , ref printerSettings
                                                                , ref pageSettings);
                        //印刷の選択ダイアログを表示する
                        if (result == DialogResult.OK)
                        {
                            //OKがクリックされた時は印刷する
                            rptHachushoAllMeisai1.PrintToPrinter(printerSettings
                                                      , pageSettings
                                                      , false);

                        }
                    }
                }
                else
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = DialogResult.None;
                    if (print == 1)
                    {
                        result = commonLogic.DisplayedPrintDialog(rptBuppinKounyusho1.PrintOptions.PrinterName
                                                                , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptBuppinKounyusho1.PrintOptions.PaperOrientation)
                                                                , rptBuppinKounyusho1.PrintOptions.PaperSize.ToString()
                                                                , ref printerSettings
                                                                , ref pageSettings);
                    }
                    else
                    {
                        if (rdoSelectVendor.Checked)
                        {
                            result = commonLogic.DisplayedPrintDialog(rptHachusho1.PrintOptions.PrinterName
                                                                    , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptHachusho1.PrintOptions.PaperOrientation)
                                                                    , rptHachusho1.PrintOptions.PaperSize.ToString()
                                                                    , ref printerSettings
                                                                    , ref pageSettings);
                        }
                        else
                        {
                            result = commonLogic.DisplayedPrintDialog(rptHachushoAllMeisai1.PrintOptions.PrinterName
                                                                    , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptHachushoAllMeisai1.PrintOptions.PaperOrientation)
                                                                    , rptHachushoAllMeisai1.PrintOptions.PaperSize.ToString()
                                                                    , ref printerSettings
                                                                    , ref pageSettings);
                        }
                    }
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        if (print == 1)
                        {
                            rptBuppinKounyusho1.PrintToPrinter(printerSettings
                                                             , pageSettings
                                                             , false);
                        }
                        else
                        {
                            if (rdoSelectVendor.Checked)
                            {
                                rptHachusho1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);
                            }
                            else
                            {
                                rptHachushoAllMeisai1.PrintToPrinter(printerSettings
                                                          , pageSettings
                                                          , false);
                            }
                        }

                    }
                }
            }
            else
            {
                printView2.Size = new Size(1375, 975);
                printView2.StartPosition = FormStartPosition.CenterScreen;
                printView2.ShowDialog();
                if (flgClose) this.closedForm();
            }
        }
        #endregion

        #region 仕入先コンボボックス生成処理
        /// <summary>
        /// 仕入先コンボボックス生成処理
        /// </summary>
        private void setVendorCombo()
        {
            DBCommon dBCommon = new DBCommon();
            string sql = string.Empty;
            sql += "SELECT jb.shiresakiCode ";
            sql += "     , MAX(jb.shiresakiName) AS shiresakiName ";
            sql += "FROM (SELECT * FROM juchu_header WHERE denpyoNo = '" + documentNo + "' AND (kanriKubun IS NULL OR kanriKubun <> '9')) jh ";
            sql += "INNER JOIN (SELECT * FROM juchu_body WHERE (kanriKubun IS NULL OR kanriKubun <> '9')) jb ";
            sql += "ON (jh.juchuNoTop = jb.juchuNoTop AND jh.juchuNoMid = jb.juchuNoMid AND jh.juchuNoBtm = jb.juchuNoBtm) ";
            sql += "GROUP BY jb.shiresakiCode ";
            sql += "ORDER BY jb.shiresakiCode ";
            DataTable dt = dBCommon.executeNoneLockSelect(sql);
            DataRow row = dt.NewRow();
            row["shiresakiCode"] = "ALL";
            row["shiresakiName"] = "すべて";
            dt.Rows.InsertAt(row, 0);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbVenbor, dt, "shiresakiCode", "shiresakiName");
        }
        #endregion

        #endregion

        private void rdoOutputUnit_Click(object sender, EventArgs e)
        {
            if (rdoSelectVendor.Checked)
            {
                cmbVenbor.Enabled = true;
            }
            else
            {
                cmbVenbor.SelectedIndex = 0;
                cmbVenbor.Enabled = false;
            }
        }
    }
}
