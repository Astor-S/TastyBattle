using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class MushroomAbilityHandler : AttackAbilityHandler
    {
        private const float DamageMultiplierBase = 1f;

        [SerializeField] MushroomAbility _mushroomAbility;

        private void OnEnable()
        {
            _mushroomAbility.AddUnit();
            UpdateDamageBonus();
        }

        private void OnDisable()
        {
            _mushroomAbility.RemoveUnit();
            UpdateDamageBonus();
        }

        private void UpdateDamageBonus()
        {
            float damageBonus = _mushroomAbility.MushroomUnitCount * _mushroomAbility.DamageBonusPerUnit;
            float baseDamage = GetBaseAttackDamage();
            float currentDamage = baseDamage * (DamageMultiplierBase + damageBonus);
            
            SetCurrentAttackDamage(currentDamage);
        }
    }
}