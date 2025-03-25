using UnityEngine;
using System;
using System.Collections;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;

    private AttackerSetup _stats;
    private DamagableTarget _attackedTarget;
    private float _attackTimer;
    private bool _isAttacking = false;

    public event Action AttackStarted;
    public event Action AttackStopped;

    public DamagableTarget AttackedTarget => _attackedTarget;
    public bool IsAttacking => _isAttacking;
    protected virtual float Damage => _stats.AttackDamage;
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

    private void FixedUpdate()
    {
        if (_attackedTarget != null && Vector3.SqrMagnitude(_attackedTarget.transform.position - transform.position) <= _stats.AttackDistance * _stats.AttackDistance)
            _isAttacking = true;
        else
            _isAttacking = false;
    }

    public void Init(AttackerSetup attackerSetup)
    {
        _stats = attackerSetup;

        gameObject.SetActive(true);
    }

    protected virtual void Hit()
    {
        if (_attackedTarget != null)
            _attackedTarget.TakeDamage(CalculateDamage());
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

    protected virtual float CalculateDamage() =>
       Damage;

    private void ChangeTarget(DamagableTarget enemy) =>
        _attackedTarget = enemy;
}