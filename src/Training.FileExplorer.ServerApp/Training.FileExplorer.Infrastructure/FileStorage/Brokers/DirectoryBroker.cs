using AutoMapper;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    private readonly IMapper _mapper;

    public DirectoryBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath) => Directory.EnumerateDirectories(directoryPath);

    public IEnumerable<string> GetFilesPath(string directoryPath) => Directory.EnumerateFiles(directoryPath);

    public IEnumerable<StorageDirectory> GetDirectories(string directoryPath) => GetDirectoriesPath(directoryPath)
        .Select(path => _mapper.Map<StorageDirectory>(new DirectoryInfo(path)));

    public StorageDirectory GetByPathAsync(string directoryPath) => _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath));

    public bool ExistsAsync(string directoryPath) => Directory.Exists(directoryPath);
}