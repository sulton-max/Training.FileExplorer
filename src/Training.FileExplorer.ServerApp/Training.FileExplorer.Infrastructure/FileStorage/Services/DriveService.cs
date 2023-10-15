using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _broker;
    // private readonly IDirectoryBroker _directoryBroker;

    public DriveService(IDriveBroker broker)
    {
        _broker = broker;
        // _directoryBroker = directoryBroker;
    }

    public ValueTask<IList<StorageDrive>> GetAsync()
    {
        var drives = _broker.Get().ToList();

        return new ValueTask<IList<StorageDrive>>(drives);
    }

    // public async ValueTask<IList<IStorageItem>> GetDriveEntriesAsync(string driveLabel)
    // {
    //     if (string.IsNullOrWhiteSpace(driveLabel))
    //         throw new ArgumentNullException(nameof(driveLabel));
    //
    //     var drive = (await GetAsync()).SingleOrDefault(d => d.Path.StartsWith(driveLabel)) ?? throw new InvalidOperationException();
    //     var entries =  _directoryBroker.GetEntries(drive.Path).ToList();
    //
    //     return entries;
    // }
}