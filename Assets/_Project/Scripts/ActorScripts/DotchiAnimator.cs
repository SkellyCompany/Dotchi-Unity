using UnityEngine;

public class DotchiAnimator : MonoBehaviour
{
	private Animator _animator;


	void Awake()
	{
		_animator = GetComponent<Animator>();	
	}

	public void IdleAnimation()
	{
		_animator.SetTrigger("Idle");
	}

	public void WalkAnimation()
	{
		_animator.SetTrigger("Walk");
	}

	public void SleepAnimation()
	{
		_animator.SetTrigger("Sleep");
	}

	public void WakeUpAnimation()
	{
		_animator.SetTrigger("WakeUp");
	}
}
