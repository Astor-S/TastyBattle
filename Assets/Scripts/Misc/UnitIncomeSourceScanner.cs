using System;
using AttackSystem;
using Buildings;
using ResourceDistribution;
using UnityEngine;
using AttackSystem;
using Buildings;

namespace Misc
{
    [RequireComponent(typeof(SphereCollider))]
    public class UnitIncomeSourceScanner : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        [SerializeField] private MainBuildingPresenter _mainBuilding;
        [SerializeField] private float _radius = 100f;

        public event Action<IIncomeSource> UnitDetected;

        private void Awake()
        {
            _collider.isTrigger = true;
            _collider.radius = _radius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamagableTarget unit) && unit.gameObject.layer != _mainBuilding.gameObject.layer)
                UnitDetected?.Invoke(unit);
        }
    }
}