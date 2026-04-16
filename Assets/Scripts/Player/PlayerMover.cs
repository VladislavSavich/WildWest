using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 9.8f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _startPosition;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        Reset();
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = transform.TransformDirection(direction) * _speed;
        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    public float GetHorizontalSpeed()
    {
        Vector3 horizontalVelocity = new Vector3(_characterController.velocity.x, 0, _characterController.velocity.z);

        return horizontalVelocity.magnitude;
    }

    public void Reset()
    {
        _characterController.enabled = false;
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _moveDirection = Vector3.zero;
        _characterController.enabled = true;
    }
}
