using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _explosionForce = 0f;
        [SerializeField] private int _maxColliders = 10;

        private Collider[] _colliders;

        private void OnEnable()
        {
            _colliders = new Collider[_maxColliders];
        }

        public void Explode(float explosionRadius, float explosionDamage)
        {
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, _colliders);

            List<DamagableTarget> targets = new();

            for (int i = 0; i < numColliders; i++)
            {
                Collider collider = _colliders[i];
                
                if (collider.TryGetComponent(out DamagableTarget target) && target.transform != transform)
                    targets.Add(target);
                if (collider.TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(_explosionForce, transform.position, explosionRadius, 1f, ForceMode.Impulse);
            }

            foreach (DamagableTarget target in targets)
                target.TakeDamage(explosionDamage);
            
            Debug.Log($"[AvocadoUnit] {gameObject.name} exploded, dealing {explosionDamage} damage in radius {explosionRadius}");
        }
    }
}