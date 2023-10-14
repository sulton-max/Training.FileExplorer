using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Api.Models.Dtos;

public interface IStorageItemDto
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}