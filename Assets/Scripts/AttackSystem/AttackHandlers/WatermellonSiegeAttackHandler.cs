using System;
using System.Collections;
using Units;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class WatermellonSiegeAttackHandler : WatermelonAttackHandler
    {
        private const float RunningUpSpeed = 15f;

        private float _distanceToTargetSquared;

        public event Action<float> SpeedChanging;
        public event Action TakingRunUp;
        public event Action RunUpTaken;
        public event Action Hitting;

        protected new WatermellonSiegeSetup Stats => base.Stats as WatermellonSiegeSetup;

        private void FixedUpdate()
        {
            _distanceToTargetSquared = Vector3.SqrMagnitude(AttackedTarget.transform.position - transform.position);
        }

        protected override IEnumerator Combat()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
            WaitForSeconds runUpWaiting = new WaitForSeconds(0.3f);

            WaitUntil approachingWaiting = new WaitUntil(
                () => _distanceToTargetSquared < Stats.HitDistance * Stats.HitDistance);

            WaitUntil runUpLongWaiting = new WaitUntil(
                () => _distanceToTargetSquared > Stats.AttackDistance * Stats.AttackDistance);

            while (enabled)
            {
                if (AttackedTarget != null && ReadyToAttack)
                {
                    StartAttack();

                    SpeedChanging?.Invoke(0f);

                    yield return runUpWaiting;

                    SpeedChanging?.Invoke(RunningUpSpeed);

                    yield return approachingWaiting;

                    Hitting?.Invoke();
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
}