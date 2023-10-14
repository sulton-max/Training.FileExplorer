using AutoMapper;
using Training.FileExplorer.Api.Models.Dtos;
using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Api.Common.MapperProfiles;

public class DriveProfile : Profile
{
    public DriveProfile()
    {
        CreateMap<StorageDriveInfoDto, StorageDriveInfo>();
        CreateMap<StorageDriveInfo, StorageDriveInfoDto>();
    }
}