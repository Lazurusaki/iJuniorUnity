using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _fadeDuration = 2.0f;
    
    private AudioSource _alarm;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() != null) 
        {      
            _alarm.Play();
            StartCoroutine(FadeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
        {
            StartCoroutine(FadeVolume(_minVolume));
        }
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
