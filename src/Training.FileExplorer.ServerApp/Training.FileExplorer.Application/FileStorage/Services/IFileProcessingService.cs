using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IFileProcessingService
{
    ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath);

    ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel);
}