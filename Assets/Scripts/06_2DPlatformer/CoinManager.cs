using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private Coin[]_coins;

    private void OnEnable()
    {
        Coin.CoinTaken += DestoyCoin;
    }

    private void OnDisable()
    {
        Coin.CoinTaken -= DestoyCoin;
    }

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        _coins = new Coin[transform.childCount];

        if (_coins.Length > 0)
        {
            Vector3 position;

            for (int i = 0; i < _coins.Length; i++)
            {
                position = transform.GetChild(i).GetComponent<Transform>().position;
                Coin coin = Instantiate(_coinPrefab, position, Quaternion.identity);
                coin.Index = i;
                _coins[i] = coin;
            }   
        }       
    }  

    private void DestoyCoin(int index)
    {
        Destroy(_coins[index].gameObject);
    }
}

