using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    protected override void ActionOnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.BulletFlewAway += ReleaseObject;
    }

    protected override void ReleaseObject(Bullet bullet)
    {
        bullet.BulletFlewAway -= ReleaseObject;
        Pool.Release(bullet);
    }

    public Bullet SpawnObject(Vector3 position)
    {
        Bullet bullet = Pool.Get();
        bullet.transform.position = position;
        return bullet;
    }
}