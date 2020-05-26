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
using YamazakiMatex.Print.Table;
using YamazakiMatex.Print.ViewForm;

namespace PrintInstructions
{
    /// <summary>
    /// 得意先一覧表
    /// </summary>
    public partial class frmTokuiMIchiran : ChildBaseForm
    {
        #region 変数宣言
        private DBMeisyoMaster meisyoMaster;
        public Boolean flgInitializeGrid = true;
        public Boolean flgSetGridData = false;
        private CommonLogic commonLogic;
        private enum LastInputDateType
        {
            None = 0
          , TargetDate = 1
        }
        /// <summary>
        /// 入金種別
        /// </summary>
        private enum NyukinSyubetu
        {
            Genkin = 0
          , Hurikomi = 1
          , Tesuryo = 2
          , Kogitte = 3
          , Tegata = 4
          , TegataWaribiki = 5
          , Sousai = 6
          , Ribeto = 7
          , Densai = 8
          , Tyousei = 9
          , Sonota = 10
        }

        #endregion

        #region イベント

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="flgMultiSelect"></param>
        /// <param name="checkMessageType"></param>
        public frmTokuiMIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            commonLogic = new CommonLogic();
            meisyoMaster = new DBMeisyoMaster();
            DialogResult = DialogResult.None;

            // 都道府県コンボボックス設定
            setPrefecturesCmb();

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);

            cmbPrefectures.Enabled = false;
        }
        #endregion

        #region プレビューボタン押下処理
        /// <summary>
        /// プレビューボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            executePrint(PrintType.Preview);
        }
        #endregion

        #region 印刷ボタン押下処理
        /// <summary>
        /// 印刷ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            executePrint(PrintType.OutPut);
        }
        #endregion

        #region 閉じるボタン押下処理
        /// <summary>
        /// 閉じるボタン押下処理
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
                    break;
                // F3キーが押下された場合
                case Keys.F3:
                    // TODO:プレビュー処理を実行
                    btnPreview_Click(null, null);
                    break;
                // F4キーが押下された場合
                case Keys.F4:
                    // TODO:印刷処理を実行
                    btnPrint_Click(null, null);
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

        #region 画面起動イベント
        /// <summary>
        /// 画面起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJyuchachuIchiran_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region 帳票出力対象ラジオボタン押下イベント
        /// <summary>
        /// 帳票出力対象ラジオボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printModeRadio_Click(object sender, EventArgs e)
        {
            if (rdoAll.Checked)
            {
                cmbPrefectures.Enabled = false;
            }
            else
            {
                cmbPrefectures.Enabled = true;
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

        #region 帳票出力データ取得処理
        /// <summary>
        /// 画面表示・帳票出力データ取得処理
        /// </summary>
        /// <returns></returns>
        private dtblTokuiM getData()
        {
            dtblTokuiM tokuisakiIchiran = new dtblTokuiM();

            DBCommon selectDb = new DBCommon();
            string kenCode = string.Empty;
            if (rdoPrefectures.Checked) kenCode = Convert.ToString(cmbPrefectures.SelectedValue);
            string sql = string.Empty;
            sql += "SELECT tm.chikuCode         AS kenCd " + "\r";
            sql += "     , mm1.kubunName        AS kenMei " + "\r";
            sql += "     , tm.tokuisakiCode     AS tokuisakiCd " + "\r";
            sql += "     , tm.tokuisakiName     AS tokuisakiNmJ " + "\r";
            sql += "     , tm.tokuisakiKanaName AS tokuisakiNmk " + "\r";
            sql += "     , tm.jigyousyoCode     AS jigyouCd " + "\r";
            sql += "     , tm.jigyousyoName     AS jigyouNm " + "\r";
            sql += "     , tm.zipCode           AS yubin " + "\r";
            sql += "     , tm.address1          AS jyusho1 " + "\r";
            sql += "     , tm.address2          AS jyusho2 " + "\r";
            sql += "     , tm.renrakusaki1      AS renraku1 " + "\r";
            sql += "     , tm.renrakusaki2      AS renraku2 " + "\r";
            sql += "     , mm2.kubunName        AS sime " + "\r";
            sql += "FROM (SELECT * FROM tokuisaki_master WHERE kanriKubun IS NULL OR kanriKubun <> '9') tm " + "\r";
            sql += "LEFT JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '004') mm1 " + "\r";
            sql += "ON (tm.chikuCode = mm1.kubun) " + "\r";
            sql += "LEFT JOIN (SELECT * FROM meisyo_master WHERE meisyoCode = '006') mm2 " + "\r";
            sql += "ON (tm.shimebi = mm2.kubun) " + "\r";
            if (!string.IsNullOrEmpty(kenCode)) sql += "WHERE tm.chikuCode = '" + kenCode + "' " + "\r";
            sql += "ORDER BY tm.tokuisakiCode, tm.jigyousyoCode " + "\r";
            tokuisakiIchiran.Tables["dtblTokuiM"].Merge(selectDb.executeNoneLockSelect(sql).Copy());

            return tokuisakiIchiran;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            dtblTokuiM tokuisakiIchiran = getData();
            if (tokuisakiIchiran.Tables["dtblTokuiM"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptTokuimIchiran1.SetDataSource(tokuisakiIchiran);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptTokuimIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptTokuimIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptTokuimIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptTokuimIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptTokuimIchiran1.PrintToPrinter(printerSettings
                                                   , pageSettings
                                                   , false);

                }
            }
            else
            {
                printView.Size = new Size(1180, 945);
                printView.StartPosition = FormStartPosition.CenterScreen;
                printView.ShowDialog();
            }
        }
        #endregion

        #region 都道府県コンボボックスの設定処理
        /// <summary>
        /// 都道府県コンボボックスの設定処理
        /// </summary>
        private void setPrefecturesCmb()
        {
            // 都道府県取得
            DataTable meisyoDt = meisyoMaster.getMeisyoDataTable(Consts.MeisyoCode.CODE004);
            // コンボボックス設定共通処理実行
            commonLogic.setComboBoxDataSource(ref cmbPrefectures, meisyoDt, "kubun", "kubunName");
        }
        #endregion

        #endregion
    }
}
