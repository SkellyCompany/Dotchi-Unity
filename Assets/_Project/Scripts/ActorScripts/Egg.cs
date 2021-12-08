using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{
	[SerializeField] private Dialogue _dialogue = default;
	[SerializeField] private Dotchi _dotchi = default;
	private Animator _animator;
	private bool _isReadyToHatch;
	private TimedTask timedTask;

	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void StartHatching()
	{
		timedTask = TimedTasksManager.Instance.StartTimedTask(180, "Egg");
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
			StartCoroutine(HttpController.Post("http://localhost:3000/dotchi/", "hardcoded"));
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
