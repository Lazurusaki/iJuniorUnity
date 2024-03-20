using UnityEngine;

[RequireComponent (typeof(ItemTaker))]

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private ItemTaker _itemTaker;
    private float _health;

    private void OnEnable()
    {
        _itemTaker.MedKitTaken += Heal;
    }

    private void OnDisable()
    {
        _itemTaker.MedKitTaken -= Heal;
    }

    private void Awake()
    {
        _itemTaker = GetComponent<ItemTaker>();
    }

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Heal(MedKit medKit)
    {
        _health = Mathf.Min(_health + medKit.HealValue, _maxHealth);
        print("Got heal");
    }
}
