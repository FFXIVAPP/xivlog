﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="French.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   French.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Localization {
    using System.Windows;

    public class French {
        private static readonly ResourceDictionary _translations = new ResourceDictionary();

        public static ResourceDictionary Translations() {
            _translations.Clear();

            _translations.Add("ChatCodesControl_RegExText", "Expression régulière");
            _translations.Add("ChatCodesControl_TabNameText", "Nom de l'onglet");
            _translations.Add("ChatCodesControl_CreateTabButtonText", "Créer un onglet ");
            _translations.Add("MainWindow_HomeButtonToolTip", "Domicile");
            _translations.Add("MainWindow_SettingsButtonToolTip", "Paramètres");
            _translations.Add("MainWindow_ChatLogButtonToolTip", "ChatLog");
            _translations.Add("MainWindow_DebugButtonToolTip", "Déboguer");
            _translations.Add("MainWindow_AboutButtonToolTip", "Quelque");
            _translations.Add("HomeTabItem_WelcomeText", "XIVLOG");
            _translations.Add("HomeTabItem_GetInTouchText", "Entrer en contact");
            _translations.Add("HomeTabItem_GetInTouchExtendedText", "Dites bonjour, faites une demande de fonctionnalité ou soulevez un bogue via l'un de ces canaux:");
            _translations.Add("HomeTabItem_OpenSourceText", "Open source");
            _translations.Add("HomeTabItem_OpenSourceExtendedText", "Ce projet est entièrement open source. Si vous l'aimez et que vous voulez dire merci, vous pouvez appuyer sur le bouton GitHub Star, tweeter ou publier à ce sujet, ou en parler à votre mère!");
            _translations.Add("HomeTabItem_DonationText", "Envie de faire un don? Il serait reçu avec gratitude. Cliquez sur le bouton pour faire un don via les sponsors GitHub.");
            _translations.Add("Palette_PrimaryMidText", "Primaire - Moyen");
            _translations.Add("Palette_LightText", "Lumière");
            _translations.Add("Palette_MidText", "Milieu");
            _translations.Add("Palette_DarkText", "Sombre");
            _translations.Add("Palette_AccentText", "Accent");
            _translations.Add("PaletteSelector_DescriptionText", "Ceci est votre palette actuelle.");
            _translations.Add("PaletteSelector_LightText", "Lumière");
            _translations.Add("PaletteSelector_DarkText", "Sombre");
            _translations.Add("PaletteSelector_PrimaryText", "Primaire");
            _translations.Add("PaletteSelector_AccentText", "Accent");
            _translations.Add("SettingsTabItem_TranslationTabHeaderText", "Traduction");
            _translations.Add("SettingsTabItem_SharlayanTabHeaderText", "Sharlayan");
            _translations.Add("SettingsTabItem_ChatCodesTabHeaderText", "Codes de chat");
            _translations.Add("SettingsTabItem_ThemeTabHeaderText", "Thème");
            _translations.Add("UserSettings_DataSettingsText", "Paramètres de données");
            _translations.Add("UserSettings_UseCachedDataText", "Utiliser le JSON mis en cache localement pour les ressources Sharlayan");
            _translations.Add("UserSettings_ResetSettingsText", "Réinitialiser les options");
            _translations.Add("UserSettings_MemoryTimingsText", "Timings de la mémoire");
            _translations.Add("UserSettings_AdjustmentText", "Ajustez ces horaires pour augmenter ou réduire la latence des données. Des synchronisations plus rapides peuvent augmenter l'utilisation du processeur.");
            _translations.Add("UserSettings_ActionsHelperText", "Actions");
            _translations.Add("UserSettings_ActorHelperText", "Acteur");
            _translations.Add("UserSettings_ChatLogHelperText", "ChatLog");
            _translations.Add("UserSettings_CurrentPlayerHelperText", "Joueur actuel");
            _translations.Add("UserSettings_InventoryHelperText", "Inventaire");
            _translations.Add("UserSettings_JobResourcesHelperText", "Ressources d'emploi");
            _translations.Add("UserSettings_PartyMembersHelperText", "Membres du parti");
            _translations.Add("UserSettings_TargetHelperText", "Cible");
            _translations.Add("HomeTabItem_UnfilteredTabHeader", "Non filtré");
            _translations.Add("HomeTabItem_TranslatedTabHeader", "Traduit");
            _translations.Add("HomeTabItem_ManualTranslateToText", "Manuel Traduire en");
            _translations.Add("HomeTabItem_ManualTranslateFromText", "Traduire manuellement à partir de");
            _translations.Add("HomeTabItem_ManualHelperText", "Saisissez le texte que vous souhaitez traduire et appuyez sur [CTRL + ENTRÉE]");
            _translations.Add("FilteredChatLogTabItem_DeleteTooltip", "Effacer");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsText", "réglages généraux");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsExtendedText", "Vous pouvez choisir de traduire chaque message envoyé dans le jeu; Cependant, vous pourriez finir par atteindre vos limites de service. Il est recommandé de ne traduire que le texte calculé pour contenir des caractères internationaux.");
            _translations.Add("TranslateSettingsTabItem_EnableTranslateText", "Utiliser la traduction automatique");
            _translations.Add("TranslateSettingsTabItem_InternationalOnly", "Trasnlate International Text uniquement");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationToText", "Traduire automatique en");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationFromText", "Traduire automatiquement à partir de");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsText", "Paramètres du fournisseur");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsExtendedText", "Veuillez sélectionner un fournisseur. Vous pouvez utiliser les services Google ou Cognitive. Les deux nécessitent que vous définissiez les clés de données appropriées.");
            _translations.Add("TranslateSettingsTabItem_GoogleServiceKeyText", "Clé de service Google");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceKeyText", "Clé de service cognitif");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceRegionText", "Région de service cognitif");

            return _translations;
        }
    }
}