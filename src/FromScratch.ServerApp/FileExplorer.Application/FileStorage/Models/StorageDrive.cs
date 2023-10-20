namespace FileExplorer.Application.FileStorage.Models;

public class StorageDrive : IStorageEntry
{
    public string Name { get; set; } = string.Empty; // C

    public string Path { get; set; } = string.Empty; // C:\\

    public string Format { get; set; } = string.Empty; // NTFS, Fat32

    public string Type { get; set; } = string.Empty;

    public long TotalSpace { get; set; }

    public long FreeSpace { get; set; }

    public long UnavailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public StorageEntryType EntryType { get; set; } = StorageEntryType.Drive;
}