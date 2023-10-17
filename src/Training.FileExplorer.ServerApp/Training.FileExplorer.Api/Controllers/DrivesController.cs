using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IDriveService _driveService;
    private readonly IDriveProcessingService _driveProcessingService;

    public DrivesController(IMapper mapper, IDriveService driveService, IDriveProcessingService driveProcessingService, IWebHostEnvironment webHostEnvironment)
    {
        _mapper = mapper;
        _driveService = driveService;
        _driveProcessingService = driveProcessingService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var data = await _driveService.GetAsync();
        var result = _mapper.Map<IEnumerable<StorageDrive>>(data);
        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{drivePath}/entries")]
    public async ValueTask<IActionResult> GetDriveEntries([FromRoute] string drivePath, [FromQuery] StorageDriveEntryFilterModel filterModel)
    {
        var data = await _driveProcessingService.GetEntriesAsync(drivePath, filterModel);
        var result = _mapper.Map<IEnumerable<IStorageEntry>>(data);
        return result.Any() ? Ok(result) : NoContent();
    }
}