using Gameplay.Ennemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<EnnemiesWave> _wave;

    [SerializeField]
    private Waypoint _firstWaypoint;

    private Stack<EnnemiesWave> _stackWave = new Stack<EnnemiesWave>();
    private Stack<Ennemy> _stackEnnemies = new Stack<Ennemy>();

    private PoolSystem _poolEnnemy;

    private EnnemiesWave _currentWave;
    private float _timeOffset = 0;

    public void Awake()
    {
        for (int i = 0; i < _wave.Count; i++)
        {
            _stackWave.Push(_wave[i]);
        }

        _wave.Clear();
    }

    private void Start()
    {
        _poolEnnemy = PoolSystem.instance;
    }

    public void SpawnNewWave()
    {
        if (_stackWave.Count <= 0)
        {
            return;
        }

        _currentWave = _stackWave.Pop();
        _ResetCurrentEnnemies();
    }

    private void _ResetCurrentEnnemies()
    {
        for (int i = 0; i < _currentWave.ennemies.Count; i++)
        {
            _stackEnnemies.Push(_currentWave.ennemies[i]);
        }
    }

    void Update()
    {
        if (_currentWave == null)
            return;

        if (_stackWave.Count < 0)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.WIN);
            return;
        }

        _timeOffset += Time.deltaTime;

        if (_timeOffset > _currentWave.timeBetweenEnnemySpawn)
        {
            _timeOffset = 0f;
            _SpawnNextEnnemy();
        }
    }

    public bool CheckIfWaveIsFinished()
    {
        return (_stackEnnemies.Count == 0 && GameManager.instance.ennemyList.Count == 0);
    }

    private void _SpawnNextEnnemy()
    {
        if (_stackEnnemies.Count == 0)
        {
            return;
        }

        Ennemy ennemy = _GetAvailableEnnemy();

        ennemy.waypoint = _firstWaypoint;
        ennemy.transform.position = transform.position;
        ennemy.gameObject.SetActive(true);
    }
     
    private Ennemy _GetAvailableEnnemy()
    {
        var ennemyType = _stackEnnemies.Pop();

        if (ennemyType.GetType() == typeof(EnnemyBrute))
        {
            return _poolEnnemy.GetAvailable<EnnemyBrute>();
        }

        if (ennemyType.GetType() == typeof(EnnemyRunner))
        {
            return _poolEnnemy.GetAvailable<EnnemyRunner>();
        }

        return null;
    }
   
}
