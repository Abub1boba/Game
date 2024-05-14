using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool IsDead => currentHealth <= 0;
    public event Action<Health> OnHealthChange;

    [SerializeField] private Animator animator;
    private float currentHealth;

    public float MaxHealth => StaticData.playerRole.startHealth;
    public float CurrentHealth => currentHealth;

    private void Start() => currentHealth = StaticData.playerRole.startHealth;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChange?.Invoke(this);

        if (currentHealth <= 0 )
        {
            Die();
        }
    }

    private void Die() => animator.SetTrigger("Dead");
}
