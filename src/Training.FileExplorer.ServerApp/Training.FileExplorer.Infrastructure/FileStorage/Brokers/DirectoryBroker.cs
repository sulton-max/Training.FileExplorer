using AutoMapper;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    private readonly IMapper _mapper;

    public DirectoryBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath) => Directory.GetDirectories(directoryPath);

    public IEnumerable<string> GetFilesPath(string directoryPath) => Directory.GetFiles(directoryPath);

    public ValueTask<StorageDirectory> GetByPathAsync(string directoryPath) => new(_mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath)));

    public ValueTask<bool> ExistsAsync(string directoryPath) => new(Directory.Exists(directoryPath));
}