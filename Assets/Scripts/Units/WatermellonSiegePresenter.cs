namespace Units
{
    public class WatermellonSiegePresenter : UnitPresenter
    {
        public new WatermellonSiege Model => base.Model as WatermellonSiege;
        public new WatermellonSiegeView View => base.View as WatermellonSiegeView;
        protected new WatermellonSiegeAttackHandler AttackHandler => base.AttackHandler as WatermellonSiegeAttackHandler;

        public override void Enable()
        {
            base.Enable();

            NavMeshAgent.stoppingDistance = Model.Stats.HitDistance;

            AttackHandler.Hitting += View.SetHittingAnimation;
            AttackHandler.SpeedChanging += ChangeSpeed;
        }

        public override void Disable()
        {
            base.Disable();

            AttackHandler.Hitting -= View.SetHittingAnimation;
            AttackHandler.SpeedChanging -= ChangeSpeed;
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