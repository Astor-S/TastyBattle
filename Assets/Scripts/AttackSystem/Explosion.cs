using UnityEngine;

namespace AttackSystem
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private int _maxColliders = 10;
        [SerializeField] private LayerMask _damageableLayers; 

        private Collider[] _colliders;

        private void OnEnable()
        {
            _colliders = new Collider[_maxColliders];
        }

        public void Explode(float explosionRadius, float explosionDamage)
        {
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, _colliders, _damageableLayers);

            for (int i = 0; i < numColliders; i++)
            {
                Collider collider = _colliders[i];

                if (collider.TryGetComponent(out DamagableTarget target) && target.transform != transform)
                    target.TakeDamage(explosionDamage);
            }

            Debug.Log($"[AvocadoUnit] {gameObject.name} exploded, dealing {explosionDamage} damage in radius {explosionRadius}");
        }
    }
}