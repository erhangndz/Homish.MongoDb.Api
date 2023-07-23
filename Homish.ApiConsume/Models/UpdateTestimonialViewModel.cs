using DtoLayer.DTOS.ContactDtos;
using DtoLayer.DTOS.TestimonialDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateTestimonialViewModel
    {
        public UpdateTestimonialDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
