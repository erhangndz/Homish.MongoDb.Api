using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.PropertyDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : CustomBaseController
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _propertyService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreatePropertyDto createPropertyDto)
        {
            var value = await _propertyService.CreateAsync(createPropertyDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdatePropertyDto updatePropertyDto)
        {
            var value = await _propertyService.UpdateAsync(updatePropertyDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var value = await _propertyService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(string id)
        {
            var value = await _propertyService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
