using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float startTime = 60f;
    private ITimer timer;
    public GameObject LosePanel;

    public ITimer Timer => timer;

    public event System.Action<float> OnTimeChanged;

    private void Awake()
    {
        Time.timeScale = 1f;
        timer = new CountdownTimer();
        (timer as CountdownTimer).OnTimerEnd += HandleTimerEnd;
    }

    private void Start()
    {
        timer.StartTimer(startTime);
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
        OnTimeChanged?.Invoke(timer.CurrentTime);
        
        if (timer.CurrentTime <= 15f && timer.IsRunning)
            AudioManager.Instance.SpeedUpMusic();
    }

    private void HandleTimerEnd()
    {
        FindObjectOfType<GameManager>()?.LoseLevel();
        
        Time.timeScale = 0f;
        if (LosePanel != null)
        {
            LosePanel.SetActive(true);
        }
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}