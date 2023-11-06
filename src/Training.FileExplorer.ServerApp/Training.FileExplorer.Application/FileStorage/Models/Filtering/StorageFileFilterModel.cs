using Training.FileExplorer.Application.Common.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageFileFilterModel : FilterPagination
{
    public string DirectoryPath { get; set; } = string.Empty;

    public ICollection<StorageFileType> FilesType { get; set; } = default!;
}