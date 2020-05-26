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
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;

namespace PrintInstructions
{
    public partial class frmRyoShuSho : Common.ChildBaseForm
    {
        #region 変数宣言

        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private DBMeisyoMaster meisyoMaster;
        private CommonLogic commonLogic;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        DBCommon masterDataSelectDb;
        private string ClaimTypeNoValue = "0";
        private string ClaimTypeYesValue = "1";
        private string DefaultOfficeCode = "000";
        private bool flgBtnSearchSelect = false;
        sfrmTokuisakiSearch fTokuisaki;
        private enum LastInputDateType
        {
            None = 0
          , OutputDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmRyoShuSho()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            meisyoMaster = new DBMeisyoMaster();
            commonLogic = new CommonLogic();
            masterDataSelectDb = new DBCommon();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            txtOutPutDateYears.Text = string.Empty;
            txtOutPutDateMonth.Text = string.Empty;
            txtOutPutDateDays.Text = string.Empty;
            txtCustomerName1.Text = string.Empty;
            txtCustomerName2.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtProviso.Text = string.Empty;
        }
        #endregion

        #region 画面起動時のイベント
        /// <summary>
        /// 画面起動時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTokuiM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtOutPutDateYears;
            // 入力情報設定
            setInputInfo();
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

            if (c is CustomTextBox)
            {
                ((CustomTextBox)c).BeforeValue = ((CustomTextBox)c).Text;
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
            setSearchButtonEnabled();
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
            if (activeControlInfo.Control.Name.Equals(txtCustomerName1.Name))
            {
                // 得意先検索画面を起動
                fTokuisaki.ShowDialog();

                // 得意先検索画面で確認ボタンが押下された場合
                if (fTokuisaki.DialogResult == DialogResult.OK)
                {
                    string tokuisakiCode = fTokuisaki.SelectedTokuisakiInfos[0].TokuisakiCode;
                    string jigyousyoCode = fTokuisaki.SelectedTokuisakiInfos[0].JigyousyoCode;
                    // 得意先情報設定処理
                    setTokuisakiInfo(tokuisakiCode, jigyousyoCode);
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
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

        #region 取消ボタン押下イベント
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!btnCancel.Enabled) return;
            // 確認メッセージを出力
            if (queryYesNo("入力内容を破棄してよろしいですか？") == DialogResult.No)
            {
                return;
            }
            txtOutPutDateYears.Text = string.Empty;
            txtOutPutDateMonth.Text = string.Empty;
            txtOutPutDateDays.Text = string.Empty;
            txtCustomerName1.Text = string.Empty;
            txtCustomerName2.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtProviso.Text = string.Empty;
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
            // 確認メッセージを出力
            if (queryYesNo("終了してよろしいですか？") == DialogResult.No)
            {
                return;
            }
            closedForm();
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

        #region 年月日フォーカスインイベント
        /// <summary>
        /// 年月日フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutPutDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.OutputDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 年月日フォーカスアウトイベント
        /// <summary>
        /// 年月日フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutPutDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.OutputDate;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.OutputDate;
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

            // 見積日付Fromの場合
            if (c.Name.Equals(txtOutPutDateYears.Name) ||
                c.Name.Equals(txtOutPutDateMonth.Name) ||
                c.Name.Equals(txtOutPutDateDays.Name) ||
                c.Name.Equals(dtpOutPutDate.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtOutPutDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOutPutDate_Leave);
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
            // 得意先名を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCustomerName1.Name))
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
            txtOutPutDateYears.MaxLength = 4;   // 年月日(年)
            txtOutPutDateMonth.MaxLength = 2;   // 年月日(月)
            txtOutPutDateDays.MaxLength = 2;    // 年月日(日)
            txtCustomerName1.MaxLength = 20;    // 宛先1
            txtCustomerName2.MaxLength = 20;    // 宛先2
            txtAmount.MaxLength = 8;            // 金額
            txtProviso.MaxLength = 20;         // 但し書き

            // 入力制御イベント設定
            txtOutPutDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月日(年)
            txtOutPutDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 年月日(月)
            txtOutPutDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 年月日(日)
            txtAmount.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);           // 金額
        }
        #endregion

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfo = tokuisakiM.getTokuisakiInfo(tokuisakiCode, jigyousyoCode, true);
            if (tokuisakiInfo.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                txtCustomerName1.Focus();
                return;
            }
            else if (Consts.KanriCodeTypes.TYPE9.Equals(tokuisakiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "得意先";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtCustomerName1.Focus();
                return;
            }

            txtCustomerName1.Text = tokuisakiInfo[0].TokuisakiName;
            txtCustomerName2.Text = tokuisakiInfo[0].JigyousyoName;
            flgSearch = true;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            if (string.IsNullOrEmpty(txtOutPutDateYears.Text) ||
                string.IsNullOrEmpty(txtOutPutDateMonth.Text) ||
                string.IsNullOrEmpty(txtOutPutDateDays.Text))
            {
                errorOK(string.Format(Messages.M0020, lblOutPutDate.Text));
                return;
            }
            dtblRyosyusyo ryosyusyo = new dtblRyosyusyo();
            DataRow newRow = ryosyusyo.Tables["dtblRyosyusyo"].NewRow();
            newRow["nen"] = txtOutPutDateYears.Text;
            newRow["tuki"] = txtOutPutDateMonth.Text;
            newRow["hi"] = txtOutPutDateDays.Text;
            if (string.IsNullOrEmpty(txtCustomerName2.Text))
            {
                newRow["atesaki2"] = txtCustomerName1.Text;
            }
            else
            {
                newRow["atesaki1"] = txtCustomerName1.Text;
                newRow["atesaki2"] = txtCustomerName2.Text;
            }
            int kingakuNo = 8;
            for (int i = txtAmount.Text.Length - 1; i >= 0; i--)
            {
                newRow["kingaku" + Convert.ToString(kingakuNo)] = Convert.ToString(txtAmount.Text[i]);
                kingakuNo--;
            }
            if (kingakuNo > 0)
            {
                newRow["kingaku" + Convert.ToString(kingakuNo)] = "￥";
            }
            newRow["tadashigaki"] = txtProviso.Text;
            newRow["genkin"] = rdoGenkin.Checked ? "✓" : string.Empty;
            newRow["kogitte"] = rdoKogitte.Checked ? "✓" : string.Empty;
            newRow["tegata"] = rdoTegata.Checked ? "✓" : string.Empty;
            newRow["sousai"] = rdoSousai.Checked ? "✓" : string.Empty;
            ryosyusyo.Tables["dtblRyosyusyo"].Rows.Add(newRow.ItemArray);

            // 帳票データの設定
            rptRyosyusyo1.SetDataSource(ryosyusyo);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptRyosyusyo1;
            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptRyosyusyo1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptRyosyusyo1.PrintOptions.PaperOrientation)
                                                                     , rptRyosyusyo1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptRyosyusyo1.PrintToPrinter(printerSettings
                                               , pageSettings
                                               , false);

                }
            }
            else
            {
                printView.Size = new Size(1375, 975);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #endregion
    }
}
