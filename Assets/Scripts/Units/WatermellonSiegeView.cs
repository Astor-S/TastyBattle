using UnityEngine;

public class WatermellonSiegeView : UnitView
{
    public readonly int Hit = Animator.StringToHash(nameof(Hit));
    public readonly int DistanceToTarget = Animator.StringToHash(nameof(DistanceToTarget));

    public void SetHittingAnimation()
    {
        Animator.SetTrigger(Hit);
    }

    public void SetDistanceToTargetInAnimation(float distance)
    {
        Animator.SetFloat(DistanceToTarget, distance);
    }
}
