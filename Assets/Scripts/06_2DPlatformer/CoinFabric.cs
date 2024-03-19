using UnityEngine;

public class CoinFabric : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private CoinTaker _coinTaker;

    private void DestoyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    private void OnEnable()
    {
        _coinTaker.CoinTaken += DestoyCoin;
    }

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {

        if (transform.childCount > 0)
        {
            Vector3 position;

            for (int i = 0; i < transform.childCount; i++)
            {
                position = transform.GetChild(i).position;
                Instantiate(_coinPrefab, position, Quaternion.identity);
            }   
        }       
    }

    private void OnDisable()
    {
        _coinTaker.CoinTaken -= DestoyCoin;
    }
}

