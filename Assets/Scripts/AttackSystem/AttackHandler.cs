using StructureElements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackHandler : IUpdatable
{
    private readonly List<DamagableTarget> _attackedUnits = new();

    private DetectionSystem _detectionSystem;
    private Health _health;

    private AttackerSetup _stats;
    private DamagableTarget _attackedTarget;
    private float _attackTimer;

    public event Action AttackStarted;
    public event Action AttackStopped;

    public DamagableTarget AttackedTarget => _attackedTarget;
    protected virtual float Damage => _stats.AttackDamage;
    protected float AttackSpeed => _stats.AttackSpeed;

    public AttackHandler(DetectionSystem detectionSystem, Health health)
    {
        _detectionSystem = detectionSystem;
        _health = health;
    }

    public void Update(float _)
    {
        LocateTarget();
        RefreshList();
    }

    public virtual void Init(AttackerSetup attackerSetup)
    {
        _health.Init(attackerSetup);
        _stats = attackerSetup;
    }

    protected virtual void Hit()
    {
        if (_attackedTarget != null)
            _attackedTarget.TakeDamage(CalculateDamage());
    }

    public virtual IEnumerator Combat()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        bool isRunning = true;

        while (isRunning)
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

    protected virtual float CalculateDamage() =>
        Damage;

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