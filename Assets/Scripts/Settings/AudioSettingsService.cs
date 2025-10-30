using UnityEngine;
using UnityEngine.Audio;

public class AudioSettingsService : MonoBehaviour, IAudioSettings
{
    [SerializeField] private AudioMixer masterMixer;

    private const string MASTER_VOLUME_PARAM = "MasterVolume";
    private float currentVolume = 1f;

    public void SetMasterVolume(float value)
    {
        currentVolume = Mathf.Clamp01(value);
        float dB = Mathf.Log10(currentVolume <= 0 ? 0.0001f : currentVolume) * 20f;
        masterMixer.SetFloat(MASTER_VOLUME_PARAM, dB);
        PlayerPrefs.SetFloat(MASTER_VOLUME_PARAM, currentVolume);
    }

    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_PARAM, 1f);
    }
}