using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _spawnInterval;

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
            GameObject enemy = Instantiate(_enemyPrefab, _spawnPoints[spawnPointIndex].position, Quaternion.identity);
            Quaternion rotation = Quaternion.Euler(0f, Random.Range(_rotationMin, _rotationMax), 0.0f);
            enemy.transform.rotation = rotation; 
            yield return wait;
        }
    }
}
