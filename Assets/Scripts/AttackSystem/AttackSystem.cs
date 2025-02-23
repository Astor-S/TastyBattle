using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _frequency;
    [SerializeField] private DetectionSystem _detectionSystem;

    public List<Unit> _attackedUnits = new();
    private WaitForFixedUpdate _waitForFixedUpdate;
    private Unit _attackedTarget;
    private float _attackTimer;

    public event Action AttackStarted;
    public event Action AttackStopped;

    public Unit AttackedTarget => _attackedTarget;
    protected float Damage => _damage;
    protected float Frequency => _frequency;

    private void Awake() =>
        _waitForFixedUpdate = new WaitForFixedUpdate();

    private void Start() =>
        StartCoroutine(nameof(Combat));

    private void Update()
    {
       //RefreshList();
        LocateTarget();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Unit unit))
            if (_detectionSystem.DetectedUnits.Contains(unit) && _attackedUnits.Contains(unit) == false)
                _attackedUnits.Add(unit);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Unit unit))
            if (_attackedUnits.Contains(unit))
                _attackedUnits.Remove(unit);
    }

    private void RefreshList()
    {
        foreach (Unit unit in _attackedUnits)
            if (unit == null)
                _attackedUnits.Remove(unit);
    }

    private void LocateTarget()
    {
        if (_attackedUnits.Count > 0 && _attackedUnits[0] != null)
            _attackedTarget = _attackedUnits[0];
    }

    protected virtual void Hit()
    {
        if (_attackedTarget != null)
        {
            _attackedTarget.TakeDamage(_damage);
            Debug.Log("Нанесено " + _damage + " урона ");
        }
    }

    protected virtual IEnumerator Combat()
    {
        while (enabled)
        {
            if (_attackedTarget != null)
            {
                AttackStarted?.Invoke();

                _attackTimer += Time.deltaTime;

                if (_attackTimer >= _frequency)
                {
                    Hit();

                    _attackTimer = 0f;
                }
            }

            AttackStopped?.Invoke();

            yield return _waitForFixedUpdate;
        }
    }
}