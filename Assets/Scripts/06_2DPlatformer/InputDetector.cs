using UnityEngine;

public class InputDetector : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;

    private float _horizontalAxis;
    private bool _jump;

    public float HorizontalAxis => _horizontalAxis;
    public bool Jump => _jump;

    private void Update()
    {
        _horizontalAxis = Input.GetAxis(HorizontalAxisName);
        _jump = Input.GetKeyDown(JumpButton);
    }
}
