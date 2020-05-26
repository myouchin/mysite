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
    /// 売上収支一覧表
    /// </summary>
    public partial class frmUriageSyushiIchiran : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , TargetDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DBTantousyaMaster tantousyaMaster;
        private string cmbAllValue = "ALL";
        private string cmbAllText = "すべて";

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmUriageSyushiIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetDateYears.Text = string.Empty;
            txtTargetDateMonth.Text = string.Empty;
            commonLogic = new CommonLogic();
            tantousyaMaster = new DBTantousyaMaster();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
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

        #region 対象年月日(FROM)フォーカスインイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月日(FROM)フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetDate;
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

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;

                switch (lastInputDateType)
                {
                    case LastInputDateType.TargetDate:
                        y = txtTargetDateYears.Text;
                        m = txtTargetDateMonth.Text;
                        d = "01";
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.TargetDate.Equals(lastInputDateType))
                    {
                        txtTargetDateYears.Focus();
                    }
                    return;
                }
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
            // 担当者コンボボックス設定
            setPersonnelCmb();
            // 入力情報設定
            setInputInfo();
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

        #endregion

        #region ビジネスロジック

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m))
            {
                ret = true;
            }
            else
            {
                DateTime date;

                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
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

            // 対象年月日(FROM)の場合
            if (c.Name.Equals(txtTargetDateYears.Name) ||
                c.Name.Equals(txtTargetDateMonth.Name) ||
                c.Name.Equals(dtpTargetDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetDateFrom_Leave);
            }

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

        #region 帳票出力データ取得処理
        /// <summary>
        /// 画面表示・帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblUriagesyusiichiran getData()
        {
            dtblUriagesyusiichiran result = new dtblUriagesyusiichiran();
            DBCommon selectDb = new DBCommon();
            string sql = string.Empty;
            sql += "SELECT tantousyaCode AS tantoCd ";
            sql += "     , tantousyaName AS tantoNm ";
            sql += "     , juchuNo AS cyumonNo ";
            sql += "     , juchuNoEda ";
            sql += "     , DATE_FORMAT(uriageHizuke, '%Y%m%d' ) AS uriageHiduke ";
            sql += "     , tokuisakiName AS hacyusyaNm ";
            sql += "     , uriageKingaku AS uriageGaku ";
            sql += "     , DATE_FORMAT(juchuHizuke, '%Y%m%d' ) AS jyucyuHiduke ";
            sql += "     , shiresakiName AS siiresakiNm ";
            sql += "     , shireKingaku AS siireGaku ";
            sql += "     , arariKingaku AS arariGaku ";
            sql += "     , kenmei AS kenmei ";
            sql += "FROM uriage_syushi_ichiran ";
            sql += "ORDER BY tantousyaCode, uriageHizuke, juchuNo, juchuNoEda, shiresakiCode ";
            DataTable dt = selectDb.executeNoneLockSelect(sql).Copy();

            decimal uriageGaku = decimal.Zero;
            decimal shireGaku = decimal.Zero;
            decimal arariGaku = decimal.Zero;
            DataRow newRow;
            List<string> tantousyList = new List<string>();
            string tantousyaCode;
            decimal dec;
            result.Tables["dtblUriagesyusiIchiranTantouGS"].Rows.Add();
            DataRow totalRow;
            int juchuNoEda;
            foreach (DataRow row in dt.Rows)
            {
                newRow = result.Tables["dtblUriagesyusiIchiran"].NewRow();
                tantousyaCode = Convert.ToString(row["tantoCd"]);
                juchuNoEda = Convert.ToInt16(row["juchuNoEda"]);
                newRow["tantoCd"] = Convert.ToString(row["tantoCd"]);
                newRow["tantoNm"] = Convert.ToString(row["tantoNm"]);
                if (string.IsNullOrEmpty(Convert.ToString(row["cyumonNo"])))
                {
                    newRow["cyumonNo"] = string.Empty;
                    newRow["uriageHiduke"] = string.Empty;
                    newRow["hacyusyaNm"] = string.Empty;
                    newRow["jyucyuHiduke"] = Convert.ToString(row["uriageHiduke"]);
                }
                else if (juchuNoEda == 1)
                {
                    newRow["cyumonNo"] = Convert.ToString(row["cyumonNo"]);
                    newRow["uriageHiduke"] = Convert.ToString(row["uriageHiduke"]);
                    newRow["hacyusyaNm"] = Convert.ToString(row["hacyusyaNm"]);
                    newRow["jyucyuHiduke"] = Convert.ToString(row["jyucyuHiduke"]);
                }
                else
                {
                    newRow["cyumonNo"] = string.Empty;
                    newRow["uriageHiduke"] = string.Empty;
                    newRow["hacyusyaNm"] = string.Empty;
                    newRow["jyucyuHiduke"] = string.Empty;
                }
                if (decimal.TryParse(Convert.ToString(row["uriageGaku"]), out uriageGaku))
                {
                    newRow["uriageGaku"] = uriageGaku.ToString("#,##0");
                }
                else
                {
                    newRow["uriageGaku"] = string.Empty;
                }
                newRow["siiresakiNm"] = Convert.ToString(row["siiresakiNm"]);
                if (decimal.TryParse(Convert.ToString(row["siireGaku"]), out shireGaku))
                {
                    newRow["siireGaku"] = shireGaku.ToString("#,##0");
                }
                else
                {
                    newRow["siireGaku"] = string.Empty;
                }
                if (decimal.TryParse(Convert.ToString(row["arariGaku"]), out arariGaku))
                {
                    newRow["arariGaku"] = arariGaku.ToString("#,##0");
                }
                else
                {
                    newRow["arariGaku"] = string.Empty;
                }
                newRow["kenmei"] = Convert.ToString(row["kenmei"]);
                result.Tables["dtblUriagesyusiIchiran"].Rows.Add(newRow.ItemArray);

                if (!tantousyList.Contains(tantousyaCode))
                {
                    newRow = result.Tables["dtblUriagesyusiIchiranTantouG"].NewRow();
                    newRow["tantoCd"] = tantousyaCode;
                    newRow["uriageGakuG"] = uriageGaku.ToString("#,##0");
                    newRow["siireGakuG"] = shireGaku.ToString("#,##0");
                    newRow["arariGakuG"] = arariGaku.ToString("#,##0");
                    result.Tables["dtblUriagesyusiIchiranTantouG"].Rows.Add(newRow.ItemArray);
                    tantousyList.Add(tantousyaCode);
                }
                else
                {
                    var query = result.Tables["dtblUriagesyusiIchiranTantouG"].AsEnumerable().Where(p => p.Field<string>("tantoCd").Equals(tantousyaCode));
                    totalRow = query.ElementAt(0);
                    decimal.TryParse(Convert.ToString(totalRow["uriageGakuG"]), out dec);
                    totalRow["uriageGakuG"] = (dec + uriageGaku).ToString("#,##0");
                    decimal.TryParse(Convert.ToString(totalRow["siireGakuG"]), out dec);
                    totalRow["siireGakuG"] = (dec + shireGaku).ToString("#,##0");
                    decimal.TryParse(Convert.ToString(totalRow["arariGakuG"]), out dec);
                    totalRow["arariGakuG"] = (dec + arariGaku).ToString("#,##0");
                }
                totalRow = result.Tables["dtblUriagesyusiIchiranTantouGS"].Rows[0];
                decimal.TryParse(Convert.ToString(totalRow["uriageGakuSG"]), out dec);
                totalRow["uriageGakuSG"] = (dec + uriageGaku).ToString("#,##0");
                decimal.TryParse(Convert.ToString(totalRow["siireGakuSG"]), out dec);
                totalRow["siireGakuSG"] = (dec + shireGaku).ToString("#,##0");
                decimal.TryParse(Convert.ToString(totalRow["arariGakuSG"]), out dec);
                totalRow["arariGakuSG"] = (dec + arariGaku).ToString("#,##0");
            }
            return result;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtTargetDateYears.Text) ||
                string.IsNullOrEmpty(txtTargetDateMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblTargetDate.Text));
                return;
            }

            registSyushihyou();

            dtblUriagesyusiichiran syushiList = getData();
            if (syushiList == null || syushiList.Tables["dtblUriagesyusiIchiran"].Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "対象年月日のデータ"));
                return;
            }
            rptUriagesyusiichiran1.SetDataSource(syushiList);

            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptUriagesyusiichiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptUriagesyusiichiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptUriagesyusiichiran1.PrintOptions.PaperOrientation)
                                                                     , rptUriagesyusiichiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptUriagesyusiichiran1.PrintToPrinter(printerSettings
                                                        , pageSettings
                                                        , false);

                }
            }
            else
            {
                printView.Size = new Size(1585, 940);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtTargetDateYears.MaxLength = 4;   // 年月(年)
            txtTargetDateMonth.MaxLength = 2;   // 年月(月)

            // 入力制御イベント設定
            txtTargetDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(年):数字のみ入力可
            txtTargetDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(月):数字のみ入力可
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
            DataRow row = tantousyaDt.NewRow();
            row["tantousyaCode"] = cmbAllValue;
            row["tantousyaName"] = cmbAllText;
            tantousyaDt.Rows.InsertAt(row, 0);
            tantousyaDt.AcceptChanges();
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPersonnel, tantousyaDt, "tantousyaCode", "tantousyaName");
        }
        #endregion

        #region 売上収支表データ登録処理
        /// <summary>
        /// 売上収支表データ登録処理
        /// </summary>
        private void registSyushihyou()
        {
            DBCommon registDb = new DBCommon();
            string sql = string.Empty;
            string targetYM = txtTargetDateYears.Text;
            targetYM += (txtTargetDateMonth.Text.Length == 1 ? "0" : string.Empty) + txtTargetDateMonth.Text;
            string selectedTantousyaCode = Convert.ToString(cmbPersonnel.SelectedValue);

            registDb.startTransaction();
            // 売上収支表データ削除
            sql = "DELETE FROM uriage_syushi_ichiran ";
            registDb.executeDBUpdate(sql);
            registDb.endTransaction();

            registDb.startTransaction();
            // 売上ファイルから売上収支表データを登録
            sql = string.Empty;
            //sql += "INSERT INTO uriage_syushi_ichiran ";
            //sql += "( ";
            //sql += "  tantousyaCode ";
            //sql += ", tantousyaName ";
            //sql += ", juchuNo ";
            //sql += ", juchuNoEda ";
            //sql += ", uriageHizuke ";
            //sql += ", juchuHizuke ";
            //sql += ", tokuisakiCode ";
            //sql += ", jigyousyoCode ";
            //sql += ", tokuisakiName ";
            //sql += ", jigyousyoName ";
            //sql += ", kenmei ";
            //sql += ", uriageKingaku ";
            //sql += ", shiresakiCode ";
            //sql += ", shiresakiName ";
            //sql += ", shireKingaku ";
            //sql += ", arariKingaku ";
            //sql += ") ";
            //sql += "SELECT uh.tantousyaCode ";
            //sql += "     , uh.tantousyaName ";
            //sql += "     , CONCAT(uh.juchuNoTop, uh.juchuNoMid, uh.juchuNoBtm) ";
            //sql += "     , 1 ";
            //sql += "     , uh.denpyoHizuke ";
            //sql += "     , MAX(jh.denpyoHizuke) AS juchuHizuke ";
            //sql += "     , MAX(uh.tokuisakiCode) AS tokuisakiCode ";
            //sql += "     , MAX(uh.jigyousyoCode) AS jigyousyoCode ";
            //sql += "     , MAX(uh.tokuisakiName) AS tokuisakiName ";
            //sql += "     , MAX(uh.jigyousyoName) AS jigyousyoName ";
            //sql += "     , MAX(uh.kenmei1) AS kenmei1 ";
            //sql += "     , SUM(IFNULL(ub.kingaku, 0)) AS kingaku ";
            //sql += "     , '' AS shiresakiCode ";
            //sql += "     , '' AS shiresakiName ";
            //sql += "     , 0 AS shireKingaku ";
            //sql += "     , NULL AS arariKingaku ";
            //sql += "FROM (SELECT * FROM uriage_header WHERE (kanriKubun IS NULL OR kanriKubun = '') AND DATE_FORMAT(denpyoHizuke, '%Y%m') = '" + targetYM + "' ";
            //if (!cmbAllValue.Equals(selectedTantousyaCode)) sql += "AND tantousyaCode = '" + selectedTantousyaCode + "' ";
            //sql += ") uh ";
            //sql += "INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            //sql += "ON (uh.denpyoNo = ub.denpyoNo) ";
            //sql += "INNER JOIN(SELECT* FROM juchu_header) jh ";
            //sql += "ON(uh.juchuNoTop = jh.juchuNoTop AND uh.juchuNoMid = jh.juchuNoMid AND uh.juchuNoBtm = jh.juchuNoBtm) ";
            //sql += "GROUP BY uh.tantousyaCode, uh.juchuNoTop, uh.juchuNoMid, uh.juchuNoBtm, uh.denpyoHizuke, uh.tokuisakiCode ";


            sql = string.Empty;
            sql += "SELECT uh.tantousyaCode ";
            sql += "     , uh.tantousyaName ";
            sql += "     , CONCAT(uh.juchuNoTop, uh.juchuNoMid, uh.juchuNoBtm) AS juchuNo ";
            sql += "     , 1 AS edaban ";
            sql += "     , uh.denpyoHizuke ";
            sql += "     , MAX(jh.denpyoHizuke) AS juchuHizuke ";
            sql += "     , MAX(uh.tokuisakiCode) AS tokuisakiCode ";
            sql += "     , MAX(uh.jigyousyoCode) AS jigyousyoCode ";
            sql += "     , MAX(uh.tokuisakiName) AS tokuisakiName ";
            sql += "     , MAX(uh.jigyousyoName) AS jigyousyoName ";
            sql += "     , MAX(uh.kenmei1) AS kenmei1 ";
            sql += "     , SUM(IFNULL(ub.kingaku, 0)) AS kingaku ";
            sql += "     , '' AS shiresakiCode ";
            sql += "     , '' AS shiresakiName ";
            sql += "     , 0 AS shireKingaku ";
            sql += "     , NULL AS arariKingaku ";
            sql += "FROM (SELECT * FROM uriage_header WHERE (kanriKubun IS NULL OR kanriKubun = '') AND DATE_FORMAT(denpyoHizuke, '%Y%m') = '" + targetYM + "' ";
            if (!cmbAllValue.Equals(selectedTantousyaCode)) sql += "AND tantousyaCode = '" + selectedTantousyaCode + "' ";
            sql += ") uh ";
            sql += "INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            sql += "ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "INNER JOIN(SELECT* FROM juchu_header) jh ";
            sql += "ON(uh.juchuNoTop = jh.juchuNoTop AND uh.juchuNoMid = jh.juchuNoMid AND uh.juchuNoBtm = jh.juchuNoBtm) ";
            sql += "GROUP BY uh.tantousyaCode, uh.juchuNoTop, uh.juchuNoMid, uh.juchuNoBtm, uh.denpyoHizuke, uh.tokuisakiCode ";
            DataTable baseDt = registDb.executeLockSelect(sql);

            foreach (DataRow baseRow in baseDt.Rows)
            {
                sql = string.Empty;
                sql += "INSERT INTO uriage_syushi_ichiran ";
                sql += "( ";
                sql += "  tantousyaCode ";
                sql += ", tantousyaName ";
                sql += ", juchuNo ";
                sql += ", juchuNoEda ";
                sql += ", uriageHizuke ";
                sql += ", juchuHizuke ";
                sql += ", tokuisakiCode ";
                sql += ", jigyousyoCode ";
                sql += ", tokuisakiName ";
                sql += ", jigyousyoName ";
                sql += ", kenmei ";
                sql += ", uriageKingaku ";
                sql += ", shiresakiCode ";
                sql += ", shiresakiName ";
                sql += ", shireKingaku ";
                sql += ", arariKingaku ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += " '" + baseRow["tantousyaCode"] + "' ";
                sql += " , '" + baseRow["tantousyaName"] + "' ";
                sql += " , '" + baseRow["juchuNo"] + "' ";
                sql += " , " + baseRow["edaban"] + " ";
                sql += " , '" + baseRow["denpyoHizuke"] + "' ";
                sql += " , '" + baseRow["juchuHizuke"] + "' ";
                sql += " , '" + baseRow["tokuisakiCode"] + "' ";
                sql += " , '" + baseRow["jigyousyoCode"] + "' ";
                sql += " , '" + baseRow["tokuisakiName"] + "' ";
                sql += " , '" + baseRow["jigyousyoName"] + "' ";
                sql += " , '" + baseRow["kenmei1"] + "' ";
                sql += " , " + baseRow["kingaku"] + " ";
                sql += " , '' ";
                sql += " , '' ";
                sql += " , 0 ";
                sql += " , NULL ";
                sql += ") ";
                registDb.executeDBUpdate(sql);
            }

            // 仕入データ取得
            sql = string.Empty;
            sql += "SELECT sh.tantousyaCode ";
            sql += "     , sh.tantousyaName";
            sql += "     , CONCAT(sh.juchuNoTop, sh.juchuNoMid, sh.juchuNoBtm) AS juchuNo ";
            sql += "     , sh.denpyoHizuke ";
            sql += "     , sh.shiresakiCode ";
            sql += "     , sh.shiresakiName ";
            sql += "     , SUM(IFNULL(sb.kingaku, 0)) kingaku ";
            sql += "FROM (SELECT * FROM shire_header WHERE (kanriKubun IS NULL OR kanriKubun = '') AND DATE_FORMAT(denpyoHizuke, '%Y%m') = '" + targetYM + "' ";
            if (!cmbAllValue.Equals(selectedTantousyaCode)) sql += "AND tantousyaCode = '" + selectedTantousyaCode + "' ";
            sql += ") sh ";
            sql += "INNER JOIN (SELECT * FROM shire_body) sb ";
            sql += "ON (sh.shireNo = sb.shireNo) ";
            sql += "GROUP BY sh.tantousyaCode, sh.juchuNoTop, sh.juchuNoMid, sh.juchuNoBtm, sh.denpyoHizuke, sh.tokuisakiCode, sh.shiresakiCode ";
            sql += "ORDER BY sh.tantousyaCode, sh.juchuNoTop, sh.juchuNoMid, sh.juchuNoBtm, sh.shiresakiCode ";
            DataTable shireDt = registDb.executeLockSelect(sql);

            // 仕入データから売上収支表データを登録・更新
            int edaban = 0;
            string wkTantousyaCode = string.Empty;
            string wkTantousyaName = string.Empty;
            string wkJuchuNo = string.Empty;
            DateTime wkDenpyoHizuke = Convert.ToDateTime("1990-01-01");
            string wkShiresakiCode = string.Empty;
            string wkShiresakiName = string.Empty;
            decimal wkKingaku;
            DataTable syushiDt;
            foreach (DataRow shireRow in shireDt.Rows)
            {
                if (!wkTantousyaCode.Equals(Convert.ToString(shireRow["tantousyaCode"])) ||
                    !wkJuchuNo.Equals(Convert.ToString(shireRow["juchuNo"])) ||
                    !wkDenpyoHizuke.Equals(Convert.ToDateTime(shireRow["denpyoHizuke"])))
                {
                    edaban = 1;
                }
                else
                {
                    edaban++;
                }
                wkTantousyaCode = Convert.ToString(shireRow["tantousyaCode"]);
                wkTantousyaName = Convert.ToString(shireRow["tantousyaName"]);
                wkJuchuNo = Convert.ToString(shireRow["juchuNo"]);
                wkDenpyoHizuke = Convert.ToDateTime(shireRow["denpyoHizuke"]);
                wkShiresakiCode = Convert.ToString(shireRow["shiresakiCode"]);
                wkShiresakiName = Convert.ToString(shireRow["shiresakiName"]);
                decimal.TryParse(Convert.ToString(shireRow["kingaku"]), out wkKingaku);

                sql = string.Empty;
                sql += "SELECT 1 ";
                sql += "FROM uriage_syushi_ichiran ";
                sql += "WHERE tantousyaCode = '" + wkTantousyaCode + "' ";
                sql += "AND juchuNo = '" + wkJuchuNo + "' ";
                sql += "AND juchuNoEda = " + edaban + " ";
                sql += "AND uriageHizuke = '" + wkDenpyoHizuke + "' ";
                syushiDt = registDb.executeLockSelect(sql);

                sql = string.Empty;
                if (syushiDt == null || syushiDt.Rows.Count == 0)
                {
                    sql += "INSERT INTO uriage_syushi_ichiran ";
                    sql += "( ";
                    sql += "  tantousyaCode ";
                    sql += ", tantousyaName ";
                    sql += ", juchuNo ";
                    sql += ", juchuNoEda ";
                    sql += ", uriageHizuke ";
                    sql += ", juchuHizuke ";
                    sql += ", tokuisakiCode ";
                    sql += ", jigyousyoCode ";
                    sql += ", tokuisakiName ";
                    sql += ", jigyousyoName ";
                    sql += ", kenmei ";
                    sql += ", uriageKingaku ";
                    sql += ", shiresakiCode ";
                    sql += ", shiresakiName ";
                    sql += ", shireKingaku ";
                    sql += ", arariKingaku ";
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "( ";
                    sql += "  '" + wkTantousyaCode + "' ";
                    sql += ", '" + wkTantousyaName + "' ";
                    sql += ", '" + wkJuchuNo + "' ";
                    sql += ", " + edaban + " ";
                    sql += ", '" + wkDenpyoHizuke + "' ";
                    sql += ", NULL ";
                    sql += ", '' ";
                    sql += ", '' ";
                    sql += ", '' ";
                    sql += ", '' ";
                    sql += ", '' ";
                    sql += ", NULL ";
                    sql += ", '" + wkShiresakiCode + "' ";
                    sql += ", '" + wkShiresakiName + "' ";
                    sql += ", " + wkKingaku + " ";
                    sql += ", NULL ";
                    sql += ") ";
                }
                else
                {
                    sql += "UPDATE uriage_syushi_ichiran ";
                    sql += "SET shiresakiCode = '" + wkShiresakiCode + "' ";
                    sql += "  , shiresakiName = '" + wkShiresakiName + "' ";
                    sql += "  , shireKingaku = " + wkKingaku + " ";
                    sql += "WHERE tantousyaCode = '" + wkTantousyaCode + "' ";
                    sql += "AND juchuNo = '" + wkJuchuNo + "' ";
                    sql += "AND juchuNoEda = " + edaban + " ";
                    sql += "AND uriageHizuke = '" + wkDenpyoHizuke + "' ";
                }
                registDb.executeDBUpdate(sql);
            }

            // 売上収支表データの粗利益を更新
            sql = string.Empty;
            sql += "UPDATE uriage_syushi_ichiran usi, ";
            sql += "( ";
            sql += " SELECT maxEda.tantousyaCode ";
            sql += "      , maxEda.juchuNo ";
            sql += "      , maxEda.juchuNoEda ";
            sql += "      , maxEda.uriageHizuke ";
            sql += "      , maxEda.uriageKingakuTotal ";
            sql += "      , maxEda.shireKingakuTotal ";
            sql += " FROM ( ";
            sql += "       SELECT tantousyaCode ";
            sql += "            , juchuNo ";
            sql += "            , MAX(juchuNoEda) AS juchuNoEda ";
            sql += "            , uriageHizuke ";
            sql += "            , SUM(IFNULL(uriageKingaku, 0)) AS uriageKingakuTotal ";
            sql += "            , SUM(IFNULL(shireKingaku, 0)) AS shireKingakuTotal ";
            sql += "       FROM uriage_syushi_ichiran ";
            sql += "       GROUP BY tantousyaCode, juchuNo, uriageHizuke ";
            sql += "      ) maxEda ";
            sql += ") shiredata ";
            sql += "SET usi.arariKingaku = shiredata.uriageKingakuTotal - shiredata.shireKingakuTotal ";
            sql += "WHERE usi.tantousyaCode = shiredata.tantousyaCode ";
            sql += "AND usi.juchuNo = shiredata.juchuNo ";
            sql += "AND usi.juchuNoEda = shiredata.juchuNoEda ";
            sql += "AND usi.uriageHizuke = shiredata.uriageHizuke ";
            registDb.executeDBUpdate(sql);

            registDb.endTransaction();
        }
        #endregion

        #endregion
    }
}
