using StructureElements;
using Units.Interfaces;

namespace Units
{
    public class MushroomUnit : Unit, IActivatable, IUnitWithAbility
    {
        private MushroomAbilityHandler _abilityHandler;

        public MushroomUnit(UnitSetup unitSetup, DetectionSystem detectionSystem, Health health) : base(unitSetup, detectionSystem, health)
        {
          
        }

        public void Enable() =>
            _abilityHandler.Enable();

        public void Disable() =>
            _abilityHandler.Disable();

        public void SetAbility(AbilityHandler abilityHandler) =>
            _abilityHandler = abilityHandler as MushroomAbilityHandler;
    }
}