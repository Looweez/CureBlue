using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
    public AudioMixer masterMixer; 
    
    public void SetMasterVolume(float volume)
    {
        
        if (volume > 0f)
        {
            masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            masterMixer.SetFloat("MasterVolume", -80f); 
        }
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen set to: " + isFullscreen);
    }
    public void Start()
    {
        /*Slider volumeSlider = GetComponentInChildren<Slider>();
        if (volumeSlider != null)
        {
            SetMasterVolume(volumeSlider.value);
        }*/
        
        Slider volumeSlider = GetComponentInChildren<Slider>(true);

        if (volumeSlider != null)
        {
            
            SetMasterVolume(volumeSlider.value);

        }
    }
}
