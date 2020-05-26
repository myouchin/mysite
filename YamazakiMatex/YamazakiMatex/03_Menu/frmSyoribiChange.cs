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
using SubForm;

namespace Menu
{
    /// <summary>
    /// 処理日変更画面
    /// </summary>
    public partial class frmSyoribiChange : ChildBaseForm
    {
        #region 変数宣言
        private bool flgInit = false;
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private CommonLogic commonLogic;
        private DBShiharaiShime syoribiDb;
        private enum LastInputDateType
        {
            None = 0
          , ProcessingDate = 1
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSyoribiChange()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            syoribiDb = new DBShiharaiShime();
            commonLogic = new CommonLogic();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiharaiShimebiKoshin_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
            // 入力情報設定
            setInputInfo();

            dtpProcessingDate.Value = syoriDate;
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
                    btnExecution_Click(null, null);
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

        #region 処理日付のフォーカスインイベント
        /// <summary>
        /// 処理日付のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessingDate_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.ProcessingDate)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 処理日付のフォーカスアウトイベント
        /// <summary>
        /// 処理日付のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessingDate_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.ProcessingDate;
                if ((sender is TextBox))
                {
                    lastInputDateText = (TextBox)sender;
                }
            }
            else
            {
                lastInputDateType = LastInputDateType.ProcessingDate;
            }
        }
        #endregion

        #region 実行ボタン押下イベント
        /// <summary>
        /// 実行ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecution_Click(object sender, EventArgs e)
        {
            syoribiDb.startTransaction();

            string command = string.Empty;
            string syoribi = txtProcessingDateYears.Text;
            syoribi += (txtProcessingDateMonth.Text.Length == 1 ? "0" : string.Empty) + txtProcessingDateMonth.Text;
            syoribi += (txtProcessingDateDays.Text.Length == 1 ? "0" : string.Empty) + txtProcessingDateDays.Text;

            // 処理日の更新
            command += "UPDATE kanri_master SET ";
            command += "  koumoku2 = '" + syoribi + "' ";
            command += ", kousinNichizi = '" + DateTime.Now + "' ";
            command += "WHERE kanriCode = '" + Consts.KanriCodes.SyoriDate + "' ";
            syoribiDb.executeDBUpdate(command);

            syoribiDb.endTransaction();

            btnClose_Click(null, null);
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

            if (!flgInit && !lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.ProcessingDate:
                        y = txtProcessingDateYears.Text;
                        m = txtProcessingDateMonth.Text;
                        d = txtProcessingDateDays.Text;
                        inputObj = dtpProcessingDate;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.ProcessingDate.Equals(lastInputDateType))
                    {
                        txtProcessingDateYears.Focus();
                    }
                    return;
                }
            }

            if (c is CustomTextBox)
            {
                ((CustomTextBox)c).BeforeValue = ((CustomTextBox)c).Text;
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
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

            // 締年月日の場合
            if (c.Name.Equals(txtProcessingDateYears.Name) ||
                c.Name.Equals(txtProcessingDateMonth.Name) ||
                c.Name.Equals(txtProcessingDateDays.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.ProcessingDate_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.ProcessingDate_Leave);
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

        #region 有効日付チェック処理
        /// <summary>
        /// 有効日付チェック処理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool checkDate(string y, string m, string d, bool flgEmptyAcceptable, Common.CustomDateTimePicker inputObj)
        {
            bool ret = false;

            if (flgEmptyAcceptable && string.IsNullOrEmpty(y + m + d))
            {
                ret = true;
            }
            else
            {
                DateTime date;
                DateTime wkdate;
                ret = DateTime.TryParse(y + "/" + m + "/" + d, out date);
                if (ret && inputObj != null)
                {
                    wkdate = date.AddDays(1);
                    inputObj.Value = wkdate;
                    inputObj.Value = date;
                }
            }
            return ret;
        }
        #endregion

        #region 入力情報設定
        /// <summary>
        /// 入力情報設定
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtProcessingDateYears.MaxLength = 4; // 請求締日(年)
            txtProcessingDateMonth.MaxLength = 2; // 請求締日(月)
            txtProcessingDateDays.MaxLength = 2;  // 請求締日(日)

            // 入力制御イベント設定
            txtProcessingDateYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求締日(年):数字のみ入力可
            txtProcessingDateMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress); // 請求締日(月):数字のみ入力可
            txtProcessingDateDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);  // 請求締日(日):数字のみ入力可
        }
        #endregion

        #endregion
    }
}
