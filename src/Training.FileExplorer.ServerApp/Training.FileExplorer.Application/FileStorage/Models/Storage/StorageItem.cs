namespace Training.FileExplorer.Application.FileStorage.Models.Storage;

public class StorageItem : IStorageItem
{
    public string Path { get; set; } = string.Empty;

    public StorageItemType ItemType { get; set; }
}