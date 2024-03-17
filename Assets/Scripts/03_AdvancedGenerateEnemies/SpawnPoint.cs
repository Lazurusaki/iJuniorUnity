using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyAdvanced _enemyType;
    [SerializeField] private Target _target;

    [HideInInspector] public EnemyAdvanced EnemyType => _enemyType;
    [HideInInspector] public Target Target => _target;
}
