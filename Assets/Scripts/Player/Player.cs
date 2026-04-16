using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationController _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotater _rotater;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private BulletCollisionHandler _collisionHandler;
    [SerializeField] private Health _health;
    [SerializeField] private WeaponSwitcher _switcher;

    public event Action GameOver;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += _health.TakeDamage;
        _health.HealthOver += PassAway;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= _health.TakeDamage;
        _health.HealthOver -= PassAway;
    }

    private void Update()
    {
        _mover.Move(_inputReader.Direction);
        _rotater.Rotate(_inputReader.CameraView, _inputReader.BodyView);
        _animator.SetupSpeed(_mover.GetHorizontalSpeed());

        if (_inputReader.GetIsSwitch())
            _switcher.SwitchWeapon();

        if (_inputReader.GetIsAttack())
        {
            if (_attacker.IsReady)
            {
                if (!_switcher.IsGun)
                    _animator.SetupSecondWeapon();

                _attacker.Attack(_switcher.IsGun);
                _animator.SetupAttack();
            }
        }
    }

    private void PassAway()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _mover.Reset();
        _health.Reset();
    }
}
