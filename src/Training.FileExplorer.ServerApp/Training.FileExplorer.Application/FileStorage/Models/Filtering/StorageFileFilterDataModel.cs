using Training.FileExplorer.Application.Common.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageFileFilterDataModel
{
    public List<StorageFilesSummary> FilterData { get; set; } = new();
}