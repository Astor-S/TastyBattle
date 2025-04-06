using AttackSystem;
using AttackSystem.AttackHandlers;
using System;
using System.Collections;
using UnityEngine;

public class WatermellonSiegeAttackHandler : WatermelonAttackHandler
{
    public event Action<float> SpeedChanging;
    public event Action TakingRunUp;
    public event Action RunUpTaken;

    public float DistanceToTarget { get; private set; }
    protected new WatermellonSiegeSetup Stats => base.Stats as WatermellonSiegeSetup;

    private void Update()
    {
        if (IsAttacking)
            DistanceToTarget = Vector3.Distance(AttackedTarget.transform.position, transform.position);
    }

    protected override IEnumerator Combat()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        WaitForSeconds runUpWaiting = new WaitForSeconds(0.3f);
        WaitUntil approachingWaiting = new WaitUntil(() => DistanceToTarget < Stats.HitDistance);
        WaitUntil runUpLongWaiting = new WaitUntil(() => DistanceToTarget > Stats.AttackDistance);

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

            yield return waitForFixedUpdate;
        }
    }
}
