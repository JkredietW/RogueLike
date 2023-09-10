using UnityEngine;

namespace JK.Roguelike
{
    public class PlayerAttacks : MonoBehaviour
    {
        [SerializeField] private float projectileVelocity;
        [SerializeField] private Rigidbody2D projectilePrefab;
        [SerializeField] private int projectileCount = 1;
        [SerializeField] private int projectileMaxSpread = 20;
        [SerializeField] private int projectileSpread = 5;
        [SerializeField] private float projectileDamage = 1;
        [SerializeField] private HitTypes hitType;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                SpawnProjectiles();
        }

        /// <summary>
        /// Spawns a projectile based on player rotation.
        /// </summary>
        private void SpawnProjectiles()
        {
            Vector2 lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            float actualRotation = (float)(Mathf.Atan2(lookDirection.x, lookDirection.y) / Mathf.PI) * 180 * -1;
            float aimDirection = actualRotation + Random.Range(-projectileSpread, projectileSpread);

            for (int i = 0; i < projectileCount; i++)
            {
                float shootAngle = aimDirection - (projectileMaxSpread / 2) + (projectileMaxSpread / projectileCount) * i + (projectileMaxSpread / 2 / projectileCount);
                Quaternion spreadRotation = Quaternion.Euler(new Vector3(0, 0, shootAngle));

                Rigidbody2D spawnedProjectile = Instantiate(projectilePrefab, new Vector2(transform.position.x, transform.position.y), spreadRotation);

                spawnedProjectile.velocity = spawnedProjectile.transform.up * projectileVelocity;
                spawnedProjectile.GetComponent<Projectile>().Initialize(projectileDamage, hitType);
            }
        }
    }
}