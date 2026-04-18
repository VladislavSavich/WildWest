using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _damage = 40f;

    public float Damage => _damage;
}
