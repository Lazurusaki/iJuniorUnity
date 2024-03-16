using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        MakeTransformation();
    }

    private void MakeTransformation()
    {
        Vector3 ForwardDirection = transform.forward;
        transform.position += ForwardDirection * _speed * Time.deltaTime;
    }
}
