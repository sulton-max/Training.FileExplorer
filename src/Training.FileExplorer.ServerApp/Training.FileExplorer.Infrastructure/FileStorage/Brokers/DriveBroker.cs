using AutoMapper;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<StorageDriveInfo> Get()
    {
        return DriveInfo
            .GetDrives()
            .Select(drive => _mapper.Map<StorageDriveInfo>(drive))
            .AsQueryable();
    }
}