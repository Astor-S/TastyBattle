using UnityEngine;

public class Projectile : MonoBehaviour
{
    private UnitCharacter _target;
    private Pool<Projectile> _pool;
    private float _damage;
    private bool _hasHit = false;

    public void Initialize(UnitCharacter target, float damage, Pool<Projectile> pool)
    {
        _target = target;
        _damage = damage;
        _hasHit = false; 
        _pool = pool; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasHit)
            return;

        UnitCharacter hitTarget = other.GetComponent<UnitCharacter>();

        if (hitTarget == _target)
        {
            _hasHit = true;
            _target.TakeDamage(_damage);
            Debug.Log("Снаряд попал в " + _target.name + ", нанесено " + _damage + " урона.");

            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false); 
        _pool.Release(this); 
    }
}