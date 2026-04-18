using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Transform _aim;
    [SerializeField] private float _cooldownValue = 0.5f;

    private bool _canAttack = true;
    private Coroutine _attackingCoroutine;

    public bool IsReadyForAttack => _canAttack;

    private void OnEnable()
    {
        _attackingCoroutine = StartCoroutine(AttackCooldown());
    }

    private void OnDisable()
    {
        if (_attackingCoroutine != null)
            StopCoroutine(_attackingCoroutine);
    }

    public void Attack(bool IsFirstWeapon)
    {
        if (_canAttack)
        {
            if (IsFirstWeapon)
                _shooter.Shoot(_aim.forward);

            if (_attackingCoroutine != null)
                _attackingCoroutine = StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_cooldownValue);
        _canAttack = true;
    }
}