using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 100;
    [SerializeField] private int _maxHitPoints = 100;

    private int _minimumValue = 0;

    public event Action<int, int> Changed;
    public event Action HealthOver;

    public int HitCount => _hitPoints;

    public void TakeDamage(int damage)
    {
        if (damage > _minimumValue)
        {
            _hitPoints -= damage;
            Changed?.Invoke(_hitPoints, _maxHitPoints);

            if (_hitPoints <= _minimumValue)
                HealthOver?.Invoke();
        }
    }

    public void Reset()
    {
        _hitPoints = _maxHitPoints;
        Changed?.Invoke(_hitPoints, _maxHitPoints);
    }
}
