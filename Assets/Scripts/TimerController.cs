using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float startTime = 60f;
    private ITimer timer;

    public ITimer Timer => timer;

    public event System.Action<float> OnTimeChanged;

    private void Awake()
    {
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
        Debug.Log("Time’s up!");
        FindObjectOfType<GameManager>()?.LoseLevel();
    }
}