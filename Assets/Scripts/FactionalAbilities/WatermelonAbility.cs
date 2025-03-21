using UnityEngine;

namespace FactionalAbilities
{
    [CreateAssetMenu(fileName = "WatermelonAbility", menuName = "Scriptable Objects/WatermelonAbility", order = 61)]
    public class WatermelonAbility : ScriptableObject
    {
        [SerializeField] private float _damageBoostThreshold = 0.5f; 
        [SerializeField] private float _damageBoostPercentage = 0.25f; 

        public float DamageBoostThreshold => _damageBoostThreshold;
        public float DamageBoostPercentage => _damageBoostPercentage;
    }
}