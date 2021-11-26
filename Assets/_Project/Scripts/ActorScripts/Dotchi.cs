using UnityEngine;

public class Dotchi : MonoBehaviour
{
	[SerializeField] private DotchiAnimator _dotchiAnimator = default;
	[SerializeField] private DotchiStatsUI _dotchiStatsUI = default;
	[SerializeField] private WorldStats _worldStats = default;
	private Rigidbody2D _rigidbody;
	private int _hunger = 10;
	private int _happiness = 10;
	private int _sleepiness = 10;
	public Vector2 MovementInput { get; set; }


	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		TimedTask timedTaskHunger = TimedTasksManager.Instance.StartTimedTask(3600, "LoseHunger");
		timedTaskHunger.finished += LoseHunger;
		TimedTask timedTaskSleepiness = TimedTasksManager.Instance.StartTimedTask(1600, "LoseSleepiness");
		timedTaskSleepiness.finished += LoseSleepiness;
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
		TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(3600, "LoseHunger");
		timedTask.finished += LoseHunger;
	}

	private void LoseHappiness()
	{
		_happiness--;
		_dotchiStatsUI.SetHappiness(_happiness);
		TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(3600, "LoseHappiness");
		timedTask.finished += LoseHappiness;
	}

	private void LoseSleepiness()
	{
		_sleepiness--;
		_dotchiStatsUI.SetSleepiness(_sleepiness);
		if (_sleepiness < 5 && _worldStats.Light <=0.25f || _sleepiness < 3 && _worldStats.Light <= 0.5f)
		{
			Sleep();
		}
		else
		{
			TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(3600, "LoseSleepiness");
			timedTask.finished += LoseSleepiness;
		}
	}

	private void GainSleepiness()
	{
		_sleepiness++;
		_dotchiStatsUI.SetSleepiness(_sleepiness);
		if (_sleepiness == 10)
		{
			WakeUp();
		}
		else
		{
			TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(1200, "GainSleepiness");
			timedTask.finished += GainSleepiness;
		}
	}

	private void Sleep()
	{
		_dotchiAnimator.SleepAnimation();
		_rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
		TimedTask timedTask = TimedTasksManager.Instance.StartTimedTask(1200, "GainSleepiness");
		timedTask.finished += GainSleepiness;
	}

	private void WakeUp()
	{
		_dotchiAnimator.WakeUpAnimation();
		_rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
	}

	void OnEnable()
	{
		_dotchiStatsUI.gameObject.SetActive(true);	
	}

	void OnDisable()
	{
		_dotchiStatsUI.gameObject.SetActive(false);
	}
}
