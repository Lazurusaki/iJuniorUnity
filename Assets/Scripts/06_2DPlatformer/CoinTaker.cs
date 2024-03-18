using System;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            Debug.Log("Coin Taken!");
        }
    }
}
