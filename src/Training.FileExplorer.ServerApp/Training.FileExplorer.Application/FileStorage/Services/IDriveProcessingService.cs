using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveProcessingService
{
    ValueTask<List<IStorageItem>> GetDriveEntriesAsync(string driveLabel);
}