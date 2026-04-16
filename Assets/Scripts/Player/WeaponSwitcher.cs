using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _firstWeapon;
    [SerializeField] private GameObject _secondWeapon;

    public bool IsGun { get; private set; }

    private void Start()
    {
        IsGun = true;
    }

    public void SwitchWeapon()
    {
        _firstWeapon.SetActive(!_firstWeapon.activeSelf);
        _secondWeapon.SetActive(!_firstWeapon.activeSelf);

        IsGun = !IsGun;
    }
}
