using System.Collections;
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
            PoolSystem.instance.QueueIntoPool<Projectile>(_arrows[i], _numberToSpawn);
        }
    }
}
