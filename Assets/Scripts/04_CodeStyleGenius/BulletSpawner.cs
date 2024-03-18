using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _initialVelocity;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _target;
  
    private void Start()
    {
        if (_bulletPrefab && _target ) 
        {
            StartCoroutine(SpawningWorker());
        }
    }

    private IEnumerator SpawningWorker()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _initialVelocity;
            yield return wait;
        }
    }
}