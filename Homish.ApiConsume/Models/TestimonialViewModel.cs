using DtoLayer.DTOS.CityDtos;
using DtoLayer.DTOS.TestimonialDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class TestimonialViewModel
    {
        public List<ResultTestimonialDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
