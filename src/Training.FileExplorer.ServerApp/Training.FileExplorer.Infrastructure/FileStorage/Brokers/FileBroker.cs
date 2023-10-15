using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class FileBroker : IFileBroker
{
    public StorageFile GetByPath(string filePath)
    {
        var fileInf = new FileInfo(filePath);

    }
}