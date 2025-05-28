using System.Collections;
using UnityEngine;
using Units;
using YG;
using ResourceDistribution;

namespace EmergencyPlayerService
{
    public class LandingUnits : MonoBehaviour
    {
        [SerializeField] private UnitFactory _unitFactory;
        [SerializeField] private UnitOrderHandler _melee;
        [SerializeField] private UnitOrderHandler _tank;
        [SerializeField] private float _summonMeleeUnitDelay = 3f;
        [SerializeField] private int _numberOfTanksToSummon = 2;
        [SerializeField] private int _numberOfMeleeToSummon = 3;

        public void CallLanding()
        {
            YG2.MetricaSend("emergency_button_clicked");
            StartCoroutine(LandingSequence());
        }

        private IEnumerator LandingSequence()
        {
            SummonTankUnitPack();

            yield return new WaitForSeconds(_summonMeleeUnitDelay);

            SummonMeleeUnitPack();

            yield return new WaitForSeconds(_summonMeleeUnitDelay);

            SummonMeleeUnitPack();
        }

        private void SummonMeleeUnitPack()
        {
            for (int i = 0; i < _numberOfMeleeToSummon; i++)
                SummonMeleeUnit();
        }

        private void SummonTankUnitPack()
        {
            for (int i = 0; i < _numberOfTanksToSummon; i++)
                SummonTankUnit();
        }

        private void SummonMeleeUnit()
        {
            if (_melee != null && _melee.Setup != null && _unitFactory != null)
                _unitFactory.CreateUnit(_melee.Setup);
        }

        private void SummonTankUnit()
        {
            if (_tank != null && _tank.Setup != null && _unitFactory != null)
                _unitFactory.CreateUnit(_tank.Setup);
        }
    }
}