using Demonics.Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TimedTasksManager : Singleton<TimedTasksManager>
{
	public List<TimedTask> TimedTasks { get; private set; } = new List<TimedTask>();
	public Action taskFinished;


	void Start()
	{
		LoadTimedTasks();
	}

	private void LoadTimedTasks()
	{
	}

	public TimedTask StartTimedTask(float seconds, string name)
	{
		TimedTask timedTask = new TimedTask(seconds, name);
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
			TimedTasks[i].RemainingTime = secondsRemaining;
			if (secondsRemaining >= TimedTasks[i].Time)
			{
				TimedTasks[i].finished?.Invoke();
				taskFinished?.Invoke();
			}
		}
	}
}
