using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 720f;

    private Vector3 _direction = Vector3.forward;

    public void SetDirection(Vector3 newDirection)
    {
        _direction = newDirection.normalized;
    }

    public void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        transform.Rotate(Vector3.back, _rotationSpeed * Time.deltaTime);
    }
}
