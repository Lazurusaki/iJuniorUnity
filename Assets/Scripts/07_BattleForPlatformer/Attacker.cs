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

    private bool _aiIsAttacking;
    private AttackerType _attackerType;
    private InputDetector _inputDetector;
    private WaypointSeeker _waypointSeeker;
    private PlayerDetector _playerDetector;
    private Health _targetHealth;

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
            _playerDetector.OnPlayerLost += SetAiNotAttacking;
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
            _playerDetector.OnPlayerLost -= SetAiNotAttacking;
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
            print(gameObject.name + "isAttacking");

            if (CheckForTarget())
            {
                _targetHealth.TakeDamage(_damage);
                print(_targetHealth.gameObject + "Damaged");
            }
        }
    }    

    private bool CheckForTarget()
    {
        RaycastHit hit;

        return (Physics.Raycast(transform.position + Vector3.up * _height, transform.forward, out hit, _distance) && hit.transform.TryGetComponent<Health>(out _targetHealth));
    }
}
