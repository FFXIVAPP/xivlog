// --------------------------------------------------------------------------------------------------------------------
// <copyright file="English.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   English.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Localization {
    using System.Windows;

    public class English {
        private static readonly ResourceDictionary _translations = new ResourceDictionary();

        public static ResourceDictionary Translations() {
            _translations.Clear();

            _translations.Add("ChatCodesControl_RegExText", "Regular Expression");
            _translations.Add("ChatCodesControl_TabNameText", "Tab Name");
            _translations.Add("ChatCodesControl_CreateTabButtonText", "Create Tab");
            _translations.Add("MainWindow_HomeButtonToolTip", "Home");
            _translations.Add("MainWindow_SettingsButtonToolTip", "Settings");
            _translations.Add("MainWindow_ChatLogButtonToolTip", "ChatLog");
            _translations.Add("MainWindow_DebugButtonToolTip", "Debug");
            _translations.Add("MainWindow_AboutButtonToolTip", "About");
            _translations.Add("HomeTabItem_WelcomeText", "XIVLOG");
            _translations.Add("HomeTabItem_GetInTouchText", "Get In Touch");
            _translations.Add("HomeTabItem_GetInTouchExtendedText", "Say hello, make a feature request, or raise a bug through one of these channels:");
            _translations.Add("HomeTabItem_OpenSourceText", "Open Source");
            _translations.Add("HomeTabItem_OpenSourceExtendedText", "This project is completely open source. If you like it and want to say thanks you could hit the GitHub Star button, tweet or post about it, or tell your mum about it!");
            _translations.Add("HomeTabItem_DonationText", "Feel like you want to make a donation?  It would be gratefully received.  Click the button to donate via GitHub sponsors.");
            _translations.Add("Palette_PrimaryMidText", "Primary - Mid");
            _translations.Add("Palette_LightText", "Light");
            _translations.Add("Palette_MidText", "Mid");
            _translations.Add("Palette_DarkText", "Dark");
            _translations.Add("Palette_AccentText", "Accent");
            _translations.Add("PaletteSelector_DescriptionText", "This is your current palette.");
            _translations.Add("PaletteSelector_LightText", "Light");
            _translations.Add("PaletteSelector_DarkText", "Dark");
            _translations.Add("PaletteSelector_PrimaryText", "Primary");
            _translations.Add("PaletteSelector_AccentText", "Accent");
            _translations.Add("SettingsTabItem_TranslationTabHeaderText", "Translation");
            _translations.Add("SettingsTabItem_SharlayanTabHeaderText", "Sharlayan");
            _translations.Add("SettingsTabItem_ChatCodesTabHeaderText", "Chat Codes");
            _translations.Add("SettingsTabItem_ThemeTabHeaderText", "Theme");
            _translations.Add("UserSettings_DataSettingsText", "Data Settings");
            _translations.Add("UserSettings_UseCachedDataText", "Use locally cached JSON for Sharlayan resources");
            _translations.Add("UserSettings_ResetSettingsText", "Reset Settings");
            _translations.Add("UserSettings_MemoryTimingsText", "Memory Timings");
            _translations.Add("UserSettings_AdjustmentText", "Adjust these timings to increase or decrease data latency. Faster timings may increase CPU usage.");
            _translations.Add("UserSettings_ActionsHelperText", "Actions");
            _translations.Add("UserSettings_ActorHelperText", "Actor");
            _translations.Add("UserSettings_ChatLogHelperText", "ChatLog");
            _translations.Add("UserSettings_CurrentPlayerHelperText", "Current Player");
            _translations.Add("UserSettings_InventoryHelperText", "Inventory");
            _translations.Add("UserSettings_JobResourcesHelperText", "Job Resources");
            _translations.Add("UserSettings_PartyMembersHelperText", "Party Members");
            _translations.Add("UserSettings_TargetHelperText", "Target");
            _translations.Add("HomeTabItem_UnfilteredTabHeader", "Unfiltered");
            _translations.Add("HomeTabItem_TranslatedTabHeader", "Translated");
            _translations.Add("HomeTabItem_ManualTranslateToText", "Manual Translate To");
            _translations.Add("HomeTabItem_ManualTranslateFromText", "Manual Translate From");
            _translations.Add("HomeTabItem_ManualHelperText", "Enter the text you want to translate and press [CTRL + ENTER]");
            _translations.Add("FilteredChatLogTabItem_DeleteTooltip", "Delete");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsText", "General Settings");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsExtendedText", "You can choose to translate every message sent in the game; however you may end up hitting your service limits. It's recommended to only translate text that is calculated to contain international characters.");
            _translations.Add("TranslateSettingsTabItem_EnableTranslateText", "Use Automatic Translation");
            _translations.Add("TranslateSettingsTabItem_InternationalOnly", "Translate International Text Only");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationToText", "Automatic Translate To");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationFromText", "Automatic Translate From");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsText", "Provider Settings");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsExtendedText", "Please select a provider. You can use either Google or Cognitive services. Both require that you set the appropriate data keys.");
            _translations.Add("TranslateSettingsTabItem_GoogleServiceKeyText", "Google Service Key");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceKeyText", "Cognitive Service Key");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceRegionText", "Cognitive Service Region");

            return _translations;
        }
    }
}