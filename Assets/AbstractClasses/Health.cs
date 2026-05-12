//abstract class for health management, can be extended for player, enemies, etc.

using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    protected abstract void Die();
}