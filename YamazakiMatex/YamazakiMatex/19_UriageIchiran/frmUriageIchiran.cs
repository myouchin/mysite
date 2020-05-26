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

namespace UriageIchiran
{
    /// <summary>
    /// 売上一覧画面
    /// </summary>
    public partial class frmUriageIchiran : Common.ChildBaseForm
    {
        #region 変数宣言
        private DateTime syoriDate;
        private DBKanriMaster kanriMaster;
        private CommonLogic commonLogic;
        private DBCommon tokuisakiSeikyuDataSelectDb;
        sfrmTokuisakiSearch fTokuisaki;
        private enum LastInputDateType
        {
            None = 0
          , TargetDateFrom = 1
          , TargetDateTo = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;
        private DataTable dataSourceDt;
        private DBTantousyaMaster tantousyaMaster;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmUriageIchiran()
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            tokuisakiSeikyuDataSelectDb = new DBCommon();
            fTokuisaki = new sfrmTokuisakiSearch(false);
            tantousyaMaster = new DBTantousyaMaster();
            dataSourceDt = new DataTable();
            foreach (DataGridViewColumn gClm in grdUriageList.Columns)
            {
                if (gClm.DefaultCellStyle.Format == "N0")
                {
                    dataSourceDt.Columns.Add(gClm.DataPropertyName, Type.GetType("System.Decimal"));
                }
                else
                {
                    dataSourceDt.Columns.Add(gClm.DataPropertyName, Type.GetType("System.String"));
                }
            }
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
            activeControlInfo.Control = txtCustomerCode;
            // 最大入力桁数設定
            setInputInfo();
            // 担当者コンボボックス設定
            setPersonnelCmb();

            btnCancel_Click(null, null);
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

        #region 取消ボタン押下イベント
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!btnCancel.Enabled) return;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtOfficesCode.Text = string.Empty;
            txtOfficesName.Text = string.Empty;
            cmbPersonnel.Text = string.Empty;
            txtTargetYMDDateFromYears.Text = string.Empty;
            txtTargetYMDDateFromMonth.Text = string.Empty;
            txtTargetYMDDateFromDays.Text = string.Empty;
            txtTargetYMDDateToYears.Text = string.Empty;
            txtTargetYMDDateToMonth.Text = string.Empty;
            txtTargetYMDDateToDays.Text = string.Empty;
            txtSubject1.Text = string.Empty;
            txtSubject2.Text = string.Empty;
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

            if (grdUriageList.CurrentCell != null)
            {
                try { grdUriageList.CurrentCell = null; } catch { }
            }

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;
                Common.CustomDateTimePicker inputObj = null;

                switch (lastInputDateType)
                {
                    case LastInputDateType.TargetDateFrom:
                        y = txtTargetYMDDateFromYears.Text;
                        m = txtTargetYMDDateFromMonth.Text;
                        d = txtTargetYMDDateFromDays.Text;
                        inputObj = dtpTargetYMDDateFrom;
                        break;
                    case LastInputDateType.TargetDateTo:
                        y = txtTargetYMDDateToYears.Text;
                        m = txtTargetYMDDateToMonth.Text;
                        d = txtTargetYMDDateToDays.Text;
                        inputObj = dtpTargetYMDDateTo;
                        break;
                }
                if (!checkDate(y, m, d, true, inputObj))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.TargetDateFrom.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateFromYears.Focus();
                    }
                    else if (LastInputDateType.TargetDateTo.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateToYears.Focus();
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
            setSearchButtonEnabled();
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

        #region 売上日付(自)のフォーカスインイベント
        /// <summary>
        /// 売上日付(自)のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 売上日付(自)のフォーカスアウトイベント
        /// <summary>
        /// 売上日付(自)のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetDateFrom;
            }
        }
        #endregion

        #region 売上日付(至)のフォーカスインイベント
        /// <summary>
        /// 売上日付(至)のフォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 売上日付(至)のフォーカスアウトイベント
        /// <summary>
        /// 売上日付(至)のフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetDateTo;
            }
        }
        #endregion

        #region 売上一覧グリッドのセル描画処理
        /// <summary>
        /// 売上一覧グリッドのセル描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdUriageList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // 品名でない列の処理
            if (e.RowIndex % grdUriageList.RowSegmentCount == 0 && e.ColumnIndex != clmHinmei.DisplayIndex)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
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

            // フォーカスインイベントを追加
            c.Enter -= new EventHandler(inputObject_Enter);
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
            // 売上日付(自)の場合
            else if (c.Name.Equals(txtTargetYMDDateFromYears.Name) ||
                     c.Name.Equals(txtTargetYMDDateFromMonth.Name) ||
                     c.Name.Equals(txtTargetYMDDateFromDays.Name) ||
                     c.Name.Equals(dtpTargetYMDDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetDateFrom_Leave);
            }
            // 売上日付(至)の場合
            else if (c.Name.Equals(txtTargetYMDDateToYears.Name) ||
                     c.Name.Equals(txtTargetYMDDateToMonth.Name) ||
                     c.Name.Equals(txtTargetYMDDateToDays.Name) ||
                     c.Name.Equals(dtpTargetYMDDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetDateTo_Leave);
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

        #region 入力情報設定処理
        /// <summary>
        /// 入力情報設定処理
        /// </summary>
        private void setInputInfo()
        {
            // 最大入力桁数設定
            txtCustomerCode.MaxLength = 5;              // 得意先コード
            txtOfficesCode.MaxLength = 3;               // 事業所コード
            cmbPersonnel.MaxLength = 10;                // 担当者名
            txtTargetYMDDateFromYears.MaxLength = 4;    // 売上日付(年)(自)
            txtTargetYMDDateFromMonth.MaxLength = 2;    // 売上日付(月)(自)
            txtTargetYMDDateFromDays.MaxLength = 2;     // 売上日付(日)(自)
            txtTargetYMDDateToYears.MaxLength = 4;      // 売上日付(年)(至)
            txtTargetYMDDateToMonth.MaxLength = 2;      // 売上日付(月)(至)
            txtTargetYMDDateToDays.MaxLength = 2;       // 売上日付(日)(至)
            txtSubject1.MaxLength = 20;                 // 件名１
            txtSubject2.MaxLength = 20;                 // 件名２

            // 入力制御イベント設定
            txtCustomerCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);             // 得意先コード :数字のみ入力可
            txtOfficesCode.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);              // 事業所コード :数字のみ入力可
            txtTargetYMDDateFromYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 売上日付(年)(自) :数字のみ入力可
            txtTargetYMDDateFromMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);   // 売上日付(月)(自) :数字のみ入力可
            txtTargetYMDDateFromDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);    // 売上日付(日)(自) :数字のみ入力可
            txtTargetYMDDateToYears.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 売上日付(年)(至) :数字のみ入力可
            txtTargetYMDDateToMonth.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);     // 売上日付(月)(至) :数字のみ入力可
            txtTargetYMDDateToDays.KeyPress += new KeyPressEventHandler(txtDigitalOnlyInput_KeyPress);      // 売上日付(日)(至) :数字のみ入力可
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

            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                errorItem = lblCustomerCode.Text;
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

        #region 売上一覧グリッド設定処理
        /// <summary>
        /// 売上一覧グリッド設定処理
        /// </summary>
        private void setGridData()
        {
            string customerCode = txtCustomerCode.Text;
            string officesCode = txtOfficesCode.Text;
            string personnel = cmbPersonnel.Text;
            string subject1 = txtSubject1.Text;
            string subject2 = txtSubject2.Text;
            DBCommon common = new DBCommon();
            string sql = string.Empty;
            sql += "SELECT DATE_FORMAT(uh.denpyoHizuke, '%c月%e日') AS denpyoHizuke " + "\r";
            sql += "     , uh.denpyoNo " + "\r";
            sql += "     , CONCAT(uh.juchuNoTop,'-',uh.juchuNoMid,'-',uh.juchuNoBtm) AS chumonNo " + "\r";
            sql += "     , ub.shouhinName1 " + "\r";
            sql += "     , ub.shouhinName2 " + "\r";
            sql += "     , IFNULL(ub.suryo, 0) AS suryo " + "\r";
            sql += "     , ub.tani " + "\r";
            sql += "     , IFNULL(ub.tanka, 0) AS tanka " + "\r";
            sql += "     , IFNULL(ub.kingaku, 0) AS kingaku " + "\r";
            sql += "FROM (SELECT * FROM uriage_header WHERE (kanriKubun IS NULL OR kanriKubun <> '9')) uh " + "\r";
            sql += "INNER JOIN (SELECT * FROM uriage_body) ub " + "\r";
            sql += "ON (uh.denpyoNo = ub.denpyoNo) " + "\r";
            sql += "WHERE IFNULL(ub.flgPrint, 0) = 1 " + "\r";
            if (!string.IsNullOrEmpty(customerCode)) sql += "AND uh.tokuisakiCode = '" + customerCode + "' " + "\r";
            if (!string.IsNullOrEmpty(officesCode)) sql += "AND uh.jigyousyoCode = '" + officesCode + "' " + "\r";
            if (!string.IsNullOrEmpty(personnel)) sql += "AND uh.tantousyaName = '" + personnel + "' " + "\r";
            try
            {
                DateTime targetDateFrom = Convert.ToDateTime(txtTargetYMDDateFromYears.Text + "/" + txtTargetYMDDateFromMonth.Text + "/" + txtTargetYMDDateFromDays.Text);
                sql += "AND uh.denpyoHizuke >= '" + targetDateFrom + "' " + "\r";
            }
            catch
            {
            }
            try
            {
                DateTime targetDateTo = Convert.ToDateTime(txtTargetYMDDateToYears.Text + "/" + txtTargetYMDDateToMonth.Text + "/" + txtTargetYMDDateToDays.Text);
                sql += "AND uh.denpyoHizuke <= '" + targetDateTo + "' " + "\r";
            }
            catch
            {
            }
            if (!string.IsNullOrEmpty(subject1)) sql += "AND uh.kenmei1 LIKE '%" + subject1 + "%' " + "\r";
            if (!string.IsNullOrEmpty(subject2)) sql += "AND uh.kenmei2 LIKE '%" + subject2 + "%' " + "\r";
            sql += "ORDER BY uh.denpyoHizuke, uh.denpyoNo, ub.rowNo " + "\r";
            DataTable uriageDt = common.executeNoneLockSelect(sql);

            dataSourceDt.Clear();
            int topRowIndex = 0;
            int btmRowIndex = 0;
            string wkDenpyoNo = string.Empty;
            bool flgDispHeadInfo = false;
            foreach (DataRow row in uriageDt.Rows)
            {
                dataSourceDt.Rows.Add();
                dataSourceDt.Rows.Add();
                topRowIndex = dataSourceDt.Rows.Count - 2;
                btmRowIndex = dataSourceDt.Rows.Count - 1;
                if (!wkDenpyoNo.Equals(Convert.ToString(row["denpyoNo"])))
                {
                    flgDispHeadInfo = true;
                    wkDenpyoNo = Convert.ToString(row["denpyoNo"]);
                }
                else
                {
                    flgDispHeadInfo = false;
                }

                // 上段行の設定
                dataSourceDt.Rows[topRowIndex]["hinmei"] = row["shouhinName1"];                                     // 品名

                // 下段行の設定
                dataSourceDt.Rows[btmRowIndex]["monthDay"] = flgDispHeadInfo ? row["denpyoHizuke"] : string.Empty;  // 伝票日付
                dataSourceDt.Rows[btmRowIndex]["denpyoNo"] = flgDispHeadInfo ? row["denpyoNo"] : string.Empty;      // 伝票番号
                dataSourceDt.Rows[btmRowIndex]["chumonNo"] = flgDispHeadInfo ? row["chumonNo"] : string.Empty;      // 注文番号
                dataSourceDt.Rows[btmRowIndex]["hinmei"] = row["shouhinName2"];                                     // 品名
                dataSourceDt.Rows[btmRowIndex]["suryo"] = row["suryo"];                                             // 数量
                dataSourceDt.Rows[btmRowIndex]["tani"] = row["tani"];                                               // 単位
                dataSourceDt.Rows[btmRowIndex]["tanka"] = row["tanka"];                                             // 単価
                dataSourceDt.Rows[btmRowIndex]["kingaku"] = row["kingaku"];                                         // 金額
                dataSourceDt.AcceptChanges();
            }

            grdUriageList.DataSource = dataSourceDt.Copy();

            if (dataSourceDt.Rows.Count == 0)
            {
                messageOK(Messages.M0064);
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

        #region 担当者コンボボックスの設定
        /// <summary>
        /// 担当者コンボボックスの設定
        /// </summary>
        private void setPersonnelCmb()
        {
            // 担当者取得
            DataTable tantousyaDt = tantousyaMaster.getTantousyaDataTable(string.Empty, string.Empty);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPersonnel, tantousyaDt, "tantousyaCode", "tantousyaName");
        }
        #endregion

        #endregion
    }
}
