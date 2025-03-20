using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private DamagableTarget _damagableTarget;

    private AttackerSetup _stats;
    private List<DamagableTarget> _attackedUnits = new();
    private DamagableTarget _attackedTarget;
    private float _attackTimer;
    private bool _isAttacking = false;

    public event Action AttackStarted;
    public event Action AttackStopped;

    public DamagableTarget AttackedTarget => _attackedTarget;
    protected float Damage => _stats.AttackDamage;
    protected float AttackSpeed => _stats.AttackSpeed;

    private void Start() => 
        StartCoroutine(nameof(Combat));

    private void OnEnable()
    {
        _detectionSystem.TargetChanged += ChangeTarget;
    }

    private void OnDisable()
    {
        _detectionSystem.TargetChanged -= ChangeTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DamagableTarget damagableTarget) && damagableTarget == _attackedTarget)
            _isAttacking = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DamagableTarget damagableTarget) && damagableTarget == _attackedTarget)
            _isAttacking = false;
    }

    private void ChangeTarget(DamagableTarget enemy)
    {
        _attackedTarget = enemy;
    }

    public void Init(AttackerSetup attackerSetup)
    {
        _stats = attackerSetup;

        gameObject.SetActive(true);
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
            if (_attackedTarget != null && _isAttacking)
            {
                AttackStarted?.Invoke();

                _attackTimer += Time.deltaTime;

                if (_attackTimer >= AttackSpeed)
                {
                    Hit();

                    _attackTimer = 0f;
                }
            }
            else
            {
                AttackStopped?.Invoke();
            }

            yield return waitForFixedUpdate;
        }
    }
}