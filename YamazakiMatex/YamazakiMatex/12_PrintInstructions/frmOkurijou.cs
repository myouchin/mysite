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
    public partial class frmOkurijou : Common.ChildBaseForm
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

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmOkurijou()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            meisyoMaster = new DBMeisyoMaster();
            commonLogic = new CommonLogic();
            masterDataSelectDb = new DBCommon();
            txtZipCode1.Text = string.Empty;
            txtZipCode2.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtOfficeName.Text = string.Empty;
            txtContact1.Text = string.Empty;
            fTokuisaki = new sfrmTokuisakiSearch(false);
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
            activeControlInfo.Control = txtCustomerName;
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
            if (activeControlInfo.Control.Name.Equals(txtCustomerName.Name))
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
            txtZipCode1.Text = string.Empty;
            txtZipCode2.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtOfficeName.Text = string.Empty;
            txtContact1.Text = string.Empty;
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
            else if (activeControlInfo.Control.Name.Equals(txtCustomerName.Name))
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
            txtZipCode1.MaxLength = 3;              // 郵便番号(上3桁)
            txtZipCode2.MaxLength = 4;              // 郵便番号(下4桁)
            txtAddress1.MaxLength = 20;             // 住所１
            txtAddress2.MaxLength = 20;             // 住所２
            txtCustomerName.MaxLength = 40;         // 得意先名
            txtOfficeName.MaxLength = 30;           // 事業所名
            txtContact1.MaxLength = 5;              // 電話番号１
            txtContact2.MaxLength = 4;              // 電話番号２
            txtContact3.MaxLength = 4;              // 電話番号３
            txtNumber.MaxLength = 3;                // 個数
            txtItemName.MaxLength = 20;             // 商品名
            txtSummary1.MaxLength = 20;             // 摘要１
            txtSummary2.MaxLength = 20;             // 摘要２
            txtSummary3.MaxLength = 20;             // 摘要３
            txtReceptionDateYears.MaxLength = 4;    // 受付日(年)
            txtReceptionDateMonth.MaxLength = 2;    // 受付日(月)
            txtReceptionDateDays.MaxLength = 2;     // 受付日(日)
            txtDeliveryDateYears.MaxLength = 4;     // お届け予定日(年)
            txtDeliveryDateMonth.MaxLength = 2;     // お届け予定日(月)
            txtDeliveryDateDays.MaxLength = 2;      // お届け予定日(日)

            // 入力制御イベント設定
            txtZipCode1.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 郵便番号(上3桁) :数字のみ入力可
            txtZipCode2.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 郵便番号(下4桁) :数字のみ入力可
            txtContact1.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 電話番号１      :数字のみ入力可
            txtContact2.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 電話番号２      :数字のみ入力可
            txtContact3.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 電話番号３      :数字のみ入力可

            txtCustomerName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
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
                txtCustomerName.Focus();
                return;
            }
            else if (Consts.KanriCodeTypes.TYPE9.Equals(tokuisakiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "得意先";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtCustomerName.Focus();
                return;
            }

            txtCustomerName.Text = tokuisakiInfo[0].TokuisakiName;
            txtOfficeName.Text = tokuisakiInfo[0].JigyousyoName;
            string[] zipCodes = tokuisakiInfo[0].ZipCode.Split('-');
            if (zipCodes.Length > 0)
            {
                txtZipCode1.Text = zipCodes[0];
            }
            if (zipCodes.Length > 1)
            {
                txtZipCode2.Text = zipCodes[1];
            }
            txtAddress1.Text = tokuisakiInfo[0].Address1;
            txtAddress2.Text = tokuisakiInfo[0].Address2;
            string[] tels = tokuisakiInfo[0].Renrakusaki1.Split('-');
            if (tels.Length > 0)
            {
                txtContact1.Text = tels[0];
            }
            if (tels.Length > 1)
            {
                txtContact2.Text = tels[1];
            }
            if (tels.Length > 2)
            {
                txtContact3.Text = tels[2];
            }
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
            dtblShukahyo shukahyo = new dtblShukahyo();
            string zipCode = txtZipCode1.Text + txtZipCode2.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string customerName = txtCustomerName.Text;
            string officeName = txtOfficeName.Text;
            string[] contact1 = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            int index = 4;
            for (int i = txtContact1.Text.Length - 1; i >= 0; i--)
            {
                contact1[index] = Convert.ToString(txtContact1.Text[i]);
                index--;
            }
            string[] contact2 = { string.Empty, string.Empty, string.Empty, string.Empty };
            index = 3;
            for (int i = txtContact2.Text.Length - 1; i >= 0; i--)
            {
                contact2[index] = Convert.ToString(txtContact2.Text[i]);
                index--;
            }
            string[] contact3 = { string.Empty, string.Empty, string.Empty, string.Empty };
            index = 3;
            for (int i = txtContact3.Text.Length - 1; i >= 0; i--)
            {
                contact3[index] = Convert.ToString(txtContact3.Text[i]);
                index--;
            }
            string[] number = { string.Empty, string.Empty , string.Empty };
            index = 2;
            for (int i = txtNumber.Text.Length - 1; i >= 0; i--)
            {
                number[index] = Convert.ToString(txtNumber.Text[i]);
                index--;
            }
            string itemName = txtItemName.Text;
            string summary1 = txtSummary1.Text;
            string summary2 = txtSummary2.Text;
            string summary3 = txtSummary3.Text;
            string receptionDateYears = txtReceptionDateYears.Text;
            string receptionDateMonth = txtReceptionDateMonth.Text;
            string receptionDateDays = txtReceptionDateDays.Text;
            string deliveryDateYears = txtDeliveryDateYears.Text;
            string deliveryDateMonth = txtDeliveryDateMonth.Text;
            string deliveryDateDays = txtDeliveryDateDays.Text;

            DataRow newRow = shukahyo.Tables["dtblSyukahyo"].NewRow();
            int yubinCnt = 7;
            for (int i = zipCode.Length - 1; i >= 0; i--)
            {
                newRow["yubin" + Convert.ToString(yubinCnt)] = zipCode[i];
                yubinCnt--;
            }
            newRow["jyusho1"] = address1;
            newRow["jyusho2"] = address2;
            newRow["tokuisakiNm"] = customerName;
            newRow["jigyosho"] = officeName;
            newRow["tel1"] = contact1[0];
            newRow["tel2"] = contact1[1];
            newRow["tel3"] = contact1[2];
            newRow["tel4"] = contact1[3];
            newRow["tel5"] = contact1[4];
            newRow["tel6"] = contact2[0];
            newRow["tel7"] = contact2[1];
            newRow["tel8"] = contact2[2];
            newRow["tel9"] = contact2[3];
            newRow["tel10"] = contact3[0];
            newRow["tel11"] = contact3[1];
            newRow["tel12"] = contact3[2];
            newRow["tel13"] = contact3[3];
            newRow["kosu1"] = number[0];
            newRow["kosu2"] = number[1];
            newRow["kosu3"] = number[2];
            newRow["hinmei"] = itemName;
            newRow["tekiyou1"] = summary1;
            newRow["tekiyou2"] = summary2;
            newRow["tekiyou3"] = summary3;
            newRow["uketukebiY"] = receptionDateYears;
            newRow["uketukebiM"] = receptionDateMonth;
            newRow["uketukebiD"] = receptionDateDays;
            newRow["tyakubiY"] = deliveryDateYears;
            newRow["tyakubiM"] = deliveryDateMonth;
            newRow["tyakubiD"] = deliveryDateDays;
            shukahyo.Tables["dtblSyukahyo"].Rows.Add(newRow.ItemArray);

            if (rdoSagawa.Checked)
            {
                // 帳票データの設定
                rptSagawa1.SetDataSource(shukahyo);
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptSagawa1;
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptSagawa1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptSagawa1.PrintOptions.PaperOrientation)
                                                                         , rptSagawa1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptSagawa1.PrintToPrinter(printerSettings
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
            else
            {
                // 帳票データの設定
                rptYamato1.SetDataSource(shukahyo);
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptYamato1;
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(rptYamato1.PrintOptions.PrinterName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptYamato1.PrintOptions.PaperOrientation)
                                                                         , rptYamato1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptYamato1.PrintToPrinter(printerSettings
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
        }
        #endregion

        #endregion
    }
}
