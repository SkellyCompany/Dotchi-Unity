using System.Collections;
using UnityEngine;

public class DotchiController : MonoBehaviour
{
    private Dotchi _dotchi;


    void Awake()
    {
        _dotchi = GetComponent<Dotchi>();
    }

    void Start()
    {
        StartCoroutine(MovementCoroutine());
    }

    IEnumerator MovementCoroutine()
    {
        float waitTime;
        while (true)
        {
            int movementRandom = Random.Range(0, 5);
            switch (movementRandom)
            {
                case 1:
                    _dotchi.MovementInput = Vector2.zero;
                    break;
                case 2:
                    _dotchi.MovementInput = new Vector2(0.0f, 1.0f);
                    break;
                case 3:
                    _dotchi.MovementInput = new Vector2(0.0f, -1.0f);
                    break;
                case 4:
                    _dotchi.MovementInput = new Vector2(1.0f, 0.0f);
                    break;
                case 5:
                    _dotchi.MovementInput = new Vector2(-1.0f, 0.0f);
                    break;
            }
            waitTime = Random.Range(1.0f, 1.75f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
