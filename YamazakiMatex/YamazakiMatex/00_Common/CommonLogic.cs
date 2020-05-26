using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Resorce;
using DB;
using System.Drawing.Printing;

namespace Common
{
    class CommonLogic
    {
        private string strCmbKey = "Key";
        private string strCmbValue = "Value";
        public string StrCmbKey
        {
            get { return strCmbKey; }
            set { strCmbKey = value; }
        }
        public string StrCmbValue
        {
            get { return strCmbValue; }
            set { strCmbValue = value; }
        }
        public enum KeyDownType
        {
            None = 0
          , Enter = 1
          , Up = 2
          , Left = 3
          , Right = 4
          , Down = 5
        }

        public void setNextFocus(Control target, KeyDownType keyDownType)
        {
            Control nextFocusControl = getNextFocusControl(target, keyDownType);
            if (nextFocusControl != null)
            {
                nextFocusControl.Focus();
                if (nextFocusControl is TextBox)
                {
                    ((TextBox)nextFocusControl).SelectionStart = 0;
                    ((TextBox)nextFocusControl).SelectionLength = 0;
                }
                else if (nextFocusControl is ComboBox && ((ComboBox)nextFocusControl).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)nextFocusControl).SelectionStart = 0;
                    ((ComboBox)nextFocusControl).SelectionLength = 0;
                }
            }
        }

        public Control getNextFocusControl(Control target, KeyDownType keyDownType)
        {
            Control ret = null;
            switch (keyDownType)
            {
                case KeyDownType.Enter:
                    if (target is CustomTextBox)
                    {
                        if (((CustomTextBox)target).EnterControl != null)
                        {
                            if (((CustomTextBox)target).EnterControl.Enabled)
                            {
                                ret = ((CustomTextBox)target).EnterControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomTextBox)target).EnterControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomComboBox)
                    {
                        if (((CustomComboBox)target).EnterControl != null)
                        {
                            if (((CustomComboBox)target).EnterControl.Enabled)
                            {
                                ret = ((CustomComboBox)target).EnterControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomComboBox)target).EnterControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDateTimePicker)
                    {
                        if (((CustomDateTimePicker)target).EnterControl != null)
                        {
                            if (((CustomDateTimePicker)target).EnterControl.Enabled)
                            {
                                ret = ((CustomDateTimePicker)target).EnterControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDateTimePicker)target).EnterControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDataGridView)
                    {
                        if (((CustomDataGridView)target).EnterControl != null)
                        {
                            if (((CustomDataGridView)target).EnterControl.Enabled)
                            {
                                ret = ((CustomDataGridView)target).EnterControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDataGridView)target).EnterControl, keyDownType);
                            }
                        }
                    }
                    break;
                case KeyDownType.Up:
                    if (target is CustomTextBox)
                    {
                        if (((CustomTextBox)target).UpControl != null)
                        {
                            if (((CustomTextBox)target).UpControl.Enabled)
                            {
                                ret = ((CustomTextBox)target).UpControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomTextBox)target).UpControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomComboBox)
                    {
                        if (((CustomComboBox)target).UpControl != null)
                        {
                            if (((CustomComboBox)target).UpControl.Enabled)
                            {
                                ret = ((CustomComboBox)target).UpControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomComboBox)target).UpControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDateTimePicker)
                    {
                        if (((CustomDateTimePicker)target).UpControl != null)
                        {
                            if (((CustomDateTimePicker)target).UpControl.Enabled)
                            {
                                ret = ((CustomDateTimePicker)target).UpControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDateTimePicker)target).UpControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDataGridView)
                    {
                        if (((CustomDataGridView)target).UpControl != null)
                        {
                            if (((CustomDataGridView)target).UpControl.Enabled)
                            {
                                ret = ((CustomDataGridView)target).UpControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDataGridView)target).UpControl, keyDownType);
                            }
                        }
                    }
                    break;
                case KeyDownType.Left:
                    if (target is CustomTextBox)
                    {
                        if (((CustomTextBox)target).LeftControl != null)
                        {
                            if (((CustomTextBox)target).LeftControl.Enabled)
                            {
                                ret = ((CustomTextBox)target).LeftControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomTextBox)target).LeftControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomComboBox)
                    {
                        if (((CustomComboBox)target).LeftControl != null)
                        {
                            if (((CustomComboBox)target).LeftControl.Enabled)
                            {
                                ret = ((CustomComboBox)target).LeftControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomComboBox)target).LeftControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDateTimePicker)
                    {
                        if (((CustomDateTimePicker)target).LeftControl != null)
                        {
                            if (((CustomDateTimePicker)target).LeftControl.Enabled)
                            {
                                ret = ((CustomDateTimePicker)target).LeftControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDateTimePicker)target).LeftControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDataGridView)
                    {
                        if (((CustomDataGridView)target).LeftControl != null)
                        {
                            if (((CustomDataGridView)target).LeftControl.Enabled)
                            {
                                ret = ((CustomDataGridView)target).LeftControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDataGridView)target).LeftControl, keyDownType);
                            }
                        }
                    }
                    break;
                case KeyDownType.Right:
                    if (target is CustomTextBox)
                    {
                        if (((CustomTextBox)target).RightControl != null)
                        {
                            if (((CustomTextBox)target).RightControl.Enabled)
                            {
                                ret = ((CustomTextBox)target).RightControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomTextBox)target).RightControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomComboBox)
                    {
                        if (((CustomComboBox)target).RightControl != null)
                        {
                            if (((CustomComboBox)target).RightControl.Enabled)
                            {
                                ret = ((CustomComboBox)target).RightControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomComboBox)target).RightControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDateTimePicker)
                    {
                        if (((CustomDateTimePicker)target).RightControl != null)
                        {
                            if (((CustomDateTimePicker)target).RightControl.Enabled)
                            {
                                ret = ((CustomDateTimePicker)target).RightControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDateTimePicker)target).RightControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDataGridView)
                    {
                        if (((CustomDataGridView)target).RightControl != null)
                        {
                            if (((CustomDataGridView)target).RightControl.Enabled)
                            {
                                ret = ((CustomDataGridView)target).RightControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDataGridView)target).RightControl, keyDownType);
                            }
                        }
                    }
                    break;
                case KeyDownType.Down:
                    if (target is CustomTextBox)
                    {
                        if (((CustomTextBox)target).DownControl != null)
                        {
                            if (((CustomTextBox)target).DownControl.Enabled)
                            {
                                ret = ((CustomTextBox)target).DownControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomTextBox)target).DownControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomComboBox)
                    {
                        if (((CustomComboBox)target).DownControl != null)
                        {
                            if (((CustomComboBox)target).DownControl.Enabled)
                            {
                                ret = ((CustomComboBox)target).DownControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomComboBox)target).DownControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDateTimePicker)
                    {
                        if (((CustomDateTimePicker)target).DownControl != null)
                        {
                            if (((CustomDateTimePicker)target).DownControl.Enabled)
                            {
                                ret = ((CustomDateTimePicker)target).DownControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDateTimePicker)target).DownControl, keyDownType);
                            }
                        }
                    }
                    else if (target is CustomDataGridView)
                    {
                        if (((CustomDataGridView)target).DownControl != null)
                        {
                            if (((CustomDataGridView)target).DownControl.Enabled)
                            {
                                ret = ((CustomDataGridView)target).DownControl;
                            }
                            else
                            {
                                ret = getNextFocusControl(((CustomDataGridView)target).DownControl, keyDownType);
                            }
                        }
                    }
                    break;
            }
            return ret;
        }

        public DateTime convertDateTime(string y, string m, string d)
        {
            DateTime res = DateTime.Now;

            DateTime.TryParse(y + "/" + m + "/" + d, out res);

            return res;
        }

        #region コンボボックス設定共通処理
        /// <summary>
        /// コンボボックス設定共通処理
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="sourceDt"></param>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        public void setComboBoxDataSource(ref CustomComboBox combo, DataTable sourceDt, string keyName, string valueName)
        {
            // コンボボックス設定共通処理実行
            setComboBoxDataSource(ref combo, sourceDt, keyName, valueName, null);
        }
        #endregion

        #region コンボボックス設定共通処理
        /// <summary>
        /// コンボボックス設定共通処理
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="sourceDt"></param>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        public void setComboBoxDataSource(ref CustomComboBox combo, DataTable sourceDt, string keyName, string valueName, string[] optionName)
        {
            // コンボボックスデータソース生成処理実行
            DataTable cmbDt = createComboBoxDataSource(sourceDt, keyName, valueName, optionName);

            // 取得データをコンボボックスのDataSourceへ設定
            combo.DataSource = cmbDt;
            combo.ValueMember = StrCmbKey;
            combo.DisplayMember = StrCmbValue;
        }
        #endregion

        #region あり・なしコンボボックス設定共通処理
        /// <summary>
        /// あり・なしコンボボックス設定共通処理
        /// </summary>
        /// <param name="combo"></param>
        public void setYesNoComboBoxDataSource(ref CustomComboBox combo)
        {
            DataTable sourceDt = new DataTable();
            sourceDt.Columns.Add(StrCmbKey);
            sourceDt.Columns.Add(StrCmbValue);
            sourceDt.Rows.Add(new object[] { "1", "あり" });
            sourceDt.Rows.Add(new object[] { "0", "なし" });
            // コンボボックス設定共通処理実行
            setComboBoxDataSource(ref combo, sourceDt, StrCmbKey, StrCmbValue, null);
        }
        #endregion

        #region 端数区分コンボボックス設定共通処理
        /// <summary>
        /// 端数区分コンボボックス設定共通処理
        /// </summary>
        /// <param name="combo"></param>
        public void setFractionTypeComboBoxDataSource(ref CustomComboBox combo)
        {
            DataTable sourceDt = new DataTable();
            sourceDt.Columns.Add(StrCmbKey);
            sourceDt.Columns.Add(StrCmbValue);
            sourceDt.Rows.Add(new object[] { Convert.ToString(Consts.RoundType.RoundDown.GetHashCode()), "切り捨て" });
            sourceDt.Rows.Add(new object[] { Convert.ToString(Consts.RoundType.RoundUp.GetHashCode()), "切り上げ" });
            sourceDt.Rows.Add(new object[] { Convert.ToString(Consts.RoundType.RoundOff.GetHashCode()), "四捨五入" });
            // コンボボックス設定共通処理実行
            setComboBoxDataSource(ref combo, sourceDt, StrCmbKey, StrCmbValue, null);
        }
        #endregion

        #region コンボボックス列設定共通処理
        /// <summary>
        /// コンボボックス列設定共通処理
        /// </summary>
        /// <param name="comboClm"></param>
        /// <param name="sourceDt"></param>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        public void setGridComboBoxDataSource(ref DataGridViewComboBoxColumn comboClm, DataTable sourceDt, string keyName, string valueName)
        {
            // コンボボックスデータソース生成処理実行
            DataTable cmbDt = createComboBoxDataSource(sourceDt, keyName, valueName, null);

            // 取得データをコンボボックスのDataSourceへ設定
            comboClm.DataSource = cmbDt;
            comboClm.ValueMember = StrCmbKey;
            comboClm.DisplayMember = StrCmbValue;
        }
        #endregion

        #region コンボボックス列設定共通処理
        /// <summary>
        /// コンボボックスデータソース生成処理
        /// </summary>
        /// <param name="comboClm"></param>
        /// <param name="sourceDt"></param>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        public DataTable createComboBoxDataSource(DataTable sourceDt, string keyName, string valueName, string[] optionName)
        {
            DataTable cmbDt = new DataTable();
            cmbDt.Columns.Add(StrCmbKey, Type.GetType("System.String"));
            cmbDt.Columns.Add(StrCmbValue, Type.GetType("System.String"));
            List<string> optionNames = new List<string>();
            if (optionName != null)
            {
                foreach (string option in optionName)
                {
                    cmbDt.Columns.Add(option, Type.GetType("System.String"));
                    optionNames.Add(option);
                }
            }
            if (sourceDt != null)
            {
                foreach (DataRow dRow in sourceDt.Rows)
                {
                    cmbDt.Rows.Add(new object[] { Convert.ToString(dRow[keyName])
                                                , Convert.ToString(dRow[valueName]) });
                    foreach (string on in optionNames)
                    {
                        cmbDt.Rows[cmbDt.Rows.Count - 1][on] = Convert.ToString(dRow[on]);
                    }
                }
            }

            return cmbDt;
        }
        #endregion

        //#region 数値項目のフォーマット設定処理
        ///// <summary>
        ///// 数値項目のフォーマット設定処理
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="format"></param>
        ///// <returns></returns>
        //public string getFormatNumberText(string value, string format)
        //{
        //    string ret = value;
        //    Int32 number;
        //    if (Int32.TryParse(value, out number))
        //    {
        //        ret = number.ToString(format);
        //    }
        //    return ret;
        //}
        //#endregion

        #region 数値の0埋め処理
        /// <summary>
        /// 数値の0埋め処理
        /// </summary>
        /// <param name="strNumber"></param>
        /// <param name="zeroCount"></param>
        /// <returns></returns>
        public string getZeroBuriedNumberText(string strNumber, int zeroCount)
        {
            string ret = string.Empty;
            decimal number = 0;
            if (decimal.TryParse(strNumber, out number))
            {
                ret = number.ToString(getZeroBuriedFormatString(zeroCount));
            }
            return ret;
        }
        #endregion

        #region 0埋め時のフォーマットテキストを取得します
        /// <summary>
        /// 0埋め時のフォーマットテキストを取得します
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        public string getZeroBuriedFormatString(int zeroCount)
        {
            string ret = string.Empty;

            while (zeroCount > 0)
            {
                ret += "0";
                zeroCount--;
            }

            return ret;
        }
        #endregion

        #region 常時入力受付文字チェック
        /// <summary>
        /// 常時入力受付文字チェック
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool checkNotEligible(char value)
        {
            bool ret = false;
            // Ctrl + aを入力した場合
            if (value == '\u0001')
            {
                ret = true;
            }
            // Ctrl + cを入力した場合
            if (value == '\u0003')
            {
                ret = true;
            }
            // Ctrl + zを入力した場合
            if (value == '\u001a')
            {
                ret = true;
            }
            // Enterを入力した場合
            if (value == '\r')
            {
                ret = true;
            }
            // BackSpaceを入力した場合
            if (value == '\b')
            {
                ret = true;
            }
            return ret;
        }
        #endregion

        #region 入力可能文字判定処理
        /// <summary>
        /// 入力可能文字判定処理
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pattern"></param>
        public bool inputCommonControl_KeyPress(KeyPressEventArgs e, string pattern)
        {
            string checkValue = Convert.ToString(e.KeyChar);
            bool ret = true;
            // 常時入力可能文字が入力された場合
            if (checkNotEligible(e.KeyChar))
            {
                return ret;
            }
            // Ctrl + vを入力した場合
            if (e.KeyChar == '\u0016')
            {
                // クリップボードの入力値をチェック
                IDataObject clipboardData = Clipboard.GetDataObject();
                if (clipboardData.GetDataPresent(DataFormats.Text))
                {
                    // 貼付文字列をチェック用変数に格納
                    checkValue = (string)clipboardData.GetData(DataFormats.Text);
                }
                else
                {
                    e.Handled = true;
                    ret = false;
                }
            }

            // イベントキャンセルフラグがtrueの場合
            if (e.Handled) return ret;
            //入力値が0～9でない場合は、イベントをキャンセルする
            if (!System.Text.RegularExpressions.Regex.IsMatch(checkValue, pattern))
            {
                e.Handled = true;
                ret = false;
            }
            return ret;
        }
        #endregion

        #region 入力文字列のバイトチェック処理
        /// <summary>
        /// 入力文字列のバイトチェック処理
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pattern"></param>
        public bool inputByteCheck_KeyPress(KeyPressEventArgs e, string inputedValue, int maxByteLength, bool flg)
        {
            string checkValue = Convert.ToString(e.KeyChar);
            bool ret = true;
            // 常時入力可能文字が入力された場合
            if (checkNotEligible(e.KeyChar))
            {
                return ret;
            }
            // Ctrl + vを入力した場合
            if (e.KeyChar == '\u0016')
            {
                // クリップボードの入力値をチェック
                IDataObject clipboardData = Clipboard.GetDataObject();
                if (clipboardData.GetDataPresent(DataFormats.Text))
                {
                    // 貼付文字列をチェック用変数に格納
                    checkValue = (string)clipboardData.GetData(DataFormats.Text);
                }
                else
                {
                    e.Handled = true;
                    ret = false;
                }
            }

            // イベントキャンセルフラグがtrueの場合
            if (e.Handled) return ret;

            checkValue += inputedValue;
            int byteCount = Encoding.GetEncoding("Shift_JIS").GetByteCount(checkValue);

            // 入力文字列のバイト数が最大入力桁数 * 2より大きい場合
            if (byteCount > maxByteLength)
            {
                e.Handled = true;
                ret = false;
            }
            return ret;
        }
        #endregion

        #region 入力可能文字判定処理(数値のみ)
        /// <summary>
        /// 入力可能文字判定処理
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pattern"></param>
        public bool inputNumberOnly(KeyPressEventArgs e, string pattern, TextBox text, int integerLength, int decimalLength)
        {
            string checkValue = string.Empty;
            string inputedValue = text.Text;                    // 入力済み文字列
            string inputValue = Convert.ToString(e.KeyChar);    // 今回入力文字列
            int startSelecttionIndex = text.SelectionStart;
            int selectionLength = text.SelectionLength;
            bool ret = true;
            bool paste = false;
            // 常時入力可能文字が入力された場合
            if (checkNotEligible(e.KeyChar))
            {
                return ret;
            }
            // Ctrl + vを入力した場合
            if (e.KeyChar == '\u0016')
            {
                // クリップボードの入力値をチェック
                IDataObject clipboardData = Clipboard.GetDataObject();
                if (clipboardData.GetDataPresent(DataFormats.Text))
                {
                    // 貼付文字列をチェック用変数に格納
                    inputValue = (string)clipboardData.GetData(DataFormats.Text);
                }
                else
                {
                    e.Handled = true;
                    ret = false;
                }
                paste = true;
            }

            // イベントキャンセルフラグがtrueの場合
            if (e.Handled) return ret;

            if (inputedValue.Length > 0)
            {
                bool flgReplace = false;
                for (int i = 0; i < inputedValue.Length; i++)
                {
                    if (selectionLength > 0)
                    {
                        if (i >= startSelecttionIndex && i < startSelecttionIndex + selectionLength)
                        {
                            if (!flgReplace)
                            {
                                checkValue += inputValue;
                            }
                            flgReplace = true;
                            continue;
                        }
                    }
                    else if (!flgReplace)
                    {
                        if (startSelecttionIndex == i)
                        {
                            checkValue += inputValue;
                            flgReplace = true;
                        }
                        else if (startSelecttionIndex == i + 1)
                        {
                            checkValue += Convert.ToString(inputedValue[i]);
                            checkValue += inputValue;
                            flgReplace = true;
                            continue;
                        }
                    }
                    checkValue += Convert.ToString(inputedValue[i]);
                }
            }
            else if(!paste)
            {
                checkValue = Convert.ToString(e.KeyChar);
            }
            else if (paste)
            {
                checkValue = inputValue;
            }

            if (Convert.ToString(checkValue[checkValue.Length - 1]).Equals(".")) checkValue += "0";
            string[] splitVal = checkValue.Split('.');
            string intVal = splitVal[0];
            string decVal = splitVal.Length > 1 ? splitVal[1] : string.Empty;
            decimal wkDec;

            checkValue = HalftoNumber(checkValue);
            // 小数点が複数入力される場合、イベントをキャンセルする
            if (splitVal.Length > 2)
            {
                e.Handled = true;
                ret = false;
            }
            // 数値変換できない場合、イベントをキャンセルする
            else if (!checkValue.Equals("-") && !decimal.TryParse(checkValue, out wkDec))
            {
                e.Handled = true;
                ret = false;
            }
            // 整数部が最大入力桁数を超える場合、イベントをキャンセルする
            else if (intVal.Replace("-", "").Replace(",", "").Length > integerLength)
            {
                e.Handled = true;
                ret = false;
            }
            // 小数部が最大入力桁数を超える場合、イベントをキャンセルする
            else if (decVal.Length > decimalLength)
            {
                e.Handled = true;
                ret = false;
            }
            // -が先頭以外に入力されている場合
            else if (checkValue.Contains("-") && !Convert.ToString(checkValue[0]).Equals("-"))
            {
                e.Handled = true;
                ret = false;
            }
            else
            {
                if (!paste)
                {
                    string a = Convert.ToString(e.KeyChar);
                    a = HalftoNumber(a);
                    e.KeyChar = (char)a[0];
                }
                else
                {
                    //IDataObject clipboardData = Clipboard.GetDataObject();
                    //clipboardData.SetData(checkValue);
                    Clipboard.SetData(DataFormats.Text, HalftoNumber(inputValue));
                }
            }
            return ret;
        }
        #endregion

        #region 数字のみ入力可能項目の制御処理
        /// <summary>
        /// 数字のみ入力可能項目の制御処理
        /// </summary>
        /// <returns></returns>
        public bool inputDigitalOnly_KeyPress(KeyPressEventArgs e)
        {
            // 入力可能文字チェック処理を実行
            return inputCommonControl_KeyPress(e, @"^[0-9]+$");
        }
        #endregion

        #region 全角カナのみ入力可能項目の制御処理
        /// <summary>
        /// 全角カナのみ入力可能項目の制御処理
        /// </summary>
        /// <returns></returns>
        public bool inputEmKanaOnly_KeyPress(KeyPressEventArgs e)
        {
            // 入力可能文字チェック処理を実行
            //return inputCommonControl_KeyPress(e, @"^[ァ-ー]+$");
            return inputCommonControl_KeyPress(e, @"^[\p{IsKatakana}\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F]+$");
        }
        #endregion

        #region 数値のみ入力可能項目の制御処理
        /// <summary>
        /// 数値のみ入力可能項目の制御処理
        /// </summary>
        /// <returns></returns>
        public bool inputNumberOnly_KeyPress(KeyPressEventArgs e, TextBox text, int integerLength, int decimalLength)
        {
            // 入力可能文字チェック処理を実行
            return inputNumberOnly(e, @"^\d{" + decimalLength + "," + integerLength + @"}(\.\d)?$", text, integerLength, decimalLength);

        }
        #endregion

        #region 数字＆ハイフンのみ入力可能項目の制御処理
        /// <summary>
        /// 数字＆ハイフンのみ入力可能項目の制御処理
        /// </summary>
        /// <returns></returns>
        public bool inputDigitalAndHaihunOnly_KeyPress(KeyPressEventArgs e)
        {
            // 入力可能文字チェック処理を実行
            return inputCommonControl_KeyPress(e, @"^[0-9-]");
        }
        #endregion

        #region 入力文字数のバイトチェック対象項目の制御処理
        /// <summary>
        /// 入力文字数のバイトチェック対象項目の制御処理
        /// </summary>
        /// <returns></returns>
        public bool inputByteCheck_KeyPress(KeyPressEventArgs e, string inputedValue, int maxByteLength)
        {
            // 入力文字数のバイトチェック処理を実行
            return inputByteCheck_KeyPress(e, inputedValue, maxByteLength, true);
        }
        #endregion
        
        #region 数値項目のフォーマット文字列取得処理
        /// <summary>
        /// 数値項目のフォーマット文字列取得処理
        /// </summary>
        /// <returns></returns>
        public string getNumberFormatString(int integerLength, int decimalLength)
        {
            string integerFormat = string.Empty;
            string decimalFormat = string.Empty;

            // 整数桁数が0以下の場合
            if (integerLength <= 0)
            {
            }
            // 上記以外
            else
            {
                integerFormat = "#,##0";
            }

            // 小数桁数が0以下の場合
            if (decimalLength <= 0)
            {
            }
            // 上記以外
            else
            {
                // 小数フォーマットの先頭に.を設定
                decimalFormat = ".";
                for (int i = 0; i < decimalLength; i++)
                {
                    if (i != decimalLength - 1)
                    {
                        decimalFormat += "#";
                    }
                    else
                    {
                        decimalFormat += "0";
                    }
                }
            }

            return (string.IsNullOrEmpty(decimalFormat) ? integerFormat : integerFormat + decimalFormat);
        }
        #endregion

        #region 納品状態文字列取得処理
        /// <summary>
        /// 納品状態文字列取得処理
        /// </summary>
        /// <param name="nouhinsyoType"></param>
        /// <returns></returns>
        public string getNouhinsyoTypeText(string nouhinsyoType)
        {
            if (nouhinsyoType == Consts.DeliveryType.NoneDeliveryCode)
            {
                return Consts.DeliveryType.NoneDeliveryText;
            }
            else if (nouhinsyoType == Consts.DeliveryType.FinishDeliveryCode)
            {
                return Consts.DeliveryType.FinishDeliveryText;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region 納品状態コード取得処理
        /// <summary>
        /// 納品状態コード取得処理
        /// </summary>
        /// <param name="nouhinsyoType"></param>
        /// <returns></returns>
        public string getNouhinsyoType(string nouhinsyoTypeText)
        {
            if (nouhinsyoTypeText == Consts.DeliveryType.NoneDeliveryText)
            {
                return Consts.DeliveryType.NoneDeliveryCode;
            }
            else if (nouhinsyoTypeText == Consts.DeliveryType.FinishDeliveryText)
            {
                return Consts.DeliveryType.FinishDeliveryCode;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region 数値型変換処理
        /// <summary>
        /// decimal変換処理
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(object val)
        {
            decimal dec;
            if (decimal.TryParse(Convert.ToString(val), out dec))
            {
                return dec;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 数値型変換処理
        /// <summary>
        /// decimal変換処理
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static decimal ToDecimal2(object val)
        {
            decimal dec;
            decimal.TryParse(Convert.ToString(val), out dec);
            return dec;
        }
        #endregion

        #region 日付型変換処理
        /// <summary>
        /// decimal変換処理
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(object val)
        {
            DateTime date;
            if (DateTime.TryParse(Convert.ToString(val), out date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 端数処理
        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="val"></param>
        /// <param name="roundType"></param>
        /// <returns></returns>
        public  decimal RoundKingaku(decimal val, Consts.RoundType roundType)
        {
            decimal ret = decimal.Zero;
            decimal hugou = val < decimal.Zero ? -1 : 1;

            switch (roundType)
            {
                case Consts.RoundType.RoundDown:
                    ret = Math.Truncate(val);
                    break;
                case Consts.RoundType.RoundUp:
                    ret = Math.Truncate(val + ((decimal)0.9) * hugou);
                    break;
                case Consts.RoundType.RoundOff:
                    ret = Math.Truncate(val + ((decimal)0.5) * hugou);
                    break;
            }

            long wkVal = Convert.ToInt64(ret);

            return Convert.ToDecimal(wkVal);
        }
        #endregion

        #region 得意先端数処理
        /// <summary>
        /// 得意先端数処理
        /// </summary>
        /// <param name="tokuisakiCode"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public decimal TokuisakiRoundKingaku(string tokuisakiCode, decimal val)
        {
            DBTokuisakiMaster tokuisakiM = new DBTokuisakiMaster();
            Consts.RoundType roundType = Consts.RoundType.RoundOff;

            // 得意先情報を取得
            DataTable dt = tokuisakiM.getTokuisakiDataTable(tokuisakiCode, string.Empty);
            if (dt != null && dt.Rows.Count > 0)
            {
                roundType = (Consts.RoundType)Convert.ToInt16(dt.Rows[0][DBFileLayout.TokuisakiMasterFile.dcKingakuHasuKubun]);
            }

            return RoundKingaku(val, roundType);
        }
        #endregion

        #region 仕入先端数処理
        /// <summary>
        /// 仕入先端数処理
        /// </summary>
        /// <param name="shiresakiCode"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public decimal ShiresakiRoundKingaku(string shiresakiCode, decimal val)
        {
            //TODO
            DBShiresakiMaster shiresakiM = new DBShiresakiMaster();
            Consts.RoundType roundType = Consts.RoundType.RoundOff;

            // 仕入先情報を取得
            DataTable dt = shiresakiM.getShiresakiDataTable(shiresakiCode);
            if (dt != null && dt.Rows.Count > 0)
            {
                //TODO
                //roundType = (Consts.RoundType)Convert.ToInt16(dt.Rows[0][DBFileLayout.ShiresakiMasterFile.dcki]);
            }

            return RoundKingaku(val, roundType);
        }
        #endregion

        #region 受注No分割処理
        /// <summary>
        /// 受注No分割処理
        /// </summary>
        /// <param name="juchuNo"></param>
        /// <param name="juchuNoTop"></param>
        /// <param name="juchuNoMid"></param>
        /// <param name="juchuNoBtm"></param>
        public void SubStringJuchuNo(string juchuNo, ref string juchuNoTop, ref string juchuNoMid, ref string juchuNoBtm)
        {
            try
            {
                juchuNoTop = juchuNo.Substring(0, 3);
                juchuNoMid = juchuNo.Substring(3, 2);
                juchuNoBtm = juchuNo.Substring(5, 10);
            }
            catch
            {
                juchuNoTop = string.Empty;
                juchuNoMid = string.Empty;
                juchuNoBtm = string.Empty;
            }
        }
        #endregion

        #region 月末日取得処理
        /// <summary>
        /// 月末日取得処理
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public string GetEndOfMonth(string year, string month)
        {
            string day = string.Empty;

            try
            {
                DateTime baseTime = Convert.ToDateTime(year + "/" + month + "/01");
                day = Convert.ToString(baseTime.AddMonths(1).AddDays(-1).Day);
            }
            catch
            {
                day = string.Empty;
            }

            return day;
        }
        #endregion

        public string HalftoNumber(string value)
        {
            value = value.Replace("０", "0");
            value = value.Replace("１", "1");
            value = value.Replace("２", "2");
            value = value.Replace("３", "3");
            value = value.Replace("４", "4");
            value = value.Replace("５", "5");
            value = value.Replace("６", "6");
            value = value.Replace("７", "7");
            value = value.Replace("８", "8");
            value = value.Replace("９", "9");
            value = value.Replace("－", "-");
            value = value.Replace("．", ".");
            return value;
        }

        public DialogResult DisplayedPrintDialog(string PrinterName
                                               , bool landscape
                                               , string paperSize
                                               , ref PrinterSettings printerSettings
                                               , ref PageSettings pageSettings)
        {
            DialogResult result = DialogResult.None;
            //PrintDialogクラスの作成
            PrintDialog pdlg = new PrintDialog();
            pdlg.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = PrinterName;
            foreach (PaperSize wkPaperSize in pdlg.PrinterSettings.DefaultPageSettings.PrinterSettings.PaperSizes)
            {
                if (wkPaperSize.Kind.ToString().Equals(paperSize.Replace("Paper", string.Empty)))
                {
                    pdlg.PrinterSettings.DefaultPageSettings.PaperSize = wkPaperSize;
                }
            }
            pdlg.PrinterSettings.DefaultPageSettings.Landscape = landscape;

            //印刷の選択ダイアログを表示する
            result = pdlg.ShowDialog();
            printerSettings = pdlg.PrinterSettings;
            pageSettings = new PageSettings(printerSettings);

            return result;
        }
    }
}
