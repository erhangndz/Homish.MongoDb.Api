using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.CityDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : CustomBaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _cityService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CreateCityDto createCityDto)
        {
            var value = await _cityService.CreateAsync(createCityDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(UpdateCityDto updateCityDto)
        {
            var value = await _cityService.UpdateAsync(updateCityDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCity(string id)
        {
            var value = await _cityService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCity(string id)
        {
            var value = await _cityService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
