using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class MappingConfig
    {
        public static MapperConfiguration RegistwerMaps()
        {
            var mappingConfig = new MapperConfiguration
            (
                config =>
                        {
                            config.CreateMap<Platform, PlatformDTO>();
                            config.CreateMap<PlatformToWrite, Platform>();
                            ;

                        }
            );

        }

    }
}
