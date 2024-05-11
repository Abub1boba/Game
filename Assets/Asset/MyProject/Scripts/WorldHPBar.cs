using UnityEngine;
using UnityEngine.UI;

public class WorldHPBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthFill;
    new private Camera camera;

    void Start()
    {
        camera = Camera.main;
        health.OnHealthChange += OnHealthChange;
    }

    private void OnHealthChange(Health health) => healthFill.fillAmount = health.CurrentHealth / health.MaxHealth;

    private void Update() => transform.LookAt(camera.transform);

    private void OnDisable() => health.OnHealthChange -= OnHealthChange;
}
