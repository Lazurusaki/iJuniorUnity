using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Coin : MonoBehaviour
{
    public static event Action<int> CoinTaken;

    private int _index;
    
    public int Index
    {
        get => _index; 
        set => _index = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CoinTaker>(out _))
        {
            CoinTaken?.Invoke(_index);
        }
    }
}