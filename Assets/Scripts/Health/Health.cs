using UnityEngine;

namespace JK.Roguelike
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void DoDamage(float damageValue)
        {
            if (currentHealth == 0)
                return;

            currentHealth = Mathf.Clamp(currentHealth - damageValue, 0, maxHealth);

            if (currentHealth == 0)
                Die();
        }

        public void OneHit() => DoDamage(maxHealth);

        protected virtual void Die()
        {
            
        }
    }
}