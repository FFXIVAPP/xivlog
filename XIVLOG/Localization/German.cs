// --------------------------------------------------------------------------------------------------------------------
// <copyright file="German.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   German.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Localization {
    using System.Windows;

    public class German {
        private static readonly ResourceDictionary _translations = new ResourceDictionary();

        public static ResourceDictionary Translations() {
            _translations.Clear();

            _translations.Add("ChatCodesControl_RegExText", "Regulären Ausdruck");
            _translations.Add("ChatCodesControl_TabNameText", "Name der Registerkarte");
            _translations.Add("ChatCodesControl_CreateTabButtonText", "Registerkarte erstellen");
            _translations.Add("MainWindow_HomeButtonToolTip", "Zuhause");
            _translations.Add("MainWindow_SettingsButtonToolTip", "die Einstellungen");
            _translations.Add("MainWindow_ChatLogButtonToolTip", "Chat Protokoll");
            _translations.Add("MainWindow_DebugButtonToolTip", "Debuggen");
            _translations.Add("MainWindow_AboutButtonToolTip", "Über");
            _translations.Add("HomeTabItem_WelcomeText", "XIVLOG");
            _translations.Add("HomeTabItem_GetInTouchText", "In Kontakt kommen");
            _translations.Add("HomeTabItem_GetInTouchExtendedText", "Sagen Sie Hallo, stellen Sie eine Funktionsanfrage oder melden Sie einen Fehler über einen dieser Kanäle:");
            _translations.Add("HomeTabItem_OpenSourceText", "Open Source");
            _translations.Add("HomeTabItem_OpenSourceExtendedText", "Dieses Projekt ist komplett Open Source. Wenn es dir gefällt und du dich bedanken möchtest, kannst du auf den GitHub Star-Button klicken, darüber twittern oder posten oder deiner Mutter davon erzählen!");
            _translations.Add("HomeTabItem_DonationText", "Möchten Sie eine Spende machen? Es würde dankbar aufgenommen werden. Klicken Sie auf die Schaltfläche, um über GitHub-Sponsoren zu spenden.");
            _translations.Add("Palette_PrimaryMidText", "Grundschule - Mitte");
            _translations.Add("Palette_LightText", "Licht");
            _translations.Add("Palette_MidText", "Mitte");
            _translations.Add("Palette_DarkText", "Dunkel");
            _translations.Add("Palette_AccentText", "Akzent");
            _translations.Add("PaletteSelector_DescriptionText", "Dies ist Ihre aktuelle Palette.");
            _translations.Add("PaletteSelector_LightText", "Licht");
            _translations.Add("PaletteSelector_DarkText", "Dunkel");
            _translations.Add("PaletteSelector_PrimaryText", "Primär");
            _translations.Add("PaletteSelector_AccentText", "Akzent");
            _translations.Add("SettingsTabItem_TranslationTabHeaderText", "Übersetzung");
            _translations.Add("SettingsTabItem_SharlayanTabHeaderText", "Sharlayan");
            _translations.Add("SettingsTabItem_ChatCodesTabHeaderText", "Chat-Codes");
            _translations.Add("SettingsTabItem_ThemeTabHeaderText", "Thema");
            _translations.Add("UserSettings_DataSettingsText", "Dateneinstellungen");
            _translations.Add("UserSettings_UseCachedDataText", "Verwenden Sie lokal zwischengespeicherten JSON für Sharlayan-Ressourcen");
            _translations.Add("UserSettings_ResetSettingsText", "Einstellungen zurücksetzen");
            _translations.Add("UserSettings_MemoryTimingsText", "Speicherzeiten");
            _translations.Add("UserSettings_AdjustmentText", "Passen Sie diese Timings an, um die Datenlatenz zu erhöhen oder zu verringern. Schnellere Timings können die CPU-Auslastung erhöhen.");
            _translations.Add("UserSettings_ActionsHelperText", "Aktionen");
            _translations.Add("UserSettings_ActorHelperText", "Darsteller");
            _translations.Add("UserSettings_ChatLogHelperText", "Chat Protokoll");
            _translations.Add("UserSettings_CurrentPlayerHelperText", "Aktueller Spieler");
            _translations.Add("UserSettings_InventoryHelperText", "Inventar");
            _translations.Add("UserSettings_JobResourcesHelperText", "Jobressourcen");
            _translations.Add("UserSettings_PartyMembersHelperText", "Parteimitglieder");
            _translations.Add("UserSettings_TargetHelperText", "Ziel");
            _translations.Add("HomeTabItem_UnfilteredTabHeader", "Ungefiltert");
            _translations.Add("HomeTabItem_TranslatedTabHeader", "Übersetzt");
            _translations.Add("HomeTabItem_ManualTranslateToText", "Manuelle Übersetzung nach");
            _translations.Add("HomeTabItem_ManualTranslateFromText", "Manuelle Übersetzung von");
            _translations.Add("HomeTabItem_ManualHelperText", "Geben Sie den zu übersetzenden Text ein und drücken Sie [STRG + EINGABETASTE].");
            _translations.Add("FilteredChatLogTabItem_DeleteTooltip", "Löschen");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsText", "Allgemeine Einstellungen");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsExtendedText", "Sie können jede im Spiel gesendete Nachricht übersetzen. Möglicherweise stoßen Sie jedoch an Ihre Servicelimits. Es wird empfohlen, nur Text zu übersetzen, der internationale Zeichen enthält.");
            _translations.Add("TranslateSettingsTabItem_EnableTranslateText", "Verwenden Sie die automatische Übersetzung");
            _translations.Add("TranslateSettingsTabItem_InternationalOnly", "Nur internationalen Text übersetzen");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationToText", "Automatische Übersetzung nach");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationFromText", "Automatische Übersetzung von");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsText", "Anbietereinstellungen");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsExtendedText", "Bitte wählen Sie einen Anbieter. Sie können entweder Google- oder Cognitive-Dienste verwenden. Für beide müssen Sie die entsprechenden Datenschlüssel festlegen.");
            _translations.Add("TranslateSettingsTabItem_GoogleServiceKeyText", "Google Service Key");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceKeyText", "Kognitiver Serviceschlüssel");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceRegionText", "Kognitive Serviceregion");

            return _translations;
        }
    }
}