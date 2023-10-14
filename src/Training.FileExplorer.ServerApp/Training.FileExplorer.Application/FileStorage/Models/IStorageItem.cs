namespace Training.FileExplorer.Application.FileStorage.Models;

public interface IStorageItem
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}