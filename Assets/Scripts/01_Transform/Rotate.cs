using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        MakeTransformation();
    }

    private void MakeTransformation()
    {
        transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }
}
