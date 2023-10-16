using AutoMapper;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class FileBroker : IFileBroker
{
    private readonly IMapper _mapper;

    public FileBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public StorageFile GetByPath(string filePath)
    {
        return _mapper.Map<StorageFile>(new FileInfo(filePath));
    }
}