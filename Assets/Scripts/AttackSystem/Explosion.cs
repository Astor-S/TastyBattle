using System;
using UnityEngine;

namespace AttackSystem
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionParticleEffect;
        [SerializeField] private LayerMask _damageableLayers; 
        [SerializeField] private int _maxColliders = 10;

        private Collider[] _colliders;

        private void OnEnable()
        {
            _colliders = new Collider[_maxColliders];
        }

        public void Explode(float explosionRadius, float explosionDamage)
        {
            PlayExplosionEffect();

            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, _colliders, _damageableLayers);

            for (int i = 0; i < numColliders; i++)
                if (_colliders[i].TryGetComponent(out DamagableTarget target) && target.transform != transform)
                    target.TakeDamage(explosionDamage);          
        }

        private void PlayExplosionEffect()
        {
            if (_explosionParticleEffect == null)
            {
                Debug.LogWarning("Explosion Particle Effect Prefab не назначен!");
                return;
            }

            ParticleSystem explosionInstance = Instantiate(_explosionParticleEffect, transform.position, Quaternion.identity);
            explosionInstance.Play();

            float duration = explosionInstance.main.duration;

            Destroy(explosionInstance.gameObject, duration);
        }
    }
}