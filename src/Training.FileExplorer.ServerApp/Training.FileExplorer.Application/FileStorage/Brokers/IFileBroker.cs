using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Brokers;

public interface IFileBroker
{
    // IEnumerable<string> GetFilesPath(string directoryPath);

    StorageFile GetByPath(string filePath);

    // bool ExistsAsync(string filePath);
}