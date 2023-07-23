using DtoLayer.DTOS.MessageDtos;
using DtoLayer.DTOS.PropertyDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdatePropertyViewModel
    {
        public UpdatePropertyDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
