namespace Training.FileExplorer.Api.Models;

public class DriveInfoDto
{
    public string Name { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string VolumeLabel { get; set; } = string.Empty;

    public long TotalSize { get; set; }

    public long AvailableFreeSpace { get; set; }

    public long TotalFreeSpace { get; set; }

    public ExplorerItemType ItemType { get; set; } = ExplorerItemType.Drive;
}