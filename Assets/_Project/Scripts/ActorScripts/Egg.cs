using UnityEngine;

public class Egg : MonoBehaviour
{
	[SerializeField] private Dialogue _dialogue = default;
	private Animator _animator;


	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void StartHatching()
	{
		TimedTask timedTask = new TimedTask(180, "Egg");
		timedTask.finished += ReadyToHatch;
		TimedTasksManager.Instance.StartTimedTask(timedTask);
	}

	private void ReadyToHatch()
	{
		_dialogue.StartDialogue("DotchiIntroduction2");
		_animator.SetTrigger("StartHatching");
	}
}
