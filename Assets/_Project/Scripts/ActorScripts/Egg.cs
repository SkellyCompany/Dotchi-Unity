using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{
	[SerializeField] private Dialogue _dialogue = default;
	[SerializeField] private Dotchi _dotchi = default;
	private Animator _animator;
	private bool _isReadyToHatch;


	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void StartHatching()
	{
		float t = PlayerPrefs.GetFloat("Egg", 0);
		TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(180, "Egg");
		timedTask.finished += ReadyToHatch;
	}

	private void ReadyToHatch()
	{
		_isReadyToHatch = true;
		_dialogue.StartDialogue("DotchiIntroduction2");
		_animator.SetTrigger("StartHatching");
	}

	private void StartHatch()
	{
		if (_isReadyToHatch)
		{
			_isReadyToHatch = false;
			_animator.SetTrigger("Hatch");
		}
	}

	public void HatchAnimationEvent()
	{
		_dialogue.StartDialogue("DotchiIntroduction3");
		gameObject.SetActive(false);
		_dotchi.gameObject.SetActive(true);
	}

	public void Interact()
	{
		StartHatch();
	}
}
