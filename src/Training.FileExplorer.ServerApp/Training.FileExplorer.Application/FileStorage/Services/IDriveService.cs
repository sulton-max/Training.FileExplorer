using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IList<StorageDrive>> GetAsync();
}