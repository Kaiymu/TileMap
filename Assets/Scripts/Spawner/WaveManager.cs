using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> _wave;

    private Queue<Wave> _waves = new Queue<Wave>();

    private Wave _currentWave;

    public delegate void Waves(int numberWave);
    public static event Waves waveNumber;

    private int _waveNumber;

    private void Awake()
    {
        for (int i = 0; i < _wave.Count; i++)
        {
            var wave = _wave[i];
            _waves.Enqueue(wave);
        }
    }

    private void Start()
    {
        _LaunchWave();
    }

    private void _LaunchWave()
    {
        if(_waves.Count == 0)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.WIN);
            return;
        }

        _currentWave = _waves.Dequeue();

        waveNumber(++_waveNumber);

        for (int i = 0; i < _currentWave.spawners.Count; i++)
        {
            var spawner = _currentWave.spawners[i];
            spawner.SpawnNewWave();
        }
    }

    private void Update()
    {
        AllWaveCompleted();
    }

    public void AllWaveCompleted()
    {
        int spawnerFinished = 0;
        for (int i = 0; i < _currentWave.spawners.Count; i++)
        {
            var spawner = _currentWave.spawners[i];
            if(spawner.CheckIfWaveIsFinished())
            {
                spawnerFinished++;
            }
        }

        if(spawnerFinished == _currentWave.spawners.Count)
        {
            _LaunchWave();
        }
    }

    // TODO ajouter un event pour savoir à quel wave nous sommes
    
    [Serializable]
    public class Wave
    {
        public string waveName;
        public List<Spawner> spawners = new List<Spawner>();
    }
}
