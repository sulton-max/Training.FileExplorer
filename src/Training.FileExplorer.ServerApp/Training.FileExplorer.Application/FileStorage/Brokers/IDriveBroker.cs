using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Application.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDriveInfo> Get();
}