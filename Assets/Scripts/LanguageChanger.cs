using System;
using UnityEngine;
using YG;

public class LanguageChanger : MonoBehaviour
{
    public event Action LanguageChanged;

    public void ChangeLanguage(string lang)
    {
        YG2.SwitchLanguage(lang);
        LanguageChanged?.Invoke();
    }
}
