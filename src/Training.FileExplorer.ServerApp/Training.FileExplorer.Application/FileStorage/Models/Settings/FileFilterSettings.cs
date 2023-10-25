namespace Training.FileExplorer.Application.FileStorage.Models.Settings;

public class FileFilterSettings
{
    public ICollection<FileExtensionSettings> FileExtensions { get; set; } = default!;
}