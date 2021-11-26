using Demonics.Sounds;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Audio _audio;

	void Awake()
	{
		_audio = GetComponent<Audio>();
	}

	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.collider.TryGetComponent(out IInteractable interactable))
				{
					_audio.Sound("Click").Play();
					interactable.Interact();
				}
			}
		}
	}
}
