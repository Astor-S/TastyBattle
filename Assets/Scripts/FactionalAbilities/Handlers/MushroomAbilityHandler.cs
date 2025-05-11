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
            float abilityDamageBonus = _mushroomAbility.MushroomUnitCount * _mushroomAbility.DamageBonusPerUnit;
            float damageBonus = DamageMultiplierBase + abilityDamageBonus;

            SetCurrentDamageBonus(damageBonus);
        }
    }
}