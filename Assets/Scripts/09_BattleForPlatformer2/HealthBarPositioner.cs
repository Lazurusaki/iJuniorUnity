using UnityEngine;

public class HealthBarPositioner : MonoBehaviour
{
    [SerializeField] private Health _character;
    [SerializeField] private float _verticalOffset;

    private void Update()
    {
        if (_character)
        {
            Vector3 newPosition = new Vector3(_character.transform.position.x, _character.transform.position.y + _verticalOffset, _character.transform.position.z);
            transform.position = newPosition;
        }
    }

}
