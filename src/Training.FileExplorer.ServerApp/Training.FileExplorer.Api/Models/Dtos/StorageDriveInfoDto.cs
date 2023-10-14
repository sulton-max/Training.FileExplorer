using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Api.Models.Dtos;

public class StorageDriveInfoDto
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public long TotalSpace { get; set; }

    public long FreeSpace { get; set; }

    public long UnavailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public StorageItemType ItemType { get; set; }
}