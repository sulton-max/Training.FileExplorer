using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Api.Models;

namespace Training.FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> Get()
    {
        var drives = DriveInfo.GetDrives();
        var driveNames = drives.Select(drive => new DriveInfoDto
        {
            Name = drive.Name,
            Format = drive.DriveFormat,
            Type = drive.DriveType.ToString(),
            VolumeLabel = drive.VolumeLabel,
            TotalSize = drive.TotalSize,
            AvailableFreeSpace = drive.AvailableFreeSpace,
            TotalFreeSpace = drive.TotalFreeSpace
        });

        return new ValueTask<IActionResult>(Ok(driveNames));
    }
}