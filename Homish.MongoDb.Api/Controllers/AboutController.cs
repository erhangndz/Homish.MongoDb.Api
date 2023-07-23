using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.AboutDtos;
using EntityLayer.Concrete;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : CustomBaseController
    {
        private readonly IAboutService _aboutService;
        

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _aboutService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDto createAboutDto)
        {
            var value = await _aboutService.CreateAsync(createAboutDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value= await _aboutService.UpdateAsync(updateAboutDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var value= await _aboutService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(string id)
        {
            var value= await _aboutService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
