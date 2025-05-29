using UnityEngine;

namespace UI.HomeMenu.CampaignMenu
{
    public class UnitModelView : MonoBehaviour
    {
        [SerializeField] private TextTranslation _textTranslation;

        public TextTranslation TextTranslation => _textTranslation;
    }
}