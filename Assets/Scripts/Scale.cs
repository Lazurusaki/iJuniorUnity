using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _scaleFactror = new Vector3(0.1f, 0.1f, 0.1f);

    private void Update()
    {
        MakeTransformation();
    }

    private void MakeTransformation()
    {
        transform.localScale += _scaleFactror * _speed * Time.deltaTime;
    }
}
