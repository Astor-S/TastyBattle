using UnityEngine;
using AttackSystem.AttackHandlers;

namespace AttackSystem.RangedAttackHandlers
{
    public class RangedAttackHandler : AttackHandler
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnPoint;
        [SerializeField] private float _projectileSpeed = 10f;

        private Pool<Projectile> _projectilePool;

        private void Awake()
        {
            _projectilePool = new Pool<Projectile>(() =>
            {
                Projectile projectile = Instantiate(
                    _projectilePrefab,
                    _projectileSpawnPoint.position,
                    _projectileSpawnPoint.rotation);

                projectile.gameObject.SetActive(false);

                return projectile;
            },
            (projectile) =>
            {
                projectile.transform.position = _projectileSpawnPoint.position;
                projectile.transform.rotation = _projectileSpawnPoint.rotation;
            });
        }

        protected override void Hit()
        {
            if (AttackedTarget != null)
            {
                Projectile projectile = _projectilePool.GetObject();
                projectile.gameObject.SetActive(true);

                projectile.transform.position = _projectileSpawnPoint.position;
                projectile.transform.rotation = _projectileSpawnPoint.rotation;

                projectile.Initialize(AttackedTarget, CalculateDamage(), _projectilePool);

                Vector3 attackedTargetElevatedPosition = AttackedTarget.transform.position + 0.5f * Vector3.up;

                projectile.Rigidbody.velocity = (attackedTargetElevatedPosition - _projectileSpawnPoint.position).normalized * _projectileSpeed;
            }
        }
    }
}