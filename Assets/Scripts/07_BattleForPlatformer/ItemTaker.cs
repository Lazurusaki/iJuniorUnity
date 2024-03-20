using System;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public event Action<Item> ItemTaken;
    public event Action <MedKit> MedKitTaken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            ItemTaken?.Invoke(item);

            if (other.TryGetComponent(out MedKit medKit))
            {
                MedKitTaken?.Invoke(medKit);
            }
        }
    }
}
