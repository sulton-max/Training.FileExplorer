﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IDriveService _driveService;

    public DrivesController(IMapper mapper, IDriveService driveService)
    {
        _mapper = mapper;
        _driveService = driveService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var data = await _driveService.GetAsync();
        var result = _mapper.Map<IEnumerable<StorageDrive>>(data);
        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{driveLabel}/entries")]
    public async ValueTask<IActionResult> GetDriveEntries([FromRoute] string driveLabel)
    {
        var data = await _driveService.GetDriveEntriesAsync(driveLabel);
        var result = _mapper.Map<IEnumerable<IStorageItem>>(data);
        return result.Any() ? Ok(result) : NoContent();
    }
}