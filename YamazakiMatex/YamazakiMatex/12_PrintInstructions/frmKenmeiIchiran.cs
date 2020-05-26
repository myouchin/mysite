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
    /// 件名一覧表
    /// </summary>
    public partial class frmKenmeiIchiran : ChildBaseForm
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
        public frmKenmeiIchiran()
        {
            InitializeComponent();
            activeControlInfo = new ActiveControlInfo();
            commonLogic = new CommonLogic();
            meisyoMaster = new DBMeisyoMaster();
            DialogResult = DialogResult.None;

            // 画面特有のイベントを追加
            setEvent(this);
            // 画面項目毎の共通イベント設定
            setCommonEvent(this);
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
        private dtblKenmeiIchiran getData()
        {
            dtblKenmeiIchiran kenmeiIchiran = new dtblKenmeiIchiran();

            DBCommon selectDb = new DBCommon();
            string sql = string.Empty;
            sql += "SELECT kenmeiNo      AS kenmeiCd " + "\r";
            sql += "     , kenmei1       AS kenmeiNm " + "\r";
            sql += "     , nonyusakiName AS nounyuNm " + "\r";
            sql += "     , busyoName     AS nounyuBusho " + "\r";
            sql += "     , renrakusaki1  AS renrakusaki1 " + "\r";
            sql += "     , renrakusaki2  AS renrakusaki2 " + "\r";
            sql += "     , zipCode       AS yubin " + "\r";
            sql += "     , address1      AS jyusho1 " + "\r";
            sql += "     , address2      AS jyusho2 " + "\r";
            sql += "FROM kenmei_master " + "\r";
            sql += "WHERE kanriKubun IS NULL OR kanriKubun <> '9' " + "\r";
            sql += "ORDER BY kenmeiNo " + "\r";
            kenmeiIchiran.Tables["dtblKenmeiIchiran"].Merge(selectDb.executeNoneLockSelect(sql).Copy());

            return kenmeiIchiran;
        }
        #endregion

        #region 帳票出力処理
        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="printType"></param>
        private void executePrint(PrintType printType)
        {
            dtblKenmeiIchiran kenmeiIchiran = getData();
            if (kenmeiIchiran.Tables["dtblKenmeiIchiran"].Rows.Count == 0)
            {
                string msg = "条件に一致するデータ";
                errorOK(string.Format(Messages.M0003, msg));
                return;
            }
            rptKenmeiIchiran1.SetDataSource(kenmeiIchiran);
            frmPrintView printView = new frmPrintView();
            printView.CrViewer.ReportSource = rptKenmeiIchiran1;

            if (PrintType.OutPut.Equals(printType))
            {
                //印刷ダイアログ表示処理実行
                System.Drawing.Printing.PrinterSettings printerSettings = null;
                System.Drawing.Printing.PageSettings pageSettings = null;
                DialogResult result = commonLogic.DisplayedPrintDialog(rptKenmeiIchiran1.PrintOptions.PrinterName
                                                                     , CrystalDecisions.Shared.PaperOrientation.Landscape.Equals(rptKenmeiIchiran1.PrintOptions.PaperOrientation)
                                                                     , rptKenmeiIchiran1.PrintOptions.PaperSize.ToString()
                                                                     , ref printerSettings
                                                                     , ref pageSettings);
                //印刷の選択ダイアログを表示する
                if (result == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    rptKenmeiIchiran1.PrintToPrinter(printerSettings
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

        #endregion
    }
}
