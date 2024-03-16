using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndTurn : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    private void Update()
    {
        MakeTransformation();
    }

    private void MakeTransformation()
    {
        Vector3 ForwardDirection = transform.forward;
        transform.position += ForwardDirection * _moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime);
    }
}
