using UnityEngine;

public class Player : MonoBehaviour
{
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
					interactable.Interact();
				}
			}
		}
	}
}
