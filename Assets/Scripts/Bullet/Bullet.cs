using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletMover _mover;
    [SerializeField] private int _damage = 20;

    private float _lifeTime = 5f;
    private Coroutine _lifeTimeCoroutine;

    public event Action<Bullet> BulletFlewAway;

    public int Damage => _damage;

    private void OnEnable()
    {
        if (_lifeTimeCoroutine != null)
            StopCoroutine(_lifeTimeCoroutine);

        _lifeTimeCoroutine = StartCoroutine(StartLifetime());
    }

    private void OnDisable()
    {
        if (_lifeTimeCoroutine != null)
        {
            StopCoroutine(_lifeTimeCoroutine);
            _lifeTimeCoroutine = null;
        }
    }

    private void Update()
    {
        _mover.Move();
    }

    private IEnumerator StartLifetime()
    {
        var wait = new WaitForSeconds(_lifeTime);

        yield return wait;

        BulletFlewAway?.Invoke(this);
    }
}
