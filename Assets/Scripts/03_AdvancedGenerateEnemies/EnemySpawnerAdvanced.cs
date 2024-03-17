using System.Collections;
using UnityEngine;

public class EnemySpawnerAdvanced : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval;

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
            SpawnPoint spawnPoint = _spawnPoints[spawnPointIndex];
            GameObject enemy = Instantiate(spawnPoint.EnemyType.gameObject, spawnPoint.transform.position, Quaternion.identity);         
            enemy.GetComponent<EnemyAdvanced>().SetTarget(spawnPoint.Target);

            yield return wait;
        }
    }
}
