using System;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public event Action<int> CollisionDetected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            CollisionDetected?.Invoke(bullet.Damage);
    }
}
