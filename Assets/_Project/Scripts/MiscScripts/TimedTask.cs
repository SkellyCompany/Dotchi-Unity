using System;

public class TimedTask
{
	public Action finished;

	public DateTime StartDate { get; private set; }
	public float Time { get; private set; }
	public float RemainingTime { get; set; }
	public string Name { get; private set; }


	public TimedTask(float seconds, string name, DateTime dateTime = default)
	{
		if (dateTime == default)
		{
			StartDate = DateTime.Now;
		}
		else
		{
			StartDate = dateTime;
		}
		Time = seconds;
		Name = name + "Task";
	}
}
