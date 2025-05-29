using Audio;
using AttackSystem;
using UnityEngine;

namespace Buildings
{
    public class TowerView : BuildingView
    {
        private readonly int _isAttacking = Animator.StringToHash(nameof(IsAttacking));

        [SerializeField] private AttackerAnimationEventHandler _attackerAnimationEventHandler;

        public int IsAttacking => _isAttacking;

        public new AttackerSoundPlayer SoundPlayer => base.SoundPlayer as AttackerSoundPlayer;

        private void OnEnable() =>
            _attackerAnimationEventHandler.AttackingStarted += SoundPlayer.SetAttackingSound;

        private void OnDisable() =>
            _attackerAnimationEventHandler.AttackingStarted -= SoundPlayer.SetAttackingSound;

        public void SetAttackingAnimation() =>
            Animator.SetBool(IsAttacking, true);

        public void StopAttackingAnimation() =>
            Animator.SetBool(IsAttacking, false);
    }
}