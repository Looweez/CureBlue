using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private SettingManager settingsManager;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider brightnessSlider;

    private void Start()
    {
        // Load existing values
        masterVolumeSlider.value = settingsManager.Audio.GetMasterVolume();
        brightnessSlider.value = settingsManager.Brightness.GetBrightness();

        // Subscribe to slider changes
        masterVolumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
    }

    private void OnDestroy()
    {
        masterVolumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        brightnessSlider.onValueChanged.RemoveListener(OnBrightnessChanged);
    }

    private void OnVolumeChanged(float value)
    {
        settingsManager.Audio.SetMasterVolume(value);
    }

    private void OnBrightnessChanged(float value)
    {
        settingsManager.Brightness.SetBrightness(value);
    }
}