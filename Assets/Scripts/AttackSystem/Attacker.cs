using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private SphereCollider _distance;
    [SerializeField] private float _damage;
    [SerializeField] private float _frequency;

    private EnemyUnit _target;
    private float _attackTimer;

    private void Update()
    {
        if (_target != null)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _frequency)
            {
                AttackTarget();
                _attackTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (((1 << target.gameObject.layer) & _targetMask) != 0)
            if (target.TryGetComponent(out EnemyUnit enemy) && _target == null)
                _target = enemy;
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.TryGetComponent(out EnemyUnit enemy) && enemy == _target)
        {
            _target = null;
            _attackTimer = 0f;
        }
    }

    private void AttackTarget()
    {
        if (_target != null)
        {
            _target.TakeDamage(_damage);
            Debug.Log("Нанесено " + _damage + " урона " + _target.name);
        }
    }
}