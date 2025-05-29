using Audio;
using UnityEngine;

public class TowerView : BuildingView
{
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    [SerializeField] private AttackerAnimationEventHandler _attackerAnimationEventHandler;

    public new AttackerSoundPlayer SoundPlayer => _soundPlayer as AttackerSoundPlayer;

    private void OnEnable() => 
        _attackerAnimationEventHandler.AttackingStarted += this.SoundPlayer.SetAttackingSound;

    private void OnDisable() => 
        _attackerAnimationEventHandler.AttackingStarted -= this.SoundPlayer.SetAttackingSound;

    public void SetAttackingAnimation() => 
        Animator.SetBool(IsAttacking, true);

    public void StopAttackingAnimation() => 
        Animator.SetBool(IsAttacking, false);
}
