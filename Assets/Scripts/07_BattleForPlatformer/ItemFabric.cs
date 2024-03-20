using UnityEngine;

public class ItemFabric : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private MedKit _medKitPrefab;
    [SerializeField] private ItemTaker _itemTaker;
    [SerializeField] private Transform _coinTransformsBranch;
    [SerializeField] private Transform _medKitTransformsBranch;

    private void OnEnable()
    {
        _itemTaker.ItemTaken += DestroyItem;
    }

    private void OnDisable()
    {
        _itemTaker.ItemTaken -= DestroyItem;
    }

    private void Start()
    {
        SpawnItemsOfBrach(_coinPrefab, _coinTransformsBranch);
        SpawnItemsOfBrach(_medKitPrefab, _medKitTransformsBranch);
    }

    private void DestroyItem(Item item)
    {
        Destroy(item.gameObject);
    }

    private void SpawnItemsOfBrach(Item _itemPrefab, Transform transformsBranch)
    {
        if (transformsBranch.childCount > 0)
        {
            for (int i = 0; i < transformsBranch.childCount; i++)
            {
                Instantiate(_itemPrefab, transformsBranch.GetChild(i).position, Quaternion.identity);
            }   
        }       
    }   
}

