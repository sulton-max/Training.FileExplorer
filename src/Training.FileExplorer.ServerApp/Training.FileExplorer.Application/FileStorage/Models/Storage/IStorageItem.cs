namespace Training.FileExplorer.Application.FileStorage.Models.Storage;

public interface IStorageItem
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}