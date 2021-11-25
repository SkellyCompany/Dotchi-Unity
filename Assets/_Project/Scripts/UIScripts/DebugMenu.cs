using Demonics.UI;
using UnityEngine;

public class DebugMenu : BaseMenu
{
	[SerializeField] private Transform _timedTasksContainer = default;
	[SerializeField] private GameObject _timedTaskOptionPrefab = default;


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			AddTimedTask();
		}
	}

	public void AddTimedTask()
	{
		TimedTaskOption timedTaskOption = Instantiate(_timedTaskOptionPrefab, _timedTasksContainer).GetComponent<TimedTaskOption>();
		timedTaskOption.SetTimedTask("egg");
	}
}
