// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Chinese.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Chinese.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Localization {
    using System.Windows;

    public class Chinese {
        private static readonly ResourceDictionary _translations = new ResourceDictionary();

        public static ResourceDictionary Translations() {
            _translations.Clear();

            _translations.Add("ChatCodesControl_RegExText", "正则表达式");
            _translations.Add("ChatCodesControl_TabNameText", "标签名称");
            _translations.Add("ChatCodesControl_CreateTabButtonText", "创建标签");
            _translations.Add("MainWindow_HomeButtonToolTip", "家");
            _translations.Add("MainWindow_SettingsButtonToolTip", "设定值");
            _translations.Add("MainWindow_ChatLogButtonToolTip", "聊天记录");
            _translations.Add("MainWindow_DebugButtonToolTip", "除错");
            _translations.Add("MainWindow_AboutButtonToolTip", "关于");
            _translations.Add("HomeTabItem_WelcomeText", "XIVLOG");
            _translations.Add("HomeTabItem_GetInTouchText", "保持联系");
            _translations.Add("HomeTabItem_GetInTouchExtendedText", "打个招呼，提出功能请求，或通过以下其中一种渠道引发错误：");
            _translations.Add("HomeTabItem_OpenSourceText", "开源的");
            _translations.Add("HomeTabItem_OpenSourceExtendedText", "该项目是完全开源的。 如果您喜欢它并想说谢谢，您可以点击GitHub Star按钮，发布或发布有关它的信息，或者告诉您的妈妈有关它的信息！");
            _translations.Add("HomeTabItem_DonationText", "感觉要捐款吗？ 我们将不胜感激。 单击该按钮以通过GitHub赞助者进行捐赠。");
            _translations.Add("Palette_PrimaryMidText", "小学-中");
            _translations.Add("Palette_LightText", "光");
            _translations.Add("Palette_MidText", "中");
            _translations.Add("Palette_DarkText", "黑暗的");
            _translations.Add("Palette_AccentText", "口音");
            _translations.Add("PaletteSelector_DescriptionText", "这是您当前的调色板。");
            _translations.Add("PaletteSelector_LightText", "光");
            _translations.Add("PaletteSelector_DarkText", "黑暗的");
            _translations.Add("PaletteSelector_PrimaryText", "基本的");
            _translations.Add("PaletteSelector_AccentText", "口音");
            _translations.Add("SettingsTabItem_TranslationTabHeaderText", "翻译");
            _translations.Add("SettingsTabItem_SharlayanTabHeaderText", "Sharlayan");
            _translations.Add("SettingsTabItem_ChatCodesTabHeaderText", "聊天码");
            _translations.Add("SettingsTabItem_ThemeTabHeaderText", "主题");
            _translations.Add("UserSettings_DataSettingsText", "资料设定");
            _translations.Add("UserSettings_UseCachedDataText", "使用本地缓存的JSON获取Sharlayan资源");
            _translations.Add("UserSettings_ResetSettingsText", "重新设置");
            _translations.Add("UserSettings_MemoryTimingsText", "记忆时间");
            _translations.Add("UserSettings_AdjustmentText", "调整这些时序以增加或减少数据延迟。 更快的计时可能会增加CPU使用率。");
            _translations.Add("UserSettings_ActionsHelperText", "动作");
            _translations.Add("UserSettings_ActorHelperText", "演员");
            _translations.Add("UserSettings_ChatLogHelperText", "聊天记录");
            _translations.Add("UserSettings_CurrentPlayerHelperText", "现任球员");
            _translations.Add("UserSettings_InventoryHelperText", "存货");
            _translations.Add("UserSettings_JobResourcesHelperText", "工作资源");
            _translations.Add("UserSettings_PartyMembersHelperText", "党员");
            _translations.Add("UserSettings_TargetHelperText", "目标");
            _translations.Add("HomeTabItem_UnfilteredTabHeader", "未过滤");
            _translations.Add("HomeTabItem_TranslatedTabHeader", "已翻译");
            _translations.Add("HomeTabItem_ManualTranslateToText", "手动翻译成");
            _translations.Add("HomeTabItem_ManualTranslateFromText", "手动翻译自");
            _translations.Add("HomeTabItem_ManualHelperText", "输入您要翻译的文字，然后按[CTRL + ENTER]");
            _translations.Add("FilteredChatLogTabItem_DeleteTooltip", "删除");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsText", "常规设置");
            _translations.Add("TranslateSettingsTabItem_GeneralSettingsExtendedText", "您可以选择翻译游戏中发送的每条消息； 但是，您最终可能会达到服务限制。 建议仅翻译经计算包含国际字符的文本。");
            _translations.Add("TranslateSettingsTabItem_EnableTranslateText", "使用自动翻译");
            _translations.Add("TranslateSettingsTabItem_InternationalOnly", "只翻译国际文字");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationToText", "自动翻译成");
            _translations.Add("TranslateSettingsTabItem_AutomaticTranslationFromText", "自动翻译自");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsText", "提供者设置");
            _translations.Add("TranslateSettingsTabItem_ProviderSettingsExtendedText", "请选择一个提供商。 您可以使用Google或认知服务。 两者都要求您设置适当的数据密钥。");
            _translations.Add("TranslateSettingsTabItem_GoogleServiceKeyText", "Google服务金钥");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceKeyText", "认知服务密钥");
            _translations.Add("TranslateSettingsTabItem_CognitiveServiceRegionText", "认知服务区");

            return _translations;
        }
    }
}