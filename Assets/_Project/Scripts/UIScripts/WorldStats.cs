using System;
using TMPro;
using UnityEngine;

public class WorldStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText = default;
    [SerializeField] private TextMeshProUGUI _dateText = default;
    [SerializeField] private TextMeshProUGUI _temperatureText = default;


    void Update()
    {
        _timeText.text = DateTime.Now.ToString("HH:mm");
        _dateText.text = DateTime.Now.ToString("dd/MM/yyyy");
    }
}
