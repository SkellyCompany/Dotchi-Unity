using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{
	[SerializeField] private Dialogue _dialogue = default;
	[SerializeField] private Dotchi _dotchi = default;
	[SerializeField] private WebSocketController _webSocketController = default;
	private Animator _animator;
	private bool _isReadyToHatch;
	private TimedTask _timedTask;

	public string MotherId { get; private set; }

	void Awake()
	{
		_animator = GetComponent<Animator>();
		MotherId = GetMacAddress();
	}

	public void StartHatching()
	{
		_timedTask = TimedTasksManager.Instance.StartTimedTask(180, "Egg");
		_timedTask.finished += ReadyToHatch;
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
			StartCoroutine(HttpController.Get($"https://dotchiapi.herokuapp.com/dotchi/mother/{MotherId}", a =>
			{
				_webSocketController.StartListening(a.dotchi_id);
			}));
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

	private string GetMacAddress()
	{
		string physicalAddress = "";
		NetworkInterface[] nice = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface adaper in nice)
		{
			Debug.Log(adaper.Description);
			if (adaper.Description == "en0")
			{
				physicalAddress = adaper.GetPhysicalAddress().ToString();
				break;
			}
			else
			{
				physicalAddress = adaper.GetPhysicalAddress().ToString();
				if (physicalAddress != "")
				{
					break;
				};
			}
		}
		physicalAddress = Regex.Replace(physicalAddress, ".{2}", "$0:");
		return physicalAddress.Remove(physicalAddress.Length - 1); ;
	}
}
