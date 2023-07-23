using DtoLayer.DTOS.ContactDtos;
using DtoLayer.DTOS.PropertyDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class PropertyViewModel
    {
        public List<ResultPropertyDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
