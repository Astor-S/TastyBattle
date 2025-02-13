using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private SphereCollider _distance;
    [SerializeField] private float _damage;
    [SerializeField] private float _frequency;

    private EnemyUnit _target;
    private Coroutine _attackCoroutine;
    private float _attackTimer;

    private void OnTriggerEnter(Collider target)
    {
        int targetLayerMask = 1 << target.gameObject.layer;

        if ((_targetMask & targetLayerMask) != 0)
            if (target.TryGetComponent(out EnemyUnit enemy) && _target == null)
                _target = enemy;

        if (_attackCoroutine == null && _target != null) 
        {
            _attackCoroutine = StartCoroutine(Attacking());
            Debug.Log("Attacking Coroutine Started");
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.TryGetComponent(out EnemyUnit enemy) && enemy == _target)
            StopAttacking();
    }

    private IEnumerator Attacking()
    {
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