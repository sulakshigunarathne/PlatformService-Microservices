using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatfromService.Data;
using PlatfromService.DTOs;

namespace PlatfromService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _repository;
        public PlatformController(IPlatformRepo repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting platforms...");

            var platformItem = _repository.GetAllPLatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }
    }

    
}
