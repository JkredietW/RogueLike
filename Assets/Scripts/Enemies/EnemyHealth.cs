namespace JK.Roguelike
{
    public class EnemyHealth : Health
    {
        protected override void Die()
        {
            base.Die();
            Spawner.Instance.EnemyDied();
            Destroy(gameObject);
        }
    }
}