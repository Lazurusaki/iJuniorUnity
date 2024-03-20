using System;
using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]

public class WaypointSeeker : MonoBehaviour
{
    public event Action PlayerReached;

    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _playerSeekSpeed;
    [SerializeField] private float _distanceThreshold;
    [SerializeField] private Transform _waypointsBranch;

    private float _speed;
    private int _currentWaypointIndex;
    private Transform _currentWaypoint;
    private Transform _lastWaypoint;
    private PlayerDetector _playerDetector;
    private bool _isSeekingPlayer;

    private void Awake()
    {
        _playerDetector = GetComponent<PlayerDetector>();
    }

    private void OnEnable()
    {
        _playerDetector.OnPlayerDetected += SeekPlayer;
        _playerDetector.OnPlayerLost += ReturnToLastWaypoint;
    }

    private void OnDisable()
    {
        _playerDetector.OnPlayerDetected -= SeekPlayer;
        _playerDetector.OnPlayerLost -= ReturnToLastWaypoint;
    }

    private void Start()
    {
        _speed = _patrolSpeed;

        if (_waypointsBranch.childCount > 0)
        {
            _currentWaypoint = _waypointsBranch.GetChild(_currentWaypointIndex);
        }
    }

    private void Update()
    {
        if (_waypointsBranch.childCount > 0 || _isSeekingPlayer)
        {
            MoveToWaypoint();
        }
    }

    private void SeekPlayer(Player player)
    {
        if (!_isSeekingPlayer)
        {
            _lastWaypoint = _currentWaypoint;
            _currentWaypoint = player.transform;
            _isSeekingPlayer = true;
            _speed = _playerSeekSpeed;
        }
    }

    private void ReturnToLastWaypoint()
    {
        _currentWaypoint = _lastWaypoint;
        _isSeekingPlayer = false;
        _speed = _patrolSpeed;
    }

    private void DefineNewWaypoint()
    {
        _currentWaypointIndex = ++_currentWaypointIndex % _waypointsBranch.childCount;
        _currentWaypoint = _waypointsBranch.GetChild(_currentWaypointIndex);
        transform.forward = _currentWaypoint.position - transform.position;
    }

    private void MoveToWaypoint()
    {
        if (Vector3.Distance(transform.position, _currentWaypoint.position) > _distanceThreshold)
        {      
            transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _speed * Time.deltaTime);
            transform.LookAt(_currentWaypoint.position);
        }
        else
        {
            if (!_isSeekingPlayer)
            {
                DefineNewWaypoint();
            }
            else
            {
                PlayerReached?.Invoke();
            }
        }
    }
}
