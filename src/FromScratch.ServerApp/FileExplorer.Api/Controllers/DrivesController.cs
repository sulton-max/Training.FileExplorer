using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAsync([FromServices]IDriveBroker driveBroker)
    {
        var result = driveBroker.Get();
        return new ValueTask<IActionResult>(Ok(result));
    }
}