using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private ItemTaker _itemTaker;
    private float _minHealth = 0;
    private float _health;

    private void OnEnable()
    {
        if (_itemTaker)
        {
            _itemTaker.MedKitTaken += Heal;
        }
    }

    private void OnDisable()
    {
        if (_itemTaker)
        {
            _itemTaker.MedKitTaken -= Heal;
        }
    }

    private void Awake()
    {
        TryGetComponent(out _itemTaker);
    }

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal(MedKit medKit)
    {
        _health = Mathf.Min(_health + medKit.HealValue, _maxHealth);
        print("Got heal");
    }

    public void TakeDamage(float  damage)
    {
        _health = Mathf.Max(_health - damage, _minHealth);
    }
}
