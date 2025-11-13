using System;

public interface IBooster
{
    bool IsActive { get; }

    public event Action<BoosterProgressEvent> OnProgressChanged;
    event Action OnActivated;
    event Action OnDeactivated;
    BoosterId BoosterId { get; }

    void Activate();
    void Tick();
    void Deactivate();
}

public struct BoosterProgressEvent
{
    public float Progress { get; }
    public float Duration { get; }
    public float RemainingTime { get; }

    public BoosterProgressEvent(float progress, float duration, float remainingTime)
    {
        Progress = progress;
        Duration = duration;
        RemainingTime = remainingTime;
    }
}
