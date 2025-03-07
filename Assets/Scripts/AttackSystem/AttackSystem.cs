using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private Health _health;

    private AttackerSetup _stats;
    private List<DamagableTarget> _attackedUnits = new();
    private DamagableTarget _attackedTarget;
    private float _attackTimer;

    public event Action AttackStarted;
    public event Action AttackStopped;

    public DamagableTarget AttackedTarget => _attackedTarget;
    protected float Damage => _stats.AttackDamage;
    protected float AttackSpeed => _stats.AttackSpeed;

    private void Start() => 
        StartCoroutine(nameof(Combat));

    private void Update()
    {
        LocateTarget();
        RefreshList();
    }

    public void Init(AttackerSetup attackerSetup)
    {
        _health.Init(attackerSetup);
        _stats = attackerSetup;
    }

    protected virtual void Hit()
    {
        if (_attackedTarget != null)
            _attackedTarget.TakeDamage(Damage);
    }

    protected virtual IEnumerator Combat()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while (enabled)
        {
            if (_attackedUnits.Count > 0)
            {
                if (_attackedTarget != null)
                {
                    AttackStarted?.Invoke();

                    _attackTimer += Time.deltaTime;

                    if (_attackTimer >= AttackSpeed)
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

            yield return waitForFixedUpdate;
        }
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
}