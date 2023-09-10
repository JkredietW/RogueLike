using UnityEngine;

namespace JK.Roguelike
{
    public class Projectile : MonoBehaviour
    {
        private float damage;
        private HitTypes hitTypes;

        public void Initialize(float damage, HitTypes hitTypes)
        {
            this.damage = damage;
            this.hitTypes = hitTypes;

            Destroy(gameObject, 10);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.TryGetComponent(out Health healthComponent);
            switch (hitTypes)
            {
                case HitTypes.Enemy:
                    if (collision.CompareTag("Enemy"))
                        Hit(healthComponent);
                    break;
                case HitTypes.Player:
                    if (collision.CompareTag("Player"))
                        Hit(healthComponent);
                    break;
                case HitTypes.Both:
                    if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
                        Hit(healthComponent);
                    break;
            }
        }

        private void Hit(Health hit)
        {
            hit.DoDamage(damage);
            Destroy(gameObject);
        }
    }

    public enum HitTypes
    {
        Enemy,
        Player,
        Both,
    }
}