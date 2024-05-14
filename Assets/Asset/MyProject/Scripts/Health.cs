using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool IsDead => currentHealth <= 0;
    public event Action<Health> OnHealthChange;

    [SerializeField] private ParticleSystem blood;
    [SerializeField] private Animator animator;
    private float currentHealth;
    private float startHealth;

    public float MaxHealth => startHealth;
    public float CurrentHealth => currentHealth;

    public void TakeDamage(float damage)
    {

        if (blood != null) Instantiate(blood, transform.position + Vector3.up, Quaternion.identity, transform);
        currentHealth -= damage;
        OnHealthChange?.Invoke(this);

        if (currentHealth <= 0 )
        {
            Die();
        }
    }

    private void Die() => animator.SetTrigger("Dead");

    internal void SetStartHealth(float StartHealth)
    {
        startHealth = StartHealth;
        currentHealth = StartHealth;
    }
}
