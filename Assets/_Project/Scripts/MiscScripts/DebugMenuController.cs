#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuController : MonoBehaviour
{
    private bool _isSceneLoaded;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
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
        }
    }
}
#endif