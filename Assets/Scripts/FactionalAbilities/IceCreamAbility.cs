using UnityEngine;

namespace FactionalAbilities
{
    [CreateAssetMenu(fileName = "IceCreamAbility", menuName = "Scriptable Objects/IceCreamAbility", order = 64)]
    public class IceCreamAbility : ScriptableObject
    {
        [SerializeField] private float _freezePercentage = 0.05f; 
        [SerializeField] private float _freezeDuration = 3f; 
        [SerializeField] private float _maxFreezePercentage = 0.5f;

        public float FreezePercentage => _freezePercentage;
        public float FreezeDuration => _freezeDuration;
        public float MaxFreezePercentage => _maxFreezePercentage;
    }
}