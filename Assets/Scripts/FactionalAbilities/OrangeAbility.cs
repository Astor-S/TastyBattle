using UnityEngine;

namespace FactionalAbilities
{
    [CreateAssetMenu(fileName = "OrangeAbility", menuName = "Scriptable Objects/OrangeAbility", order = 62)]
    public class OrangeAbility : ScriptableObject
    {
        [SerializeField] private float _damagePerSecond = 1f; 
        [SerializeField] private float _duration = 3f; 

        public float DamagePerSecond => _damagePerSecond;
        public float Duration => _duration;
    }
}