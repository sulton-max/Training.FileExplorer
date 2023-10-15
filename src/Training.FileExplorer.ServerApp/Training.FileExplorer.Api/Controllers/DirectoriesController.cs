using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Api.Models.Dtos;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryService _directoryService;
    private readonly IMapper _mapper;

    public DirectoriesController(IDirectoryService directoryService, IMapper mapper)
    {
        _directoryService = directoryService;
        _mapper = mapper;
    }

    [HttpGet("{directoryPath}")]
    public async ValueTask<IActionResult> GetByPathAsync([FromRoute] string directoryPath)
    {
        var data = await _directoryService.GetByPathAsync(directoryPath);
        var result = data is not null ? _mapper.Map<StorageDirectoryDto>(data) : null;

        return result is not null ? Ok(result) : NoContent();
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetEntriesAsync([FromRoute] string directoryPath)
    {
        var data = await _directoryService.GetEntriesAsync(directoryPath);
        var result = _mapper.Map<IEnumerable<IStorageItem>>(data);

        return result.Any() ? Ok(result) : NoContent();
    }
}