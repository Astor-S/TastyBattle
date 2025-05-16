using UnityEngine;
using YG;

public class LanguageSaveSystem : SaveSystem
{
    [SerializeField] private LanguageChanger _languageChanger;

    public override void Load()
    {
        if (YG2.saves.language == default)
            _languageChanger.ChangeLanguage(YG2.envir.language);
        else
            _languageChanger.ChangeLanguage(YG2.saves.language);
    }

    public override void Save() => 
        YG2.saves.language = _languageChanger.GetLanguage();
}
