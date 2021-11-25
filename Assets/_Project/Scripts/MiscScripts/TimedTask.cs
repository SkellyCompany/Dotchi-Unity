using System;

public class TimedTask
{
	public Action finished;

	public DateTime StartDate { get; private set; }
	public float Time { get; private set; }
	public string Name { get; private set; }


	public TimedTask(float seconds, string name)
	{
		StartDate = DateTime.Now;
		Time = seconds;
		Name = name;
	}
}
