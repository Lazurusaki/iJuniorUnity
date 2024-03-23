using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]

public class HealthBarViewer : HealthViewer
{
    private Slider _healthSlider;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
    }

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    protected override void UpdateHealth()
    {
        if (_health)
        {
            _healthSlider.value = _health.HealthValue / _health.MaxHealth;
        }
    }
}
