using UnityEngine;

namespace FactionalAbilities
{
    [CreateAssetMenu(fileName = "AvocadoAbility", menuName = "Scriptable Objects/AvocadoAbility", order = 63)]
    public class AvocadoAbility : ScriptableObject
    {
        [SerializeField] private float _explosionDamage = 10f;
        [SerializeField] private float _explosionRadius = 5f;

        public float ExplosionRadius => _explosionRadius;
        public float ExplosionDamage => _explosionDamage;
    }
}