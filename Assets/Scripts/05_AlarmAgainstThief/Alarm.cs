using System.Collections;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private SecureZone _secureZone; 
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _fadeDuration = 2.0f;
    
    private AudioSource _alarm;
    private Coroutine _coroutine;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.volume = _minVolume;
    }

    private void OnEnable()
    {
        if (_secureZone)
        {
            _secureZone.ThiefDetected += Activate;
            _secureZone.ThiefLost += Deactivate;
        }
    }

    private void OnDisable()
    {
        if (_secureZone)
        {
            _secureZone.ThiefDetected -= Activate;
            _secureZone.ThiefLost -= Deactivate;
        }
    }

    private void Activate()
    {
        if (!_alarm.isPlaying)
        {
            _alarm.Play();

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(FadeVolume(_maxVolume));
        }
    }

    private void Deactivate()
    {
        StartCoroutine(FadeVolume(_minVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        while (_alarm.volume != targetVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _maxVolume / _fadeDuration * Time.deltaTime);
            yield return null;
        }

        if (_alarm.volume == _minVolume)
        {
            _alarm.Stop();
        }
    }

}
