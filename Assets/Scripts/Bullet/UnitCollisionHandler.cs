using System;
using UnityEngine;

public class UnitCollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            CollisionDetected?.Invoke();
        else if(collision.gameObject.TryGetComponent(out Player player))
            CollisionDetected?.Invoke();
    }
}
