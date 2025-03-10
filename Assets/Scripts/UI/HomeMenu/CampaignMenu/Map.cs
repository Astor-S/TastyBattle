using UnityEngine;

namespace UI.HomeMenu.CampaignMenu
{
    [CreateAssetMenu(fileName = "NewMap", menuName = "Scriptable Objects/Map")]
    public class Map : ScriptableObject, Interfaces.IMapImageProvider
    {
        [SerializeField] private int _mapIndex;
        [SerializeField] private Sprite _mapImage;

        public Sprite GetMapImage() =>
            _mapImage;
    }
}