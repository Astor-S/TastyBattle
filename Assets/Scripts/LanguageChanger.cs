using System;
using UnityEngine;
using YG;

public class LanguageChanger : MonoBehaviour
{
    private string _language = default;

    public void ChangeLanguage(string lang)
    {
        YG2.SwitchLanguage(lang);
        _language = lang;
    }

    public string GetLanguage() => 
        _language;
}
