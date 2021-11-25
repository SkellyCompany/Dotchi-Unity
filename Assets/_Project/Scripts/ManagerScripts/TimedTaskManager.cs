using Demonics.Manager;
using System;
using System.Collections.Generic;

public class TimedTasksManager : Singleton<TimedTasksManager>
{
	private readonly List<TimedTask> _timedTasks = new List<TimedTask>();

	
	public void StartTimedTask(TimedTask timedTask)
	{
		timedTask.finished += () => _timedTasks.RemoveAll(e => e == timedTask);
		_timedTasks.Add(timedTask);
	}

	void Update()
	{
		for (int i = 0; i < _timedTasks.Count; i++)
		{
			var dateDifference = DateTime.Now - _timedTasks[i].StartDate;
			if (dateDifference.Minutes >= _timedTasks[i].Minutes)
			{
				_timedTasks[i].finished?.Invoke();
			}
		}
	}
}
