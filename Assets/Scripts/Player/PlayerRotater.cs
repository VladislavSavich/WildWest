using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _minVerticalAngle;
    [SerializeField] private float _maxVerticalAngle;

    private int _fullCircleDegrees = 360;
    private int _halfCircleDegrees = 180;
    private Vector3 _currentCameraRotation;

    private void Start()
    {
        _currentCameraRotation = _camera.localEulerAngles;

        if (_currentCameraRotation.x > _halfCircleDegrees)
            _currentCameraRotation.x -= _fullCircleDegrees;
    }

    public void Rotate(Vector3 cameraView, Vector3 bodyView)
    {
        _player.Rotate(_speed * bodyView);

        _currentCameraRotation.x += _speed * cameraView.x;
        _currentCameraRotation.x = Mathf.Clamp(_currentCameraRotation.x, _minVerticalAngle, _maxVerticalAngle);
        _camera.localRotation = Quaternion.Euler(_currentCameraRotation);
    }
}
