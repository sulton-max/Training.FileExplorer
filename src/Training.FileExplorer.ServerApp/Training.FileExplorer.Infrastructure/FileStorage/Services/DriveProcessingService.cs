using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DriveProcessingService : IDriveProcessingService
{
    private readonly IDriveService _driveService;
    private readonly IFileService _fileService;
    private readonly IDirectoryService _directoryService;

    public DriveProcessingService(IDriveService driveService, IFileService fileService, IDirectoryService directoryService)
    {
        _driveService = driveService;
        _fileService = fileService;
        _directoryService = directoryService;
    }

    public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string drivePath, StorageDriveEntryFilterModel filterModel)
    {
        var storageItems = new List<IStorageEntry>();

        if (filterModel.IncludeDirectories)
            storageItems.AddRange(await _directoryService.GetSubDirectoriesAsync(drivePath, filterModel));

        if (filterModel.IncludeFiles)
            storageItems.AddRange(await _fileService.GetFiles(drivePath, filterModel));

        return storageItems;
    }
}