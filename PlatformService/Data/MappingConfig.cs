 using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformWriteDTO, Platform>();

        }
    }
}
