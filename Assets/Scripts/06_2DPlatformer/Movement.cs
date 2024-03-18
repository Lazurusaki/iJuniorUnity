using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent (typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _jumpForce = 2.0f;

    [SerializeField] private bool _isGrounded;
    private float _groundCheckDistance = 0.2f;
    private Rigidbody _rigidBody;
    private float _horizontalInput;

    public bool IsGrounded => _isGrounded;
    public float HorizontalInput => _horizontalInput;
    
    private void Update()
    {     
        HandleMovement();
        HandleGrounded();
        HandleJump();
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void HandleMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        
        if (_horizontalInput !=0)
        {     
            Vector3 movement = new Vector3(0f, 0f, _horizontalInput) * _speed * Time.deltaTime;
            transform.LookAt(transform.position + movement);
            transform.Translate(movement, Space.World);     
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse );
        }
    }

    private void HandleGrounded()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);
    }
}
