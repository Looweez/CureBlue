using UnityEngine;

public class CountdownTimer : ITimer
{
    public float CurrentTime { get; private set; }
    public float MaxTime { get; private set; }
    public bool IsRunning { get; private set; }

    public event System.Action OnTimerEnd;

    public void StartTimer(float duration)
    {
        MaxTime = duration;
        CurrentTime = duration;
        IsRunning = true;
    }

    public void StopTimer()
    {
        IsRunning = false;
    }

    public void Tick(float deltaTime)
    {
        if (!IsRunning) return;

        CurrentTime -= deltaTime;
        if (CurrentTime <= 0f)
        {
            CurrentTime = 0f;
            IsRunning = false;
            OnTimerEnd?.Invoke();
        }
    }
}