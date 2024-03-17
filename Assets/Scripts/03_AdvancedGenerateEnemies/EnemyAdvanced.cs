using UnityEngine;

public class EnemyAdvanced : MonoBehaviour
{
    private Target _target;

    public void SetTarget(Target target)
    { 
        _target = target; 
    }

    private void Update()
    {
        transform.LookAt(_target.transform);
    }
}
