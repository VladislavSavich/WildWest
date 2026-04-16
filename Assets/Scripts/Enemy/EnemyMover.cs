using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _minimumDistance = 30f;
    private float _minimumSpeed = 0f;
    private float _distance;
    private Coroutine _movingCoroutine;

    public float Velocity { get; private set; }

    private void Start()
    {
        Velocity = _minimumSpeed;
    }

    public void StartMoving(Player target)
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(MoveToTarget(target));
    }

    private IEnumerator MoveToTarget(Player target)
    {
        while (enabled)
        {
            yield return null;

            _distance = (transform.position - target.transform.position).sqrMagnitude;

            if (_distance > _minimumDistance)
            {
                float step = _speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                Velocity = _speed;
            }
            else
            {
                Velocity = _minimumSpeed;
            }
        }
    }
}
