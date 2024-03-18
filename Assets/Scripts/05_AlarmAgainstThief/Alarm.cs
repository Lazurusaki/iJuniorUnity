using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private SecureZone _secureZone; 
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _fadeDuration = 2.0f;
    
    private AudioSource _alarmSound;
    private Coroutine _coroutine;

    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>();
        _alarmSound.volume = _minVolume;
    }

    public void Activate()
    {
        if (!_alarmSound.isPlaying)
        {
            _alarmSound.Play();
        }

        if (_coroutine != null)
        {
             StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(FadeVolume(_maxVolume));
        
    }

    public void Deactivate()
    {
        StartCoroutine(FadeVolume(_minVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        while (_alarmSound.volume != targetVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, _maxVolume / _fadeDuration * Time.deltaTime);
            yield return null;
        }

        if (_alarmSound.volume == _minVolume)
        {
            _alarmSound.Stop();
        }
    }

}
