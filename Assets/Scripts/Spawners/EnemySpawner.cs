using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<Enemy> _enemys = new List<Enemy>();
    private int _activeEnemys = 0;

    public event Action AllEnemysRemoves;

    public void SpawnObject(Enemy enemy, Transform point)
    {
        Enemy newEnemy = Instantiate(enemy, point.position, point.rotation);
        newEnemy.Dead += RemoveEnemy;
        _enemys.Add(newEnemy);
        _activeEnemys++;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.Dead -= RemoveEnemy;
            _enemys.Remove(enemy);
            Destroy(enemy.gameObject);
            _activeEnemys--;
        }

        if (_activeEnemys == 0)
            AllEnemysRemoves?.Invoke();
    }

    public void RemoveAllEnemys()
    {
        while (_enemys.Count > 0)
        {
            Enemy enemy = _enemys[0];

            if (enemy != null)
            {
                enemy.Dead -= RemoveEnemy;
                Destroy(enemy.gameObject);
            }

            _enemys.RemoveAt(0);
        }

        _activeEnemys = 0;
    }
}
