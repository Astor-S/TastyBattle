using System.Collections.Generic;
using UnityEngine;
using FactionalAbilities;

namespace Units
{
    public class MushroomUnitFactory : UnitFactory
    {
        [SerializeField] private UnitPresenter[] _mushroomUnits;
        [SerializeField] private MushroomAbility _mushroomAbility;

        private void Awake()
        {
            _unitTemplates = new Dictionary<BattleRole, UnitPresenter>();

            foreach (UnitPresenter unit in _mushroomUnits)
            {
                if (_unitTemplates.ContainsKey(unit.BattleRole) == false)
                    _unitTemplates.Add(unit.BattleRole, unit);
            }
        }

        protected override AbilityHandler CreateAbilityHandler(UnitSetup unitSetup) =>
            new MushroomAbilityHandler(unitSetup, _mushroomAbility);
    }
}