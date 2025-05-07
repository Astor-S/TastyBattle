using UnityEngine;
using AttackSystem;

namespace FactionalAbilities.Handlers
{
    public class AvocadoAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AvocadoAbility _avocadoAbility;
        [SerializeField] private DamagableTarget _damageTarget;
        [SerializeField] private Explosion _explosion;

        private bool _isExploding = false;

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
            if (_isExploding)
                return; 
            
            _isExploding = true; 

            if (_avocadoAbility != null && _explosion != null) 
                _explosion.Explode(_avocadoAbility.ExplosionRadius, _avocadoAbility.ExplosionDamage);

            _isExploding = false;
        }
    }
}