using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{
	[SerializeField] private Dialogue _dialogue = default;
	private Animator _animator;
	private bool _isReadyToHatch;


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
		_isReadyToHatch = true;
		_dialogue.StartDialogue("DotchiIntroduction2");
		_animator.SetTrigger("StartHatching");
	}

	private void Hatch()
	{
		if (_isReadyToHatch)
		{
			_isReadyToHatch = false;
			Debug.Log("hatch");
		}
	}

	public void Interact()
	{
		Hatch();
	}
}
