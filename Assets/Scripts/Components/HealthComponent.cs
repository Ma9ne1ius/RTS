using UnityEngine;

namespace Units
{
    public class HealthComponent : MonoBehaviour
    {
        private float currentHealth;
        public float regenerationHealth;
        public float maxHealth;
        public HealthComponent(float maxHealth, float regenerationHealth)
        {
            this.currentHealth = maxHealth;
            this.regenerationHealth = regenerationHealth;
            this.maxHealth = maxHealth;
        }

    }
}