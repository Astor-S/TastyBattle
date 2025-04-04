using AttackSystem.AttackHandlers;
using System;
using System.Collections;
using UnityEngine;

public class WatermellonSiegeAttackHandler : WatermelonAttackHandler
{
    private float _distanceToTarget;

    public event Action<float> SpeedChanging;

    protected new WatermellonSiegeSetup Stats => base.Stats as WatermellonSiegeSetup;

    private void Update()
    {
        if (IsAttacking)
            _distanceToTarget = Vector3.Distance(AttackedTarget.transform.position, transform.position);
    }

    protected override IEnumerator Combat()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        WaitForSeconds runUpWaiting = new WaitForSeconds(0.3f);
        WaitUntil approachingWaiting = new WaitUntil(() => _distanceToTarget < Stats.HitDistance);

        while (enabled)
        {
            if (AttackedTarget != null && IsAttacking)
            {
                StartAttack();

                SpeedChanging?.Invoke(0f);

                yield return runUpWaiting;

                SpeedChanging?.Invoke(15f);

                yield return approachingWaiting;

                if (AttackTimer >= AttackSpeed)
                {
                    Hit();
                    SpeedChanging?.Invoke(-1f);
                    ResetTimer();
                }
            }
            else
            {
                StopAttack();
            }

            yield return waitForFixedUpdate;
        }
    }
}
