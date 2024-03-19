using System;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    public event Action<Coin> CoinTaken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            CoinTaken?.Invoke(coin);
        }
    }
}
