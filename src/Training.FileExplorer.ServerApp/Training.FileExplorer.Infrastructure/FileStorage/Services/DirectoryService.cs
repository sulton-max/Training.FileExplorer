using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;

    public DirectoryService(IDirectoryBroker broker)
    {
        _broker = broker;
    }

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));
    }

    public async ValueTask<IList<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var directories = await Task.Run(() =>
            _broker.GetDirectoriesPath(directoryPath).Select(subDirectoryPath => _broker.GetByPathAsync(subDirectoryPath)));

        return directories.ToList();
    }

    // public ValueTask<IQueryable<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath)
    // {
    //     if (string.IsNullOrWhiteSpace(directoryPath))
    //         throw new ArgumentNullException(nameof(directoryPath));
    //
    //     // var directoryInfo = new DirectoryInfo(directoryPath);
    //     if (!directoryInfo.Exists)
    //         throw new ArgumentException("Directory does not exist.", nameof(directoryPath));
    //
    //     // directoryInfo.GetDirectoriesPath().
    //
    //
    //     return _broker.GetDirectoriesPath(directoryPath);
    // }
}