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
    ///得意先別売掛一覧出力画面
    /// </summary>
    public partial class frmTokuisakiUrikakeIchiran : ChildBaseForm
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
        private string dummyCode = "Dummy";

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmTokuisakiUrikakeIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetDateYears.Text = string.Empty;
            txtTargetDateMonth.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            cmbOffices.Text = string.Empty;
            commonLogic = new CommonLogic();
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

        #region 年月フォーカスインイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 年月フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDate_Leave(object sender, EventArgs e)
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
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
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

        #region 得意先コードのフォーカスアウトイベント
        /// <summary>
        /// 得意先コードのフォーカスアウトイベント
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
                txtCustomerName.Text = string.Empty;
                setOfficesCmb(dummyCode, string.Empty);
            }
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

            // 年月の場合
            if (c.Name.Equals(txtTargetDateYears.Name) ||
                c.Name.Equals(txtTargetDateMonth.Name) ||
                c.Name.Equals(dtpTargetDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetDate_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCd_Leave);
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
        private dtblTokuisakibetuUrikakeichiran getData()
        {
            dtblTokuisakibetuUrikakeichiran result = new dtblTokuisakibetuUrikakeichiran();

            DBCommon db = new DBCommon();
            DateTime targetDate = Convert.ToDateTime(txtTargetDateYears.Text + "-" + txtTargetDateMonth.Text + "-01");
            string nendo = targetDate.Month >= 10 ? Convert.ToString(targetDate.Year) : Convert.ToString(targetDate.Year - 1);
            string tuki = Convert.ToString(targetDate.Month);
            string tokuisakiCode = txtCustomerCode.Text;
            string jigyouysoCode = Convert.ToString(cmbOffices.SelectedValue);
            string sql = string.Empty;
            sql += "SELECT tu.nen " + "\r";
            sql += "     , tu.tuki " + "\r";
            sql += "     , tu.tokuisakiCd " + "\r";
            sql += "     , tu.tokuisakiNm " + "\r";
            sql += "     , tu.jigyoushoNm " + "\r";
            sql += "     , tu.zenngetuKkoshi " + "\r";
            sql += "     , tu.togetuNyukin " + "\r";
            sql += "     , tu.togetuUriage " + "\r";
            sql += "     , tu.togetuShohizei " + "\r";
            sql += "     , tu.togetuKurikoshi " + "\r";
            sql += "     , tu.flgChild " + "\r";
            sql += "FROM ( " + "\r";
            sql += "      SELECT " + txtTargetDateYears.Text + " AS nen " + "\r";
            sql += "           , " + tuki + " AS tuki " + "\r";
            sql += "           , tm.tokuisakiCode AS tokuisakiCd " + "\r";
            sql += "           , tm.jigyousyoCode AS jigyoushoCd " + "\r";
            sql += "           , tm.tokuisakiName AS tokuisakiNm " + "\r";
            sql += "           , tm.jigyousyoName AS jigyoushoNm " + "\r";
            sql += "           , SUM(tu." + tuki + "GatsuZenKurikoshi) AS zenngetuKkoshi " + "\r";
            sql += "           , SUM(tu." + tuki + "GatsuNyukin) AS togetuNyukin " + "\r";
            sql += "           , SUM(tu." + tuki + "GatsuUriage) AS togetuUriage " + "\r";
            sql += "           , SUM(tu." + tuki + "GatsuShouhiZei) AS togetuShohizei " + "\r";
            sql += "           , SUM(tu." + tuki + "GatsuKurikoshi) AS togetuKurikoshi " + "\r";
            sql += "           , 0 AS flgChild " + "\r";
            sql += "      FROM (SELECT * " + "\r";
            sql += "            FROM tokuisaki_urikake " + "\r";
            sql += "            WHERE nendo = '" + nendo + "' " + "\r";
            if (!string.IsNullOrEmpty(tokuisakiCode)) sql += "      AND tokuisakiCode = '" + tokuisakiCode + "' " + "\r";
            if (!string.IsNullOrEmpty(jigyouysoCode)) sql += "      AND jigyousyoCode = '" + jigyouysoCode + "' " + "\r";
            sql += "           ) tu " + "\r";
            sql += "      INNER JOIN (SELECT * FROM tokuisaki_master WHERE IFNULL(seikyusakiCode, '') = '' AND IFNULL(seikyusakiJigyousyoCode, '') = '') tm " + "\r";
            sql += "      ON (tu.tokuisakiCode = tm.tokuisakiCode) " + "\r";
            sql += "      GROUP BY (tu.tokuisakiCode) " + "\r";
            sql += "      UNION ALL " + "\r";
            sql += "      SELECT " + txtTargetDateYears.Text + " AS nen " + "\r";
            sql += "           , " + tuki + " AS tuki " + "\r";
            sql += "           , tu.tokuisakiCode AS tokuisakiCd " + "\r";
            sql += "           , tu.jigyousyoCode AS jigyoushoCd " + "\r";
            sql += "           , tm.tokuisakiName AS tokuisakiNm " + "\r";
            sql += "           , tm.jigyousyoName AS jigyoushoNm " + "\r";
            sql += "           , NULL AS zenngetuKkoshi " + "\r";
            sql += "           , NULL AS togetuNyukin " + "\r";
            sql += "           , tu." + tuki + "GatsuUriage AS togetuUriage " + "\r";
            sql += "           , tu." + tuki + "GatsuShouhiZei AS togetuShohizei " + "\r";
            sql += "           , NULL AS togetuKurikoshi " + "\r";
            sql += "           , 1 AS flgChild " + "\r";
            sql += "      FROM (SELECT * " + "\r";
            sql += "            FROM tokuisaki_urikake " + "\r";
            sql += "            WHERE nendo = '" + nendo + "' " + "\r";
            if (!string.IsNullOrEmpty(tokuisakiCode)) sql += "      AND tokuisakiCode = '" + tokuisakiCode + "' " + "\r";
            if (!string.IsNullOrEmpty(jigyouysoCode)) sql += "      AND jigyousyoCode = '" + jigyouysoCode + "' " + "\r";
            sql += "           ) tu " + "\r";
            sql += "      INNER JOIN (SELECT * FROM tokuisaki_master WHERE IFNULL(seikyusakiCode, '') <> '' OR IFNULL(seikyusakiJigyousyoCode, '') <> '') tm " + "\r";
            sql += "      ON (tu.tokuisakiCode = tm.tokuisakiCode AND tu.jigyousyoCode = tm.jigyousyoCode) " + "\r";
            sql += "     ) tu " + "\r";
            sql += "WHERE ( " + "\r";
            sql += "      tu.zenngetuKkoshi <> 0 " + "\r";
            sql += "   OR tu.togetuNyukin <> 0 " + "\r";
            sql += "   OR tu.togetuUriage <> 0 " + "\r";
            sql += "   OR tu.togetuShohizei <> 0 " + "\r";
            sql += "   OR tu.togetuKurikoshi <> 0 " + "\r";
            sql += "      ) " + "\r";
            sql += "ORDER BY tu.nen, tu.tuki, tu.tokuisakiCd, tu.jigyoushoCd " + "\r";
            DataTable dt = db.executeNoneLockSelect(sql);

            DataRow newRow;
            DataRow row;
            DataRow lastRow;
            bool flgChild = false;
            decimal dec;
            decimal totalZenngetuKkoshi = decimal.Zero;
            decimal totalTogetuNyukin = decimal.Zero;
            decimal totalTogetuUriage = decimal.Zero;
            decimal totalTogetuShohizei = decimal.Zero;
            decimal totalTogetuKurikoshi = decimal.Zero;
            int maxRow = 14;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                flgChild = Convert.ToInt16(row["flgChild"]) == 1 ? true : false;
                newRow = result.Tables["dtblTokuisakibetuUrikakeichiran"].NewRow();
                newRow["nen"] = Convert.ToString(row["nen"]);
                newRow["tuki"] = Convert.ToString(row["tuki"]);
                if (!flgChild) newRow["tokuisakiCd"] = Convert.ToString(row["tokuisakiCd"]);
                newRow["tokuisakiNm"] = Convert.ToString(row["tokuisakiNm"]);
                newRow["jigyoushoNm"] = Convert.ToString(row["jigyoushoNm"]);
                if (!flgChild)
                {
                    decimal.TryParse(Convert.ToString(row["zenngetuKkoshi"]), out dec);
                    newRow["zenngetuKkoshi"] = dec.ToString("#,##0");
                    totalZenngetuKkoshi += dec;
                }
                if (!flgChild)
                {
                    decimal.TryParse(Convert.ToString(row["togetuNyukin"]), out dec);
                    newRow["togetuNyukin"] = dec.ToString("#,##0");
                    totalTogetuNyukin += dec;
                }
                decimal.TryParse(Convert.ToString(row["togetuUriage"]), out dec);
                newRow["togetuUriage"] = dec.ToString("#,##0");
                if (!flgChild) totalTogetuUriage += dec;
                decimal.TryParse(Convert.ToString(row["togetuShohizei"]), out dec);
                newRow["togetuShohizei"] = dec.ToString("#,##0");
                if (!flgChild) totalTogetuShohizei += dec;
                if (!flgChild)
                {
                    decimal.TryParse(Convert.ToString(row["togetuKurikoshi"]), out dec);
                    newRow["togetuKurikoshi"] = dec.ToString("#,##0");
                    totalTogetuKurikoshi += dec;
                }
                result.Tables["dtblTokuisakibetuUrikakeichiran"].Rows.Add(newRow.ItemArray);

                if (i + 1 == dt.Rows.Count)
                {
                    int cnt = maxRow - (result.Tables["dtblTokuisakibetuUrikakeichiran"].Rows.Count % maxRow);
                    while (cnt > 0)
                    {
                        result.Tables["dtblTokuisakibetuUrikakeichiran"].Rows.Add();
                        cnt--;
                    }
                    result.Tables["dtblTokuisakibetuUrikakeichiran"].AcceptChanges();
                    lastRow = result.Tables["dtblTokuisakibetuUrikakeichiran"].Rows[result.Tables["dtblTokuisakibetuUrikakeichiran"].Rows.Count - 1];
                    lastRow["tokuisakiNm"] = "合計";
                    lastRow["zenngetuKkoshi"] = totalZenngetuKkoshi.ToString("#,##0");
                    lastRow["togetuNyukin"] = totalTogetuNyukin.ToString("#,##0");
                    lastRow["togetuUriage"] = totalTogetuUriage.ToString("#,##0");
                    lastRow["togetuShohizei"] = totalTogetuShohizei.ToString("#,##0");
                    lastRow["togetuKurikoshi"] = totalTogetuKurikoshi.ToString("#,##0");
                }
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

            // 得意先別売掛ファイル更新処理実行
            registTokuisakiUrikake();

            // 帳票出力データ取得処理実行
            dtblTokuisakibetuUrikakeichiran urikakeIchiran = getData();
            if (urikakeIchiran.Tables["dtblTokuisakibetuUrikakeichiran"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptTokuisakibetuUrikakeIchiran1.SetDataSource(urikakeIchiran);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptTokuisakibetuUrikakeIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptTokuisakibetuUrikakeIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptTokuisakibetuUrikakeIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptTokuisakibetuUrikakeIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptTokuisakibetuUrikakeIchiran1.PrintToPrinter(printerSettings
                                                                 , pageSettings
                                                                 , false);

                }
            }
            else
            {
                printView.Size = new Size(1180, 945);
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
            txtCustomerCode.MaxLength = 5;      // 得意先ｺｰﾄﾞ
            cmbOffices.MaxLength = 10;          // 事業所

            // 入力制御イベント設定
            txtTargetDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(年):数字のみ入力可
            txtTargetDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(月):数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 得意先ｺｰﾄﾞ  :数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
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
                    txtCustomerName.Enabled = false;
                    txtCustomerName.Text = string.Empty;
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
                    txtCustomerName.Enabled = false;
                }
                // 事業所コンボボックスの再設定
                setOfficesCmb(tokuisakiCode, jigyousyoCode);
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
            cmbOffices.BeforeSelectedValue = Convert.ToString(cmbOffices.SelectedValue);

            return true;
        }
        #endregion

        #region 得意先別売掛ファイル更新処理
        /// <summary>
        /// 得意先別売掛ファイル更新処理
        /// </summary>
        private void registTokuisakiUrikake()
        {
            string sql = string.Empty;
            DBCommon db = new DBCommon();

            db.startTransaction();

            string tokuisakiCode = txtCustomerCode.Text;
            string jigyousyoCode = Convert.ToString(cmbOffices.SelectedValue);
            string chikuCode;
            DateTime targetDateFrom = Convert.ToDateTime(txtTargetDateYears.Text + "-" + txtTargetDateMonth.Text + "-01");
            DateTime targetDateTo = Convert.ToDateTime(txtTargetDateYears.Text + "-" + txtTargetDateMonth.Text + "-" + commonLogic.GetEndOfMonth(txtTargetDateYears.Text, txtTargetDateMonth.Text));
            string nendo = targetDateFrom.Month >= 10 ? Convert.ToString(targetDateFrom.Year) : Convert.ToString(targetDateFrom.Year - 1);
            DateTime zengetuDate = targetDateFrom.AddMonths(-1);
            string zengetuNendo = zengetuDate.Month >= 10 ? Convert.ToString(zengetuDate.Year) : Convert.ToString(zengetuDate.Year - 1);
            string zengetu = Convert.ToString(zengetuDate.Month);

            #region 得意先情報取得
            sql += "SELECT * FROM tokuisaki_master WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            if (!string.IsNullOrEmpty(tokuisakiCode)) sql += "AND tokuisakiCode = '" + tokuisakiCode + "'";
            if (!string.IsNullOrEmpty(jigyousyoCode)) sql += "AND jigyousyoCode = '" + jigyousyoCode + "'";
            DataTable tokuisakiDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 得意先別売掛ファイルの登録
            string[] monthList = { "10", "11", "12", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            DataTable dt;
            foreach (DataRow tokuisakiRow in tokuisakiDt.Rows)
            {
                chikuCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcChikuCode]);
                tokuisakiCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                jigyousyoCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                sql = string.Empty;
                sql += "SELECT 1 FROM tokuisaki_urikake ";
                sql += "WHERE chikuCode = '" + chikuCode + "'";
                sql += "AND tokuisakiCode = '" + tokuisakiCode + "'";
                sql += "AND jigyousyoCode = '" + jigyousyoCode + "'";
                sql += "AND nendo = '" + nendo + "'";
                dt = db.executeNoneLockSelect(sql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    sql = string.Empty;
                    sql += "INSERT INTO tokuisaki_urikake ";
                    sql += "(";
                    sql += "  chikuCode ";
                    sql += ", tokuisakiCode ";
                    sql += ", jigyousyoCode ";
                    sql += ", nendo ";
                    foreach (string month in monthList)
                    {
                        sql += ", " + month + "GatsuZenKurikoshi ";
                        sql += ", " + month + "GatsuUriage ";
                        sql += ", " + month + "GatsuShouhiZei ";
                        sql += ", " + month + "GatsuNyukin ";
                        sql += ", " + month + "GatsuKurikoshi ";
                    }
                    sql += ") ";
                    sql += "VALUES ";
                    sql += "(";
                    sql += "  '" + chikuCode + "' ";
                    sql += ", '" + tokuisakiCode + "' ";
                    sql += ", '" + jigyousyoCode + "' ";
                    sql += ", '" + nendo + "' ";
                    foreach (string month in monthList)
                    {
                        sql += ", 0 ";
                        sql += ", 0 ";
                        sql += ", 0 ";
                        sql += ", 0 ";
                        sql += ", 0 ";
                    }
                    sql += ") ";
                    db.executeDBUpdate(sql);
                }
            }
            #endregion

            #region 得意先別売掛ファイル更新用の金額を集計して取得
            sql = string.Empty;
            sql += "SELECT tul.* " + "\r";
            sql += "     , tul.zengetsuKurikoshi - tul.nyukin + tul.uriage + tul.uriageSyouhizei AS tougetsuKurikoshi " + "\r";
            sql += "FROM ( " + "\r";
            sql += "      SELECT tm.chikuCode " + "\r";
            sql += "           , ud.tokuisakiCode " + "\r";
            sql += "           , ud.jigyousyoCode " + "\r";
            sql += "           , ud.kingaku AS uriage " + "\r";
            sql += "           , CASE tm.nouhinsyoSyohizeiKubun " + "\r";
            sql += "               WHEN '1' THEN IFNULL(ud.syouhizei, 0) " + "\r";
            sql += "               ELSE CASE IFNULL(tm.syohizeiHasuKubun, '2') " + "\r";
            sql += "                      WHEN '0' THEN truncate(ud.kingaku * 10 / 100, 0) " + "\r";
            sql += "                      WHEN '1' THEN TRUNCATE((ud.kingaku * 10 / 100) + 0.9, 0) " + "\r";
            sql += "                      ELSE TRUNCATE((ud.kingaku * 10 / 100) + 0.5, 0) " + "\r";
            sql += "                    END " + "\r";
            sql += "             END AS uriageSyouhizei " + "\r";
            sql += "           , IFNULL(n.goukei, 0) AS nyukin " + "\r";
            sql += "           , IFNULL(tu." + zengetu + "GatsuKurikoshi, 0) AS zengetsuKurikoshi " + "\r";
            sql += "      FROM " + "\r";
            sql += "      ( " + "\r";
            sql += "       SELECT uh.tokuisakiCode AS tokuisakiCode " + "\r";
            sql += "            , uh.jigyousyoCode AS jigyousyoCode " + "\r";
            sql += "            , SUM(IFNULL(ub.kingaku, 0)) AS kingaku " + "\r";
            sql += "            , SUM(IFNULL(uf.syouhizei, 0)) AS syouhizei " + "\r";
            sql += "       FROM ( " + "\r";
            sql += "             SELECT * " + "\r";
            sql += "             FROM uriage_header " + "\r";
            sql += "             WHERE (kanriKubun IS NULL OR kanriKubun <> '9') " + "\r";
            sql += "             AND denpyoHizuke >= '" + targetDateFrom + "' " + "\r";
            sql += "             AND denpyoHizuke <= '" + targetDateTo + "' " + "\r";
            sql += "            ) uh " + "\r";
            sql += "       INNER JOIN ( " + "\r";
            sql += "                   SELECT * " + "\r";
            sql += "                   FROM uriage_body " + "\r";
            sql += "                   WHERE IFNULL(flgPrint, 0) = 1 " + "\r";
            sql += "                  ) ub " + "\r";
            sql += "       ON (uh.denpyoNo = ub.denpyoNo) " + "\r";
            sql += "       INNER JOIN (SELECT * FROM uriage_footer) uf " + "\r";
            sql += "       ON (uh.denpyoNo = uf.denpyoNo) " + "\r";
            sql += "       GROUP BY uh.tokuisakiCode, uh.jigyousyoCode " + "\r";
            sql += "      ) ud " + "\r";
            sql += "      INNER JOIN (SELECT * FROM tokuisaki_master) tm " + "\r";
            sql += "      ON (ud.tokuisakiCode = tm.tokuisakiCode AND ud.jigyousyoCode = tm.jigyousyoCode) " + "\r";
            sql += "      LEFT JOIN (SELECT tokuisakiCode " + "\r";
            sql += "                      , jigyousyoCode " + "\r";
            sql += "                      , SUM(IFNULL(goukei, 0)) AS goukei " + "\r";
            sql += "                 FROM nyukin " + "\r";
            sql += "                 WHERE nyukinHizuke >= '" + targetDateFrom + "' " + "\r";
            sql += "                 AND nyukinHizuke <= '" + targetDateTo + "' " + "\r";
            sql += "                 GROUP BY tokuisakiCode, jigyousyoCode) n " + "\r";
            sql += "      ON (ud.tokuisakiCode = n.tokuisakiCode AND ud.jigyousyoCode = n.jigyousyoCode) " + "\r";
            sql += "      LEFT JOIN (SELECT * FROM tokuisaki_urikake WHERE nendo = '" + zengetuNendo + "') tu " + "\r";
            sql += "      ON (ud.tokuisakiCode = tu.tokuisakiCode AND ud.jigyousyoCode = tu.jigyousyoCode) " + "\r";
            sql += ") tul " + "\r";
            sql += "WHERE 1 = 1 " + "\r";
            sql += "AND (" + "\r";
            int tokuisakiCount = 0;
            foreach (DataRow tokuisakiRow in tokuisakiDt.Rows)
            {
                tokuisakiCount++;
                chikuCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcChikuCode]);
                tokuisakiCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                jigyousyoCode = Convert.ToString(tokuisakiRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                if (tokuisakiCount > 1) sql += " OR ";
                sql += "(tul.chikuCode = '" + chikuCode + "' AND tul.tokuisakiCode = '" + tokuisakiCode + "' AND tul.jigyousyoCode = '" + jigyousyoCode + "') " + "\r";
            }
            sql += ") " + "\r";
            DataTable urikakeList = db.executeNoneLockSelect(sql);
            #endregion

            #region 得意先別売掛ファイルの更新
            foreach (DataRow urikakeRow in urikakeList.Rows)
            {
                chikuCode = Convert.ToString(urikakeRow[DBFileLayout.TokuisakiMasterFile.dcChikuCode]);
                tokuisakiCode = Convert.ToString(urikakeRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                jigyousyoCode = Convert.ToString(urikakeRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                sql = string.Empty;
                sql += "UPDATE tokuisaki_urikake ";
                sql += "SET " + txtTargetDateMonth.Text + "GatsuZenKurikoshi = " + urikakeRow["zengetsuKurikoshi"] + " ";
                sql += "  , " + txtTargetDateMonth.Text + "GatsuUriage = " + urikakeRow["uriage"] + " ";
                sql += "  , " + txtTargetDateMonth.Text + "GatsuShouhiZei = " + urikakeRow["uriageSyouhizei"] + " ";
                sql += "  , " + txtTargetDateMonth.Text + "GatsuNyukin = " + urikakeRow["nyukin"] + " ";
                sql += "  , " + txtTargetDateMonth.Text + "GatsuKurikoshi = " + urikakeRow["tougetsuKurikoshi"] + " ";
                sql += "WHERE chikuCode = '" + chikuCode + "' ";
                sql += "AND tokuisakiCode = '" + tokuisakiCode + "' ";
                sql += "AND jigyousyoCode = '" + jigyousyoCode + "' ";
                sql += "AND nendo = '" + nendo + "' ";
                db.executeDBUpdate(sql);
            }
            #endregion

            db.endTransaction();
        }
        #endregion

        #endregion
    }
}
