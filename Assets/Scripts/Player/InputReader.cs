using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const KeyCode SwitchKey = KeyCode.R;
    private const KeyCode AttackKey = KeyCode.Mouse0;

    private bool _isAttack;
    private bool _isSwitch;

    public Vector3 Direction { get; private set; }
    public Vector3 CameraView { get; private set; }
    public Vector3 BodyView { get; private set; }

    private void Update()
    {
        Direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        CameraView = -Input.GetAxis(MouseY) * Time.deltaTime * Vector3.right;
        BodyView = Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up;

        if (Input.GetKeyDown(AttackKey))
            _isAttack = true;

        if (Input.GetKeyDown(SwitchKey))
            _isSwitch = true;
    }

    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);
    public bool GetIsSwitch() => GetBoolAsTrigger(ref _isSwitch);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
