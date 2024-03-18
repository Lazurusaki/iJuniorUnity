using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class CoinPint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _hideDuration = 5.0f;

    private Coin _coin;

    private void Start()
    {
       _coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CoinTaker>())
        {
            StartCoroutine(HideForDuration());
        }
    }

    private IEnumerator HideForDuration()
    {  
        _coin.gameObject.SetActive(false);
        yield return new WaitForSeconds(_hideDuration);
        _coin.gameObject.SetActive(true);
    }

}
