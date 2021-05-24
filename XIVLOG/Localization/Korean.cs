﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Korean.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Korean.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Localization {
    using System.Windows;

    public class Korean {
        private static readonly ResourceDictionary _translations = new ResourceDictionary();

        public static ResourceDictionary Translations() {
            _translations.Clear();

            _translations.Add("ChatCodesControl_RegExText", "정규식");
            _translations.Add("ChatCodesControl_TabNameText", "탭 이름");
            _translations.Add("ChatCodesControl_CreateTabButtonText", "탭 만들기");
            _translations.Add("MainWindow_HomeButtonToolTip", "집");
            _translations.Add("MainWindow_SettingsButtonToolTip", "설정");
            _translations.Add("MainWindow_ChatLogButtonToolTip", "ChatLog");
            _translations.Add("MainWindow_DebugButtonToolTip", "디버그");
            _translations.Add("MainWindow_AboutButtonToolTip", "약간");
            _translations.Add("HomeTabItem_WelcomeText", "XIVLOG");
            _translations.Add("HomeTabItem_GetInTouchText", "연락하기");
            _translations.Add("HomeTabItem_GetInTouchExtendedText", "다음 채널 중 하나를 통해 인사, 기능 요청 또는 버그 제기 :");
            _translations.Add("HomeTabItem_OpenSourceText", "오픈 소스");
            _translations.Add("HomeTabItem_OpenSourceExtendedText", "이 프로젝트는 완전히 오픈 소스입니다. 당신이 그것을 좋아하고 감사의 말을 전하고 싶다면 GitHub Star 버튼을 누르거나, 그것에 대해 트윗하거나 게시하거나, 엄마에게 그것에 대해 말할 수 있습니다!");
            _translations.Add("HomeTabItem_DonationText", "기부하고 싶으신가요? 고맙게 받아 들일 것입니다. 버튼을 클릭하여 GitHub 스폰서를 통해 기부하세요.");
            _translations.Add("Palette_PrimaryMidText", "기본-중간");
            _translations.Add("Palette_LightText", "빛");
            _translations.Add("Palette_MidText", "중간");
            _translations.Add("Palette_DarkText", "어두운");
            _translations.Add("Palette_AccentText", "악센트");
            _translations.Add("PaletteSelector_DescriptionText", "이것이 현재 팔레트입니다.");
            _translations.Add("PaletteSelector_LightText", "빛");
            _translations.Add("PaletteSelector_DarkText", "어두운");
            _translations.Add("PaletteSelector_PrimaryText", "일 순위");
            _translations.Add("PaletteSelector_AccentText", "악센트");
            _translations.Add("SettingsTabItem_TranslationTabHeaderText", "번역");
            _translations.Add("SettingsTabItem_SharlayanTabHeaderText", "Sharlayan");
            _translations.Add("SettingsTabItem_ChatCodesTabHeaderText", "채팅 코드");
            _translations.Add("SettingsTabItem_ThemeTabHeaderText", "테마");
            _translations.Add("UserSettings_DataSettingsText", "데이터 설정");
            _translations.Add("UserSettings_UseCachedDataText", "Sharlayan 리소스에 로컬로 캐시 된 JSON 사용");
            _translations.Add("UserSettings_ResetSettingsText", "설정 재설정");
            _translations.Add("UserSettings_MemoryTimingsText", "메모리 타이밍");
            _translations.Add("UserSettings_AdjustmentText", "이러한 타이밍을 조정하여 데이터 대기 시간을 늘리거나 줄입니다. 타이밍이 빠를수록 CPU 사용량이 늘어날 수 있습니다.");
            _translations.Add("UserSettings_ActionsHelperText", "행위");
            _translations.Add("UserSettings_ActorHelperText", "배우");
            _translations.Add("UserSettings_ChatLogHelperText", "ChatLog");
            _translations.Add("UserSettings_CurrentPlayerHelperText", "현재 플레이어");
            _translations.Add("UserSettings_InventoryHelperText", "목록");
            _translations.Add("UserSettings_JobResourcesHelperText", "직업 자원");
            _translations.Add("UserSettings_PartyMembersHelperText", "파티원");
            _translations.Add("UserSettings_TargetHelperText", "표적");
            _translations.Add("HomeTabItem_UnfilteredTabHeader", "필터링되지 않음");
            _translations.Add("HomeTabItem_TranslatedTabHeader", "번역됨");
            _translations.Add("HomeTabItem_ManualTranslateToText", "수동 번역");
            _translations.Add("HomeTabItem_ManualTranslateFromText", "수동 번역");
            _translations.Add("HomeTabItem_ManualHelperText", "번역 할 텍스트를 입력하고 [CTRL + ENTER]를 누릅니다.");
            _translations.Add("FilteredChatLogTabItem_DeleteTooltip", "지우다");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsText", "일반 설정");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsExtendedText", "게임에서 보낸 모든 메시지를 번역하도록 선택할 수 있습니다. 그러나 서비스 제한에 도달 할 수 있습니다. 국제 문자를 포함하는 것으로 계산 된 텍스트 만 번역하는 것이 좋습니다.");
            _translations.Add("TranslateSettingsTabItem_EnableTranslateText", "자동 번역 사용");
            _translations.Add("TranslateSettingsTabItem_InternationalOnly", "Trasnlate 국제 텍스트 전용");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationToText", "자동 번역");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationFromText", "다음에서 자동 번역");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsText", "공급자 설정");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsExtendedText", "공급자를 선택하십시오. Google 또는 Cognitive 서비스를 사용할 수 있습니다. 둘 다 적절한 데이터 키를 설정해야합니다.");
            _translations.Add("TranslateSettingsTabItem_GoogleServiceKeyText", "Google 서비스 키");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceKeyText", "인지 서비스 키");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceRegionText", "인지 서비스 지역");

            return _translations;
        }
    }
}