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
            TotalSpace = drive.TotalSize,
            FreeSpace = drive.AvailableFreeSpace,
            UnavailableSpace = drive.TotalFreeSpace - drive.AvailableFreeSpace,
            UsedSpace = drive.TotalSize - drive.TotalFreeSpace
        });

        return new ValueTask<IActionResult>(Ok(driveNames));
    }

    [HttpGet("{driveName}")]
    public ValueTask<IActionResult> GetDriveEntries([FromRoute]string driveName)
    {
        var directories = Directory.GetDirectories(driveName);
        var files = Directory.GetFiles(driveName);

    }

}