using Gameplay.Ennemies;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnnemy : MonoBehaviour
{
    [SerializeField]
    private int _numberToSpawn;
    [SerializeField]
    private List<Ennemy> _ennemies;

    private void Start()
    {
        for(int i = 0; i < _ennemies.Count; i++)
        {
            PoolSystem.instance.QueueIntoPool<Ennemy>(_ennemies[i], _numberToSpawn);
        }
    }
}
