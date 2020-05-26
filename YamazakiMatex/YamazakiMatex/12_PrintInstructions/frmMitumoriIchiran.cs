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
    /// 見積一覧出力画面
    /// </summary>
    public partial class frmMitumoriIchiran : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private enum LastInputDateType
        {
            None = 0
          , EstimateDateFrom = 1
          , EstimateDateTo = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;

        /// <summary>
        /// データ取得区分
        /// </summary>
        public enum GetDataType
        {
            Display = 0,
            Print = 1
        }

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmMitumoriIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            txtEstimateNoFrom.Text = string.Empty;
            txtEstimateNoTo.Text = string.Empty;
            txtEstimateDateFromYears.Text = string.Empty;
            txtEstimateDateFromMonth.Text = string.Empty;
            txtEstimateDateFromDays.Text = string.Empty;
            txtEstimateDateToYears.Text = string.Empty;
            txtEstimateDateToMonth.Text = string.Empty;
            txtEstimateDateToDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerKanaName.Text = string.Empty;
            setGridData();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
            txtCustomerKanaName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);               // 得意先カナ名       :入力文字数のバイトチェック
        }
        #endregion

        #region 一覧表示ボタン押下イベント
        /// <summary>
        /// 一覧表示ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDispList_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
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

        #region 見積日付(FROM)フォーカスアウトイベント
        /// <summary>
        /// 見積日付(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.EstimateDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.EstimateDateFrom;
            }
        }
        #endregion

        #region 見積日付(TO)フォーカスアウトイベント
        /// <summary>
        /// 見積日付(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.EstimateDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.EstimateDateTo;
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
                    case LastInputDateType.EstimateDateFrom:
                        y = txtEstimateDateFromYears.Text;
                        m = txtEstimateDateFromMonth.Text;
                        d = txtEstimateDateFromDays.Text;
                        break;
                    case LastInputDateType.EstimateDateTo:
                        y = txtEstimateDateToYears.Text;
                        m = txtEstimateDateToMonth.Text;
                        d = txtEstimateDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.EstimateDateFrom.Equals(lastInputDateType))
                    {
                        txtEstimateDateFromYears.Focus();
                    }
                    else if (LastInputDateType.EstimateDateTo.Equals(lastInputDateType))
                    {
                        txtEstimateDateToYears.Focus();
                    }
                    return;
                }
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
        }
        #endregion

        #region 見積日付(FROM)フォーカスインイベント
        /// <summary>
        /// 見積日付(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.EstimateDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 見積日付(TO)フォーカスインイベント
        /// <summary>
        /// フ見積日付(TO)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.EstimateDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 見積Noフォーカスアウトイベント
        /// <summary>
        /// 見積Noフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstimateNo_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            int mitumoriNo = 0;

            if (int.TryParse(control.Text, out mitumoriNo))
            {
                control.Text = mitumoriNo.ToString("00000000");
            }
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
                // F1キーが押下された場合
                case Keys.F1:
                    // 一覧表示ボタン押下時の処理を実行
                    btnDispList_Click(null, null);
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

        #endregion

        #region ビジネスロジック

        #region 一覧グリッドデータ設定処理
        /// <summary>
        /// 一覧グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;

            // 取得データをグリッドに設定
            grdSearchList.DataSource = getData(GetDataType.Display);

            flgSetGridData = false;
        }
        #endregion

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
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

            // 見積日付Fromの場合
            if (c.Name.Equals(txtEstimateDateFromYears.Name) ||
                c.Name.Equals(txtEstimateDateFromMonth.Name) ||
                c.Name.Equals(txtEstimateDateFromDays.Name) ||
                c.Name.Equals(dtpEstimateDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtEstimateDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEstimateDateFrom_Leave);
            }
            // 見積日付Toの場合
            else if (c.Name.Equals(txtEstimateDateToYears.Name) ||
                     c.Name.Equals(txtEstimateDateToMonth.Name) ||
                     c.Name.Equals(txtEstimateDateToDays.Name) ||
                     c.Name.Equals(dtpEstimateDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtEstimateDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtEstimateDateTo_Leave);
            }

            // 検索ボタンでない場合
            if (!c.Name.Equals(btnDispList.Name))
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

        #region 画面表示・帳票出力データ取得処理
        /// <summary>
        /// 画面表示・帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private DataTable getData(GetDataType getDataType)
        {
            string sql = string.Empty;

            sql += "SELECT mh.tantousyaCode                           AS tantoCd ";
            sql += "     , tm.tantousyaName                           AS tantoNm ";
            sql += "     , mh.mitumoriNo                              AS mitumoriNo ";
            sql += "     , DATE_FORMAT(mh.mitumoriHizuke, '%Y/%c/%e') AS mitumoriDate ";
            sql += "     , mm.kubunName                               AS mitumoriKbn ";
            sql += "     , ''                                         AS kiDate ";
            sql += "     , mh.nouki                                   AS nouki ";
            sql += "     , mh.yuukouKigen                             AS yukoukigen ";
            sql += "     , mh.ukewatasiBasyo1                         AS ukewatasiBasyo1 ";
            sql += "     , mh.ukewatasiBasyo2                         AS ukewatasiBasyo2 ";
            sql += "     , mh.torihikiJouken                          AS torihikiJyouken ";
            sql += "     , tokuisakiCode                              AS tokuisakiCd ";
            sql += "     , jigyousyoName                              AS jigyousyoNm ";
            sql += "     , tokuisakiName                              AS tokuisakiNm ";
            if (GetDataType.Display.Equals(getDataType))
            {
                sql += "     , mf.shouhizei                           AS shohiZei ";
                sql += "     , mf.kingaku                             AS kingaku ";
                sql += "     , mf.goukei                              AS mitumoriKingaku ";
            }
            else
            {
                sql += "     , FORMAT(IFNULL(mf.shouhizei, '') ,0)    AS shohiZei ";
                sql += "     , FORMAT(IFNULL(mf.kingaku, '') ,0)      AS kingaku ";
                sql += "     , FORMAT(IFNULL(mf.goukei, '') ,0)       AS mitumoriKingaku ";
            }
            sql += "     , mh.kenmei1                  AS tokuisakiTantousya ";
            sql += "     , mh.kenmei1                                 AS kenmei1 ";
            sql += "FROM(SELECT * from mitumori_header WHERE kanriKubun IS NULL OR kanriKubun <> '9') mh ";
            sql += "LEFT JOIN(SELECT * from mitumori_footer WHERE kanriKubun IS NULL OR kanriKubun <> '9') mf ";
            sql += "ON(mh.mitumoriNo = mf.mitumoriNo) ";
            sql += "LEFT JOIN(SELECT* from meisyo_master WHERE (kanriKubun IS NULL OR kanriKubun <> '9') AND meisyoCode = '002') mm ";
            sql += "ON(mh.mitumoriKubun = mm.kubun) ";
            sql += "LEFT JOIN(SELECT* from tantousya_master WHERE kanriKubun IS NULL OR kanriKubun<> '9') tm ";
            sql += "ON(mh.tantousyaCode = tm.tantousyaCode) ";
            sql += "WHERE 1 = 1 ";
            // 見積No(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateNoFrom.Text))
            {
                sql += "AND mh.mitumoriNo >= '" + txtEstimateNoFrom.Text + "' ";
            }
            // 見積No(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateNoTo.Text))
            {
                sql += "AND mh.mitumoriNo <= '" + txtEstimateNoTo.Text + "' ";
            }
            // 見積日付(FROM)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateDateFromYears.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateFromMonth.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateFromDays.Text))
            {
                string estimateDateFrom = txtEstimateDateFromYears.Text;
                estimateDateFrom += "/" + txtEstimateDateFromMonth.Text;
                estimateDateFrom += "/" + txtEstimateDateFromDays.Text;
                sql += "AND (mh.mitumoriHizuke IS NOT NULL AND STR_TO_DATE(mh.mitumoriHizuke, '%Y-%m-%d') >= '" + estimateDateFrom + "') ";
            }
            // 見積日付(TO)が入力されている場合
            if (!string.IsNullOrEmpty(txtEstimateDateToYears.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateToMonth.Text) &&
                !string.IsNullOrEmpty(txtEstimateDateToDays.Text))
            {
                string estimateDateTo = txtEstimateDateToYears.Text;
                estimateDateTo += "/" + txtEstimateDateToMonth.Text;
                estimateDateTo += "/" + txtEstimateDateToDays.Text;
                sql += "AND (mh.mitumoriHizuke IS NOT NULL AND STR_TO_DATE(mh.mitumoriHizuke, '%Y-%m-%d') <= '" + estimateDateTo + "') ";
            }
            // 得意先コードが入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                sql += "AND mh.tokuisakiCode = '" + txtCustomerCode.Text + "' ";
            }
            // 得意先漢字名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                sql += "AND mh.tokuisakiName Like '%" + txtCustomerName.Text + "%' ";
            }
            // 得意先カナ名が入力されている場合
            if (!string.IsNullOrEmpty(txtCustomerKanaName.Text))
            {
                sql += "AND mh.tokuisakiKanaName Like '%" + txtCustomerKanaName.Text + "%' ";
            }
            sql += "ORDER BY mh.mitumoriNo ";

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
            DataTable mitumoriList = getData(GetDataType.Print);
            dtblMitumoriIchiran mitumoriIchiran = new dtblMitumoriIchiran();
            foreach (DataRow row in mitumoriList.Rows)
            {
                mitumoriIchiran.Tables["dtblMitumoriIchiran"].Rows.Add(row.ItemArray);
            }
            rptMitumoriIchiran1.SetDataSource(mitumoriIchiran);


            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptMitumoriIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                CommonLogic commonLogic = new CommonLogic();
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptMitumoriIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptMitumoriIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptMitumoriIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptMitumoriIchiran1.PrintToPrinter(printerSettings
                                                     , pageSettings
                                                     , false);

                }
            }
            else
            {
                printView.Size = new Size(1300, 940);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #endregion
    }
}
