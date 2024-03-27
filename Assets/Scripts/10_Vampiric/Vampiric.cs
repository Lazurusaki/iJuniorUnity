using System.Collections;
using UnityEngine;

[RequireComponent (typeof(InputDetector), typeof(Health))]

public class Vampiric : MonoBehaviour
{
    [SerializeField] private float _drainRate;
    [SerializeField] private float _distance;
    [SerializeField] private float _duration;
    [SerializeField] private float _coldown;

    private InputDetector _inputDetector;
    private Coroutine _drainCorutine;
    private Coroutine _coldownCorutine;
    private Health _health;
    private float _halfMultiplier = 0.5f;
    private bool _isAvailable = true;
    
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
        if (_inputDetector.Vampiric && _isAvailable)
        {
            if (CheckForTarget(out Health targetHealth))
            {
                if (_coldownCorutine != null)
                {
                    StopCoroutine(_coldownCorutine);
                }

                if (_drainCorutine != null)
                {
                    StopCoroutine(_drainCorutine);
                }

                _isAvailable = false;
                _coldownCorutine = StartCoroutine(Coldown());
                _drainCorutine = StartCoroutine(Drain());
            }
        }
    }

    private bool CheckForTarget(out Health targetHealth)
    {
        targetHealth = null;
        Vector3 originPosition = transform.position + Vector3.up * (GetComponent<CapsuleCollider>().height * _halfMultiplier);
        
        if (Physics.Raycast(originPosition, transform.forward, out RaycastHit hit, _distance))
        {
            if (hit.transform.TryGetComponent<Health>(out targetHealth))
            {
                return (targetHealth.HealthValue > _drainRate);
            }
        }

        return false;
    }

    private IEnumerator Drain()
    {
        float timer = _duration;
        float drainPeriod = 0.1f;
        WaitForSeconds wait = new WaitForSeconds(drainPeriod); 

        while (timer > 0 && CheckForTarget(out Health targetHealth))
        {
            targetHealth.TakeDamage(_drainRate);
            _health.Heal(_drainRate);
            yield return wait;
            timer -= drainPeriod;
        }
    }

    private IEnumerator Coldown()
    {
        float currentTime = 0;

        while (currentTime < _coldown)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }

        _isAvailable = true;
    }
}
