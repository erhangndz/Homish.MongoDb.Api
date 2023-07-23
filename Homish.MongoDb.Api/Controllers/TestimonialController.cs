using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.TestimonialDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : CustomBaseController
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _testimonialService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = await _testimonialService.CreateAsync(createTestimonialDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = await _testimonialService.UpdateAsync(updateTestimonialDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            var value = await _testimonialService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTestimonial(string id)
        {
            var value = await _testimonialService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
