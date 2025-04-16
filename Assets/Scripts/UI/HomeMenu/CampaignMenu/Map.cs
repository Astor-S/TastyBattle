using UnityEngine;
using UI.HomeMenu.CampaignMenu.Interfaces;

namespace UI.HomeMenu.CampaignMenu
{
    [CreateAssetMenu(fileName = "NewMap", menuName = "Scriptable Objects/Map")]

    public class Map : ScriptableObject, IMapImageProvider
    {
        [SerializeField] private int _mapIndex;
        [SerializeField] private Sprite _mapImage;

        public Sprite GetMapImage() =>
            _mapImage;
    }
}