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
using Juchu;

namespace PrintInstructions
{
    public partial class frmAtena : Common.ChildBaseForm
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
        sfrmShiiresakiSearch fShiiresaki;

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmAtena()
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
            txtCompanyName.Text = string.Empty;
            cmbTitles1.Text = string.Empty;
            txtBelongs1.Text = string.Empty;
            txtBelongs2.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbTitles2.Text = string.Empty;
            cmbBikou.Text = string.Empty;
            fTokuisaki = new sfrmTokuisakiSearch(false);
            fShiiresaki = new sfrmShiiresakiSearch(false, CheckMessageType.None);
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

            // 敬称コンボボックス設定処理
            setTitlesCmb();
            // 但し書きコンボボックス設定処理
            setBikouCmb();

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtCompanyName;
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

            // 会社名を編集中の場合
            if (activeControlInfo.Control.Name.Equals(txtCompanyName.Name))
            {
                // 得意先検索または仕入先検索の選択画面を表示
                frmSearchDiplaySelect searchDiplaySelect = new frmSearchDiplaySelect("得意先検索", "仕入先検索");
                searchDiplaySelect.StartPosition = FormStartPosition.CenterScreen;
                searchDiplaySelect.ShowDialog();
                bool flgTokuisakiSearch = (searchDiplaySelect.DisplayType == frmSearchDiplaySelect.StartDisplayType.SearchDiplay1);

                if (flgTokuisakiSearch)
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
                }
                else
                {
                    // 仕入先検索画面を起動
                    fShiiresaki.ShowDialog();

                    // 得意先検索画面で確認ボタンが押下された場合
                    if (fShiiresaki.DialogResult == DialogResult.OK)
                    {
                        // 仕入先情報設定処理
                        setShiiresakiInfo(fShiiresaki.SelectedShiresakiCodes[0]);
                    }
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
            txtCompanyName.Text = string.Empty;
            cmbTitles1.SelectedIndex = 0;
            txtBelongs1.Text = string.Empty;
            txtBelongs2.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbTitles2.SelectedIndex = 0;
            cmbBikou.SelectedIndex = 0;
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
            // 会社名を編集中の場合
            else if (activeControlInfo.Control.Name.Equals(txtCompanyName.Name))
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
            txtCompanyName.MaxLength = 30;          // 得意先名
            cmbTitles1.MaxLength = 3;               // 敬称１
            txtBelongs1.MaxLength = 20;             // 所属１
            txtBelongs2.MaxLength = 20;             // 所属２
            txtTitle.MaxLength = 20;                // 役職
            txtName.MaxLength = 10;                 // 個人名
            cmbTitles2.MaxLength = 3;               // 敬称２
            cmbBikou.MaxLength = 5;                 // 摘要

            // 入力制御イベント設定
            txtZipCode1.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 郵便番号(上3桁) :数字のみ入力可
            txtZipCode2.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 郵便番号(下4桁) :数字のみ入力可

            txtCompanyName.KeyPress += new KeyPressEventHandler(txtByteCheck_KeyPress);                   // 得意先名           :入力文字数のバイトチェック
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
                txtCompanyName.Focus();
                return;
            }
            else if (Consts.KanriCodeTypes.TYPE9.Equals(tokuisakiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "得意先";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtCompanyName.Focus();
                return;
            }

            txtCompanyName.Text = tokuisakiInfo[0].TokuisakiName;
            txtBelongs1.Text = tokuisakiInfo[0].JigyousyoName;
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
            flgSearch = true;
        }
        #endregion

        #region 仕入先情報設定処理
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private void setShiiresakiInfo(string shiresakiCode)
        {
            DBShiresakiMaster shiiresakiM = new DBShiresakiMaster();
            // 得意先情報を取得
            List<DBFileLayout.ShiresakiMasterFile> shiiresakiInfo = shiiresakiM.getShiresakiInfo(shiresakiCode);
            if (shiiresakiInfo.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "仕入先ｺｰﾄﾞ"));
                txtCompanyName.Focus();
                return;
            }
            else if (Consts.KanriCodeTypes.TYPE9.Equals(shiiresakiInfo[0].KanriKubun))
            {
                string msg1 = "削除";
                string msg2 = "仕入先";
                string msg3 = "使用";
                errorOK(string.Format(Messages.M0013, msg1, msg2, msg3));
                txtCompanyName.Focus();
                return;
            }

            txtCompanyName.Text = shiiresakiInfo[0].ShiresakiName;
            string[] zipCodes = shiiresakiInfo[0].ZipCode.Split('-');
            if (zipCodes.Length > 0)
            {
                txtZipCode1.Text = zipCodes[0];
            }
            if (zipCodes.Length > 1)
            {
                txtZipCode2.Text = zipCodes[1];
            }
            txtAddress1.Text = shiiresakiInfo[0].Address1;
            txtAddress2.Text = shiiresakiInfo[0].Address2;
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
            dtblAtena atena = new dtblAtena();
            DataRow newRow;

            string[] zipCode = new string[7];
            zipCode[0] = string.Empty;
            zipCode[1] = string.Empty;
            zipCode[2] = string.Empty;
            zipCode[3] = string.Empty;
            zipCode[4] = string.Empty;
            zipCode[5] = string.Empty;
            zipCode[6] = string.Empty;
            try
            {
                zipCode[0] = Convert.ToString(txtZipCode1.Text[0]);
                zipCode[1] = Convert.ToString(txtZipCode1.Text[1]);
                zipCode[2] = Convert.ToString(txtZipCode1.Text[2]);
            }
            catch
            {
            }
            try
            {
                zipCode[3] = Convert.ToString(txtZipCode2.Text[0]);
                zipCode[4] = Convert.ToString(txtZipCode2.Text[1]);
                zipCode[5] = Convert.ToString(txtZipCode2.Text[2]);
                zipCode[6] = Convert.ToString(txtZipCode2.Text[3]);
            }
            catch
            {
            }
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string companyName = txtCompanyName.Text;
            string titles1 = cmbTitles1.Text;
            string belongs1 = txtBelongs1.Text;
            string belongs2 = txtBelongs2.Text;
            string title = txtTitle.Text;
            string name = txtName.Text;
            string titles2 = cmbTitles2.Text;
            string bikou = cmbBikou.Text;

            string printerName = "OKI DATA CORP OKI MICROLINE 5650SU3-R";
            PrintDialog pdlg = new PrintDialog();
            pdlg.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = printerName;
            if (pdlg.PrinterSettings.DefaultPageSettings.PrinterSettings.PaperSizes.Count == 0)
            {
                printerName = "OKI MICROLINE 5650SU-R";
            }
            if (rdoKaku2.Checked)
            {
                newRow = atena.Tables["dtblAtenaKaku2"].NewRow();

                newRow["zipCode1"] = zipCode[0];
                newRow["zipCode2"] = zipCode[1];
                newRow["zipCode3"] = zipCode[2];
                newRow["zipCode4"] = zipCode[3];
                newRow["zipCode5"] = zipCode[4];
                newRow["zipCode6"] = zipCode[5];
                newRow["zipCode7"] = zipCode[6];
                newRow["address1"] = address1;
                newRow["address2"] = address2;
                if (!string.IsNullOrEmpty(belongs1) ||
                    !string.IsNullOrEmpty(belongs2) ||
                    !string.IsNullOrEmpty(title) ||
                    !string.IsNullOrEmpty(name) ||
                    !string.IsNullOrEmpty(titles2))
                {
                    newRow["companyName2"] = companyName;
                    newRow["belongs1"] = belongs1;
                    newRow["belongs2"] = belongs2;
                    newRow["position"] = title;
                    newRow["name"] = name;
                    newRow["title2"] = titles2;
                }
                else
                {
                    newRow["companyName1"] = companyName;
                    newRow["title1"] = titles1;
                }
                newRow["remarks"] = bikou;
                atena.Tables["dtblAtenaKaku2"].Rows.Add(newRow.ItemArray);

                // 帳票データの設定
                rptAtena2Gou1.SetDataSource(atena);
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptAtena2Gou1;
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(printerName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptAtena2Gou1.PrintOptions.PaperOrientation)
                                                                         , rptAtena2Gou1.PrintOptions.PaperSize.ToString()
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptAtena2Gou1.PrintToPrinter(printerSettings
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
                if (!string.IsNullOrEmpty(titles1)) companyName = companyName + "　" + titles1;
                if (!string.IsNullOrEmpty(titles2)) name = name + "　" + titles2;

                newRow = atena.Tables["dtblAtenaNaga3"].NewRow();

                newRow["zipCode1"] = zipCode[0];
                newRow["zipCode2"] = zipCode[1];
                newRow["zipCode3"] = zipCode[2];
                newRow["zipCode4"] = zipCode[3];
                newRow["zipCode5"] = zipCode[4];
                newRow["zipCode6"] = zipCode[5];
                newRow["zipCode7"] = zipCode[6];
                for (int i = 0; i < address1.Length; i++)
                {
                    newRow["address1_" + (i + 1)] = ConvertHaifun(Convert.ToString(address1[i]));
                }
                for (int i = 0; i < address2.Length; i++)
                {
                    newRow["address2_" + (i + 1)] = ConvertHaifun(Convert.ToString(address2[i]));
                }

                int maxNameLength = companyName.Length;
                if (maxNameLength < belongs1.Length) maxNameLength = belongs1.Length;
                if (maxNameLength < belongs2.Length) maxNameLength = belongs2.Length;
                if (maxNameLength < title.Length) maxNameLength = title.Length;
                if (maxNameLength < name.Length) maxNameLength = name.Length;

                //int nameStartIndex = 33 - maxNameLength;
                //if (nameStartIndex % 2 == 0)
                //{
                //    nameStartIndex = ((int)nameStartIndex / 2) + 1;
                //}
                //else
                //{
                //    nameStartIndex = (int)nameStartIndex / 2;
                //}

                if (!string.IsNullOrEmpty(belongs1) ||
                    !string.IsNullOrEmpty(belongs2) ||
                    !string.IsNullOrEmpty(title) ||
                    !string.IsNullOrEmpty(name))
                {
                    int nameCount = 0;
                    int nameIndex = 0;
                    if (!string.IsNullOrEmpty(companyName))
                    {
                        nameCount++;
                    }
                    if (!string.IsNullOrEmpty(belongs1))
                    {
                        nameCount++;
                    }
                    if (!string.IsNullOrEmpty(belongs2))
                    {
                        nameCount++;
                    }
                    if (!string.IsNullOrEmpty(title))
                    {
                        nameCount++;
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        nameCount++;
                    }

                    switch (nameCount)
                    {
                        case 1:
                            nameIndex = 2;
                            break;
                        case 2:
                            nameIndex = 1;
                            break;
                        case 3:
                            nameIndex = 1;
                            break;
                        case 4:
                            nameIndex = 0;
                            break;
                        case 5:
                            nameIndex = 0;
                            break;
                        default:
                            break;
                    }

                    if (!string.IsNullOrEmpty(companyName))
                    {
                        nameIndex++;
                        for (int i = 0; i < companyName.Length; i++)
                        {
                            //newRow["name" + nameIndex + "_" + (nameStartIndex + i)] = ConvertHaifun(Convert.ToString(companyName[i]));
                            newRow["name" + nameIndex + "_" + (i + 1)] = ConvertHaifun(Convert.ToString(companyName[i]));
                        }
                    }
                    if (!string.IsNullOrEmpty(belongs1))
                    {
                        nameIndex++;
                        for (int i = 0; i < belongs1.Length; i++)
                        {
                            //newRow["name" + nameIndex + "_" + (nameStartIndex + i)] = ConvertHaifun(Convert.ToString(belongs1[i]));
                            newRow["name" + nameIndex + "_" + (i + 1)] = ConvertHaifun(Convert.ToString(belongs1[i]));
                        }
                    }
                    if (!string.IsNullOrEmpty(belongs2))
                    {
                        nameIndex++;
                        for (int i = 0; i < belongs2.Length; i++)
                        {
                            //newRow["name" + nameIndex + "_" + (nameStartIndex + i)] = ConvertHaifun(Convert.ToString(belongs2[i]));
                            newRow["name" + nameIndex + "_" + (i + 1)] = ConvertHaifun(Convert.ToString(belongs2[i]));
                        }
                    }
                    if (!string.IsNullOrEmpty(title))
                    {
                        nameIndex++;
                        for (int i = 0; i < title.Length; i++)
                        {
                            //newRow["name" + nameIndex + "_" + (nameStartIndex + i)] = ConvertHaifun(Convert.ToString(title[i]));
                            newRow["name" + nameIndex + "_" + (i + 1)] = ConvertHaifun(Convert.ToString(title[i]));
                        }
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        nameIndex++;
                        for (int i = 0; i < name.Length; i++)
                        {
                            //newRow["name" + nameIndex + "_" + (nameStartIndex + i)] = ConvertHaifun(Convert.ToString(name[i]));
                            newRow["name" + nameIndex + "_" + (i + 1)] = ConvertHaifun(Convert.ToString(name[i]));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < companyName.Length; i++)
                    {
                        //newRow["name3_" + (nameStartIndex + i)] = ConvertHaifun(Convert.ToString(companyName[i]));
                        newRow["name3_" + (i + 1)] = ConvertHaifun(Convert.ToString(companyName[i]));
                    }
                }
                for (int i = 0; i < bikou.Length; i++)
                {
                    newRow["remarks" + (i + 1)] = ConvertHaifun(Convert.ToString(bikou[i]));
                    if ((i + 1) == 5) break;
                }
                atena.Tables["dtblAtenaNaga3"].Rows.Add(newRow.ItemArray);

                // 帳票データの設定
                rptAtena3Gou1.SetDataSource(atena);
                frmPrintView printView = new frmPrintView();
                printView.CrViewer.ReportSource = rptAtena3Gou1;
                if (PrintType.OutPut.Equals(printType))
                {
                    //印刷ダイアログ表示処理実行
                    System.Drawing.Printing.PrinterSettings printerSettings = null;
                    System.Drawing.Printing.PageSettings pageSettings = null;
                    DialogResult result = commonLogic.DisplayedPrintDialog(printerName
                                                                         , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptAtena3Gou1.PrintOptions.PaperOrientation)
                                                                         //, rptAtena3Gou1.PrintOptions.PaperSize.ToString()
                                                                         , "JapaneseEnvelopeChouNumber3Rotated"
                                                                         , ref printerSettings
                                                                         , ref pageSettings);
                    //印刷の選択ダイアログを表示する
                    if (result == DialogResult.OK)
                    {
                        //OKがクリックされた時は印刷する
                        rptAtena3Gou1.PrintToPrinter(printerSettings
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

        #region ハイフン変換処理
        /// <summary>
        /// ハイフン変換処理
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ConvertHaifun(string val)
        {
            string res = val;

            if (val.Contains("-") ||
                val.Contains("－") ||
                val.Contains("ー") ||
                val.Contains("—"))
            {
                val = val.Replace("-", "|");
                val = val.Replace("－", "|");
                val = val.Replace("ー", "|");
                val = val.Replace("—", "|");
                res = val;
            }

            return res;
        }
        #endregion

        #region 敬称コンボボックスの設定
        /// <summary>
        /// 敬称コンボボックスの設定
        /// </summary>
        private void setTitlesCmb()
        {
            // 敬称取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE015);
            DataRow newRow = meisyoDt.NewRow();
            newRow["kubun"] = "dummy";
            newRow["kubunName"] = string.Empty;
            meisyoDt.Rows.InsertAt(newRow, 0);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbTitles1, meisyoDt, "kubun", "kubunName");
            commonLogic.setComboBoxDataSource(ref cmbTitles2, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #region 但し書きコンボボックスの設定
        /// <summary>
        /// 但し書きコンボボックスの設定
        /// </summary>
        private void setBikouCmb()
        {
            // 但し書きコンボボックスの設定
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE016);
            DataRow newRow = meisyoDt.NewRow();
            newRow["kubun"] = "dummy";
            newRow["kubunName"] = string.Empty;
            meisyoDt.Rows.InsertAt(newRow, 0);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbBikou, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #endregion
    }
}
