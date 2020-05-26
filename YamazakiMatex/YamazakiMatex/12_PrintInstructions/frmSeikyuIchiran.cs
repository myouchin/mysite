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
using SubForm;

namespace PrintInstructions
{
    /// <summary>
    /// 請求一覧出力画面
    /// </summary>
    public partial class frmSeikyuIchiran : ChildBaseForm
    {
        #region 変数宣言
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private enum LastInputDateType
        {
            None = 0
          , BillingDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private CommonLogic commonLogic;
        private string dummyCode = "Dummy";
        private string cmbAllValue = "ALL";
        private string cmbAllText = "全て";
        sfrmTokuisakiSearch fTokuisaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmSeikyuIchiran()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            activeControlInfo = new ActiveControlInfo();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            txtBillingDateYears.Text = string.Empty;
            txtBillingDateMonth.Text = string.Empty;
            txtBillingDateDays.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
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
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
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
            executePrint(PrintType.Preview);
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
            executePrint(PrintType.OutPut);
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
            closedForm();
        }
        #endregion

        #region 請求年月日フォーカスインイベント
        /// <summary>
        /// 請求年月日フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBillingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.BillingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 請求年月日フォーカスアウトイベント
        /// <summary>
        /// 請求年月日フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBillingDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.BillingDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.BillingDate;
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
                    case LastInputDateType.BillingDate:
                        y = txtBillingDateYears.Text;
                        m = txtBillingDateMonth.Text;
                        d = txtBillingDateDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.BillingDate.Equals(lastInputDateType))
                    {
                        txtBillingDateYears.Focus();
                    }
                    return;
                }
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
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
                txtCustomerName.Text = string.Empty;
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
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    // 検索ボタン押下時の処理を実行
                    btnSearch_Click(null, null);
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

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSeikyuIchiran_Load(object sender, EventArgs e)
        {
            // 事業所コンボボックス設定
            setOfficesCmb(Consts.OthersCustomerCode, string.Empty);
            // 入力情報設定
            setInputInfo();
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

            // 請求年月日の場合
            if (c.Name.Equals(txtBillingDateYears.Name) ||
                c.Name.Equals(txtBillingDateMonth.Name) ||
                c.Name.Equals(txtBillingDateDays.Name) ||
                c.Name.Equals(dtpBillingDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtBillingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtBillingDate_Leave);
            }
            // 得意先ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCd_Leave);
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

        #region 帳票出力データ取得処理
        /// <summary>
        /// 帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private DataTable getData()
        {
            string sql = string.Empty;
            sql += "SELECT '" + txtBillingDateYears.Text + "'                              AS seikyuNen ";
            sql += "     , '" + txtBillingDateMonth.Text + "'                              AS seikyuTuki ";
            sql += "     , '" + txtBillingDateDays.Text + "'                               AS seikyuShime ";
            sql += "     , tm.tokuisakiCode                                                AS tokuiCd ";
            sql += "     , tm.tokuisakiName                                                AS tokuiNm ";
            sql += "     , tm.jigyousyoName                                                AS jigyoNm ";
            sql += "     , FORMAT(IFNULL(ts.zengetsuSeikyu, 0), 0)                         AS zengetuSeikyu ";
            sql += "     , FORMAT(IFNULL(ts.nyukin, 0), 0)                                 AS nyukin ";
            sql += "     , FORMAT(IFNULL(ts.kurikosi, 0), 0)                               AS kurikoshi ";
            sql += "     , FORMAT(IFNULL(ts.zeinukiUriage, 0), 0)                          AS tougetuZeinukiOkaiage ";
            sql += "     , FORMAT(IFNULL(ts.kurikosi, 0) + IFNULL(ts.zeinukiUriage, 0), 0) AS tougetuSeikyu ";
            sql += "     , FORMAT(IFNULL(ts.syouhizei, 0), 0)                              AS syouhiZei ";
            sql += "     , FORMAT(IFNULL(ts.zeikomiSeikyu, 0), 0)                          AS togetuZeikomiSeikyu ";
            sql += "FROM(SELECT * FROM tokuisaki_seikyu WHERE(kanriKubun IS NULL OR kanriKubun = '')) ts ";
            sql += "LEFT JOIN(SELECT * FROM tokuisaki_master WHERE(kanriKubun IS NULL OR kanriKubun = '')) tm ";
            sql += "ON(ts.tokuisakiCode = tm.tokuisakiCode AND ts.jigyousyoCode = tm.jigyousyoCode) ";
            sql += "WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(txtBillingDateYears.Text) &&
                !string.IsNullOrEmpty(txtBillingDateMonth.Text) &&
                !string.IsNullOrEmpty(txtBillingDateDays.Text))
            {
                DateTime billingDate = Convert.ToDateTime(txtBillingDateYears.Text + "/" + txtBillingDateMonth.Text + "/" + txtBillingDateDays.Text);
                sql += "AND ts.seikyubi = '" + billingDate + "' ";
            }
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                sql += "AND tm.tokuisakiCode = '" + txtCustomerCode.Text + "' ";
            }
            if (!string.IsNullOrEmpty(cmbOffices.Text) && !cmbAllValue.Equals(Convert.ToString(cmbOffices.SelectedValue)))
            {
                sql += "AND tm.jigyousyoCode = '" + Convert.ToString(cmbOffices.SelectedValue) + "' ";
            }
            sql += "AND (IFNULL(ts.zengetsuSeikyu, 0) <> 0 ";
            sql += "  OR IFNULL(ts.nyukin, 0) <> 0 ";
            sql += "  OR IFNULL(ts.kurikosi, 0) <> 0 ";
            sql += "  OR IFNULL(ts.zeinukiUriage, 0) <> 0 ";
            sql += "  OR IFNULL(ts.syouhizei, 0) <> 0 ";
            sql += "  OR IFNULL(ts.zeikomiSeikyu, 0) <> 0 ";
            sql += "    ) ";

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
            if (string.IsNullOrEmpty(txtBillingDateYears.Text) ||
                string.IsNullOrEmpty(txtBillingDateMonth.Text) ||
                string.IsNullOrEmpty(txtBillingDateDays.Text))
            {
                errorOK(string.Format(Messages.M0020, lblBillingDate.Text));
                return;
            }
            DataTable seikyuList = getData();
            if (seikyuList == null || seikyuList.Rows.Count == 0)
            {
                string msg = "請求年月日{0}{1}に該当するデータ";
                string strCustomerCode = string.IsNullOrEmpty(txtCustomerCode.Text) ? string.Empty : "、得意先コード";
                string strCustomerName = string.IsNullOrEmpty(cmbOffices.Text) || cmbAllValue.Equals(Convert.ToString(cmbOffices.SelectedValue)) ? string.Empty : "、事業所";
                msg = string.Format(msg, strCustomerCode, strCustomerName);
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            dtblSeikyuIchiran seikyuIchiran = new dtblSeikyuIchiran();
            foreach (DataRow row in seikyuList.Rows)
            {
                seikyuIchiran.Tables["dtblSeikyuIchiran"].Rows.Add(row.ItemArray);
            }
            rptSeikyuIchiran1.SetDataSource(seikyuIchiran.Tables["dtblSeikyuIchiran"]);


            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptSeikyuIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptSeikyuIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptSeikyuIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptSeikyuIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptSeikyuIchiran1.PrintToPrinter(printerSettings
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
                    txtCustomerName.Text = string.Empty;
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
                }
                setOfficesCmb(txtCustomerCode.Text, string.Empty);
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;

            return true;
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
            txtBillingDateYears.MaxLength = 4;  // 請求年月日(年)
            txtBillingDateMonth.MaxLength = 2;  // 請求年月日(月)
            txtBillingDateDays.MaxLength = 2;   // 請求年月日(日)
            txtCustomerCode.MaxLength = 5;      // 得意先ｺｰﾄﾞ

            // 入力制御イベント設定
            txtBillingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(年):数字のみ入力可
            txtBillingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求年月日(月):数字のみ入力可
            txtBillingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 請求年月日(日):数字のみ入力可
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
            if (officesDt != null && officesDt.Rows.Count > 1)
            {
                DataRow newRow = officesDt.NewRow();
                newRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode] = cmbAllValue;
                newRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoName] = cmbAllText;
                officesDt.Rows.InsertAt(newRow, 0);
            }
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbOffices, officesDt
                                            , DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode
                                            , DBFileLayout.TokuisakiMasterFile.dcJigyousyoName);

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

        #endregion
    }
}
