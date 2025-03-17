using FactionalAbilities;
using UnityEngine;

namespace Units
{
    public class MushroomUnit : MonoBehaviour
    {
        private const float DamageMultiplierBase = 1f;

        [SerializeField] MushroomAbility _mushroomAbility;
        [SerializeField] UnitSetup _unitSetup;

        private float _baseAttackDamage;
        private float _currentAttackDamage;

        public float CurrentAttackDamage => _currentAttackDamage;

        private void Awake()
        {
            _baseAttackDamage = _unitSetup.AttackDamage;
            _currentAttackDamage = _baseAttackDamage;
        }

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
            _currentAttackDamage = _baseAttackDamage * (DamageMultiplierBase + damageBonus);

            Debug.Log($"[{gameObject.name}] UpdateDamageBonus: " +
                     $"Base Damage = {_baseAttackDamage}, " +
                     $"Bonus = {damageBonus:F2}, " +
                     $"Current Damage = {_currentAttackDamage:F2}");
        }
    }
}