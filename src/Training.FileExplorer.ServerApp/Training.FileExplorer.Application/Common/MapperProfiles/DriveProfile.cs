using AutoMapper;
using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Application.Common.MapperProfiles;

public class DriveProfile : Profile
{
    public DriveProfile()
    {
        CreateMap<DriveInfo, StorageDriveInfo>()
            .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.VolumeLabel))
            .ForMember(src => src.Path, opt => opt.MapFrom(dest => dest.Name))
            .ForMember(src => src.Format, opt => opt.MapFrom(dest => dest.DriveFormat))
            .ForMember(src => src.Type, opt => opt.MapFrom(dest => dest.DriveType))
            .ForMember(src => src.TotalSpace, opt => opt.MapFrom(dest => dest.TotalSize))
            .ForMember(src => src.FreeSpace, opt => opt.MapFrom(dest => dest.AvailableFreeSpace))
            .ForMember(src => src.UnavailableSpace, opt => opt.MapFrom(dest => dest.TotalFreeSpace - dest.AvailableFreeSpace))
            .ForMember(src => src.UsedSpace, opt => opt.MapFrom(dest => dest.TotalSize - dest.TotalFreeSpace))
    }
}