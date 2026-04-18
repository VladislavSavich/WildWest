using System;
using UnityEngine;

public class WeaponCollisionHandler : MonoBehaviour
{
    public event Action<float> CollisionDetected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            CollisionDetected?.Invoke(bullet.Damage);
        else if (collision.gameObject.TryGetComponent(out Sword sword))
            CollisionDetected?.Invoke(sword.Damage);
    }
}
