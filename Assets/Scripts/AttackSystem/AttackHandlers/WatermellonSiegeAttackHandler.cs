using AttackSystem.AttackHandlers;
using System;
using System.Collections;
using UnityEngine;

public class WatermellonSiegeAttackHandler : WatermelonAttackHandler
{
    public event Action<float> SpeedChanging;
    public event Action TakingRunUp;
    public event Action RunUpTaken;

    private float _distanceToTargetSquared;
    protected new WatermellonSiegeSetup Stats => base.Stats as WatermellonSiegeSetup;

    private void Update()
    {
        if (IsAttacking)
            _distanceToTargetSquared = Vector3.SqrMagnitude(AttackedTarget.transform.position - transform.position);
    }

    protected override IEnumerator Combat()
    {
        WaitForSeconds runUpWaiting = new WaitForSeconds(0.3f);
        WaitUntil approachingWaiting = new WaitUntil(() => _distanceToTargetSquared < Stats.HitDistance* Stats.HitDistance);
        WaitUntil runUpLongWaiting = new WaitUntil(() => _distanceToTargetSquared > Stats.AttackDistance * Stats.AttackDistance);

        while (enabled)
        {
            if (AttackedTarget != null && IsAttacking)
            {
                StartAttack();

                SpeedChanging?.Invoke(0f);

                yield return runUpWaiting;

                SpeedChanging?.Invoke(15f);

                yield return approachingWaiting;

                Hit();
                SpeedChanging?.Invoke(-1f);
                TakingRunUp?.Invoke();

                yield return runUpLongWaiting;

                RunUpTaken?.Invoke();
            }
            else
            {
                StopAttack();
            }

            yield return WaitForFixedUpdate;
        }
    }
}
