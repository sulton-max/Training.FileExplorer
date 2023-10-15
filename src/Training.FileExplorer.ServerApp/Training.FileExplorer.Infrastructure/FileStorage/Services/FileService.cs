using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;
    private readonly IDirectoryBroker _directoryBroker;

    public FileService(IFileBroker fileBroker, IDirectoryBroker directoryBroker)
    {
        _fileBroker = fileBroker;
        _directoryBroker = directoryBroker;
    }

    public ValueTask<IList<StorageFile>> GetFiles(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        if (!_directoryBroker.ExistsAsync(directoryPath))
            throw new ArgumentException("Directory does not exist.", nameof(directoryPath));

        var files = _directoryBroker.GetFilesPath(directoryPath).Select(filePath => _fileBroker.GetByPath(filePath));

        return new ValueTask<IList<StorageFile>>(files.ToList());
    }
}