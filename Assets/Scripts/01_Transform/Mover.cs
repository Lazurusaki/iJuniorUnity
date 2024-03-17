using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover: MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 ForwardDirection = transform.forward;
        transform.position += ForwardDirection * _speed * Time.deltaTime;
    }
}
