using System.Collections;
using UnityEngine;

public enum AttackerType
{
    Player,
    AI
}

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private float _height = 1f;
    [SerializeField] private float _attackInterval = 1f;

    private bool _aiIsAttacking;
    private AttackerType _attackerType;
    private InputDetector _inputDetector;
    private WaypointSeeker _waypointSeeker;
    private PlayerDetector _playerDetector;
    private Health _targetHealth;
    private bool _canAttack = true;
    private Coroutine _attackColdown;

    private void Awake()
    {
        if (TryGetComponent(out _inputDetector) && !TryGetComponent(out _waypointSeeker) && !TryGetComponent(out _playerDetector))
        {
            _attackerType = AttackerType.Player;
        }
        else if (!TryGetComponent(out _inputDetector) && TryGetComponent(out _waypointSeeker) && TryGetComponent(out _playerDetector))
        {
            _attackerType=AttackerType.AI;
            _waypointSeeker.PlayerReached += SetAiAttacking;
            _playerDetector.PlayerLost += SetAiNotAttacking;
        }
        else
        {
            print("Error: required components not found");
        }
    }

    private void OnDisable()
    {
        if (_attackerType == AttackerType.AI)
        {
            _waypointSeeker.PlayerReached -= SetAiAttacking;
            _playerDetector.PlayerLost -= SetAiNotAttacking;
        }
    }

    private void Update()
    {
        HandleAttack();
    }

    private void SetAiAttacking()
    {
        _aiIsAttacking = true;
    }

    private void SetAiNotAttacking()
    {
        _aiIsAttacking = false;
    }

    private void HandleAttack()
    {
        if ((_attackerType == AttackerType.Player && _inputDetector.Attack) || (_attackerType == AttackerType.AI && _aiIsAttacking))
        {
            if (CheckForTarget() && _canAttack)
            {
                _targetHealth.TakeDamage(_damage);

                if (_attackColdown != null) 
                {
                    StopCoroutine(_attackColdown);
                }

                _attackColdown = StartCoroutine(AttackColdown());
            }
        }
    }    

    private bool CheckForTarget()
    {
        RaycastHit hit;

        return (Physics.Raycast(transform.position + Vector3.up * _height, transform.forward, out hit, _distance) && hit.transform.TryGetComponent<Health>(out _targetHealth));
    }

    private IEnumerator AttackColdown()
    {
        _canAttack = false;

        while (!_canAttack)
        {
            yield return new WaitForSeconds(_attackInterval);
            _canAttack = true;
        }        
    }
}
