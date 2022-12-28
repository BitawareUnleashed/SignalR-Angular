namespace SignalR.Server.Models;
public class TimerManager
{
    private Timer? _timer;
    private AutoResetEvent? _autoResetEvent;
    private Action? _action;
    public DateTime TimerStarted { get; set; }
    public bool IsTimerStarted { get; set; }
    public void PrepareTimer(Action action)
    {
        _action = action;
        _autoResetEvent = new AutoResetEvent(false);
        _timer = new Timer(Execute, _autoResetEvent, 100, 100);
        TimerStarted = DateTime.Now;
        IsTimerStarted = true;
    }
    public void Execute(object? stateInfo)
    {
        if (_action is null) return;
        _action();
    }
}

