
using DtoLayer.DTOS.CityDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class CityViewModel
    {
        public List<ResultCityDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
