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
            Debug.Log($"[{gameObject.name}] OnEnable: Mushroom Unit Count = {_mushroomAbility.MushroomUnitCount}");
            UpdateDamageBonus();
        }

        private void OnDisable()
        {
            _mushroomAbility.RemoveUnit();
            Debug.Log($"[{gameObject.name}] OnDisable: Mushroom Unit Count = {_mushroomAbility.MushroomUnitCount}");
            UpdateDamageBonus();
        }

        private void UpdateDamageBonus()
        {
            float damageBonus = _mushroomAbility.MushroomUnitCount * _mushroomAbility.DamageBonusPerUnit;
            float baseDamage = GetBaseAttackDamage();
            float currentDamage = baseDamage * (DamageMultiplierBase + damageBonus);
            
            SetCurrentAttackDamage(currentDamage);

            Debug.Log($"[{gameObject.name}] UpdateDamageBonus: " +
                     $"Base Damage = {baseDamage}, " +
                     $"Bonus = {damageBonus:F2}, " +
                     $"Current Damage = {CurrentAttackDamage:F2}");
        }
    }
}