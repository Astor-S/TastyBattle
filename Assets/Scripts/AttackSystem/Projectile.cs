using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IDestroyable<Projectile>
{
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private Rigidbody _rigidbody;

    private DamagableTarget _target;
    private Pool<Projectile> _pool;
    private WaitForSeconds _waitLifeTime;
    private float _damage;
    private bool _hasHit = false;

    public Rigidbody Rigidbody => _rigidbody;

    public event Action<Projectile> Destroyed;

    private void OnEnable()
    {
        _waitLifeTime = new WaitForSeconds(_lifeTime);
        StartCoroutine(DelayedDestroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasHit)
            return;

        if (other.TryGetComponent(out DamagableTarget damagableTarget))
        {
            if (damagableTarget == _target)
            {
                _hasHit = true;
                _target.TakeDamage(_damage);

                ReturnToPool();
            }
        }

    }

    public void Initialize(DamagableTarget target, float damage, Pool<Projectile> pool)
    {
        _target = target;
        _damage = damage;
        _hasHit = false;
        _pool = pool;
    }

    private IEnumerator DelayedDestroy()
    {
        yield return _waitLifeTime;
        Destroy();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        _pool.Release(this);
    }

    private void Destroy()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}