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
using Resorce;
using Common;
using SubForm;

namespace TokuisakiSeikyuKanri
{
    /// <summary>
    /// 得意先請求管理画面
    /// </summary>
    public partial class frmTokuisakiSeikyuKanri : Common.ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private CommonLogic commonLogic;
        private DBCommon tokuisakiSeikyuDataSelectDb;
        private RadioButton activeRadioButton = null;
        private bool flgSearch = false;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private int inputIntegerLength = 8;
        private int inputDecimalLength = 0;
        sfrmTokuisakiSearch fTokuisaki;
        private Dictionary<int, int> dicMonths = new Dictionary<int, int>()
                {
                 {10, 1}
               , {11, 2}
               , {12, 3}
               , {1, 4}
               , {2, 5}
               , {3, 6}
               , {4, 7}
               , {5, 8}
               , {6, 9}
               , {7, 10}
               , {8, 11}
               , {9, 12}
                };
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmTokuisakiSeikyuKanri()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            tokuisakiSeikyuDataSelectDb = new DBCommon();
            fTokuisaki = new sfrmTokuisakiSearch(false);
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTokuisakiSeikyuKanri_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtClaimYear;
            // ラジオボタン変更処理実行
            inputModeChange(rdoRegist);
            // 最大入力桁数設定
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
                // F2キーが押下された場合
                case Keys.F2:
                    // 一覧表示処理を実行
                    btnListDisp_Click(null, null);
                    break;
                // F10キーが押下された場合
                case Keys.F10:
                    // 保存処理を実行
                    btnSave_Click(null, null);
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
                    setTokuisakiInfo(tokuisakiCode, jigyousyoCode, true, txtCustomerCode);
                }
                flgSetFocus = true;
            }
            if (flgSetFocus && activeControlInfo != null && activeControlInfo.Control != null)
            {
                activeControlInfo.Control.Focus();
            }
        }
        #endregion

        #region 一覧表示ボタン押下イベント
        /// <summary>
        /// 一覧表示ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListDisp_Click(object sender, EventArgs e)
        {
            // チェック処理
            if (!checkRequired())
            {
                return;
            }
            setGridData();
        }
        #endregion

        #region 保存ボタン押下イベント
        /// <summary>
        /// 保存ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;
            flgSaving = true;

            string queryMessage = string.Empty;
            if (rdoRegist.Checked)
            {
                queryMessage = Messages.M0001;
            }
            else if (rdoDelete.Checked)
            {
                queryMessage = Messages.M0002;
            }

            // 処理実行確認
            if (queryYesNo(queryMessage) == DialogResult.Yes)
            {
                DateTime registerDate = DateTime.Now;
                // 得意先請求管理ファイル更新SQL生成処理実行
                List<string> commands = createTokuisakiSeikyuRegistSql(registerDate);
                if (tokuisakiSeikyuDataSelectDb.DBRef < 0)
                {
                    errorOK(Messages.M0063);
                    return;
                }
                int registResult = 0;

                // 得意先請求管理ファイルの更新
                foreach (string command in commands)
                {
                    registResult = tokuisakiSeikyuDataSelectDb.executeDBUpdate(command);
                    if (tokuisakiSeikyuDataSelectDb.DBRef != 0) break;
                }

                if (tokuisakiSeikyuDataSelectDb.DBRef < 0)
                {
                    string tableName = string.Empty;
                    string processName = string.Empty;
                    if (registResult < 0)
                    {
                        tableName = "得意先請求管理ファイル";
                    }
                    if (rdoRegist.Checked)
                    {
                        processName = "更新処理";
                    }
                    else if (rdoDelete.Checked)
                    {
                        processName = "削除処理";
                    }
                    errorOK(string.Format(Messages.M0011, tableName, processName));
                }
                else
                {
                    string message1 = "得意先請求管理ファイル";
                    string message2;
                    if (rdoRegist.Checked)
                    {
                        message2 = "更新処理";
                    }
                    else
                    {
                        message2 = "削除";
                    }

                    messageOK(string.Format(Messages.M0012, message1, message2));
                    tokuisakiSeikyuDataSelectDb.endTransaction();
                    btnCancel_Click(null, null);
                }
            }
            flgSaving = false;
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
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                string queryMeaasage = string.Empty;
                string str1 = "取消してよろしいですか？";
                if (rdoRegist.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoDelete.Checked)
                {
                    queryMeaasage = Messages.M0015;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }
            RadioButton activeModeRdo = null;
            if (rdoRegist.Checked)
            {
                activeModeRdo = rdoRegist;
            }
            else if (rdoReference.Checked)
            {
                activeModeRdo = rdoReference;
            }
            else if (rdoDelete.Checked)
            {
                activeModeRdo = rdoDelete;
            }
            // ラジオボタン変更処理実行
            inputModeChange(activeModeRdo);
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
            closedForm();
        }
        #endregion

        #region 得意先コードのフォーカスアウトイベント
        /// <summary>
        /// 得意先コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            // 入力値が空白でない場合
            if (!string.IsNullOrEmpty(text.Text))
            {
                // 得意先情報の設定
                if (setTokuisakiInfo(commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), string.Empty, false, text))
                {
                    text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                }
            }
            else
            {
                txtCustomerName.Text = string.Empty;
                txtOfficesCode.Text = string.Empty;
                txtOfficesName.Text = string.Empty;
            }
        }
        #endregion

        #region 事業所コードのフォーカスアウトイベント
        /// <summary>
        /// 事業所コードのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOfficesCode_Leave(object sender, EventArgs e)
        {
            CustomTextBox text = (CustomTextBox)sender;
            // 得意先コードが空白でない場合
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                // 得意先情報の設定
                if (setTokuisakiInfo(txtCustomerCode.Text, commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength), false, text))
                {
                    text.Text = commonLogic.getZeroBuriedNumberText(text.Text, text.MaxLength);
                }
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

            if (grdClaimList.CurrentCell != null)
            {
                try { grdClaimList.CurrentCell = null; } catch { }
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

        #region 処理モードラジオボタンクリックイベント
        /// <summary>
        /// 処理モードラジオボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputModeRadio_Click(object sender, EventArgs e)
        {
            string queryMeaasage = string.Empty;
            string str1 = "処理モードを変更してよろしいですか？";
            RadioButton radio = (RadioButton)sender;
            if (!flgSaving && activeRadioButton != null && activeRadioButton.Name == radio.Name) return;
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                if (rdoRegist.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoDelete.Checked)
                {
                    queryMeaasage = Messages.M0015;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoRegist.Checked = (rdoRegist.Name == radio.Name);
            rdoReference.Checked = (rdoReference.Name == radio.Name);
            rdoDelete.Checked = (rdoDelete.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
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

        #region 数値のみ入力可能項目のキー押下イベント
        /// <summary>
        /// 数値のみ入力可能項目のキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberOnlyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数値のみ入力可能項目の制御処理を実行
            commonLogic.inputNumberOnly_KeyPress(e, (TextBox)sender, activeControlInfo.IntegerLength, activeControlInfo.DecimalLength);
        }
        #endregion

        #region カレントセル変更時イベント
        /// <summary>
        /// カレントセル変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdClaimList_CurrentCellChanged(object sender, EventArgs e)
        {
            // カレントセルがnullの場合何もしない
            if (grdClaimList.CurrentCell == null) return;

            // カレントセルインデックスから上段行のインデックスを取得
            int selectedGridTopRowIndex = 0;
            if (grdClaimList.CurrentCell.RowIndex % grdClaimList.RowSegmentCount == 0)
            {
                selectedGridTopRowIndex = grdClaimList.CurrentCell.RowIndex;
            }
            else
            {
                selectedGridTopRowIndex = grdClaimList.CurrentCell.RowIndex - 1;
            }

            // データグリッドビュー行の背景色および入力可否設定
            //setGridRowStyle(selectedGridTopRowIndex);
            activeControlInfo = new ActiveControlInfo();
            // カレントセルがTextBoxCellかつ
            // 入力可能セルの場合
            if (grdClaimList.CurrentCell.OwningColumn is DataGridViewTextBoxColumn &&
                !grdClaimList.CurrentCell.ReadOnly)
            {
                //beforeCellValue = Convert.ToString(grdClaimList.CurrentCell.Value);
                // カレントセルの編集モードを開始
                grdClaimList.BeginEdit(true);
            }
        }
        #endregion

        #region グリッドセルの入力開始処理
        /// <summary>
        /// グリッドセルの入力開始処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdClaimList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            CustomDataGridView dgv = (CustomDataGridView)sender;
            
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = e.Control;
            activeControlInfo.RowIndex = dgv.CurrentCell.RowIndex;
            activeControlInfo.ClmIndex = dgv.CurrentCell.ColumnIndex;
            activeControlInfo.FlgGridEditingControl = true;

            // コントロールがDataGridViewTextBoxEditingControlの場合
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                // 入力制御イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyPress -= new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                // 商品ｺｰﾄﾞ列の場合
                if (activeControlInfo.ClmIndex != clmSeikyuYMD.Index)
                {
                    // 入力制御イベントを追加
                    ((DataGridViewTextBoxEditingControl)e.Control).KeyPress += new KeyPressEventHandler(txtNumberOnlyInput_KeyPress);
                    activeControlInfo.IntegerLength = inputIntegerLength;
                    activeControlInfo.DecimalLength = inputDecimalLength;
                }
                // キー押下イベントを削除
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown -= new KeyEventHandler(inputObject_KeyDown);
                // キー押下イベントを追加
                ((DataGridViewTextBoxEditingControl)e.Control).KeyDown += new KeyEventHandler(inputObject_KeyDown);
            }
            setSearchButtonEnabled();
        }
        #endregion

        #region DataGridViewのCellValidatingイベントを処理する
        /// <summary>
        /// DataGridViewのCellValidatingイベントを処理する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdClaimList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CustomDataGridView dgv = (CustomDataGridView)sender;
            if (rdoReference.Checked || rdoDelete.Checked) return;
            if (dgv.CurrentCell.ReadOnly) return;

            // 請求日セルの場合
            if (dgv.CurrentCell.ColumnIndex == clmSeikyuYMD.DisplayIndex)
            {
                string inputText = Convert.ToString(e.FormattedValue);
                if (!checkDate(inputText, true))
                {
                    errorOK(Messages.M0017);
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region 請求管理グリッドの入力確定処理
        /// <summary>
        /// 請求管理グリッドの入力確定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdClaimList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string inputValue = Convert.ToString(grdClaimList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
            // 請求日列でない場合
            if (e.ColumnIndex != clmSeikyuYMD.DisplayIndex)
            {
                recalcAmount(e.RowIndex);
            }
            else
            {
                if (activeControlInfo.CancelEdit) return;
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

            // 得意先ｺｰﾄﾞの場合
            if (c.Name.Equals(txtCustomerCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            }
            // 事業所ｺｰﾄﾞの場合
            else if (c.Name.Equals(txtOfficesCode.Name))
            {
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtOfficesCode_Leave);
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

        #region 得意先情報設定処理
        /// <summary>
        /// 得意先情報設定処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="jigyousyoCode"></param>
        private bool setTokuisakiInfo(string tokuisakiCode, string jigyousyoCode, bool flgUnconditional, CustomTextBox focusObj)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, Consts.OthersCustomerCode.Equals(tokuisakiCode) ? string.Empty : jigyousyoCode);
            if (dt == null || dt.Rows.Count == 0)
            {
                errorOK(string.Format(Messages.M0003, "得意先ｺｰﾄﾞ"));
                focusObj.Focus();
                return false;
            }

            if (flgUnconditional || txtCustomerCode.BeforeValue != tokuisakiCode || txtOfficesCode.BeforeValue != jigyousyoCode)
            {
                DataRow dRow;
                if (Consts.OthersCustomerCode.Equals(tokuisakiCode))
                {
                    dRow = dt.Rows[0];
                    // 取得データを画面項目に設定
                    txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                    txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
                    txtOfficesCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                    txtOfficesName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoName]);
                }
                else
                {
                    var query = dt.AsEnumerable().Where(p => p.Field<string>("jigyousyoCode").Equals(jigyousyoCode));
                    if (query.Count() > 0)
                    {
                        dRow = query.ElementAt(0);
                        // 取得データを画面項目に設定
                        txtCustomerCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiCode]);
                        txtCustomerName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcTokuisakiName]);
                        txtOfficesCode.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoCode]);
                        txtOfficesName.Text = Convert.ToString(dRow[DBFileLayout.TokuisakiMasterFile.dcJigyousyoName]);
                    }
                }
            }

            txtCustomerCode.BeforeValue = txtCustomerCode.Text;
            txtOfficesCode.BeforeValue = txtOfficesCode.Text;

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

        #region 処理モードラジオボタン変更処理
        /// <summary>
        /// 処理モードラジオボタン変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputModeChange(RadioButton radio)
        {
            // チェックOFFの場合何もしない
            if (!radio.Checked) return;

            // トランザクション開始済みの場合
            if (tokuisakiSeikyuDataSelectDb.FlgTransactionStarted)
            {
                // トランザクション終了処理を実行
                tokuisakiSeikyuDataSelectDb.endTransaction();
            }

            activeRadioButton = radio;
            #region 共通初期値設定
            txtClaimYear.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtOfficesCode.Text = string.Empty;
            txtOfficesName.Text = string.Empty;
            // グリッド初期化処理実行
            initGridData();
            #endregion

            flgSearch = false;
            // モード別編集可否設定
            setEnabled();
        }
        #endregion

        #region 処理モード別項目制御処理
        /// <summary>
        /// 処理モード別項目制御処理
        /// </summary>
        private void setEnabled()
        {
            if (flgSettingEnable) return;
            flgSettingEnable = true;
            rdoRegist.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            rdoDelete.Click -= new EventHandler(inputModeRadio_Click);
            grdClaimList.Focus();
            #region モード別編集可否設定
            // 登録
            if (rdoRegist.Checked)
            {
                grdClaimList.ReadOnly = !flgSearch;
                txtClaimYear.ReadOnly = flgSearch;
                txtCustomerCode.ReadOnly = flgSearch;
                txtOfficesCode.ReadOnly = flgSearch;
                btnSearch.Enabled = true;
                btnListDisp.Enabled = !flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = flgSearch;
                btnClose.Enabled = true;

                if (!flgSearch)
                {
                    txtClaimYear.Focus();
                }
                else
                {
                    grdClaimList.Focus();
                }
            }
            // 参照
            else if (rdoReference.Checked)
            {
                grdClaimList.ReadOnly = true;
                txtClaimYear.ReadOnly = flgSearch;
                txtCustomerCode.ReadOnly = flgSearch;
                txtOfficesCode.ReadOnly = flgSearch;
                btnSearch.Enabled = !flgSearch;
                btnListDisp.Enabled = !flgSearch;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
                if (!flgSearch)
                {
                    txtClaimYear.Focus();
                }
                else
                {
                    grdClaimList.Focus();
                }
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                grdClaimList.ReadOnly = true;
                txtClaimYear.ReadOnly = flgSearch;
                txtCustomerCode.ReadOnly = flgSearch;
                txtOfficesCode.ReadOnly = flgSearch;
                btnSearch.Enabled = !flgSearch;
                btnListDisp.Enabled = !flgSearch;
                btnSave.Enabled = flgSearch;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
                if (!flgSearch)
                {
                    txtClaimYear.Focus();
                }
                else
                {
                    grdClaimList.Focus();
                }
            }
            clmMonth.ReadOnly = true;
            //clmZengetsuSeikyu.ReadOnly = true;
            clmKurikoshi.ReadOnly = true;
            clmZeiKomiSeikyu.ReadOnly = true;
            #endregion
            rdoRegist.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
            rdoDelete.Click += new EventHandler(inputModeRadio_Click);
            flgSettingEnable = false;
        }
        #endregion

        #region 処理モード別変更チェック処理
        /// <summary>
        /// 処理モード別変更チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkDataChange()
        {
            bool result = false;
            // 処理モード別の変更チェック処理
            if (rdoRegist.Checked)
            {
                if (!string.IsNullOrEmpty(txtClaimYear.Text) ||
                    !string.IsNullOrEmpty(txtCustomerCode.Text) ||
                    !string.IsNullOrEmpty(txtOfficesCode.Text))
                {
                    result = true;
                }
            }
            else if (rdoDelete.Checked)
            {
                if (flgSearch)
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion

        #region 入力情報設定処理
        /// <summary>
        /// 入力情報設定処理
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtClaimYear.MaxLength = 4;     // 請求年度
            txtCustomerCode.MaxLength = 5;  // 得意先コード
            txtOfficesCode.MaxLength = 3;   // 事業所コード

            // 入力制御イベント設定
            txtClaimYear.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);        // 請求年度     :数字のみ入力可
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 得意先コード :数字のみ入力可
            txtOfficesCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 事業所コード :数字のみ入力可
        }
        #endregion

        #region 請求管理グリッド初期化処理
        /// <summary>
        /// 請求管理グリッド初期化処理
        /// </summary>
        private void initGridData()
        {
            DataTable initDt = new DataTable();
            initDt.Columns.Add(clmMonth.DataPropertyName, Type.GetType("System.String"));
            initDt.Columns.Add(clmZengetsuSeikyu.DataPropertyName, Type.GetType("System.Decimal"));
            initDt.Columns.Add(clmNyukin.DataPropertyName, Type.GetType("System.Decimal"));
            initDt.Columns.Add(clmKurikoshi.DataPropertyName, Type.GetType("System.Decimal"));
            initDt.Columns.Add(clmZeiNukiUriage.DataPropertyName, Type.GetType("System.Decimal"));
            initDt.Columns.Add(clmZei.DataPropertyName, Type.GetType("System.Decimal"));
            initDt.Columns.Add(clmZeiKomiSeikyu.DataPropertyName, Type.GetType("System.Decimal"));
            initDt.Columns.Add(clmSeikyuYMD.DataPropertyName, Type.GetType("System.String"));
            initDt.Columns.Add(clmSeikyuNo.DataPropertyName, Type.GetType("System.String"));

            //initDt.Rows.Add(new object[] { "10", 12345678, 12345678, 12345678, 12345678, 12345678, 12345678, "2019/12/10" });
            initDt.Rows.Add(new object[] { "10", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "11", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "12", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "1", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "2", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "3", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "4", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "5", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "6", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "7", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "8", null, null, null, null, null, null, string.Empty, string.Empty });
            initDt.Rows.Add(new object[] { "9", null, null, null, null, null, null, string.Empty, string.Empty });

            grdClaimList.DataSource = initDt;
        }
        #endregion

        #region 必須入力チェック
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;
            string errorItem = string.Empty;
            // 得意先情報を取得
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            DataTable dt = tokuisakiM.getTokuisakiDataTable(string.IsNullOrEmpty(txtCustomerCode.Text)? "Dummy" : txtCustomerCode.Text, Consts.OthersCustomerCode.Equals(txtCustomerCode.Text) ? string.Empty : txtOfficesCode.Text);

            if (string.IsNullOrEmpty(txtClaimYear.Text))
            {
                errorItem = lblClaimYear.Text;
            }
            else if (dt == null || dt.Rows.Count == 0)
            {
                errorItem = lblCustomer.Text;
            }

            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 請求管理グリッド設定処理
        /// <summary>
        /// 請求管理グリッド設定処理
        /// </summary>
        private void setGridData()
        {
            int year = Convert.ToInt16(txtClaimYear.Text);
            int nextYear = year + 1;
            string baseCommand = string.Empty;
            baseCommand += "  SELECT {0} AS m " + "\r";
            baseCommand += "       , zengetsuSeikyu " + "\r";
            baseCommand += "       , nyukin " + "\r";
            baseCommand += "       , kurikosi " + "\r";
            baseCommand += "       , zeinukiUriage " + "\r";
            baseCommand += "       , syouhizei " + "\r";
            baseCommand += "       , zeikomiSeikyu " + "\r";
            baseCommand += "       , DATE_FORMAT(seikyubi, '%Y/%m/%d') AS seikyubi " + "\r";
            baseCommand += "       , seikyuNo " + "\r";
            baseCommand += "  FROM tokuisaki_seikyu " + "\r";
            baseCommand += "  WHERE tokuisakiCode = '" + txtCustomerCode.Text + "' " + "\r";
            baseCommand += "  AND jigyousyoCode = '" + txtOfficesCode.Text + "' " + "\r";
            baseCommand += "  AND shimeNengetu = '{1}' " + "\r";
            string sql = string.Empty;
            sql += "SELECT ts.* " + "\r";
            sql += "FROM " + "\r";
            sql += "( " + "\r";
            sql += string.Format(baseCommand, 10, Convert.ToString(year) + "10");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 11, Convert.ToString(year) + "11");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 12, Convert.ToString(year) + "12");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 1, Convert.ToString(nextYear) + "01");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 2, Convert.ToString(nextYear) + "02");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 3, Convert.ToString(nextYear) + "03");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 4, Convert.ToString(nextYear) + "04");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 5, Convert.ToString(nextYear) + "05");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 6, Convert.ToString(nextYear) + "06");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 7, Convert.ToString(nextYear) + "07");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 8, Convert.ToString(nextYear) + "08");
            sql += "  " + "UNION ALL " + "\r";
            sql +=  string.Format(baseCommand, 9, Convert.ToString(nextYear) + "09");
            sql += ") ts ";

            tokuisakiSeikyuDataSelectDb.startTransaction();
            DataTable dt = tokuisakiSeikyuDataSelectDb.executeLockSelect(sql);
            int[] mList = new int[] { 10, 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // グリッドの初期化
            initGridData();
            DataTable dataSource = (DataTable)grdClaimList.DataSource;
            dataSource.Rows.Clear();

            foreach (int m in mList)
            {
                var queryDB = dt.AsEnumerable().Where(p => p.Field<Int64>("m") == m);
                if (queryDB.Count() > 0)
                {
                    foreach (DataRow row in queryDB)
                    {
                        dataSource.Rows.Add(new object[] { m.ToString()
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcZengetsuSeikyu]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcNyukin]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcKurikosi]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcZeinukiUriage]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcSyouhizei]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcZeikomiSeikyu]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcSeikyubi]
                                                         , row[DBFileLayout.TokuisakiSeikyuFile.dcSeikyuNo] });
                    }
                }
                else
                {
                    dataSource.Rows.Add(new object[] { m.ToString(), decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, string.Empty, string.Empty });
                }
            }
            dataSource.AcceptChanges();
            //recalcAmount(0);
            flgSearch = true;
            setEnabled();

        }
        #endregion

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string ymd, bool flgEmptyAcceptable)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(ymd))
            {
                ret = true;
            }
            else
            {
                DateTime date;
                string y;
                string m;
                string d;
                string[] wkYMD1;
                string[] wkYMD2;
                try
                {
                    wkYMD1 = ymd.Split('/');
                    wkYMD2 = ymd.Split('-');
                    if (wkYMD1.Length == 3)
                    {
                        y = wkYMD1[0];
                        m = wkYMD1[1];
                        d = wkYMD1[2];
                    }
                    else if (wkYMD2.Length == 3)
                    {
                        y = wkYMD2[0];
                        m = wkYMD2[1];
                        d = wkYMD2[2];
                    }
                    else
                    {
                        y = ymd.Replace(",", "").Substring(0, 4);
                        m = ymd.Replace(",", "").Substring(4, 4);
                        d = ymd.Replace(",", "").Substring(6, 2);
                    }
                    ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
                }
                catch
                {
                }
            }
            return ret;
        }
        #endregion

        #region 金額再計算処理
        /// <summary>
        /// 金額再計算処理
        /// </summary>
        /// <param name="rowIndex"></param>

        private void recalcAmount(int rowIndex)
        {
            DataTable dt = (DataTable)grdClaimList.DataSource;
            DataRow dRow;
            int targetMonth = 0;
            int beforeMonth = 0;
            decimal zengetuSeikyu;
            decimal nyukin;
            decimal kurikosi;
            decimal zeinuki;
            decimal zei;

            for (int i = rowIndex; i < dt.Rows.Count; i++)
            {
                dRow = dt.Rows[i];
                targetMonth = Convert.ToInt16(dRow[clmMonth.DataPropertyName]);
                beforeMonth = targetMonth == 1 ? 12 : targetMonth - 1;
                // 前月請求
                //var query = dt.AsEnumerable().Where(p => p.Field<string>(clmMonth.DataPropertyName).Equals(Convert.ToString(beforeMonth)));
                var query = dt.AsEnumerable().Where(p => dt.Rows.IndexOf(p) == (i - 1));
                if (i == rowIndex)
                {
                    decimal.TryParse(Convert.ToString(dRow[clmZengetsuSeikyu.DataPropertyName]), out zengetuSeikyu);
                }
                else if (i > 0 && query.Count() > 0)
                {
                    decimal.TryParse(Convert.ToString(query.ElementAt(0)[clmZeiKomiSeikyu.DataPropertyName]), out zengetuSeikyu);
                }
                else
                {
                    decimal.TryParse(Convert.ToString(dRow[clmZengetsuSeikyu.DataPropertyName]), out zengetuSeikyu);
                }
                dRow[clmZengetsuSeikyu.DataPropertyName] = zengetuSeikyu;
                // 御入金
                decimal.TryParse(Convert.ToString(dRow[clmNyukin.DataPropertyName]), out nyukin);
                dRow[clmNyukin.DataPropertyName] = nyukin;
                // 繰越額
                if (zengetuSeikyu - nyukin > decimal.Zero)
                {
                    kurikosi = zengetuSeikyu - nyukin;
                }
                else
                {
                    kurikosi = decimal.Zero;
                }
                dRow[clmKurikoshi.DataPropertyName] = kurikosi;
                // 当月税抜御買上額
                decimal.TryParse(Convert.ToString(dRow[clmZeiNukiUriage.DataPropertyName]), out zeinuki);
                dRow[clmZeiNukiUriage.DataPropertyName] = zeinuki;
                // 消費税額
                decimal.TryParse(Convert.ToString(dRow[clmZei.DataPropertyName]), out zei);
                dRow[clmZei.DataPropertyName] = zei;
                // 当月税込請求額
                dRow[clmZeiKomiSeikyu.DataPropertyName] = kurikosi + zeinuki + zei;
            }
            dt.AcceptChanges();
        }
        #endregion

        #region 得意先請求管理ファイル更新SQL生成処理
        /// <summary>
        /// 得意先請求管理ファイル更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createTokuisakiSeikyuRegistSql(DateTime registerDate)
        {
            List<string> commands = new List<string>();
            string sql = string.Empty;
            int year = Convert.ToInt16(txtClaimYear.Text);
            int nextYear = year + 1;
            string tokuisakiCode = txtCustomerCode.Text;
            string jigyousyoCode = txtOfficesCode.Text;
            string updSeikyuNo;

            if (rdoRegist.Checked)
            {
                DataTable dt = (DataTable)grdClaimList.DataSource;
                DataRow dRow;
                int targetMonth = 0;
                string selectYear;
                string selectMonth;
                DataTable selectDt;
                DateTime seikyubi;
                DBCommon common = new DBCommon();
                DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
                DBMeisyoMaster meisyoM = new DBMeisyoMaster();
                // 得意先情報を取得
                List<DBFileLayout.TokuisakiMasterFile> tokuisakiInfo = tokuisakiM.getTokuisakiInfo(tokuisakiCode, Consts.OthersCustomerCode.Equals(tokuisakiCode) ? string.Empty : jigyousyoCode);
                List<DBFileLayout.MeisyoMasterFile> meisyoInfo = meisyoM.getMeisyoInfo(Consts.MeisyoCode.CODE006);
                DataTable seikyuNoDt = tokuisakiSeikyuDataSelectDb.executeLockSelect("SELECT IFNULL(MAX(CAST(seikyuNo AS SIGNED)), 0) AS seikyuNo FROM tokuisaki_seikyu ");
                if (tokuisakiSeikyuDataSelectDb.DBRef < 0)
                {
                    return commands;
                }
                int seikyuNo = Convert.ToInt16(seikyuNoDt.Rows[0]["seikyuNo"]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dRow = dt.Rows[i];
                    targetMonth = Convert.ToInt16(dRow[clmMonth.DataPropertyName]);
                    if (dicMonths[syoriDate.Month] <= dicMonths[targetMonth]) continue;
                    selectYear = targetMonth >= 10 ? Convert.ToString(year) : Convert.ToString(nextYear);
                    selectMonth = targetMonth < 10 ? "0" : string.Empty;
                    selectMonth += Convert.ToString(targetMonth);
                    sql = string.Empty;
                    sql += "SELECT 1 FROM tokuisaki_seikyu " + "\r";
                    sql += "WHERE tokuisakiCode = '" + tokuisakiCode + "' " + "\r";
                    if (!string.IsNullOrEmpty(jigyousyoCode)) sql += "AND jigyousyoCode = '" + jigyousyoCode + "' " + "\r";
                    sql += "AND shimeNengetu = '" + selectYear + selectMonth + "' " + "\r";
                    selectDt = tokuisakiSeikyuDataSelectDb.executeNoneLockSelect(sql);
                    if (!string.IsNullOrEmpty(Convert.ToString(dRow[clmSeikyuYMD.DataPropertyName])))
                    {
                        seikyubi = Convert.ToDateTime(Convert.ToString(dRow[clmSeikyuYMD.DataPropertyName]));
                    }
                    else
                    {
                        if (tokuisakiInfo[0].Shimebi.Equals(Consts.EndOfMonthValue))
                        {
                            seikyubi = Convert.ToDateTime(selectYear + "/" + Convert.ToString(targetMonth) + "/01").AddMonths(1).AddDays(-1);
                        }
                        else if (tokuisakiInfo[0].Shimebi.Equals(Consts.FromTimeToTimeValue))
                        {
                            seikyubi = Convert.ToDateTime(selectYear + "/" + selectMonth + "/" + Convert.ToString(registerDate.Day));
                        }
                        else
                        {
                            var query = meisyoInfo.AsEnumerable().Where(p => p.Kubun == tokuisakiInfo[0].Shimebi);
                            if (query.Count() > 0)
                            {
                                seikyubi = Convert.ToDateTime(selectYear + "/" + selectMonth + "/" + Convert.ToInt16(query.ElementAt(0).KubunName));
                            }
                            else
                            {
                                seikyubi = Convert.ToDateTime(selectYear + "/" + selectMonth + "/01");
                            }
                        }
                    }
                    if (selectDt == null || selectDt.Rows.Count == 0)
                    {
                        seikyuNo++;
                        sql = string.Empty;
                        sql += "INSERT INTO tokuisaki_seikyu " + "\r";
                        sql += "( " + "\r";
                        sql += "  seikyuNo " + "\r";
                        sql += ", tokuisakiCode " + "\r";
                        sql += ", jigyousyoCode " + "\r";
                        sql += ", seikyubi " + "\r";
                        sql += ", shimeNengetu " + "\r";
                        sql += ", zengetsuSeikyu " + "\r";
                        sql += ", nyukin " + "\r";
                        sql += ", kurikosi " + "\r";
                        sql += ", zeinukiUriage " + "\r";
                        sql += ", syouhizei " + "\r";
                        sql += ", zeikomiSeikyu " + "\r";
                        sql += ", kousinNichizi " + "\r";
                        sql += ", kanriKubun " + "\r";
                        sql += ") " + "\r";
                        sql += "VALUES " + "\r";
                        sql += "( " + "\r";
                        sql += "  '" + commonLogic.getZeroBuriedNumberText(seikyuNo.ToString(), 8) + "' " + "\r";
                        sql += ", '" + tokuisakiCode + "' " + "\r";
                        sql += ", '" + jigyousyoCode + "' " + "\r";
                        sql += ", '" + seikyubi + "' " + "\r";
                        sql += ", '" + selectYear + selectMonth + "' " + "\r";
                        sql += ", " + dRow[clmZengetsuSeikyu.DataPropertyName] + " " + "\r";
                        sql += ", " + dRow[clmNyukin.DataPropertyName] + " " + "\r";
                        sql += ", " + dRow[clmKurikoshi.DataPropertyName] + " " + "\r";
                        sql += ", " + dRow[clmZeiNukiUriage.DataPropertyName] + " " + "\r";
                        sql += ", " + dRow[clmZei.DataPropertyName] + " " + "\r";
                        sql += ", " + dRow[clmZeiKomiSeikyu.DataPropertyName] + " " + "\r";
                        sql += ", '" + registerDate + "' " + "\r";
                        sql += ", '' " + "\r";
                        sql += ") " + "\r";
                        commands.Add(sql);
                    }
                    else
                    {
                        updSeikyuNo = Convert.ToString(dRow[clmSeikyuNo.DataPropertyName]);
                        sql = string.Empty;
                        sql += "UPDATE tokuisaki_seikyu " + "\r";
                        sql += "SET seikyubi = '" + seikyubi + "' " + "\r";
                        sql += "  , zengetsuSeikyu = " + dRow[clmZengetsuSeikyu.DataPropertyName] + " " + "\r";
                        sql += "  , nyukin = " + dRow[clmNyukin.DataPropertyName] + " " + "\r";
                        sql += "  , kurikosi = " + dRow[clmKurikoshi.DataPropertyName] + " " + "\r";
                        sql += "  , zeinukiUriage = " + dRow[clmZeiNukiUriage.DataPropertyName] + " " + "\r";
                        sql += "  , syouhizei = " + dRow[clmZei.DataPropertyName] + " " + "\r";
                        sql += "  , zeikomiSeikyu = " + dRow[clmZeiKomiSeikyu.DataPropertyName] + " " + "\r";
                        sql += "  , kousinNichizi = '" + registerDate + "' " + "\r";
                        sql += "WHERE tokuisakiCode = '" + tokuisakiCode + "' " + "\r";
                        if (!string.IsNullOrEmpty(jigyousyoCode)) sql += "AND jigyousyoCode = '" + jigyousyoCode + "' " + "\r";
                        sql += "AND shimeNengetu = '" + selectYear + selectMonth + "' " + "\r";
                        sql += "AND seikyuNo = '" + updSeikyuNo + "' " + "\r";
                        commands.Add(sql);
                    }
                }
            }
            else
            {
                sql += "DELETE FROM tokuisaki_seikyu " + "\r";
                sql += "WHERE tokuisakiCode = '" + tokuisakiCode + "' " + "\r";
                if (!string.IsNullOrEmpty(jigyousyoCode)) sql += "AND jigyousyoCode = '" + jigyousyoCode + "' " + "\r";
                sql += "AND ( " + "\r";
                sql += "      (shimeNengetu = '" + Convert.ToString(year) + "10') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(year) + "11') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(year) + "12') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "01') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "02') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "03') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "04') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "05') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "06') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "07') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "08') " + "\r";
                sql += "   OR (shimeNengetu = '" + Convert.ToString(nextYear) + "09') " + "\r";
                sql += "    ) " + "\r";
                commands.Add(sql);
            }

            return commands;
        }
        #endregion

        #endregion
    }
}
