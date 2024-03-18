using System;
using UnityEngine;

public class SecureZone : MonoBehaviour
{
    public event Action ThiefDetected;
    public event Action ThiefLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            ThiefDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            ThiefLost?.Invoke();
        }
    }
}
