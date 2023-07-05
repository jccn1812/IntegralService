using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Repository;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PlatformsController( IRepository repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
             var platformsItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformsItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById" )]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id) 
        { 
            var PlatformItem = _repository.GetPlatformById(id);
            if (PlatformItem != null) 
            {
              return Ok(_mapper.Map<PlatformReadDTO>(PlatformItem));
            }

            return NotFound();
        }

        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformWriteDTO platformCreateDtO) 
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDtO);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDTO>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }



    }
}
