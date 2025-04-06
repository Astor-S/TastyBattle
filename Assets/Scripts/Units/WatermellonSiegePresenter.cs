using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class WatermellonSiegePresenter : UnitPresenter
    {
        private bool _isRunningUp = false;

        public new WatermellonSiege Model => base.Model as WatermellonSiege;
        public new WatermellonSiegeView View => base.View as WatermellonSiegeView;
        protected new WatermellonSiegeAttackHandler AttackHandler => base.AttackHandler as WatermellonSiegeAttackHandler;

        protected override void FixedUpdate()
        {
            if (DetectionSystem.CurrentTarget != null && NavMeshAgent.enabled == true)
            {
                if (_isRunningUp)
                {
                    Vector3 runUpDirection = transform.position - AttackHandler.AttackedTarget.transform.position;
                    NavMeshAgent.SetDestination(new Vector3(runUpDirection.x, transform.position.y, runUpDirection.z));
                    View.SetDistanceToTargetInAnimation(AttackHandler.DistanceToTarget);
                }
                else
                {
                    NavMeshAgent.SetDestination(DetectionSystem.CurrentTarget.transform.position);
                }
            }
        }

        public override void Enable()
        {
            base.Enable();

            NavMeshAgent.stoppingDistance = Model.Stats.HitDistance;

            AttackHandler.Hitting += View.SetHittingAnimation;
            AttackHandler.SpeedChanging += ChangeSpeed;
            AttackHandler.TakingRunUp += RunUp;
            AttackHandler.RunUpTaken += OnRunUpTaken;
        }

        public override void Disable()
        {
            base.Disable();

            AttackHandler.Hitting -= View.SetHittingAnimation;
            AttackHandler.SpeedChanging -= ChangeSpeed;
            AttackHandler.TakingRunUp -= RunUp;
            AttackHandler.RunUpTaken += OnRunUpTaken;
        }

        private void RunUp()
        {
            _isRunningUp = true;
        }

        private void OnRunUpTaken()
        {
            _isRunningUp = false;
        }

        private void ChangeSpeed(float speed)
        {
            if (speed < 0f)
                NavMeshAgent.speed = Model.Stats.MovementSpeed;
            else
                NavMeshAgent.speed = speed;
        }
    }
}