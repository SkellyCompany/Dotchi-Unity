using UnityEngine;

public class Dotchi : MonoBehaviour
{
	[SerializeField] private DotchiAnimator _dotchiAnimator = default;
	[SerializeField] private DotchiStatsUI _dotchiStatsUI = default;
	[SerializeField] private WorldStats _worldStats = default;
	private Rigidbody2D _rigidbody;
	private float _health;
	private float _happiness;
	private float _sleepiness;
	public Vector2 MovementInput { get; set; }


	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
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

	public void SetHealth(float health)
	{
		_health = health;
		_dotchiStatsUI.SetHealth(_health);
	}


	public void SetHappiness(float happiness)
	{
		_happiness = happiness;
		_dotchiStatsUI.SetHappiness(_happiness);
	}

	private void Sleep()
	{
		_dotchiAnimator.SleepAnimation();
		_rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
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
