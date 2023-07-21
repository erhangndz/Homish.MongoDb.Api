using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.BannerDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : CustomBaseController
    {
       private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _bannerService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddBanner(CreateBannerDto createBannerDto)
        {
            var value = await _bannerService.CreateAsync(createBannerDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var value = await _bannerService.UpdateAsync(updateBannerDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBanner(string id)
        {
            var value = await _bannerService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdBanner(string id)
        {
            var value = await _bannerService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
