using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip mainMusic;
    [SerializeField] private AudioClip valveCleaned;
    [SerializeField] private AudioClip cageUnlocked;
    [SerializeField] private AudioClip fishFreed;
    [SerializeField] private AudioClip seaweedTangle;
    [SerializeField] private AudioClip gameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicSource.clip = mainMusic;
        musicSource.Play();
    }

    public void PlaySFX(string key)
    {
        AudioClip clip = key switch
        {
            "ValveCleaned" => valveCleaned,
            "CageUnlocked" => cageUnlocked,
            "FishFreed" => fishFreed,
            "SeaweedTangle" => seaweedTangle,
            "GameOver" => gameOver,
            _ => null
        };
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void SpeedUpMusic()
    {
        musicSource.pitch = 1.25f;
    }

    public void ResetMusicSpeed()
    {
        musicSource.pitch = 1f;
    }
}