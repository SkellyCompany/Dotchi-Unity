using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimedTaskOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText = default;
    [SerializeField] private Button _finishedButton = default;


	public void SetTimedTask(TimedTask timedTask)
    {
        _nameText.text = timedTask.Name;
        _finishedButton.onClick.AddListener(() => timedTask.finished.Invoke());
        _finishedButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

	void OnDestroy()
	{
        _finishedButton.onClick.RemoveAllListeners();
	}
}
