using DB.Application.UseCases.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogsController : ControllerBase
{
    private readonly ILogService _logService;

    public LogsController(ILogService logService)
    {
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var logs = await _logService.GetAllAsync();

        return Ok(logs);
    }
}
