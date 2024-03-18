using System;
using UnityEngine;

public class SecureZone : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            if (_alarm)
            {
                _alarm.Activate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            if (_alarm)
            {
                _alarm.Deactivate();
            }
        }
    }
}
