using UnityEngine;

public interface ITimer
{
    float CurrentTime { get; }
    float MaxTime { get; }
    bool IsRunning { get; }

    void StartTimer(float duration);
    void StopTimer();
    void Tick(float deltaTime);
}

