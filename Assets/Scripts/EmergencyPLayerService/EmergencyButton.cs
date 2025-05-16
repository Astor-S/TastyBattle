using UnityEngine;
using UnityEngine.UI;
using AttackSystem;
using GameService;

namespace EmergencyPlayerService
{
    public class EmergencyButton : MonoBehaviour
    {
        [SerializeField] private Button _emergencyButton;
        [SerializeField] private DamagableTarget _target;
        [SerializeField] private RewardAdService _rewardAdService;

        private void Start()
        {
            _emergencyButton.interactable = false;
        }

        private void OnEnable()
        {
            if (_target != null)
                _target.HalfHP += OnHalfHPReached;

            _rewardAdService.EmergencyReceived += OnButtonClick;
        }

        private void OnDisable()
        {
            if (_target != null)
                _target.HalfHP -= OnHalfHPReached;

            _rewardAdService.EmergencyReceived -= OnButtonClick;
        }

        public void OnButtonClick()
        {
            _rewardAdService.ShowRewardAd(_rewardAdService.EmergencyId);
            gameObject.SetActive(false);
        }

        private void OnHalfHPReached() =>
            _emergencyButton.interactable = true;
    }
}