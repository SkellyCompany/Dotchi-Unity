using UnityEngine;

public class Egg : MonoBehaviour
{
	public void StartHatching()
	{
		TimedTask timedTask = new TimedTask(1, "Egg");
		timedTask.finished += Hatch;
		TimedTasksManager.Instance.StartTimedTask(timedTask);
	}

	private void Hatch()
	{
		Debug.Log("hatch");
	}
}
