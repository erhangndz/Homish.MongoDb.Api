using DtoLayer.DTOS.BannerDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class UpdateBannerViewModel
    {
        public UpdateBannerDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
