using System.Collections;
using UnityEngine;

[RequireComponent (typeof(InputDetector))]

public class Vampiric : MonoBehaviour
{
    [SerializeField] private float _drainRate;
    [SerializeField] private float _distance;
    [SerializeField] private float _duration;

    private InputDetector _inputDetector;
    private Coroutine _coroutine;
    private Health _health;
    private Health _targetHealth;
    private float _halfMultiplier = 0.5f;
    
    private void Awake()
    {
        _inputDetector = GetComponent<InputDetector>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        AbilityHandler();
    }

    private void AbilityHandler()
    {
        if (_inputDetector.Vampiric && CheckForTarget())
        {
            if (_targetHealth.HealthValue > 0)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine(Drain(_duration));
            }
        }
    }

    private bool CheckForTarget()
    {
        RaycastHit hit;
        return (Physics.Raycast(transform.position + Vector3.up * (GetComponent<CapsuleCollider>().height*_halfMultiplier), transform.forward, out hit, _distance) && hit.transform.TryGetComponent<Health>(out _targetHealth));
    }

    private IEnumerator Drain(float duration)
    {
        float timer = duration;

        while (timer > 0)
        {
            _targetHealth.TakeDamage(_drainRate);
            _health.Heal(_drainRate);
            yield return null;
            timer -= Time.deltaTime;
        }
    }
}
