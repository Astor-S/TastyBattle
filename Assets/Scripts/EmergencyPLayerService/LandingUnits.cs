using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EmergencyPlayerService
{
    public class LandingUnits : MonoBehaviour
    {
        [SerializeField] private Button _emergencyButton;
        [SerializeField] private UnitOrderHandler _melee;
        [SerializeField] private UnitOrderHandler _tank;
        [SerializeField] private float _summonMeleeUnitDelay = 3f;

        private void OnEnable()
        {
            if (_emergencyButton != null)
                _emergencyButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            if (_emergencyButton != null)
                _emergencyButton.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick() =>
            CallLanding();

        private void CallLanding() =>
            StartCoroutine(LandingSequence());

        private IEnumerator LandingSequence()
        {
            SummonTankUnit();
            SummonTankUnit();

            yield return new WaitForSeconds(_summonMeleeUnitDelay); 

            SummonMeleeUnit();
            SummonMeleeUnit();
            SummonMeleeUnit();

            yield return new WaitForSeconds(_summonMeleeUnitDelay); 

            SummonMeleeUnit();
            SummonMeleeUnit();
            SummonMeleeUnit();
        }

        private void SummonMeleeUnit() =>
           _melee.Order();

        private void SummonTankUnit() =>
            _tank.Order();
    }
}