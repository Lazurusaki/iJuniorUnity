using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    private void Start()
    {
        transform.LookAt(_targetTransform);
    }
}
