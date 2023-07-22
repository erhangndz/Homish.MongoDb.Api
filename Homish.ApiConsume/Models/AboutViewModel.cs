using DtoLayer.DTOS.AboutDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class AboutViewModel
    {
        public List<ResultAboutDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
