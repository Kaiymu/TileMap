using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField]
    private HealthBar _healthBar;

    [SerializeField]
    private int _HP;

    private void Start()
    {
        _healthBar.SetMaxValue(_HP);
    }

    public void Damage(int damage)
    {
        _HP -= damage;
        _healthBar.UpdateSlider(_HP);

        if (_HP <= 0)
        {
            _EndGame();
        }
    }

    private void _EndGame()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.LOOSE);
    }
}
