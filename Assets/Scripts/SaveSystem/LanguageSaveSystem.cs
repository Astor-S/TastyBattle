using PlayerPrefs = RedefineYG.PlayerPrefs;
using UnityEngine;
using YG;

public class LanguageSaveSystem : SaveSystem
{
    private const string Language = "language";

    [SerializeField] private LanguageChanger _languageChanger;

    public override void Load()
    {
        if (YG2.saves.language == default)
            _languageChanger.ChangeLanguage(YG2.envir.language);
        else
            _languageChanger.ChangeLanguage(YG2.saves.language);

        Save();
    }

    public override void LoadLocal()
    {
        if (PlayerPrefs.HasKey(Language) == false)
            _languageChanger.ChangeLanguage(YG2.envir.language);
        else
            _languageChanger.ChangeLanguage(PlayerPrefs.GetString(Language));

        Save();
    }

    public override void Save()
    {
        PlayerPrefs.SetString(Language, _languageChanger.GetLanguage());
        PlayerPrefs.Save();

        YG2.saves.language = _languageChanger.GetLanguage();
        YG2.SaveProgress();
    }
}
