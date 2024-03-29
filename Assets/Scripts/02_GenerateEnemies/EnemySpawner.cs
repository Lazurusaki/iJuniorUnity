using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] EnemyOld _enemyPrefab;
    [SerializeField] private float _spawnInterval;

    private float _rotationMin = 0f;
    private float _rotationMax = 360f;   

    private void Start()
    {
        if (_spawnPoints.Length > 0)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        while (true)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            GameObject enemy = Instantiate(_enemyPrefab.gameObject, _spawnPoints[spawnPointIndex].position, Quaternion.identity);
            Quaternion rotation = Quaternion.Euler(0f, Random.Range(_rotationMin, _rotationMax), 0.0f);
            enemy.transform.rotation = rotation; 
            yield return wait;
        }
    }
}
