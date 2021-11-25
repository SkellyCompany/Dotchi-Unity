using Demonics.Manager;
using System;
using System.Collections.Generic;

public class TimedTasksManager : Singleton<TimedTasksManager>
{
	public List<TimedTask> TimedTasks { get; private set; } = new List<TimedTask>();
	public Action taskFinished;


	public void StartTimedTask(TimedTask timedTask)
	{
		timedTask.finished += () => TimedTasks.RemoveAll(e => e == timedTask);
		TimedTasks.Add(timedTask);
		taskFinished?.Invoke();
	}

	void Update()
	{
		for (int i = 0; i < TimedTasks.Count; i++)
		{
			TimeSpan dateDifference = DateTime.Now - TimedTasks[i].StartDate;
			if (dateDifference.Seconds >= TimedTasks[i].Time)
			{
				TimedTasks[i].finished?.Invoke();
				taskFinished?.Invoke();
			}
		}
	}
}
