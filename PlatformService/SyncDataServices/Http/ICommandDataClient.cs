﻿using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformtoCommand(PlatformReadDTO plat);
    }
}
