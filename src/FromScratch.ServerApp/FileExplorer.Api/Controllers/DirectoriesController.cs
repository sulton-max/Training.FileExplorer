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
        var filesPath = Directory.EnumerateFiles(webRootPath);

        var entries = new List<IStorageEntry>();

        var directories = directoriesPath.Select(directoryPath =>
        {
            var directory = new DirectoryInfo(directoryPath);

            return new StorageDirectory
            {
                Name = directory.Name,
                Path = directory.FullName,
                ItemsCount = directory.EnumerateFileSystemInfos().Count()
            };
        });

        var files = filesPath.Select(filePath =>
        {
            var file = new FileInfo(filePath);

            return new StorageFile()
            {
                Name = file.Name,
                Path = file.FullName,
                DirectoryPath = file.DirectoryName,
                Size = file.Length,
                Extension = file.Extension,
            };
        });

        entries.AddRange(directories);
        entries.AddRange(files);

        // Ok methodi response status codini va response ni serializatsiya qiladi
         return new ValueTask<IActionResult>(Ok(entries));
    }

    [HttpGet("{directoryPath}/entries")]
    public ValueTask<IActionResult> GetDirectoryEntriesByPath([FromRoute] string directoryPath)
    {
        var directoriesPath = Directory.EnumerateDirectories(directoryPath);
        var filesPath = Directory.EnumerateFiles(directoryPath);

        var entries = new List<IStorageEntry>();

        var directories = directoriesPath.Select(path =>
        {
            var directory = new DirectoryInfo(path);

            return new StorageDirectory
            {
                Name = directory.Name,
                Path = directory.FullName,
                ItemsCount = directory.EnumerateFileSystemInfos().Count()
            };
        });

        var files = filesPath.Select(filePath =>
        {
            var file = new FileInfo(filePath);

            return new StorageFile()
            {
                Name = file.Name,
                Path = file.FullName,
                DirectoryPath = file.DirectoryName,
                Size = file.Length,
                Extension = file.Extension,
            };
        });

        entries.AddRange(directories);
        entries.AddRange(files);

        // Ok methodi response status codini va response ni serializatsiya qiladi
        return new ValueTask<IActionResult>(Ok(entries));
    }
}