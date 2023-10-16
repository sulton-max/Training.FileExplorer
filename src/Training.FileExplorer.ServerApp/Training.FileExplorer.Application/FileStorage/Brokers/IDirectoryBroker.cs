using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetDirectoriesPath(string directoryPath);

    IEnumerable<string> GetFilesPath(string directoryPath);

    StorageDirectory GetByPathAsync(string directoryPath);

    bool ExistsAsync(string directoryPath);

    bool SetAccessControl(string directoryPath);
}