using System;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out _))
        {
            Debug.Log("Coin Taken!");
        }
    }
}
