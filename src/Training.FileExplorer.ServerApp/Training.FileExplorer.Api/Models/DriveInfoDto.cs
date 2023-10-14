namespace Training.FileExplorer.Api.Models;

public class DriveInfoDto
{
    public string Name { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string VolumeLabel { get; set; } = string.Empty;

    public long TotalSpace { get; set; }

    public long FreeSpace { get; set; }

    public long UnavailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public ExplorerItemType ItemType { get; set; } = ExplorerItemType.Drive;
}