using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.WhatWedoDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatWedoController : CustomBaseController
    {
        private readonly IWhatWedoService _whatWedoService;

        public WhatWedoController(IWhatWedoService whatWedoService)
        {
            _whatWedoService = whatWedoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _whatWedoService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateWhatWedoDto createWhatWedoDto)
        {
            var value = await _whatWedoService.CreateAsync(createWhatWedoDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateWhatWedoDto updateWhatWedoDto)
        {
            var value = await _whatWedoService.UpdateAsync(updateWhatWedoDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var value = await _whatWedoService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAbout(string id)
        {
            var value = await _whatWedoService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
