using UnityEngine;

public class MedKit : Item
{
    [SerializeField] private float _healValue = 100f;

    public float HealValue => _healValue;
}
