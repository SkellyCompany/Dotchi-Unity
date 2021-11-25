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
	[SerializeField] private GameObject _timedTaskOptionPrefab = default;
	[SerializeField] private TextMeshProUGUI _temperatureText = default;
	[SerializeField] private TextMeshProUGUI _lightText = default;
	[SerializeField] private TextMeshProUGUI _soundText = default;
	private WorldStats _worldStats;


	void Awake()
	{
		_worldStats = FindObjectOfType<WorldStats>();
		if (_worldStats == null)
		{
			_measuremeantsButton.gameObject.SetActive(false);
		}
		else
		{
			_measuremeantsButton.gameObject.SetActive(true);
		}
		TimedTasksManager.Instance.taskFinished += LoadTimedTasks;
		LoadTimedTasks();
	}

	private void LoadTimedTasks()
	{
		if (SceneManager.GetSceneByName("DebugScene").isLoaded)
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
}
