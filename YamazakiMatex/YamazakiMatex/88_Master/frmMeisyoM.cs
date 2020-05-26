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
using Resorce;
using DB;

namespace Master
{
    public partial class frmMeisyoM : ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private CommonLogic commonLogic;
        private DBKanriMaster kanriMaster;
        private DBMeisyoMaster meisyoMaster;
        private DBCommon masterDataSelectDb;
        private int selectedNameCodeIndex = -1;
        private string strNewItem = "追加";
        int selectingRowIndex = -1;
        private RadioButton activeRadioButton = null;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private string defaultNameCodeCmb = string.Empty;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMeisyoM()
        {
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            meisyoMaster = new DBMeisyoMaster();
            masterDataSelectDb = new DBCommon();
            InitializeComponent();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMeisyoM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtNameCode;

            // 入力情報設定
            setInputInfo();
            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);

        }
        #endregion

        #region 画面モードラジオボタン押下イベント
        /// <summary>
        /// 画面モードラジオボタン押下イベント
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
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }

            // ラジオボタンのチェック状態変更
            rdoNew.Checked = (rdoNew.Name == radio.Name);
            rdoCorrection.Checked = (rdoCorrection.Name == radio.Name);
            rdoReference.Checked = (rdoReference.Name == radio.Name);

            // ラジオボタンのチェック状態による項目初期化処理
            inputModeChange(radio);
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

        #region 名称コードコンボボックス変更イベント
        /// <summary>
        /// 名称コードコンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbNameCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedNameCodeIndex != cmbNameCode.SelectedIndex)
            {
                if (strNewItem.Equals(Convert.ToString(cmbNameCode.SelectedValue)))
                {
                    cmbNameCode.DropDownStyle = ComboBoxStyle.DropDown;
                    txtNameCode.Visible = true;
                    txtNameCode.Text = string.Empty;
                    txtName.ReadOnly = false;
                    txtNameCode.Focus();
                }
                else
                {
                    cmbNameCode.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (rdoCorrection.Checked)
                    {
                        txtName.ReadOnly = false;
                    }
                    else
                    {
                        txtName.ReadOnly = true;
                    }
                    txtNameCode.Visible = false;

                }
                txtName.Text = Convert.ToString(((DataTable)cmbNameCode.DataSource).Rows[cmbNameCode.SelectedIndex][DBFileLayout.MeisyoMasterFile.dcMeisyoName]);
                setGridData();
                selectedNameCodeIndex = cmbNameCode.SelectedIndex;
            }
            else if (strNewItem.Equals(Convert.ToString(cmbNameCode.SelectedValue)))
            {
                txtNameCode.Focus();
            }
        }
        #endregion

        #region グリッドセル押下イベント
        /// <summary>
        /// グリッドセル押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void grdTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectingRowIndex != e.RowIndex)
            {
                selectingRowIndex = e.RowIndex;
                DataRow selectRow = ((DataTable)grdTypeList.DataSource).Rows[selectingRowIndex];
                txtBeforeType.Text = Convert.ToString(selectRow[DBFileLayout.MeisyoMasterFile.dcKubun]);
                txtType.Text = Convert.ToString(selectRow[DBFileLayout.MeisyoMasterFile.dcKubun]);
                txtTypeName.Text = Convert.ToString(selectRow[DBFileLayout.MeisyoMasterFile.dcKubunName]);
            }
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
            // 必須チェック処理
            if (!checkRequired())
            {
                return;
            }
            // 名称情報の存在チェック
            string msgCode = string.Empty;
            if (checkExistsMeisyoInfo(ref msgCode))
            {
                errorOK(msgCode);
                return;
            }

            string queryMessage = string.Empty;
            if (rdoNew.Checked)
            {
                queryMessage = Messages.M0001;
            }
            else if (rdoCorrection.Checked)
            {
                queryMessage = Messages.M0001;
            }

            // 処理実行確認
            if (queryYesNo(queryMessage) == DialogResult.Yes)
            {
                masterDataSelectDb.startTransaction();
                DateTime registerDate = DateTime.Now;
                List<string> sqlMeisyoMasterCommands = createRegistSql(registerDate);

                // 名称マスタの更新
                foreach (string command in sqlMeisyoMasterCommands)
                {
                    masterDataSelectDb.executeDBUpdate(command);
                }

                if (masterDataSelectDb.DBRef < 0)
                {
                    string processName = string.Empty;
                    if (rdoNew.Checked)
                    {
                        processName = "登録処理";
                    }
                    else if (rdoCorrection.Checked)
                    {
                        processName = "更新処理";
                    }
                    errorOK(string.Format(Messages.M0011, "名称マスタ", processName));
                    masterDataSelectDb.endTransaction();
                    return;
                }
                else
                {
                    string message1 = "名称マスタ";
                    string message2;
                    if (rdoNew.Checked)
                    {
                        message2 = "登録";
                    }
                    else
                    {
                        message2 = "訂正";
                    }
                    messageOK(string.Format(Messages.M0012, message1, message2));
                    masterDataSelectDb.endTransaction();
                    string defaultNameCodeCmb = string.Empty;
                    if (string.IsNullOrEmpty(txtNameCode.Text)) defaultNameCodeCmb = Convert.ToString(cmbNameCode.SelectedValue);
                    btnCancel_Click(null, null);
                    if (!string.IsNullOrEmpty(defaultNameCodeCmb)) cmbNameCode.SelectedValue = defaultNameCodeCmb;
                    return;
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
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
            }
            RadioButton activeModeRdo = null;
            if (rdoNew.Checked)
            {
                activeModeRdo = rdoNew;
            }
            else if (rdoCorrection.Checked)
            {
                activeModeRdo = rdoCorrection;
            }
            else if (rdoReference.Checked)
            {
                activeModeRdo = rdoReference;
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
            // 処理モード別の変更チェック処理
            if (!flgSaving && checkDataChange())
            {
                string queryMeaasage = string.Empty;
                string str1 = "終了してよろしいですか？";
                if (rdoNew.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }
                else if (rdoCorrection.Checked)
                {
                    queryMeaasage = Messages.M0014;
                }

                // 確認メッセージを出力
                if (queryYesNo(string.Format(queryMeaasage, str1)) == DialogResult.No)
                {
                    return;
                }
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

        #region 処理モード別項目制御処理
        /// <summary>
        /// 処理モード別項目制御処理
        /// </summary>
        private void setEnabled()
        {
            if (flgSettingEnable) return;
            flgSettingEnable = true;
            rdoNew.Click -= new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                // 入力制御設定
                cmbNameCode.DropDownStyle = ComboBoxStyle.DropDown;
                txtNameCode.Visible = true;
                txtName.ReadOnly = false;
                txtType.ReadOnly = false;
                txtTypeName.ReadOnly = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                cmbNameCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                cmbNameCode.DropDownStyle = ComboBoxStyle.DropDownList;
                txtNameCode.Visible = false;
                txtName.ReadOnly = false;
                txtType.ReadOnly = false;
                txtTypeName.ReadOnly = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                cmbNameCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                cmbNameCode.DropDownStyle = ComboBoxStyle.DropDownList;
                txtNameCode.Visible = false;
                txtName.ReadOnly = true;
                txtType.ReadOnly = true;
                txtTypeName.ReadOnly = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                cmbNameCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            #endregion
            rdoNew.Click += new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
            rdoReference.Click += new EventHandler(inputModeRadio_Click);
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
            if (rdoNew.Checked)
            {
                if (!string.IsNullOrEmpty(txtNameCode.Text) ||
                    !string.IsNullOrEmpty(txtName.Text) ||
                    !string.IsNullOrEmpty(txtType.Text) ||
                    !string.IsNullOrEmpty(txtTypeName.Text))
                {
                    result = true;
                }
            }
            else if (rdoCorrection.Checked)
            {
                result = true;
            }
            return result;
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

            activeRadioButton = radio;

            #region 共通初期値設定

            txtNameCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtBeforeType.Text = string.Empty;
            txtType.Text = string.Empty;
            txtTypeName.Text = string.Empty;

            #endregion

            // 名称コンボボックス設定処理実行
            setNameCodeCmb(rdoNew.Checked);

            // グリッドデータ設定
            setGridData();

            // モード別編集可否設定
            setEnabled();
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

        #region 名称コードコンボボックスの設定処理
        /// <summary>
        /// 名称コードコンボボックスの設定処理
        /// </summary>
        private void setNameCodeCmb(bool flgAddNewItem)
        {
            selectedNameCodeIndex = -1;
            // 名称コード取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(string.Empty);

            DataTable dataSourceDt = new DataTable();
            dataSourceDt.Columns.Add(DBFileLayout.MeisyoMasterFile.dcMeisyoCode, Type.GetType("System.String"));
            dataSourceDt.Columns.Add(DBFileLayout.MeisyoMasterFile.dcMeisyoName, Type.GetType("System.String"));
            if (flgAddNewItem) dataSourceDt.Rows.Add(new object[] { strNewItem, string.Empty });
            string wkNameCode;
            List<string> wkNameCodes = new List<string>();
            foreach (DataRow dRow in meisyoDt.Rows)
            {
                wkNameCode = Convert.ToString(dRow[DBFileLayout.MeisyoMasterFile.dcMeisyoCode]);
                if (wkNameCodes.Contains(wkNameCode)) continue;

                dataSourceDt.Rows.Add(new object[] { wkNameCode, Convert.ToString(dRow[DBFileLayout.MeisyoMasterFile.dcMeisyoName]) });
                wkNameCodes.Add(wkNameCode);
            }
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbNameCode, dataSourceDt
                                            , DBFileLayout.MeisyoMasterFile.dcMeisyoCode
                                            , DBFileLayout.MeisyoMasterFile.dcMeisyoCode
                                            , new string[] { DBFileLayout.MeisyoMasterFile.dcMeisyoName });
        }
        #endregion

        #region グリッドデータ設定処理
        /// <summary>
        /// グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            // 区分取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Convert.ToString(cmbNameCode.SelectedValue));
            DataTable dataSourceDt = new DataTable();
            dataSourceDt.Columns.Add(DBFileLayout.MeisyoMasterFile.dcKubun, Type.GetType("System.String"));
            dataSourceDt.Columns.Add(DBFileLayout.MeisyoMasterFile.dcKubunName, Type.GetType("System.String"));
            foreach (DataRow dRow in meisyoDt.Rows)
            {
                dataSourceDt.Rows.Add(new object[] { dRow[DBFileLayout.MeisyoMasterFile.dcKubun], dRow[DBFileLayout.MeisyoMasterFile.dcKubunName] });
            }
            grdTypeList.DataSource = dataSourceDt;

            if (dataSourceDt.Rows.Count > 0)
            {
                txtBeforeType.Text = Convert.ToString(dataSourceDt.Rows[0][DBFileLayout.MeisyoMasterFile.dcKubun]);
                txtType.Text = Convert.ToString(dataSourceDt.Rows[0][DBFileLayout.MeisyoMasterFile.dcKubun]);
                txtTypeName.Text = Convert.ToString(dataSourceDt.Rows[0][DBFileLayout.MeisyoMasterFile.dcKubunName]);
            }
            else
            {
                txtBeforeType.Text = string.Empty;
                txtType.Text = string.Empty;
                txtTypeName.Text = string.Empty;
            }
            selectingRowIndex = -1;
        }
        #endregion

        #region 必須入力チェック処理
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;
            string errorItem = string.Empty;

            if (rdoNew.Checked)
            {
                if (strNewItem.Equals(Convert.ToString(cmbNameCode.SelectedValue)) && string.IsNullOrEmpty(txtNameCode.Text))
                {
                    errorItem = lblNameCode.Text;
                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    errorItem = lblName.Text;
                }
                else if (string.IsNullOrEmpty(txtType.Text))
                {
                    errorItem = lblType.Text;
                }
                else if (string.IsNullOrEmpty(txtTypeName.Text))
                {
                    errorItem = lblTypeName.Text;
                }
            }
            else if (rdoNew.Checked)
            {
                if (string.IsNullOrEmpty(txtType.Text) && !string.IsNullOrEmpty(txtTypeName.Text))
                {
                    errorItem = lblType.Text;
                }
                else if (!string.IsNullOrEmpty(txtType.Text) && string.IsNullOrEmpty(txtTypeName.Text))
                {
                    errorItem = lblTypeName.Text;
                }
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

        #region 名称情報の存在チェック処理
        /// <summary>
        /// 名称情報の存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkExistsMeisyoInfo(ref string msgCode)
        {
            bool ret = false;

            DBMeisyoMaster meisyoMaster = new DBMeisyoMaster();
            string checkNameCode = Convert.ToString(cmbNameCode.SelectedValue);
            string nameCode = strNewItem.Equals(checkNameCode) ? txtNameCode.Text : checkNameCode;
            List<DBFileLayout.MeisyoMasterFile> meisyoInfos = meisyoMaster.getMeisyoInfo(nameCode, true);
            string type = txtType.Text;

            if (rdoNew.Checked)
            {
                if (strNewItem.Equals(Convert.ToString(cmbNameCode.SelectedValue)))
                {
                    if (meisyoInfos.Count > 0)
                    {
                        msgCode = Messages.M0053;
                        ret = true;
                    }
                }
                else
                {
                    foreach (DBFileLayout.MeisyoMasterFile meisyoMasterFile in meisyoInfos)
                    {
                        if (meisyoMasterFile.Kubun.Equals(type))
                        {
                            msgCode = Messages.M0054;
                            ret = true;
                            break;
                        }
                    }
                }
            }

            return ret;
        }
        #endregion

        #region 名称マスタの更新SQL生成処理
        /// <summary>
        /// 名称マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private List<string> createRegistSql(DateTime registerDate)
        {
            List<string> commands = new List<string>();
            string command = string.Empty;

            string wkMeisyoCode = Convert.ToString(cmbNameCode.SelectedValue);
            string meisyoCode = strNewItem.Equals(wkMeisyoCode) ? txtNameCode.Text : wkMeisyoCode;
            string meisyoName = txtName.Text;
            string beforeKubun = txtBeforeType.Text;
            string kubun = txtType.Text;
            string kubunName = txtTypeName.Text;

            if (rdoNew.Checked)
            {
                // 担当者マスタの登録SQL生成
                command += "INSERT INTO meisyo_master ";
                command += "( ";
                command += "  meisyoCode ";
                command += ", meisyoName ";
                command += ", kubun ";
                command += ", kubunName ";
                command += ", kousinNichizi ";
                command += ", kanriKubun ";
                command += ") ";
                command += "VALUES ";
                command += "( ";
                command += "'" + meisyoCode + "' ";
                command += "," + "'" + meisyoName + "' ";
                command += "," + "'" + kubun + "' ";
                command += "," + "'" + kubunName + "' ";
                command += "," + "'" + registerDate + "' ";
                command += "," + "'' ";
                command += ") ";
                commands.Add(command);
            }
            else if (rdoCorrection.Checked)
            {
                // 担当者マスタの更新SQL生成
                if (!string.IsNullOrEmpty(kubun))
                {
                    command += "UPDATE meisyo_master SET ";
                    command += "  kubun = '" + kubun + "' ";
                    command += ", kubunName = '" + kubunName + "' ";
                    command += ", kousinNichizi = '" + registerDate + "' ";
                    command += ", kanriKubun = '' ";
                    command += "WHERE meisyoCode = '" + meisyoCode + "' ";
                    command += "AND kubun = '" + beforeKubun + "' ";
                    commands.Add(command);
                }
                command = string.Empty;
                command += "UPDATE meisyo_master SET ";
                command += "  meisyoName = '" + meisyoName + "' ";
                command += ", kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '' ";
                command += "WHERE meisyoCode = '" + meisyoCode + "' ";
                commands.Add(command);
            }

            return commands;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtNameCode.MaxLength = 3;  // 名称コード
            txtName.MaxLength = 10;     // 名称
            txtType.MaxLength = 2;      // 区分
            txtTypeName.MaxLength = 15; // 区分名

            // 入力制御イベント設定
            txtNameCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 名称コード :数字のみ入力可
            txtType.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 区分       :数値のみ入力可
        }
        #endregion

        #endregion
    }
}
