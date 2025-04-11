using UnityEngine;

public class WatermellonSiegeView : UnitView
{
    public readonly int Hit = Animator.StringToHash(nameof(Hit));
    public readonly int RunUp = Animator.StringToHash(nameof(RunUp));

    public void SetHittingAnimation()
    {
        Animator.SetTrigger(Hit);
    }

    public void SetRunningUpAnimation()
    {
        Animator.SetTrigger(RunUp);
    }
}
