using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.BannerDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateAboutViewModel
    {
        public UpdateAboutDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
