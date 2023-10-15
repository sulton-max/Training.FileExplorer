namespace Training.FileExplorer.Application.Common.Models.Filtering;

public class FilterPagination : FilterModelBase
{
    public long PageSize { get; set; }

    public long PageToken { get; set; }
}