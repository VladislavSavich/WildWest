using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));
    public readonly int Attack = Animator.StringToHash(nameof(Attack));
    public readonly int SecondWeapon = Animator.StringToHash(nameof(SecondWeapon));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }

    public void SetupAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void SetupSecondWeapon()
    {
        _animator.SetTrigger(SecondWeapon);
    }
}
