using UnityEngine;
using YG;

namespace SDKProperties
{
    public class LanguageChanger : MonoBehaviour
    {
        public void ChangeLanguage(string lang) =>
            YG2.SwitchLanguage(lang);
    }
}