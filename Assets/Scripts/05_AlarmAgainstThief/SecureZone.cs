using System;
using UnityEngine;

public class SecureZone : MonoBehaviour
{
    public Action ThiefDetected;
    public Action ThiefLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            ThiefDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            ThiefLost?.Invoke();
        }
    }
}
