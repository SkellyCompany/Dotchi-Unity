using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimedTaskOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText = default;
    [SerializeField] private TextMeshProUGUI _timeText = default;
    [SerializeField] private Button _finishedButton = default;


	public void SetTimedTask(TimedTask timedTask)
    {
        _nameText.text = timedTask.Name;
        _timeText.text = $"Time: {Mathf.Round(timedTask.RemainingTime)}/{Mathf.Round(timedTask.Time)}s";
        _finishedButton.onClick.AddListener(() => timedTask.finished.Invoke());
        _finishedButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

	void OnDestroy()
	{
        _finishedButton.onClick.RemoveAllListeners();
	}
}
