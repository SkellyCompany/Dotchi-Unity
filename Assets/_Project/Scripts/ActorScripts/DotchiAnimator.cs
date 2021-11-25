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
}
