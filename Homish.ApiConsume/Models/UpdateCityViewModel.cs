using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.CityDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateCityViewModel
    {
        public UpdateCityDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
