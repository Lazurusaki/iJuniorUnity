using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public event Action<Player> PlayerDetected;
    public event Action PlayerLost;

    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _detectionHeight = 1f;

    private Player _target;
    private bool _playerDetected;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * _detectionHeight, transform.forward, out hit, _distance))
        {
            if (hit.transform.TryGetComponent<Player>(out _target))
            {
                _playerDetected = true;
                PlayerDetected?.Invoke(_target);
            }
        }
        else if (_playerDetected)
        {
            PlayerLost?.Invoke();
            _playerDetected = false;
        } 
    }
}
