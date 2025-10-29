using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TimerController timerController;

    private void OnEnable()
    {
        timerController.OnTimeChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        timerController.OnTimeChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(float time)
    {
        timerText.text = $"{Mathf.CeilToInt(time)}s";
    }
}