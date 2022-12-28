using Microsoft.AspNetCore.SignalR;

namespace SignalR.Server.Models;

public class ChartModel
{
    public int Data { get; set; }
    public string? Label { get; set; }
    public string? BackgroundColor { get; set; }

    public ChartModel()
    {
        //Data = new List<int>();
    }
}

public class ChartHub : Hub
{
}