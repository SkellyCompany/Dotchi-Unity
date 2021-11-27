using Demonics.Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TimedTasksManager : Singleton<TimedTasksManager>
{
	public List<TimedTask> TimedTasks { get; private set; } = new List<TimedTask>();
	public Action taskFinished;


	public TimedTask StartTimedTask(float seconds, string name)
	{
		TimedTask timedTask = new TimedTask(seconds, name);
		float storedTime = PlayerPrefs.GetFloat(timedTask.Name, 0);
		timedTask.StoredTime = storedTime;
		timedTask.finished += () => TimedTasks.RemoveAll(e => e == timedTask);
		TimedTasks.Add(timedTask);
		taskFinished?.Invoke();
		return timedTask;
	}

	void Update()
	{
		for (int i = 0; i < TimedTasks.Count; i++)
		{
			float secondsRemaining = (float)(DateTime.Now - TimedTasks[i].StartDate).TotalSeconds;
			TimedTasks[i].RemainingTime = secondsRemaining + TimedTasks[i].StoredTime;
			if (TimedTasks[i].RemainingTime >= TimedTasks[i].Time)
			{
				PlayerPrefs.SetFloat(TimedTasks[i].Name, 0);
				TimedTasks[i].finished?.Invoke();
				taskFinished?.Invoke();
			}
		}
	}

	void OnApplicationQuit()
	{
		for (int i = 0; i < TimedTasks.Count; i++)
		{
			PlayerPrefs.SetFloat(TimedTasks[i].Name	, TimedTasks[i].RemainingTime);
		}
	}
}
