using AutoMapper.QueryableExtensions;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    public IEnumerable<IStorageItem> GetEntriesAsync(string path)
    {
        var files = Directory
            .GetFiles(path)
            .Select(filePath => new StorageItem()
            {
                Path = filePath,
                ItemType = StorageItemType.File
            })
            .AsQueryable();

        var directories = Directory
            .GetDirectories(path)
            .Select(directoryPath => new StorageItem()
            {
                Path = directoryPath,
                ItemType = StorageItemType.Directory
            })
            .AsQueryable();

        return files.Concat(directories);
    }
}