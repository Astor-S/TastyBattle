using PlayerPrefs = RedefineYG.PlayerPrefs;
using UnityEngine;
using YG;

public class LanguageSaveSystem : SaveSystem
{
    private const string Language = "language";

    [SerializeField] private LanguageChanger _languageChanger;

    private void OnEnable() => 
        _languageChanger.LanguageChanged += Save;

    private void OnDisable() => 
        _languageChanger.LanguageChanged -= Save;

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
        PlayerPrefs.SetString(Language, YG2.lang);
        PlayerPrefs.Save();

        YG2.saves.language = YG2.lang;
        YG2.SaveProgress();
    }
}
