using System.Collections;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private Vector3 _direction;
    private Coroutine _rotateCoroutine;

    public void StartRotate(Player target)
    {
        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(RotateToTarget(target));
    }

    private IEnumerator RotateToTarget(Player target)
    {
        while (enabled)
        {
            yield return null;

            _direction = (target.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(_direction);
        }
    }
}
