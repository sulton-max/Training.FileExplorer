using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveProcessingService
{
    ValueTask<List<IStorageEntry>> GetEntriesAsync(string drivePath, StorageDriveEntryFilterModel filterModel);
}