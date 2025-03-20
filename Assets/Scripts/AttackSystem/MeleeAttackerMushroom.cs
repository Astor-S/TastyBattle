public class MeleeAttackerMushroom : MushroomAttackHandler
{
    public MeleeAttackerMushroom(
        DetectionSystem detectionSystem,
        Health health) :
        base(detectionSystem,
            health) { }
}