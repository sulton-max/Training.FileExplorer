using Training.FileExplorer.Application.Common.Models.Filtering;
using Training.FileExplorer.Application.Common.Querying.Extensions;
using Training.FileExplorer.Application.FileStorage.Brokers;
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

    public async ValueTask<IList<StorageFile>> GetFiles(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        if (!_directoryBroker.ExistsAsync(directoryPath))
            throw new ArgumentException("Directory does not exist.", nameof(directoryPath));

        var files = await Task.Run(() =>
            _directoryBroker
                .GetFilesPath(directoryPath)
                .ApplyPagination(paginationOptions)
                .Select(filePath => _fileBroker.GetByPath(filePath)));

        return files.ToList();
    }
}