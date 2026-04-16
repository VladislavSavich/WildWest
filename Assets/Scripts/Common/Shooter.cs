using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private Transform _point;

    private Vector3 _firePoint;

    public void Shoot(Vector3 direction)
    {
        _firePoint = new Vector3(_point.position.x, _point.position.y, _point.position.z);

        Bullet bullet = _spawner.SpawnObject(_firePoint);

        if (bullet != null)
        {
            if (bullet.TryGetComponent(out BulletMover mover))
                mover.SetDirection(direction);
        }
    }
}