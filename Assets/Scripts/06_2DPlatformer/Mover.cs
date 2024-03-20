using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(InputDetector))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _jumpForce = 2.0f;

    private bool _isGrounded;
    private float _groundCheckDistance = 0.1f;
    private bool _wantToJump; 
    private Rigidbody _rigidBody;
    private InputDetector _inputDetector;
    private float _horizontalInput;

    public bool IsGrounded => _isGrounded;
    public float HorizontalInput => _horizontalInput;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _inputDetector = GetComponent<InputDetector>();
    }

    private void FixedUpdate()
    {
        HandleGrounded();
        HandleJump();
    }

    private void Update()
    {     
        HandleMovement();
        CheckWantToJump();  
    }

    private void HandleMovement()
    {
        _horizontalInput = _inputDetector.HorizontalAxis;

        if (_horizontalInput != 0)
        {
            Vector3 movementOffset = new Vector3(0f, 0f, _horizontalInput) * _speed * Time.deltaTime;
            transform.LookAt(transform.position + movementOffset);
            transform.Translate(movementOffset, Space.World);
        }
    }

    private void CheckWantToJump()
    {
        if (_inputDetector.Jump)
        {
            _wantToJump = true;
        }
    }

    private void HandleGrounded()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);
    }

    private void HandleJump()
    {
        if (_wantToJump && _isGrounded)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse );            
        }

        _wantToJump = false;
    } 
}
