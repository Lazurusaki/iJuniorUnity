using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class HealthTextViewer : HealthViewer
{
    private TMP_Text _text;

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
        _text = GetComponent<TMP_Text>();
    }

    protected override void UpdateHealth()
    {
        if (_health)
        {
            _text.text = _health.HealthValue.ToString() + " / " + _health.MaxHealth.ToString();
        }
    }
}
