using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorce
{
    class Messages
    {
        public const string M0001 = "保存しますか？";
        public const string M0002 = "削除しますか？";
        public const string M0003 = "入力した{0}は存在しません。";
        public const string M0004 = "複写する行を選択してください。";
        public const string M0005 = "行複写を実行してください。\r(複写中の行は背景色が薄緑色となります。)";
        public const string M0006 = "貼付する行を選択してください。\r(選択行は背景色が水色となります。)";
        public const string M0007 = "入力中の内容が上書きされますが貼付してよろしいですか？";
        public const string M0008 = "挿入する行を選択してください。\r(選択行は背景色が水色となります。)";
        public const string M0009 = "削除する行を選択してください。\r(選択行は背景色が水色となります。)";
        public const string M0010 = "明細の中間に存在する空白行は削除されます。\r処理を継続してよろしいですか？";
        public const string M0011 = "{0}の{1}でエラーが発生しました。\r再度処理を実行してください。";
        public const string M0012 = "{0}の{1}が完了しました。";
        public const string M0013 = "既に{0}された{1}のため、{2}できません。";
        public const string M0014 = "保存処理が実行されていないため入力内容が破棄されます。\r{0}";
        public const string M0015 = "削除処理が実行されていません。\r{0}";
        public const string M0016 = "選択した行は{0}のため{1}できません。\r{2}";
        public const string M0017 = "有効な日付を入力してください。";
        public const string M0018 = "対象の行を選択してください。";
        public const string M0019 = "既に入力済みの{0}、{1}、{2}、{3}が上書きされますがよろしいですか？";
        public const string M0020 = "{0}を入力してください。";
        public const string M0021 = "入力中の内容が上書きされますが処理を継続してよろしいですか？";
        public const string M0022 = "{0}は{1}のみ入力可能です。";
        public const string M0023 = "{0}と{1}を入力してください。";
        public const string M0024 = "入力したIDまたはパスワードに誤りがあります。\r入力内容を確認してください。";
        public const string M0025 = "備考入力行を選択してください。\r(選択行は背景色が水色となります。)";
        public const string M0026 = "{0}を起動しますがよろしいですか？";
        public const string M0027 = "対象の{0}は他者によって使用中のため処理を継続できません。";
        public const string M0028 = "納品書が出力済みのため、明細部の仕入単価、仕入金額、仕入先納品数のみ編集可能です。";
        public const string M0029 = "指定した{0}は存在しません。";
        public const string M0030 = "受注入力画面で作成した明細は削除できません。";
        public const string M0031 = "対象の{0}は{1}が他者によって使用中のため処理を継続できません。";
        public const string M0032 = "対象の仕入データは納品書入力によって作成されたデータのため以下の操作が行えません。\r・ヘッダ部の編集\r・明細の追加および削除";
        public const string M0033 = "入力内容が破棄されます。\r{0}";
        public const string M0034 = "一覧画面で入力中の内容が破棄されます。\r処理を継続してよろしいですか？";
        public const string M0035 = "更新対象のデータが他者によって使用中のため処理を実行できませんでした。";
        public const string M0036 = "指定した締日に該当する得意先は存在しません。\r締日を変更して再度実行してください。";
        public const string M0037 = "更新対象のデータが存在しないため処理を実行できませんでした。";
        public const string M0038 = "{0}年{1}月度の締日更新処理を実行します。\rよろしいですか？";
        public const string M0039 = "{0}年{1}月度の取消処理を実行します。\rよろしいですか？";
        public const string M0040 = "請求日には{0}年{1}月{2}日から{3}年{4}月{5}日の日付を入力してください。";
        public const string M0041 = "対象売上日付を入力する場合は、自、至共に入力してください。";
        public const string M0042 = "{0}年{1}月度の{2}処理が完了しました。";
        public const string M0043 = "{0}年{1}月度の{2}でエラーが発生しました。";
        public const string M0044 = "事業所コードが未入力の場合、「000」として登録されますがよろしいですか？";
        public const string M0045 = "入力した得意先コードと事業所コードの組み合わせは既に得意先マスタに登録されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0046 = "入力した請求先コードと請求先事業所コードの組み合わせは得意先マスタに存在しません。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0047 = "商品コードが未入力のため、登録済みの商品コードのうち、最大値+1が自動採番されます。\r処理を継続してよろしいですか？";
        public const string M0048 = "入力した商品コードは既に商品マスタに登録されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0049 = "入力した伝票Noは既に使用されています。\r{0}以上の値を入力してください。";
        public const string M0050 = "入力した仕入先コードは既に仕入先マスタに登録されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0051 = "入力した担当者コードは既に担当者マスタに登録されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0052 = "入力した担当者コードは既に担当者マスタから削除されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0053 = "入力した名称コードは既に名称マスタに登録されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0054 = "入力した名称コードと区分の組み合わせは既に名称マスタに登録されています。\r入力内容を確認の上、再度保存処理を実行してください。";
        public const string M0055 = "{0}年{1}月の請求締処理が行われていないため出力できません。";
        public const string M0056 = "対象の仕入データは納品書入力によって作成されたデータのため削除できません。";
        public const string M0057 = "納品書が入力済みのため削除できません。";
        public const string M0058 = "締め処理を実施済みの納品書のため訂正・削除できません。\r締め処理を取消後、再度実行してください。";
        public const string M0059 = "選択した行は納品書作成以前から存在する明細のため貼り付けできません。";
        public const string M0060 = "納品書作成以前から存在する明細の上には挿入できません。";
        public const string M0061 = "納品書作成以前から存在する明細は削除できません。";
        public const string M0062 = "得意先コードに99999が設定されています。\r納品書作成を行いますか？";
        public const string M0063 = "得意先請求管理ファイルが他者により更新中のため処理を継続できません。";
        public const string M0064 = "検索条件に一致する売上データは存在しませんでした。";
        public const string M0065 = "指定した事業所には請求管理先が存在するため、個別更新による取消は実行できません。\r操作を実行したい場合、全件更新から取消を行うか請求管理先を指定して取消を行ってください。";
    }
}
