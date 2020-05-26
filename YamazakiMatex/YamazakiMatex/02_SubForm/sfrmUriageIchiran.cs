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

namespace SubForm
{
    /// <summary>
    /// 売上関連データ一覧画面
    /// </summary>
    public partial class sfrmUriageIchiran : Common.ChildBaseForm
    {
        List<DataGridViewRow> gRows;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        private const string dateTypeJuchuKey = "juchu";
        private string dateTypeJuchuValue = "受注日付";
        private const string dateTypeHachuKey = "hachu";
        private string dateTypeHachuValue = "発注日付";
        private const string dateTypeNouhinsyoKey = "nouhinsyo";
        private string dateTypeNouhinsyoValue = "納品書日付";
        private const string dateTypeShireKey = "shire";
        private string dateTypeShireValue = "仕入日付";
        private enum LastInputDateType
        {
            None = 0
          , TargetYMDDateFrom = 1
          , TargetYMDDateTo = 2
        }
        private LastInputDateType lastInputDateType = LastInputDateType.None;
        private TextBox lastInputDateText = null;

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public sfrmUriageIchiran()
        {
            commonLogic = new CommonLogic();
            InitializeComponent();
            setContorolLayout(this);
            createDateTypeCommbo();
            btnCancel_Click(null, null);
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
        }
        #endregion

        #region 閉じるボタン押下イベント
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            closedForm();
        }
        #endregion

        #region 一覧描画イベント
        /// <summary>
        /// 一覧描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (flgInitializeGrid)
            {
                if (grdSearchList.Rows.Count > 0) grdSearchList.Rows[0].Selected = false;
                flgInitializeGrid = false;
            }
        }
        #endregion

        #region 一覧データ設定処理
        /// <summary>
        /// 一覧データ設定処理
        /// </summary>
        private void setGridData()
        {
            flgSetGridData = true;
            DBCommon db = new DBCommon();
            string sql = string.Empty;
            sql += "SELECT JuchuNo ";
            sql += "     , JuchuDate ";
            sql += "     , HachuNo ";
            sql += "     , HachuDate ";
            sql += "     , NouhinsyoNo ";
            sql += "     , NouhinsyoDate ";
            sql += "     , ShireNo ";
            sql += "     , ShireDate ";
            sql += "FROM ( ";
            sql += "      SELECT CONCAT(jh.juchuNoTop, jh.juchuNoMid, jh.juchuNoBtm) AS JuchuNo ";
            sql += "           , jh.denpyoHizuke AS JuchuDate ";
            sql += "           , jh.denpyoNo AS HachuNo ";
            sql += "           , jh.denpyoHizuke AS HachuDate ";
            sql += "           , uh.denpyoNo AS NouhinsyoNo ";
            sql += "           , uh.denpyoHizuke AS NouhinsyoDate ";
            sql += "           , sh.shireNo AS ShireNo ";
            sql += "           , sh.denpyoHizuke AS ShireDate ";
            sql += "           , 1 AS DataType ";
            sql += "           , jh.denpyoHizuke AS OrderDate ";
            sql += "      FROM ( ";
            sql += "            SELECT denpyoNo ";
            sql += "                 , denpyoHizuke ";
            sql += "                 , juchuNoTop ";
            sql += "                 , juchuNoMid ";
            sql += "                 , juchuNoBtm ";
            sql += "            FROM juchu_header ";
            sql += "            WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "           ) jh ";
            sql += "      LEFT JOIN ( ";
            sql += "                 SELECT denpyoNo ";
            sql += "                      , denpyoHizuke ";
            sql += "                      , juchuNoTop ";
            sql += "                      , juchuNoMid ";
            sql += "                      , juchuNoBtm ";
            sql += "                 FROM uriage_header ";
            sql += "                 WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "                ) uh ";
            sql += "      ON (jh.juchuNoTop = uh.juchuNoTop AND jh.juchuNoMid = uh.juchuNoMid AND jh.juchuNoBtm = uh.juchuNoBtm) ";
            sql += "      LEFT JOIN ( ";
            sql += "                 SELECT shireNo ";
            sql += "                      , denpyoHizuke ";
            sql += "                      , uriageDenpyoNo ";
            sql += "                 FROM shire_header ";
            sql += "                 WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "                ) sh ";
            sql += "      ON (uh.denpyoNo = sh.uriageDenpyoNo) ";
            sql += "      UNION ALL ";
            sql += "      SELECT NULL AS JuchuNo ";
            sql += "           , NULL AS JuchuDate ";
            sql += "           , NULL AS HachuNo ";
            sql += "           , NULL AS HachuDate ";
            sql += "           , uh.denpyoNo AS NouhinsyoNo ";
            sql += "           , uh.denpyoHizuke AS NouhinsyoDate ";
            sql += "           , sh.shireNo AS ShireNo ";
            sql += "           , sh.denpyoHizuke AS ShireDate ";
            sql += "           , 2 AS DataType ";
            sql += "           , uh.denpyoHizuke AS OrderDate ";
            sql += "      FROM (SELECT * ";
            sql += "            FROM uriage_header ";
            sql += "            WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "            AND CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm)  = '') uh ";
            sql += "      LEFT JOIN ( ";
            sql += "                 SELECT shireNo ";
            sql += "                      , denpyoHizuke ";
            sql += "                      , uriageDenpyoNo ";
            sql += "                 FROM shire_header ";
            sql += "                 WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "                ) sh ";
            sql += "      ON (uh.denpyoNo = sh.uriageDenpyoNo) ";
            sql += "      UNION ALL ";
            sql += "      SELECT NULL AS JuchuNo ";
            sql += "           , NULL AS JuchuDate ";
            sql += "           , NULL AS HachuNo ";
            sql += "           , NULL AS HachuDate ";
            sql += "           , NULL AS NouhinsyoNo ";
            sql += "           , NULL AS NouhinsyoDate ";
            sql += "           , shireNo AS ShireNo ";
            sql += "           , denpyoHizuke AS ShireDate ";
            sql += "           , 3 AS DataType ";
            sql += "           , denpyoHizuke AS OrderDate ";
            sql += "      FROM shire_header ";
            sql += "      WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "      AND CONCAT(juchuNoTop, juchuNoMid, juchuNoBtm)  = '' ";
            sql += "      AND uriageDenpyoNo  = '' ";
            sql += "     ) uriageIchiran ";
            sql += "WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(txtTargetYMDDateFromYears.Text) ||
                !string.IsNullOrEmpty(txtTargetYMDDateFromMonth.Text) ||
                !string.IsNullOrEmpty(txtTargetYMDDateFromDays.Text) ||
                !string.IsNullOrEmpty(txtTargetYMDDateToYears.Text) ||
                !string.IsNullOrEmpty(txtTargetYMDDateToMonth.Text) ||
                !string.IsNullOrEmpty(txtTargetYMDDateToDays.Text))
            {
                string format;
                switch (Convert.ToString(cmbDateType.SelectedValue))
                {
                    case (dateTypeJuchuKey):
                        format = "JuchuDate";
                        break;
                    case (dateTypeHachuKey):
                        format = "HachuDate";
                        break;
                    case (dateTypeNouhinsyoKey):
                        format = "NouhinsyoDate";
                        break;
                    case (dateTypeShireKey):
                        format = "ShireDate";
                        break;
                    default:
                        format = string.Empty;
                        break;
                }
                try
                {
                    string strTargetDateFrom = txtTargetYMDDateFromYears.Text;
                    strTargetDateFrom += "-" + txtTargetYMDDateFromMonth.Text;
                    strTargetDateFrom += "-" + txtTargetYMDDateFromDays.Text;
                    DateTime targetDateFrom = Convert.ToDateTime(strTargetDateFrom);
                    if (!string.IsNullOrEmpty(format)) sql += string.Format("AND ({0} IS NOT NULL AND {0} >= '" + targetDateFrom + "') ", format);
                }
                catch
                {
                }
                try
                {
                    string strTargetDateTo = txtTargetYMDDateToYears.Text;
                    strTargetDateTo += "-" + txtTargetYMDDateToMonth.Text;
                    strTargetDateTo += "-" + txtTargetYMDDateToDays.Text;
                    DateTime targetDateTo = Convert.ToDateTime(strTargetDateTo);
                    if (!string.IsNullOrEmpty(format)) sql += string.Format("AND ({0} IS NOT NULL AND {0} <= '" + targetDateTo + "') ", format);
                }
                catch
                {
                }
            }
            sql += "ORDER BY uriageIchiran.DataType, uriageIchiran.OrderDate ";

            DataTable dt = db.executeNoneLockSelect(sql);

            grdSearchList.DataSource = dt;
            gRows = new List<DataGridViewRow>();
            flgSetGridData = false;
        }
        #endregion

        #region 一覧再表示ボタン押下イベント
        /// <summary>
        /// 一覧再表示ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            flgInitializeGrid = true;
            setGridData();
        }
        #endregion

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfrmHachuSearch_Load(object sender, EventArgs e)
        {
            setGridData();
        }
        #endregion

        #region 検索条件日付区分コンボボックス生成処理
        /// <summary>
        /// 検索条件日付区分コンボボックス生成処理
        /// </summary>
        private void createDateTypeCommbo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("value");
            dt.Rows.Add(new object[] { dateTypeJuchuKey, dateTypeJuchuValue });
            dt.Rows.Add(new object[] { dateTypeHachuKey, dateTypeHachuValue });
            dt.Rows.Add(new object[] { dateTypeNouhinsyoKey, dateTypeNouhinsyoValue });
            dt.Rows.Add(new object[] { dateTypeShireKey, dateTypeShireValue });
            commonLogic.setComboBoxDataSource(ref cmbDateType, dt, "key", "value");
        }
        #endregion

        #region 対象年月日(FROM)フォーカスインイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDDateFrom_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYMDDateFrom)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月日(FROM)フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(FROM)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDDateFrom_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYMDDateFrom;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYMDDateFrom;
            }
        }
        #endregion

        #region 対象年月日(TO)フォーカスインイベント
        /// <summary>
        /// 対象年月日(TO)フォーカスインイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDDateTo_Enter(object sender, EventArgs e)
        {
            if (lastInputDateType == LastInputDateType.TargetYMDDateTo)
            {
                lastInputDateType = LastInputDateType.None;
                lastInputDateText = null;
            }
        }
        #endregion

        #region 対象年月日(TO)フォーカスアウトイベント
        /// <summary>
        /// 対象年月日(TO)フォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetYMDDateTo_Leave(object sender, EventArgs e)
        {
            if (!(sender is DateTimePicker))
            {
                lastInputDateType = LastInputDateType.TargetYMDDateTo;
                lastInputDateText = (TextBox)sender;
            }
            else
            {
                lastInputDateType = LastInputDateType.TargetYMDDateTo;
            }
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

            // 対象年月日(FROM)の場合
            if (c.Name.Equals(txtTargetYMDDateFromYears.Name) ||
                c.Name.Equals(txtTargetYMDDateFromMonth.Name) ||
                c.Name.Equals(txtTargetYMDDateFromDays.Name) ||
                c.Name.Equals(dtpTargetYMDDateFrom.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetYMDDateFrom_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetYMDDateFrom_Leave);
            }
            // 対象年月日(TO)の場合
            else if (c.Name.Equals(txtTargetYMDDateToYears.Name) ||
                     c.Name.Equals(txtTargetYMDDateToMonth.Name) ||
                     c.Name.Equals(txtTargetYMDDateToDays.Name) ||
                     c.Name.Equals(dtpTargetYMDDateTo.Name))
            {
                // フォーカスインイベントを追加
                c.Enter += new EventHandler(this.txtTargetYMDDateTo_Enter);
                // フォーカスアウトイベントを追加
                c.Leave += new System.EventHandler(this.txtTargetYMDDateTo_Leave);
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
                // F1キーが押下された場合
                case Keys.F1:
                    // 取消処理を実行
                    button7_Click(null, null);
                    break;
                // F11キーが押下された場合
                case Keys.F11:
                    // 取消処理を実行
                    btnCancel_Click(null, null);
                    break;
                // F12キーが押下された場合
                case Keys.F12:
                    // 閉じる処理を実行
                    button10_Click(null, null);
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

            if (!lastInputDateType.Equals(LastInputDateType.None))
            {
                string y = string.Empty;
                string m = string.Empty;
                string d = string.Empty;

                switch (lastInputDateType)
                {
                    case LastInputDateType.TargetYMDDateFrom:
                        y = txtTargetYMDDateFromYears.Text;
                        m = txtTargetYMDDateFromMonth.Text;
                        d = txtTargetYMDDateFromDays.Text;
                        break;
                    case LastInputDateType.TargetYMDDateTo:
                        y = txtTargetYMDDateToYears.Text;
                        m = txtTargetYMDDateToMonth.Text;
                        d = txtTargetYMDDateToDays.Text;
                        break;
                }
                if (!checkDate(y, m, d, true))
                {
                    errorOK(Messages.M0017);
                    if (lastInputDateText != null)
                    {
                        lastInputDateText.Focus();
                    }
                    else if (LastInputDateType.TargetYMDDateFrom.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateFromYears.Focus();
                    }
                    else if (LastInputDateType.TargetYMDDateTo.Equals(lastInputDateType))
                    {
                        txtTargetYMDDateToYears.Focus();
                    }
                    return;
                }
            }
            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = (Control)sender;
        }
        #endregion

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

        #region 取消ボタン押下イベント
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTargetYMDDateFromYears.Text = string.Empty;
            txtTargetYMDDateFromMonth.Text = string.Empty;
            txtTargetYMDDateFromDays.Text = string.Empty;
            txtTargetYMDDateToYears.Text = string.Empty;
            txtTargetYMDDateToMonth.Text = string.Empty;
            txtTargetYMDDateToDays.Text = string.Empty;
        }
        #endregion
    }
}
