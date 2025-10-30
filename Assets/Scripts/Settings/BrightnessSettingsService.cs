using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettingsService : MonoBehaviour, IBrightnessSettings
{
    [SerializeField] private Image brightnessOverlay;
    private const string BRIGHTNESS_PARAM = "Brightness";
    private float currentBrightness = 1f;

    public void SetBrightness(float value)
    {
        currentBrightness = Mathf.Clamp01(value);
        if (brightnessOverlay != null)
        {
            // Lower brightness means darker overlay
            Color c = brightnessOverlay.color;
            c.a = 1f - currentBrightness; 
            brightnessOverlay.color = c;
        }

        PlayerPrefs.SetFloat(BRIGHTNESS_PARAM, currentBrightness);
    }

    public float GetBrightness()
    {
        return PlayerPrefs.GetFloat(BRIGHTNESS_PARAM, 1f);
    }
}