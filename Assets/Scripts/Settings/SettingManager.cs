using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private AudioSettingsService audioService;
    [SerializeField] private BrightnessSettingsService brightnessService;

    public IAudioSettings Audio => audioService;
    public IBrightnessSettings Brightness => brightnessService;

    private void Awake()
    {
        // Apply saved values at startup
        audioService.SetMasterVolume(audioService.GetMasterVolume());
        brightnessService.SetBrightness(brightnessService.GetBrightness());
    }
}
