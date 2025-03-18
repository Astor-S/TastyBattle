using StructureElements;
using FactionalAbilities;

namespace Units
{
    public class MushroomUnit : Unit, IActivatable
    {
        private readonly MushroomAbilityHandler _abilityHandler;

        public MushroomUnit(UnitSetup setup, MushroomAbility mushroomAbility) : base(setup) 
        {
            _abilityHandler = new MushroomAbilityHandler(setup, mushroomAbility);
        }

        public void Enable() =>
            _abilityHandler.Enable();

        public void Disable() =>
            _abilityHandler.Disable();
    }
}