using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    const string IsMovingTriggerName = "isMoving";
    const string IsGroundedTriggerName = "isGrounded";
    const string AnimationSpeedParameterName = "AnimationSpeed";

    private Movement _movement;
    private Animator _animator;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();
}

    private void Update()
    {
        if (_movement && _animator)
        {
            _animator.SetBool(IsMovingTriggerName, _movement.HorizontalInput != 0 ? true : false);
            _animator.SetFloat(AnimationSpeedParameterName, Mathf.Abs(_movement.HorizontalInput));
            _animator.SetBool(IsGroundedTriggerName, _movement.IsGrounded);
        }
    }


}
