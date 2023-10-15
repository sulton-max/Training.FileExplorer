using Training.FileExplorer.Application.Common.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageDriveEntryFilterModel : FilterPagination
{
    public string DriveLabel { get; set; } = string.Empty;

    public bool IncludeFiles { get; set; }

    public bool IncludeDirectories { get; set; }
}