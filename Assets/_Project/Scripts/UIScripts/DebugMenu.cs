using Demonics.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugMenu : BaseMenu
{
	[SerializeField] private Transform _timedTasksContainer = default;
	[SerializeField] private Button _measuremeantsButton = default;
	[SerializeField] private Button _statsButton = default;
	[SerializeField] private GameObject _timedTaskOptionPrefab = default;
	[SerializeField] private TextMeshProUGUI _temperatureText = default;
	[SerializeField] private TextMeshProUGUI _lightText = default;
	[SerializeField] private TextMeshProUGUI _soundText = default;
	[SerializeField] private TextMeshProUGUI _sleepinessText = default;
	[SerializeField] private TextMeshProUGUI _happinessText = default;
	[SerializeField] private TextMeshProUGUI _hungerText = default;
	[SerializeField] private TextMeshProUGUI _macAddressText = default;
	private WorldStats _worldStats;
	private DotchiStatsUI _dotchiStatsUI;


	void Awake()
	{
		_dotchiStatsUI = FindObjectOfType<DotchiStatsUI>();
		if (_dotchiStatsUI == null)
		{
			_statsButton.gameObject.SetActive(false);
		}
		else
		{
			_statsButton.gameObject.SetActive(true);
		}
		_worldStats = FindObjectOfType<WorldStats>();
		if (_worldStats == null)
		{
			_measuremeantsButton.gameObject.SetActive(false);
		}
		else
		{
			_measuremeantsButton.gameObject.SetActive(true);
		}
		Egg egg = FindObjectOfType<Egg>();
		if (egg != null)
		{
			_macAddressText.text = egg.MotherId;
		}
		TimedTasksManager.Instance.taskFinished += LoadTimedTasks;
		LoadTimedTasks();
	}

	private void LoadTimedTasks()
	{
		if (SceneManager.GetSceneByName("DebugScene").isLoaded && _timedTasksContainer != null)
		{
			foreach (Transform timedTaskOption in _timedTasksContainer)
			{
				timedTaskOption.gameObject.SetActive(false);
			}
		}
	
		List<TimedTask> timedTasks = TimedTasksManager.Instance.TimedTasks;
		for (int i = 0; i < timedTasks.Count; i++)
		{
			AddTimedTask(timedTasks[i]);
		}
	}

	public void AddTimedTask(TimedTask timedTask)
	{
		if (_timedTasksContainer == null)
		{
			Debug.Log("empty");
		}
		TimedTaskOption timedTaskOption = Instantiate(_timedTaskOptionPrefab, _timedTasksContainer).GetComponent<TimedTaskOption>();
		timedTaskOption.SetTimedTask(timedTask);
	}

	public void SetTemperature(float value)
	{
		_worldStats.SetTemperature(value);
		_temperatureText.text = $"Temperature: {Mathf.Round(value)}";
	}

	public void SetLight(float value)
	{
		_worldStats.SetLight(value);
		_lightText.text = $"Light: {Mathf.Round(value)}";
	}

	public void SetSound(float value)
	{
		//_worldStats.SetTemperature(value);
		_soundText.text = $"Sound: {Mathf.Round(value)}";
	}

	public void SetSleepiness(float value)
	{
		_dotchiStatsUI.SetSleepiness(value);
		_sleepinessText.text = $"Sleepiness: {value}";
	}

	public void SetHappiness(float value)
	{
		_dotchiStatsUI.SetHappiness(value);
		_happinessText.text = $"Happiness: {value}";
	}

	public void SetHunger(float value)
	{
		_dotchiStatsUI.SetHealth(value);
		_hungerText.text = $"Hunger: {value}";
	}
}
