using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _hitPoints = 100f;
    [SerializeField] private float _maxHitPoints = 100f;

    private float _minimumValue = 0f;

    public event Action<float, float> Changed;
    public event Action HealthOver;

    public float HitCount => _hitPoints;

    public void TakeDamage(float damage)
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
