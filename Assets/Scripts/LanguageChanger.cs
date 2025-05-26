using System;
using UnityEngine;
using YG;

public class LanguageChanger : MonoBehaviour
{
    public void ChangeLanguage(string lang) =>
        YG2.SwitchLanguage(lang);
}
