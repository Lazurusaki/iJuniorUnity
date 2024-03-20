using UnityEngine;

public class InputDetector : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;
    private const KeyCode AttackButton = KeyCode.F;

    private float _horizontalAxis;
    private bool _jump;
    private bool _attack;

    public float HorizontalAxis => _horizontalAxis;
    public bool Jump => _jump;
    public bool Attack => _attack;

    private void Update()
    {
        _horizontalAxis = Input.GetAxis(HorizontalAxisName);
        _jump = Input.GetKeyDown(JumpButton);
        _attack = Input.GetKeyDown(AttackButton);
    }
}
