namespace Training.FileExplorer.Application.FileStorage.Models.Storage;

public class StorageFile : IStorageItem
{
    public string Path { get; set; }

    public StorageItemType ItemType { get; set; }
}