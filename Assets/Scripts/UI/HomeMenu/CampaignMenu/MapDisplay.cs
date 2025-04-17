using TMPro;
using UnityEngine;

namespace UI.HomeMenu.CampaignMenu
{
    public class MapDisplay : MonoBehaviour
    {
        private UnitMapView _unitMapView;

        public void DisplayMap(UnitMapView unitMapView, Transform container)
        {
            if (container.childCount > 0)
                Destroy(container.GetChild(0).gameObject);

            _unitMapView = Instantiate(unitMapView, container);
        }
    }
}