using UnityEngine;
using AttackSystem;

namespace FactionalAbilities.Handlers
{
    public class AvocadoAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AvocadoAbility _avocadoAbility;
        [SerializeField] private DamagableTarget _damageTarget;
        [SerializeField] private Explosion _explosion;

        private void OnEnable()
        {
            if (_damageTarget != null)
                _damageTarget.Dying += HandleDying;
        }

        private void OnDisable()
        {
            if (_damageTarget != null)
                _damageTarget.Dying -= HandleDying; 
        }

        private void HandleDying(DamagableTarget target)
        {
            if (_avocadoAbility != null && _explosion != null)
                _explosion.Explode(_avocadoAbility.ExplosionRadius, _avocadoAbility.ExplosionDamage);
        }
    }
}