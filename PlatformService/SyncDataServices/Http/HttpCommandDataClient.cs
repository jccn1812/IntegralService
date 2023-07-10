﻿using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient( HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformtoCommand(PlatformReadDTO plat)
        {

            var httpContent = new StringContent
            (
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync($"{ _configuration["CommandService"]}", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync post Command service is OK");
            }
            else
            {
                Console.WriteLine("Sync post Command service NOT OK");
            }

        }
    }
}