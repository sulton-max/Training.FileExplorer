using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFiles(string directoryPath);
}