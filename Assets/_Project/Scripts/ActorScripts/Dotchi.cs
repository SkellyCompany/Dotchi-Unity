using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dotchi : MonoBehaviour
{
	//[SerializeField] private DochiAnimator _dochiAnimator = default;
	private Rigidbody2D _rigidbody;

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
			//_dochiAnimator.IdleAnimation();
		}
		else
		{
			//_dochiAnimator.RunAnimation();
		}
	}
}
