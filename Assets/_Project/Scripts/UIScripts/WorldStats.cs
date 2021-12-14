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
	public float Light { get; private set; } = 1.0f;


	void Update()
	{
		_timeText.text = DateTime.Now.ToString("HH:mm");
		_dateText.text = DateTime.Now.ToString("dd/MM/yyyy");
	}

	public void SetTemperature(float value)
	{
		float colorValue = value / 100;
		if (value >= 0)
		{
			_globalLight.color = Color.HSVToRGB(0.12f, colorValue, 1.0f);
		}
		else
		{
			_globalLight.color = Color.HSVToRGB(0.6f, Mathf.Abs(colorValue), 1.0f);
		}
		_temperatureText.text = $"{Mathf.Round(value)}°C";
	}

	public void SetLight(float value)
	{
		Light = value / 100.0f;
		_globalLight.intensity = Light;
	}

	public void SetHumidity(float value)
	{
		//To Do
	}

	public void SetSound(float value)
	{
		//To Do
	}
}
