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
    /// 受発注一覧出力画面
    /// </summary>
    public partial class frmJyuchachuIchiran : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , TargetYm = 1
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
        public frmJyuchachuIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtTargetYmYears.Text = string.Empty;
            txtTargetYmMonth.Text = string.Empty;
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

        #region 対象年月フォーカスインイベント
        /// <summary>
        /// 対象年月フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYm_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYm)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月フォーカスアウトイベント
        /// <summary>
        /// 見積日付(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYm_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYm;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYm;
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
                    case LastInputDateType.TargetYm:
                        y = txtTargetYmYears.Text;
                        m = txtTargetYmMonth.Text;
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
                    else if (LastInputDateType.TargetYm.Equals(lastInputDateType))
                    {
                        txtTargetYmYears.Focus();
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

            // 対象年月Fromの場合
            if (c.Name.Equals(txtTargetYmYears.Name) ||
                c.Name.Equals(txtTargetYmMonth.Name) ||
                c.Name.Equals(dtpTargetYm.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetYm_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetYm_Leave);
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
        private DataTable getData()
        {
            string sql = string.Empty;

            DateTime denpyoHizukeFrom = Convert.ToDateTime(txtTargetYmYears.Text + "/" + txtTargetYmMonth.Text + "/" + "01");
            DateTime denpyoHizukeTo = Convert.ToDateTime(txtTargetYmYears.Text + "/" + txtTargetYmMonth.Text + "/" + commonLogic.GetEndOfMonth(txtTargetYmYears.Text, txtTargetYmMonth.Text));

            sql += "SELECT '" + txtTargetYmYears.Text + "' AS syoriNen ";
            sql += "     , '" + txtTargetYmMonth.Text + "' AS syoriTuki ";
            sql += "     , CONCAT(juchu.juchuNoTop, juchu.juchuNoMid, juchu.juchuNoBtm) AS jyuchuNo ";
            sql += "     , juchu.denpyoHizuke                                           AS date ";
            sql += "     , juchu.tokuisakiName                                          AS tokuisakiNm ";
            sql += "     , juchu.jigyousyoName                                          AS jigyosyoNm ";
            sql += "     , juchu.kenmei1                                                AS kenNm1 ";
            sql += "     , juchu.kenmei2                                                AS kenNm2 ";
            sql += "     , FORMAT(juchu.juchuKingaku ,0)                                AS jyuchuKingaku ";
            sql += "     , juchu.tantousyaName                                          AS tantousya ";
            sql += "     , IFNULL(hachu.hachuNo, '')                                    AS hachuNo ";
            sql += "     , IFNULL(hachu.shiresakiName, '')                              AS siiresakiNm ";
            sql += "     , FORMAT(IFNULL(hachu.shireKingaku, '') ,0)                    AS hachukingaku ";
            sql += "FROM ";
            sql += "( ";
            sql += "  SELECT jh.juchuNoTop ";
            sql += "       , jh.juchuNoMid ";
            sql += "       , jh.juchuNoBtm ";
            sql += "       , jh.denpyoHizuke ";
            sql += "       , jh.tokuisakiName ";
            sql += "       , jh.jigyousyoName ";
            sql += "       , jh.kenmei1 ";
            sql += "       , jh.kenmei2 ";
            sql += "       , jb.juchuKingaku ";
            sql += "       , jh.tantousyaName ";
            sql += "       , jb.shiresakiCode ";
            sql += "  FROM( ";
            sql += "         SELECT juchuNoTop, juchuNoMid, juchuNoBtm, shiresakiCode, SUM(IFNULL(juchuKingaku, 0)) AS juchuKingaku ";
            sql += "         FROM juchu_body ";
            sql += "         WHERE kanriKubun IS NULL OR kanriKubun <> '9' ";
            sql += "         GROUP BY juchuNoTop, juchuNoMid, juchuNoBtm, shiresakiCode ";
            sql += "       ) jb ";
            sql += "       INNER JOIN ";
            sql += "       ( ";
            sql += "         SELECT * ";
            sql += "         FROM juchu_header ";
            sql += "         WHERE kanriKubun IS NULL OR kanriKubun <> '9' ";
            sql += "       ) jh ";
            sql += "       ON(jb.juchuNoTop = jh.juchuNoTop AND jb.juchuNoMid = jh.juchuNoMid AND jb.juchuNoBtm = jh.juchuNoBtm) ";
            sql += ") juchu ";
            sql += "LEFT JOIN ";
            sql += "( ";
            sql += "  SELECT hh.hachuNo ";
            sql += "       , hh.shiresakiName ";
            sql += "       , hb.shireKingaku ";
            sql += "       , hh.juchuNoTop ";
            sql += "       , hh.juchuNoMid ";
            sql += "       , hh.juchuNoBtm ";
            sql += "       , hh.shiresakiCode ";
            sql += "  FROM( ";
            sql += "         SELECT hachuNo, SUM(IFNULL(kingaku, 0)) AS shireKingaku ";
            sql += "         FROM hachu_body ";
            sql += "         WHERE kanriKubun IS NULL OR kanriKubun <> '9' ";
            sql += "         GROUP BY hachuNo ";
            sql += "       ) hb ";
            sql += "       INNER JOIN ";
            sql += "       ( ";
            sql += "         SELECT * ";
            sql += "         FROM hachu_header ";
            sql += "         WHERE kanriKubun IS NULL OR kanriKubun <> '9' ";
            sql += "       ) hh ";
            sql += "       ON(hb.hachuNo = hh.hachuNo) ";
            sql += ") hachu ";
            sql += "ON(juchu.juchuNoTop = hachu.juchuNoTop ";
            sql += "AND juchu.juchuNoMid = hachu.juchuNoMid ";
            sql += "AND juchu.juchuNoBtm = hachu.juchuNoBtm ";
            sql += "AND juchu.shiresakiCode = hachu.shiresakiCode) ";
            sql += "WHERE juchu.denpyoHizuke >= '" + denpyoHizukeFrom + "' ";
            sql += "AND juchu.denpyoHizuke <= '" + denpyoHizukeTo + "' ";
            sql += "ORDER BY CONCAT(juchu.juchuNoTop, juchu.juchuNoMid, juchu.juchuNoBtm), juchu.shiresakiCode ";

            DBCommon selectDb = new DBCommon();
            return selectDb.executeNoneLockSelect(sql).Copy();
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtTargetYmYears.Text) ||
                string.IsNullOrEmpty(txtTargetYmMonth.Text))
            {
                errorOK(string.Format(Messages.M0020, lblTargetYm.Text));
                return;
            }
            DataTable juhachuList = getData();
            if (juhachuList == null || juhachuList.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "対象年月のデータ"));
                return;
            }
            dtblJyuhaccyuIchiran juhachuIchiran = new dtblJyuhaccyuIchiran();
            foreach (DataRow row in juhachuList.Rows)
            {
                juhachuIchiran.Tables["dtblJyuhaccyuIchiran"].Rows.Add(row.ItemArray);
            }
            rptJyuchachuIchiran1.SetDataSource(juhachuIchiran.Tables["dtblJyuhaccyuIchiran"]);

            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptJyuchachuIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptJyuchachuIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptJyuchachuIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptJyuchachuIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptJyuchachuIchiran1.PrintToPrinter(printerSettings
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
            txtTargetYmYears.MaxLength = 4; // 対象年月(年)
            txtTargetYmMonth.MaxLength = 2; // 対象年月(月)

            // 入力制御イベント設定
            txtTargetYmYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(年):数字のみ入力可
            txtTargetYmMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(月):数字のみ入力可
        }
        #endregion

        #endregion
    }
}
