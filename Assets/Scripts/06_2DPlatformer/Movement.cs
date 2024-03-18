using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent (typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _jumpForce = 2.0f;

    private float _groundCheckDistance = 0.1f;
    private float _characterHeight;
    private Rigidbody _rigidBody;

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void Awake()
    {
        float halfHeightMultiplier = 0.5f;
        _characterHeight = GetComponent<CapsuleCollider>().height * halfHeightMultiplier;
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0.0f)
        {
            Vector3 movement = new Vector3(0f, 0f, horizontalInput) * _speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down,  _characterHeight + _groundCheckDistance);
    }

    
}
