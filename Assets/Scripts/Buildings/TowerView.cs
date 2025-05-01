using UnityEngine;

public class TowerView : BuildingView
{
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    [SerializeField] private AttackerAnimationEventHandler _attackerAnimationEventHandler;

    private void OnEnable() => 
        _attackerAnimationEventHandler.AttackingStarted += SoundPlayer.SetAttackingSound;

    private void OnDisable() => 
        _attackerAnimationEventHandler.AttackingStarted -= SoundPlayer.SetAttackingSound;

    public void SetAttackingAnimation() => 
        Animator.SetBool(IsAttacking, true);

    public void StopAttackingAnimation() => 
        Animator.SetBool(IsAttacking, false);
}
