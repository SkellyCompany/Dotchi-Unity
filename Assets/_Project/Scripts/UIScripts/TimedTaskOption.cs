using TMPro;
using UnityEngine;

public class TimedTaskOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText = default;


    public void SetTimedTask(string name)
    {
        _nameText.text = name;
    }
}
