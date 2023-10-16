using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IFileService _fileService;
    private readonly IDirectoryService _directoryService;

    public DirectoryProcessingService(IFileService fileService, IDirectoryService directoryService)
    {
        _fileService = fileService;
        _directoryService = directoryService;
    }

    public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDriveEntryFilterModel filterModel)
    {
        var storageItems = new List<IStorageEntry>();

        if (filterModel.IncludeDirectories)
            storageItems.AddRange(await _directoryService.GetSubDirectoriesAsync(directoryPath, filterModel));

        if (filterModel.IncludeFiles)
            storageItems.AddRange(await _fileService.GetFiles(directoryPath, filterModel));

        return storageItems;
    }
}