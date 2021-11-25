using System;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WorldStats : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight = default;
    [SerializeField] private TextMeshProUGUI _timeText = default;
    [SerializeField] private TextMeshProUGUI _dateText = default;
    [SerializeField] private TextMeshProUGUI _temperatureText = default;

    void Update()
    {
        _timeText.text = DateTime.Now.ToString("HH:mm");
        _dateText.text = DateTime.Now.ToString("dd/MM/yyyy");
    }

    public void SetTemperature(float value)
    {
        float colorValue = (value * 5) / 255.0f;
        if (value > 20)
        {
            _globalLight.color = new Color(1.0f, colorValue, colorValue);
        }
        else
        {
            _globalLight.color = new Color(colorValue, colorValue, 1.0f);
        }
        _temperatureText.text = $"{Mathf.Round(value)}°C";
    }

    public void SetLight(float value)
    {
        _globalLight.intensity = value;
    }
}
