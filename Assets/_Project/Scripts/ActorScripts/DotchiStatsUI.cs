using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DotchiStatsUI : MonoBehaviour
{
    [SerializeField] private Slider _hungerSlider = default;
    [SerializeField] private Slider _happinessSlider = default;
    [SerializeField] private Slider _sleepinessSlider = default;
    [SerializeField] private Image _hungerImage = default;
    [SerializeField] private Image _happinessImage = default;
    [SerializeField] private Image _sleepinessImage = default;
    [SerializeField] private Image _hungerDangerImage = default;
    [SerializeField] private Image _happinessDangerImage = default;
    [SerializeField] private Image _sleepinessDangerImage = default;
    private Coroutine _hungerIconDangerCoroutine;
    private Coroutine _happinessIconDangerCoroutine;
    private Coroutine _sleepIconDangerCoroutine;


    public void SetHunger(float value)
    {
        _hungerSlider.value = value;
        StopStatIconDangerCoroutine(_hungerIconDangerCoroutine, _hungerImage, _hungerDangerImage);
        if (value < 5)
        {
            _hungerIconDangerCoroutine = StartCoroutine(StatIconDangerCoroutine(_hungerImage, _hungerDangerImage));
        }
    }

    public void SetHappiness(float value)
    {
        _happinessSlider.value = value;
        StopStatIconDangerCoroutine(_happinessIconDangerCoroutine, _happinessImage, _happinessDangerImage);
        if (value < 5)
        {
            _happinessIconDangerCoroutine = StartCoroutine(StatIconDangerCoroutine(_happinessImage, _happinessDangerImage));
        }
    }

    public void SetSleepiness(float value)
    {
        _sleepinessSlider.value = value;
        StopStatIconDangerCoroutine(_sleepIconDangerCoroutine, _sleepinessImage, _sleepinessDangerImage);
        if (value < 5)
        {
            _sleepIconDangerCoroutine = StartCoroutine(StatIconDangerCoroutine(_sleepinessImage, _sleepinessDangerImage));
        }
    }

    IEnumerator StatIconDangerCoroutine(Image statIconImage, Image statIconDangerImage)
    {
        while (true)
        {
            statIconImage.gameObject.SetActive(false);
            statIconDangerImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            statIconImage.gameObject.SetActive(true);
            statIconDangerImage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void StopStatIconDangerCoroutine(Coroutine coroutine, Image statIconImage, Image statIconDangerImage)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            statIconImage.gameObject.SetActive(true);
            statIconDangerImage.gameObject.SetActive(false);
        }
    }
}
