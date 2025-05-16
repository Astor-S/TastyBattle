using UnityEngine;
using UI.Screens;

namespace GameService
{
    public class AwardService : MonoBehaviour
    {
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private AwardScreen _awardScreen;

        private void OnEnable()
        {
            _completeScreen.ScreenActivated += HandleScreenActivated;
        }

        private void OnDisable()
        {
            _completeScreen.ScreenActivated -= HandleScreenActivated;
        }

        private void HandleScreenActivated() =>
            _awardScreen.GiveReward();
    }
}