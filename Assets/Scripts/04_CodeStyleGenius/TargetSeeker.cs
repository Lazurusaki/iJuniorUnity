using TMPro;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceThreshold;
    [SerializeField] private Transform[] _targets;

    private int _currentTargetIndex;
    private Transform _currentTarget;

    private void Start()
    {
        if (_targets.Length != 0)
        {
            _currentTarget = _targets[_currentTargetIndex];
        }
    }

    private void Update()
    {
        if (_targets.Length != 0)
        {
            MoveToTarget();
        }
    }

    public void DefineNewTarget()
    {
        _currentTargetIndex++;

        if (_currentTargetIndex == _targets.Length)
        {
            _currentTargetIndex = 0;
        }

        _currentTarget = _targets[_currentTargetIndex].transform;
        transform.forward = _currentTarget.position - transform.position;
    }

    private void MoveToTarget()
    {     
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentTarget.position) < _distanceThreshold)
        {
            DefineNewTarget();
        }
    }
}