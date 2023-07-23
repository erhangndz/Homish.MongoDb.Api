using DtoLayer.DTOS.CityDtos;
using DtoLayer.DTOS.ContactDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateContactViewModel
    {
        public UpdateContactDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
