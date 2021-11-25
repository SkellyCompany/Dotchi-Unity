using UnityEngine;
using UnityEngine.UI;

public class DotchiStatsUI : MonoBehaviour
{
    [SerializeField] private Slider _hungerSlider = default;
    [SerializeField] private Slider _happinessSlider = default;
    [SerializeField] private Slider _sleepinessSlider = default;


    public void SetHunger(float value)
    {
        _hungerSlider.value = value;
    }

    public void SetHappiness(float value)
    {
        _happinessSlider.value = value;
    }

    public void SetSleepyness(float value)
    {
        _sleepinessSlider.value = value;
    }
}
