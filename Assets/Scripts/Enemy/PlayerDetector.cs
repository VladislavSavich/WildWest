using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _scanRadius = 100f;
    [SerializeField] private LayerMask _playerLayer;

    private Collider[] _targets;
    private int _maximumTargets = 30;

    public event Action<Player> PlayerDetected;

    private void Start()
    {
        _targets = new Collider[_maximumTargets];

        FindPlayer();
    }

    private void FindPlayer()
    {
        int targetCount = Physics.OverlapSphereNonAlloc(transform.position, _scanRadius, _targets, _playerLayer);

        for (int i = 0; i < targetCount; i++)
        {
            if (_targets[i].TryGetComponent(out Player player))
            {
                PlayerDetected?.Invoke(player);
            }
        }
    }
}
