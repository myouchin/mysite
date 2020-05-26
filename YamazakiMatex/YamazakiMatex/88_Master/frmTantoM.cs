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

namespace Master
{
    public partial class frmTantoM : ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private RadioButton activeRadioButton = null;
        private bool flgSettingEnable = false;
        private bool flgSaving = false;
        private CommonLogic commonLogic;
        int selectingRowIndex = -1;
        DBTantousyaMaster masterDataSelectDb;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmTantoM()
        {
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            masterDataSelectDb = new DBTantousyaMaster();
            InitializeComponent();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTantoM_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtPersonCode;

            // ラジオボタン変更処理実行
            inputModeChange(rdoNew);
            // 入力情報設定
            setInputInfo();
            // グリッドデータの設定
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
            // 必須チェック処理
            if (!checkRequired())
            {
                return;
            }
            // 新規作成の場合
            if (rdoNew.Checked)
            {
                // 担当者コードの存在チェック
                if (checkExistsTantousyaInfo())
                {
                    errorOK(Messages.M0051);
                    return;
                }
            }
            // 訂正の場合
            else if (rdoCorrection.Checked)
            {
                // 担当者コードの存在チェック
                if (checkExistsTantousyaInfo())
                {
                    errorOK(Messages.M0052);
                    return;
                }
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
            else if (rdoDelete.Checked)
            {
                queryMessage = Messages.M0002;
            }

            // 処理実行確認
            if (queryYesNo(queryMessage) == DialogResult.Yes)
            {
                masterDataSelectDb.startTransaction();
                DateTime registerDate = DateTime.Now;
                string sqlTokuisakiMasterCommand = createRegistSql(registerDate);

                // 得意先マスタの更新
                masterDataSelectDb.executeDBUpdate(sqlTokuisakiMasterCommand);

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
                    else if (rdoDelete.Checked)
                    {
                        processName = "削除処理";
                    }
                    errorOK(string.Format(Messages.M0011, "担当者マスタ", processName));
                    masterDataSelectDb.endTransaction();
                    return;
                }
                else
                {
                    string message1 = "担当者コード:" + txtPersonCode.Text;
                    string message2;
                    if (rdoNew.Checked)
                    {
                        message2 = "登録";
                    }
                    else if (rdoCorrection.Checked)
                    {
                        message2 = "訂正";
                    }
                    else
                    {
                        message2 = "削除";
                    }
                    messageOK(string.Format(Messages.M0012, message1, message2));
                    masterDataSelectDb.endTransaction();
                    btnCancel_Click(null, null);
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
            closedForm();
        }
        #endregion

        #region グリッドセル押下イベント
        /// <summary>
        /// グリッドセル押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPersonList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectingRowIndex != e.RowIndex)
            {
                selectingRowIndex = e.RowIndex;
                DataRow selectRow = ((DataTable)grdPersonList.DataSource).Rows[selectingRowIndex];
                txtPersonCode.Text = Convert.ToString(selectRow[DBFileLayout.TantousyaMasterFile.dcTantousyaCode]);
                txtPersonName.Text = Convert.ToString(selectRow[DBFileLayout.TantousyaMasterFile.dcTantousyaName]);
                txtAuthority.Text = Convert.ToString(selectRow[DBFileLayout.TantousyaMasterFile.dcKengen]);
                txtPass.Text = Convert.ToString(selectRow[DBFileLayout.TantousyaMasterFile.dcPassWord]);
                txtMail.Text = Convert.ToString(selectRow[DBFileLayout.TantousyaMasterFile.dcMail]);
                txtOrderNo.Text = Convert.ToString(selectRow[DBFileLayout.TantousyaMasterFile.dcChumonNo]);
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
            rdoNew.Checked = (rdoNew.Name == radio.Name);
            rdoCorrection.Checked = (rdoCorrection.Name == radio.Name);
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

        #endregion

        #region ビジネスロジック

        #region グリッドデータ設定処理
        /// <summary>
        /// グリッドデータ設定処理
        /// </summary>
        private void setGridData()
        {
            DataTable tantousyaDt = masterDataSelectDb.getTantousyaDataTable(string.Empty, string.Empty, false);
            tantousyaDt.Columns.Add(clmBeforePersonCode.DataPropertyName, Type.GetType("System.String"));
            tantousyaDt.Columns.Add(clmBeforePersonName.DataPropertyName, Type.GetType("System.String"));
            tantousyaDt.Columns.Add(clmBeforeAuthority.DataPropertyName, Type.GetType("System.String"));
            tantousyaDt.Columns.Add(clmBeforePass.DataPropertyName, Type.GetType("System.String"));
            tantousyaDt.Columns.Add(clmBeforeMail.DataPropertyName, Type.GetType("System.String"));
            tantousyaDt.Columns.Add(clmBeforeOrderNo.DataPropertyName, Type.GetType("System.String"));

            foreach (DataRow dRow in tantousyaDt.Rows)
            {
                dRow[clmBeforePersonCode.DataPropertyName] = Convert.ToString(dRow[clmPersonCode.DataPropertyName]);
                dRow[clmBeforePersonName.DataPropertyName] = Convert.ToString(dRow[clmPersonName.DataPropertyName]);
                dRow[clmBeforeAuthority.DataPropertyName] = Convert.ToString(dRow[clmAuthority.DataPropertyName]);
                dRow[clmBeforePass.DataPropertyName] = Convert.ToString(dRow[clmPass.DataPropertyName]);
                dRow[clmBeforeMail.DataPropertyName] = Convert.ToString(dRow[clmMail.DataPropertyName]);
                dRow[clmBeforeOrderNo.DataPropertyName] = Convert.ToString(dRow[clmOrderNo.DataPropertyName]);
            }
            tantousyaDt.AcceptChanges();

            grdPersonList.DataSource = tantousyaDt;
            selectingRowIndex = -1;
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

            // グリッドデータ設定
            setGridData();

            #region 共通初期値設定

            txtPersonCode.Text = string.Empty;
            txtPersonName.Text = string.Empty;
            txtAuthority.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtOrderNo.Text = string.Empty;

            #endregion

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
            rdoNew.Click -= new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click -= new EventHandler(inputModeRadio_Click);
            rdoReference.Click -= new EventHandler(inputModeRadio_Click);
            rdoDelete.Click -= new EventHandler(inputModeRadio_Click);
            #region モード別編集可否設定
            // 新規
            if (rdoNew.Checked)
            {
                // 入力制御設定
                txtPersonCode.ReadOnly = false;
                txtPersonName.ReadOnly = false;
                txtAuthority.ReadOnly = false;
                txtPass.ReadOnly = false;
                txtMail.ReadOnly = false;
                txtOrderNo.ReadOnly = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPersonCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 訂正
            else if (rdoCorrection.Checked)
            {
                // 入力制御設定
                txtPersonCode.ReadOnly = true;
                txtPersonName.ReadOnly = false;
                txtAuthority.ReadOnly = false;
                txtPass.ReadOnly = false;
                txtMail.ReadOnly = false;
                txtOrderNo.ReadOnly = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPersonCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 参照
            else if (rdoReference.Checked)
            {
                // 入力制御設定
                txtPersonCode.ReadOnly = true;
                txtPersonName.ReadOnly = true;
                txtAuthority.ReadOnly = true;
                txtPass.ReadOnly = true;
                txtMail.ReadOnly = true;
                txtOrderNo.ReadOnly = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPersonCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：保存";
            }
            // 削除
            else if (rdoDelete.Checked)
            {
                // 入力制御設定
                txtPersonCode.ReadOnly = true;
                txtPersonName.ReadOnly = true;
                txtAuthority.ReadOnly = true;
                txtPass.ReadOnly = true;
                txtMail.ReadOnly = true;
                txtOrderNo.ReadOnly = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;

                // 初期フォーカス設定
                txtPersonCode.Focus();

                // 表示文字列設定
                btnSave.Text = "F10：実行";
            }
            #endregion
            rdoNew.Click += new EventHandler(inputModeRadio_Click);
            rdoCorrection.Click += new EventHandler(inputModeRadio_Click);
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
            if (rdoNew.Checked)
            {
                if (!string.IsNullOrEmpty(txtPersonCode.Text) ||
                    !string.IsNullOrEmpty(txtPersonName.Text) ||
                    !string.IsNullOrEmpty(txtAuthority.Text) ||
                    !string.IsNullOrEmpty(txtPass.Text) ||
                    !string.IsNullOrEmpty(txtMail.Text) ||
                    !string.IsNullOrEmpty(txtOrderNo.Text))
                {
                    result = true;
                }
            }
            else if (rdoCorrection.Checked)
            {
                result = true;
            }
            else if (rdoDelete.Checked)
            {
                result = true;
            }
            return result;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtPersonCode.MaxLength = 3;    // 担当者コード
            txtPersonName.MaxLength = 10;   // 担当者名
            txtAuthority.MaxLength = 1;     // 権限
            txtPass.MaxLength = 8;          // パスワード
            txtMail.MaxLength = 40;         // メールアドレス
            txtOrderNo.MaxLength = 5;       // 注文No

            // IMEMODE設定
            txtPass.ImeMode = ImeMode.Disable;
            txtMail.ImeMode = ImeMode.Disable;

            // 入力制御イベント設定
            txtPersonCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 担当者コード :数字のみ入力可
            txtAuthority.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 権限         :数値のみ入力可
            txtOrderNo.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 注文No       :数字のみ入力可
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

            if (string.IsNullOrEmpty(txtPersonCode.Text))
            {
                errorItem = lblPersonCode.Text;
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

        #region 担当者情報の存在チェック処理
        /// <summary>
        /// 担当者情報の存在チェック処理
        /// </summary>
        /// <returns></returns>
        private bool checkExistsTantousyaInfo()
        {
            bool ret = false;

            DBTantousyaMaster tantousyaMaster = new DBTantousyaMaster();
            List<DBFileLayout.TantousyaMasterFile> shouhinInfos = tantousyaMaster.getTantousyaInfo(txtPersonCode.Text, true);

            if (rdoNew.Checked)
            {
                if (shouhinInfos.Count > 0)
                {
                    ret = true;
                }
            }
            else if (rdoCorrection.Checked)
            {
                if (shouhinInfos.Count > 0 && Consts.KanriCodeTypes.TYPE9.Equals(shouhinInfos[0].KanriKubun))
                {
                    ret = true;
                }
            }

            return ret;
        }
        #endregion

        #region 担当者マスタの更新SQL生成処理
        /// <summary>
        /// 商品マスタの更新SQL生成処理
        /// </summary>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createRegistSql(DateTime registerDate)
        {
            string command = string.Empty;

            string tantousyaCode = txtPersonCode.Text;
            string tantousyaName = txtPersonName.Text;
            string kengen = txtAuthority.Text;
            string passWord = txtPass.Text;
            string mail = txtMail.Text;
            string chumonNo = txtOrderNo.Text;

            if (rdoNew.Checked)
            {
                // 担当者マスタの登録SQL生成
                command += "INSERT INTO tantousya_master ";
                command += "( ";
                command += "  tantousyaCode ";
                command += ", tantousyaName ";
                command += ", kengen ";
                command += ", passWord ";
                command += ", chumonNo ";
                command += ", mail ";
                command += ", kousinNichizi ";
                command += ", kanriKubun ";
                command += ") ";
                command += "VALUES ";
                command += "( ";
                command += "'" + tantousyaCode + "' ";
                command += "," + "'" + tantousyaName + "' ";
                command += "," + "'" + kengen + "' ";
                command += "," + "'" + passWord + "' ";
                command += "," + chumonNo + " ";
                command += "," + "'" + mail + "' ";
                command += "," + "'" + registerDate + "' ";
                command += "," + "'' ";
                command += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 担当者マスタの更新SQL生成
                command = "UPDATE tantousya_master SET ";
                command += "  tantousyaCode = '" + tantousyaCode + "' ";
                command += ", tantousyaName = '" + tantousyaName + "' ";
                command += ", kengen = '" + kengen + "' ";
                command += ", passWord = '" + passWord + "' ";
                command += ", chumonNo = " + chumonNo + " ";
                command += ", mail = '" + mail + "' ";
                command += ", kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '' ";
                command += "WHERE tantousyaCode = '" + tantousyaCode + "' ";
            }
            else
            {
                // 担当者マスタの論理削除SQL生成
                command = "UPDATE tantousya_master SET ";
                command += "  kousinNichizi = '" + registerDate + "' ";
                command += ", kanriKubun = '" + Consts.KanriCodeTypes.TYPE9 + "' ";
                command += "WHERE tantousyaCode = '" + tantousyaCode + "' ";
            }

            return command;
        }
        #endregion

        #endregion
    }
}
