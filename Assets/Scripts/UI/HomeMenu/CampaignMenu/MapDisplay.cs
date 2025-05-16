using TMPro;
using UnityEngine;
using YG;

namespace UI.HomeMenu.CampaignMenu
{
    public class MapDisplay : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _playerDescriptionField;
        [SerializeField] private TextMeshProUGUI _enemyDescriptionField;

        private UnitModelView _unitMapView;

        public TextMeshProUGUI PlayerDescriptionField => _playerDescriptionField;
        public TextMeshProUGUI EnemyDescriptionField => _enemyDescriptionField;

        public void DisplayMap(UnitModelView unitMapView, Transform container, TextMeshProUGUI text)
        {
            if (container.childCount > 0)
                Destroy(container.GetChild(0).gameObject);

            _unitMapView = Instantiate(unitMapView, container);

            text.text = _unitMapView.LanguageDescription[YG2.lang];
        }
    }
}