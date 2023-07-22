using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.ContactDtos;
using Homish.MongoDb.Api.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homish.MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : CustomBaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _contactService.GetAllAsync();
            return CreateActionResultInstance(values);

        }

        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactDto createContactDto)
        {
            var value = await _contactService.CreateAsync(createContactDto);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = await _contactService.UpdateAsync(updateContactDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var value = await _contactService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdContact(string id)
        {
            var value = await _contactService.GetByIdAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
