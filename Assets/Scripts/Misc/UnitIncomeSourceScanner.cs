using AttackSystem;
using Buildings;
using System;
using UnityEngine;

namespace Misc
{
    [RequireComponent(typeof(SphereCollider))]
    public class UnitIncomeSourceScanner : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        [SerializeField] private MainBuildingPresenter _mainBuilding;

        public event Action<IIncomeSource> UnitDetected;

        private void Awake()
        {
            _collider.isTrigger = true;
            _collider.radius = 100f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamagableTarget unit) && unit.gameObject.layer != _mainBuilding.gameObject.layer)
                UnitDetected?.Invoke(unit);
        }
    }
}
