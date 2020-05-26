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
    ///支払予定表出力画面
    /// </summary>
    public partial class frmShiharaiYotei : ChildBaseForm
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

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmShiharaiYotei()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetDateYears.Text = string.Empty;
            txtTargetDateMonth.Text = string.Empty;
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
        private dtblShiharaiYotei getData()
        {
            dtblShiharaiYotei shiharaiYotei = new dtblShiharaiYotei();
            DBCommon selectDb = new DBCommon();
            string sql = string.Empty;
            int onePageRowCount = 18;

            string targetYM = txtTargetDateYears.Text;
            targetYM += ((Convert.ToInt16(txtTargetDateMonth.Text) < 10 ? "0" : string.Empty) + txtTargetDateMonth.Text);
            string targetYMD = targetYM + "01";
            sql += "SELECT sm.shiresakiCode AS shiireCd ";
            sql += "     , sm.shiresakiName AS shiireNm ";
            sql += "     , IFNULL(ss1.tougetsuKurikoshi, 0) AS zenZan ";
            sql += "     , IFNULL(ss2.tougetsuShire, 0) AS toZo ";
            sql += "     , IFNULL(ss3.shiharai, 0) AS shiharai ";
            sql += "     , IFNULL(ss1.tougetsuKurikoshi, 0) + IFNULL(ss2.tougetsuShire, 0) - IFNULL(ss3.shiharai, 0) AS toZan ";
            sql += "FROM  ";
            sql += "( ";
            sql += " SELECT shiresakiCode ";
            sql += "      , shiresakiName ";
            sql += "      , DATE_FORMAT(str_to_date( '" + targetYMD + "' ,  '%Y%m%d') - INTERVAL TRUNCATE((IFNULL(shiharaiSaito, 0) / 30) + 0.9, 0) MONTH - INTERVAL 1 DAY , '%Y%m' ) AS ss1Tuki ";
            sql += "      , DATE_FORMAT(str_to_date( '" + targetYMD + "' ,  '%Y%m%d') - INTERVAL TRUNCATE((IFNULL(shiharaiSaito, 0) / 30) + 0.9, 0) MONTH , '%Y%m' ) AS ss2Tuki ";
            sql += "      , '" + targetYM + "' AS ss3Tuki ";
            sql += " FROM shiresaki_master ";
            sql += " WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += ") sm ";
            sql += "LEFT JOIN ( ";
            sql += "           SELECT shiresakiCode AS shiresakiCode_ss1 ";
            sql += "                , nengetu ";
            sql += "                , tougetsuKurikoshi ";
            sql += "           FROM shiharai_seikyu ";
            sql += "          ) ss1 ";
            sql += "ON (sm.shiresakiCode = ss1.shiresakiCode_ss1 AND sm.ss1Tuki = ss1.nengetu) ";
            sql += "LEFT JOIN ( ";
            sql += "           SELECT shiresakiCode AS shiresakiCode_ss2 ";
            sql += "                , nengetu ";
            sql += "                , tougetsuShire ";
            sql += "           FROM shiharai_seikyu ";
            sql += "          ) ss2 ";
            sql += "ON (sm.shiresakiCode = ss2.shiresakiCode_ss2 AND sm.ss2Tuki = ss2.nengetu) ";
            sql += "LEFT JOIN ( ";
            sql += "           SELECT shiresakiCode AS shiresakiCode_ss3 ";
            sql += "                , nengetu ";
            sql += "                , IFNULL(tougetsuGenkin, 0) + IFNULL(tougetsuTegata, 0) + IFNULL(tougetsuHurikomi, 0) + IFNULL(tougetsuSousai, 0) AS shiharai ";
            sql += "           FROM shiharai_seikyu ";
            sql += "          ) ss3 ";
            sql += "ON (sm.shiresakiCode = ss3.shiresakiCode_ss3 AND sm.ss3Tuki = ss3.nengetu) ";
            sql += "WHERE (sm.shiresakiCode = ss1.shiresakiCode_ss1 ";
            sql += "    OR sm.shiresakiCode = ss2.shiresakiCode_ss2 ";
            sql += "    OR sm.shiresakiCode = ss3.shiresakiCode_ss3) ";
            DataTable dt = selectDb.executeNoneLockSelect(sql);

            decimal zenZanG = decimal.Zero, toZoG = decimal.Zero, shiharaiG = decimal.Zero, toZanG = decimal.Zero;
            decimal zenZan = decimal.Zero, toZo = decimal.Zero, shiharai = decimal.Zero, toZan = decimal.Zero;
            DataRow newRow;
            foreach (DataRow row in dt.Rows)
            {
                newRow = shiharaiYotei.Tables["dtblShiharaiYotei"].NewRow();

                decimal.TryParse(Convert.ToString(row["zenZan"]), out zenZan);
                decimal.TryParse(Convert.ToString(row["toZo"]), out toZo);
                decimal.TryParse(Convert.ToString(row["shiharai"]), out shiharai);
                decimal.TryParse(Convert.ToString(row["toZan"]), out toZan);
                zenZanG += zenZan;
                toZoG += toZo;
                shiharaiG += shiharai;
                toZanG += toZan;

                newRow["nen"] = txtTargetDateYears.Text;
                newRow["tuki"] = txtTargetDateMonth.Text;
                newRow["shiireCd"] = Convert.ToString(row["shiireCd"]);
                newRow["shiireNm"] = Convert.ToString(row["shiireNm"]);
                newRow["zenZan"] = zenZan.ToString("#,##0");
                newRow["toZo"] = toZo.ToString("#,##0");
                newRow["shiharai"] = shiharai.ToString("#,##0");
                newRow["toZan"] = toZan.ToString("#,##0");

                shiharaiYotei.Tables["dtblShiharaiYotei"].Rows.Add(newRow.ItemArray);
            }

            int addCount = onePageRowCount - ((shiharaiYotei.Tables["dtblShiharaiYotei"].Rows.Count + 1) % onePageRowCount);
            if (addCount == onePageRowCount) addCount = 0;

            while (addCount > 0)
            {
                addCount--;
                newRow = shiharaiYotei.Tables["dtblShiharaiYotei"].NewRow();
                newRow["nen"] = txtTargetDateYears.Text;
                newRow["tuki"] = txtTargetDateMonth.Text;
                shiharaiYotei.Tables["dtblShiharaiYotei"].Rows.Add(newRow.ItemArray);
            }

            newRow = shiharaiYotei.Tables["dtblShiharaiYoteiG"].NewRow();
            newRow["nen"] = txtTargetDateYears.Text;
            newRow["tuki"] = txtTargetDateMonth.Text;
            newRow["zenZanG"] = zenZanG.ToString("#,##0");
            newRow["toZoG"] = toZoG.ToString("#,##0");
            newRow["shiharaiG"] = shiharaiG.ToString("#,##0");
            newRow["toZanG"] = toZanG.ToString("#,##0");
            shiharaiYotei.Tables["dtblShiharaiYoteiG"].Rows.Add(newRow.ItemArray);

            return shiharaiYotei;
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
            dtblShiharaiYotei shiharaiYotei = getData();
            if (shiharaiYotei.Tables["dtblShiharaiYotei"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptShiharaiYotei1.SetDataSource(shiharaiYotei);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptShiharaiYotei1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptShiharaiYotei1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptShiharaiYotei1.PrintOptions.PaperOrientation)
                                                                     , rptShiharaiYotei1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptShiharaiYotei1.PrintToPrinter(printerSettings
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

            // 入力制御イベント設定
            txtTargetDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(年):数字のみ入力可
            txtTargetDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月(月):数字のみ入力可
        }
        #endregion

        #endregion
    }
}
