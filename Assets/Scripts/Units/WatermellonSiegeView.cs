using UnityEngine;

namespace Units
{
    public class WatermellonSiegeView : UnitView
    {
        private readonly int _hit = Animator.StringToHash(nameof(Hit));
        private readonly int _runUp = Animator.StringToHash(nameof(RunUp));

        public int Hit => _hit;
        public int RunUp => _runUp;

        public void SetHittingAnimation() =>
            Animator.SetTrigger(Hit);

        public void SetRunningUpAnimation() =>
            Animator.SetTrigger(RunUp);
    }
}