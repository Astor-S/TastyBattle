using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private SphereCollider _distance;
    [SerializeField] private float _damage;
    [SerializeField] private float _frequency;

    private UnitCharacter _target;
    private Coroutine _attackCoroutine;
    private float _attackTimer;
    
    public bool IsAttacking { get; private set; } = false;

    public Vector3 Target => _target.transform.position;

    public event Action AttackStarted;
    public event Action AttackStopped;

    private void Start()
    {
        if (LayerMask.LayerToName(gameObject.layer) == "Enemy")
            _targetMask = LayerMask.GetMask("Player");
        else
            _targetMask = LayerMask.GetMask("Enemy");
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.isTrigger)
            return;

        int targetLayerMask = 1 << target.gameObject.layer;

        if ((_targetMask & targetLayerMask) != 0)
            if (target.TryGetComponent(out UnitCharacter unit) && _target == null)
                _target = unit;

        if (_attackCoroutine == null && _target != null) 
        {
            _attackCoroutine = StartCoroutine(Attacking());
            Debug.Log("Attacking Coroutine Started");
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.TryGetComponent(out UnitCharacter unit) && unit == _target)
            StopAttacking();
    }

    private IEnumerator Attacking()
    {
        IsAttacking = true;
        AttackStarted?.Invoke();

        while (enabled)
        {
            if (_target != null && _target.gameObject != null) 
            {
                _attackTimer += Time.deltaTime;

                if (_attackTimer >= _frequency)
                {
                    AttackTarget();
                    _attackTimer = 0f;
                }
            }
            else
            {
                StopAttacking();
                yield break;
            }

            yield return null;
        }
    }

    private void AttackTarget()
    {
        if (_target != null && _target.gameObject != null)
        {
            _target.TakeDamage(_damage);
            Debug.Log("Нанесено " + _damage + " урона " + _target.name);
        }
        else
        {
            StopAttacking();
        }
    }

    private void StopAttacking()
    {
        IsAttacking = false;
        AttackStopped?.Invoke();

        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
            Debug.Log("Attacking Coroutine Stopped");
        }

        _target = null;
        _attackTimer = 0f;
    }
}