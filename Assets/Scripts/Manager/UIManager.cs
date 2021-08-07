using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textWave;

    private void Start()
    {
        GameManager.instance.state += _GameState;
        WaveManager.waveNumber += _WaveNumber;
    }

    private void _GameState(GameManager.GameState gameState)
    {
        _textWave.color = new Color(_textWave.color.r, _textWave.color.g, _textWave.color.b, 1f);

        if (gameState == GameManager.GameState.WIN)
        {
            _textWave.text = "You win !";
        } else if (gameState == GameManager.GameState.LOOSE)
        {
            _textWave.text = "You loose !";
        }
    }

    private void _WaveNumber(int waveNumber)
    {
        _textWave.color = new Color(_textWave.color.r, _textWave.color.g, _textWave.color.b, 1f);
        _textWave.text = "Wave : " + waveNumber;
        StartCoroutine(_FadeAfter());
    }

    private IEnumerator _FadeAfter()
    {
        yield return new WaitForSeconds(1f);
        _textWave.color = new Color(_textWave.color.r, _textWave.color.g, _textWave.color.b, 0f);
    }
}
