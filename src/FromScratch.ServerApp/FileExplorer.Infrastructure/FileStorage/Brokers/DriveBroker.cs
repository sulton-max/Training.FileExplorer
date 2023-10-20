using AutoMapper;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<StorageDrive> Get()
    {
        return DriveInfo
            .GetDrives()
            .Select(driveInfo => _mapper.Map<StorageDrive>(driveInfo));
    }
}