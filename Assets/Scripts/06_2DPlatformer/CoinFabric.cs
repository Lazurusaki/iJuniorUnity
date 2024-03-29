using UnityEngine;

public class CoinFabric : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private CoinTaker _coinTaker;

    private void OnEnable()
    {
        _coinTaker.CoinTaken += DestoyCoin;
    }

    private void OnDisable()
    {
        _coinTaker.CoinTaken -= DestoyCoin;
    }

    private void Start()
    {
        SpawnCoins();
    }

    private void DestoyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    private void SpawnCoins()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Instantiate(_coinPrefab, transform.GetChild(i).position, Quaternion.identity);
            }   
        }       
    }   
}

