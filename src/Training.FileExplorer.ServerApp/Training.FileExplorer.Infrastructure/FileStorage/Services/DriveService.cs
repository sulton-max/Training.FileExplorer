using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _broker;
    private readonly IDirectoryBroker _directoryBroker;

    public DriveService(IDriveBroker broker, IDirectoryBroker directoryBroker)
    {
        _broker = broker;
        _directoryBroker = directoryBroker;
    }

    public ValueTask<IList<StorageDriveInfo>> GetAsync()
    {
        var drives = _broker.Get().ToList();

        return new ValueTask<IList<StorageDriveInfo>>(drives);
    }

    public ValueTask<IList<IStorageItem>> GetDriveEntriesAsync(string drivePath)
    {
        var entries = _directoryBroker.GetEntriesAsync(drivePath).ToList();

        return new ValueTask<IList<IStorageItem>>(entries);
    }
}