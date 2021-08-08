using Gameplay.Tower;
using PoolSystem.Runtime;
using System.Collections.Generic;
using UnityEngine;

public class PoolTower : MonoBehaviour
{
    // We need to reset the tower at their first level to do that properly.
    // So for the moment, la flemme.
    [SerializeField]
    private int _numberToSpawn;
    [SerializeField]
    private List<BasicTower> _basicTowers = new List<BasicTower>();

    private void Awake()
    {
        for (int i = 0; i < _basicTowers.Count; i++) {
            PoolManager.instance.QueueIntoPool<BasicTower>(_basicTowers[i], _numberToSpawn);
        }
    }
}
