using UnityEngine;

public class Dotchi : MonoBehaviour
{
	[SerializeField] private DotchiAnimator _dotchiAnimator = default;
	[SerializeField] private DotchiStatsUI _dotchiStatsUI = default;
	private Rigidbody2D _rigidbody;
	private int _hunger = 10;
	private int _happiness = 10;
	private int _sleepyness = 10;
	public Vector2 MovementInput { get; set; }


	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(3600, "Hunger");
		timedTask.finished += LoseHunger;
	}

	void Update()
	{
		Movement();
	}

	private void Movement()
	{
		_rigidbody.velocity = MovementInput * 2;
		if (_rigidbody.velocity == Vector2.zero)
		{
			_dotchiAnimator.IdleAnimation();
		}
		else
		{
			_dotchiAnimator.WalkAnimation();
		}
	}

	private void LoseHunger()
	{
		_hunger--;
		_dotchiStatsUI.SetHunger(_hunger);
		TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(3600, "Hunger");
		timedTask.finished += LoseHunger;
	}
}
