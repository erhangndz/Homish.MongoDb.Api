using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.ContactDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class ContactViewModel
    {
        public List<ResultContactDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
