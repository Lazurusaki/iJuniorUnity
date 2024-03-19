using UnityEngine;

[RequireComponent(typeof(Mover),typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    const string IsMovingTriggerName = "isMoving";
    const string IsGroundedTriggerName = "isGrounded";
    const string AnimationSpeedParameterName = "AnimationSpeed";

    private Mover _movement;
    private Animator _animator;

    private void Awake()
    {
        _movement = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_movement && _animator)
        {
            _animator.SetBool(IsMovingTriggerName, _movement.HorizontalInput != 0);
            _animator.SetFloat(AnimationSpeedParameterName, Mathf.Abs(_movement.HorizontalInput));
            _animator.SetBool(IsGroundedTriggerName, _movement.IsGrounded);
        }
    }
}
