using PoolSystem.Runtime;
using System.Collections.Generic;
using UnityEngine;

public class PoolArrow : MonoBehaviour
{
    [SerializeField]
    private int _numberToSpawn;
    [SerializeField]
    private List<Projectile> _arrows;

    private void Start()
    {
        for (int i = 0; i < _arrows.Count; i++)
        {
            PoolManager.instance.QueueIntoPool<Projectile>(_arrows[i], _numberToSpawn);
        }
    }
}
