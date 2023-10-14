using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IList<StorageDriveInfo>> GetAsync();

    ValueTask<IList<IStorageItem>> GetDriveEntriesAsync(string drivePath);
}