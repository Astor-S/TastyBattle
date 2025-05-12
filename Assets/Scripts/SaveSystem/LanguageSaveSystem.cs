using UnityEngine;
using YG;

public class LanguageSaveSystem : SaveSystem
{
    [SerializeField] private LanguageChanger _languageChanger;

    public override void Load()
    {
        if (YG2.saves.Language == default)
            _languageChanger.ChangeLanguage(YG2.envir.language);
        else
            _languageChanger.ChangeLanguage(YG2.saves.Language);
    }

    public override void Save() => 
        YG2.saves.Language = _languageChanger.GetLanguage();
}
