using FileExplorer.Application.FileStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    public DirectoriesController()
    {
    }

    [HttpGet("root/entries")]
    public ValueTask<IActionResult> GetRootEntriesAsync([FromServices] IWebHostEnvironment environment)
    {
        // ContentRootPath - bu project joylashgan folder
        // WebRootPath - static fayllar joylashgan folder
        var webRootPath = environment.WebRootPath;
        var contentRootPath = environment.ContentRootPath;

        var directoriesPath = Directory.EnumerateDirectories(webRootPath);

        var directories = directoriesPath
            .Select(directoryPath =>
        {
            var directory = new DirectoryInfo(directoryPath);

            return new StorageDirectory
            {
                Name = directory.Name,
                Path = directory.FullName,
                ItemsCount = directory.EnumerateFileSystemInfos().Count()
            };
        });

        // Ok methodi response status codini va response ni serializatsiya qiladi
        return new ValueTask<IActionResult>(Ok(directories));
    }

    [HttpGet("{directoryPath}/entries")]
    public ValueTask<IActionResult> GetDirectoryEntriesByPath([FromRoute] string directoryPath)
    {
        return new ValueTask<IActionResult>(Ok());
    }
}