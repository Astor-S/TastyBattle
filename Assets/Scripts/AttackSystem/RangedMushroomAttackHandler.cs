using UnityEngine;

namespace AttackSystem
{
    public class RangedMushroomAttackHandler : MushroomAttackHanlder
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

                projectile.Initialize(AttackedTarget, Damage, _projectilePool);

                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

                if (projectileRigidbody != null)
                    projectileRigidbody.velocity = (AttackedTarget.transform.position - _projectileSpawnPoint.position).normalized * _projectileSpeed;
            }
        }
    }
}