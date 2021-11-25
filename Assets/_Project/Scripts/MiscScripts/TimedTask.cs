using System;

public class TimedTask
{
	public Action finished;

	public DateTime StartDate { get; private set; }
	public int Minutes { get; private set; }
	public string Name { get; private set; }

	public TimedTask(int minutes, string name)
	{
		StartDate = DateTime.Now;
		Minutes = minutes;
		Name = name + "Task";
	}
}
