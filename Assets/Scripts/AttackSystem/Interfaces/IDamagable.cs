namespace AttackSystem.Interfaces
{
    public interface IDamagable
    {
        public Health Health { get; }

        public void TakeDamage(float damage);
    }
}