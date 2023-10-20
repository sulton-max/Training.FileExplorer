using FileExplorer.Application.FileStorage.Models;

namespace FileExplorer.Application.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}