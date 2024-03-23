using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class HealthTextViewer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TMP_Text _text;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateText;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateText;
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void UpdateText()
    {
        if (_health)
        {
            _text.text = _health.HealthValue.ToString() + " / " + _health.MaxHealth.ToString();
        }
    }
}
