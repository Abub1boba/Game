using UnityEngine;
using UnityEngine.UI;

public class HUDbar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthFill;

    void Start()
    {
        health.OnHealthChange += OnHealthChange;
    }

    private void OnHealthChange(Health health)
    {
        healthFill.fillAmount = health.CurrentHealth / health.MaxHealth;
    }

    private void OnDisable() => health.OnHealthChange -= OnHealthChange;
}
