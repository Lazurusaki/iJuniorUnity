using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]

public class HealthBarViewer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _healthSlider;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateBar;
    }

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void UpdateBar()
    {
        if (_health)
        {
            _healthSlider.value = _health.HealthValue / _health.MaxHealth;
        }
    }
}
