using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveStarter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private List<Enemy> _allEnemy;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _waveCounter = 0;
    private int _maxWaveLimit = 6;
    private int _enemyCount = 3;
    private int _bossCount = 1;
    private int _counter;

    public event Action AllEnemysDead;

    private void OnEnable()
    {
        _spawner.AllEnemysRemoves += StartWave;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysRemoves -= StartWave;
    }

    private void StartWave()
    {
        if (_waveCounter < _maxWaveLimit)
        {
            Enemy prefabToSpawn = _allEnemy[_waveCounter];

            for (int i = 0; i < _counter; i++)
            {
                _spawner.SpawnObject(prefabToSpawn, _spawnPoints[i]);
            }

            _waveCounter++;
            _counter = _counter == _enemyCount ? _bossCount : _enemyCount;
        }
        else
        {
            AllEnemysDead?.Invoke();
        }
    }

    public void Reset()
    {
        _spawner.RemoveAllEnemys();
        _waveCounter = 0;
        _counter = _enemyCount;
        StartWave();
    }
}
