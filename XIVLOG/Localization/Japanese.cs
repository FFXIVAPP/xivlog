// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Japanese.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Japanese.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Localization {
    using System.Windows;

    public class Japanese {
        private static readonly ResourceDictionary _translations = new ResourceDictionary();

        public static ResourceDictionary Translations() {
            _translations.Clear();

            _translations.Add("ChatCodesControl_RegExText", "正規表現");
            _translations.Add("ChatCodesControl_TabNameText", "タブ名");
            _translations.Add("ChatCodesControl_CreateTabButtonText", "タブを作成");
            _translations.Add("MainWindow_HomeButtonToolTip", "ホームホーム");
            _translations.Add("MainWindow_SettingsButtonToolTip", "設定");
            _translations.Add("MainWindow_ChatLogButtonToolTip", "ChatLog");
            _translations.Add("MainWindow_DebugButtonToolTip", "デバッグ");
            _translations.Add("MainWindow_AboutButtonToolTip", "いくつか");
            _translations.Add("HomeTabItem_WelcomeText", "XIVLOG");
            _translations.Add("HomeTabItem_GetInTouchText", "連絡する");
            _translations.Add("HomeTabItem_GetInTouchExtendedText", "次のいずれかのチャネルを通じて、挨拶するか、機能をリクエストするか、バグを報告してください。");
            _translations.Add("HomeTabItem_OpenSourceText", "オープンソース");
            _translations.Add("HomeTabItem_OpenSourceExtendedText", "このプロジェクトは完全にオープンソースです。 気に入って感謝の気持ちを伝えたい場合は、GitHub Starボタンを押すか、ツイートまたは投稿するか、お母さんに伝えてください。");
            _translations.Add("HomeTabItem_DonationText", "寄付したい気がしますか？ ありがたいです。 ボタンをクリックして、GitHubスポンサー経由で寄付します。");
            _translations.Add("Palette_PrimaryMidText", "プライマリ-ミッド");
            _translations.Add("Palette_LightText", "光");
            _translations.Add("Palette_MidText", "ミッド");
            _translations.Add("Palette_DarkText", "闇");
            _translations.Add("Palette_AccentText", "アクセント");
            _translations.Add("PaletteSelector_DescriptionText", "これが現在のパレットです。");
            _translations.Add("PaletteSelector_LightText", "光");
            _translations.Add("PaletteSelector_DarkText", "闇");
            _translations.Add("PaletteSelector_PrimaryText", "プライマリ");
            _translations.Add("PaletteSelector_AccentText", "アクセント");
            _translations.Add("SettingsTabItem_TranslationTabHeaderText", "翻訳");
            _translations.Add("SettingsTabItem_SharlayanTabHeaderText", "Sharlayan");
            _translations.Add("SettingsTabItem_ChatCodesTabHeaderText", "チャットコード");
            _translations.Add("SettingsTabItem_ThemeTabHeaderText", "テーマ");
            _translations.Add("UserSettings_DataSettingsText", "データ設定");
            _translations.Add("UserSettings_UseCachedDataText", "SharlayanリソースにローカルにキャッシュされたJSONを使用する");
            _translations.Add("UserSettings_ResetSettingsText", "設定をリセット");
            _translations.Add("UserSettings_MemoryTimingsText", "メモリのタイミング");
            _translations.Add("UserSettings_AdjustmentText", "これらのタイミングを調整して、データの待ち時間を増減します。 タイミングが速いと、CPU使用率が高くなる可能性があります。");
            _translations.Add("UserSettings_ActionsHelperText", "行動");
            _translations.Add("UserSettings_ActorHelperText", "俳優");
            _translations.Add("UserSettings_ChatLogHelperText", "ChatLog");
            _translations.Add("UserSettings_CurrentPlayerHelperText", "現在のプレーヤー");
            _translations.Add("UserSettings_InventoryHelperText", "在庫");
            _translations.Add("UserSettings_JobResourcesHelperText", "求人情報");
            _translations.Add("UserSettings_PartyMembersHelperText", "党員");
            _translations.Add("UserSettings_TargetHelperText", "目標");
            _translations.Add("HomeTabItem_UnfilteredTabHeader", "フィルタリングされていない");
            _translations.Add("HomeTabItem_TranslatedTabHeader", "翻訳済み");
            _translations.Add("HomeTabItem_ManualTranslateToText", "手動翻訳先");
            _translations.Add("HomeTabItem_ManualTranslateFromText", "手動翻訳元");
            _translations.Add("HomeTabItem_ManualHelperText", "翻訳したいテキストを入力し、[CTRL + ENTER]を押します");
            _translations.Add("FilteredChatLogTabItem_DeleteTooltip", "削除");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsText", "一般設定");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsExtendedText", "ゲームで送信されるすべてのメッセージを翻訳することを選択できます。 ただし、サービスの制限に達する可能性があります。 国際文字を含むように計算されたテキストのみを翻訳することをお勧めします。");
            _translations.Add("TranslateSettingsTabItem_EnableTranslateText", "自動翻訳を使用する");
            _translations.Add("TranslateSettingsTabItem_InternationalOnly", "翻訳国際テキストのみ");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationToText", "自動翻訳先");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationFromText", "自動翻訳元");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsText", "プロバイダー設定");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsExtendedText", "プロバイダーを選択してください。 GoogleまたはCognitiveサービスのいずれかを使用できます。 どちらの場合も、適切なデータキーを設定する必要があります。");
            _translations.Add("TranslateSettingsTabItem_GoogleServiceKeyText", "Googleサービスキー");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceKeyText", "コグニティブサービスキー");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceRegionText", "コグニティブサービスリージョン");

            return _translations;
        }
    }
}