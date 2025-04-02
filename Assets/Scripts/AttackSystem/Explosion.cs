using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AttackSystem
{
    public class Explosion : MonoBehaviour
    {
        public void Explode(float explosionRadius, float explosionDamage)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            
            List<DamagableTarget> targets = colliders
                .Select(collider => collider.GetComponent<DamagableTarget>())
                .Where(target => target != null && target != this)
                .ToList();

            foreach (DamagableTarget target in targets)
                target.TakeDamage(explosionDamage);
            
            Debug.Log($"[AvocadoUnit] {gameObject.name} exploded, dealing {explosionDamage} damage in radius {explosionRadius}");
        }
    }
}