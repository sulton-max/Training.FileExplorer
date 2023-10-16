using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace Training.FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _broker;

    public DriveService(IDriveBroker broker)
    {
        _broker = broker;
    }

    public ValueTask<IList<StorageDrive>> GetAsync()
    {
        var drives = _broker.Get().ToList();

        return new ValueTask<IList<StorageDrive>>(drives);
    }
}