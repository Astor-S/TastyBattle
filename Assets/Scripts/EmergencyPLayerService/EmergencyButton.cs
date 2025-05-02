using UnityEngine;
using UnityEngine.UI;
using AttackSystem;

namespace EmergencyPlayerService
{
    public class EmergencyButton : MonoBehaviour
    {
        [SerializeField] private Button _emergencyButton;
        [SerializeField] private DamagableTarget _target;

        private void Start()
        {
            _emergencyButton.interactable = false;
        }

        private void OnEnable()
        {
            if (_target != null)
                _target.HalfHP += OnHalfHPReached;   
        }

        private void OnDisable()
        {
            if (_target != null)
                _target.HalfHP -= OnHalfHPReached;
        }

        public void OnButtonClick() =>
            gameObject.SetActive(false);

        private void OnHalfHPReached() =>
            _emergencyButton.interactable = true;
    }
}