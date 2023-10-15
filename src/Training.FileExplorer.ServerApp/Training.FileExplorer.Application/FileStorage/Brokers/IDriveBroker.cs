using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}