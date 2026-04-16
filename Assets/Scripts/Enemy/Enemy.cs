using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AnimationController _animator;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyRotator _rotator;
    [SerializeField] private PlayerDetector _detector;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private BulletCollisionHandler _collisionHandler;
    [SerializeField] private Health _health;

    public event Action<Enemy> Dead;

    private void OnEnable()
    {
        _detector.PlayerDetected += SetTarget;
        _collisionHandler.CollisionDetected += _health.TakeDamage;
        _health.HealthOver += Die;
    }

    private void OnDisable()
    {
        _detector.PlayerDetected -= SetTarget;
        _collisionHandler.CollisionDetected -= _health.TakeDamage;
        _health.HealthOver -= Die;
    }

    private void Update()
    {
        _animator.SetupSpeed(_mover.Velocity);

        if (_attacker.IsReady)
        {
            _attacker.Attack(true);
            _animator.SetupAttack();
        }
    }

    private void SetTarget(Player target)
    {
        _mover.StartMoving(target);
        _rotator.StartRotate(target);
    }

    private void Die() => Dead?.Invoke(this);
}
