using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.TeamDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : CustomBaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _teamService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamDto createTeamDto)
        {
            var value = await _teamService.CreateAsync(createTeamDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var value = await _teamService.UpdateAsync(updateTeamDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(string id)
        {
            var value = await _teamService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTeam(string id)
        {
            var value = await _teamService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
