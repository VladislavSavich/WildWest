using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private float _attackCooldown = 0.5f;

    private bool _canAttack = true;
    private Coroutine _atackingCoroutine;

    public bool IsReady => _canAttack;

    private void OnEnable()
    {
        _atackingCoroutine = StartCoroutine(AttackCooldown());
    }

    private void OnDisable()
    {
        if (_atackingCoroutine != null)
            StopCoroutine(_atackingCoroutine);
    }

    public void Attack(bool IsFirstWeapon)
    {
        if (_canAttack)
        {
            if (IsFirstWeapon)
                _shooter.Shoot(_aimTransform.forward);

            if (_atackingCoroutine != null)
                _atackingCoroutine = StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}