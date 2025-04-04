using UnityEngine;

public class WatermellonSiegeView : UnitView
{
    public readonly int Hit = Animator.StringToHash(nameof(Hit));

    public void SetHittingAnimation()
    {
        Animator.SetTrigger(Hit);
    }
}
