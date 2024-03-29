﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Server.Models;

namespace SignalR.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    private readonly IHubContext<ChartHub> _hub;
    private readonly TimerManager _timer;

    public ChartController(IHubContext<ChartHub> hub, TimerManager timer)
    {
        _hub = hub;
        _timer = timer;
    }
    [HttpGet]
    public IActionResult Get()
    {
        if (!_timer.IsTimerStarted)
            _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferData", DataManager.GetData()));
        return Ok(new { Message = "Request Completed" });
    }
}

