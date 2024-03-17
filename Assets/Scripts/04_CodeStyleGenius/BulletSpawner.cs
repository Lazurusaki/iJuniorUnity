using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _initialVelocity;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _target;
    [SerializeField] private bool _isActivated;

    private bool _isWorking = false;
    
    private void Update()
    {
        if (_isActivated && !_isWorking &&_bulletPrefab && _target ) 
        {
            StartCoroutine(SpawningWorker());
        }
    }

    private IEnumerator SpawningWorker()
    {
        var wait = new WaitForSeconds(_spawnInterval);
        _isWorking = true;

        while (_isActivated)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _initialVelocity;
            yield return wait;
        }

        _isWorking = false;
    }

}