using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] protected  UnitStats _unitStats;

    private List<DamagableTarget> _attackedUnits = new();
    private WaitForFixedUpdate _waitForFixedUpdate;
    private DamagableTarget _attackedTarget;
    private float _attackTimer;

    public event Action AttackStarted;
    public event Action AttackStopped;

    public DamagableTarget AttackedTarget => _attackedTarget;

    private void Awake() =>
        _waitForFixedUpdate = new WaitForFixedUpdate();

    private void Start() =>
        StartCoroutine(nameof(Combat));

    private void Update()
    {
        LocateTarget();
        RefreshList();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DamagableTarget unit))
            if (_detectionSystem.DetectedUnits.Contains(unit) && _attackedUnits.Contains(unit) == false)
                _attackedUnits.Add(unit);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DamagableTarget unit))
            if (_attackedUnits.Contains(unit))
                _attackedUnits.Remove(unit);
    }

    private void LocateTarget()
    {
        if (_attackedUnits.Count > 0)
            if (_attackedUnits[0] != null && _attackedUnits[0].isActiveAndEnabled)
                _attackedTarget = _attackedUnits[0];
    }

    private void RefreshList()
    {
        if (_attackedUnits.Count > 0)
            if (_attackedUnits[0] == null || _attackedUnits[0].isActiveAndEnabled == false)
                _attackedUnits.RemoveAt(0);
    }

    protected virtual void Hit()
    {
        if (_attackedTarget != null)
        {
            _attackedTarget.TakeDamage(_unitStats.AttackDamage);
            Debug.Log("Нанесено " + _unitStats.AttackDamage + " урона " + _attackedTarget.name);
        }
    }

    protected virtual IEnumerator Combat()
    {
        while (enabled)
        {
            if (_attackedUnits.Count > 0)
            {
                if (_attackedTarget != null)
                {
                    AttackStarted?.Invoke();

                    _attackTimer += Time.deltaTime;

                    if (_attackTimer >= _unitStats.AttackFrequency)
                    {
                        Hit();

                        _attackTimer = 0f;
                    }
                }
            }
            else
            {
                AttackStopped?.Invoke();
            }

            yield return _waitForFixedUpdate;
        }
    }
}