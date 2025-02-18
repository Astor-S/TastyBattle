using UnityEngine;

public class RangedAttacker : Attacker
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

    protected override void AttackTarget()
    {
        if (Target != null && Target.gameObject != null)
        {
            Projectile projectile = _projectilePool.GetObject(); 
            projectile.gameObject.SetActive(true); 

            projectile.transform.position = _projectileSpawnPoint.position;
            projectile.transform.rotation = _projectileSpawnPoint.rotation; 

            projectile.Initialize(Target, Damage, _projectilePool); 

            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
                projectileRigidbody.velocity = (Target.transform.position - _projectileSpawnPoint.position).normalized * _projectileSpeed;
            
            Debug.Log("Выпущен снаряд в " + Target.name);
        }
        else
        {
            StopAttacking();
        }
    }
}