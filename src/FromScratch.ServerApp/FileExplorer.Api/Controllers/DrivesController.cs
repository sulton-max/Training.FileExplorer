using FileExplorer.Application.FileStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAsync()
    {
        var drivesInfo = DriveInfo.GetDrives();

        var drive = drivesInfo.Select(driveInfo => new StorageDrive
        {
            Name = driveInfo.Name.Substring(0, driveInfo.Name.IndexOf(':')),
            Path = driveInfo.Name,
            Format = driveInfo.DriveFormat,
            Type = driveInfo.DriveType.ToString(),
            TotalSpace = driveInfo.TotalSize,
            FreeSpace = driveInfo.AvailableFreeSpace,
            UnavailableSpace = driveInfo.TotalFreeSpace - driveInfo.AvailableFreeSpace,
            UsedSpace = driveInfo.TotalSize - driveInfo.TotalFreeSpace
        });

        return new ValueTask<IActionResult>(Ok(drive));
    }
}