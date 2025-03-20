using Units;
public class MushroomAttackHandler : AttackHandler
{
    private MushroomAbilityHandler _mushroomAbilityHandler;

    public MushroomAttackHandler(AbilityHandler abilityHandler, DetectionSystem detectionSystem, Health health) : base(detectionSystem, health) =>
        _mushroomAbilityHandler = abilityHandler as MushroomAbilityHandler;

    protected override float Damage => _mushroomAbilityHandler.CurrentAttackDamage;
}