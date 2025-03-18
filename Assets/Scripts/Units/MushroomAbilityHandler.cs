using FactionalAbilities;
using StructureElements;

namespace Units
{
    public class MushroomAbilityHandler : IActivatable
    {
        private const float DamageMultiplierBase = 1f;

        private readonly MushroomAbility _mushroomAbility;
        private readonly UnitSetup _unitSetup;

        private float _currentAttackDamage;

        public float CurrentAttackDamage => _currentAttackDamage;

        public MushroomAbilityHandler(UnitSetup unitSetup, MushroomAbility mushroomAbility)
        {
            _unitSetup = unitSetup;
            _currentAttackDamage = unitSetup.AttackDamage;
            _mushroomAbility = mushroomAbility;
        }

        public void Enable()
        {
            _mushroomAbility.AddUnit();
            UpdateDamageBonus();
        }

        public void Disable()
        {
            _mushroomAbility.RemoveUnit();
            UpdateDamageBonus();
        }

        private void UpdateDamageBonus()
        {
            float damageBonus = _mushroomAbility.MushroomUnitCount * _mushroomAbility.DamageBonusPerUnit;
            _currentAttackDamage = _unitSetup.AttackDamage * (DamageMultiplierBase + damageBonus);
        }
    }
}