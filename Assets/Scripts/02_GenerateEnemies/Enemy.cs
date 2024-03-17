using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;

    private void SetTarget(Target target)
    { 
        _target = target; 
    }
}
