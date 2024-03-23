using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]

public class HealthBarSmoothViewer : HealthViewer
{ 
    [SerializeField] private float _smoothRate;

    private Slider _healthSlider;
    private  Coroutine _smoothCoroutine;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    protected override void UpdateHealth()
    {
        if (_health)
        {
            if (_smoothCoroutine != null)
            {
                StopCoroutine(SmoothCoroutine());
            }

            _smoothCoroutine = StartCoroutine(SmoothCoroutine());
        }
    }

    private IEnumerator SmoothCoroutine()
    {
        while (_healthSlider.value != (_health.HealthValue / _health.MaxHealth)) 
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, _health.HealthValue / _health.MaxHealth, _smoothRate * Time.deltaTime);
            yield return null;
        }      
    }
}
