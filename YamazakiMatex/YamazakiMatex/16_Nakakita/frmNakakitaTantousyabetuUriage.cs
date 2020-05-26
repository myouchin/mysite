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

namespace Nakakita
{
    /// <summary>
    /// 中北電機担当者別売上
    /// </summary>
    public partial class frmNakakitaTantousyabetuUriage : Common.ChildBaseForm
    {
        #region 変数宣言
        private DBKanriMaster kanriMaster;
        private DateTime syoriDate;
        private CommonLogic commonLogic;
        private string nendo;
        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmNakakitaTantousyabetuUriage(string n)
        {
            InitializeComponent();
            kanriMaster = new DBKanriMaster();
            commonLogic = new CommonLogic();
            nendo = n;
        }
        #endregion

        #region 画面起動時の処理
        /// <summary>
        /// 画面起動時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNakakitaTantousyabetuUriage_Load(object sender, EventArgs e)
        {
            // 処理日付取得
            syoriDate = kanriMaster.getSyoriDate();
            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            activeControlInfo = new ActiveControlInfo();
            activeControlInfo.Control = txtTargetYear;
            txtTargetYear.Text = nendo;
            // グリッド再表示
            setGridData();
            DialogResult = DialogResult.None;
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
                // F11キーが押下された場合
                case Keys.F11:
                    // 次頁表示処理を実行
                    btnNextPage_Click(null, null);
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

        #region 前頁ボタン押下イベント
        /// <summary>
        /// 前頁ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            closedForm();
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
            DialogResult = DialogResult.OK;
            closedForm();
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

        #region 必須入力チェック処理
        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <returns></returns>
        private bool checkRequired()
        {
            bool ret = true;

            // TODO

            return ret;
        }
        #endregion

        #region グリッド設定処理
        /// <summary>
        /// グリッド設定処理
        /// </summary>
        private void setGridData()
        {
            // データ登録処理実行
            registData();

            DBCommon db = new DBCommon();
            string sql = string.Empty;
            int tantousyaMinCount = 8;
            DataRow newRow;

            sql = string.Empty;
            sql += "SELECT * ";
            sql += "FROM ( ";
            sql += "       SELECT tm.tantousyaName AS person ";
            sql += "            , ntu.10GatsuUriage AS person10Month ";
            sql += "            , ntu.11GatsuUriage AS person11Month ";
            sql += "            , ntu.12GatsuUriage AS person12Month ";
            sql += "            , ntu.1GatsuUriage AS person1Month ";
            sql += "            , ntu.2GatsuUriage AS person2Month ";
            sql += "            , ntu.3GatsuUriage AS person3Month ";
            sql += "            , ntu.4GatsuUriage AS person4Month ";
            sql += "            , ntu.5GatsuUriage AS person5Month ";
            sql += "            , ntu.6GatsuUriage AS person6Month ";
            sql += "            , ntu.7GatsuUriage AS person7Month ";
            sql += "            , ntu.8GatsuUriage AS person8Month ";
            sql += "            , ntu.9GatsuUriage AS person9Month ";
            sql += "       FROM (SELECT * FROM nakakita_tantousya_uriage WHERE nendo = '" + txtTargetYear.Text + "') ntu ";
            sql += "       INNER JOIN (SELECT * FROM tantousya_master) tm ";
            sql += "       ON (ntu.tantousyaCode = tm.tantousyaCode) ";
            sql += "       ORDER BY ntu.tantousyaCode ";
            sql += ") ud ";
            sql += "UNION ALL ";
            sql += "SELECT '合計' AS person ";
            sql += "     , SUM(IFNULL(ntu.10GatsuUriage, 0)) AS person10Month ";
            sql += "     , SUM(IFNULL(ntu.11GatsuUriage, 0)) AS person11Month ";
            sql += "     , SUM(IFNULL(ntu.12GatsuUriage, 0)) AS person12Month ";
            sql += "     , SUM(IFNULL(ntu.1GatsuUriage, 0)) AS person1Month ";
            sql += "     , SUM(IFNULL(ntu.2GatsuUriage, 0)) AS person2Month ";
            sql += "     , SUM(IFNULL(ntu.3GatsuUriage, 0)) AS person3Month ";
            sql += "     , SUM(IFNULL(ntu.4GatsuUriage, 0)) AS person4Month ";
            sql += "     , SUM(IFNULL(ntu.5GatsuUriage, 0)) AS person5Month ";
            sql += "     , SUM(IFNULL(ntu.6GatsuUriage, 0)) AS person6Month ";
            sql += "     , SUM(IFNULL(ntu.7GatsuUriage, 0)) AS person7Month ";
            sql += "     , SUM(IFNULL(ntu.8GatsuUriage, 0)) AS person8Month ";
            sql += "     , SUM(IFNULL(ntu.9GatsuUriage, 0)) AS person9Month ";
            sql += "FROM (SELECT * FROM nakakita_tantousya_uriage WHERE nendo = '" + txtTargetYear.Text + "') ntu ";
            DataTable tantousyaDt = db.executeNoneLockSelect(sql);
            while (tantousyaDt.Rows.Count < tantousyaMinCount)
            {
                newRow = tantousyaDt.NewRow();
                tantousyaDt.Rows.InsertAt(newRow, tantousyaDt.Rows.Count - 1);
            }

            grdPerson.DataSource = tantousyaDt.Copy();

        }
        #endregion

        #region 中北電機データ登録処理
        /// <summary>
        /// 中北電機データ登録処理
        /// </summary>
        private void registData()
        {
            DBCommon db = new DBCommon();
            string sql = string.Empty;
            DateTime registDate = DateTime.Now;
            DateTime targetDateFrom = Convert.ToDateTime(txtTargetYear.Text + "-10-01");
            DateTime targetDateTo = Convert.ToDateTime(Convert.ToString(Convert.ToInt16(txtTargetYear.Text) + 1) + "-10-01").AddDays(-1);

            #region 担当者情報取得
            sql = string.Empty;
            sql += "SELECT * FROM tantousya_master WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            DataTable tantousyaDt = db.executeNoneLockSelect(sql);
            #endregion

            #region 担当者別データ取得
            sql = string.Empty;
            sql += "            SELECT tm.tantousyaCode ";
            sql += "                 , tm.tantousyaName ";
            sql += "                 , uh.year ";
            sql += "                 , uh.month ";
            sql += "                 , SUM(IFNULL(ub.kingaku, 0)) uriageKingaku ";
            sql += "            FROM (SELECT * FROM tantousya_master) tm ";
            sql += "            INNER JOIN (SELECT * ";
            sql += "                             , DATE_FORMAT(denpyoHizuke, '%Y') AS year ";
            sql += "                             , DATE_FORMAT(denpyoHizuke, '%m') AS month ";
            sql += "                        FROM uriage_header ";
            sql += "                        WHERE (kanriKubun IS NULL OR kanriKubun <> '9') ";
            sql += "                        AND denpyoHizuke >= '" + targetDateFrom + "' ";
            sql += "                        AND denpyoHizuke <= '" + targetDateTo + "' ";
            sql += "                        AND tokuisakiCode = '10001' "; // TODO
            sql += "            ) uh ";
            sql += "            ON (tm.tantousyaCode = uh.tantousyaCode) ";
            sql += "            INNER JOIN (SELECT * FROM uriage_body WHERE IFNULL(flgPrint, 0) = 1) ub ";
            sql += "            ON (uh.denpyoNo = ub.denpyoNo) ";
            sql += "            GROUP BY tm.tantousyaCode, uh.year, uh.month ";
            sql += "            ORDER BY tm.tantousyaCode, uh.year, uh.month ";
            DataTable tantousyaDataDt = db.executeNoneLockSelect(sql);
            #endregion

            List<string> commands = new List<string>();
            string tantousyaCode;
            string month;
            string month10Uriage = "NULL";
            string month11Uriage = "NULL";
            string month12Uriage = "NULL";
            string month1Uriage = "NULL";
            string month2Uriage = "NULL";
            string month3Uriage = "NULL";
            string month4Uriage = "NULL";
            string month5Uriage = "NULL";
            string month6Uriage = "NULL";
            string month7Uriage = "NULL";
            string month8Uriage = "NULL";
            string month9Uriage = "NULL";

            #region 担当者別データ登録SQL生成
            commands.Add("DELETE FROM nakakita_tantousya_uriage WHERE nendo = '" + txtTargetYear.Text + "' ");
            foreach (DataRow tantousyaRow in tantousyaDt.Rows)
            {
                tantousyaCode = Convert.ToString(tantousyaRow[DBFileLayout.TantousyaMasterFile.dcTantousyaCode]);
                month10Uriage = "NULL";
                month11Uriage = "NULL";
                month12Uriage = "NULL";
                month1Uriage = "NULL";
                month2Uriage = "NULL";
                month3Uriage = "NULL";
                month4Uriage = "NULL";
                month5Uriage = "NULL";
                month6Uriage = "NULL";
                month7Uriage = "NULL";
                month8Uriage = "NULL";
                month9Uriage = "NULL";
                var query = tantousyaDataDt.AsEnumerable().Where(p => p.Field<string>(DBFileLayout.TantousyaMasterFile.dcTantousyaCode).Equals(tantousyaCode)).OrderBy(p => tantousyaDataDt.Rows.IndexOf(p));
                foreach (DataRow shitenRow in query)
                {
                    month = Convert.ToString(shitenRow["month"]);
                    if ("10".Equals(month))
                    {
                        month10Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("11".Equals(month))
                    {
                        month11Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("12".Equals(month))
                    {
                        month12Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("01".Equals(month))
                    {
                        month1Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("02".Equals(month))
                    {
                        month2Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("03".Equals(month))
                    {
                        month3Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("04".Equals(month))
                    {
                        month4Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("05".Equals(month))
                    {
                        month5Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("06".Equals(month))
                    {
                        month6Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("07".Equals(month))
                    {
                        month7Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else if ("08".Equals(month))
                    {
                        month8Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                    else
                    {
                        month9Uriage = Convert.ToString(shitenRow["uriageKingaku"]);
                    }
                }
                sql = string.Empty;
                sql += "INSERT INTO nakakita_tantousya_uriage ";
                sql += "( ";
                sql += "  tantousyaCode ";
                sql += ", nendo ";
                sql += ", 10GatsuUriage ";
                sql += ", 11GatsuUriage ";
                sql += ", 12GatsuUriage ";
                sql += ", 1GatsuUriage ";
                sql += ", 2GatsuUriage ";
                sql += ", 3GatsuUriage ";
                sql += ", 4GatsuUriage ";
                sql += ", 5GatsuUriage ";
                sql += ", 6GatsuUriage ";
                sql += ", 7GatsuUriage ";
                sql += ", 8GatsuUriage ";
                sql += ", 9GatsuUriage ";
                sql += ", kousinNichizi ";
                sql += ", kanriKubun ";
                sql += ") ";
                sql += "VALUES ";
                sql += "( ";
                sql += "  '" + tantousyaCode + "' ";
                sql += ", '" + txtTargetYear.Text + "' ";
                sql += ", " + month10Uriage + " ";
                sql += ", " + month11Uriage + " ";
                sql += ", " + month12Uriage + " ";
                sql += ", " + month1Uriage + " ";
                sql += ", " + month2Uriage + " ";
                sql += ", " + month3Uriage + " ";
                sql += ", " + month4Uriage + " ";
                sql += ", " + month5Uriage + " ";
                sql += ", " + month6Uriage + " ";
                sql += ", " + month7Uriage + " ";
                sql += ", " + month8Uriage + " ";
                sql += ", " + month9Uriage + " ";
                sql += ", '" + registDate + "' ";
                sql += ", '' ";
                sql += ") ";
                commands.Add(sql);
            }
            #endregion

            #region データ登録実行
            db.startTransaction();
            foreach (string cmd in commands)
            {
                db.executeDBUpdate(cmd);
            }
            db.endTransaction();
            #endregion

        }
        #endregion

        #endregion

    }
}
