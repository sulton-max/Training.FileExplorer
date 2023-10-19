namespace FileExplorer.Application.FileStorage.Models;

public class StorageFile : IStorageEntry
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string? DirectoryPath { get; set; } = string.Empty;

    public long Size { get; set; }

    public string Extension { get; set; } = string.Empty;

    public StorageEntryType EntryType { get; set; } = StorageEntryType.File;
}