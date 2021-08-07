using UnityEngine;
using Gameplay.Tower;

public class TowerDrop : MonoBehaviour
{
    private BasicTower _tower = null;

    public bool TryUpdateBasicTower(BasicTower tower)
    {
        if(_tower != null)
        {
            if (!_AreSameType(tower))
                return false;

            _tower.LevelUp();
            Destroy(tower.gameObject);
        } else
        {
            _tower = tower;
        }

        return true;
    }

    private bool _AreSameType(BasicTower tower)
    {
        return _tower.GetType().Name == tower.GetType().Name;
    }
}
