using System.Runtime.InteropServices;
using AutoMapper;
using Training.FileExplorer.Application.Common.Models.Filtering;
using Training.FileExplorer.Application.Common.Querying.Extensions;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;
    private readonly IMapper _mapper;

    public DirectoryService(IDirectoryBroker broker, IMapper mapper)
    {
        _broker = broker;
        _mapper = mapper;
    }

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));
    }

    public async ValueTask<IList<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var testA = _broker.GetDirectoriesPath(directoryPath).ToList().Select(dir =>
        {
            try
            {
                var result = _broker.SetAccessControl(dir);
                var test = _broker.GetByPathAsync(dir);
                return test;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new StorageDirectory();
        }).ToList();

        var directories = await Task.Run(() =>
            _broker
                .GetDirectoriesPath(directoryPath)
                .ApplyPagination(paginationOptions)
                .Select(subDirectoryPath => _broker.GetByPathAsync(subDirectoryPath)));

            return directories.ToList();
    }
}