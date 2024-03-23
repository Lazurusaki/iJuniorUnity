using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;

    [SerializeField] private float _maxHealth = 100f;

    private ItemTaker _itemTaker;
    private float _minHealth = 0;
    private float _healthValue;

    public float HealthValue => _healthValue;
    public float MaxHealth => _maxHealth;

    private void OnEnable()
    {
        if (_itemTaker)
        {
            _itemTaker.MedKitTaken += Heal;
        }
    }

    private void OnDisable()
    {
        if (_itemTaker)
        {
            _itemTaker.MedKitTaken -= Heal;
        }
    }

    private void Awake()
    {
        TryGetComponent(out _itemTaker);
    }

    private void Start()
    {
        _healthValue = _maxHealth;
        HealthChanged?.Invoke();
    }

    public void Heal(MedKit medKit)
    {
        _healthValue = Mathf.Min(_healthValue + medKit.HealValue, _maxHealth);
        HealthChanged?.Invoke();     
    }

    public void TakeDamage(float  damage)
    {
        _healthValue = Mathf.Max(_healthValue - damage, _minHealth);
        HealthChanged?.Invoke();
    }
}
