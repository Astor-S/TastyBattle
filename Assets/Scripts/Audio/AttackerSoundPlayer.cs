using UnityEngine;

namespace Audio
{
    public class AttackerSoundPlayer : DamagableSoundPlayer
    {
        [SerializeField] private AttackerAnimationEventHandler _attackerAnimation;

        public AttackerSoundPack AttackerSoundPack => _soundPack as AttackerSoundPack;

        public void SetAttackingSound() =>
            PlaySound(AttackerSoundPack.AttackingSound, false);
    }
}