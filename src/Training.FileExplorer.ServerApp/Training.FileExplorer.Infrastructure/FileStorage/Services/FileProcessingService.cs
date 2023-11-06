using Training.FileExplorer.Application.Common.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class FileProcessingService : IFileProcessingService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public FileProcessingService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public async ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath)
    {
        var pagination = new FilterPagination
        {
            PageSize = int.MaxValue,
            PageToken = 1
        };

        var filesPath = _directoryService.GetFilesPath(directoryPath, pagination);
        var files = await _fileService.GetFilesByPathAsync(filesPath);
        
        var filesSummary = _fileService.GetFilesSummary(files);
        var filterDataModel = new StorageFileFilterDataModel
        {
            FilterData = filesSummary.ToList()
        };
        
        return filterDataModel;
    }

    public async ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel)
    {
        var filteredFilesPath = _directoryService
            .GetFilesPath(filterModel.DirectoryPath, filterModel)
            .Where(filePath => filterModel.FilesType.Contains(_fileService.GetFileType(filePath)));

        var files = await _fileService.GetFilesByPathAsync(filteredFilesPath);

        return files;
    }
}