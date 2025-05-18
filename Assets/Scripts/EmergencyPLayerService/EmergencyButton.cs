using UnityEngine;
using UnityEngine.UI;
using AttackSystem;
using GameService;

namespace EmergencyPlayerService
{
    public class EmergencyButton : MonoBehaviour
    {
        [SerializeField] private Button _emergencyButton;
        [SerializeField] private LandingUnits _landingUnits;
        [SerializeField] private InvulnerabilityPlayerBase _invulnerabilityPlayer;
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

            _rewardAdService.EmergencyReceived += ActivateBonus;
        }

        private void OnDisable()
        {
            if (_target != null)
                _target.HalfHP -= OnHalfHPReached;

            _rewardAdService.EmergencyReceived -= ActivateBonus;
        }

        public void OnButtonClick() =>
            _rewardAdService.ShowRewardAd(_rewardAdService.EmergencyId);

        private void ActivateBonus()
        {
            _landingUnits.CallLanding();
            _invulnerabilityPlayer.OnActivateInvulnerability();
            gameObject.SetActive(false);
        }

        private void OnHalfHPReached() =>
            _emergencyButton.interactable = true;
    }
}