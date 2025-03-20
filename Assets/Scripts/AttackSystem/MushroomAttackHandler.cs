using Units;
public class MushroomAttackHandler : AttackHandler
{
    private MushroomAbilityHandler _abilityHandler;

    public MushroomAttackHandler(DetectionSystem detectionSystem, Health health) : base(detectionSystem, health) { }

    protected override float Damage => _abilityHandler.CurrentAttackDamage;

    public void InitAbility(MushroomAbilityHandler abilityHandler)
    {
        _abilityHandler = abilityHandler;
    }
}