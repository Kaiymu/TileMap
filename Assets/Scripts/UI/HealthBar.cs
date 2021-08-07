using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    public void SetMaxValue(int maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    public void UpdateSlider(int value)
    {
        _slider.value = value;
    }
}
