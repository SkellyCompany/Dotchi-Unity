using Demonics.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenu : BaseMenu
{
	[SerializeField] private Transform _timedTasksContainer = default;
	[SerializeField] private GameObject _timedTaskOptionPrefab = default;


	void Awake()
	{
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
}
