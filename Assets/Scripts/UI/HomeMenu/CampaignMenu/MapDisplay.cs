using TMPro;
using UnityEngine;

namespace UI.HomeMenu.CampaignMenu
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerDescriptionField;
        [SerializeField] private TextMeshProUGUI _enemyDescriptionField;

        private UnitMapView _unitMapView;

        public TextMeshProUGUI PlayerDescrotionField => _playerDescriptionField;
        public TextMeshProUGUI EnemyDescriptionField => _enemyDescriptionField;

        public void DisplayMap(UnitMapView unitMapView, Transform container, TextMeshProUGUI text)
        {
            if (container.childCount > 0)
                Destroy(container.GetChild(0).gameObject);

            _unitMapView = Instantiate(unitMapView, container);

            text.text = _unitMapView.Description;
        }
    }
}