using System;
using System.Collections.Generic;
using UnityEngine;
using AttackSystem;
using Units;

namespace DetectionSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public class DetectionController : MonoBehaviour
    {
        private const float Radius = 7f;

        private readonly List<DamagableTarget> _detectedUnits = new ();

        [SerializeField] private DamagableTarget _currentUnit;
        [SerializeField] private Transform _baseTransform;
        [SerializeField] private SphereCollider _collider;

        private string _enemyLayer;
        private DamagableTarget _enemyBase;
        private bool _isSiege = false;

        public DamagableTarget CurrentTarget { get; private set; } = null;

    #if UNITY_EDITOR
        private void OnValidate()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = Radius;
        }
    #else
        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = _radius;
        }
    #endif

        private void FixedUpdate()
        {
            if (CurrentTarget != null)
                _baseTransform.LookAt(CurrentTarget.transform);
        }

        private void OnEnable()
        {
            for (int i = 0; i < _detectedUnits.Count; i++)
                _detectedUnits[i].Dying -= OnDetectedUnitDied;

            _detectedUnits.Clear();

            CurrentTarget = _enemyBase;
        }

        public void Init(int layer, DamagableTarget enemyBase, BattleRole battleRole = BattleRole.Range)
        {
            if (layer == LayersData.EnemyLayerNumber)
                _enemyLayer = LayersData.Player;
            else
                _enemyLayer = LayersData.Enemy;

            _enemyBase = enemyBase;
            CurrentTarget = _enemyBase;
            _isSiege = battleRole == BattleRole.Siege;

            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other) =>
            HandleTriggerEntry(other);

        private void OnTriggerExit(Collider other) =>
            HandleTriggerExit(other);

        private void HandleTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out DamagableTarget unit) && _detectedUnits.Contains(unit))
            {
                unit.Dying -= OnDetectedUnitDied;

                _detectedUnits.Remove(unit);

                if (CurrentTarget == unit)
                {
                    if (_detectedUnits.Count == 0)
                        CurrentTarget = _enemyBase;
                    else
                        CurrentTarget = _detectedUnits[0];
                }
            }
        }

        private void HandleTriggerEntry(Collider other)
        {
            if (other.TryGetComponent(out DamagableTarget unit) &&
                _detectedUnits.Contains(unit) == false &&
                LayerMask.LayerToName(unit.gameObject.layer) == _enemyLayer &&
                (_isSiege == false || unit.IsBuilding))
            {
                unit.Dying += OnDetectedUnitDied;
                _detectedUnits.Add(unit);

                if (_detectedUnits.Count == 1)
                    CurrentTarget = unit;
            }
        }

        private void OnDetectedUnitDied(DamagableTarget diedUnit)
        {
            diedUnit.Dying -= OnDetectedUnitDied;

            _detectedUnits.RemoveAll(unit => unit == null || unit.IsAlive == false);

            if (CurrentTarget == diedUnit)
            {
                if (_detectedUnits.Count == 0)
                    CurrentTarget = _enemyBase;
                else
                    CurrentTarget = _detectedUnits[0];
            }
        }
    }
}