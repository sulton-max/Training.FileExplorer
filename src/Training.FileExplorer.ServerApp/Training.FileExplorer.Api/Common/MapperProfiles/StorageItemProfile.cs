using AutoMapper;
using Training.FileExplorer.Api.Models.Dtos;
using Training.FileExplorer.Application.FileStorage.Models;

namespace Training.FileExplorer.Api.Common.MapperProfiles;

public class StorageItemProfile : Profile
{
    public StorageItemProfile()
    {
        CreateMap<IStorageItem, IStorageItemDto>();
        CreateMap<IStorageItemDto, IStorageItem>();
    }
}