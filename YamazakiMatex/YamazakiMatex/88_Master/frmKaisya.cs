using System;
using System.Data;
using System.Windows.Forms;
using Resorce;
using Common;
using DB;

namespace Master
{
    public partial class frmKaisyaM : Common.ChildBaseForm
    {
        #region 変数宣言
        private CommonLogic commonLogic;

        private DBKaisyaMaster kaisyaMaster;
        private bool flgSaving = false;
        private bool flgSearch = false;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmKaisyaM()
        {
            InitializeComponent();
            commonLogic = new CommonLogic();
            kaisyaMaster = new DBKaisyaMaster();
        }
        #endregion
        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmKaisyaM_Load(object sender, EventArgs e)
        {
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtKaisya;
            // 画面初期化イベント実行
            initializeDisp();
        }
        #endregion
        #region 保存ボタン押下処理
        /// <summary>
        /// 保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //変数定義
            string queryMessage = string.Empty;
            string mode = string.Empty;
            int Result = 0;

            if (!btnSave.Enabled) return;
            flgSaving = true;

            // チェック処理
            if (!checkRequired())
            {
                return;
            }

            //確認メッセージ設定
            queryMessage = Messages.M0001;

            // 処理実行確認
            if (queryYesNo(queryMessage) == DialogResult.Yes)
            {
                //SQL取得
                string sqlCommand = createRegistSql();

                //SQL実行
                kaisyaMaster.startTransaction();

                Result = kaisyaMaster.executeDBUpdate(sqlCommand);

                if (rdoNew.Checked)
                {
                    mode = "登録処理";
                }
                else if (rdoCorrection.Checked)
                {
                    mode = "更新処理";
                }

                //処理結果
                if (Result < 0)
                {
                    errorOK(string.Format(Messages.M0011, "会社マスタ", mode));
                }
                else
                {
                    messageOK(string.Format(Messages.M0012, "会社マスタ", mode));
                }
                kaisyaMaster.endTransaction();
                btnCancel_Click(null, null);
            }

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
                // 確認メッセージを出力
                if (queryYesNo(string.Format(Messages.M0014, "取消してよろしいですか？")) == DialogResult.No)
                {
                    return;
                }
            }
            //画面初期表示状態に設定
            initializeDisp();
        }
        #endregion
        #region 画面項目編集中のキーボード押下イベント
        /// <summary>
        /// 画面項目編集中のキーボード押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmKaisyaM_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                // Enterキーが押下された場合
                case Keys.Enter:
                    // 編集中の項目が存在しない場合なにもしない
                    if (activeControlInfo.Control == null) break;
                    break;
                case Keys.Down:
                    if (this.activeControl is TextBox)
                    {
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        break;
                    }
                    break;
                case Keys.Up:
                    if (this.activeControl is TextBox)
                    {
                        this.SelectNextControl(this.ActiveControl, e.KeyCode == Keys.Down, true, true, true);
                        break;
                    }
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

        #region ビジネスロジック
        #region 会社マスタ情報設定処理
        /// <summary>
        /// 会社マスタ情報設定処理
        /// </summary>
        private bool setKaisyaMInfo()
        {
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            // マスタ情報を取得
            DataTable dt = kaisyaMaster.getKaisyaDataTable();
            if (dt == null || dt.Rows.Count == 0)
            {
                txtKaisya.Focus();
                return false;
            }

            // 取得データを画面項目に設定
            DataRow dRow = dt.Rows[0];
            txtKaisya.Text = Convert.ToString(dRow["kaisyaName"]);
            txtYubinNo.Text = Convert.ToString(dRow["zipCode"]);
            txtJyusho.Text = Convert.ToString(dRow["address"]);
            txtRenrakusaki1.Text = Convert.ToString(dRow["renrakusaki1"]);
            txtRenrakusaki2.Text = Convert.ToString(dRow["renrakusaki2"]);
            txtGaiyou.Text = Convert.ToString(dRow["gaiyou"]);
            txtKaisya.Focus();

            flgSearch = true;

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            return true;
        }
        #endregion

        #region 画面項目初期化処理
        /// <summary>
        /// 画面項目初期化処理
        /// </summary>
        /// <param name="type"></param>
        private void initializeDisp()
        {
            // 入力情報設定
            setInputInfo();

            // 会社名
            txtKaisya.Text = string.Empty;
            // 住所
            txtJyusho.Text = string.Empty;
            // 郵便番号
            txtYubinNo.Text = string.Empty;
            // 連絡先1
            txtRenrakusaki1.Text = string.Empty;
            // 連絡先2
            txtRenrakusaki2.Text = string.Empty;
            // 概要
            txtGaiyou.Text = string.Empty;

            //DBデータ設定
            setKaisyaMInfo();

            //ラジオボタン制御
            if (!string.IsNullOrEmpty(txtKaisya.Text))
            {
                //登録非活性
                rdoNew.Enabled = false;
                rdoCorrection.Enabled = true;
                rdoCorrection.Checked = true;
            }
            else
            {
                rdoCorrection.Enabled = false;
                rdoNew.Enabled = true;
                rdoNew.Checked = true;
            }
            txtKaisya.Focus();
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtKaisya.MaxLength = 15;     // 会社名
            txtYubinNo.MaxLength = 8;     // 郵便番号
            txtJyusho.MaxLength = 20;     // 住所
            txtRenrakusaki1.MaxLength = 13;       // 連絡先１
            txtRenrakusaki2.MaxLength = 13;        // 連絡先２
            txtGaiyou.MaxLength = 30;     // 概要

            this.KeyDown += new KeyEventHandler(FrmKaisyaM_KeyDown);
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
            //会社名入力チェック
            string text = string.Empty;

            if (string.IsNullOrEmpty(txtKaisya.Text))
            {
                errorItem = lblKaisya.Text;
            }


            // チェックエラーの場合
            if (!string.IsNullOrEmpty(errorItem))
            {
                errorOK(string.Format(Messages.M0020, errorItem));
                txtKaisya.Focus();
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 会社マスタ登録・更新SQL生成処理
        /// <summary>
        /// 会社マスタ登録・更新SQL生成処理
        /// </summary>
        /// <param name="mitumoriNo"></param>
        /// <param name="registerDate"></param>
        /// <returns></returns>
        private string createRegistSql()
        {
            string sql = string.Empty;
            //入力データ取得
            string kaisyaName = txtKaisya.Text;
            string zipCode = txtYubinNo.Text;
            string address = txtJyusho.Text;
            string renrakusaki1 = txtRenrakusaki1.Text;
            string renrakusaki2 = txtRenrakusaki2.Text;
            string gaiyou = txtGaiyou.Text;
            DateTime registerDate = DateTime.Now;

            if (rdoNew.Checked)
            {

                // 会社マスタ登録SQL生成
                sql += "INSERT INTO kaisya_master ";
                sql += "( ";
                sql += "  kaisyaName ";
                sql += ", zipCode ";
                sql += ", address ";
                sql += ", renrakusaki1 ";
                sql += ", renrakusaki2 ";
                sql += ", gaiyou ";
                sql += ", kousinNichizi ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "'" + kaisyaName + "' ";
                sql += "," + "'" + zipCode + "' ";
                sql += "," + "'" + address + "' ";
                sql += "," + "'" + renrakusaki1 + "' ";
                sql += "," + "'" + renrakusaki2 + "' ";
                sql += "," + "'" + gaiyou + "' ";
                sql += "," + "'" + registerDate.ToString("yyyyMMdd") + "' ";
                sql += ") ";
            }
            else if (rdoCorrection.Checked)
            {
                // 会社マスタ更新SQL生成
                sql = "UPDATE kaisya_master SET ";
                sql += "  kaisyaName = '" + kaisyaName + "' ";
                sql += ", zipCode = '" + zipCode + "' ";
                sql += ", address = '" + address + "' ";
                sql += ", renrakusaki1 = '" + renrakusaki1 + "' ";
                sql += ", renrakusaki2 = '" + renrakusaki2 + "' ";
                sql += ", gaiyou = '" + gaiyou + "' ";
                sql += ", kousinNichizi = '" + registerDate.ToString("yyyyMMdd") + "' ";
            }

            return sql;
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
                if (!string.IsNullOrEmpty(txtKaisya.Text) ||
                    !string.IsNullOrEmpty(txtJyusho.Text) ||
                    !string.IsNullOrEmpty(txtYubinNo.Text) ||
                    !string.IsNullOrEmpty(txtRenrakusaki1.Text) ||
                    !string.IsNullOrEmpty(txtRenrakusaki2.Text) ||
                    !string.IsNullOrEmpty(txtGaiyou.Text))
                {
                    result = true;
                }
            }
            else if (rdoCorrection.Checked)
            {
                if (flgSearch)
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion
        #endregion
    }
}
