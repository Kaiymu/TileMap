using Gameplay.Ennemies;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState { NONE, WIN, LOOSE, PLAYING, START}

    private GameState _GAMESTATE;

    public delegate void State(GameState gameState);
    public event State state;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject.transform);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [HideInInspector]
    public List<Ennemy> ennemyList;

    public List<Ennemy> GetActiveEnnemies()
    {
        var tempList = new List<Ennemy>();
        for(int i = 0; i < ennemyList.Count; i++)
        {
            if (ennemyList[i].gameObject.activeInHierarchy)
            {
                tempList.Add(ennemyList[i]);
            }
        }

        return tempList;
    }

    public void UpdateGameState(GameState gameState)
    {
        if(gameState != _GAMESTATE)
        {
            _GAMESTATE = gameState;
            state(gameState);
        }
    }
}
