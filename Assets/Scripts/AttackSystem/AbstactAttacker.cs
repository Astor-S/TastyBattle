using System.Collections;
using UnityEngine;

public abstract class AbstactAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private SphereCollider _distance;
    [SerializeField] private float _damage;
    [SerializeField] private float _frequency;

    private UnitCharacter _target;
    private Coroutine _attackCoroutine;
    private float _attackTimer;

    protected UnitCharacter Target { get => _target; set => _target = value; }
    protected float Damage { get => _damage; set => _damage = value; }
    protected float Frequency { get => _frequency; set => _frequency = value; }
    protected float AttackTimer { get => _attackTimer; set => _attackTimer = value; }

    private void OnTriggerEnter(Collider target)
    {
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

    protected virtual void AttackTarget()
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

    protected virtual IEnumerator Attacking()
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

    protected virtual void StopAttacking()
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