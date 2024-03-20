using UnityEngine;

public enum AttackerType
{
    Player,
    AI
}

public class Attacker : MonoBehaviour
{
    private bool _aiIsAttacking;
    private AttackerType _attackerType;
    private InputDetector _inputDetector;
    private WaypointSeeker _waypointSeeker;
    private PlayerDetector _playerDetector;

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
        }
    }    
}
