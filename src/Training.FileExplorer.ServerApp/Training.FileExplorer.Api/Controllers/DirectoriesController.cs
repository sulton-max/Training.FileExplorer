using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Api.Models.Dtos;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryService _directoryService;
    private readonly IDirectoryProcessingService _directoryProcessingService;
    private readonly IMapper _mapper;

    public DirectoriesController(IDirectoryService directoryService, IDirectoryProcessingService directoryProcessingService, IMapper mapper)
    {
        _directoryService = directoryService;
        _directoryProcessingService = directoryProcessingService;
        _mapper = mapper;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync(
        [FromQuery] StorageDriveEntryFilterModel filterModel,
        [FromServices] IWebHostEnvironment environment
    )
    {
        var data = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);
        return data.Any() ? Ok(data) : NoContent();
    }

    [HttpGet("{directoryPath}")]
    public async ValueTask<IActionResult> GetByPathAsync([FromRoute] string directoryPath)
    {
        var data = await _directoryService.GetByPathAsync(directoryPath);
        var result = data is not null ? _mapper.Map<StorageDirectoryDto>(data) : null;

        return result is not null ? Ok(result) : NoContent();
    }
}