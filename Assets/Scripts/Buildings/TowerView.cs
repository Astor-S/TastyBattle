using UnityEngine;

public class TowerView : BuildingView
{
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    public void SetAttackingAnimation()
    {
        Animator.SetBool(IsAttacking, true);

        SoundPlayer.SetAttackingSound();
    }

    public void StopAttackingAnimation()
    {
        Animator.SetBool(IsAttacking, false);

        SoundPlayer.StopAttackingSound();
    }
}
