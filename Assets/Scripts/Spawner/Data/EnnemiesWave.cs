using Gameplay.Ennemies;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ennemies wave", menuName = "Data/Wave", order = 1)]
public class EnnemiesWave : ScriptableObject
{
    public float timeBetweenEnnemySpawn;
    public List<Ennemy> ennemies;
}