using Training.FileExplorer.Application.Common.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    ValueTask<IList<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath, FilterPagination paginationOptions);

    ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath);
}