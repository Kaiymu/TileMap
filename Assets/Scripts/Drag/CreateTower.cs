using Gameplay.Tower;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField]
    private BasicTower _prefabBasicTower;
    private BasicTower _refBasicTower;

    private void Awake()
    {
        _CreateTower();
    }

    private void _CreateTower()
    {
        _refBasicTower = Instantiate(_prefabBasicTower, transform.position, Quaternion.identity);
        _refBasicTower.transform.parent = transform;
    }

    // If the tower is null, it meant it was destroyed (So we have to refill).
    // And if we're not the parent, then we create a new tower.
    private void Update()
    {
        if ((_refBasicTower == null) ||
            (_refBasicTower.transform.parent != null && _refBasicTower.transform.parent != transform))
        {
            _CreateTower();
        }
    }
}
