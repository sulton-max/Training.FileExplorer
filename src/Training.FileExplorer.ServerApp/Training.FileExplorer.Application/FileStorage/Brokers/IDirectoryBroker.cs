using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<IStorageItem> GetEntriesAsync(string path);
}