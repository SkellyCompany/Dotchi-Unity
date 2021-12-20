using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuController : MonoBehaviour
{
	private float _startTime;
	private float _endTime;
	private bool _isSceneLoaded;


	private void Start()
	{
		_isSceneLoaded = true;
		SceneManager.LoadScene("DebugScene", LoadSceneMode.Additive);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_startTime = Time.time;
		}
		if (Input.GetMouseButtonUp(0))
		{
			_endTime = Time.time;
		}

		if (_endTime - _startTime > 0.5f)
		{
			if (!_isSceneLoaded)
			{
				_isSceneLoaded = true;
				SceneManager.LoadScene("DebugScene", LoadSceneMode.Additive);
			}
			else
			{
				_isSceneLoaded = false;
				SceneManager.UnloadSceneAsync("DebugScene");
			}
			_startTime = 0.0f;
			_endTime = 0.0f;
		}
	}
}
